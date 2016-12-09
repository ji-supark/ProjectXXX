
public class Lobby : GameMain
{
    public void Awake()
    {
        UIBase ui = UIManager.Instance.Open("UILobbyMenu");
        ui.transform.SetAsFirstSibling();
    }
        public override void OnFocus()
    {

    }
}