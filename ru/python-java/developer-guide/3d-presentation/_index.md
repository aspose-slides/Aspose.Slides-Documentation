---
title: Создание 3D‑эффектов в презентациях с использованием Python
linktitle: 3D Презентация
type: docs
weight: 232
url: /ru/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструзия
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте и отображайте 3D‑эффекты для фигур и текста PowerPoint в Python через Java с Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Python via Java может создавать, редактировать, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья о 3D‑форматирующих эффектах для фигур и текста PowerPoint. Она не о вставке или редактировании отдельные файлов 3D‑моделей. Когда вы экспортируете слайд в изображение, PDF или HTML, Aspose.Slides отображает эти 3D‑эффекты в экспортированном 2D‑выводе.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте метод [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) для применения 3D‑форматирования к фигуре. Метод возвращает [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте метод [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Он применяет 3D‑форматирование к текстовой рамке вместо тела фигуры.

Самыми важными членами API являются:

| Член API | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Повернуть объект в 3D‑пространстве или соответствовать предустановке вращения 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Предустановка света, направление и вращение света. | Изменить отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько фигура вытягивается назад от своей передней грани. | Преобразовать плоскую фигуру в явно толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет экструдированных боковых граней. | Сделать глубину видимой или согласовать цвет боков с заливкой спереди. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настроить глубину для фигур или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или закруглённые кромки на передних и задних гранях. | Добавить смягчённый или формованный край вместо острой плоской грани. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) и [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в отрисованном выводе. |

## **Создание 3D‑фигуры**

Фигура обычно требует четыре типа настроек, прежде чем она будет выглядеть правдоподобно 3D:

- Настройки камеры, поскольку стандартный вид спереди может скрывать экструзию.
- Настройки света, поскольку освещение делает грани и боковые поверхности различимыми.
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.
- Настройки экструзии или глубины, поскольку плоской фигуре нужна толщина.

В следующем примере создаётся прямоугольник, на его переднюю грань добавляется текст и применяется 3D‑форматирование. Значения вращения камеры указаны в градусах, высота экструзии — 100 пунктов. Пример рендерит слайд в PNG‑изображение в два раза больше его стандартных размеров и сохраняет презентацию как PPTX.

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

Отображённое изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Поворот фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, задаваемому через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Этот пример создаёт прямоугольник, выбирает ортографический фронтальный вид и задаёт его вращения X, Y и Z соответственно 20, 30 и 40 градусов. Он настраивает фигуру в памяти без сохранения файла:

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

Используйте камеру, когда необходимо изменить то, как пользователь видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Это меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

### **Копирование ориентации камеры из шаблонной фигуры**

Чтобы совпасть с ориентацией шаблонной фигуры, считайте её предустановку камеры с помощью [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) и её углы вращения с помощью [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Пример открывает `template.pptx` и копирует ориентацию камеры из первой фигуры на первом слайде во вторую фигуру. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

Углы указаны в градусах. Индекс `0` — широта, индекс `1` — долгота, индекс `2` — оборот. Передайте их в [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) в том же порядке. Если источник возвращает `None`, у него нет явного вращения, поэтому оставьте углы второй фигуры неустановленными. Явное вращение `(0, 0, 0)` возвращает три нуля и должно быть скопировано.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

При повторном открытии `camera-copy.pptx` в PowerPoint стрелка справа имеет ту же предустановку камеры и вращение, что и прямоугольник слева. Обе фигуры используют одинаковое освещение и глубину экструзии.

![Синий 3D‑прямоугольник и правая стрелка с совпадающей ориентацией камеры, вид сверху и справа](camera-orientation.png)

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint элемент управления глубиной задаёт эту видимую толщину, а элемент управления цветом задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, сопоставленные с свойствами цвета экструзии и высоты экструзии](img_02_02.png)

Используйте [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) для задания толщины и [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) для доступа к цвету боков. Этот пример задаёт прямоугольнику экструзию 100 пунктов с фиолетовыми боками и вращает камеру, чтобы продемонстрировать толщину. Он настраивает фигуру в памяти без сохранения файла:

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

Метод [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) задаёт глубину 3D‑фигуры. Метод [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) управляет высотой эффекта экструзии, как показано в примере.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к экструзии 150 пунктов. Позиции градиентных стопов 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд рендерится в PNG‑изображение в два раза больше его стандартных размеров:

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

Отрисованный вывод сохраняет градиент на передней грани и отрисовывает экструзию отдельно:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует существующего файла «image.jpg» в рабочем каталоге. Он растягивает изображение, чтобы заполнить прямоугольник, задаёт экструзию 150 пунктов и вращает камеру в градусах. Он настраивает фигуру в памяти без сохранения или рендеринга файла:

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

Изображение отрисовывается на передней грани, а экструзия — как 3D‑боковая поверхность:

![Отрисованный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда самим буквам требуется экструзия, материал, освещение и настройки камеры.

В следующем примере создаётся текст с оранжево‑белой сеткой, применяется восходящий арочный изгиб и настраиваются 3D‑параметры через [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Высота и глубина экструзии указаны в пунктах, вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был видим только текст. Пример рендерит PNG‑изображение в два раза больше стандартных размеров слайда и сохраняет презентацию как PPTX:

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

Текст отрисовывается выгнутым, экструзированным 3D‑набором букв:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранжевой паттерн‑заливкой и тёмной экструзией](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы сохранить текст читаемым, одновременно сохраняя 3D‑вид фигуры, вызовите [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) через [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). При значении `True` текст остается вне 3D‑сцены. При `False` текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и экструзия остаются настроенными через [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Это также отличается от обычного вращения. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) вращает фигуру в плоскости слайда, тогда как [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

В следующем автономном примере создаётся синий прямоугольник с текстом и клонируется рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `False` слева и `True` справа. Углы камеры указаны в градусах, высота экструзии — 40 пунктов. Пример сохраняет презентацию как PPTX и рендерит сравнение слайдов в PNG в два раза больше стандартных размеров.

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

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читается. Оба прямоугольника сохраняют одинаковую видимую экструзию и 3D‑ориентацию.

![Пара 3D‑прямоугольников рядом: текст следует 3D‑ориентации слева и остаётся плоским справа](keep_text_flat.png)

## **Экспорт и поведение рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это относится к рендерингу слайдов в [PNG](/slides/ru/python-java/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/python-java/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/python-java/convert-powerpoint-to-html/), а также к генерации кадров для [video conversion](/slides/ru/python-java/convert-powerpoint-to-video/).

Обратите внимание:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, световой установки, материала, экструзии, заливки и масштабирования слайда.
- Если необходимо проверить унаследованные или тематические значения форматирования, читайте [effective shape properties](/slides/ru/python-java/shape-effective-properties/).
- Некоторые форматы вывода не могут сохранять редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат отрисовывается, а не сохраняется как редактируемые 3D‑настройки.

## **Часто задаваемые вопросы**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**  
Aspose.Slides создает и отображает 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат его поддерживает.

**В чём разница между 3D‑моделью и 3D‑эффектом?**  
3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, например вращение, экструзия, фаска, освещение и материал. Эта статья рассматривает 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**  
Минимум — задать вращение камеры и либо экструзию, либо глубину. На практике также следует установить световую установку и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Могу ли я применять 3D‑эффекты к фигурам и тексту?**  
Да. Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) для тела фигуры и [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) для текста.

**Появятся ли 3D‑эффекты при экспорте в изображения, PDF, HTML или видеокадры?**  
Да. Aspose.Slides отображает 3D‑эффекты при создании изображений слайдов, PDF‑выхода, HTML‑выхода и кадров, используемых для преобразования в видео. Экспортированный вывод содержит отрисованный вид, а не редактируемый 3D‑объект.

**Могу ли я прочитать окончательные 3D‑значения после применения наследования и настроек темы?**  
Да. Используйте API эффективного форматирования, описанные в [Shape Effective Properties](/slides/ru/python-java/shape-effective-properties/), чтобы получить окончательные значения камеры, световой установки, фаски и связанных 3D‑параметров.