﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEngine;

public class Candy
{
    public int X { get; private set; }
    public int Y { get; private set; }  

    public Candy(int x, int y)
    {
        X = x;
        Y = y;
    }   
}
