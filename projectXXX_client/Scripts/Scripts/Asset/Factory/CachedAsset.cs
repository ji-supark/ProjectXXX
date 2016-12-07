using UnityEngine;
using System.Collections.Generic;

public enum AssetState
{
    Waiting,
    Using,
}

public abstract class CachedAsset : MonoBehaviour
{
    private AssetState m_assetState = AssetState.Waiting;
    private Transform m_assetNode = null;
    private Transform m_cachedTransform;

    public new Transform transform
    {
        get
        {
            if (null == m_cachedTransform)
            {
                m_cachedTransform = GetComponent<Transform>();
            }

            return m_cachedTransform;
        }
    }

    public AssetState Assetstate
    {

        get
        {
            return m_assetState;
        }

        private set
        {
            m_assetState = value;
            switch (m_assetState)
            {
                case AssetState.Using:
                    OnUse();
                    break;
                case AssetState.Waiting:
                    OnRestore();
                    break;
            }
        }
    }

    protected internal Transform ResourceNode
    {
        get { return m_assetNode; }
        set { m_assetNode = value; }
    }

    public AssetState AssetState { get; internal set; }

    public void Use()
    {
        Assetstate = AssetState.Using;
    }

    public void Restore()
    {
        Assetstate = AssetState.Waiting;
    }

    internal abstract void OnInitialize(params object[] parameters);
    protected abstract void OnUse();
    protected abstract void OnRestore();
    internal abstract void Initialize(object[] parameters);
}