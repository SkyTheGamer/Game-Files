using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridCreation : MonoBehaviour
{
    public int scale = 5;
    public int Vscale = 5;
    public int chunkH = 100;
    public int chunkW = 100;
    public int chunks = 9;
    public int road = 3;
    public int buildingF = 3;
    public int rnd;
    public int RoadCheck;
    public GameObject Road;
    public GameObject grid;
    public GameObject building;
    public GameObject Border;
    public GameObject Coordinate;
    public Vector3 leftBottomLocation = new Vector3(0,0,0);
    public GameObject[,] gridArray;
    // Start is called before the first frame update
    void Awake()
    {
        RoadCheck = road;
        Road.transform.localScale = new Vector3((float) scale * 0.1f, Road.transform.localScale.y, (float) scale * 0.1f);
        Coordinate.transform.localScale = new Vector3((float) scale * 0.1f, Coordinate.transform.localScale.y, (float) scale * 0.1f);
        building.transform.localScale = new Vector3((float) scale, building.transform.localScale.y, (float) scale);
        Border.transform.localScale = new Vector3((float) scale * 0.1f, Border.transform.localScale.y, (float) scale * 0.1f);
        gridArray = new GameObject [chunkW * chunks * road * scale,chunkH * chunks * road * scale];
        GameObject newObject;

        for (int chunkX = 0; chunkX < chunks; chunkX++) {
            for (int chunkY = 0; chunkY < chunks; chunkY++) {
                rnd = Random.Range(0, 6);
                for (int tileX = 0; tileX < chunkW; tileX++) {
                    for (int tileY= 0; tileY < chunkH; tileY++) {
                        if (rnd == 0) {
                            newObject = Instantiate(Coordinate, new Vector3(leftBottomLocation.x + scale * (tileX + (chunkX * (chunkW + road))), rnd * Vscale, leftBottomLocation.z + scale * (tileY + (chunkY* (chunkH + road)))), Quaternion.identity);}
                        else {
                            newObject = Instantiate(building, new Vector3(leftBottomLocation.x + scale * (tileX + (chunkX * (chunkW + road))), rnd  * Vscale, leftBottomLocation.z + scale * (tileY + (chunkY* (chunkH + road)))), Quaternion.identity);
                            newObject.GetComponent<GridStats>().layer = rnd;   
                            newObject.transform.localScale = new Vector3(newObject.transform.localScale.x, newObject.GetComponent<GridStats>().layer * Vscale, newObject.transform.localScale.z);
                            newObject.transform.position = new Vector3(newObject.transform.position.x, 0 + newObject.transform.localScale.y/2, newObject.transform.position.z);

                        }
                        newObject.transform.SetParent(grid.transform);
                        newObject.GetComponent<GridStats>().x = (int) leftBottomLocation.x + (tileX + (chunkX * (chunkW + road)));
                        newObject.GetComponent<GridStats>().y = (int) leftBottomLocation.z + (tileY + (chunkY* (chunkH + road)));
                        newObject.GetComponent<GridStats>().layer = rnd;                        
                        gridArray[newObject.GetComponent<GridStats>().x,newObject.GetComponent<GridStats>().y] = newObject;
                        }
                    for (int roadX = 0; roadX < road; roadX++) {
                        if (chunkX != (chunks - 1)) {
                            for (int roadY = 0; roadY < chunkH; roadY++) {
                                newObject = Instantiate(Road, new Vector3(leftBottomLocation.x + scale * ((chunkW + (chunkX * (chunkW + road)) + roadX)), 0, leftBottomLocation.z + scale * ((chunkY * (chunkH + road)) + roadY)), Quaternion.identity);
                                newObject.GetComponent<GridStats>().x = (int) leftBottomLocation.x + ((chunkW + (chunkX * (chunkW + road)) + roadX));
                                newObject.GetComponent<GridStats>().y = (int) leftBottomLocation.z + ((chunkY * (chunkH + road)) + roadY);
                                newObject.GetComponent<GridStats>().layer = 0;  
                                newObject.transform.SetParent(grid.transform);
                                gridArray[newObject.GetComponent<GridStats>().x,newObject.GetComponent<GridStats>().y] = newObject;}}}
                }

        }
                if (chunkX != (chunks - 1)){                
                for (int roadX = 0; roadX < (chunkW * chunks + chunks * road - road); roadX++) {
                        for (int roadY = 0; roadY < road; roadY++) {
                            newObject = Instantiate(Road, new Vector3(leftBottomLocation.x + scale * (roadX), 0, leftBottomLocation.z + scale * (chunkH + (chunkX * (chunkH + road)) + roadY)), Quaternion.identity);
                            newObject.transform.SetParent(grid.transform);
                            newObject.GetComponent<GridStats>().x = (int) leftBottomLocation.x + roadX;
                            newObject.GetComponent<GridStats>().y = (int) leftBottomLocation.z + chunkH + (chunkX * (chunkH + road)) + roadY;
                            newObject.GetComponent<GridStats>().layer = 0;                                               
                            gridArray[newObject.GetComponent<GridStats>().x,newObject.GetComponent<GridStats>().y] = newObject;}}}
        }














        // for (int i = 0; i < chunkW; i++) {
        //     if (RoadCheck != road) {
        //         RoadCheck += 1;
        //     }
        //     if ((k == chunk)) {
        //         RoadCheck = 0;
        //         k = 0;
        //         }
        //     for (int j = 0; j < chunkH; j++ ) {
        //         // rnd = Random.Range(0, buildingF);
        //         // if (rnd == 0) {
        //         //     newObject = Instantiate(building, new Vector3(leftBottomLocation.x + scale * i, 0, leftBottomLocation.z + scale * j), Quaternion.identity);
        //         //     newObject.GetComponent<GridStats>().building = true;
        //         // }
        //         // else 
        //         if (RoadCheck == road) {
        //             newObject = Instantiate(Coordinate, new Vector3(leftBottomLocation.x + scale * i, 0, leftBottomLocation.z + scale * j), Quaternion.identity);}
        //         else
        //             {newObject = Instantiate(building, new Vector3(leftBottomLocation.x + scale * i, 0, leftBottomLocation.z + scale * j), Quaternion.identity);
        //                 } 
        //         // if (i == 0 || j == 0 || i == (chunkH - 1) || j == (chunkW - 1))
        //             // newObject = Instantiate(Border, new Vector3(i * scale , 0, j * scale),Quaternion.identity);
        //         // else if ((i % 2) == 0 || (j % 2) == 0) {
        //         //     newObject = Instantiate(Road, new Vector3(i * scale , 0, j * scale),Quaternion.identity);
        //         // }
        //         // else {
        //         //     newObject = Instantiate(Road, new Vector3(i * scale , 0, j * scale),Quaternion.identity);
        //         //     }
        //         newObject.transform.SetParent(grid.transform);
        //         newObject.GetComponent<GridStats>().x = i;
        //         newObject.GetComponent<GridStats>().y = j;
        //         gridArray[i,j] = newObject;
        //     }
        //     if (RoadCheck == road)
        //         k++;       
        // }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
