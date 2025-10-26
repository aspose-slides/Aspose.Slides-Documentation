---
title: Управление таблицами презентаций с помощью Python
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/python-net/developer-guide/presentation-content/powerpoint-table/manage-table/
keywords:
- добавить таблицу
- создать таблицу
- доступ к таблице
- соотношение сторон
- выравнивание текста
- форматирование текста
- стиль таблицы
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создание и редактирование таблиц в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Откройте простые примеры кода, чтобы оптимизировать работу с таблицами."
---

## **Обзор**

Таблица в PowerPoint — эффективный способ представления информации. Информация, расположенная в сетке ячеек (строк и столбцов), представлена ясно и легко воспринимается.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) , класс [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) и другие связанные типы, которые помогают создавать, обновлять и управлять таблицами в любой презентации.

## **Создание таблиц с нуля**

В этом разделе показано, как создать таблицу с нуля в Aspose.Slides, добавив форму таблицы на слайд, определив её строки и столбцы и задав точные размеры. Вы также узнаете, как заполнять ячейки текстом, настраивать выравнивание и границы, а также настраивать внешний вид таблицы.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получить ссылку на слайд по его индексу.
3. Определить массив ширин столбцов.
4. Определить массив высот строк.
5. Добавить [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) на слайд.
6. Пройтись по каждой [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) и задать формат верхней, нижней, правой и левой границ.
7. Объединить первые две ячейки в первой строке таблицы.
8. Получить доступ к [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) ячейки [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) .
9. Добавить текст в [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) .
10. Сохранить изменённую презентацию.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Нумерация в стандартных таблицах**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка в таблице имеет индекс (0, 0) (столбец 0, строка 0).

Для примера, в таблице с 4 столбцами и 4 строками ячейки нумеруются так:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Следующий пример на Python показывает, как ссылаться на ячейки, используя эту нумерацию с нуля:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Доступ к существующей таблице**

В этом разделе объясняется, как найти и работать с существующей таблицей в презентации с помощью Aspose.Slides. Вы узнаете, как находить таблицу на слайде, получать доступ к её строкам, столбцам и ячейкам, а также обновлять содержимое или форматирование.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получить ссылку на слайд, содержащий таблицу, по его индексу.
3. Пройтись по всем объектам [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)..., пока не найдёте таблицу.
4. Использовать объект [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)... для работы с таблицей.
5. Сохранить изменённую презентацию.

{{% alert color="info" %}}
Если на слайде несколько таблиц, лучше искать нужную таблицу по свойству `alternative_text`.
{{% /alert %}}

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Выравнивание текста в таблицах**

В этом разделе показано, как управлять выравниванием текста внутри ячеек таблицы с помощью Aspose.Slides. Вы научитесь задавать горизонтальное и вертикальное выравнивание ячеек, чтобы содержание было чётким и последовательным.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получить ссылку на слайд по его индексу.
3. Добавить объект [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) на слайд.
4. Получить объект [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) из таблицы.
5. Выравнять текст по вертикали.
6. Сохранить изменённую презентацию.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка форматирования текста на уровне таблицы**

В этом разделе показано, как применить форматирование текста на уровне таблицы в Aspose.Slides, чтобы каждая ячейка наследовала единый стиль. Вы научитесь задавать размеры шрифта, выравнивание и отступы глобально.

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получить ссылку на слайд по его индексу.
3. Добавить [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) на слайд.
4. Задать размер шрифта (высоту шрифта) для текста.
5. Задать выравнивание абзаца и отступы.
6. Задать вертикальную ориентацию текста.
7. Сохранить изменённую презентацию.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Применение встроенных стилей таблиц**

Aspose.Slides позволяет форматировать таблицы, используя предопределённые стили непосредственно в коде. Пример демонстрирует создание таблицы, применение встроенного стиля и сохранение результата — эффективный способ обеспечить согласованное, профессиональное форматирование.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Блокировка соотношения сторон таблиц**

Соотношение сторон формы — это отношение её размеров. Aspose.Slides предоставляет свойство `aspect_ratio_locked`, которое позволяет блокировать соотношение сторон для таблиц и других форм.

Следующий пример на Python показывает, как блокировать соотношение сторон для таблицы:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица имеет свойство [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) , а абзацы имеют [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/) . Использование обоих обеспечивает правильный порядок RTL и отображение внутри ячеек.

**Как предотвратить перемещение или изменение размера таблицы пользователями в окончательном файле?**

Используйте [shape locks](/slides/ru/python-net/applying-protection-to-presentation/) чтобы отключить перемещение, изменение размера, выбор и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать область ячейки в соответствии с выбранным режимом (растягивание или мозаика).