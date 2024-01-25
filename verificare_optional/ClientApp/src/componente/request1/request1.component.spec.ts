// src/app/autori.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutoriService {
  private apiUrl = 'https://localhost:7107/api'; // Înlocuiți cu URL-ul real al API-ului

  constructor(private http: HttpClient) { }

  getAutori(): Observable<Autori[]> {
    return this.http.get<Autori[]>(`${this.apiUrl}`);
  }

  getAutorById(id: string): Observable<Autori> {
    return this.http.get<Autori>(`${this.apiUrl}/${id}`);
  }

  getCartiByAutorId(id: string): Observable<Carti[]> {
    return this.http.get<Carti[]>(`${this.apiUrl}/${id}/carti`);
  }

  postAutori(autori: Autori): Observable<Autori> {
    return this.http.post<Autori>(`${this.apiUrl}`, autori);
  }
}

interface Autori {
  id: string;
  nume: string;
  prenume: string;
  varsta: number;

}

interface Carti {
  id: string;
  nume_carte: string;
  nr_pagini: string;
}

