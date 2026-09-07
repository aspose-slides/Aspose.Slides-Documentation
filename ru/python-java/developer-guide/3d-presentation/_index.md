---
title: Создание 3D эффектов в презентациях с использованием Python
linktitle: 3D презентация
type: docs
weight: 232
url: /ru/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D презентация
- 3D вращение
- 3D глубина
- 3D экструдирование
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте и визуализируйте 3D эффекты для фигур и текста PowerPoint в Python через Java с Aspose.Slides. Настраивайте камеру, освещение, материал, экструдирование, заливки и 3D текст."
---
## **Обзор**

Aspose.Slides for Python via Java может создавать, редактировать, сохранять и визуализировать 3‑D форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3‑D эффекты, такие как вращение, экструдирование, фаски, освещение, материал, градиентные или картинные заливки и 3‑D текст.

{{% alert color="info" title="Note" %}}

Эта статья о 3‑D эффектах форматирования фигур и текста PowerPoint. Она не о вставке или редактировании отдельных 3‑D файлов моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides визуализирует эти 3‑D эффекты в экспортированном 2‑D выводе.

{{% /alert %}}

Установите пакет, как описано в [Установка](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides`, при необходимости запускает JVM и затем импортирует API. Пример с заливкой картинкой требует файл `image.jpg` в рабочем каталоге.

## **Концепции 3‑D Форматирования**

Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat), чтобы применить 3‑D форматирование к фигуре. Возвращаемый объект формата управляет 3‑D сценой для этой фигуры.

Для текста используйте [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat). Это применяет 3‑D форматирование к текстовой рамке, а не к телу фигуры.

Самыми важными членами API являются:

| Член API | Что он контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getCamera) | Точка обзора, тип предустановленной камеры, вращение, масштаб и перспектива. | Вращение объекта в 3‑D пространстве или соответствие предустановленному вращению PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getLightRig) | Предустановка света, направление и вращение света. | Изменить отображение бликов и теней на 3‑D поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Как далеко фигура вытягивается назад от своей передней грани. | Превратить плоскую фигуру в заметно толстый 3‑D объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет экструдированных боков. | Сделать глубину видимой или согласовать цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3‑D глубина, используемая в форматировании PowerPoint. | Точно настроить глубину фигур или текста, особенно в сочетании с фасками и материалом. |
| [getBevelTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или скруглённые кромки на передних и задних гранях. | Добавить смягчённую или формованную кромку вместо острого плоского края. |
| [getContourColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setContourWidth) | Обводка вокруг 3‑D объекта. | Подчеркнуть контур объекта в визуализированном выводе. |

## **Создание 3‑D Фигуры**

Фигура обычно требует четырёх видов настроек, чтобы выглядеть убедительно 3‑D:

- Настройки камеры, потому что стандартный вид спереди может скрыть экструдирование.
- Настройки освещения, потому что свет делает грани и боковины различимыми.
- Настройки материала, потому что поверхность влияет на то, как свет отображается.
- Настройки экструдирования или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст к его передней грани, применяет 3‑D форматирование, сохраняет презентацию как PPTX и визуализирует слайд в PNG‑изображение.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

Визуализированное изображение слайда показывает прямоугольник как толстый 3‑D блок:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Вращение Фигуры с Помощью Камеры**

В PowerPoint 3‑D вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, которое задаётся через API камеры.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через 3‑D формат, полученный от [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat):

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

Используйте камеру, когда нужно изменить точку зрения наблюдателя. Это не меняет 2‑D геометрию фигуры на слайде. Оно меняет 3‑D точку обзора, которую используют PowerPoint и Aspose.Slides при рендеринге.

## **Добавление Экструдирования и Глубины**

Экструдирование делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Установите высоту экструдирования для толщины и цвет экструдирования для цвета боков:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Используйте настройку глубины, когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать её с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур высота экструдирования понятнее, так как напрямую выражает видимую экструдированную часть.

## **Использование Градиентных или Картинных Заливок с 3‑D Эффектами**

3‑D форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструдирования.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет экструдирования к бокам:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

Визуализированный вывод сохраняет градиент на передней грани и отдельно рендерит экструдирование:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Чтобы использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Изображение отображается на передней грани, а экструдирование – как 3‑D боковая поверхность:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Применение 3‑D Форматирования к Тексту**

3‑D форматирование фигуры влияет на тело фигуры. 3‑D форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, когда самим буквам требуется экструдирование, материал, освещение и настройки камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформацию WordArt и настраивает 3‑D параметры у [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/):

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

Текст визуализируется как изогнутые, экструдированные 3‑D буквы:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Экспорт и Поведение При Визуализации**

Aspose.Slides сохраняет 3‑D форматирование при сохранении в форматы PowerPoint, такие как PPTX. При визуализации или экспорте в форматы фиксированного макета 3‑D сцена растеризуется или рисуется в вывод как 2‑D результат. Это относится к рендерингу слайдов в PNG, экспорту в PDF, HTML или генерации кадров для видеоконверсии.

Имейте в виду следующее:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать зрителем после экспорта.
- Окончательный вид зависит от комбинации камеры, световой установки, материала, экструдирования, заливки и масштабирования слайда.
- Если нужно проверить унаследованные или тематические значения форматирования, используйте API эффективного форматирования.
- Некоторые форматы вывода не могут хранить редактируемое 3‑D форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3‑D настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3‑D презентации?**

Aspose.Slides создаёт и визуализирует 3‑D эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3‑D сценами, которые зритель мог бы вращать. В PPTX 3‑D форматирование остаётся редактируемым в PowerPoint, где формат поддерживает его.

**В чём разница между 3‑D моделью и 3‑D эффектом?**

3‑D модель — это отдельный 3‑D объект, вставляемый в презентацию. 3‑D эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструдирование, фаска, освещение и материал. Эта статья рассматривает именно 3‑D эффекты.

**Какие настройки необходимы для видимой 3‑D фигуры?**

Как минимум задайте вращение камеры и либо экструдирование, либо глубину. На практике также задают световую установку и материал, чтобы визуализированные грани имели чёткие блики и тени.

**Можно ли применять 3‑D эффекты и к фигурам, и к тексту?**

Да. Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat) для тела фигуры и [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat) для текста.

**Будут ли 3‑D эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3‑D эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконверсии. Экспортированный вывод содержит отрендеренный внешний вид, а не редактируемый 3‑D объект.

**Можно ли считать окончательные 3‑D значения после применения наследования и тем?**

Да. Используйте [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getEffective), чтобы получить финальные значения камеры, световой установки, фаски и связанных 3‑D параметров.