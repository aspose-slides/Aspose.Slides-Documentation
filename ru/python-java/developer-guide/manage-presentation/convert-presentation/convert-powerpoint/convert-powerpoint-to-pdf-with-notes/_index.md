---
title: Преобразование презентаций PowerPoint в PDF с заметками в Python
linktitle: PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать PPT
- преобразовать PPTX
- PowerPoint в PDF
- презентацию в PDF
- PPT в PDF
- PPTX в PDF
- сохранить презентацию как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- заметки докладчика
- PDF с заметками
- Python
- Java
- Aspose.Slides
description: "Преобразуйте презентации PPT и PPTX в PDF с заметками докладчика, используя Aspose.Slides для Python через Java. Настройте размещение заметок и сохраните длинные заметки."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint в PDF с заметками докладчика, используя Aspose.Slides для Python через Java. Вы можете размещать заметки под каждым слайдом и позволять длинным заметкам продолжаться на дополнительных страницах. Для других параметров экспорта PDF см. [Convert PowerPoint to PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).

## **Преобразование PowerPoint в PDF с заметками**

Для экспорта презентации PPT или PPTX в PDF используйте метод [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). Чтобы добавить заметки докладчика, создайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/) и настройте его метод [setNotesPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Присвойте этот макет [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) с помощью [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Следующий пример загружает `sample.pptx` и экспортирует его в `output.pdf` с заметками докладчика под слайдами:

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

{{% alert color="info" title="Примечание" %}}
Вы также можете попробовать [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion).
{{% /alert %}}

## **FAQ**

**Как предотвратить обрезку длинных заметок докladчика?**

Используйте [NotesPositions.BottomFull](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/#BottomFull), как в примере выше. Эта настройка отображает полные заметки, используя дополнительные страницы при необходимости.

**Могу ли я разместить каждый слайд и его заметки на одной странице?**

Используйте [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/#BottomTruncated). Эта настройка ограничивает заметки одной страницей, поэтому несоответствующие заметки могут быть усечены.

**Как экспортировать слайды без заметок докладчика?**

Опустите конфигурацию макета заметок и используйте стандартный экспорт PDF, описанный в статье [Convert PowerPoint to PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).