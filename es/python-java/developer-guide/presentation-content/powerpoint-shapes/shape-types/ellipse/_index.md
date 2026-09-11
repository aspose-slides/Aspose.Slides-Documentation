---
title: Añadir elipses a presentaciones en Python mediante Java
linktitle: Elipse
type: docs
weight: 30
url: /es/python-java/ellipse/
keywords:
- elipse
- forma
- añadir elipse
- crear elipse
- dibujar elipse
- elipse con formato
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprende a crear, dar formato y manipular formas de elipse en Aspose.Slides para Python mediante Java en presentaciones PPT y PPTX; se incluyen ejemplos de código en Python."
---
## **Visión general**

Este artículo muestra cómo añadir formas elípticas a diapositivas de PowerPoint mediante Aspose.Slides. Cubre la creación de una elipse sencilla, la creación de una elipse con formato y el guardado de la presentación actualizada como archivo PPTX. También aborda preguntas relacionadas, como trabajar con la posición y el tamaño de la elipse, controlar el orden de apilamiento y aplicar efectos de animación.

## **Crear una elipse**

Para añadir una elipse sencilla a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtener una referencia a una diapositiva mediante su índice.
- Añadir una elipse usando el método [addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) del objeto [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).
- Guardar la presentación modificada como archivo PPTX.

El siguiente ejemplo añade una elipse a la primera diapositiva:

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

    # Añadir una forma elíptica.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Guardar el archivo PPTX en disco.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crear una elipse con formato**

Para añadir una elipse con formato a una diapositiva, siga los pasos a continuación:

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
- Obtener una referencia a una diapositiva mediante su índice.
- Añadir una elipse usando el método [addAutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addAutoShape) del objeto [ShapeCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/).
- Establecer el tipo de relleno de la elipse a sólido.
- Establecer el color de relleno sólido mediante [getSolidFillColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/#getSolidFillColor) en el objeto [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/) asociado al objeto [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/).
- Establecer el color del contorno de la elipse.
- Establecer el ancho del contorno de la elipse.
- Guardar la presentación modificada como archivo PPTX.

El siguiente ejemplo añade una elipse con formato a la primera diapositiva de la presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instanciar la clase Presentation que representa el archivo PPTX.
presentation = Presentation()
try:
    # Obtener la primera diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Añadir una forma elíptica.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Dar formato al relleno de la elipse.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Dar formato al contorno de la elipse.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Guardar el archivo PPTX en disco.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**¿Cómo establezco la posición y el tamaño exactos de una elipse respecto a las unidades de la diapositiva?**

Las coordenadas y los tamaños se especifican normalmente **en puntos**. Para obtener resultados predecibles, base sus cálculos en el tamaño de la diapositiva y convierta los milímetros o pulgadas requeridos a puntos antes de asignar los valores.

**¿Cómo puedo colocar una elipse por encima o por debajo de otros objetos (controlar el orden de apilamiento)?**

Ajuste el orden de dibujo del objeto llevándolo al frente o enviándolo al fondo. Esto permite que la elipse se superponga a otros objetos o revele los que están debajo de ella.

**¿Cómo animo la aparición o el énfasis de una elipse?**

[Apply](/slides/es/python-java/shape-animation/) efectos de entrada, énfasis o salida a la forma, y configure disparadores y temporizaciones para orquestar cuándo y cómo se reproduce la animación.