---
title: Objeto OLE
type: docs
weight: 210
url: /es/python-net/examples/elements/ole-object/
keywords:
- objeto OLE
- agregar objeto OLE
- acceder al objeto OLE
- eliminar objeto OLE
- actualizar objeto OLE
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Trabaje con objetos OLE en Python usando Aspose.Slides: inserte o actualice archivos incrustados, establezca iconos o enlaces, extraiga contenido y controle el comportamiento para PPT, PPTX y ODP."
---
Demuestra la inserción de un archivo como objeto OLE y la actualización de sus datos usando **Aspose.Slides for Python via .NET**.

## **Agregar un objeto OLE**

Inserte un archivo PDF en la presentación.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Cargar datos PDF para incrustar.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # Añadir un marco de objeto OLE a la diapositiva.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a un objeto OLE**

Obtenga el primer marco del objeto OLE en una diapositiva.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Obtener el primer marco de objeto OLE en la diapositiva.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **Eliminar un objeto OLE**

Elimine un objeto OLE incrustado de la diapositiva.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un objeto OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Actualizar datos del objeto OLE**

Reemplace los datos incrustados en un objeto OLE existente.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es un objeto OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # Actualizar el objeto OLE con los nuevos datos incrustados.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```