---
title: Správa pozadí prezentací v .NET
linktitle: Pozadí snímku
type: docs
weight: 20
url: /cs/net/presentation-background/
keywords:
- pozadí prezentace
- pozadí snímku
- jednobarevná barva
- přechodová barva
- obrázkové pozadí
- průhlednost pozadí
- vlastnosti pozadí
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET, s tipy na kód, které vylepší vaše prezentace."
---
## **Úvod**

Jednobarevné barvy, přechody a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jednotlivý snímek) nebo pro **hlavní snímek** (platí pro více snímků najednou).

![Pozadí PowerPointu](powerpoint-background.png)

## **Nastavení jednobarevného pozadí pro normální snímek**

Aspose.Slides vám umožňuje nastavit jednobarevnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá hlavní snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte snímku vlastnost [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Solid`.
4. Použijte vlastnost [SolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/solidfillcolor/) na [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/) a určete jednobarevnou barvu pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit modrou jednobarevnou barvu jako pozadí pro normální snímek:

```cs
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Nastavte barvu pozadí snímku na modrou.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Uložte prezentaci na disk.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Nastavení jednobarevného pozadí pro hlavní snímek**

Aspose.Slides vám umožňuje nastavit jednobarevnou barvu jako pozadí pro hlavní snímek v prezentaci. Hlavní snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednobarevné pozadí hlavního snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte hlavnímu snímku vlastnost [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) (prostřednictvím `masters`) na `OwnBackground`.
3. Nastavte pozadí hlavního snímku [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Solid`.
4. Použijte [SolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/solidfillcolor/) k určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit jednobarevnou barvu (lesní zelená) jako pozadí pro hlavní snímek:

```cs
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Nastavte barvu pozadí hlavního snímku na lesní zelenou.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Uložte prezentaci na disk.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Nastavení přechodu jako pozadí snímku**

Přechod je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku může přechod dodat prezentaci umělecký a profesionální vzhled. Aspose.Slides vám umožňuje nastavit barvu přechodu jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte snímku vlastnost [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Gradient`.
4. Použijte vlastnost [GradientFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/gradientformat/) na [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/) a nakonfigurujte požadované nastavení přechodu.
5. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit barvu přechodu jako pozadí snímku:

```cs
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Použijte gradientový efekt na pozadí.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Uložte prezentaci na disk.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednobarevných a přechodových výplní vám Aspose.Slides umožňuje použít obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte snímku vlastnost [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) na `OwnBackground`.
3. Nastavte pozadí snímku [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte vlastnost [PictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/picturefillformat/) na [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/) a přiřaďte obrázek jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit obrázek jako pozadí snímku:

```c#
 // Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Nastavte vlastnosti obrázku pozadí.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Načtěte obrázek.
    IImage image = Images.FromFile("Tulips.jpg");
    // Přidejte obrázek do kolekce obrázků prezentace.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Uložte prezentaci na disk.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Následující ukázka kódu ukazuje, jak nastavit typ výplně pozadí na dlaždicový obrázek a upravit vlastnosti dláždění:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Nastavte obrázek použitý pro výplň pozadí.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Nastavte režim výplně obrázku na Dlaždice a upravte vlastnosti dlaždic.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Přečtěte si více: [**Tile Picture As Texture**](/slides/cs/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Změna průhlednosti obrázku pozadí**

Možná budete chtít upravit průhlednost obrázku pozadí snímku, aby se obsah snímku lépe vyjímal. Následující kód v C# ukazuje, jak změnit průhlednost obrázku pozadí snímku:

```cs
var transparencyValue = 30; // Například.

// Získejte kolekci operací transformace obrázku.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Najděte existující efekt pevné procentuální průhlednosti.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Nastavte novou hodnotu průhlednosti.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje rozhraní [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Toto rozhraní vystavuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibackgroundeffectivedata/fillformat/) a [EffectFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Pomocí vlastnosti `background` třídy [BaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslide/) můžete získat efektivní pozadí snímku.

Následující příklad v C# ukazuje, jak získat efektivní hodnotu pozadí snímku:

```cs
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Získejte efektivní pozadí, s ohledem na hlavní snímek, rozvržení a motiv.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **Často kladené otázky**

**Mohu resetovat vlastní pozadí a obnovit pozadí motivu/layoutu?**

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího [layoutu](/slides/cs/net/slide-layout/)/[masteru](/slides/cs/net/slide-master/) (tzn. z [pozadí motivu](/slides/cs/net/presentation-theme/)).

**Co se stane s pozadím, pokud později změníme motiv prezentace?**

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [layoutu](/slides/cs/net/slide-layout/)/[masteru](/slides/cs/net/slide-master/), aktualizuje se podle [nového motivu](/slides/cs/net/presentation-theme/).