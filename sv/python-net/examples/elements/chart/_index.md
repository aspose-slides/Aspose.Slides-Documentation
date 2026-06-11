---
title: Diagram
type: docs
weight: 60
url: /sv/python-net/examples/elements/chart/
keywords:
- diagram
- lägga till diagram
- åtkomst till diagram
- ta bort diagram
- uppdatera diagram
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa diagram i Python med Aspose.Slides: lägg till data, formatera serier, axlar och etiketter, ändra typer och exportera—fungerar med PPT, PPTX och ODP."
---
Exempel på hur man lägger till, får åtkomst till, tar bort och uppdaterar olika diagramtyper med **Aspose.Slides for Python via .NET**. Kodsnuttarna nedan demonstrerar grundläggande diagramoperationer.

## **Lägg till ett diagram**

Denna metod lägger till ett enkelt områdesdiagram på den första bilden.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till ett enkelt stapeldiagram på den första bilden.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till ett diagram**

Följande kod hämtar ett diagram från formsamlingen.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Åtkomst till det första diagrammet på bilden.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Ta bort ett diagram**

Följande kod tar bort ett diagram från en bild.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Anta att den första formen är ett diagram.
        chart = slide.shapes[0]

        # Ta bort diagrammet.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Uppdatera diagramdata**

Du kan ändra diagramegenskaper, till exempel titeln.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är ett diagram.
        chart = slide.shapes[0]

        # Ändra diagramtitel.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```