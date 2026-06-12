---
title: Spravovat zástupce prezentace v .NET
linktitle: Spravovat zástupce
type: docs
weight: 10
url: /cs/net/manage-placeholder/
keywords:
- zástupce
- textový zástupce
- obrazový zástupce
- zástupce grafu
- výzva textu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Jednoduše spravujte zástupce v Aspose.Slides pro .NET: nahraďte text, přizpůsobte výzvy a nastavte průhlednost obrázku v PowerPointu a OpenDocumentu."
---
## **Přehled**

Aspose.Slides vám umožňuje programově spravovat zástupce v prezentacích. Tento článek vysvětluje, jak najít zástupce na snímcích a změnit jejich text, nastavit vlastní výzvu k zadání textu pro rozvržení zástupců a upravit průhlednost obrázku použitého jako pozadí zástupce. Zahrnuje také krátkou sekci FAQ, která objasňuje rozdíl mezi základními zástupci a lokálními tvary, vysvětluje, jak lze změny zástupců aplikovat prostřednictvím rozvržení nebo hlav, a odkazuje na správu zástupců v hlavičkách a patičkách.

## **Změna textu v zástupci**
Pomocí [Aspose.Slides for .NET](/slides/cs/net/) můžete najít a upravit zástupce na snímcích v prezentacích. Aspose.Slides vám umožňuje měnit text v zástupci.

**Požadavek**: Potřebujete prezentaci, která obsahuje zástupce. Takovou prezentaci můžete vytvořit v běžné aplikaci Microsoft PowerPoint.

Postup, jak pomocí Aspose.Slides nahradit text v zástupci v dané prezentaci:

1. Vytvořte instanci třídy [`Presentation`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a jako argument předajte prezentaci.
2. Získejte referenci na snímek pomocí jeho indexu.
3. Procházejte tvary, abyste našli zástupce.
4. Přetypujte tvar zástupce na [`AutoShape`](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) a změňte text pomocí [`TextFrame`](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) přidruženého k [`AutoShape`](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/).
5. Uložte upravenou prezentaci.

Tento kód v C# ukazuje, jak změnit text v zástupci:

```c#
// Vytvoří instanci třídy Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Přistupuje k prvnímu snímku
    ISlide sld = pres.Slides[0];

    // Prochází tvary, aby našel zástupce
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Mění text v každém zástupci
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Ukládá prezentaci na disk
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Nastavení výzvy v zástupci**
Standardní a předpřipravená rozvržení obsahují výzvy k zadání textu jako ***Click to add a title*** nebo ***Click to add a subtitle***. Pomocí Aspose.Slides můžete vložit své vlastní výzvy do rozvržení zástupců.

Tento kód v C# ukazuje, jak nastavit výzvu v zástupci:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Prochází snímek
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint zobrazuje "Click to add title"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Přidá podtitul
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Nastavení průhlednosti obrázku v zástupci**

Aspose.Slides vám umožňuje nastavit průhlednost obrázku v pozadí textového zástupce. Úpravou průhlednosti obrázku v takovém rámečku můžete zvýraznit text nebo obrázek (v závislosti na barvách textu a obrázku).

Tento kód v C# ukazuje, jak nastavit průhlednost pro obrázek pozadí (uvnitř tvaru):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **Často kladené otázky**

**Co je základní zástupce a jak se liší od lokálního tvaru na snímku?**

Základní zástupce je původní tvar v rozvržení nebo hlavě, ze kterého dědí tvar na snímku – typ, pozice a některé formátování pocházejí z něj. Lokální tvar je nezávislý; pokud neexistuje základní zástupce, dědičnost se nepoužije.

**Jak mohu aktualizovat všechny nadpisy nebo popisky v celé prezentaci, aniž bych procházel každý snímek?**

Upravte odpovídající zástupce v rozvržení nebo v hlavě. Snímky založené na těchto rozvrženích/hlavě automaticky převzaly změnu.

**Jak mohu ovládat standardní zástupce hlavičky/patičky – datum a čas, číslo snímku a text patičky?**

Použijte správce HeaderFooter v příslušném rozsahu (normální snímky, rozvržení, hlavní, poznámky/letáky) k zapnutí nebo vypnutí těchto zástupců a k nastavení jejich obsahu.