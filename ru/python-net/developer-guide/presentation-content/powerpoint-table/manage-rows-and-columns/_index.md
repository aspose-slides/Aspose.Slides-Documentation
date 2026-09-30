---
title: Управление строками и столбцами в таблицах PowerPoint с использованием Python
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
description: "Управляйте строками и столбцами таблицы в PowerPoint с помощью Aspose.Slides for Python via .NET и ускоряйте редактирование презентаций и обновление данных."
---
## **Введение**

Aspose.Slides for Python via .NET позволяет управлять структурой таблицы и её форматированием в презентациях PowerPoint через класс [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Вы можете задать строку заголовка, клонировать или удалять строки и столбцы, а также применять форматирование текста к всей строке или столбцу.

В этой статье объясняются эти операции с примерами на Python. Также показано, как получить предустановку стиля таблицы, чтобы её можно было переиспользовать. Индексы строк и столбцов таблицы нумеруются с нуля.

## **Управление высотой строки**

Используйте [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) для установки минимальной высоты строки в пунктах. Это нижняя граница, а не фиксированная высота. [Row.height](https://reference.aspose.com/slides/python-net/aspose.slides/row/height/) возвращает фактическую высоту и только для чтения. Доступ к строке осуществляется через [Table.rows](https://reference.aspose.com/slides/python-net/aspose.slides/table/rows/).

В примере загружается файл [row-height-input.pptx](row-height-input.pptx), в котором таблица является первой фигурой на первом слайде. Первая строка начинается с 70 пунктов. Ячейки используют 18‑пунктовый шрифт Arial, перенос текста и отступы по 6 пунктов сверху и снизу; более длинный текст во втором столбце переносится на несколько строк. Пример увеличивает минимум до 100 пунктов, затем уменьшает его до 20 пунктов, печатает фактическую высоту после каждого изменения и сохраняет оба результата.

```python
import aspose.slides as slides

with slides.Presentation("row-height-input.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    row = table.rows[0]

    row.minimal_height = 100
    print(f"Increased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-increased.pptx", slides.export.SaveFormat.PPTX)

    row.minimal_height = 20
    print(f"Decreased: minimum = {row.minimal_height:.1f}, actual = {row.height:.1f} pt")
    presentation.save("row-height-decreased.pptx", slides.export.SaveFormat.PPTX)
```

При работе с предоставленной презентацией увеличение минимума добавляет пространство к строке. Уменьшение убирает это дополнительное пространство, но фактическая высота остаётся больше 20 пунктов, поскольку текст и отступы ячеек требуют больше места. Снижение только минимума не может заставить строку стать ниже пространства, требуемого её содержимым.

Несколько факторов влияют на фактическую высоту:

- **Текст и размер шрифта:** более длинный текст, явные разрывы строк или более крупный шрифт могут требовать больше вертикального пространства.
- **Перенос и ширина столбца:** при включённом переносе более узкий [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) может привести к большему количеству строк. Более широкий столбец уменьшит требуемое вертикальное пространство.
- **Отступы ячеек:** [Cell.margin_top](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_top/) и [Cell.margin_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_bottom/) добавляют вертикальное пространство. [Cell.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_left/) и [Cell.margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/cell/margin_right/) уменьшают доступную ширину для текста и могут вызвать дополнительный перенос.

Для этой таблицы без объединённых ячеек ячейка, требующая наибольшего вертикального пространства, определяет ограничение снизу для всей строки. Чтобы сделать строку короче, возможно, придётся сократить текст, уменьшить размер шрифта или отступы, либо увеличить ширину столбца.

Изображения ниже показывают одну и ту же таблицу в одинаковом масштабе. В данном запуске фактические высоты составили 70, 100 и 55,2 пункта: последняя строка осталась выше своего минимального значения в 20 пунктов. Точные измерения текста могут различаться в зависимости от шрифтов, доступных в вашей среде. Скачайте сохранённые результаты: [increased minimum](row-height-increased.pptx) и [decreased minimum](row-height-decreased.pptx).

| Оригинал: минимум 70 pt, фактически 70 pt | Увеличенный минимум: 100 pt, фактически 100 pt | Уменьшенный минимум: 20 pt, фактически 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **Установка первой строки как заголовка**

Используйте свойство [first_row](https://reference.aspose.com/slides/python-net/aspose.slides/table/first_row/) для пометки первой строки как заголовка. Её внешний вид зависит от применённого к таблице стиля.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите первую страницу.
3. Получите таблицу, хранящуюся как первая фигура на странице.
4. Включите форматирование заголовка для её первой строки.
5. Сохраните изменённую презентацию.

В примере требуется файл `table.pptx` с таблицей в первой фигуре первого слайда. Он включает форматирование заголовка для первой строки и сохраняет файл `First_row_header.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]
    table.first_row = True

    presentation.save("First_row_header.pptx", slides.export.SaveFormat.PPTX)
```

## **Клонирование строки или столбца таблицы**

Клонируйте строки или столбцы, чтобы переиспользовать их содержимое и форматирование. Вы можете добавить копию в конец таблицы или вставить её в конкретную позицию.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите первую страницу.
3. Задайте ширины столбцов и высоты строк.
4. Добавьте таблицу с помощью метода [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Клонируйте необходимые строки.
6. Клонируйте необходимые столбцы.
7. Сохраните изменённую презентацию.

Пример требует `Test.pptx` с как минимум одним слайдом. Он создаёт таблицу из трёх столбцов и пяти строк, размеры указаны в пунктах. Затем добавляет копии первой строки и первого столбца, после чего вставляет копии второй строки и второго столбца в позицию с индексом 3 (четвёртая позиция). Получившаяся таблица содержит семь строк и пять столбцов. Параметр `False` отключает клонирование в смежные объединённые строки или столбцы; в этой таблице объединённых ячеек нет.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[0][0].text_frame.text = "Row 1 Cell 1"
    table.rows[0][1].text_frame.text = "Row 1 Cell 2"
    table.rows.add_clone(table.rows[0], False)

    table.rows[1][0].text_frame.text = "Row 2 Cell 1"
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"
    table.rows.insert_clone(3, table.rows[1], False)

    table.columns.add_clone(table.columns[0], False)
    table.columns.insert_clone(3, table.columns[1], False)

    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Удаление строки или столбца из таблицы**

Удаляйте строки или столбцы, которые больше не нужны в таблице. При удалении элемент смещает индексы последующих строк или столбцов.

1. Создайте презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите первую страницу.
3. Задайте ширины столбцов и высоты строк.
4. Добавьте таблицу методом [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
5. Удалите вторую строку и второй столбец.
6. Сохраните изменённую презентацию.

В этом примере создаётся таблица 3×3 и удаляется строка и столбец с индексом 1, в результате получается таблица 2×2 в файле `TestTable_out.pptx`. Размеры указаны в пунктах. Параметр `False` отключает удаление смежных объединённых строк или столбцов; в этой таблице объединённых ячеек нет.

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

## **Применение форматирования текста на уровне строки таблицы**

Применяйте форматирование текста к всей строке, чтобы ячейки оставались одинаковыми. Можно задать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите таблицу на первом слайде.
3. Установите [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) для первой строки.
4. Установите [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) и [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) для первой строки.
5. Установите [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) для второй строки.
6. Сохраните изменённую презентацию.

Пример требует `table.pptx` с таблицей в первой фигуре первого слайда и как минимум двумя строками. Он применяет 25‑пунктовый текст, выравнивание по правому краю и отступ абзаца в 20 пунктов к первой строке, затем задаёт вертикальный текст во второй строке.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)

    presentation.save("row_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Применение форматирования текста на уровне столбца таблицы**

Применяйте форматирование текста к всему столбцу, чтобы ячейки оставались одинаковыми. Можно задать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите таблицу на первом слайде.
3. Установите [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) для первого столбца.
4. Установите [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) и [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) для первого столбца.
5. Установите [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) для второго столбца.
6. Сохраните изменённую презентацию.

Пример требует `table.pptx` с таблицей в первой фигуре первого слайда и как минимум двумя столбцами. Он применяет 25‑пунктовый текст, выравнивание по правому краю и отступ абзаца в 20 пунктов к первому столбцу, затем задаёт вертикальный текст во втором столбце.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]

    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    presentation.save("column_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **Получение свойств стиля таблицы**

Используйте свойство [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) для получения предустановки, применённой к таблице, и её переиспользования в другой таблице. Это позволяет определить предустановку вместо отдельных переопределений форматирования ячеек.

В примере создаётся таблица, применяется [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/), затем читается обратно предустановка. Выводится `True`, когда полученная предустановка совпадает с применённой, и таблица сохраняется в `table.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(style_preset == slides.TableStylePreset.DARK_STYLE1)

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/мастера, а вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заново заполните строки таблицы в нужном порядке.

**Можно ли использовать чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередующиеся столбцы, затем переопределите конкретные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.