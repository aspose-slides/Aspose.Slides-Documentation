---
title: Grafieken uit presentatie exporteren in JavaScript
linktitle: Grafiek exporteren
type: docs
weight: 90
url: /nl/nodejs-java/export-chart/
keywords:
- grafiek
- grafiek naar afbeelding
- grafiek als afbeelding
- grafiekafbeelding extraheren
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u presentatiegrafieken kunt exporteren met Aspose.Slides voor Node.js via Java, met ondersteuning voor PPT- en PPTX-formaten, en rapportage stroomlijnen in elke workflow."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een grafiek uit een presentatie te exporteren als afbeelding. Dit artikel laat zien hoe u een afbeelding van een grafiek kunt krijgen en opslaan, wat handig is wanneer u grafiekvisualisaties buiten een PowerPoint-presentatie wilt hergebruiken.

## **Grafiekafbeelding ophalen**
Aspose.Slides voor Node.js via Java biedt ondersteuning voor het extraheren van een afbeelding van een specifieke grafiek. Hieronder staat een voorbeeld.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik een grafiek exporteren als een vector (SVG) in plaats van een rasterafbeelding?**

Ja. Een grafiek is een vorm, en de inhoud kan worden opgeslagen als SVG met behulp van de [shape-to-SVG saving method](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/writeassvg/).

**Hoe kan ik de exacte grootte van de geëxporteerde grafiek in pixels instellen?**

Gebruik de overloads voor afbeeldingsrendering waarmee u de grootte of schaal kunt opgeven – de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/schaal.

**Wat moet ik doen als lettertypen in labels en de legende er na export fout uitzien?**

[Laad de benodigde lettertypen](/slides/nl/nodejs-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/) zodat de weergave van de grafiek de metriek en tekstweergave behoudt.

**Respecteert export het PowerPoint-thema, stijlen en effecten?**

Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema's, stijlen, vullingen, effecten), zodat het uiterlijk van de grafiek behouden blijft.

**Waar kan ik de beschikbare render-/exportmogelijkheden vinden naast grafiekafbeeldingen?**

Bekijk de [API](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/)/[documentatie](/slides/nl/nodejs-java/convert-powerpoint/) voor uitvoerdoelen ([PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/nl/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/), enz.) en gerelateerde renderopties.