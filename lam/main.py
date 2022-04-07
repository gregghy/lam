#!/usr/bin/env python3
import cgi
def reg():
    print('Content-type: text/html\n')
    form = cgi.FieldStorage()
    u = open('nome_utente.txt','a')
    u.write(form['utente'].value+'/n')
    u.close()

    p = open('password.txt', 'a')
    p.write(form['passwd'].value+'/n')
    p.close()

    print('<html>')
    print('<head><tile>Primo programma in cgi</title></head>')
    print('<body>')
    print('<h2> registrazione effettuata</h2>')
    print('</body>')
    print('</html>')
reg()

def log():
    print('Content-type: text/html\n')
    form = cgi.FieldStorage()
    U=[]
    P=[]
    u = ''
    p = ''

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

    print('<h1>'+u+'</h1>')
    print('<h1>'+p+'</h1>')
log()