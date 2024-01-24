using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            Object.DontDestroyOnLoad(base.gameObject);
        }
        else if(instance != this)
        {
            Object.Destroy(base.gameObject);
        }
    }

    [Header("Thông tin chỉ số")]
    public int hp;

    public int mana;

    [Header("Kỹ năng")]
    public bool fire_skill_1;

    public bool fire_skill_2;

    public bool lightning_skill_1;

    public bool lightning_skill_2;

    public bool frost_skill_1;

    [Header("Thu thập")]
    public int crystal;

    public int shards;

    [Header("Tiêu thụ")]
    public int hp_shard_count;

    public int mp_shard_count;

    public bool mp_1_sold;

    public bool hp_1_sold;

    public bool mp_2_sold;

    public bool hp_2_sold;

    [Header("Tiến trình cốt truyện game")]
    public int story_progress;

    [Header("Thiết lập level")]
    public int lvl;

    public int lvl_spawn;

    public int lvl_last;

    [Header("Thiết lập phòng level và rương")]
    public bool[] lvl_0_chests = new bool[3];

    public bool[] lvl_1_chests = new bool[3];

    public bool[] lvl_2_chests = new bool[4];

    public bool[] lvl_3_chests = new bool[3];

    public bool[] lvl_4_chests = new bool[3];

    public bool[] lvl_0_rooms = new bool[39];

    public bool[] lvl_1_rooms = new bool[39];

    public bool[] lvl_2_rooms = new bool[50];

    public bool[] lvl_3_rooms = new bool[47];

    public bool[] lvl_4_rooms = new bool[46];

    public bool[] lvl_5_rooms = new bool[30];

    public bool GetSkillValue(string name)
    {
        DataManager component = base.gameObject.GetComponent<DataManager>();
        FieldInfo field = component.GetType().GetField(name);
        return (bool)field.GetValue(component);
    }
}
