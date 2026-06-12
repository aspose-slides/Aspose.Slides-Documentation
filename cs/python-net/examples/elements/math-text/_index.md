---
title: Matematický text
type: docs
weight: 160
url: /cs/python-net/examples/elements/math-text/
keywords:
- matematický text
- přidat matematický text
- přístup k matematickému textu
- odstranit matematický text
- formátovat matematický text
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Práce s matematickým textem v Pythonu pomocí Aspose.Slides: vytváření a úprava rovnic, zlomků, kořenů, indexů, formátování a vykreslování výsledků pro PPT a PPTX."
---
Ukazuje práci s tvary obsahujícími matematický text a formátování rovnic pomocí **Aspose.Slides for Python via .NET**.

## **Přidat matematický text**

Vytvořte matematický tvar obsahující zlomek a Pythagorovu větu.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Přidat matematický tvar na snímek.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Přístup k matematickému odstavci.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Přidat jednoduchý zlomek: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Přidat rovnici: c² = a² + b².
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

## **Přístup k matematickému textu**

Najděte tvar, který obsahuje matematický odstavec na snímku.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Najít první tvar, který obsahuje matematický odstavec.
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

## **Odstranit matematický text**

Odstraňte matematický tvar ze snímku.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je tvar s matematickým textem.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formátovat matematický text**

Nastavte vlastnosti písma pro matematickou část.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Předpokládáme, že první tvar je tvar s matematickým textem.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```