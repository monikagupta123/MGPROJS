import { Component, OnInit  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Iprovider } from  './provider';
import {  NgForm } from '@angular/forms';




@Component({
  templateUrl: './provider-registration.component.html',
  styleUrls: ['./provider-registration.component.css']
})
export class ProviderRegistrationComponent implements OnInit {
  pageTitle = 'Provider Registration';
  errorMessage = '';
  newUser:Iprovider | undefined;
  newId: number = 0;
  deleteDisable: boolean = true;
  providers : Iprovider[] =[];
  
    /* {
      "providerId": 1,
      "firstName": "Kathy",
      "lastName": "Worthen",
      "npiNumber": "06092022",
      "businessAddress": "Greenlanes Jax , FL, 32256",
      "telephoneNumber":"904-001-1234",
      "emailAddress":"abc@uhc.com"
  }, 
  {
    "providerId": 2,
    "firstName": "David",
    "lastName": "Warren",
    "npiNumber": "06092022",
    "businessAddress": "Greenlanes Jax , FL, 32256",
    "telephoneNumber":"904-001-1234",
    "emailAddress":"abc@uhc.com"
} */
  
  
  
   
  constructor(private route: ActivatedRoute,
              private router: Router
              ) {
                
  }

  

  ngOnInit(): void {
  }
  onBack(): void {
    this.router.navigate(['/providers']);

    
  }
  onClickSubmit(form:NgForm){
    this.newId = this.providers.length + 1;
    this.newUser = {
      providerId: this.newId,
      firstName : form.value.firstName,
      lastName: form.value.lastName,
      npiNumber : form.value.npiNumber,
      businessAddress: form.value.businessAddress,
      telephoneNumber : form.value.telephoneNumber,
      emailAddress: form.value.emailAddress
    };
     this.providers.push(this.newUser);
     form.resetForm();

     
      
  }

  deleteRow(id:number){
    for(let i = 0; i < this.providers.length; ++i){
        if (this.providers[i].providerId === id) {
            this.providers.splice(i,1);
        }
    }

    
    }
    resetForm(form: NgForm) {
      form.resetForm();
}
}
