---
title: Управление рабочими книгами диаграмм в презентациях в .NET
linktitle: Рабочая книга диаграммы
type: docs
weight: 70
url: /ru/net/chart-workbook/
keywords:
- рабочая книга диаграмм
- данные диаграммы
- ячейка рабочей книги
- метка данных
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
description: "Откройте для себя Aspose.Slides для .NET: легко управляйте рабочими книгами диаграмм в форматах PowerPoint и OpenDocument, упрощая данные вашей презентации."
---
## **Обзор**

В этой статье объясняется, как работать с рабочими книгами диаграмм в Aspose.Slides. Она показывает, как читать и записывать данные диаграммы через потоки рабочей книги, использовать ячейки рабочей книги в качестве меток данных диаграммы, получать доступ к коллекциям листов и указывать тип источника данных для значений диаграммы.

Также рассматривается работа с внешними рабочими книгами в качестве источников данных диаграмм. В примерах демонстрируется, как создать и назначить внешнюю рабочую книгу, получить путь к внешней рабочей книге, связанной с диаграммой, и редактировать данные диаграммы, когда рабочая книга доступна.

Для ячеек рабочей книги, представляющих отсутствующие данные, см. [Control the Display of Empty Cells](/slides/ru/net/chart-series/) для различий между пустой ячейкой и нулём, а также сравнение режимов отображения в линейной диаграмме.

## **Включать данные из скрытых строк и столбцов**

Используйте [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) для управления тем, будет ли диаграмма строить данные из скрытых строк и столбцов листа. Установите `true`, чтобы строить только видимые ячейки, или `false`, чтобы включать как видимые, так и скрытые ячейки. Эта настройка управляет построением диаграммы; она не скрывает и не раскрывает строки или столбцы листа.

[Пример презентации](hidden-source-data.pptx) содержит столбчатую диаграмму как первую фигуру на первом слайде. Встроенный лист `Sheet1` содержит диапазон источника `A1:C4`. Строка 3 и столбец C скрыты, но их ячейки всё равно содержат значения.

| Строка листа | A: Месяц | B: Розница | C: Оптовая продажа (скрытый столбец) |
| --- | --- | --- | --- |
| 2 | Январь | 10 | 30 |
| 3 (hidden row) | Февраль | 40 | 60 |
| 4 | Март | 20 | 50 |

Получайте доступ к исходным ячейкам через [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) и читайте [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) для проверки их скрытого статуса. Это свойство только для чтения. В этом файле B2 видима, B3 принадлежит скрытой строке, а C2 — скрытому столбцу; пример выводит `False`, `True` и `True` соответственно.

Для этого примера обновите данные диаграммы после изменения настройки построения: сохраните встроенную рабочую книгу с помощью [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) и загрузите её заново с помощью [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/). При включении всех ячеек также используйте [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) для восстановления полного диапазона, включая скрытую категорию «Февраль». Просто изменение флага недостаточно для обновления кэшированных данных диаграммы и меток категории в этом образце.

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
            // Восстановить полный диапазон источника, включая скрытые категории.
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

Пример сохраняет две версии презентации: одну только с видимыми значениями розницы (10 и 20), другую со всеми шестью значениями. Ниже приведённые изображения получены из сохранённых презентаций после их повторного открытия; оба файла сохраняют свою настройку построения. Строка 3 и столбец C остаются скрытыми в обеих встроенных рабочих книгах.

| Только видимые ячейки (`true`) | Все ячейки (`false`) |
| --- | --- |
| ![Только видимые ячейки: значения розницы 10 и 20 для Января и Марта.](hidden_cells_True.png) | ![Все ячейки: значения розницы и оптовой продажи для Января, Февраля и Марта.](hidden_cells_False.png) |

Скрытая ячейка, содержащая значение, отличается от пустой ячейки. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) управляет тем, как отображаются отсутствующие значения; он не включает и не исключает скрытые исходные данные. См. [Control the Display of Empty Cells](/slides/ru/net/chart-series/#control-the-display-of-empty-cells) для примера.

## **Получить диапазон данных диаграммы**

Перед обновлением данных рабочей книги в существующей презентации проверьте диапазоны источника, чтобы определить, какие ячейки листа использует каждая диаграмма. Метод [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) возвращает текущий диапазон данных в виде формулы, квалифицированной листом, например `Sheet1!$A$1:$D$5`. Здесь `Sheet1` — имя листа, `!` разделяет его от диапазона ячеек, а `$A$1:$D$5` — ячейки от A1 до D5 включительно. Знаки `$` указывают абсолютные ссылки на строки и столбцы.

Метод читает текущий диапазон без изменения диаграммы или её рабочей книги. Если диаграмма не использует рабочую книгу как источник данных, он бросает [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Подробнее см. [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

В этом примере открывается презентация и проверяется наличие диаграмм на каждом слайде. Для каждой диаграммы выводится её имя и диапазон источника. Если диаграмма не использует рабочую книгу, выводится сообщение и переходим к следующей диаграмме.

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

Aspose.Slides for .NET предоставляет методы [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/), позволяющие читать и записывать рабочие книги данных диаграмм (содержащие данные, отредактированные с помощью Aspose.Cells). **Примечание**: данные диаграммы должны быть организованы одинаково или иметь схожую структуру с источником.

В этом примере используется презентация с диаграммой как первой фигурой на первом слайде. Встроенная рабочая книга читается в поток, очищаются существующие серии и категории, после чего та же рабочая книга записывается обратно. Изменения остаются в памяти; презентация не сохраняется.

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

Когда заменяется встроенная рабочая книга изменённой, диаграмма сохраняет свои исходные коллекции серий и категорий. Это несоответствие может привести к сбою [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) с ошибкой «index out of range». Очистите существующие серии и категории перед записью обновлённой рабочей книги обратно в диаграмму. В примере используется диаграмма, являющаяся первой фигурой на первом слайде. Комментарий отмечает место, где могла бы происходить правка рабочей книги; рабочий пример записывает оригинальную книгу обратно и проверяет макет в памяти.

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

    // Измените поток рабочей книги здесь, например, с помощью Aspose.Cells.

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

Очистка коллекций удаляет устаревшие ссылки перед записью рабочей книги. Перед использованием диаграммы восстановите необходимые сопоставления серий и категорий для обновлённой книги.

## **Установка пользовательских числовых форматов для ячеек рабочей книги**

Используйте [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) для управления отображением числовых значений в встроенной рабочей книге диаграммы. Например, в отчёте может потребоваться отображать коэффициент конверсии в виде процента с четырьмя знаками после запятой и коэффициент с пятью знаками после запятой. Оба значения должны оставаться числовыми, чтобы их можно было использовать в расчётах и построении диаграммы.

Числовой формат меняет только отображение, а не сохранённое значение. Формат `0.0000%` отображает `0.125` как `12.5000%`; он не заменяет сохранённое число на `12.5`. Аналогично, `0.00000` отображает `0.1234567` как `0.12346`, не изменяя сохранённое значение. Если пользовательский формат — пустая строка (`""`), используется [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/).

В примере создаётся столбчатая диаграмма и получает доступ к её ячейкам через [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). На листе 0 ячейка B2 содержит коэффициент конверсии, а C2 — коэффициент. Оба значения используются диаграммой. Пример также включает метки значений, привязанные к форматам источника.

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

Форматы ячеек рабочей книги независимы от форматов, задаваемых напрямую на осях или метках данных диаграммы. В данном примере каждая метка отображает значение своей исходной ячейки, поскольку [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) включён, а [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) равно `true`. После сохранения и повторного открытия презентации метки показывают `12.5000%` и `0.12346`, как показано ниже. Вертикальная ось использует собственный [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`, а [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) установлено в `false`.

Чтобы задать отдельный формат для метки данных, отключите привязку к источнику (`false`) и задайте её [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/). Это не изменит формат ячейки рабочей книги. Например, независимый формат метки `0.00` отобразит первое значение как `0.13`, в то время как B2 всё равно будет показывать `12.5000%`. См. [Chart Data Labels](/slides/ru/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) для прямого форматирования меток.

Изображение ниже получено из сохранённой презентации после её повторного открытия:

![Столбчатая диаграмма с метками, привязанными к источнику, показывающими 12.5000% и 0.12346, и независимым числовым форматом оси.](custom-cell-formats.png)

## **Установка ячейки рабочей книги в качестве метки данных диаграммы**

Текст из ячеек рабочей книги можно использовать в качестве меток данных диаграммы.

В примере добавляется пузырьковая диаграмма с данными по умолчанию на первый слайд существующей презентации. Для первой серии используются ячейки A10:A12 листа 0 в качестве первых трёх меток, включаются метки из ячеек, и презентация сохраняется.

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

Значения точек серии также могут быть сохранены напрямую как числовые литералы. См. [Set Series Values Using Numeric Literals](/slides/ru/net/chart-series/#set-series-values-using-numeric-literals) для полного примера, где они сохраняются и читаются. Тип источника точек отдельный от внутренней или внешней конфигурации рабочей книги диаграммы; использование числовых литералов само по себе не удаляет встроенную рабочую книгу.

В примере создаётся 3‑D столбчатая диаграмма с данными по умолчанию и задаются два имени серии, использующие разные источники данных. Первое имя задаётся строковым литералом; второе — ячейкой C1 листа 0. Перечисление [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) выбирает источник для каждого имени. Пример сохраняет презентацию с обновлёнными именами серий.

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

Aspose.Slides не поддерживает формат двоичной рабочей книги Excel (.xlsb), который может быть встроен в некоторые диаграммы. Можно использовать свойство [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) интерфейса [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) совместно с перечислением [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) для обнаружения неподдерживаемых форматов и пропуска соответствующих диаграмм. Пример проверяет фигуры первого слайда существующей презентации, пропускает не‑диаграммные фигуры и выводит диагностическое сообщение для каждой диаграммы с встроенной рабочей книгой .xlsb.

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

    // Читать или изменять поддерживаемые данные рабочей книги диаграммы здесь.
}
```

## **Внешняя рабочая книга**

Aspose.Slides поддерживает использование внешних рабочих книг в качестве источника данных для диаграмм.

### **Создание внешней рабочей книги**

Используйте [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) и [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) для экспорта встроенной рабочей книги диаграммы в файл и связывания диаграммы с этой внешней книгой.

В примере создаётся круговая диаграмма с данными по умолчанию и экспортируется её рабочая книга. Затем поток вывода закрывается перед назначением внешней рабочей книги в качестве источника данных диаграммы, после чего презентация сохраняется.

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

### **Установка внешней рабочей книги**

С помощью метода [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) можно назначить внешнюю рабочую книгу диаграмме в качестве источника данных. Этот метод также позволяет обновить путь к внешней книге (если она была перемещена).

Хотя редактировать данные в рабочих книгах, хранящихся в удалённых местах или ресурсах, нельзя, такие книги могут использоваться в качестве внешнего источника данных. Если указан относительный путь к внешней книге, он автоматически преобразуется в абсолютный.

В примере используется внешняя рабочая книга, лист `Sheet1` которой содержит имя серии в B1, имена категорий в A2:A4 и числовые значения в B2:B4. Пример создаёт круговую диаграмму, связывает книгу и использует [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) для сопоставления A1:B4 с одной серией и тремя категориями. Презентация сохраняется с привязанной диаграммой.

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

* Когда `updateChartData` = `false`, обновляется только путь к рабочей книге. Данные диаграммы не загружаются и не обновляются из целевой книги, поэтому книга может быть недоступна.
* Когда `updateChartData` = `true`, данные диаграммы обновляются из целевой книги.

В следующем примере задаётся заполнитель URL со значением `updateChartData` = `false`. Диаграмма сохраняет данные по умолчанию и презентация сохраняется без загрузки недоступной книги.

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

### **Получить путь к внешней рабочей книге диаграммы**

Чтобы определить, какая рабочая книга связана с диаграммой, проверьте, использует ли диаграмма внешний источник данных, и получите её путь.

В примере проверяется первая фигура первого слайда презентации с привязанной внешней книгой. Если это диаграмма, связанная с внешней книгой, выводится [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) в консоль. Затем сохраняется копия презентации.

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

Данные во внешних рабочих книгах можно редактировать так же, как и во внутренних. Если внешняя книга не может быть загружена, бросается исключение.

В примере используется диаграмма, первая фигура первого слайда, связанная с доступной внешней книгой. Значение первой точки первой серии устанавливается в 100, после чего презентация сохраняется. Редактирование значений ячеек может обновлять связанный внешний XLSX‑файл, поэтому при необходимости сохранения оригинала используйте копию.

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

Если диаграмма использует внешнюю рабочую книгу, которой нет или она недоступна, Aspose.Slides может восстановить рабочую книгу диаграммы из кэшированных данных презентации. Создайте [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), настройте его [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), и установите [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) в `true` перед открытием презентации.

Следующий пример C# восстанавливает данные рабочей книги для диаграммы, первая фигура первого слайда, ссылающейся на недоступную внешнюю книгу. Доступ к восстановленным данным осуществляется через [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) и [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Прочитать или изменить восстановленные данные рабочей книги здесь.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Если внешняя рабочая книга недоступна и восстановление отключено, Aspose.Slides бросает [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Включайте восстановление только тогда, когда использование кэшированных данных диаграммы является приемлемым вариантом, поскольку кэш может не содержать изменений, внесённых во внешнюю книгу после последнего обновления презентации.

## **FAQ**

**Можно ли определить, связана ли конкретная диаграмма с внешней или встроенной рабочей книгой?**

Да. Диаграмма имеет [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) и [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); если источник — внешняя книга, можно прочитать полный путь, чтобы убедиться, что используется внешний файл.

**Поддерживаются ли относительные пути к внешним рабочим книгам и как они хранятся?**

Да. При указании относительного пути он автоматически преобразуется в абсолютный. Презентация сохраняет абсолютный путь в файле PPTX, поэтому при перемещении книги может потребоваться обновить связь.

**Можно ли использовать рабочие книги, расположенные на сетевых ресурсах/общих папках?**

Да, такие книги могут быть использованы в качестве внешнего источника данных. Однако прямое редактирование удалённых книг из Aspose.Slides не поддерживается — их можно только использовать как источник.

**Перезаписывает ли Aspose.Slides внешний XLSX при сохранении презентации?**

Презентация хранит [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). Редактирование данных, привязанных к ячейкам, также может обновлять связанный локальный XLSX‑файл. При необходимости оставить оригинал без изменений используйте копию книги.

**Что делать, если внешний файл защищён паролем?**

Aspose.Slides не принимает пароль при связывании. Обычно снимают защиту заранее или готовят расшифрованную копию (например, с помощью [Aspose.Cells](https://reference.aspose.com/cells/net/)) и связывают её.

**Могут ли несколько диаграмм ссылаться на одну и ту же внешнюю рабочую книгу?**

Да. Каждая диаграмма хранит свою собственную связь. Если все они указывают на один и тот же файл, обновление этого файла отразится в каждой диаграмме при следующей загрузке данных.