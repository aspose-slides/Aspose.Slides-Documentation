---
title: Export Math Equations from Presentations in Python
linktitle: Export Equations
type: docs
weight: 30
url: /python-net/exporting-math-equations/
keywords:
- export math equations
- export equations to LaTeX
- PowerPoint to LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Export math equations from PowerPoint presentations to LaTeX or MathML directly with Aspose.Slides for Python via .NET."
---

## **Introduction**

Aspose.Slides for Python via .NET allows you to export math equations from presentations. For example, you may need to extract equations from specific slides and reuse them in another program or platform.

{{% alert color="primary" %}}

You can export equations directly to LaTeX or to MathML, a popular standard for mathematical content used on the web and in many applications.

{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides can convert a PowerPoint math equation directly to LaTeX; an intermediate MathML file and an external converter are not required. A math equation is stored in a text frame as a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/). Use [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) to get a [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/), and then call [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). The method returns a string that you can save, display, send to another application, or process further.

The following example examines every text frame on every slide, finds all math portions, and writes each equation to a separate `.tex` file:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) returns all text frames found on a slide. The [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) type check separates genuine editable equations from ordinary text and images.

LaTeX engines and document templates do not all support the same commands, packages, or Unicode characters. Test the returned string with the LaTeX engine used by your application. If a symbol or Office Math element has no suitable representation in that environment, replace it in the returned string with a project-specific command or skip the equation and record the issue for review.

## **Save Math Equations as MathML**

Although humans can easily write LaTeX, MathML is typically generated automatically by applications. Because MathML is XML-based, programs can read and parse it reliably, so it is commonly used as an output and printing format across many fields.

The following sample code shows how to export a math equation from a presentation to MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

You can export either an entire math paragraph ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) or an individual block ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) to MathML. Both types provide a method to write to MathML.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

A formula lives in a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) and has a [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Images and regular text portions without a [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) are not exportable formulas.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

The export targets standard MathML (XML). Aspose uses Presentation MathML—the presentation subset of the standard—which is widely used across applications and the web.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Yes, if those objects contain text portions with a [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (i.e., genuine PowerPoint formulas), they are exported. If a formula is embedded as an image, it is not.

**Does exporting to MathML modify the original presentation?**

No. Writing MathML is a serialization of the formula’s content; it does not modify the presentation file.
