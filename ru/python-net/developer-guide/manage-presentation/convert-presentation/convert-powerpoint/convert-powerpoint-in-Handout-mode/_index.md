---
title: Конвертация презентаций в режиме раздаточного листа с Python
linktitle: Режим раздаточного листа
type: docs
weight: 150
url: /ru/python-net/convert-powerpoint-in-handout-mode/
keywords:
- конвертация PowerPoint
- конвертация презентации
- режим раздаточного листа
- раздаточный лист
- PowerPoint
- презентация
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Конвертируйте презентации в раздаточные листы с помощью Python. Устанавливайте количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с Aspose.Slides, сопровождая примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в различные форматы, включая создание раздаточных листов для печати в режиме Handout. Этот режим позволяет настроить, как несколько слайдов отображаются на одной странице, что удобно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, установив свойство `slides_layout_options` в классах [PdfOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) и [TiffOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/tiffoptions/).

Чтобы задать размеры и ориентацию страницы раздаточного листа перед экспортом, см. [Размер страницы заметок](/slides/ru/python-net/notes-size/).

## **Экспорт в режиме раздаточного листа**

Чтобы настроить режим Handout, используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handoutlayoutingoptions/), который определяет количество слайдов, размещаемых на одной странице, и другие параметры отображения.

Ниже приведён пример кода, показывающий, как конвертировать презентацию в PDF в режиме Handout.

```py
import aspose.slides as slides

# Загрузить презентацию.
with slides.Presentation("sample.pptx") as presentation:

    # Установить параметры экспорта.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 слайда на одной странице по горизонтали
    slides_layout_options.print_slide_numbers = True                                 # печатать номера слайдов
    slides_layout_options.print_frame_slide = True                                   # печатать рамку вокруг слайдов
    slides_layout_options.print_comments = False                                     # без комментариев

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Экспортировать презентацию в PDF с выбранным макетом.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
Имейте в виду, что свойство `slides_layout_options` доступно только для некоторых форматов вывода, таких как PDF, HTML, TIFF, а также при рендеринге в виде изображений.
{{% /alert %}} 

## **FAQ**

**Каково максимальное количество миниатюр слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [предустановки](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handouttype/) до 9 миниатюр на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтальное/вертикальное), 6 (горизонтальное/вертикальное) и 9 (горизонтальное/вертикальное).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок миниатюр строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Могу ли я включить скрытые слайды в вывод Handout?**

Да. Включите параметр `show_hidden_slides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/tiffoptions/).