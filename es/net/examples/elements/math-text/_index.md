---
title: Texto matemático
type: docs
weight: 160
url: /es/net/examples/elements/math-text/
keywords:
- texto matemático
- añadir texto matemático
- acceder al texto matemático
- eliminar texto matemático
- formatear texto matemático
- ejemplo de código
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Explore ejemplos de MathematicalText de Aspose.Slides for .NET: cree y formatee ecuaciones, fracciones, matrices y símbolos con C# en presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo trabajar con formas de texto matemático y dar formato a ecuaciones usando **Aspose.Slides for .NET**.

## **Añadir texto matemático**

Crea una forma matemática que contenga una fracción y la fórmula pitagórica.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Añadir una forma matemática a la diapositiva.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Acceder al párrafo matemático.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Añadir una fracción simple: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Añadir ecuación: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Acceder al texto matemático**

Ubica una forma que contenga un párrafo matemático en la diapositiva.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Encontrar la primera forma que contiene un párrafo matemático.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Ejemplo: crear una fracción (no añadida aquí).
        var fraction = new MathematicalText("x").Divide("y");

        // Utilizar mathParagraph o fraction según sea necesario...
    }
}
```

## **Eliminar texto matemático**

Elimina una forma matemática de la diapositiva.

```csharp
static void RemoveMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```

## **Formatear texto matemático**

Establece las propiedades de fuente para una porción matemática.

```csharp
static void FormatMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```