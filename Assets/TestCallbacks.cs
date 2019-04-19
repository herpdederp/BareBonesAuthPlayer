using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCallbacks : Bolt.GlobalEventListener
{

    public override void SceneLoadLocalDone(string scene)
    {
        if (BoltNetwork.IsServer)
        {
            BoltEntity entity = BoltNetwork.Instantiate(BoltPrefabs.Cube);
            entity.TakeControl();

        }
    }

    public override void SceneLoadRemoteDone(BoltConnection connection)
    {
        if (BoltNetwork.IsServer)
        {
            BoltEntity entity = BoltNetwork.Instantiate(BoltPrefabs.Cube);
            entity.AssignControl(connection);

        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
