---
title: Párrafo
type: docs
weight: 60
url: /es/net/paragraph/
keywords: "Párrafo, porción, coordenada de párrafo, coordenada de porción, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Párrafo y porción en una presentación de PowerPoint en C# o .NET"
---

## **Obtener coordenadas de párrafo y porción en TextFrame**
Usando Aspose.Slides para .NET, los desarrolladores ahora pueden obtener las coordenadas rectangulares de un **Paragraph** dentro de la colección de párrafos de un **TextFrame**. También permite obtener las coordenadas de una **portion** dentro de la colección de porciones de un párrafo. En este tema, demostraremos con un ejemplo cómo obtener las coordenadas rectangulares del párrafo junto con la posición de la porción dentro de un párrafo.

## **Obtener coordenadas rectangulares del párrafo**
Se ha añadido el nuevo método **GetRect()**. Permite obtener el rectángulo que delimita el párrafo.
```c#
// Instanciar un objeto Presentation que representa un archivo de presentación
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```


## **Obtener el tamaño del párrafo y la porción dentro del marco de texto de una celda de tabla**

Para obtener el tamaño y las coordenadas de la [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion) o del [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) en un marco de texto de una celda de tabla, puede usar los métodos [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) y [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

Este fragmento de código muestra la operación descrita:
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

**¿Afecta el ajuste de línea a los límites de un párrafo?**

Sí. Si el [wrapping](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/) está habilitado en el [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/), el texto se ajusta al ancho del área, lo que cambia los límites reales del párrafo.

**¿Pueden mapearse de forma fiable las coordenadas del párrafo a píxeles en la imagen exportada?**

Sí. Convierta puntos a píxeles usando: pixels = points × (DPI / 72). El resultado depende del DPI elegido para la renderización/exportación.

**¿Cómo obtener los parámetros de formato “efectivo” del párrafo, teniendo en cuenta la herencia de estilos?**

Utilice la [estructura de datos de formato de párrafo efectivo](/slides/es/net/shape-effective-properties/); devuelve los valores finales consolidados para sangrías, espaciado, ajuste, RTL y más.