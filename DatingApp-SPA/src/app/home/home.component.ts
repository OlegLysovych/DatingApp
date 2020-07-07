import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  weatherForecasts: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getWeatherForecasts();
  }

  registerToggle() {
    this.registerMode = true;
  }

  getWeatherForecasts(){
    this.http.get('http://localhost:5000/weatherforecast').subscribe(respone =>{
      this.weatherForecasts = respone;
    }, error => {
      console.log(error);
    });
  }

  
  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }
}
