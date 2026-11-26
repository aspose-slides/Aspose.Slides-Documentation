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
- путь геометрии
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
description: "Создавайте и настраивайте формы в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET: пути геометрии, скруглённые углы, составные формы."
---
## **Обзор**

Эта статья объясняет, как настраивать формы презентаций в Aspose.Slides, редактируя геометрию формы с помощью точек редактирования и путей геометрии. Она показывает, как работать с [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) для изменения существующих форм, выполнения базовых операций редактирования пути, добавления или удаления точек и применения обновлённой геометрии обратно к форме.

Она также демонстрирует, как создавать пользовательские и составные формы, строить формы со скруглёнными углами, определять, является ли геометрия формы закрытой, и извлекать элементы формы для анализа контура.

## **Изменение формы с помощью точек редактирования**

В PowerPoint вы можете использовать **Edit Points** для изменения квадрата:

* Переместить угол внутрь или наружу.
* Отрегулировать кривизну в точке.
* Добавить новые точки.

Редактирование точек позволяет изменять контур формы или использовать существующую форму в качестве основы для новой.

## **Советы по редактированию форм**

![overview_image](custom_shape_0.png)

При редактировании форм PowerPoint учитывайте следующие концепции:

* Форма (или её путь) может быть закрытой или открытой.
* Путь формы состоит из опорных точек, соединённых сегментами.
* Сегмент может быть прямым или кривым. Опорные точки и контрольные ручки определяют его форму.
* Опорные точки бывают угловыми, прямыми или плавными:
  * В угловой точке соседние сегменты могут соединяться под углом.
  * В плавной точке две контрольные ручки выровнены и находятся на одинаковом расстоянии от опорной точки.
  * В прямой точке две контрольные ручки выровнены, но могут находиться на разном расстоянии от опорной точки.
* Перемещение опорных точек или регулировка их ручек меняет контур формы.

Для редактирования форм PowerPoint через точки редактирования **Aspose.Slides** предоставляет класс [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).

* Экземпляр [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) представляет путь геометрии объекта [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Чтобы получить [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) из экземпляра [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/), можно использовать метод [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Чтобы установить [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) для формы, можно использовать эти методы: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) для форм с одним путём и [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) для форм с несколькими путями.
* Чтобы добавить сегменты, можно использовать методы из раздела [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Используя свойства [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) и [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), можно задать внешний вид пути геометрии.
* Используя свойство [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/), можно получить путь геометрии [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) в виде массива сегментов пути.

## **Простые операции редактирования**

Используйте следующие методы для редактирования пути геометрии. Перегрузки, принимающие индекс, вставляют сегмент в указанную позицию с нулевым основанием в массиве сегментов пути.

| Операция | Метод |
| --- | --- |
| Добавить или вставить прямую линию. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Добавить или вставить кубическую кривую Безье с двумя контрольными точками и конечной точкой. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Добавить или вставить квадратичную кривую Безье с одной контрольной точкой и конечной точкой. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Добавить эллиптическую дугу с указанными размерами и углами в градусах. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Замкнуть текущую фигуру, соединяя её конечную точку с начальной. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Установить начальную точку фигуры. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Удалить сегмент по нулевому индексу. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Добавление пользовательских точек к форме**

В этом примере две точки вставляются в прямоугольную форму с помощью [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) и применяют отредактированный путь через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/). Координаты локальны для формы: обе новые точки находятся в её центре, на 100 пунктов от левого края и 50 пунктов от верхнего. Индексы сегментов 1 и 4 размещают их на верхнем и нижнем краях, притягивая эти грани внутрь.

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

## **Удаление точек из формы**

В этом примере изменяется контур сердца путём удаления сегмента с нулевым индексом 2 с помощью [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/). Применение изменённого пути через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) обновляет контур формы.

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

## **Создание пользовательской формы**

В этом примере строится пятиконечная звезда с помощью [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Чередующиеся внешние и внутренние радиусы 100 и 50 пунктов задают концы и впадины; шаг в 72 градуса равномерно размещает пять кончиков. Путь замыкается с помощью [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) и применяется к прямоугольной форме через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), заменяя её контур.

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

## **Создание составной пользовательской формы**

В этом примере определяются два замкнутых объекта [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) для верхней и нижней третьей части формы. Применение обоих путей через [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) создаёт одну составную форму с разрывом посередине её средней трети.

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

## **Создание пользовательской формы со скруглёнными углами**

В этом примере прямые сегменты комбинируются с [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) для создания формы со внутрёнутренними скруглёнными углами. Каждый параметр угла задаёт ширину и высоту дуги в пунктах, а отрезок ‑90° рисует четверть эллипса против часовой стрелки. Готовый путь применяется через [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), а презентация сохраняется в формате PPTX.

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

## **Определение, закрыта ли геометрия формы**

Следующая вспомогательная функция проверяет, заканчивается ли каждый непустой путь геометрии замыкающим сегментом. Она читает [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) и сравнивает команду последнего сегмента [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) с [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Возвращает false, когда нет непустых путей. Функция проверяет окончательную команду каждого пути; она не анализирует каждый подпункт внутри пути. Пример выводит `True` для прямоугольника.

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

## **Проверка команд пути геометрии**

Скачайте [contour.pptx](contour.pptx) и поместите его в рабочий каталог. Первая форма на первом слайде имеет прямой верхний край, кубическую кривую Безье и прямой замыкающий край. Используйте [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) для чтения её путей. Для каждого пути [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) перечисляет сегменты в порядке рисования. Команда [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) каждого сегмента определяет, как интерпретировать его [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/).

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

Форма расположена в точке (200, 100) пунктов на слайде. Сообщаемые координаты локальны для формы. Её левый верхний угол имеет координаты (0, 0), ось X растёт вправо, ось Y — вниз. Замыкающий сегмент возвращается к начальной точке без дополнительных координат.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![Фигура PowerPoint с прямой верхней гранью, изогнутой гранью от верхнего правого до нижнего левого и прямой левой гранью](contour.png)

## **Извлечение и проверка элементов формы**

Используйте [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) для проверки существующей формы как элементов, содержащих точки пути и типы точек. Каждый возвращённый [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) раскрывает свои массивы [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) и [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/). Такое представление полезно для анализа контура или передачи геометрии в пользовательские инструменты рисования.

Пример открывает презентацию, находит первую форму геометрии напрямую на первом слайде и выводит её сегменты пути. Используйте презентацию, содержащую форму с прямыми и кривыми сегментами, чтобы увидеть оба типа вывода. Поиск внутри групп не выполняется.

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
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
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

Массивы соответствуют индексам: `points[i]` — точка, `types[i]` — её роль. Тип `0` начинает фигуру, тип `1` рисует линию от предыдущей точки к текущей. Кубический сегмент Безье начинается от предыдущей конечной точки и использует три последовательных элемента типа `3`: две контрольные точки и новую конечную точку. Цикл обрабатывает эти три элемента вместе и проверяет конечную точку на замыкание.

Типы точек также содержат флаги. Маска `0x07` определяет тип сегмента, а проверка `0x80` отдельно обнаруживает закрытый подпуть. Например, `129` (`0x81`) — конечная точка линии, закрывающая подпуть, а `131` (`0x83`) — конечная точка Безье, закрывающая его. Сравнение сырого значения только с `1` или `3` упустит такие случаи. Другие флаги, такие как тире (`0x10`) и маркер (`0x20`), не меняют базовый тип сегмента.

**Координаты и преобразования.** Точки измеряются в пунктах (1/72 дюйма), X растёт вправо, Y — вниз. Для не сгруппированной формы извлечённые координаты уже включают её позицию [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) и [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) и отражают её текущую ширину и высоту. Например, не повернутый прямоугольник в `(100, 200)` размером `120 × 80` имеет границы контура `(100, 200)`–`(220, 280)`. Не добавляйте позицию формы повторно. Вычтите её X и Y, чтобы получить координаты относительно её ненаправленного фрейма.

Извлечённые точки не учитывают [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) формы и горизонтальные и вертикальные отражения. Чтобы воспроизвести отображаемый контур, примените эти преобразования вокруг центра формы. Для сгруппированных форм также учитывайте сопоставление координат группы и её преобразования; не предполагаете, что извлечённые точки уже являются окончательными координатами слайда, и не применяйте трансляцию или масштаб дважды, если они уже отражены в кадре дочернего элемента.

**Проверка против редактирования.** Извлечённые массивы описывают контур; изменение их не обновляет оригинальную форму. Выбирайте такой подход, когда ваш анализ или код рисования требует массивов точка/тип. Используйте [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/), когда нужны команды геометрии в локальной системе координат формы или когда требуется редактировать её геометрию. Применяйте отредактированные пути через [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) или [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/).

## **FAQ**

**Что произойдет с заливкой и контуром после замены геометрии?**

Стиль остаётся у формы; меняется только контур. Заливка и контур автоматически применяются к новой геометрии.

**Как правильно повернуть пользовательскую форму вместе с её геометрией?**

Используйте свойство формы [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/); геометрия вращается вместе с формой, поскольку привязана к её собственной системе координат.

**Можно ли преобразовать пользовательскую форму в изображение, чтобы «зафиксировать» результат?**

Да. Экспортируйте требуемый [слайд](/slides/ru/python-net/convert-powerpoint-to-png/) или саму [форму](/slides/ru/python-net/create-shape-thumbnails/) в растровый формат; это упрощает дальнейшую работу со сложными геометриями.