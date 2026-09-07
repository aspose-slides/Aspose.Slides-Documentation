---
title: Convertir PPT y PPTX a JPG en Python
linktitle: PowerPoint a JPG
type: docs
weight: 60
url: /es/python-java/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- PowerPoint a JPG
- PPT a JPG
- PPTX a JPG
- guardar diapositiva como JPG
- exportar PPT a JPG
- exportar PPTX a JPG
- Python
- Java
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint (PPT, PPTX) a imágenes JPG en Python mediante Java. Establezca dimensiones de imagen personalizadas y renderice notas y comentarios con Aspose.Slides."
---
## **Introducción**

Aspose.Slides for Python via Java le permite convertir presentaciones PowerPoint y OpenDocument (PPT, PPTX y ODP) en imágenes JPEG. Puede exportar cada diapositiva o una diapositiva seleccionada para crear miniaturas, crear un visor de presentaciones o incrustar vistas previas de diapositivas en un sitio web o aplicación.

## **Convertir PowerPoint PPT/PPTX a JPG**

1. Cargue la presentación con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Obtenga las diapositivas usando [getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlides).
3. Llame a [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) con factores de escala horizontal y vertical para renderizar cada diapositiva.
4. Guarde cada imagen renderizada como JPEG usando [ImageFormat.Jpeg](https://reference.aspose.com/slides/es/python-java/aspose.slides/imageformat/#Jpeg), luego libere los recursos de la imagen.

{{% alert color="info" title="Note" %}}
Exportar a JPG crea una imagen independiente para cada diapositiva. Guarde la imagen renderizada en lugar de guardar la presentación directamente en un formato de imagen.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **Convertir PowerPoint PPT/PPTX a JPG con dimensiones personalizadas**

Calcule los factores de escala horizontal y vertical a partir de las dimensiones en píxeles deseadas y del tamaño original de la diapositiva, y páselos a [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage). El siguiente ejemplo genera una imagen de 1200 × 800 para cada diapositiva.

Usar factores de escala diferentes puede estirar la diapositiva. Para conservar su relación de aspecto, utilice el mismo factor de escala para ambos ejes; el ancho y la altura resultantes seguirán entonces las proporciones originales de la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **Renderizar comentarios al guardar diapositivas como imágenes**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/) para configurar notas y comentarios, y aplique el diseño a través de [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Este ejemplo coloca las notas en la parte inferior, truncando las notas que no caben, y muestra los comentarios a la derecha en un área de 200 píxeles de ancho. Guarda cada diapositiva renderizada como una imagen JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```
## **Preguntas frecuentes**

**¿Puedo convertir varias diapositivas o presentaciones a JPG?**

Sí. Los ejemplos recorren todas las diapositivas y guardan un JPG por diapositiva. Para procesar varias presentaciones, repita la conversión para cada archivo de entrada y utilice carpetas de salida diferentes o nombres de archivo únicos para evitar sobrescribir imágenes.

**¿Se incluyen gráficos, SmartArt, tablas y formas en las imágenes?**

Estos objetos se renderizan como parte de la diapositiva. Asegúrese de que las tipografías utilizadas por la presentación estén disponibles en el entorno de conversión para reducir diferencias provocadas por la sustitución de fuentes.

**¿Cómo puedo reducir el uso de memoria al exportar presentaciones grandes?**

Procese las imágenes una a una, libere cada imagen después de guardarla y evite dimensiones de salida innecesariamente grandes. Los requisitos de memoria dependen del contenido de la diapositiva y del tamaño de la imagen.

## **Ver también**

- [Convertir PowerPoint a PNG](/slides/es/python-java/convert-powerpoint-to-png/).
- [Renderizar una diapositiva como imagen SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/).