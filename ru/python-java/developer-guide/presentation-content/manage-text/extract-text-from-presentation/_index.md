---
title: Продвинутое извлечение текста из презентаций на Python через Java
linktitle: Извлечение текста
type: docs
weight: 90
url: /ru/python-java/extract-text-from-presentation/
keywords:
- извлечение текста
- извлечение текста со слайда
- извлечение текста из презентации
- извлечение текста из PowerPoint
- извлечение текста из OpenDocument
- извлечение текста из PPT
- извлечение текста из PPTX
- извлечение текста из ODP
- получение текста
- получение текста со слайда
- получение текста из презентации
- получение текста из PowerPoint
- получение текста из OpenDocument
- получение текста из PPT
- получение текста из PPTX
- получение текста из ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Быстро извлеките текст из презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for Python via Java. Следуйте нашему простому пошаговому руководству, чтобы сэкономить время."
---
## **Обзор**

Извлечение текста из презентаций — распространённая, но при этом важная задача для разработчиков, работающих с содержимым слайдов. Независимо от того, работаете ли вы с файлами Microsoft PowerPoint в формате PPT или PPTX, или с презентациями OpenDocument (ODP), доступ к текстовым данным и их извлечение может быть критически важным для анализа, автоматизации, индексирования или миграции контента.

В этой статье представлено полное руководство по эффективному извлечению текста из различных форматов презентаций, включая PPT, PPTX и ODP, с использованием Aspose.Slides for Python via Java. Вы узнаете, как систематически проходить элементы презентации, чтобы точно получить необходимый текстовый контент.

## **Извлечение текста со слайда**

Aspose.Slides for Python via Java предоставляет класс [SlideUtil](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/). Этот класс содержит несколько перегруженных статических методов для извлечения всего текста из презентации или слайда. Чтобы извлечь текст из слайда презентации, используйте метод [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/#getAllTextBoxes). Этот метод принимает объект типа [BaseSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/) в качестве параметра. При выполнении метод сканирует весь слайд в поисках текста и возвращает массив объектов типа [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/), сохраняющих любое форматирование текста.

Следующий фрагмент кода извлекает весь текст с первого слайда презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Извлечение текста из презентации**

Чтобы просканировать текст во всей презентации, используйте статический метод [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/#getAllTextFrames), предоставляемый классом [SlideUtil](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/). Он принимает два параметра:

1. Сначала объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), представляющий PowerPoint‑ или OpenDocument‑презентацию, из которой будет извлекаться текст.
2. Затем значение типа `bool`, указывающее, следует ли включать мастер‑слайды при сканировании текста презентации.

Метод возвращает массив объектов типа [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/), включая информацию о форматировании текста. Приведённый ниже код сканирует текст и детали форматирования из презентации, включая мастер‑слайды.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Категоризованное и быстрое извлечение текста**

Класс [PresentationFactory](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationfactory/) также предоставляет методы для извлечения всего текста из презентаций:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Извлечь текст из файла.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Извлечь текст из потока.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Извлечь текст из потока с параметрами загрузки.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

Аргумент перечисления [TextExtractionArrangingMode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textextractionarrangingmode/) указывает режим организации результата извлечения текста и может принимать следующие значения:

- [Unarranged](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) — необработанный текст без учёта его положения на слайде.
- [Arranged](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textextractionarrangingmode/#Arranged) — текст упорядочен в том же порядке, что и на слайде.

Режим Unarranged можно использовать, когда важна скорость; он быстрее, чем режим Arranged.

[PresentationText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationtext/) представляет собой необработанный текст, извлечённый из презентации. Его метод [getSlidesText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentationtext/#getSlidesText) возвращает массив объектов типа `SlideText`. Каждый объект представляет текст соответствующего слайда. Объект типа `SlideText` имеет следующие методы:

- `getText` — текст внутри фигур слайда.
- `getMasterText` — текст внутри фигур мастер‑слайда, связанных с этим слайдом.
- `getLayoutText` — текст внутри фигур макетного слайда, связанных с этим слайдом.
- `getNotesText` — текст внутри фигур слайда заметок, связанных с этим слайдом.
- `getCommentsText` — текст внутри комментариев, связанных с этим слайдом.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **Вопросы и ответы**

**Насколько быстро Aspose.Slides обрабатывает большие презентации при извлечении текста?**

Aspose.Slides оптимизирован для высокой производительности и может обрабатывать даже [large presentations](/slides/ru/python-java/open-presentation/), что делает его подходящим для сценариев реального времени или массовой обработки.

**Может ли Aspose.Slides извлекать текст из таблиц и диаграмм внутри презентаций?**

Да. Aspose.Slides может извлекать текст из множества элементов слайда, включая таблицы и объекты, связанные с диаграммами, поэтому вы можете получать доступ к текстовому содержимому и анализировать его в типовых структурах презентаций.

**Нужна ли специальная лицензия Aspose.Slides для извлечения текста из презентаций?**

Вы можете извлекать текст, используя бесплатную пробную версию Aspose.Slides, хотя она имеет [определённые ограничения](/slides/ru/python-java/licensing/), например обработку только ограниченного количества слайдов. Для неограниченного использования и работы с более крупными презентациями рекомендуется приобрести полную лицензию.