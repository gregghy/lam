import os
a = input('Inserisci il test da cercare: ')
B = []
D= []
for nomedir, nomesub, nomefile in os.walk('/home/gregghy/lam/serie2'):
    for i in nomefile:
        if i[-4:] == '.txt':
            B.append(nomedir+'/'+i)
print(D)
index = -1
for i in B:
    f = open(i, 'r')
    t = ''
    for i in f:
        t=t+i
    l = 0
    for i in t:
        l = l+1
    n = 0
    for i in a:
        n=n+1
    q = 0
    index = index+1
    while True:
        if t[q:n] == a:
            print('There is "'+a+'" in '+B[index])
            break;
        else:
            q = q+1
            n = n+1
            if n > l:
                print('There is not "'+a+'" in '+B[index])
                break;
    f.close()
   



    