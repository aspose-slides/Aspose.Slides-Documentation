---
title: PowerPoint-dia's naar PNG converteren in .NET
linktitle: PowerPoint naar PNG
type: docs
weight: 30
url: /nl/net/convert-powerpoint-to-png/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar PNG
- presentatie naar PNG
- dia naar PNG
- PPT naar PNG
- PPTX naar PNG
- PPT opslaan als PNG
- PPTX opslaan als PNG
- PPT exporteren naar PNG
- PPTX exporteren naar PNG
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-presentaties snel omzetten naar hoogwaardige PNG-afbeeldingen met Aspose.Slides voor .NET, met nauwkeurige, geautomatiseerde resultaten."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatie‑dia’s kunt omzetten naar PNG‑afbeeldingen met Aspose.Slides voor .NET. U kunt presentaties laden in formaten zoals PPT, PPTX en ODP, elke dia renderen en opslaan als een afzonderlijke PNG‑afbeelding.

De onderstaande voorbeelden tonen het renderen van miniaturen, het instellen van schaalfactoren, het specificeren van de uitvoerdimensies in pixels, en het kiezen van een gradient‑renderingsstijl.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
De parameterloze overload van [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) rendert met een schaal van 0,2. Een dia van 720 × 540 points levert bijvoorbeeld een miniatuur van 144 × 108 pixels op. Om de uitvoerdimensies te beheersen, gebruikt u de overloads met schaalfactoren of een expliciete afbeeldingsgrootte zoals hieronder weergegeven.
{{% /alert %}}

## **PowerPoint naar PNG converteren**

Laad een presentatie met de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse en benader de dia’s via de [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑collectie. Het voorbeeld rendert elke dia met [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) zonder parameters om een miniatuur te maken. Daarna wordt [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) aangeroepen met [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) om elke gerenderde dia op te slaan als een PNG‑afbeelding.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **PowerPoint naar PNG converteren met aangepaste afmetingen**

Geef horizontale en verticale schaalfactoren door aan [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) om de gerenderde afmetingen te bepalen. In dit voorbeeld zijn beide factoren 2, waardoor een dia van 720 × 540 points een afbeelding van 1440 × 1080 pixels oplevert. Gelijke schaalfactoren behouden de beeldverhouding van de dia. Iedere afbeelding wordt in PNG‑formaat opgeslagen met [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **PowerPoint naar PNG converteren met aangepaste grootte**

Om de uitvoerdimensies in pixels op te geven, geeft u een grootte door aan [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) in plaats van schaalfactoren. Dit voorbeeld rendert elke dia op 960 × 720 pixels en slaat het resultaat op met [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Kies afmetingen die overeenkomen met de beeldverhouding van de dia om uitrekking van de afbeelding te voorkomen.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

## **Kies een gradient‑renderingsstijl**

Stel dat een dia gradientvullingen bevat, maar de overgangen in de geëxporteerde PNG lichter of anders lijken dan in PowerPoint. U kunt de eigenschap [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) van [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) gebruiken om te bepalen hoe de gradients worden gerenderd.

Download [gradient-styles.pptx](gradient-styles.pptx) en plaats het in de werkmap van de applicatie. De eerste dia bevat twee lineaire gradients: cyaan naar oranje bovenaan en blauw naar geel onderaan. Elke gradient heeft twee stops, bij 0% en 100%.

Het volgende voorbeeld laadt deze presentatie en rendert dezelfde eerste dia in beide modi met [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

De onderstaande afbeeldingen tonen de output van dezelfde dia, met beide gradients in elke afbeelding:

| Default | PowerPointUI |
| --- | --- |
| ![Cyaan-naar-oranje en blauw-naar-geel gradients gerenderd met Default](gradient-Default.png) | ![Dezelfde gradients gerenderd met PowerPointUI](gradient-PowerPointUI.png) |

In dit voorbeeld levert `Default` lichtere tussenkleuren op, terwijl `PowerPointUI` donkerdere tussenkleuren oplevert. Het verschil hangt af van de kleuren en stops in de gradient.

Kies `Default` wanneer de standaarduitvoer van Aspose.Slides aan uw behoeften voldoet. Probeer `PowerPointUI` wanneer uw prioriteit is om de weergave in PowerPoint te evenaren. Vergelijk beide outputs met uw gewenste resultaat; geen van beide modi is in alle gevallen de voorkeur.

## **Veelgestelde vragen**

**Hoe kan ik een specifiek vorm, zoals een diagram of afbeelding, exporteren in plaats van de hele dia?**

Aspose.Slides ondersteunt het [genereren van miniaturen voor individuele vormen](/slides/nl/net/create-shape-thumbnails/), waardoor u een vorm als PNG‑afbeelding kunt renderen.

**Wordt parallelle conversie ondersteund op een server?**

Ja. Gebruik een aparte Presentatie‑instantie voor elke thread of elk proces; [deel geen enkele instantie tussen threads](/slides/nl/net/multithreading/).

**Wat zijn de evaluatiebeperkingen bij het exporteren naar PNG?**

De evaluatiemodus voegt een watermerk toe aan de output‑afbeeldingen en past [andere beperkingen](/slides/nl/net/licensing/) toe totdat een licentie is geïnstalleerd.