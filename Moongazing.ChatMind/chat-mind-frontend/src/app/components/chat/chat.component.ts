import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ChatService } from '../../../services/chatservice';

@Component({
  selector: 'app-chat',
  standalone: true, // Standalone olarak tanımlandı
  imports: [CommonModule, FormsModule], // Angular modülleri
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css'],
})
export class ChatComponent {
  question: string = '';
  answer: string = '';
  isLoading: boolean = false;

  constructor(private chatService: ChatService) {}

  askQuestion(): void {
    if (!this.question.trim()) {
      alert('Please enter a question.');
      return;
    }

    this.isLoading = true;

    this.chatService.askQuestion(this.question).subscribe(
      (response) => {
        this.answer = response.answer;
        this.isLoading = false;
      },
      (error) => {
        console.error('Error:', error);
        this.isLoading = false;
      }
    );
  }
}
