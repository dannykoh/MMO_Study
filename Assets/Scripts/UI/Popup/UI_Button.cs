using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        Button pointButton = GetButton((int)Buttons.PointButton);
        AddUIEvent(pointButton.gameObject, OnButtonClicked, Define.UIEvent.Click);

        GameObject imageGO = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(imageGO,
            ((PointerEventData eventData) =>
            {
                imageGO.transform.position = eventData.position;
            }),
            Define.UIEvent.Drag);

        //Get<Text>((int)Texts.ScoreText).text = "Bind Test";
    }

    int score = 0;
    public void OnButtonClicked(PointerEventData eventData)
    {
        score++;
        GetText((int)Texts.ScoreText).text = $"점수 : {score}점";
    }
}
