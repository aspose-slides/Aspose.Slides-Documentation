---
title: Gráfico
type: docs
weight: 60
url: /es/python-net/examples/elements/chart/
keywords:
- gráfico
- añadir gráfico
- acceder gráfico
- eliminar gráfico
- actualizar gráfico
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Cree y personalice gráficos en Python con Aspose.Slides: añada datos, formatee series, ejes y etiquetas, cambie tipos y exporte—funciona con PPT, PPTX y ODP."
---
Ejemplos para añadir, acceder, eliminar y actualizar diferentes tipos de gráficos con **Aspose.Slides for Python via .NET**. Los fragmentos a continuación demuestran operaciones básicas con gráficos.

## **Añadir un gráfico**

Este método añade un gráfico de áreas sencillo a la primera diapositiva.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añadir un gráfico de columnas sencillo a la primera diapositiva.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a un gráfico**

El siguiente código recupera un gráfico de la colección de formas.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder al primer gráfico de la diapositiva.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Eliminar un gráfico**

El siguiente código elimina un gráfico de una diapositiva.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un gráfico.
        chart = slide.shapes[0]

        # Eliminar el gráfico.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar datos del gráfico**

Puede cambiar las propiedades del gráfico, como el título.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un gráfico.
        chart = slide.shapes[0]

        # Cambiar el título del gráfico.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```