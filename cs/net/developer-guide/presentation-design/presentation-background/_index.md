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
description: "Naučte se nastavit dynamická pozadí v souborech PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET, s tipy v kódu, které posílí vaše prezentace."
---
## **Úvod**

Jednobarevné barvy, přechody a obrázky se běžně používají jako pozadí snímků. Můžete nastavit pozadí pro **normální snímek** (jediný snímek) nebo **master snímek** (platí pro více snímků najednou).

![Pozadí PowerPoint](powerpoint-background.png)

## **Nastavení jednobarevného pozadí pro normální snímek**

Aspose.Slides umožňuje nastavit jednobarevnou barvu jako pozadí konkrétního snímku v prezentaci — i když prezentace používá master snímek. Změna se vztahuje pouze na vybraný snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) pozadí snímku na `Solid`.
4. Použijte vlastnost [SolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/solidfillcolor/) na [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/) k určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit modrou jednobarevnou barvu jako pozadí pro normální snímek:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Nastavení jednobarevného pozadí pro master snímek**

Aspose.Slides umožňuje nastavit jednobarevnou barvu jako pozadí master snímku v prezentaci. Master snímek funguje jako šablona, která řídí formátování všech snímků, takže když zvolíte jednobarevnou barvu pro pozadí master snímku, použije se na každý snímek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) master snímku (pomocí `masters`) na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) pozadí master snímku na `Solid`.
4. Použijte [SolidFillColor](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/solidfillcolor/) k určení jednobarevné barvy pozadí.
5. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit jednobarevnou barvu (lesní zelená) jako pozadí pro master snímek:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Nastavte barvu pozadí master snímku na lesní zelenou.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Uložte prezentaci na disk.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Nastavení přechodového pozadí pro snímek**

Přechod je grafický efekt vytvořený postupnou změnou barvy. Použitý jako pozadí snímku, může přechod učinit prezentaci umělečtější a profesionálnější. Aspose.Slides umožňuje nastavit barvu přechodu jako pozadí pro snímky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) pozadí snímku na `Gradient`.
4. Použijte vlastnost [GradientFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/gradientformat/) na [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/) k nastavení požadovaných parametrů přechodu.
5. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit barvu přechodu jako pozadí pro snímek:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Použijte přechodový efekt na pozadí.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Uložte prezentaci na disk.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Nastavení obrázku jako pozadí snímku**

Kromě jednobarevných a přechodových výplní umožňuje Aspose.Slides použít obrázky jako pozadí snímků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Nastavte [BackgroundType](https://reference.aspose.com/slides/cs/net/aspose.slides/backgroundtype/) snímku na `OwnBackground`.
3. Nastavte [FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) pozadí snímku na `Picture`.
4. Načtěte obrázek, který chcete použít jako pozadí snímku.
5. Přidejte obrázek do kolekce obrázků prezentace.
6. Použijte vlastnost [PictureFillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/picturefillformat/) na [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/fillformat/) k přiřazení obrázku jako pozadí.
7. Uložte upravenou prezentaci.

Následující příklad v C# ukazuje, jak nastavit obrázek jako pozadí pro snímek:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Následující ukázka kódu ukazuje, jak nastavit typ výplně pozadí na dlaždicový obrázek a upravit vlastnosti dlaždicování:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert color="info" %}}

Přečtěte si více: [**Tile Picture As Texture**](/slides/cs/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Změna průhlednosti obrázku pozadí**

Můžete chtít upravit průhlednost obrázku pozadí snímku, aby se obsah snímku více vynikl. Následující kód v C# ukazuje, jak změnit průhlednost obrázku pozadí snímku:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Například.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Získejte kolekci operací transformace obrázku.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Najděte existující efekt průhlednosti s pevnou procentuální hodnotou.
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

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Získání hodnoty pozadí snímku**

Aspose.Slides poskytuje rozhraní [IBackgroundEffectiveData](https://reference.aspose.com/slides/cs/net/aspose.slides/ibackgroundeffectivedata/) pro získání efektivních hodnot pozadí snímku. Toto rozhraní zpřístupňuje efektivní [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibackgroundeffectivedata/fillformat/) a [EffectFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Při použití vlastnosti `background` třídy [BaseSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslide/) můžete získat efektivní pozadí pro snímek.

Následující příklad v C# ukazuje, jak získat efektivní hodnotu pozadí snímku:

```cs
using Aspose.Slides;

// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Získejte efektivní pozadí s ohledem na master, rozvržení a motiv.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

### Can I reset a custom background and restore the theme/layout background?

Ano. Odstraňte vlastní výplň snímku a pozadí bude znovu zděděno z odpovídajícího [layout](/slides/cs/net/slide-layout/)/[master](/slides/cs/net/slide-master/) (tj. [theme background](/slides/cs/net/presentation-theme/)).

### What happens to the background if I change the presentation’s theme later?

Pokud má snímek vlastní výplň, zůstane nezměněna. Pokud je pozadí zděděno z [layout](/slides/cs/net/slide-layout/)/[master](/slides/cs/net/slide-master/), bude aktualizováno tak, aby odpovídalo [new theme](/slides/cs/net/presentation-theme/).