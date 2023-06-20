import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
model : any={};
loggedin = false;
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }
  login(){
    this.accountService.login(this.model).subscribe({
      next: response=>{
        console.log(response);
        this.loggedin = true;
      },
      error: error =>console.log(error)
    })
    console.log(this.model);
  }
  
  logout(){
    this.loggedin=false;
  }

}
