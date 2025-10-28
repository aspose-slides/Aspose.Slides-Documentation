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
description: "Позвольте Python‑приложениям рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint и OpenDocument — получайте полный контроль над прямыми, угловыми и изогнутыми соединителями."
---

## **Введение**

Соединитель PowerPoint — это специализированная линия, связывающая две фигуры и остающаяся прикреплённой, когда фигуры перемещаются или переориентируются на слайде. Соединители прикрепляются к **точкам соединения** (зеленые точки) фигур. Точки соединения появляются, когда указатель приближается к ним. **Ручки регулировки** (желтые точки), доступные у некоторых соединителей, позволяют изменять их позицию и форму.

## **Типы соединителей**

В PowerPoint доступны три типа соединителей: прямой, угол (изломанный) и изогнутый.

Aspose.Slides поддерживает следующие типы соединителей:

| Тип соединителя                 | Изображение                                                | Количество точек регулировки |
| ------------------------------- | ---------------------------------------------------------- | ---------------------------- |
| `ShapeType.LINE`                | ![Линейный соединитель](shapetype-lineconnector.png)      | 0                            |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Прямой соединитель 1](shapetype-straightconnector1.png) | 0                            |
| `ShapeType.BENT_CONNECTOR2`     | ![Изломанный соединитель 2](shapetype-bent-connector2.png) | 0                            |
| `ShapeType.BENT_CONNECTOR3`     | ![Изломанный соединитель 3](shapetype-bentconnector3.png) | 1                            |
| `ShapeType.BENT_CONNECTOR4`     | ![Изломанный соединитель 4](shapetype-bentconnector4.png) | 2                            |
| `ShapeType.BENT_CONNECTOR5`     | ![Изломанный соединитель 5](shapetype-bentconnector5.png) | 3                            |
| `ShapeType.CURVED_CONNECTOR2`   | ![Изогнутый соединитель 2](shapetype-curvedconnector2.png) | 0                            |
| `ShapeType.CURVED_CONNECTOR3`   | ![Изогнутый соединитель 3](shapetype-curvedconnector3.png) | 1                            |
| `ShapeType.CURVED_CONNECTOR4`   | ![Изогнутый соединитель 4](shapetype-curvedconnector4.png) | 2                            |
| `ShapeType.CURVED_CONNECTOR5`   | ![Изогнутый соединитель 5](shapetype.curvedconnector5.png) | 3                            |

## **Соединение фигур с помощью соединителей**

В этом разделе показано, как связать фигуры соединителями в Aspose.Slides. Вы добавите соединитель на слайд, прикрепите его начало и конец к целевым фигурам. Использование точек соединения гарантирует, что соединитель останется «приклеенным» к фигурам даже при их перемещении или изменении размеров.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд, используя метод `add_auto_shape` объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Добавьте соединитель с помощью метода `add_connector` того же объекта [ShapeCollection] и укажите тип соединителя.
5. Соедините фигуры соединителем.
6. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
7. Сохраните презентацию.

Ниже показан код Python, который добавляет изломанный соединитель между двумя фигурами (эллипсом и прямоугольником):

```python
import aspose.slides as slides

# Создаём объект Presentation для создания файла PPTX.
with slides.Presentation() as presentation:

    # Получаем коллекцию фигур первого слайда.
    shapes = presentation.slides[0].shapes

    # Добавляем эллипс‑AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Добавляем прямоугольник‑AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Добавляем соединитель на слайд.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Соединяем фигуры.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Применяем кратчайший путь.
    connector.reroute()

    # Сохраняем презентацию.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Метод `connector.reroute` переопределяет путь соединителя, заставляя его идти по кратчайшему возможному маршруту между фигурами. Для этого метод может изменить значения `start_shape_connection_site_index` и `end_shape_connection_site_index`.

{{% /alert %}}

## **Указание точек соединения**

В этом разделе объясняется, как прикрепить соединитель к конкретной точке соединения фигуры в Aspose.Slides. Таргетируя точные точки, вы можете управлять маршрутизацией соединителя и расположением, получая чистые, предсказуемые диаграммы в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с помощью метода `add_auto_shape` объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Добавьте соединитель через метод `add_connector` того же объекта и укажите тип соединителя.
5. Соедините фигуры.
6. Установите предпочтительные точки соединения на фигурах.
7. Сохраните презентацию.

Пример кода Python, демонстрирующий указание предпочтительной точки соединения:

```python
import aspose.slides as slides

# Создаём объект Presentation для создания файла PPTX.
with slides.Presentation() as presentation:

    # Доступ к коллекции фигур первого слайда.
    shapes = presentation.slides[0].shapes

    # Добавляем эллипс‑AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Добавляем прямоугольник‑AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Добавляем соединитель к коллекции фигур слайда.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Соединяем фигуры.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Устанавливаем предпочтительный индекс точки соединения у эллипса.
    site_index = 6

    # Проверяем, что индекс находится в диапазоне доступных точек.
    if ellipse.connection_site_count > site_index:
        # Присваиваем предпочтительную точку соединения.
        connector.start_shape_connection_site_index = site_index

    # Сохраняем презентацию.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Регулировка точек соединителя**

Вы можете изменять соединители, используя их точки регулировки. Только соединители, у которых есть такие точки, могут быть отредактированы этим способом. Для подробностей о поддерживаемых соединителях см. таблицу в разделе **Типы соединителей**.

### **Простой пример**

Рассмотрим ситуацию, когда соединитель между двумя фигурами (A и B) пересекает третью фигуру (C):

![Пересечение соединителя](connector-obstruction.png)

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

Чтобы обойти третью фигуру, переместите вертикальный сегмент соединителя влево:

![Исправленное пересечение](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Сложные примеры**

Для более продвинутой регулировки учитывайте следующее:

- Положение точки регулировки определяется формулой; изменение этой точки меняет форму всего соединителя.
- Точки регулировки хранятся в строго упорядоченном массиве от начала к концу соединителя.
- Значения точек выражаются в процентах от ширины/высоты формы соединителя.
  - Форма ограничена начальной и конечной точкой соединителя и масштабируется в 1000.
  - Первая, вторая и третья точки представляют: процент ширины, процент высоты и снова процент ширины.
- При вычислении координат точек учитывайте вращение и отражение соединителя. **Примечание:** Для всех соединителей из раздела **Типы соединителей** угол вращения = 0.

#### **Случай 1**

Две текстовые рамки соединены соединителем:

![Связанные фигуры](connector-shape-complex.png)

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаём объект Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3

    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Регулировка**

Увеличьте значение первой точки на 20 % ширины и второй на 200 % высоты:

```python
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Результат:

![Регулировка 1](connector-adjusted-1.png)

Чтобы построить модель, определяющую координаты и форму сегментов соединителя, создайте фигуру, соответствующую вертикальному компоненту `connector.adjustments[0]`:

```python
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Результат:

![Регулировка 2](connector-adjusted-2.png)

#### **Случай 2**

В **случае 1** мы показали простую регулировку. В реальных сценариях нужно учитывать вращение и настройки отображения (`connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v`). Ниже — основной порядок действий.

1. Добавьте новую текстовую рамку (**To 1**) и зелёный соединитель, связывающий её с уже существующими объектами.

```python
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Результат:

![Регулировка 3](connector-adjusted-3.png)

2. Создайте фигуру, соответствующую **горизонтальному** сегменту, проходящему через точку `connector.adjustments[0]`. Используйте значения `connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v` и формулу поворота вокруг точки `x0`:

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0
```

В нашем случае угол = 90° и соединитель отображается вертикально, поэтому код выглядит так:

```python
    x = connector.x
    y = connector.y
    
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    x += connector.width * adjValue_0.raw_value / 100000
    
    # sin(90°)=1, cos(90°)=0
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Результат:

![Регулировка 4](connector-adjusted-4.png)

Таким образом, мы продемонстрировали расчёты как для простых, так и для сложных точек регулировки с учётом вращения. Эти знания позволят вам построить собственную модель или написать код для получения `GraphicsPath`‑объекта или задания значений точек регулировки на основе координат слайда.

## **Определение углов линий соединителей**

В примере ниже показано, как определить угол линии соединителя на слайде с помощью Aspose.Slides. Вы научитесь считывать конечные точки соединителя и вычислять его ориентацию, чтобы точно выравнивать стрелки, подписи и другие фигуры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите слайд по индексу.
3. Получите объект линии соединителя.
4. Используйте ширину и высоту линии, а также размеры рамки фигуры, чтобы вычислить угол.

Пример кода Python:

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

**Как определить, может ли соединитель «приклеиться» к конкретной фигуре?**

Проверьте, есть ли у фигуры свойства [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). Если их нет или количество равно нулю, приклейка недоступна; в этом случае используйте свободные концы и разместите их вручную. Рекомендуется проверять количество точек до прикрепления.

**Что происходит с соединителем, если я удалю одну из связанных фигур?**

Концы отсоединятся; соединитель останется на слайде как обычная линия с незакреплёнными началом/концом. Вы можете либо удалить его, либо заново установить соединения и, при необходимости, вызвать [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**Сохраняются ли привязки соединителей при копировании слайда в другую презентацию?**

Как правило, да, при условии, что связанные фигуры также копируются. Если слайд вставляется в другой файл без этих фигур, концы становятся свободными, и их потребуется прикрепить заново.