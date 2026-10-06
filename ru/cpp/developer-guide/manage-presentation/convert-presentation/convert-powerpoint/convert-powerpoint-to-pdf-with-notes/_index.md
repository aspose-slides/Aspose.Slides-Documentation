---
title: Конвертировать презентации PowerPoint в PDF с заметками на C++
linktitle: PowerPoint в PDF с заметками
type: docs
weight: 50
url: /ru/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- конвертировать слайд
- конвертировать PPT
- конвертировать PPTX
- PowerPoint в PDF
- презентацию в PDF
- слайд в PDF
- PPT в PDF
- PPTX в PDF
- сохранить презентацию как PDF
- сохранить PPT как PDF
- сохранить PPTX как PDF
- экспортировать PPT в PDF
- экспортировать PPTX в PDF
- заметки докладчика
- PDF с заметками
- C++
- Aspose.Slides
description: "Конвертировать форматы PPT и PPTX в PDF с заметками с помощью Aspose.Slides для C++. Сохранить макеты и заметки докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как конвертировать презентации PowerPoint в формат PDF с заметками докладчика, используя Aspose.Slides. Это руководство охватывает необходимые шаги и предоставляет примеры кода, чтобы помочь вам эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, преобразуя слайды PowerPoint в документы PDF с сохранением заметок докладчика.
- Настроить вывод PDF так, чтобы заметки докладчика включались и форматировались согласно вашим требованиям.

Чтобы задать размеры и ориентацию страницы заметок перед экспортом, см. [Размер страницы заметок](/slides/ru/cpp/notes-size/).

## **Конвертация PowerPoint в PDF с заметками**

Метод `Save` в классе [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) может использоваться для конвертации презентации PPT или PPTX в PDF с заметками докладчика. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/) для включения заметок докладчика, а затем сохраняете файл в формате PDF. Следующий фрагмент кода демонстрирует, как конвертировать пример презентации в PDF в представлении слайдов с заметками.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Отображать заметки докладчика под слайдом.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Возможно, вам будет интересно ознакомиться с Aspose [Онлайн конвертером PowerPoint в PDF](https://products.aspose.app/slides/ru/conversion).
{{% /alert %}}