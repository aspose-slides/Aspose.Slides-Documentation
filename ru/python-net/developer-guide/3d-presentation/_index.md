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
description: "Применяйте и визуализируйте 3D‑эффекты для форм и текста PowerPoint в Python с помощью Aspose.Slides. Настраивайте камеру, освещение, материал, выдавливание, заливки и 3D‑текст."
---
## **Обзор**

Aspose.Slides for Python via .NET может создавать, редактировать, сохранять и рендерить 3D‑форматирование PowerPoint‑подобных форм и текста. В этой статье рассматриваются 3D‑эффекты, такие как вращение, выдавливание, фаски, освещение, материал, градиентные или растровые заливки и 3D‑текст.

{{% alert color="info" title="Note" %}}

Эта статья посвящена 3D‑форматированию форм и текста PowerPoint. Она не относится к вставке или редактированию отдельных 3D‑модельных файлов. При экспорте слайда в изображение, PDF или HTML Aspose.Slides рендерит эти 3D‑эффекты в экспортированный 2D‑вывод.

{{% /alert %}}

## **Концепции 3D‑форматирования**

Используйте свойство [Shape.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/three_d_format/) для применения 3D‑форматирования к форме. Свойство предоставляет доступ к [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/), который управляет 3D‑сценой для данной формы.

Для текста используйте свойство [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/three_d_format/). Оно применяет 3D‑форматирование к текстовому кадру вместо тела формы.

Самыми важными свойствами являются:

| Свойство | Что управляет | Когда использовать |
|---|---|---|
| [camera](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/camera/) | Точка обзора, предустановленный тип камеры, вращение, масштаб и перспектива. | Вращайте объект в 3D‑пространстве или используйте предустановку вращения 3D PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/light_rig/) | Предустановка освещения, направление и вращение света. | Измените отображение бликов и теней на 3D‑поверхности. |
| [material](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/material/) | Материал поверхности, например плоский, матовый, пластик или металл. | Сделайте одинаковую геометрию более плоской, мягкой, глянцевой или металлической. |
| [extrusion_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/extrusion_height/) | Насколько далеко форма выдвигается назад от своей передней грани. | Преобразуйте плоскую форму в явно толстый 3D‑объект. |
| [extrusion_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/extrusion_color/) | Цвет выдавленных боковых граней. | Сделайте глубину видимой или согласуйте цвет боков с передней заливкой. |
| [depth](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/depth/) | Дополнительная 3D‑глубина, используемая в 3D‑форматировании PowerPoint. | Точно настройте глубину для форм или текста, особенно совместно с настройками фаски и материала. |
| [bevel_top](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/bevel_top/) и [bevel_bottom](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/bevel_bottom/) | Поднятые или скругленные кромки на передних и задних гранях. | Добавьте смягченную или форму‑образную кромку вместо острой плоской грани. |
| [contour_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/contour_color/) и [contour_width](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/contour_width/) | Контур вокруг 3D‑объекта. | Подчеркните границу объекта в визуализированном выводе. |

## **Создание 3D‑формы**

Обычно форме требуется четыре типа настроек, чтобы она выглядела убедительно 3D:

- Настройки камеры, потому что стандартный вид спереди может скрыть выдавливание.
- Настройки освещения, поскольку свет делает грани и боковые поверхности различимыми.
- Настройки материала, так как поверхность влияет на то, как свет отображается.
- Настройки выдавливания или глубины, так как плоской форме нужна толщина.

В следующем примере создаётся прямоугольник, добавляется текст на его переднюю грань и применяется 3D‑форматирование. Значения вращения камеры указаны в градусах, а высота выдавливания — 100 пунктов. Пример рендерит слайд в PNG‑изображение вдвое больше его стандартных размеров и сохраняет презентацию как PPTX.

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

Отрисованный синий 3D‑прямоугольник с белым 3D‑текстом на передней грани:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Вращение формы с помощью камеры**

В PowerPoint 3D‑вращение настраивается на панели 3‑D Rotation. Значения вращения по осям X, Y и Z соответствуют вращению, установленному через API камеры.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

В Aspose.Slides доступ к камере осуществляется через [ThreeDFormat.camera](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/camera/). В этом примере создаётся прямоугольник, выбирается ортографический вид спереди и задаются вращения X, Y и Z соответственно 20, 30 и 40 градусов. Форматирование формы происходит в памяти без сохранения файла:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Используйте камеру, когда необходимо изменить то, как зритель видит объект. Она не меняет 2D‑геометрию формы на слайде. Она изменяет 3D‑точку обзора, используемую PowerPoint и Aspose.Slides при рендеринге.

## **Добавление выдавливания и глубины**

Выдавливание делает форму толстой, вытягивая её за переднюю грань. В PowerPoint контроль глубины задаёт эту видимую толщину, а контроль цвета задаёт цвет боковых граней.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Установите [ThreeDFormat.extrusion_height] для толщины и [ThreeDFormat.extrusion_color] для цвета боков. В этом примере прямоугольнику задаётся выдавливание 100 пунктов с пурпурными сторонами и камера вращается, чтобы показать толщину. Форматирование формы происходит в памяти без сохранения файла:

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

Свойство [ThreeDFormat.depth] задаёт глубину 3D‑формы. Свойство [extrusion_height] управляет высотой эффекта выдавливания, как показано в этом примере.

## **Использование градиентных или растровых заливок с 3D‑эффектами**

3D‑форматирование не зависит от заливки формы. Можно применить сплошной цвет, градиент, узор или растровую заливку к передней грани и при этом использовать те же настройки камеры, света, материала и выдавливания.

В этом примере применяется градиент от синего к оранжевому на переднюю грань и тёмно‑оранжевый цвет к выдавливанию 150 пунктов. Остановки градиента на 0 и 100 обозначают начало и конец градиента. Значения вращения камеры указаны в градусах. Слайд рендерится в PNG‑изображение вдвое больше его стандартных размеров:

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

Отрисованный 3D‑прямоугольник с градиентной заливкой от синего к оранжевому и оранжевым выдавливанием:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Чтобы вместо этого использовать растровую заливку, добавьте изображение в презентацию и назначьте его заливкой формы. Этот пример требует существующего файла с именем "image.jpg" в рабочем каталоге. Он растягивает изображение, чтобы заполнить прямоугольник, применяет выдавливание 150 пунктов и задаёт вращение камеры в градусах. Форматирование формы происходит в памяти без сохранения или рендеринга файла:

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

Отрисованный 3D‑прямоугольник с фотографической заливкой на передней грани и оранжевым выдавливанием:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Применение 3D‑форматирования к тексту**

3D‑форматирование формы влияет на её тело. 3D‑форматирование текста влияет на текстовый кадр. Это полезно для эффектов, похожих на WordArt, где сами буквы требуют выдавливания, материала, освещения и настроек камеры.

В следующем примере создаётся текст с оранжево‑белой сеткой, применяется изгиб вверх и настраиваются 3D‑параметры через [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/three_d_format/). Высота выдавливания и глубина указаны в пунктах, а вращение света — в градусах. Заливка и контур формы скрыты, чтобы был виден только текст. Пример рендерит PNG‑изображение вдвое больше стандартных размеров слайда и сохраняет презентацию как PPTX:

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

Отрисованный 3D‑текст с изогнутой трансформацией WordArt, оранжевой узорной заливкой и темным выдавливанием:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Сохранение текста плоским на 3D‑форме**

Чтобы сохранить читаемость текста, сохраняя 3D‑вид формы, установите [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/keep_text_flat/) через [TextFrame.text_frame_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/text_frame_format/). Когда значение `True`, текст остаётся вне 3D‑сцены. Когда значение `False`, текст участвует в сцене и следует её 3D‑ориентации.

Эта настройка не удаляет 3D‑форматирование формы: её камера, освещение, материал и выдавливание остаются настроенными через [Shape.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/three_d_format/). Это также отличается от обычного вращения. [Shape.rotation] вращает форму в плоскости слайда, в то время как [TextFrameFormat.rotation_angle] управляет пользовательским вращением текста внутри его ограничивающего прямоугольника. Сохранение текста вне 3D‑сцены не сбрасывает ни один из этих углов.

В следующем автономном примере создаётся синий прямоугольник с текстом и клонируется рядом с оригиналом. Обе формы имеют одинаковое 3D‑форматирование; различается только настройка текста: `False` слева и `True` справа. Углы камеры указаны в градусах, высота выдавливания — 40 пунктов. Пример сохраняет презентацию как PPTX и рендерит сравнительный слайд в PNG вдвое больше стандартных размеров.

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

Параллельно расположенные 3D‑прямоугольники: keep_text_flat — False слева и True справа:

![Side-by-side 3D rectangles: keep_text_flat is False on the left and True on the right](keep_text_flat.png)

## **Экспорт и поведение рендеринга**

Aspose.Slides сохраняет 3D‑форматирование при сохранении в форматы PowerPoint, такие как PPTX. При рендеринге или экспорте в форматы фиксированной разметки сцена 3D растрируется или отображается в выводе как 2D‑результат. Это относится к рендерингу слайдов в [PNG](/slides/ru/python-net/convert-powerpoint-to-png/), экспорту в [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), экспорту в [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), или генерации кадров для [video conversion](/slides/ru/python-net/convert-powerpoint-to-video/).

- Экспортированные изображения и PDF не являются интерактивными. Объект нельзя вращать после экспорта.
- Конечный вид зависит от комбинации камеры, освещения, материала, выдавливания, заливки и масштабирования слайда.
- Если необходимо проверить унаследованные или основанные на теме значения форматирования, прочитайте [эффективные свойства формы](/slides/ru/python-net/shape-effective-properties/).
- Некоторые форматы вывода не могут хранить редактируемое 3D‑форматирование PowerPoint. В этих форматах визуальный результат рендерится, а не сохраняется как редактируемые 3D‑настройки.

## **Часто задаваемые вопросы**

**Может ли Aspose.Slides создавать интерактивные 3D‑презентации?**

Aspose.Slides создает и рендерит 3D‑эффекты PowerPoint для форм и текста. Он не делает экспортированные изображения, PDF или HTML‑страницы интерактивными 3D‑сценами, которые пользователь может вращать. В PPTX 3D‑форматирование остаётся редактируемым в PowerPoint, если формат поддерживает его.

**В чем разница между 3D‑моделью и 3D‑эффектом?**

3D‑модель — это отдельный 3D‑объект, вставляемый в презентацию. 3D‑эффект — это форматирование, применяемое к обычной форме PowerPoint или тексту, такое как вращение, выдавливание, фаска, освещение и материал. В этой статье рассматриваются 3D‑эффекты.

**Какие настройки необходимы для видимой 3D‑формы?**

Как минимум, задайте вращение камеры и либо выдавливание, либо глубину. На практике также следует задать освещение и материал, чтобы отрисованные грани имели чёткие блики и тени.

**Можно ли применять 3D‑эффекты и к формам, и к тексту?**

Да. Используйте [Shape.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/three_d_format/) для тела формы и [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/three_d_format/) для текста.

**Будут ли 3D‑эффекты видны при экспорте в изображения, PDF, HTML или видеокадры?**

Да. Aspose.Slides рендерит 3D‑эффекты при создании изображений слайдов, PDF‑вывода, HTML‑вывода и кадров, используемых для видеоконверсии. Экспортированный вывод содержит отрисованный вид, а не редактируемый 3D‑объект.

**Можно ли получить окончательные 3D‑значения после применения наследования и настроек темы?**

Да. Используйте API эффективного форматирования, описанные в [эффективных свойствах формы](/slides/ru/python-net/shape-effective-properties/), чтобы прочитать окончательные значения камеры, освещения, фаски и связанных 3D‑параметров.