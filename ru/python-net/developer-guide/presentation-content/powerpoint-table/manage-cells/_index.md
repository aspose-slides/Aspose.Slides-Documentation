---
title: Управление ячейками таблиц в презентациях с Python
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/python-net/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удаление границы
- разделение ячейки
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint в Python: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц и изменять их в презентациях PowerPoint. Эта статья объясняет, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разделения, изменить цвет фона ячейки и добавить изображение внутрь ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через свойства ячеек и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля. Координаты в этой статье записываются как `(column, row)`.

## **Определить объединённую ячейку таблицы**

Пример открывает существующую презентацию и получает первую фигуру на первом слайде как таблицу. Предполагается, что слайд и фигура существуют и что фигура является таблицей. Затем он перебирает все строки и столбцы и использует [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) для определения ячеек в объединённых областях. Для каждого совпадения выводятся координаты ячейки в порядке `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), а также начальные координаты области, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) и [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Удалить границы ячеек таблицы**

Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Ширины столбцов, высоты строк и позиция таблицы задаются в пунктах. Пример устанавливает все четыре границы ячейки в [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), делая их невидимыми.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить диагональные границы ячеек**

Используйте [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/) для рисования линии от верхнего левого угла к нижнему правому и [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/) для рисования линии от нижнего левого угла к верхнему правому. Диагональ может обозначать заголовок‑угол; обе диагонали могут образовать крест‑икс, обозначающий, что ячейка не применима.

Каждая диагональ является объектом [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). В её [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) установите [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в значение [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) и выберите [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Установите [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) линии в пунктах.

Пример создаёт три ячейки в одной строке: красную диагональ вниз, синюю диагональ вверх и обе диагонали. Верхняя, нижняя, левая и правая границы ячеек остаются без изменений.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Диагональ — это свойство форматирования, а не разделение ячейки. Каждая ячейка сохраняет единственный [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); области по обе стороны от диагонали нельзя редактировать независимо.

Сохранённая таблица, отрисованная в Microsoft PowerPoint:

![Три ячейки таблицы, показывающие красную диагональ от верхнего левого к нижнему правому, синюю диагональ от нижнего левого к верхнему правому и обе диагонали, образующие крест‑икс.](diagonal-cell-borders.png)

*Слева направо: диагональ вниз (красная, 3 pt), диагональ вверх (синяя, 5 pt) и обе диагонали.*

## **Объединить ячейки таблицы**

Используйте [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) для объединения прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент управляет тем, может ли объединение включать ячейки за пределами указанного диапазона; `False` сохраняет объединение внутри этого диапазона.

Пример создаёт таблицу 4 × 4 с колонками и строками по 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, в то время как базовая сетка таблицы остаётся четырёхколо­нной и четырёхстрочной. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её положение в левом верхнем угле: `table.rows[1][1]` в этом примере. Другие позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за пределами диапазона не меняются.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Разделить ячейки таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблиц PowerPoint.

Этот пример создаёт таблицу 4 × 4 с колонками и строками по 70 пунктов и вызывает [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) для ячейки `(1, 1)`. Половина ширины ячейки (70 pt) передаётся для создания двух ячеек равной ширины.

После разделения две половины доступны как `table.rows[1][1]` и `table.rows[1][2]`. Сетка таблицы теперь имеет пять столбцов: ячейки, изначально находившиеся в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

<!-- visual-explanation:manage-cells:start -->
[![Необъединённая ячейка шириной 70 пунктов делится на две ячейки по 35 пунктов, добавляя пятый столбец сетки и сдвигая индексы справа.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Разделение ширины затрагивает ячейку (1, 1), используя нулевые (column, row) индексы. Остальные строки сохраняют ячейку, охватывающую обе новые позиции столбцов.*
<!-- visual-explanation:manage-cells:end -->

### **Разделить объединённые ячейки по строке или столбцу**

Чтобы подготовить объединённые шаблонные ячейки к заполнению данными, используйте [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) для разделения по существующей строковой границе или [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) для разделения по столбцовой границе.

Аргумент `index` определяет количество строк в верхней части или столбцов в левой части разделения; он относится к объединённой области:

- Разделение по строке: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Разделение по столбцу: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

В примере ожидается, что презентация содержит таблицу как первую фигуру на первом слайде, при этом ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижней позиции, используется [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) и [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) для определения начала и проверяются обе охватываемые области. `split_by_row_span` с индексом 1 затем отделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `split_by_col_span` с индексом 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Получить получившиеся ячейки из таблицы после разделения.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите результирующие ячейки по их координатам; здесь обе имеют охват 1, а [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) возвращает `False`. Более крупные области могут оставаться частично объединёнными после одного разделения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пустая, но наследует форматирование ячейки, такое как заливка, границы и отступы. После разделения заполните ячейки и при необходимости явно задайте форматирование текста.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием шаблонной ячейки. См. [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) для деталей.

### **Разделить ячейку на определённую высоту**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) принимает высоту верхней части в пунктах. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) принимает количество существующих строк сетки в верхней части. Чтобы вертикально центрировать ячейку высотой 40 пунктов в правом столбце, вычтите 40 из фактической высоты ячейки и равномерно распределите оставшееся пространство сверху и снизу.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

Первое разделение добавляет строку в сетку, оставляя нижние 90 пунктов в `table.rows[1][1]`. Второе разделение делит эту ячейку на среднюю ячейку высотой 40 пунктов и нижнюю ячейку высотой 50 пунктов. Теперь три ячейки в правом столбце имеют высоты 50, 40 и 50 пунктов сверху вниз. Левая ячейка охватывает все три строки при своей исходной высоте 140 пунктов.

![Левая ячейка занимает полную высоту таблицы рядом с тремя ячейками, в средней из которых находится надпись Middle.](split-by-height.png)

## **Изменить цвет фона ячейки таблицы**

Этот пример создаёт таблицу со столбцами шириной 150 пунктов и строками высотой 50 пунктов. Для ячейки `(2, 3)`, находящейся в третьем столбце и четвёртой строке, устанавливается [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в значение solid и [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) в красный.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить изображение внутрь ячейки таблицы**

Поместите входное изображение в рабочий каталог перед запуском примера. Оно загружается с помощью [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) и добавляется в коллекцию изображений презентации через [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Затем изображение назначается как заливка картинки ячейки `(0, 0)`, первой ячейки таблицы.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить соотношение сторон. Ширины столбцов и высоты строк указываются в пунктах. Загруженное изображение автоматически освобождается по завершении блока `with`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Могу ли я задать разную толщину линий и стили для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [режим заполнения](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при черепице плитки пересчитываются.

**Можно ли назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/python-net/manage-hyperlinks/) устанавливаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку части текста или всему тексту в ячейке.

**Можно ли задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (фрагменты) с независимым форматированием — семейство шрифта, стиль, размер и цвет.