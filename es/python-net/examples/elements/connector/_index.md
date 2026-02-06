---
title: Conector
type: docs
weight: 190
url: /es/python-net/examples/elements/connector/
keywords:
- conector
- agregar conector
- acceder a conector
- eliminar conector
- volver a conectar formas
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Dibuje y controle conectores en Python con Aspose.Slides: añada, rote, vuelva a trazar, establezca puntos de conexión, flechas y estilos para enlazar formas en PPT, PPTX y ODP."
---
Muestra cómo conectar formas con conectores y cambiar sus destinos usando **Aspose.Slides for Python via .NET**.

## **Agregar un Conector**

Inserte una forma de conector entre dos puntos en la diapositiva.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añadir una forma de conector doblado.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a un Conector**

Recupere la primera forma de conector añadida a una diapositiva.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder al primer conector en la diapositiva.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Eliminar un Conector**

Elimine un conector de la diapositiva.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un conector.
        connector = slide.shapes[0]

        # Eliminar el conector.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Reconectar Formas**

Adjunte un conector a dos formas asignando los destinos de inicio y fin.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Añadir la primera forma rectangular.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Añadir la segunda forma rectangular.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Añadir una forma de conector doblado.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Conectar el inicio del conector a la primera forma.
        connector.start_shape_connected_to = shape1
        # Conectar el final del conector a la segunda forma.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```