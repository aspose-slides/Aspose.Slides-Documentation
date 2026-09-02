---
title: Export Math Equations from Presentations in .NET
linktitle: Export Equations
type: docs
weight: 30
url: /net/exporting-math-equations/
keywords:
- export math equations
- export equations to LaTeX
- PowerPoint to LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Export math equations from PowerPoint presentations to LaTeX or MathML directly with Aspose.Slides for .NET."
---

## **Introduction**

Aspose.Slides for .NET allows you to export math equations from presentations. For example, you may need to extract the mathematical equations on slides (from a specific presentation) and use them in another program or platform. 

{{% alert color="info" %}} 

You can export equations directly to LaTeX or to MathML, a popular standard for mathematical content used on the web and in many applications.

{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides can convert a PowerPoint math equation directly to LaTeX; an intermediate MathML file and an external converter are not required. A math equation is stored in a text frame as a [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/). Use [MathPortion.MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/mathparagraph/) to get an [IMathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/), and then call [IMathParagraph.ToLatex](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathparagraph/tolatex/). The method returns a string that you can save, display, send to another application, or process further.

The following example examines every text frame on every slide, finds all math portions, and writes each equation to a separate `.tex` file:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/) returns all text frames found on a slide. The [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) type check separates genuine editable equations from ordinary text and images.

LaTeX engines and document templates do not all support the same commands, packages, or Unicode characters. Test the returned string with the LaTeX engine used by your application. If a symbol or Office Math element has no suitable representation in that environment, replace it in the returned string with a project-specific command or skip the equation and record the issue for review.

## **Save Math Equations as MathML**

While humans easily write the code for some equation formats like LaTeX, they struggle to write the code for MathML because the latter is meant to be generated automatically by apps. Programs read and parse MathML easily because its code is in XML, so MathML is commonly used as an output and printing format in many fields. 

This sample code shows you how to export a math equation from a presentation to MathML:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

You can export either an entire math paragraph ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)) or an individual block ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) to MathML. Both types provide a method to write to MathML.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

A formula lives in a [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) and has a [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). Images and regular text portions without a [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) are not exportable formulas.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

The export targets standard MathML (XML). Aspose uses Presentation MathML—the presentation subset of the standard—which is widely used across applications and the web.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Yes, if those objects contain text portions with a [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) (i.e., genuine PowerPoint formulas), they are exported. If a formula is embedded as an image, it is not.

**Does exporting to MathML modify the original presentation?**

No. Writing MathML is a serialization of the formula’s content; it does not modify the presentation file.
