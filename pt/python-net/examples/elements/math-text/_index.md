---
title: Texto Matemático
type: docs
weight: 160
url: /pt/python-net/examples/elements/math-text/
keywords:
- texto matemático
- adicionar texto matemático
- acessar texto matemático
- remover texto matemático
- formatar texto matemático
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Trabalhe com texto matemático em Python usando Aspose.Slides: crie e edite equações, frações, radicais, sobrescritos, formatação e renderize resultados para PPT e PPTX."
---
Ilustra o trabalho com formas de texto matemático e a formatação de equações usando **Aspose.Slides for Python via .NET**.

## **Adicionar Texto Matemático**

Crie uma forma matemática contendo uma fração e a fórmula de Pitágoras.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Adicionar uma forma Matemática ao slide.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Acessar o parágrafo matemático.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Adicionar uma fração simples: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Adicionar equação: c² = a² + b².
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

## **Acessar Texto Matemático**

Localize uma forma que contém um parágrafo matemático no slide.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Encontrar a primeira forma que contém um parágrafo matemático.
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

## **Remover Texto Matemático**

Exclua uma forma matemática do slide.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Assumindo que a primeira forma é uma forma com texto matemático.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatar Texto Matemático**

Defina as propriedades da fonte para uma parte matemática.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Presumindo que a primeira forma seja uma forma com texto matemático.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```