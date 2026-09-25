---
title: Создание 3D-эффектов в презентациях с использованием Python
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D вытягивание
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте и рендерите 3D‑эффекты для фигур и текста PowerPoint в Python через Java с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, вытягивание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides для Python через Java может создавать, изменять, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, вытягивание, скосы, освещение, материал, градиентные или картинковые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья посвящена 3D‑эффектам форматирования фигур и текста в PowerPoint. Она не касается вставки или редактирования отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides преобразует эти 3D‑эффекты в экспортированный 2D‑результат.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat) для применения 3D‑форматирования к фигуре. Метод возвращает объект [ThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat). Он применяет 3D‑форматирование к текстовой рамке вместо тела фигуры.

Самыми важными членами API являются:

| Член API | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getCamera) | Точка зрения, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращать объект в 3D‑пространстве или соответствовать предустановке 3D‑вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getLightRig) | Предустановка света, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько далеко фигура выступает назад от своей передней грани. | Превратить плоскую фигуру в отчетливо толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет вытянутых боковых граней. | Сделать глубину видимой или согласовать цвет боков с заливкой спереди. |
| [getDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину для фигур или текста, особенно совместно с настройками скоса и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или скругленные кромки на передней и задней гранях. | Добавить смягченную или формованную кромку вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourColor) и [getContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setContourWidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границы объекта в отрисованном выводе. |

## **Создание 3D‑фигуры**

Фигуре обычно нужны четыре типа настроек, чтобы выглядеть убедительно 3D:

- Настройки камеры, потому что вид по умолчанию спереди может скрывать вытягивание.
- Настройки освещения, потому что свет делает грани и боковые поверхности различимыми.
- Настройки материала, потому что поверхность влияет на то, как отображается свет.
- Настройки вытягивания или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создает прямоугольник, добавляет текст к его передней грани и применяет 3D‑форматирование. Значения вращения камеры указаны в градусах, высота вытягивания — 100 пунктов. Пример отрисовывает слайд в PNG‑изображение в два раза больше стандартных размеров и сохраняет презентацию как PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Отрисованное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют тем, что задаются через API камеры.

![Панель PowerPoint 3‑D Rotation с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getCamera). Этот пример создает прямоугольник, выбирает ортографический фронтальный вид и задает вращения X, Y и Z — соответственно 20, 30 и 40 градусов. Фигура конфигурируется в памяти без сохранения файла:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Используйте камеру, когда необходимо изменить точку обзора объекта. Это не меняет 2D‑геометрию фигуры на слайде, а лишь меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление вытягивания и глубины**

Вытягивание делает фигуру толстой, удлиняя её за передней гранью. В PowerPoint контроль глубины задаёт видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Элементы управления глубиной в PowerPoint, сопоставленные с параметрами цвета вытягивания и высоты вытягивания](img_02_02.png)

Используйте [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setExtrusionHeight) для установки толщины и [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionColor) для доступа к цвету боков. Этот пример задаёт прямоугольнику вытягивание = 100 пунктов с фиолетовыми боками и вращает камеру, чтобы показать толщину. Фигура конфигурируется в памяти без сохранения файла:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Метод [ThreeDFormat.setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setDepth) задает глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setExtrusionHeight) управляет высотой эффекта вытягивания, как показано в этом примере.

## **Использование градиентных или картинных заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Можно применить сплошную заливку, градиент, шаблон или картинку к передней грани и при этом использовать те же настройки камеры, света, материала и вытягивания.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к 150‑пунктовому вытягиванию. Позиции градиентных стопов 0 и 100 определяют начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд отрисовывается в PNG‑изображение в два раза больше стандартных размеров:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

Отрисованный результат сохраняет градиент на передней грани и отдельно отрисовывает вытягивание:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым вытягиванием](img_02_03.png)

Чтобы использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует существующего файла «image.jpg» в рабочем каталоге. Он растягивает картинку, заполняя прямоугольник, задаёт вытягивание = 150 пунктов и вращение камеры в градусах. Фигура конфигурируется в памяти без сохранения или рендеринга файла:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Картинка отрисовывается на передней грани, а вытягивание — как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым вытягиванием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовую рамку. Это удобно для эффектов, похожих на WordArt, когда сами буквы требуют вытягивания, материала, освещения и настроек камеры.

Следующий пример создаёт текст с оранжево‑белой сеткой, применяет верхний арочный изгиб и конфигурирует 3D‑настройки через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat). Высота вытягивания и глубина указаны в пунктах, вращение света — в градусах. Заливка и контур фигуры скрыты, так что виден только текст. Пример отрисовывает PNG‑изображение в два раза больше стандартных размеров слайда и сохраняет презентацию как PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Текст отрисован как изогнутый, вытянутый 3D‑надпись:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранжевой шаблонной заливкой и темным вытягиванием](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑вид фигуры, вызовите [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setKeepTextFlat) через [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getTextFrameFormat). Когда значение `True`, текст остаётся вне 3D‑сцены. Когда `False`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и вытягивание остаются сконфигурированными через [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat). Это также отличается от обычного вращения. [Shape.setRotation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setRotation) вращает фигуру в плоскости слайда, а [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setRotationAngle) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий самостоятельный пример создаёт синий прямоугольник с текстом и копирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `False` слева и `True` справа. Углы камеры указаны в градусах, высота вытягивания = 40 пунктов. Пример сохраняет презентацию как PPTX и отрисовывает сравнительный слайд в PNG в два раза больше стандартных размеров.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и более читаемым. Оба прямоугольника сохраняют одинаковое видимое вытягивание и 3D‑ориентацию.

![Бок‑о‑бок 3D‑прямоугольники: текст следует 3D‑ориентации слева и остаётся плоским справа](keep_text_flat.png)

## **Экспорт и поведение при рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированного макета 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это происходит при рендеринге слайдов в [PNG](/slides/ru/python-java/convert-powerpoint-to-png/), экспорте в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), экспорте в [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), либо при создании кадров для [видеоконвертации](/slides/ru/python-java/convert-powerpoint-to-video/).

Имейте в виду:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Финальный вид зависит от комбинации камеры, световой установки, материала, вытягивания, заливки и масштабирования слайда.
- Если нужно проверить унаследованные или тематические значения форматирования, читайте [эффективные свойства фигур](/slides/ru/python-java/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат отрисовывается, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, где формат это поддерживает.

**В чем разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, вытягивание, скос, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑фигуры?**

Как минимум нужно задать вращение камеры и либо вытягивание, либо глубину. На практике также задают световую установку и материал, чтобы отрисованные грани имели четкие блики и тени.

**Можно ли применять 3D‑эффекты как к фигурам, так и к тексту?**

Да. Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat) для тела фигуры и [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный файл содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанное в [Эффективные свойства фигур](/slides/ru/python-java/shape-effective-properties/), чтобы получить финальные значения камеры, световой установки, скоса и связанных 3D‑параметров.