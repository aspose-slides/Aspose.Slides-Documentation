---
title: Obtener los límites de la porción de texto en presentaciones .NET
linktitle: Límites de la porción
type: docs
weight: 47
url: /es/net/portion-bounds/
keywords:
- límites de porción de texto
- porción de texto
- parte de texto
- coordenadas de texto
- posición de texto
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo obtener los límites de la porción de texto en presentaciones de PowerPoint usando Aspose.Slides para .NET."
---
## **Resumen**

Una porción de texto representa un fragmento concreto de texto dentro de un párrafo y le permite trabajar con ese fragmento de forma independiente del contenido circundante. En Aspose.Slides, las porciones pueden usarse cuando necesita obtener los límites de un fragmento de texto, aplicar formato sólo a una parte de un párrafo o controlar el comportamiento del texto a un nivel más detallado.

Este artículo muestra cómo obtener el rectángulo delimitador de una porción mediante [IPortion.GetRect](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/getrect/). También muestra cómo obtener las coordenadas del comienzo de una porción mediante [IPortion.GetCoordinates](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/getcoordinates/). Además, destaca escenarios comunes relacionados con porciones, como aplicar un hipervínculo a un único fragmento de texto, comprender cómo se resuelve el formato a través de la herencia de porción, párrafo, marco de texto y tema, y manejar casos en los que una fuente especificada no está disponible.

## **Obtener límites de una porción de texto**

Utilice [IPortion.GetRect](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/getrect/) para recuperar el rectángulo delimitador de una porción de texto:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Obtener coordenadas de una porción de texto**

Utilice [IPortion.GetCoordinates](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/getcoordinates/) para recuperar las coordenadas del comienzo de una porción de texto:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **Preguntas frecuentes**

**¿Puedo aplicar un hipervínculo sólo a parte del texto dentro de un único párrafo?**

Sí, puede [asignar un hipervínculo](/slides/es/net/manage-hyperlinks/) a una porción individual; sólo ese fragmento será clicable, no todo el párrafo.

**¿Cómo funciona la herencia de estilos: qué anula una porción y qué se toma de un párrafo o de un marco de texto?**

Las propiedades a nivel de porción tienen la máxima precedencia. Si una propiedad no está establecida en el [IPortion](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/), Aspose.Slides la toma del [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/). Si tampoco está establecida allí, Aspose.Slides usa el estilo del [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) o del [theme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/theme/).

**¿Qué ocurre si la fuente especificada para una porción falta en la máquina o el servidor de destino?**

Se aplican las [reglas de sustitución de fuentes](/slides/es/net/font-selection-sequence/). El texto puede volver a fluir: las métricas, la hyphenación y el ancho pueden cambiar, lo que afecta al posicionamiento preciso.

**¿Puedo establecer la transparencia del relleno de texto o un degradado específicos de la porción independientemente del resto del párrafo?**

Sí, el color, el relleno y la transparencia del texto a nivel del [IPortion](https://reference.aspose.com/slides/es/net/aspose.slides/iportion/) pueden diferir de los fragmentos vecinos.