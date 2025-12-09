---
title: Конвертировать презентации в режиме раздаточного листа с Python
linktitle: Режим раздаточного листа
type: docs
weight: 150
url: /ru/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздаточного листа
- раздаточный лист
- PowerPoint
- презентация
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Конвертировать презентации в раздаточные листы с помощью Python. Установите количество слайдов на страницу, сохраните заметки, экспортируйте в PDF или изображения с Aspose.Slides, с примером кода. Попробуйте бесплатно."
---

## **Экспорт в режиме раздаточного листа**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, в том числе создавать раздаточные листы для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что удобно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив свойство `slides_layout_options` в классах [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) и [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/handoutlayoutingoptions/), который определяет, сколько слайдов размещается на одной странице, а также другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.
```py
# Загрузить презентацию.
with slides.Presentation("sample.pptx") as presentation:

    # Установить параметры экспорта.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 слайда на одной странице горизонтально
    slides_layout_options.print_slide_numbers = True                                 # печатать номера слайдов
    slides_layout_options.print_frame_slide = True                                   # печатать рамку вокруг слайдов
    slides_layout_options.print_comments = False                                     # без комментариев

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Экспортировать презентацию в PDF с выбранным макетом.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


{{% alert color="warning" %}} 
Имейте в виду, что свойство `slides_layout_options` доступно только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме раздаточного листа?**

Aspose.Slides поддерживает [preset‑варианты](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальной или вертикальной раскладкой: 1, 2, 3, 4 (горизонтально/вертикально), 6 (горизонтально/вертикально) и 9 (горизонтально/вертикально).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод раздаточного листа?**

Да. Включите опцию `show_hidden_slides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).