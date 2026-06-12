---
title: Beheer presentatie-achtergronden in .NET
linktitle: Dia-achtergrond
type: docs
weight: 20
url: /nl/net/presentation-background/
keywords:
- presentatie-achtergrond
- dia-achtergrond
- vaste kleur
- kleurverloop
- afbeeldingsachtergrond
- achtergrondtransparantie
- achtergrond-eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe je dynamische achtergronden instelt in PowerPoint- en OpenDocument-bestanden met Aspose.Slides voor .NET, met code-tips om je presentaties te verbeteren."
---
## **Inleiding**

Vaste kleuren, kleurverlopen en afbeeldingen worden vaak gebruikt voor dia‑achtergronden. Je kan de achtergrond instellen voor een **normale dia** (een enkele dia) of een **masterdia** (geldt voor meerdere dia’s tegelijk).

![PowerPoint-achtergrond](powerpoint-background.png)

## **Stel een vaste kleurachtergrond in voor een normale dia**

Aspose.Slides maakt het mogelijk om een vaste kleur in te stellen als achtergrond voor een specifieke dia in een presentatie — zelfs als de presentatie een masterdia gebruikt. De wijziging geldt uitsluitend voor de geselecteerde dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de dia‑achtergrond in op `Solid`.
4. Gebruik de eigenschap [SolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/solidfillcolor/) op [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/) om de vaste achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

De volgende C#‑voorbeeld laat zien hoe je een blauwe vaste kleur als achtergrond voor een normale dia instelt:

```cs
// Maak een instantie van de Presentation-klasse aan.
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

## **Stel een vaste kleurachtergrond in voor een masterdia**

Aspose.Slides maakt het mogelijk om een vaste kleur in te stellen als achtergrond voor de masterdia in een presentatie. De masterdia fungeert als een sjabloon dat de opmaak voor alle dia’s beheert; wanneer je een vaste kleur voor de achtergrond van de masterdia kiest, wordt deze toegepast op elke dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de masterdia in (via `masters`) op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de masterdia‑achtergrond in op `Solid`.
4. Gebruik de [SolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/solidfillcolor/) om de vaste achtergrondkleur op te geven.
5. Sla de gewijzigde presentatie op.

De volgende C#‑voorbeeld laat zien hoe je een vaste kleur (boshoud) als achtergrond voor een masterdia instelt:

```cs
// Maak een instantie van de Presentation-klasse aan.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Stel de achtergrondkleur voor de Masterdia in op bosgroen.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Sla de presentatie op naar schijf.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Stel een kleurverloopachtergrond in voor een dia**

Een kleurverloop is een grafisch effect dat ontstaat door een geleidelijke verandering in kleur. Wanneer het wordt gebruikt als dia‑achtergrond, kan een kleurverloop presentaties een meer artistiek en professioneel uiterlijk geven. Aspose.Slides maakt het mogelijk om een kleurverloop als achtergrond voor dia’s in te stellen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de dia‑achtergrond in op `Gradient`.
4. Gebruik de eigenschap [GradientFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/gradientformat/) op [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/) om je gewenste kleurverloopinstellingen te configureren.
5. Sla de gewijzigde presentatie op.

De volgende C#‑voorbeeld laat zien hoe je een kleurverloop als achtergrond voor een dia instelt:

```cs
// Maak een instantie van de Presentation-klasse aan.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Pas een kleurverloop toe op de achtergrond.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Sla de presentatie op naar schijf.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Stel een afbeelding in als dia‑achtergrond**

Naast vaste en kleurverloopvullingen maakt Aspose.Slides het mogelijk om afbeeldingen te gebruiken als dia‑achtergronden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse aan.
2. Stel de [BackgroundType](https://reference.aspose.com/slides/nl/net/aspose.slides/backgroundtype/) van de dia in op `OwnBackground`.
3. Stel de [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/filltype/) van de dia‑achtergrond in op `Picture`.
4. Laad de afbeelding die je als dia‑achtergrond wilt gebruiken.
5. Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
6. Gebruik de eigenschap [PictureFillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/picturefillformat/) op [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/fillformat/) om de afbeelding als achtergrond toe te wijzen.
7. Sla de gewijzigde presentatie op.

De volgende C#‑voorbeeld laat zien hoe je een afbeelding als achtergrond voor een dia instelt:

```c#
 // Maak een instantie van de Presentation-klasse aan.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];
 
     // Stel eigenschappen van de achtergrondafbeelding in.
     slide.Background.Type = BackgroundType.OwnBackground;
     slide.Background.FillFormat.FillType = FillType.Picture;
     slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
 
     // Laad de afbeelding.
     IImage image = Images.FromFile("Tulips.jpg");
     // Voeg de afbeelding toe aan de afbeeldingscollectie van de presentatie.
     IPPImage ppImage = presentation.Images.AddImage(image);
     image.Dispose();
 
     slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;
 
     // Sla de presentatie op naar schijf.
     presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
 }
```

De volgende code‑voorbeeld laat zien hoe je het vultype van de achtergrond instelt op een getegeld beeld en de tegel‑eigenschappen wijzigt:

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

    // Stel de afbeelding in die voor de achtergrondvulling gebruikt wordt.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Stel de picture fill mode in op Tile en pas de tegel‑eigenschappen aan.
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
Lees meer: [**Afbeelding tegel als textuur**](/slides/nl/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparantie van de achtergrondafbeelding wijzigen**

Je wilt misschien de transparantie van de achtergrondafbeelding van een dia aanpassen zodat de inhoud beter opvalt. De volgende C#‑code laat zien hoe je de transparantie van een dia‑achtergrondafbeelding wijzigt:

```cs
var transparencyValue = 30; // Bijvoorbeeld.

// Haal de collectie van afbeeldingstransformatie‑operaties op.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Zoek een bestaand vaste‑percentage transparantie‑effect.
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
```

## **De achtergrondwaarde van de dia ophalen**

Aspose.Slides biedt de interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ibackgroundeffectivedata/) voor het ophalen van de effectieve achtergrondwaarden van een dia. Deze interface exposeert de effectieve [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibackgroundeffectivedata/fillformat/) en [EffectFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Met de `background`‑eigenschap van de [BaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslide/) klasse kun je de effectieve achtergrond van een dia verkrijgen.

De volgende C#‑voorbeeld laat zien hoe je de effectieve achtergrondwaarde van een dia ophaalt:

```cs
// Maak een instantie van de Presentation-klasse aan.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Haal de effectieve achtergrond op, rekening houdend met master, lay‑out en thema.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

**Kan ik een aangepaste achtergrond resetten en het thema-/lay‑outachtergrond herstellen?**

Ja. Verwijder de aangepaste vulling van de dia, en de achtergrond wordt weer geërfd van de overeenkomstige [lay‑out](/slides/nl/net/slide-layout/)/[master](/slides/nl/net/slide-master/) dia (d.w.z. de [thematische achtergrond](/slides/nl/net/presentation-theme/)).

**Wat gebeurt er met de achtergrond als ik later het thema van de presentatie wijzig?**

Als een dia zijn eigen vulling heeft, blijft deze onveranderd. Als de achtergrond wordt geërfd van de [lay‑out](/slides/nl/net/slide-layout/)/[master](/slides/nl/net/slide-master/), wordt deze bijgewerkt om overeen te komen met het [nieuwe thema](/slides/nl/net/presentation-theme/).