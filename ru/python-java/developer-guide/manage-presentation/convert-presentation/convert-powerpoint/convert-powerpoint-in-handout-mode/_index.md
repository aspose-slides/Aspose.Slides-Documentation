---
title: Конвертировать презентации PowerPoint в режиме раздачи с помощью Python
linktitle: Режим раздачи
type: docs
weight: 150
url: /ru/python-java/convert-powerpoint-in-handout-mode/
keywords:
- конвертировать PowerPoint
- конвертировать презентацию
- режим раздачи
- раздача
- PPT
- PPTX
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Конвертировать презентации PowerPoint в раздачу с помощью Python через Java. Размещать несколько слайдов на странице и экспортировать в PDF с помощью Aspose.Slides."
---
## **Введение**

Aspose.Slides for Python via Java позволяет экспортировать презентации в режиме раздачи, размещая несколько слайдов на одной странице. Это удобно для печати материалов презентаций для конференций, семинаров и аналогичных мероприятий.

Настройте компоновку через метод [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Макеты раздачи поддерживаются классами [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/), и [TiffOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tiffoptions/). Для указания параметров макета и отображения используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handoutlayoutingoptions/).

## **Экспорт в режиме раздачи**

Чтобы экспортировать презентацию в режиме раздачи, создайте экземпляр [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handoutlayoutingoptions/) и присвойте его целевым параметрам экспорта с помощью [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

В следующем примере загружается `sample.pptx` и экспортируется в PDF с четырьмя слайдами на страницу в горизонтальном порядке. Включаются номера слайдов и рамки вокруг слайдов, комментарии исключаются.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Загрузить презентацию.
presentation = Presentation("sample.pptx")
try:
    # Настроить макет раздачи.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Экспортировать презентацию в PDF с выбранным макетом.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Настройки оформления раздачи применяются к поддерживаемым форматам вывода, таким как PDF, HTML, TIFF и отрисованные изображения. Они не изменяют порядок слайдов в исходной презентации.
{{% /alert %}}

## **Часто задаваемые вопросы**

**Каково максимальное количество миниатюр слайдов на странице в режиме раздачи?**

Aspose.Slides поддерживает до девяти миниатюр на странице. Предустановки [HandoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handouttype/) предоставляют один, два, три, четыре, шесть или девять слайдов на страницу. Предустановки с четырьмя, шести и девятью слайдами поддерживают горизонтальный и вертикальный порядок.

**Могу ли я определить собственную сетку, например пять или восемь слайдов на страницу?**

Нет. Количество и порядок миниатюр управляются предопределёнными значениями [HandoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handouttype/). Произвольные сетки не поддерживаются этими настройками оформления раздачи.

**Могу ли я включить скрытые слайды в вывод раздачи?**

Да. Включите скрытые слайды в параметрах экспорта для целевого формата. Для PDF вызовите [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) с `True` перед сохранением презентации.