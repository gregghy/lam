import os
b=[]
for nomedir, nomesub, nomefile in os.walk('/home/gregghy/lam/serie2'):
    for i in nomefile:
        b.append(nomedir+'/'+i)
print(b)