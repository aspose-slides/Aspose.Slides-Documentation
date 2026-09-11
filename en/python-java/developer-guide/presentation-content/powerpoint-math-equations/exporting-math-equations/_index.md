---
title: Export Math Equations from Presentations in Python
linktitle: Export Equations
type: docs
weight: 30
url: /python-java/exporting-math-equations/
keywords:
- export math equations
- export equations to LaTeX
- PowerPoint to LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Export math equations from PowerPoint presentations to LaTeX or MathML directly with Aspose.Slides for Python via Java."
---

## **Introduction**

Aspose.Slides allows you to export math equations from presentations. For example, you may need to extract the mathematical equations on slides (from a specific presentation) and use them in another program or platform. 

{{% alert color="info" title="Note" %}} 

You can export equations directly to LaTeX or to MathML, a popular standard for mathematical content used on the web and in many applications.

{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides can convert a PowerPoint math equation directly to LaTeX; an intermediate MathML file and an external converter are not required. A math equation is stored in a text frame as an [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/). Use [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) to get an [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/), and then call [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex). The method returns a string that you can save, display, send to another application, or process further.

The following example examines every text frame on every slide, finds all math portions, and writes each equation to a separate `.tex` file:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/python-java/aspose.slides/slideutil/#getAllTextBoxes) returns all text frames found on a slide. The [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) type check separates genuine editable equations from ordinary text and images.

LaTeX engines and document templates do not all support the same commands, packages, or Unicode characters. Test the returned string with the LaTeX engine used by your application. If a symbol or Office Math element has no suitable representation in that environment, replace it in the returned string with a project-specific command or skip the equation and record the issue for review.

## **Save Math Equations as MathML**

While people can easily write code for some equation formats, such as LaTeX, MathML is harder to write by hand because it is designed to be generated automatically by applications. Programs can easily read and parse MathML because it is XML-based, so MathML is commonly used as an output and printing format in many fields. 

This sample code shows you how to export a math equation from a presentation to MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **FAQ**

**What exactly is exported to MathML—a paragraph or an individual formula block?**

You can export either an entire math paragraph ([MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/)) or an individual block ([MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/)) to MathML. Both types provide a method to write to MathML.

**How can I tell that an object on a slide is a math formula rather than regular text or an image?**

A formula lives in a [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) and has a [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/). Images and regular text portions without a [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) are not exportable formulas.

**Where does the MathML come from in a presentation—is it PowerPoint-specific or a standard?**

The export targets standard MathML (XML). Aspose uses Presentation MathML—the presentation subset of the standard—which is widely used across applications and the web.

**Is exporting formulas inside tables, SmartArt, groups, etc., supported?**

Yes, if those objects contain text portions with a [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) (i.e., genuine PowerPoint formulas), they are exported. If a formula is embedded as an image, it is not.

**Does exporting to MathML modify the original presentation?**

No. Writing MathML is a serialization of the formula’s content; it does not modify the presentation file.
