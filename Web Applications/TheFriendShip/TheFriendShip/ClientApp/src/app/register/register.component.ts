import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { Form, FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model = new User();
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  submit(form: Form) {
    console.log('Submitted');

    console.log(this.model)
    console.log(form);
    if (this.model['password'] == this.model['confpassword']) {
      console.log("passwords match");
      alert("Success! Passwords match");
      //this.authService.register(this.model.username, this.model.password).subscribe(user => console.log(user));
    } else {
      console.log("passwords do not match");
      alert("Error! Passwords do not match");
    }
  }
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
// Tried to get form Validation working... 
///** @title Input with a custom ErrorStateMatcher */
//@Component({
//  selector: 'register.component',
//  templateUrl: './register.component.html',
//  styleUrls: ['./register.component.css'],
//})
//export class InputErrorStateMatcherExample {
//  emailFormControl = new FormControl('', [
//    Validators.required,
//    Validators.email,
//  ]);

//  matcher = new MyErrorStateMatcher();
//}

