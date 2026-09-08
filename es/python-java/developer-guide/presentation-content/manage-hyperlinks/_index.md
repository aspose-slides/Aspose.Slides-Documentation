---
title: Gestionar hipervínculos de presentaciones en Python vía Java
linktitle: Gestionar hipervínculo
type: docs
weight: 20
url: /es/python-java/manage-hyperlinks/
keywords:
- añadir URL
- añadir hipervínculo
- crear hipervínculo
- formatear hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- hipervínculo de texto
- hipervínculo de diapositiva
- hipervínculo de forma
- hipervínculo de imagen
- hipervínculo de vídeo
- hipervínculo mutable
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Gestione hipervínculos sin esfuerzo en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python vía Java: mejore la interactividad y el flujo de trabajo en minutos."
---
## **Introducción**

Un hipervínculo es una referencia a un objeto o datos o a un lugar en algo. Estos son hipervínculos comunes en presentaciones de PowerPoint:

* Enlaces a sitios web dentro de textos, formas o medios
* Enlaces a diapositivas

Aspose.Slides for Python a través de Java le permite realizar muchas tareas relacionadas con hipervínculos en presentaciones. 

{{% alert color="info" title="Nota" %}} 

Puede que desee consultar Aspose simple, [editor de PowerPoint en línea gratuito.](https://products.aspose.app/slides/es/editor)

{{% /alert %}} 

## **Agregar hipervínculos URL**

### **Agregar hipervínculos URL al texto**

Este código Python le muestra cómo agregar un hipervínculo a un sitio web en un texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Agregar hipervínculos URL a formas o marcos**

Este código de ejemplo en Python a través de Java le muestra cómo agregar un hipervínculo a un sitio web a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Agregar hipervínculos URL a medios**

Aspose.Slides le permite agregar hipervínculos a archivos de imagen, audio y vídeo. 

Este código de ejemplo le muestra cómo agregar un hipervínculo a una **imagen**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Añade imagen a la presentación
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # Crea un marco de imagen en la diapositiva 1 basado en la imagen añadida previamente
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este código de ejemplo le muestra cómo agregar un hipervínculo a un **archivo de audio**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Este código de ejemplo le muestra cómo agregar un hipervínculo a un **vídeo**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Consejo" %}} 

Puede que desee ver *[Gestionar OLE](/slides/es/python-java/manage-ole/)*.

{{% /alert %}}

## **Usar hipervínculos para crear una tabla de contenido**

Dado que los hipervínculos le permiten añadir referencias a objetos o lugares, puede utilizarlos para crear una tabla de contenido. 

Este código de ejemplo le muestra cómo crear una tabla de contenido con hipervínculos:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatear hipervínculos**

### **Color**

Con la propiedad [Hyperlink.setColorSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setColorSource) en la clase [Hyperlink](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/), puede establecer el color para los hipervínculos y también obtener la información de color de los hipervínculos. La característica se introdujo por primera vez en PowerPoint 2019, por lo que los cambios que involucren esta propiedad no se aplican a versiones anteriores de PowerPoint.

Este código de ejemplo demuestra una operación en la que se añadieron hipervínculos con diferentes colores a la misma diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eliminar hipervínculos de presentaciones**

### **Eliminar hipervínculos del texto**

Este código Python le muestra cómo eliminar el hipervínculo de un texto en una diapositiva de presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Eliminar hipervínculos de formas o marcos**

Este código Python le muestra cómo eliminar el hipervínculo de una forma en una diapositiva de presentación: 

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hipervínculo mutable**

La clase [Hyperlink](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/) es mutable. Con esta clase, puede cambiar los valores de estas propiedades:

- [setTargetFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

El fragmento de código le muestra cómo agregar un hipervínculo a una diapositiva y editar su información sobre herramienta más tarde:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Cambia la información sobre herramienta del hipervínculo que ya ha sido añadido
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Propiedades compatibles en HyperlinkQueries**

Puede acceder a [HyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/) desde una presentación, diapositiva o texto para el cual está definido el hipervínculo. 

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/#getHyperlinkQueries)

La clase [HyperlinkQueries](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/) admite estos métodos y propiedades: 

- [getHyperlinkClicks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/es/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **Preguntas frecuentes**

**¿Cómo puedo crear una navegación interna no solo a una diapositiva, sino a una "sección" o a la primera diapositiva de una sección?**

Las secciones en PowerPoint son agrupaciones de diapositivas; la navegación técnicamente apunta a una diapositiva específica. Para "navegar a una sección", normalmente se enlaza a su primera diapositiva.

**¿Puedo adjuntar un hipervínculo a los elementos de la diapositiva maestra para que funcione en todas las diapositivas?**

Sí. Los elementos de la diapositiva maestra y de los diseños admiten hipervínculos. dichos enlaces aparecen en las diapositivas hijas y son clicables durante la presentación.

**¿Se conservarán los hipervínculos al exportar a PDF, HTML, imágenes o vídeo?**

En [PDF](/slides/es/python-java/convert-powerpoint-to-pdf/) y [HTML](/slides/es/python-java/convert-powerpoint-to-html/), sí: los enlaces suelen conservarse. Al exportar a [imágenes](/slides/es/python-java/convert-powerpoint-to-png/) y [vídeo](/slides/es/python-java/convert-powerpoint-to-video/), la capacidad de hacer clic no se mantendrá debido a la naturaleza de esos formatos (los fotogramas ráster/vídeo no admiten hipervínculos).