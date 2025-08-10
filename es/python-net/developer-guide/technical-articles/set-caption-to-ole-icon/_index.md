---
title: Establecer leyendas en iconos OLE en Python
type: docs
weight: 160
url: /es/python-net/set-caption-to-ole-icon/
keywords:
- icono OLE
- título de imagen
- leyenda
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Descubra cómo establecer leyendas para los iconos de objetos OLE en presentaciones PPT, PPTX y ODP con Aspose.Slides for Python via .NET, mejorando las diapositivas con etiquetas personalizadas."
---

Se ha añadido una nueva propiedad **SubstitutePictureTitle** a la interfaz **IOleObjectFrame** y a la clase **OleObjectFrame**. Permite obtener, establecer o cambiar el título de un ícono OLE. El siguiente fragmento de código muestra un ejemplo de cómo crear un objeto de Excel y establecer su título.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Agregar un objeto OLE a la diapositiva
    with open("oleSourceFile.xlsx", "rb") as ole_stream:
        data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.read(), "xlsx")

    ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

    # Agregar una imagen a la colección de imágenes de la presentación
    with slides.Images.from_file("oleIconFile.ico") as image:
        pp_image = presentation.images.add_image(image)

    # Establecer la imagen como un ícono para el objeto OLE
    ole_frame.is_object_icon = True
    ole_frame.substitute_picture_format.picture.image = pp_image

    # Establecer un título para el ícono OLE
    ole_frame.substitute_picture_title = "Ejemplo de título"
```