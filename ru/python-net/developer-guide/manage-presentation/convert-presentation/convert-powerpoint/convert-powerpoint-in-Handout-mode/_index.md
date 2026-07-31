---
title: Конвертировать презентации в режиме раздатки с Python
linktitle: Режим раздатки
type: docs
weight: 150
url: /ru/python-net/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздатки
- раздатка
- PowerPoint
- презентация
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Конвертировать презентации в раздатки с помощью Python. Установите количество слайдов на страницу, сохраняйте заметки, экспортируйте в PDF или изображения с Aspose.Slides, с примером кода. Попробуйте бесплатно."
---
## **Введение**

Aspose.Slides предоставляет возможность конвертировать презентации в разные форматы, включая создание раздаточных материалов для печати в режиме Handout. Этот режим позволяет настроить отображение нескольких слайдов на одной странице, что полезно для конференций, семинаров и других мероприятий. Вы можете включить этот режим, задав свойство `slides_layout_options` в классах [PdfOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) и [TiffOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/tiffoptions/).

## **Экспорт в режиме Handout**

Для настройки режима Handout используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handoutlayoutingoptions/), который определяет количество слайдов, размещаемых на одной странице, а также прочие параметры отображения.

Ниже приведён пример кода, показывающий, как преобразовать презентацию в PDF в режиме Handout.

```py
# Загрузить презентацию.
with slides.Presentation("sample.pptx") as presentation:

    # Установить параметры экспорта.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 слайда на одной странице по горизонтали
    slides_layout_options.print_slide_numbers = True                                 # печать номеров слайдов
    slides_layout_options.print_frame_slide = True                                   # печать рамки вокруг слайдов
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

**Каково максимальное количество эскизов слайдов на странице в режиме Handout?**

Aspose.Slides поддерживает [presets](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handouttype/) до 9 эскизов на странице с горизонтальным или вертикальным расположением: 1, 2, 3, 4 (горизонтальное/вертикальное), 6 (горизонтальное/вертикальное) и 9 (горизонтальное/вертикальное).

**Могу ли я задать пользовательскую сетку, например 5 или 8 слайдов на страницу?**

Нет. Количество и порядок эскизов строго контролируются перечислением [HandoutType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/handouttype/); произвольные макеты не поддерживаются.

**Можно ли включить скрытые слайды в вывод Handout?**

Да. Включите параметр `show_hidden_slides` в настройках экспорта для целевого формата, например [PdfOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/tiffoptions/).