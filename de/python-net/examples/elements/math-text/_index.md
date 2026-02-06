---
title: Mathe-Text
type: docs
weight: 160
url: /de/python-net/examples/elements/math-text/
keywords:
- Mathe-Text
- Mathe-Text hinzufügen
- Mathe-Text zugreifen
- Mathe-Text entfernen
- Mathe-Text formatieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Arbeiten Sie mit mathematischem Text in Python unter Verwendung von Aspose.Slides: Erstellen und bearbeiten Sie Gleichungen, Brüche, Radikale, Skripte, Formatierungen und rendern Sie die Ergebnisse für PPT und PPTX."
---
Veranschaulicht die Arbeit mit mathematischen Textformen und das Formatieren von Gleichungen mit **Aspose.Slides for Python via .NET**.

## **Mathe-Text hinzufügen**

Erstelle eine mathematische Form, die einen Bruch und die pythagoreische Formel enthält.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Füge eine mathematische Form zur Folie hinzu.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Greife auf den mathematischen Absatz zu.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Füge einen einfachen Bruch hinzu: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Füge die Gleichung hinzu: c² = a² + b².
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

## **Mathe-Text zugreifen**

Finde eine Form, die einen mathematischen Absatz auf der Folie enthält.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Finde die erste Form, die einen mathematischen Absatz enthält.
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

## **Mathe-Text entfernen**

Lösche eine mathematische Form von der Folie.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, die erste Form ist eine Form mit mathematischem Text.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Mathe-Text formatieren**

Setze Schriftarteigenschaften für einen mathematischen Teil.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Angenommen, die erste Form ist eine Form mit mathematischem Text.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```