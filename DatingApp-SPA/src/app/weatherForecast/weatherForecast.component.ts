import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weatherforecast',
  templateUrl: './weatherForecast.component.html',
  styleUrls: ['./weatherForecast.component.css']
})
export class WeatherForecastComponent implements OnInit {
  weatherForecasts: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getWeatherForecasts();
  }

  getWeatherForecasts(){
    this.http.get('http://localhost:5000/weatherforecast').subscribe(respone =>{
      this.weatherForecasts = respone;
    }, error => {
      console.log(error);
    });
  }

}
