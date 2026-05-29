---
title: Создание 3D-эффектов в презентациях с использованием Python
linktitle: 3D-презентация
type: docs
weight: 232
url: /ru/python-net/3d-presentation/
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
- Aspose.Slides
description: "Применяйте и рендерите 3D-эффекты для фигур и текста PowerPoint в Python с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, экструзию, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Python via .NET может создавать, изменять, сохранять и отображать 3D‑форматирование в стиле PowerPoint для фигур и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, экструзия, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="primary" %}}
Эта статья посвящена 3D‑форматированию фигур и текста в PowerPoint. Она не охватывает вставку или редактирование отдельны х файлов 3D‑моделей. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑результат.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте свойство [Shape.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/three_d_format/) для применения 3D‑форматирования к фигуре. Это свойство открывает доступ к [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте свойство [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/three_d_format/). Оно применяет 3D‑форматирование к рамке текста, а не к телу фигуры.

Самые важные свойства:

| Свойство | Что управляет | Когда использовать |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/camera/) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращение объекта в 3D‑пространстве или соответствие предустановке вращения PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/light_rig/) | Предустановка освещения, направление и вращение света. | Изменение отображения бликов и теней на 3D‑поверхности. |
| [material](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/material/) | Материал поверхности, например плоский, матовый, пластик или металл. | Делает одну и ту же геометрию более плоской, мягкой, блестящей или металлической. |
| [extrusion_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/extrusion_height/) | Насколько фигура вытягивается назад от своей передней грани. | Превращает плоскую фигуру в визуально толстый 3D‑объект. |
| [extrusion_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/extrusion_color/) | Цвет экструзированных боковин. | Делает глубину видимой или согласует цвет боковин с передней заливкой. |
| [depth](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/depth/) | Дополнительная 3D‑глубина, используемая форматом PowerPoint. | Точная настройка глубины для фигур или текста, особенно совместно с фасками и материалом. |
| [bevel_top](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/bevel_top/) и [bevel_bottom](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/bevel_bottom/) | Поднятые или скруглённые края на передних и задних гранях. | Добавление смягчённого или формованного края вместо острого плоского лица. |
| [contour_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/contour_color/) и [contour_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/contour_width/) | Контур вокруг 3D‑объекта. | Подчёркивает границы объекта в рендеринге. |

## **Создание 3D‑фигуры**

Для того чтобы фигура выглядела правдоподобно в 3D, обычно нужны четыре типа настроек:

- Настройки камеры, потому что вид по умолчанию может скрывать экструзию.
- Настройки света, потому что освещение делает грани и стороны различимыми.
- Настройки материала, потому что поверхность влияет на то, как свет отрисовывается.
- Настройки экструзии или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создаёт прямоугольник, добавляет текст на его переднюю грань, применяет 3D‑форматирование, сохраняет презентацию как PPTX и рендерит слайд в PNG‑изображение.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Отрендеренное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Отрендеренный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается в панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют тем, что задаются через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения X, Y и Z](img_02_01.png)

В Aspose.Slides задавайте тип камеры и вращение через [ThreeDFormat.camera](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Используйте камеру, когда нужно изменить точку обзора для зрителя. Камера не меняет 2D‑геометрию фигуры на слайде, а меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление экструзии и глубины**

Экструзия делает фигуру толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![Контролы глубины PowerPoint, сопоставленные со свойствами extrusion_color и extrusion_height](img_02_02.png)

Установите [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/extrusion_height/) для толщины и [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/extrusion_color/) для цвета боковин:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Используйте [ThreeDFormat.depth](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/depth/) при необходимости работать напрямую со значением глубины PowerPoint или комбинировать глубину с фаской, материалом и эффектами текста. Во многих случаях для фигур более понятно использовать [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/extrusion_height/), поскольку он прямо задаёт видимую экструзию.

## **Градиентные или растровые заливки с 3D‑эффектами**

3D‑форматирование независимо от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и экструзии.

В примере ниже применяется градиентная заливка к фигуре и более тёмный цвет экструзии к боковым граням:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

Отрендеренный результат сохраняет градиент на передней грани и отдельным образом отображает экструзию:

![Отрендеренный 3D‑прямоугольник с градиентом от синего к оранжевому и оранжевой экструзией](img_02_03.png)

Чтобы использовать растровую заливку, добавьте изображение в презентацию и задайте его в качестве заливки фигуры:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Изображение отображается на передней грани, а экструзия рендерится как 3D‑поверхность боков:

![Отрендеренный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевой экструзией](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на рамку текста. Это полезно для эффектов, похожих на WordArt, когда сами буквы требуют экструзии, материала, освещения и настроек камеры.

В следующем примере создаётся текст с узорчатой заливкой, применяется трансформация WordArt и настраиваются 3D‑параметры [TextFrameFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/):

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

Текст отображается как изогнутые, экструзированные 3D‑буквы:

![Отрендеренный 3D‑текст с арочным преобразованием WordArt, оранженной узорчатой заливкой и тёмной экструзией](img_02_05.png)

## **Экспорт и поведение рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или отрисовывается в выходной файл как 2D‑результат. Это справедливо при рендеринге слайдов в [PNG](/slides/ru/python-net/convert-powerpoint-to-png/), экспорте в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), экспорте в [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), или генерации кадров для [video conversion](/slides/ru/python-net/convert-powerpoint-to-video/).

Учтите следующее:

- Экспортированные изображения и PDF‑файлы не интерактивны. Объект нельзя вращать после экспорта.
- Финальный вид зависит от комбинации камеры, светового оборудования, материала, экструзии, заливки и масштаба слайда.
- Если необходимо просмотреть унаследованные или тематические значения форматирования, читайте [effective shape properties](/slides/ru/python-net/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF‑файлы или HTML‑страницы интерактивными 3D‑сценами, которые пользователь мог бы вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат это поддерживает.

**В чём разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной фигуре или тексту PowerPoint, такое как вращение, экструзия, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**

Минимум — установить вращение камеры и либо экструзию, либо глубину. На практике также задают световую схему и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты и к фигурам, и к тексту?**

Да. Используйте [Shape.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/three_d_format/) для тела фигуры и [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/three_d_format/) для текста.

**Будут ли 3D‑эффекты отображаться при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконвертации. Экспортированный результат содержит отрисованное изображение, а не редактируемый 3D‑объект.

**Можно ли считать окончательные 3D‑значения после применения наследования и тем?**

Да. Используйте API эффективного форматирования, описанные в [Shape Effective Properties](/slides/ru/python-net/shape-effective-properties/), чтобы получить финальные значения камеры, световой схемы, фаски и связанных 3D‑параметров.