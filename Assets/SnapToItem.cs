using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnapToItem : MonoBehaviour
{

    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup HLG;
    public TMP_Text NaemLanel;
    public string[] ItemNames;

    bool isSnapped;

    float snapSpeed;
    public float snapForce;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSnapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        int currentItem = Mathf.RoundToInt(0 - contentPanel.localPosition.x / (sampleListItem.rect.width + HLG.spacing));
        Debug.Log(currentItem);

        if (scrollRect.velocity.magnitude < 200 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;

            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(
                Mathf.MoveTowards(contentPanel.localPosition.x, 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing)), snapSpeed),
                contentPanel.localPosition.y,
                contentPanel.localPosition.z
            );

            Debug.Log(contentPanel.localPosition);

            NaemLanel.text = ItemNames[currentItem];

            if (contentPanel.localPosition.x == 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing)))
            {
                isSnapped = true;
            }

        }

        if (scrollRect.velocity.magnitude > 200)
        {
            NaemLanel.text = "_________";
            isSnapped = false;
            snapSpeed = 0;
        }

    }
}
