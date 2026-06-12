---
title: Diagrammen in presentaties exporteren in .NET
linktitle: Diagram exporteren
type: docs
weight: 90
url: /nl/net/export-chart/
keywords:
- grafiek
- grafiek naar afbeelding
- grafiek als afbeelding
- grafiekafbeelding extraheren
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u presentatiediagrammen kunt exporteren met Aspose.Slides voor .NET, ondersteund PPT- en PPTX-formaten, en stroomlijn rapportage in elke werkstroom."
---
## **Overzicht**

Aspose.Slides stelt je in staat om een diagram uit een presentatie te exporteren als afbeelding. Dit artikel laat zien hoe je een afbeelding van een diagram verkrijgt en opslaat, wat handig is wanneer je diagramvisualisaties buiten een PowerPoint‑presentatie wilt hergebruiken.

Naast de basisworkflow voor het exporteren van afbeeldingen behandelt het artikel ook veelvoorkomende vragen over export, zoals het opslaan van diagraminhoud als SVG, het regelen van de uitvoergrootte via renderopties, het laden van lettertypen om het uiterlijk van labels en legenda te behouden, en het behouden van de oorspronkelijke opmaak van de presentatie, zoals thema’s, stijlen, opvullingen en effecten tijdens het renderen.

## **Een diagramafbeelding ophalen**
Aspose.Slides for .NET biedt ondersteuning voor het extraheren van een afbeelding van een specifiek diagram. Hieronder staat een voorbeeld.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Kan ik een diagram exporteren als vector (SVG) in plaats van als rasterafbeelding?**

Ja. Een diagram is een vorm, en de inhoud kan worden opgeslagen als SVG met behulp van de [shape-to-SVG‑opslaanmethode](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/writeassvg/).

**Hoe kan ik de exacte grootte van het geëxporteerde diagram in pixels instellen?**

Gebruik de overloads voor afbeeldingrendering waarmee je de grootte of schaal kunt opgeven – de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/schaal.

**Wat moet ik doen als lettertypen in labels en de legenda er na export verkeerd uitzien?**

[Laad de vereiste lettertypen](/slides/nl/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsloader/) zodat het renderen van het diagram de metriek en weergave van de tekst behoudt.

**Houdt de export rekening met het PowerPoint‑thema, stijlen en effecten?**

Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema’s, stijlen, opvullingen, effecten), zodat het uiterlijk van het diagram behouden blijft.

**Waar kan ik de beschikbare render‑/exportmogelijkheden vinden naast diagramafbeeldingen?**

Zie de exportsectie van de [API](https://reference.aspose.com/slides/nl/net/aspose.slides.export/)/[documentatie](/slides/nl/net/convert-powerpoint/) voor uitvoerdoelen ([PDF](/slides/nl/net/convert-powerpoint-to-pdf/), [SVG](/slides/nl/net/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/net/convert-powerpoint-to-xps/), [HTML](/slides/nl/net/convert-powerpoint-to-html/), enz.) en gerelateerde renderopties.