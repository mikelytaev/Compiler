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
sub esp, 12
push 256
call _malloc
add esp, 4
push tstr1
push eax
call _strcpy
add esp, 8
push eax
pop eax
mov dword [ebp -4], eax
push 256
call _malloc
add esp, 4
push eax
pop eax
mov [ebp -8], eax
push dword [ebp -8]
push StrF
call _scanf
add esp, 8
push 256
call _malloc
add esp, 4
push eax
push dword [ebp -8]
push eax
call _strcpy
add esp, 8
push 256
call _malloc
add esp, 4
push tstr3
push eax
call _strcpy
add esp, 8
push eax
call _strcat
mov ebx, eax
add esp, 4
call _free
add esp, 4
push ebx
pop eax
mov dword [ebp -12], eax
push 256
call _malloc
add esp, 4
push eax
push dword [ebp -12]
push eax
call _strcpy
add esp, 8
push StrF
call _printf
add esp, 4
call _free
add esp, 4
mov ebx, eax
push dword [ebp -4]
call _free
add esp, 4
push dword [ebp -8]
call _free
add esp, 4
push dword [ebp -12]
call _free
add esp, 4
mov eax, ebx
mov esp, ebp
pop ebp
ret


section .data
IntF dd "%d", 10, 0
StrF dd "%s", 10, 0
tstr0 dd "hello" , 0
tstr1 dd "hello" , 0
tstr2 dd "" , 0
tstr3 dd "hello___" , 0
