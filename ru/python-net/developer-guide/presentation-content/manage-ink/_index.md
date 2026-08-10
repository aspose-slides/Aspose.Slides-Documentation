---
title: Управление объектами чернил в презентациях с помощью Python
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/python-net/manage-ink/
keywords:
- чернила
- объект чернил
- трасса чернил
- управление чернилами
- рисование чернил
- рисование
- экспорт чернил
- рендеринг чернил
- скрыть чернила
- InkOptions
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint, редактируйте трассы и свойства кисти, а также контролируйте отображение чернил при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для Python через .NET."
---
## **Введение**

PowerPoint предоставляет возможность рисования чернилами, позволяющую рисовать произвольные штрихи. Чернила можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам слайда.

Пространство имён [aspose.slides.ink](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/) содержит классы, необходимые для работы с объектами чернил. Например, класс [Ink](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/ink/) представляет объект чернил на слайде.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами формы. В своей простейшей форме форма — это контейнер, определяющий область самого объекта (его рамку) вместе с такими свойствами, как размер контейнера, форма и фон. Подробнее см. [Shape Layout Format](https://docs.aspose.com/slides/ru/python-net/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint обрабатывает объект чернил, он игнорирует все свойства рамки объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными свойствами [Ink.width](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/ink/width/) и [Ink.height](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Трассы черилл**

Трасса чернил — это основной элемент, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Трасса хранит последовательность соединённых точек.

Самая простая форма кодирования указывает координаты X и Y каждой образцовой точки. При отрисовке всех соединённых точек получается изображение, похожее на это:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки трассы чернил. Её свойства [InkBrush.color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/inkbrush/color/) и [InkBrush.size](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/inkbrush/size/) управляют цветом и размером.

### **Установить цвет кисти чернил**

Этот фрагмент кода Python показывает, как задать цвет кисти чернил:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Установить размер кисти чернил**

Этот фрагмент кода Python показывает, как задать размер кисти чернил:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Обычно ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующий раздел данных серый). Когда ширина и высота кисти совпадают, PowerPoint показывает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Следовательно, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти его трасс. Здесь целевой объект (трасса рукописного текста) масштабирован до размера контейнера (рамки). Когда размер контейнера меняется, размер кисти остаётся постоянным, и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление отображением чернил при экспорте и рендеринге**

Aspose.Slides предоставляет класс [InkOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/) для управления тем, как объекты чернил отображаются в экспортируемом или отрисованном выводе. С его помощью можно полностью скрыть чернила или изменить способ интерпретации маски кисти чернил.

Параметры чернил доступны через параметры экспорта или рендеринга для нескольких форматов вывода:

| Вывод | Свойство Ink options |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Изображение слайда | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Через эти свойства доступны два одинаковых параметра:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/hide_ink/) определяет, включать ли объекты чернил в вывод. Значение по умолчанию — `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) определяет, интерпретировать ли операцию маски как непрозрачность при рендеринге кисти чернил. Значение по умолчанию — `True`; установите `False`, чтобы использовать операцию ROP.

### **Скрыть объекты чернил в PDF‑выводе**

По умолчанию объекты чернил остаются видимыми при экспорте. Установите [InkOptions.hide_ink](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/hide_ink/) в значение `True`, когда требуется чистый вывод без рукописных аннотаций или другого содержимого чернил.

Следующий пример на Python экспортирует презентацию в PDF, скрывая все объекты чернил:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Скрыть объекты чернил при рендеринге слайда в изображение**

Чтобы скрыть объекты чернил при рендеринге слайдов в растровые изображения, настройте [RenderingOptions.ink_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/renderingoptions/ink_options/) и передайте параметры рендеринга методу [Slide.get_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/get_image/).

Следующий пример на Python рендерит первый слайд как PNG‑изображение без объектов чернил:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Управление рендерингом маски чернил**

Свойство [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) управляет тем, как операции маски интерпретируются при рендеринге кистей чернил. Значение по умолчанию — `True`, что использует непрозрачность. Установите свойство в `False`, чтобы вместо этого использовать операцию ROP.

Следующий пример на Python экспортирует слайд в SVG и использует рендеринг на основе ROP для операций маски чернил:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Тот же параметр можно применить через [`TiffOptions.ink_options`](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/tiffoptions/ink_options/) при экспорте презентации или рендеринге слайда в TIFF.

### **Выбор: скрыть или сохранить чернила**

Установите [InkOptions.hide_ink](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/hide_ink/) в `True`, когда экспортируемый файл должен быть чистой версией аннотированной презентации, например, окончательной копией для распространения без отметок рецензента.

Оставьте [InkOptions.hide_ink](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/hide_ink/) со значением по умолчанию `False`, когда аннотации чернил являются частью предполагаемого содержимого, например, комментариев рецензента, рукописных заметок, подсветок или рисунков, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные варианты обзора и финального результата из одной и той же презентации без изменения исходных объектов чернил.

## **FAQ**

**Можно ли изменить цвет или размер существующего штриха чернилом?**

Да. Получите трассу из [Ink.traces](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/ink/traces/), затем измените её [InkTrace.brush](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/inktrace/brush/). Вы можете задать свойства [InkBrush.color](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/inkbrush/color/) и [InkBrush.size](https://reference.aspose.com/slides/ru/python-net/aspose.slides.ink/inkbrush/size/) кисти.

**Изменяет ли скрытие чернил исходную презентацию?**

Нет. [InkOptions.hide_ink](https://reference.aspose.com/slides/ru/python-net/aspose.slides.export/inkoptions/hide_ink/) влияет только на отрисованный или экспортированный результат; он не удаляет и не изменяет объекты чернил в исходной презентации.

**Какие форматы экспорта поддерживают параметры чернил?**

Вы можете настроить параметры чернил для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или рендеринга, перечисленные выше.

**Дополнительные материалы**

* Чтобы узнать о формах в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/ru/python-net/powerpoint-shapes/).
* Для получения информации об эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/ru/python-net/shape-effective-properties/#get-effective-font-height-value).
* Подробности экспорта в PDF доступны в статье [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ru/python-net/convert-powerpoint-to-pdf/).
* Подробности экспорта в HTML доступны в статье [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ru/python-net/convert-powerpoint-to-html/).
* Подробности экспорта в SVG доступны в статье [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ru/python-net/render-a-slide-as-an-svg-image/).
* Подробности экспорта в TIFF доступны в статье [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ru/python-net/convert-powerpoint-to-tiff/).
* Подробности рендеринга слайда в изображение доступны в статье [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ru/python-net/convert-slide/).