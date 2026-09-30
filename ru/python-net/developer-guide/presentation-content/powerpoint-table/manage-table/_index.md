---
title: Управление таблицами презентаций с Python
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/python-net/manage-table/
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
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python через .NET. Откройте простые примеры кода, упрощающие работу с таблицами."
---
## **Введение**

Таблицы в PowerPoint упорядочивают информацию по строкам и столбцам, упрощая чтение и сравнение значений.

Aspose.Slides предоставляет классы [Таблица](https://reference.aspose.com/slides/python-net/aspose.slides/table/) и [Ячейка](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами в презентациях.

## **Создать таблицу с нуля**

Создайте таблицу, указав её позицию, ширину столбцов и высоту строк. После добавления на слайд вы можете форматировать границы ячеек, объединять ячейки и вставлять текст.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите список ширин столбцов в пунктах.
4. Определите список высот строк в пунктах.
5. Добавьте объект [Таблица](https://reference.aspose.com/slides/python-net/aspose.slides/table/) на слайд с помощью метода [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/).
6. Пройдитесь по каждой [Ячейка](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к объединённой ячейке через её свойство [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/).
9. Установите текст в объединённой ячейке.
10. Сохраните изменённую презентацию.

Пример ниже создаёт таблицу с тремя столбцами и пятью строками в точке (100, 50). Он применяет красные границы шириной 5 пунктов, объединяет первые две ячейки первой строки и сохраняет результат как `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Нумерация в стандартной таблице**

В стандартной таблице индексы ячеек начинаются с нуля и используют порядок (столбец, строка). Первая ячейка имеет индекс (0, 0). В Python доступ к ячейке осуществляется через `table.rows[row_index][column_index]`; индекс строки указывается первым в этом выражении.

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот пример создаёт 4 × 4 таблицу, показанную выше, со шириной столбцов и высотой строк по 70 пунктов и красными границами ячеек шириной 5 пунктов. Координаты иллюстрируют индексы ячеек; пример оставляет ячейки пустыми и сохраняет таблицу как `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к существующей таблице**

Таблицы хранятся в коллекции фигур слайда. Пройдитесь по фигурам, чтобы найти таблицу, затем используйте класс [Таблица](https://reference.aspose.com/slides/python-net/aspose.slides/table/) для чтения или обновления её ячеек.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Пройдитесь по объектам [Фигура](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) и останавливаясь, когда найдёте таблицу. Если на слайде несколько таблиц, используйте [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) , чтобы определить нужную.
4. Обновите текст в целевой ячейке.
5. Сохраните изменённую презентацию.

Пример ниже открывает `UpdateExistingTable.pptx` и находит первую таблицу на первом слайде. Он задаёт ячейке в столбце 0, строке 1 значение `New` и сохраняет результат как `table1_out.pptx`. Входные данные должны содержать как минимум один слайд, а первая таблица на этом слайде должна иметь как минимум один столбец и две строки.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Для изменения высоты строки в существующей таблице и понимания, почему её фактическая высота может превышать запрошенный минимум, см. [Управление высотой строки](/slides/ru/python-net/manage-rows-and-columns/#control-row-height).

## **Найти ячейку, владеющую TextFrame**

Когда универсальный код обработки текста получает объект [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) из таблицы, используйте свойство [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) , чтобы получить владеющую [Ячейка](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Для текстового кадра ячейки таблицы [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) установлен, а [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) равно `None`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения свойства [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) и [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/). [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) также только для чтения: он обеспечивает навигацию к владельцу, но не меняет владения. Всегда проверяйте возвращаемую ячейку на `None` перед её использованием.

Для полного примера, определяющего владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, см. [Поиск и замена текста](/slides/ru/python-net/search-and-replace-text/).

## **Выравнивание текста в таблице**

Вы можете управлять вертикальной привязкой и направлением текста отдельных ячеек таблицы. Пример в этом разделе центрирует текст в первой ячейке и вращает его на 270 градусов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [Таблица](https://reference.aspose.com/slides/python-net/aspose.slides/table/) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) из таблицы.
5. Получите первый [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) и задайте его текст и цвет.
6. Установите свойства ячейки [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) и [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) .
7. Сохраните изменённую презентацию.

Этот пример создаёт 4 × 4 таблицу со столбцами шириной 120 пунктов и строками высотой 100 пунктов. Он форматирует текст в ячейке (0, 0), добавляет значения в остальные ячейки первой строки и сохраняет результат как `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить форматирование текста на уровне таблицы**

Используйте [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/) , чтобы применить форматирование текста ко всем ячейкам таблицы. Его перегрузки принимают форматирование части, абзаца и текстового кадра, поэтому вы можете задавать эти свойства без обхода отдельных ячеек.

1. Загрузите презентацию, используя класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите объект [Таблица](https://reference.aspose.com/slides/python-net/aspose.slides/table/) со слайда.
4. Установите [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) для текста.
5. Установите [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) и [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/) .
6. Установите [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) .
7. Сохраните изменённую презентацию.

Пример ниже открывает `table.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он задаёт размер шрифта 25 пунктов, выравнивает абзацы по правому краю с правым отступом 20 пунктов и делает текст вертикальным. Форматированная презентация сохраняется как `result.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить свойства стиля таблицы**

Используйте [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/) , чтобы прочитать или задать предустановленный стиль таблицы. Этот пример применяет [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) к одной таблице, выводит имя предустановки и назначает тот же стиль второй таблице. Обе таблицы сохраняются в `table-style.pptx`.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Блокировать соотношение сторон таблицы**

Соотношение сторон таблицы — это отношение её ширины к высоте. Используйте [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/) , чтобы заблокировать это соотношение для таблицы.

Пример ниже открывает `pres.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он выводит текущее состояние блокировки, включает блокировку соотношения сторон, выводит обновлённое состояние (`True`) и сохраняет результат как `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет свойство [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), а абзацы имеют [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Использование обоих обеспечивает правильный порядок RTL и корректный рендеринг внутри ячеек.

**Как предотвратить перемещение или изменение размера таблицы пользователями в окончательном файле?**

Используйте [блокировки фигур](/slides/ru/python-net/applying-protection-to-presentation/) , чтобы отключить перемещение, изменение размера, выделение и т.д. Эти блокировки применяются и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) для ячейки; изображение покрывает область ячейки в соответствии с выбранным режимом (растягивание или черепица).