---
title: Управление рабочими книгами диаграмм в презентациях на .NET
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/net/chart-workbook/
keywords:
- рабочая книга диаграммы
- данные диаграммы
- ячейка рабочей книги
- подпись данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кэш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные ваших презентаций."
---
## **Обзор**

Эта статья объясняет, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграмм через потоки рабочей книги, использовать ячейки рабочей книги в качестве подписей данных диаграммы, получать доступ к коллекциям листов и задавать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры демонстрируют, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и изменить данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/net/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение линейных диаграмм доступных режимов отображения.

## **Включать данные из скрытых строк и столбцов**

Используйте [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) для управления тем, будет ли диаграмма строить данные из скрытых строк и столбцов листа. Установите `true`, чтобы строить только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не раскрывает строки или столбцы листа.

Скачайте [hidden-source-data.pptx](hidden-source-data.pptx) и разместите его в рабочем каталоге. На первом слайде находится столбчатая диаграмма как первая фигура. Встроенный лист `Sheet1` содержит исходный диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничные | C: Оптовые (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/chartdataworkbook/) и читайте [IChartDataCell.IsHidden](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/ishidden/) для проверки их скрытого статуса. Это свойство только для чтения. В этом файле B2 видима, B3 принадлежит скрытой строке, а C2 — скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: оставьте встроенную рабочую книгу с помощью [ReadWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/readworkbookstream/) и загрузите её заново с помощью [WriteWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/writeworkbookstream/). При включении всех ячеек также используйте [SetRange](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию февраля. Простая смена флага недостаточна для обновления кэшированных данных диаграммы и меток категорий в этом образце.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Обновите данные диаграммы из встроенной рабочей книги.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Восстановите полный исходный диапазон, включая скрытые категории.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Пример сохраняет `hidden_cells_True.pptx` только с видимыми значениями розницы (10 и 20) и `hidden_cells_False.pptx` со всеми шестью значениями. Ниже показанные изображения получены из сохранённых презентаций после их повторного открытия; оба файла сохраняют назначенную настройку построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/displayblanksas/) управляет тем, как отображаются отсутствующие значения; она не включает и не исключает скрытые исходные данные. См. [Control the Display of Empty Cells](/slides/ru/net/chart-series/#control-the-display-of-empty-cells) для примера.

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for .NET предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные диаграмм, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаковым образом или иметь структуру, аналогичную исходной.

Этот пример открывает `chart.pptx`, который должен содержать диаграмму как первую фигуру на первом слайде. Он считывает встроенную рабочую книгу в поток, очищает существующие серии и категории и записывает ту же рабочую книгу обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Проверка макета диаграммы после изменения рабочей книги**

Когда вы заменяете встроенную рабочую книгу модифицированной, диаграмма сохраняет свои оригинальные коллекции серий и категорий. Это несоответствие может привести к сбою [IChart.ValidateChartLayout](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/validatechartlayout/) с ошибкой «индекс за пределами диапазона». Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. Этот пример требует `chart.pptx` с диаграммой как первой фигурой на первом слайде. Комментарий отмечает место, где будет редактироваться рабочая книга; исполняемый пример записывает оригинальную рабочую книгу обратно и проверяет макет в памяти.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Измените поток рабочей книги здесь, например, используя Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Очистка коллекций удаляет устаревшие ссылки данных перед записью рабочей книги. Восстановите любые необходимые отображения серий и категорий для обновлённой рабочей книги перед использованием диаграммы.

## **Установка ячейки рабочей книги в качестве подписи данных диаграммы**

Вы можете использовать текст из ячеек рабочей книги в качестве подписей данных диаграммы. Ниже приведены шаги, показывающие, как привязать подписи в пузырьковой диаграмме к ячейкам её рабочей книги.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите первый слайд по нулевому индексу.
1. Добавьте пузырьковую диаграмму с данными по умолчанию.
1. Получите серии диаграммы.
1. Установите ячейку рабочей книги в качестве подписи данных.
1. Сохраните презентацию.

Этот пример открывает `chart2.pptx`, который должен содержать хотя бы один слайд, и добавляет пузырьковую диаграмму с данными по умолчанию. Он использует ячейки A10:A12 на листе 0 для первых трёх подписей первой серии, включает подписи из ячеек и сохраняет результат в `resultchart.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Управление листами**

Свойство [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/worksheets/) предоставляет доступ к листам в рабочей книге диаграммы. Этот пример создаёт круговую диаграмму с данными по умолчанию и выводит имя каждого листа в консоль.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Указание типа источника данных**

Этот пример создаёт 3‑D столбчатую диаграмму с данными по умолчанию и задаёт два имени серий, используя разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 на листе 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/datasourcetype/) выбирает источник для каждого имени. Результат сохраняется в `pres.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Обнаружение неподдерживаемых форматов встроенных рабочих книг**

Aspose.Slides не поддерживает двоичный формат рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Вы можете использовать свойство [EmbeddedWorkbookType](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) на [IChartData](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/) вместе с перечислением [WorkbookType](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Этот пример проверяет фигуры на первом слайде `sample.pptx`, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы со встроенной рабочей книгой .xlsb.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Чтение или изменение поддерживаемых данных рабочей книги диаграммы здесь.
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [ReadWorkbookStream](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [SetExternalWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/setexternalworkbook/) для экспорта встроенной рабочей книги диаграммы в файл и привязки диаграммы к этой внешней рабочей книге.

Этот пример создаёт круговую диаграмму с данными по умолчанию, записывает её рабочую книгу в `externalWorkbook1.xlsx` и закрывает поток вывода перед назначением файла в качестве источника данных диаграммы. Он сохраняет связанную презентацию в `externalWorkbook.pptx`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Назначение внешней рабочей книги**

С помощью метода [SetExternalWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/setexternalworkbook/) вы можете назначить внешнюю рабочую книгу диаграмме в качестве её источника данных. Этот метод также можно использовать для обновления пути к внешней рабочей книге (если она была перемещена).

Хотя вы не можете редактировать данные в рабочих книгах, хранящихся в удалённых расположениях или ресурсах, такие книги можно использовать как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в полный путь.

Этот пример требует `externalWorkbook.xlsx` в рабочем каталоге. На листе `Sheet1` должны быть имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает рабочую книгу и использует [SetRange](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/setrange/) для отображения диапазона A1:B4 в одну серию и три категории. Результат сохраняется в `Presentation_with_externalWorkbook.pptx`.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

Параметр `updateChartData` метода [SetExternalWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/setexternalworkbook/) управляет тем, загружается ли рабочая книга.

* Когда `updateChartData` равно `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой рабочей книги, поэтому рабочая книга может быть недоступна.
* Когда `updateChartData` равно `true`, данные диаграммы обновляются из целевой рабочей книги.

В следующем примере назначается заполнитель URL со значением `updateChartData` = `false`. Сохраняется диаграмма с данными по умолчанию, и презентация сохраняется без загрузки недоступной рабочей книги.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Получение пути к внешней рабочей книге, использующейся в диаграмме**

Чтобы определить, какая рабочая книга привязана к диаграмме, сначала проверьте, использует ли диаграмма внешний источник данных. Если да, вы можете получить путь к рабочей книге, выполнив следующие действия.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/).
1. Получите первый слайд по нулевому индексу.
1. Убедитесь, что первая фигура является диаграммой.
1. Прочитайте тип источника данных диаграммы.
1. Если источник — внешняя рабочая книга, прочитайте её путь.

Этот пример открывает `externalWorkbook.pptx`, созданный в предыдущем примере, и проверяет первую фигуру на первом слайде. Если это диаграмма, привязанная к внешней рабочей книге, пример выводит [ExternalWorkbookPath](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/externalworkbookpath/) в консоль. Затем он сохраняет копию презентации в `Result.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Редактирование данных диаграммы**

Вы можете редактировать данные во внешних рабочих книгах так же, как вносите изменения во внутренние. Если внешняя рабочая книга не может быть загружена, генерируется исключение.

Этот пример требует `presentation.pptx` с диаграммой как первой фигурой на первом слайде и доступной внешней рабочей книги. Он задаёт значение первой точки данных первой серии, опираясь на ячейку, равным 100, и сохраняет презентацию в `presentation_out.pptx`. Редактирование значений ячеек может обновлять связанный внешний файл XLSX, поэтому используйте копию, если необходимо сохранить оригинальную рабочую книгу.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Восстановление рабочей книги из кэша диаграммы**

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может реконструировать рабочую книгу диаграммы из данных, кэшированных в презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/), настройте её [SpreadsheetOptions](https://reference.aspose.com/slides/ru/net/aspose.slides/loadoptions/spreadsheetoptions/) и установите [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ru/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) в `true` перед открытием презентации.

Следующий пример на C# открывает `presentation.pptx`, у которого первая фигура на первом слайде должна быть диаграммой, ссылающейся на недоступную внешнюю рабочую книгу, и получает восстановленные данные через [IChart.ChartData](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/chartdata/) и [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Прочитайте или измените данные восстановленной рабочей книги здесь.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Если внешняя рабочая книга недоступна, а восстановление отключено, Aspose.Slides генерирует [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Включайте восстановление только когда использование кэшированных данных диаграммы является приемлемой альтернативой, поскольку кэш может не содержать изменений, внесённых во внешнюю рабочую книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/datasourcetype/) и [path to an external workbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/externalworkbookpath/); если источник — внешняя рабочая книга, вы можете прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. Если вы указываете относительный путь, он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому перемещение рабочей книги может потребовать обновления ссылки.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие рабочие книги могут быть использованы как внешний источник данных. Однако редактировать удалённые рабочие книги напрямую из Aspose.Slides не поддерживается — их можно только использовать как источник.

**Перезаписывает ли Aspose.Slides внешний файл XLSX при сохранении презентации?**

Презентация сохраняет [link to the external file](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/chartdata/externalworkbookpath/). Редактирование данных диаграммы, основанных на ячейках, также может обновлять связанный локальный файл XLSX. Используйте копию рабочей книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при привязке. Обычный подход — снять защиту заранее или подготовить расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/net/)) и привязать её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит собственную ссылку. Если все они указывают на один и тот же файл, обновление этого файла будет отражено во всех диаграммах при следующей загрузке данных.