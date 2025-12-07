---
title: Преобразование презентаций PowerPoint в режиме листовки с использованием C++
linktitle: Режим листовки
type: docs
weight: 150
url: /ru/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим листовки
- листовка
- PPT
- PPTX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Преобразуйте презентации в листовки с помощью C++. Установите количество слайдов на страницу, сохраните заметки, экспортируйте в PDF или изображения с Aspose.Slides, с примером кода. Попробуйте бесплатно."
---

## **Экспорт режима листовки**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание листовок для печати в режиме Handout. Этот режим позволяет настроить отображение нескольких слайдов на одной странице, что удобно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, задав метод `set_SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/), и [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/).

Для настройки режима листовки используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме листовки.
```cpp
// Загрузить презентацию.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Установить параметры экспорта.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 слайда на одной странице по горизонтали
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // печать номеров слайдов
slidesLayoutOptions->set_PrintFrameSlide(true);                      // печатать рамку вокруг слайдов
slidesLayoutOptions->set_PrintComments(false);                       // без комментариев

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Экспортировать презентацию в PDF с выбранной разметкой.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
Имейте в виду, что метод `set_SlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме листовки?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной раскладкой: 1, 2, 3, 4 (горизонтальная/вертикальная), 6 (горизонтальная/вертикальная) и 9 (горизонтальная/вертикальная).

**Можно ли задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод листовки?**

Да. Используйте метод `set_ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/), или [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).