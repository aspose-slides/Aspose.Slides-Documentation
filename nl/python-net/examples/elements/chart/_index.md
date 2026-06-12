---
title: Grafiek
type: docs
weight: 60
url: /nl/python-net/examples/elements/chart/
keywords:
- grafiek
- grafiek toevoegen
- grafiek benaderen
- grafiek verwijderen
- grafiek bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Maak en pas grafieken aan in Python met Aspose.Slides: voeg gegevens toe, formatteer series, assen en labels, wijzig types en exporteer—werkt met PPT, PPTX en ODP."
---
Voorbeelden voor het toevoegen, benaderen, verwijderen en bijwerken van verschillende grafiektype met **Aspose.Slides for Python via .NET**. De onderstaande fragmenten demonstreren basisgrafiekbewerkingen.

## **Grafiek toevoegen**

Deze methode voegt een eenvoudige gebiedsgrafiek toe aan de eerste dia.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een eenvoudige kolomgrafiek toe aan de eerste dia.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafiek benaderen**

De volgende code haalt een grafiek op uit de vormverzameling.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Toegang tot de eerste grafiek op de dia.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Grafiek verwijderen**

De volgende code verwijdert een grafiek van een dia.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemen dat de eerste vorm een grafiek is.
        chart = slide.shapes[0]

        # Verwijder de grafiek.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafiekgegevens bijwerken**

U kunt grafiekeigenschappen wijzigen, zoals de titel.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Aannemen dat de eerste vorm een grafiek is.
        chart = slide.shapes[0]

        # Wijzig de grafiektitel.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```