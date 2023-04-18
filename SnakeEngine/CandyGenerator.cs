using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEngine;

internal class CandyGenerator
{

    private int xScope;
    private int yScope;
    private Random random;

    public CandyGenerator(int fieldWidth, int fieldHeight)
    {
        xScope = fieldWidth;
        yScope = fieldHeight;
        random = new Random();
    }

    public Candy Generate()
    {
        int x = random.Next(1, xScope);
        int y = random.Next(1, yScope);
        return new Candy(x, y);
    }
}

