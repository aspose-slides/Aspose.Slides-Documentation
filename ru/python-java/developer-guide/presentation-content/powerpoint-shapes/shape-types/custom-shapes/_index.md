---
title: Настройка форм презентаций в Python через Java
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/python-java/custom-shape/
keywords:
- пользовательская форма
- добавить форму
- создать форму
- изменить форму
- геометрия формы
- путь геометрии
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- скруглённый угол
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для Python через Java: пути геометрии, скруглённые углы, составные формы."
---
## **Обзор**

В этой статье объясняется, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы через точки редактирования и пути геометрии. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) для изменения существующих форм, выполнять базовые операции редактирования пути, добавлять или удалять точки и применять обновлённую геометрию к форме.

Также демонстрируется, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определять, закрыта ли геометрия формы, исследовать элементы формы и преобразовывать контуры текста Java AWT в пути геометрии.

## **Изменение формы с помощью точек редактирования**

В PowerPoint вы можете использовать **Точки редактирования**, чтобы изменить квадрат:

* Переместить угол внутрь или наружу.
* Скорректировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint имейте в виду следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из опорных точек, соединённых сегментами.
* Сегмент может быть прямым или кривым. Опорные точки и управляющие ручки определяют его форму.
* Опорные точки бывают угловыми, прямыми или сглаженными:
  * В угловой точке смежные сегменты могут встречаться под углом.
  * В сглаженной точке две управляющие ручки выровнены и находятся на одинаковом расстоянии от опорной точки.
  * В прямой точке две управляющие ручки выровнены, но могут иметь разное расстояние от опорной точки.
* Перемещение опорных точек или регулировка их ручек меняет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) представляет путь геометрии объекта [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), используйте метод [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Чтобы установить [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) для формы, используйте методы: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) для форм с одним путем и [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) для форм с несколькими путями.
* Чтобы добавить сегменты, используйте методы из [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* С помощью методов [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) и [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) можно задать отображение пути геометрии.
* С помощью метода [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) в виде массива сегментов пути.
* Чтобы получить дополнительные параметры настройки геометрии формы, можно прочитать объект [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) через его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) и воспроизвести сегменты на [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию (нумерация с нуля) массива сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Добавить или вставить кубическую кривую Безье с двумя управляющими точками и конечной точкой. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Добавить или вставить квадратичную кривую Безье с одной управляющей точкой и конечной точкой. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Установить начальную точку фигуры. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Удалить сегмент по индексу, нумерация с нуля. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Добавление пользовательских точек к форме**

В этом примере вставляются две точки в прямоугольную форму с помощью [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) и применяется отредактированный путь через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Координаты локальны для формы: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 помещают их на верхний и нижний края, притягивая эти края внутрь.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Удаление точек из формы**

В этом примере меняется контур сердцевидной формы, удаляя сегмент с индексом 2 (нумерация с нуля) с помощью [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Применение изменённого пути через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) обновляет контур формы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Создание пользовательской формы**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов задают вершины и врезы; шаг в 72 градуса равномерно размещает пять вершин. Путь закрывается методом [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) и применяется к прямоугольной форме через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), заменяя её контур.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Создание составной пользовательской формы**

В этом примере определяются два закрытых объекта [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей через [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну составную форму с промежутком через её среднюю треть.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Создание пользовательской формы со скруглёнными углами**

В этом примере комбинируются прямые сегменты с [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) для создания формы с внутренне‑скруглёнными углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а разворот ‑90 градусов рисует дугу против часовой стрелки – четверть эллипса. Готовый путь применяется через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), и презентация сохраняется в формате PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Определение, закрыта ли геометрия формы**

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой путь геометрии закрывающим сегментом. Она читает [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) и сравнивает конечный сегмент’s [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) с [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Возвращает `False`, когда нет непустых путей. Проверка касается только последней команды каждого пути; она не исследует каждый подпуть внутри пути. В примере выводится `True` для прямоугольника.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Извлечение и анализ элементов формы**

Используйте [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) для анализа существующей формы как набора элементов, содержащих точки пути и типы точек. Преобразуйте каждый полученный элемент к типу [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) с помощью `jpype.JObject`, чтобы получить массивы точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) и [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается `input.pptx`, находится первая геометрическая форма на первом слайде и выводятся её сегменты пути. Используйте презентацию, содержащую форму с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не выполняется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Массивы согласованы по индексу: `points[i]` — точка, а `types[i]` описывает её роль. Тип `0` начинается фигура, тип `1` — линия от предыдущей точки к текущей. Кубический сегмент Безье начинается от предыдущей конечной точки и использует три последовательных элемента типа `3`: два управляющих шага и новую конечную точку. Цикл потребляет эти три элемента совместно и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` определяет тип сегмента, а отдельная проверка `0x80` обнаруживает закрытый подпуть. Например, значение `129` (`0x81`) означает конечную точку линии, закрывающую подпуть, а `131` (`0x83`) — конечную точку Безье, закрывающую его. В Java эти флаги хранятся в знаковых байтах; маскирование сохраняет нужные битовые значения. Сравнение «сырых» значений только с `1` или `3` упустило бы такие случаи. Другие флаги, такие как пунктир (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X растёт вправо, Y — вниз. Для не сгруппированной формы извлечённые координаты уже включают позицию, возвращаемую методами [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) и [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY), а также её текущую ширину и высоту. Например, не повернутый прямоугольник с координатами `(100, 200)` и размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы ещё раз. Вычтите её X и Y, чтобы получить координаты относительно её необёрнутой рамки.

Извлечённые точки не учитывают поворот формы, возвращаемый методом [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), а также горизонтальное и вертикальное отражения. Чтобы воспроизвести отображаемый контур, примените эти преобразования относительно центра формы. Для сгруппированных форм также учитывайте преобразования координат группы; не предполагаете, что извлечённые точки уже являются окончательными координатами слайда, и не применяйте трансляцию или масштаб дважды, если они уже учтены в кадре дочернего объекта.

**Анализ vs. редактирование.** Извлечённые массивы описывают контур; изменение их не обновляет исходную форму. Выбирайте такой подход, когда ваш код анализа или рисования нуждается в массивах точек/типов. Используйте [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), когда нужны команды геометрии в локальной системе координат формы или вы хотите редактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) или [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Преобразование Java AWT Shape в GeometryPath**

В этом примере комбинируется прямоугольный контур с текстом, преобразованным в геометрию. Метод [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) контура отключает его заливку. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) создаёт контур текста в объекте [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) поставляет команды перемещения, линии, квадратичной, кубической и закрывающей сегменты, которые пример воспроизводит на [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Текст использует шрифт Arial размером 40 пунктов. Контур сдвинут на 20 пунктов по горизонтали и позиционируется так, чтобы его визуальная верхняя часть находилась на 10 пунктов ниже верхнего края формы. Текстовый путь заполняется, в то время как исходный прямоугольник остаётся контуром. Применение обоих путей через [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт единую форму, содержащую прямоугольник и текст.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Получить путь геометрии формы.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Создать новый графический путь с текстом.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Преобразовать графический путь в путь геометрии.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Применить путь текста вместе с оригинальным путем геометрии.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контурами после замены геометрии?**

Стиль остаётся привязанным к форме; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую форму вместе с её геометрией?**

Используйте метод формы [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation); геометрия вращается вместе с формой, потому что она привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте нужную [slide](/slides/ru/python-java/convert-powerpoint-to-png/) область или саму [shape](/slides/ru/python-java/create-shape-thumbnails/) в растровый формат; это упростит дальнейшую работу со сложными геометриями.