---
title: Настройка форм презентаций в Python
linktitle: Пользовательская форма
type: docs
weight: 20
url: /ru/python-net/custom-shape/
keywords:
- пользовательская форма
- добавить форму
- создать форму
- изменить форму
- геометрия формы
- геометрический путь
- точки пути
- точки редактирования
- добавить точку
- удалить точку
- операция редактирования
- скруглённый угол
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET: геометрические пути, скруглённые углы, составные формы."
---
## **Обзор**

Эта статья объясняет, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы через точки редактирования и геометрические пути. Показано, как работать с [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме.

Также демонстрируется, как создавать пользовательские и составные формы, создавать формы со скруглёнными углами, определять, замкнута ли геометрия формы, и извлекать элементы формы для анализа контуров.

## **Изменить форму с помощью точек редактирования**

В PowerPoint вы можете использовать **Edit Points**, чтобы изменить квадрат:

* Переместить угол внутрь или наружу.  
* Отрегулировать кривизну в точке.  
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму как основу для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.  
* Путь формы состоит из опорных точек, соединённых сегментами.  
* Сегмент может быть прямым или кривым. Опорные точки и управляющие ручки определяют его форму.  
* Опорные точки бывают уголковыми, прямыми или сглаженными:  
  * В уголковой точке соединяющие сегменты могут встречаться под углом.  
  * В сглаженной точке две управляющие ручки выровнены и находятся на одинаковом расстоянии от опорной точки.  
  * В прямой точке две управляющие ручки выровнены, но могут находиться на разном расстоянии от опорной точки.  
* Перемещение опорных точек или изменение их ручек меняет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) представляет геометрический путь объекта [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).  
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), можно использовать метод [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).  
* Чтобы установить [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) для формы, можно использовать методы: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) для форм с одним путем и [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) для форм с несколькими путями.  
* Чтобы добавить сегменты, можно использовать методы класса [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).  
* С помощью свойств [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) и [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) можно задать внешний вид геометрического пути.  
* Свойство [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) позволяет получить геометрический путь [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) в виде массива сегментов пути.

## **Простые операции редактирования**

Используйте следующие методы для редактирования геометрического пути. Перегрузки, принимающие индекс, вставляют сегмент в позицию с нулевым базовым индексом в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Добавить или вставить кубическую кривую Безье с двумя управляющими точками и конечной точкой. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Добавить или вставить квадратичную кривую Безье с одной управляющей точкой и конечной точкой. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Добавить эллиптическую дугу с заданными размерами и углами в градусах. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Замкнуть текущую фигуру, соединив её конечную точку с начальной. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Установить начальную точку фигуры. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Удалить сегмент по нулевому базовому индексу. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Добавить пользовательские точки к форме**

В этом примере вставляются две точки в прямоугольную форму с помощью [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) и применяется отредактированный путь через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Координаты локальны для формы: обе новые точки находятся в её центре, на расстоянии 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхней и нижней гранях, притягивая эти грани внутрь.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Удалить точки из формы**

В этом примере изменяется контур формы в виде сердца, удаляя сегмент с нулевым базовым индексом 2 с помощью [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Применение изменённого пути через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) обновляет контур формы.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Создать пользовательскую форму**

В этом примере создаётся пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Чередующиеся наружные и внутренние радиусы 100 и 50 пунктов определяют вершины и впадины; шаг 72 градуса равномерно размещает пять вершин. Путь замыкается методом [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) и применяется к прямоугольной форме через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), заменяя её контур.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Создать составную пользовательскую форму**

В этом примере определяются два закрытых объекта [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) для верхней и нижней трети формы. Применение обоих путей через [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) создаёт одну составную форму с промежутком в её средней трети.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Создать пользовательскую форму со скруглёнными углами**

В этом примере комбинируются прямые сегменты с [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) для создания формы со внутрь‑изогнутыми углами. Каждый размер угла задаёт ширину и высоту дуги в пунктах, а sweep‑угол -90° рисует против часовой стрелки четверть эллипса. Завершённый путь применяется через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), и презентация сохраняется в формате PPTX.

```python
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

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Определить, закрыта ли геометрия формы**

Следующий вспомогательный метод проверяет, заканчивается ли каждый непустой геометрический путь закрывающим сегментом. Он читает [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) и сравнивает команду последнего сегмента [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) с [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Возвращает false, если нет непустых путей. Метод проверяет только последнюю команду каждого пути; он не исследует каждый субфигуру внутри пути. Пример выводит `True` для прямоугольника.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Извлечь и проанализировать элементы формы**

Используйте [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) для анализа существующей формы как элементов, содержащих точки пути и типы точек. Каждый возвращённый [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) раскрывает массивы [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) и [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

Пример открывает презентацию, находит первую геометрическую форму непосредственно на первом слайде и выводит её сегменты пути. Используйте презентацию, содержащую форму с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не производится.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Сохраняет тип сегмента, исключая флаги.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Массивы сопоставляются по индексу: `points[i]` — точка, `types[i]` — её роль. Тип 0 начинается фигуру, тип 1 рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается в предыдущей конечной точке и использует три последовательных элемента типа 3: два управляющих пункта и новую конечную точку. Цикл потребляет эти три элемента вместе и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` определяет тип сегмента, а `0x80` проверяется отдельно для обнаружения закрытого подпути. Например, `129` (`0x81`) — конец линии, закрывающий подпуть, а `131` (`0x83`) — конец Безье, закрывающий его. Сравнение чистого значения только с `1` или `3` пропустило бы такие случаи. Другие флаги, такие как тире (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X растёт вправо, Y — вниз. Для разобщённой формы извлечённые координаты уже включают её [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) и [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) и отражают её текущую ширину и высоту. Например, неповёрнутый прямоугольник в точке `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её необработанной рамки.

Извлечённые точки не учитывают [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) формы и горизонтальные/вертикальные отражения. Чтобы воспроизвести отображаемый контур, примените эти трансформации вокруг центра формы. Для группированных форм также учитывайте преобразования координат группы; не предполагая, что извлечённые точки уже являются окончательными координатами слайда или не применяя трансляцию и масштабирование дважды, если они уже учтены в кадре дочернего элемента.

**Анализ против редактирования.** Извлечённые массивы описывают контур; их изменение не обновляет исходную форму. Выбирайте такой подход, когда вашему коду анализа или рисования нужны массивы точек/типов. Используйте [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) когда нужны геометрические команды в локальной системе координат формы или вы хотите редактировать её геометрию. Применяйте отредактированные пути через [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) или [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Что произойдёт со заливкой и контуром после замены геометрии?**

Стиль остаётся привязан к форме; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно вращать пользовательскую форму вместе с её геометрией?**

Используйте свойство [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) формы; геометрия вращается вместе с формой, поскольку привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте нужную [slide](/slides/ru/python-net/convert-powerpoint-to-png/) область или саму [shape](/slides/ru/python-net/create-shape-thumbnails/) в растровый формат; это упростит дальнейшую работу со сложными геометриями.