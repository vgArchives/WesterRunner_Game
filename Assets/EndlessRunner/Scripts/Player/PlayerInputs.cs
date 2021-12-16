// GENERATED AUTOMATICALLY FROM 'Assets/EndlessRunner/Scripts/Player/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""edde6b0a-ffb1-4fb4-8253-93111322ee38"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3cff3e2c-3fbd-473e-a09e-cec93c922e5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""99057634-06d3-4e90-b2ee-b1d81217b130"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0265133f-655e-43b7-95fc-08f846688867"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8a72b314-adb2-4be4-8e66-c93525273b0b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPositionTest"",
                    ""type"": ""PassThrough"",
                    ""id"": ""62f0c66b-8f54-4d9a-a0df-40d4148ecc66"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Sideways"",
                    ""id"": ""f226f0f6-e756-4bb4-bd12-b95a3be105c0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6ca986db-4f22-4ab6-bbb7-564e83f38d81"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ae068d27-293d-4b05-83eb-3f5cd5a3fcbc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f72f0a91-7bb2-4759-b243-4eeb7ed35773"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""66e3484f-756d-462e-b890-2642fae04440"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Smartphone"",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8304184-1e7d-466d-9cd0-4c3fc1ee6306"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Smartphone"",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d9a6e6d-1e55-45c8-8db0-078d76d906a3"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPositionTest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Smartphone"",
            ""bindingGroup"": ""Smartphone"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_Move = m_Inputs.FindAction("Move", throwIfNotFound: true);
        m_Inputs_Jump = m_Inputs.FindAction("Jump", throwIfNotFound: true);
        m_Inputs_TouchPress = m_Inputs.FindAction("TouchPress", throwIfNotFound: true);
        m_Inputs_TouchPosition = m_Inputs.FindAction("TouchPosition", throwIfNotFound: true);
        m_Inputs_TouchPositionTest = m_Inputs.FindAction("TouchPositionTest", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_Move;
    private readonly InputAction m_Inputs_Jump;
    private readonly InputAction m_Inputs_TouchPress;
    private readonly InputAction m_Inputs_TouchPosition;
    private readonly InputAction m_Inputs_TouchPositionTest;
    public struct InputsActions
    {
        private @PlayerInputs m_Wrapper;
        public InputsActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Inputs_Move;
        public InputAction @Jump => m_Wrapper.m_Inputs_Jump;
        public InputAction @TouchPress => m_Wrapper.m_Inputs_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Inputs_TouchPosition;
        public InputAction @TouchPositionTest => m_Wrapper.m_Inputs_TouchPositionTest;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnJump;
                @TouchPress.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPress;
                @TouchPosition.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPosition;
                @TouchPositionTest.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPositionTest;
                @TouchPositionTest.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPositionTest;
                @TouchPositionTest.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnTouchPositionTest;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @TouchPositionTest.started += instance.OnTouchPositionTest;
                @TouchPositionTest.performed += instance.OnTouchPositionTest;
                @TouchPositionTest.canceled += instance.OnTouchPositionTest;
            }
        }
    }
    public InputsActions @Inputs => new InputsActions(this);
    private int m_SmartphoneSchemeIndex = -1;
    public InputControlScheme SmartphoneScheme
    {
        get
        {
            if (m_SmartphoneSchemeIndex == -1) m_SmartphoneSchemeIndex = asset.FindControlSchemeIndex("Smartphone");
            return asset.controlSchemes[m_SmartphoneSchemeIndex];
        }
    }
    public interface IInputsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchPositionTest(InputAction.CallbackContext context);
    }
}
