---
title: Конвертировать презентации PowerPoint в режим раздачи с помощью Python
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
description: "Конвертировать презентации PowerPoint в раздачи с помощью Python через Java. Расставьте несколько слайдов на странице и экспортируйте в PDF с Aspose.Slides."
---
## **Введение**

Aspose.Slides for Python via Java позволяет экспортировать презентации в режиме раздачи, размещая несколько слайдов на одной странице. Это удобно для печати материалов презентаций для конференций, семинаров и подобных мероприятий.

Настройте макет с помощью метода [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Макеты раздачи поддерживаются классами [PdfOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/) и [TiffOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tiffoptions/). Используйте объект [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handoutlayoutingoptions/) для указания параметров макета и отображения.

Чтобы задать размеры и ориентацию страницы раздачи перед экспортом, см. раздел [Notes Page Size](/slides/ru/python-java/notes-size/).

## **Экспорт в режиме раздачи**

Чтобы экспортировать презентацию в режиме раздачи, создайте экземпляр [HandoutLayoutingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handoutlayoutingoptions/) и назначьте его целевым параметрам экспорта с помощью метода [setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

В следующем примере загружается файл `sample.pptx` и экспортируется в PDF с четырьмя слайдами на страницу в горизонтальном порядке. Включаются номера слайдов и рамки вокруг слайдов, комментарии исключаются.

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
Настройки макета раздачи применяются к поддерживаемым форматам вывода, таким как PDF, HTML, TIFF и генерируемые изображения. Они не изменяют порядок слайдов в исходной презентации.
{{% /alert %}}

## **Вопросы и ответы**

**Каково максимальное количество миниатюр слайдов на странице в режиме раздачи?**

Aspose.Slides поддерживает до девяти миниатюр на страницу. Предустановки [HandoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handouttype/) предоставляют варианты с одним, двумя, тремя, четырьмя, шестью или девятью слайдами на страницу. Предустановки для четырёх, шести и девяти слайдов поддерживают горизонтальный и вертикальный порядок.

**Могу ли я задать пользовательскую сетку, например пять или восемь слайдов на страницу?**

Нет. Количество и порядок миниатюр управляются значениями предопределённого [HandoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/handouttype/). Произвольные сетки не поддерживаются этими настройками макета раздачи.

**Можно ли включить скрытые слайды в вывод раздачи?**

Да. Включите скрытые слайды в настройках экспорта для целевого формата. Для PDF вызовите [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) с параметром `True` перед сохранением презентации.