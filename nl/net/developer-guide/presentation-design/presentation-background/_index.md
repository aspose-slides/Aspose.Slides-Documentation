---
title: Beheer presentatie-achtergronden in .NET
linktitle: Dia-achtergrond
type: docs
weight: 20
url: /nl/net/presentation-background/
keywords:
- presentatie-achtergrond
- dia-achtergrond
- effen kleur
- verloopkleur
- afbeelding-achtergrond
- achtergrondtransparantie
- achtergrondeigenschappen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u dynamische achtergronden instelt in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor .NET, met code-tips om uw presentaties te verbeteren."
---
## **Introductie**

Effen kleuren, verlopen en afbeeldingen worden vaak gebruikt voor dia‑achtergronden. Je kunt de achtergrond instellen voor een **normale dia** (een enkele dia) of een **masterdia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint‑achtergrond](powerpoint-background.png)

## **Instellen van een effen kleurachtergrond voor een normale dia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor een specifieke dia in een presentatie — zelfs als de presentatie een masterdia gebruikt. De wijziging geldt alleen voor de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) class.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de dia‑achtergrond in op `Solid`.
4. Gebruik de eigenschap [SolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/solidfillcolor/) op [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/) om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

Het volgende C#‑voorbeeld toont hoe je een blauwe effen kleur als achtergrond instelt voor een normale dia:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Stel de achtergrondkleur van de dia in op blauw.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Sla de presentatie op naar schijf.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Instellen van een effen kleurachtergrond voor een masterdia**

Aspose.Slides stelt je in staat om een effen kleur als achtergrond in te stellen voor de masterdia in een presentatie. De masterdia fungeert als een sjabloon dat de opmaak van alle dia’s beheert, zodat wanneer je een effen kleur kiest voor de achtergrond van de masterdia, deze op elke dia wordt toegepast.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) class.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de masterdia (via `masters`) in op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de masterdia‑achtergrond in op `Solid`.
4. Gebruik de eigenschap [SolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/solidfillcolor/) om de effen achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

Het volgende C#‑voorbeeld toont hoe je een effen kleur (bosgroen) als achtergrond instelt voor een masterdia:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Stel de achtergrondkleur voor de Masterdia in op Bosgroen.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Sla de presentatie op naar schijf.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Instellen van een verloopachtergrond voor een dia**

Een verloop is een grafisch effect dat ontstaat door een geleidelijke kleurverandering. Wanneer het wordt gebruikt als dia‑achtergrond, kan een verloop presentaties een meer artistiek en professioneel uiterlijk geven. Aspose.Slides stelt je in staat om een verloopkleur als achtergrond in te stellen voor dia’s.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) class.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de dia‑achtergrond in op `Gradient`.
4. Gebruik de eigenschap [GradientFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/gradientformat/) op [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/) om je gewenste verloopinstellingen te configureren.
5. Sla de gewijzigde presentatie op.

Het volgende C#‑voorbeeld toont hoe je een verloopkleur als achtergrond instelt voor een dia:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Pas een verloop-effect toe op de achtergrond.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Sla de presentatie op naar schijf.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Een afbeelding als dia‑achtergrond instellen**

Naast effen en verloopvullingen stelt Aspose.Slides je in staat afbeeldingen als dia‑achtergrond te gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) class.
2. Stel het [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel het [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de dia‑achtergrond in op `Picture`.
4. Laad de afbeelding die je als dia‑achtergrond wilt gebruiken.
5. Voeg de afbeelding toe aan de afbeeldingencollectie van de presentatie.
6. Gebruik de eigenschap [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/picturefillformat/) op [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de gewijzigde presentatie op.

Het volgende C#‑voorbeeld toont hoe je een afbeelding als achtergrond instelt voor een dia:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Stel de eigenschappen van de achtergrondafbeelding in.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Laad de afbeelding.
    IImage image = Images.FromFile("Tulips.jpg");
    // Voeg de afbeelding toe aan de afbeeldingencollectie van de presentatie.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Sla de presentatie op naar schijf.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

De volgende code‑sample laat zien hoe je het achtergrondvulltype instelt op een betegelde afbeelding en de betegelingseigenschappen wijzigt:

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

    // Stel de afbeelding in die wordt gebruikt voor de achtergrondvulling.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Stel de picture fill-modus in op Tegel en pas de tegel‑eigenschappen aan.
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
Lees meer: [**Tegelafbeelding als textuur**](/slides/nl/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparantie van de achtergrondafbeelding aanpassen**

Je wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud van de dia beter opvalt. De volgende C#‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding wijzigt:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Bijvoorbeeld.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Haal de collectie van picture‑transform‑operaties op.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Zoek een bestaand vast‑percentage transparantie‑effect.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Stel de nieuwe transparantiewaarde in.
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

## **De achtergrondwaarde van een dia ophalen**

Aspose.Slides biedt de interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ibackgroundeffectivedata/) voor het ophalen van de effectieve achtergrondwaarden van een dia. Deze interface geeft toegang tot de effectieve [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibackgroundeffectivedata/fillformat/) en [EffectFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Met de `background`‑eigenschap van de klasse [BaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslide/) kun je de effectieve achtergrond van een dia verkrijgen.

Het volgende C#‑voorbeeld toont hoe je de effectieve achtergrondwaarde van een dia ophaalt:

```cs
using Aspose.Slides;

// Maak een instantie van de Presentation-klasse.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Haal de effectieve achtergrond op, rekening houdend met master, layout en thema.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **Veelgestelde vragen**

### Kan ik een aangepaste achtergrond resetten en de thema/lay‑out‑achtergrond herstellen?

Ja. Verwijder de aangepaste vulling van de dia, dan wordt de achtergrond opnieuw overgeërfd van de overeenkomstige [layout](/slides/nl/net/slide-layout/)/[master](/slides/nl/net/slide-master/) dia (dat wil zeggen de [theme background](/slides/nl/net/presentation-theme/)).

### Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?

Als een dia een eigen vulling heeft, blijft deze ongewijzigd. Als de achtergrond wordt overgeërfd van de [layout](/slides/nl/net/slide-layout/)/[master](/slides/nl/net/slide-master/), wordt deze bijgewerkt om overeen te komen met het [new theme](/slides/nl/net/presentation-theme/).