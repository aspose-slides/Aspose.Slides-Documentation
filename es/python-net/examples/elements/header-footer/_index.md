---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/python-net/examples/elements/header-footer/
keywords:
- encabezado pie de página
- agregar encabezado pie de página
- actualizar encabezado pie de página
- establecer fecha y hora
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Controla los encabezados y pies de página en Python con Aspose.Slides: agrega o edita la fecha/hora, los números de diapositiva y el texto del pie de página, muestra u oculta los marcadores de posición en PPT, PPTX y ODP."
---
Muestra cómo agregar pies de página y actualizar marcadores de posición de fecha y hora usando **Aspose.Slides for Python via .NET**.

## **Agregar un pie de página**

Añade texto al área del pie de página de una diapositiva y hazlo visible.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar fecha y hora**

Modifica el marcador de posición de fecha y hora en una diapositiva.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```