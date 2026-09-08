---
title: Optimizar la gestión de imágenes en presentaciones usando Python
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/python-java/image/
keywords:
- añadir imagen
- añadir imagen
- reemplazar imagen
- colección de imágenes
- marco de imagen
- imagen enlazada
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- SVG a formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda cómo añadir, reutilizar, enlazar, reemplazar y gestionar imágenes raster y SVG en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python a través de Java."
---
## **Introducción**

Aspose.Slides for Python via Java ofrece varias formas de trabajar con imágenes, y cada una sirve para un propósito diferente. Puedes almacenar una imagen en una presentación, mostrarla en un marco de imagen, usarla como fondo de diapositiva, enlazar a una imagen externa, reemplazar un recurso de imagen compartido o convertir contenido SVG en formas editables.

Este artículo se centra en los recursos de imagen y cómo se utilizan en toda la presentación. Para recortar, aplicar transparencia, efectos, estiramiento y otros formatos aplicados a un marco de imagen individual, consulta [Marco de imagen](/slides/es/python-java/picture-frame/).

## **Comprender el modelo de imagen**

Los siguientes conceptos de la API están estrechamente relacionados pero no son intercambiables:

- La [colección de imágenes de presentación](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/) almacena los recursos de imagen que usa la presentación. Utiliza [ImageCollection.addImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/#addImage) para añadir datos de imagen y obtener un recurso [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/).
- Un [marco de imagen](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) es una forma que muestra una imagen en una diapositiva, diseño o maestro. Utiliza [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addPictureFrame) para colocar un recurso de imagen en una diapositiva.
- Un fondo de diapositiva utiliza una imagen como parte del relleno de la diapositiva en lugar de como una forma. Por lo tanto, no se comporta como un marco de imagen.
- [PPImage.replaceImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#replaceImage) reemplaza un recurso de imagen. Si varios elementos de la presentación usan ese recurso, todos usarán el reemplazo.
- Convertir un SVG en formas crea formas de diapositiva editables. Tras la conversión, el contenido ya no se gestiona como un único recurso de imagen.

Un flujo de trabajo típico es, por lo tanto: añadir datos de imagen a la colección de imágenes, recibir un [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/), y luego usar ese recurso en uno o más marcos de imagen o rellenos.

## **Añadir una imagen incrustada**

Para insertar una imagen local, carga el archivo, añádelo a la colección de imágenes y crea un marco de imagen que utilice el [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) devuelto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La imagen añadida de esta forma se incrusta en la presentación, por lo que el archivo resultante no depende de que el archivo de imagen original siga estando disponible.

### **Añadir una imagen desde la web**

Cuando una imagen está disponible mediante HTTP o HTTPS, descarga sus bytes, añádelos a la colección de imágenes de la presentación y usa el recurso de imagen devuelto de la misma manera que una imagen local.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

En aplicaciones de larga duración, reutiliza un cliente HTTP o una estrategia de gestión de conexiones adecuada a la aplicación en lugar de crear repetidamente infraestructura de red innecesaria. También valida las URL remotas, los tamaños de respuesta y los tipos de contenido cuando la fuente no es de confianza.

## **Reutilizar imágenes en varias diapositivas**

Si la misma imagen se necesita más de una vez, añádela a la presentación una sola vez y reutiliza el [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) devuelto al crear marcos de imagen adicionales. Esto evita cargar repetidamente los mismos datos de origen y hace explícita la relación entre el recurso de imagen compartido y sus usos.

Para gráficos que deben aparecer automáticamente en muchas diapositivas, como el logotipo de la empresa, considera colocar el marco de imagen en un [maestro de diapositiva](/slides/es/python-java/slide-master/) o diseño en lugar de añadir una forma equivalente a cada diapositiva.

## **Usar una imagen como fondo de diapositiva**

Una imagen de fondo se asigna al relleno de la diapositiva; no se añade como una forma de marco de imagen. Esto es útil cuando la imagen debe cubrir el fondo de la diapositiva y no debe manipularse como un objeto de diapositiva normal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para opciones adicionales de fondo, incluidas las de maestros y diseños, consulta [Fondo de presentación](/slides/es/python-java/presentation-background/).

## **Imágenes incrustadas e imágenes enlazadas**

Las imágenes incrustadas y enlazadas tienen diferentes compensaciones de portabilidad y tamaño de archivo:

- **Imagen incrustada:** los datos de la imagen se almacenan dentro de la presentación. La presentación es autocontenida, pero el tamaño del archivo incluye los datos de la imagen.
- **Imagen enlazada:** la presentación almacena una ruta o URL a una imagen externa. Esto puede reducir el tamaño de la presentación, pero el recurso externo debe seguir siendo accesible cuando se abra o renderice la presentación.

Una imagen enlazada puede crearse asignando la ruta externa o URL mediante [Picture.setLinkPathLong](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#setLinkPathLong) en lugar de incrustar los datos de la imagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Utiliza imágenes enlazadas solo cuando el entorno de implementación pueda acceder de forma fiable al recurso externo. Para presentaciones que deben funcionar sin conexión o trasladarse entre sistemas, las imágenes incrustadas suelen ser más seguras.

## **Trabajar con imágenes SVG**

SVG es un formato vectorial, por lo que puede resultar útil para iconos, diagramas y otros gráficos que deben escalar sin la misma pérdida de detalle que las imágenes rasterizadas. Aspose.Slides admite SVG tanto como recurso de imagen como fuente de formas editables de diapositiva.

### **Añadir un SVG como imagen**

Crea un [SvgImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/), añádelo a la colección de imágenes y coloca el recurso de imagen resultante en un marco de imagen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Archivos SVG con recursos externos**

Un SVG puede hacer referencia a imágenes, hojas de estilo o fuentes externas. Para estos casos, [SvgImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/) proporciona constructores que aceptan un [ExternalResourceResolver](https://reference.aspose.com/slides/es/python-java/aspose.slides/externalresourceresolver/) y una URI base. El resolvedor puede asignar una URI relativa a una URI absoluta permitida y devolver un flujo para el recurso solicitado.

El resolvedor pone los recursos externos a disposición mientras Aspose.Slides procesa el SVG, pero no reescribe el SVG en un documento autocontenido. Si el SVG debe seguir siendo portable, incrusta sus recursos necesarios dentro del propio SVG, por ejemplo usando URIs `data:` para imágenes enlazadas.

Cuando los archivos SVG provienen de fuentes no fiables, restringe los esquemas, ubicaciones de archivo y anfitriones a los que el resolvedor puede acceder. Los resolvedores de red también deben aplicar tiempos de espera, límites de tamaño de respuesta y validación de contenido.

### **Convertir SVG a formas editables**

Aspose.Slides puede convertir un SVG en un grupo de formas editables de diapositiva, similar al comando correspondiente de PowerPoint.

![Menú emergente de PowerPoint](img_01_01.png)

Utiliza la sobrecarga de [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addGroupShape) que acepta un [SvgImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/svgimage/) para realizar la conversión.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usa la conversión de SVG a formas cuando los elementos vectoriales individuales necesiten editarse como formas de PowerPoint. Si el SVG solo necesita mostrarse, mantenerlo como imagen es más sencillo y evita crear muchas formas separadas.

## **Reemplazar un recurso de imagen existente**

Utiliza [PPImage.replaceImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#replaceImage) cuando quieras reemplazar un recurso de imagen existente. Esto es especialmente útil para gráficos compartidos como logotipos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si varios marcos de imagen, fondos, maestros o diseños usan el mismo recurso de imagen, reemplazar ese recurso actualiza todos esos usos. Si solo debe cambiar un marco de imagen, asigna una imagen diferente a ese marco en lugar de reemplazar el recurso compartido.

[PPImage.replaceImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#replaceImage) también ofrece sobrecargas que aceptan una matriz de bytes u otro [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/).

## **Orientaciones prácticas para la gestión de imágenes**

### **Controlar el tamaño de la presentación**

Las imágenes raster grandes pueden hacer que una presentación sea innecesariamente pesada. Usa imágenes de origen con dimensiones apropiadas para su tamaño de visualización previsto, reutiliza recursos de imagen compartidos siempre que sea posible y evita incrustar copias repetidas del mismo gráfico de alta resolución.

Para imágenes raster que ya se han colocado en marcos de imagen, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillformat/#compressImage) puede reducir los datos de imagen según la resolución y los ajustes de recorte seleccionados. Esto es procesamiento de marcos de imagen, no gestión de la colección de imágenes, así que consulta [Marco de imagen](/slides/es/python-java/picture-frame/) para operaciones de formato relacionadas.

### **Elegir entre contenido incrustado y enlazado**

Incrustar hace que la presentación sea portable porque todos los datos de imagen necesarios viajan con el archivo. Enlazar puede reducir el tamaño del archivo, pero introduce una dependencia externa. Usa enlaces solo cuando esa dependencia sea aceptable y estable.

### **Reutilizar la identidad de marca compartida**

Para logotipos, marcas de agua o gráficos decorativos repetidos, usa un recurso de imagen y reutilízalo. Si el gráfico pertenece al diseño de la presentación más que al contenido de la diapositiva, colócalo en un maestro o diseño para que sea heredado por las diapositivas correspondientes.

### **Mantener los recursos SVG portables**

Un SVG autocontenido es más fácil de mover y renderizar de forma consistente que un SVG que depende de archivos externos o recursos de red. Cuando sea posible, incrusta los recursos necesarios antes de importar el SVG. Convierte SVG a formas solo cuando los elementos vectoriales individuales necesiten editase.

### **Utilizar la API de imágenes multiplataforma moderna**

Para código nuevo de Python via Java, usa los objetos de imagen multiplataforma de Aspose.Slides y las API [Images](https://reference.aspose.com/slides/es/python-java/aspose.slides/images/) en lugar de la API pública heredada basada en `java.awt.image.BufferedImage`. Consulta [API moderna](/slides/es/python-java/modern-api/) para obtener orientación sobre la migración.

WMF y EMF requieren consideraciones especiales. Cuando estos formatos se pasan a través de un objeto de imagen multiplataforma, [ImageCollection.addImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/#addImage) convierte el metafichero a una representación PNG raster antes de insertarlo. Si conservar los datos del metafichero es importante, utiliza la sobrecarga basada en flujo de [ImageCollection.addImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagecollection/#addImage). Generar contenido EMF a partir de hojas de cálculo u otros productos es un flujo de integración separado y está fuera del alcance de este artículo.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre la colección de imágenes y un marco de imagen?**

La colección de imágenes almacena recursos de imagen reutilizables. Un marco de imagen es una forma de diapositiva que muestra uno de esos recursos y proporciona formato específico de imagen como recorte y efectos.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en todas partes?**

Si el logotipo ya está compartido como un recurso de imagen, reemplaza ese recurso con [PPImage.replaceImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/#replaceImage). Para la identidad de marca en toda la presentación, colocar el logotipo en un maestro o diseño también puede reducir el contenido duplicado de las diapositivas.

**¿Por qué una imagen enlazada desaparece en otro ordenador?**

Una imagen enlazada depende de su archivo externo o URL. Si ese recurso no se puede alcanzar desde el otro ordenador, la imagen enlazada puede estar indisponible. Incrusta la imagen cuando la presentación deba ser autocontenida.

**¿Se puede editar un SVG insertado como formas de PowerPoint?**

Sí. Convierte el SVG con [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addGroupShape); el grupo resultante contiene formas editables de diapositiva en lugar de una única imagen SVG.

**¿Cómo puedo mantener las presentaciones con muchas imágenes más pequeñas?**

Reutiliza recursos de imagen compartidos, evita fuentes raster innecesariamente grandes, comprime imágenes raster adecuadas cuando sea pertinente, mantiene la identidad de marca repetida en maestros o diseños y usa imágenes enlazadas solo cuando una dependencia externa sea aceptable.