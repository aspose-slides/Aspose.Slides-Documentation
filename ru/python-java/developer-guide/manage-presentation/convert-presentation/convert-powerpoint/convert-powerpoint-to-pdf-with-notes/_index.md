---
title: Конвертировать презентации PowerPoint в PDF с примечаниями на Python
linktitle: PowerPoint в PDF с примечаниями
type: docs
weight: 50
url: /ru/python-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PDF
- презентация в PDF
- PPT в PDF
- PPTX в PDF
- сохранить презентацию как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- примечания выступающего
- PDF с примечаниями
- Python
- Java
- Aspose.Slides
description: "Конвертировать презентации PPT и PPTX в PDF с примечаниями выступающего, используя Aspose.Slides для Python через Java. Настройте размещение примечаний и сохраните длиные примечания."
---
## **Обзор**

В этой статье объясняется, как преобразовать презентации PowerPoint в PDF с примечаниями выступающего, используя Aspose.Slides для Python через Java. Вы можете добавить примечания под каждым слайдом и позволить длинным примечаниям продолжаться на дополнительные страницы. Для других настроек экспорта PDF см. [Конвертировать PowerPoint в PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).

Чтобы задать размеры и ориентацию страницы примечаний перед экспортом, см. [Размер страницы примечаний](/slides/ru/python-java/notes-size/).

## **Конвертировать PowerPoint в PDF с примечаниями**

Используйте метод [save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save) класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) для экспорта презентации PPT или PPTX в PDF. Чтобы включить примечания выступающего, создайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/) и настройте размещение примечаний с помощью его метода [setNotesPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Назначьте этот макет [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/) с помощью [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Следующий пример загружает `sample.pptx` и экспортирует его в `output.pdf` с примечаниями выступающего под слайдами:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    # Настройте параметры PDF для отображения примечаний выступающего.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)

    # Сохраните презентацию в PDF с примечаниями выступающего.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Вы также можете попробовать [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion).
{{% /alert %}}

## **FAQ**

**Как предотвратить обрезку длинных примечаний выступающего?**

Используйте [NotesPositions.BottomFull](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/#BottomFull), как в примере выше. Эта настройка отображает полные примечания, при необходимости используя дополнительные страницы.

**Могу ли я разместить каждый слайд и его примечания на одной странице?**

Используйте [NotesPositions.BottomTruncated](https://reference.aspose.com/slides/ru/python-java/aspose.slides/notespositions/#BottomTruncated). Эта настройка ограничивает примечания одной страницей, поэтому неприложенные части могут быть обрезаны.

**Как экспортировать слайды без примечаний выступающего?**

Не указывайте конфигурацию макета примечаний и используйте стандартный экспорт PDF, описанный в [Конвертировать PowerPoint в PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).