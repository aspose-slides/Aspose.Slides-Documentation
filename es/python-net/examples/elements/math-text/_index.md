---
title: Texto Matemático
type: docs
weight: 160
url: /es/python-net/examples/elements/math-text/
keywords:
- texto matemático
- agregar texto matemático
- acceder al texto matemático
- eliminar texto matemático
- formatear texto matemático
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Trabaje con texto matemático en Python usando Aspose.Slides: cree y edite ecuaciones, fracciones, radicales, scripts, formato, y genere resultados para PPT y PPTX."
---
Ilustra el trabajo con formas de texto matemático y el formato de ecuaciones usando **Aspose.Slides for Python via .NET**.

## **Agregar texto matemático**

Crea una forma matemática que contiene una fracción y la fórmula pitagórica.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Añadir una forma matemática a la diapositiva.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Acceder al párrafo matemático.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Añadir una fracción simple: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Añadir ecuación: c² = a² + b².
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

## **Acceder al texto matemático**

Localiza una forma que contiene un párrafo matemático en la diapositiva.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Encontrar la primera forma que contiene un párrafo matemático.
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

## **Eliminar texto matemático**

Elimina una forma matemática de la diapositiva.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es una forma con texto matemático.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatear texto matemático**

Establece las propiedades de fuente para una porción matemática.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Suponiendo que la primera forma es una forma con texto matemático.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```