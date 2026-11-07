---
title: Presentaties comprimeren
description: Verminder de grootte van presentaties met afbeeldingscompressie en bewaarinstellingen.
type: docs
url: /nl/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Overzicht**

Comprimeer afbeeldingen, verwijder bijgesneden beeldgebieden wanneer ze niet meer nodig zijn, en kies compressie‑instellingen voor de presentatie vóór het opslaan. Dit is handig voor presentaties met grote foto’s of herhaald mediabestand. Het bespaarde bedrag hangt af van de inhoud en de instellingen die je kiest.

## **Gebruikvoorbeeld**

Dit C#‑voorbeeld maakt gebruik van Aspose.Slides for .NET. Het genereert zichtbaar een gradient‑PNG van 1600 × 900 pixel, plaatst deze in een klein afbeeldingsframe en slaat *before.pptx* op. Vervolgens comprimeert het die afbeelding tot een doelresolutie van 96 DPI en slaat *compressed.pptx* op. Vergelijk beide bestandsgroottes en voorbeeldweergaven: de besparing hangt af van de invoerafbeelding en de weergegeven grootte.

Voor de installatie, zie [Installeer Aspose.Slides voor .NET](/slides/nl/net/installation/).

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

## **Veelgestelde vragen**

### **Is dit een enkele optimalisatieschakelaar voor het hele bestand?**

Aspose.Slides for .NET 26.11 voegt [Compress.CompressPresentation](/slides/nl/net/low-code-presentation-operations/#compress-the-whole-presentation) toe, dat ongebruikte layout-/master‑verwijdering, ingebedde‑lettertype‑subsettering en 150‑DPI afbeeldingscompressie combineert. Het verwijdert permanent bijgesneden afbeeldingsgebieden. Voor alleen‑afbeeldingsverwerking, gebruik Compress.CompressImages; voor fijnere controle, behoud de per‑afbeeldingsworkflow hierboven. Deze nieuwe helpers zijn specifiek voor de genoemde .NET‑versie; raadpleeg de bijbehorende gids voor andere SDK’s.

### **Verandert afbeeldingscompressie bewerkbare tekst of grafieken?**

Afbeeldingscompressie richt zich op afbeeldingsgegevens, niet op bewerkbare tekst of grafiekgegevens. Controleer de afbeeldingen, want het verkleinen of hercomprimeren kan hun details verminderen.

### **Hoe moet ik een resolutie kiezen voor afbeeldingen in presentaties?**

Kies een doel op basis van de weergegeven afbeeldingsgrootte en het beoogde scherm‑ of printgebruik. Houd meer resolutie aan voor grote schermen, afdrukken en gedetailleerde diagrammen, en vergelijk de gerenderde output voordat je het origineel verwijdert.

## **Gidsen**

- [Optimaliseer afbeeldingsbeheer in presentaties in .NET](/slides/nl/net/image/)

Gerelateerde functie: [Verwijder ongebruikte masters, lay-outs en media](/slides/nl/features/remove-unused-content/).

## Uitvoerbare .NET‑voorbeelden

- [Verminder presentatiegrootte](/slides/nl/net/examples/optimization-batch/compression/)