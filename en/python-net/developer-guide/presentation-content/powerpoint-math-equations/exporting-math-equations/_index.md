---
title: Export Math Equations from Presentations in Python
linktitle: Export Equations
type: docs
weight: 30
url: /python-net/exporting-math-equations/
keywords:
- export math equations
- MathML
- LaTeX
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Unlock seamless export of math equations from PowerPoint to MathML using Aspose.Slides for Python via .NET—preserve formatting and boost compatibility."
---

Aspose.Slides for Python via .NET allows you to export math equations from presentations. For example, you may need to extract equations from specific slides and reuse them in another program or platform.

{{% alert color="primary" %}}

You can export equations to MathML, a widely used standard for representing mathematical content on the web and in many applications.

{{% /alert %}}

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
