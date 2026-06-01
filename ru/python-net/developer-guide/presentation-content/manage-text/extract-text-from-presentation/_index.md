---
title: "Продвинутое извлечение текста из презентаций на Python"
linktitle: "Извлечение текста"
type: docs
weight: 90
url: /ru/python-net/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получить текст
- получить текст со слайда
- получить текст из презентации
- получить текст из PowerPoint
- получить текст из OpenDocument
- получить текст из PPT
- получить текст из PPTX
- получить текст из ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Быстро извлекайте текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — частая, но важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным может быть критически важен для анализа, автоматизации, индексации или миграции контента.

В этой статье представлено полное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с помощью Aspose.Slides for Python via .NET. Вы узнаете, как систематически перебрать элементы презентации для точного получения необходимого текстового содержимого.

## **Извлечение текста со слайда**

Aspose.Slides for Python via .NET предоставляет пространство имён [aspose.slides.util](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/), в котором находится класс [SlideUtil](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/). Этот класс раскрывает несколько перегруженных статических методов для извлечения всего текста из презентации или отдельного слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [get_all_text_boxes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Метод принимает объект типа [BaseSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseslide/) в качестве параметра. При выполнении метод просматривает весь слайд в поисках текста и возвращает массив объектов типа [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/), сохраняя любые форматирования текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Извлечение текста из презентации**

Чтобы просканировать текст всей презентации, используйте статический метод [get_all_text_frames](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/get_all_text_frames/) класса [SlideUtil](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Сначала объект [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлекаться текст.
1. Затем значение `Boolean`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов типа [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/), включая информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая мастер‑слайды.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Категоризованное и быстрое извлечение текста**

Класс [PresentationFactory](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationfactory/) также предоставляет методы для извлечения всего текста из презентаций:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:
- `UNARRANGED` – Неотсортированный текст без учёта его положения на слайде.
- `ARRANGED` – Текст упорядочен в том же порядке, что и на слайде.

Режим `UNARRANGED` полезен, когда важна скорость; он быстрее, чем режим `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentationtext/) представляет собой необработанный текст, извлечённый из презентации. Его свойство `slides_text` возвращает массив объектов текста слайдов. Каждый объект представляет текст соответствующего слайда и имеет следующие свойства:

- `text` – Текст внутри фигур слайда.
- `master_text` – Текст внутри фигур мастер‑слайда, связанного с этим слайдом.
- `layout_text` – Текст внутри фигур шаблона слайда, связанного с этим слайдом.
- `notes_text` – Текст внутри фигур нот-слайда, связанного с этим слайдом.
- `comments_text` – Текст внутри комментариев, связанных с этим слайдом.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **Вопросы и ответы**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и может обрабатывать даже [большие презентации](/slides/ru/python-net/open-presentation/), что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да. Aspose.Slides может извлекать текст из множества элементов слайда, включая таблицы и объекты, связанные с диаграммами, так что вы сможете получать и анализировать текстовое содержание в типичных структурах презентаций.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, однако она имеет [определённые ограничения](/slides/ru/python-net/licensing/), например, обработку лишь ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.