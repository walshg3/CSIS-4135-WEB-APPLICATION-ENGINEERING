import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginPageComponent },
  { path: 'signup', redirectTo: '/register', pathMatch: 'full' },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
