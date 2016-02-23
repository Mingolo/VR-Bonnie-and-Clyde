using UnityEngine;
using System.Collections;

public class Initalising : MonoBehaviour {

    public GameObject Path_1;
    public GameObject Path_Left;
    public GameObject Path_Right;
    public GameObject previous, current, next;
    private int prev, cur, after,dir;
    bool isCheck;
    bool isZ;
    // Dir or direction is same as below
    // Straight=0, Right=1, Left=2,
    // y = +42 plus  so that the terrain starts at y=0
    public float x_offset, z_offset;
    private float x_check, z_check;

    /*      1 -> Left z+500,x+9 , y=-90*
            1 -> Right z+500, x-0.4 y=90*

            Right->straight(1) x+499, y=90*
            Right-> Left X+499, z-10 y=0

            Left-> Straight(1) z+490 y=0
            Left->Right z+500, y = 90 *
    */

     public  void Call_Map( int ne)
    {

        Vector3 pos;
        //Instantiate(Path_1, pos, Quaternion.Euler(0, 90, 0));
        after = ne;
        isCheck = true;
        switch (cur)
        {
            //current path is straight
            case 0:

                if (after == 2 && dir==0) //Straight and then Left
                {
                    x_offset += 9f;
                    z_offset += 500f;
                    z_check = z_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, -90, 0));
                    dir = 2;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;

                }
                if (after == 1 && dir==0)   //Straight and then right
                {
                    x_offset -= 0.4f;
                    z_offset += 500f;
                    z_check = z_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Right, pos, Quaternion.Euler(0, 90, 0));
                    dir = 1;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                if (after == 2 && dir ==1 )//Right and then Left
                {
                    z_offset -= 9f;
                    x_offset += 500f;
                    x_check = x_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, 0, 0));
                    dir = 0;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;

                }
                if (after == 0 && dir == 1)//Right path continue Straight
                {
                    x_offset += 500f;
                    x_check = x_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, 90, 0));
                    dir = 1;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;

                }
                if (after == 0 && dir == 2)//Left path continue straight
                {
                    x_offset -= 500f;
                    x_check = x_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, -90, 0));
                    dir = 2;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;

                }

                if (after == 1 && dir==2) //Left and then Right
                {
                    z_offset += 0.4f;
                    x_offset -= 500f;
                    x_check = x_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Right, pos, Quaternion.Euler(0, 0, 0));
                    dir = 0;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                break;
            //Current Path is Right
            case 1:
                if (after == 0 && dir == 0)
                {
                    z_offset += 500f;
                    z_check = z_offset;

                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, 0, 0));
                    dir = 0;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                if (after == 0 && dir == 1)
                {
                    x_offset += 500f;
                    x_check = x_offset;

                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, 90, 0));
                    dir = 1;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                if (after == 2 && dir == 0)
                {
                    x_offset -= 10f;
                    z_offset += 510f;
                    z_check = z_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Left, pos, Quaternion.Euler(0, -90, 0));
                    dir = 2;
                    prev = cur;
                    cur = after;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                break;
            //Current path is Left
            case 2:
                if (after == 0 && dir == 0)
                {

                    z_offset += 500f;
                    z_check = z_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, 0, 0));
                    prev = cur;
                    cur = after;
                    dir = 0;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }
                if (after == 0 && dir == 2)
                {

                    x_offset -= 500f;
                    x_check = x_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, -90, 0));
                    prev = cur;
                    cur = after;
                    dir = 2;
                    Destroy(previous);
                    previous = current;
                    current = next;
                }


                if (after == 1 && dir == 2)
                {

                    z_offset += 500f;
                    z_check = z_offset;
                    pos = new Vector3(x_offset, 42, z_offset);
                    next = (GameObject)Instantiate(Path_Right, pos, Quaternion.Euler(0, 90, 0));
                    dir = 1;
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
        // Initially Spawn 3x Straight roads at -500 units, 0 units and 500 units.
        // -500 units is a dummy that will be deleted as soon as Call_Map is called
        Vector3 pos;
        cur = 0;
        prev = 0;
        after = 0;
        z_offset = 0f;
        x_offset = 0f;
        dir = 0;

        pos = new Vector3(x_offset, 42, z_offset-500f);
        previous = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, 0, 0));
        pos = new Vector3(x_offset, 42, z_offset);
        current = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, 0, 0));
        //pos = new Vector3(x_offset, 42, z_offset+500f);
        //next = (GameObject)Instantiate(Path_1, pos, Quaternion.Euler(0, 0, 0));
        isCheck = true;  
    }
	
	// Update is called once per frame
	void Update () {
        if(isCheck)  //To see if We need to check for next point to call map
        {

            if (dir==0)   //To check the X co-ord or Z co-ord
            {

                if (transform.position.z >= z_check) // Are we beyond the Z point?
                {
                    Call_Map(1);
                    isCheck = false;
                }
            }
            else //Looks like its the X co-ord
            {
                if(dir == 1 &&  transform.position.x >= x_check) // Going right, check Positive X
                {
                    Call_Map(1);
                    isCheck = false;
                }
                else if(dir == 2 && transform.position.x <=x_check ) //Going left, check Negative X
                {
                    Call_Map(1);
                    isCheck = false;
                }
            }
        }

	}
}