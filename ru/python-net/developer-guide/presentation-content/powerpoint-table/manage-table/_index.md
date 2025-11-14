---
title: Управление таблицей
type: docs
weight: 10
url: /ru/python-net/manage-table/
keywords: "Таблица, создание таблицы, доступ к таблице, соотношение сторон таблицы, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Создайте и управляйте таблицами в презентациях PowerPoint на Python"

---

Таблица в PowerPoint — это эффективный способ отображения и представления информации. Информация в сетке ячеек (расположенных в строках и столбцах) проста и понятна.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/), класс [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/), интерфейс [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами во всех видах презентаций.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) на слайд с помощью метода `add_table(x, y, column_widths, row_heights)`.
6. Пройдите по каждой [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/), чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/).
9. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
10. Сохраните измененную презентацию.

Этот код на Python показывает, как создать таблицу в презентации:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PPTX
with slides.Presentation() as pres:
    # Получает доступ к первому слайду
    sld = pres.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Добавляет форму таблицы на слайд
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Устанавливает формат границ для каждой ячейки
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # Объединяет ячейки 1 и 2 первой строки
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # Добавляет текст в объединенную ячейку
    tbl.rows[0][0].text_frame.text = "Объединенные ячейки"

    # Сохраняет презентацию на диске
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек простая и начинается с нуля. Первая ячейка в таблице индексируется как 0,0 (столбец 0, строка 0).

Например, ячейки в таблице с 4 колонками и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код на Python показывает, как указать нумерацию для ячеек в таблице:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PPTX
with slides.Presentation() as pres:
    # Получает доступ к первому слайду
    sld = pres.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Добавляет форму таблицы на слайд
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

    # Сохраняет презентацию на диск
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к существующей таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

2. Получите ссылку на слайд, содержащий таблицу, через его индекс. 

3. Создайте объект [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) и установите его в null.

4. Пройдите по всем объектам [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), пока не найдете таблицу.

   Если вы подозреваете, что слайд, с которым вы работаете, содержит только одну таблицу, вы можете просто проверить все фигуры, которые он содержит. Когда фигура определяется как таблица, вы можете привести ее к объекту [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Но если слайд, с которым вы работаете, содержит несколько таблиц, вы лучше поискать нужную таблицу по ее `alternative_text`. 

5. Используйте объект [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) для работы с таблицей. В примере ниже мы добавили новую строку в таблицу.

6. Сохраните измененную презентацию.

Этот код на Python показывает, как получить доступ и работать с существующей таблицей:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий файл PPTX
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # Получает доступ к первому слайду
    sld = pres.slides[0]

    # Инициализирует null TableEx
    tbl = None

    # Проходит по фигурам и устанавливает ссылку на найденную таблицу
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Устанавливает текст для первой колонки второй строки
    tbl.rows[0][1].text_frame.text = "Новый"

    # Сохраняет измененную презентацию на диск
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите ссылку на слайд через его индекс. 
3. Добавьте объект [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) на слайд. 
4. Получите доступ к объекту [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) из таблицы. 
5. Получите доступ к [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/).
6. Выравните текст по вертикали.
7. Сохраните измененную презентацию.

Этот код на Python показывает, как выровнять текст в таблице:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получает первый слайд 
    slide = presentation.slides[0]

    # Определяет столбцы с ширинами и строки с высотами
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # Добавляет форму таблицы на слайд
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # Получает доступ к текстовому кадру
    txtFrame = tbl.rows[0][0].text_frame

    # Создает объект Paragraph для текстового кадра
    paragraph = txtFrame.paragraphs[0]

    # Создает объект Portion для абзаца
    portion = paragraph.portions[0]
    portion.text = "текст здесь"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Выравнивает текст по вертикали
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Сохраняет презентацию на диск
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Настройка форматирования текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд через его индекс. 
3. Получите доступ к объекту [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) со слайда.
4. Установите `font_height` для текста. 
5. Установите `alignment` и `margin_right`. 
6. Установите `text_vertical_type`.
7. Сохраните измененную презентацию. 

Этот код на Python показывает, как применить предпочтительные параметры форматирования к тексту в таблице:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Устанавливает высоту шрифта ячеек таблицы
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # Устанавливает выравнивание текста ячеек таблицы и правый отступ одним вызовом
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # Устанавливает вертикальный тип текста для ячеек таблицы
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)


    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Получение свойств стиля таблицы**

Aspose.Slides позволяет вам извлекать стильовые свойства для таблицы, чтобы вы могли использовать эти данные для другой таблицы или где-то еще. Этот код на Python показывает, как получить стильовые свойства из предустановленного стиля таблицы:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической фигуры — это соотношение ее размеров в разных измерениях. Aspose.Slides предоставляет свойство `aspect_ratio_locked`, чтобы вы могли заблокировать настройку соотношения сторон для таблиц и других фигур. 

Этот код на Python показывает, как заблокировать соотношение сторон для таблицы:

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("Блокировка соотношения сторон установлена: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("Блокировка соотношения сторон установлена: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```