---
title: Wiskundige tekst
type: docs
weight: 160
url: /nl/python-net/examples/elements/math-text/
keywords:
- wiskundige tekst
- wiskundige tekst toevoegen
- wiskundige tekst openen
- wiskundige tekst verwijderen
- wiskundige tekst opmaken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Werk met wiskundige tekst in Python met Aspose.Slides: maak en bewerk vergelijkingen, breuken, wortels, scripts, opmaak, en render resultaten voor PPT en PPTX."
---
Illustreert het werken met wiskundige tekstvormen en het opmaken van vergelijkingen met behulp van **Aspose.Slides for Python via .NET**.

## **Wiskundige tekst toevoegen**

Maak een wiskundige vorm die een breuk en de Pythagoras‑formule bevat.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Voeg een wiskundige vorm toe aan de dia.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Toegang tot de wiskundige alinea.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Voeg een eenvoudige breuk toe: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Voeg een vergelijking toe: c² = a² + b².
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

## **Wiskundige tekst openen**

Zoek een vorm die een wiskundige alinea op de dia bevat.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Zoek de eerste vorm die een wiskundige alinea bevat.
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

## **Wiskundige tekst verwijderen**

Verwijder een wiskundige vorm van de dia.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Aangenomen dat de eerste vorm een vorm met wiskundige tekst is.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Wiskundige tekst opmaken**

Stel de lettertype‑eigenschappen in voor een wiskundig gedeelte.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Aangenomen dat de eerste vorm een vorm met wiskundige tekst is.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```