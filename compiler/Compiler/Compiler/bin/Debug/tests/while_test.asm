extern _printf
extern _scanf
extern _strcmp
extern _strcat
extern _strcpy
extern _malloc
extern _memcpy
extern _free
section .text
global _main
_main:
push ebp
mov ebp, esp
sub esp, 4
lea ebx, [ebp -4]
push ebx
push IntF
call _scanf
add esp, 8
wslb0:
push 1
pop eax
cmp eax, 0
je wsle1
push 1
push dword [ebp -4]
pop ebx
pop eax
add ebx, eax
push ebx
pop eax
mov dword [ebp -4], eax
mov ebx, 10
push dword [ebp -4]
pop eax
cmp eax, ebx
jg lbl2
mov eax, 0
jmp lbl3
lbl2:
mov eax, 1
lbl3:
push eax
pop eax
cmp eax, 0
je lbl4
jmp wsle1
jmp lbl5
lbl4:
lbl5:
jmp wslb0
wsle1:
push dword [ebp -4]
push IntF
call _printf
add esp, 8
mov ebx, eax
mov eax, ebx
mov esp, ebp
pop ebp
ret


section .data
IntF dd "%d", 10, 0
StrF dd "%s", 10, 0
