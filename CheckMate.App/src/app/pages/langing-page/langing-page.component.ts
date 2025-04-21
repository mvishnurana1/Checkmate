import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { catchError, EMPTY, first, tap } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-langing-page',
  standalone: true,
  imports: [MatButtonModule],
  providers: [HttpClient],
  templateUrl: './langing-page.component.html',
  styleUrl: './langing-page.component.scss'
})
export class LangingPageComponent {
  constructor(
    readonly httpClient: HttpClient,
    private router: Router,
  ) {}

  login() {
    window.location.href = 'https://localhost:7086/login';

    const url = new URL(window.location.href);
    const token = url.searchParams.get('token');

    if (token) {
      console.log('JWT from URL:', token);
      localStorage.setItem('access_token', token);
    } else {
      window.location.href = 'https://localhost:7086/login';
      console.log('here');
    }
  }

  getWeatherData() {
    this.httpClient.get('https://localhost:7086/WeatherForecast').pipe(
      tap(x => {
        this.router.navigate(['/signin-google'])
        console.log(x);
      }),
      catchError((err) => {
        console.log(err);

        return EMPTY;
      })
    )
    .subscribe();
  }
}
