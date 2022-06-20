import { NgModule } from '@angular/core';
import { ProviderListComponent } from './provider-list.component';
import { ProviderRegistrationComponent } from './provider-registration.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    ProviderListComponent,
    ProviderRegistrationComponent
  ],
  imports: [
    RouterModule.forChild([
      { path: 'providers', component: ProviderListComponent },
      {
        path: 'registration',
        //canActivate: [ProductDetailGuard],
        component: ProviderRegistrationComponent
      }
    ]),
    SharedModule
  ]
})
export class ProviderModule { }
