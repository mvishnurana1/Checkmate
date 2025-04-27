import { Routes } from '@angular/router';
import { LangingPageComponent, NotFoundPageComponent, SigninPageComponent, SignupPageComponent } from './pages';

export const routes: Routes = [
    { path: '', component: LangingPageComponent },
    { path: 'signin', component: SigninPageComponent },
    { path: 'signup', component: SignupPageComponent },
    { path: '**', component: NotFoundPageComponent },
];
