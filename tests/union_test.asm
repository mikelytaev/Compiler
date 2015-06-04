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
mov dword [ebp -4], 10
push 10
push IntF
call _printf
add esp, 8
mov dword [ebp -4], 20
push 20
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
