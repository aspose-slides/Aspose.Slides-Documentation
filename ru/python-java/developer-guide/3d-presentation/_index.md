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
- 3D выдавливание
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте и визуализируйте 3D‑эффекты для фигур и текста PowerPoint в Python через Java с Aspose.Slides. Настраивайте камеру, освещение, материал, выдавливание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Python via Java может создавать, редактировать, сохранять и визуализировать 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты такие как вращение, выдавливание, фаски, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="info" title="Примечание" %}}

Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не касается вставки или редактирования отдельных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортируемый 2D‑вывод.

{{% /alert %}}

Установите пакет, как описано в [Installation](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides`, при необходимости запускает JVM и затем импортирует API. Пример с заливкой картинкой требует файл `image.jpg` в рабочем каталоге.

## **Концепции 3D‑форматирования**

Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat), чтобы применить 3D‑форматирование к фигуре. Возвращаемый объект формата управляет 3D‑сценой для этой фигуры.

Для текста используйте [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat). Это применяет 3D‑форматирование к текстовой рамке, а не к телу фигуры.

Самые важные члены API:

| Член API | Что управляет | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getCamera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3D‑пространстве или сопоставьте с предустановкой вращения 3D в PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getLightRig) | Предустановка освещения, направление и вращение света. | Измените отображение бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько далеко фигура вытекает назад от передней грани. | Преобразуйте плоскую фигуру в явно толстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет выдавленных боковых граней. | Сделайте глубину видимой или согласуйте цвет боков с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая форматированием PowerPoint 3D. | Точная настройка глубины для фигур или текста, особенно совместно с настройками фаски и материала. |
| [getBevelTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или закруглённые кромки на передней и задней гранях. | Добавьте смягчённый или отлёченный край вместо острого плоского. |
| [getContourColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setContourWidth) | Контур вокруг 3D‑объекта. | Подчеркните границу объекта в визуализированном результате. |

## **Создание 3D‑фигуры**

Обычно фигуре требуется четыре вида настроек, чтобы выглядеть убедительно в 3D:

- Настройки камеры, потому что вид по умолчанию может скрывать выдавливание.
- Настройки освещения, потому что свет делает грани и боковины различимыми.
- Настройки материала, потому что поверхность влияет на то, как свет отображается.
- Настройки выдавливания или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

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

Отрендеренный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, которое задаётся через API камеры.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через 3D‑формат, возвращаемый [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat):

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

Используйте камеру, когда нужно изменить точку зрения наблюдателя. Это не меняет 2D‑геометрию фигуры на слайде, а меняет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление выдавливания и глубины**

Выдавливание делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт видимую толщину, а контроль цвета задаёт цвет боковых граней.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Установите высоту выдавливания для толщины и цвет выдавливания для цвета боков:

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

Используйте настройку глубины, когда необходимо работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и эффектами текста. Во многих сценариях фигур параметр высоты выдавливания более наглядный, так как он непосредственно выражает видимую выдавливку.

## **Использование градиентных или изображений заливки с 3D‑эфектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинку к передней грани и при этом использовать те же настройки камеры, света, материала и выдавливания.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет выдавливания к боковым граням:

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

Отрендеренный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Чтобы использовать заливку изображением, добавьте изображение в презентацию и назначьте его заливкой фигуры:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
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
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Картинка рендерится на передней грани, а выдавливание отображается как 3D‑боковая поверхность:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовую рамку. Это полезно для эффектов, похожих на WordArt, где сами буквы требуют выдавливания, материала, освещения и настроек камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформ WordArt и настраивает 3D‑параметры у [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/):

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

Отрендеренный 3D‑текст с изогнутым трансформом WordArt, оранжевой узорной заливкой и тёмным выдавливанием:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Экспорт и поведение при визуализации**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это относится к рендерингу слайдов в PNG, экспорту в PDF, HTML или генерации кадров для видеоконвертации.

Имейте в виду следующие моменты:

- Экспортированные изображения и PDF не интерактивны. Объект нельзя вращать после экспорта.
- Окончательный вид зависит от комбинации камеры, освещения, материала, выдавливания, заливки и масштаба слайда.
- Если необходимо просмотреть унаследованные или основанные на теме значения форматирования, используйте API эффективного форматирования.
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **Часто задаваемые вопросы**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и визуализирует 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, где формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставленный в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, выдавливание, фаска, освещение и материал. Эта статья рассматривает именно 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — установить вращение камеры и либо выдавливание, либо глубину. На практике также задают световую схему и материал, чтобы у визуализированных граней были чёткие блики и тени.

**Можно ли применять 3D‑эффекты и к фигурам, и к тексту?**

Да. Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat) для тела фигуры и [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный результат содержит отрендеренный вид, а не редактируемый 3D‑объект.

**Можно ли прочитать окончательные 3D‑значения после применения наследования и настроек темы?**

Да. Используйте [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getEffective) для получения финальных значений камеры, световой схемы, фаски и связанных 3D‑параметров.