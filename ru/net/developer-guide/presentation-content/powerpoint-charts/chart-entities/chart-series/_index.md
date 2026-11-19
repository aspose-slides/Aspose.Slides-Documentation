---
title: Управление данными серий диаграмм в презентациях на .NET
linktitle: Серии данных
type: docs
url: /ru/net/chart-series/
keywords:
- серии диаграмм
- перекрытие серии
- цвет серии
- цвет категории
- имя серии
- точка данных
- зазор серии
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной зазора и отрицательными значениями в презентациях с помощью C#."
---
## **Обзор**

Диаграмма может хранить построенные значения в ячейках рабочей книги или непосредственно в виде числовых литералов. [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) представляет один набор связанных значений, а каждый [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) представляет точку в этом наборе. Объекты [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) предоставляют метки или значения группировки, общие для серии. В диаграммах, созданных с данными по умолчанию, имена серий, категории и значения точек используют объекты [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) из рабочей книги диаграммы.

Для типичной категориальной диаграммы рабочая книга по умолчанию использует строку 0 для имен серий, столбец 0 для имен категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/), нулевые. Такая раскладка удобна, когда вы создаёте диаграмму с данными по умолчанию, но не следует полагать, что каждый существующий график использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три различных уровня:

- Настройки уровня серии, такие как [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), задают внешний вид по умолчанию для всех точек в одной серии.  
- Настройки отдельной точки, такие как [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), переопределяют внешний вид серии для одной точки.  
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/), когда нужно задать такие параметры, как перекрытие или ширина зазора.

Если явное заполнение точки или серии не задано, стиль диаграммы и тема определяют автоматический внешний вид. Когда присутствует как форматирование серии, так и точки, форматирование точки имеет приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

Для сгруппированной цилиндрической диаграммы посмотрите, как [changing the 3D series type or bar shape](/slides/ru/net/3d-chart/#change-the-3d-series-type-and-bar-shape) влияет на первую серию.

## **Задание значений серии с использованием числовых литералов**

Используйте числовые литералы, когда значения серии поступают из данных приложения или вычислений и не требуют ссылок на ячейки листа. Установите [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) в [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) перед назначением каждого [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) через [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

Настройка коллекции определяет тип источника для всех значений точек в этой серии. Каждый [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) сообщает выбранный тип; изменить его можно через настройку коллекции. При работе с `Worksheet` используйте [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) для доступа к ссылке на ячейку. При работе с `DoubleLiterals` используйте `AsLiteralDouble` для прямого чтения или записи числа.

В следующем примере создаётся столбчатая диаграмма с сериями и категориями по умолчанию, затем вычисленные значения 10, 20 и т.д. присваиваются существующим точкам первой серии. Пример сохраняет презентацию, открывает её заново и выводит сохранённые значения.

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

Тип источника значения точки отличается от [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), который определяет внутреннюю или внешнюю конфигурацию рабочей книги диаграммы. Использование числовых литералов само по себе не удаляет встроенную рабочую книгу. В данном примере рабочая книга остаётся доступной для меток категорий, имён серий и остальных серий. См. [Chart Workbook](/slides/ru/net/chart-workbook/) для управления рабочей книгой.

Для точечных и пузырьковых диаграмм задайте [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) и [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) чтобы выбрать источники для [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) и [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Пузырьковые диаграммы также используют [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) для [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). Установите каждый применимый источник в `DoubleLiterals` перед присвоением чисел через свойство `AsLiteralDouble`.

## **Задание перекрытия серии диаграммы**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) показывает, насколько столбцы или бары перекрываются в 2D‑диаграмме, от ‑100 % до 100 %. Это только чтение проекции настройки в родительской группе серий. Установите [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) для обновления всех совместимых серий в этой группе. Параметр применяется к типам диаграмм, отображающих сгруппированные столбцы или бары; он не влияет на несвязанные группы серий в комбинированных диаграммах.

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

// Новая диаграмма содержит примерные серии, категории и значения.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

Результат:

![Перекрытие серии](series_overlap.png)

## **Изменение цвета заливки серии**

Используйте [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) для задания заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) переопределяет заливку серии для этой точки.

В следующем примере применяется сплошная синяя заливка к первой серии:

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

## **Изменение имени серии**

Имя серии хранится в рабочей книге диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для сгруппированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже использованную в [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/). Такой подход избавляет от предположений о конкретных строках и столбцах в существующей диаграмме:

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

![Имя серии](series_name.png)

### **Создание серии с именем из нескольких ячеек**

Составное имя серии полезно, когда название продукта и период отчёта хранятся в отдельных ячейках рабочей книги. Например, можно объединить `Product A` в B1 и `2026` в C1 в одно имя серии, оставив обе части привязанными к их исходным ячейкам.

Для этого используйте [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) для получения диапазона имён, затем передайте эту коллекцию в [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). Параметр `skipHiddenCells` определяет, включать ли скрытые ячейки: `true` — исключает, `false` — включает. В примере использовано `false`, чтобы включить каждую ячейку диапазона имён.

В следующем примере создаётся презентация с одной серией и двумя точками данных. Диапазон B1:C1 обеспечивает только имя серии; A2:A3 — метки категорий, B2:B3 — числовые значения.

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

В результате имя серии будет `Product A 2026` (пробел между значениями ячеек). Легенда отображает его как одну запись для обеих колонок. Ниже изображение, полученное из сохранённой презентации:

![Гистограмма с данными North и South и составным именем серии Product A 2026 в легенде](composite_series_name.png)

## **Получение автоматического цвета заливки серии**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии явно не определена. Вызов метода лишь читает вычисленный цвет; он не назначает новую заливку.

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

## **Установка инвертированного цвета заливки для серии диаграммы**

Для серий баров, столбцов и пузырьков [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) позволяет отображать отрицательные значения другим цветом. Задайте обычную заливку серии сплошной, включите инверсию и укажите цвет отрицательного значения через [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Отрицательные числа в рабочей книге остаются без изменений; меняется только их отображаемый цвет.

В следующем примере заменяются данные диаграммы на одну серию. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

Инверсию можно включить для отдельной точки через [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

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

## **Очистка конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке в рабочей книге значение `null`. Для столбчатой диаграммы значение доступно через [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). Точка остаётся на той же позиции категории, но диаграмма рассматривает её значение как пустое согласно настройкам отображения пустых значений.

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

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые — ещё и ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое нужно удалить. Не вызывайте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) если хотите оставить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, — отдельный случай от действительно пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги обозначает отсутствие данных; ячейка, содержащая `0`, — известное числовое значение. Установите [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) в `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки пустой ячейки.

Используйте [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она меняет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

В следующем самостоятельном примере создаётся линейная диаграмма с одной серией, очищается значение для третьего дня и сохраняется три версии диаграммы, по одной для каждого режима. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 содержит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

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

// Оставьте день 3 действительно пустым, при этом сохранив его категорию и точку данных.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Каждый выходной файл сохраняет режим, назначенный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте нужный режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. Третий день пуст в рабочей книге во всех случаях:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию на День 3, Zero обрезает линию до нуля, а Span соединяет День 2 с Днём 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. На линейной диаграмме легко сравнить все три режима. У столбчатых и баровых диаграмм нет линии, связывающей пропущенную категорию, поэтому `Span` не может создать соединительный сегмент, показанный выше; пропущенный столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте три разных результата для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установка ширины зазора между рядами серии**

Ширина зазора — это расстояние между соседними кластерами баров или столбцов, выраженное в проценте от ширины самого бара/столбца. Как и перекрытие, она относится к родительской группе серий, а не к отдельной серии. Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

В следующем примере изменяется ширина зазора и сохраняется только итоговая презентация:

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

![Ширина зазора](gap_width.png)

## **Показать или скрыть линии серии**

Линии серии визуально соединяют связанные части диаграммы. Используйте [IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/) для отображения или скрытия их в поддерживаемых сложных баровых и PieOfPie‑диаграммах. В двумерных сложных баровых и столбчатых диаграммах они соединяют соответствующие границы стеков по категориям. В Pie of Pie и Bar of Pie диаграммах они соединяют основную часть с вторичной. Эта настройка не является универсальным соединителем для других типов диаграмм.

Доступ к группе осуществляется через [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). Настройка применяется ко всем сериям в этой группе. [IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/) только для чтения и отражает настройку родительской группы; измените свойство группы, чтобы обновить её.

В следующем примере создаётся одна диаграмма [PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) с данными по умолчанию. Диаграмма сохраняется дважды: со включёнными линиями серии и без, получая две презентации для сравнения.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| Линии серии включены | Линии серии выключены |
| --- | --- |
| ![Диаграмма Pie of Pie с включенными линиями серии](series_lines_enabled.png) | ![Диаграмма Pie of Pie с выключенными линиями серии](series_lines_disabled.png) |
| Две линии соединяют основной пирог со вторичным. | Оба пирога видны, но соединительные линии скрыты. |

Линии серии отличаются от выносных линий подписи данных, которые соединяют подписи с их точками, от сеток, отмечающих интервалы по осям, и от линий в линейных диаграммах, представляющих сами данные. Эта настройка не управляет перечисленными элементами.

## **FAQ**

**Какие типы диаграмм поддерживают данные серии?**

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не все имеют одинаковую структуру значений или параметры. Например, категориальные диаграммы используют категории и значения, точечные — X и Y, а пузырьковые — добавляют размер пузыря. Используйте метод создания точек, соответствующий типу серии. Такие параметры, как перекрытие и ширина зазора, применимы только к совместимым баровым или столбцовым группам.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения на уровне группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит каждую серию в диаграмме.

**Создана ли новая диаграмма с данными по умолчанию?**

Да. По умолчанию [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) создаёт примерные серии, категории и значения. Вы можете изменить эти ячейки или очистить обе коллекции (серий и категорий) перед добавлением полностью пользовательского набора данных. Перегрузка также может создать диаграмму без данных по умолчанию.

**Как диаграмма связывается с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). Изменение ссылочной ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных поддерживайте согласованность строк категорий и строк значений серий, чтобы каждая точка строилась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Установите соответствующую ячейку значения в `null`, чтобы сохранить позицию категории точки как пустую точку. Используйте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) только когда нужно удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались выровненными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). Поддерживаемые диаграммы могут отображать пустоты как пробелы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел [Управление отображением пустых ячеек](#control-the-display-of-empty-cells) для полного примера и визуального сравнения.

**Как форматируются отрицательные значения?**

Для поддерживаемых баровых, столбцовых и пузырьковых серий включите [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) и задайте [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Для отдельной точки поведение можно переопределить через [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Эти свойства влияют только на форматирование, а не на хранимые численные значения.

**Какой формат выигрывает, когда серия и точка отформатированы?**

Явное форматирование отдельной точки имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если он не задан, автоматический стиль и тему диаграммы. Параметры группы, такие как перекрытие и ширина зазора, управляют расположением и не переопределяют форматирование точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения задают размер файла презентации, доступная память, время рендеринга и читаемость диаграммы.

**Что менять, если столбцы слишком близко или слишком далеко друг от друга?**

Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) в нужной родительской группе серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе.