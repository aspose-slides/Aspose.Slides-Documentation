---
title: Применение формул листа диаграммы в презентациях на .NET
linktitle: Формулы листа
type: docs
weight: 70
url: /ru/net/chart-worksheet-formulas/
keywords:
- таблица диаграммы
- рабочий лист диаграммы
- формула диаграммы
- формула листа
- формула электронной таблицы
- рабочая книга данных диаграммы
- вычисление формулы
- предпочтительная культура
- культура-специфическая формула
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
- .NET
- C#
- Aspose.Slides
description: "Применяйте формулы в стиле Excel в листах диаграмм Aspose.Slides для .NET, пересчитывайте значения и используйте результаты в диаграммах PowerPoint."
---
## **Обзор**

Диаграммы PowerPoint обычно хранят свои исходные данные во встроенном листе. В Aspose.Slides для .NET вы можете получить доступ к этому листу через рабочую книгу данных диаграммы, записывать входные значения, назначать формулы ячейкам, вычислять поддерживаемые формулы и использовать вычисленные ячейки в качестве данных диаграммы.

В этой статье объясняется полный рабочий процесс работы с формулами: создание диаграммы, заполнение её листа, назначение формул в стиле A1 или R1C1, их пересчёт, чтение вычисленных значений, привязка этих ячеек к серии диаграммы и сохранение презентации. Также описываются поддерживаемый синтаксис формул, набор встроенных функций, кэшированные значения, неподдерживаемые формулы и ошибки, характерные для электронных таблиц.

## **Листы диаграмм и формулы**

Рабочий лист диаграммы содержит категории, названия серий и значения, используемые диаграммой. В PowerPoint вы можете просмотреть лист, открыв редактор данных диаграммы:

![Диаграмма PowerPoint с открытым встроенным листом, показывающая данные категорий и серий](chart-worksheet-formulas_1.png)

В Aspose.Slides лист доступен через [рабочую книгу данных диаграммы](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/). Используйте свойство [Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/formula/) для формул в стиле A1 и свойство [R1C1Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/r1c1formula/) для формул в стиле R1C1. После изменения входных ячеек или формул вызовите [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) для пересчёта поддерживаемых формул и обновления соответствующих значений ячеек.

Вычисленная ячейка всё ещё предоставляет свой результат через свойство [Value](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/value/). Это важно, когда необходимо просмотреть результат формулы в коде или использовать ячейку как точку данных диаграммы.

## **Создание диаграммы и вычисление формул листа**

Следующий пример демонстрирует сквозной рабочий процесс. Он создаёт группированную столбчатую диаграмму, очищает примерные данные, записывает квартальные значения доходов и расходов, вычисляет прибыль с помощью формул, читает результаты, использует вычисленные ячейки в качестве значений диаграммы и сохраняет презентацию.

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

Нотация A1 обозначает столбцы буквами, а строки – числами. Присваивайте выражения в стиле A1 через [IChartDataCell.Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/formula/).

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

Распространённые формы ссылок A1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `A2` | `$A$2` | `A$2`, `$A2` |
| Строка | `2:2` | `$2:$2` | — |
| Столбец | `A:A` | `$A:$A` | — |
| Диапазон | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Относительные ссылки могут изменяться, когда формула перемещается или копируется в приложении электронных таблиц. Абсолютные ссылки фиксируют обе координаты, а смешанные фиксируют только строку или столбец.

## **Использование формул в стиле R1C1**

Нотация R1C1 численно обозначает и строки, и столбцы. Относительные ссылки используют смещения в квадратных скобках. Присваивайте эту синтаксис через [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

Распространённые формы ссылок R1C1:

| Ссылка | Относительная | Абсолютная | Смешанная |
|---|---|---|---|
| Ячейка | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Строка | `R[2]` | `R2` | — |
| Столбец | `C[3]` | `C3` | — |
| Диапазон | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Например, в ячейке `D2` `RC[-2]` обозначает ячейку в той же строке на два столбца влево (`B2`).

## **Константы и операторы формул**

Встроенный Evaluator формул поддерживает логические значения, числовые литералы, строки, значения ошибок электронных таблиц, арифметические операторы и операторы сравнения.

### **Константы и литералы**

| Тип | Примеры | Примечания |
|---|---|---|
| Логический | `TRUE`, `FALSE` | Можно использовать напрямую в логических выражениях, например `A2=TRUE`. |
| Числовой | `1`, `0.5`, `.3`, `1E-2` | Поддерживаются обычные и научные нотации. |
| Строка | `"abc"`, `"2/3/2020 12:00"` | Текстовые литералы заключаются в двойные кавычки внутри формулы. |
| Результат ошибки | `#DIV/0!`, `#N/A`, `#REF!` | Допустимая формула может вернуть значение ошибки электронной таблицы вместо обычного результата. |

Этот пример использует несколько типов констант:

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
| `-` | Вычитание или унарный минус | `2-3`, `-3` |
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

Aspose.Slides включает встроенный Evaluator формул для листов диаграмм, но это не полноценный движок расчётов Excel. Документированный набор функций ограничен функциями, перечисленными ниже. Не следует предполагать, что произвольную функцию Excel можно пересчитать с помощью [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Функция | Назначение или поддерживаемая форма | Пример |
|---|---|---|
| `ABS` | Абсолютное значение | `ABS(A2)` |
| `AVERAGE` | Среднее арифметическое | `AVERAGE(B2:B5)` |
| `CEILING` | Округление числа вверх до кратного | `CEILING(A2,5)` |
| `CHOOSE` | Выбор значения по индексу | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Объединение текстовых значений | `CONCAT(A2,B2)` |
| `CONCATENATE` | Объединение текстовых значений | `CONCATENATE(A2," ",B2)` |
| `DATE` | Создание даты, используя систему дат 1900 года | `DATE(2026,8,19)` |
| `DAYS` | Возврат количества дней между датами | `DAYS(B2,A2)` |
| `FIND` | Поиск одного текстового значения внутри другого | `FIND("-","A2")` |
| `FINDB` | Поиск текста по байтам | `FINDB("a",A2)` |
| `IF` | Условный результат | `IF(A2>0,A2,0)` |
| `INDEX` | Форма ссылки | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Векторная форма | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Векторная форма | `MATCH(A2,B2:B5,0)` |
| `MAX` | Максимальное значение | `MAX(B2:B5)` |
| `SUM` | Сумма значений | `SUM(B2:B5)` |
| `VLOOKUP` | Вертикальный поиск | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ограничения, указанные в таблице, значимы: `INDEX` документирован в виде ссылки, тогда как `LOOKUP` и `MATCH` — в их векторных формах. `DATE` использует систему дат 1900 года. Функции и возможности, не перечисленные здесь, следует считать неподдерживаемыми Evaluator формул Aspose.Slides, если они не задокументированы отдельно.

## **Вычисление формул с предпочтительной культурой**

Некоторые функции рабочей книги диаграммы интерпретируют текст в соответствии с правилами конкретной культуры. Это особенно важно для функций, предназначенных для языков, использующих двубайтовые наборы символов (DBCS). Чтобы правильно вычислять такие формулы, создайте [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/), установите [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/ru/net/aspose.slides/ispreadsheetoptions/preferredculture/) через [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/spreadsheetoptions/), а затем загрузите презентацию.

В следующем примере выбирается японская культура, открывается презентация с настроенными параметрами загрузки, и вызывается [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) для каждой рабочей книги диаграммы:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

Предпочтительная культура является частью конфигурации загрузки презентации, поэтому укажите её до создания экземпляра [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). Используйте культуру, ожидаемую формулами рабочей книги; например, используйте `ja-JP` для формул, которые должны следовать японским правилам расчёта DBCS.

## **Пересчёт и кэшированные значения**

Файлы электронных таблиц обычно хранят формулу и её последнее вычисленное значение. Поэтому Aspose.Slides может прочитать кэшированное значение из [IChartDataCell.Value](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/value/) при загрузке презентации, если соответствующие данные диаграммы не были изменены.

После изменения входных ячеек или формул не полагайтесь на старый кэшированный результат. Вызовите [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) перед чтением вычисленных значений или сохранением данных диаграммы, зависящих от них.

Для формул, не входящих в поддерживаемый набор, Aspose.Slides может не суметь разобрать формулу или определить её зависимости. Если рабочая книга была изменена, предыдущее кэшированное значение больше нельзя считать надёжным. В такой ситуации чтение значения ячейки с неподдерживаемыми данными может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Если ваша диаграмма зависит от функций Excel, которые Aspose.Slides не вычисляет, вычислите эти формулы с помощью движка электронных таблиц, поддерживающего их, и запишите полученные значения обратно в рабочую книгу диаграммы. Не заменяйте неподдерживаемые формулы предполагаемыми значениями.

## **Обработка ошибок формул**

Существует два разных типа проблем, которые нужно различать.

Формула может быть корректной, но возвращать результат ошибки электронных таблиц, такой как `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` или `#VALUE!`. В этом случае токен ошибки является результатом ячейки и может быть возвращён через `Value`.

Формула также может потерпеть неудачу на уровне разбора, ссылки, зависимости или поддерживаемых данных. Aspose.Slides предоставляет специфичные для электронных таблиц исключения для этих случаев: [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), и [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Когда формулы приходят из шаблонов или ввода пользователя, обрабатывайте эти исключения вокруг пересчёта и доступа к значению:

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

Поддержка формул в листах диаграмм предназначена для определённого набора вычислений электронных таблиц, а не для полной совместимости с Excel. Учитывайте эти ограничения при проектировании рабочего процесса отчётности:

- Используйте только документированные константы, операторы, ссылки и функции, когда необходимо, чтобы Aspose.Slides пересчитывал формулы.
- Пересчитывайте после изменения ячеек, от которых зависят результаты формул.
- Считайте кэшированные значения из загруженных презентаций снимками, а не заменой пересчёту после изменений.
- Тестируйте формулы из существующих шаблонов перед тем, как полагаться на их вычисленные значения, особенно если они используют функции, не входящие в документированный список.
- Для формул, требующих полноценного движка расчётов электронных таблиц, вычисляйте их внешне, а затем обновляйте рабочую книгу диаграммы полученными значениями.

## **FAQ**

**В чём разница между `Formula` и `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/formula/) хранит выражение в стиле A1, например `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/r1c1formula/) хранит выражение в стиле R1C1, например `RC[-2]-RC[-1]`. Используйте нотацию, которая лучше соответствует тому, как вы генерируете или копируете формулы.

**Нужно ли читать саму ячейку или её значение после вычисления?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/getcell/) возвращает `IChartDataCell`. Чтобы получить вычисленный результат, прочитайте свойство [Value](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/value/) этой ячейки после пересчёта.

**Когда следует вызывать `CalculateFormulas`?**

Вызовите [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) после изменения входных значений или формул и до того, как вы будете использовать вычисленные результаты. Это обновляет значения формул, поддерживаемых встроенным Evaluator.

**Поддерживает ли Aspose.Slides каждую функцию Excel?**

Нет. Встроенный Evaluator поддерживает документированный набор функций. Функции, не входящие в этот набор, не следует считать корректно пересчитываемыми. Если требуется полная совместимость с формулами Excel, выполните расчёт с помощью соответствующего движка электронных таблиц и запишите окончательные значения в рабочую книгу диаграммы.

**Что происходит, если загруженная презентация содержит неподдерживаемую формулу?**

Если данные диаграммы не изменялись, рабочая книга может всё ещё содержать ранее вычисленное кэшированное значение. После изменения связанных данных это кэшированное значение может стать недействительным. Обращение к ячейке, формула которой не может быть обработана, может вызвать [CellUnsupportedDataException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Являются ли значения ошибок формул теми же, что и исключения .NET?**

Нет. Результат вроде `#DIV/0!` — это значение электронной таблицы, полученное в результате корректного расчёта. Исключения, такие как [CellInvalidFormulaException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) или [CellCircularReferenceException](https://reference.aspose.com/slides/ru/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), указывают на то, что формулу невозможно обработать обычным способом.

**Обновляется ли диаграмма автоматически при изменении ячейки формулы?**

Серия диаграммы может ссылаться на ячейки рабочей книги. Сначала пересчитайте рабочую книгу, затем сохраните или отобразите презентацию. Если точки данных диаграммы ссылаются на вычисленные ячейки, диаграмма использует эти обновлённые значения; отдельный метод обновления диаграммы не требуется в этом рабочем процессе.

**Могут ли диаграммы использовать внешнюю рабочую книгу Excel?**

Да, данные диаграммы можно настроить на использование внешней рабочей книги через API данных диаграммы. Однако описанный в этой статье процесс вычисления формул относится к рабочей книге данных диаграммы и набору формул, оцененных Aspose.Slides. Не следует полагать, что [CalculateFormulas](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) полностью пересчитывает произвольные формулы во внешнем файле XLSX.

**Могу ли я использовать формулы, ссылающиеся на другой лист или рабочую книгу?**

Ссылки в стиле Excel могут присутствовать в рабочих книгах диаграмм, но оценка формул ограничена поддерживаемым парсером и набором функций. Если ссылка между листами или внешняя ссылка критична, проверьте точную формулу в целевой версии Aspose.Slides. Для рабочих процессов, требующих широкой совместимости ссылок Excel, вычисляйте рабочую книгу внешне и записывайте полученные значения обратно в данные диаграммы.

**Должны ли строки формул начинаться с `=`?**

Примеры API Aspose.Slides присваивают выражения, такие как `B2-C2` или `SUM(B2:B5)`, без начального `=`. Использование такой формы сохраняет согласованность генерируемых формул с документированными примерами API.