---
title: Форматирование фигур PowerPoint в Python
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/python-net/shape-formatting/
keywords:
- формат фигуры
- формат линии
- эффект эскиза
- эскиз линии фигуры
- формат стиля соединения
- градиентная заливка
- заливка узором
- заливка изображением
- заливка текстурой
- заливка сплошным цветом
- прозрачность фигуры
- повернуть фигуру
- 3D эффект фаски
- 3D эффект вращения
- сбросить форматирование
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Python с помощью Aspose.Slides — задавать стили заполнения, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя контур или применяя к нему эффекты. Кроме того, можно задавать параметры заполнения, которые определяют, как будет заполнено внутреннее пространство фигур.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python предоставляет классы и свойства, позволяющие форматировать фигуры с теми же возможностями, что и в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linestyle/) фигуры.
1. Задайте толщину линии.
1. Установите [dash style](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linedashstyle/) фигуры.
1. Задайте цвет линии для фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Ниже приведён пример кода на Python, показывающий, как отформатировать прямоугольный `AutoShape`:

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

## **Применение эффектов эскиза к линиям фигур**

Эффект эскиза делает линию фигуры выглядящей нарисованной от руки. Используйте [Shape.line_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/line_format/) для доступа к настройкам линий, [LineFormat.sketch_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/lineformat/sketch_format/) для доступа к настройкам эскиза и [SketchFormat.sketch_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sketchformat/sketch_type/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linesketchtype/).

Ниже показан код на Python, который применяет эффект [LineSketchType.CURVED](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linesketchtype/), выводит явно присвоенное значение и удаляет эффект с помощью [LineSketchType.NONE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Получить формат линии фигуры и её формат эскиза.
    sketch_format = shape.line_format.sketch_format

    # Применить эффект эскиза.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Прочитать эффект эскиза, назначенный непосредственно фигуре.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Удалить эффект эскиза.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Значение, возвращаемое `SketchFormat.sketch_type`, представляет настройку, непосредственно присвоенную фигуре. Если форматирование линии может наследоваться от темы, шаблона или макета слайда, используйте [LineFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/lineformat/get_effective/), получите свойство `sketch_format` у возвращённого объекта и прочитайте его `sketch_type`. Эффективное значение отражает фактически применённое форматирование после разрешения наследования:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию PowerPoint при соединении двух линий под углом (например, в углу фигуры) использует настройку **Round**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Ниже показан код на Python, демонстрирующий, как три прямоугольника (как на изображении выше) были созданы с настройками соединения Miter, Bevel и Round:

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

	# Установите толщину линии.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Установите цвет линии каждой прямоугольной фигуры.
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

В PowerPoint градиентное заполнение — это параметр форматирования, позволяющий применить к фигуре плавный переход нескольких цветов. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Как применить градиентное заполнение к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в `GRADIENT`.
1. Добавьте два предпочтительных цвета с заданными позициями, используя методы `add` коллекции `gradient_stops`, доступной через класс [GradientFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Ниже пример кода на Python, показывающий, как применить градиент к эллипсу:

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

    # Добавьте два градиентных узла.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![The ellipse with gradient fill](gradient-fill.png)

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить к фигуре двухцветный узор (точки, полосы, перекрёстные линии или шахматный узор). Вы можете задать собственные цвета переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального оформления презентаций. Даже после выбора предопределённого узора вы можете указать точные цвета, которые он будет использовать.

Как применить узор к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в `PATTERN`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [back_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/patternformat/back_color/) узора.
1. Установите [fore_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/patternformat/fore_color/) узора.
1. Сохраните изменённую презентацию в файл PPTX.

Ниже пример кода на Python, показывающий, как применить узор к прямоугольнику:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Установите тип заливки в Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Установите стиль узора.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Установите фон и передний цвет узора.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![The rectangle with pattern fill](pattern-fill.png)

## **Заполнение картинкой**

В PowerPoint заполнение картинкой — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, effectively using the image as the shape's background.

Как использовать Aspose.Slides для применения заполнения картинкой к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в `PICTURE`.
1. Установите режим заполнения картинкой в `TILE` (или другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Присвойте это изображение свойству `picture.image` объекта `picture_fill_format` фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![The lotus picture](lotus.png)

Ниже пример кода на Python, показывающий, как заполнить фигуру картинкой:

```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Установите тип заливки в Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Установите режим заполнения изображением.
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

### **Картинка‑мозаика в качестве текстуры**

Если нужно установить мозаичную картинку в качестве текстуры и настроить её размещение, используйте следующие свойства класса [PictureFillFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/picture_fill_mode/): задаёт режим заполнения картинкой — `TILE` или `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_alignment/): определяет выравнивание плиток внутри фигуры.
- [tile_flip](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_flip/): управляет горизонтальным, вертикальным или двойным отражением плитки.
- [tile_offset_x](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_offset_x/): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [tile_offset_y](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_offset_y/): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [tile_scale_x](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_scale_x/): определяет горизонтальный масштаб плитки в процентах.
- [tile_scale_y](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_scale_y/): определяет вертикальный масштаб плитки в процентах.

Ниже пример кода, показывающий, как добавить прямоугольную фигуру с мозаичным заполнением и настроить параметры плитки:

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    first_slide = presentation.slides[0]

    # Добавьте автофигуру прямоугольника.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Установите тип заливки фигуры в Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Загрузите изображение и добавьте его в ресурсы презентации.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Присвойте изображение фигуре.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Настройте режим заполнения изображением и свойства мозаики.
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

## **Сплошное заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, который заполняет фигуру одним, равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку цветом к фигуре с помощью Aspose.Slides, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в `SOLID`.
1. Укажите желаемый цвет заливки.
1. Сохраните изменённую презентацию в файл PPTX.

Ниже пример кода на Python, показывающий, как применить сплошную заливку цветом к прямоугольнику в слайде PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автофигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Установите тип заливки в Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Установите цвет заливки.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Сохраните файл PPTX на диск.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![The shape with solid color fill](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошную заливку, градиент, картинку или текстуру к фигурам, вы также можете задать уровень прозрачности, контролирующий непрозрачность заполнения. Чем выше значение прозрачности, тем более «прозрачной» будет фигура, позволяя видеть фон или объекты, расположенные под ней.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент в цвете, используемом для заполнения. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите тип заполнения в `SOLID`.
1. Используйте `Color.from_argb`, чтобы задать цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

Ниже пример кода на Python, показывающий, как применить прозрачный цвет заливки к прямоугольнику:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]
    
    # Добавьте сплошную прямоугольную автофигуру.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Добавьте прозрачную прямоугольную автофигуру над сплошной фигурой.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![The transparent shape](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при позиционировании визуальных элементов с определёнными требованиями к выравниванию или дизайну.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство `rotation` фигуры в нужный угол.
1. Сохраните презентацию.

Ниже пример кода на Python, показывающий, как повернуть фигуру на 5 градусов:

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

Aspose.Slides позволяет применять к фигурам 3D‑эффекты фаски, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/).

Чтобы добавить 3D‑фаску к фигуре, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/) фигуры, определив параметры фаски.
1. Сохраните презентацию.

Ниже пример кода на Python, показывающий, как применить 3D‑эффекты фаски к фигуре:

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

## **Добавление 3D‑поворачиваемых эффектов**

Aspose.Slides позволяет применять к фигурам 3D‑поворачиваемые эффекты, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/).

Чтобы применить 3D‑поворот к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры [camera_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/camera/camera_type/) и [light_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/lightrig/light_type/), чтобы задать 3D‑поворот.
1. Сохраните презентацию.

Ниже пример кода на Python, показывающий, как применить 3D‑поворачиваемый эффект к фигуре:

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

Ниже пример кода на Python, показывающий, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/) к их значениям по умолчанию:

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

Только незначительно. Основную часть места занимают встроенные изображения и медиафайлы, тогда как параметры фигур (цвета, эффекты, градиенты) хранятся как метаданные и почти не увеличивают размер файла.

**Как определить фигуры на слайде с одинаковым форматированием, чтобы их сгруппировать?**

Сравните ключевые параметры форматирования каждой фигуры — настройки заполнения, линии и эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонной презентации или файле‑шаблоне `.POTX`. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно применяйте их форматирование там, где это требуется.