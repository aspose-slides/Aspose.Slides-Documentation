---
title: Párrafo
type: docs
weight: 60
url: /net/paragraph/
keywords: "Párrafo, porción, coordenada de párrafo, coordenada de porción, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Párrafo y porción en presentación de PowerPoint en C# o .NET"
---

## **Obtener coordenadas de párrafo y porción en TextFrame**
Usando Aspose.Slides para .NET, los desarrolladores ahora pueden obtener las coordenadas rectangulares para el párrafo dentro de la colección de párrafos de TextFrame. También permite obtener las coordenadas de la porción dentro de la colección de porciones de un párrafo. En este tema, vamos a demostrar con la ayuda de un ejemplo cómo obtener las coordenadas rectangulares para el párrafo junto con la posición de la porción dentro de un párrafo.

## **Obtener coordenadas rectangulares del párrafo**
Se ha agregado el nuevo método **GetRect()**. Permite obtener el rectángulo de límites del párrafo.

```c#
// Instanciar un objeto de presentación que representa un archivo de presentación
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Obtener tamaño de párrafo y porción dentro de la celda de texto de la tabla** ##

Para obtener el tamaño y las coordenadas de la [Porción](https://reference.aspose.com/slides/net/aspose.slides/portion) o [Párrafo](https://reference.aspose.com/slides/net/aspose.slides/paragraph) en el marco de texto de una celda de tabla, se pueden utilizar los métodos [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/methods/getrect) y [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/methods/getrect).

Este código de ejemplo demuestra la operación descrita:

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