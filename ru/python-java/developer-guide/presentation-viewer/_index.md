---
title: Создать просмотрщик презентаций в Python через Java
linktitle: Просмотрщик презентаций
type: docs
weight: 50
url: /ru/python-java/presentation-viewer/
keywords: 
- просмотр презентации
- просмотрщик презентаций
- создание просмотрщика презентаций
- просмотр PPT
- просмотр PPTX
- просмотр ODP
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Создайте пользовательский просмотрщик презентаций в Python через Java с использованием Aspose.Slides. Легко отображайте файлы PowerPoint и OpenDocument без Microsoft PowerPoint."
---
## **Введение**

Aspose.Slides for Python via Java используется для создания файлов презентаций со слайдами. Эти слайды можно просматривать, открывая презентации в Microsoft PowerPoint, например. Однако иногда разработчикам может потребоваться просматривать слайды как изображения в их предпочтительном просмотрщике изображений или создавать свой собственный просмотрщик презентаций. В таких случаях Aspose.Slides позволяет экспортировать отдельный слайд в виде изображения. В этой статье описано, как это сделать.

## **Создание SVG‑изображения из слайда**

Чтобы создать SVG‑изображение из слайда презентации с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Откройте байтовый поток.
1. Сохраните слайд как SVG‑изображение в поток и запишите его в файл.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Создание SVG с пользовательским идентификатором формы**

Aspose.Slides можно использовать для создания [SVG](https://docs.fileformat.com/page-description-language/svg/) из слайда с пользовательским идентификатором формы. Для этого используйте метод [SvgShape.setId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgshape/#setId) из [SvgShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` может быть использован для установки идентификатора формы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Создание эскиза слайда**

Aspose.Slides помогает генерировать миниатюрные изображения слайдов. Чтобы создать миниатюру слайда с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите миниатюрное изображение указанного слайда с заданным масштабом.
1. Сохраните миниатюрное изображение в любом требуемом формате изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Создание миниатюры слайда с пользовательскими размерами**

Чтобы создать миниатюру слайда с пользовательскими размерами, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите миниатюрное изображение указанного слайда с заданными размерами.
1. Сохраните миниатюрное изображение в любом требуемом формате изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Создание миниатюры слайда с примечаниями докладчика**

Чтобы создать миниатюру слайда с примечаниями докладчика с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [RenderingOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/).
1. Используйте метод [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) для установки положения примечаний докладчика.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите миниатюрное изображение указанного слайда с указанными параметрами рендеринга.
1. Сохраните миниатюрное изображение в любом требуемом формате изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Живой пример**

Вы можете попробовать бесплатное приложение [**Aspose.Slides Viewer**](https://products.aspose.app/slides/ru/viewer/) чтобы увидеть, что можно реализовать с помощью API Aspose.Slides:

![Онлайн‑просмотрщик PowerPoint](online-PowerPoint-viewer.png)

## **FAQ**

**Можно ли встроить просмотрщик презентаций в веб‑приложение?**

Да. Вы можете использовать Aspose.Slides на стороне сервера для рендеринга слайдов в изображения или HTML и отображать их в браузере. Навигацию и масштабирование можно реализовать с помощью JavaScript для интерактивного опыта.

**Какой лучший способ отображать слайды внутри собственного просмотрщика?**

Рекомендуется рендерить каждый слайд как изображение (например, PNG или SVG) или преобразовывать его в HTML с помощью Aspose.Slides, а затем выводить результат в элементе picture (для настольных приложений) или в HTML‑контейнере (для веба).

**Как работать с большими презентациями, содержащими множество слайдов?**

Для больших наборов слайдов используйте отложенную загрузку или рендеринг по требованию. Это значит генерировать содержимое слайда только тогда, когда пользователь переходит к нему, что снижает потребление памяти и время загрузки.