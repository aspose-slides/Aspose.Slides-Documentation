---
title: Форматирование фигур PowerPoint в Python
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/python-net/shape-formatting/
keywords:
- форматировать фигуру
- форматировать линию
- эффект наброска
- линия фигуры наброска
- форматировать стиль соединения
- градиентная заливка
- узорная заливка
- заливка изображением
- заливка текстурой
- сплошная заливка цветом
- прозрачность фигуры
- черно-белая отрисовка фигуры
- оттенки серого отрисовка фигуры
- вращение фигуры
- 3d скосовый эффект
- 3d вращающий эффект
- сброс форматирования
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Python с помощью Aspose.Slides — задавайте стили заливки, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контурам. Кроме того, фигуры можно форматировать, задавая параметры, контролирующие заполнение их внутренностей.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python предоставляет классы и свойства, позволяющие форматировать фигуры с теми же возможностями, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги выполнения:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите [style линии](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linestyle/) фигуры.
1. Задайте толщину линии.
1. Установите [style штриховки](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linedashstyle/) фигуры.
1. Задайте цвет линии фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код Python демонстрирует, как отформатировать прямоугольный `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

    # Создайте экземпляр класса Presentation, представляющего файл презентации.
    # Получите первый слайд.
    # Добавьте автофигуру типа Rectangle.
    # Уберите заливку у прямоугольной фигуры, чтобы видны были только её линии.
    # Примените форматирование к линиям прямоугольника.
    # Задайте цвет линии прямоугольника.
    # Сохраните файл PPTX на диск.
    with slides.Presentation() as presentation:

        # Get the first slide.
        slide = presentation.slides[0]

        # Add an auto shape of the Rectangle type.
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

        # Remove the fill from the rectangle shape so only its lines are visible.
        shape.fill_format.fill_type = slides.FillType.NO_FILL

        # Apply formatting to the rectangle's lines.
        shape.line_format.style = slides.LineStyle.THICK_THIN
        shape.line_format.width = 7
        shape.line_format.dash_style = slides.LineDashStyle.DASH

        # Set the color for the rectangle's line.
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

        # Save the PPTX file to disk.
        presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядящей нарисованной от руки. Используйте [Shape.line_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/line_format/) для доступа к настройкам линии, [LineFormat.sketch_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/lineformat/sketch_format/) для доступа к настройкам наброска и [SketchFormat.sketch_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/sketchformat/sketch_type/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linesketchtype/).

Следующий код Python показывает, как применить эффект [LineSketchType.CURVED](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linesketchtype/), прочитать явно присвоенное значение и удалить эффект с помощью [LineSketchType.NONE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Получить формат линии фигуры и её формат наброска.
    sketch_format = shape.line_format.sketch_format

    # Применить эффект наброска.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Прочитать эффект наброска, назначенный напрямую фигуре.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Удалить эффект наброска.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Значение, возвращаемое `SketchFormat.sketch_type`, представляет настройку, присвоенную непосредственно фигуре. Если форматирование линии может быть унаследовано из темы, шаблона мастера или шаблона разметки, используйте [LineFormat.get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/lineformat/get_effective/), получите свойство `sketch_format` возвращённого объекта и прочитайте его свойство `sketch_type`. Эффективное значение отражает форматирование, фактически применённое после разрешения наследования:

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

* Круглое
* Срез
* Скошенное

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Круглое**. Однако при работе с фигурой с острыми углами вы можете предпочесть вариант **Срез**.

![Стиль соединения в презентации](join-style-powerpoint.png)

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

	# Задайте ширину линии.
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

	# Задайте стиль соединения.
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

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить плавный переход цветов к фигуре. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Ниже показано, как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры свойство [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в значение `GRADIENT`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `add` коллекции `gradient_stops`, открытой классом [GradientFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код Python демонстрирует, как применить эффект градиентной заливки к эллипсу:

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

    # Добавьте две градиентные остановки.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить двухцветный узор (точки, полосы, крест‑штриховку или шахматы) к фигуре. Можно выбрать собственные цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применить к фигурам для повышения визуальной привлекательности ваших презентаций. Даже после выбора готового узора вы всё равно можете указать точные цвета, которые он будет использовать.

Ниже показано, как применить заполнение узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры свойство [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в значение `PATTERN`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [back_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/patternformat/back_color/) узора.
1. Установите [fore_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/patternformat/fore_color/) узора.
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

    # Установите тип заливки в Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Установите стиль узора.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Задайте фон и передний цвет узора.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прямоугольник с узорной заливкой](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, используя его в качестве фона фигуры.

Ниже показано, как с помощью Aspose.Slides применить заполнение изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры свойство [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в значение `PICTURE`.
1. Установите режим заполнения изображения в `TILE` (или другой предпочтительный режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Присвойте это изображение свойству `picture.image` формата заполнения `picture_fill_format` фигуры.
1. Сохраните изменённую презентацию в файл PPTX.

Предположим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий код Python демонстрирует, как заполнить фигуру изображением:

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

    # Установите режим заливки изображением.
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

![Фигура с заполнением изображением](picture-fill.png)

### **Замостить изображение как текстуру**

Если нужно задать замощённое изображение в качестве текстуры и настроить поведение замощения, можно использовать следующие свойства класса [PictureFillFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/picture_fill_mode/): задаёт режим заполнения изображения — `TILE` или `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_alignment/): определяет выравнивание плиток внутри фигуры.
- [tile_flip](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_flip/): управляет тем, будет ли плитка отражена горизонтально, вертикально или в обеих плоскостях.
- [tile_offset_x](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_offset_x/): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [tile_offset_y](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_offset_y/): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [tile_scale_x](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_scale_x/): определяет горизонтальный масштаб плитки в процентах.
- [tile_scale_y](https://reference.aspose.com/slides/ru/python-net/aspose.slides/picturefillformat/tile_scale_y/): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольную фигуру с замощённой заливкой изображения и настроить параметры замощения:

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

    # Назначьте изображение фигуре.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Настройте режим заливки изображением и свойства замощения.
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

![Параметры замощения](tile-options.png)

## **Сплошная заливка цветом**

В PowerPoint сплошная заливка цветом — это параметр форматирования, который заполняет фигуру одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры свойство [FillType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) в значение `SOLID`.
1. Назначьте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию в файл PPTX.

Следующий код Python демонстрирует, как применить сплошную заливку к прямоугольнику в слайде PowerPoint:

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

![Фигура со сплошной заливкой цветом](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint при применении сплошной, градиентной, картинной или текстурной заливки к фигурам можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» будет фигура, позволяя частично видеть фон или нижележащие объекты.

Aspose.Slides позволяет задать уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите тип заливки в `SOLID`.
1. Используйте `Color.from_argb` для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
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

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Aspose.Slides позволяет вращать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
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

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D‑скошенных эффектов**

Aspose.Slides позволяет применять 3D‑скошенные эффекты к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/).

Чтобы добавить 3D‑скошенные эффекты к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Настройте [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/) фигуры, задав параметры скоса.
1. Сохраните презентацию.

Следующий код Python показывает, как применить 3D‑скошенные эффекты к фигуре:

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

![3D‑скошенный эффект](3D-bevel-effect.png)

## **Добавление 3D‑вращающих эффектов**

Aspose.Slides позволяет применять 3D‑вращающие эффекты к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) на слайд.
1. Установите у фигуры свойства [camera_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/camera/camera_type/) и [light_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/lightrig/light_type/), определяющие 3D‑вращение.
1. Сохраните презентацию.

Следующий код Python демонстрирует, как применить 3D‑вращающие эффекты к фигуре:

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

![3D‑вращающий эффект](3D-rotation-effect.png)

## **Управление черно‑белой отрисовкой фигур**

Свойство [Shape.black_white_mode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/black_white_mode/) указывает, как отдельная фигура будет отрисовываться, когда презентация просматривается или обрабатывается в чёрно‑белом режиме. Оно не включает чёрно‑белый режим автоматически и не меняет заполнение, линии или другое форматирование фигуры в обычном цветном режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/ru/python-net/aspose.slides/blackwhitemode/) для выбора желаемого поведения. Например, `AUTOMATIC` позволяет приложению‑отрисовщику выбрать метод преобразования, `GRAY` и `LIGHT_GRAY` используют оттенки серого, `BLACK_WHITE` применяет только чёрный и белый, `BLACK` и `WHITE` принудительно задают один цвет, `COLOR` сохраняет обычные цвета, а `HIDDEN` исключает фигуру из чёрно‑белого отображения. `NOT_DEFINED` означает, что для фигуры не задан отдельный режим.

Следующий код Python создаёт цветную фигуру и заставляет её отображаться серой в чёрно‑белом режиме:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Сохраните оранжевую заливку в цветном режиме, но отобразите фигуру серым цветом в черно-белом режиме.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

В обычном цветном режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе чёрно‑белого отображения он использует серый цвет, поскольку его режим установлен в `GRAY`. Это позволяет сохранять полноцветный слайд, одновременно определяя отдельный вид для печати, предварительного просмотра или других процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код Python показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/ru/python-net/aspose.slides/layoutslide/) к их значениям по умолчанию:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Влияет ли форматирование фигур на окончательный размер файла презентации?**

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть пространства, а параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и практически не добавляют объёма.

**Как обнаружить фигуры на слайде, у которых одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заполнения, линии и эффекты. Если все соответствующие значения совпадают, считайте их стили идентичными и логически сгруппируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Могу ли я сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с желаемыми стилями в шаблоне презентации или файле шаблона `.POTX`. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.