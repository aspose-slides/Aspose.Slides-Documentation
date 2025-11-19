---
title: Управление верхним и нижним индексом в Python
linktitle: Верхний и нижний индекс
type: docs
weight: 80
url: /ru/python-net/superscript-and-subscript/
keywords:
- верхний индекс
- нижний индекс
- добавить верхний индекс
- добавить нижний индекс
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Освойте верхний и нижний индексы в Aspose.Slides для Python через .NET и улучшите свои презентации профессиональным форматированием текста для максимального воздействия."
---

## **Добавить верхний и нижний индекс**

Вы можете добавить текст в верхнем и нижнем индексе к любой части абзаца. В Aspose.Slides используйте свойство `escapement` класса [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) для управления этим.

`escapement` — это процент от **-100% до 100%**:

- **> 0** → верхний индекс (например, 25% = небольшое поднятие; 100% = полный верхний индекс)
- **0** → базовая линия (нет верхнего/нижнего индекса)
- **< 0** → нижний индекс (например, -25% = небольшое понижение; -100% = полный нижний индекс)

Шаги:

1. Создайте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и получите слайд.
1. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) и получите доступ к его [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Очистите существующие абзацы.
1. Для верхнего индекса: создайте абзац и часть, установите `portion.portion_format.escapement` в значение от **0 и 100**, задайте текст и добавьте часть.
1. Для нижнего индекса: создайте другой абзац и часть, установите `escapement` в значение от **-100 и 0**, задайте текст и добавьте часть.
1. Сохраните презентацию в формате PPTX.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Получить слайд.
    slide = presentation.slides[0]

    # Создать текстовое поле.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Создать абзац для текста в верхнем индексе.
    superscript_paragraph = slides.Paragraph()

    # Создать текстовый фрагмент с обычным текстом.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Создать текстовый фрагмент с текстом в верхнем индексе.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Создать абзац для текста в нижнем индексе.
    subscript_paragraph = slides.Paragraph()

    # Создать текстовый фрагмент с обычным текстом.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Создать текстовый фрагмент с текстом в нижнем индексе.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Добавить абзацы в текстовое поле.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


## **Часто задаваемые вопросы**

**Могу ли я применять верхний/нижний индекс в таблицах и других контейнерах, а не только в обычных текстовых полях?**

Да. Вы можете форматировать текст как верхний или нижний индекс внутри любого объекта, который предоставляет [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (включая ячейки таблиц). Форматирование применяется к частям текста внутри этого фрейма.

**Сохраняются ли верхний/нижний индекс при экспорте в PDF, HTML или изображения?**

Да. Aspose.Slides сохраняет форматирование верхнего/нижнего индекса при экспорте в распространённые форматы, такие как [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) и [raster images](/slides/ru/python-net/convert-powerpoint-to-png/), поскольку конвейер рендеринга учитывает форматирование текста на уровне частей.

**Могу ли я комбинировать верхний/нижний индекс с гиперссылками в одном текстовом фрагменте?**

Да. [Hyperlinks](/slides/ru/python-net/manage-hyperlinks/) назначаются на уровне части (фрагмента), поэтому часть может одновременно иметь гиперссылку и быть отформатирована как верхний или нижний индекс.