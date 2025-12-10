---
title: Obtener límites de párrafo de presentaciones en .NET
linktitle: Párrafo
type: docs
weight: 60
url: /es/net/paragraph/
keywords:
- límites de párrafo
- límites de porción de texto
- coordenada de párrafo
- coordenada de porción
- tamaño de párrafo
- tamaño de porción de texto
- marco de texto
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo recuperar los límites de párrafo y de porción de texto en Aspose.Slides para .NET para optimizar la posición del texto en presentaciones de PowerPoint."
---

## **Obtener coordenadas de párrafo y porción en un TextFrame**
Con Aspose.Slides for .NET, los desarrolladores ahora pueden obtener las coordenadas rectangulares para Paragraph dentro de la colección de párrafos de TextFrame. También permite obtener las coordenadas de la porción dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar con un ejemplo cómo obtener las coordenadas rectangulares para un párrafo junto con la posición de la porción dentro de un párrafo.

## **Obtener coordenadas rectangulares de un párrafo**
Se ha añadido el nuevo método **GetRect()**. Permite obtener el rectángulo de límites del párrafo.
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Obtener el tamaño de un párrafo y de una porción dentro de un TextFrame de celda de tabla**
Para obtener el tamaño y las coordenadas del [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) o del [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) en un TextFrame de celda de tabla, puedes usar los métodos [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) y [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).
```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```


## **FAQ**

**¿En qué unidades se devuelven las coordenadas de un párrafo y de las porciones de texto?**

En puntos, donde 1 pulgada = 72 puntos. Esto se aplica a todas las coordenadas y dimensiones en la diapositiva.

**¿El ajuste de línea afecta los límites de un párrafo?**

Sí. Si el [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) está habilitado en el [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/), el texto se ajusta para encajar al ancho del área, lo que cambia los límites reales del párrafo.

**¿Se pueden mapear de manera fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierte puntos a píxeles usando: pixels = points × (DPI / 72). El resultado depende del DPI elegido para el renderizado/exportación.

**¿Cómo obtener los parámetros de formato de párrafo "efectivos", teniendo en cuenta la herencia de estilos?**

Utiliza la [estructura de datos de formato de párrafo efectivo](/slides/es/net/shape-effective-properties/); devuelve los valores consolidados finales para sangrías, espaciado, ajuste, RTL y más.