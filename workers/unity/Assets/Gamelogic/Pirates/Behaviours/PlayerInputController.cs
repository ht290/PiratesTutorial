using Improbable.Ship;
using Improbable.Unity;
using Improbable.Unity.Visualizer;
using UnityEngine;
using Assets.Gamelogic.UI;

namespace Assets.Gamelogic.Pirates.Behaviours
{
    // Add this MonoBehaviour on client workers only
    [WorkerType(WorkerPlatform.UnityClient)]
    public class PlayerInputController : MonoBehaviour
    {
        /* 
         * Client will only have write-access for their own designated PlayerShip entity's ShipControls component,
         * so this MonoBehaviour will be enabled on the client's designated PlayerShip GameObject only and not on
         * the GameObject of other players' ships.
         */
        [Require]
        private ShipControls.Writer ShipControlsWriter;

        void OnEnable()
        {
            SplashScreenController.HideSplashScreen();
        }

        void Update()
        {
            ShipControlsWriter.Send(new ShipControls.Update()
                .SetTargetSpeed(Mathf.Clamp01(Input.GetAxis("Vertical")))
                .SetTargetSteering(Input.GetAxis("Horizontal")));
        }
    }
}
