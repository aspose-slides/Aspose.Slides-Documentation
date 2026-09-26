---
title: Конвертировать презентации в PDF с заметками на Python
linktitle: Презентация в PDF с заметками
type: docs
weight: 50
url: /ru/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать OpenDocument
- конвертировать презентацию
- конвертировать PPT
- конвертировать PPTX
- конвертировать ODP
- PowerPoint в PDF
- OpenDocument в PDF
- презентация в PDF
- PPT в PDF
- PPTX в PDF
- ODP в PDF
- заметки докладчика
- PDF с заметками
- Python
- Aspose.Slides
description: "Конвертировать форматы PPT, PPTX и ODP в PDF с заметками с помощью Aspose.Slides для Python. Сохранить макеты и заметки докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как с помощью Aspose.Slides преобразовать презентации PowerPoint в формат PDF с заметками докладчика. В руководстве описаны необходимые шаги и приведены примеры кода, которые помогут выполнить задачу эффективно. По окончании статьи вы сможете:

- Реализовать процесс конвертации, преобразуя слайды PowerPoint в PDF‑документы с сохранением заметок докладчика.
- Настроить выходной PDF так, чтобы заметки докладчика были включены и отформатированы в соответствии с вашими требованиями.

Чтобы задать размеры и ориентацию страницы заметок перед экспортом, см. [Notes Page Size](/slides/ru/python-net/notes-size/).

## **Конвертация PowerPoint в PDF с заметками**

Метод `save` класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) можно использовать для преобразования презентации PPT или PPTX в PDF с заметками докладчика. С Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета с помощью класса [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/notescommentslayoutingoptions/) для включения заметок, а затем сохраняете файл в формате PDF. Следующий фрагмент кода демонстрирует, как конвертировать пример презентации в PDF в режиме слайдов заметок.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # Настройте параметры PDF для рендеринга заметок докладчика.
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # Сохраните презентацию в PDF с заметками докладчика.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Вы можете попробовать онлайн‑конвертер Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion).
{{% /alert %}}