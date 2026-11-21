---
title: Конвертировать презентации PowerPoint в режиме Handout с использованием C++
linktitle: Режим раздаточного материала
type: docs
weight: 150
url: /ru/cpp/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздаточного материала
- раздаточный материал
- PPT
- PPTX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Конвертировать презентации в раздаточные материалы на C++. Настройте количество слайдов на странице, сохраняйте заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides, с примерами кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, вызвав метод `set_SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/itiffoptions/).

Чтобы задать размеры и ориентацию страницы раздаточного материала перед экспортом, см. [Notes Page Size](/slides/ru/cpp/notes-size/).

## **Экспорт в режиме Handout**

Для настройки режима Handout используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handoutlayoutingoptions/), который определяет, сколько слайдов помещается на одну страницу и другие параметры отображения.

Ниже приведён пример кода, показывающий, как сконвертировать презентацию в PDF в режиме Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Load a presentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 слайда на одной странице по горизонтали
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // печатать номера слайдов
slidesLayoutOptions->set_PrintFrameSlide(true);                      // печатать рамку вокруг слайдов
slidesLayoutOptions->set_PrintComments(false);                       // без комментариев

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Учтите, что метод `set_SlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **FAQ**

### Каково максимальное количество миниатюр слайдов на странице в режиме Handout?

Aspose.Slides поддерживает [preset‑ы](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handouttype/) до 9 миниатюр на страницу с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтально/вертикально), 6 (горизонтально/вертикально) и 9 (горизонтально/вертикально).

### Можно ли задать пользовательскую сетку, например 5 или 8 слайдов на страницу?

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handouttype/); произвольные раскладки не поддерживаются.

### Можно ли включить скрытые слайды в вывод Handout?

Да. Используйте метод `set_ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/).