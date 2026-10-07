---
title: Управление ячейками таблиц в презентациях с помощью Python
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/python-java/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удалить границу
- разделить ячейку
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте ячейками таблиц PowerPoint в Python: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц в презентациях PowerPoint и изменять их. Эта статья объясняет, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разделения, изменить цвет фона ячейки и добавить изображение внутрь ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячейки через свойства ячейки и сохранить изменённую презентацию в файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля, для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определение объединённой ячейки таблицы**

Пример открывает существующую презентацию и получает первую форму на первом слайде как таблицу. Предполагается, что слайд и форма существуют и что форма является таблицей. Затем он перебирает все строки и столбцы и использует [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) для определения ячеек в объединённых областях. Для каждого совпадения выводятся координаты ячейки в порядке `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) и начальные координаты области, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) и [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Удаление границ ячейки таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и добавьте таблицу на первый слайд с помощью [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Ширины столбцов, высоты строк и позиция таблицы задаются в пунктах. Пример устанавливает все четыре границы ячейки в [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), делая их невидимыми.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Объединение ячеек таблицы**

Используйте [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) для объединения прямоугольного диапазона ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент управляет тем, может ли объединение включать ячейки за пределами указанного диапазона; `False` сохраняет объединение внутри этого диапазона.

Пример создаёт таблицу 4×4 с колоннами и строками шириной 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, в то время как базовая сетка таблицы остаётся четырёхколоночной и четырёхстрочной. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом верхнем углу: `table.get_Item(1, 1)` в этом примере. Другие позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек за пределами диапазона не меняются.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Разделение ячеек таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблиц PowerPoint.

В этом примере создаётся таблица 4×4 с колоннами и строками шириной 70 пунктов и вызывается [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) для ячейки `(1, 1)`. Половина ширины ячейки 70 пунктов передаётся для создания двух ячеек одинаковой ширины.

После разделения две половины доступны как `table.get_Item(1, 1)` и `table.get_Item(2, 1)`. Сетка таблицы теперь содержит пять столбцов: ячейки, первоначально находившиеся в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Разделение объединённых ячеек по строке или столбцу**

Чтобы подготовить объединённые шаблонные ячейки к заполнению данными, используйте [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) для разделения вдоль существующей границы строки или [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) для разделения вдоль границы столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разделения; он относителен к объединённой области:

- Разделение по строке: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Разделение по столбцу: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Пример ожидает, что презентация содержит таблицу в виде первой формы на первом слайде, где ячейки `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижнего положения, он использует [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) и [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) для определения начала и проверяет обе области. `splitByRowSpan(1)` затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Получить результирующие ячейки из таблицы после разделения.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите результирующие ячейки по их координатам; здесь обе имеют span = 1, и [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) выводит `False`. Более крупные области могут оставаться частично объединёнными после одного разделения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пуста, но наследует форматирование ячейки, такое как заливка, границы и поля. Заполняйте ячейки после разделения и явно задавайте требуемое форматирование текста.

Сохранённая презентация содержит отдельные ячейки «Product A» и «Product B» с сохранённым форматированием шаблонных ячеек. Смотрите [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) для подробностей.

## **Изменение цвета фона ячейки таблицы**

Этот пример создаёт таблицу со столбцами шириной 150 пунктов и строками высотой 50 пунктов. Он использует [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) для выбора сплошной заливки и задаёт цвет, полученный через [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), как красный для ячейки `(2, 3)`, то есть третьего столбца и четвёртой строки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление изображения внутри ячейки таблицы**

Поместите входное изображение в рабочий каталог перед запуском примера. Оно загружается с помощью [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) и добавляется в коллекцию изображений презентации через [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Затем изображение назначается заливке рисунком ячейки `(0, 0)`, первой ячейки в таблице.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) растягивает изображение, заполняя ячейку, что может изменить его соотношение сторон. Ширины столбцов и высоты строк задаются в пунктах. Загруженное изображение освобождается в блоке `finally` после добавления в презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Можно ли задать разную толщину и стиль линий для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки рисунка в качестве фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подгоняется к новой ячейке; при заливке плитками плитки пересчитываются.

**Можно ли назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/python-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/формы. На практике ссылку назначают части текста или всему тексту в ячейке.

**Можно ли задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (блоки) с независимым форматированием — семейство шрифта, начертание, размер и цвет.