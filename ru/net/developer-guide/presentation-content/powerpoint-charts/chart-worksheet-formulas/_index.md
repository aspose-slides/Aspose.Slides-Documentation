---
title: Применение формул листов диаграмм в презентациях на .NET
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/net/chart-worksheet-formulas/
keywords:
- диаграмма электронная таблица
- лист диаграммы
- формула диаграммы
- формула листа
- формула электронных таблиц
- рабочая книга данных диаграммы
- вычисление формулы
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
- .NET
- C#
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides for .NET, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят исходные данные во вложенном листе. В Aspose.Slides для .NET вы можете получить доступ к этому листу через рабочую книгу данных диаграммы, записывать входные значения, назначать формулы ячейкам, вычислять поддерживаемые формулы и использовать вычисленные ячейки как данные диаграммы.

В этой статье объясняется полный рабочий процесс с формулами: создание диаграммы, заполнение её листа, назначение формул в стиле A1 или R1C1, их повторный расчёт, чтение вычисленных значений, связывание этих ячеек с рядом диаграммы и сохранение презентации. Также описываются поддерживаемый синтаксис формул, набор встроенных функций, кешированные значения, нес поддерживаемые формулы и ошибки, характерные для электронных таблиц.

## **Листы диаграмм и формулы**

Лист диаграммы содержит категории, имена рядов и значения, используемые диаграммой. В PowerPoint вы можете просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытым вложенным листом, показывающая данные категорий и рядов](chart-worksheet-formulas_1.png)

В Aspose.Slides лист доступен через [рабочую книгу данных диаграммы](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/). Используйте свойство [Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/formula/) для формул в стиле A1 и свойство [R1C1Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/r1c1formula/) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) для пересчёта поддерживаемых формул и обновления соответствующих значений ячеек.

Вычисленная ячейка по‑прежнему предоставляет свой результат через свойство [Value](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/value/). Это важно, когда необходимо проверить результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

В следующем примере демонстрируется сквозной рабочий процесс. Он создаёт сгруппированную столбчатую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки как значения диаграммы и сохраняет презентацию.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Точки данных диаграммы ссылаются на `D2:D4`, поэтому диаграмма использует вычисленные значения прибыли. В этом рабочем процессе нет отдельного вызова обновления диаграммы: сначала пересчитайте рабочую книгу, затем используйте или сохраните данные диаграммы, указывающие на вычисленные ячейки.

## **Использование формул в стиле A1**

A1‑notation определяет столбцы буквами, а строки — цифрами. Присваивайте выражения в стиле A1 через [IChartDataCell.Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `A2` | `$A$2` | `A$2`, `$A2` |
| Строка | `2:2` | `$2:$2` | — |
| Столбец | `A:A` | `$A:$A` | — |
| Диапазон | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Относительные ссылки могут изменяться при перемещении или копировании формулы в приложении электронных таблиц. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или только столбец.

## **Использование формул в стиле R1C1**

Нотация R1C1 численно определяет как строки, так и столбцы. Относительные ссылки используют смещения в квадратных скобках. Присваивайте такой синтаксис через [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Строка | `R[2]` | `R2` | — |
| Столбец | `C[3]` | `C3` | — |
| Диапазон | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Например, в ячейке `D2` выражение `RC[-2]` означает ячейку в той же строке, но на два столбца влево (`B2`).

## **Константы и операторы формул**

Встроенный вычислитель формул поддерживает логические значения, числовые литералы, строки, значения ошибок листа, арифметические операторы и операторы сравнения.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычная и научная нотация. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Результат ошибки | `#DIV/0!`, `#N/A`, `#REF!` | Допустимая формула может возвращать значение ошибки листа вместо обычного результата. |

В этом примере используются несколько типов констант:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Ложь
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
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
| `<` | Меньше | `A2<3` |
| `<=` | Меньше или равно | `A2<=3` |

## **Поддерживаемые предопределённые функции**

Aspose.Slides содержит встроенный вычислитель формул для листов диаграмм, но это не полноценный движок расчётов Excel. Документированный набор функций ограничен приведёнными ниже функциями. Не следует полагать, что произвольную функцию Excel можно пересчитать с помощью [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание значения даты с использованием системы дат 1900 года | `DATE(2026,8,19)` |
| `DAYS` | Возвращает количество дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск одного текстового значения внутри другого | `FIND("-",A2)` |
| `FINDB` | Поиск текста по байтам | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Форма ссылки | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Суммирование значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, существенны: `INDEX` документирован в виде ссылки, тогда как `LOOKUP` и `MATCH` — в их векторных формах. `DATE` использует систему дат 1900 года. Функции и возможности, не перечисленные здесь, следует рассматривать как неподдерживаемые вычислителем формул Aspose.Slides, если они не описаны отдельно.

## **Пересчёт и кешированные значения**

Файлы электронных таблиц обычно хранят как формулу, так и её последнюю вычисленную величину. Поэтому Aspose.Slides может считывать кешированное значение из [IChartDataCell.Value](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/value/) , когда презентация загружена и соответствующие данные диаграммы не изменены.

После изменения входных ячеек или формул не полагайтесь на старый кешированный результат. Вызовите [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) перед чтением вычисленных значений или сохранением данных диаграммы, от которых они зависят.

Для формул, выходящих за поддерживаемый набор, Aspose.Slides может не суметь разобрать формулу или установить её зависимости. Если рабочая книга была изменена, предыдущее кешированное значение уже нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Если ваша диаграмма зависит от функций Excel, которые Aspose.Slides не вычисляет, вычислите эти формулы с помощью движка электронных таблиц, который их поддерживает, и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы предполагаемыми значениями.

## **Обработка ошибок формул**

Существует два разных типа проблем, которые необходимо различать.

Формула может быть корректной, но возвращать ошибочный результат листа, например `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через `Value`.

Формула также может завершиться неудачей на уровне разбора, ссылки, зависимости или поддерживаемых данных. Aspose.Slides предоставляет специфичные для листов исключения для этих случаев: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Когда формулы поступают из шаблонов или ввода пользователя, обрабатывайте эти исключения вокруг пересчёта и доступа к значениям:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Практические ограничения**

Поддержка формул в листах диаграмм предназначена для ограниченного набора вычислений электронных таблиц, а не для полной совместимости с Excel. Учтите эти ограничения при разработке рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, когда требуется, чтобы Aspose.Slides пересчитывал формулы.
- Пересчитывайте после изменения ячеек, от которых зависят результаты формул.
- Считайте кешированные значения из загруженных презентаций снимками, а не заменой пересчёту после правок.
- Тестируйте формулы из существующих шаблонов, прежде чем полагаться на их вычисленные значения, особенно если они используют функции, не входящие в документированный список.
- Для формул, требующих полного движка расчётов электронных таблиц, вычисляйте их внешне, а затем обновляйте рабочую книгу диаграммы полученными значениями.

## **FAQ**

**В чём разница между `Formula` и `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/formula/) сохраняет выражение в стиле A1, например `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/r1c1formula/) сохраняет выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует тому, как вы генерируете или копируете формулы.

**Нужно ли читать саму ячейку или её значение после расчёта?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/getcell/) возвращает `IChartDataCell`. Чтобы получить вычисленный результат, читайте свойство [Value](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/value/) этой ячейки после пересчёта.

**Когда следует вызывать `CalculateFormulas`?**

Вызывайте [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) после изменения входных значений или формул и перед тем, как вам потребуются вычисленные результаты. Это обновляет значения формул, поддерживаемых встроенным вычислителем.

**Поддерживает ли Aspose.Slides все функции Excel?**

Нет. Встроенный вычислитель поддерживает документированный подмножество функций. Не следует полагать, что функции за пределами этого набора будут пересчитаны корректно. Если требуется полная совместимость с формулами Excel, выполните вычисление с помощью подходящего движка электронных таблиц и запишите окончательные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не изменились, в рабочей книге может оставаться ранее вычисленное кешированное значение. После изменения связанных данных это кешированное значение может стать недействительным. Доступ к ячейке, формула которой не может быть обработана, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Являются ли значения ошибок формул теми же, что и исключения .NET?**

Нет. Результат вроде `#DIV/0!` — это значение листа, полученное в результате корректного вычисления. Исключения, такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), указывают на то, что формула не может быть обработана обычным способом.

**Обновляется ли диаграмма автоматически при изменении ячейки с формулой?**

Ряд диаграммы может ссылаться на ячейки рабочей книги. Сначала пересчитайте рабочую книгу, затем сохраните или отрендерите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует обновлённые значения; отдельный метод обновления диаграммы не требуется в этом рабочем процессе.

**Могут ли диаграммы использовать внешний рабочий лист Excel?**

Да, данные диаграммы можно настроить на использование внешней рабочей книги через API данных диаграммы. Однако описанный в этой статье процесс вычисления формул относится к рабочей книге данных диаграммы и подмножеству формул, оцениваемому Aspose.Slides. Не следует полагать, что [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) обеспечивает полный пересчёт произвольных формул во внешнем файле XLSX.

**Могу ли я использовать формулы, ссылающиеся на другой лист или рабочую книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но оценка формул ограничена поддерживаемым парсером и набором функций. Если ссылка между листами или внешняя ссылка критична, проверьте точную формулу с вашей целевой версией Aspose.Slides. Для процессов, требующих широкой совместимости ссылок Excel, вычисляйте рабочую книгу внешне и записывайте полученные значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides присваивают выражения, такие как `B2-C2` или `SUM(B2:B5)`, без начального `=`. Использование такой формы сохраняет согласованность с документированными примерами API.