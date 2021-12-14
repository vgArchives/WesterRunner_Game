using UnityEngine;
using UnityEngine.UI;

public class UIButtonBackground : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _highlightedSprite;

    private Image sourceImage;

    public Sprite DefaultSprite { get => _defaultSprite; }
    public Sprite HighlightedSprite { get => _highlightedSprite; }

    public void Initialize(Sprite defaultSprite, Sprite highlightedSprite) 
    {
        _defaultSprite = defaultSprite;
        _highlightedSprite = highlightedSprite;

        Awake();
    }
    
    private void Awake() 
    {
        sourceImage = GetComponent<Image>();
    }

    public void DefaultBackground()
    {
        sourceImage.sprite = DefaultSprite;
    }
    
    public void HighlightBackground()
    {
        sourceImage.sprite = HighlightedSprite;
    }
}
