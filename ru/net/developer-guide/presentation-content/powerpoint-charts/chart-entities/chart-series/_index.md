---
title: Управление сериями данных диаграмм в презентациях на .NET
linktitle: Серии данных
type: docs
url: /ru/net/chart-series/
keywords:
- серии диаграмм
- перекрытие серий
- цвет серии
- цвет категории
- имя серии
- точка данных
- промежуток серии
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять сериями диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с C#."
---
## **Обзор**

Диаграмма хранит построенные данные в рабочей книге данных диаграммы. [IChartSeries](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/) представляет один набор связанных значений, а каждый [IChartDataPoint](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [IChartCategory](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartcategory/) предоставляют метки или значения группировки, общие для серии. Поэтому имя серии, категории и значения точек связаны с объектами [IChartDataCell](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы категории рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/getcell/), нумеруются с нуля. Такая раскладка полезна при создании диаграммы с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует её. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Установки диаграммы имеют три разных уровня:

- Настройки уровня серии, такие как [IChartSeries.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/format/), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки данных, такие как [IChartDataPoint.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/format/), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, входящим в один [IChartSeriesGroup](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/parentseriesgroup/), когда необходимо задать параметры, такие как перекрытие или ширина промежутка.

Когда явная заливка точки или серии не задана, стиль и тема диаграммы определяют автоматический внешний вид. Если заданы как параметры серии, так и точки, параметры заливки точки имеют приоритет для этой точки.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Установить перекрытие серии диаграммы**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/overlap/) сообщает, насколько столбцы или бары перекрываются в 2D‑диаграмме, в диапазоне от ‑100 до 100 процентов. Это только чтение проекции настройки группы родительских серий. Установите [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/overlap/), чтобы обновить каждую совместимую серию в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные бары или столбцы; она не влияет на несвязанные группы серий в комбинированной диаграмме.

Следующий пример задаёт перекрытие для группы, содержащей первую серию:

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

![Перекрытие серий](series_overlap.png)

## **Изменить цвет заливки серии**

Используйте [IChartSeries.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/format/) для установки заливки по умолчанию для всей серии. Если у точки уже задана явная заливка, её настройка [IChartDataPoint.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/format/) переопределяет заливку серии для этой точки.

Следующий пример задаёт сплошную синюю заливку первой серии:

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

Название серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию для группированной столбчатой диаграммы ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже используемую [IChartSeries.Name](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/name/). Такой подход избегает предположений о конкретных строках и столбцах в существующей диаграмме:

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

## **Получить автоматический цвет заливки серии**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Это цвет, используемый, когда заливка серии не задана явно. Вызов метода только читает вычисленный цвет; он не назначает новую заливку.

Следующий пример выводит автоматический цвет каждой серии по умолчанию:

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

Для серий типа бар, столбец и пузырь [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertifnegative/) позволяет отображать отрицательные значения другим цветом. Задайте обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Отрицательные числа остаются без изменений в рабочей книге; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — названия категорий, столбец 1 — значения:

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

Вы можете включить инверсию для одной точки через [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

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

## **Очистить определённое значение точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её ячейке в рабочей книге значение `null`. Для столбчатой диаграммы построенное значение доступно через [IChartDataPoint.YValue](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/yvalue/). Точка остаётся на той же позиции категории, но диаграмма рассматривает её значение как пустое в соответствии с настройками отображения пустых значений.

Следующий пример очищает только вторую точку в первой серии:

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

Точечные диаграммы используют отдельные ячейки X и Y, а пузырьковые — ещё ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое хотите удалить. Не вызывайте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapointcollection/clear/), если хотите сохранить остальные точки, так как этот метод удаляет все точки из коллекции.

## **Управление отображением пустых ячеек**

Скрытые ячейки, содержащие значения, — отдельный случай от пустых ячеек. Чтобы включать или исключать данные из скрытых строк и столбцов листа, см. [Include Data from Hidden Rows and Columns](/slides/ru/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Пустая ячейка рабочей книги представляет отсутствующие данные; ячейка, содержащая `0`, представляет известное числовое значение. Установите [IChartDataCell.Value](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/value/) в `null`, чтобы сделать ячейку пустой. Числовой ноль остаётся нулём независимо от настройки отображения пустых ячеек.

Используйте [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/displayblanksas/) для выбора способа отображения пустых ячеек. Эта настройка применяется ко всей диаграмме. Она изменяет способ построения пустот, не заполняя пустую ячейку нулём или интерполированным значением.

Следующий автономный пример создаёт линейную диаграмму с одной серией, очищает значение для Дня 3 и сохраняет одну и ту же диаграмму в каждом режиме. Входной файл не требуется. [IChartDataWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/) использует лист 0, столбец 0 для меток категорий и столбец 1 для значений; строка 0 хранит имя серии. Итоговые данные: `10, 20, empty, 30, 40`.

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

// Оставить третий день действительно пустым, сохранив его категорию и точку данных.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

Каждый выходной файл сохраняет режим, заданный перед сохранением: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` и `empty_cells_Span.pptx`. Чтобы сохранить только одну версию, задайте желаемый режим и сохраните презентацию один раз вместо перебора режимов.

Сравнение ниже показывает одинаковые данные во всех трёх файлах. День 3 пуст в рабочей книге в каждом случае:

![Линейные диаграммы с одинаковыми данными: Gap разрывает линию в День 3, Zero опускает линию до нуля, а Span соединяет День 2 с Днём 4.](display_blanks_as.png)

Видимый эффект зависит от типа диаграммы. Линейная диаграмма позволяет легко сравнивать все три режима. Бар и столбчатые диаграммы не имеют линии для соединения пропущенной категории, поэтому `Span` не может создать соединительный сегмент, показанный выше; отсутствующий столбец и столбец нулевой высоты могут выглядеть одинаково. Аналогично, точечная диаграмма только с маркерами не имеет соединительной линии. Не ожидайте трёх различимых результатов для каждого типа диаграммы; проверьте вывод для используемого типа.

## **Установить ширину промежутка серии**

Ширина промежутка — это пространство между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она относится к группе родительских серий, а не к отдельной серии. Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) один раз для группы. Большее значение создаёт больше пространства между кластерами; меньшее — делает их плотнее.

Следующий пример изменяет ширину промежутка и сохраняет только окончательную презентацию:

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

**Which chart types support data series?**  
Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, категорические диаграммы используют категории и значения, точечные — значения X и Y, а пузырьковые добавляют размеры пузыря. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**What is a chart series group?**  
[IChartSeriesGroup](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/) содержит совместимые серии, которые используют настройки уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы через одну серию не обязательно изменит все серии диаграммы.

**Does a newly created chart contain default data?**  
Да. По умолчанию [IShapeCollection.AddChart](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addchart/) создаёт примерные серии, категории и значения. Вы можете отредактировать эти ячейки или очистить обе коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существуют перегрузки, позволяющие создать диаграмму без данных по умолчанию.

**How are chart objects connected to workbook cells?**  
Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/). Изменение ссылки ячейки обновляет соответствующий элемент диаграммы. При построении пользовательских данных поддерживайте выравнивание строк категорий и строк значений серий, чтобы каждая точка отображалась под нужной категорией.

**How do I clear one point instead of the whole series?**  
Установите соответствующую ячейку значения в `null`, чтобы сохранить позицию категории точки как пустой. Используйте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapointcollection/clear/) только тогда, когда действительно хотите удалить все точки из серии. Если вы также удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**How are empty points displayed?**  
Результат зависит от типа диаграммы и [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/displayblanksas/). Поддерживаемые диаграммы могут показывать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации. См. раздел **Управление отображением пустых ячеек** для полного примера и визуального сравнения.

**How are negative values formatted?**  
Для поддерживаемых серий баров, столбцов и пузырей включите [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertifnegative/) и задайте [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Для отдельной точки можно переопределить поведение с помощью [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Эти свойства влияют только на форматирование, а не на хранимые числовые значения.

**Which formatting wins when both a series and a point are formatted?**  
Явное форматирование отдельной точки имеет приоритет для этой точки. Остальные точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Свойства группы, такие как перекрытие и ширина промежутка, управляют расположением и не переопределяют форматирование точек.

**Is there a limit to how many series a chart can contain?**  
Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения определяются размером файла презентации, доступной памятью, временем рендеринга и удобочитаемостью диаграммы.

**What should I change when columns are too close together or too far apart?**  
Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) для соответствующей группы родительских серий. Увеличьте значение, чтобы увеличить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе.