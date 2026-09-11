---
title: Añadir formas de línea a presentaciones en Python mediante Java
linktitle: Línea
type: docs
weight: 50
url: /es/python-java/line/
keywords:
- línea
- crear línea
- añadir línea
- línea simple
- configurar línea
- personalizar línea
- estilo de guiones
- cabeza de flecha
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a manipular el formato de líneas en presentaciones de PowerPoint con Aspose.Slides para Python mediante Java. Descubra propiedades, métodos y ejemplos."
---
## **Descripción general**

Aspose.Slides le permite añadir formas de línea a diapositivas de PowerPoint mediante código. Este artículo muestra cómo crear una línea simple y cómo personalizar una línea para que aparezca como una flecha.

Aprenderá cómo añadir una forma de línea a una diapositiva, ajustar su apariencia visual y guardar la presentación actualizada. Los ejemplos se centran en configuraciones prácticas de formato de línea, como estilo, ancho, patrón de guiones, opciones de cabeza de flecha y color de relleno.

## **Crear una línea simple**

Para añadir una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtenga una referencia a una diapositiva por su índice.
- Añada una forma de línea mediante el método [addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) de la objeto [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).
- Guarde la presentación modificada como un archivo PPTX.

El siguiente ejemplo añade una línea a la primera diapositiva de la presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanciar la clase Presentation que representa el archivo PPTX.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma de línea.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Guardar el archivo PPTX en disco.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crear una línea con forma de flecha**

Aspose.Slides for Python via Java también permite a los desarrolladores configurar propiedades de línea para que una línea resulte más atractiva. Para configurar una línea con forma de flecha, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtenga una referencia a una diapositiva por su índice.
- Añada una forma de línea mediante el método [addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) de la objeto [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).
- Establezca el [estilo de línea](https://reference.aspose.com/slides/es/python-java/aspose.slides/linestyle/) a uno de los estilos ofrecidos por Aspose.Slides for Python via Java.
- Establezca el ancho de la línea.
- Establezca el [estilo de guiones](https://reference.aspose.com/slides/es/python-java/aspose.slides/linedashstyle/) a uno de los estilos ofrecidos por Aspose.Slides for Python via Java.
- Establezca el [estilo de cabeza de flecha](https://reference.aspose.com/slides/es/python-java/aspose.slides/linearrowheadstyle/) y la [longitud](https://reference.aspose.com/slides/es/python-java/aspose.slides/linearrowheadlength/) al inicio de la línea.
- Establezca el [estilo de cabeza de flecha](https://reference.aspose.com/slides/es/python-java/aspose.slides/linearrowheadstyle/) y la [longitud](https://reference.aspose.com/slides/es/python-java/aspose.slides/linearrowheadlength/) al final de la línea.
- Guarde la presentación modificada como un archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Instanciar la clase Presentation que representa el archivo PPTX.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma de línea.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Aplicar formato a la línea.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Guardar el archivo PPTX en disco.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo convertir una línea normal en un conector para que se "ajuste" a las formas?**

No. Una línea normal (un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, utilice el tipo [Connector](https://reference.aspose.com/slides/es/python-java/aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/python-java/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

Lea las [propiedades efectivas](/slides/es/python-java/shape-effective-properties/) de la línea y su relleno; estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (mover, cambiar el tamaño)?**

Sí. Las formas proporcionan [objetos de bloqueo](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#getAutoShapeLock) que le permiten [denegar operaciones de edición](/slides/es/python-java/applying-protection-to-presentation/).