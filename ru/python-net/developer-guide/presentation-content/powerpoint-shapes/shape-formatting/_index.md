---
title: Форматирование фигур
type: docs
weight: 20
url: /ru/python-net/shape-formatting/
keywords: "Форматировать фигуры, форматировать линии, стиль соединения, градиентная заливка, заполнение узором, заливка изображением, заливка сплошным цветом, поворот фигур, эффекты 3D-скоса, эффект 3D-вращения, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Форматирование фигур в презентации PowerPoint на Python"
---

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, вы можете форматировать фигуры, изменяя или применяя определенные эффекты к их составным линиям. Кроме того, вы можете форматировать фигуры, указывая настройки, которые определяют, как они (их область) заполняются.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides для Python через .NET** предоставляет интерфейсы и свойства, которые позволяют вам форматировать фигуры на основе известных параметров в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете указать предпочитаемый стиль линии для фигуры. Эти шаги описывают такую процедуру:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Установите цвет для линий фигуры.
5. Установите ширину линий фигуры.
6. Установите [стиль линии](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) для линии фигуры.
7. Установите [стиль штриха](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) для линии фигуры.
8. Запишите измененную презентацию в файл PPTX.

Этот код на Python демонстрирует операцию, в которой мы отформатировали прямоугольник `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation, представляющий файл PPTX
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Добавляет прямоугольник AutoShape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Устанавливает цвет заливки для прямоугольника
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.white

    # Применяет некоторое форматирование к линиям прямоугольника
    shp.line_format.style = slides.LineStyle.THICK_THIN
    shp.line_format.width = 7
    shp.line_format.dash_style = slides.LineDashStyle.DASH

    # Устанавливает цвет для линии прямоугольника
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Записывает файл PPTX на диск
    pres.save("RectShpLn_out-1.pptx", slides.export.SaveFormat.PPTX)
```

## **Стиль соединения**

Вот три типа стиля соединения:

* Закругленный
* Прямоугольный
* Скошенный

По умолчанию, когда PowerPoint соединяет две линии под углом (или угол фигуры), он использует настройку **Закругленный**. Однако, если вы хотите нарисовать фигуру с очень острыми углами, вы можете выбрать **Прямоугольный**.

![join-style-powerpoint](join-style-powerpoint.png)

Этот код на Python демонстрирует операцию, в которой были созданы 3 прямоугольника (изображение выше) с настройками стиля соединения Прямоугольный, Скошенный и Закругленный:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation, представляющий файл PPTX
with slides.Presentation() as pres:
	# Получает первый слайд
	sld = pres.slides[0]

	# Добавляет 3 прямоугольника AutoShape
	shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 150, 75)
	shp2 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 150, 75)
	shp3 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 250, 150, 75)

	# Устанавливает цвет заливки для фигуры
	shp1.fill_format.fill_type = slides.FillType.SOLID
	shp1.fill_format.solid_fill_color.color = draw.Color.black
	shp2.fill_format.fill_type = slides.FillType.SOLID
	shp2.fill_format.solid_fill_color.color = draw.Color.black
	shp3.fill_format.fill_type = slides.FillType.SOLID
	shp3.fill_format.solid_fill_color.color = draw.Color.black

	# Устанавливает ширину линий
	shp1.line_format.width = 15
	shp2.line_format.width = 15
	shp3.line_format.width = 15

	# Устанавливает цвет для линии прямоугольника
	shp1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shp3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shp3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Устанавливает стиль соединения
	shp1.line_format.join_style = slides.LineJoinStyle.MITER
	shp2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shp3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Добавляет текст к каждому прямоугольнику
	shp1.text_frame.text = "Это стиль соединения Прямоугольный"
	shp2.text_frame.text = "Это стиль соединения Скошенный"
	shp3.text_frame.text = "Это стиль соединения Закругленный"

	# Записывает файл PPTX на диск
	pres.save("RectShpLnJoin_out-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Градиентная заливка**
В PowerPoint Градиентная заливка - это вариант форматирования, который позволяет применить непрерывный переход цветов к фигуре. Например, вы можете применить два или более цвета в настройке, где один цвет постепенно переходит в другой.

Вот как вы используете Aspose.Slides для применения градиентной заливки к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры на `Gradient`.
5. Добавьте 2 предпочитаемых цвета с определенными позициями, используя методы `Add`, которые предоставляются коллекцией `GradientStops`, связанной с классом `GradientFormat`.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Python демонстрирует операцию, где эффект градиентной заливки был использован на эллипсе:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation, представляющий файл презентации
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Добавляет эллипс AutoShape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 75, 150)

    # Применяет градиентное форматирование к эллипсу
    shp.fill_format.fill_type = slides.FillType.GRADIENT
    shp.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Устанавливает направление градиента
    shp.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Добавляет 2 градиентных остановки
    shp.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shp.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Записывает файл PPTX на диск
    pres.save("EllipseShpGrad_out-3.pptx", slides.export.SaveFormat.PPTX)
```


## **Заполнение узором**
В PowerPoint Заполнение узором - это вариант форматирования, который позволяет применить двухцветный узор, состоящий из точек, полос, пересечений или клеток к фигуре. Кроме того, вы можете выбрать свои предпочитаемые цвета для переднего и заднего плана вашего узора.

Aspose.Slides предоставляет более 45 предопределенных стилей, которые могут использоваться для форматирования фигур и обогащения презентаций. Даже после выбора предопределенного узора, вы все равно можете указать цвета, которые должны содержать узор.

Вот как вы используете Aspose.Slides для применения заполнения узором к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры на `Pattern`.
5. Установите предпочитаемый стиль узора для фигуры.
6. Установите цвет фона для [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
7. Установите цвет переднего плана для [PatternFormat](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/).
8. Запишите измененную презентацию в файл PPTX.

Этот код на Python демонстрирует операцию, в которой заполнили узор фигуру для украшения прямоугольника: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation, представляющий файл презентации
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Добавляет прямоугольник AutoShape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Устанавливает тип заливки на узор
    shp.fill_format.fill_type = slides.FillType.PATTERN

    # Устанавливает стиль узора
    shp.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Устанавливает цвета фона и переднего плана узора
    shp.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shp.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Записывает файл PPTX на диск
    pres.save("RectShpPatt_out-4.pptx", slides.export.SaveFormat.PPTX)
```


## **Заполнение изображением**
В PowerPoint Заполнение изображением - это вариант форматирования, который позволяет поместить изображение внутрь фигуры. По сути, вы можете использовать изображение в качестве фона фигуры.

Вот как вы используете Aspose.Slides для заполнения фигуры изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры на `Picture`.
5. Установите режим заполнения изображения на тайлинг (Tile).
6. Создайте объект `IPPImage`, используя изображение, которое будет использовано для заполнения фигуры.
7. Установите свойство `Picture.Image` объекта `PictureFillFormat` на недавно созданный `IPPImage`.
8. Запишите измененную презентацию в файл PPTX.

Этот код на Python показывает, как заполнить фигуру изображением:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation, представляющий файл PPTX
with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Добавляет прямоугольник AutoShape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Устанавливает тип заливки на изображение
    shp.fill_format.fill_type = slides.FillType.PICTURE

    # Устанавливает режим заливки изображения
    shp.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Устанавливает изображение
    img = draw.Bitmap(path + "Tulips.jpg")
    imgx = pres.images.add_image(img)
    shp.fill_format.picture_fill_format.picture.image = imgx

    # Записывает файл PPTX на диск
    pres.save("RectShpPic_out-5.pptx", slides.export.SaveFormat.PPTX)
```


## **Заливка сплошным цветом**
В PowerPoint Заливка сплошным цветом - это вариант форматирования, который позволяет заполнить фигуру одним цветом. Выбранный цвет обычно является однородным. Цвет применяется к фону фигуры без каких-либо специальных эффектов или модификаций.

Вот как вы используете Aspose.Slides для применения заливки сплошным цветом к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Установите [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры на `Solid`.
5. Установите свой предпочитаемый цвет для фигуры.
6. Запишите измененную презентацию в файл PPTX.

Этот код на Python показывает, как применить заливку сплошным цветом к фигуре в PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Получает первый слайд
    slide = presentation.slides[0]

    # Добавляет прямоугольник AutoShape
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Устанавливает тип заливки на сплошной
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Устанавливает цвет для прямоугольника
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Записывает файл PPTX на диск
    presentation.save("RectShpSolid_out-6.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка прозрачности**

В PowerPoint, когда вы заполняете фигуры сплошными цветами, градиентами, изображениями или текстурами, вы можете указать уровень прозрачности, который определяет степень непрозрачности заливки. Таким образом, например, если вы установите низкий уровень прозрачности, объект или фон слайда за фигурой будет просвечивать.

Aspose.Slides позволяет вам установить уровень прозрачности для фигуры следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Используйте `Color.FromArgb` с установленным альфа-компонентом.
5. Сохраните объект как файл PowerPoint.

Этот код на python демонстрирует процесс:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    # Добавляет сплошную фигуру
    solidShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 75, 175, 75, 150)

    # Добавляет прозрачную фигуру поверх сплошной
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("ShapeTransparentOverSolid_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Поворот фигур**
Aspose.Slides позволяет вам наклонить фигуру, добавленную на слайд, следующим образом: 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Поверните фигуру на нужное количество градусов. 
5. Запишите измененную презентацию в файл PPTX.

Этот код на Python показывает, как повернуть фигуру на 90 градусов:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Получает первый слайд
    sld = pres.slides[0]

    # Добавляет прямоугольник AutoShape
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 75, 150)

    # Поворачивает фигуру на 90 градусов
    shp.rotation = 90

    # Записывает файл PPTX на диск
    pres.save("RectShpRot_out-7.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавление 3D-эффектов скоса**
Aspose.Slides для Python через .NET позволяет вам добавлять 3D-эффекты скоса к фигуре, изменяя ее свойства [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) таким образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Установите предпочитаемые параметры для свойств [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) фигуры. 
5. Запишите презентацию на диск.

Этот код на Python показывает, как добавить 3D-эффекты скоса к фигуре:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation
with slides.Presentation() as pres:
    slide = pres.slides[0]

    # Добавляет фигуру на слайд
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 30, 30, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    format = shape.line_format.fill_format
    format.fill_type = slides.FillType.SOLID
    format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Устанавливает свойства ThreeDFormat фигуры
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Записывает презентацию как файл PPTX
    pres.save("Bavel_out-8.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавление 3D-эффекта вращения**
Aspose.Slides позволяет вам применять 3D-эффекты вращения к фигуре, изменяя ее свойства [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) на слайд.
4. Укажите предпочитаемые параметры для CameraType и LightType.
5. Запишите презентацию на диск. 

Этот код на Python показывает, как применить 3D-эффекты вращения к фигуре:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаёт экземпляр класса Presentation
with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 200, 200)

    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(40, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.LINE, 30, 300, 200, 200)
    autoShape.three_d_format.depth = 6
    autoShape.three_d_format.camera.set_rotation(0, 35, 20)
    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

            
    pres.save("Rotation_out-9.pptx", slides.export.SaveFormat.PPTX)
```

## **Сброс форматирования**

Этот код на Python показывает, как сбросить форматирование на слайде и вернуть положение, размер и форматирование каждой фигуры, которая имеет заполнение на [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) к их значениям по умолчанию:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    for slide in pres.slides:
        # Каждая фигура на слайде, которая имеет заполнение на макете, будет возвращена к исходным значениям
        slide.reset()
```