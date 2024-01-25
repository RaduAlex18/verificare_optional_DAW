// src/app/autori-list.component.ts
import { Component, OnInit } from '@angular/core';
import { AutoriService } from './request1.component.spec';

@Component({
  selector: 'app-autori-list',
  template: `
    <h2>Lista Autorilor</h2>
    <ul>
      <li *ngFor="let autor of autori">
        {{ autor.nume }} {{ autor.prenume }} ({{ autor.varsta }} ani)
      </li>
    </ul>
  `,
  styles: []
})
export class AutoriListComponent implements OnInit {
  autori: Autori[];

  constructor(private autoriService: AutoriService) { }

  ngOnInit(): void {
    this.autoriService.getAutori().subscribe(
      data => this.autori = data,
      error => console.error('Error getting autori:', error)
    );
  }
}
