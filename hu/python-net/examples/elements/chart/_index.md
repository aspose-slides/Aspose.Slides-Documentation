---
title: Diagram
type: docs
weight: 60
url: /hu/python-net/examples/elements/chart/
keywords:
- diagram
- diagram hozzáadása
- diagram elérése
- diagram eltávolítása
- diagram frissítése
- kódrészletek
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Diagramokat hozhat létre és testreszabhat Pythonban az Aspose.Slides segítségével: adatokat adhat hozzá, sorozatokat, tengelyeket és címkéket formázhat, típusokat változtathat, és exportálhat—működik PPT, PPTX és ODP fájlokkal."
---
Példák különböző diagramtípusok hozzáadására, elérésére, eltávolítására és frissítésére **Aspose.Slides for Python via .NET**-vel. Az alábbi kódrészletek az alapvető diagramműveleteket mutatják be.

## **Diagram hozzáadása**

Ez a metódus egy egyszerű területdiagramot ad hozzá az első diára.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Egyszerű oszlopdiagram hozzáadása az első diára.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagram elérése**

Az alábbi kód lekéri a diagramot az alakzatgyűjteményből.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Az első diagram elérése a dián.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Diagram eltávolítása**

Az alábbi kód eltávolít egy diagramot egy diáról.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy diagram.
        chart = slide.shapes[0]

        # A diagram eltávolítása.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagram adatainak frissítése**

A diagram tulajdonságait, például a címet, módosíthatja.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy diagram.
        chart = slide.shapes[0]

        # A diagram címének módosítása.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```