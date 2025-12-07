---
title: Конвертировать презентации PowerPoint в режим раздаточного материала с использованием C++
linktitle: Режим раздаточного материала
type: docs
weight: 150
url: /ru/cpp/convert-powerpoint-in-Handout-mode/
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
description: "Конвертировать презентации в раздаточный материал на C++. Установить количество слайдов на страницу, сохранять примечания, экспортировать в PDF или изображения с помощью Aspose.Slides, с примером кода. Попробуйте бесплатно."
---

## **Экспорт режима раздаточного материала**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `set_SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/).

Для настройки режима раздаточного материала используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице и другие параметры отображения.

Ниже приведен пример кода, показывающий, как конвертировать презентацию в PDF в режиме раздаточного материала.
```cpp
// Загрузить презентацию.
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
Имейте в виду, что метод `set_SlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **Вопросы и ответы**

**Каково максимальное количество миниатюр слайдов на странице в режиме раздаточного материала?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/), позволяя разместить до 9 миниатюр на странице с горизонтальной или вертикальной сортировкой: 1, 2, 3, 4 (горизонтальная/вертикальная), 6 (горизонтальная/вертикальная) и 9 (горизонтальная/вертикальная).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод раздаточного материала?**

Да. Используйте метод `set_ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).