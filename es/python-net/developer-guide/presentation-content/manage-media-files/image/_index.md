---
title: Optimizar la gestión de imágenes en PowerPoint con Python
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/python-net/image/
keywords:
- añadir imagen
- añadir foto
- añadir bitmap
- reemplazar imagen
- reemplazar foto
- desde web
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- añadir EMF
- añadir WMF
- añadir TIFF
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Simplifique la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET, optimizando el rendimiento y automatizando su flujo de trabajo."
---
## **Introducción**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, internet u otras fuentes en las diapositivas. Del mismo modo, Aspose.Slides te permite añadir imágenes a las diapositivas de varias formas.

{{% alert  title="Tip" color="primary" %}}
Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que te permiten crear rápidamente presentaciones a partir de imágenes.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Si deseas añadir una imagen como objeto de marco —especialmente si planeas usar opciones estándar de formato como cambiar el tamaño o aplicar efectos— consulta [Añadir marcos de imagen a presentaciones con Python](https://docs.aspose.com/slides/es/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Puedes usar operaciones de E/S de imágenes y presentaciones para convertir imágenes entre formatos. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/python-net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/es/python-net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/es/python-net/conversion/jpg-to-png/); convertir [PNG a JPG](https://products.aspose.com/slides/es/python-net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/es/python-net/conversion/png-to-svg/); y convertir [SVG a PNG](https://products.aspose.com/slides/es/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides admite trabajar con imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros.

## **Agregar imágenes almacenadas localmente a diapositivas**

Puedes añadir una o más imágenes desde tu ordenador a una diapositiva de una presentación. El siguiente ejemplo en Python muestra cómo añadir una imagen a una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar imágenes desde la web a diapositivas**

Si la imagen que deseas añadir a una diapositiva no está disponible en tu ordenador, puedes insertarla directamente desde la web.

El siguiente ejemplo en Python muestra cómo añadir una imagen desde una URL a una diapositiva:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Descargar los bytes sin procesar de la imagen.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar imágenes a los maestros de diapositivas**

Un maestro de diapositivas es la diapositiva de nivel superior que almacena y controla la información—tema, diseño, etc.—para todas las diapositivas que están bajo él. Cuando añades una imagen a un maestro de diapositivas, esa imagen aparece en cada diapositiva que utiliza ese maestro.

El siguiente ejemplo en Python muestra cómo añadir una imagen a un maestro de diapositivas:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar imágenes como fondos de diapositivas**

Puedes usar una imagen como fondo para una o varias diapositivas. Para más detalles, consulta *[Establecer imágenes como fondos de diapositivas](/slides/es/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a presentaciones**

El contenido SVG puede añadirse a una presentación mediante la clase [SvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/). La imagen SVG resultante puede entonces añadirse a la colección de imágenes de la presentación y usarse para crear un marco de imagen.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Convertir SVG a un conjunto de formas**

Aspose.Slides convierte los SVG en un conjunto de formas de manera similar al manejo de SVG de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Esta funcionalidad se proporciona mediante una sobrecarga del método [add_group_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_group_shape/) en la clase [ShapeCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/), que recibe un [SvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/) como su primer argumento.

El código de muestra a continuación muestra cómo convertir un archivo SVG en un conjunto de formas.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Leer el contenido del archivo SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Crear un objeto SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Obtener el tamaño de la diapositiva.
        slide_size = presentation.slide_size.size

        # Convertir la imagen SVG en un grupo de formas y escalarla al tamaño de la diapositiva.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Guardar la presentación en formato PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Agregar imágenes como EMF a diapositivas**

Aspose.Slides for Python te permite insertar imágenes Enhanced Metafile (EMF) en presentaciones.

El siguiente ejemplo en Python demuestra esto:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas aquellas usadas por formas de diapositivas. Esta sección describe varios enfoques para actualizar imágenes en la colección. La API proporciona métodos sencillos para reemplazar una imagen con datos de bytes sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) o con otra imagen que ya exista en la colección.

Sigue estos pasos:

1. Carga la presentación que contiene las imágenes usando la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/).
1. Carga una nueva imagen desde un archivo en un array de bytes.
1. Reemplaza la imagen objetivo con la nueva imagen usando el array de bytes.
1. Alternativamente, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.
1. O reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Guarda la presentación modificada como archivo PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:

    # La primera forma.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # La segunda forma.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # La tercera forma.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Guardar la presentación en un archivo.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Con el conversor gratuito [Texto a GIF](https://products.aspose.app/slides/es/text-to-gif) de Aspose, puedes animar texto fácilmente y crear GIFs a partir de texto.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conserva la resolución original de la imagen tras la inserción?**

Sí. Los píxeles de origen se conservan, pero la apariencia final depende de cómo se escale la [imagen](/slides/es/python-net/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en decenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una distribución y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usan ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, tras lo cual cada parte individual se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo para varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/python-net/presentation-background/) en la diapositiva maestra o en la distribución correspondiente; cualquier diapositiva que use esa maestra/distribución heredará el fondo.

**¿Cómo evitar que una presentación se vuelva demasiado grande debido a muchas imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.