a = input('Inserisci il tuo testo: ')
f = open("file.txt","r")
t = ''
for i in f:
    t=t+i
n = 0
for i in a:
    n=n+1
q = 0
while True:
    if t[q:n] == a:
        print('yes')
        break;
    else:
        q = q+1
        n = n+1
f.close()