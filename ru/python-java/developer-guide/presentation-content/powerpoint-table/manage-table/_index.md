---
title: Управление таблицами презентаций в Python
linktitle: Управление таблицей
type: docs
weight: 10
url: /ru/python-java/manage-table/
keywords:
- добавить таблицу
- создать таблицу
- доступ к таблице
- соотношение сторон
- выравнивание текста
- форматирование текста
- стиль таблицы
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для Python через Java. Откройте простые примеры кода, чтобы упростить работу с таблицами."
---
## **Введение**

Таблицы в PowerPoint упорядочивают информацию по строкам и столбцам, облегчая чтение и сравнение значений.

Aspose.Slides предоставляет классы [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) и [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами в презентациях.

## **Создание таблицы с нуля**

Создайте таблицу, указав её позицию, ширину столбцов и высоту строк. После добавления её на слайд вы можете форматировать границы ячеек, объединять ячейки и вставлять текст.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите список ширин столбцов в пунктах.
4. Определите список высот строк в пунктах.
5. Добавьте объект [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable).
6. Пройдите по каждому [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) и примените форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите объединённую ячейку через её метод [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame).
9. Установите текст в объединённой ячейке.
10. Сохраните изменённую презентацию.

Ниже приведён пример, создающий таблицу из трёх столбцов и пяти строк в позиции (100, 50) пунктов. Он применяет красные границы шириной 5 пунктов, объединяет первые две ячейки первой строки и сохраняет результат как `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), False)
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells")

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Нумерация в стандартной таблице**

В стандартной таблице индексы ячеек начинаются с нуля и задаются в порядке (столбец, строка). Первая ячейка имеет индекс (0, 0).

Например, ячейки в таблице с 4 столбцами и 4 строками нумеруются так:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот пример создаёт таблицу 4 × 4, показанную выше, со столбцовыми ширинами и высотами строк по 70 пунктов и красными границами ячеек шириной 5 пунктов. Координаты иллюстрируют индексы ячеек; пример оставляет ячейки пустыми и сохраняет таблицу как `StandardTables_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к существующей таблице**

Таблицы хранятся в коллекции фигур слайда. Пройдите по фигурам, чтобы найти таблицу, затем используйте класс [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) для чтения или обновления её ячеек.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Пройдите по объектам [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) и остановитесь, когда найдёте таблицу. Если на слайде несколько таблиц, используйте [getAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getAlternativeText) для идентификации нужной.
4. Обновите текст в целевой ячейке.
5. Сохраните изменённую презентацию.

Ниже пример, открывающий `UpdateExistingTable.pptx` и находящий первую таблицу на первом слайде. Он задаёт ячейке в столбце 0, строке 1 значение `New` и сохраняет результат как `table1_out.pptx`. Входной файл должен содержать как минимум один слайд, а первая таблица на этом слайде должна иметь минимум один столбец и две строки.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("UpdateExistingTable.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = None

    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            break

    if table is not None:
        table.get_Item(0, 1).getTextFrame().setText("New")
        presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Чтобы изменить высоту строки в существующей таблице и понять, почему её фактическая высота может превышать запрошенный минимум, смотрите [Control Row Height](/slides/ru/python-java/manage-rows-and-columns/#control-row-height).

## **Поиск ячейки, владеющей TextFrame**

Когда универсальный код обработки текста получает [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) из таблицы, используйте метод [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) для получения владеющей [Cell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/). Для текстового фрейма ячейки таблицы [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) возвращает владельца, а [TextFrame.getParentShape](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentShape) — `None`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения методы [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) и [Cell.getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParentCell) также предоставляет навигацию только для чтения: он возвращает владельца, но не меняет владения. Всегда проверяйте возвращаемую ячейку на `None` перед использованием.

Для полного примера, который определяет владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, смотрите [Search and Replace Text](/slides/ru/python-java/search-and-replace-text/).

## **Выравнивание текста в таблице**

Можно управлять вертикальной привязкой и направлением текста отдельных ячеек таблицы. Пример в этом разделе центрирует текст в первой ячейке и вращает его на 270 градусов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) из таблицы.
5. Получите первый [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) и задайте ему текст и цвет.
6. Установите вертикальную привязку ячейки и направление текста с помощью [setTextAnchorType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextAnchorType) и [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setTextVerticalType).
7. Сохраните изменённую презентацию.

Этот пример создаёт таблицу 4 × 4 со столбцовыми ширинами 120 пунктов и высотами строк 100 пунктов. Он форматирует текст в ячейке (0, 0), добавляет значения в остальные ячейки первой строки и сохраняет результат как `Vertical_Align_Text_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    text_frame = table.get_Item(0, 0).getTextFrame()
    paragraph = text_frame.getParagraphs().get_Item(0)

    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка форматирования текста на уровне таблицы**

Используйте [setTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setTextFormat) для применения форматирования текста ко всем ячейкам таблицы. Его перегрузки принимают форматирование части, абзаца и текстового фрейма, поэтому вы можете задавать эти свойства без перебора отдельных ячеек.

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите объект [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) со слайда.
4. Установите размер шрифта, используя [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Установите выравнивание абзаца и правый отступ с помощью [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) и [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Установите направление текста через [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Сохраните изменённую презентацию.

Ниже пример, открывающий `table.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он задаёт размер шрифта 25 пунктов, выравнивает абзацы по правому краю с правым отступом 20 пунктов и делает текст вертикальным. Форматированная презентация сохраняется как `result.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.setTextFormat(text_frame_format)
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Получение свойств стиля таблицы**

Используйте [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) для чтения предустановленного стиля таблицы и [setStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setStylePreset) для его назначения. Этот пример применяет [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/) к одной таблице, выводит значение предустановки и присваивает тот же стиль второй таблице. Обе таблицы сохраняются в `table-style.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    another_table = slide.getShapes().addTable(10, 100, column_widths, row_heights)
    another_table.setStylePreset(style_preset)

    presentation.save("table-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон таблицы — это отношение её ширины к высоте. Используйте [setAspectRatioLocked](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) для фиксации этого соотношения у таблицы.

В примере ниже открывается `pres.pptx`, который должен содержать как минимум один слайд с таблицей в качестве первой фигуры. Он выводит текущее состояние блокировки, включает блокировку соотношения сторон, выводит обновлённое состояние (`True`) и сохраняет результат как `pres-out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    table.getGraphicalObjectLock().setAspectRatioLocked(True)
    print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Можно ли включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setRightToLeft), а у абзацев есть [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setRightToLeft). Использование обоих гарантирует правильный RTL‑порядок и рендеринг внутри ячеек.

**Как предотвратить перемещение или изменение размеров таблицы пользователями в итоговом файле?**

Используйте [shape locks](/slides/ru/python-java/applying-protection-to-presentation/) для отключения перемещения, изменения размеров, выбора и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/) для ячейки; изображение покрывает область ячейки в соответствии с выбранным режимом (растягивание или мозаика).