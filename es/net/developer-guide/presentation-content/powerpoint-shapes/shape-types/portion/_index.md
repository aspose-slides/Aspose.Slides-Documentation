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
description: "Aprenda cómo gestionar porciones de texto en presentaciones de PowerPoint usando Aspose.Slides para .NET, mejorando el rendimiento y la personalización."
---

## **Obtener coordenadas de posición de la porción**
Se ha añadido el método **GetCoordinates()** a IPortion y a la clase Portion, lo que permite recuperar las coordenadas del inicio de la porción:
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


## **FAQ**

**¿Puedo aplicar un hipervínculo solo a una parte del texto dentro de un mismo párrafo?**

Sí, puedes [asignar un hipervínculo](/slides/es/net/manage-hyperlinks/) a una porción individual; solo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Portion y qué se toma de Paragraph/TextFrame?**

Las propiedades a nivel de Portion tienen la mayor precedencia. Si una propiedad no está establecida en el [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); si tampoco está establecida allí, la toma del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una Portion no está disponible en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/net/font-selection-sequence/). El texto puede refluenciar: métricas, guión y ancho pueden cambiar, lo que afecta a la posición precisa.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico para una Portion independiente del resto del párrafo?**

Sí, el color, relleno y transparencia del texto a nivel de [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.