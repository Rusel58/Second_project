using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;

public class ResourceBank : MonoBehaviour
{
    private Dictionary<Resource, ObservableInt> resources = new Dictionary<Resource, ObservableInt>();

    public void ChangeResource(Resource r, int v)
    {
        if (!resources.ContainsKey(r)) resources[r] = new ObservableInt();

        resources[r].Value += v;
    }

    public ObservableInt GetResource(Resource r)
    {
        if (!resources.ContainsKey(r))
            resources[r] = new ObservableInt();

        return resources[r];
    }

    public void ResourcePlus(Resource r)
    {
        resources[r].Value++;
    }
}
