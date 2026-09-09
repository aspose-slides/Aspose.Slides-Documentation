---
title: Obtener límites de porciones de texto de presentaciones en Python a través de Java
linktitle: Límites de porción
type: docs
weight: 47
url: /es/python-java/portion-bounds/
keywords:
- límites de porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda cómo recuperar los límites de una porción de texto en presentaciones de PowerPoint usando Aspose.Slides para Python a través de Java."
---
## **Descripción general**

Una porción de texto representa un fragmento específico de texto dentro de un párrafo y le permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando necesita obtener los límites de un fragmento de texto, aplicar formato solo a una parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción mediante [Portion.getRect](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getRect). También muestra cómo obtener las coordenadas del inicio de una porción mediante [Portion.getCoordinates](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getCoordinates). Además, destaca escenarios comunes relacionados con las porciones, como aplicar un hipervínculo a un único fragmento de texto, comprender cómo se resuelve el formato a través de la porción, el párrafo, el marco de texto y la herencia del tema, y manejar casos en los que una fuente especificada no está disponible.

## **Obtener el rectángulo delimitador de una porción de texto**

Use [Portion.getRect](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getRect) para recuperar el rectángulo delimitador de una porción de texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Obtener las coordenadas de una porción de texto**

Use [Portion.getCoordinates](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/#getCoordinates) para recuperar las coordenadas del comienzo de una porción de texto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un único párrafo?**

Sí, puede [asignar un hipervínculo](/slides/es/python-java/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué anula una porción y qué se toma de un párrafo o de un marco de texto?**

Las propiedades a nivel de porción tienen la precedencia más alta. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/), Aspose.Slides la toma del [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/). Si tampoco está establecida allí, Aspose.Slides usa el estilo del [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/es/python-java/aspose.slides/theme/).

**¿Qué ocurre si la fuente especificada para una porción falta en la máquina o servidor de destino?**

Se aplican las [Reglas de sustitución de fuentes](/slides/es/python-java/font-selection-sequence/). El texto puede volver a fluir: las métricas, la hyphenación y el ancho pueden cambiar, lo que afecta a una posición precisa.

**¿Puedo establecer transparencia o un degradado de relleno de texto específico de la porción de forma independiente del resto del párrafo?**

Sí, el color, el relleno y la transparencia del texto a nivel de la [Portion](https://reference.aspose.com/slides/es/python-java/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.