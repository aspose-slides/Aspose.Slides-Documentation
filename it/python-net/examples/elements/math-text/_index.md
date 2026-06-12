---
title: "Testo Matematico"
type: docs
weight: 160
url: /it/python-net/examples/elements/math-text/
keywords:
  - "testo matematico"
  - "aggiungi testo matematico"
  - "accedi al testo matematico"
  - "rimuovi testo matematico"
  - "formatta testo matematico"
  - "esempi di codice"
  - "PowerPoint"
  - "OpenDocument"
  - "presentazione"
  - "Python"
  - "Aspose.Slides"
description: "Lavora con il testo matematico in Python usando Aspose.Slides: crea e modifica equazioni, frazioni, radici, script, formattazione e genera i risultati per PPT e PPTX."
---
Illustra come lavorare con forme di testo matematico e formattare le equazioni usando **Aspose.Slides for Python via .NET**.

## **Aggiungi Testo Matematico**

Crea una forma matematica contenente una frazione e la formula pitagorica.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Aggiungi una forma Math alla diapositiva.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Accedi al paragrafo matematico.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Aggiungi una frazione semplice: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Aggiungi equazione: c² = a² + b².
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

## **Accedi al Testo Matematico**

Individua una forma che contiene un paragrafo matematico nella diapositiva.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Trova la prima forma che contiene un paragrafo matematico.
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

## **Rimuovi Testo Matematico**

Elimina una forma matematica dalla diapositiva.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia una forma con testo matematico.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatta Testo Matematico**

Imposta le proprietà del carattere per una porzione matematica.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Supponendo che la prima forma sia una forma con testo matematico.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```