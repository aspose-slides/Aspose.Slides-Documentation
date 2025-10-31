---
title: "Настройка фигур в презентациях с помощью Python"
linktitle: "Пользовательская фигура"
type: docs
weight: 20
url: /ru/python-net/custom-shape/
keywords:
- "пользовательская фигура"
- "добавить фигуру"
- "создать фигуру"
- "изменить фигуру"
- "геометрия фигуры"
- "геометрический путь"
- "точки пути"
- "редактировать точки"
- "добавить точку"
- "удалить точку"
- "операция редактирования"
- "согнутый угол"
- "PowerPoint"
- "OpenDocument"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python через .NET: геометрические пути, сглаженные углы, составные фигуры."
---

## **Обзор**

Представьте квадрат. В PowerPoint, используя **Edit Points**, вы можете:

* переместить угол квадрата внутрь или наружу,
* изменить кривизну угла или точки,
* добавить новые точки к квадрату,
* манипулировать его точками.

Эти операции применимы к любой фигуре. С помощью **Edit Points** можно изменить существующую фигуру или создать новую на её основе.

## **Советы по редактированию фигур**

!["Редактировать точки" команда](custom_shape_0.png)

Перед тем как начать редактирование фигур PowerPoint с помощью **Edit Points**, обратите внимание на следующее:

* Фигура (или её путь) может быть **замкнутой** или **открытой**.
* Замкнутая фигура не имеет начальной и конечной точек; открытая фигура имеет начало и конец.
* Каждая фигура имеет как минимум две опорные точки, соединённые отрезками.
* Отрезок может быть прямым или кривым; характер отрезка определяется опорными точками.
* Опорные точки могут быть **угловыми**, **плавными** или **прямыми**:
  * **Угловая** точка — место, где встречаются два прямых отрезка под углом.
  * **Плавная** точка имеет две коллинейные ручки, и соседние отрезки образуют плавную кривую. При этом обе ручки находятся на одинаковом расстоянии от опорной точки.
  * **Прямая** точка также имеет две коллинейные ручки, но расстояния ручек от опорной точки могут различаться.
* Перемещая или редактируя опорные точки (тем самым изменяя углы отрезков), вы меняете внешний вид фигуры.

Для редактирования фигур PowerPoint Aspose.Slides предоставляет класс [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) представляет геометрический путь объекта [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), используйте метод [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Чтобы задать [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) для фигуры, используйте [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) для *solid shapes* и [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) для *composite shapes*.
* Для добавления отрезков применяйте методы класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Свойства [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) и [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) позволяют управлять внешним видом геометрического пути.
* Свойство [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) возвращает массив отрезков пути фигуры.

## **Простые операции редактирования**

Ниже перечислены методы, используемые для простых операций редактирования.

**Добавить линию** в конец пути:

```py
line_to(point)
line_to(x, y)
```

**Добавить линию** в указанную позицию пути:

```py
line_to(point, index)
line_to(x, y, index)
```

**Добавить кубическую кривую Безье** в конец пути:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Добавить кубическую кривую Безье** в указанную позицию пути:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Добавить квадратичную кривую Безье** в конец пути:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Добавить квадратичную кривую Безье** в указанную позицию пути:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Добавить дугу** к пути:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Замкнуть текущую фигурную часть** пути:

```py
close_figure()
```

**Задать позицию для следующей точки**:

```py
move_to(point)
move_to(x, y)
```

**Удалить отрезок пути** по индексу:

```py
remove_at(index)
```

## **Добавление пользовательских точек к фигуркам**

Здесь вы узнаете, как определить произвольную форму, добавляя собственную последовательность точек. Указывая упорядоченные точки и типы отрезков (прямые или кривые) и, при желании, замыкая путь, можно рисовать точные пользовательские графики — полигоны, значки, выноски или логотипы — непосредственно на слайдах.

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) и задайте его тип [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Получите экземпляр [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) из фигуры.
3. Вставьте новую точку между двумя верхними точками пути.
4. Вставьте новую точку между двумя нижними точками пути.
5. Примените обновлённый путь к фигуре.

Пример кода на Python, показывающий, как добавить пользовательские точки к фигуре:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Пользовательские точки](custom_shape_1.png)

## **Удаление точек из фигур**

Иногда в пользовательской фигуре присутствуют лишние точки, усложняющие её геометрию или влияющие на отображение. В этом разделе показано, как удалить отдельные точки из пути фигуры, чтобы упростить контур и получить более чистый результат.

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) и задайте тип [ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Получите экземпляр [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) из фигуры.
3. Удалите отрезок из пути.
4. Примените обновлённый путь к фигуре.

Пример кода на Python, показывающий, как удалить точки из фигуры:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Удалённые точки](custom_shape_2.png)

## **Создание пользовательских фигур**

Создавайте индивидуальные векторные фигуры, определяя [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) и составляя его из линий, дуг и кривых Безье. В этом разделе показано, как построить собственную геометрию с нуля и добавить получившуюся фигуру на слайд.

1. Вычислите точки фигуры.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
5. Примените путь к фигуре.

Пример кода на Python, показывающий, как создать пользовательскую фигуру:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Пользовательская фигура](custom_shape_3.png)

## **Создание составных пользовательских фигур**

Создание составной пользовательской фигуры позволяет объединять несколько геометрических путей в одну переиспользуемую фигуру на слайде. Определите и объедините эти пути, чтобы построить сложные визуальные элементы, выходящие за рамки стандартного набора фигур.

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
4. Примените оба пути к фигуре.

Пример кода на Python, показывающий, как создать составную пользовательскую фигуру:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Составная фигура](custom_shape_4.png)

## **Создание пользовательских фигур со сглаженными углами**

В этом разделе показано, как нарисовать пользовательскую фигуру с плавно сглаженными углами, используя геометрический путь. Вы комбинируете прямые отрезки и окружные дуги, формируя контур, а затем добавляете готовую фигуру на слайд.

Пример кода на Python, показывающий, как создать пользовательскую фигуру со сглаженными углами:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Сглаженные углы](custom_shape_6.png)

## **Определение, является ли геометрия фигуры замкнутой**

Замкнутая фигура — это такая, у которой все стороны соединены, образуя единый контур без разрывов. Такая фигура может быть простой геометрической формой или сложным пользовательским контуром. Ниже приведён пример кода, показывающий, как проверить, замкнута ли геометрия фигуры:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**Что происходит со заливкой и контуром после замены геометрии?**

Стиль остаётся привязан к фигуре; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую фигуру вместе с её геометрией?**

Используйте свойство [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/) фигуры; геометрия вращается вместе с фигурой, поскольку привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую фигуру в изображение, «зафиксировав» результат?**

Да. Экспортируйте нужную область [slide](/slides/ru/python-net/convert-powerpoint-to-png/) или саму [shape](/slides/ru/python-net/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу с тяжёлой геометрией.