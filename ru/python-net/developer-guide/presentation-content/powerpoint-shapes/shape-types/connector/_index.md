---
title: Управление соединителями в презентациях с помощью Python
linktitle: Соединитель
type: docs
weight: 10
url: /ru/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/connector/
keywords:
- соединитель
- тип соединителя
- точка соединения
- линия соединителя
- угол соединителя
- соединять формы
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Позвольте приложениям Python рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint и OpenDocument — получайте полный контроль над прямыми, сгибными и изогнутыми соединителями."
---

## **Введение**

Соединитель PowerPoint — это специализированная линия, связывающая две формы и остающаяся прикреплённой, когда формы перемещаются или переустанавливаются на слайде. Соединители присоединяются к **точкам соединения** (зеленые точки) на формах. Точки соединения появляются, когда указатель к ним приближается. **Рукоятки регулировки** (желтые точки), доступные на некоторых соединителях, позволяют изменять положение и форму соединителя.

## **Типы соединителей**

В PowerPoint можно использовать три типа соединителей: прямой, сгибной (угловой) и изогнутый.

Aspose.Slides поддерживает следующие типы соединителей:

| Тип соединителя                  | Image                                                     | Количество точек настройки |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                | ![Линейный соединитель](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Прямой соединитель 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![Сгибной соединитель 2](shapetype-bent-connector2.png)        | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![Сгибной соединитель 3](shapetype-bentconnector3.png)         | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![Сгибной соединитель 4](shapetype-bentconnector4.png)         | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![Сгибной соединитель 5](shapetype-bentconnector5.png)         | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![Изогнутый соединитель 2](shapetype-curvedconnector2.png)     | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![Изогнутый соединитель 3](shapetype-curvedconnector3.png)     | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![Изогнутый соединитель 4](shapetype-curvedconnector4.png)     | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![Изогнутый соединитель 5](shapetype.curvedconnector5.png)     | 3                           |

## **Соединение форм с помощью соединителей**

В этом разделе показано, как соединять формы с помощью соединителей в Aspose.Slides. Вы добавите соединитель на слайд, присоедините его начало и конец к целевым формам. Использование точек соединения гарантирует, что соединитель останется «приклеенным» к формам даже при их перемещении или изменении размеров.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд, используя метод `add_auto_shape`, предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Добавьте соединитель, используя метод `add_connector`, предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), и укажите тип соединителя.
5. Соедините формы с помощью соединителя.
6. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
7. Сохраните презентацию.

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

Метод `connector.reroute` перенаправляет соединитель, заставляя его выбрать кратчайший возможный путь между формами. Для этого метод может изменить значения `start_shape_connection_site_index` и `end_shape_connection_site_index`.

{{% /alert %}}

## **Указание точек соединения**

В этом разделе объясняется, как присоединить соединитель к определённой точке соединения на форме в Aspose.Slides. Выбирая точные точки соединения, вы можете управлять маршрутизацией и расположением соединителя, создавая чистые, предсказуемые диаграммы в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд, используя метод `add_auto_shape`, предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Добавьте соединитель, используя метод `add_connector` на объекте [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) и укажите тип соединителя.
5. Соедините формы с помощью соединителя.
6. Установите желаемые точки соединения на формах.
7. Сохраните презентацию.

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

## **Регулирование точек соединителя**

Вы можете изменять соединители, используя их точки настройки. Только соединители, которые предоставляют точки настройки, могут быть изменены таким способом. Подробности о том, какие соединители поддерживают настройки, см. в таблице раздела [Connector Types](/slides/ru/python-net/connector/#connector-types).

### **Простой случай**

Рассмотрим случай, когда соединитель между двумя формами (A и B) пересекает третью форму (C):

![Перекрытие соединителя](connector-obstruction.png)

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

Чтобы избежать третьей формы, подкорректируйте соединитель, переместив его вертикальный сегмент влево:

![Исправленное перекрытие соединителя](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Сложные случаи** 

Для более сложных настроек рассмотрите следующее:

- Регулируемая точка соединителя определяется формулой, задающей её положение. Изменение этой точки может изменить общую форму соединителя.
- Точки настройки соединителя хранятся в строго упорядоченном массиве, нумерованном от начала соединителя до его конца.
- Значения точек настройки представляют проценты ширины/высоты формы соединителя.  
  - Форма ограничивается начальной и конечной точками соединителя и масштабируется на 1000.  
  - Первая, вторая и третья точки настройки представляют соответственно: процент ширины, процент высоты и снова процент ширины.
- При вычислении координат точек настройки учитывайте вращение и отражение соединителя. **Примечание:** Для всех соединителей, перечисленных в разделе [Connector Types](/slides/ru/python-net/connector/#connector-types), угол вращения равен 0.

#### **Случай 1**

Рассмотрим случай, когда два объекта текстовых фреймов соединены соединителем:

![Связанные формы](connector-shape-complex.png)

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

Измените значения точек настройки соединителя, увеличив процент ширины на 20 % и процент высоты на 200 % соответственно:

```python
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Результат:

![Настройка соединителя 1](connector-adjusted-1.png)

Для определения координат и формы сегментов соединителя создайте форму, соответствующую вертикальному компоненту соединителя при `connector.adjustments[0]`:

```python
    # Draw the vertical component of the connector.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Результат:

![Настройка соединителя 2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую регулировку соединителя, используя базовые принципы. В типовых сценариях необходимо учитывать вращение соединителя и его параметры отображения (управляемые `connector.rotation`, `connector.frame.flip_h` и `connector.frame.flip_v`). Ниже показан процесс.

Сначала добавьте новый объект текстового фрейма (**To 1**) на слайд (для соединения) и создайте новый зелёный соединитель, который соединит его с существующими объектами.

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

![Настройка соединителя 3](connector-adjusted-3.png)

Затем создайте форму, соответствующую **горизонтальному** сегменту соединителя, проходящему через новую точку настройки `connector.adjustments[0]`. Используйте значения из `connector.rotation`, `connector.frame.flip_h` и `connector.frame.flip_v` и примените стандартную формулу преобразования координат при вращении вокруг заданной точки `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта = 90°, а соединитель отображается вертикально, поэтому соответствующий код выглядит так:

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

![Настройка соединителя 4](connector-adjusted-4.png)

Мы продемонстрировали расчёты, включающие простые и более сложные точки настройки (учитывающие вращение). Используя эти знания, вы можете разработать собственную модель — или написать код — для получения объекта `GraphicsPath` или даже задать значения точек настройки соединителя, исходя из конкретных координат слайда.

## **Определение углов линии соединителя**

Используйте пример ниже, чтобы определить угол линии соединителя на слайде с помощью Aspose.Slides. Вы узнаете, как считывать концевые точки соединителя и вычислять его ориентацию, чтобы точно выравнивать стрелки, подписи и другие формы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Получите форму линии соединителя.
4. Используйте ширину и высоту линии, а также ширину и высоту рамки формы, чтобы вычислить угол.

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

**Как узнать, может ли соединитель быть «приклеен» к конкретной форме?**  
Проверьте, предоставляет ли форма [точки соединения](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). Если их нет или их количество равно нулю, возможность «приклеить» недоступна; в этом случае используйте свободные концевые точки и позиционируйте их вручную. Рекомендуется проверять количество точек перед присоединением.

**Что происходит с соединителем, если я удаляю одну из связанных форм?**  
Концы соединителя будут отсоединены; соединитель останется на слайде как обычная линия с свободным началом/концом. Вы можете либо удалить его, либо переназначить соединения и, при необходимости, вызвать [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**Сохраняются ли привязки соединителей при копировании слайда в другую презентацию?**  
Как правило, да, при условии, что копируются и целевые формы. Если слайд вставляется в другой файл без связанных форм, концы становятся свободными, и их необходимо вновь прикрепить.