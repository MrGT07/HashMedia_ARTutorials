#include <TM1637.h>
#include <pitches.h>
TM1637 *_display = new TM1637(12, 13);

int songState = 0;
int melody[] = {
 NOTE_F4, NOTE_E4, NOTE_D4, NOTE_CS4,
 NOTE_C4, NOTE_B3, NOTE_AS3, NOTE_A3,
 NOTE_G3, NOTE_A3, NOTE_AS3, NOTE_A3, 
 NOTE_G3, NOTE_C4, 0, 
 
 NOTE_C4, NOTE_A3, NOTE_A3, NOTE_A3,
 NOTE_GS3, NOTE_A3, NOTE_F4, NOTE_C4, 
 NOTE_C4, NOTE_A3, NOTE_AS3, NOTE_AS3, 
 NOTE_AS3, NOTE_C4, NOTE_D4, 0, 
 
 NOTE_AS3, NOTE_G3, NOTE_G3, NOTE_G3,
 NOTE_FS3, NOTE_G3, NOTE_E4, NOTE_D4, 
 NOTE_D4, NOTE_AS3, NOTE_A3, NOTE_A3, 
 NOTE_A3, NOTE_AS3, NOTE_C4, 0,
 
 NOTE_C4, NOTE_A3, NOTE_A3, NOTE_A3,
 NOTE_GS3, NOTE_A3, NOTE_A4, NOTE_F4, 
 NOTE_F4, NOTE_C4, NOTE_B3, NOTE_G4, 
 NOTE_G4, NOTE_G4, NOTE_G4, 0,
 
 NOTE_G4, NOTE_E4, NOTE_G4, NOTE_G4,
 NOTE_FS4, NOTE_G4, NOTE_D4, NOTE_G4, 
 NOTE_G4, NOTE_FS4, NOTE_G4, NOTE_C4, 
 NOTE_B3, NOTE_C4, NOTE_B3, NOTE_C4, 0
};
int tempo[] = {
 8, 16, 8, 16,
 8, 16, 8, 16,
 16, 16, 16, 8,
 16, 8, 3,
 
 12, 16, 16, 16,
 8, 16, 8, 16,
 8, 16, 8, 16,
 8, 16, 4, 12,
 
 12, 16, 16, 16,
 8, 16, 8, 16,
 8, 16, 8, 16,
 8, 16, 4, 12,
 
 12, 16, 16, 16,
 8, 16, 8, 16,
 8, 16, 8, 16,
 8, 16, 4, 16,
 
 12, 17, 17, 17,
 8, 12, 17, 17, 
 17, 8, 16, 8,
 16, 8, 16, 8, 1 
};

unsigned long previousMillis1 = 0;
const long interval1 = 1500;

unsigned long previousMillis2 = 0;
const long interval2 = 100;
int displayStatus = 0;
int mode = 0;
bool countdown = false;
unsigned long previousMillis3 = 0;
const long interval3 = 1000;
int count = 20;
void setup() { 

 pinMode(9, INPUT);
 pinMode(10, OUTPUT);
 pinMode(11, OUTPUT);
 pinMode(2, INPUT);
 
 _display->set(5);
 _display->point(false);
 _display->init();
}
void loop() {
 if(mode == 0) {
 if(digitalRead(2) == HIGH) {
 delay(25);
 if(digitalRead(2) == HIGH) {
 countdown = true;
 }
 else {
 countdown = false;
 }
 }
 if(countdown) {
 showCountdown();
 }
 }
 else {
 toggleFreePlay(); 
 }
 if(digitalRead(10) == HIGH) {
 delay(25);
 if(digitalRead(10) == HIGH) {
 while(digitalRead(10) == HIGH) {
 buzz(11, NOTE_B0, 1000/24);
 }
 }
 }
 else
 sing();
}
void showCountdown() {
 unsigned long currentMillis = millis();
 if (currentMillis - previousMillis3 >= interval3) {
 previousMillis3 = currentMillis;
 --count;
 showNumber(count);
 if(count == 0) {
 countdown = false;
 count = 20;
 buzz(11, NOTE_B0, 1000/24); 
 delay(100);
 buzz(11, NOTE_B0, 1000/24);
 delay(100);
 buzz(11, NOTE_B0, 1000/24);
 }
 }
}
void showNumber(int number) {
 _display->display(0, 25);
 _display->display(3, 25);
	if(number == 10)
	{
		 _display->display(1,1);
	 _display->display(2,0);
	}
	else if(number > 9)
	{
	 _display->display(1,1);
	 int newVal = number - 10;
	 _display->display(2, newVal);
	}
	else
	{
		 _display->display(1,0);
	 _display->display(2,number);
	}
}
void toggleFreePlay() {
 unsigned long currentMillis = millis();
 if (currentMillis - previousMillis1 >= interval1) {
 previousMillis1 = currentMillis;
 if(displayStatus == 1) 
 showPlay();
 else
 showFree();
 }
}
void showPlay() {
 _display->display(0, 21);
 _display->display(1, 18);
 _display->display(2, 10);
 _display->display(3, 4);
 displayStatus = 2;
}
void showFree() {
 _display->display(0, 15);
 _display->display(1, 23);
 _display->display(2, 14);
 _display->display(3, 14);
 displayStatus = 1;
}
void buzz(int targetPin, long frequency, long length) {
 long delayValue = 1000000/frequency/2;
 long numCycles = frequency * length/ 1000;
 for (long i=0; i < numCycles; i++){
 digitalWrite(targetPin,HIGH);
 delayMicroseconds(delayValue);
 digitalWrite(targetPin,LOW);
 delayMicroseconds(delayValue);
 }
}
void sing() {
 unsigned long currentMillis = millis();
 if (currentMillis - previousMillis2 >= interval2) {
 previousMillis2 = currentMillis;
 int noteDuration = 1000 / tempo[songState];
 buzz(10, melody[songState], noteDuration);
 int pauseBetweenNotes = noteDuration;
 delay(pauseBetweenNotes);
 buzz(10, 0, noteDuration);
 
 ++songState;
 if(songState > 79) {
 songState = 14;
 } 
 }
}