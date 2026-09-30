---
title: Управление строками и столбцами в таблицах PowerPoint с помощью Python
linktitle: Строки и столбцы
type: docs
weight: 20
url: /ru/python-java/manage-rows-and-columns/
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
description: "Управляйте строками и столбцами таблицы в PowerPoint с помощью Aspose.Slides для Python через Java и ускорьте редактирование презентаций и обновление данных."
---
## **Введение**

Aspose.Slides for Python via Java позволяет управлять структурой таблиц и их форматированием в презентациях PowerPoint с помощью класса [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Вы можете пометить строку заголовка, клонировать или удалять строки и столбцы и применять форматирование текста к целой строке или столбцу.

В этой статье объясняются эти операции с примерами на Python. Также показано, как получить предустановку стиля таблицы, чтобы её можно было повторно использовать. Индексы строк и столбцов таблицы начинаются с нуля.

## **Управление высотой строки**

Используйте [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight), чтобы задать минимальную высоту строки в пунктах. Это нижняя граница, а не фиксированная высота. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) возвращает реальную высоту. Получить строку можно через [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

Пример загружает [row-height-input.pptx](row-height-input.pptx), в котором первая форма на первом слайде — таблица. Первая строка начинается с 70 пунктов. Ячейки используют текст Arial 18 пт, с переносом строк и отступами сверху и снизу по 6 пт; более длинный текст во второй колонке переносится на несколько строк. Пример увеличивает минимум до 100 пунктов, затем уменьшает его до 20 пунктов, выводит реальную высоту после каждого изменения и сохраняет оба результата.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

С предоставленной презентацией увеличение минимума добавляет пространство к строке. Уменьшение убирает это дополнительное пространство, но реальная высота остаётся больше 20 пт, поскольку текст и отступы ячеек требуют больше места. Снижение только минимального значения не может принудительно уменьшить строку ниже требуемого её содержимым пространства.

Несколько факторов влияют на реальную высоту:

- **Текст и размер шрифта:** более длинный текст, явные разрывы строк или больший шрифт могут требовать больше вертикального пространства.  
- **Перенос и ширина столбца:** при включённом переносе уменьшение ширины столбца с помощью [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) может привести к появлению дополнительных строк. Более широкий столбец может уменьшить требуемое вертикальное пространство.  
- **Отступы ячеек:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) и [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) добавляют вертикальное пространство. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) и [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) уменьшают ширину, доступную для текста, и могут вызвать дополнительный перенос.

Для этой таблицы без объединённых ячеек ячейка, требующая наибольшее вертикальное пространство, определяет нижний предел содержимого для всей строки. Чтобы сделать строку короче, возможно, придётся сократить текст, уменьшить размер шрифта или отступы, либо увеличить ширину столбца.

Изображения ниже показывают одну и ту же таблицу в одинаковом масштабе. В приведённых результатах реальная высота была 70, 100 и 55.2 пт: финальная строка осталась выше своего минимума 20 пт. Точные измерения текста могут различаться в зависимости от шрифтов, доступных в вашей среде. Скачайте сохранённые результаты: [increased minimum](row-height-increased.pptx) и [decreased minimum](row-height-decreased.pptx).

| Оригинал: минимум 70 пт, реальная 70 пт | Увеличено: минимум 100 пт, реальная 100 пт | Уменьшено: минимум 20 пт, реальная 55.2 пт |
| --- | --- | --- |
| ![Оригинальная таблица с первой строкой 70 пт.](row-height-before.png) | ![Таблица после увеличения минимума первой строки до 100 пт.](row-height-increased.png) | ![Таблица после уменьшения минимума первой строки до 20 пт; переносимый текст удерживает строку выше минимума.](row-height-decreased.png) |

## **Установить первую строку как заголовок**

Используйте метод [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow), чтобы пометить первую строку для форматирования заголовка. Её внешний вид зависит от применённого к таблице стиля.

1. Загрузите презентацию с классом [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Получите доступ к первому слайду.  
3. Получите доступ к таблице, хранящейся как первая форма на слайде.  
4. Включите форматирование заголовка для её первой строки.  
5. Сохраните изменённую презентацию.

Для примера требуется `table.pptx` с таблицей в первой форме первого слайда. Он включает форматирование заголовка для первой строки и сохраняет `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Клонирование строки или столбца таблицы**

Клонируйте строки или столбцы, чтобы повторно использовать их содержимое и форматирование. Вы можете добавить копию в конец таблицы или вставить её в определённую позицию.

1. Загрузите презентацию с классом [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Получите доступ к первому слайду.  
3. Задайте ширины столбцов и высоты строк.  
4. Добавьте таблицу с помощью метода [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).  
5. Клонируйте необходимые строки.  
6. Клонируйте необходимые столбцы.  
7. Сохраните изменённую презентацию.

Для примера требуется `Test.pptx` с хотя бы одним слайдом. Он создаёт таблицу из трёх столбцов и пяти строк с размерами, указанными в пунктах. Затем добавляет копии первой строки и столбца, а после этого вставляет копии второй строки и столбца в позицию с индексом 3 (четвёртая позиция). В результате таблица имеет семь строк и пять столбцов. Параметр `False` отключает клонирование в соседние объединённые строки или столбцы; в этой таблице нет объединённых ячеек.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Удаление строки или столбца из таблицы**

Удаляйте строки или столбцы, которые больше не нужны в таблице. При удалении элемент смещает индексы последующих строк или столбцов.

1. Создайте презентацию с классом [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Получите доступ к первому слайду.  
3. Задайте ширины столбцов и высоты строк.  
4. Добавьте таблицу с методом [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).  
5. Удалите вторую строку и второй столбец.  
6. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 3×3 и удаляет строку и столбец с индексом 1, оставляя таблицу 2×2 в `TestTable_out.pptx`. Размеры указаны в пунктах. Параметр `False` отключает удаление соседних объединённых строк или столбцов; в этой таблице нет объединённых ячеек.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Настройка форматирования текста на уровне строк таблицы**

Применяйте форматирование текста ко всей строке, чтобы ячейки оставались согласованными. Можно задать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с классом [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Получите доступ к таблице на первом слайде.  
3. Используйте [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) для первой строки.  
4. Используйте [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) и [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) для первой строки.  
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) для второй строки.  
6. Сохраните изменённую презентацию.

Для примера требуется `table.pptx` с таблицей в первой форме первого слайда и как минимум двумя строками. Он применяет текст размером 25 пт, выравнивание по правому краю и правый отступ абзаца 20 пт к первой строке, затем задаёт вертикальный текст во второй строке.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Настройка форматирования текста на уровне столбцов таблицы**

Применяйте форматирование текста ко всему столбцу, чтобы ячейки оставались согласованными. Можно задать свойства шрифта, форматирование абзаца и направление текста без необходимости форматировать каждую ячейку отдельно.

1. Загрузите презентацию с классом [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).  
2. Получите доступ к таблице на первом слайде.  
3. Используйте [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) для первого столбца.  
4. Используйте [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) и [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) для первого столбца.  
5. Используйте [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) для второго столбца.  
6. Сохраните изменённую презентацию.

Для примера требуется `table.pptx` с таблицей в первой форме первого слайда и как минимум двумя столбцами. Он применяет текст размером 25 пт, выравнивание по правому краю и правый отступ абзаца 20 пт к первому столбцу, затем задаёт вертикальный текст во втором столбце.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Получение свойств стиля таблицы**

Используйте метод [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset), чтобы получить предустановку, применённую к таблице, и повторно использовать её в другой таблице. Это идентифицирует предустановку, а не отдельные переопределения форматирования ячеек.

Пример создаёт таблицу, применяет [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1) и считывает предустановку обратно. Он выводит целочисленное значение, соответствующее `DarkStyle1`, и сохраняет таблицу в `table.pptx`.

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpile.JArray(jpile.JDouble)([100, 150])
    row_heights = jpile.JArray(jpile.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/разметки/мастер‑шаблона, но вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, таблицы Aspose.Slides не имеют встроенной сортировки или фильтров. Сначала отсортируйте данные в памяти, а затем заполните строки таблицы в полученном порядке.

**Можно ли использовать чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета в отдельных ячейках?**

Да. Включите чередующиеся столбцы, а затем переопределите отдельные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.