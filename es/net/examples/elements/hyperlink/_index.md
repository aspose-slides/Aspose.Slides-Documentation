---
title: Hipervínculo
type: docs
weight: 130
url: /es/net/examples/elements/hyperlink/
keywords:
- hipervínculo
- agregar hipervínculo
- acceder hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Añadir y gestionar hipervínculos en Aspose.Slides for .NET: enlazar texto, formas e imágenes, establecer destinos y acciones para PPT, PPTX y ODP con ejemplos en C#."
---
Este artículo muestra cómo agregar, acceder, eliminar y actualizar hipervínculos en formas usando **Aspose.Slides for .NET**.

## **Agregar un hipervínculo**

Cree una forma rectangular con un hipervínculo que apunta a un sitio web externo.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Acceder a un hipervínculo**

Lea la información del hipervínculo a partir de la porción de texto de una forma.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Eliminar un hipervínculo**

Elimine el hipervínculo del texto de una forma.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Actualizar un hipervínculo**

Cambie el destino de un hipervínculo existente. Utilice `HyperlinkManager` para modificar el texto que ya contiene un hipervínculo, lo que imita cómo PowerPoint actualiza los hipervínculos de forma segura.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Cambiar un hipervínculo dentro de texto existente debe hacerse mediante
    // HyperlinkManager en lugar de establecer la propiedad directamente.
    // Esto imita cómo PowerPoint actualiza los hipervínculos de forma segura.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```