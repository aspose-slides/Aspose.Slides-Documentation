---
title: Управление рядами данных диаграмм в презентациях на .NET
linktitle: Ряды данных
type: docs
url: /ru/net/chart-series/
keywords:
- ряды диаграмм
- перекрытие рядов
- цвет ряда
- цвет категории
- имя ряда
- точка данных
- промежуток между рядами
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять рядами диаграмм, точками данных, ячейками рабочей книги, форматированием, перекрытием, шириной промежутка и отрицательными значениями в презентациях с C#."
---
## **Обзор**

Диаграмма сохраняет отображаемые данные в рабочей книге данных диаграммы. Объект [IChartSeries](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/) представляет один набор связанных значений, и каждый объект [IChartDataPoint](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/) в серии ссылается на одну или несколько ячеек рабочей книги. Объекты [IChartCategory](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartcategory/) предоставляют метки или значения группировки, общие для серии. Поэтому имя серии, категории и значения точек связаны с объектами [IChartDataCell](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatacell/), а не хранятся только как отображаемый текст.

Для типичной диаграммы с категориями рабочая книга по умолчанию использует строку 0 для имён серий, столбец 0 для имён категорий и остальные ячейки для значений серий. Индексы листа, строки и столбца, передаваемые в [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/getcell/), начинаются с 0. Этот макет удобен, когда вы создаёте диаграмму с данными по умолчанию, но не следует предполагать, что каждая существующая диаграмма использует его. Для загруженной презентации проверьте ячейки, на которые ссылаются серии, категории и точки данных, прежде чем изменять значения в рабочей книге.

Настройки диаграммы имеют три различных области действия:

- Настройки уровня серии, такие как [IChartSeries.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/format/), задают внешний вид по умолчанию для всех точек в одной серии.
- Настройки отдельной точки данных, такие как [IChartDataPoint.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/format/), переопределяют внешний вид серии для одной точки.
- Настройки группы применяются к совместимым сериям, принадлежащим одному [IChartSeriesGroup](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/). Доступ к группе осуществляется через [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/parentseriesgroup/), когда необходимо задать параметры, такие как перекрытие или ширина промежутка.

Когда явное заполнение точки или серии не задано, стиль и тема диаграммы определяют автоматический внешний вид. Если присутствуют как настройки серии, так и точки, оформление точки имеет приоритет для этой точки.

![серия диаграммы PowerPoint](chart-series-powerpoint.png)

## **Установка перекрытия серии диаграммы**

[IChartSeries.Overlap](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/overlap/) сообщает, насколько столбцы или бары перекрываются в 2D‑диаграмме, в диапазоне от ‑100 до 100 процентов. Это только проекция настройки группы родительской серии в режиме только для чтения. Установите [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/overlap/), чтобы обновить каждую совместимую серию в этой группе. Эта опция применяется к типам диаграмм, отображающим сгруппированные столбцы или бары; она не влияет на несвязанные группы серий в комбинированной диаграмме.

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

![Перекрытие серии](series_overlap.png)

## **Изменение цвета заливки серии**

Используйте [IChartSeries.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/format/) для установки заливки по умолчанию для всей серии. Если для точки уже задана явная заливка, её настройка [IChartDataPoint.Format](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/format/) переопределяет заливку серии для этой точки.

Следующий пример применяет сплошную синюю заливку к первой серии:

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

Имя серии хранится в рабочей книге данных диаграммы и обычно отображается в легенде. В рабочей книге по умолчанию, созданной для диаграммы со сгруппированными столбцами, ячейка B1 находится в строке 0, столбце 1 и содержит имя первой серии. Именованные константы в следующем примере делают эту структуру явной:

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

Вы также можете обновить ячейку, уже указанную в [IChartSeries.Name](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/name/). Такой подход избавляет от предположений о конкретных строках и столбцах в существующей диаграмме:

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

## **Получение автоматического цвета заливки серии**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) возвращает цвет, вычисленный из индекса серии и стиля диаграммы. Этот цвет используется, когда заливка серии явно не задана. Вызов метода только читает вычисленный цвет; он не назначает новую заливку.

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

## **Установка обратного цвета заливки для серии диаграммы**

Для серий типа бар, столбец и пузырь [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertifnegative/) может отображать отрицательные значения другим цветом заливки. Установите обычную заливку серии как сплошную, включите инверсию и задайте цвет отрицательного значения через [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Отрицательные числа остаются без изменений в рабочей книге; меняется только их цвет отображения.

Следующий пример заменяет данные диаграммы по умолчанию одной серией. Строка 0 листа содержит имя серии, столбец 0 — имена категорий, столбец 1 — значения:

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

![Обратный сплошной цвет заливки](inverted_solid_fill_color.png)

Вы можете включить инверсию для отдельной точки через [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). В следующем примере инверсия отключена для серии и включена только для выбранной точки. Точке также присвоено отрицательное значение, чтобы эффект был виден:

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

## **Удаление конкретного значения точки данных**

Чтобы сделать одну точку пустой, не удаляя остальные, задайте её поддерживающую ячейку рабочей книги значением `null`. Для столбчатой диаграммы отображаемое значение доступно через [IChartDataPoint.YValue](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/yvalue/). Точка данных остаётся на той же позиции категории, но диаграмма рассматривает её значение как пустое согласно настройкам отображения пустых значений.

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

Диаграммы разброса используют отдельные ячейки X и Y, а диаграммы пузырей — также ячейку размера. Очищайте только ту ячейку, которая представляет значение, которое вы собираетесь удалить. Не вызывайте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapointcollection/clear/), если хотите сохранить остальные точки, поскольку этот метод удаляет все точки из коллекции.

## **Установка ширины промежутка между сериями**

Ширина промежутка — это пространство между соседними кластерами баров или столбцов, выраженное в процентах от ширины бара или столбца. Как и перекрытие, она относится к группе родительской серии, а не к отдельной серии. Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) один раз для группы. Большое значение создаёт больше пространства между кластерами; меньшее значение делает их плотнее.

Следующий пример меняет ширину промежутка и сохраняет только окончательную презентацию:

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

Все типы диаграмм, представленные перечислением [ChartType](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/charttype/), используют данные диаграммы, но их серии не всегда имеют одинаковую структуру значений или настройки. Например, диаграммы с категориями используют категории и значения, диаграммы разброса — X и Y, а пузырьковые диаграммы добавляют размеры пузырей. Используйте метод создания точек данных, соответствующий типу серии. Параметры, такие как перекрытие и ширина промежутка, применимы только к совместимым группам баров или столбцов.

**Что такое группа серий диаграммы?**

[IChartSeriesGroup](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/) содержит совместимые серии, которые разделяют настройки построения уровня группы. Комбинированная диаграмма может содержать более одной группы, поэтому изменение группы, полученной через одну серию, не обязательно изменит каждую серию в диаграмме.

**Создаётся ли в новой диаграмме набор данных по умолчанию?**

Да. По умолчанию [IShapeCollection.AddChart](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addchart/) создаёт образцы серий, категорий и значений. Вы можете отредактировать эти ячейки или очистить коллекции серий и категорий перед добавлением полностью пользовательского набора данных. Существует перегрузка, позволяющая создать диаграмму без данных по умолчанию.

**Как диаграммы связываются с ячейками рабочей книги?**

Имена серий, метки категорий и значения точек данных ссылаются на ячейки в [IChartDataWorkbook](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdataworkbook/). Изменение ячейки, на которую ссылаются, обновляет соответствующий элемент диаграммы. При построении пользовательских данных следите за тем, чтобы строки категорий и строки значений серий были согласованы, чтобы каждая точка отображалась под нужной категорией.

**Как очистить одну точку, а не всю серию?**

Задайте соответствующую ячейку значения `null`, чтобы точка сохранила свою позицию категории как пустую. Используйте [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapointcollection/clear/) только тогда, когда хотите удалить все точки из этой серии. Если одновременно удаляете категории, обновите каждую серию, чтобы их значения оставались согласованными с коллекцией категорий.

**Как отображаются пустые точки?**

Результат зависит от типа диаграммы и [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/displayblanksas/). Поддерживаемые диаграммы могут отображать пустоты как разрывы, как нулевые значения или соединяя соседние точки. Выберите настройку, соответствующую смыслу отсутствующих данных в вашей презентации.

**Как форматировать отрицательные значения?**

Для поддерживаемых баров, столбцов и пузырей включите [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertifnegative/) и задайте [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). Вы можете переопределить поведение для отдельной точки с помощью [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). Эти свойства влияют на оформление, а не на хранимые числовые значения.

**Какой формат имеет приоритет, если заданы и серия, и точка?**

Явное форматирование точки данных имеет приоритет для этой точки. Другие точки продолжают использовать явный формат серии или, если формат серии не определён, автоматический стиль и тему диаграммы. Свойства группы, такие как перекрытие и ширина промежутка, управляют расположением и не являются переопределяющими форматами уровня точек.

**Есть ли ограничение на количество серий в диаграмме?**

Aspose.Slides не накладывает отдельного фиксированного ограничения на количество серий. На практике ограничения определяются размером файла презентации, доступной памятью, временем рендеринга и читаемостью диаграммы.

**Что менять, если столбцы слишком близко или слишком далеко друг от друга?**

Установите [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) в нужной группе родительских серий. Увеличьте значение, чтобы расширить пространство между кластерами, или уменьшите его, чтобы собрать кластеры ближе друг к другу.