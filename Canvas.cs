using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

class Canvas
{
    private List<Color> pixels;
    private int width;
    private int height;

    public Canvas(int width, int height)
    {
        if (width  < 0) throw new Exception("Width must be positive");
        if (height < 0) throw new Exception("Height must be positive");

        pixels = Enumerable.Repeat(Color.White, width * height).ToList();
        this.width = width;
        this.height = height;
    }

    public void DrawPixel(int x, int y, Color colour)
    {
        if (x < 0) return;
        if (y < 0) return;
        if (x >= width) return;
        if (y >= height) return;

        int index = y * width + x;

        pixels[index] = colour;
    }

    public void DrawCircle(int cx, int cy, int radius, Color colour)
    {
        for (int y = cy - radius + 1; y <= cy + radius - 1; y++)
        {
            for (int x = cx - radius + 1; x <= cx + radius - 1; x++)
            {
                if (((x - cx) * (x - cx)) + ((y - cy) * (y - cy)) < (radius * radius))
                {
                    DrawPixel(x, y, colour);
                }
            }
        }
    }

    public void SaveToFile(string filename)
    {
        var image = new Bitmap(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int index = y * width + x;
                image.SetPixel(x, y, pixels[index]);
            } 
        }

        image.Save(filename);
    }
}