---
title: Создание 3D‑презентаций на Python
linktitle: 3D‑презентация
type: docs
weight: 232
url: /ru/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑презентация
- 3D‑вращение
- 3D‑глубина
- 3D‑выдавливание
- 3D‑градиент
- 3D‑текст
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко создавайте интерактивные 3D‑презентации на Python с помощью Aspose.Slides. Быстро экспортируйте в форматы PowerPoint и OpenDocument для универсального использования."
---

## **Обзор**

Как обычно создаёте 3D‑презентацию в PowerPoint? Microsoft PowerPoint позволяет добавлять 3D‑модели, применять 3D‑эффекты к фигурам, создавать 3D‑текст, вставлять 3D‑графику и строить 3D‑анимацию.

Создание 3D‑эффектов производит большое впечатление и часто является самым простым способом превратить обычный набор слайдов в 3D‑презентацию. Начиная с Aspose.Slides 20.9, добавлен новый **кроссплатформенный 3D‑движок**. Этот движок позволяет экспортировать и растеризовать фигуры и текст с 3D‑эффектами. В более ранних версиях фигуры с 3D‑эффектами отрисовывались плоско; теперь они могут быть отрисованы с **полноценным 3D**. Вы также можете создавать фигуры с 3D‑эффектами через API Aspose.Slides.

В API Aspose.Slides, чтобы сделать фигуру 3D‑фигурой PowerPoint, используйте свойство [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/), которое открывает члены класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat):

- [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) и [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/): задают фаски, выбирают тип фаски (например, Angle, Circle, SoftRound) и определяют высоту и ширину фаски.  
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/): симулирует движение камеры вокруг объекта; изменяя вращение, масштаб и другие параметры камеры, можно управлять фигурами как 3D‑моделями в PowerPoint.  
- [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) и [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/): задают свойства контура, чтобы фигура выглядела как 3D‑объект PowerPoint.  
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/), [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) и [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/): делают фигуру трёхмерной, задавая её глубину или выдавливание.  
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/): создаёт световые эффекты на 3D‑фигуре; аналогично камере, можно задать вращение света относительно фигуры и выбрать тип освещения.  
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/): выбирает материал, чтобы 3D‑фигура выглядела более реалистично. Предопределённые материалы включают Metal, Plastic, Powder, Matte и др.

Все 3D‑возможности применимы как к фигурам, так и к тексту. Ниже показано, как получать доступ к этим свойствам и последовательно их использовать.

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

Сгенерированная миниатюра выглядит так:

![todo:image_alt_text](img_01_01.png)

## **3D‑вращение**

Вы можете вращать 3D‑фигуры PowerPoint в трёхмерном пространстве, делая их интерактивными. Чтобы повернуть 3D‑фигуру в PowerPoint, используйте следующее меню:

![todo:image_alt_text](img_02_01.png)

В API Aspose.Slides вращением 3D‑фигуры управляют через свойство [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/).

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... задать другие параметры 3D‑сцены

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

## **3D‑толщина и выдавливание**

Чтобы добавить третье измерение к фигуре и сделать её действительно 3D, используйте свойства [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) и [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/):

```py
shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
# ... задать другие параметры 3D‑сцены

with slide.get_image(image_scale, image_scale) as thumbnail:
    thumbnail.save("sample_3d.png")
```

В PowerPoint обычно используют меню **Depth** для задания глубины 3D‑фигуры:

![todo:image_alt_text](img_02_02.png)

## **3D‑градиент**

Градиент можно использовать для заполнения 3D‑фигуры PowerPoint. Создадим фигуру с градиентным заполнением и применим к ней 3D‑эффект:

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

И результат:

![todo:image_alt_text](img_02_03.png)

Помимо градиентных заливок, фигуру можно заполнить изображением:

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

Вот как это выглядит:

![todo:image_alt_text](img_02_04.png)

## **3D‑текст (WordArt)**

Aspose.Slides позволяет также применять 3D‑эффекты к тексту. Чтобы создать 3D‑текст, можно использовать трансформ‑эффект WordArt:

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
    # настройка эффекта WordArt «Arch Up»
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

Результат:

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Будут ли сохранены 3D‑эффекты при экспорте презентации в изображения/PDF/HTML?**

Да. 3D‑движок Slides рендерит 3D‑эффекты при экспорте в поддерживаемые форматы ([изображения](/slides/ru/python-net/convert-powerpoint-to-png/), [PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/ru/python-net/convert-powerpoint-to-html/), и др.).

**Можно ли получить «эффективные» (окончательные) значения 3D‑параметров, учитывающие темы, наследование и т.п.?**

Да. Slides предоставляет API для [чтения эффективных значений](/slides/ru/python-net/shape-effective-properties/) (в том числе для 3D — освещения, фасок и пр.), позволяя увидеть окончательные настройки.

**Работают ли 3D‑эффекты при конвертации презентации в видео?**

Да. При [генерации кадров для видео](/slides/ru/python-net/convert-powerpoint-to-video/) 3D‑эффекты рендерятся так же, как при [экспорте изображений](/slides/ru/python-net/convert-powerpoint-to-png/).