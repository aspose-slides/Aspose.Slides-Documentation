---
title: Optimiza la gestión de imágenes en PowerPoint con Python
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/python-net/image/
keywords:
- agregar imagen
- agregar foto
- agregar mapa de bits
- agregar PNG
- agregar JPG
- agregar SVG
- agregar EMF
- agregar WMF
- agregar TIFF
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Agiliza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides for Python via .NET, mejorando el rendimiento y automatizando tu flujo de trabajo."
---

## **Imágenes en Diapositivas de Presentaciones**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar fotos desde un archivo, internet u otros lugares en las diapositivas. De manera similar, Aspose.Slides te permite agregar imágenes a las diapositivas de tus presentaciones a través de diferentes procedimientos.

{{% alert  title="Consejo" color="primary" %}} 

Aspose proporciona convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que permiten a las personas crear presentaciones rápidamente a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como un objeto de marco—especialmente si planeas usar opciones de formato estándar en ella para cambiar su tamaño, agregar efectos, etc.—ve a [Marco de Imagen](https://docs.aspose.com/slides/python-net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes manipular operaciones de entrada/salida que involucren imágenes y presentaciones de PowerPoint para convertir una imagen de un formato a otro. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convertir [PNG a JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convertir [SVG a PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite operaciones con imágenes en estos formatos populares: JPEG, PNG, BMP, GIF, y otros. 

## **Agregar Imágenes Almacenadas Localmente a Diapositivas**

Puedes agregar una o varias imágenes de tu computadora a una diapositiva en una presentación. Este código de ejemplo en Python te muestra cómo agregar una imagen a una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Imágenes Desde la Web a Diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes agregar la imagen directamente desde la web. 

Este código de ejemplo te muestra cómo agregar una imagen desde la web a una diapositiva en Python:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as pres:
    slide = pres.slides[0]
    imageData = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = pres.images.add_image(imageData)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Imágenes a Maestros de Diapositivas**

Un maestro de diapositivas es la diapositiva superior que almacena y controla información (tema, diseño, etc.) sobre todas las diapositivas debajo de ella. Así que, cuando agregas una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva bajo ese maestro de diapositivas. 

Este código de ejemplo en Python te muestra cómo agregar una imagen a un maestro de diapositivas:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    masterSlide = slide.layout_slide.master_slide
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)
        masterSlide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
        
    pres.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Imágenes como Fondo de Diapositivas**

Puedes decidir utilizar una imagen como el fondo de una diapositiva específica o varias diapositivas. En ese caso, debes consultar *[Establecer Imágenes como Fondos para Diapositivas](https://docs.aspose.com/slides/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a Presentaciones**
Puedes agregar o insertar cualquier imagen en una presentación utilizando el método [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) que pertenece a la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

Para crear un objeto de imagen basado en una imagen SVG, puedes hacerlo de esta manera:

1. Crea un objeto SvgImage para insertarlo en ImageShapeCollection
2. Crea un objeto PPImage de ISvgImage
3. Crea un objeto PictureFrame utilizando la interfaz IPPImage

Este código de ejemplo te muestra cómo implementar los pasos anteriores para agregar una imagen SVG a una presentación:
```py 
import aspose.slides as slides

# Crear nueva presentación
with slides.Presentation() as p:
    # Leer contenido del archivo SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Crear objeto SvgImage
        svgImage = slides.SvgImage(svgContent)

        # Crear objeto PPImage
        ppImage = p.images.add_image(svgImage)

        # Crea un nuevo PictureFrame 
        p.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, ppImage.width, ppImage.height, ppImage)

        # Guardar presentación en formato PPTX
        p.save("presentation_with-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Convertir SVG a un Conjunto de Formas**
La conversión de SVG a un conjunto de formas de Aspose.Slides es similar a la funcionalidad de PowerPoint que se utiliza para trabajar con imágenes SVG:

![Menú emergente de PowerPoint](img_01_01.png)

La funcionalidad es proporcionada por uno de los sobrecargas del método [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/addgroupshape/) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) que toma un objeto [ISvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/isvgimage/) como el primer argumento.

Este código de ejemplo te muestra cómo usar el método descrito para convertir un archivo SVG a un conjunto de formas:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Leer contenido del archivo SVG
    with open("sample.svg","rt") as in_file:
        svgContent = in_file.read()
        # Crear objeto SvgImage
        svgImage = slides.SvgImage(svgContent)

        # Obtener tamaño de la diapositiva
        slide_size = presentation.slide_size.size

        # Convertir la imagen SVG a un grupo de formas escalándola al tamaño de la diapositiva
        presentation.slides[0].shapes.add_group_shape(svgImage, 0, 0, slide_size.width, slide_size.height)

        # Guardar presentación en formato PPTX
        presentation.save("presentation_with_shape_svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar Imágenes como EMF en Diapositivas**
Aspose.Slides para Python a través de .NET te permite agregar la imagen EMF. 

Este código de ejemplo te muestra cómo realizar la tarea descrita:

```py 
with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open("image.emf", "rb") as in_file:
        emfImage = pres.images.add_image(in_file)
        slide_size = pres.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emfImage)
    
    pres.save("pres_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Información" color="info" %}}

Usando el convertidor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/text-to-gif), puedes animar fácilmente textos, crear GIFs a partir de textos, etc. 

{{% /alert %}}