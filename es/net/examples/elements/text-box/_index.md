---
title: Caja de texto
type: docs
weight: 40
url: /es/net/examples/elements/text-box/
keywords:
- ejemplo de caja de texto
- agregar caja de texto
- acceder a caja de texto
- eliminar caja de texto
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear y formatear cajas de texto en C# con Aspose.Slides: establecer fuentes, alineación, ajuste de texto, autofit y enlaces para pulir diapositivas para PowerPoint y OpenDocument."
---

En Aspose.Slides, un **cuadro de texto** se representa mediante un `AutoShape`. Casi cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y muestra solo texto.

Esta guía explica cómo agregar, acceder y eliminar cuadros de texto programáticamente.

## Agregar un cuadro de texto

Un cuadro de texto es simplemente un `AutoShape` sin relleno ni borde y con algún texto formateado. Así es como se crea uno:

```csharp
public static void Add_TextBox()
{
    using var pres = new Presentation();

    // Create a rectangle shape (defaults to filled with border and no text)
    var textBox = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Remove fill and border to make it look like a typical text box
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Set text formatting
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Assign the actual text content
    textBox.TextFrame.Text = "Some text...";
}
````

> 💡 **Nota:** Cualquier `AutoShape` que contenga un `TextFrame` no vacío puede funcionar como un cuadro de texto.

## Acceder a los cuadros de texto por contenido

Para encontrar todos los cuadros de texto que contengan una palabra clave específica (p. ej. "Slide"), recorra las formas y verifique su texto:

```csharp
public static void Access_TextBox()
{
    using var pres = new Presentation();

    foreach (var shape in pres.Slides[0].Shapes)
    {
        // Only AutoShapes can contain editable text
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Do something with the matching text box
            }
        }
    }
}
```

## Eliminar cuadros de texto por contenido

Este ejemplo encuentra y elimina todos los cuadros de texto en la primera diapositiva que contengan una palabra clave específica:

```csharp
public static void Remove_TextBox()
{
    using var pres = new Presentation();

    var shapesToRemove = pres.Slides[0].Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => pres.Slides[0].Shapes.Remove(shape));
}
```

> 💡 **Consejo:** Siempre cree una copia de la colección de formas antes de modificarla durante la iteración para evitar errores de modificación de la colección.