import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  //username = '';
  //password = '';
  //error = '';
  //constructor(private authService: AuthService, private router: Router) { }

  //onLogin(): void {
  //  this.authService.login(this.email, this.password).subscribe((user: any) => {
  //    if (user) {
  //      if (user.role === 'admin') {
  //        this.router.navigate(['/admin']);
  //      } else if (user.role === 'seller') {
  //        this.router.navigate(['/seller']);
  //      } else {
  //        this.router.navigate(['/']);
  //      }
  //    } else {
  //      alert('فشل تسجيل الدخول');
  //    }
  //  });
  //}

  loginForm!: FormGroup;
  submitted = false;
  errorMessage = '';

  //constructor(
  //  private formBuilder: FormBuilder,
  //  private router: Router,
  //  private authService: AuthService
  //) {
  //  this.loginForm = this.formBuilder.group({
  //    username: ['', Validators.required],
  //    password: ['', Validators.required],
  //    rememberMe: [false]
  //  });
  //}
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) { }


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      rememberMe: [false],
    });
  }

  //OnLogin() {
  //  this.authService.login(this.username, this.password).subscribe({
  //    next: () => {
  //      const role = localStorage.getItem('role');
  //      if (role === 'Admin') this.router.navigate(['/admin']);
  //      else if (role === 'Seller') this.router.navigate(['/seller']);
  //      else this.router.navigate(['/buyer']);
  //    },
  //    error: err => {
  //      this.error = 'بيانات الدخول غير صحيحة';
  //    }
  //  });
  //}

  // Convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  //onSubmit() {
  //  this.submitted = true;

  //  // Stop here if form is invalid
  //  if (this.loginForm.invalid) {
  //    return;
  //  }

  //  // In a real app, you would authenticate with a server
  //  console.log('Login attempt:', this.loginForm.value);

  //  // Mock successful login
  //  localStorage.setItem('currentUser', JSON.stringify({
  //    username: this.loginForm.value.username
  //  }));

  //  // Navigate to profile page on successful login
  //  this.router.navigate(['/buyerdashboard']);
  //}
  onSubmit(): void {
    this.submitted = true;
    if (this.loginForm.invalid) return;

    this.authService.login(this.loginForm.value).subscribe({
      next: (res) => {
        const role = res.role.toLowerCase();
        if (role === 'admin') this.router.navigate(['/admin']);
        else if (role === 'seller') this.router.navigate(['/seller']);
        else this.router.navigate(['/buyer']);
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'فشل في تسجيل الدخول';
      }
    });
  }
}
