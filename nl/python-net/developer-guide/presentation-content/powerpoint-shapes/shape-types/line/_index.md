---
title: Lijnvormen maken in presentaties met Python
linktitle: Lijn
type: docs
weight: 50
url: /nl/python-net/line/
keywords:
  - lijn
  - lijn maken
  - lijn toevoegen
  - eenvoudige lijn
  - lijn configureren
  - lijn aanpassen
  - streepjesstijl
  - pijlkop
  - PowerPoint
  - OpenDocument
  - presentatie
  - Python
  - Aspose.Slides
description: "Leer hoe je lijnopmaak in PowerPoint- en OpenDocument-presentaties kunt bewerken met Aspose.Slides voor Python via .NET. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides for Python via .NET ondersteunt het toevoegen van verschillende soorten vormen aan de dia's. In dit onderwerp beginnen we met werken met vormen door lijnen aan de dia's toe te voegen. Met Aspose.Slides kunnen ontwikkelaars niet alleen eenvoudige lijnen maken, maar ook enkele bijzondere lijnen op de dia's tekenen.

## **Eenvoudige lijnen maken**

Gebruik Aspose.Slides om een eenvoudige lijn aan een dia toe te voegen als een eenvoudige scheiding of verbindingslijn. Volg de onderstaande stappen om een eenvoudige lijn aan een geselecteerde dia in een presentatie toe te voegen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal een verwijzing naar de dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) van type `LINE` toe met behulp van de `add_auto_shape`‑methode op het [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/)‑object.
1. Sla de presentatie op als een PPTX‑bestand.

In het onderstaande voorbeeld wordt een lijn toegevoegd aan de eerste dia van de presentatie.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse.
with slides.Presentation() as presentation:

    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van type LINE toe.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Pijlvormige lijnen maken**

Aspose.Slides stelt je in staat om lijneigenschappen te configureren zodat ze visueel aantrekkelijker worden. Hieronder configureren we enkele eigenschappen van een lijn zodat deze eruitziet als een pijl. Volg de onderstaande stappen:

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.
1. Haal een verwijzing naar een dia op basis van de index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) van type `LINE` toe met behulp van de `add_auto_shape`‑methode op het [ShapeCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapecollection/)‑object.
1. Stel de [lijnstijl](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linestyle/) in.
1. Stel de lijndikte in.
1. Stel de [streepjesstijl](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linedashstyle/) van de lijn in.
1. Stel de [pijlkopstijl](https://reference.aspose.com/slides/nl/python-net/aspose.slides/linearrowheadstyle/) en lengte in voor het beginpunt van de lijn.
1. Stel de pijlkopstijl en lengte in voor het eindpunt van de lijn.
1. Sla de presentatie op als een PPTX‑bestand.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Maak een instantie van de Presentation-klasse die het PPTX-bestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een autoshape van type LINE toe.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Pas opmaak toe op de lijn.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **Veelgestelde vragen**

**Kan ik een gewone lijn omzetten in een connector zodat deze 'magnetisch' aan vormen plakt?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/) van type [LINE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shapetype/)) wordt niet automatisch een connector. Om de lijn aan vormen te laten plakken, gebruik je het speciale [Connector](https://reference.aspose.com/slides/nl/python-net/aspose.slides/connector/) type en de [bijbehorende API's](/slides/nl/python-net/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn worden geërfd van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

Lees de effectieve eigenschappen [/slides/nl/python-net/shape-effective-properties/](/slides/nl/python-net/shape-effective-properties/) via de [ILineFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ilinefillformateffectivedata/)‑klassen — deze houden al rekening met overerving en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, formaat wijzigen)?**

Ja. Vormen bieden [vergrendelingsobjecten](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/auto_shape_lock/) waarmee je [bewerkingsacties kunt uitschakelen](/slides/nl/python-net/applying-protection-to-presentation/).