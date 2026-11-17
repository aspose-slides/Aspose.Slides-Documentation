---
title: Управление ячейками таблиц в презентациях с использованием Python
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/python-java/manage-cells/
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
description: "Управляйте ячейками таблиц PowerPoint в Python: определяйте объединённые ячейки, удаляйте границы, разделяйте ячейки и задавайте цвета фона и изображения с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides позволяет вам получать доступ к ячейкам таблиц в презентациях PowerPoint и изменять их. Эта статья объясняет, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разбиения ячеек, изменить цвет фона ячейки и добавить изображение внутри ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, обновить форматирование ячеек через свойства ячейки и сохранить изменённую презентацию как файл PPTX.

Aspose.Slides использует индексы, начинающиеся с нуля, для доступа к ячейкам таблицы в порядке `(column, row)`.

## **Определить объединённую ячейку таблицы**

Пример открывает существующую презентацию и получает первую форму на первом слайде как таблицу. Предполагается, что слайд и форма существуют и что форма является таблицей. Затем он перебирает все строки и столбцы и использует [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) чтобы определить ячейки в объединённых областях. Для каждого совпадения он выводит координаты ячейки в порядке `row;column`, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) и стартовые координаты области, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) и [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

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

## **Удалить границы ячеек таблицы**

Создайте [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) и добавьте таблицу на её первый слайд с помощью [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable). Ширины столбцов, высоты строк и позиция таблицы задаются в пунктах. Пример устанавливает все четыре границы ячеек в [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), делая их невидимыми.

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

## **Добавить диагональные границы ячейки**

Используйте [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown) чтобы нарисовать линию от верхнего левого угла к нижнему правому, и [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp) чтобы нарисовать линию от нижнего левого угла к верхнему правому. Диагональ может отмечать заголовок угла. Обе диагонали могут образовывать X, чтобы пометить ячейку как неприменимую.

Каждая диагональ является [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). В её [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) используйте [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) для выбора [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) и выберите цвет через [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor). Установите ширину линии в пунктах с помощью [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth).

Пример создаёт три ячейки в одной строке: красную диагональ вниз, синюю диагональ вверх и обе диагонали. Он оставляет границы ячеек сверху, снизу, слева и справа без изменений.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Диагональ — это свойство форматирования, а не разрезка ячейки. Каждая ячейка сохраняет один текстовый фрейм, доступ к которому осуществляется через [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame). Области по обе стороны от диагонали нельзя редактировать независимо.

Сохранённая таблица, отображаемая в Microsoft PowerPoint:

![Три ячейки таблицы с красной диагональю от верхнего левого к нижнему правому, синей диагональю от нижнего левого к верхнему правому и обеими диагоналями, образующими X.](diagonal-cell-borders.png)

*Слева направо: диагональ вниз (красная, 3 пт), диагональ вверх (синяя, 5 пт) и обе диагонали.*

## **Объединить ячейки таблицы**

Используйте [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells) чтобы объединить прямоугольный диапазон ячеек таблицы в одну ячейку. Укажите ячейки в левом верхнем и правом нижнем углах диапазона. Последний аргумент определяет, может ли объединение включать ячейки за пределами указанного диапазона; `False` сохраняет объединение внутри этого диапазона.

Пример создаёт таблицу 4 × 4 с колонками и строками по 70 пунктов, затем объединяет четыре центральные ячейки от `(1, 1)` до `(2, 2)`. Получившаяся ячейка охватывает два столбца и две строки, в то время как базовая сетка таблицы остаётся из четырёх столбцов и четырёх строк. Чтобы получить доступ к содержимому или форматированию объединённой ячейки, используйте её позицию в левом верхнем углу: `table.get_Item(1, 1)` в этом примере. Остальные позиции в объединённом диапазоне остаются частью сетки таблицы, поэтому индексы ячеек вне диапазона не меняются.

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

## **Разделить ячейки таблицы**

Объединение ячеек в предыдущем примере сохраняет сетку таблицы. Разделение ячейки может добавить новый столбец в сетку и изменить индексы столбцов ячеек справа от неё. Aspose.Slides следует модели сетки таблицы PowerPoint.

Этот пример создаёт таблицу 4 × 4 с колонками и строками по 70 пунктов и вызывает [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) для ячейки `(1, 1)`. Половина ширины ячейки 70 пунктов передаётся для создания двух ячеек одинаковой ширины.

После этого разделения две половины доступны как `table.get_Item(1, 1)` и `table.get_Item(2, 1)`. Сетка таблицы теперь имеет пять столбцов: ячейки, изначально в столбцах 2 и 3, перемещаются в столбцы 3 и 4 соответственно. Индексы строк остаются без изменений. Используйте обновлённые индексы столбцов при доступе к ячейкам после разделения.

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

<!-- visual-explanation:manage-cells:start -->
[![Необъединённая ячейка шириной 70 пунктов разбивается на две ячейки по 35 пунктов, добавляя пятый столбец сетки и сдвигая индексы справа.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Разделение ширины влияет на ячейку (1, 1), используя индексы (столбец, строка), начинающиеся с нуля. Другие строки сохраняют ячейку, охватывающую обе новые позиции столбцов.*
<!-- visual-explanation:manage-cells:end -->

### **Разделить объединённые ячейки по строке или столбцу**

Чтобы подготовить объединённые шаблонные ячейки к заполнению данными, используйте [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) чтобы разделить вдоль существующей границы строки, или [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan) чтобы разделить вдоль границы столбца.

Аргумент `index` считает строки в верхней части или столбцы в левой части разделения; он относительно объединённой области:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Пример ожидает, что презентация содержит таблицу в первой форме на первом слайде, где `(1, 2)` и `(1, 3)` объединены вертикально. Начиная с нижней позиции, он использует [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) и [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) чтобы найти начало и проверяет оба охвата. `splitByRowSpan(1)` затем разделяет строки 2 и 3 для названий продуктов. Для горизонтального объединения двух столбцов используйте `splitByColSpan(1)` вместо этого.

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

        # Получить получившиеся ячейки из таблицы после разделения.
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

Сетка таблицы и окружающие индексы ячеек остаются без изменений. Получите полученные ячейки по их координатам; здесь обе имеют охваты 1 и [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) выводит `False`. Более крупные области могут оставаться частично объединёнными после одного разделения.

Исходный текст и его форматирование остаются в верхней (или левой) ячейке; новая ячейка пуста, но наследует форматирование ячейки, такое как заливка, границы и отступы. Заполняйте ячейки после разделения и задавайте любые требуемые форматы текста явно.

Сохранённая презентация содержит отдельные ячейки "Product A" и "Product B" с сохранённым форматированием шаблона ячейки. См. [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) для деталей.

### **Разделить ячейку на определённой высоте**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) принимает высоту верхней части в пунктах. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) принимает количество существующих строк сетки в верхней части. Чтобы центрировать ячейку высотой 40 пунктов в правом столбце, вычтите 40 из фактической высоты ячейки и равномерно разделите оставшееся пространство сверху и снизу.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Первое разделение добавляет строку сетки и оставляет нижние 90 пунктов в ячейке `(1, 1)`. Второе разделение делит эту ячейку на среднюю ячейку высотой 40 пунктов и нижнюю ячейку высотой 50 пунктов. Правый столбец теперь имеет три ячейки высотой 50, 40 и 50 пунктов сверху вниз. Левая ячейка охватывает все три строки и сохраняет исходную высоту 140 пунктов.

![Левая ячейка охватывает всю высоту таблицы рядом с тремя ячейками, где средняя находится в центре.](split-by-height.png)

## **Изменить цвет фона ячейки таблицы**

Этот пример создаёт таблицу со столбцами шириной 150 пунктов и строками высотой 50 пунктов. Он использует [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) чтобы выбрать сплошную заливку и устанавливает цвет, возвращаемый [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor), в красный для ячейки `(2, 3)`, в третьем столбце и четвёртой строке.

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

## **Добавить изображение внутрь ячейки таблицы**

Поместите входное изображение в рабочий каталог перед запуском этого примера. Он загружает изображение с помощью [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) и добавляет его в коллекцию изображений презентации через [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Затем он назначает изображение заполнению картинки ячейки `(0, 0)`, первой ячейки в таблице.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) растягивает изображение, чтобы заполнить ячейку, что может изменить её соотношение сторон. Ширины колонок и высоты строк задаются в пунктах. Загруженное изображение освобождается в блоке `finally` после его добавления в презентацию.

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

## **Вопросы и ответы**

**Могу ли я установить разную толщину линий и стили для разных сторон одной ячейки?**

Да. Границы [верхний](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[нижний](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[левый](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[правый](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки как фон ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при замостке плитки пересчитываются.

**Могу ли я назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/python-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку части или всему тексту в ячейке.

**Могу ли я установить разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (отрезки) с независимым форматированием — семейство шрифта, стиль, размер и цвет.