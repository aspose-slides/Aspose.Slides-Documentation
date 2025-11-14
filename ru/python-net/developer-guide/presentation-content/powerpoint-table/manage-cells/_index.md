---
title: Управление ячейками
type: docs
weight: 30
url: /ru/python-net/manage-cells/
keywords: "Таблица, объединенные ячейки, разделенные ячейки, изображение в ячейке таблицы, Python, Aspose.Slides для Python через .NET"
description: "Ячейки таблицы в презентациях PowerPoint на Python"
---

## **Определите объединенную ячейку таблицы**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите таблицу с первого слайда. 
3. Переберите строки и столбцы таблицы, чтобы найти объединенные ячейки.
4. Напечатайте сообщение, когда будут найдены объединенные ячейки.

Этот код на Python показывает, как определить объединенные ячейки таблицы в презентации:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # предполагая, что #0.Shape#0 - это таблица
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("Ячейка 01 является частью объединенной ячейки с RowSpan=2 и ColSpan=3, начиная с ячейки 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **Удаление границ ячеек таблицы**
1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд через его индекс. 
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд с помощью метода `AddTable`.
6. Переберите каждую ячейку, чтобы очистить верхние, нижние, правые и левые границы.
7. Сохраните измененную презентацию как файл PPTX.

Этот код на Python показывает, как удалить границы из ячеек таблицы:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as pres:
   # Получает первый слайд
    sld = pres.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # Добавляет фигуру таблицы на слайд
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Устанавливает формат границ для каждой ячейки
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Записывает файл PPTX на диск
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Нумерация в объединенных ячейках**
Если мы объединим 2 пары ячеек (1, 1) x (2, 1) и (1, 2) x (2, 2), результирующая таблица будет нумероваться. Этот код на Python демонстрирует процесс:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as presentation:
    # Получает первый слайд
    sld = presentation.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Добавляет фигуру таблицы на слайд
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Устанавливает формат границ для каждой ячейки
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Объединяет ячейки (1, 1) x (2, 1)
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # Объединяет ячейки (1, 2) x (2, 2)
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

Затем мы дальше объединим ячейки, объединив (1, 1) и (1, 2). Результат — таблица, содержащая большую объединенную ячейку в центре: 

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as presentation:
    # Получает первый слайд
    slide = presentation.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # Добавляет фигуру таблицы на слайд
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Устанавливает формат границ для каждой ячейки
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Объединяет ячейки (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Объединяет ячейки (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Объединяет ячейки (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    # Записывает файл PPTX на диск
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Нумерация в разделенной ячейке**
В предыдущих примерах, когда ячейки таблицы были объединены, нумерация или номер в других ячейках не изменялись. 

На этот раз мы берем обычную таблицу (таблицу без объединенных ячеек) и затем пробуем разделить ячейку (1,1), чтобы получить специальную таблицу. Вы можете обратить внимание на нумерацию этой таблицы, которая может показаться странной. Однако именно так Microsoft PowerPoint нумерует ячейки таблиц, и Aspose.Slides делает то же самое. 

Этот код на Python демонстрирует описанный процесс:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, который представляет файл PPTX
with slides.Presentation() as presentation:
    # Получает первый слайд
    slide = presentation.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Добавляет фигуру таблицы на слайд
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Устанавливает формат границ для каждой ячейки
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Объединяет ячейки (1, 1) x (2, 1)
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Объединяет ячейки (1, 2) x (2, 2)
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Разделяет ячейку (1, 1). 
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Записывает файл PPTX на диск
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Изменение цвета фона ячейки таблицы**

Этот код на Python показывает, как изменить цвет фона ячейки таблицы:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # создаем новую таблицу
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # устанавливаем цвет фона для ячейки 
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавить изображение внутрь ячейки таблицы**
1. Создайте экземпляр класса `Presentation`.
2. Получите ссылку на слайд через его индекс.
3. Определите массив столбцов с шириной.
4. Определите массив строк с высотой.
5. Добавьте таблицу на слайд через метод `AddTable`. 
6. Создайте объект `Bitmap`, чтобы хранить файл изображения.
7. Добавьте изображение bitmap в объект `IPPImage`.
8. Установите `FillFormat` для ячейки таблицы в `Picture`.
9. Добавьте изображение в первую ячейку таблицы.
10. Сохраните измененную презентацию как файл PPTX.

Этот код на Python показывает, как разместить изображение внутри ячейки таблицы при создании таблицы:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получает первый слайд
    islide = presentation.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # Добавляет фигуру таблицы на слайд
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # Создает объект изображения Bitmap для хранения файла изображения
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # Создает объект IPPImage, используя объект bitmap
    imgx1 = presentation.images.add_image(image)

    # Добавляет изображение в первую ячейку таблицы
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # Сохраняет PPTX на диск
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```