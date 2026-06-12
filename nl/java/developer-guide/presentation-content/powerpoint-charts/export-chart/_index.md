---
title: Exporteren van presentatiediagrammen in Java
linktitle: Diagram exporteren
type: docs
weight: 90
url: /nl/java/export-chart/
keywords:
- diagram
- diagram naar afbeelding
- diagram als afbeelding
- diagramafbeelding extraheren
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u presentatiediagrammen kunt exporteren met Aspose.Slides voor Java, ondersteund voor PPT- en PPTX-formats, en vereenvoudig rapportage in elke workflow."
---
## **Overzicht**

Met Aspose.Slides kunt u een diagram vanuit een presentatie exporteren als een afbeelding. Dit artikel laat zien hoe u een afbeelding van een diagram krijgt en opslaat, wat handig is wanneer u diagramvisualisaties buiten een PowerPoint‑presentatie wilt hergebruiken.

Naast de basisworkflow voor afbeeldings‑export behandelt het artikel ook veelvoorkomende vragen over export, waaronder het opslaan van diagraminhoud als SVG, het regelen van de uitvoergrootte via rendering‑opties, het laden van lettertypen om labels en legenda’s correct weer te geven, en het behouden van de oorspronkelijke opmaak van de presentatie zoals thema’s, stijlen, vullingen en effecten tijdens het renderen.

## **Een diagramafbeelding ophalen**
Aspose.Slides for Java biedt ondersteuning voor het extraheren van een afbeelding van een specifiek diagram. Hieronder staat een voorbeeld.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik een diagram exporteren als een vector (SVG) in plaats van een rasterafbeelding?**

Ja. Een diagram is een vorm, en de inhoud kan worden opgeslagen als SVG via de [shape-to-SVG‑opslaand methode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Hoe kan ik de exacte grootte van het geëxporteerde diagram in pixels instellen?**

Gebruik de overloads voor beeld‑rendering die u toestaan de grootte of schaal op te geven – de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/schaal.

**Wat moet ik doen als lettertypen in labels en de legenda er na export verkeerd uitzien?**

[Laad de vereiste lettertypen](/slides/nl/java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/) zodat de weergave van het diagram de metriek en tekstweergave behoudt.

**Respecteert de export het PowerPoint‑thema, de stijlen en de effecten?**

Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema’s, stijlen, vullingen, effecten), zodat het uiterlijk van het diagram behouden blijft.

**Waar kan ik beschikbare render‑/exportmogelijkheden vinden naast diagramafbeeldingen?**

Zie de [API](https://reference.aspose.com/slides/nl/java/com.aspose.slides/)/[documentatie](/slides/nl/java/convert-powerpoint/) voor uitvoerdoelen ([PDF](/slides/nl/java/convert-powerpoint-to-pdf/), [SVG](/slides/nl/java/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/java/convert-powerpoint-to-xps/), [HTML](/slides/nl/java/convert-powerpoint-to-html/), enz.) en gerelateerde renderopties.