---
title: Obtener límites de párrafo de presentaciones en .NET
linktitle: Límites de párrafo
type: docs
weight: 43
url: /es/net/paragraph-bounds/
keywords:
- límites de párrafo
- coordenada de párrafo
- tamaño de párrafo
- marco de texto
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo obtener los límites de párrafo en Aspose.Slides para .NET y optimizar la posición del texto en presentaciones de PowerPoint."
---
## **Visión general**

Este artículo explica cómo obtener los límites, el tamaño y las coordenadas de los párrafos en Aspose.Slides. Muestra cómo recuperar un rectángulo de párrafo a partir de un [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) mediante [IParagraph.GetRect](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getrect/), cómo obtener las coordenadas del párrafo dentro del marco de texto de una celda de tabla, y destaca detalles importantes como las unidades de medida, el efecto del ajuste de texto en los límites, la conversión a píxeles y los valores de formato de párrafo efectivos.

## **Obtener coordenadas rectangulares de un párrafo**

Utilice [IParagraph.GetRect](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getrect/) para obtener el rectángulo delimitador de un párrafo.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Obtener el tamaño de un párrafo dentro de un marco de texto de celda de tabla**

Para obtener el tamaño y las coordenadas de un [IParagraph](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/) en el marco de texto de una celda de tabla, utilice [IParagraph.GetRect](https://reference.aspose.com/slides/es/net/aspose.slides/iparagraph/getrect/). El rectángulo devuelto es relativo al marco de texto de la celda de tabla, por lo que debe añadir la posición de la tabla y el desplazamiento de la celda cuando necesite coordenadas a nivel de diapositiva.

El siguiente ejemplo obtiene los límites del párrafo dentro de una celda de tabla y dibuja rectángulos en la diapositiva para visualizarlos:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿En qué unidades se miden las coordenadas del párrafo?**

Se miden en puntos, donde 1 pulgada equivale a 72 puntos. Esto se aplica a todas las coordenadas y dimensiones de la diapositiva.

**¿Afecta el ajuste de texto a los límites del párrafo?**

Sí. Si [TextFrameFormat.WrapText](https://reference.aspose.com/slides/es/net/aspose.slides/textframeformat/wraptext/) está habilitado para el [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/), el texto se ajusta para que quepa en el ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando esta fórmula: píxeles = puntos × (DPI / 72). El resultado depende del DPI elegido para el renderizado o la exportación.

**¿Cómo obtener los parámetros de formato de párrafo “efectivos”, teniendo en cuenta la herencia de estilos?**

Utilice la [effective paragraph formatting data structure](/slides/es/net/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.