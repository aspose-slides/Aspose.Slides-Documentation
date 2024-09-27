---
title: Управление строками и колонками
type: docs
weight: 20
url: /ru/python-net/manage-rows-and-columns/
keywords: "Таблица, строки и колонки таблицы, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Управление строками и колонками таблицы в презентациях PowerPoint на Python"
---

Чтобы управлять строками и колонками таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), интерфейс [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) и многие другие типы.

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд через его индекс.
3. Создайте объект [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) и установите его в null.
4. Переберите все объекты [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) для поиска соответствующей таблицы.
5. Установите первую строку таблицы в качестве заголовка.

Этот код на Python показывает, как установить первую строку таблицы в качестве заголовка:

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation("table.pptx") as pres:
    # Получает доступ к первому слайду
    sld = pres.slides[0]

    # Инициализирует null TableEx
    tbl = None

    # Перебирает фигуры и устанавливает ссылку на таблицу
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Устанавливает первую строку таблицы в качестве заголовка
    tbl.first_row = True
    
    # Сохраняет презентацию на диск
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование строки или колонки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд через его индекс.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) на слайд с помощью метода `add_table(x, y, column_widths, row_heights)`.
6. Клонируйте строку таблицы.
7. Клонируйте колонку таблицы.
8. Сохраните измененную презентацию.

Этот код на Python показывает, как клонировать строку или колонку таблицы PowerPoint:

```python
 import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation() as presentation:

    # Получает доступ к первому слайду
    sld = presentation.slides[0]

    # Определяет ширины колонок и высоты строк
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Добавляет фигуру таблицы на слайд
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Добавляет текст в ячейку 1 строки 1
    table.rows[0][0].text_frame.text = "Ячейка 1 Строка 1"

    # Добавляет текст в ячейку 1 строки 2
    table.rows[1][0].text_frame.text = "Ячейка 1 Строка 2"

    # Клонирует строку 1 в конец таблицы
    table.rows.add_clone(table.rows[0], False)

    # Добавляет текст в ячейку 2 строки 1
    table.rows[0][1].text_frame.text = "Ячейка 2 Строка 1"

    # Добавляет текст в ячейку 2 строки 2
    table.rows[1][1].text_frame.text = "Ячейка 2 Строка 2"

    # Клонирует строку 2 как 4-ю строку таблицы
    table.rows.insert_clone(3,table.rows[1], False)

    # Клонирует первую колонку в конец
    table.columns.add_clone(table.columns[0], False)

    # Клонирует 2-ю колонку по индексу 4-й колонки
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Сохраняет презентацию на диск
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Удалить строку или колонку из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд через его индекс.
3. Определите массив `columnWidth`.
4. Определите массив `rowHeight`.
5. Добавьте объект [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) на слайд с помощью метода `add_table(x, y, column_widths, row_heights)`.
6. Удалите строку таблицы.
7. Удалите колонку таблицы.
8. Сохраните измененную презентацию.

Этот код на Python показывает, как удалить строку или колонку из таблицы:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить форматирование текста на уровне строки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд через его индекс.
3. Получите доступ к соответствующему объекту [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) на слайде.
4. Установите `font_height` ячеек первой строки.
5. Установите `alignment` и `margin_right` ячеек первой строки.
6. Установите `text_vertical_type` ячеек второй строки.
7. Сохраните измененную презентацию.

Этот код на Python демонстрирует операцию.

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Устанавливает высоту шрифта ячеек первой строки
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # Устанавливает выравнивание текста и правый отступ ячеек первой строки
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # Устанавливает вертикальный тип текста ячеек второй строки
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)
	
    # Сохраняет презентацию на диск
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить форматирование текста на уровне колонки таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд через его индекс.
3. Получите доступ к соответствующему объекту [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) на слайде.
4. Установите `font_height` ячеек первой колонки.
5. Установите `alignment` и `margin_right` ячеек первой колонки.
6. Установите `text_vertical_type` ячеек второй колонки.
7. Сохраните измененную презентацию.

Этот код на Python демонстрирует операцию: 

```python
import aspose.slides as slides

# Создает экземпляр класса Presentation
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Устанавливает высоту шрифта ячеек первой колонки
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # Устанавливает выравнивание текста и правый отступ ячеек первой колонки 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # Устанавливает вертикальный тип текста ячеек второй колонки
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # Сохраняет презентацию на диск
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет вам извлекать свойства стиля для таблицы, чтобы вы могли использовать эти детали для другой таблицы или где-то еще. Этот код на Python показывает, как получить свойства стиля из предварительно заданного стиля таблицы:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```