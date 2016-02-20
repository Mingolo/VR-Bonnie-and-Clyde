using UnityEngine;
using System.Collections;

public class Initalising : MonoBehaviour {

    public GameObject Path_1;
    public GameObject Path_Left;
    public GameObject Path_Right;
    public GameObject previous, current, next;
    public int prev, cur, after;
    // Straight=0, Left=1,Right=2
    // y = +42 plus  so that the terrain starts at y=0
    public float x_offset, z_offset;

    /*      1 -> Left z+500,x+9 , y=-90*
            1 -> Right z+500, x-0.4 y=90*

            Right->straight(1) x+499, y=90*
            Right-> Left X+499, z-10 y=0

            Left-> Straight(1) z+490 y=0
            Left->Right z+500, y = 90 *
    */

     public  void setobj()
    {

        Vector3 pos;
        //Instantiate(Path_1, pos, Quaternion.Euler(0, 90, 0));

        switch (cur)
        {
            //current path is straight
            case 0:

                if (after == 1)
                {
                    x_offset += 9f;
                    z_offset += 500f;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, -90, 0));
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                if (after == 2)
                {
                    x_offset -= 0.4f;
                    z_offset += 500f;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, -90, 0));
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                break;
            //Current Path is Left
            case 1:
                if (after == 0)
                {
                    z_offset += 500f;

                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, 90, 0));
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                if (after == 2)
                {
                    x_offset -= 10f;
                    z_offset += 499f;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, 0, 0));
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                break;
            //Current path is Right
            case 2:
                if (after == 0)
                {

                    z_offset += 490f;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, 0, 0));
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                if (after == 1)
                {

                    z_offset += 500f;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, 90, 0));
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                break;
        }




        }
        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
