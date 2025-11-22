---
title: Управление строками и столбцами в таблицах PowerPoint с помощью Python
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/python-net/manage-rows-and-columns/
keywords:
- строка таблицы
- столбец таблицы
- первая строка
- заголовок таблицы
- клонировать строку
- клонировать столбец
- копировать строку
- копировать столбец
- удалить строку
- удалить столбец
- форматирование текста строки
- форматирование текста столбца
- стиль таблицы
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте строками и столбцами таблиц в PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET и ускоряйте редактирование презентаций и обновление данных."
---

## **Обзор**

В этой статье показано, как управлять строками и столбцами таблиц в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python. Вы узнаете, как добавлять, вставлять, клонировать и удалять строки или столбцы, помечать первую строку как заголовок, корректировать размеры и расположение, а также применять форматирование текста и стилей на уровне строки или столбца. Каждый шаг продемонстрирован с помощью компактных автономных фрагментов кода, основанных на API [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), чтобы вы могли быстро найти таблицу на слайде и изменить её структуру в соответствии с дизайном.

## **Установить первую строку как заголовок**

Пометьте первую строку таблицы как заголовок, чтобы явно различать заголовки столбцов и данные. В Aspose.Slides for Python достаточно включить параметр *First Row* таблицы, чтобы применить форматирование заголовка, определённое выбранным стилем таблицы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
1. Получите доступ к слайду по его индексу.
1. Пройдитесь по всем объектам [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), чтобы найти нужную таблицу.
1. Установите первую строку таблицы в качестве заголовка.

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation("table.pptx") as presentation:
    # Получить доступ к первому слайду.
    slide = presentation.slides[0]

    # Пройтись по объектам shapes и получить ссылку на таблицу.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Установить первую строку таблицы как заголовок.
    table.first_row = True
    
    # Сохранить презентацию на диск.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Клонировать строку или столбец таблицы**

Клонируйте любую строку или столбец таблицы и вставьте копию в нужное место таблицы. Дубликат сохраняет содержимое ячеек, форматирование и размеры, что позволяет быстро и последовательно расширять макеты.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
1. Получите доступ к слайду по его индексу.
1. Определите массив ширин столбцов.
1. Определите массив высот строк.
1. Добавьте [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) на слайд, используя `add_table(x, y, column_widths, row_heights)`.
1. Клонируйте строку таблицы.
1. Клонируйте столбец таблицы.
1. Сохраните изменённую презентацию.

```python
 import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    # Доступ к первому слайду.
    slide = presentation.slides[0]

    # Задать ширины столбцов и высоты строк.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Добавить таблицу на слайд.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Добавить текст в строку 1, столбец 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Добавить текст в строку 2, столбец 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Клонировать строку 1 в конец таблицы.
    table.rows.add_clone(table.rows[0], False)

    # Добавить текст в строку 1, столбец 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Добавить текст в строку 2, столбец 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Клонировать строку 2 как 4-ю строку таблицы.
    table.rows.insert_clone(3,table.rows[1], False)

    # Клонировать первый столбец в конец.
    table.columns.add_clone(table.columns[0], False)

    # Клонировать второй столбец по индексу 3 (четвертая позиция).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Сохранить презентацию на диск.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Удалить строку или столбец из таблицы**

Оптимизируйте таблицу, удаляя любую строку или столбец по индексу с помощью Aspose.Slides for Python — макет автоматически пересчитывается, сохраняя форматирование оставшихся ячеек. Это удобно для упрощения сеток данных или удаления заполнителей без необходимости воссоздавать таблицу.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
1. Получите доступ к слайду по его индексу.
1. Определите массив ширин столбцов.
1. Определите массив высот строк.
1. Добавьте ITable на слайд, используя `add_table(x, y, column_widths, row_heights)`.
1. Удалите строку таблицы.
1. Удалите столбец таблицы.
1. Сохраните изменённую презентацию.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Настроить форматирование текста на уровне строк таблицы**

Примените единообразный стиль текста ко всей строке таблицы одним шагом. С Aspose.Slides for Python вы можете установить семейство шрифта, размер, начертание, цвет и выравнивание для всех ячеек строки одновременно, чтобы заголовки или группы данных были согласованы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
1. Получите доступ к слайду по его индексу.
1. Получите доступ к соответствующему объекту [Table] на слайде.
1. Установите высоту шрифта для ячеек первой строки.
1. Установите выравнивание и правый отступ для ячеек первой строки.
1. Установите вертикальный тип текста для ячеек второй строки.
1. Сохраните изменённую презентацию.

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Установить высоту шрифта для ячеек первой строки.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Установить выравнивание текста и правый отступ для ячеек первой строки.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Установить вертикальный тип текста для ячеек второй строки.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
	
    # Сохранить презентацию на диск.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Настроить форматирование текста на уровне столбцов таблицы**

Примените единообразный стиль текста ко всему столбцу таблицы одновременно. С Aspose.Slides for Python можно задать семейство шрифта, размер, начертание, цвет и выравнивание для всех ячеек столбца, создавая согласованные вертикальные полосы для заголовков или данных.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию.
1. Получите доступ к слайду по его индексу.
1. Получите доступ к соответствующему объекту [Table] на слайде.
1. Установите высоту шрифта для ячеек первого столбца.
1. Установите выравнивание и правый отступ для ячеек первого столбца.
1. Установите вертикальный тип текста для ячеек второго столбца.
1. Сохраните изменённую презентацию.

```python
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Установить высоту шрифта для ячеек первого столбца.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Установить выравнивание текста и правый отступ для ячеек первого столбца.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Установить вертикальный тип текста для ячеек второго столбца.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Сохранить презентацию на диск.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```


## **Получить свойства стиля таблицы**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы вы могли повторно использовать их для другой таблицы или в другом месте. Следующий код Python демонстрирует, как получить свойства стиля из предустановленного стиля таблицы:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/шаблона, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не поддерживают встроенную сортировку или фильтры. Сначала отсортируйте данные в памяти, а затем заново заполните строки таблицы в этом порядке.

**Можно ли использовать полосатые (заштрихованные) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите полосатые столбцы, а затем переопределите отдельные ячейки локальным форматированием; форматирование уровня ячейки имеет приоритет над стилем таблицы.