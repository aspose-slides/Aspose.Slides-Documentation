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
- набросок линии фигуры
- стиль соединения
- градиентное заполнение
- заполнение узором
- заполнение изображением
- заполнение текстурой
- заполнение сплошным цветом
- прозрачность фигуры
- черно‑белое отображение фигуры
- отображение фигуры в градациях серого
- повернуть фигуру
- эффект 3D‑скоса
- эффект 3D‑вращения
- сброс форматирования
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Python с помощью Aspose.Slides — задавайте стили заполнения, линий и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контурам. Кроме того, вы можете форматировать фигуры, задавая параметры, которые контролируют заполнение их внутренних областей.

![форматирование формы PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python предоставляет классы и свойства, позволяющие форматировать фигуры с использованием тех же параметров, что доступны в PowerPoint.

## **Форматирование линий**

Используя Aspose.Slides, вы можете задать пользовательский стиль линии для фигуры. Ниже перечислены шаги процедуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) фигуры.
1. Задайте толщину линии.
1. Установите [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) фигуры.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код Python демонстрирует, как отформатировать прямоугольный `AutoShape`:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автоматическую фигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Удалите заливку у прямоугольной фигуры, чтобы отображались только её линии.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Примените форматирование к линиям прямоугольника.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Задайте цвет линии прямоугольника.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Сохраните файл PPTX на диск.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры похожей на нарисованную от руки. Используйте [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) для доступа к настройкам линии, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) для доступа к настройкам наброска и [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Следующий код Python показывает, как применить эффект [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), прочитать явно установленное значение и удалить эффект с помощью [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Доступ к формату линии фигуры и её формату наброска.
    sketch_format = shape.line_format.sketch_format

    # Применить эффект наброска.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Прочитать эффект наброска, назначенный напрямую фигуре.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Удалить эффект наброска.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Значение, возвращаемое `SketchFormat.sketch_type`, представляет параметр, назначенный непосредственно фигуре. Если форматирование линии может быть унаследовано из темы, мастер‑слайда или макета, используйте [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), получите свойство `sketch_format` возвращённого объекта и прочитайте его свойство `sketch_type`. Эффективное значение отражает фактическое форматирование после разрешения наследования:

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

## **Форматирование стилей соединения**

Here are the three join type options:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Round**. Однако, если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий код Python демонстрирует, как три прямоугольника (как показано на изображении выше) были созданы с использованием настроек типов соединения Miter, Bevel и Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

	# Получите первый слайд.
	slide = presentation.slides[0]

	# Добавьте три автоматических фигуры типа Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Задайте цвет заливки для каждой прямоугольной фигуры.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Задайте толщину линии.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Задайте цвет линии для каждого прямоугольника.
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

## **Градиентное заполнение**

В PowerPoint градиентное заполнение — это параметр форматирования, позволяющий наложить непрерывный переход цветов на фигуру. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Ниже показано, как применить градиентное заполнение к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `GRADIENT`.
1. Добавьте два желаемых цвета с определёнными позициями, используя методы `add` коллекции `gradient_stops`, предоставляемой классом [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию как файл PPTX.

```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автоматическую фигуру типа Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Примените градиентное форматирование к эллипсу.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Задайте направление градиента.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Добавьте два градиентных пункта.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Сохраните файл PPTX на диск.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Эллипс с градиентным заполнением](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Choose a Gradient Rendering Style](/slides/ru/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга, не меняя градиент, сохранённый в презентации.

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить двуцветный дизайн — точки, полосы, штриховку или клетку — к фигуре. Вы можете выбрать пользовательские цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узоров, которые можно применять к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора вы всё равно можете задать точные цвета, которые он будет использовать.

Ниже показано, как применить заполнение узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `PATTERN`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) узора.
1. Установите [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) узора.
1. Сохраните изменённую презентацию как файл PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автоматическую фигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Установите тип заливки в Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Установите стиль узора.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Установите фоновые и передние цвета узора.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Сохраните файл PPTX на диск.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прямоугольник с узорным заполнением](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутрь фигуры, effectively using the image as the shape's background.

Ниже показано, как использовать Aspose.Slides для заполнения фигуры изображением:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `PICTURE`.
1. Установите режим заполнения изображения в `TILE` (или другой желаемый режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Назначьте это изображение свойству `picture.image` формата `picture_fill_format` фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Предположим, у нас есть файл "lotus.png" со следующим изображением:

![Изображение лотоса](lotus.png)

```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автоматическую фигуру типа Rectangle.
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

![Фигура с заполнением изображением](picture-fill.png)

### **Тайловое изображение как текстура**

Если вы хотите установить тайловое изображение в качестве текстуры и настроить поведение тайлинга, вы можете использовать следующие свойства класса [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): задаёт режим заполнения изображения — `TILE` или `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): определяет выравнивание тайлов внутри фигуры.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): управляет тем, будет ли тайл отражён по горизонтали, вертикали или обеим осям.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): задаёт горизонтальное смещение тайла (в пунктах) от начала фигуры.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): задаёт вертикальное смещение тайла (в пунктах) от начала фигуры.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): определяет горизонтальный масштаб тайла в процентах.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): определяет вертикальный масштаб тайла в процентах.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    first_slide = presentation.slides[0]

    # Добавьте автоматическую прямоугольную фигуру.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Установите тип заливки фигуры в Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Загрузите изображение и добавьте его в ресурсы презентации.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Присвойте изображение фигуре.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Настройте режим заполнения изображением и свойства тайлинга.
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

![Настройки тайла](tile-options.png)

## **Сплошное цветное заполнение**

В PowerPoint сплошное цветное заполнение — это параметр форматирования, который заполняет фигуру одним однородным цветом. Этот простой фоновый цвет применяется без градиентов, текстур или узоров.

Чтобы применить сплошное цветное заполнение к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) фигуры в `SOLID`.
1. Назначьте желаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию как файл PPTX.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автоматическую фигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Установите тип заливки в Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Установите цвет заливки.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Сохраните файл PPTX на диск.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Фигура со сплошным цветным заполнением](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошное, градиентное, изображение или текстурное заполнение к фигурам, вы также можете задать уровень прозрачности, чтобы контролировать непрозрачность заливки. Более высокое значение прозрачности делает фигуру более прозрачной, позволяя частично видеть фон или подложенные объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент цвета, используемого для заливки. Как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите тип заливки в `SOLID`.
1. Используйте `Color.from_argb`, чтобы определить цвет с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]
    
    # Добавьте сплошную прямоугольную автоматическую фигуру.
    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Добавьте прозрачную прямоугольную автоматическую фигуру поверх сплошной.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
    
    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет поворачивать фигуры в презентациях PowerPoint. Это может быть полезно при позиционировании визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойство `rotation` фигуры в требуемый угол.
1. Сохраните презентацию.

```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation() as presentation:

    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте автоматическую фигуру типа Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Поверните фигуру на 5 градусов.
    shape.rotation = 5

    # Сохраните файл PPTX на диск.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D скосов**

Aspose.Slides позволяет применять 3D‑скосы к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Чтобы добавить 3D‑скосы к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Настройте свойство [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) фигуры, определив параметры скосов.
1. Сохраните презентацию.

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

    # Сохраните презентацию как файл PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Эффект 3D скоса](3D-bevel-effect.png)

## **Добавление 3D вращения**

Aspose.Slides позволяет применять 3D‑вращения к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Чтобы применить 3D‑вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд.
1. Установите свойства [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) и [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) фигуры, определив 3D‑вращение.
1. Сохраните презентацию.

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

    # Сохраните презентацию как файл PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Эффект 3D вращения](3D-rotation-effect.png)

## **Управление чёрно‑белым отображением фигур**

Свойство [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) определяет, как отдельная фигура будет отображаться, когда презентация просматривается или обрабатывается в чёрно‑белом режиме. Оно не включает чёрно‑белый режим само по себе и не меняет заливку, линии или другое форматирование фигуры в обычном цветовом режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) для выбора желаемого поведения. Например, `AUTOMATIC` позволяет приложению выбора преобразования, `GRAY` и `LIGHT_GRAY` используют серую градацию, `BLACK_WHITE` — только чёрный и белый, `BLACK` и `WHITE` — принудительно один цвет, `COLOR` — сохраняет обычные цвета, `HIDDEN` — скрывает фигуру в чёрно‑белом режиме. `NOT_DEFINED` означает, что режим для фигуры не задан.

Следующий код создаёт цветную фигуру и заставляет её отображаться серой в чёрно‑белом режиме:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Сохраняйте оранжевую заливку в цветном режиме, но отображайте фигуру в оттенках серого в чёрно‑белом режиме.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе чёрно‑белого отображения он используется серым, потому что его режим установлен в `GRAY`. Это позволяет сохранять полноцветный слайд, определяя отдельный вид для печати, предпросмотра или других процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Следующий код показывает, как сбросить форматирование слайда и вернуть позицию, размер и форматирование всех фигур‑заполнителей на [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) к их значениям по умолчанию:

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

Только незначительно. Встроенные изображения и медиа‑файлы занимают большую часть пространства файла, тогда как параметры фигур — цвета, эффекты и градиенты — хранятся как метаданные и практически не увеличивают размер.

**Как обнаружить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — параметры заливки, линии и эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как одинаковые и логически группируйте такие фигуры, что упрощает дальнейшее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонной презентации или файле шаблона `.POTX`. При создании новой презентации откройте шаблон, клонируйте требуемые стилизованные фигуры и применяйте их форматирование там, где это необходимо.