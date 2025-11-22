---
title: Создание 3D презентаций в Python
linktitle: 3D презентация
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
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко создавайте интерактивные 3D презентации на Python с помощью Aspose.Slides. Быстро экспортируйте в форматы PowerPoint и OpenDocument для универсального использования."
---

## **Обзор**

Как обычно создавать 3D-презентацию в PowerPoint? Microsoft PowerPoint позволяет добавлять 3D-модели, применять 3D-эффекты к фигурам, создавать 3D-текст, вставлять 3D-графику и создавать 3D-анимацию.

Создание 3D-эффектов оказывает большое влияние и часто является самым простым способом превратить обычную презентацию в 3D-презентацию. Начиная с Aspose.Slides 20.9, был добавлен новый **cross-platform 3D engine**. Этот движок позволяет экспортировать и растеризовать фигуры и текст с 3D-эффектами. В более ранних версиях фигуры с 3D-эффектами отображались плоско; теперь их можно отобразить с **full-fledged 3D**. Вы также можете создавать фигуры с 3D-эффектами через API Aspose.Slides.

В API Aspose.Slides, чтобы сделать фигуру 3D-фигурой PowerPoint, используйте свойство [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) , которое раскрывает члены класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat) :

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) и [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/): задайте фаски, выберите тип фаски (например, Angle, Circle, SoftRound) и определите высоту и ширину фаски.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/): имитировать движение камеры вокруг объекта; регулируя поворот камеры, масштаб и другие свойства, можно управлять фигурами как 3D-моделями в PowerPoint.
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) и [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/): задайте свойства контура, чтобы фигура выглядела как 3D-объект PowerPoint.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/), [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/), и [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/): сделайте фигуру трехмерной, задав ее глубину или экструзию.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/): создайте освещающие эффекты на 3D-фигуре; аналогично камере, можно задать вращение света относительно 3D-фигуры и выбрать тип света.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/): выберите материал, чтобы сделать 3D-фигуру более реалистичной. Предустановленные материалы включают Metal, Plastic, Powder, Matte и другие.

Все 3D-функции могут применяться как к фигурам, так и к тексту. Ниже приведены разделы, демонстрирующие, как получить доступ к этим свойствам и изучить их пошагово.
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


Отрисованная миниатюра выглядит так:

![todo:image_alt_text](img_01_01.png)

## **3D‑вращение**

Вы можете вращать 3D-фигуры PowerPoint в трехмерном пространстве, чтобы добавить интерактивность. Чтобы вращать 3D-фигуру в PowerPoint, используйте следующее меню:

![todo:image_alt_text](img_02_01.png)

В API Aspose.Slides вы управляете 3D‑вращением фигуры через свойство [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) .
```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... установить другие параметры 3D-сцены

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```


## **3D‑глубина и экструзия**

Чтобы добавить третье измерение к вашей фигуре и сделать её действительно 3D, используйте свойства [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) и [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) :
```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... установить другие параметры 3D-сцены

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```


В PowerPoint обычно используется меню **Depth** для установки глубины 3D‑фигуры:

![todo:image_alt_text](img_02_02.png)

## **3D‑градиент**

Градиент можно использовать для заливки 3D-фигуры PowerPoint. Создадим фигуру с градиентной заливкой и применим к ней 3D-эффект:
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


И вот результат:

![todo:image_alt_text](img_02_03.png)

В дополнение к градиентным заливкам вы можете заполнять фигуры изображением:
```py
with open("image.png", "rb") as image_file:
    image_data = image_file.read()

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    # ... настройка 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* properties

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("sample_3d.png")
```


Так это выглядит:

![todo:image_alt_text](img_02_04.png)

## **3D‑текст (WordArt)**

Aspose.Slides позволяет также применять 3D-эффекты к тексту. Чтобы создать 3D‑текст, можно использовать эффект преобразования WordArt:
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


Вот результат:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Сохранятся ли 3D-эффекты при экспорте презентации в изображения/PDF/HTML?**

Да. 3D‑движок Slides рендерит 3D‑эффекты при экспорте в поддерживаемые форматы ([images](/slides/ru/python-net/convert-powerpoint-to-png/), [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), и т.д.).

**Могу ли я получить «эффективные» (окончательные) значения параметров 3D, учитывающие темы, наследование и т.д.?**

Да. Slides предоставляет API для [read effective values](/slides/ru/python-net/shape-effective-properties/) (в том числе для 3D — освещение, фаски и пр.), чтобы вы могли увидеть итоговые применённые настройки.

**Работают ли 3D-эффекты при конвертации презентации в видео?**

Да. При [generating frames for the video](/slides/ru/python-net/convert-powerpoint-to-video/) 3D‑эффекты рендерятся так же, как и для [exported images](/slides/ru/python-net/convert-powerpoint-to-png/).