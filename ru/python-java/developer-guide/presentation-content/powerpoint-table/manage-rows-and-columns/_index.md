---
title: Управление строками и столбцами в таблицах PowerPoint с использованием Python
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
description: "Управляйте строками и столбцами таблицы в PowerPoint с помощью Aspose.Slides для Python через Java и ускоряйте редактирование презентаций и обновление данных."
---
## **Введение**

Чтобы вы могли управлять строками и столбцами таблицы в презентации PowerPoint, Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) и многие другие типы.

## **Установить первую строку в качестве заголовка**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Создайте ссылку на [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) и установите её в `None`.
4. Пройдитесь по всем объектам [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/), чтобы найти нужную таблицу.
5. Установите первую строку таблицы в качестве её заголовка.

Этот пример кода на Python показывает, как установить первую строку таблицы в качестве заголовка:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = None
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape
            table.setFirstRow(True)
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Клонировать строку или столбец таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Определите список ширин столбцов.
4. Определите список высот строк.
5. Добавьте объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addTable).
6. Клонируйте строку таблицы.
7. Клонируйте столбец таблицы.
8. Сохраните изменённую презентацию.

Этот пример кода на Python показывает, как клонировать строку или столбец таблицы PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
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

## **Удалить строку или столбец из таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите список ширин столбцов.
4. Определите список высот строк.
5. Добавьте объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addTable).
6. Удалите строку таблицы.
7. Удалите столбец таблицы.
8. Сохраните изменённую презентацию.

Этот пример кода на Python показывает, как удалить строку или столбец из таблицы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)
    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)
    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить форматирование текста на уровне строк таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к соответствующему объекту [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) на слайде.
4. Установите высоту шрифта ячеек первой строки, используя [setFontHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Установите выравнивание текста и правый отступ ячеек первой строки, используя [setAlignment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setAlignment) и [setMarginRight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Установите тип вертикального текста ячеек второй строки, используя [setTextVerticalType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Сохраните изменённую презентацию.

Этот пример кода на Python демонстрирует эту операцию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Установить форматирование текста на уровне столбцов таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию.
2. Получите ссылку на слайд по его индексу.
3. Получите доступ к соответствующему объекту [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) на слайде.
4. Установите высоту шрифта ячеек первого столбца, используя [setFontHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Установите выравнивание текста и правый отступ ячеек первого столбца, используя [setAlignment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setAlignment) и [setMarginRight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Установите тип вертикального текста ячеек второго столбца, используя [setTextVerticalType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Сохраните изменённую презентацию.

Этот пример кода на Python демонстрирует эту операцию:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
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
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Получить свойства стиля таблицы**

Aspose.Slides позволяет получать свойства стиля таблицы, чтобы вы могли использовать эти детали для другой таблицы или в другом месте. Этот пример кода на Python показывает, как получить свойства стиля из предустановленного стиля таблицы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)
    style_preset = table.getStylePreset()
    print(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Часто задаваемые вопросы**

**Можно ли применить темы/стили PowerPoint к уже созданной таблице?**

Да. Таблица наследует тему слайда/макета/основы, и вы всё равно можете переопределять заливки, границы и цвета текста поверх этой темы.

**Можно ли сортировать строки таблицы, как в Excel?**

Нет, у таблиц Aspose.Slides нет встроенной сортировки или фильтров. Сначала выполните сортировку данных в памяти, а затем заново заполните строки таблицы в этом порядке.

**Можно ли использовать чередующиеся (полосатые) столбцы, сохраняя пользовательские цвета отдельные ячейки?**

Да. Включите чередование столбцов, а затем переопределите отдельные ячейки локальным форматированием; форматирование на уровне ячейки имеет приоритет над стилем таблицы.