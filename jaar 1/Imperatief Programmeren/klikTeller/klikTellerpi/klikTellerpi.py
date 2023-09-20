from tkinter import Frame
from tkinter import Frame, Entry, Button, Label, Tk


scherm = Frame();
scherm.configure(background="lightBlue");
scherm.configure(width=200, height=100);
scherm.pack();

count = 0;

knop = Button(scherm);
uitkomst = Label(scherm);


knop.place(x= 20, y=32);
uitkomst.place(x=110, y=34);

knop.configure(text="++");
uitkomst.configure(text=count);

knop.configure(width=10);
uitkomst.place(width=80);

def Incrementer():
    global count;
    count += 1;
    uitkomst.configure(text=count);
    
    

knop.configure(command=Incrementer);
scherm.mainloop();