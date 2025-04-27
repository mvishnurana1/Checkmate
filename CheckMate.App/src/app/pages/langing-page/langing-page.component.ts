import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-langing-page',
  standalone: true,
  imports: [MatButtonModule, MatToolbarModule],
  providers: [HttpClient],
  templateUrl: './langing-page.component.html',
  styleUrl: './langing-page.component.scss'
})
export class LangingPageComponent {
  constructor(
    readonly httpClient: HttpClient,
  ) {}
}
