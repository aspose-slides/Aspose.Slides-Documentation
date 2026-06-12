---
title: Grafieken uit presentaties exporteren op Android
linktitle: Grafiek exporteren
type: docs
weight: 90
url: /nl/androidjava/export-chart/
keywords:
- grafiek
- grafiek naar afbeelding
- grafiek als afbeelding
- grafiekafbeelding extraheren
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u presentatiegrafieken kunt exporteren met Aspose.Slides voor Android via Java, met ondersteuning voor PPT- en PPTX-formaten, en stroomlijn rapportage in elke workflow."
---
## **Overzicht**

Aspose.Slides stelt u in staat een grafiek uit een presentatie te exporteren als een afbeelding. Dit artikel laat zien hoe u een afbeelding van een grafiek krijgt en opslaat, wat handig is wanneer u grafiekvisualisaties buiten een PowerPoint‑presentatie wilt hergebruiken.

Naast de basisworkflow voor afbeeldings‑export behandelt het artikel ook veelvoorkomende vragen over export, waaronder het opslaan van grafiekinhoud als SVG, het regelen van de uitvoergrootte via renderopties, het laden van lettertypen om de weergave van labels en legenda te behouden, en het behouden van de oorspronkelijke presentatie‑opmaak zoals thema’s, stijlen, vullingen en effecten tijdens het renderen.

## **Grafiekafbeelding ophalen**
Aspose.Slides for Android via Java biedt ondersteuning voor het extraheren van een afbeelding van een specifieke grafiek. Hieronder staat een voorbeeld.

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

## **Veelgestelde vragen**

**Kan ik een grafiek exporteren als vector (SVG) in plaats van een rasterafbeelding?**

Ja. Een grafiek is een vorm, en de inhoud kan worden opgeslagen als SVG met behulp van de [shape-to-SVG opslaan methode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Hoe kan ik de exacte grootte van de geëxporteerde grafiek in pixels instellen?**

Gebruik de overloads voor afbeeldings‑renderen die u toelaten de grootte of schaal op te geven – de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/schaal.

**Wat moet ik doen als lettertypen in labels en de legenda er verkeerd uitzien na exporteren?**

[Laad de vereiste lettertypen](/slides/nl/androidjava/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/) zodat het renderen van de grafiek de metriek en weergave van de tekst behoudt.

**Respecteert de export het PowerPoint‑thema, de stijlen en de effecten?**

Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema’s, stijlen, vullingen, effecten), zodat het uiterlijk van de grafiek behouden blijft.

**Waar kan ik de beschikbare render‑/exportmogelijkheden vinden, naast grafiekafbeeldingen?**

Zie de [API](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/)/[documentatie](/slides/nl/androidjava/convert-powerpoint/) voor uitvoerdoelen ([PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/nl/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), etc.) en gerelateerde renderopties.