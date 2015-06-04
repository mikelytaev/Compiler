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
sub esp, 16
mov dword [ebp -4], 0
mov dword [ebp -8], 1
mov dword [ebp -12], 100
push 100
push IntF
call _printf
add esp, 8
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
mov dword [ebp -4], 1
mov dword [ebp -8], 10
mov dword [ebp -16], 0
wslb2:
mov ebx, 10
push dword [ebp -16]
pop eax
cmp eax, ebx
jl lbl0
mov eax, 0
jmp lbl1
lbl0:
mov eax, 1
lbl1:
push eax
pop eax
cmp eax, 0
je wsle3
push 1
push dword [ebp -16]
pop ebx
pop eax
add ebx, eax
push ebx
pop eax
mov dword [ebp -16], eax
push dword [ebp -16]
pop eax
mov dword [ebp -4], eax
jmp wslb2
wsle3:
push 10
push dword [ebp -4]
pop ebx
pop eax
add ebx, eax
push ebx
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
tstr0 dd " " , 0
