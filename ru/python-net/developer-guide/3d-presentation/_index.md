---
title: Create 3D Presentations in Python
linktitle: 3D Presentation
type: docs
weight: 232
url: /ru/python-net/developer-guide/3d-presentation/
keywords:
- 3D PowerPoint
- 3D presentation
- 3D rotation
- 3D depth
- 3D extrusion
- 3D gradient
- 3D text
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Создавайте интерактивные 3D‑презентации на Python с помощью Aspose.Slides без усилий. Быстро экспортируйте в форматы PowerPoint и OpenDocument для универсального использования."
---

## **Обзор**

Как обычно создаёте 3D‑презентацию PowerPoint? Microsoft PowerPoint позволяет добавлять 3D‑модели, применять 3D‑эффекты к фигурам, создавать 3D‑текст, вставлять 3D‑графику и строить 3D‑анимацию.

Создание 3D‑эффектов оказывает сильное визуальное воздействие и часто является самым простым способом превратить обычный набор слайдов в 3D‑презентацию. Начиная с Aspose.Slides 20.9, добавлен новый **кроссплатформенный 3D‑движок**. Этот движок позволяет экспортировать и растеризовать фигуры и текст с 3D‑эффектами. В более ранних версиях фигуры с 3D‑эффектами рендерились плоско; теперь они могут отображаться с **полноценным 3D**. Вы также можете создавать фигуры с 3D‑эффектами через API Aspose.Slides.

В API Aspose.Slides, чтобы сделать фигуру 3D‑фигурой PowerPoint, используйте свойство [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/), которое раскрывает члены класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat):

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) и [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/): задавайте фаски, выбирайте тип фаски (например, Angle, Circle, SoftRound) и определяйте высоту и ширину фаски.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/): моделируйте перемещение камеры вокруг объекта; изменяя вращение, масштаб и другие свойства камеры, можно управлять фигурами как 3D‑моделями в PowerPoint.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) и [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/): задавайте свойства контура, чтобы фигура выглядела как 3D‑объект PowerPoint.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/), [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) и [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/): делайте фигуру трехмерной, задавая её глубину или экструдируя её.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/): создавайте световые эффекты на 3D‑фигуре; аналогично камере, можно задать вращение света относительно 3D‑фигуры и выбрать тип света.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/): выбирайте материал, чтобы 3D‑фигура выглядела более естественно. Предопределённые материалы включают Metal, Plastic, Powder, Matte и другие.

Все 3D‑возможности применимы как к фигуркам, так и к тексту. Ниже показано, как получить доступ к этим свойствам и пошагово их использовать.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")

    presentation.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

Отрендеренный миниатюра выглядит так:

![todo:image_alt_text](img_01_01.png)

## **3D‑вращение**

Вы можете вращать 3D‑фигуры PowerPoint в трехмерном пространстве, добавляя интерактивность. Чтобы вращать 3D‑фигуру в PowerPoint, используйте следующее меню:

![todo:image_alt_text](img_02_01.png)

В API Aspose.Slides вращение 3D‑фигуры контролируется через свойство [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/).

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... задать другие параметры 3D‑сцены

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **3D‑глубина и экструдирование**

Чтобы придать фигуре третье измерение и сделать её действительно 3D, используйте свойства [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) и [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... задать другие параметры 3D‑сцены

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

В PowerPoint обычно используется меню **Depth** для установки глубины 3D‑фигуры:

![todo:image_alt_text](img_02_02.png)

## **3D‑градиент**

Градиент можно использовать для заливки 3D‑фигуры PowerPoint. Создадим фигуру с градиентной заливкой и применим к ней 3D‑эффект:

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
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

И результат выглядит так:

![todo:image_alt_text](img_02_03.png)

Помимо градиентных заливок, фигуры можно заполнять изображением:

```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... настройка 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* свойства

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```

Вот как это выглядит:

![todo:image_alt_text](img_02_04.png)

## **3D‑текст (WordArt)**

Aspose.Slides позволяет применять 3D‑эффекты и к тексту. Чтобы создать 3D‑текст, можно использовать трансформацию WordArt:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D text"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    text_frame_format = shape.text_frame.text_frame_format
    # настройка трансформации WordArt "Arch Up"
    text_frame_format.transform = slides.TextShapeType.ARCH_UP

    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text3d.png")

    presentation.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

Полученный результат:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Сохранятся ли 3D‑эффекты при экспорте презентации в изображения/PDF/HTML?**

Да. 3D‑движок Slides рендерит 3D‑эффекты при экспорте в поддерживаемые форматы ([изображения](/slides/ru/python-net/convert-powerpoint-to-png/), [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/) и др.).

**Можно ли получить «эффективные» (окончательные) значения 3D‑параметров, учитывающие темы, наследование и т.д.?**

Да. Slides предоставляет API для [чтения эффективных значений](/slides/ru/python-net/shape-effective-properties/) (включая 3D‑параметры — освещение, фаски и пр.), позволяя увидеть окончательные применённые настройки.

**Работают ли 3D‑эффекты при конвертации презентации в видео?**

Да. При [генерации кадров для видео](/slides/ru/python-net/convert-powerpoint-to-video/) 3D‑эффекты рендерятся так же, как при [экспорте изображений](/slides/ru/python-net/convert-powerpoint-to-png/).