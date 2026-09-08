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
- 3D экструдирование
- 3D градиент
- 3D текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте и рендерьте 3D-эффекты для фигур и текста PowerPoint в Python через Java с Aspose.Slides. Настраивайте камеру, освещение, материал, экструдирование, заливки и 3D-текст."
---
## **Обзор**

Aspose.Slides for Python via Java может создавать, изменять, сохранять и рендерить 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструдирование, фаски, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="info" title="Примечание" %}}
Эта статья относится к 3D‑форматированию фигур и текста PowerPoint. Она не охватывает вставку или редактирование отдельных файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

Установите пакет, как описано в [Установка](/slides/ru/python-java/installation/). Каждый пример импортирует `asposeslides`, при необходимости запускает JVM и затем импортирует API. Пример с заливкой картинкой требует файл `image.jpg` в рабочем каталоге.

## **Концепции 3D‑форматирования**

Используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat), чтобы применить 3D‑форматирование к фигуре. Возвращаемый объект формата управляет 3D‑сценой для этой фигуры.

Для текста используйте [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat). Это применяет 3D‑форматирование к текстовому кадру вместо тела фигуры.

Самыми важными членами API являются:

| Член API | Что контролирует | Когда использовать |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getCamera) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Поворот объекта в 3D‑пространстве или соответствие предустановке 3D‑вращения PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getLightRig) | Предустановка света, направление и вращение света. | Изменение отображения бликов и теней на 3D‑поверхности. |
| [getMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getMaterial) и [setMaterial](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setMaterial) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделать одинаковую геометрию более плоской, мягкой, блестящей или металлической. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionHeight) и [setExtrusionHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Насколько фигура вытягивается назад от своей передней грани. | Превратить плоскую фигуру в заметно толcстый 3D‑объект. |
| [getExtrusionColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getExtrusionColor) | Цвет экструдированных сторон. | Сделать глубину видимой или согласовать цвет сторон с передней заливкой. |
| [getDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getDepth) и [setDepth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setDepth) | Дополнительная 3D‑глубина, используемая в форматировании PowerPoint. | Тонко настроить глубину фигур или текста, особенно совместно с фаской и материалом. |
| [getBevelTop](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelTop) и [getBevelBottom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getBevelBottom) | Поднятые или скруглённые кромки на передних и задних гранях. | Добавить смягчённую или формованную кромку вместо острой плоской поверхности. |
| [getContourColor](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getContourWidth) и [setContourWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#setContourWidth) | Контур вокруг 3D‑объекта. | Подчеркнуть границу объекта в визуальном выводе. |

## **Создание 3D‑фигуры**

Обычно фигуре нужны четыре типа настроек, чтобы она выглядела убедительно 3D:

- Настройки камеры, потому что вид спереди по умолчанию может скрывать экструдирование.
- Настройки света, поскольку освещение делает грани и боковые стороны различимыми.
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.
- Настройки экструдирования или глубины, потому что плоской фигуре нужна толщина.

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

Отрисованное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Поворот фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели «3‑D Rotation». Значения вращения по осям X, Y и Z соответствуют вращению, которое задаётся через API камеры.

![Панель PowerPoint 3‑D Rotation с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides задайте тип камеры и вращение через 3D‑формат, возвращаемый методом [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat):

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

Используйте камеру, когда нужно изменить точку обзора объекта. Это не меняет 2D‑геометрию фигуры на слайде, а изменяет 3D‑точку обзора, которую используют PowerPoint и Aspose.Slides при рендеринге.

## **Добавление экструдирования и глубины**

Экструдирование делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint параметр глубины устанавливает видимую толщину, а параметр цвета задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, сопоставленные с параметрами цвета экструдирования и высоты экструдирования](img_02_02.png)

Задайте высоту экструдирования для толщины и цвет экструдирования для цвета боковых сторон:

```python
import jpide
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

Используйте настройку глубины, когда нужно работать напрямую со значением глубины PowerPoint или комбинировать её с фаской, материалом и текстовыми эффектами. Во многих сценариях фигур высота экструдирования более наглядна, потому что напрямую выражает видимую экструдированность.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинку к передней грани и при этом использовать те же настройки камеры, света, материала и экструдирования.

Этот пример применяет градиентную заливку к фигуре и более тёмный цвет экструдирования к боковым сторонам:

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

Отрисованный вывод сохраняет градиент на передней грани и отдельо рендерит экструдирование:

![Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым экструдированием](img_02_03.png)

Чтобы использовать заливку картинкой, добавьте изображение в презентацию и назначьте его заливкой фигуры:

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

Картинка рендерится на передней грани, а экструдирование отображается как 3D‑поверхность боков:

![Отрисованный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым экструдированием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигур влияет на тело фигуры. 3D‑форматирование текста влияет на текстовый кадр. Это полезно для эффектов, похожих на WordArt, когда сами буквы нуждаются в экструдировании, материале, освещении и настройках камеры.

Следующий пример создаёт текст с узорной заливкой, применяет трансформацию WordArt и настраивает 3D‑параметры на объекте [TextFrameFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/):

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

Текст отрисовывается как изогнутые, экструдированные 3D‑буквы:

![Отрисованный 3D‑текст с арочным преобразованием WordArt, оранженной узорной заливкой и тёмным экструдированием](img_02_05.png)

## **Поведение при экспорте и рендеринге**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растрируется или рисуется в вывод как 2D‑результат. Это относится к рендерингу слайдов в PNG, экспорту в PDF, экспорту в HTML и генерации кадров для видеоконвертации.

Имейте в виду следующее:

- Экспортированные изображения и PDF‑файлы не интерактивны. Объект нельзя вращать после экспорта.
- Итоговый вид зависит от комбинации камеры, осветительной установки, материала, экструдирования, заливки и масштабирования слайда.
- Если нужно просмотреть унаследованные или тематические значения форматирования, используйте API эффективного форматирования.
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **Вопросы и ответы**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF‑файлы или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такие как вращение, экструдирование, фаска, освещение и материал. Эта статья охватывает именно 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — задать вращение камеры и либо экструдирование, либо глубину. На практике также задают осветительную установку и материал, чтобы грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты одновременно к фигурам и к тексту?**

Да. Для тела фигуры используйте [Shape.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getThreeDFormat), а для текста — [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getThreeDFormat).

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, вывода PDF, HTML и кадров, используемых для видеоконвертации. Экспортированный вывод содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли считать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте [ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getEffective), чтобы получить конечные значения камеры, осветительной установки, фаски и связанных 3D‑параметров.