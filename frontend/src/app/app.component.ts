import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpService } from './core/services/http.service';
import { OnInit } from '@angular/core';
import { environment } from '../environments/environment.development';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  private httpService = inject(HttpService); 
  	title = 'spotify-like';

	  ngOnInit(): void {
		  this.httpService.get(environment.artist.byName.replace("XXXX", "Drake")).subscribe((value)=>{
			console.log(value);
		});
	}
}
