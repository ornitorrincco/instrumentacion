void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  i = 0;
  while(i <= 10000){
    Serial.println(i);
    delay(100);
    i++;
  }
}
