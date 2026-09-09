---
title: Конвертировать презентации PowerPoint в PDF с заметками в Python
linktitle: PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PDF
- презентацию в PDF
- PPT в PDF
- PPTX в PDF
- сохранить презентацию как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- заметки ведущего
- PDF с заметками
- Python
- Java
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в PDF с заметками ведущего, используя Aspose.Slides для Python через Java. Настройте размещение заметок и сохраните длинные заметки."
---
## **Обзор**

В этой статье объясняется, как конвертировать презентации PowerPoint в PDF с заметками ведущего, используя Aspose.Slides для Python через Java. Вы можете включать заметки под каждым слайдом и позволять длинным заметкам продолжаться на дополнительных страницах. Для других параметров экспорта PDF см. [Конвертировать PowerPoint в PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).

## **Конвертировать PowerPoint в PDF с заметками**

Используйте метод [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) для экспорта презентации PPT или PPTX в PDF. Чтобы включить заметки ведущего, создайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/) и настройте размещение заметок с помощью его метода [setNotesPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Присвойте этот макет [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) с помощью [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Следующий пример загружает `sample.pptx` и экспортирует его в `output.pdf` с заметками ведущего под слайдами:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Настройте параметры PDF для отображения заметок докладчика.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Сохраните презентацию в PDF с заметками докладчика.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Вы также можете попробовать [Онлайн-конвертер PowerPoint в PDF](https://products.aspose.app/slides/ru/conversion).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Как предотвратить обрезку длинных заметок ведущего?**

Используйте [NotesPositions.BottomFull](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/#BottomFull), как в примере выше. Эта настройка отображает полные заметки, используя дополнительные страницы при необходимости.

**Могу ли я разместить каждый слайд и его заметки на одной странице?**

Используйте [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/#BottomTruncated). Эта настройка ограничивает заметки одной страницей, поэтому заметки, которые не помещаются, могут быть усечены.

**Как экспортировать слайды без заметок ведущего?**

Опустите настройку макета заметок и используйте стандартный экспорт PDF, описанный в [Конвертировать PowerPoint в PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).