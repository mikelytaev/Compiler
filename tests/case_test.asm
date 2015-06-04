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
push dword [ebp -4]
push 1
pop eax
cmp eax, [esp]
jne lbl1
push 256
call _malloc
add esp, 4
push tstr0
push eax
call _strcpy
add esp, 8
push eax
push StrF
call _printf
add esp, 4
call _free
add esp, 4
jmp lbl0
lbl1:
push 2
pop eax
cmp eax, [esp]
jne lbl2
push 256
call _malloc
add esp, 4
push tstr1
push eax
call _strcpy
add esp, 8
push eax
push StrF
call _printf
add esp, 4
call _free
add esp, 4
jmp lbl0
lbl2:
push 3
pop eax
cmp eax, [esp]
jne lbl3
push 256
call _malloc
add esp, 4
push tstr2
push eax
call _strcpy
add esp, 8
push eax
push StrF
call _printf
add esp, 4
call _free
add esp, 4
jmp lbl0
lbl3:
lbl0:
mov ebx, eax
mov eax, ebx
mov esp, ebp
pop ebp
ret


section .data
IntF dd "%d", 10, 0
StrF dd "%s", 10, 0
tstr0 dd "uno" , 0
tstr1 dd "dos" , 0
tstr2 dd "thes" , 0
