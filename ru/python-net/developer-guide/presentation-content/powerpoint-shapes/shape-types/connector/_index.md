---
title: Коннектор
type: docs
weight: 10
url: /python-net/connector/
keywords: "Соединять фигуры, коннекторы, фигуры PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Соединять фигуры PowerPoint на Python"
---

Коннектор PowerPoint — это специальная линия, которая соединяет или связывает две фигуры вместе и остается прикрепленной к фигурам, даже когда они перемещаются или изменяют свое положение на данном слайде.

Коннекторы, как правило, соединены с *точками подключения* (зелеными точками), которые по умолчанию существуют на всех фигурах. Точки подключения появляются, когда курсор приближается к ним.

*Точки регулировки* (оранжевые точки), которые существуют только на определенных коннекторах, используются для изменения положения и формы коннекторов.

## **Типы коннекторов**

В PowerPoint вы можете использовать прямые, угловые (изогнутые) и кривые коннекторы.

Aspose.Slides предоставляет эти коннекторы:

| Коннектор                      | Изображение                                                    | Количество точек регулировки |
| ------------------------------ | ------------------------------------------------------------ | ----------------------------- |
| `ShapeType.LINE`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                             |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                             |
| `ShapeType.BENT_CONNECTOR2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                             |
| `ShapeType.BENT_CONNECTOR3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                             |
| `ShapeType.BENT_CONNECTOR4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                             |
| `ShapeType.BENT_CONNECTOR5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                             |
| `ShapeType.CURVED_CONNECTOR2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                             |
| `ShapeType.CURVED_CONNECTOR3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                             |
| `ShapeType.CURVED_CONNECTOR4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                             |
| `ShapeType.CURVED_CONNECTOR5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                             |

## **Соединение фигур с помощью коннекторов**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд, используя метод `add_auto_shape`, предоставленный объектом `Shapes`.
1. Добавьте коннектор, используя метод `add_auto_shape`, предоставленный объектом `Shapes`, определив тип коннектора.
1. Соедините фигуры, используя коннектор.
1. Вызовите метод `reroute`, чтобы применить самый короткий путь подключения.
1. Сохраните презентацию.

Этот код на Python показывает, как добавить коннектор (изогнутый коннектор) между двумя фигурами (эллипс и прямоугольник):

```python
import aspose.slides as slides

# Создает экземпляр класса презентации, который представляет PPTX-файл
with slides.Presentation() as input:
    # Получает доступ к коллекции фигур для конкретного слайда
    shapes = input.slides[0].shapes

    # Добавляет Эллипс
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Добавляет Прямоугольник
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # Добавляет коннектор к коллекции фигур
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Соединяет фигуры с помощью коннектора
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Вызывает reroute, который устанавливает автоматический самый короткий путь между фигурами
    connector.reroute()

    # Сохраняет презентацию
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)

```

{{%  alert title="ПРИМЕЧАНИЕ"  color="warning"   %}} 

Метод `connector.reroute` перенастраивает коннектор и заставляет его следовать по самому короткому возможному пути между фигурами. Чтобы достичь своей цели, метод может изменить точки `start_shape_connection_site_index` и `end_shape_connection_site_index`.

{{% /alert %}} 

## **Указать точку подключения**

Если вы хотите, чтобы коннектор соединял две фигуры, используя конкретные точки на фигурах, вы должны указать свои предпочтительные точки подключения следующим образом:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Добавьте две [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд, используя метод `add_auto_shape`, предоставленный объектом `Shapes`.
1. Добавьте коннектор, используя метод `add_connector`, предоставленный объектом `Shapes`, определив тип коннектора.
1. Соедините фигуры, используя коннектор.
1. Установите ваши предпочтительные точки подключения на фигурах.
1. Сохраните презентацию.

Этот код на Python демонстрирует операцию, где указывается предпочтительная точка подключения:

```python
import aspose.slides as slides

# Создает экземпляр класса презентации, который представляет PPTX-файл
with slides.Presentation() as presentation:
    # Получает доступ к коллекции фигур для конкретного слайда
    shapes = presentation.slides[0].shapes

    # Добавляет коннектор к коллекции фигур на слайде
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Добавляет Эллипс
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Добавляет Прямоугольник
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # Соединяет фигуры с помощью коннектора
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Устанавливает индекс предпочтительной точки подключения на фигуре Эллипс
    wantedIndex = 6

    # Проверяет, меньше ли предпочтительный индекс максимального количества точек подключения
    if ellipse.connection_site_count > wantedIndex:
        # Устанавливает предпочтительную точку подключения на Эллипсе
        connector.start_shape_connection_site_index = wantedIndex

    # Сохраняет презентацию
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Регулировка точки коннектора**

Вы можете отрегулировать существующий коннектор через его точки регулировки. Только коннекторы с точками регулировки могут быть изменены таким образом. Смотрите таблицу в разделе **[Типы коннекторов.](/slides/python-net/connector/#types-of-connectors)** 

#### **Простой случай**

Рассмотрим случай, когда коннектор между двумя фигурами (A и B) проходит через третью фигуру (C):

![connector-obstruction](connector-obstruction.png)

Код:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

Чтобы избежать или обойти третью фигуру, мы можем отрегулировать коннектор, переместив его вертикальную линию влево следующим образом:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **Сложные случаи** 

Для выполнения более сложных исправлений вам нужно учитывать следующие моменты:

* Точка регулировки коннектора тесно связана с формулой, которая вычисляет и определяет ее положение. Поэтому изменения в местоположении точки могут изменить форму коннектора.
* Точки регулировки коннектора определяются в строгом порядке в массиве. Точки регулировки пронумерованы от начальной точки до конечной.
* Значения точек регулировки отражают процент ширины/высоты формы коннектора. 
  * Форма ограничена начальными и конечными точками коннектора, умноженными на 1000. 
  * Первая точка, вторая точка и третья точка определяют процент от ширины, процент от высоты и процент от ширины (снова) соответственно.
* Для расчетов, которые определяют координаты точек регулировки коннектора, необходимо учитывать вращение коннектора и его отражение. **Обратите внимание**, что угол вращения для всех коннекторов, показанных в разделе **[Типы коннекторов](/slides/python-net/connector/#types-of-connectors)**, равен 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстового фрейма соединены через коннектор:

![connector-shape-complex](connector-shape-complex.png)

Код:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создает экземпляр класса презентации, который представляет PPTX-файл
with slides.Presentation() as pres:
    # Получает первый слайд в презентации
    sld = pres.slides[0]
    # Добавляет фигуры, которые будут соединены через коннектор
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "От"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "К"
    # Добавляет коннектор
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Указывает направление коннектора
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Указывает цвет коннектора
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Указывает толщину линии коннектора
    connector.line_format.width = 3

    # Соединяет фигуры с помощью коннектора
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connection_site_index = 2

    # Получает точки регулировки для коннектора
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**Регулировка**

Мы можем изменить значения точек регулировки коннектора, увеличив соответствующий процент ширины и высоты на 20% и 200% соответственно:

```python
    # Изменяет значения точек регулировки
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

Результат:

![connector-adjusted-1](connector-adjusted-1.png)

Чтобы определить модель, позволяющую нам определить координаты и форму отдельных частей коннектора, давайте создадим фигуру, которая будет соответствовать горизонтальному компоненту коннектора в точке connector.adjustments[0]:

```python
    # Рисует вертикальный компонент коннектора

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Результат:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую операцию регулировки коннектора, используя основные принципы. В обычных ситуациях вам нужно учитывать вращение коннектора и его отображение (которые устанавливаются через connector.rotation, connector.frame.flip_h и connector.frame.flip_v). Теперь мы продемонстрируем процесс.

Сначала давайте добавим новый объект текстового фрейма (**К 1**) на слайд (для целей соединения) и создадим новый (зеленый) коннектор, который соединяет его с уже созданными объектами.

```python
    # Создает новый связывающий объект
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "К 1"
    # Создает новый коннектор
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # Соединяет объекты с помощью нового созданного коннектора
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connection_site_index = 3
    # Получает точки регулировки коннектора
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # Изменяет значения точек регулировки 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

Результат:

![connector-adjusted-3](connector-adjusted-3.png)

Во-вторых, давайте создадим фигуру, которая будет соответствовать горизонтальному компоненту коннектора, проходящего через точку регулировки нового коннектора connector.adjustments[0]. Мы будем использовать значения из данных коннектора для connector.rotation, connector.frame.flip_h и connector.frame.flip_v и применим популярную формулу преобразования координат для вращения вокруг заданной точки x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол объекта составляет 90 градусов, а коннектор отображается вертикально, поэтому вот соответствующий код:

```python
    # Сохраняет координаты коннектора
    x = connector.x
    y = connector.y
    # Корректирует координаты коннектора в случае, если он появляется
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Учитывает значение точки регулировки как координату
    x += connector.width * adjValue_0.raw_value / 100000
    
    #  Преобразует координаты, поскольку Sin(90) = 1 и Cos(90) = 0
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Определяет ширину горизонтального компонента с использованием значения второй точки регулировки
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Результат:

![connector-adjusted-4](connector-adjusted-4.png)

Мы продемонстрировали расчеты, связанные с простыми регулировками и сложными точками регулировки (точки регулировки с углами вращения). Используя полученные знания, вы можете разработать свою собственную модель (или написать код), чтобы получить объект `GraphicsPath` или даже установить значения точек регулировки коннектора на основе конкретных координат слайда.

## **Нахождение угла линий коннектора**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд через его индекс.
1. Получите доступ к форме линии коннектора.
1. Используйте ширину линии, высоту, высоту рамки формы и ширину рамки формы, чтобы вычислить угол.

Этот код на Python демонстрирует операцию, в которой мы вычислили угол для формы линии коннектора:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.Height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)

```