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

Эта статья объясняет, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Она показывает, как работать с [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме. Она также демонстрирует, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определить, закрыта ли геометрия формы, исследовать элементы формы и преобразовывать контуры текста Java AWT в пути геометрии.

## **Изменить форму с помощью точек редактирования**

В PowerPoint вы можете использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из точек привязки, соединённых сегментами.
* Сегмент может быть прямым или изогнутым. Точки привязки и контрольные ручки определяют его форму.
* Точки привязки могут быть угловыми, прямыми или плавными:
  * В угловой точке прилегающие сегменты могут соединяться под углом.
  * В плавной точке две контрольные ручки выровнены и находятся на одинаковом расстоянии от точки привязки.
  * В прямой точке две контрольные ручки выровнены, но могут находиться на разном расстоянии от точки привязки.
* Перемещение точек привязки или настройка их ручек изменяет контур формы.

Для редактирования форм PowerPoint с помощью точек редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) представляет путь геометрии объекта [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/), можно использовать метод [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) для формы, можно использовать методы: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) для форм с единственным путём и [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) для форм с несколькими путями.
* Чтобы добавить сегменты, можно использовать методы из [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Используя методы [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) и [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode), можно задать внешний вид пути геометрии.
* С помощью метода [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) в виде массива сегментов пути.
* Чтобы получить доступ к дополнительным параметрам настройки геометрии формы, можно прочитать [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) через его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) и воспроизвести сегменты на [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в эту позицию с нулевой базой в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Добавить или вставить кубическую кривую Безье с двумя контрольными точками и конечной точкой. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Добавить или вставить квадратичную кривую Безье с одной контрольной точкой и конечной точкой. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Задать начальную точку фигуры. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Удалить сегмент по индексу с нулевой базой. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Добавить пользовательские точки к форме**

В этом примере вставляются две точки в прямоугольную форму с помощью [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) и применяется отредактированный путь с помощью [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Координаты локальны для формы: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхнем и нижнем краях, втягивая эти края внутрь.

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

## **Удалить точки из формы**

В этом примере меняется контур формы в виде сердца, удаляя сегмент по индексу 2 (ноль‑базовый) с помощью [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Применение изменённого пути с помощью [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) обновляет контур формы.

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

## **Создать пользовательскую форму**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов определяют вершины и впадины; шаг 72 градуса равномерно размещает пять вершин. Путь замыкается с помощью [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) и применяется к прямоугольной форме через [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), заменяя её контур.

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

## **Создать составную пользовательскую форму**

В этом примере определяются два замкнутых объекта [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей с помощью [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну составную форму с разрывом посередине её средней трети.

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
    bottom_path.moveTo(shape.getHeight() / 3 * 2, 0)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Создать пользовательскую форму со скруглёнными углами**

В этом примере комбинируются прямые сегменты с [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo), чтобы создать форму со скруглёнными внутрь углами. Размер каждого угла задаёт ширину и высоту дуги в пунктах, а разворот -90 градусов рисует контр‑часовой квартальный эллипс. Завершённый путь применяется с помощью [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), и презентация сохраняется в формате PPTX.

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

## **Определить, закрыта ли геометрия формы**

Следующая вспомогательная функция проверяет, оканчивается ли каждый непустой путь геометрии закрывающим сегментом. Она читает [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) и сравнивает последнюю команду сегмента [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) с [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Возвращает `False`, если нет непустых путей. Проверяется только конечная команда каждого пути; отдельные подпостройки внутри пути не анализируются. Пример выводит `True` для прямоугольника.

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

## **Исследовать команды пути геометрии**

Скачайте [contour.pptx](contour.pptx) и разместите его в рабочей директории приложения. Первая форма на первом слайде имеет прямой верхний край, кубическую кривую Безье и прямой закрывающий край. Используйте [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) для чтения путей формы и [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) для чтения сегментов каждого пути в порядке отрисовки. Для каждого сегмента [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) определяет команду и определяет, как интерпретировать значения, возвращаемые [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

Форма расположена в точке (200, 100) пунктов на слайде. Сообщённые координаты локальны относительно формы, при этом (0, 0) находится в её левом верхнем углу, x растёт вправо, y растёт вниз. Закрывающий сегмент возвращается к начальной точке без дополнительных координат.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Форма PowerPoint с прямым верхним краем, изогнутым краем от правого верха к левому низу и прямым левым краем](contour.png)

## **Извлечь и исследовать элементы формы**

Используйте [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements), чтобы исследовать существующую форму как элементы, содержащие точки пути и типы точек. Приведите каждый возвращённый элемент к типу [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) с помощью `jpype.JObject`, чтобы получить массивы точек и типов через методы [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) и [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

В примере открывается input.pptx, находится первая геометрическая форма непосредственно на первом слайде и выводятся её сегменты пути. Используйте презентацию, содержащую форму с прямыми и изогнутыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не выполняется.

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
                point_type = types[i] & 0x07  # Сохранить тип сегмента, исключая флаги.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Потребить обе контрольные точки и конечную точку.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Массивы соответствуют по индексу: `points[i]` — это точка, а `types[i]` описывает её роль. Тип `0` начинается фигура, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается от предыдущей конечной точки и использует три последовательных элемента типа `3`: две контрольные точки и новую конечную точку. Цикл обрабатывает эти три элемента вместе и проверяет конечную точку на замыкание. Типы точек также содержат флаги. Маска с `0x07` определяет тип сегмента, а проверка `0x80` отдельно выявляет закрытый подпуть. Например, `129` (`0x81`) означает конец линии, закрывающий подпуть, а `131` (`0x83`) — конец сегмента Безье, закрывающего подпуть. Java хранит эти флаги в знаковых байтах; маскирование сохраняет ожидаемые битовые значения. Сравнение сырого значения только с `1` или `3` упустит эти случаи. Другие флаги, такие как тире (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и трансформации.** Точки измеряются в пунктах (1/72 дюйма), при этом X растёт вправо, а Y — вниз. Для разъединённой формы извлечённые координаты уже включают позицию, возвращаемую [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) и [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY), и отражают её текущую ширину и высоту. Например, не повёрнутый прямоугольник с координатами `(100, 200)` и размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её необращённого кадра.

Извлечённые точки не учитывают вращение формы, возвращаемое [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), или горизонтальные/вертикальные отражения. Чтобы воспроизвести отображаемый контур, примените эти трансформации относительно центра формы. Для составных форм также учитывайте сопоставление координат группы и трансформации; не предполагайте, что извлечённые точки являются окончательными координатами отрисовки слайда, и не применяйте трансляцию или масштабирование дважды, если они уже учитываются в кадре дочернего элемента.

**Исследование vs редактирование.** Извлечённые массивы описывают контур; их изменение не обновляет исходную форму. Выберите этот подход, когда вашему коду анализа или рисования нужны массивы точек/типов. Используйте [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), если нужны геометрические команды в локальной системе координат формы или необходимо отредактировать её геометрию. Применяйте отредактированные пути через [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) или [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Преобразовать Java AWT Shape в GeometryPath**

В этом примере комбинируется прямоугольный контур с текстом, преобразованным в геометрию. Метод [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) контура отключает заливку. [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) создаёт контур текста в объекте [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Его [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) поставляет перемещения, линии, квадратичные, кубические и закрывающие сегменты, которые пример воспроизводит на [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Текст использует шрифт Arial размером 40 пунктов. Контур смещён на 20 пунктов по горизонтали и расположен так, чтобы его визуальная верхняя часть была на 10 пунктов ниже верхнего края формы. Путь текста заполнен, тогда как исходный прямоугольник остаётся контуром. Применение обоих путей с помощью [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) создаёт одну форму, содержащую прямоугольник и текст.

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

    # Применить текстовый путь вместе с оригинальным путём геометрии.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся у формы; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**

Используйте метод формы [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation); геометрия вращается вместе с формой, так как привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте нужную [слайд](/slides/ru/python-java/convert-powerpoint-to-png/) область или саму [форму](/slides/ru/python-java/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.