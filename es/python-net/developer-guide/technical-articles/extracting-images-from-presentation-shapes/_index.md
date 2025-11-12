---
title: Extraer imágenes de formas de presentación en Python
linktitle: Imagen de forma
type: docs
weight: 90
url: /es/python-net/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- fondo de diapositiva
- fondo de forma
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Extrae imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET — solución rápida y fácil de usar."
---

## **Extraer imágenes de formas**

{{% alert color="primary" %}} 

Las imágenes a menudo se añaden a las formas y también se utilizan frecuentemente como fondos de diapositivas. Los objetos de imagen se añaden a través de [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), que es una colección de objetos [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/). 

Este artículo explica cómo puedes extraer las imágenes añadidas a las presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, debes localizar la imagen primero recorriendo cada diapositiva y luego cada forma. Una vez que la imagen se encuentre o identifique, puedes extraerla y guardarla como un nuevo archivo. XXX 

```py
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": slides.ImageFormat.JPEG,
        "emf": slides.ImageFormat.EMF,
        "bmp": slides.ImageFormat.BMP,
        "png": slides.ImageFormat.PNG,
        "wmf": slides.ImageFormat.WMF,
        "gif": slides.ImageFormat.GIF,
    }.get(image_type, slides.ImageFormat.JPEG)

with slides.Presentation("pres.pptx") as pres:
    #Accediendo a la presentación
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accediendo a la primera diapositiva
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Obteniendo la imagen de fondo  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Obteniendo la imagen de fondo  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #Estableciendo el formato de imagen deseado 
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.image.save(
                file_name.format("LayoutSlide_" if is_layout else "", slideIndex, image_type), 
                image_format)

        for i in range(len(slide.shapes)):
            shape = slide.shapes[i]
            shape_image = None

            if type(shape) is slides.AutoShape and shape.fill_format.fill_type == slides.FillType.PICTURE:
                shape_image = shape.fill_format.picture_fill_format.picture.image
            elif type(shape) is slides.PictureFrame:
                shape_image = shape.picture_format.picture.image

            if shape_image is not None:
                image_type = shape_image.content_type.split("/")[1]
                image_format = get_image_format(image_type)

                shape_image.image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```

## **Preguntas frecuentes**

**¿Puedo extraer la imagen original sin recorte, efectos o transformaciones de forma?**

Sí. Cuando accedes a la imagen de una forma, obtienes el objeto de imagen de la colección de imágenes de la presentación, es decir, los píxeles originales sin recortes ni efectos de estilo. El flujo de trabajo recorre la colección de imágenes de la presentación y los objetos [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), que almacenan los datos en bruto.

**¿Existe el riesgo de duplicar archivos idénticos al guardar muchas imágenes a la vez?**

Sí, si guardas todo indiscriminadamente. Una colección de imágenes de una presentación puede contener datos binarios idénticos referenciados por diferentes formas o diapositivas. Para evitar duplicados, compara hashes, tamaños o contenidos de los datos extraídos antes de escribir.

**¿Cómo puedo determinar qué formas están vinculadas a una imagen específica de la colección de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) a las formas. Construye un mapeo manualmente durante la recorrida: cada vez que encuentres una referencia a un PPImage, registra qué formas lo utilizan.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

No directamente, porque un objeto OLE es un contenedor. Necesitas extraer el paquete OLE en sí y luego analizar su contenido con herramientas separadas. Las formas de imagen de la presentación funcionan a través de [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/); OLE es un tipo de objeto diferente.