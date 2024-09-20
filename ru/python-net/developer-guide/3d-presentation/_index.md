---
title: 3D Презентация
type: docs
weight: 232
url: /python-net/3d-presentation/
keywords: "3D, 3D PowerPoint, 3D презентация, 3D поворот, 3D глубина, 3D экструзия, 3D градиент, 3D текст, PowerPoint презентация, Python, Aspose.Slides для Python"
description: "3D PowerPoint презентация на Python"
---


## Обзор
Как вы обычно создаете 3D PowerPoint презентацию?
Microsoft PowerPoint позволяет создавать 3D презентации в том смысле, что мы можем добавлять 3D модели, применять 3D эффекты к фигурам,
создавать 3D текст, загружать 3D графику в презентацию, создавать 3D анимации в PowerPoint.

Создание 3D эффектов существенно улучшает вашу презентацию, превращая её в 3D презентацию, и может быть самым простым способом реализации 3D презентации.
Начиная с версии Aspose.Slides 20.9, был добавлен новый **кроссплатформенный 3D движок**. Новый 3D движок позволяет
экспортировать и растрировать фигуры и текст с 3D эффектами. В предыдущих версиях 
фигуры Slides с примененными 3D эффектами отображались плоско. Но теперь возможно
отрисовывать фигуры с **полноценным 3D**.
Более того, теперь возможно создавать фигуры с 3D эффектами через публичный API Slides.

В API Aspose.Slides, чтобы придать 
фигуре статус PowerPoint 3D фигуры, используйте свойство [IShape.ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), 
которое наследует возможности интерфейса [IThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat):
- [BevelBottom](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
и [BevelTop](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): установить фаску на фигуру, определить тип фаски (например, угол, круг, мягкий круг), определить высоту и ширину фаски.
- [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): используется для имитации движения камеры вокруг объекта. Другими словами, установив вращение камеры, масштаб и другие свойства, вы можете поиграть с вашими
фигурами как с 3D моделью в PowerPoint.
- [ContourColor](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
и [ContourWidth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): установить свойства контура, чтобы фигура выглядела как 3D PowerPoint фигура.
- [depth](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/), 
[extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
и [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): используются, чтобы сделать фигуру трехмерной, что означает преобразование 2D фигуры в 3D фигуру,
устанавливая её глубину или экструзируя её.
- [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): может создать световой эффект на 3D фигуре. Логика этого свойства схожа с Camera, вы можете установить вращение света
относительно 3D фигуры и выбрать тип света.
- [material](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/): установка типа материала 3D фигуры может сделать её более живой. Свойство предоставляет набор предопределенных материалов, таких как: 
Металлический, Пластик, Порошок, Матовое и т.д.  

Все 3D функции могут быть применены как к фигурам, так и к тексту. Давайте посмотрим, как получить доступ к упомянутым выше свойствам, а затем рассмотрим их в деталях шаг за шагом:
```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64
    
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.light_rigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT 
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = draw.Color.blue
    
    with pres.slides[0].get_image(2, 2) as image:
        image.save("sample_3d.png")

    pres.save("sandbox_3d.pptx", slides.export.SaveFormat.PPTX)
```

Сгенерированный миниатюра выглядит так:

![todo:image_alt_text](img_01_01.png)

## 3D Поворот
Можно вращать PowerPoint 3D фигуры в 3D плоскости, что придает больше интерактивности. Чтобы повернуть 3D фигуру в PowerPoint, вы обычно используете следующее меню:

![todo:image_alt_text](img_02_01.png)

В API Aspose.Slides вращение 3D фигуры можно управлять с помощью свойства [camera](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/):

```py
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
# ... установить другие параметры 3D сцены
with pres.slides[0].get_image(2, 2) as image:
    image.save("sample_3d.png")
```

## 3D Глубина и Экструзия
Чтобы придать третье измерение вашей фигуре и сделать ее 3D фигурой, используйте [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) 
и [extrusion_color.color](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformat/) свойства:

```py
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = draw.Color.purple
# ... установить другие параметры 3D сцены
with pres.slides[0].get_image(2, 2) as image:
    image.save("sample_3d.png")
```

Обычно вы используете меню Глубина в PowerPoint для установки глубины для PowerPoint 3D фигуры:

![todo:image_alt_text](img_02_02.png)


## 3D Градиент
Градиент может быть использован для заполнения цвета PowerPoint 3D фигуры. Давайте создадим фигуру с цветом градиентной заливки и применим к ней 3D эффект:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Градиент"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, draw.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, draw.Color.orange)
   
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.light_rigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = draw.Color.dark_orange
   
    with pres.slides[0].get_image(2, 2) as image:
        image.save("sample_3d.png")
```

А вот и результат:

![todo:image_alt_text](img_02_03.png)

Кроме градиентного цвета заливки, возможно заполнить фигуры изображением:
```py
shape.fill_format.fill_type = slides.FillType.PICTURE
with open("image.png", "rb") as fs : 
    data = fs.read()

    shape.fill_format.picture_fill_format.picture.image = pres.images.add_image(data)
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    
    # .. настройка 3D: shape.three_d_format.camera, shape.three_d_format.light_rig, shape.three_d_format.Extrusion* свойства
    with pres.slides[0].get_image(2, 2) as image:
        image.save("sample_3d.png")
```


Вот как это выглядит:

![todo:image_alt_text](img_02_04.png)

## 3D Текст (WordArt)
Aspose.Slides также позволяет применять 3D к тексту. Для создания 3D текста можно использовать эффект трансформации WordArt:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D текст"
   
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID
   
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128
   
    textFrame = shape.text_frame
    # установка эффекта трансформации "Арка вверх"
    textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP

    textFrame.text_frame_format.three_d_format.extrusion_height = 3.5
    textFrame.text_frame_format.three_d_format.depth = 3
    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.light_rigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
   
    with pres.slides[0].get_image(2, 2) as image:
        image.save("text3d.png")

    pres.save("text3d.pptx", slides.export.SaveFormat.PPTX)
```

Вот результат:

![todo:image_alt_text](img_02_05.png)


## Не поддерживается - Скоро
Следующие функции PowerPoint 3D пока не поддерживаются: 
- Фаска
- Материал
- Контур
- Освещение

Мы продолжаем улучшать наш 3D движок, и эти функции будут реализованы в будущем.