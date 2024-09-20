---
title: Пользовательская Форма
type: docs
weight: 20
url: /python-net/custom-shape/
keywords: "Форма PowerPoint, пользовательская форма, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление пользовательской формы в презентацию PowerPoint на Python"
---

# Изменение формы с помощью контрольных точек

Рассмотрим квадрат. В PowerPoint, с помощью **контрольных точек**, вы можете 

* перемещать угол квадрата внутрь или наружу
* задавать кривизну для угла или точки
* добавлять новые точки к квадрату
* манипулировать точками на квадрате и т.д. 

По сути, вы можете выполнять описанные задачи с любой фигурой. Используя контрольные точки, вы можете изменить фигуру или создать новую фигуру на основе существующей.

## Советы по редактированию фигур

![overview_image](custom_shape_0.png)

Перед тем, как начать редактирование фигур PowerPoint через контрольные точки, вам стоит учесть следующие моменты о формах:

* Фигура (или ее путь) может быть закрытой или открытой.
* Когда фигура закрыта, у нее нет начальной или конечной точки. Когда фигура открыта, у нее есть начало и конец.
* Все фигуры состоят как минимум из 2 якорных точек, связанных между собой линиями.
* Линия может быть прямой или изогнутой. Якорные точки определяют природу линии.
* Якорные точки существуют как угловые точки, простые точки или гладкие точки:
  * Угловая точка - это точка, где 2 прямые линии соединяются под углом.
  * Гладкая точка - это точка, где 2 ручки находятся на прямой линии, а сегменты линии соединяются плавной кривой. В этом случае все ручки отделены от якорной точки на равное расстояние.
  * Простая точка - это точка, где 2 ручки находятся на прямой линии, а сегменты линии соединяются плавной кривой. В этом случае ручки не обязательно должны быть отделены от якорной точки на равное расстояние.
* Перемещая или редактируя якорные точки (что меняет угол линий), вы можете изменить внешний вид фигуры.

Для редактирования фигур PowerPoint через контрольные точки, **Aspose.Slides** предоставляет класс [**GeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) и интерфейс [**IGeometryPath**](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) представляет собой геометрический путь объекта [IGeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/).
* Для получения `GeometryPath` из экземпляра `IGeometryShape`, вы можете использовать метод [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/).
* Чтобы установить `GeometryPath` для фигуры, вы можете использовать эти методы: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) для *сплошных фигур* и [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) для *композитных фигур*.
* Чтобы добавить сегменты, вы можете использовать методы, указанные в [IGeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/).
* Используя свойства [IGeometryPath.Stroke](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/) и [IGeometryPath.FillMode](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/), вы можете установить внешний вид для геометрического пути.
* Используя свойство [IGeometryPath.PathData](https://reference.aspose.com/slides/python-net/aspose.slides/igeometrypath/properties/pathdata), вы можете получить геометрический путь `GeometryShape` в виде массива сегментов пути.
* Чтобы получить доступ к дополнительным параметрам настройки геометрии формы, вы можете преобразовать [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) в [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* Используйте методы `GeometryPathToGraphicsPath` и `GraphicsPathToGeometryPath` (из класса [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/)) для преобразования `GeometryPath` в `GraphicsPath` и обратно.

## **Простые операции редактирования**

Этот код на Python показывает, как

**Добавить линию** в конец пути:

```py
line_to(point)
line_to(x, y)
```
**Добавить линию** в указанное положение на пути:

```py    
line_to(point, index)
line_to(x, y, index)
```
**Добавить кубическую кривую Безье** в конец пути:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```
**Добавить кубическую кривую Безье** в указанное положение на пути:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```
**Добавить квадратичную кривую Безье** в конец пути:
```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```
**Добавить квадратичную кривую Безье** в указанное положение на пути:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```
**Добавить заданный дуговой сегмент** к пути:
```py
arc_to(width, height, startAngle, sweepAngle)
```
**Закрыть текущую фигуру** пути:
```py
close_figure()
```
**Установить положение для следующей точки**:
```py
move_to(point)
move_to(x, y)
```
**Удалить сегмент пути** по указанному индексу:

```py
remove_at(index)
```
## Добавление пользовательских точек к фигуре
1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) и установите тип [ShapeType.Rectangle](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) из фигуры.
3. Добавьте новую точку между двумя верхними точками на пути.
4. Добавьте новую точку между двумя нижними точками на пути.
6. Примените путь к фигуре.

Этот код на Python показывает, как добавить пользовательские точки к фигуре:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    geometryPath = shape.get_geometry_paths()[0]

    geometryPath.line_to(100, 50, 1)
    geometryPath.line_to(100, 50, 4)
    shape.set_geometry_path(geometryPath)
```

![example1_image](custom_shape_1.png)

## Удаление точек из фигуры

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) и установите тип [ShapeType.Heart](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Получите экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) из фигуры.
3. Удалите сегмент для пути.
4. Примените путь к фигуре.

Этот код на Python показывает, как удалить точки из фигуры:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)
    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## Создание пользовательской фигуры

1. Вычислите точки для фигуры.
2. Создайте экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Заполните путь точками.
4. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
5. Примените путь к фигуре.

Этот код на Python показывает, как создать пользовательскую фигуру:

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

starPath = slides.GeometryPath()
starPath.move_to(points[0])

for i in range(len(points)):
    starPath.line_to(points[i])

starPath.close_figure()

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(starPath)
```
![example3_image](custom_shape_3.png)


## Создание составной пользовательской фигуры

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Создайте первый экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Создайте второй экземпляр класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
4. Примените пути к фигуре.

Этот код на Python показывает, как создать составную пользовательскую фигуру:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometryPath0 = slides.GeometryPath()
    geometryPath0.move_to(0, 0)
    geometryPath0.line_to(shape.width, 0)
    geometryPath0.line_to(shape.width, shape.height/3)
    geometryPath0.line_to(0, shape.height / 3)
    geometryPath0.close_figure()

    geometryPath1 = slides.GeometryPath()
    geometryPath1.move_to(0, shape.height/3 * 2)
    geometryPath1.line_to(shape.width, shape.height / 3 * 2)
    geometryPath1.line_to(shape.width, shape.height)
    geometryPath1.line_to(0, shape.height)
    geometryPath1.close_figure()

    shape.set_geometry_paths([geometryPath0, geometryPath1])
```
![example4_image](custom_shape_4.png)

## **Создание пользовательской фигуры с закругленными углами**

Этот код на Python показывает, как создать пользовательскую фигуру с закругленными углами (внутрь):

```py
import aspose.slides as slides
import aspose.pydrawing as draw

shapeX = 20
shapeY = 20
shapeWidth = 300
shapeHeight = 200

leftTopSize = 50
rightTopSize = 20
rightBottomSize = 40
leftBottomSize = 10

with slides.Presentation() as presentation:
    childShape = presentation.slides[0].shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shapeX, shapeY, shapeWidth, shapeHeight)

    geometryPath = slides.GeometryPath()

    point1 = draw.PointF(leftTopSize, 0)
    point2 = draw.PointF(shapeWidth - rightTopSize, 0)
    point3 = draw.PointF(shapeWidth, shapeHeight - rightBottomSize)
    point4 = draw.PointF(leftBottomSize, shapeHeight)
    point5 = draw.PointF(0, leftTopSize)

    geometryPath.move_to(point1)
    geometryPath.line_to(point2)
    geometryPath.arc_to(rightTopSize, rightTopSize, 180, -90)
    geometryPath.line_to(point3)
    geometryPath.arc_to(rightBottomSize, rightBottomSize, -90, -90)
    geometryPath.line_to(point4)
    geometryPath.arc_to(leftBottomSize, leftBottomSize, 0, -90)
    geometryPath.line_to(point5)
    geometryPath.arc_to(leftTopSize, leftTopSize, 90, -90)

    geometryPath.close_figure()

    childShape.set_geometry_path(geometryPath)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## Преобразование GeometryPath в GraphicsPath (System.Drawing.Drawing2D) 

1. Создайте экземпляр класса [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Создайте экземпляр класса [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) из пространства имен [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Преобразуйте экземпляр [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) в экземпляр [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) с помощью класса [ShapeUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/shapeutil/).
4. Примените пути к фигуре.

Этот код на Python — реализация вышеуказанных шагов — демонстрирует процесс преобразования **GeometryPath** в **GraphicsPath**:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 100)

    originalPath = shape.get_geometry_paths()[0]
    originalPath.fill_mode = slides.PathFillModeType.NONE

    gPath = draw.drawing2d.GraphicsPath()

    gPath.add_string("Text in shape", draw.FontFamily("Arial"), 1, 40, draw.PointF(10, 10), draw.StringFormat.generic_default)

    textPath = slides.util.ShapeUtil.graphics_path_to_geometry_path(gPath)
    textPath.fill_mode = slides.PathFillModeType.NORMAL

    shape.set_geometry_paths([originalPath, textPath])
```
![example5_image](custom_shape_5.png)