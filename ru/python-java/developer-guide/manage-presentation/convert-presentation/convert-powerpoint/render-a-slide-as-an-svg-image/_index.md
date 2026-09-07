---
title: Экспорт слайдов презентаций в виде изображений SVG в Python через Java
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
description: "Экспорт слайдов PowerPoint в виде изображений SVG в Python через Java с управлением шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — это масштабируемый формат изображений на основе XML, который хорошо подходит для веб‑публикаций, просмотров слайдов, рабочих процессов доступности и автоматической постобработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспортировать слайд в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [Slide.writeAsSvg](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/). Примеры требуют существующего файла `presentation.pptx`. Каждый пример при необходимости запускает JVM и закрывает свои выходные потоки. Следующий пример экспортирует каждый слайд презентации в отдельный файл SVG.

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

Имя файла использует [Slide.getSlideNumber](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getSlideNumber) вместо индекса цикла. Вы также можете экспортировать отдельную форму с помощью [Shape.writeAsSvg](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), когда просмотровщик слайдов или веб‑страница нуждаются только в этой форме.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setUseFrameSize) включает текстовую рамку в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setUseFrameRotation) определяет, применяется ли вращение рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) в `True`, когда текст должен рендериться без лигатур.

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

## **Управление текстом и шрифтами**

### **Векторизация всего текста**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setVectorizeText) в `True`, чтобы записывать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным между браузерами, но текст больше не будет выделяемым или searchable как SVG‑текст.

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

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed` — чтобы включить данные шрифта в SVG, или `Vectorize` — чтобы отрисовывать только текст, использующий внешние шрифты, как графику. Проверьте лицензирование шрифтов перед их встраиванием.

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

## **Уменьшение размера встроенных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setPicturesCompression) для снижения разрешения встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) — чтобы исключать обрезанные области источника, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setJpegQuality) — для управления качеством кодирования JPEG. Эти параметры уменьшают размер файла ценой качества изображения или сохранённости данных изображения.

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

## **Назначение стабильных идентификаторов формам и тексту**

Используйте контроллер форматирования Python, зарегистрированный через `jpype.JProxy`, чтобы присвоить значения [SvgShape.setId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgshape/#setId) формам и значения [SvgTSpan.setId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgtspan/#setId) элементам текста `tspan`. Назначьте прокси с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Следующий контроллер использует [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getOfficeInteropShapeId), который остаётся стабильным в течение всего жизненного цикла формы, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для постобработки неизменённой презентации.

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

## **Добавление обработчиков событий SVG**

В контроллере форматирования Python вызовите [SvgShape.setEventHandler](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgshape/#setEventHandler) с объектом [SvgEvent](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgevent/), чтобы добавить обработчик JavaScript к экспортированной форме. Зарегистрируйте контроллер через `jpype.JProxy` и назначьте его с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Определите функцию JavaScript на странице или в SVG‑документе, содержащем результат.

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

Хост‑страница может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий позволяет реализовать просмотровщики слайдов, улучшения доступности и другие интерактивные рабочие процессы SVG.

## **FAQ**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setVectorizeText) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgoptions/#setVectorizeText), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/svgexternalfontshandling/#Vectorize), когда только текст, использующий внешние шрифты, должен быть преобразован в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора связанных файлов шрифтов, если целевая среда может их обслуживать. Протестируйте результат, поскольку снижение разрешения изображения, снижение качества JPEG и векторизация текста по‑разному влияют на качество и размер.

**Можно ли изменить экспортированные элементы SVG после экспорта?**

Да. Присвойте идентификаторы через контроллер форматирования, затем выберите соответствующие SVG‑элементы в вашем инструменте постобработки или скрипте браузера.