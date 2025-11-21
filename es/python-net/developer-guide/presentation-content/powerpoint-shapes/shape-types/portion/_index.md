---
title: Gestionar porciones de texto en presentaciones con Python
linktitle: Porción de Texto
type: docs
weight: 70
url: /es/python-net/portion/
keywords:
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar porciones de texto en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Python mediante .NET, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de porciones de texto**

El método [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) se ha añadido a la clase [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) que permite obtener las coordenadas de las porciones de texto:
```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```


## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/python-net/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Porción y qué se toma del Párrafo/TextFrame?**

Las propiedades a nivel de Porción tienen la precedencia más alta. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/); si tampoco está establecida allí, la toma del [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una Porción no está presente en la máquina/servidor de destino?**

Se aplican las [Font substitution rules](/slides/es/python-net/font-selection-sequence/). El texto puede volver a fluir: las métricas, la separación de sílabas y el ancho pueden cambiar, lo que importa para una posición precisa.

**¿Puedo establecer una transparencia de relleno de texto o un degradado específico de Porción independiente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.