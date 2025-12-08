---
title: Форматирование фигур PowerPoint в Python
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/python-net/shape-formatting/
keywords:
- форматирование фигуры
- форматирование линии
- форматирование стиля соединения
- градиентное заполнение
- заполнение узором
- заполнение изображением
- заполнение текстурой
- заполнение сплошным цветом
- прозрачность фигуры
- поворачивать фигуру
- 3D-эффект фаски
- 3D-вращение
- сброс форматирования
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Python с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---

## **Обзор**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, фигуры можно форматировать, задавая параметры, контролирующие заполнение их внутренней области.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python предоставляет классы и свойства, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides можно указать пользовательский стиль линии для фигуры. Ниже описана последовательность действий:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) фигуры.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код Python демонстрирует, как отформатировать прямоугольник `AutoShape`:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Установите цвет заливки для прямоугольной фигуры.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Примените форматирование к линиям прямоугольника.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Установите цвет линии прямоугольника.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Сохраните файл PPTX на диск.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The formatted lines in the presentation](formatted-lines.png)

## **Форматирование стилей соединений**

Существует три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется параметр **Round**. Однако при работе с фигурой с острыми углами вы можете предпочесть вариант **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Следующий код Python демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек соединения Miter, Bevel и Round:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

	# Получите первый слайд.
	slide = presentation.slides[0]

	# Добавьте три автофигуры типа Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Установите цвет заливки для каждой прямоугольной фигуры.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Установите ширину линии.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Установите цвет линии для каждого прямоугольника.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Установите стиль соединения.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Добавьте текст к каждому прямоугольнику.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Сохраните файл PPTX на диск.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```


## **Градиентное заполнение**

В PowerPoint градиентное заполнение — это параметр форматирования, позволяющий применять плавный переход цветов к фигуре. Например, можно задать два и более цветов, при этом один цвет постепенно переходит в другой.

Как применить градиентное заполнение к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `GRADIENT`.
1. Добавьте два выбранных вами цвета с заданными позициями, используя методы `add` коллекции `gradient_stops`, доступной через класс [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код Python демонстрирует, как применить эффект градиентного заполнения к эллипсу:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Примените градиентное форматирование к эллипсу.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Установите направление градиента.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Добавьте два градиентных стопа.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The ellipse with gradient fill](gradient-fill.png)

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить двухцветный узор (точки, полосы, перекрёстные штрихи или шахматы) к фигуре. Вы можете выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального оформления презентаций. После выбора предопределённого узора вы всё равно можете задать точные цвета, которые он будет использовать.

Как применить заполнение узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `PATTERN`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) узора.
1. Установите [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) узора.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код Python демонстрирует, как применить заполнение узором к прямоугольнику:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Установите тип заполнения в Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Установите стиль узора.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Установите цвета фона и переднего плана узора.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The rectangle with pattern fill](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, фактически используя изображение в качестве фона фигуры.

Как использовать Aspose.Slides для заполнения фигуры изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `PICTURE`.
1. Установите режим заполнения изображения в `TILE` (или иной предпочитаемый режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Присвойте это изображение свойству `picture.image` формата `picture_fill_format` фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Допустим, у нас есть файл "lotus.png" со следующим изображением:

![The lotus picture](lotus.png)

Следующий код Python демонстрирует, как заполнить фигуру изображением:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Установите тип заполнения в Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Установите режим заполнения изображения.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Загрузите изображение и добавьте его в ресурсы презентации.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Установите изображение.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Сохраните файл PPTX на диск.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The shape with picture fill](picture-fill.png)

### **Текстурирование плиткой изображения**

Если вы хотите задать изображение в виде плитки в качестве текстуры и настроить поведение укладки, можно использовать следующие свойства класса [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): задаёт режим заполнения изображения — `TILE` или `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): определяет выравнивание плиток внутри фигуры.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): определяет горизонтальный масштаб плитки в процентах.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольник с заполнением изображением‑плиткой и настроить параметры укладки:
```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    first_slide = presentation.slides[0]

    # Добавьте автофигуру прямоугольника.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Установите тип заполнения фигуры в Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Загрузите изображение и добавьте его в ресурсы презентации.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Присвойте изображение фигуре.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Настройте режим заполнения изображением и свойства укладки плитки.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Сохраните файл PPTX на диск.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The tile options](tile-options.png)

## **Заполнение сплошным цветом**

В PowerPoint заполнение сплошным цветом — это параметр форматирования, который заполняет фигуру одним однородным цветом. Этот простой фоновый цвет применяется без градиентов, текстур или узоров.

Чтобы применить заполнение сплошным цветом к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `SOLID`.
1. Задайте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код Python демонстрирует, как применить сплошное заполнение к прямоугольнику в слайде PowerPoint:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Установите тип заполнения в Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Установите цвет заливки.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Сохраните файл PPTX на диск.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The shape with solid color fill](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошное, градиентное, изображение или текстурное заполнение к фигурам, можно также задать уровень прозрачности, чтобы контролировать непрозрачность заливки. Более высокое значение прозрачности делает фигуру более просвечивающей, позволяя частично видеть фон или объекты позади неё.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите тип заливки в `SOLID`.
1. Используйте `Color.from_argb`, чтобы определить цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Следующий код Python демонстрирует, как применить прозрачный цвет заливки к прямоугольнику:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]
    
    # Добавьте сплошную прямоугольную автофигуру.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Добавьте прозрачную прямоугольную автофигуру поверх сплошной фигуры.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The transparent shape](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы вращать фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство `rotation` фигуры в требуемый угол.
1. Сохраните презентацию.

Следующий код Python демонстрирует, как повернуть фигуру на 5 градусов:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Поверните фигуру на 5 градусов.
    shape.rotation = 5

    # Сохраните файл PPTX на диск.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The shape rotation](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Aspose.Slides позволяет применять 3D‑эффекты фаски к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Чтобы добавить 3D‑фаску к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Настройте свойства [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) фигуры, задав параметры фаски.
1. Сохраните презентацию.

Следующий код Python показывает, как применить 3D‑фаску к фигуре:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Добавьте фигуру на слайд.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Установите свойства ThreeDFormat фигуры.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Сохраните презентацию в файл PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The 3D bevel effect](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

Aspose.Slides позволяет применять 3D‑вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойства [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) и [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) фигуры, определив параметры 3D‑вращения.
1. Сохраните презентацию.

Следующий код Python демонстрирует, как применить 3D‑вращение к фигуре:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Сохраните презентацию в файл PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![The 3D rotation effect](3D-rotation-effect.png)

## **Сброс форматирования**

Следующий код Python показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) к их значениям по умолчанию:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть объёма, тогда как параметры фигур—цвета, эффекты, градиенты—хранятся как метаданные и практически не увеличивают размер файла.

**Как определить фигуры на слайде, у которых одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры—параметры заливки, контура и эффектов. Если все соответствующие значения совпадают, считается, что их стили идентичны, и такие фигуры можно логически группировать, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблон презентации или файл шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте нужные стилизованные фигуры и повторно применяйте их форматирование там, где это необходимо.