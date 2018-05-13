import { Injector, Component, OnInit } from '@angular/core';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';
import { Field } from "../../../shared/models/field.model";
import { UserService } from "../../../shared/services/user.service";
import { Resource } from "../../../shared/models/resource.model";
import { ComponentFactoryService } from "../../../modules/component-factory/component-factory.service";

@Component({
    selector: 'logout-admin',
    templateUrl: './logout.admin.component.html'
})
export class LogoutAdminComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "LogoutComponent";

    constructor(public injector: Injector,
        public userService: UserService,
        public componentFactoryService: ComponentFactoryService) {
        super(injector);
    }

    ngOnInit()
    {
        this.logout();
    }

    logout() {
        this.httpService.post("/authentication/logout/", null)
            .subscribe(response => {
                this.httpService.getResources().subscribe(response => {
                    var resource = new Resource(response);
                    this.componentFactoryService.create(resource.loginPath);
                });
                this.userService.updateAuth();
            },
            response => {
                this.category.validateFieldsets(response);
            });
    }
}
