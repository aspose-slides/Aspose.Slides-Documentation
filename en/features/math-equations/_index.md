---
title: Work with mathematical equations
description: Create and edit equations as structured mathematical content.
type: docs
url: /features/math-equations/
weight: 840
feature_id: math-equations
feature_group: text
translationKey: slides-feature-math-equations
feature_catalogue_version: 3
feature_guides:
- /slides/net/powerpoint-math-equations/
---

## **Overview**

Build equations from mathematical elements such as fractions, radicals and subscripts. Read and edit the equation model in a presentation, or export it to LaTeX or MathML for another workflow. Equations can remain editable mathematical content instead of pictures.

## **Usage example**

This C# example creates the editable equation x²/y as a superscript inside a stacked fraction. It saves `math-equations.pptx` and a PNG preview. The rendering host needs a suitable math font, such as Cambria Math.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddMathShape(40, 40, 500, 120);
var mathParagraph = ((MathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
var numerator = new MathematicalText("x").SetSuperscript("2");
var fraction = numerator.Divide(new MathematicalText("y"), MathFractionTypes.Bar);
mathParagraph.Add(new MathBlock(fraction));
presentation.Save("math-equations.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("math-equations.png", Aspose.Slides.ImageFormat.Png);
```

## **FAQ**

### **Can I create an equation by importing a LaTeX string?**

The conversion here is export to LaTeX or MathML. Build the equation through the mathematical elements when creating it in the presentation.

### **Are equations stored as editable math objects or images?**

The example stores an editable equation model in the PPTX, rather than replacing it with a picture. An image export is only a rendered view of that model.

### **How can I export an equation to MathML?**

Export the mathematical paragraph through its MathML writer into a stream. Use the equation guide for the complete export workflow.

## **Guides**

- [Add Math Equations to PowerPoint Presentations in .NET](/slides/net/powerpoint-math-equations/)

Related feature: [Format text within slides](/slides/features/text-formatting/).
