using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class NewBehaviourScript : Agent
{
    //Ai Observes the Enviroment -> makes Decision
    //based on current data -> acts out -> reward or not ->
    //observes again

    [SerializeField] private Transform targetPosition;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material losMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;
    //space size = input amount -> Position = 3 (the x,y,z inputs)
    //stack vectors = amount of last decision will be saved and used in memory


    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(Random.Range(-6f, +6f), 0, Random.Range(-5f, +7f)); //back to the Starting position
        targetPosition.localPosition = new Vector3(Random.Range(-6f, +6f), 0, Random.Range(-5f, +7f));
    }

    /// <summary>
    /// Observation
    /// </summary>
    /// <param name="sensor"></param>
    public override void CollectObservations(VectorSensor sensor)
    {
        //inputs for the AI for solving the problem
        sensor.AddObservation(transform.localPosition); //Ai gets the player Position
        sensor.AddObservation(targetPosition.localPosition); //get Goal Position

    }

    /// <summary>
    /// Desicion + Action
    /// </summary>
    /// <param name="actions"></param>
    public override void OnActionReceived(ActionBuffers actions)
    {
        //Output from the AI int (descrete) and floats (continuous)
        
        //Debug.Log(actions.DiscreteActions[0]);  //discrete typ
        Debug.Log(actions.ContinuousActions[0]);  //continouse typ

        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        //moveing the character
        float moveSpeed = 20f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    //verify if code correct
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");

    }

    /// <summary>
    /// Reward
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision mit" + other.gameObject);
        //AddReward();
        if(other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(+1f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode(); //Reseting Statue to train again
        }
        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f); //negative Reward
            floorMeshRenderer.material = losMaterial;
            EndEpisode(); //Reseting Statue to train again
        }


    }

}
