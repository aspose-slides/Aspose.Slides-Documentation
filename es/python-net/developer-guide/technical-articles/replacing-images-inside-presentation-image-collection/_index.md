---
title: Reemplazando Imágenes dentro de la Colección de Imágenes de Presentación
type: docs
weight: 110
url: /es/python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides para Python a través de .NET hace posible reemplazar las imágenes añadidas en las formas de las diapositivas. Este artículo explica cómo reemplazar la imagen añadida en la colección de imágenes de la presentación utilizando diferentes enfoques.

{{% /alert %}} 
## **Reemplazando Imagen dentro de la Colección de Imágenes de Presentación**
Aspose.Slides para Python a través de .NET proporciona métodos de API simples para reemplazar las imágenes dentro de la colección de imágenes de la presentación. Por favor, siga los pasos a continuación:

1. Cargue el archivo de presentación con la imagen dentro de él utilizando la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Cargue una imagen desde un archivo en un array de bytes.
1. Reemplace la imagen objetivo con la nueva imagen en el array de bytes.
1. En el segundo enfoque, cargue la imagen en un objeto Image y reemplace la imagen objetivo con la imagen cargada.
1. En el tercer enfoque, reemplace la imagen con la imagen ya añadida en la colección de imágenes de la presentación.
1. Escriba la presentación modificada como un archivo PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#Instantiate the presentation
with slides.Presentation("pres.pptx") as presentation:

    #the first way
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #the second way
    newImage = slides.Images.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #the third way
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #Save the presentation
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```