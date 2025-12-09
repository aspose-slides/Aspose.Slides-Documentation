---
title: Настройка фигур в презентациях с Python
linktitle: Пользовательская фигура
type: docs
weight: 20
url: /ru/python-net/custom-shape/
keywords:
- пользовательская фигура
- добавить фигуру
- создать фигуру
- изменить фигуру
- геометрия фигуры
- путь геометрии
- точки пути
- редактировать точки
- добавить точку
- удалить точку
- операция редактирования
- скруглённый угол
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте фигуры в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python на платформе .NET: геометрические пути, скруглённые углы, составные фигуры."
---

## **Обзор**

Рассмотрим квадрат. В PowerPoint, используя **Edit Points**, вы можете:

* перемещать угол квадрата внутрь или наружу,
* регулировать кривизну угла или точки,
* добавлять новые точки к квадрату,
* манипулировать его точками.

Эти операции можно применять к любой фигуре. С помощью **Edit Points** вы можете изменить форму или создать новую на основе существующей формы.

## **Советы по редактированию фигур**

![Команда "Edit Points"](custom_shape_0.png)

Прежде чем начать редактировать фигуры PowerPoint с помощью **Edit Points**, учитывайте следующие замечания о фигурах:

* Фигура (или её контур) может быть **закрытой** или **открытой**.
* Закрытая фигура не имеет начальной или конечной точки; открытая фигура имеет начало и конец.
* Каждая фигура имеет как минимум две опорные точки, соединённые отрезками.
* Отрезок может быть прямым или изогнутым; опорные точки определяют характер отрезка.
* Опорные точки могут быть **угловыми**, **плавными** или **прямыми**:
  * Точка **угловая** — это место, где два прямых отрезка встречаются под углом.
  * Точка **плавная** имеет две ручки, лежащие на одной линии, и прилегающие отрезки образуют плавную кривую. При этом обе ручки находятся на одинаковом расстоянии от опорной точки.
  * Точка **прямая** также имеет две коллинеарные ручки, и прилегающие отрезки образуют плавную кривую. В этом случае ручки не обязаны находиться на одинаковом расстоянии от опорной точки.
* Перемещая или редактируя опорные точки (тем самым изменяя углы отрезков), вы можете менять внешний вид фигуры.

Чтобы редактировать фигуры PowerPoint, Aspose.Slides предоставляет класс [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Объект [GeometryPath] представляет геометрический путь [GeometryShape] объекта.
* Чтобы получить [GeometryPath] из экземпляра [GeometryShape], используйте метод [GeometryShape.get_geometry_paths].
* Для установки [GeometryPath] для фигуры используйте [GeometryShape.set_geometry_path] для *solid shapes* и [GeometryShape.set_geometry_paths] для *composite shapes*.
* Для добавления отрезков используйте методы класса [GeometryPath].
* Используйте свойства [GeometryPath.stroke] и [GeometryPath.fill_mode] для управления внешним видом геометрического пути.
* Используйте свойство [GeometryPath.path_data] для получения геометрического пути фигуры в виде массива отрезков пути.

## **Простые операции редактирования**

Следующие методы используются для простых операций редактирования.

**Добавить линию** в конец пути:
```py
line_to(point)
line_to(x, y)
```


**Добавить линию** в указанной позиции пути:
```py    
line_to(point, index)
line_to(x, y, index)
```


**Добавить кубическую кривую Безье** в конец пути:
```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```


**Добавить кубическую кривую Безье** в указанной позиции пути:
```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```


**Добавить квадратичную кривую Безье** в конец пути:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```


**Добавить квадратичную кривую Безье** в указанной позиции пути:
```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```


**Добавить дугу** к пути:
```py
arc_to(width, heigth, startAngle, sweepAngle)
```


**Закрыть текущую фигуру** в пути:
```py
close_figure()
```


**Установить позицию для следующей точки**:
```py
move_to(point)
move_to(x, y)
```


**Удалить сегмент пути** по заданному индексу:
```py
remove_at(index)
```


## **Добавить пользовательские точки к фигурам**

Здесь вы узнаете, как определить произвольную форму, добавляя собственную последовательность точек. Указывая упорядоченные точки и типы отрезков (прямые или изогнутые) и, при необходимости, закрывая путь, вы можете рисовать точные пользовательские графические элементы — многоугольники, значки, выноски или логотипы — непосредственно на слайдах.

1. Создайте экземпляр класса [GeometryShape] и задайте ему [ShapeType.RECTANGLE].
2. Получите экземпляр [GeometryPath] из фигуры.
3. Вставьте новую точку между двумя верхними точками пути.
4. Вставьте новую точку между двумя нижними точками пути.
5. Примените обновлённый путь к фигуре.

Следующий код на Python показывает, как добавить пользовательские точки к фигуре:
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

##  **Удалить точки из фигур**

Иногда пользовательская фигура содержит лишние точки, усложняющие её геометрию или влияющие на отображение. В этом разделе показано, как удалить конкретные точки из пути фигуры, чтобы упростить контур и достичь более чистых, точных результатов.

1. Создайте экземпляр класса [GeometryShape] и задайте ему тип [ShapeType.HEART].
2. Получите экземпляр [GeometryPath] из фигуры.
3. Удалите сегмент из пути.
4. Примените обновлённый путь к фигуре.

Следующий код на Python показывает, как удалить точки из фигуры:
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

##  **Создать пользовательские фигуры**

Создавайте индивидуальные векторные фигуры, определяя [GeometryPath] и составляя её из линий, дуг и кривых Безье. В этом разделе показано, как построить пользовательскую геометрию с нуля и добавить получившуюся фигуру на слайд.

1. Вычислите точки для фигуры.
2. Создайте экземпляр класса [GeometryPath].
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape].
5. Примените путь к фигуре.

Следующий код на Python показывает, как создать пользовательскую фигуру:
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

## **Создать составные пользовательские фигуры**

Создание составной пользовательской фигуры позволяет объединить несколько геометрических путей в одну, переиспользуемую фигуру на слайде. Определите и объедините эти пути, чтобы построить сложные визуальные элементы, выходящие за рамки стандартного набора фигур.

1. Создайте экземпляр класса [GeometryShape].
2. Создайте первый экземпляр класса [GeometryPath].
3. Создайте второй экземпляр класса [GeometryPath].
4. Примените оба пути к фигуре.

Следующий код на Python показывает, как создать составную пользовательскую фигуру:
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

## **Создать пользовательские фигуры со скруглёнными углами**

В этом разделе показано, как нарисовать пользовательскую фигуру со сглаженными скруглёнными углами, используя геометрический путь. Вы комбинируете прямые отрезки и круговые дуги, чтобы сформировать контур, и добавите готовую фигуру на слайд.

Следующий код на Python показывает, как создать пользовательскую фигуру со скруглёнными углами:
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


![Скруглённые углы](custom_shape_6.png)

## **Определить, является ли геометрия фигуры замкнутой**

Замкнутая фигура определяется как такая, где все её стороны соединены, образуя единую границу без пробелов. Такая фигура может быть простой геометрической формой или сложным пользовательским контуром. Следующий пример кода показывает, как проверить, является ли геометрия фигуры замкнутой:
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

**Что произойдёт с заливкой и контуром после замены геометрии?**

Стиль остаётся привязанным к фигуре; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую фигуру вместе с её геометрией?**

Используйте свойство [rotation] фигуры; геометрия вращается вместе с фигурой, поскольку привязана к собственной системе координат фигуры.

**Можно ли преобразовать пользовательскую фигуру в изображение, чтобы “зафиксировать” результат?**

Да. Экспортируйте необходимую область [slide](/slides/ru/python-net/convert-powerpoint-to-png/) или саму [shape](/slides/ru/python-net/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу с тяжёлыми геометриями.