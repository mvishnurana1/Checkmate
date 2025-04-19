import { Component } from '@angular/core';
import { NavigationComponent } from './layout';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NavigationComponent],
  template: '<app-navigation />',
})
export class AppComponent {}
