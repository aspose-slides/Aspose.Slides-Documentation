---
title: Tekst matematyczny
type: docs
weight: 160
url: /pl/python-net/examples/elements/math-text/
keywords:
- tekst matematyczny
- dodaj tekst matematyczny
- dostęp do tekstu matematycznego
- usuń tekst matematyczny
- formatowanie tekstu matematycznego
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Pracuj z tekstem matematycznym w Pythonie przy użyciu Aspose.Slides: twórz i edytuj równania, ułamki, pierwiastki, indeksy, formatowanie oraz renderuj wyniki dla PPT i PPTX."
---
Ilustruje pracę z kształtami tekstu matematycznego i formatowaniem równań przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj tekst matematyczny**

Utwórz kształt matematyczny zawierający ułamek i wzór Pitagorasa.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj kształt matematyczny do slajdu.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Uzyskaj dostęp do akapitu matematycznego.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Dodaj prosty ułamek: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Dodaj równanie: c² = a² + b².
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

## **Dostęp do tekstu matematycznego**

Zlokalizuj kształt, który zawiera akapit matematyczny na slajdzie.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Znajdź pierwszy kształt, który zawiera akapit matematyczny.
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

## **Usuń tekst matematyczny**

Usuń kształt matematyczny ze slajdu.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest kształtem z tekstem matematycznym.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatuj tekst matematyczny**

Ustaw właściwości czcionki dla części matematycznej.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest kształtem z tekstem matematycznym.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```