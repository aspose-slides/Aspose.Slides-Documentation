---
title: Math Text
type: docs
weight: 160
url: /net/examples/elements/math-text/
keywords:
- math text
- add math text
- access math text
- remove math text
- format math text
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Explore Aspose.Slides for .NET MathematicalText examples: create and format equations, fractions, matrices, and symbols with C# in PPT, PPTX, and ODP presentations."
---

This article demonstrates working with mathematical text shapes and formatting equations using **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add Math Text**

Create a math shape containing a fraction and the Pythagorean formula.

```csharp
using Aspose.Slides.Export;
using System;
using Aspose.Slides;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Add a Math shape to the slide.
var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

// Access the math paragraph.
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

// Add a simple fraction: x / y
var fraction = new MathematicalText("x").Divide("y");
mathParagraph.Add(new MathBlock(fraction));

// Add equation: c² = a² + b²
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));

mathParagraph.Add(mathBlock);

presentation.Save("math-text-01.pptx", SaveFormat.Pptx);
```

## **Access Math Text**

Locate a shape that contains a math paragraph on the slide.

```csharp
using System;
using Aspose.Slides.Export;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddMathShape(50, 50, 200, 80);
var seed = (MathPortion)shape.TextFrame.Paragraphs[0].Portions[0];
seed.MathParagraph.Add(new MathBlock(new MathematicalText("x").Divide("y")));

// Read the first math portion from the slide.
var mathPortion = slide.Shapes.OfType<IAutoShape>()
    .SelectMany(item => item.TextFrame.Paragraphs)
    .SelectMany(paragraph => paragraph.Portions)
    .OfType<MathPortion>()
    .First();
Console.WriteLine(mathPortion.MathParagraph.Count);

presentation.Save("math-text-02.pptx", SaveFormat.Pptx);
```

## **Remove Math Text**

Delete a math shape from the slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
var fraction = new MathematicalText("x").Divide("y");
mathParagraph.Add(new MathBlock(fraction));

slide.Shapes.Remove(mathShape);

presentation.Save("math-text-03.pptx", SaveFormat.Pptx);
```

## **Format Math Text**

Set font properties for a math portion.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var mathShape = slide.Shapes.AddMathShape(50, 50, 100, 50);
var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
var fraction = new MathematicalText("x").Divide("y");
mathParagraph.Add(new MathBlock(fraction));

// The paragraph default is persisted for its mathematical content.
mathShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

presentation.Save("math-text-04.pptx", SaveFormat.Pptx);
```
