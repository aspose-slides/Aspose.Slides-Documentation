---
title: Manage Connectors in Presentations with Python
linktitle: Connector
type: docs
weight: 10
url: /ru/python-net/connector/
keywords:
- connector
- connector type
- connector point
- connector line
- connector angle
- connect shapes
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Empower Python apps to draw, connect and auto-route lines in PowerPoint & OpenDocument slides—gain full control over straight, elbow and curved connectors."
---

## **Введение**

Соединитель PowerPoint — это специализированная линия, связывающая две формы и остающаяся присоединённой, когда формы перемещаются или переориентируются на слайде. Соединители привязываются к **точкам соединения** (зеленые точки) на формах. Точки соединения появляются, когда указатель подходит к ним. **Ручки регулировки** (желтые точки), доступные для некоторых соединителей, позволяют изменять позицию и форму соединителя.

## **Типы соединителей**

В PowerPoint можно использовать три типа соединителей: прямой, сгиб (угловой) и изогнутый.

Aspose.Slides поддерживает следующие типы соединителей:

| Тип соединителя                  | Изображение                                                     | Количество точек регулировки |
| -------------------------------- | ---------------------------------------------------------------- | ---------------------------- |
| `ShapeType.LINE`                | ![Линейный соединитель](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Прямой соединитель 1](shapetype-straightconnector1.png)       | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![Изогнутый соединитель 2](shapetype-bent-connector2.png)       | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![Изогнутый соединитель 3](shapetype-bentconnector3.png)        | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![Изогнутый соединитель 4](shapetype-bentconnector4.png)        | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![Изогнутый соединитель 5](shapetype-bentconnector5.png)        | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![Кривой соединитель 2](shapetype-curvedconnector2.png)         | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![Кривой соединитель 3](shapetype-curvedconnector3.png)         | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![Кривой соединитель 4](shapetype-curvedconnector4.png)         | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![Кривой соединитель 5](shapetype.curvedconnector5.png)         | 3                           |

## **Соединять формы с помощью соединителей**

В этом разделе демонстрируется, как связывать формы соединителями в Aspose.Slides. Вы добавите соединитель на слайд, присоедините его начало и конец к целевым формам. Использование точек соединения гарантирует, что соединитель останется «приклеенным» к формам даже при их перемещении или изменении размеров.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд с помощью метода `add_auto_shape`, предоставляемого объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. Добавьте соединитель с помощью метода `add_connector`, предоставляемого объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), и укажите тип соединителя.
1. Соедините формы соединителем.
1. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию.

Ниже приведён пример кода на Python, показывающий, как добавить изогнутый соединитель между двумя формами (эллипсом и прямоугольником):

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Call reroute to set the shortest path.
    connector.reroute()

    # Save the presentation.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}

Метод `connector.reroute` перенаправляет соединитель, заставляя его принимать кратчайший возможный путь между формами. Для этого метод может изменить значения `start_shape_connection_site_index` и `end_shape_connection_site_index`.

{{% /alert %}}

## **Указать точки соединения**

В этом разделе объясняется, как присоединить соединитель к конкретной точке соединения на форме в Aspose.Slides. Таргетируя точные места соединения, вы можете контролировать маршрутизацию и расположение соединителя, получая чистые, предсказуемые диаграммы в своих презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд с помощью метода `add_auto_shape`, предоставляемого объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. Добавьте соединитель с помощью метода `add_connector` на объекте [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) и укажите тип соединителя.
1. Соедините формы соединителем.
1. Установите предпочтительные точки соединения на формах.
1. Сохраните презентацию.

Ниже пример кода на Python, демонстрирующий, как указать предпочтительную точку соединения:

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide's shape collection.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Set the preferred connection site index on the ellipse.
    site_index = 6

    # Check that the preferred index is within the available site count.
    if  ellipse.connection_site_count > site_index:
        # Assign the preferred connection site on the ellipse AutoShape.
        connector.start_shape_connection_site_index = site_index

    # Save the presentation.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировать точки соединителя**

Вы можете изменять соединители посредством их точек регулировки. Только соединители, которые раскрывают точки регулировки, могут быть отредактированы таким способом. Подробную информацию о поддерживаемых точках см. в таблице раздела [Типы соединителей](/slides/ru/python-net/connector/#connector-types).

### **Простой случай**

Рассмотрим случай, когда соединитель между двумя формами (A и B) пересекает третью форму (C):

![Перекрытие соединителя](connector-obstruction.png)

Пример кода:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Чтобы избежать пересечения с третьей формой, сместите вертикальный отрезок соединителя влево:

![Исправленное перекрытие соединителя](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Сложные случаи** 

Для более продвинутых регулировок рассмотрим следующее:

- Точка регулировки соединителя задаётся формулой, определяющей её положение. Изменение этой точки меняет форму соединителя в целом.
- Точки регулировки хранятся в строго упорядоченном массиве, нумеруемом от начала соединителя к его концу.
- Значения точек представляют проценты ширины/высоты формы соединителя.
  - Форма ограничена начальной и конечной точками соединителя и масштабируется по коэффициенту 1000.
  - Первая, вторая и третья точки представляют соответственно: процент ширины, процент высоты и снова процент ширины.
- При вычислении координат точек необходимо учитывать вращение и отражение соединителя. **Примечание:** Для всех соединителей, перечисленных в разделе [Типы соединителей](/slides/ru/python-net/connector/#connector-types), угол вращения равен 0.

#### **Случай 1**

Рассмотрим ситуацию, когда два объекта текстового кадра соединены соединителем:

![Связанные формы](connector-shape-complex.png)

Пример кода:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Get the first slide.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Add a connector.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Set the connector's direction.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Set the connector's color.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Set the connector's line thickness.
    connector.line_format.width = 3

    # Link the shapes with the connector.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Get the connector's adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Регулировка**

Измените значения точек регулировки соединителя, увеличив процент ширины на 20 % и процент высоты на 200 %:

```python
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Результат:

![Регулировка соединителя 1](connector-adjusted-1.png)

Чтобы определить модель, позволяющую вычислить координаты и форму сегментов соединителя, создайте форму, соответствующую вертикальному компоненту соединителя при `connector.adjustments[0]`:

```python
    # Draw the vertical component of the connector.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Результат:

![Регулировка соединителя 2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую регулировку соединителя на основе базовых принципов. В типичных сценариях необходимо учитывать вращение соединителя и его параметры отображения (управляемые свойствами `connector.rotation`, `connector.frame.flip_h` и `connector.frame.flip_v`). Ниже показан процесс.

Сначала добавим новый объект текстового кадра (**To 1**) на слайд (для соединения) и создадим новый зелёный соединитель, связывающий его с существующими объектами.

```python
    # Create a new target object.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Create a new connector.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Connect the objects using the newly created connector.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Get the connector adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Результат:

![Регулировка соединителя 3](connector-adjusted-3.png)

Затем создаём форму, соответствующую **горизонтальному** сегменту соединителя, проходящему через новую точку регулировки `connector.adjustments[0]`. Используем значения `connector.rotation`, `connector.frame.flip_h` и `connector.frame.flip_v`, а также стандартную формулу преобразования координат при вращении вокруг точки `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта = 90° и соединитель отображается вертикально, поэтому код выглядит так:

```python
    # Save the connector coordinates.
    x = connector.x
    y = connector.y
    
    # Correct the connector coordinates if it is flipped.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Use the adjustment point value as the coordinate.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Convert the coordinates because sin(90°) = 1 and cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determine the width of the horizontal segment using the second adjustment point value.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Результат:

![Регулировка соединителя 4](connector-adjusted-4.png)

Мы продемонстрировали вычисления как простых, так и более сложных точек регулировки (учитывающих вращение). На основе этих знаний вы можете построить собственную модель — или написать код — для получения объекта `GraphicsPath` либо установки значений точек регулировки соединителя в зависимости от конкретных координат слайда.

## **Найти углы линий соединителей**

Используйте пример ниже, чтобы определить угол линий соединителей на слайде с помощью Aspose.Slides. Вы узнаете, как считывать конечные точки соединителя и вычислять его ориентацию, чтобы точно выравнивать стрелки, подписи и другие формы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по индексу.
1. Доступ к форме линии соединителя.
1. Используйте ширину и высоту линии, а также ширину и высоту рамки формы, чтобы вычислить угол.

Ниже пример кода на Python, демонстрирующий, как вычислить угол для формы линии соединителя:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Как определить, может ли соединитель «приклеиваться» к конкретной форме?**

Проверьте, раскрывает ли форма [точки соединения](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). Если их нет или их количество равно 0, приклеивание недоступно; в этом случае используйте свободные концы и позиционируйте их вручную. Рекомендуется проверять количество точек перед присоединением.

**Что происходит с соединителем, если удалить одну из подключённых форм?**

Концы отсоединятся; соединитель останется на слайде как обычная линия со свободными началом/концом. Вы можете либо удалить его, либо переназначить соединения и, при необходимости, вызвать [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**Сохраняются ли привязки соединителей при копировании слайда в другую презентацию?**

Как правило, да, при условии, что копируются и целевые формы. Если слайд вставляется в другой файл без подключённых форм, концы становятся свободными, и их нужно будет заново прикрепить.