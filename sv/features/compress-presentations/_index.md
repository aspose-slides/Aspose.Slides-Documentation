---
title: Komprimera presentationer
description: Minska presentationsstorlek med bildkomprimering och spara inställningar.
type: docs
url: /sv/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Översikt**

Komprimera bilder, ta bort beskurna bildområden när de inte längre behövs, och välj komprimeringsinställningar för presentationen innan du sparar. Detta är användbart för presentationer med stora fotografier eller upprepat media. Hur mycket som sparas beror på innehållet och de inställningar du väljer.

## **Användningsexempel**

Detta C#-exempel använder Aspose.Slides for .NET. Det genererar tydligt en 1600 × 900 pixel gradient-PNG, infogar den i en liten bildram och sparar *before.pptx*. Därefter komprimerar det bilden till en måluppslagning på 96 DPI och sparar *compressed.pptx*. Jämför båda filstorlekarna och förhandsvisningarna: besparingen beror på inmatningsbilden och den visade storleken.

För installation, se [Installera Aspose.Slides för .NET](/slides/sv/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **FAQ**

### **Är detta en enskild optimeringsväxel för hela filen?**

Aspose.Slides for .NET 26.11 lägger till [Compress.CompressPresentation](/slides/sv/net/low-code-presentation-operations/#compress-the-whole-presentation), vilket kombinerar borttagning av oanvända layout/master, delmängdsinställning av inbäddade teckensnitt och 150-DPI bildkomprimering. Det tar permanent bort beskurna bildområden. För endast bildbehandling, använd Compress.CompressImages; för finare kontroll, behåll arbetsflödet per bild ovan. Dessa nya hjälpfunktioner är specifika för den angivna .NET‑versionen; kontrollera motsvarande guide för andra SDK‑er.

### **Påverkar bildkomprimering redigerbar text eller diagram?**

Bildkomprimering riktar sig mot bilddata, inte redigerbar text eller diagramdata. Granska bilderna eftersom omskalning eller omkomprimering kan minska deras detaljrikedom.

### **Hur bör jag välja en upplösning för presentationsbilder?**

Välj ett mål baserat på den visade bildstorleken och avsedd skärm‑ eller utskriftsanvändning. Behåll högre upplösning för stora skärmar, utskrifter och detaljerade diagram, och jämför det renderade resultatet innan du kastar originalet.

## **Guider**

- [Optimera bildhantering i presentationer i .NET](/slides/sv/net/image/)

Relaterad funktion: [Ta bort oanvända master, layouter och media](/slides/sv/features/remove-unused-content/).

## Körbara .NET‑exempel

- [Minska presentationsstorlek](/slides/sv/net/examples/optimization-batch/compression/)