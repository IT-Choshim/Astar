using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareGrig : MonoBehaviour {

    public int width;   // 10
    public int heigth;  // 15

    [SerializeField]
    private SquareCell cellPrefab;   // SquareCell
    [SerializeField]
    private SquareCell cellPlayer;   // Player
    [SerializeField]
    private SquareCell cellHinder;   // Hinder
    [SerializeField]
    private SquareCell cellDester;   // Dester


    public SquareCell[] cells;
    public SquareCell player;
    // private SquareCell[] hinders;
    public SquareCell dester;

    private int z = 0;

    private static SquareGrig _Instantiate;
    public static SquareGrig Instantiate{
        get{
            if(_Instantiate == null){
                _Instantiate = GameObject.FindObjectOfType<SquareGrig>();
            }
            return _Instantiate;
        }
    }

    private void Start()
    {
        cells = new SquareCell[width * heigth];
        //hinders = new SquareCell[];
        for (int i = 0; i < width;i++){
            for (int j = 0; j < heigth;j++){
                //if (z != 0)
                   // z++;
                InstantiateCell(i, j, z);

                if(i >= 3 & i<8)
                    if(j%i == 0)
                        InstantiateHinder(i, j, z);

                if(i == 1 & j ==3)
                    InstantiatePlayer(i, j, z);

                if(i == 9 & j == 12)
                    InstantiateDester(i, j, z);

                z++;
            }
        }
        //for (int i = 0; i < cells.Length;i++){
        //    Debug.Log(cells[i]);
        //}
        Contro.Instantiate.Init();

    }

    private void InstantiateCell(int i,int j,int z){
        Vector3 pos;
        pos.x = i * 100f;
        pos.y = j * 100f;
        pos.z = 0f;

        SquareCell cell = Instantiate<SquareCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = pos;
        cell.Line = i;
        cell.Column = j;
        cell.Z = z;
        cells[z] = cell;
    }

    // Player
    private void InstantiatePlayer(int i,int j,int z){
        Vector3 pos;
        pos.x = i * 100f;
        pos.y = j * 100f;
        pos.z = 0f;

        player = Instantiate<SquareCell>(cellPlayer);
        player.transform.SetParent(transform, false);
        player.transform.localPosition = pos;
        player.IsIf = true;
        player.Line = i;
        player.Column = j;
        cells[z] = player;
    }

    // Dester
    private void InstantiateDester(int i,int j,int z){
        Vector3 pos;
        pos.x = i * 100f;
        pos.y = j * 100f;
        pos.z = 0f;

        dester = Instantiate<SquareCell>(cellDester);
        dester.transform.SetParent(transform, false);
        dester.transform.localPosition = pos;
        dester.IsIf = true;
        dester.IsDest = true;
        dester.Line = i;
        dester.Column = j;
        cells[z] = dester;
    }

    // Hinder
    private void InstantiateHinder(int i,int j,int z){
        Vector3 pos;
        pos.x = i * 100f;
        pos.y = j * 100f;
        pos.z = 0f;

        SquareCell cell = Instantiate<SquareCell>(cellHinder);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = pos;
        cell.IsIf = true;
        cell.Line = i;
        cell.Column = j;
        cells[z] = cell;
        //Debug.Log(cells[z]);
    }
}
