---
title: "Математический текст"
type: docs
weight: 160
url: /ru/python-net/examples/elements/math-text/
keywords:
- "математический текст"
- "добавить математический текст"
- "доступ к математическому тексту"
- "удалить математический текст"
- "форматировать математический текст"
- "примеры кода"
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Работайте с математическим текстом в Python с помощью Aspose.Slides: создавайте и редактируйте уравнения, дроби, радикалы, индексы, форматируйте и получайте результат в виде PPT и PPTX."
---
Иллюстрирует работу с математическими текстовыми фигурами и форматирование уравнений с помощью **Aspose.Slides for Python via .NET**.

## **Добавить математический текст**

Создайте математическую фигуру, содержащую дробь и теорему Пифагора.

```py
def add_math_text():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Добавить математическую форму на слайд.
        math_shape = slide.shapes.add_math_shape(0, 0, 720, 150)

        # Получить доступ к математическому абзацу.
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

        # Добавить простую дробь: x / y.
        fraction = slides.mathtext.MathematicalText("x").divide("y")
        math_paragraph.add(slides.mathtext.MathBlock(fraction))

        # Добавить уравнение: c² = a² + b².
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

## **Доступ к математическому тексту**

Найдите фигуру, содержащую математический абзац на слайде.

```py
def access_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Найдите первую форму, содержащую математический абзац.
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

## **Удалить математический текст**

Удалите математическую фигуру со слайда.

```py
def remove_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагается, что первая фигура — это фигура с математическим текстом.
        math_shape = slide.shapes[0]

        slide.shapes.remove(math_shape)

        presentation.save("math_text_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Форматировать математический текст**

Установите свойства шрифта для части математического текста.

```py
def format_math_text():
    with slides.Presentation("math_text.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагается, что первая фигура — это фигура с математическим текстом.
        math_shape = slide.shapes[0]

        math_shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 20

        presentation.save("math_text_formatted.pptx", slides.export.SaveFormat.PPTX)
```