---
title: Применение формул листов диаграмм в презентациях с Python
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/python-net/chart-worksheet-formulas/
keywords:
- таблица диаграммы
- лист диаграммы
- формула диаграммы
- формула листа
- формула электронной таблицы
- рабочая книга данных диаграммы
- вычисление формулы
- предпочтительная культура
- культурно-зависимая формула
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
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в Aspose.Slides для Python через .NET листы диаграмм, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во встроенном листе. В Aspose.Slides для Python через .NET вы можете получить доступ к этому листу через рабочую книгу данных диаграммы, записать входные значения, назначить ячейкам формулы, вычислить поддерживаемые формулы и использовать рассчитанные ячейки в качестве данных диаграммы.

В этой статье описывается полный процесс работы с формулами: создание диаграммы, заполнение её листа, назначение формул в стиле A1 или R1C1, их пересчёт, чтение рассчитанных значений, привязка этих ячеек к серии диаграммы и сохранение презентации. Также рассматриваются поддерживаемый синтаксис формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, характерные для электронных таблиц.

## **Листы диаграмм и формулы**

Лист диаграммы содержит категории, имена серий и значения, используемые диаграммой. В PowerPoint вы можете просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытым встроенным листом, показывающая данные категорий и серий](chart-worksheet-formulas_1.png)

В Aspose.Slides лист доступен через [рабочую книгу данных диаграммы](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdataworkbook/). Используйте свойство [formula](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/formula/) для формул в стиле A1 и свойство [r1c1_formula](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [calculate_formulas](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) для пересчёта поддерживаемых формул и обновления соответствующих значений ячеек.

Рассчитанная ячейка по‑прежнему предоставляет свой результат через свойство [value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/value/). Это важно, когда необходимо проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Следующий пример демонстрирует сквозной процесс. Он создаёт сгруппированную столбчатую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует рассчитанные ячейки в качестве значений диаграммы и сохраняет презентацию.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует рассчитанные значения прибыли. В этом процессе нет отдельного вызова обновления диаграммы: сначала пересчитайте рабочую книгу, затем используйте или сохраните данные диаграммы, указывающие на рассчитанные ячейки.

## **Использование формул в стиле A1**

Нотация A1 обозначает столбцы буквами, а строки — цифрами. Присваивайте выражения в стиле A1 через [IChartDataCell.formula](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Распространённые формы ссылок A1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `A2` | `$A$2` | `A$2`, `$A2` |
| Строка | `2:2` | `$2:$2` | — |
| Столбец | `A:A` | `$A:$A` | — |
| Диапазон | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Относительные ссылки могут изменяться при перемещении или копировании формулы в электронных таблицах. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул в стиле R1C1**

Нотация R1C1 обозначает как строки, так и столбцы числовыми значениями. Относительные ссылки используют смещения в квадратных скобках. Присваивайте эту нотацию через [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Распространённые формы ссылок R1C1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Строка | `R[2]` | `R2` | — |
| Столбец | `C[3]` | `C3` | — |
| Диапазон | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Например, в ячейке `D2` запись `RC[-2]` означает ячейку в той же строке, два столбца влево (`B2`).

## **Константы и операторы формул**

Встроенный оценщик формул поддерживает логические значения, числовые литералы, строки, значения ошибок электронных таблиц, арифметические операторы и операторы сравнения.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычные и научные записи. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Ошибка | `#DIV/0!`, `#N/A`, `#REF!` | Валидная формула может вернуть значение ошибки вместо обычного результата. |

Этот пример использует несколько типов констант:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # False
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Арифметические операторы**

| Оператор | Значение | Пример |
|---|---|---|
| `+` | Сложение или унарный плюс | `2+3` |
| `-` | Вычитание или отрицание | `2-3`, `-3` |
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
| `>` | Больше | `A2>3` |
| `>=` | Больше или равно | `A2>=3` |
| `<` | Менее | `A2<3` |
| `<=` | Менее или равно | `A2<=3` |

## **Поддерживаемые предопределённые функции**

Aspose.Slides включает встроенный оценщик формул для листов диаграмм, но это не полноценный движок расчёта Excel. Документированный набор функций ограничен перечисленными ниже. Не следует предполагать, что произвольная функция Excel может быть пересчитана с помощью [calculate_formulas](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание даты в системе 1900‑го года | `DATE(2026,8,19)` |
| `DAYS` | Число дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск текста внутри другого текста | `FIND("-",A2)` |
| `FINDB` | Поиск текста в байтовом представлении | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Форма ссылки | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимум | `MAX(B2:B5)` |
| `SUM` | Сумма | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, существенны: `INDEX` документирован в форме ссылки, тогда как `LOOKUP` и `MATCH` — в их векторных формах. `DATE` использует систему дат 1900‑го года. Функции и возможности, не перечисленные здесь, следует считать неподдерживаемыми встроенным оценщиком формул Aspose.Slides, если они не документированы отдельно.

## **Вычисление формул с предпочтительной культурой**

Некоторые функции рабочей книги интерпретируют текст согласно правилам определённой культуры. Это особенно важно для функций, предназначенных для языков с двойными байтовыми набором символов (DBCS). Чтобы правильно вычислить такие формулы, создайте [LoadOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/), задайте [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/ru/python-net/aspose.slides/spreadsheetoptions/) через [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/spreadsheet_options/), а затем загрузите презентацию.

В следующем примере выбирается японская культура, открывается презентация с указанными параметрами загрузки и вызывается [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) для каждой рабочей книги диаграммы:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

Предпочтительная культура является частью конфигурации загрузки презентации, поэтому задавайте её до создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/). Используйте культуру, ожидаемую формулами рабочей книги; например, `ja-JP` для формул, которые должны следовать японским правилам расчёта DBCS.

## **Пересчёт и кэшированные значения**

Файлы электронных таблиц обычно хранят как формулу, так и её последнее вычисленное значение. Aspose.Slides может считывать кэшированное значение из [IChartDataCell.value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/value/) при загрузке презентации, если соответствующие данные диаграммы не изменялись.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) перед чтением рассчитанных значений или сохранением данных диаграммы, от которых они зависят.

Для формул, не входящих в поддерживаемый набор, Aspose.Slides может не суметь разобрать формулу или определить её зависимости. Если рабочая книга была изменена, предыдущее кэшированное значение больше нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Если ваша диаграмма использует функции Excel, которые Aspose.Slides не вычисляет, вычислите их внешним движком электронных таблиц и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы догадками.

## **Обработка ошибок формул**

Существует два разных типа проблем.

Формула может быть корректной, но возвращать значение ошибки электронной таблицы, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть получен через `value`.

Формула также может завершиться ошибкой на этапе разбора, ссылки, зависимости или поддержки данных. Aspose.Slides предоставляет специализированные исключения для этих случаев: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Когда формулы поступают из шаблонов или пользовательского ввода, обрабатывайте эти исключения вокруг пересчёта и доступа к значениям:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Практические ограничения**

Поддержка формул в листах диаграмм предназначена для ограниченного подмножества расчётов электронных таблиц, а не для полной совместимости с Excel. Учтите эти ограничения при проектировании процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, когда требуется пересчёт формул Aspose.Slides.
- Пересчитывайте после изменения ячеек, от которых зависят результаты формул.
- Рассматривайте кэшированные значения из загруженных презентаций как снимки, а не как замену пересчёту после правок.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не указанные в списке.
- Для формул, требующих полного движка расчёта электронных таблиц, выполните вычисления внешне и затем обновите рабочую книгу диаграммы полученными значениями.

## **FAQ**

**В чём разница между `formula` и `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/formula/) хранит выражение в стиле A1, например `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) хранит выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует тому, как вы генерируете или копируете формулы.

**Нужно ли читать саму ячейку или её значение после вычисления?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) возвращает `IChartDataCell`. Чтобы получить рассчитанный результат, прочитайте свойство [value](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/ichartdatacell/value/) этой ячейки после пересчёта.

**Когда следует вызывать `calculate_formulas`?**

Вызовите [calculate_formulas](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) после изменения входных значений или формул и перед тем, как полагаться на рассчитанные результаты. Это обновит значения формул, поддерживаемых встроенным оценщиком.

**Поддерживает ли Aspose.Slides каждую функцию Excel?**

Нет. Встроенный оценщик поддерживает только документированный набор функций. Функции, не входящие в этот набор, не следует считать корректно пересчитывающимися. Если требуется полная совместимость с формулами Excel, выполните расчёт внешним движком электронных таблиц и запишите окончательные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не менялись, в рабочей книге может оставаться ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Попытка доступа к ячейке, формула которой не может быть обработана, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Являются ли значения ошибок формул тем же, что и исключения Python?**

Нет. Значение вроде `#DIV/0!` — это значение ячейки, полученное в результате корректного вычисления. Исключения такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) указывают на то, что формула не может быть обработана обычным способом.

**Обновляется ли диаграмма автоматически при изменении ячейки с формулой?**

Серия диаграммы может ссылаться на ячейки рабочей книги. Сначала пересчитайте рабочую книгу, затем сохраните или отобразите презентацию. Если точки данных диаграммы ссылаются на рассчитанные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не требуется.

**Могут ли диаграммы использовать внешний рабочий лист Excel?**

Да, данные диаграммы можно настроить для использования внешнего листа через API данных диаграммы. Однако описанный в этой статье процесс вычисления формул относится к рабочей книге диаграммы и набору формул, оцениваемых Aspose.Slides. Не следует полагать, что [calculate_formulas](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) полностью пересчитывает произвольные формулы во внешнем файле XLSX.

**Можно ли использовать формулы, ссылающиеся на другой лист или книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но их оценка ограничена поддерживаемым парсером и набором функций. Если необходима перекрёстная ссылка на лист или внешний файл, проверьте корректность такой формулы для вашей версии Aspose.Slides. Для процессов, требующих широкой совместимости ссылок Excel, вычислите рабочую книгу внешне и запишите полученные значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides задают выражения без ведущего `=`, например `B2-C2` или `SUM(B2:B5)`. Такой формат сохраняет согласованность с документированными примерами API.