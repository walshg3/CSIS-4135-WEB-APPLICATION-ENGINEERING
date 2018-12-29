import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { Form, FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  //When we do the login validation if the user is logged in, use this and refer to the angular equivelent for the react.js function
  //  componentWillMount()
  //  https://medium.com/@sho_mukai/angular-4-life-cycle-functions-and-the-equivalent-react-js-ones-for-fun-293c0742419

  model = new User();
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  submit(form: Form) {
    console.log('Submitted');
    this.authService.login(this.model).subscribe();
  }

}
