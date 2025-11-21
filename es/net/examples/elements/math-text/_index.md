---
title: Texto Matemático
type: docs
weight: 160
url: /es/net/examples/elements/math-text/
keywords:
- ejemplo de texto matemático
- agregar texto matemático
- acceder al texto matemático
- eliminar texto matemático
- formatear texto matemático
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Trabaje con texto matemático en C# usando Aspose.Slides: cree y edite ecuaciones, fracciones, radicales, scripts, formato y renderice resultados para PPT y PPTX."
---

Ilustra el trabajo con formas de texto matemático y el formato de ecuaciones usando **Aspose.Slides for .NET**.

## Añadir texto matemático

Cree una forma matemática que contenga una fracción y la fórmula pitagórica.
```csharp
static void Add_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Añadir una forma matemática a la diapositiva
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Acceder al párrafo matemático
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


## Acceder al texto matemático

Ubique una forma que contenga un párrafo matemático en la diapositiva.
```csharp
static void Access_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Encontrar la primera forma que contiene un párrafo matemático
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Ejemplo: crear una fracción (no añadido aquí)
        var fraction = new MathematicalText("x").Divide("y");

        // Usar mathParagraph o fraction según sea necesario...
    }
}
```


## Eliminar texto matemático

Elimine una forma matemática de la diapositiva.
```csharp
static void Remove_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    slide.Shapes.Remove(mathShape);
}
```


## Formatear texto matemático

Establezca las propiedades de fuente para una porción matemática.
```csharp
static void Format_Math_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    mathShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;
}
```
