using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;

public class TestController : Bolt.EntityEventListener<ITestState>
{


    public CharacterController _cc;
    public override void Attached()
    {
        _cc = GetComponent<CharacterController>();
        state.SetTransforms(state.Transform, transform);
    }



    public override void SimulateController()
    {
        ITestCommandInput input = TestCommand.Create();
        input.Forward = Input.GetKey(KeyCode.W);
        input.Back = Input.GetKey(KeyCode.S);
        input.Left = Input.GetKey(KeyCode.A);
        input.Right = Input.GetKey(KeyCode.D);

        entity.QueueInput(input);
    }

    public override void ExecuteCommand(Command command, bool resetState)
    {

        TestCommand cmd = (TestCommand)command;

        if (resetState)
        {
            //owner has sent a correction to the controller
            transform.position = cmd.Result.Position;

        }
        else
        {
            if (cmd.Input.Forward)
                _cc.Move(Vector3.forward * Time.fixedDeltaTime * 10f);
            else if (cmd.Input.Back)
                _cc.Move(Vector3.back * Time.fixedDeltaTime * 10f);
            if (cmd.Input.Left)
                _cc.Move(Vector3.left * Time.fixedDeltaTime * 10f);
            else if (cmd.Input.Right)
                _cc.Move(Vector3.right * Time.fixedDeltaTime * 10f);

            cmd.Result.Position = transform.position;

        }
    }

}
