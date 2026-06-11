---
title: Matematisk text
type: docs
weight: 160
url: /sv/python-net/examples/elements/math-text/
keywords:
- matematisk text
- lägg till matematisk text
- åtkomst till matematisk text
- ta bort matematisk text
- formatera matematisk text
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Arbeta med matematisk text i Python med Aspose.Slides: skapa och redigera ekvationer, bråk, radikaler, skript, formatering och rendera resultat för PPT och PPTX."
---
Illustrerar hur man arbetar med matematiska textformer och formaterar ekvationer med hjälp av **Aspose.Slides for Python via .NET**.

## **Lägg till matematisk text**

Skapa en matematisk form som innehåller en bråkdel och Pythagoras formel.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Lägg till en matematisk form på bilden.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Åtkomst till det matematiska stycket.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Lägg till ett enkelt bråk: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Lägg till ekvation: c² = a² + b².
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

## **Åtkomst till matematisk text**

Lokalisera en form som innehåller ett matematiskt stycke på bilden.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Hitta den första formen som innehåller ett matematiskt stycke.
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

## **Ta bort matematisk text**

Ta bort en matematisk form från bilden.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är en form med matematisk text.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatera matematisk text**

Ställ in teckensnittsegenskaper för en matematisk del.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Antar att den första formen är en form med matematisk text.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```