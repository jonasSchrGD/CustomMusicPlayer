using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

class CustomTrackBar : Control
{
    public CustomTrackBar()
    {
        this.DoubleBuffered = true;
    }

    //mouse input
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (thumb.Contains(e.Location))
        {
            holdingThumb = true;
        }
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        holdingThumb = false;
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (holdingThumb)
        {
            value = e.Location.X / (float)Width;

            if (value < 0)
                value = 0;
            if (value > 1)
                value = 1;

            this.Invalidate();
        }
    }

    //draw
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        circleSize = Size.Height / 2;

        thumb.Width = circleSize;
        thumb.Height = circleSize;

        RectangleF track = new RectangleF();
        if (drawState == DrawingState.FullSizeBar)
        {
            track = DrawFullSizeBar(g);
        }
        else if (drawState == DrawingState.SmallBar)
        {
            track = DrawSmallBar(g);
        }

        thumb.X = track.X + (Width - circleSize) * value;
        if (thumb.X < 0)
            thumb.X = 0;
        thumb.Y = track.Y - ((circleSize - track.Height) / 2) - 0.5f;
        g.FillEllipse(new SolidBrush(thumbColor), thumb);
    }
    RectangleF DrawFullSizeBar(Graphics g)
    {
        RectangleF track = new RectangleF(0, (Height - circleSize) / 2, Width, circleSize);

        DrawRoundedBar(g, new SolidBrush(trackColor), track);

        track.Width = (track.Width - circleSize) * value + circleSize;
        DrawRoundedBar(g, new SolidBrush(progressColor), track);

        return track;
    }
    RectangleF DrawSmallBar(Graphics g)
    {
        RectangleF track = new RectangleF(circleSize / 2, (Height - circleSize / 3) / 2, Width - circleSize, circleSize / 3);

        g.FillRectangle(new SolidBrush(trackColor), track);

        track.Width = track.Width * value;
        g.FillRectangle(new SolidBrush(progressColor), track);

        track.X = 0;
        return track;
    }
    void DrawRoundedBar(Graphics g, Pen color, RectangleF position)
    {
        if (position.Width > 0 && position.Height > 0)
        {
            g.DrawEllipse(color, new RectangleF(position.X, position.Y, position.Height, position.Height));
            g.DrawEllipse(color, new RectangleF(position.X + position.Width - position.Height, position.Y, position.Height, position.Height));

            g.DrawRectangle(color, new Rectangle((int)position.Height / 2, (int)position.Y, (int)(Width - position.Height), (int)position.Height));
        }
    }
    void DrawRoundedBar(Graphics g, Brush color, RectangleF position)
    {
        if (position.Width > 0 && position.Height > 0)
        {
            g.FillEllipse(color, new RectangleF(position.X, position.Y - 0.5f, position.Height, position.Height));

            if (position.Width > position.Height)
                g.FillEllipse(color, new RectangleF(position.X + position.Width - position.Height, position.Y - 0.5f, position.Height, position.Height));

            g.FillRectangle(color, new RectangleF(position.Height / 2, position.Y, position.Width - position.Height, position.Height));
        }
    }

    //variables
    private DrawingState drawState = 0;
    private bool holdingThumb = false;
    private int circleSize = 0;
    private RectangleF thumb = new RectangleF();

    private float value = 0.1f;

    public enum DrawingState
    {
        FullSizeBar,
        SmallBar,
    }

    private Color trackColor = System.Drawing.Color.White;
    private Color progressColor = System.Drawing.Color.LightSkyBlue;
    private Color thumbColor = System.Drawing.Color.CornflowerBlue;

    public float Value
    {
        get
        {
            return value;
        }
    }
    public DrawingState DrawState
    {
        get
        {
            return drawState;
        }
        set
        {
            drawState = value;
        }
    }
    public Color TrackColor
    {
        get
        {
            return trackColor;
        }
        set
        {
            trackColor = value;
        }
    }
    public Color ProgressColor
    {
        get
        {
            return progressColor;
        }
        set
        {
            progressColor = value;
        }
    }
    public Color ThumbColor
    {
        get
        {
            return thumbColor;
        }
        set
        {
            thumbColor = value;
        }
    }
}