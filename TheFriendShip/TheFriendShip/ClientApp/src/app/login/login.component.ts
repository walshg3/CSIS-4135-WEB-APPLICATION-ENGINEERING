import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { Form } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { JwtModule } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model = new User();
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  submit(form: Form) {
    console.log('Submitted');

    //this.http.post('/api/auth/login', this.model).subscribe(status => console.log(status));
    this.authService.login(this.model).subscribe();
  }

}
