import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

/**
 * A service that centralizes all the CRUD operations needed on the API url found in the development environment.
 * 
 * It uses the Angular's `HttClient` class.
 */
@Injectable({
  providedIn: 'root'
})
export class HttpService {
	/**
	 * Injected instance of Angular's `HttpClient` used to make HTTP requests.
	 * It allows sending requests (GET, POST, etc.) to interact with APIs and handle responses.
	 * 
	 * @private
	 */
	private httpClient = inject(HttpClient);

	constructor() {}

	/**
	 * Performs an HTTP GET request to retrieve data from the server.
	 * 
	 * This method uses Angular's HTTP client to make a GET request to the specified endpoint and returns an observable
	 * containing the server's response. It can be used to fetch various types of data such as JSON or other response formats 
	 * depending on the server and the API.
	 *
	 * @param endpoint The URL or path of the endpoint to which the request should be sent.
	 *                 Example: '/api/users', '/products/list'
	 * 
	 * @returns An observable of type `T` that emits the server's response. The observable needs to be subscribed to in order to receive the response.
	 *          The generic type `T` allows specifying the expected type of the response (e.g., `User[]`, `Product`).
	 *
	 * @example
	 * // Example of usage with a specific type
	 * this.get<User>('/api/users/123').subscribe(user => {
	 *   console.log(user);
	 * });
	 * 
	 */
	get<T>(endpoint: string) : Observable<T> {
		return this.httpClient.get<T>(environment.baseApiURL + endpoint);
	}

	/**
	 * Performs an HTTP DELETE request to retrieve data from the server.
	 * 
	 * This method uses Angular's HTTP client to make a DELETE request to the specified endpoint and returns an observable
	 * containing the server's response. It can be used to fetch various types of data such as JSON or other response formats 
	 * depending on the server and the API.
	 *
	 * @param endpoint The URL or path of the endpoint to which the request should be sent.
	 *                 Example: '/api/users', '/products/list'
	 * 
	 * @returns An observable of type `T` that emits the server's response. The observable needs to be subscribed to in order to receive the response.
	 *          The generic type `T` allows specifying the expected type of the response (e.g., `User[]`, `Product`).
	 *
	 * @example
	 * // Example of usage with a specific type
	 * this.delete<User>('/api/users/123').subscribe(user => {
	 *   console.log(user);
	 * });
	 * 
	 */
	delete<T>(endpoint: string) : Observable<T> {
		return this.httpClient.delete<T>(environment.baseApiURL + endpoint);
	}

	/**
	 * Performs an HTTP PUT request to retrieve data from the server.
	 * 
	 * This method uses Angular's HTTP client to make a PUT request to the specified endpoint and returns an observable
	 * containing the server's response. It can be used to fetch various types of data such as JSON or other response formats 
	 * depending on the server and the API.
	 * 
	 * @param endpoint  The URL or path of the endpoint to which the request should be sent.
	 *                 Example: '/api/users', '/products/list'
	 * @param body The body of the HTTP request, which represents the data to be sent to the server.
     *             This should be an object that conforms to the expected structure for the specific API endpoint.
	 *             For example:
	 *             - To update a user: `{ "name": "John", "email": "john@example.com" }`
	 *             - To update a product: `{ "id": 123, "name": "New Product", "price": 25.99 }`
	 * 
	 * @returns An observable of type `T` that emits the server's response. The observable needs to be subscribed to in order to receive the response.
	 *          The generic type `T` allows specifying the expected type of the response (e.g., `User[]`, `Product`).
	 */
	put<T>(endpoint: string, body: T) : Observable<T> {
		return this.httpClient.put<T>(environment.baseApiURL + endpoint, body);
	}

	/**
	 * Performs an HTTP POST request to retrieve data from the server.
	 * 
	 * This method uses Angular's HTTP client to make a PUT request to the specified endpoint and returns an observable
	 * containing the server's response. It can be used to fetch various types of data such as JSON or other response formats 
	 * depending on the server and the API.
	 * 
	 * @param endpoint  The URL or path of the endpoint to which the request should be sent.
	 *                 Example: '/api/users', '/products/list'
	 * @param body The body of the HTTP request, which represents the data to be sent to the server.
     *             This should be an object that conforms to the expected structure for the specific API endpoint.
	 *             For example:
	 *             - To create a user: `{ "name": "John", "email": "john@example.com" }`
	 *             - To create a product: `{ "id": 123, "name": "New Product", "price": 25.99 }`
	 * 
	 * @returns An observable of type `T` that emits the server's response. The observable needs to be subscribed to in order to receive the response.
	 *          The generic type `T` allows specifying the expected type of the response (e.g., `User[]`, `Product`).
	 */
	post<T>(endpoint: string, body: T) : Observable<T> {
		return this.httpClient.post<T>(environment.baseApiURL + endpoint, body);
	}
}