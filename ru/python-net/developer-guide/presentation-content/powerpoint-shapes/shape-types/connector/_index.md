---
title: Управление соединителями в презентациях с Python
linktitle: Соединитель
type: docs
weight: 10
url: /ru/python-net/connector/
keywords:
- соединитель
- тип соединителя
- точка соединителя
- линия соединителя
- угол соединителя
- связывать фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Позвольте Python‑приложениям рисовать, соединять и автоматически прокладывать линии в слайдах PowerPoint и OpenDocument — получайте полный контроль над прямыми, угловыми и изогнутыми соединителями."
---

## **Введение**

Соединитель PowerPoint — это специализированная линия, соединяющая две фигуры и остающаяся привязанной к ним при перемещении или переустановке фигур на слайде. Соединители привязываются к **точкам соединения** (зеленые точки) на фигурах. Точки соединения появляются, когда указатель приближается к ним. **Ручки регулировки** (желтые точки), доступные для некоторых соединителей, позволяют изменять положение и форму соединителя.

## **Типы соединителей**

В PowerPoint можно использовать три типа соединителей: прямой, с изгибом (угловой) и изогнутый.

Aspose.Slides поддерживает следующие типы соединителей:

| Тип соединителя | Изображение | Количество точек регулировки |
| ---------------- | ------------ | ---------------------------- |
| `ShapeType.LINE` | ![Линейный соединитель](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Прямой соединитель 1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![Сгнутый соединитель 2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![Сгнутый соединитель 3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![Сгнутый соединитель 4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![Сгнутый соединитель 5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![Изогнутый соединитель 2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![Изогнутый соединитель 3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![Изогнутый соединитель 4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![Изогнутый соединитель 5](shapetype.curvedconnector5.png) | 3 |

## **Соединять фигуры с помощью соединителей**

В этом разделе показано, как связывать фигуры с помощью соединителей в Aspose.Slides. Вы добавите соединитель на слайд, привяжете его начало и конец к целевым фигурам. Использование точек соединения гарантирует, что соединитель останется «приклеенным» к фигурам даже при их перемещении или изменении размера.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд, используя метод `add_auto_shape`, предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Добавьте соединитель с помощью метода `add_connector`, предоставляемого объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/), указав тип соединителя.
5. Соедините фигуры с помощью соединителя.
6. Вызовите метод `reroute`, чтобы применить кратчайший путь соединения.
7. Сохраните презентацию.

Следующий код Python показывает, как добавить сгнутый соединитель между двумя фигурами (эллипсом и прямоугольником):
```python
import aspose.slides as slides

    # Создать экземпляр класса Presentation для создания файла PPTX.
    with slides.Presentation() as presentation:

        # Получить коллекцию фигур первого слайда.
        shapes = presentation.slides[0].shapes

        # Добавить AutoShape‑окружность.
        ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

        # Добавить AutoShape‑прямоугольник.
        rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

        # Добавить соединитель на слайд.
        connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

        # Соединить фигуры с помощью соединителя.
        connector.start_shape_connected_to = ellipse
        connector.end_shape_connected_to = rectangle

        # Вызвать reroute для установки кратчайшего пути.
        connector.reroute()

        # Сохранить презентацию.
        presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}
Метод `connector.reroute` переупорядочивает соединитель, заставляя его выбрать наиболее короткий возможный путь между фигурами. Для этого метод может изменить значения `start_shape_connection_site_index` и `end_shape_connection_site_index`.
{{% /alert %}}

## **Указать точки соединения**

Этот раздел объясняет, как привязать соединитель к конкретной точке соединения на фигуре в Aspose.Slides. Точная настройка точек соединения позволяет управлять маршрутизацией и размещением соединителей, получая чистые и предсказуемые диаграммы в презентациях.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте два объекта [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) на слайд, используя метод `add_auto_shape`, предоставляемый объектом [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Добавьте соединитель с помощью метода `add_connector` на объекте [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) и укажите тип соединителя.
5. Соедините фигуры с помощью соединителя.
6. Установите предпочтительные точки соединения на фигурах.
7. Сохраните презентацию.

Следующий код Python демонстрирует, как указать предпочтительную точку соединения:
```python
import aspose.slides as slides

# Создать экземпляр класса Presentation для создания файла PPTX.
with slides.Presentation() as presentation:

    # Получить коллекцию фигур первого слайда.
    shapes = presentation.slides[0].shapes

    # Добавить AutoShape‑окружность.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Добавить AutoShape‑прямоугольник.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Добавить соединитель в коллекцию фигур слайда.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Соединить фигуры с помощью соединителя.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Установить предпочтительный индекс точки подключения для окружности.
    site_index = 6

    # Проверить, что предпочтительный индекс находится в пределах количества доступных точек.
    if  ellipse.connection_site_count > site_index:
        # Присвоить предпочтительную точку подключения для AutoShape‑окружности.
        connector.start_shape_connection_site_index = site_index

    # Сохранить презентацию.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```


## **Регулировать точки соединителя**

Вы можете изменять соединители, используя их точки регулировки. Только соединители, которые открывают точки регулировки, могут быть изменены таким способом. Подробнее о том, какие соединители поддерживают регулировку, смотрите в таблице в разделе [Типы соединителей](/slides/ru/python-net/connector/#connector-types).

### **Простой случай**

Рассмотрим ситуацию, когда соединитель между двумя фигурами (A и B) пересекает третью фигуру (C):

![Препятствие соединителя](connector-obstruction.png)

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


Чтобы избежать третьей фигуры, переместите вертикальный сегмент соединителя влево:

![Устранённое препятствие соединителя](connector-obstruction-fixed.png)
```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```


### **Сложные случаи** 

Для более продвинутой регулировки рассмотрите следующее:

- Точка регулировки соединителя управляется формулой, определяющей её положение. Изменение этой точки может изменить общую форму соединителя.
- Точки регулировки соединителя хранятся в строго упорядоченном массиве, нумерованном от начала соединителя к его концу.
- Значения точек регулировки представляют собой проценты от ширины/высоты формы соединителя.
  - Форма ограничена начальной и конечной точками соединителя и масштабируется на 1000.
  - Первая, вторая и третья точки регулировки означают соответственно: процент ширины, процент высоты и снова процент ширины.
- При вычислении координат точек регулировки учитывайте вращение и отражение соединителя. **Примечание:** Для всех соединителей, перечисленных в разделе [Типы соединителей](/slides/ru/python-net/connector/#connector-types), угол вращения равен 0.

#### **Случай 1**

Рассмотрим случай, когда два текстовых фрейма связаны соединителем:

![Связанные фигуры](connector-shape-complex.png)

Пример кода:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation для создания PPTX‑файла.
with slides.Presentation() as presentation:

    # Получить первый слайд.
    slide = presentation.slides[0]

    # Получить первый слайд.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Добавить соединитель.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Установить направление соединителя.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Установить цвет соединителя.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Установить толщину линии соединителя.
    connector.line_format.width = 3

    # Связать фигуры соединителем.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Получить точки регулировки соединителя.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```


**Регулировка**

Измените значения точек регулировки соединителя, увеличив процент ширины на 20 % и процент высоты на 200 % соответственно:
```python
    # Изменить значения точек регулировки.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


Результат:

![Регулировка соединителя 1](connector-adjusted-1.png)

Чтобы определить модель, позволяющую вычислять координаты и форму сегментов соединителя, создайте фигуру, соответствующую вертикальному компоненту соединителя при `connector.adjustments[0]`:
```python
    # Нарисовать вертикальную часть соединителя.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```


Результат:

![Регулировка соединителя 2](connector-adjusted-2.png)

#### **Случай 2**

В **Случае 1** мы продемонстрировали простую регулировку соединителя на основе базовых принципов. В типичных сценариях необходимо учитывать вращение соединителя и его настройки отображения (контролируемые параметрами `connector.rotation`, `connector.frame.flip_h` и `connector.frame.flip_v`). Ниже описание процесса.

Сначала добавьте новый текстовый фрейм (**To 1**) на слайд (для соединения) и создайте новый зелёный соединитель, связывающий его с существующими объектами.
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

    # Соединить объекты с помощью только что созданного соединителя.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Получить точки регулировки соединителя.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Изменить значения точек регулировки.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


Результат:

![Регулировка соединителя 3](connector-adjusted-3.png)

Затем создайте фигуру, соответствующую **горизонтальному** сегменту соединителя, проходящему через новую точку регулировки `connector.adjustments[0]`. Используйте значения `connector.rotation`, `connector.frame.flip_h` и `connector.frame.flip_v`, и примените стандартную формулу преобразования координат при вращении вокруг точки `x0`:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

В нашем случае угол вращения объекта = 90 °, а соединитель отображается вертикально, поэтому соответствующий код выглядит так:
```python
    # Сохранить координаты соединителя.
    x = connector.x
    y = connector.y
    
    # Корректировать координаты соединителя, если он отражён.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Использовать значение точки регулировки как координату.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Преобразовать координаты, так как sin(90°) = 1 и cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Определить ширину горизонтального сегмента, используя значение второй точки регулировки.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```


Результат:

![Регулировка соединителя 4](connector-adjusted-4.png)

Мы продемонстрировали расчёты, включающие как простые регулировки, так и более сложные точки регулировки (учитывающие вращение). Используя эти знания, вы можете разработать собственную модель — или написать код — для получения объекта `GraphicsPath` или даже установки значений точек регулировки соединителя на основе конкретных координат слайда.

## **Найти углы линии соединителя**

Используйте пример ниже, чтобы определить угол линии соединителя на слайде с помощью Aspose.Slides. Вы узнаете, как считывать конечные точки соединителя и вычислять его ориентацию, чтобы точно выравнивать стрелки, подписи и другие фигуры.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Доступ к форме линии соединителя.
4. Используйте ширину и высоту линии, а также ширину и высоту кадра фигуры, чтобы рассчитать угол.

Следующий код Python демонстрирует, как вычислить угол для формы линии соединителя:
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


## **Вопросы и ответы**

**Как понять, может ли соединитель «приклеиваться» к конкретной фигуре?**

Проверьте, открывает ли фигура [точки соединения](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/). Если их нет или их количество равно 0, приклеивание недоступно; в этом случае используйте свободные концы и позиционируйте их вручную. Рекомендуется проверять количество точек перед привязкой.

**Что происходит с соединителем, если удалить одну из связанных фигур?**

Его концы будут отсоединены; соединитель останется на слайде как обычная линия со свободным началом/концом. Вы можете либо удалить его, либо переназначить соединения и при необходимости [переупорядочить](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**Сохраняются ли привязки соединителей при копировании слайда в другую презентацию?**

Как правило, да, при условии, что связанные фигуры также копируются. Если слайд вставляется в другой файл без связанных фигур, концы становятся свободными, и их необходимо заново привязать.