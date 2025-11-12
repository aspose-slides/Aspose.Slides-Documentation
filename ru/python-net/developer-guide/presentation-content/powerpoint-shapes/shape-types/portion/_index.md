---
title: Управление текстовыми фрагментами в презентациях с помощью Python
linktitle: Текстовый фрагмент
type: docs
weight: 70
url: /ru/python-net/portion/
keywords:
- текстовый фрагмент
- часть текста
- координаты текста
- позиция текста
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять текстовыми фрагментами в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET, повышая производительность и возможности настройки."
---

## **Получить координаты текстовых фрагментов**

Метод [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) был добавлен в класс [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/), что позволяет получать координаты текстовых фрагментов:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Могу ли я применить гиперссылку только к части текста в одном абзаце?**

Да, вы можете [assign a hyperlink](/slides/ru/python-net/manage-hyperlinks/) к отдельному фрагменту; только этот фрагмент будет кликабельным, а не весь абзац.

**Как работает наследование стилей: что переопределяет Portion и что берётся из Paragraph/TextFrame?**

Свойства уровня Portion имеют высший приоритет. Если свойство не задано у [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/), движок берёт его из [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/); если и там нет, из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) или из стиля [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/).

**Что происходит, если шрифт, указанный для Portion, отсутствует на целевой машине/сервере?**

Применяются [Font substitution rules](/slides/ru/python-net/font-selection-sequence/). Текст может измениться: метрики, переносы и ширина могут измениться, что важно для точного позиционирования.

**Могу ли я задать прозрачность или градиент заливки текста на уровне Portion независимо от остальных абзацев?**

Да, цвет текста, заливка и прозрачность на уровне [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) могут отличаться от соседних фрагментов.