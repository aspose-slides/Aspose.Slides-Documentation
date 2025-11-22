---
title: Optimizar la gestión de imágenes en PowerPoint con Python
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/python-net/image/
keywords:
- agregar imagen
- agregar foto
- agregar mapa de bits
- reemplazar imagen
- reemplazar foto
- desde web
- fondo
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
description: "Optimice la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para Python a través de .NET, mejorando el rendimiento y automatizando su flujo de trabajo."
---

## **Visión general**

Las imágenes hacen que las presentaciones sean más atractivas e interesantes. En Microsoft PowerPoint, puedes insertar imágenes desde un archivo, Internet u otras fuentes en las diapositivas. De manera similar, Aspose.Slides permite agregar imágenes a las diapositivas de varias formas.

{{% alert  title="Tip" color="primary" %}}

Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—que le permiten crear presentaciones rápidamente a partir de imágenes.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Si deseas agregar una imagen como objeto de marco —especialmente si planeas usar opciones de formato estándar como cambiar el tamaño o aplicar efectos— consulta [Agregar marcos de imágenes a presentaciones con Python](https://docs.aspose.com/slides/python-net/picture-frame/).

{{% /alert %}}

{{% alert title="Note" color="warning" %}}

Puedes usar operaciones de E/S de imágenes y presentaciones para convertir imágenes entre formatos. Consulta estas páginas: convertir [imagen a JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); convertir [JPG a imagen](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); convertir [JPG a PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); convertir [PNG a JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); convertir [PNG a SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); y convertir [SVG a PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite trabajar con imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros.

## **Agregar imágenes almacenadas localmente a diapositivas**

Puedes agregar una o más imágenes desde tu computadora a una diapositiva en una presentación. El siguiente ejemplo en Python muestra cómo agregar una imagen a una diapositiva:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar imágenes de la web a diapositivas**

Si la imagen que deseas agregar a una diapositiva no está disponible en tu computadora, puedes insertarla directamente desde la web.

El siguiente ejemplo en Python muestra cómo agregar una imagen desde una URL a una diapositiva:
```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar imágenes a los maestros de diapositivas**

Un maestro de diapositivas es la diapositiva de nivel superior que almacena y controla información—tema, diseño, etc.—para todas las diapositivas que están bajo él. Cuando agregas una imagen al maestro de diapositivas, esa imagen aparece en cada diapositiva que usa ese maestro.

El siguiente ejemplo en Python muestra cómo agregar una imagen a un maestro de diapositivas:
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


## **Establecer una imagen como fondo de diapositiva**

Puede que desees usar una imagen como fondo para una diapositiva específica o para varias diapositivas. Para más detalles, consulta [Establecer una imagen como fondo de una diapositiva](https://docs.aspose.com/slides/python-net/presentation-background/#set-image-as-background-for-slide).

## **Agregar SVG a presentaciones**

Puedes insertar cualquier imagen en una presentación usando el método [add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) de la clase [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

Para crear un objeto de imagen a partir de un SVG, sigue estos pasos:

1. Crea un [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) y agrégalo a la colección de imágenes de la presentación.  
2. Crea un objeto [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) a partir del [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/).  
3. Crea un objeto [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) usando el [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/).

El siguiente ejemplo en Python muestra cómo agregar una imagen SVG a una presentación usando estos pasos:
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Leer el contenido de un archivo SVG.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Crear un objeto SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Crear un objeto PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # Crear un nuevo PictureFrame.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Guardar la presentación en formato PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **Convertir SVG a un conjunto de formas**

Aspose.Slides convierte SVGs en un conjunto de formas de manera similar al manejo de SVG de PowerPoint.

![Menú emergente de PowerPoint](img_01_01.png)

Esta funcionalidad la proporciona una sobrecarga del método [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_group_shape/) en la clase [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) que toma un [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) como su primer argumento. 

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


## **Agregar imágenes como EMF en diapositivas**

Aspose.Slides for Python permite insertar imágenes Enhanced Metafile (EMF) en presentaciones.

El siguiente ejemplo en Python demuestra esto:
```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```


## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas aquellas usadas por formas de diapositivas. Esta sección describe varias formas de actualizar imágenes en la colección. La API brinda métodos sencillos para reemplazar una imagen con datos de bytes sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/), o con otra imagen que ya exista en la colección.

Sigue estos pasos:

1. Carga la presentación que contiene las imágenes usando la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Carga una nueva imagen desde un archivo en una matriz de bytes.  
3. Reemplaza la imagen objetivo con la nueva imagen usando la matriz de bytes.  
4. Alternativamente, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.  
5. O bien, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.  
6. Guarda la presentación modificada como archivo PPTX.  
```py
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

Con el conversor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/text-to-gif), puedes animar texto fácilmente y crear GIFs a partir de texto.

{{% /alert %}}

## **FAQ**

**¿Se mantiene la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [picture](/slides/es/python-net/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en un diseño y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual cada parte se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo de varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/python-net/presentation-background/) en la diapositiva maestra o en el diseño correspondiente; cualquier diapositiva que use esa maestra/diseño heredará el fondo.

**¿Cómo evito que la presentación "infle" de tamaño debido a muchas imágenes?**

Reutiliza un solo recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.