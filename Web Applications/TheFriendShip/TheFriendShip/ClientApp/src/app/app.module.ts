import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './modules/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { Routes, RouterModule } from '@angular/router';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { LoginPageComponent } from './login-page/login-page.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    LoginPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FlexLayoutModule,
    HttpClientModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:*', 'https://thefriendshipannerd.azurewebsites.net/api/auth/login'],
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
