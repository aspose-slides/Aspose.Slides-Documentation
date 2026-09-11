---
title: Gestionar gráficos SmartArt en presentaciones usando Python
linktitle: Gráficos SmartArt
type: docs
weight: 20
url: /es/python-java/manage-smartart-shape/
keywords:
- Objeto SmartArt
- Gráfico SmartArt
- Estilo SmartArt
- Color SmartArt
- Crear SmartArt
- Agregar SmartArt
- Editar SmartArt
- Cambiar SmartArt
- Acceder a SmartArt
- Tipo de diseño SmartArt
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Automatice la creación, edición y estilado de SmartArt en PowerPoint con Python usando Aspose.Slides, con ejemplos de código concisos y orientación centrada en el rendimiento."
---
## **Resumen**

Aspose.Slides le permite crear y administrar gráficos SmartArt en presentaciones de PowerPoint de forma programática. Este artículo explica cómo agregar una forma SmartArt a una diapositiva, acceder a formas SmartArt existentes, encontrar SmartArt por un tipo de diseño específico y actualizar su apariencia visual cambiando el estilo SmartArt o el estilo de color.

Los ejemplos muestran cómo trabajar con formas SmartArt a través de la colección de formas de la diapositiva de la presentación, comprobar si una forma es SmartArt y luego modificar o inspeccionar sus propiedades.

## **Crear una forma SmartArt**
Aspose.Slides for Python via Java provides an API to create SmartArt shapes. To create a SmartArt shape in a slide, please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) class.
1. Get a slide by its index.
1. [Agregar una forma SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addSmartArt) by specifying a [SmartArtLayoutType](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartartlayouttype/).
1. Save the modified presentation as a PPTX file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Guardar la presentación.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt añadida a la diapositiva**|

## **Acceder a una forma SmartArt en una diapositiva**
The following example accesses SmartArt shapes on a presentation slide. It iterates through every shape on the slide and checks whether the shape is a [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) instance.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Recorrer cada forma en la primera diapositiva.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Acceder a una forma SmartArt con un tipo de diseño particular**
The following example accesses a [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) shape with a particular layout type, returned by [SmartArt.getLayout](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/#getLayout).

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) instance.
1. Check whether the SmartArt shape has the specified layout type and perform the required operation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Recorrer cada forma en la primera diapositiva.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Comprobar el diseño del SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Cambiar el estilo de una forma SmartArt**
This example shows how to change the quick style of a SmartArt shape.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) instance.
1. Find the SmartArt shape with the specified style.
1. Set the new style for the SmartArt shape.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Recorrer cada forma en la primera diapositiva.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Comprobar y cambiar el estilo del SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con estilo cambiado**|

## **Cambiar el estilo de color de una forma SmartArt**
This example accesses a SmartArt shape with a particular color style and changes that style.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) class and load the presentation containing a SmartArt shape.
1. Get the first slide by its index.
1. Iterate through every shape on the first slide.
1. Check whether the shape is a [SmartArt](https://reference.aspose.com/slides/es/python-java/aspose.slides/smartart/) instance.
1. Find the SmartArt shape with the specified color style.
1. Set the new color style for the SmartArt shape.
1. Save the presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Recorrer cada forma en la primera diapositiva.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Comprobar y cambiar el estilo del SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con estilo de color cambiado**|

## **Preguntas frecuentes**

**¿Puedo animar SmartArt como un solo objeto?**

Sí. SmartArt es una forma, por lo que puede aplicar [animaciones estándar](/slides/es/python-java/powerpoint-animation/) mediante la API de animaciones (entrada, salida, énfasis, rutas de movimiento) al igual que con otras formas.

**¿Cómo puedo encontrar un SmartArt específico en una diapositiva si no conozco su ID interno?**

Establezca y use el [texto alternativo](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setAlternativeText) y busque la forma por ese valor; esta es una forma recomendada de localizar la forma objetivo.

**¿Puedo agrupar SmartArt con otras formas?**

Sí. Puede agrupar SmartArt con otras formas (imágenes, tablas, etc.) y luego [manipular el grupo](/slides/es/python-java/group/).

**¿Cómo obtengo una imagen de un SmartArt específico (p. ej., para una vista previa o informe)?**

Exporte una miniatura/imágen de la forma; la biblioteca puede [renderizar formas individuales](/slides/es/python-java/create-shape-thumbnails/) a archivos raster (PNG/JPG/TIFF).

**¿Se preservará la apariencia de SmartArt al convertir toda la presentación a PDF?**

Sí. El motor de renderizado apunta a una alta fidelidad para la [exportación a PDF](/slides/es/python-java/convert-powerpoint-to-pdf/), con una variedad de opciones de calidad y compatibilidad.