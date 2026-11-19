---
title: Создание 3D‑эффектов в презентациях с использованием Python
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/python-net/3d-presentation/
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
- Aspose.Slides
description: "Применяйте и рендерьте 3D‑эффекты для фигур и текста PowerPoint в Python с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, выдавливание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Python via .NET может создавать, редактировать, сохранять и рендерить 3D‑форматирование в стиле PowerPoint для фигур и текста. Эта статья охватывает 3D‑эффекты, такие как вращение, выдавливание, фаски, освещение, материал, градиентные или картинные заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}
Эта статья о 3D‑эффектах форматирования фигур и текста PowerPoint. Она не о вставке или редактировании отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.
{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте свойство [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) для применения 3D‑форматирования к фигуре. Это свойство раскрывает [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), который управляет 3D‑сценой для этой фигуры.

Для текста используйте свойство [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Оно применяет 3D‑форматирование к текстовому фрейму вместо тела фигуры.

Самыми важными свойствами являются:

| Свойство | Что контролирует | Когда использовать |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Точка зрения, предустановленный тип камеры, вращение, масштаб и перспектива. | Поверните объект в 3D‑пространстве или сопоставьте с предустановкой вращения 3D в PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Предустановка освещения, направление и вращение света. | Измените отображение бликов и теней на 3D‑поверхности. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одну и ту же геометрию более плоской, мягкой, глянцевой или металлической. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Насколько фигура выступает назад от её передней грани. | Превратите плоскую фигуру в заметно толстый 3D‑объект. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Цвет выдавленных боковых граней. | Сделайте глубину видимой или согласуйте цвет боков с передней заливкой. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Дополнительная 3D‑глубина, используемая PowerPoint при 3D‑форматировании. | Точно настройте глубину фигур или текста, особенно совместно с настройками фаски и материала. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) и [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Поднятые или закруглённые кромки на передних и задних гранях. | Добавьте смягчённый или сформованный край вместо острого плоского лица. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) и [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Контур вокруг 3D‑объекта. | Подчеркните границу объекта в визуализированном выводе. |

## **Создание 3D‑фигуры**

Для того чтобы фигура выглядела убедительно 3D, обычно требуются четыре типа настроек:

- Настройки камеры, так как вид по умолчанию спереди может скрывать выдавливание.  
- Настройки освещения, поскольку свет делает грани и боковины читаемыми.  
- Настройки материала, поскольку поверхность влияет на то, как свет отображается.  
- Настройки выдавливания или глубины, потому что плоской фигуре нужна толщина.

Следующий пример создает прямоугольник, добавляет текст к его передней грани и применяет 3D‑форматирование. Значения вращения камеры указаны в градусах, а высота выдавливания — 100 пунктов. Пример рендерит слайд в PNG‑изображение в двойных размерах по сравнению с размером по умолчанию и сохраняет презентацию как PPTX.

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

Сформированное изображение слайда показывает прямоугольник как толстый 3D‑блок:

![Синий 3D‑прямоугольник с белым 3D‑текстом на передней грани](img_01_01.png)

## **Вращение фигуры с помощью камеры**

В PowerPoint 3D‑вращение настраивается на панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, установленному через API камеры.

![Панель 3‑D Rotation в PowerPoint с выделенными значениями вращения по X, Y и Z](img_02_01.png)

В Aspose.Slides доступ к камере происходит через [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Этот пример создает прямоугольник, выбирает ортографический вид спереди и задает его вращения X, Y и Z соответственно 20, 30 и 40 градусов. Он конфигурирует фигуру в памяти без сохранения файла:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Используйте камеру, когда нужно изменить то, как пользователь видит объект. Это не меняет 2D‑геометрию фигуры на слайде. Оно меняет 3D‑точку зрения, используемую PowerPoint и Aspose.Slides при рендеринге.

### **Копирование ориентации камеры из шаблонной фигуры**

Чтобы сопоставить ориентацию с шаблонной фигурой, скопируйте её предустановку [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) и прочитайте её вращение с помощью [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Пример открывает `template.pptx` и копирует ориентацию камеры с первой фигуры первого слайда во вторую фигуру. Обе фигуры уже имеют 3D‑освещение, а у второй фигуры нет явного вращения камеры.

Углы указаны в градусах. Индексы `0`, `1` и `2` хранят соответственно широту, долготу и оборот. Передайте их в [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) в этом порядке. Если источник не имеет явного вращения, `get_rotation` возвращает `None`, поэтому оставьте углы назначения неустановленными. Если источник явно задаёт все три угла как ноль, скопируйте эти нули.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Когда вы откроете `camera-copy.pptx` в PowerPoint, обе фигуры будут иметь одинаковую предустановку камеры и вращение. Стрелка справа использует ориентацию, скопированную из прямоугольника слева. Обе фигуры используют одинаковое освещение и глубину выдавливания.

![Синий 3D‑прямоугольник и правая стрелка с совпадающей ориентацией камеры, вид сверху и справа](camera-orientation.png)

## **Добавление выдавливания и глубины**

Выдавливание делает фигуру толстой, расширяя её за переднюю грань. В PowerPoint элемент управления глубиной задаёт эту видимую толщину, а элемент управления цветом задаёт цвет боковых граней.

![Элементы управления глубиной PowerPoint, соответствующие свойствам цвета выдавливания и высоты выдавливания](img_02_02.png)

Установите [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) для толщины и [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) для цвета боков. Этот пример задаёт прямоугольнику выдавливание 100 пунктов с пурпурными боками и вращает камеру, чтобы показать толщину. Он конфигурирует фигуру в памяти без сохранения файла:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Свойство [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) задаёт глубину 3D‑фигуры. Свойство [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) управляет высотой эффекта выдавливания, как показано в этом примере.

## **Использование градиентных или картинных заливок с 3D‑эффектами**

3D‑форматирование не зависит от заливки фигуры. Вы можете применить сплошной цвет, градиент, узор или картинную заливку к передней грани и при этом использовать те же настройки камеры, света, материала и выдавливания.

Этот пример применяет градиент от синего к оранжевому к передней грани и тёмно‑оранжевый цвет к выдавливанию высотой 150 пунктов. Градиентные маркеры 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд рендерится в PNG‑изображение в двойных размерах по сравнению с размерами по умолчанию:

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

Сформированный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием:

![Сформированный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием](img_02_03.png)

Чтобы использовать картинную заливку, добавьте изображение в презентацию и назначьте его заливкой фигуры. Этот пример требует наличия файла `image.jpg` в рабочем каталоге. Он растягивает картинку, заполняя прямоугольник, применяет выдавливание 150 пунктов и задаёт вращение камеры в градусах. Он конфигурирует фигуру в памяти без сохранения или рендеринга файла:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Картинка отображается на передней грани, а выдавливание — как 3D‑боковая поверхность:

![Сформированный 3D‑прямоугольник с фотозаливкой на передней грани и оранжевым выдавливанием](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование фигуры влияет на тело фигуры. 3D‑форматирование текста влияет на текстовый фрейм. Это полезно для эффектов, похожих на WordArt, когда самим буквам требуется выдавливание, материал, освещение и настройки камеры.

Следующий пример создаёт текст с оранжево‑белой сеткой, применяет изгиб вверх и настраивает 3D‑параметры через [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Высота выдавливания и глубина указаны в пунктах, вращение света — в градусах. Заливка и контур фигуры скрыты, чтобы был виден только текст. Пример рендерит PNG‑изображение в двойных размерах по сравнению со слайдом по умолчанию и сохраняет презентацию как PPTX:

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

Сформированный 3D‑текст с выгнутой трансформацией WordArt, оранжевой заливкой узором и тёмным выдавливанием:

![Сформированный 3D‑текст с выгнутой трансформацией WordArt, оранжевой заливкой узором и тёмным выдавливанием](img_02_05.png)

## **Сохранение текста плоским на 3D‑фигуре**

Чтобы текст оставался читаемым, сохраняя 3D‑вид фигуры, установите [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) через [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Когда значение `True`, текст остаётся вне 3D‑сцены. Когда `False`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование фигуры: её камера, освещение, материал и выдавливание продолжают работать через [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). Это также отличается от обычного вращения. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) вращает фигуру в плоскости слайда, тогда как [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) задаёт пользовательское вращение текста внутри его ограничивающего прямоугольника. Оставление текста вне 3D‑сцены не сбрасывает ни один из этих углов.

Следующий автономный пример создаёт синий прямоугольник с текстом и клонирует его рядом с оригиналом. Обе фигуры имеют одинаковое 3D‑форматирование; различается только настройка текста: `False` слева и `True` справа. Углы камеры указаны в градусах, высота выдавливания — 40 пунктов. Пример сохраняет презентацию как PPTX и рендерит сравнение слайда в PNG в двойных размерах по сравнению с оригиналом:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

Слева текст следует 3D‑ориентации. Справа он остаётся плоским и легче читаемым. Оба прямоугольника сохраняют одинаковое видимое выдавливание и 3D‑ориентацию.

![Две 3D‑прямоугольника рядом: keep_text_flat – False слева и True справа](keep_text_flat.png)

## **Экспорт и поведение рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки 3D‑сцена растеризуется или рисуется в вывод как 2D‑результат. Это применимо, когда вы рендерите слайды в [PNG](/slides/ru/python-net/convert-powerpoint-to-png/), экспортируете в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), экспортируете в [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), или генерируете кадры для [video conversion](/slides/ru/python-net/convert-powerpoint-to-video/).

Учтите следующие моменты:

- Экспортированные изображения и PDF не интерактивны. После экспорта пользователь не может вращать объект.  
- Окончательный вид зависит от комбинации камеры, освещения, материала, выдавливания, заливки и масштабирования слайда.  
- Если нужно проверить наследованные или тематические значения форматирования, прочитайте [эффективные свойства фигуры](/slides/ru/python-net/shape-effective-properties/).  
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **FAQ**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**  
Aspose.Slides создаёт и рендерит 3D‑эффекты PowerPoint для фигур и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чём разница между 3D‑моделью и 3D‑эффектом?**  
3D‑модель — отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — форматирование, применяемое к обычной фигуре или тексту PowerPoint (вращение, выдавливание, фаска, освещение, материал). В этой статье рассматриваются 3D‑эффекты.

**Какие настройки требуются для видимой 3D‑фигуры?**  
Минимум — задать вращение камеры и либо выдавливание, либо глубину. На практике также задают световую сцену и материал, чтобы рендеренные грани имели чёткие блики и тени.

**Могу ли я применять 3D‑эффекты как к фигурам, так и к тексту?**  
Да. Используйте [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) для тела фигуры и [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или кадры видео?**  
Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров для видеоконвертации. Экспортированный файл содержит визуализированный вид, а не редактируемый 3D‑объект.

**Могу ли я прочитать окончательные 3D‑значения после применения наследования и настроек темы?**  
Да. Используйте API эффективного форматирования, описанное в [эффективные свойства фигуры](/slides/ru/python-net/shape-effective-properties/), чтобы получить окончательные значения камеры, световой сцены, фаски и связанных 3D‑параметров.