import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root', // Standalone yapıya uygun
})
export class ChatService {
  private apiUrl = 'http://localhost:5000/api/chat/ask'; // Backend URL

  constructor(private http: HttpClient) {}

  askQuestion(question: string): Observable<any> {
    return this.http.post(this.apiUrl, { question });
  }
}
