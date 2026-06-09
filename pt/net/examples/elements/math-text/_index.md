---
title: Texto Matemático
type: docs
weight: 160
url: /pt/net/examples/elements/math-text/
keywords:
- texto matemático
- adicionar texto matemático
- acessar texto matemático
- remover texto matemático
- formatar texto matemático
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Explore exemplos de MathematicalText do Aspose.Slides for .NET: crie e formate equações, frações, matrizes e símbolos com C# em apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como trabalhar com formas de texto matemático e formatar equações usando **Aspose.Slides for .NET**.

## **Adicionar Texto Matemático**

Crie uma forma matemática contendo uma fração e a fórmula de Pitágoras.

```csharp
static void AddMathText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Adicionar uma forma Math ao slide.
    var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

    // Acessar o parágrafo matemático.
    var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

    // Adicionar uma fração simples: x / y
    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    // Adicionar equação: c² = a² + b²
    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);
}
```

## **Acessar Texto Matemático**

Localize uma forma que contenha um parágrafo matemático no slide.

```csharp
static void AccessMathText()
{
    using var presentation = new Presentation("sample.pptx");
    var slide = presentation.Slides[0];

    // Encontrar a primeira forma que contém um parágrafo matemático.
    var mathShape = slide.Shapes
        .OfType<IAutoShape>()
        .FirstOrDefault(s =>
            s.TextFrame != null &&
            s.TextFrame.Paragraphs.Any(p =>
                p.Portions.Any(portion => portion is MathPortion)));

    if (mathShape != null)
    {
        var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Exemplo: criar uma fração (não adicionada aqui).
        var fraction = new MathematicalText("x").Divide("y");

        // Use mathParagraph ou fraction conforme necessário...
    }
}
```

## **Remover Texto Matemático**

Exclua uma forma matemática do slide.

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

## **Formatar Texto Matemático**

Defina as propriedades da fonte para uma porção matemática.

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