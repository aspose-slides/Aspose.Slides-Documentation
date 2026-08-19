---
title: "Optimizar la gestión de imágenes en presentaciones con Python"
linktitle: "Gestionar imágenes"
type: docs
weight: 10
url: /es/python-net/image/
keywords:
- "añadir imagen"
- "añadir foto"
- "reemplazar imagen"
- "colección de imágenes"
- "marco de imagen"
- "imagen vinculada"
- "fondo"
- "añadir PNG"
- "añadir JPG"
- "añadir SVG"
- "SVG a formas"
- "recursos SVG externos"
- "PowerPoint"
- "OpenDocument"
- "presentación"
- "Python"
- "Aspose.Slides"
description: "Aprenda cómo añadir, reutilizar, vincular, reemplazar y gestionar imágenes raster y SVG en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python vía .NET."
---
## **Introducción**

Aspose.Slides for Python via .NET ofrece varias formas de trabajar con imágenes, y cada una sirve a un propósito diferente. Puede almacenar una imagen en una presentación, mostrarla en un marco de imagen, usarla como fondo de diapositiva, enlazar a una imagen externa, reemplazar un recurso de imagen compartido o convertir contenido SVG en formas editables.

Este artículo se centra en los recursos de imagen y en cómo se utilizan en toda una presentación. Para recortar, transparencia, efectos, estirado y otros formatos aplicados a un marco de imagen individual, consulte [Marco de imagen](/slides/es/python-net/picture-frame/).

## **Comprender el modelo de imagen**

Los siguientes conceptos de API están estrechamente relacionados pero no son intercambiables:

- La [colección de imágenes de la presentación](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/) almacena los recursos de imagen utilizados por la presentación. Utilice [ImageCollection.add_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/add_image/) para agregar datos de imagen y obtener un recurso [IPPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ippimage/).
- Un [marco de imagen](https://reference.aspose.com/slides/es/python-net/aspose.slides/ipictureframe/) es una forma que muestra una imagen en una diapositiva, diseño o maestro. Utilice [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/) para colocar un recurso de imagen en una diapositiva.
- Un fondo de diapositiva utiliza una imagen como parte del relleno de la diapositiva en lugar de como una forma. Por lo tanto, no se comporta como un marco de imagen.
- [IPPImage.replace_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/ippimage/replace_image/) reemplaza un recurso de imagen. Si varios elementos de la presentación utilizan ese recurso, todos usarán el reemplazo.
- Convertir un SVG a formas crea formas de diapositiva editables. Después de la conversión, el contenido ya no se gestiona como un único recurso de imagen.

Un flujo de trabajo típico es, por tanto: agregar datos de imagen a la colección de imágenes, recibir un [IPPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ippimage/), y luego usar ese recurso en uno o más marcos de imagen o rellenos.

## **Agregar una imagen incrustada**

Para insertar una imagen local, lea el archivo, añada sus datos a la colección de imágenes y cree un marco de imagen que utilice el `IPPImage` devuelto.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

La imagen añadida de esta forma se incrusta en la presentación, por lo que el archivo resultante no depende de que el archivo de imagen original siga estando disponible.

### **Agregar una imagen desde la web**

Cuando una imagen está disponible mediante HTTP o HTTPS, descargue sus bytes, añádalos a la colección de imágenes de la presentación y utilice el recurso de imagen devuelto de la misma manera que una imagen local.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

En aplicaciones de larga duración, reutilice un cliente HTTP o un grupo de conexiones cuando sea apropiado en lugar de crear una nueva conexión para cada solicitud. También valide URLs remotas, tamaños de respuesta y tipos de contenido cuando la fuente no sea de confianza.

## **Reutilizar imágenes en varias diapositivas**

Si la misma imagen se necesita más de una vez, añádala a la presentación una sola vez y reutilice el [IPPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ippimage/) devuelto al crear marcos de imagen adicionales. Esto evita cargar repetidamente los mismos datos de origen y hace explícita la relación entre el recurso de imagen compartido y sus usos.

Para los gráficos que deben aparecer automáticamente en muchas diapositivas, como el logotipo de la empresa, considere colocar el marco de imagen en un [maestro de diapositiva](/slides/es/python-net/slide-master/) o diseño en lugar de añadir una forma equivalente a cada diapositiva.

## **Usar una imagen como fondo de diapositiva**

Una imagen de fondo se asigna al relleno de la diapositiva; no se añade como una forma de marco de imagen. Esto es útil cuando la imagen debe cubrir todo el fondo de la diapositiva y no debe manipularse como un objeto normal de la diapositiva.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Para opciones de fondo adicionales, incluidos los fondos de maestros y diseños, consulte [Fondo de la presentación](/slides/es/python-net/presentation-background/).

## **Imágenes incrustadas y imágenes vinculadas**

Las imágenes incrustadas y vinculadas tienen diferentes compensaciones de portabilidad y tamaño de archivo:

- **Imagen incrustada:** los datos de la imagen se almacenan dentro de la presentación. La presentación es autónoma, pero el tamaño del archivo incluye los datos de la imagen.
- **Imagen vinculada:** la presentación almacena una ruta o URL a una imagen externa. Esto puede reducir el tamaño de la presentación, pero el recurso externo debe seguir siendo accesible cuando se abra o renderice la presentación.

Una imagen vinculada puede crearse asignando la ruta o URL externa a través de [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/es/python-net/aspose.slides/islidespicture/link_path_long/) en lugar de incrustar los datos de la imagen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Utilice imágenes vinculadas solo cuando el entorno de despliegue pueda acceder de forma fiable al recurso externo. Para presentaciones que deben funcionar sin conexión o trasladarse entre sistemas, las imágenes incrustadas suelen ser más seguras.

## **Trabajar con imágenes SVG**

SVG es un formato vectorial, por lo que puede ser útil para iconos, diagramas y otros gráficos que deben escalarse sin la misma pérdida de detalle que las imágenes rasterizadas. Aspose.Slides soporta SVG tanto como recurso de imagen como como origen de formas editables de diapositiva.

### **Agregar un SVG como imagen**

Cree un [SvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/svgimage/), añádalo a la colección de imágenes y coloque el recurso de imagen resultante en un marco de imagen.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **Convertir SVG a formas editables**

![Menú emergente de PowerPoint](img_01_01.png)

Utilice la sobrecarga [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_group_shape/) que acepta un [ISvgImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/isvgimage/) para realizar la conversión.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Utilice la conversión de SVG a formas cuando los elementos vectoriales individuales necesiten editarse como formas de PowerPoint. Si el SVG solo necesita mostrarse, mantenerlo como imagen es más sencillo y evita crear muchas formas separadas.

## **Reemplazar un recurso de imagen existente**

Utilice [IPPImage.replace_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/ippimage/replace_image/) cuando desee reemplazar un recurso de imagen existente. Esto es especialmente útil para gráficos compartidos como logotipos.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Si varios marcos de imagen, fondos, maestros o diseños usan el mismo recurso de imagen, reemplazar ese recurso actualiza todos esos usos. Si solo debe cambiar un marco de imagen, asigne una imagen diferente a ese marco en lugar de reemplazar el recurso compartido.

`replace_image` también ofrece sobrecargas que aceptan un [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) u otro [IPPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ippimage/).

## **Guía práctica de gestión de imágenes**

### **Controlar el tamaño de la presentación**

Las imágenes rasterizadas grandes pueden hacer que una presentación sea innecesariamente grande. Utilice imágenes de origen con dimensiones apropiadas para el tamaño de visualización previsto, reutilice recursos de imagen compartidos cuando sea posible y evite incrustar copias repetidas del mismo gráfico de alta resolución.

Para imágenes rasterizadas que ya se han colocado en marcos de imagen, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/picturefillformat/compress_image/) puede reducir los datos de la imagen según la resolución y la configuración de recorte seleccionadas. Esto es un procesamiento de marco de imagen, no una gestión de la colección de imágenes, por lo que consulte [Marco de imagen](/slides/es/python-net/picture-frame/) para operaciones de formato relacionadas.

### **Elegir entre contenido incrustado y vinculado**

Incrustar hace que la presentación sea portátil porque todos los datos de imagen necesarios viajan con el archivo. Vincular puede reducir el tamaño del archivo, pero introduce una dependencia externa. Use enlaces solo cuando esa dependencia sea aceptable y estable.

### **Reutilizar la marca compartida**

Para logotipos, marcas de agua o gráficos decorativos repetidos, use un único recurso de imagen y reutilícelo. Si el gráfico pertenece al diseño de la presentación más que al contenido de la diapositiva, colóquelo en un maestro o diseño para que sea heredado por las diapositivas correspondientes.

### **Mantener los recursos SVG portátiles**

Un SVG autónomo es más fácil de mover y renderizar de forma consistente que un SVG que depende de archivos externos o recursos de red. Cuando sea posible, incruste los recursos necesarios antes de importar el SVG. Convierta SVG a formas solo cuando los elementos vectoriales individuales necesiten editarse.

### **Utilizar la API moderna de imágenes multiplataforma**

Para nuevo código Python via .NET, use las API [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/) y [Images](https://reference.aspose.com/slides/es/python-net/aspose.slides/images/) de Aspose.Slides en lugar de las API de imagen obsoletas `aspose.pydrawing.Image` o `aspose.pydrawing.Bitmap`. Consulte [API moderna](/slides/es/python-net/modern-api/) para obtener orientación sobre la migración.

WMF y EMF requieren consideraciones especiales. Cuando estos formatos se pasan a través de un [IImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/iimage/), [ImageCollection.add_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/add_image/) convierte el metarchivo a una representación raster PNG antes de la inserción. Si conservar los datos del metarchivo es importante, use la sobrecarga basada en flujo de [ImageCollection.add_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/add_image/). Generar contenido EMF a partir de hojas de cálculo u otros productos es un flujo de integración separado y está fuera del alcance de este artículo.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre la colección de imágenes y un marco de imagen?**

La colección de imágenes almacena recursos de imagen reutilizables. Un marco de imagen es una forma de diapositiva que muestra uno de esos recursos y proporciona formatos específicos de imagen como recorte y efectos.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en todas partes?**

Si el logotipo ya está compartido como un recurso de imagen, reemplácelo con [IPPImage.replace_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/ippimage/replace_image/). Para la marca en toda la presentación, colocar el logotipo en un maestro o diseño también puede reducir el contenido duplicado de las diapositivas.

**¿Por qué una imagen vinculada desaparece en otro ordenador?**

Una imagen vinculada depende de su archivo externo o URL. Si ese recurso no puede alcanzarse desde el otro ordenador, la imagen vinculada puede no estar disponible. Incruste la imagen cuando la presentación deba ser autónoma.

**¿Se puede editar un SVG insertado como formas de PowerPoint?**

Sí. Convierta el SVG con [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_group_shape/); el grupo resultante contiene formas de diapositiva editables en lugar de una sola imagen SVG.

**¿Cómo puedo mantener más pequeñas las presentaciones con muchas imágenes?**

Reutilice recursos de imagen compartidos, evite fuentes rasterizadas innecesariamente grandes, comprima las imágenes raster adecuadas cuando corresponda, mantenga la marca repetida en maestros o diseños y use imágenes vinculadas solo cuando una dependencia externa sea aceptable.