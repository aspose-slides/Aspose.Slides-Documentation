---
title: Управление коннекторами в презентациях с помощью Python
linktitle: Коннектор
type: docs
weight: 10
url: /ru/python-net/connector/
keywords:
- коннектор
- тип коннектора
- точка коннектора
- линия коннектора
- угол коннектора
- точка соединения
- точка регулировки
- соединять фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как добавлять, прикреплять, переориентировать, регулировать и исследовать прямые, сгибные и изогнутые коннекторы PowerPoint с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Коннектор – это линия, которая может оставаться привязанной к двум фигурам, когда любая из фигур перемещается. Его концы привязываются к точкам соединения, которые отображаются зелёными точками в PowerPoint. Некоторые изогнутые и сгибные коннекторы также имеют точки регулировки, обозначенные оранжевыми точками, которые управляют положением отдельных сегментов коннектора.

Aspose.Slides представляет коннекторы через интерфейс [IConnector](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iconnector/). Вы можете создавать их, привязывать их концы к фигурам, выбирать точки соединения, переориентировать их и изменять геометрию коннекторов, имеющих точки регулировки.

## **Типы коннекторов**

Перечисление [ShapeType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapetype/) включает предустановки прямых, сгибных и изогнутых коннекторов. В таблице ниже показаны доступные геометрии коннекторов и количество точек регулировки, определённое для каждой предустановки.

| Коннектор | Изображение | Количество точек регулировки |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Количество и смысл точек регулировки являются частью выбранной предустановки коннектора. Не следует предполагать, что два разных типа коннекторов имеют одинаковую структуру коллекции.

## **Соединение двух фигур**

Для добавления коннектора используйте [IShapeCollection.add_connector](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapecollection/add_connector/), а затем задайте его свойства [start_shape_connected_to](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iconnector/start_shape_connected_to/) и [end_shape_connected_to](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iconnector/end_shape_connected_to/). После привязки обоих концов вызов [IConnector.reroute](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iconnector/reroute/) выбирает короткий путь между фигурами.

Ниже приведён пример, который соединяет эллипс и прямоугольник с помощью сгибного коннектора:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}

Вызов `reroute` может изменить значения [start_shape_connection_site_index](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) и [end_shape_connection_site_index](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iconnector/end_shape_connection_site_index/). После переориентирования назначьте конкретные точки соединения, если они должны оставаться фиксированными.

{{% /alert %}}

## **Выбор точки соединения**

Каждая соединяемая фигура сообщает количество своих точек через [connection_site_count](https://reference.aspose.com/slides/ru/python-net/aspose.slides/igeometryshape/connection_site_count/). Перед привязкой к коннектору проверьте предпочтительный нулевой индекс точки; количество точек различается в зависимости от геометрии фигуры.

В этом примере коннектор привязывается к определённой точке эллипса, если такая точка существует:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировка точки коннектора**

Коннекторы с точками регулировки предоставляют их через [IGeometryShape.adjustments](https://reference.aspose.com/slides/ru/python-net/aspose.slides/igeometryshape/adjustments/). Просмотрите каждый [IAdjustValue](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iadjustvalue/) и проверьте его [type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iadjustvalue/type/) перед изменением [raw_value](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iadjustvalue/raw_value/). Для общей работы с фигурами см. [Shape Manipulation](/slides/ru/python-net/shape-manipulations/).

Количество, порядок, смысл и допустимый диапазон значений регулировки зависят от предустановки коннектора. Свойство `type` доступно только для чтения, а значение регулировки можно изменять. Свойство только для чтения [name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iadjustvalue/name/) предоставляет дополнительную идентификацию, когда у коннектора несколько регулировок одного и того же семантического типа.

### **Обход препятствия**

На следующей схеме коннектор `ShapeType.BENT_CONNECTOR5` между двумя фигурами проходит через третью фигуру:

![connector-obstruction](connector-obstruction.png)

Этот код создаёт «заблокированный» коннектор:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Перемещение вертикального сгиба меняет маршрут, так что коннектор обходит препятствие:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Вместо предположения, что элемент коллекции с индексом `1` всегда представляет вертикальный сгиб, пример ищет `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` и изменяет его только при наличии ожидаемого семантического типа:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

У `ShapeType.BENT_CONNECTOR5` есть два регулировочных параметра `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` и один `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`. Если нужный тип встречается более одного раза, проверьте `name` и известную геометрию предустановки перед выбором. Если регулировка имеет тип [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapeadjustmenttype/), рассматривайте её смысл и диапазон как специфичные для предустановки и не меняйте её, пока не будет известен соответствующий контракт.

## **Связь значений регулировки с геометрией коннектора**

Для сгибных коннекторов значения регулировки можно использовать для оценки положения отдельных сегментов. Эти расчёты зависят от предустановки коннектора:

- `ShapeType.BENT_CONNECTOR4` обычно предоставляет одну регулировку `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` и одну `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`.
- Для этих позиций сгиба `raw_value / 100000` даёт долю ширины или высоты кадра коннектора, использованную в примерах ниже.
- Кадр коннектора может быть повернут или отражён, поэтому координаты кадра необходимо преобразовать перед сравнением с координатами слайда.

Ниже приведён пример, который сначала определяет тип регулировки через `type`. Индексы коллекции не рассматриваются как переносимые идентификаторы.

### **Неповернутый коннектор**

Исходная схема содержит два текстовых объекта, соединённых `ShapeType.BENT_CONNECTOR4`:

![connector-shape-complex](connector-shape-complex.png)

Этот пример исследует коннектор и получает его горизонтальные и вертикальные регулировки сгиба:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Чтобы изменить оба сгиба, найдите каждый ожидаемый тип и измените значения только после того, как оба будут найдены:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

В результате коннектор получает перемещённые горизонтальные и вертикальные сегменты:

![connector-adjusted-1](connector-adjusted-1.png)

После определения семантических типов их значения можно преобразовать в координаты кадра коннектора. Этот пример рисует тонкий прямоугольник над вертикальным сегментом, управляемым двумя регулировками сгиба:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Фигура‑направляющая отмечает вычисленный сегмент:

![connector-adjusted-2](connector-adjusted-2.png)

### **Повернутый или отражённый коннектор**

Когда та же геометрия коннектора ориентирована вертикально, её свойства [frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapeframe/flip_h/) и [flip_v](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapeframe/flip_v/) влияют на преобразование координат кадра коннектора в координаты слайда.

Этот пример создаёт и регулирует вертикально ориентированный коннектор:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Отрегулированный коннектор отображается вертикально между фигурами:

![connector-adjusted-3](connector-adjusted-3.png)

Для произвольного угла вращения `alpha` вращайте точку кадра коннектора `(x, y)` вокруг его центра `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Следующий код обрабатывает ориентацию на 90 градусов, использованную в этом примере, и рисует красную направляющую над соответствующим сегментом коннектора:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Красная направляющая отмечает вычисленный сегмент после преобразования координат:

![connector-adjusted-4](connector-adjusted-4.png)

Эти формулы описывают предустановки, использованные в примерах, а не универсальную модель коннектора. Перед применением того же расчёта к другой предустановке проверьте типы регулировки, ориентацию кадра и диапазоны значений.

## **Определение угла направления коннектора**

Направление прямого коннектора можно вычислить из его ширины и высоты с учётом горизонтального и вертикального отражения. Ниже пример, который выводит угол по часовой стрелке от положительной горизонтальной оси в координатах слайда:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**Как определить, может ли коннектор присоединяться к фигуре?**

Проверьте [connection_site_count](https://reference.aspose.com/slides/ru/python-net/aspose.slides/igeometryshape/connection_site_count/) фигуры. Положительное значение означает, что фигура имеет точки соединения. Перед привязкой к коннектору проверьте выбранный индекс точки.

**Можно ли идентифицировать регулировку коннектора по её индексу в коллекции?**

Индекс имеет смысл только для известной предустановки коннектора и известного расположения коллекции. Проверьте [IAdjustValue.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iadjustvalue/type/) перед изменением значения и используйте [IAdjustValue.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iadjustvalue/name/) как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.

**Что происходит, когда подключённая фигура удаляется?**

Соответствующий конец коннектора отсоединяется. Коннектор остаётся на слайде и может быть удалён, перемещён как свободная линия или привязан к другой фигуре.

**Сохраняются ли привязки коннектора при копировании слайда?**

Привязки обычно сохраняются, когда копируются соединённые фигуры вместе со слайдом. Если коннектор копируется без одной из целевых фигур, необходимо вновь привязать затронутый конец.