using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contro : MonoBehaviour {

    private SquareGrig grig;
    private SquareCell[] cells;
    private SquareCell player;
    private SquareCell dester;

    private SquareCell now; // 当前位置的格子

    private List<SquareCell> open = new List<SquareCell>();
    private List<SquareCell> close = new List<SquareCell>();

    private bool over = false;

    private static Contro instantiate;
    public static Contro Instantiate{
        get{
            if(instantiate == null){
                instantiate = new Contro();
            }
            return instantiate;
        }
    }

    private void Awake()
    {
        Debug.Log("0000");
    }

    public void Init()
    {
        Debug.Log("+++++++++");
        grig = SquareGrig.Instantiate;
        cells = grig.cells;
        player = grig.player;
        dester = grig.dester;

       

        close.Add(player);
        now = player;

        while(true){
            if(over == true){
                break;
            }

            if (open.Count != 0){
                close.AddRange(open.ToArray());
                open.Clear();
            }
            Debug.Log(now.Line + "---" + now.Column);
            Sides(now);
            now.gameObject.GetComponent<Image>().color = Color.green;

        }
    }

    // 检查周边是否可加入open
    private void Sides(SquareCell squareCell){

        if(CreateZIsTrue(squareCell.Line-1,squareCell.Column) != true & cellIsIf(squareCell.Line - 1, squareCell.Column) != true)
        {
            squareCell.IsIf = true;
            squareCell.G = 10;
            open.Add(GetCell(squareCell.Line - 1, squareCell.Column));
        }
        if(CreateZIsTrue(squareCell.Line-1,squareCell.Column+1) != true & cellIsIf(squareCell.Line - 1, squareCell.Column + 1) != true){
            squareCell.IsIf = true;
            squareCell.G = 14;
            open.Add(GetCell(squareCell.Line - 1, squareCell.Column+1));
        }
        if(CreateZIsTrue(squareCell.Line-1,squareCell.Column-1) != true & cellIsIf(squareCell.Line - 1, squareCell.Column - 1) != true){
            squareCell.IsIf = true;
            squareCell.G = 14;
            open.Add(GetCell(squareCell.Line - 1, squareCell.Column-1));
        }
        if(CreateZIsTrue(squareCell.Line,squareCell.Column+1) != true & cellIsIf(squareCell.Line, squareCell.Column + 1) != true){
            squareCell.IsIf = true;
            squareCell.G = 10;
            open.Add(GetCell(squareCell.Line, squareCell.Column+1));
        }
        if(CreateZIsTrue(squareCell.Line,squareCell.Column-1) != true & cellIsIf(squareCell.Line, squareCell.Column - 1) != true){
            squareCell.IsIf = true;
            squareCell.G = 10;
            open.Add(GetCell(squareCell.Line, squareCell.Column-1));
        }
        if (CreateZIsTrue(squareCell.Line + 1, squareCell.Column) != true & cellIsIf(squareCell.Line + 1, squareCell.Column) != true)
        {
            squareCell.IsIf = true;
            squareCell.G = 10;
            open.Add(GetCell(squareCell.Line + 1, squareCell.Column));
        }
        if (CreateZIsTrue(squareCell.Line + 1, squareCell.Column + 1) != true & cellIsIf(squareCell.Line + 1, squareCell.Column + 1) != true)
        {
            squareCell.IsIf = true;
            squareCell.G = 14;
            open.Add(GetCell(squareCell.Line + 1, squareCell.Column + 1));
        }
        if (CreateZIsTrue(squareCell.Line + 1, squareCell.Column - 1) != true & cellIsIf(squareCell.Line + 1, squareCell.Column - 1) != true)
        {
            squareCell.IsIf = true;
            squareCell.G = 14;
            open.Add(GetCell(squareCell.Line + 1, squareCell.Column - 1));
        }

        if(over != true)
            now = GetMinF();
    }

    // 根据i j，判断是否在cells
    private bool CreateZIsTrue(int i,int j){
        if(i == dester.Line & j == dester.Column){
            over = true;
        }
        if ((i >= 0 & i < 10) & (j >= 0 & j < 15))
            if ((i*grig.heigth+(j+1))>=0 & (i*grig.heigth+(j+1))<cells.Length){
                return false;
        }

        return true;
    }

    private bool cellIsIf(int i,int j){
        if ((i >= 0 & i < 10) & (j >= 0 & j < 15))
            if (cells[i * grig.heigth + j].IsIf != true)
                return false;
        return true;
    }

    private SquareCell GetCell(int i,int j){
        return cells[i * grig.heigth + j];
    }

    // 对比open中F最小
    private SquareCell GetMinF(){
        if (open.Count == 0)
            Debug.Log("死路一条，走不了");

        for (int i = 0; i < open.Count;i++){
            open[i].H = (dester.Line - open[i].Line) + (dester.Column - open[i].Column);
            open[i].F = open[i].G + open[i].H;
        }

        for (int i = 0; i < open.Count;i++){
            for (int j = i + 1; j < open.Count;j++){
                if(open[i].F >= open[j].F){
                    SquareCell temp = open[i];
                    open[i] = open[j];
                    open[j] = temp;
                }
            }
        }
        //Debug.Log(open.Count);
        return open[0];
    }

}
