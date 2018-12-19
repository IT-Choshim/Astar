using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareCell : MonoBehaviour {

    private bool isIf = false;   // true ：未被hinder player dester占用
    private bool isDest = false; // 终点
    private int line;   // 行数
    private int column; // 列数
    private int z;  // 所在cells索引

    private int f;
    private int g;  // 距起点
    private int h;  // 距终点

    public bool IsIf{
        get { return isIf; }
        set { isIf = value; }
    }

    public bool IsDest{
        get { return isDest; }
        set { isDest = value; }
    }

    public int Line{
        get { return line; }
        set { line = value; }
    }

    public int Column{
        get { return column; }
        set { column = value; }
    }

    public int Z{
        get { return z; }
        set { z = value; }
    }

    public int F{
        get { return f; }
        set { f = value; }
    }

    public int G{
        get { return g; }
        set { g = value; }
    }

    public int H{
        get { return h; }
        set { h = value; }
    }


}
