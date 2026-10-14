---
title: Форматирование фигур PowerPoint в Python через Java
linktitle: Форматирование фигур
type: docs
weight: 20
url: /ru/python-java/shape-formatting/
keywords:
- форматирование фигуры
- форматирование линии
- эффект наброска
- набросок линии фигуры
- форматировать стиль соединения
- градиентная заливка
- заливка узором
- заливка изображением
- заливка текстурой
- заливка сплошным цветом
- прозрачность фигуры
- чёрно‑белая отрисовка фигуры
- отображение фигуры в градациях серого
- поворот фигуры
- 3D-скошенный эффект
- 3D-эффект вращения
- сброс форматирования
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как форматировать фигуры PowerPoint в Python через Java с помощью Aspose.Slides — задавайте стили заливки, линии и эффектов для файлов PPT, PPTX и ODP с точностью и полным контролем."
---
## **Введение**

В PowerPoint вы можете добавлять фигуры на слайды. Поскольку фигуры состоят из линий, их можно форматировать, изменяя или применяя эффекты к контуру. Кроме того, вы можете форматировать фигуры, указывая параметры, которые контролируют заполнение их внутренней части.

![форматирование-фигур-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Python via Java предоставляет классы и методы, позволяющие форматировать фигуры с теми же параметрами, что доступны в PowerPoint.

## **Форматирование линий**

С помощью Aspose.Slides вы можете указать пользовательский стиль линии для фигуры. Ниже приведена последовательность шагов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Установите [line style](https://reference.aspose.com/slides/python-java/aspose.slides/linestyle/) фигуры.
1. Установите ширину линии.
1. Установите [dash style](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/) линии.
1. Установите цвет линии для фигуры.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код демонстрирует, как отформатировать прямоугольник [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineDashStyle, LineStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить автофигуру типа Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75)

    # Установить цвет заливки для прямоугольной фигуры.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Применить форматирование к линиям прямоугольника.
    shape.getLineFormat().setStyle(LineStyle.ThickThin)
    shape.getLineFormat().setWidth(7)
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash)

    # Установить цвет линии прямоугольника.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Сохранить файл PPTX на диск.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Отформатированные линии в презентации](formatted-lines.png)

## **Применение эффектов наброска к линиям фигур**

Эффект наброска делает линию фигуры выглядящей как нарисованную от руки. Используйте [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) для доступа к настройкам линии, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getSketchFormat) для доступа к настройкам наброска и [SketchFormat.setSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#setSketchType) для выбора значения из перечисления [LineSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/).

Следующий Python‑код показывает, как применить эффект [LineSketchType.Curved](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#Curved), прочитать явно назначенное значение и удалить эффект с помощью [LineSketchType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/linesketchtype/#None):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LineSketchType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)

    # Получить формат линии фигуры и её формат наброска.
    sketch_format = shape.getLineFormat().getSketchFormat()

    # Применить эффект наброска.
    sketch_format.setSketchType(LineSketchType.Curved)

    # Прочитать эффект наброска, назначенный напрямую фигуре.
    explicit_sketch_type = sketch_format.getSketchType()
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Удалить эффект наброска.
    sketch_format.setSketchType(LineSketchType.None_)
finally:
    presentation.dispose()
```

Значение, возвращаемое [SketchFormat.getSketchType](https://reference.aspose.com/slides/python-java/aspose.slides/sketchformat/#getSketchType), представляет настройку, присвоенную непосредственно фигуре. Если форматирование линии может быть унаследовано от темы, мастер‑слайда или макета, используйте [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective), обращайтесь к `LineFormatEffectiveData.getSketchFormat` и читайте `SketchFormatEffectiveData.getSketchType`. Эффективное значение отражает фактическое форматирование после разрешения наследования:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    line_format = shape.getLineFormat()

    explicit_sketch_type = line_format.getSketchFormat().getSketchType()
    effective_line_format = line_format.getEffective()
    effective_sketch_type = effective_line_format.getSketchFormat().getSketchType()

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
finally:
    presentation.dispose()
```

## **Форматирование стилей соединений**

Вот три варианта типа соединения:

* Round
* Miter
* Bevel

По умолчанию, когда PowerPoint соединяет две линии под углом (например, в углу фигуры), используется настройка **Round**. Однако если вы рисуете фигуру с острыми углами, вам может подойти вариант **Miter**.

![Стиль соединения в презентации](join-style-powerpoint.png)

Следующий Python‑код демонстрирует, как были созданы три прямоугольника (как показано на изображении выше) с настройками соединения Miter, Bevel и Round:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineJoinStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить три автофигуры типа Rectangle.
    miter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75)
    bevel_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75)
    round_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75)

    # Установить цвет заливки для каждой прямоугольной фигуры.
    miter_shape.getFillFormat().setFillType(FillType.Solid)
    miter_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    bevel_shape.getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    round_shape.getFillFormat().setFillType(FillType.Solid)
    round_shape.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Установить ширину линии.
    miter_shape.getLineFormat().setWidth(15)
    bevel_shape.getLineFormat().setWidth(15)
    round_shape.getLineFormat().setWidth(15)

    # Установить цвет линии для каждого прямоугольника.
    miter_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    miter_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    bevel_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    bevel_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    round_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    round_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Установить стиль соединения.
    miter_shape.getLineFormat().setJoinStyle(LineJoinStyle.Miter)
    bevel_shape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel)
    round_shape.getLineFormat().setJoinStyle(LineJoinStyle.Round)

    # Добавить текст к каждому прямоугольнику.
    miter_shape.getTextFrame().setText("Miter Join Style")
    bevel_shape.getTextFrame().setText("Bevel Join Style")
    round_shape.getTextFrame().setText("Round Join Style")

    # Сохранить файл PPTX на диск.
    presentation.save("join_styles.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Градиентная заливка**

В PowerPoint градиентная заливка — это параметр форматирования, позволяющий применить непрерывный переход цветов к фигуре. Например, можно задать два и более цветов так, чтобы один постепенно переходил в другой.

Вот как применить градиентную заливку к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) фигуры в `Gradient`.
1. Добавьте два предпочтительных цвета с определёнными позициями, используя метод [addPresetColor](https://reference.aspose.com/slides/python-java/aspose.slides/gradientstopcollection/#addPresetColor) коллекции градиентных остановок, предоставляемой классом [GradientFormat](https://reference.aspose.com/slides/python-java/aspose.slides/gradientformat/).
1. Сохраните изменённую презентацию как файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GradientDirection, GradientShape, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить автофигуру типа Ellipse.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75)

    # Применить градиентное форматирование к эллипсу.
    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)

    # Установить направление градиента.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2)

    # Добавить две градиентные остановки.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, PresetColor.Purple)
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, PresetColor.Red)

    # Сохранить файл PPTX на диск.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Эллипс с градиентной заливкой](gradient-fill.png)

Если градиент выглядит иначе в экспортированном изображении, чем в PowerPoint, см. [Choose a Gradient Rendering Style](/slides/ru/python-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Вы можете выбрать стиль рендеринга без изменения градиентной заливки, хранящейся в презентации.

## **Заполнение узором**

В PowerPoint заполнение узором — это параметр форматирования, позволяющий применить двухцветный дизайн — например, точки, полосы, перекрёстные линии или шахматы — к фигуре. Вы можете выбрать пользовательские цвета для переднего и заднего плана узора.

Aspose.Slides предоставляет более 45 предопределённых стилей узора, которые можно применять к фигурам для улучшения визуального восприятия презентаций. Даже после выбора предопределённого узора вы можете указать точные цвета, которые он будет использовать.

Вот как применить заполнение узором к фигуре с помощью Aspose.Slides:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) фигуры в `Pattern`.
1. Выберите стиль узора из предопределённых вариантов.
1. Установите [Background Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getBackColor) узора.
1. Установите [Foreground Color](https://reference.aspose.com/slides/python-java/aspose.slides/patternformat/#getForeColor) узора.
1. Сохраните изменённую презентацию как файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить автофигуру типа Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Установить тип заливки в Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern)

    # Установить стиль узора.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis)

    # Установить фоновые и передние цвета узора.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY)
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW)

    # Сохранить файл PPTX на диск.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Прямоугольник с узорчатой заливкой](pattern-fill.png)

## **Заполнение изображением**

В PowerPoint заполнение изображением — это параметр форматирования, позволяющий вставить изображение внутри фигуры, фактически используя его в качестве фона фигуры.

Вот как с помощью Aspose.Slides применить заполнение изображением к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) фигуры в `Picture`.
1. Установите режим заполнения изображением в `Tile` (или другой предпочитаемый режим).
1. Создайте объект [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) из изображения, которое хотите использовать.
1. Передайте изображение методу `SlidesPicture.setImage`.
1. Сохраните изменённую презентацию как файл PPTX.

Допустим, у нас есть файл «lotus.png» со следующим изображением:

![Изображение лотоса](lotus.png)

Следующий Python‑код демонстрирует, как заполнить фигуру изображением:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, SaveFormat, ShapeType

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить автофигуру типа Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130)
    
    # Установить тип заливки в Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Установить режим заливки изображением.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile)

    # Загрузить изображение и добавить его в ресурсы презентации.
    image = Images.fromFile("lotus.png")
    picture = presentation.getImages().addImage(image)
    image.dispose()

    # Установить изображение.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Сохранить файл PPTX на диск.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Фигура с заполнением изображением](picture-fill.png)

### **Замостить изображение как текстуру**

Если вы хотите задать замощённое изображение в качестве текстуры и настроить поведение замощения, можете использовать следующие методы класса [PictureFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode): задаёт режим заполнения изображением — `Tile` или `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileAlignment): определяет выравнивание плиток внутри фигуры.
- [setTileFlip](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileFlip): управляет тем, будет ли плитка отражена по горизонтали, вертикали или обеим осям.
- [setTileOffsetX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetX): задаёт горизонтальное смещение плитки (в пунктах) от начала фигуры.
- [setTileOffsetY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileOffsetY): задаёт вертикальное смещение плитки (в пунктах) от начала фигуры.
- [setTileScaleX](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleX): определяет горизонтальный масштаб плитки в процентах.
- [setTileScaleY](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setTileScaleY): определяет вертикальный масштаб плитки в процентах.

Следующий пример кода показывает, как добавить прямоугольник с замощённой заливкой изображением и настроить параметры плитки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, ShapeType, TileFlip

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    first_slide = presentation.getSlides().get_Item(0)

    # Добавить автофигуру прямоугольника.
    shape = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95)

    # Установить тип заливки фигуры в Picture.
    shape.getFillFormat().setFillType(FillType.Picture)

    # Загрузить изображение и добавить его в ресурсы презентации.
    source_image = Images.fromFile("lotus.png")
    presentation_image = presentation.getImages().addImage(source_image)
    source_image.dispose()

    # Назначить изображение фигуре.
    picture_fill_format = shape.getFillFormat().getPictureFillFormat()
    picture_fill_format.getPicture().setImage(presentation_image)

    # Настроить режим заливки изображением и свойства замощения.
    picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    picture_fill_format.setTileOffsetX(-32)
    picture_fill_format.setTileOffsetY(-32)
    picture_fill_format.setTileScaleX(50)
    picture_fill_format.setTileScaleY(50)
    picture_fill_format.setTileAlignment(RectangleAlignment.BottomRight)
    picture_fill_format.setTileFlip(TileFlip.FlipBoth)

    # Сохранить файл PPTX на диск.
    presentation.save("tile.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Параметры замощения](tile-options.png)

## **Заливка сплошным цветом**

В PowerPoint сплошная заливка — это параметр форматирования, заполняющий фигуру одним равномерным цветом. Этот простой фон применяется без градиентов, текстур или узоров.

Чтобы применить сплошную заливку к фигуре с помощью Aspose.Slides, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) фигуры в `Solid`.
1. Назначьте предпочитаемый цвет заливки фигуре.
1. Сохраните изменённую презентацию как файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить автофигуру типа Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Установить тип заливки в Solid.
    shape.getFillFormat().setFillType(FillType.Solid)

    # Установить цвет заливки.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW)

    # Сохранить файл PPTX на диск.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Фигура со сплошной заливкой](solid-color-fill.png)

## **Установка прозрачности**

В PowerPoint, когда вы применяете сплошной цвет, градиент, изображение или текстуру к фигурам, можно также задать уровень прозрачности, контролирующий непрозрачность заливки. Чем выше значение прозрачности, тем более «прозрачной» выглядит фигура, позволяя частично видеть фон или находящиеся под ней объекты.

Aspose.Slides позволяет установить уровень прозрачности, изменяя альфа‑компонент в цвете, используемом для заливки. Вот как это сделать:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Установите [FillType](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) в `Solid`.
1. Используйте [Color](https://docs.oracle.com/en/java/javase/17/docs/api/java.desktop/java/awt/Color.html) для определения цвета с прозрачностью (компонент `alpha` управляет прозрачностью).
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить сплошную прямоугольную автофигуру.
    solid_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Добавить прозрачную прямоугольную автофигуру поверх сплошной фигуры.
    transparent_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75)
    transparent_shape.getFillFormat().setFillType(FillType.Solid)
    transparent_color = Color(255, 255, 0, 204)
    transparent_shape.getFillFormat().getSolidFillColor().setColor(transparent_color)

    # Сохранить файл PPTX на диск.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Прозрачная фигура](shape-transparency.png)

## **Поворот фигур**

Aspose.Slides позволяет поворачивать фигуры в презентациях PowerPoint. Это может быть полезно при размещении визуальных элементов с определённым выравниванием или дизайнерскими требованиями.

Чтобы повернуть фигуру на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Установите свойство вращения фигуры в требуемый угол.
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Добавить автофигуру типа Rectangle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)

    # Повернуть фигуру на 5 градусов.
    shape.setRotation(5)

    # Сохранить файл PPTX на диск.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Поворот фигуры](shape-rotation.png)

## **Добавление 3D-скошенных эффектов**

Aspose.Slides позволяет применять 3D-скошенные эффекты к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/).

Чтобы добавить 3D-скошенные эффекты к фигуре, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Настройте свойство [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) фигуры, определив параметры скоса.
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, FillType, LightRigPresetType, LightingDirection, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Создайте экземпляр класса Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавьте фигуру на слайд.
    shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE)
    shape.getLineFormat().setWidth(2.0)

    # Set the shape's ThreeDFormat properties.
    shape.getThreeDFormat().setDepth(4)
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    shape.getThreeDFormat().getBevelTop().setHeight(6)
    shape.getThreeDFormat().getBevelTop().setWidth(6)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)

    # Save the presentation as a PPTX file.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Эффект 3D-скошения](3D-bevel-effect.png)

## **Добавление 3D-вращения**

Aspose.Slides позволяет применять 3D-вращение к фигурам, настраивая их свойства [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/).

Чтобы применить 3D-вращение к фигуре:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) на слайд.
1. Используйте методы [setCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setCameraType) и [setLightType](https://reference.aspose.com/slides/python-java/aspose.slides/lightrig/#setLightType) для определения 3D‑вращения.
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, Presentation, SaveFormat, ShapeType

# Создайте экземпляр класса Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    auto_shape.getThreeDFormat().setDepth(6)
    auto_shape.getThreeDFormat().getCamera().setRotation(40, 35, 20)
    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)

    # Сохраните презентацию как файл PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат:

![Эффект 3D-вращения](3D-rotation-effect.png)

## **Управление черно-белой отрисовкой фигур**

Метод [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setBlackWhiteMode) задаёт, как отдельная фигура будет отрисовываться, когда презентация просматривается или обрабатывается в черно‑белом режиме. Этот метод сам по себе не включает черно‑белый режим и не меняет заполнение, линии или другое форматирование фигуры в обычном цветном режиме.

Используйте значение из класса [BlackWhiteMode](https://reference.aspose.com/slides/python-java/aspose.slides/blackwhitemode/) для выбора нужного поведения. Например, `Automatic` позволяет приложению‑отображателю выбрать способ конвертации, `Gray` и `LightGray` используют серую окраску, `BlackWhite` оставляет только черный и белый, `Black` и `White` принудительно задают один цвет, `Color` сохраняет обычные цвета, а `Hidden` исключает фигуру в черно‑белом режиме. `NotDefined` означает, что режим для фигуры не задан.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteMode, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    # Сохранить оранжевую заливку в цветном режиме, но отрисовать фигуру серым цветом в черно‑белом режиме.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray)

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

В обычном цветовом режиме прямоугольник сохраняет оранжевую заливку. В рабочем процессе черно‑белого отображения он использует серую окраску, потому что его режим установлен в `Gray`. Это позволяет сохранить слайд с полным спектром цветов, задав отдельный вид для печати, предварительного просмотра или других процессов, учитывающих настройки черно‑белого отображения презентации.

## **Сброс форматирования**

Следующий Python‑код показывает, как сбросить форматирование слайда и вернуть положение, размер и форматирование всех фигур с заполнителями на [LayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) к их значениям по умолчанию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    for slide in presentation.getSlides():
        # Сбросить каждую фигуру на слайде, у которой есть заполнитель в макете.
        slide.reset()

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Влияет ли форматирование фигур на конечный размер файла презентации?**

Только минимально. Встроенные изображения и медиа‑файлы занимают большую часть объёма, тогда как параметры фигур, такие как цвета, эффекты и градиенты, хранятся как метаданные и почти не увеличивают размер файла.

**Как определить фигуры на слайде, имеющие одинаковое форматирование, чтобы сгруппировать их?**

Сравните ключевые свойства форматирования каждой фигуры — заполнение, линии и эффекты. Если все соответствующие значения совпадают, рассматривайте их стили как идентичные и логически группируйте такие фигуры, что упрощает последующее управление стилями.

**Можно ли сохранить набор пользовательских стилей фигур в отдельный файл для повторного использования в других презентациях?**

Да. Сохраните образцы фигур с нужными стилями в шаблонном наборе слайдов или файле шаблона .POTX. При создании новой презентации откройте шаблон, клонируйте необходимые стилизованные фигуры и снова примените их форматирование там, где требуется.