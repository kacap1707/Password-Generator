# Coder

You can easily create a password to your liking by chosing an option on the generator. You can also manage the length of your password. 

There are different ways to build your password:
```cs
a) var pass = new Password(); // you'll get by default 32 characters long password with at least one digit and at least one special                                          character 

b) var p1 = new Password(PasswordOptions.OnlyAlphabet, 16); // you can chose both the password option you wish and your desired length

c) var p2 = new Password(25); // you can also check only the length you want and the programm will generate a password with at least one                                    digit and at least one special character

d) var p3 = new Password("askd;fasfshdfksj 'l323;kj;adsfjk;"); // thus, you can write a password on your own (why not?! :-))

e) var p4 = new Password(PasswordOptions.OnlyAlphabet); // finally, you can just select the password option you like and get a 32                                                                      characters long password
```

As a choice, you can run the windows form application:
![Alt Text](https://raw.githubusercontent.com/kacap1707/Coder/master/1.jpg)
![ScreenShot](1.jpg)
![ScreenShot](https://raw.github.com/kacap1707/Coder/master/https://gyazo.com/ba9e8604b3f219e264c800f35c1359f5)
![ScreenShot](https://raw.githubusercontent.com/kacap1707/Coder/master/C:\Users\HP\Desktop\1.jpg)
