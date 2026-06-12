---
title: Export van presentatiegrafieken met Python
linktitle: Export Grafiek
type: docs
weight: 90
url: /nl/python-net/export-chart/
keywords:
- grafiek
- grafiek naar afbeelding
- grafiek als afbeelding
- grafiekafbeelding extraheren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u presentatiegrafieken kunt exporteren met Aspose.Slides voor Python via .NET, met ondersteuning voor PPT-, PPTX- en ODP-formaten, en stroomlijn rapportage in elke workflow."
---
## **Overzicht**

Aspose.Slides stelt je in staat een grafiek uit een presentatie te exporteren als afbeelding. Dit artikel toont hoe je een afbeelding van een grafiek kunt verkrijgen en opslaan, wat handig is wanneer je grafiekvisualisaties buiten een PowerPoint‑presentatie wilt hergebruiken.

## **Grafiekafbeelding ophalen**
Aspose.Slides voor Python via .NET biedt ondersteuning voor het extraheren van een afbeelding van een specifieke grafiek. Hieronder is een voorbeeld gegeven.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **Veelgestelde vragen**

**Kan ik een grafiek exporteren als een vector (SVG) in plaats van een rasterafbeelding?**

Ja. Een grafiek is een vorm, en de inhoud kan worden opgeslagen als SVG met behulp van de [shape-to-SVG-opslagmethode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/write_as_svg/).

**Hoe kan ik de exacte grootte van de geëxporteerde grafiek in pixels instellen?**

Gebruik de image-rendering‑overloads die je in staat stellen de grootte of schaal op te geven – de bibliotheek ondersteunt het renderen van objecten met opgegeven afmetingen/schaal.

**Wat moet ik doen als lettertypen in labels en de legenda er na export verkeerd uitzien?**

[Laad de benodigde lettertypen](/slides/nl/python-net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsloader/) zodat de grafiekrendering metriek en tekstweergave behoudt.

**Houdt de export rekening met het PowerPoint‑thema, stijlen en effecten?**

Ja. De renderer van Aspose.Slides volgt de opmaak van de presentatie (thema’s, stijlen, vullingen, effecten), zodat het uiterlijk van de grafiek behouden blijft.

**Waar kan ik de beschikbare render‑/exportmogelijkheden vinden buiten grafiekafbeeldingen?**

Zie de exportsectie van de [API](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/)/[documentatie](/slides/nl/python-net/convert-powerpoint/) voor uitvoerdoelen ([PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/nl/python-net/convert-powerpoint-to-xps/), [HTML](/slides/nl/python-net/convert-powerpoint-to-html/), enz.) en gerelateerde renderopties.