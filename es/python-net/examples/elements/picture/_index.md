---
title: Imagen
type: docs
weight: 50
url: /es/python-net/examples/elements/picture/
keywords:
- imagen
- marco de imagen
- añadir imagen
- acceder a la imagen
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Trabaje con imágenes en Python usando Aspose.Slides: inserte, reemplace, recorte, comprima, ajuste la transparencia y los efectos, rellene formas y exporte a PPT, PPTX y ODP."
---
Muestra cómo insertar y acceder a imágenes a partir de imágenes en memoria usando **Aspose.Slides for Python via .NET**. Los ejemplos siguientes crean una imagen en memoria, la colocan en una diapositiva y luego la recuperan.

## **Agregar una imagen**

Este código carga una imagen desde un archivo y la inserta como un marco de imagen en la primera diapositiva.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Cargar una imagen desde un archivo.
        with open("image.png", "rb") as image_stream:
            # Añadir la imagen a los recursos de la presentación.
            image = presentation.images.add_image(image_stream)

        # Insertar un marco de imagen que muestra la imagen en la primera diapositiva.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder a una imagen**

Este ejemplo verifica que una diapositiva contenga un marco de imagen y luego accede al primero que encuentra.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Acceder al primer marco de imagen en la diapositiva.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```