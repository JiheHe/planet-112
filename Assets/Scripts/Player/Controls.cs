//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Scripts/Player/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""7acfd943-c4aa-4c83-9ff1-730fd25726fc"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""17f46e3f-f8ea-46ba-8b5c-4e2c1958b4eb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8aa35135-855e-4a74-9566-d3931ec160cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NewPlant"",
                    ""type"": ""Button"",
                    ""id"": ""41a1b36b-8ebf-4cb0-a89b-d8a7ae49c53f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""7b843204-6113-45b4-905f-5ef6104d64fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Hotbar"",
                    ""type"": ""Button"",
                    ""id"": ""67e363b3-09d1-4bfc-bf7d-bbdf4e455806"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Settings"",
                    ""type"": ""Button"",
                    ""id"": ""d350d0d1-1aed-4018-aa32-50be821365ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Temp"",
                    ""type"": ""Button"",
                    ""id"": ""d92edcde-b5c8-4e32-b491-34fd45996185"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""b155e1b2-eaee-46cf-b4c8-993a837a7a49"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eddc2d8c-1d2b-4286-bae5-20703f565cda"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5129b3e5-337e-4f8a-bbed-6e077c2c538e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4a6c127a-e126-4281-980d-5b68c27ac7c1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b2c5183b-40ee-4927-b75e-aafe5c17f46f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8efbfb13-ddd2-46f0-93a1-97ef2b6238cb"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""038775f4-9114-47f4-8e69-f17cebf24c0e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""01edc946-b62f-4dd1-8610-7dead0406b4f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""419eb21f-53fe-4a9e-8fd6-0085c3a552cc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7def6d26-8f99-456f-b4dd-4985ebad8a30"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1ef0acfd-d172-4661-8b2f-dda606b762bd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbad689b-950d-4ff0-9656-28f3510bb9cf"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""NewPlant"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6ce1d48-f9db-4bf6-9c6b-f6f274267b3c"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3404ca7e-8bcd-4594-83db-cd39ee7a88d8"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f3c4f5e-4656-4307-835b-4378bd135c2e"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ede3eb40-369b-40f4-9f21-315e1b4be845"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b661333-0b20-4288-a9f8-0e04d8c3958e"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d1e4827-6dd4-4f34-8478-a19aa703c563"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbe4f336-aa1f-430b-9c22-c7daea832e58"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6f06efe-fe8e-43d4-b975-245c188166bb"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c688907-0cb5-44bd-9ce3-ad7f06fcc42f"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""adea9256-4943-42f0-bebb-36708bd18383"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Hotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2db3cb4-57ae-45df-a55e-5c942045b2e3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Settings"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad484125-25b3-4f7e-87d9-15e22e6d8491"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Computer"",
                    ""action"": ""Temp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Computer"",
            ""bindingGroup"": ""Computer"",
            ""devices"": []
        }
    ]
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Movement = m_Main.FindAction("Movement", throwIfNotFound: true);
        m_Main_Interact = m_Main.FindAction("Interact", throwIfNotFound: true);
        m_Main_NewPlant = m_Main.FindAction("NewPlant", throwIfNotFound: true);
        m_Main_Inventory = m_Main.FindAction("Inventory", throwIfNotFound: true);
        m_Main_Hotbar = m_Main.FindAction("Hotbar", throwIfNotFound: true);
        m_Main_Settings = m_Main.FindAction("Settings", throwIfNotFound: true);
        m_Main_Temp = m_Main.FindAction("Temp", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Movement;
    private readonly InputAction m_Main_Interact;
    private readonly InputAction m_Main_NewPlant;
    private readonly InputAction m_Main_Inventory;
    private readonly InputAction m_Main_Hotbar;
    private readonly InputAction m_Main_Settings;
    private readonly InputAction m_Main_Temp;
    public struct MainActions
    {
        private @Controls m_Wrapper;
        public MainActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Main_Movement;
        public InputAction @Interact => m_Wrapper.m_Main_Interact;
        public InputAction @NewPlant => m_Wrapper.m_Main_NewPlant;
        public InputAction @Inventory => m_Wrapper.m_Main_Inventory;
        public InputAction @Hotbar => m_Wrapper.m_Main_Hotbar;
        public InputAction @Settings => m_Wrapper.m_Main_Settings;
        public InputAction @Temp => m_Wrapper.m_Main_Temp;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_MainActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnInteract;
                @NewPlant.started -= m_Wrapper.m_MainActionsCallbackInterface.OnNewPlant;
                @NewPlant.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnNewPlant;
                @NewPlant.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnNewPlant;
                @Inventory.started -= m_Wrapper.m_MainActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnInventory;
                @Hotbar.started -= m_Wrapper.m_MainActionsCallbackInterface.OnHotbar;
                @Hotbar.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnHotbar;
                @Hotbar.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnHotbar;
                @Settings.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSettings;
                @Settings.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSettings;
                @Settings.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSettings;
                @Temp.started -= m_Wrapper.m_MainActionsCallbackInterface.OnTemp;
                @Temp.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnTemp;
                @Temp.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnTemp;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @NewPlant.started += instance.OnNewPlant;
                @NewPlant.performed += instance.OnNewPlant;
                @NewPlant.canceled += instance.OnNewPlant;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Hotbar.started += instance.OnHotbar;
                @Hotbar.performed += instance.OnHotbar;
                @Hotbar.canceled += instance.OnHotbar;
                @Settings.started += instance.OnSettings;
                @Settings.performed += instance.OnSettings;
                @Settings.canceled += instance.OnSettings;
                @Temp.started += instance.OnTemp;
                @Temp.performed += instance.OnTemp;
                @Temp.canceled += instance.OnTemp;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    private int m_ComputerSchemeIndex = -1;
    public InputControlScheme ComputerScheme
    {
        get
        {
            if (m_ComputerSchemeIndex == -1) m_ComputerSchemeIndex = asset.FindControlSchemeIndex("Computer");
            return asset.controlSchemes[m_ComputerSchemeIndex];
        }
    }
    public interface IMainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnNewPlant(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnHotbar(InputAction.CallbackContext context);
        void OnSettings(InputAction.CallbackContext context);
        void OnTemp(InputAction.CallbackContext context);
    }
}
