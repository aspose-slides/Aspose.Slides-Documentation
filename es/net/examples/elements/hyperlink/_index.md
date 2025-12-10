---
title: Hipervínculo
type: docs
weight: 130
url: /es/net/examples/elements/hyperlink/
keywords:
- ejemplo de hipervínculo
- agregar hipervínculo
- acceder al hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Agregar, editar y eliminar hipervínculos en C# con Aspose.Slides: texto de enlace, formas, diapositivas, URL y correo electrónico; establecer destinos y acciones para PPT, PPTX y ODP."
---

Demuestra cómo agregar, acceder, eliminar y actualizar hipervínculos en formas usando **Aspose.Slides for .NET**.

## **Agregar un hipervínculo**

Cree una forma rectangular con un hipervínculo que apunta a un sitio web externo.
```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```


## **Acceder a un hipervínculo**

Lea la información del hipervínculo de la porción de texto de una forma.
```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```


## **Eliminar un hipervínculo**

Elimine el hipervínculo del texto de una forma.
```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```


## **Actualizar un hipervínculo**

Cambie el destino de un hipervínculo existente. Use `HyperlinkManager` para modificar texto que ya contiene un hipervínculo, lo que imita cómo PowerPoint actualiza los hipervínculos de forma segura.
```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Cambiar un hipervínculo dentro del texto existente debe hacerse vía
    // HyperlinkManager en lugar de establecer la propiedad directamente.
    // Esto imita cómo PowerPoint actualiza los hipervínculos de forma segura.
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
