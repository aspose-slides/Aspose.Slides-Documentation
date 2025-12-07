---
title: Конвертировать презентации PowerPoint в режим раздаточного листа с использованием C++
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
description: "Конвертировать презентации в раздаточные листы на C++. Устанавливайте количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с помощью Aspose.Slides, с примером кода. Попробуйте бесплатно."
---

## **Экспорт в режиме раздаточного листа**

Aspose.Slides предоставляет возможность преобразовывать презентации в различные форматы, включая создание раздаточных листов для печати в режиме Handout. Этот режим позволяет настроить отображение нескольких слайдов на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив метод `set_SlidesLayoutOptions` в интерфейсах [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/) и [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) .

Для настройки режима Handout используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) , который определяет количество слайдов, размещаемых на одной странице, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как преобразовать презентацию в PDF в режиме Handout.
```cpp
// Загрузить презентацию.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Установить параметры экспорта.
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
Имейте в виду, что метод `set_SlidesLayoutOptions` доступен только для некоторых форматов вывода, таких как PDF, HTML, TIFF, и при рендеринге в виде изображений.
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [предустановки](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной последовательностью: 1, 2, 3, 4 (горизонтальная/вертикальная), 6 (горизонтальная/вертикальная) и 9 (горизонтальная/вертикальная).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) ; произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод Handout?**

Да. Используйте метод `set_ShowHiddenSlides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).