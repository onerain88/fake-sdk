using System;
using System.Linq;
using UnityEngine;

public class FakeSDK : MonoBehaviour {
    private static IVuplexWrapper vuplexWrapper;

    static FakeSDK() {
        Type interfaceType = typeof(IVuplexWrapper);
        Type steamWrapperType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .FirstOrDefault(clazz => interfaceType.IsAssignableFrom(clazz) && clazz.IsClass);
        if (steamWrapperType != null) {
            vuplexWrapper = Activator.CreateInstance(steamWrapperType) as IVuplexWrapper;
        }
    }

    // Start is called before the first frame update
    async void Start() {
        await vuplexWrapper.Init(transform);
    }
}
