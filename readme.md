компилятор в asm x86 (nasm)

бинарник bin/compiler.exe
трансляция в asm:
compiler.exe input.txt output.asm
компиляция output.asm
nasm -f win32 output.asm && gcc output.obj && a.exe
