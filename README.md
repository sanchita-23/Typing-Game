# Typing Game

**Overview**

Typing Game is a fun and engaging WPF-based desktop application designed to improve typing speed and accuracy.
Users are presented with random words or sentences to type within a countdown timer.
The game offers vibrant UI, real-time score tracking, and intuitive pause/resume functionality to provide an enjoyable experience for users of all skill levels.

**Features**

1. Timed Gameplay<br><br>
A 60-second countdown timer challenges users to type as many words as possible within the time limit.
The timer is clearly displayed and dynamically updates in real-time.

2. Word Display<br><br>
Displays random words or sentences from a predefined list.
Ensures no immediate repetition of words to maintain variety.
The displayed word updates as soon as the user types the current word correctly.

3. Pause/Resume Functionality<br><br>
Allows users to pause the timer during gameplay and resume it later.
Provides flexibility for interruptions, ensuring users don't lose progress.

4. Score Tracking<br><br>
Keeps track of the number of correctly typed words.
The score dynamically updates as users type correctly, offering instant feedback.

5. Input Validation<br><br>
Validates user input in real-time:<br><br>
Correct Input: Text appears in black.<br><br>
Partial Match: Text remains in black for valid partial input.<br><br>
Incorrect Input: Highlights the input in red for immediate feedback.<br><br>

6. Colorful User Interface<br><br>
Visually appealing design with vibrant colors to enhance the user experience.
Separate color schemes for different components:<br><br>
Timer: Red to signify urgency.<br><br>
Score: Green to signify success.<br><br>
Buttons: Bold colors like blue and green for easy visibility.

**Documentation**

Class: MainWindow<br><br>
The MainWindow class handles game logic, timer functionality, and user interface interactions.

Important Methods:<br><br>
MainWindow()<br><br>

Initializes UI components and sets default timer and score values.<br><br>
SetPlaceholderText()<br><br>

Sets a placeholder text ("Type here...") in the input box.<br><br>
InputTextBox_GotFocus()<br><br>

Clears placeholder text when the input box gains focus.<br><br>
InputTextBox_LostFocus()<br><br>

Restores placeholder text if the input box loses focus and is empty.<br><br>
StartGameButton_Click()<br><br>

Starts the game, initializes the timer, and loads the first word.<br><br>
ResumeGameButton_Click()<br><br>

Toggles between pausing and resuming the timer.<br><br>
StartGame()<br><br>

Resets the game, initializes the timer, and loads the first word.<br><br>
GameTimer_Elapsed()<br><br>

Handles timer ticks, decrementing the countdown and ending the game when the timer reaches zero.<br><br>
LoadNextWord()<br><br>

Randomly selects and displays the next word from the list.<br><br>
InputTextBox_TextChanged()<br><br>

Validates user input, updates the score for correct input, and highlights incorrect input.

**Setup Instructions**

Prerequisites<br><br>
Visual Studio (2019 or later)<br><br>
.NET Framework 4.7.2 or later

**Usage**

Launch the Typing Game application.
Click Start Game to begin the game.
Type the word displayed in the DisplayTextBox:<br><br>
Correct Input: Increases your score.<br><br>
Incorrect Input: Highlights the input in red.<br><br>
Use the Pause/Resume button to toggle the timer.
The game ends when the timer reaches 0, and your final score is displayed.
