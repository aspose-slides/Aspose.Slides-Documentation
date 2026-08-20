---
title: Управление фигурами презентации в Python
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/python-net/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Поиск фигуры
- Клонирование фигуры
- Удаление фигуры
- Скрытие фигуры
- Изменение порядка фигур
- Получить ID фигуры interop
- Альтернативный текст фигуры
- Форматы макета фигуры
- Фигура в формате SVG
- Фигура в SVG
- Выравнивание фигуры
- Отражение фигуры
- PowerPoint
- Презентация
- Python
- Aspose.Slides
description: "Узнайте, как идентифицировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET представляет фигуры на слайде как упорядоченную [ShapeCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/). Коллекция одновременно является местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

Эта статья следует этой модели. Сначала она объясняет, как надёжно идентифицировать фигуру, затем показывает, как клонировать, удалять, скрывать и менять порядок фигур. В заключительных разделах рассматриваются форматирование на уровне макета, экспорт в SVG, выравнивание и настройки отражения. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему рабочему процессу.

## **Определение и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигур может изменить их индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Shape.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/name/) полезен для шаблонов, контролируемых разработчиками, и легко просматривается в панели выбора PowerPoint. Имена можно редактировать, но они не гарантируют уникальность, поэтому следует установить соглашение об именовании, если код от них зависит.
- [Shape.alternative_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/alternative_text/) полезен, когда описание доступности или тег, добавленный автором, уже идентифицирует фигуру. Оно отображается пользователям, может быть локализовано или переписано для доступности и также не гарантирует уникальность. Не переиспользуйте осмысленный текст доступности в качестве ключа базы данных.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/office_interop_shape_id/) — только для чтения, уникальный внутри слайда и соответствующий идентификатору фигуры, используемому в интеропе PowerPoint. Используйте его при интеграции с PowerPoint или когда нужен однозначный справочник в течение жизни фигуры. Клонированная или воссозданная фигура получает новый идентификатор.

Связанное свойство [Shape.unique_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/unique_id/) имеет область действия презентации, но предназначено для надстроек и может быть переопределено. Не рассматривайте его как постоянный внешний ключ. Если нужна долгосрочная идентичность, храните сопоставление в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Следующий пример ищет по `name` с точным сравнением и выводит межоперационный ID, ограниченный слайдом. Когда шаблон не содержит ожидаемую фигуру, код сообщает об этом, вместо того чтобы продолжать работу с неверным объектом.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Когда операция специфична для типа фигуры, проверьте тип перед использованием членов, характерных для типа. Этот пример обновляет текст и альтернативный текст только если именованный объект является [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не продолжайте полагаться на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_clone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/insert_clone/) также создаёт копию, но помещает её в указанный индекс z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения его размеров; перегрузки с шириной и высотой могут также изменить размер.

Пример создаёт целевой слайд, клонирует помеченный прямоугольник спереди и вставляет второй клон сзади. Изменения любого клона не затрагивают исходную фигуру.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новые логические идентификаторы клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[ShapeCollection.remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/remove/) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений в ходе итерации по индексам проходите от конца, чтобы каждый оставшийся индекс оставался корректным.

Этот пример удаляет каждую фигуру с заданным именем. Он читает `slide.shapes[index]`, а не фиксированный элемент коллекции, и не приводит тип фигуры без необходимости.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

После удаления меняется количество фигур и индексы последующих фигур. Ссылки на не затронутые фигуры остаются более надёжными, чем сохранённые индексы. Также учитывайте коннекторы, анимацию и другие возможности презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Shape.hidden](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/hidden/) в `True` оставляет фигуру в коллекции, но предотвращает её отображение в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Скрытие — это не удаление и не безопасность. Объект всё ещё может быть найден и раскрыт пользователем или кодом, и остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры рисуются в порядке их расположения в коллекции. [ShapeCollection.reorder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; `len(slide.shapes) - 1` — передний.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Прямоугольник создаётся первым и изначально находится за эллипсом. Перемещение его в последний индекс помещает его спереди. Завершайте настройку Z‑порядка после добавления или клонирования всех связанных фигур, поскольку эти операции добавляют новые элементы в коллекцию и могут изменить задуманный стэк.

## **Проверка фигур на слайдах макета**

Обычные слайды, слайды макета и слайды образца имеют отдельные коллекции фигур. Фигура в коллекции макета — это не тот же объект, что аналогично расположенная фигура на обычном слайде. Проверяйте фигуры макета, когда нужно понять или изменить форматирование, предоставляемое макетом.

Следующий пример читает [Shape.fill_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/fill_format/) и [Shape.line_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/line_format/) каждой фигуры макета, не предполагая, что каждая фигура является `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Редактирование макета может затронуть несколько слайдов, использующих его. Прежде чем менять фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и проверьте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/write_as_svg/) записывает отрисованное содержимое одной фигуры в поток. В результате будет только фигура, а не весь фон слайда или соседние фигуры.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Поток принадлежит вызывающему коду и должен быть закрыт им.

## **Выравнивание фигур**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/align_shapes/) имеет перегрузки, позволяющие выравнивать либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapesalignmenttype/) задаёт край, центральную линию или режим распределения. Установите `align_to_slide` в `True`, чтобы использовать границы слайда; установите в `False`, чтобы выравнивать выбранные фигуры относительно друг друга.

Этот пример выравнивает три фигуры по верхнему краю слайда. Их текущие индексы определяются непосредственно перед выравниванием.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Выравнивание меняет позицию, а не Z‑порядок. Относительное выравнивание обычно требует как минимум две фигуры, тогда как горизонтальное или вертикальное распределение нуждается в достаточном числе фигур для определения интервалов. Пересчитайте индексы, если меняете коллекцию перед вызовом метода.

## **Отражение фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapeframe/) хранит положение, размер, настройки горизонтального и вертикального отражения и вращения. Его свойства `flip_h` и `flip_v` используют [NullableBool](https://reference.aspose.com/slides/ru/python-net/aspose.slides/nullablebool/): `TRUE` включает отражение, `FALSE` отключает, а `NOT_DEFINED` сохраняет неустановленное или значение по умолчанию.

Входная презентация ниже содержит одну неотражённую фигуру.

![Фигура до отражения](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и заменяет только два параметра отражения. Это важно, потому что присвоение нового [Shape.frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/frame/) заменяет весь кадр целиком.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

Сохранённая фигура отражена по горизонтали и вертикали, при этом сохраняются её положение, размер и вращение.

![Фигура после отражения](flipped_shape.png)

## **FAQ**

**Следует ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для краткосрочной обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенный `name` или `alternative_text` в шаблонах, созданных вручную, или `office_interop_shape_id` для работы с интеропом PowerPoint.

**Удаляет ли скрытие фигуры её из Z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно найти, переупорядочить, отредактировать или снова сделать видимой.

**Почему клонированная фигура появилась перед другой фигурой?**

`add_clone` добавляет клон в конец коллекции, что соответствует передней части Z‑порядка. Используйте `insert_clone`, чтобы задать начальный индекс, или `reorder` после добавления всех фигур.