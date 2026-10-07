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

Aspose.Slides позволяет получать доступ к ячейкам таблицы и изменять их в презентациях PowerPoint. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разделения ячеек, изменить фон ячейки и добавить изображение внутри ячейки таблицы. В примерах показано, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через свойства ячейки и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля. Координаты в этой статье записываются в виде `(column, row)`.

## **Определить объединённую ячейку таблицы**

В примере открывается существующая презентация и доступ к первой фигуре на первом слайде осуществляется как к таблице. Предполагается, что слайд и фигура существуют и что фигура является таблицей. Затем происходит перебор всех строк и столбцов, и используется [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) для определения ячеек в объединённых областях. Для каждого совпадения выводятся координаты ячейки в порядке `row;column`, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), а также начальные координаты области, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) и [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/).

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

Создайте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/). Ширина столбцов, высота строк и положение таблицы задаются в пунктах. В примере все четыре границы ячейки устанавливаются в значение [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), делая их невидимыми.

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

## **Объединить ячейки таблицы**

Используйте [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/) для объединения прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в верхнем левом и нижнем правом углах диапазона. Последний аргумент определяет, может ли объединение включать ячейки за пределами указанного диапазона; `False` сохраняет объединение внутри этого диапазона.

В примере создаётся таблица 4×4 с колонками и строками по 70 пунктов, затем объединяются четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает две колонки и две строки, при этом базовая сетка таблицы сохраняет четыре колонки и четыре строки. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её положение в верхнем левом углу: `table.rows[1][1]` в этом примере. Другие позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за пределами диапазона не меняются.

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

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек, расположенных справа от неё. Aspose.Slides следует модели сетки таблиц PowerPoint.

В этом примере создаётся таблица 4×4 с колонками и строками по 70 пунктов и вызывается [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) для ячейки `(1, 1)`. Половина ширины ячейки в 70 пунктов передаётся для создания двух ячеек одинаковой ширины.

После этого разделения две половины доступны как `table.rows[1][1]` и `table.rows[1][2]`. Сетка таблицы теперь имеет пять столбцов: ячейки, ранее находившиеся в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте эти обновлённые индексы столбцов при доступе к ячейкам после разделения.

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

### **Разделить объединённые ячейки по строке или столбцу**

Чтобы подготовить объединённые ячейки шаблона к заполнению данными, используйте [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) для разделения по существующей границе строки или [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) для разделения по границе столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разделения; он относится к объединённой области:

- Разделение по строке: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Разделение по столбцу: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

В примере предполагается, что в презентации таблица находится в первой фигуре на первом слайде, при этом ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижнего положения, используются [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) и [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) для определения начала и проверяются оба охвата. `split_by_row_span` с индексом 1 затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `split_by_col_span` с индексом 1.

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

        # Получить полученные ячейки из таблицы после разделения.
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

Сетка таблицы и индексы соседних ячеек остаются без изменений. Получайте результирующие ячейки по их координатам; здесь обе имеют охват 1, и [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) выводит `False`. Более большие области могут оставаться частично объединёнными после одного разделения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пуста, но наследует форматирование ячейки, такое как заливка, границы и поля. Заполняйте ячейки после разделения и явно задавайте требуемое форматирование текста.

Сохранённая презентация содержит отдельные ячейки "Product A" и "Product B" с сохранённым форматированием ячеек шаблона. Смотрите [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) для деталей.

## **Изменить цвет фона ячейки таблицы**

В этом примере создаётся таблица со столбцами шириной 150 пунктов и строками высотой 50 пунктов. Для ячейки `(2, 3)`, находящейся в третьем столбце и четвёртой строке, устанавливается [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в значение solid и [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) в красный.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить изображение внутри ячейки таблицы**

Поместите входное изображение в рабочий каталог перед запуском этого примера. Оно загружает изображение с помощью [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) и добавляет его в коллекцию изображений презентации через [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). Затем изображение назначается как заливка рисунком ячейки `(0, 0)`, первой ячейки в таблице.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) растягивает изображение, чтобы заполнить ячейку, что может изменить её соотношение сторон. Ширина столбцов и высота строк указаны в пунктах. Загруженное изображение автоматически освобождается, когда завершается его блок `with`.

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

## **FAQ**

**Могу ли я задать разную толщину и стиль линий для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки рисунка в качестве фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подгоняется к новой ячейке; при заливке плиткой плитки пересчитываются.

**Могу ли я назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/python-net/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку части текста или всему тексту в ячейке.

**Могу ли я задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (фрагменты) с независимым форматированием — семейство шрифта, стиль, размер и цвет.