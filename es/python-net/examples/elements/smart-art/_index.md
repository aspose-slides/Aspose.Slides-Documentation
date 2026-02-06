---
title: SmartArt
type: docs
weight: 140
url: /es/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- añadir SmartArt
- acceder a SmartArt
- eliminar SmartArt
- diseño de SmartArt
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Crea y edita SmartArt en Python con Aspose.Slides: agrega nodos, cambia diseños y estilos, convierte a formas con precisión y exporta a PPT, PPTX y ODP."
---
Muestra cómo añadir gráficos SmartArt, acceder a ellos, eliminarlos y cambiar los diseños usando **Aspose.Slides for Python via .NET**.

## **Agregar SmartArt**

Insertar un gráfico SmartArt usando uno de los diseños incorporados.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a SmartArt**

Obtener el primer objeto SmartArt en una diapositiva.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder a la primera forma SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Eliminar SmartArt**

Suprimir una forma SmartArt de la diapositiva.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un objeto SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Cambiar diseño de SmartArt**

Actualizar el tipo de diseño de un gráfico SmartArt existente.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un objeto SmartArt.
        smart_art = slide.shapes[0]

        # Cambiar el diseño del SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```