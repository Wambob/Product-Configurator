// GENERATED AUTOMATICALLY FROM 'Assets/Input/User.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @User : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @User()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""User"",
    ""maps"": [
        {
            ""name"": ""FreeCam"",
            ""id"": ""a0f93457-ee1a-42f3-9372-a7a4d7057bdc"",
            ""actions"": [
                {
                    ""name"": ""CamRotation"",
                    ""type"": ""Value"",
                    ""id"": ""3bc40b3c-e4cf-4798-998b-fb19a933c266"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""8497a8ed-87fd-4c24-aba0-e226c1f0f5ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""263046ea-533a-475f-92d5-a1e05cf2dff8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CamRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6e8f36f-a26b-4b84-806a-2df78e61eea0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55ed08ef-d105-44ff-8f13-4d60ef7aa977"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FreeCam
        m_FreeCam = asset.FindActionMap("FreeCam", throwIfNotFound: true);
        m_FreeCam_CamRotation = m_FreeCam.FindAction("CamRotation", throwIfNotFound: true);
        m_FreeCam_Drag = m_FreeCam.FindAction("Drag", throwIfNotFound: true);
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

    // FreeCam
    private readonly InputActionMap m_FreeCam;
    private IFreeCamActions m_FreeCamActionsCallbackInterface;
    private readonly InputAction m_FreeCam_CamRotation;
    private readonly InputAction m_FreeCam_Drag;
    public struct FreeCamActions
    {
        private @User m_Wrapper;
        public FreeCamActions(@User wrapper) { m_Wrapper = wrapper; }
        public InputAction @CamRotation => m_Wrapper.m_FreeCam_CamRotation;
        public InputAction @Drag => m_Wrapper.m_FreeCam_Drag;
        public InputActionMap Get() { return m_Wrapper.m_FreeCam; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeCamActions set) { return set.Get(); }
        public void SetCallbacks(IFreeCamActions instance)
        {
            if (m_Wrapper.m_FreeCamActionsCallbackInterface != null)
            {
                @CamRotation.started -= m_Wrapper.m_FreeCamActionsCallbackInterface.OnCamRotation;
                @CamRotation.performed -= m_Wrapper.m_FreeCamActionsCallbackInterface.OnCamRotation;
                @CamRotation.canceled -= m_Wrapper.m_FreeCamActionsCallbackInterface.OnCamRotation;
                @Drag.started -= m_Wrapper.m_FreeCamActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_FreeCamActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_FreeCamActionsCallbackInterface.OnDrag;
            }
            m_Wrapper.m_FreeCamActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CamRotation.started += instance.OnCamRotation;
                @CamRotation.performed += instance.OnCamRotation;
                @CamRotation.canceled += instance.OnCamRotation;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
            }
        }
    }
    public FreeCamActions @FreeCam => new FreeCamActions(this);
    public interface IFreeCamActions
    {
        void OnCamRotation(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
    }
}
