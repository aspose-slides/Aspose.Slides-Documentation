---
title: Управление сериями данных диаграмм в презентациях на .NET
linktitle: Серии данных
type: docs
url: /ru/net/chart-series/
keywords:
- серия диаграммы
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток между сериями
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с помощью C#."
---
## **Обзор**

Диаграмма может хранить отображаемые значения в ячейках рабочей книги или непосредственно как числовые литералы. Объект [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) представляет один набор связанных значений, а каждый [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) представляет точку в этом наборе. Объекты [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) предоставляют метки или группирующие значения, общие для серий. В диаграммах, созданных с данными по умолчанию, имена серий, категории и значения точек используют объекты [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) из рабочей книги диаграммы.

Для типичной диаграммы с категориями рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/), нумеруются с 0. Такое расположение удобно, когда вы создаёте диаграмму с данными по умолчанию, но не следует полагать, что каждый существующий график использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем менять значения в рабочей книге.

Настройки диаграммы имеют три отдельных уровня:

- Настройки уровня серии, такие как [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), задают внешний вид всех точек в одной серии.
- Настройки отдельной точки, такие как [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), переопределяют внешний вид серии для конкретной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/), когда необходимо задать такие параметры, как перекрытие или ширина промежутка.

Если явным образом не задано заполнение точки или серии, стиль и тема диаграммы определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точек, приоритет имеет форматирование точки.

![Серия диаграммы PowerPoint](chart-series-powerpoint.png)

## **Установить значения серии с использованием числовых литералов**

Используйте числовые литералы, когда значения серии получены из данных приложения или вычислений и не требуют ссылок на ячейки листа. Установите [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) в [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) до присвоения каждой точке её [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) через [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

Настройка коллекции управляет типом источника всех значений точек в данной серии. [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) каждой точки показывает выбранный тип; изменить его можно через настройку коллекции. При работе с `Worksheet` используйте [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) для доступа к ссылочной ячейке. При `DoubleLiterals` используйте `AsLiteralDouble` для прямого чтения или записи числа.

В следующем примере создаётся столбчатая диаграмма с сериями и категориями по умолчанию, после чего вычисленные значения 10, 20 и т.д. присваиваются существующим точкам первой серии. Затем презентация сохраняется, открывается заново и выводит сохранённые значения.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

Тип источника значения точки отделён от [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), который указывает внутреннюю или внешнюю конфигурацию рабочей книги диаграммы. Использование числовых литералов само по себе не удаляет внедрённую рабочую книгу. В этом примере рабочая книга остаётся доступной для меток категорий, имён серий и остальных серий. Смотрите [Chart Workbook](/slides/ru/net/chart-workbook/) для управления рабочей книгой.

Для точечных и пузырьковых диаграмм задайте [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) и [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) для выбора источников [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) и [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Для пузырьковой диаграммы также используйте [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) для [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Установите каждый соответствующий источник в `DoubleLiterals` перед присвоением чисел через свойство `AsLiteralDouble`.

## **Установить перекрытие серий диаграммы**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) показывает, насколько столбцы или бары перекрываются в 2‑D диаграмме, от ‑100 % до 100 %. Это только чтение проекции настройки группы родительских серий. Чтобы обновить все совместимые серии в группе, задайте [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/). Этот параметр применяется к типам диаграмм, отображающим сгруппированные столбцы или бары; он не влияет на несвязанные группы серий в комбинированных диаграммах.

В следующем примере задаётся перекрытие для группы, содержащей первую серию:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// Новая диаграмма содержит образцы серий, категорий и значений.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Результат:

![Перекрытие серий](series_overlap.png)

## **Изменить цвет заливки серии**

Используйте [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) для установки заливки по умолчанию для всей серии. Если у точки уже задано явное заполнение, её настройка [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) переопределяет заливку серии для этой точки.

В следующем примере к первой серии применяется сплошная синяя заливка:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

Результат:

![Цвет серии](series_color.png)

## **Изменить название серии**

Название серии хранится в рабочей книге диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. В следующем примере именованные константы делают эту структуру явной:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Вы также можете обновить ячейку, уже связанную с [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Такой подход позволяет не полагаться на конкретные строки и столбцы в существующей диаграмме:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

Результат:

![Название серии](series_name.png)

### **Создать серию с именем из нескольких ячеек**

Составное имя серии удобно, когда название продукта и период отчёта хранятся в разных ячейках рабочей книги. Например, можно объединить `Product A` в B1 и `2026` в C1 в одно имя серии, сохраняя связь обеих частей с их исходными ячейками.

Вызовите [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) для получения диапазона имён, затем передайте эту коллекцию в [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Параметр `skipHiddenCells` определяет, включать ли скрытые ячейки: `true` — исключает, `false` — включает. В примере используется `false`, чтобы включить все ячейки диапазона имён.

В следующем примере создаётся презентация с одной серией и двумя точками данных. Ячейки B1:C1 содержат только имя серии; A2:A3 — метки категорий; B2:B3 — числовые значения.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Эти две ячейки задают имя серии.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Отдельные ячейки задают категории и числовые точки данных.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

Полученное имя серии — `Product A 2026`, между двумя значениями ячеек вставлен пробел. Легенда отображает его как одну запись для обоих столбцов. Ниже изображение, полученное из сохранённой презентации:

![Столбчатая диаграмма с названиями North и South и составным именем серии Product A 2026 в легенде](composite_series_name.png)

## **Получить автоматический цвет заливки серии**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) возвращает цвет, вычисленный на основе индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии явно не задана. Вызов метода только читает вычисленный цвет; он не задаёт новую заливку.

В следующем примере выводится автоматический цвет каждой серии по умолчанию:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

Пример вывода для стиля диаграммы по умолчанию:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Точные цвета зависят от стиля и темы диаграммы.

## **Установить инвертированный цвет заливки для серии диаграммы**

Для серий типа бар, столбец и пузырек свойство [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) позволяет отображать отрицательные значения другим цветом. Установите обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Отрицательные числа в рабочей книге остаются без изменений; меняется только их отображаемый цвет.

В следующем примере заменяется стандартный набор данных диаграммы одной серией. Строка 0 листа содержит имя серии, столбец 0 — названия категорий, столбец 1 — значения:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

Результат:

![Инвертированный сплошной цвет заливки](inverted_solid_fill_color.png)

Вы также можете включить инверсию для одной точки через [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки, которой также присвоено отрицательное значение, чтобы эффект был виден:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **Очистить конкретное значение точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейку рабочей книги значением `null`. Для столбчатой диаграммы отображаемое значение доступно через [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Точка сохраняет своё положение в категории, но диаграмма рассматривает её значение как пустое согласно настройкам обработки пустых значений.

В следующем примере очищается только вторая точка первой серии:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые — также ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы хотите удалить. Не вызывайте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) если хотите оставить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, отличаются от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствие данных; ячейка, содержащая `0`, — известное числовое значение. Установите [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) в `null`, чтобы сделать ячейку пустой. Число 0 остаётся нулём независимо от настройки пустой ячейки.

Используйте [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

В следующем самостоятельном примере создаётся линейная диаграмма с одной серией, очищается значение для Дня 3 и сохраняется та же диаграмма в каждом из режимов. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 — имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Оставить день 3 действительно пустым, при этом сохранив его категорию и точку данных.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Каждый выходной файл сохраняет выбранный режим перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо итерации по режимам.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию в Дне 3, Zero опускает линию до нуля, а Span соединяет День 2 с Днем 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. На линейных диаграммах все три режима легко сравнить. У бар‑ и столбчатых диаграмм нет линии, соединяющей отсутствующую категорию, поэтому `Span` не может создать показанный выше соединительный сегмент; пустой столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте трёх разных результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установить ширину промежутка между сериями**

Ширина промежутка — это пространство между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она относится к группе родительских серий, а не к отдельной серии. Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) один раз для группы. Большое значение создаёт больший промежуток между кластерами; меньшее — уплотняет их.

В следующем примере меняется ширина промежутка и сохраняется только итоговая презентация:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

Результат:

![Ширина промежутка](gap_width.png)

## **FAQ**

**Какие типы диаграмм поддерживают серии данных?**

Все типы, представленные перечислением [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы категорий используют категории и значения, точечные — X и Y, а пузырьковые — дополнительно размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) содержит совместимые серии, которые используют общие настройки построения. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы через одну серию не обязательно изменит все серии в диаграмме.

**Создаёт ли новая диаграмма данные по умолчанию?**

Да. По умолчанию [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) создаёт образцы серий, категорий и значений. Вы можете изменить эти ячейки или очистить обе коллекции перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как объекты диаграммы связаны с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Изменение связанной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных сохраняйте согласованность строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `null`, чтобы точка сохраняла своё положение в категории как пустая. Используйте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) только когда нужно удалить все точки из серии.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Поддерживаемые типы могут отображать пустоты как разрывы, как нули или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. [Control the Display of Empty Cells](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых бар‑, столбцовых и пузырьковых серий включите [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) и задайте [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Для отдельной точки можно переопределить поведение через [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Эти свойства влияют только на оформление, а не на сохранённые числовые значения.

**Какой формат имеет приоритет, если и серия, и точка отформатированы?**

Явное форматирование точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если он не определён, автоматический стиль и тему диаграммы. Групповые свойства, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределениями формата точек.

**Существует ли ограничение количества серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения формата файла, доступная память, время рендеринга и читаемость диаграммы определяют практический предел.

**Что менять, если столбцы слишком близко или слишком далеко друг от друга?**

Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) в соответствующей группе родительских серий. Увеличьте значение, чтобы расширить промежуток между кластерами, или уменьшите, чтобы сблизить их.