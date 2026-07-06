---
title: Obtener los límites de la porción de texto de presentaciones en Python
linktitle: Límites de porción
type: docs
weight: 47
url: /es/python-net/portion-bounds/
keywords:
- límites de porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo obtener los límites de la porción de texto en presentaciones PowerPoint y OpenDocument utilizando Aspose.Slides para Python mediante .NET."
---
## **Visión general**

Una porción de texto representa un fragmento específico de texto dentro de un párrafo y le permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando necesita obtener los límites de un fragmento de texto, aplicar formato solo a una parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción mediante [Portion.get_rect](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/get_rect/). También muestra cómo obtener las coordenadas del comienzo de una porción mediante [Portion.get_coordinates](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/get_coordinates/). Además, destaca escenarios comunes relacionados con porciones, como aplicar un hipervínculo a un solo fragmento de texto, comprender cómo se resuelve el formato a través de la herencia de porción, párrafo, marco de texto y tema, y gestionar casos en los que una fuente especificada no está disponible.

## **Obtener los límites de una porción de texto**

Utilice [Portion.get_rect](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/get_rect/) para recuperar el rectángulo delimitador de una porción de texto:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Obtener las coordenadas de una porción de texto**

Utilice [Portion.get_coordinates](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/get_coordinates/) para recuperar las coordenadas del comienzo de una porción de texto:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puede [assign a hyperlink](/slides/es/python-net/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué anula una porción y qué se toma de un párrafo o marco de texto?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/), Aspose.Slides la toma del [Paragraph](https://reference.aspose.com/slides/es/python-net/aspose.slides/paragraph/). Si tampoco está establecida allí, Aspose.Slides usa el estilo del [TextFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/textframe/) o del [theme](https://reference.aspose.com/slides/es/python-net/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una porción falta en la máquina o servidor de destino?**

Se aplican las [Font substitution rules](/slides/es/python-net/font-selection-sequence/). El texto puede reajustarse: las métricas, la hyphenation y el ancho pueden cambiar, lo que es importante para una posición precisa.

**¿Puedo establecer la transparencia o un degradado de relleno de texto específicos de la porción de forma independiente del resto del párrafo?**

Sí, el color, el relleno y la transparencia del texto a nivel de [Portion](https://reference.aspose.com/slides/es/python-net/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.