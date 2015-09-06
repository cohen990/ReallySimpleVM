# Specs

16 bit machine
64k memory - \$0000 -> \$FFFF
5 registers - A (8bits), B (8bits), D (16bits -> holds concatenated value of A and B), X(16bits), Y(16bits)

# Screen Output

4k of memory reserved for screen output(? do I need this? probably not really)
\$A000 - \$AFA0

80x25 screen

# Bytecodes and Mnemonics

## Basic Mnemonics

For loading data into registers, storing data in memory and ending execution.

|Mnemonic| Description| Example| What will this example do?|
|---|---|---|----|
|LDA<br>\$01|Assigns a value to our A register |LDA&nbsp;#\$2A| Assigns the hex value \$2A to the A register|
|LDX<br>\$02|Assigns a value to our X register |LDX&nbsp;#16000 |Assigns the number 16,000 to the X register|
|STA<br>\$03|Stores the value of the A register to a memory location|STA&nbsp;,X| Stores the value of the A register to the memory location pointed to by the X register|
|END<br>\$04|Terminates the B32 program |END&nbsp;START|Terminate the program and tell our assembler that execution of our program should start at the START label |

## Comparator Mnemonics

Comparisons are assigned to a comparison flag result which is set out as follows.

| 1 byte ||||||||
|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|
|1|2|3|4|**5**|**6**|**7**|**8**|
|nothing|nothing|nothing|nothing|**Greater Than**|**Less Than**|**Not Equal**|**Equal**|

|Mnemonic|Description|Example| What will this example do?|
|--------|--------|--------|--------|
|CMPA<br>\$05|Compares the value of the ‘A’ register |CMPA&nbsp;#\$20|Compares the value of the ‘A’|register with \$20 and sets our internal “compare registers” appropriately|
|CMPB<br>\$06|Compares the value of the ‘B’ register|CMPB&nbsp;#\$20| Compares the value of the ‘B’ register with \$20 and sets our internal “compare registers” appropriately|
|CMPX<br>\$07|Compares the value of the ‘X’ register|CMPX&nbsp;#\$A057| Compares the value of the ‘X’ register with \$A057 and sets our internal “compare registers” appropriately|
|CMPY<br>\$08|Compares the value of the ‘Y’ register|CMPY&nbsp;#\$A057|Compares the value of the ‘Y’ register with \$A057 and sets our internal “compare registers” appropriately|
|CMPD<br>\$09|Compares the value of the ‘D’ register|CMPD&nbsp;#\$A057| Compares the value of the ‘D’ register with \$A057 and sets our internal “compare registers” appropriately|


## Jump Mnemonics

|Mnemonic| Description| Example| What will this example do?|
|--------|------------|--------|---------------------------|
|JMP<br>\$0A|Jumps to a specific location in memory and resumes execution| JMP&nbsp;#\$3000| Jumps to memory location \$3000 and resumes execution at this location|
|JEQ<br>\$0B|Jumps to a specific location in memory ONLY if the result of the last compare was equal|CMPA&nbsp;#\$6A <br>JEQ&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if it’s equal, the program jumps to memory location #\$3000 and resumes execution|
|JNE<br>\$0C|Jumps to a specific location in memory ONLY if the result of the last compare was NOT equal|CMPA&nbsp;#\$6A<br>JNE&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if it’s NOT equal, the program jumps to memory location #\$3000 and resumes execution|
|JGT<br>\$0D|Jumps to a specific location in memory ONLY if the result of the last compare was greater than the value| CMPA&nbsp;#\$6A <br>JGT&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if ‘A’ is greater than \$6A, the program jumps to memory location #\$3000 and resumes execution|
|JLT<br>\$0E| Jumps to a specific location in memory ONLY if the result of the last compare was less than the value |CMPA&nbsp;#\$6A<br>JLT&nbsp;#\$3000|Compares the value of the ‘A’ register to \$6A and if ‘A’ is less than \$6A, the program jumps to memory location #\$3000 and resumes execution|

## Advanced Mnemonics

|Mnemonic| Description| Example |What will this example do?|
|--------|------------|---------|--------------------------|
|INCA<br>\$0F|Increment the value in the ‘A’ register by 1 |INCA| Increment the value of the ‘A’register by 1|
|INCB<br>\$10|Increment the value in the ‘B’ register by 1|INCB| Increment the value of the ‘B’ register by 1|
|INCX<br>\$11|Increment the value in the ‘X’ register by 1 |INCX| Increment the value of the ‘X’ register by 1|
|INCY<br>\$12|Increment the value in the ‘Y’ register by 1 |INCY| Increment the value of the ‘Y’ register by 1|
|INCD<br>\$13|Increment the value in the ‘D’ register by 1 |INCD| Increment the value of the ‘D’ register by 1|
|DECA<br>\$14|Decrement the value in the ‘A’ register by 1 |DECA| Decrement the value of the ‘A’ register by 1|
|DECB<br>\$15|Decrement the value in the ‘B’ register by 1 |DECB| Decrement the value of the ‘B’ register by 1|
|DECX<br>\$16|Decrement the value in the ‘X’ register by 1 |DECX| Decrement the value of the ‘X’ register by 1|
|DECY<br>\$17|Decrement the value in the ‘Y’ register by 1 |DECY| Decrement the value of the ‘Y’ register by 1|
|DECD<br>\$18|Decrement the value in the ‘D’ register by 1|DECD| Decrement the value of the ‘D’ register by 1|
|ROLA<br>\$19|Rotate ‘A’ register to the left| ROLA| Rotates ‘A’ register to the left|
|ROLB<br>\$1A|Rotate ‘B’ register to the left| ROLB| Rotates ‘B’ register to the left|
|RORA<br>\$1B|Rotate ‘A’ register to the right| RORA |Rotates ‘A’ register to the right|
|RORB<br>\$1C|Rotate ‘B’ register to the right |RORB| Rotates ‘B’ register to the right|
|ADCA<br>\$1D|Adds 1 to the value in ‘A’ register, IF carry flag is set|ADCA| Adds 1 to the value in ‘A’ register, IF carry flag is set |
|ADCB<br>\$1E|Adds 1 to the value in ‘B’ register, IF carry flag is set|ADCB| Adds 1 to the value in ‘B’ register, IF carry flag is set|
|ADDA<br>\$1F|Adds a value to the ‘A’ register |ADDA&nbsp;#\$30 |Adds \$30 to the value in ‘A’ register, storing the value in ‘A’ register|
|ADDB<br>\$20|Adds a value to the ‘B’ register |ADDB&nbsp;#\$30| Adds \$30 to the value in ‘B’ register, storing the value in ‘B’ register|
|ADDAB<br>\$21|Adds the value of the ‘A’ register to the value of the ‘B’ register and stores the result in the ‘D’ register|ADDAB| Adds the value of the ‘A’ register with the value of the ‘B’ register, storing the result in the ‘D’ register|
|LDB<br>\$22| Loads a value into the ‘B’ register |LDB&nbsp;#\$A0| Places \$A0 in the ‘B’ register|
|LDY<br>\$23|Loads a value into the ‘Y’ register|LDY&nbsp;#\$89FF| Places \$89FF in the ‘Y’ register|

# Flags

Flags are used to store state in the machine.

## Comparison Flag

The comparison flag is set out as follows:

| 1 byte ||||||||
|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|
|1|2|3|4|**5**|**6**|**7**|**8**|
|nothing|nothing|nothing|nothing|**Greater Than**|**Less Than**|**Not Equal**|**Equal**|

It is used to store the result of a comparison operation.

## Overflow flag

This is a single bit. It is flipped when a mathematical operation overflows.

## Carry flag

A single bit. Used to "carry" bits from a bit shift operation

The flag byte in this machine looks like:

| 1 byte ||||||||
|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|:-----:|
|1|2|3|4|5|6|**7**|**8**|
|nothing|nothing|nothing|nothing|nothing|nothing|**Carry**|**Overflow**|

The compare flag is stored in a separate byte.

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