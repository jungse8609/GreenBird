using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameActions
{
    // Gameplay
    public event UnityAction TapEvent = delegate { };

    private GameInput _gameInput = default;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Game.SetCallbacks(this);
            _gameInput.Game.Enable();
        }
    }

    public void OnTap(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            TapEvent.Invoke();
    }
}
