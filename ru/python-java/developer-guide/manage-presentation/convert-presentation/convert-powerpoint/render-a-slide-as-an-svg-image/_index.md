---
title: Экспортировать слайды презентации в виде SVG‑изображений в Python через Java
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- Параметры экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Экспортировать слайды PowerPoint в виде SVG‑изображений в Python через Java и управлять шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — это масштабируемый формат изображений на основе XML, который хорошо подходит для веб‑публикаций, просмотрщиков слайдов, рабочих процессов доступности и автоматической постобработки. Aspose.Slides экспортирует каждый слайд в отдельный SVG‑файл и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) когда экспортируемый SVG должен быть компактным, предсказуемым в разных браузерах или готовым к интерактивному использованию.

## **Экспортировать слайд как SVG**

Создайте [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Примеры требуют существующего файла `presentation.pptx`. Каждый пример при необходимости запускает JVM и закрывает выходные потоки. Ниже приведён пример, который экспортирует каждый слайд презентации в отдельный SVG‑файл.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Имя файла формируется с помощью [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber), а не индекса цикла. Вы также можете экспортировать отдельную фигуру с помощью [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/), когда просмотрщику слайдов или веб‑странице нужен только этот объект.

## **Настроить вывод SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых кадров [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) включает текстовый кадр в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) определяет, применяется ли вращение кадра. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) в `True`, когда текст должен рендериться без лигатур.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Управление обрезкой конца линии у наконечников стрелок**

В SVG 1.1 нет настройки смещения маркера, позволяющей указать, где линия должна обрезаться под наконечником. По умолчанию Aspose.Slides укорачивает экспортируемую линию, чтобы её штрих не выступал за пределы маркера. Вызовите [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) со значением `True`, чтобы рисовать штрих до исходной конечной точки линии. Эта настройка влияет только на вывод SVG. Позиция и длина линии на слайде остаются прежними.

Пример рисует треугольные и ромбовидные наконечники на линиях толщиной 2 и 10 пунктов. Он экспортирует один и тот же слайд дважды, меняя только параметр обрезки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Сравнение показывает треугольный наконечник на 10‑пунктовой линии. При включённой обрезке кончик острый. При отключённой обрезке штрих выступает за наклонные стороны маркера и образует плоский конец.

![Увеличенный треугольник 10 пунктов с острым кончиком при включённой обрезке и плоским концом при отключённой обрезке](line-end-cropping.png)

В остальных линиях примера выступающий штрих менее заметен на 2‑пунктовом треугольнике. Заполненный ромб покрывает конец штриха при обеих ширинах.

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете контролировать, останется ли текст текстовым или будет преобразован в векторную графику, а также как включаются или ссылаются внешние шрифты. Ниже перечислены варианты, помогающие сбалансировать визуальную согласованность, возможность выбора текста и зависимости от шрифтов в экспортированном SVG.

### **Векторизовать весь текст**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) в `True`, чтобы записать весь текст слайдов как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным в разных браузерах, но текст уже нельзя будет выделять или искать как SVG‑текст.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Выберите способ обработки внешних шрифтов**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) принимает значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/). Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Проверьте лицензирование шрифтов перед их встраиванием.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Сократить размер внедренных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) для снижения разрешения внедрённых изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) для исключения обрезанных областей источника и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) для управления качеством JPEG‑кодирования. Эти параметры уменьшают размер файла за счёт качества изображения или сохранённого объёма данных изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Управление разрешением растеризации метафайлов**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его для баланса между детализацией и размером файла, когда растеризуется изображение EMF или WMF. Он не определяет глобальное DPI для SVG и не принуждает каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), в котором содержится изображение EMF с плотно расположенными диагональными линиями. Ниже показан пример, экспортирующий первый слайд с тремя разрешениями растеризации через [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Все остальные параметры экспорта остаются одинаковыми, чтобы результаты можно было сравнить.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

В результате EMF превращается в один встроенный PNG в каждом SVG. Ниже приведены измерения для предоставленной презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| Разрешение растеризации метафайла DPI | Размеры встроенного PNG | Размер файла SVG (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже демонстрирует один и тот же участок внедрённого растра при одинаковом увеличенном размере отображения. Диагональные линии показывают заметную пикселизацию при 72 DPI и более плавные края при более высоких разрешениях, при этом размер SVG‑файла растёт. Увеличение значения не обязательно улучшает каждую деталь или меняет каждое экспортированное изображение.

![Увеличенная детализация диагональной линии при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) управляет снижением разрешения изображений и может скрывать эффект изменения разрешения растеризации метафайла. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) управляет качеством JPEG‑кодирования, а не разрешением растеризации метафайла.

## **Назначить стабильные идентификаторы фигурам и тексту**

Используйте контроллер форматирования Python, зарегистрированный через `jpype.JProxy`, чтобы назначать значения [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) фигурам и [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) элементам текста `tspan`. Привяжите прокси с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Ниже показан контроллер, использующий [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), который остаётся стабильным в течение жизни фигуры, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для пост‑обработки неизменённой презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Добавить обработчики событий SVG**

В контроллере форматирования Python вызовите [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) с объектом [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) для добавления обработчика JavaScript к экспортируемой фигуре. Зарегистрируйте контроллер через `jpype.JProxy` и привяжите его с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Определите функцию JavaScript на странице или в SVG‑документе, который размещает результат.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Хост‑страница может определить функцию JavaScript, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий открывает возможности для просмотрщиков слайдов, улучшения доступности и других интерактивных SVG‑рабочих процессов.

## **Вопросы и ответы**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Какой лучший способ сделать SVG меньше?**

Начните с сжатия внедрённых изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, потому что снижение разрешения изображения, снижение качества JPEG и векторизация текста имеют разные компромиссы между качеством и размером.

**Можно ли изменить экспортированные элементы SVG после экспорта?**

Да. Назначьте идентификаторы через контроллер форматирования, а затем выберите соответствующие SVG‑элементы в вашем инструменте пост‑обработки или скрипте браузера.