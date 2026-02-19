---
title: Cuadro de texto
type: docs
weight: 40
url: /es/net/examples/elements/text-box/
keywords:
- cuadro de texto
- añadir cuadro de texto
- acceder al cuadro de texto
- eliminar cuadro de texto
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con cuadros de texto en Aspose.Slides para .NET: añada, formatee, alinee, envuelva, ajuste automáticamente y aplique estilos al texto usando C# para presentaciones PPT, PPTX y ODP."
---
En Aspose.Slides, un **cuadro de texto** se representa mediante un `AutoShape`. Casi cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y muestra solo texto.

Esta guía explica cómo agregar, acceder y eliminar cuadros de texto mediante código.

## **Agregar un cuadro de texto**

Un cuadro de texto es simplemente un `AutoShape` sin relleno ni borde y con algo de texto formateado. Aquí se muestra cómo crear uno:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Crear una forma rectangular (por defecto con relleno, borde y sin texto).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Eliminar relleno y borde para que se parezca a un cuadro de texto típico.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Establecer el formato del texto.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Asignar el contenido de texto real.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Nota:** Cualquier `AutoShape` que contenga un `TextFrame` no vacío puede funcionar como un cuadro de texto.

## **Acceder a los cuadros de texto por contenido**

Para encontrar todos los cuadros de texto que contengan una palabra clave específica (p. ej. "Slide"), recorra las formas y compruebe su texto:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Solo los AutoShapes pueden contener texto editable.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Hacer algo con el cuadro de texto coincidente.
            }
        }
    }
}
```

## **Eliminar los cuadros de texto por contenido**

Este ejemplo encuentra y elimina todos los cuadros de texto de la primera diapositiva que contienen una palabra clave específica:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Consejo:** Siempre cree una copia de la colección de formas antes de modificarla durante la iteración para evitar errores de modificación de la colección.