﻿
using System.Linq.Expressions;
using YouTube_App;

User u = new User("adam.bartl2001@seznam.cz","123Kočičí", new Server(new Website("https://youtube.com")));
u.OpenWebsite();