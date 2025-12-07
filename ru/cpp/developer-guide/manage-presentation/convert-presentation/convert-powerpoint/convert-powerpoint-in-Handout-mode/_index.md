---
title: Конвертация презентаций PowerPoint в режиме раздаточного листа с использованием C++
linktitle: Режим раздаточного листа
type: docs
weight: 150
url: /ru/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздаточного листа
- раздаточный лист
- PPT
- PPTX
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Конвертируйте презентации в раздаточные листы на C++. Установите количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides, с примером кода. Попробуйте бесплатно."
---

## **Экспорт в режиме раздаточного листа**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных листов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, задав метод `set_SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/).

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.
```cpp
// Загрузить презентацию.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Установить параметры экспорта.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 слайда на странице по горизонтали
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // печать номеров слайдов
slidesLayoutOptions->set_PrintFrameSlide(true);                      // печать рамки вокруг слайдов
slidesLayoutOptions->set_PrintComments(false);                       // без комментариев

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Экспортировать презентацию в PDF с выбранным макетом.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 

Имейте в виду, что метод `set_SlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.

{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [предустановки](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтальное/вертикальное), 6 (горизонтальное/вертикальное) и 9 (горизонтальное/вертикальное).

**Можно ли задать пользовательскую сетку, например 5 или 8 слайдов на странице?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод Handout?**

Да. Используйте метод `set_ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).