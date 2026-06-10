---
title: Matematikai szöveg
type: docs
weight: 160
url: /hu/python-net/examples/elements/math-text/
keywords:
- matematikai szöveg
- matematikai szöveg hozzáadása
- matematikai szöveg elérése
- matematikai szöveg eltávolítása
- matematikai szöveg formázása
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Matematikai szöveggel dolgozás Pythonban az Aspose.Slides használatával: egyenletek, törtek, gyökök, indexek, formázás létrehozása és szerkesztése, valamint az eredmények megjelenítése PPT és PPTX formátumban."
---
Bemutatja a matematikai szöveges alakzatok használatát és egyenletek formázását a **Aspose.Slides for Python via .NET** segítségével.

## **Matematikai szöveg hozzáadása**

Hozzon létre egy matematikai alakzatot, amely tartalmaz egy törtet és a Pitagorasz-formulát.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adj hozzá egy Math alakzatot a diára.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Hozzáférés a matematikai bekezdéshez.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Adj hozzá egy egyszerű törtet: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Adj hozzá egy egyenletet: c² = a² + b².
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

## **Matematikai szöveg elérése**

Keressen egy alakzatot, amely tartalmaz egy matematikai bekezdést a dián.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Keresse meg az első alakzatot, amely matematikai bekezdést tartalmaz.
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

## **Matematikai szöveg eltávolítása**

Törölje a matematikai alakzatot a diáról.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy matematikai szöveget tartalmazó alakzat.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Matematikai szöveg formázása**

Állítsa be a betűtípus tulajdonságait egy matematikai részlethez.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Feltételezve, hogy az első alakzat egy matematikai szöveget tartalmazó alakzat.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```