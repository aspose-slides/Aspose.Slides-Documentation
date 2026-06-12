---
title: Exporteren van presentatiegrafieken in C++
linktitle: Grafiek exporteren
type: docs
weight: 90
url: /nl/cpp/export-chart/
keywords:
- grafiek
- grafiek naar afbeelding
- grafiek als afbeelding
- grafiekafbeelding extraheren
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u presentatiegrafieken kunt exporteren met Aspose.Slides voor C++, met ondersteuning voor PPT- en PPTX-formaten, en vereenvoudig rapportage in elke workflow."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een grafiek uit een presentatie te exporteren als een afbeelding. Dit artikel laat zien hoe u een afbeelding van een grafiek kunt verkrijgen en opslaan, wat handig is wanneer u grafische visualisaties buiten een PowerPoint‑presentatie wilt hergebruiken.

## **Grafiekafbeelding ophalen**
Aspose.Slides for C++ biedt ondersteuning voor het extraheren van een afbeelding van een specifieke grafiek. Hieronder vindt u een voorbeeld.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Veelgestelde vragen**

**Kan ik een grafiek exporteren als een vector (SVG) in plaats van een rasterafbeelding?**  
Ja. Een grafiek is een vorm, en de inhoud kan worden opgeslagen als SVG met behulp van de [methode om vorm naar SVG op te slaan](https://reference.aspose.com/slides/nl/cpp/aspose.slides/shape/writeassvg/).

**Hoe kan ik de exacte afmeting van de geëxporteerde grafiek in pixels instellen?**  
Gebruik de image‑rendering‑overloads waarmee u de grootte of schaal kunt opgeven – de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/schaal.

**Wat moet ik doen als lettertypen in labels en de legenda er na het exporteren verkeerd uitzien?**  
[Laad de vereiste lettertypen](/slides/nl/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/) zodat de weergave van de grafiek de metriek en tekstweergave behoudt.

**Houdt de export rekening met het PowerPoint‑thema, stijlen en effecten?**  
Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema’s, stijlen, vullingen, effecten), zodat het uiterlijk van de grafiek behouden blijft.

**Waar kan ik de beschikbare render‑/exportmogelijkheden vinden buiten grafiekafbeeldingen?**  
Bekijk de exportsectie van de [API](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/)/[documentatie](/slides/nl/cpp/convert-powerpoint/) voor uitvoerdoelen ([PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/cpp/convert-powerpoint-to-xps/), [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), enz.) en gerelateerde renderopties.