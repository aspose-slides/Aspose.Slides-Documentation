---
title: Конвертировать презентации PowerPoint в PDF с примечаниями на C++
linktitle: PowerPoint в PDF с примечаниями
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
- примечания докладчика
- PDF с примечаниями
- C++
- Aspose.Slides
description: "Конвертировать форматы PPT и PPTX в PDF с примечаниями с помощью Aspose.Slides для C++. Сохраняет макеты и примечания докладчика для профессиональных презентаций."
---
## **Обзор**

В этой статье вы узнаете, как конвертировать презентации PowerPoint в PDF с примечаниями докладчика с помощью Aspose.Slides. Это руководство охватит необходимые шаги и предоставит примеры кода, помогающие эффективно выполнить эту задачу. К концу статьи вы сможете:

- Реализовать процесс конвертации, преобразующий слайды PowerPoint в PDF‑документы с сохранением примечаний докладчика.  
- Настроить выходной PDF, чтобы убедиться, что примечания докладчика включены и отформатированы в соответствии с вашими требованиями.

## **Конвертировать PowerPoint в PDF с заметками**

Метод `Save` класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) может быть использован для преобразования презентации PPT или PPTX в PDF с примечаниями докладчика. С помощью Aspose.Slides вы просто загружаете презентацию, настраиваете параметры макета, используя класс [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/notescommentslayoutingoptions/) для включения примечаний докладчика, и затем сохраняете файл в формате PDF. Следующий фрагмент кода демонстрирует, как конвертировать пример презентации в PDF в представлении с примечаниями к слайдам.

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

// Настроить параметры PDF для отображения примечаний докладчика.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Отобразить примечания докладчика под слайдом.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Возможно, вам будет интересно ознакомиться с онлайн‑конвертером Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ru/conversion). 
{{% /alert %}}