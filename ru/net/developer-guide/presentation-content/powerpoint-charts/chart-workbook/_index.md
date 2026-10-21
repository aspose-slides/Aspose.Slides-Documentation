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
- метка данных
- лист
- источник данных
- внешняя рабочая книга
- внешние данные
- кеш диаграммы
- восстановление рабочей книги
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Откройте для себя Aspose.Slides для .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая работу с данными вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Описывается, как читать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. Примеры показывают, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и изменять данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/net/chart-series/) — разницу между пустой ячейкой и нулём, а также сравнение доступных режимов отображения на линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) — чтобы управлять тем, будет ли диаграмма использовать данные из скрытых строк и столбцов листа. Установите `true`, чтобы отображать только видимые ячейки, или `false`, чтобы включить как видимые, так и скрытые. Эта настройка управляет построением диаграммы; она не скрывает и не делает видимыми строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму в качестве первой формы на первом слайде. Встроенный лист `Sheet1` содержит диапазон `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розничная продажа | C: Оптовая продажа (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (скрытая строка) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Доступ к исходным ячейкам получайте через [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) и читайте [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) — чтобы проверить их статус скрытия. Это свойство только для чтения. В данном файле B2 видима, B3 относится к скрытой строке, а C2 — к скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) и загрузите её заново с помощью [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). При включении всех ячеек также используйте [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/), чтобы восстановить полный диапазон, включая скрытую категорию «Февраль». Простое изменение флага недостаточно для обновления кэша данных диаграммы и меток категорий в этом примере.

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

        // Обновить данные диаграммы из встроенной рабочей книги.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Восстановить полный исходный диапазон, включая скрытые категории.
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

Пример сохраняет две версии презентации: одну только с видимыми значениями розничных продаж (10 и 20), а другую со всеми шести значениями. Ниже показаны изображения, полученные из сохранённых презентаций после их повторного открытия; обе файлы сохраняют выбранную настройку построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розничных продаж 10 и 20 для января и марта.](hidden_cells_True.png) | ![Все ячейки: значения розничных и оптовых продаж для января, февраля и марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) — управляет тем, как отображаются отсутствующие значения; она не включает и не исключает скрытые исходные данные. См. [Control the Display of Empty Cells](/slides/ru/net/chart-series/#control-the-display-of-empty-cells) — пример.

## **Получение диапазона данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте исходные диапазоны, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` разделяет его от диапазона ячеек, а `$A$1:$D$5` указывает ячейки от A1 до D5 включительно. Знаки доллара означают абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу в качестве источника данных, будет выброшено исключение [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Подробнее см. в [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

В этом примере открывается презентация и проверяются формы на каждом слайде на наличие диаграмм. Выводятся имя каждой диаграммы и её исходный диапазон. Если диаграмма не использует рабочую книгу, выводится сообщение и процесс переходит к следующей диаграмме.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Чтение и запись данных диаграммы из рабочей книги**

Aspose.Slides for .NET предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание** — данные диаграммы должны быть организованы тем же способом или иметь структуру, аналогичную исходной.

В примере используется презентация, в которой диаграмма является первой формой на первом слайде. Встроенная рабочая книга читается в поток, очищаются существующие серии и категории, затем та же рабочая книга записывается обратно. Изменения остаются в памяти; пример не сохраняет презентацию.

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

### **Проверка компоновки диаграммы после изменения рабочей книги**

При замене встроенной рабочей книги изменённой, диаграмма сохраняет свои исходные коллекции серий и категорий. Такое несоответствие может привести к сбою [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) с ошибкой «index out of range». Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. В примере используется диаграмма, являющаяся первой формой на первом слайде. Комментарий отмечает место, где должна происходить правка рабочей книги; runnable‑пример записывает оригинальную рабочую книгу обратно и проверяет компоновку в памяти.

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

Очистка коллекций удаляет устаревшие ссылки перед записью рабочей книги. Перед использованием диаграммы воссоздайте необходимые сопоставления серий и категорий для обновлённой рабочей книги.

## **Установка пользовательских числовых форматов для ячеек рабочей книги**

Используйте [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) — чтобы управлять отображением числовых значений в встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться вывод коэффициента конверсии в виде процента с четырёх знаками после запятой и коэффициента с пятью знаками после запятой. Оставьте оба значения числовыми, чтобы они оставались доступными для расчётов и построения диаграмм.

Числовой формат меняет только отображение, а не сохраняемое значение. Формат `0.0000%` выводит `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` выводит `0.1234567` как `0.12346` без округления сохранённого значения. Если пользовательский формат — пустая строка (`""`), используется [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/).

В следующем примере создаётся столбчатая диаграмма и её ячейки получают доступ через [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Обе ячейки поставляют значения диаграммы. Пример также включает метки значений, привязанные к исходным форматам.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

Форматы ячеек рабочей книги отдельны от форматов, задаваемых напрямую на осях диаграммы или метках данных. В этом примере каждая метка показывает значение своей исходной ячейки, потому что включён [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/), а также параметр [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) установлен в `true`. После сохранения и повторного открытия презентации метки отображают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`, а [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) для неё `false`.

Чтобы задать отдельный формат для метки, отключите привязку к источнику, установив соответствующий флаг в `false`, и задайте её [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Это не меняет формат ячейки рабочей книги. Например, независимый формат метки `0.00` выводит первое значение как `0.13`, в то время как B2 по‑прежнему показывает `12.5000%`. См. [Chart Data Labels](/slides/ru/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) — прямое форматирование меток.

Ниже изображение, полученное из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с метками, связанными с источником, показывающая 12.5000% и 0.12346, а также независимо отформатированной числовой осью.](custom-cell-formats.png)

## **Использование ячейки рабочей книги в качестве метки данных диаграммы**

Текст из ячеек рабочей книги можно использовать в качестве меток данных диаграммы.

В этом примере к первой форме существующей презентации добавляется пузырьковая диаграмма с данными по умолчанию. Для первых трёх меток первого ряда используются ячейки A10:A12 листа 0, включаются метки из ячеек, и сохраняется обновлённая презентация.

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

Свойство [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) предоставляет доступ к листам в рабочей книге диаграммы. В примере создаётся круговая диаграмма с данными по умолчанию и выводятся имена всех листов в консоль.

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

В этом примере создаётся 3‑мерная столбчатая диаграмма с данными по умолчанию и задаются два имени рядов, использующие разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами рядов.

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

Aspose.Slides не поддерживает бинарный формат рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Для обнаружения неподдерживаемых форматов и пропуска таких диаграмм используйте свойство [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) интерфейса [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/). Пример проверяет формы на первом слайде существующей презентации, пропускает не‑диаграммные формы и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

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

    // Прочитать или изменить поддерживаемые данные рабочей книги диаграммы здесь.
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/), чтобы экспортировать встроенную рабочую книгу диаграммы в файл и связать диаграмму с этой внешней книгой.

В примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её рабочая книга. Поток вывода закрывается до назначения внешней рабочей книги в качестве источника данных диаграммы, после чего сохраняется связанная презентация.

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

С помощью метода [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) можно назначить внешнюю рабочую книгу диаграмме как источник данных. Этот метод также позволяет обновить путь к внешней рабочей книге (если она была перемещена).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги всё равно могут использоваться как внешний источник данных. Если указан относительный путь к внешней рабочей книге, он автоматически преобразуется в абсолютный.

В примере используется внешняя рабочая книга, лист которой `Sheet1` содержит имя ряда в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает её с книгой и использует [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) для сопоставления A1:B4 с одним рядом и тремя категориями. Затем сохраняется презентация со связанной диаграммой.

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

Параметр `updateChartData` метода [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) управляет тем, будет ли загружена рабочая книга.

* Когда `updateChartData` равен `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* Когда `updateChartData` равен `true`, данные диаграммы обновляются из целевой книги.

В следующем примере задаётся заглушка URL с `updateChartData` =`false`. Сохраняется презентация с данными круговой диаграммы по умолчанию без загрузки недоступной книги.

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

### **Получение пути к внешнему источнику данных рабочей книги диаграммы**

Чтобы определить, к какой рабочей книге привязана диаграмма, проверьте, использует ли диаграмма внешний источник данных, и получите путь к её рабочей книге.

Пример проверяет первую форму на первом слайде презентации, содержащей ссылку на внешнюю рабочую книгу. Если это диаграмма, связанная с внешней книгой, пример выводит [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) в консоль, затем сохраняет копию презентации.

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

Данные во внешних рабочих книгах можно изменять так же, как и в встроенных. Если внешняя рабочая книга не может быть загружена, выбрасывается исключение.

В примере используется диаграмма, являющаяся первой формой на первом слайде и связанная с доступной внешней книгой. Значение первого пункта первого ряда, поддерживаемое ячейкой, устанавливается в 100, и обновлённая презентация сохраняется. При изменении значений ячеек можно обновлять связанный внешний файл XLSX, поэтому используйте копию, если нужно сохранить оригинальную книгу.

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

Если диаграмма использует внешнюю рабочую книгу, которая отсутствует или недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), настройте её [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) и установите [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) в `true` перед открытием презентации.

В следующем примере на C# восстанавливаются данные рабочей книги для диаграммы, которая является первой формой на первом слайде и ссылается на недоступную внешнюю книгу. Данные получаются через [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) и [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true;
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions;
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Прочитайте или измените восстановленные данные рабочей книги здесь.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides бросает [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемой альтернативой, поскольку кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Могу ли я определить, к какой именно рабочей книге привязана конкретная диаграмма — внешней или встроенной?**

Да. У диаграммы есть [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) и [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); если тип источника — внешняя рабочая книга, можно считать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому перемещение книги может потребовать обновления ссылки.

**Можно ли использовать книги, размещённые на сетевых ресурсах/общих папках?**

Да, такие книги могут использоваться как внешний источник данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно только использовать в качестве источника.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). При редактировании данных, поддерживаемых ячейками, можно также обновить связанный локальный файл XLSX. Используйте копию книги, если оригинал должен оставаться неизменным.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при установке ссылки. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/net/)) и связываются с этой копией.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную ссылку. Если все они указывают на один и тот же файл, изменение этого файла отразится в каждой диаграмме при следующей загрузке данных.