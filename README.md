# Specs

16 bit machine
64k memory - $0000 -> $FFFF
5 registers - A (8bits), B (8bits), D (16bits -> holds concatenated value of A and B), X(16bits), Y(16bits)

# Screen Output

4k of memory reserved for screen output(? do I need this? probably not really)
$A000 - $AFA0

80x25 screen

# Bytecodes and Mnemonics

## Basic Mnemonics

For loading data into registers, storing data in memory and ending execution.

### LDA - $01

Load 'A' Register - loads the operand into A
operand length 1 byte (for the 8 bits of the A register)
mnemonic length 2 bytes

### LDX - $02

Load 'X' register - loads operand into X
operand length 2 bytes
mnemonic length 3 bytes

### STA - $03

Store 'A' Register - store the value in A register to a location in memory

### END - $04

Terminates the program - the operand tells the program where to start up again.



|Mnemonic| Description| Example| What will this example do?|
|---|---|---|----|
|LDA - \$01|Assigns a value to our A register |LDA #\$2A| Assigns the hex value \$2A to the A register|
|LDX - \$02|Assigns a value to our X register |LDX #16000 |Assigns the number 16,000 to the X register|
|STA - \$03|Stores the value of the A register to a memory location|STA ,X| Stores the value of the A register to the memory location pointed to by the X register|
|END - \$04|Terminates the B32 program |END START |Terminate the program and tell our assembler that execution of our program should start at the START label |

## Comparator Mnemonics

Comparisons are assigned a byte result which is set out as follows.

| 1 byte ||||||||
|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|
|1|2|3|4|**5**|**6**|**7**|**8**|
|nothing|nothing|nothing|nothing|**Greater Than**|**Less Than**|**Not Equal**|**Equal**|

### CMPA - $05

Compares operand to value stored in 'A'.

### CMPB - $06

Compares operand to value stored in 'B'.

### CMPX - $07

Compares operand to value stored in 'X'.

### CMPY - $08

Compares operand to value stored in 'Y'.

### CMPD - $09

Compares operand to value stored in 'D'.

## Jump Mnemonics

Jump to another place in memory and continue execution.
The conditionals among these use the results of previous comparisons

### JMP - $0A

Jumps to a location in memory given by the operand and resumes execution

### JEQ - $0B

iff the previous comparison was equal:
Jumps to a location in memory given by the operand and resumes execution

### JNE - $0C

iff the previous comparison was not equal:
Jumps to a location in memory given by the operand and resumes execution

### JGT - $0D

iff the previous comparison was greater than:
Jumps to a location in memory given by the operand and resumes execution

### JLT - $0E

iff the previous comparison was less than.:
Jumps to a location in memory given by the operand and resumes execution


|Mnemonic| Description| Example| What will this example do?|
|--------|------------|--------|---------------------------|
|JMP - \$0A|Jumps to a specific location in memory and resumes execution| JMP&nbsp;#\$3000| Jumps to memory location \$3000 and resumes execution at this location|
|JEQ - \$0B|Jumps to a specific location in memory ONLY if the result of the last compare was equal|CMPA&nbsp;#\$6A <br>JEQ&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if it’s equal, the program jumps to memory location #\$3000 and resumes execution|
|JNE - \$0C|Jumps to a specific location in memory ONLY if the result of the last compare was NOT equal|CMPA&nbsp;#\$6A<br>JNE&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if it’s NOT equal, the program jumps to memory location #\$3000 and resumes execution|
|JGT - \$0D|Jumps to a specific location in memory ONLY if the result of the last compare was greater than the value| CMPA&nbsp;#\$6A <br>JGT&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if ‘A’ is greater than \$6A, the program jumps to memory location #\$3000 and resumes execution|
|JLT - \$0E| Jumps to a specific location in memory ONLY if the result of the last compare was less than the value |CMPA&nbsp;#\$6A<br>JLT&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if ‘A’ is less than \$6A, the program jumps to memory location #\$3000 and resumes execution|


# File Format of executables

|Data| Length| Description|
|---|---|---|
|“B32”| 3 Bytes |Our magic header number|
|&lt;Starting Address&gt; |2 Bytes |This is a 16-bit integer that tells our virtual machine where, in memory, to place our program.|
|&lt;Execution Address&gt; |2 Bytes |This is a 16-bit integer that tells our virtual machine where to begin execution of our program.|
|&lt;ByteCode&gt; |?? Bytes |This will be the start of our bytecode, which can be any length.|

# Assembler

Our assembler expects input in the format:

```
[Optional Label:]
<white space><mnemonic><white space><operand>[Optional white space]<newline>
```