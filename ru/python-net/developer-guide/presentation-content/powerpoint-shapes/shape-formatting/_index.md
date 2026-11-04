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
- форматировать стиль соединения
- градиентная заливка
- шаблонная заливка
- заливка изображением
- заливка текстурой
- сплошная заливка
- прозрачность фигуры
- чёрно‑белое отображение фигуры
- отображение фигуры в градациях серого
- повернуть фигуру
- 3D‑эффект фаски
- 3D‑эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint на Python с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

Форматируйте фигуры в PowerPoint, регулируя их контуры, заливки и эффекты. Aspose.Slides for Python via .NET позволяет управлять этими настройками программно, включая прозрачность, вращение и 3D‑форматирование.

![Варианты форматирования фигур в PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Python via .NET предоставляет классы и свойства, позволяющие форматировать фигуры с теми же параметрами, что доступны в PowerPoint.

## **Форматирование линий**

Используйте [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) для управления контуром фигуры. В этом примере создаётся незаполненный прямоугольник с синей штриховой линией. [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) выбирает составную линию «толстая‑тонкая», а [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) задаёт её ширину 7 пунктов, и [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) выбирает тип штриха.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

### **Установка пользовательских шаблонов штрихов линии**

Используйте [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/), когда предопределённые стили линии не предоставляют нужных длин штрихов и промежутков, например для фирменных контуров или технических схем. Присвоение шаблона автоматически задаёт [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) значение [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).

Элементы списка чередуются между длинами штрихов и промежутков, начиная со штриха. Каждое значение является кратным ширине линии: `[4, 2]` при ширине 3 пункта даёт штрих длиной 12 пунктов и промежуток 6 пунктов. Используйте пары конечных неотрицательных значений для определения полных сегментов штрих‑промежуток. В примере используются положительные значения, чтобы каждый штрих и промежуток были видимы.

В этом примере создаются пять синих линий одинаковой длины с плоскими концами. Первые три сравнивают шаблоны при ширине 3 пункта. Четвёртая повторяет первый шаблон при двойной ширине, удваивая и длину штриха, и промежутка. Пятая переключается с пользовательского шаблона на сплошную линию.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Вернуть последнюю линию к сплошному стилю.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы вернуться к предопределённому штриховому стилю, присвойте [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) свойству [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/). Выбранный стиль управляет внешним видом линии.

Результат в PowerPoint сверху вниз: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; и **Solid, 3 pt**.

![Три пользовательских шаблона штрихов, более широкая линия с первым шаблоном и сплошная линия в PowerPoint](custom-dash-patterns.png)

### **Установка концов линии**

Используйте [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/) для задания окончаний открытой линии. Перечисление [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) предоставляет три явных стиля концов:

- `FLAT`: штрих заканчивается в конечной точке.
- `ROUND`: полукруглый конец выступает за конечную точку на половину ширины линии.
- `SQUARE`: квадратный конец выступает за конечную точку на половину ширины линии.

Перечисление также включает `NOT_DEFINED`, что означает отсутствие явно заданного стиля конца.

Концы отличаются от стрелок, которые добавляют символы к концам линии, и от соединений, которые управляют углами между сегментами линии. В этом примере стрелки отключаются через [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) и [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/), чтобы сравнивались только формы концов.

Следующий пример создаёт три визуально одинаковые горизонтальные линии шириной 20 пунктов. Сверху вниз они используют плоские, круглые и квадратные концы. Их конечные точки имеют одинаковые горизонтальные координаты; круглые и квадратные концы выступают на 10 пунктов за каждую конечную точку.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Результат в PowerPoint сверху вниз: **Flat**, **Round**, и **Square**.

![Плоские, круглые и квадратные концы на одинаковых толстых линиях в PowerPoint](line-caps.png)

## **Применение эффектов «набросок» к линиям фигур**

Эффект «набросок» делает линию фигуры выглядящей как нарисованную от руки. Используйте [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) для доступа к настройкам линии, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) для доступа к параметрам наброска и [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Следующий код Python демонстрирует, как применить эффект [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Значение, возвращаемое [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/), представляет настройку, непосредственно назначенную фигуре. Если форматирование линии может наследоваться из темы, шаблона слайда или макета слайда, используйте [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), доступ к [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/) и чтение [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/). Эффективное значение отражает форматирование, действительно применённое после разрешения наследования. Этот пример требует существующей презентации с как минимум одной фигурой на первом слайде и выводит оба значения:

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

Стиль соединения определяет, как два сегмента контура встречаются в углу. Используйте **Round** для скруглённых углов, **Miter** для острых углов или **Bevel** для сближённых углов.

![Стиль соединения в презентации](join-style-powerpoint.png)

В этом примере создаются три чёрных прямоугольника с синими контурами шириной 15 пунктов. Свойству [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) последовательно присваиваются значения miter, bevel и round из перечисления [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), чтобы сравнить, как рисуются углы.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Ограничение соединений‑митеров на острых углах**

Используйте [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/) совместно со [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/) = [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/), чтобы ограничить, насколько далеко может выступать острый угол.

Предел — это отношение расстояния между внутренним и внешним углом соединения к ширине линии. Например, значение `8` позволяет длине митера достигать восьми ширин линии; это не измеряется в пунктах. Если угол превышает предел, PowerPoint заменяет его сближённым соединением. Больший предел допускает более острые точки. Настройка влияет только на соединения‑митеры и не имеет видимого эффекта, когда угол остаётся в пределах обоих пределов.

В этом примере создаются два одинаковых незаполненных треугольника с контурами шириной 20 пунктов. Левый треугольник использует предел `2`, правый — `8`. Каждый треугольник шириной 80 пунктов и высотой 160 пунктов, что даёт отношение длины митера к ширине линии приблизительно `4.12`. Поэтому PowerPoint обрезает левый верхний угол и сохраняет правый.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Результат в PowerPoint: **Miter limit 2** слева и **miter limit 8** справа.

![Смещённый угол при пределе митера 2 и остроконечный угол при пределе 8 в PowerPoint](miter-limits.png)

## **Градиентная заливка**

Градиентная заливка плавно смешивает цвета внутри фигуры. Этот пример заполняет эллипс линейным градиентом под углом 45° от красного к пурпурному с помощью [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/). Метод [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) размещает цветовые остановки на позициях 0 и 1, в начале и в конце градиента. Очистка существующих остановок гарантирует, что будут использованы только эти два цвета.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. раздел [Choose a Gradient Rendering Style](/slides/ru/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга без изменения градиентной заливки, хранящейся в презентации.

### **Установка угла линейного градиента**

Используйте [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/) для управления ориентацией заливки [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/). Угол измеряется в градусах и увеличивается по часовой стрелке: `0` — слева направо, `90` — сверху вниз, `180` — справа налево, `270` — снизу вверх. Поддерживаются дробные углы. Финитные углы за пределами `[0, 360)` нормализуются к одному обороту; например, `-45` становится `315`, а `360` — `0`.

В этом примере создаются шесть прямоугольников с одинаковыми красными, зелёными и синими остановками на позициях `0`, `0.5` и `1`. Масштабирование отключено, чтобы угол можно было сравнивать независимо от пропорций прямоугольников. Углы слева направо: `0`, `45` и `90` в первой строке, и `135`, `180` и `270` во второй строке.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Результат в PowerPoint:

![Линейные градиенты под углами 0, 45 и 90 градусов в верхней строке и 135, 180 и 270 градусов в нижней строке](linear-gradient-angles.png)

### **Масштабировать линейный градиент вместе с фигурой**

[GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) принимает значение [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/). Установите его явно в `FALSE`, чтобы сохранять геометрический угол градиента при изменении пропорций фигуры, или в `TRUE`, чтобы масштабировать градиент вместе с шириной и высотой фигуры. При включённом масштабировании видимый угол может отличаться от назначенного на несферической фигуре.

Следующий пример использует угол `45` градусов и те же цветовые остановки, что и в сравнении углов. В левом столбце `FALSE`, в правом `TRUE`. Каждый столбец содержит широкий прямоугольник над высоким. Оба начинаются с одинаковых широких размеров; изменение ширины и высоты второго прямоугольника демонстрирует, как заливка реагирует на изменение размера без изменения параметров градиента.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Результат в PowerPoint, с отключённым масштабированием слева и включённым справа:

![Широкие и высокие прямоугольники с градиентом 45°, сравнение linear_gradient_scaled FALSE слева и TRUE справа](linear-gradient-scaling.png)

При отключённом масштабировании диагональные цветовые полосы сохраняют одинаковую ориентацию в обеих фигурах. При включённом масштабировании полосы растягиваются вместе с пропорциями фигуры. Это помогает воспроизвести градиент шаблона при адаптации фигуры к другому размеру. На квадрате включение масштабирования не меняет внешний вид этого градиента `45` градусов.

Оба параметра — угол и масштабирование — применяются к линейным градиентам. Они не управляют заливками [GradientShape.RADIAL or GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/).

### **Комбинация угла с направлением градиента**

[GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) выбирает стиль градиента из перечисления [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/); это не заменяет числовой угол. Для линейного градиента стили углов могут изменять область распределения цветов без изменения [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/). Сохраняйте направление неизменным при сравнении углов или масштабирования.

Следующий пример применяет те же настройки в обратном порядке. Два прямоугольника выглядят одинаково: назначение направления до или после угла не меняет результат.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Шаблонная заливка**

Шаблонная заливка применяет двухцветный узор, такой как точки, полосы или клетки. Этот пример использует [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/) для выбора узора «решётка». [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) задаёт светло‑серый фон, а [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) — жёлтый цвет узора.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прямоугольник с шаблонной заливкой](pattern-fill.png)

## **Заливка изображением**

Заливка изображением использует картинку внутри фигуры. Этот пример требует локального изображения и использует [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) для загрузки его в коллекцию изображений презентации. Установка [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) в режим «плитка» повторяет изображение внутри прямоугольника. Исходное изображение, используемое здесь, показано ниже:

![Изображение лотоса](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Фигура с заливкой изображением](picture-fill.png)

### **Повтор изображения как текстуры**

Если нужно установить повторяющуюся картинку как текстуру и настроить её поведение, можно использовать следующие свойства класса [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): задаёт режим заливки — `TILE` или `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): определяет выравнивание плиток внутри фигуры.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): управляет тем, переворачивается ли плитка горизонтально, вертикально или в обеих направлениях.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): определяет горизонтальный масштаб плитки в процентах.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): определяет вертикальный масштаб плитки в процентах.

В этом примере требуется локальное изображение и конфигурируется [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) для повторения его с масштабом 50 % от оригинального размера. Смещения −32 пункта сдвигают плитки горизонтально и вертикально; выравнивание по правому нижнему углу и зеркальное отражение в обоих направлениях определяют расположение повторяющейся текстуры.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Параметры плитки](tile-options.png)

## **Сплошная заливка**

Сплошная заливка задаёт фигуре один однородный цвет. Этот пример устанавливает [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в режим сплошной заливки и задаёт жёлтый цвет через [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/), затем сохраняет прямоугольник в презентации.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Фигура со сплошной заливкой](solid-color-fill.png)

## **Использовать фон слайда в качестве заливки фигуры**

Используйте [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/) когда фигура должна соответствовать фону слайда, например в шаблоне презентации. Сначала установите [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), чтобы убрать любую явную заливку. При такой комбинации фигура использует фон слайда вместо собственного стиля заливки. Включение флага само по себе не удаляет уже существующую явную заливку.

Это отличается от [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/): заливка фоном покрывает объекты за фигурой соответствующей областью фона слайда, тогда как отсутствие заливки оставляет эти объекты видимыми. Градиент остаётся привязанным к слайду, а не начинается внутри каждой фигуры.

В следующем примере создаётся фон‑шаблон, наследуемый слайдом, и размещается магентовая полоса за тремя прямоугольниками. Левый прямоугольник использует фон, средний — без заливки, правый переключается с фоновой заливки на явную оранжевую.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Наследовать градиент от мастера.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Сначала добавить этот объект, чтобы он оказался позади прямоугольников.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Отключить заливку фоном перед применением явной заливки.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Результат слева направо: **фон заливки**, **без заливки** и **явная заливка**. Магентовая полоса скрыта левым и правым прямоугольниками, но остаётся видимой через средний.

![Фоновая заливка, отсутствие заливки и явная оранжевая заливка над магентовой полосой](background-fill.png)

То же поведение применяется к фону, определённому непосредственно на слайде, или унаследованному из макета. Фигура использует разрешённый фон слайда; пример оставляет фон слайда и макета неопределёнными, чтобы обеспечить их мастером.

## **Установка прозрачности**

Для сплошной заливки альфа‑компонента цвета управляет непрозрачностью: 0 — полностью прозрачный, 255 — полностью непрозрачный. Этот пример использует значение альфа 128 для жёлтого прямоугольника, делая его примерно на 50 % прозрачным, чтобы нижний прямоугольник оставался видимым. Цвет задаётся через [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/).

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Вращение фигур**

Используйте [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) для вращения фигуры в плоскости слайда. Угол измеряется в градусах; в этом примере прямоугольник вращается на 5 градусов по часовой стрелке и сохраняется в презентацию.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Вращение фигуры](shape-rotation.png)

## **Добавление 3D‑эффектов фаски**

Используйте [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) для придания фигуре глубины и фасок. Этот пример создаёт зелёный эллипс с оранжевым контуром, задаёт [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) 4 пункта и применяет круглую верхнюю фаску шириной и высотой 6 пунктов через [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/). Фронтальная орфографическая камера и трёхточечное освещение делают фаску видимой.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Эффект 3D‑фаски](3D-bevel-effect.png)

## **Добавление 3D‑вращения**

3‑D‑вид фигуры управляется настройками камеры. Этот пример использует [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) с углами широты, долготы и вращения 40, 35 и 20 градусов соответственно. Выбирается изометрическая камера через [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) и сбалансированное освещение через [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/), затем сохраняется отформатированный прямоугольник.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Эффект 3D‑вращения](3D-rotation-effect.png)

## **Управление чёрно‑белым отображением фигур**

Свойство [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) указывает, как отдельная фигура отображается при просмотре или обработке презентации в чёрно‑белом режиме. Оно не включает чёрно‑белый режим само по себе и не меняет заливку, контур или другое форматирование фигуры в обычном цветовом режиме.

Используйте значение из перечисления [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/), чтобы выбрать желаемое поведение. Например, `AUTOMATIC` позволяет приложению выбора преобразования, `GRAY` и `LIGHT_GRAY` используют оттенки серого, `BLACK_WHITE` — только чёрный и белый, `BLACK` и `WHITE` принудительно задают один цвет, `COLOR` сохраняет обычные цвета, а `HIDDEN` исключает фигуру в чёрно‑белом режиме. `NOT_DEFINED` означает, что режим на уровне фигуры не задан.

В этом примере создаётся оранжевый прямоугольник и задаётся [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) в значение `GRAY`. Сохранённая фигура сохраняет оранжевую заливку для обычного цветного отображения и запрашивает серое отображение в приложениях, поддерживающих чёрно‑белый режим:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе чёрно‑белого отображения он использует серый цвет, потому что его режим установлен в `GRAY`. Это позволяет сохранять полноцветный слайд, определяя отдельный вид для печати, предварительного просмотра или других процессов, учитывающих настройки чёрно‑белого отображения презентации.

## **Сброс форматирования**

Используйте [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/) для восстановления положения, размеров и форматирования заполнителей слайдов из соответствующих заполнителей макета. Этот пример требует существующей презентации с заполнителями, связанными с макетом, и сбрасывает каждый слайд перед сохранением. Фигуры без соответствующих заполнителей макета не сбрасываются.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Цвета, стили линий и настройки эффектов обычно добавляют немного данных по сравнению с внедрёнными изображениями и мультимедиа. Заливки изображениями могут увеличить размер файла, поскольку их изображения хранятся в презентации.

**Как определить фигуры на слайде, имеющие идентичное форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — заливку, контур и настройки эффектов. Если все соответствующие значения совпадают, рассматривайте их стили как идентичные и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблоне презентации или файле .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и повторно примените их форматирование там, где это требуется.