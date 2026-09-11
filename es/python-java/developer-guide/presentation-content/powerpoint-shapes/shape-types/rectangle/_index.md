---
title: Añadir rectángulos a presentaciones en Python vía Java
linktitle: Rectángulo
type: docs
weight: 80
url: /es/python-java/rectangle/
keywords:
- añadir rectángulo
- crear rectángulo
- forma de rectángulo
- rectángulo simple
- rectángulo con formato
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Mejora tus presentaciones de PowerPoint añadiendo rectángulos con Aspose.Slides para Python mediante Java—diseña y modifica formas de forma programada fácilmente."
---
## **Visión general**

Este artículo muestra cómo añadir formas de rectángulo a diapositivas de PowerPoint utilizando Aspose.Slides. Cubre la creación de un rectángulo simple, la creación de un rectángulo con formato y el guardado de la presentación actualizada como un archivo PPTX.

También verá cómo aplicar un formato básico al rectángulo, como un color de relleno sólido, color de línea y anchura de línea. Además, las preguntas frecuentes del artículo apuntan a tareas relacionadas con rectángulos, incluyendo esquinas redondeadas, rellenos con imágenes, efectos visuales, hipervínculos, bloqueos de forma, opciones de exportación y propiedades efectivas.

## **Añadir un rectángulo a una diapositiva**

Para añadir un rectángulo simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtenga una referencia a una diapositiva por su índice.
- Añada un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo rectángulo usando el método [addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un rectángulo simple a la primera diapositiva de la presentación.

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

    # Añadir una forma de rectángulo.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Guardar el archivo PPTX en disco.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Añadir un rectángulo con formato a una diapositiva**

Para añadir un rectángulo con formato a una diapositiva, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtenga una referencia a una diapositiva por su índice.
- Añada un [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) de tipo rectángulo usando el método [addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).
- Establezca el [fill type](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) del rectángulo a sólido.
- Establezca el color del rectángulo usando el método [setColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/colorformat/#setColor) sobre el color de relleno sólido del objeto [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/) asociado al objeto [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/).
- Establezca el color del contorno del rectángulo.
- Establezca el ancho del contorno del rectángulo.
- Guarde la presentación modificada como un archivo PPTX.

Los pasos anteriores se implementan en el ejemplo que se muestra a continuación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciar la clase Presentation que representa el archivo PPTX.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma de rectángulo.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formatear el relleno del rectángulo.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formatear el contorno del rectángulo.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Guardar el archivo PPTX en disco.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Cómo añado un rectángulo con esquinas redondeadas?**

Utilice el [shape type](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapetype/) con esquinas redondeadas y ajuste el radio de la esquina en las propiedades de la forma; el redondeado también puede aplicarse por esquina mediante ajustes geométricos.

**¿Cómo relleno un rectángulo con una imagen (textura)?**

Seleccione el [fill type](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) de imagen, proporcione la fuente de la imagen y configure los [stretching/tiling modes](https://reference.aspose.com/slides/es/python-java/aspose.slides/picturefillmode/).

**¿Puede un rectángulo tener sombra y brillo?**

Sí. [Outer/inner shadow, glow, and soft edges](/slides/es/python-java/shape-effect/) están disponibles con parámetros ajustables.

**¿Puedo convertir un rectángulo en un botón con un hipervínculo?**

Sí. [Assign a hyperlink](/slides/es/python-java/manage-hyperlinks/) al hacer clic en la forma (ir a una diapositiva, archivo, dirección web o correo electrónico).

**¿Cómo puedo proteger un rectángulo contra movimientos y cambios?**

[Use shape locks](/slides/es/python-java/applying-protection-to-presentation/): puede prohibir el movimiento, el cambio de tamaño, la selección o la edición de texto para preservar el diseño.

**¿Puedo convertir un rectángulo a una imagen rasterizada o SVG?**

Sí. Puede [render the shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getImage) a una imagen con un tamaño/escala especificados o [export it as SVG](/slides/es/python-java/create-shape-thumbnails/) para uso vectorial.

**¿Cómo obtengo rápidamente las propiedades reales (efectivas) de un rectángulo teniendo en cuenta el tema y la herencia?**

[Use the shape’s effective properties](/slides/es/python-java/shape-effective-properties/): la API devuelve valores calculados que tienen en cuenta los estilos del tema, el diseño y la configuración local, simplificando el análisis de formato.