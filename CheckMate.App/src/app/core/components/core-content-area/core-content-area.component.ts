import { Component, Directive } from '@angular/core';

@Directive({ selector: 'core-content-area-header' })
export class CoreContentAreaHeader {}

@Directive({ selector: 'core-content-area-body' })
export class CoreContentAreaBody {}

@Component({
  selector: 'core-content-area',
  imports: [],
  templateUrl: './core-content-area.component.html',
  styleUrl: './core-content-area.component.scss'
})
export class CoreContentAreaComponent {}
