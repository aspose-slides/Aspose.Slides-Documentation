---
title: Управление фигурами презентации в Python
linktitle: Манипулирование фигурами
type: docs
weight: 40
url: /ru/python-net/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Найти фигуру
- Клонировать фигуру
- Удалить фигуру
- Скрыть фигуру
- Изменить порядок фигур
- Получить interop ID фигуры
- Альтернативный текст фигуры
- Точка регулировки фигуры
- Регулировка предустановленной фигуры
- Геометрия фигуры
- Форматы макета фигуры
- Фигура как SVG
- Фигура в SVG
- Выровнять фигуру
- Отзеркалить фигуру
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как идентифицировать, регулировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отзеркаливать фигуры презентации с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET представляет фигуры на слайде как упорядоченный [ShapeCollection](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/). Эта коллекция одновременно является местом, где вы находите и изменяете фигуры, и источником их порядка наложения: индекс `0` – самая задняя фигура, а последний индекс – самая передняя.

В этой статье используется указанная модель. Сначала объясняется, как надёжно определить фигуру и изменить предустановленные точки регулировки, затем показывается, как клонировать, удалять, скрывать и переупорядочивать фигуры. Последние разделы охватывают форматирование на уровне макета, экспорт в SVG, выравнивание и настройки отзеркаливания. Каждый пример независим, поэтому вы можете использовать только те операции, которые нужны вашему рабочему процессу.

## **Определение и поиск фигур**

Индексы в коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигуры может изменить её индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Shape.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/name/) полезен для шаблонов, контролируемых разработчиком, и легко просматривается в панели выделения PowerPoint. Имена можно редактировать, но они не гарантировано уникальны, поэтому при зависимости кода от них следует установить конвенцию именования.
- [Shape.alternative_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/alternative_text/) удобен, когда описание доступности или тег, заданный автором, уже идентифицирует фигуру. Оно видно пользователям, может локализоваться или переписываться для доступности и также не гарантирует уникальность. Не переопределяйте осмысленный текст доступности в качестве ключа базы данных.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/office_interop_shape_id/) – только для чтения, уникальный в пределах слайда и соответствующий идентификатору фигуры, используемому в PowerPoint Interop. Используйте его при интеграции с PowerPoint или когда нужен однозначный справочник в течение жизни фигуры. Клонированная или заново созданная фигура — другая фигура и получает собственный ID.

Связанное свойство [Shape.unique_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/unique_id/) имеет область действия презентации, но предназначено для надстроек и может быть переопределено. Его не следует рассматривать как постоянный внешний ключ. Если необходима долгосрочная идентификация, храните сопоставление в данных приложения и проверяйте, что ожидаемая фигура всё ещё существует.

Следующий пример ищет по `name` с точным сравнением и выводит межоперационный ID, ограниченный слайдом. Когда шаблон не содержит ожидаемую фигуру, код сообщает об этом вместо продолжения работы с неверным объектом.

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

Когда операция специфична для типа фигуры, проверьте тип перед использованием типо‑специфичных членов. Этот пример обновляет текст и альтернативный текст только если именованный объект является [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/).

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

## **Определение и изменение предустановленных регулировок фигур**

Фигуры с предустановленной геометрией могут иметь регулировочные точки, управляющие, например, размером углов, пропорциями стрелки или углом дуги. Доступ к ним осуществляется через только‑для‑чтения коллекцию [GeometryShape.adjustments](https://reference.aspose.com/slides/ru/python-net/aspose.slides/geometryshape/adjustments/). Коллекция поставляется фигурой, но каждый [AdjustValue](https://reference.aspose.com/slides/ru/python-net/aspose.slides/adjustvalue/) содержит значение, которое можно изменить.

Не полагайтесь только на фиксированный индекс коллекции. Перебирайте регулировки и проверяйте только‑для‑чтения свойство [AdjustValue.type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/adjustvalue/type/), значение [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapeadjustmenttype/) которого описывает, что регулирует данная точка. Свойство только‑для‑чтения [AdjustValue.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/adjustvalue/name/) предоставляет дополнительную идентификационную информацию и особенно полезно, когда предустановка содержит более одной регулировки с одинаковым семантическим типом.

Используйте свойство значения, соответствующее смыслу регулировки:

| Тип регулировки | Назначение | Значение для изменения |
|---|---|---|
| `CORNER_SIZE` | Размер скруглённых углов | [raw_value](https://reference.aspose.com/slides/ru/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Толщина хвоста стрелки | `raw_value` |
| `ARROWHEAD_LENGTH` | Длина наконечника стрелки | `raw_value` |
| `ARROWHEAD_WIDTH` | Ширина наконечника стрелки | `raw_value` |
| `START_ANGLE` | Начальный угол среза или дуги | [angle_value](https://reference.aspose.com/slides/ru/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Конечный угол среза или дуги | `angle_value` |

`type` и `name` нельзя присваивать. `raw_value` — целое число с правом чтения/записи в собственных единицах геометрии предустановки, а `angle_value` — угол в градусах с правом чтения/записи. Количество, порядок, смысл и допустимый диапазон регулировок зависят от предустановки [GeometryShape.shape_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/geometryshape/shape_type/). Значение, допустимое для одной предустановки, может быть недопустимым или иметь иной эффект для другой.

Когда `type` равно `ShapeAdjustmentType.CUSTOM`, API не распознаёт стандартный семантический смысл. Проверьте `name`, тип предустановки и текущее значение и оставьте регулировку неизменной, если ожидаемый смысл и диапазон неизвестны. Даже для распознанных типов проверяйте, появляется ли тот же тип более одного раза, прежде чем выбирать значение. Статья [Connector](/slides/ru/python-net/connector/) демонстрирует подобную ситуацию с регулировками изгибов соединителей.

Следующий полностью законченный пример создаёт стандартные и изменённые варианты трёх предустановленных фигур. Он перебирает каждую регулировку, выводит её `name` и `type`, меняет размерные значения через `raw_value`, углы через `angle_value` и сохраняет результат. Левая колонка сохраняет геометрию по умолчанию; правая колонка показывает отрегулированный закруглённый прямоугольник, четырёхстороннюю стрелку и сектор.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Добавить заголовки для столбцов с фигурами по умолчанию и с изменёнными параметрами.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Проверка семантического типа перед изменением значения делает код более явным и избавляет от предположения, что определённый индекс коллекции имеет одинаковый смысл в разных предустановках.

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания работают с коллекцией сразу. Если операция меняет количество или порядок фигур, не продолжайте полагаться на индексы, захваченные до этой операции.

### **Клонирование фигуры**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_clone/) создаёт независимую копию и добавляет её в конец целевой коллекции. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/insert_clone/) также создаёт копию, но помещает её в указанный индекс z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения размеров; перегрузки с шириной и высотой могут также изменить размер.

Пример создаёт целевой слайд, клонирует отмеченный прямоугольник на передний план и вставляет второй клон в задний. Изменения любого из клонов не влияют на исходную фигуру.

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

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте новые логические идентификаторы клону, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, управляются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[ShapeCollection.remove](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/remove/) удаляет конкретный объект фигуры из её коллекции. При удалении нескольких совпадений в процессе итерации по индексам перебирайте их в обратном порядке, чтобы каждый оставшийся индекс оставался валидным.

В этом примере удаляются все фигуры с указанным именем. Он читает `slide.shapes[index]`, а не фиксированный элемент коллекции, и не делает ненужных привидений типа.

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

После удаления количество фигур и индексы последующих фигур изменяются. Ссылки на неизменённые фигуры остаются надёжнее, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие функции презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить больше, чем только внешний вид слайда.

### **Сокрытие фигуры**

Установка [Shape.hidden](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/hidden/) в `True` оставляет фигуру в коллекции, но препятствует её отображению в обычном показе слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие удобно для необязательных элементов, которые могут быть восстановлены позже.

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

Скрытие — не удаление и не защита. Объект всё ещё может быть найден и сделан видимым пользователем или кодом, и он остаётся частью файла презентации.

### **Изменение Z‑порядка**

Перекрывающиеся фигуры отрисовываются в порядке коллекции. [ShapeCollection.reorder](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/reorder/) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` – задний; `len(slide.shapes) - 1` – передний.

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

Прямоугольник создаётся первым и изначально находится за эллипсом. Перемещение его в конечный индекс помещает его спереди. Завершайте настройку Z‑порядка после добавления или клонирования всех связанных фигур, потому что эти операции добавляют или вставляют новые элементы в коллекцию и могут изменить ожидаемую стековую последовательность.

## **Проверка фигур в макетных слайдах**

Обычные слайды, макетные слайды и мастер‑слайды имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогично расположенная фигура на обычном слайде. Проверяйте фигуры макета, когда нужно понять или изменить форматирование, предоставляемое макетом.

Следующий пример читает для каждой фигуры макета [Shape.fill_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/fill_format/) и [Shape.line_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/line_format/), не предполагая, что каждая фигура является `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Редактирование макета может затронуть несколько слайдов, которые его используют. Прежде чем изменять фигуру макета, определите, наследует ли обычный слайд объект или содержит локальное переопределение, и протестируйте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/write_as_svg/) записывает отрисованное содержимое одной фигуры в поток. Результат содержит только эту фигуру, а не весь фон слайда или соседние фигуры.

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

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и ресурсов, таких как шрифты и изображения. Если нужен весь состав, экспортируйте слайд, а не отдельную фигуру. Вызывающий код владеет потоком и должен его закрыть.

## **Выравнивание фигур**

Перегрузки [SlideUtil.align_shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.util/slideutil/align_shapes/) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapesalignmenttype/) указывает край, центральную линию или режим распределения. Установите `align_to_slide` в `True`, чтобы использовать края слайда; установите в `False`, чтобы выравнивать выбранные фигуры относительно друг друга.

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

Выравнивание меняет позиции, а не Z‑порядок. Относительное выравнивание обычно требует минимум две фигуры, тогда как горизонтальное или вертикальное распределение нуждается в достаточном количестве фигур для определения интервалов. Пересчитайте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отзеркаливание фигуры**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapeframe/) хранит позицию, размер, настройки горизонтального и вертикального отзеркаливания и вращения. Его значения `flip_h` и `flip_v` используют [NullableBool](https://reference.aspose.com/slides/ru/python-net/aspose.slides/nullablebool/): `TRUE` включает отзеркаливание, `FALSE` выключает, а `NOT_DEFINED` сохраняет неуказанное или значение по умолчанию.

Входная презентация ниже содержит одну неотзеркаленную фигуру.

![Фигура до отзеркаливания](shape_to_be_flipped.png)

Пример сохраняет все остальные параметры кадра и заменяет только две настройки отзеркаливания. Это важно, потому что присвоение нового [Shape.frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/frame/) заменяет полностью весь кадр.

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

Сохранённая фигура будет отзеркалена по горизонтали и вертикали, при этом её позиция, размер и вращение сохранятся.

![Фигура после отзеркаливания](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для короткоживущей обработки, когда коллекция не изменится до использования индекса. Предпочтительно использовать проверенный `name` или конвенцию `alternative_text` для шаблонов, созданных вручную, либо `office_interop_shape_id` для межоперационных задач в пределах слайда.

**Удаляется ли скрытая фигура из Z‑порядка?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно найти, переупорядочить, редактировать или снова сделать видимой.

**Почему клон фигуры оказался перед другой фигурой?**

`add_clone` добавляет клон в конец коллекции, что соответствует передней части Z‑порядка. Используйте `insert_clone`, чтобы задать начальный индекс, или `reorder` после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации регулировки предустановленной фигуры?**

Только после точной проверки предустановки и макета коллекции. Предпочтительно перебрать `GeometryShape.adjustments` и проверять `AdjustValue.type`; используйте `AdjustValue.name` как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.