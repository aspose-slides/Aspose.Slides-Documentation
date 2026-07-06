---
title: Получить границы текстового фрагмента в презентациях на Python
linktitle: Границы фрагмента
type: docs
weight: 47
url: /ru/python-net/portion-bounds/
keywords:
- границы текстового фрагмента
- текстовый фрагмент
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как получить границы текстового фрагмента в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Текстовый фрагмент представляет собой конкретный отрывок текста внутри абзаца и позволяет работать с этим отрывком независимо от окружающего содержимого. В Aspose.Slides фрагменты можно использовать, когда необходимо получить границы текстового отрывка, применить форматирование только к части абзаца или управлять поведением текста на более детальном уровне.

В этой статье показано, как получить ограничивающий прямоугольник фрагмента, используя [Portion.get_rect](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/get_rect/). Также показано, как получить координаты начала фрагмента, используя [Portion.get_coordinates](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/get_coordinates/). Кроме того, рассмотрены типичные сценарии, связанные с фрагментами, такие как применение гиперссылки к отдельному текстовому отрывку, понимание того, как форматирование разрешается через уровень фрагмента, абзаца, TextFrame и наследование темы, а также обработка случаев, когда указанный шрифт недоступен.

## **Получение границ текстового фрагмента**

Используйте [Portion.get_rect](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/get_rect/) чтобы получить ограничивающий прямоугольник текстового фрагмента:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Получение координат текстового фрагмента**

Используйте [Portion.get_coordinates](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/get_coordinates/) чтобы получить координаты начала текстового фрагмента:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **Вопросы и ответы**

**Могу ли я применить гиперссылку только к части текста внутри одного абзаца?**

Да, вы можете [назначить гиперссылку](/slides/ru/python-net/manage-hyperlinks/) отдельному фрагменту; только этот отрывок будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяется на уровне фрагмента, а что берётся из абзаца или TextFrame?**

Свойства уровня фрагмента имеют высший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/), Aspose.Slides берёт его из [Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/). Если и там оно не задано, Aspose.Slides использует стиль из [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) или [theme](https://reference.aspose.com/slides/ru/python-net/aspose.slides.theme/theme/).

**Что происходит, если шрифт, указанный для фрагмента, отсутствует на целевой машине или сервере?**

[Правила подстановки шрифтов](/slides/ru/python-net/font-selection-sequence/) применяются. Текст может перераспределиться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я задать прозрачность заливки текста или градиент для конкретного фрагмента независимо от остального абзаца?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/) могут отличаться от соседних фрагментов.