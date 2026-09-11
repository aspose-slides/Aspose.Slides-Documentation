---
title: Управление ячейками таблиц в презентациях с помощью Python
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/python-java/manage-cells/
keywords:
- ячейка таблицы
- объединить ячейки
- удалить границу
- разделить ячейку
- изображение в ячейке
- цвет фона
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Легко управляйте ячейками таблиц в PowerPoint с помощью Aspose.Slides для Python через Java. Овладейте быстрым доступом, изменением и стилизацией ячеек для беспроблемной автоматизации слайдов."
---
## **Обзор**

Aspose.Slides позволяет получать доступ к ячейкам таблиц в презентациях PowerPoint и изменять их. В этой статье объясняется, как определить объединённые ячейки таблицы, удалить границы ячеек, работать с нумерацией ячеек после объединения или разделения, изменить фон ячейки и добавить изображение внутрь ячейки таблицы. Примеры показывают, как создать или открыть презентацию, получить таблицу со слайда, изменить форматирование ячеек через свойства ячеек и сохранить изменённую презентацию в файл PPTX.

## **Определение объединённой ячейки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите таблицу с первого слайда.
3. Пройдитесь по строкам и столбцам таблицы, чтобы найти объединённые ячейки.
4. Выведите сообщение, когда найдены объединённые ячейки.

Этот код на Python показывает, как определить объединённые ячейки таблицы в презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Предположим, что первая фигура на первом слайде является таблицей.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Удаление границ ячеек таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите список ширин столбцов.
4. Определите список высот строк.
5. Добавьте таблицу на слайд с помощью метода [addTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addTable).
6. Пройдитесь по каждой ячейке, чтобы очистить верхнюю, нижнюю, правую и левую границы.
7. Сохраните изменённую презентацию в файл PPTX.

Этот код на Python показывает, как удалить границы из ячеек таблицы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Задать ширины столбцов и высоты строк.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Добавить таблицу на слайд.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Установить формат границы для каждой ячейки.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Сохранить презентацию в файл PPTX.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Нумерация в объединённых ячейках**

Если мы объединим две пары ячеек, (1, 1) и (2, 1), а также (1, 2) и (2, 2), полученная таблица сохраняет свою нумерацию ячеек. Этот код на Python демонстрирует процесс:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Задать ширины столбцов и высоты строк.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Добавить таблицу на слайд.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Установить формат границы для каждой ячейки.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Объединить ячейки (1, 1) и (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Объединить ячейки (1, 2) и (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Сохранить презентацию в файл PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Затем мы продолжаем объединять ячейки, объединяя (1, 1) и (1, 2). В результате получаем таблицу с большой объединённой ячейкой в центре:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Задать ширины столбцов и высоты строк.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Добавить таблицу на слайд.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Установить формат границы для каждой ячейки.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Объединить ячейки (1, 1) и (2, 1).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Объединить ячейки (1, 2) и (2, 2).
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Объединить ячейки (1, 1) и (1, 2).
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Сохранить презентацию в файл PPTX.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Нумерация в разделённой ячейке**

В предыдущих примерах объединение ячеек таблицы не меняло нумерацию остальных ячеек.

На этот раз мы берём обычную таблицу (таблицу без объединённых ячеек) и пытаемся разделить ячейку (1, 1), получая особую таблицу. Обратите внимание на нумерацию этой таблицы — она может показаться странной. Однако так Microsoft PowerPoint нумерует ячейки таблиц, и Aspose.Slides делает то же самое.

Этот код на Python демонстрирует описанный процесс:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Задать ширины столбцов и высоты строк.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Добавить таблицу на слайд.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Установить формат границы для каждой ячейки.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Разделить ячейку (1, 1).
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Сохранить презентацию в файл PPTX.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Изменение фонового цвета ячейки таблицы**

Этот код на Python показывает, как изменить фон ячейки таблицы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Задать ширины столбцов и высоты строк.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Добавить таблицу на слайд.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Установить фоновый цвет ячейки.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Сохранить презентацию в файл PPTX.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление изображения в ячейку таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите список ширин столбцов.
4. Определите список высот строк.
5. Добавьте таблицу на слайд с помощью метода [addTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addTable).
6. Загрузите файл изображения с помощью [Images.fromFile](https://reference.aspose.com/slides/ru/python-java/aspose.slides/images/#fromFile).
7. Добавьте изображение в презентацию, создав объект [PPImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/ppimage/).
8. Установите для ячейки таблицы тип заполнения [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/fillformat/) — [FillType.Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/filltype/#Picture).
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните изменённую презентацию в файл PPTX.

Этот код на Python показывает, как разместить изображение внутри ячейки таблицы при её создании:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Получить первый слайд.
    slide = presentation.getSlides().get_Item(0)

    # Задать ширины столбцов и высоты строк.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Добавить таблицу на слайд.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Создать изображение презентации из файла изображения.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Добавить изображение в первую ячейку таблицы.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Сохранить презентацию в файл PPTX.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я задать разную толщину линий и стили для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellformat/#getBorderRight) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут отличаться. Это логически вытекает из управления границами каждой стороны ячейки, продемонстрированного в статье.

**Что происходит с изображением, если я изменю размер столбца/строки после установки картинки в качестве фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при замощении плитки пересчитываются. В статье упоминаются режимы отображения изображения в ячейке.

**Могу ли я назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/python-java/manage-hyperlinks/) задаются на уровне текста (части) внутри текстового фрейма ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку либо части, либо всему тексту в ячейке.

**Могу ли я задать разные шрифты внутри одной ячейки?**

Да. Текстовый фрейм ячейки поддерживает [portions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) (проснования) с независимым форматированием — семейство шрифта, стиль, размер и цвет.