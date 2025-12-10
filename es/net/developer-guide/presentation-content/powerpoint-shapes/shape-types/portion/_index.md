---
title: Gestionar porciones de texto en presentaciones en .NET
linktitle: Porción de texto
type: docs
weight: 70
url: /es/net/portion/
keywords:
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a gestionar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para .NET, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de una porción de texto**
**GetCoordinates()** se ha añadido a la interfaz IPortion y a la clase Portion, lo que permite obtener las coordenadas del inicio de la porción:
```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```


## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un solo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/net/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué anula una Porción y qué se toma de Paragraph/TextFrame?**

Las propiedades a nivel de Porción tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), el motor la toma de la [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); si tampoco está establecida allí, se toma de la [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una Porción no está presente en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/net/font-selection-sequence/). El texto puede volver a fluir: las métricas, el guionado y el ancho pueden cambiar, lo que es importante para el posicionamiento preciso.

**¿Puedo establecer la transparencia o el degradado del relleno del texto a nivel de Porción, independiente del resto del párrafo?**

Sí, el color del texto, el relleno y la transparencia a nivel de [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) pueden ser diferentes de los fragmentos vecinos.