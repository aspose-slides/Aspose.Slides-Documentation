---
title: Преобразование презентаций PowerPoint в режиме Handout с использованием C++
linktitle: Режим Handout
type: docs
weight: 150
url: /ru/cpp/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим handout
- handout
- PPT
- PPTX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте презентации в раздаточные материалы с помощью C++. Установите количество слайдов на страницу, сохраните заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides, с примерами кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить отображение нескольких слайдов на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `set_SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/itiffoptions/).

## **Экспорт в режиме Handout**

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handoutlayoutingoptions/), который определяет количество слайдов, размещаемых на одной странице, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.

```cpp
// Загрузить презентацию.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 слайда на одной странице горизонтально
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // печать номеров слайдов
slidesLayoutOptions->set_PrintFrameSlide(true);                      // печать рамки вокруг слайдов
slidesLayoutOptions->set_PrintComments(false);                       // без комментариев

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Имейте в виду, что метод `set_SlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) и 9 (horizontal/vertical).

**Могу ли я задать собственную сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод Handout?**

Да. Используйте метод `set_ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/cpp/aspose.slides.export/tiffoptions/).