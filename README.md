# Specs

16 bit machine
64k memory - $0000 -> $FFFF
5 registers - A (8bits), B (8bits), D (16bits -> holds concatenated value of A and B), X(16bits), Y(16bits)

# Screen Output

4k of memory reserved for screen output(? do I need this? probably not really)
$A000 - $AFA0

80x25 screen

# Bytecodes and Mnemonics

## LDA - $01

Load 'A' Register - loads the operand into A
operand length 1 byte (for the 8 bits of the A register)
mnemonic length 2 bytes

## LDX - $02

Load 'X' register - loads operand into X
operand length 2 bytes
mnemonic length 3 bytes

## STA - $03

Store 'A' Register - store the value in A register to a location in memory

## END - $04

Terminates the program - the operand tells the program where to start up again.


|Mnemonic| Description| Example| What will this example do?|
|---|---|---|----|
|LDA - \$01|Assigns a value to our A register |LDA #\$2A| Assigns the hex value \$2A to the A register|
|LDX - \$02|Assigns a value to our X register |LDX #16000 |Assigns the number 16,000 to the X register|
|STA - \$03|Stores the value of the A register to a memory location|STA ,X| Stores the value of the A register to the memory location pointed to by the X register|
|END - \$04|Terminates the B32 program |END START |Terminate the program and tell our assembler that execution of our program should start at the START label |