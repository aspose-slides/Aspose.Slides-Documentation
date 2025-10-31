---
title: Управление соединителями в презентациях с помощью Python
linktitle: Соединитель
type: docs
weight: 10
url: /ru/python-net/connector/
keywords:
- соединитель
- тип соединителя
- точка соединения
- линия соединителя
- угол соединителя
- соединить фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Позволяет Python‑приложениям рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint и OpenDocument — получайте полный контроль над прямыми, угловыми и изогнутыми соединителями."
---

## **Введение**

Соединитель PowerPoint — это специализированная линия, связывающая две фигуры и остающаяся привязанной, когда фигуры перемещаются или переустанавливаются на слайде. Соединители прикрепляются к **точкам соединения** (зеленые точки) на фигурах. Точки соединения появляются, когда указатель приближается к ним. **Ручки регулировки** (желтые точки), доступные у некоторых соединителей, позволяют изменять положение и форму соединителя.

## **Типы соединителей**

В PowerPoint можно использовать три типа соединителей: прямой, угловой (с изгибом) и изогнутый.

Aspose.Slides поддерживает следующие типы соединителей:

| Тип соединителя                  | Изображение                                                     | Кол‑во точек регулировки |
| -------------------------------- | --------------------------------------------------------------- | ------------------------ |
| `ShapeType.LINE`                | ![Line connector](shapetype-lineconnector.png)                | 0                        |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Straight connector 1](shapetype-straightconnector1.png)      | 0                        |
| `ShapeType.BENT_CONNECTOR2`     | ![Bent connector 2](shapetype-bent-connector2.png)            | 0                        |
| `ShapeType.BENT_CONNECTOR3`     | ![Bent connector 3](shapetype-bentconnector3.png)             | 1                        |
| `ShapeType.BENT_CONNECTOR4`     | ![Bent connector 4](shapetype-bentconnector4.png)             | 2                        |
| `ShapeType.BENT_CONNECTOR5`     | ![Bent connector 5](shapetype-bentconnector5.png)             | 3                        |
| `ShapeType.CURVED_CONNECTOR2`   | ![Curved connector 2](shapetype-curvedconnector2.png)         | 0                        |
| `ShapeType.CURVED_CONNECTOR3`   | ![Curved connector 3](shapetype-curvedconnector3.png)         | 1                        |
| `ShapeType.CURVED_CONNECTOR4`   | ![Curved connector 4](shapetype-curvedconnector4.png)         | 2                        |
| `ShapeType.CURVED_CONNECTOR5`   | ![Curved connector 5](shapetype.curvedconnector5.png)         | 3                        |

## **Соединение фигур с помощью соединителей**

В этом разделе демонстрируется, как связывать фигуры соединителями в Aspose.Slides. Вы добавите соединитель на слайд, прикрепите его начало и конец к целевым фигурам. Использование точек соединения гарантирует, что соединитель останется «приклеенным» к фигурам даже при их перемещении или изменении размера.

1. Создайте экземпляр класса [Presentation]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/presentation/" >}}).
1. Получите ссылку на слайд по его индексу.
1. Добавьте два объекта [AutoShape]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/" >}}) на слайд, используя метод `add_auto_shape` объекта [ShapeCollection]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/" >}}).
1. Добавьте соединитель, используя метод `add_connector` того же объекта [ShapeCollection] и указав тип соединителя.
1. Соедините фигуры соединителем.
1. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
1. Сохраните презентацию.

Ниже показан Python‑код, добавляющий изогнутый соединитель между двумя фигурами (эллипсом и прямоугольником):

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation для создания PPTX файла.
with slides.Presentation() as presentation:

    # Получить коллекцию фигур первого слайда.
    shapes = presentation.slides[0].shapes

    # Добавить AutoShape‑ellipse.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Добавить AutoShape‑rectangle.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Добавить соединитель на слайд.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Соединить фигуры соединителем.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Вызвать reroute для установки кратчайшего пути.
    connector.reroute()

    # Сохранить презентацию.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}
Метод `connector.reroute` пере‑прокладывает соединитель, заставляя его выбрать кратчайший возможный путь между фигурами. При этом метод может изменить значения `start_shape_connection_site_index` и `end_shape_connection_site_index`.
{{% /alert %}}

## **Указание точек соединения**

В этом разделе объясняется, как прикрепить соединитель к конкретной точке соединения на фигуре в Aspose.Slides. Точное указание точек соединения позволяет управлять маршрутом соединителя и создавать аккуратные, предсказуемые диаграммы в презентациях.

1. Создайте экземпляр класса [Presentation]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/presentation/" >}}).
1. Получите ссылку на слайд по его индексу.
1. Добавьте два объекта [AutoShape]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/" >}}) на слайд, используя метод `add_auto_shape` объекта [ShapeCollection].
1. Добавьте соединитель, используя метод `add_connector` объекта [ShapeCollection] и укажите тип соединителя.
1. Соедините фигуры соединителем.
1. Установите предпочтительные точки соединения на фигурах.
1. Сохраните презентацию.

Ниже пример кода Python, задающий предпочтительную точку соединения:

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation для создания PPTX файла.
with slides.Presentation() as presentation:

    # Получить коллекцию фигур первого слайда.
    shapes = presentation.slides[0].shapes

    # Добавить AutoShape‑ellipse.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Добавить AutoShape‑rectangle.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Добавить соединитель в коллекцию фигур слайда.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Соединить фигуры соединителем.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Установить предпочтительный индекс точки соединения для эллипса.
    site_index = 6

    # Проверить, что предпочтительный индекс находится в диапазоне доступных точек.
    if ellipse.connection_site_count > site_index:
        # Присвоить предпочтительную точку соединения для эллипса.
        connector.start_shape_connection_site_index = site_index

    # Сохранить презентацию.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировка точек соединителя**

Вы можете изменять соединители с помощью их точек регулировки. Только соединители, которые предоставляют такие точки, могут быть отредактированы. Подробности о том, какие соединители поддерживают регулировку, см. в таблице в разделе [Типы соединителей](/slides/ru/python-net/connector/#connector-types).

### **Простой случай**

Рассмотрим случай, когда соединитель между двумя фигурами (A и B) пересекает третью фигуру (C):

![Connector obstruction](connector-obstruction.png)

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

Чтобы избежать пересечения с третьей фигурой, сместите вертикальный сегмент соединителя влево:

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Сложные случаи**

Для более продвинутой регулировки рассмотрим следующее:

- Точка регулировки соединителя определяется формулой, задающей её положение. Изменение этой точки изменяет общую форму соединителя.
- Точки регулировки хранятся в строго упорядоченном массиве, пронумерованном от начала соединителя к его концу.
- Значения точек представляют процент от ширины/высоты фигуры соединителя.
  - Фигура ограничена начальной и конечной точками соединителя и масштабируется на 1000.
  - Первая, вторая и третья точки соответствуют: процент ширины, процент высоты и снова процент ширины.
- При вычислении координат точек учитываются вращение и отражение соединителя. **Примечание:** Для всех соединителей, перечисленных в [Типы соединителей](/slides/ru/python-net/connector/#connector-types), угол вращения = 0.

#### **Случай 1**

Две текстовые рамки соединены соединителем:

![Linked shapes](connector-shape-complex.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation для создания PPTX файла.
with slides.Presentation() as presentation:

    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить первую фигуру.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Добавить соединитель.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Установить направление стрелки.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Установить цвет соединителя.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Установить толщину линии.
    connector.line_format.width = 3

    # Соединить фигуры соединителем.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Получить точки регулировки соединителя.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Регулировка**

Изменить значения точек регулировки, увеличив процент ширины на 20 % и процент высоты на 200 %:

```python
    # Изменить значения точек регулировки.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Результат:

![Connector adjustment 1](connector-adjusted-1.png)

Для построения модели, позволяющей определить координаты и форму сегментов соединителя, создайте фигуру, соответствующую вертикальному компоненту соединителя в `connector.adjustments[0]`:

```python
    # Нарисовать вертикальный компонент соединителя.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Результат:

![Connector adjustment 2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую регулировку соединителя. В типичных сценариях необходимо учитывать вращение соединителя и его параметры отображения (`connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v`). Ниже показан процесс.

Сначала добавим новый объект текстовой рамки (**To 1**) на слайд и создадим новый зеленый соединитель, связывающий его с существующими объектами.

```python
    # Создать новый целевой объект.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Создать новый соединитель.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Соединить объекты новым соединителем.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Получить точки регулировки.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Изменить значения точек регулировки.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Результат:

![Connector adjustment 3](connector-adjusted-3.png)

Затем создадим фигуру, соответствующую **горизонтальному** сегменту соединителя, проходящему через точку регулировки `connector.adjustments[0]`. Используем значения `connector.rotation`, `connector.frame.flip_h` и `connector.frame.flip_v` и применим стандартную формулу преобразования координат при вращении вокруг точки `x0`:

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
```

В нашем случае угол вращения = 90°, а соединитель отображается вертикально, поэтому код выглядит так:

```python
    # Сохранить координаты соединителя.
    x = connector.x
    y = connector.y
    
    # Скорректировать координаты, если соединитель отражён.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Использовать значение точки регулировки как координату.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Преобразовать координаты, т.к. sin(90°)=1 и cos(90°)=0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Определить ширину горизонтального сегмента по второй точке регулировки.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Результат:

![Connector adjustment 4](connector-adjusted-4.png)

Мы продемонстрировали расчёты как простых, так и сложных точек регулировки (учитывающих вращение). Используя эти сведения, вы можете построить собственную модель — или написать код, получающий объект `GraphicsPath` — или даже задавать значения точек регулировки в зависимости от конкретных координат слайда.

## **Определение углов линии соединителя**

Ниже пример, показывающий, как определить угол линии соединителя на слайде с помощью Aspose.Slides. Вы узнаете, как читать концевые точки соединителя и вычислять его ориентацию для точного выравнивания стрелок, подписей и других фигур.

1. Создайте экземпляр класса [Presentation]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/presentation/" >}}).
1. Получите ссылку на слайд по индексу.
1. Получите объект линии соединителя.
1. Используйте ширину и высоту линии, а также ширину и высоту рамки фигуры, чтобы вычислить угол.

Пример кода Python для вычисления угла линии соединителя:

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

**Как определить, может ли соединитель «приклеиваться» к конкретной фигуре?**

Проверьте, предоставляет ли фигура [точки соединения]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/" >}}). Если их нет или количество равно 0, приклеивание недоступно; в таком случае используйте свободные концы и позиционируйте их вручную. Рекомендуется проверять количество точек перед прикреплением.

**Что происходит с соединителем, если удалить одну из соединённых фигур?**

Концы отсоединятся; соединитель останется на слайде как обычная линия со свободными началом/концом. Его можно удалить или переназначить соединения и, при необходимости, вызвать [reroute]({{< ref "https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/" >}}).

**Сохраняются ли привязки соединителей при копировании слайда в другую презентацию?**

Обычно да, при условии, что копируются также целевые фигуры. Если слайд вставляется в другой файл без связанных фигур, концы становятся свободными, и их необходимо заново прикрепить.