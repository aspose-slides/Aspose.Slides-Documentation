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
description: "Создавайте и редактируйте таблицы в слайдах PowerPoint с помощью Aspose.Slides для Python через Java. Откройте простые примеры кода для оптимизации ваших процессов работы с таблицами."
---
## **Введение**

Таблица в PowerPoint — эффективный способ отображения информации. Информация в сетке ячеек (расположенных в строках и столбцах) представлена просто и легко понятна.

Aspose.Slides предоставляет класс [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) класс [Cell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/) и другие типы, позволяющие создавать, обновлять и управлять таблицами во всех типах презентаций.

## **Создание таблицы с нуля**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Определите список ширин столбцов.
4. Определите список высот строк.
5. Добавьте объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) на слайд с помощью метода [addTable](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addTable).
6. Итерируйтесь по каждой [Cell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/) чтобы применить форматирование к верхней, нижней, правой и левой границам.
7. Объедините первые две ячейки первой строки таблицы.
8. Получите доступ к [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) ячейки [Cell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/).
9. Добавьте некоторый текст в [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).
10. Сохраните изменённую презентацию.

Этот код на Python демонстрирует, как создать таблицу в презентации:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

    # Создаёт экземпляр класса Presentation, представляющего файл PPTX
presentation = Presentation()
try:

    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Определяет столбцы с шириной и строки с высотой
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Добавляет форму таблицы на слайд
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Устанавливает формат границы для каждой ячейки
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

    # Объединяет ячейки 1 и 2 первой строки
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Добавляет текст в объединённую ячейку
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Сохраняет презентацию на диск
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Нумерация в стандартной таблице**

В стандартной таблице нумерация ячеек проста и начинается с нуля. Первая ячейка в таблице имеет индекс 0,0 (столбец 0, строка 0).

Например, ячейки таблицы с 4 столбцами и 4 строками нумеруются следующим образом:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Этот код на Python демонстрирует, как создать таблицу со стандартной нумерацией ячеек:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Создаёт экземпляр класса Presentation, представляющего файл PPTX
presentation = Presentation()
try:

    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Определяет столбцы с шириной и строки с высотой
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Добавляет форму таблицы на слайд
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Устанавливает формат границы для каждой ячейки
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)

    # Сохраняет презентацию на диск
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к существующей таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий таблицу, по его индексу.
3. Инициализируйте переменную для объекта [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) и установите её в `None`.
4. Итерируйтесь по всем объектам [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/) до тех пор, пока не будет найдена таблица.

   Если вы подозреваете, что обрабатываемый слайд содержит одну таблицу, можете просто проверить все содержащиеся в нём фигуры. Когда фигура определяется как таблица, вы можете использовать её как объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/). Однако если на слайде несколько таблиц, лучше искать нужную таблицу по её [getAlternativeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getAlternativeText).
5. Используйте объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) чтобы работать с таблицей. В приведённом ниже примере мы обновляем текст в первом столбце второй строки.
6. Сохраните изменённую презентацию.

Этот код на Python демонстрирует, как получить доступ к существующей таблице и работать с ней:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Создаёт экземпляр класса Presentation, представляющего файл PPTX
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Инициализирует ссылку на таблицу.
    table = None

    # Проходит по фигурам и задаёт ссылку на найденную таблицу
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Устанавливает текст для первого столбца второй строки
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Сохраняет изменённую презентацию на диск
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Найти ячейку, которой принадлежит TextFrame**

Когда общий код обработки текста получает [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) из таблицы, используйте метод [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParentCell), чтобы получить принадлежащую [Cell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/). Для текстового фрейма ячейки таблицы [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParentCell) возвращает владельца, а [TextFrame.getParentShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParentShape) возвращает `None`, хотя сама таблица является фигурой.

Координаты ячейки доступны через только для чтения методы [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/#getFirstColumnIndex) и [Cell.getFirstRowIndex](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame.getParentCell](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/#getParentCell) также предоставляет только для чтения навигацию: он возвращает владельца, но не меняет владение. Всегда проверяйте полученную ячейку на `None` перед её использованием.

Для полного примера, определяющего владельцев ячеек таблицы и фигур, включая фигуры, связанные с узлами SmartArt, см. [Search and Replace Text](/slides/ru/python-java/search-and-replace-text/).

## **Выравнивание текста в таблице**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Добавьте объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) на слайд.
4. Получите объект [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/) из таблицы.
5. Получите [Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) объекта [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).
6. Выравняйте текст по вертикали.
7. Сохраните изменённую презентацию.

Этот код на Python демонстрирует, как выровнять текст в таблице:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

# Создаёт экземпляр класса Presentation
presentation = Presentation()
try:

    # Получает первый слайд
    slide = presentation.getSlides().get_Item(0)

    # Определяет столбцы с шириной и строки с высотой
    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Добавляет форму таблицы на слайд
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
    table.get_Item(1, 0).getTextFrame().setText("10")
    table.get_Item(2, 0).getTextFrame().setText("20")
    table.get_Item(3, 0).getTextFrame().setText("30")

    # Получает текстовый фрейм
    text_frame = table.get_Item(0, 0).getTextFrame()

    # Доступ к первому абзацу в текстовом фрейме.
    paragraph = text_frame.getParagraphs().get_Item(0)

    # Доступ к первой части в абзаце.
    portion = paragraph.getPortions().get_Item(0)
    portion.setText("Text here")
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    # Выравнивает текст по вертикали
    cell = table.get_Item(0, 0)
    cell.setTextAnchorType(TextAnchorType.Center)
    cell.setTextVerticalType(TextVerticalType.Vertical270)

    # Сохраняет презентацию на диск
    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка форматирования текста на уровне таблицы**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
2. Получите ссылку на слайд по его индексу.
3. Получите объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/) со слайда.
4. Установите высоту шрифта текста с помощью [setFontHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Установите выравнивание и правый отступ с помощью [setAlignment](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setAlignment) и [setMarginRight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setMarginRight).
6. Установите вертикальный тип текста с помощью [setTextVerticalType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Сохраните изменённую презентацию.

Этот код на Python демонстрирует, как применить выбранные параметры форматирования к тексту в таблице:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Создаёт экземпляр класса Presentation
presentation = Presentation("simpletable.pptx")
try:

    # Предположим, что первая фигура на первом слайде — это таблица
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Устанавливает высоту шрифта ячеек таблицы
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Устанавливает выравнивание текста ячеек таблицы и правый отступ одним вызовом
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Устанавливает вертикальный тип текста ячеек таблицы
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Получение свойств стиля таблицы**

Aspose.Slides позволяет получить свойства стиля таблицы, чтобы вы могли использовать эту информацию для другой таблицы или в другом месте. Этот код на Python демонстрирует, как получить свойства стиля из предустановленного стиля таблицы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # изменить тему предустановочного стиля по умолчанию

    # Получает предустановку стиля таблицы
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Применяет полученную предустановку стиля к другой таблице
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Блокировка соотношения сторон таблицы**

Соотношение сторон геометрической формы — это отношение её размеров в разных измерениях. Aspose.Slides предоставляет метод [setAspectRatioLocked](https://reference.aspose.com/slides/ru/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked), позволяющий заблокировать настройку соотношения сторон для таблиц и других фигур.

Этот код на Python демонстрирует, как заблокировать соотношение сторон для таблицы:

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # инвертировать
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я включить направление чтения справа налево (RTL) для всей таблицы и текста в её ячейках?**

Да. Таблица предоставляет метод [setRightToLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/#setRightToLeft), а у абзацев есть [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#setRightToLeft). Использование обоих обеспечивает правильный порядок RTL и отображение внутри ячеек.

**Как можно предотвратить перемещение или изменение размера таблицы в конечном файле?**

Используйте [shape locks](/slides/ru/python-java/applying-protection-to-presentation/) для отключения перемещения, изменения размеров, выделения и т.д. Эти блокировки применимы и к таблицам.

**Поддерживается ли вставка изображения в ячейку в качестве фона?**

Да. Вы можете задать [picture fill](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/) для ячейки; изображение будет покрывать область ячейки в соответствии с выбранным режимом (растягивание или замощение).