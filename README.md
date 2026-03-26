[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/hZIAsDPT)
# CSCI 1260 — Project

### Build and Run 
Most IDEs have a button to build and run just by clicking it, but the following should be the appropriate instructions 
```bash 
dotnet build 
Dotnet run --project CardGameWar 
``` 

### Player Count 
Player count is decided by the player and input, selected from 1-3 computers. These 1-3 computers and the 1 human player make the player count 2-4 total. 


### General Note 
The general logic of War: 

1. winner of the round is decided by the value of the cards, if two cards of the same value are placed, everyone places one more card each and the winner will get all of the cards on the table. 
2. once a player runs out of cards, they will be removed from the game, and their cards redispersed to the remaining players. 
