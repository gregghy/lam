def reg():
    utente = input('Nome utente: ')
    passwd = input('Password: ')
    u = open('nome_utente.txt','a')
    u.write(utente+'\n')

    p = open('password.txt', 'a')
    p.write(passwd+'\n')

    u.close()
    p.close()
#reg()

def log():
    U=[]
    P=[]
    u = ''
    p = ''
    utente = 'gregghy'
    passwd = 'Flexi001'

    u = open('nome_utente.txt','r')
    U.append(u.readlines())

    p = open('password.txt', 'r')
    P.append(p.readlines())
    u.close()
    p.close()
    for i in U:
        if i == utente+'\n':
            u = 'OK'
        else:
            pass
    
    for i in P:
        if i == passwd+'\n':
            p = 'OK'
        else:
            pass

    print(utente)
    print(passwd)
log()
