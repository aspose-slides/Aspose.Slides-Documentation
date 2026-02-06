---
title: MathText
type: docs
weight: 160
url: /python-net/examples/elements/math-text/
keywords:
- math text
- add math text
- access math text
- remove math text
- format math text
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Work with math text in Python using Aspose.Slides: create and edit equations, fractions, radicals, scripts, formatting, and render results for PPT and PPTX."
---

Illustrates working with mathematical text shapes and formatting equations using **Aspose.Slides for Python via .NET**.

## **Add Math Text**

Create a math shape containing a fraction and the Pythagorean formula.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Add a Math shape to the slide.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Access the math paragraph.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Add a simple fraction: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Add equation: c² = a² + b².
        math_block = (
            slides.mathtext.MathematicalText("c")
            .set_superscript("2")
            .join("=")
            .join(slides.mathtext.MathematicalText("a").set_superscript("2"))
            .join("+")
            .join(slides.mathtext.MathematicalText("b").set_superscript("2"))
        )
        math_paragraph.add(math_block)

        presentation.save("math_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Access Math Text**

Locate a shape that contains a math paragraph on the slide.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Find the first shape that contains a math paragraph.
        math_shape = next(
            (
                shape for shape in slide.shapes
                if isinstance(shape, slides.AutoShape)
                and shape.text_frame is not None
                and any(
                    any(isinstance(portion, slides.mathtext.MathPortion) for portion in paragraph.portions)
                    for paragraph in shape.text_frame.paragraphs
                )
            ),
            None
        )
```

## **Remove Math Text**

Delete a math shape from the slide.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a shape with math text.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Format Math Text**

Set font properties for a math portion.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Assuming the first shape is a shape with math text.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```
