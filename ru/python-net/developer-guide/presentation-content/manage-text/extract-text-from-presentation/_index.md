---
title: "Продвинутое извлечение текста из презентаций PowerPoint на Python"
linktitle: "Извлечение текста"
type: docs
weight: 90
url: /ru/python-net/extract-text-from-presentation/
keywords:
- "извлечение текста"
- "извлечение текста со слайда"
- "извлечение текста из презентации"
- "извлечение текста из PowerPoint"
- "извлечение текста из OpenDocument"
- "извлечение текста из PPT"
- "извлечение текста из PPTX"
- "извлечение текста из ODP"
- "получение текста"
- "получение текста со слайда"
- "получение текста из презентации"
- "получение текста из PowerPoint"
- "получение текста из OpenDocument"
- "получение текста из PPT"
- "получение текста из PPTX"
- "получение текста из ODP"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Узнайте, как быстро и просто извлекать текст из презентаций PowerPoint с помощью Aspose.Slides for Python через .NET. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время и эффективно получать доступ к содержимому слайдов в ваших приложениях."
---

## **Обзор**

Извлечение текста из презентаций — распространённая, но важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, имеете ли вы дело с файлами Microsoft PowerPoint в формате PPT или PPTX, либо с презентациями OpenDocument (ODP), доступ к текстовым данным и их извлечение могут быть критически важными для анализа, автоматизации, индексирования или миграции контента.

Эта статья предоставляет исчерпывающее руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с помощью Aspose.Slides for Python. Вы узнаете, как систематически обходить элементы презентации, чтобы точно получить нужный текстовый контент.

## **Извлечение текста со слайда**

Aspose.Slides for Python предоставляет пространство имён [aspose.slides.util](https://reference.aspose.com/slides/python-net/aspose.slides.util/), которое включает класс [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). Этот класс раскрывает несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст со слайда в презентации, используйте метод [get_all_text_boxes](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Этот метод принимает объект типа [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) в качестве параметра. При выполнении метод сканирует весь слайд в поиске текста и возвращает массив объектов типа [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), сохраняющий любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Получите массив объектов TextFrame со всех слайдов в файле PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)
    # Пройдите по массиву текстовых фреймов.
    for text_frame in text_frames:
        # Пройдите по абзацам в текущем текстовом фрейме.
        for paragraph in text_frame.paragraphs:
            # Пройдите по текстовым фрагментам в текущем абзаце.
            for portion in paragraph.portions:
                # Выведите текст текущего фрагмента.
                print(portion.text)
                # Выведите высоту шрифта текста.
                print(portion.portion_format.font_height)
                # Выведите имя шрифта текста.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Извлечение текста из презентации**

Чтобы просканировать текст всей презентации, используйте статический метод [get_all_text_frames](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/get_all_text_frames/) класса [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/). Он принимает два параметра:

1. Объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), представляющий презентацию PowerPoint или OpenDocument, из которой будет извлекаться текст.  
2. Значение `Boolean`, указывающее, следует ли включать шаблоны слайдов при сканировании текста из презентации.

Метод возвращает массив объектов типа [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), включая информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая шаблоны слайдов.
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation("pres.pptx") as presentation:
    # Получите массив объектов TextFrame со всех слайдов в файле PPTX.
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, True)
    # Пройдите по массиву текстовых фреймов.
    for text_frame in text_frames:
        # Пройдите по абзацам в текущем текстовом фрейме.
        for paragraph in text_frame.paragraphs:
            # Пройдите по текстовым фрагментам в текущем абзаце.
            for portion in paragraph.portions:
                # Выведите текст текущего фрагмента.
                print(portion.text)
                # Выведите высоту шрифта текста.
                print(portion.portion_format.font_height)
                # Выведите имя шрифта текста.
                if portion.portion_format.latin_font is not None:
                    print(portion.portion_format.latin_font.font_name)
```


## **Категоризированное и быстрое извлечение текста**

Класс [PresentationFactory](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentationfactory/) также предоставляет статические методы для извлечения всего текста из презентаций:
```py
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```


Аргумент‑перечисление [TextExtractionArrangingMode](https://reference.aspose.com/slides/python-net/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:
- `UNARRANGED` — «сырой» текст без учёта его положения на слайде.  
- `ARRANGED` — текст упорядочен в том же порядке, что и на слайде.

Режим `UNARRANGED` можно использовать, когда важна скорость; он быстрее, чем режим `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/python-net/aspose.slides/presentationtext/) представляет собой «сырой» текст, извлечённый из презентации. Он содержит свойство `slides_text`, которое возвращает массив объектов типа [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/). Каждый объект представляет текст на соответствующем слайде. Объект типа [ISlideText](https://reference.aspose.com/slides/python-net/aspose.slides/islidetext/) имеет следующие свойства:

- `text` — текст внутри фигур слайда.  
- `master_text` — текст внутри фигур мастер‑слайда, связанного с этим слайдом.  
- `layout_text` — текст внутри фигур макетного слайда, связанного с этим слайдом.  
- `notes_text` — текст внутри фигур слайда заметок, связанного с этим слайдом.  
- `comments_text` — текст внутри комментариев, связанных с этим слайдом.

```py
import aspose.slides as slides

arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory().get_presentation_text("sample.pptx", arranging_mode)
slide_text = presentation_text.slides_text[0]
print(slide_text.text)
print(slide_text.layout_text)
print(slide_text.master_text)
print(slide_text.notes_text)
```


## **FAQ**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**  

Aspose.Slides оптимизирован для высокой производительности и эффективно обрабатывает даже [большие презентации](/slides/ru/python-net/open-presentation/), что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**  

Да, Aspose.Slides полностью поддерживает извлечение текста из таблиц, диаграмм и других сложных элементов слайдов, позволяя легко получать и анализировать весь текстовый контент.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**  

Вы можете извлекать текст с помощью бесплатной пробной версии Aspose.Slides, хотя она будет иметь [определённые ограничения](/slides/ru/python-net/licensing/), например обработку только ограниченного числа слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.