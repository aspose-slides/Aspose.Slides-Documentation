---
title: Porción
type: docs
weight: 70
url: /es/net/portion/
keywords: "Porción, forma de PowerPoint, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Obtener porción en una presentación de PowerPoint en C# o .NET"
---

## **Obtener coordenadas de posición de la porción**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:
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

**¿Cómo funciona la herencia de estilos: qué sobrescribe una Portion y qué se toma del Paragraph/TextFrame?**

Las propiedades a nivel de Portion tienen la mayor precedencia. Si una propiedad no está establecida en la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), el motor la toma del [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); si tampoco está establecida allí, del [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) o del estilo del [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una Portion falta en la máquina/servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/net/font-selection-sequence/). El texto puede refluír: las métricas, la guionación y el ancho pueden cambiar, lo que es importante para un posicionamiento preciso.

**¿Puedo establecer una transparencia o degradado de relleno de texto específico de una Portion independiente del resto del párrafo?**

Sí, el color, el relleno y la transparencia del texto a nivel de [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) pueden diferir de los fragmentos vecinos.