---
title: У管理 управления объектами чернил презентации в Python через Java
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/python-java/manage-ink/
keywords:
- чернила
- объект чернил
- след чернил
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
- Java
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint, редактируйте следы и свойства кисти, а также контролируйте отображение чернил при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для Python через Java."
---
## **Введение**

PowerPoint предоставляет функцию чернил, позволяющую рисовать свободные штрихи. Чернила можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам слайда.

Aspose.Slides предоставляет типы, необходимые для работы с объектами чернил. Например, класс [Ink](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ink/) представляет объект чернил на слайде.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами формы. В своей простой форме форма — это контейнер, определяющий область самого объекта (его рамку) вместе с такими свойствами, как размер контейнера, форма и фон. Подробнее см. раздел [Shape Layout Format](/slides/ru/python-java/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint обрабатывает объект чернил, он игнорирует все свойства рамки объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными методами [Shape.getWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getWidth) и [Shape.getHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Траки чернил**

Трек чернил — это базовый элемент, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Трек хранит последовательность соединённых точек.

Самая простая форма кодирования задаёт координаты X и Y каждой точки образца. При отрисовке всех соединённых точек получается изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки трека чернил. У кисти есть собственный цвет и размер, представленные методами [InkBrush.getColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkbrush/#getColor) и [InkBrush.getSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkbrush/#getSize).

### **Установка цвета кисти чернил**

Этот пример Python показывает, как установить цвет кисти чернил:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Установка размера кисти чернил**

Этот пример Python показывает, как установить размер кисти чернил:

```python
import jpape
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующий раздел данных серый). Когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Поэтому, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти его треков. Здесь целевой объект (текстовый трек рукописного ввода) масштабирован до размеров контейнера (рамки). Когда размер контейнера меняется, размер кисти остаётся постоянным, и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление отображением чернил при экспорте и рендеринге**

Aspose.Slides предоставляет класс [InkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/) для управления тем, как объекты чернил отображаются в экспортированном или отрендеренном выводе. С помощью его свойств можно полностью скрыть чернила или изменить способ интерпретации маски кисти чернил.

Параметры чернил доступны через параметры экспорта или рендеринга для нескольких типов вывода:

| Output | Ink options property |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Следующие методы [InkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/) раскрывают те же две настройки:

- [getHideInk](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#getHideInk) определяет, включаются ли объекты чернил в вывод. Значение по умолчанию — `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) определяет, интерпретируется ли операция маски как непрозрачность при рендеринге кисти чернил. Значение по умолчанию — `True`; вызов [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) с `False` переключает использование операции ROP.

### **Скрыть объекты чернил в PDF‑выводе**

По умолчанию объекты чернил остаются видимыми при экспорте. Чтобы получить чистый вывод без рукописных аннотаций или другого чернильного содержимого, вызовите [InkOptions.setHideInk](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#setHideInk) с `True`.

Следующий пример Python экспортирует презентацию в PDF, скрывая все объекты чернил:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Скрыть объекты чернил при рендеринге слайда в изображение**

Чтобы скрыть объекты чернил при рендеринге слайдов в растровые изображения, настройте [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/#getInkOptions) и передайте параметры рендеринга в [Slide.getImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getImage).

Следующий пример Python рендерит первый слайд в PNG‑изображение без объектов чернил:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Управление рендерингом маски чернил**

Настройка [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) определяет, как операции маски интерпретируются при рендеринге кистей чернил. Значение по умолчанию — `True`, что использует непрозрачность. Чтобы вместо этого использовать операцию ROP, вызовите [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) с `False`.

Следующий пример Python экспортирует слайд в SVG и использует рендеринг на основе ROP для операций маски чернил:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

То же самое можно применить через [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/tiffoptions/#getInkOptions) при экспорте презентации или рендеринге слайда в TIFF.

### **Выбор: скрывать или сохранять чернила**

Когда вам требуется чистая версия аннотированной презентации для распространения без отметок рецензирования, вызовите [InkOptions.setHideInk](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#setHideInk) с `True` во время экспорта.

Оставьте [InkOptions.getHideInk](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#getHideInk) со значением `False`, если чернильные аннотации являются частью предполагаемого содержимого, например, комментариев рецензента, рукописных заметок, выделений или рисунков, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные версии для рецензирования и финального результата из одной и той же презентации без изменения исходных чернильных объектов.

## **FAQ**

**Можно ли изменить цвет или размер существующего штриха чернил?**

Да. Получите трек через [Ink.getTraces](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ink/#getTraces), затем измените его [InkTrace.getBrush](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inktrace/#getBrush). Вызовите [InkBrush.setColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkbrush/#setColor) или [InkBrush.setSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkbrush/#setSize), чтобы изменить кисть.

**Изменяет ли скрытие чернил исходную презентацию?**

Нет. Вызов [InkOptions.setHideInk](https://reference.aspose.com/slides/ru/python-java/aspose.slides/inkoptions/#setHideInk) влияет только на отрендеренный или экспортированный результат; он не удаляет и не изменяет объекты чернил в исходной презентации.

**Какие форматы экспорта поддерживают параметры чернил?**

Вы можете настроить параметры чернил для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или рендеринга, указанные выше.

**Дополнительные материалы**

* Чтобы узнать о формах в целом, см. раздел [PowerPoint Shapes](/slides/ru/python-java/powerpoint-shapes/).
* Для получения информации об эффективных значениях, см. [Shape Effective Properties](/slides/ru/python-java/shape-effective-properties/#get-effective-font-height-value).
* Для сведения о экспорте в PDF, см. [Convert PPT and PPTX to PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/).
* Для сведения об экспорте в HTML, см. [Convert PowerPoint Presentations to HTML](/slides/ru/python-java/convert-powerpoint-to-html/).
* Для сведения об экспорте в SVG, см. [Render Presentation Slides as SVG Images](/slides/ru/python-java/render-a-slide-as-an-svg-image/).
* Для сведения об экспорте в TIFF, см. [Convert PowerPoint Presentations to TIFF](/slides/ru/python-java/convert-powerpoint-to-tiff/).
* Для сведения о рендеринге слайдов в изображения, см. [Convert Presentation Slides to Images](/slides/ru/python-java/convert-slide/).