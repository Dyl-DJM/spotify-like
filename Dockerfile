#name of the image chosen
FROM mcr.microsoft.com/dotnet/aspnet
#where the application will live
#and where future run command will run from
WORKDIR .


FROM mcr.microsoft.com/dotnet/sdk:8.0

# Install the application dependencies
#copy host to working directory data

# Copy in the source code
#COPY src ./src
#COPY . .
EXPOSE 4200
# Setup an app user so the container doesn't run as the root user
#useless here
#RUN useradd app
#USER app

#the command to run front-end (angular) app
#CMD ["./angular/ng", "serve", "--open", "0.0.0.0", "--port", "8080"]


#equivalent to "cd", in order to go to the angular 
# file content
WORKDIR /angular

# source : https://www.docker.com/blog/docker-best-practices-choosing-between-run-cmd-and-entrypoint/
# These commands are executed during the image build process, and each RUN instruction creates a new layer in the Docker image. 
# For example, if you create an image that requires specific software or libraries installed, you would use RUN to execute the necessary installation commands.
#in our case we will install angular last version


# Install Node.js and Yarn
#RUN 
#yarn add @angular/cli

#already exists in global environment thus cause error...
#RUN npm install --global yarn



#INSTALL YARN (BEGIN)

#install yarn directly
#IT'S Compulsory to enable docker to download node
FROM node:22.9.0

#Install some dependencies

WORKDIR /usr/app

#precise that the install has to work in the environment of the folder "./angular"
COPY ./angular /usr/app

#it must be installed exactly here
RUN npm install

# Install curl and apt-transport-https to handle https sources

RUN apt-get update && apt-get install -y \
    curl \
    apt-transport-https \
    lsb-release \
    gnupg
# Install yarn using the official Yarn repo
RUN curl -sL https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add - && \
    echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list && \
    apt-get update && \
    apt-get install -y yarn

#INSTALL YARN (END)
#COPY ./ /angular

#INSTALL ANGULAR tools (BEGIN)
RUN yarn add @angular-devkit/architect 
RUN yarn add @angular/cli@19.2.7 
#RUN npm install -g npm@11.3.0

#WORKDIR /angular

#COPY package.json .

#RUN npm install --dev
#RUN npm i -g @angular/cli
RUN npm update

#go to the "./angular" project folder
WORKDIR ./angular

#start is equivalent
#for ng serve --host 0.0.0.0 (look at package.json in scipts)
#RUN npm start --host 
#RUN npm start

RUN npm start
#CMD ["npm", "start"]

#RUN ng "serve", "--host", "0.0.0.0", "--port", "4200"]



