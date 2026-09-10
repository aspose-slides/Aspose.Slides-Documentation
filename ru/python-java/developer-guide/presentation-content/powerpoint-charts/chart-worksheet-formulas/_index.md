---
title: Применение формул листа диаграммы в презентациях на Python через Java
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/python-java/chart-worksheet-formulas/
keywords:
- таблица диаграммы
- лист диаграммы
- формула диаграммы
- формула листа
- формула электронных таблиц
- рабочая книга данных диаграммы
- вычисление формул
- предпочтительная культура
- формула, зависящая от культуры
- DBCS
- логическая константа
- числовая константа
- строковая константа
- константа ошибки
- арифметический оператор
- оператор сравнения
- стиль A1
- стиль R1C1
- предопределённая функция
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides для Python через Java, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во встроенном листе. В Aspose.Slides for Python via Java вы можете получить доступ к этому листу через рабочую книгу данных диаграммы, записывать входные значения, назначать формулы ячейкам, вычислять поддерживаемые формулы и использовать вычисленные ячейки в качестве данных диаграммы.

Эта статья объясняет полный рабочий процесс с формулами: создание диаграммы, заполнение её листа, назначение формул в стиле A1 или R1C1, их пересчет, чтение вычисленных значений, привязку этих ячеек к сериям диаграммы и сохранение презентации. Также описывается поддерживаемый синтаксис формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, специфичные для электронных таблиц.

## **Листы диаграмм и формулы**

Лист диаграммы содержит категории, имена серий и значения, используемые диаграммой. В PowerPoint вы можете просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытым встроенным листом, показывающая данные категорий и серий](chart-worksheet-formulas_1.png)

В Aspose.Slides лист доступен через класс [ChartDataWorkbook](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/). Используйте [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#setFormula) для формул в стиле A1 и [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#setR1C1Formula) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#calculateFormulas), чтобы пересчитать поддерживаемые формулы и обновить соответствующие значения ячеек.

Вычисленная ячейка по‑прежнему предоставляет свой результат через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#getValue). Это важно, когда нужно проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Следующий пример демонстрирует сквозной рабочий процесс. Он создаёт группированную столбчатую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки в качестве значений диаграммы и сохраняет презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом рабочем процессе нет отдельного вызова обновления диаграммы: сначала пересчитайте рабочую книгу, затем используйте или сохраните данные диаграммы, указывающие на вычисленные ячейки.

## **Использование формул в стиле A1**

Обозначение A1 определяет столбцы буквами, а строки цифрами. Присваивайте выражения в стиле A1 через [ChartDataCell.setFormula](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Распространённые формы ссылок A1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `A2` | `$A$2` | `A$2`, `$A2` |
| Строка | `2:2` | `$2:$2` | — |
| Столбец | `A:A` | `$A:$A` | — |
| Диапазон | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Относительные ссылки могут изменяться, когда формула перемещается или копируется в приложении для электронных таблиц. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул в стиле R1C1**

Обозначение R1C1 численно определяет как строки, так и столбцы. Относительные ссылки используют смещения в квадратных скобках. Присваивайте такой синтаксис через [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Распространённые формы ссылок R1C1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Строка | `R[2]` | `R2` | — |
| Столбец | `C[3]` | `C3` | — |
| Диапазон | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Например, в ячейке `D2`, `RC[-2]` означает ячейку в той же строке, на два столбца левее (`B2`).

## **Константы и операторы формул**

Встроенный вычислитель формул поддерживает логические значения, числовые литералы, строки, значения ошибок электронных таблиц, арифметические операторы и операторы сравнения.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычные и научные записи. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Результат ошибки | `#DIV/0!`, `#N/A`, `#REF!` | Допустимая формула может вычисляться в значение ошибки электронной таблицы вместо обычного результата. |

В этом примере используются несколько типов констант:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Ложь
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Арифметические операторы**

| Оператор | Значение | Пример |
|---|---|---|
| `+` | Сложение или унарный плюс | `2+3` |
| `-` | Вычетание или унарный минус | `2-3`, `-3` |
| `*` | Умножение | `2*3` |
| `/` | Деление | `2/3` |
| `%` | Процент | `30%` |
| `^` | Возведение в степень | `2^3` |

Используйте скобки, чтобы явно задать порядок вычисления, например `(A2+B2)*C2`.

### **Операторы сравнения**

Выражения сравнения возвращают логические значения.

| Оператор | Значение | Пример |
|---|---|---|
| `=` | Равно | `A2=3` |
| `<>` | Не равно | `A2<>3` |
| `>` | Больше чем | `A2>3` |
| `>=` | Больше или равно | `A2>=3` |
| `<` | Меньше чем | `A2<3` |
| `<=` | Меньше или равно | `A2<=3` |

## **Поддерживаемые предопределённые функции**

В Aspose.Slides включён встроенный вычислитель формул для листов диаграмм, но это не полноценный движок расчётов Excel. Документированный набор функций ограничен перечисленными ниже. Не следует предполагать, что произвольную функцию Excel можно пересчитать с помощью [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединить текстовые значения | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединить текстовые значения | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создать значение даты, используя систему дат 1900 года | `DATE(2026,8,19)` |
| `DAYS` | Возвращает количество дней между датами | `DAYS(B2,A2)` |
| `FIND` | Найти один текст внутри другого | `FIND("-",A2)` |
| `FINDB` | Поиск текста по байтам | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Форма ссылки | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Сумма значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, существенны: `INDEX` документирована в виде ссылки, тогда как `LOOKUP` и `MATCH` — в векторных формах. `DATE` использует систему дат 1900 года. Функции и возможности, не перечисленные здесь, следует считать неподдерживаемыми вычислителем формул Aspose.Slides, если они не задокументированы отдельно.

## **Вычисление формул с указанием предпочтительной культуры**

Некоторые функции рабочей книги диаграммы интерпретируют текст в соответствии с правилами конкретной культуры. Это особенно важно для функций, предназначенных для языков, использующих наборы двойных байтов (DBCS). Чтобы правильно вычислить такие формулы, создайте [LoadOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/), задайте предпочтительную культуру с помощью [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), назначьте параметры электронной таблицы через [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), и затем загрузите презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Предпочтительная культура является частью конфигурации загрузки презентации, поэтому её следует указать до создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/). Используйте культуру, ожидаемую формулами рабочей книги; например, `ja-JP` для формул, которые должны следовать японским правилам расчётов DBCS.

## **Пересчёт и кэшированные значения**

Файлы электронных таблиц обычно хранят как формулу, так и её последнее вычисленное значение. Поэтому Aspose.Slides может читать кэшированное значение через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#getValue) при загрузке презентации, если соответствующие данные диаграммы не изменились.

После изменения входных ячеек или формул не следует полагаться на старый кэшированный результат. Вызовите [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) перед чтением вычисленных значений или сохранением данных диаграммы, от которых они зависят.

Для формул, не входящих в поддерживаемый набор, Aspose.Slides может не суметь разобрать формулу или определить её зависимости. Если рабочая книга была изменена, предыдущее кэшированное значение больше нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellunsupporteddataexception/).

Если ваша диаграмма зависит от функций Excel, которые Aspose.Slides не вычисляет, вычислите такие формулы с помощью движка электронных таблиц, который их поддерживает, и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы догадками.

## **Обработка ошибок формул**

Существует два разных вида проблем, которые следует различать.

Формула может быть корректной, но возвращать результат ошибки электронной таблицы, такой как `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через [ChartDataCell.getValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdatacell/#getValue).

Формула также может потерпеть неудачу на этапе разбора, ссылки, зависимости или уровня поддерживаемых данных. Aspose.Slides предоставляет специфичные для электронных таблиц исключения для этих случаев: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellcircularreferenceexception/), и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellunsupporteddataexception/).

Когда формулы поступают из шаблонов или пользовательского ввода, обрабатывайте эти исключения при пересчёте и доступе к значениям:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Практические ограничения**

Поддержка формул в листах диаграмм предназначена для определённого подмножества вычислений электронных таблиц, а не для полной совместимости с Excel. Учтите эти ограничения при проектировании рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, когда требуется, чтобы Aspose.Slides пересчитывал формулы.
- Пересчитайте после изменения ячеек, от которых зависят результаты формул.
- Считайте кэшированные значения из загруженных презентаций снимками, а не заменой пересчёту после правок.
- Тестируйте формулы из существующих шаблонов перед использованием их вычисленных значений, особенно если они используют функции, не входящие в документированный список.
- Для формул, требующих полного движка расчётов электронных таблиц, вычисляйте их внешне, а затем обновляйте рабочую книгу диаграммы полученными значениями.

## **FAQ**

**В чём разница между [ChartDataCell.setFormula] и [ChartDataCell.setR1C1Formula]?**

[ChartDataCell.setFormula] сохраняет выражение в стиле A1, например `B2-C2`. [ChartDataCell.setR1C1Formula] сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует тому, как вы генерируете или копируете формулы.

**Нужно ли читать саму ячейку или её значение после вычисления?**

[ChartDataWorkbook.getCell] возвращает объект [ChartDataCell]. Чтобы получить вычисленный результат, вызовите у этой ячейки метод [ChartDataCell.getValue] после пересчёта.

**Когда следует вызывать [ChartDataWorkbook.calculateFormulas]?**

Вызывайте [ChartDataWorkbook.calculateFormulas] после изменения входных значений или формул и перед тем, как вы будете полагаться на вычисленные результаты. Это обновляет значения формул, поддерживаемых встроенным вычислителем.

**Поддерживает ли Aspose.Slides все функции Excel?**

Нет. Встроенный вычислитель поддерживает только документированное подмножество функций. Не следует предполагать корректный пересчёт функций, не включённых в этот набор. Если требуется полная совместимость формул Excel, выполните расчёт с помощью подходящего движка электронных таблиц и запишите окончательные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не изменялись, в рабочей книге может оставаться ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Попытка доступа к ячейке, формулу которой невозможно обработать, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellunsupporteddataexception/).

**Являются ли значения ошибок формул тем же, что и исключения?**

Нет. Результат вроде `#DIV/0!` — это значение ячейки, полученное в результате корректного вычисления. Исключения, такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/python-java/aspose.slides/cellcircularreferenceexception/), указывают на то, что формулу нельзя обработать нормально.

**Обновляется ли диаграмма автоматически при изменении ячейки с формулой?**

Серии диаграммы могут ссылаться на ячейки рабочей книги. Сначала пересчитайте рабочую книгу, затем сохраните или отрендерите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не требуется.

**Могут ли диаграммы использовать внешний файл Excel?**

Да, данные диаграммы можно настроить на использование внешней рабочей книги через API данных диаграммы. Однако описанный в статье процесс вычисления формул относится к рабочей книге данных диаграммы и к набору формул, поддерживаемому Aspose.Slides. Не следует полагать, что [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) обеспечивает полное пересчитывание произвольных формул во внешнем файле XLSX.

**Могу ли я использовать формулы, ссылающиеся на другой лист или рабочую книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но оценка формул ограничена поддерживаемым парсером и набором функций. Если кросс‑листовая или внешняя ссылка необходима, проверьте точную формулу в используемой версии Aspose.Slides. Для процессов, требующих широкой совместимости ссылок Excel, вычислите рабочую книгу внешне и запишите полученные значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides присваивают выражения, такие как `B2-C2` или `SUM(B2:B5)`, без ведущего `=`. Такой вариант сохраняет согласованность с показанными в документации примерами API.