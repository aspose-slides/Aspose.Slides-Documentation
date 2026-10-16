---
title: Создание или обновление диаграмм PowerPoint‑презентаций в .NET
linktitle: Создать или обновить диаграммы
type: docs
weight: 10
url: /ru/net/create-chart/
keywords:
- добавить диаграмму
- создать диаграмму
- редактировать диаграмму
- изменить диаграмму
- обновить диаграмму
- точечная диаграмма
- круговая диаграмма
- линейная диаграмма
- диаграмма Tree Map
- биржевая диаграмма
- коробчатая диаграмма с усами
- воронкообразная диаграмма
- лучевая диаграмма
- гистограмма
- радиальная диаграмма
- диаграмма с несколькими категориями
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: Создавайте и настраивайте диаграммы в презентациях PowerPoint с использованием Aspose.Slides для .NET. Добавляйте, форматируйте и редактируйте диаграммы с практическими примерами кода на C#.
---
## **Обзор**

Эта статья предоставляет всестороннее руководство по созданию и настройке диаграмм с помощью Aspose.Slides для .NET. Вы узнаете, как программно добавить диаграмму на слайд, заполнить её данными и применить различные параметры форматирования, чтобы соответствовать вашим конкретным требованиям к дизайну. На протяжении статьи детальные примеры кода иллюстрируют каждый шаг, от инициализации презентации и объекта диаграммы до настройки серий, осей и легенд. Следуя этому руководству, вы получите прочное понимание того, как интегрировать динамическое создание диаграмм в ваши .NET‑приложения, упростив процесс создания презентаций, основанных на данных.

## **Создать диаграмму**

Диаграммы помогают людям быстро визуализировать данные и получать выводы, которые могут быть не очевидны из таблицы или электронных таблиц.

**Зачем создавать диаграммы?**

Используя диаграммы, вы можете:

* агрегировать, сжимать или суммировать большие объёмы данных на одном слайде презентации;
* выявлять шаблоны и тенденции в данных;
* определять направление и динамику данных во времени или относительно конкретной единицы измерения;
* обнаруживать выбросы, аномалии, отклонения, ошибки и бессмысленные данные;
* эффективно представлять сложные данные.

В PowerPoint вы можете создавать диаграммы через функцию *Insert*, которая предоставляет шаблоны для проектирования множества типов диаграмм. С помощью Aspose.Slides вы можете создавать как обычные диаграммы (на основе популярных типов), так и пользовательские диаграммы.

{{% alert color="info" title="Note" %}}
Используйте перечисление [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) в пространстве имён [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Значения этого перечисления соответствуют различным типам диаграмм.
{{% /alert %}}

### **Создать группированные столбчатые диаграммы**

В этом примере используется [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для создания группированной столбчатой диаграммы, сравнивающей две серии по трём категориям. Серии используют красные и зелёные заливки, а отдельные подписи показывают имена категорий, имена серий и значения. Индекс листа 0 относится к первому листу во встроенной книге диаграмм.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Результат:

![The Clustered Column chart](clustered_column_chart.png)

### **Создать точечные диаграммы**

Точечные диаграммы (также известные как scatter plots или графики x‑y) часто используют для проверки шаблонов или демонстрации корреляций между двумя переменными.

Используйте точечную диаграмму, когда:

* у вас есть парные числовые данные;
* две переменные хорошо сочетаются друг с другом;
* вы хотите определить, связаны ли две переменные;
* у вас есть независимая переменная, имеющая несколько значений для зависимой переменной.

В этом примере построены два набора значений x‑y. Первая серия использует прямые линии со звездочками в качестве маркеров, вторая — сглаженные линии с круговыми маркерами; обе используют [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) = 10. Свойство [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) управляет формой маркера.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Результат:

![The Scatter chart](scatter_chart.png)

### **Создать круговые диаграммы**

Круговые диаграммы лучше всего использовать для отображения отношения части к целому, особенно когда данные содержат категориальные метки с числовыми значениями. Однако если в данных много частей или меток, стоит рассмотреть использование гистограммы.

В этом примере создаётся круговая диаграмма с тремя квартальными значениями. Каждый сектор имеет индивидуальную заливку и границу, а подписи отображают различные комбинации значений, процентов и информации о серии. Свойство [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) задаёт начальный угол первого сектора — 180°.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

Результат:

![The Pie chart](pie_chart.png)

Чтобы улучшить читаемость подписей за пределами круга, см. [Format Leader Lines](/slides/ru/net/chart-data-label/#format-leader-lines) для примера, где подписи позиционируются и настраиваются цвет, ширина, прозрачность и стиль штриха линий.

### **Создать линейные диаграммы**

Линейные диаграммы (также известные как line graphs) лучше всего подходят для демонстрации изменения значений со временем. С их помощью можно одновременно сравнивать большие объёмы данных, отслеживать изменения и тенденции, выделять аномалии в сериях и многое другое.

В этом примере используется [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для создания линейной диаграммы с сериями и категориями по умолчанию, после чего презентация сохраняется в формате PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

По умолчанию точки на линейной диаграмме соединяются прямыми непрерывными линиями. Если требуется соединять точки пунктиром, задайте свойству [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) значение из [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Результат:

![The Line chart](line_chart.png)

### **Создать диаграммы Tree Map**

Диаграммы Tree Map лучше всего подходят для отображения данных продаж, когда нужно показать относительный размер категорий и быстро обратить внимание на элементы, являющиеся крупными contributors внутри каждой категории.

В этом примере создаётся Tree Map с восемью листами, сгруппированными в четыре ствола и две ветви. Метод [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) назначает стволы на уровне группировки 1 и ветви на уровне 2. Значения определяют относительные размеры прямоугольников, а метки категорий и перекрывающиеся метки родителей показывают иерархию.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Ветка 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Ветка 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

Результат:

![The Treemap chart](treemap_chart.png)

### **Создать водопадные диаграммы**

Водопадная диаграмма показывает, как положительные и отрицательные изменения влияют на конечное значение. Например, разбивка прибыли может начинаться с доходов, затем вычитать издержки и добавлять прочие доходы. Столбцы‑изменения «плавают» между предыдущим и новым накопленным значением, а столбцы‑итоги идут от нуля до накопленного значения.

Ниже приведён пример с суммами в тысячах долларов США:

| Категория | Значение в книге | Тип столбца |
| --- | ---: | --- |
| Выручка | 1000 | Увеличение |
| Себестоимость продаж | -400 | Уменьшение |
| Валовая прибыль | 600 | Промежуточный итог |
| Операционные расходы | -200 | Уменьшение |
| Прочие доходы | 50 | Увеличение |
| Чистая прибыль | 450 | Финальный итог |

Чтобы пометить точку как промежуточный или финальный итог, задайте её свойству [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) значение `true`. Укажите фактическую накопленную сумму в соответствующей ячейке книги: `600` для валовой прибыли (`1000 - 400`) и `450` для чистой прибыли (`600 - 200 + 50`). Свойство лишь помечает столбец как итоговый; оно не вычисляет и не заполняет значение ячейки. Не используйте ноль как заполнитель и не задавайте другое изменение для итоговой точки. Итоговый столбец отображает накопленное значение без повторного добавления к текущему значению.

Этот полный пример на C# создаёт диаграмму, используя член `Waterfall` перечисления [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), очищает данные по умолчанию и заполняет встроенную книгу. Индекс листа `0` выбирает первый лист; столбец A содержит названия категорий, столбец B — значения. Каждая ячейка со значением добавляется через [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/). Нулевые индексы точек `2` и `5` идентифицируют промежуточный и финальный итог. Включение [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) отображает суммы на столбцах. Входная презентация или книга не требуются.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// Третья и шестая точки представляют итоги, а не дополнительные изменения.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

Задайте свойству уровня серии [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) значение `true`, чтобы отобразить линии, соединяющие последовательные столбцы, и упростить восприятие текущего значения. Чтобы скрыть эти линии, замените присваивание в примере на `series.ShowConnectorLines = false;` перед сохранением. Это изменит только видимость линий, а не данные или итоги.

Сохранённая презентация показывает валовую прибыль 600 и чистую прибыль 450, при этом оба итога считаются от нуля:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **Создать биржевые диаграммы**

Биржевые диаграммы используют данные о ценах открытия, максимума, минимума и закрытия, помогая анализировать рыночные тенденции и волатильность. Они предоставляют важные сведения о динамике акций, облегчая принятие решений инвесторами и аналитиками.

В этом примере создаётся диаграмма OHLC (open‑high‑low‑close) с четырьмя сериями в указанном порядке и тремя категориями. Свойство [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) включает столбцы «вверх/вниз», а [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) управляет линиями high‑low, показывающими диапазоны цен; линии отдельных серий и мелкие горизонтальные сетки скрыты.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

Результат:

![The Stock chart](stock_chart.png)

### **Создать диаграммы «коробка‑усик»**

Диаграммы «коробка‑усик» отображают распределение данных, суммируя ключевые статистические показатели, такие как медиана, квартали и потенциальные выбросы. Они полезны в исследовательском анализе и статистических исследованиях для быстрого понимания изменчивости данных и выявления аномалий.

В этом примере создаётся диаграмма «коробка‑усик» из шести значений. Свойство [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) выбирает исключительный метод расчёта квартилей. Пример также включает линии среднего, маркеры среднего, внутренние точки и выбросы.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **Создать воронкообразные диаграммы**

Воронкообразные диаграммы визуализируют процессы, состоящие из последовательных этапов, где объём данных уменьшается с каждым шагом. Они полезны для анализа коэффициентов конверсии, выявления узких мест и отслеживания эффективности процессов продаж или маркетинга.

В этом примере используется [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для добавления воронкообразной диаграммы на первый слайд существующей презентации. По умолчанию данные заменяются шестью категориями со значениями от 50 до 500, затем презентация сохраняется. Входная презентация должна содержать минимум один слайд.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

Результат:

![The Funnel chart](funnel_chart.png)

### **Создать лучевые диаграммы**

Лучевые диаграммы визуализируют иерархические данные, отображая уровни в виде концентрических колец. Они помогают иллюстрировать отношения часть‑к‑целому и идеальны для представления вложенных категорий и подкатегорий в компактном виде.

В этом примере создаётся лучевая диаграмма с восемью листами, сгруппированными в четыре ствола и две ветви. Метод [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) назначает стволы на уровне 1 и ветви на уровне 2. Метки категорий определяют сегменты, а значения задают их относительные размеры.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// Ветка 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// Ветка 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

Результат:

![The Sunburst chart](sunburst_chart.png)

### **Создать гистограммы**

Гистограммы показывают распределение числовых значений по интервалам (корзинам). Для ежемесячных отчётов о времени обработки заказов используйте одинаковую ширину корзин и пороги, чтобы интервалы оставались согласованными и распределения было удобно сравнивать.

Установите для горизонтальной оси свойство [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) в режим из [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). Параметр [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) применяется только к `ByBinWidth`; [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) — только к `ByNumberOfBins`. Используйте `Automatic`, чтобы позволить диаграмме самостоятельно выбирать корзины.

#### **Использовать фиксированную ширину корзины**

В этом примере время обработки группируется в интервалы по 10 минут, при этом отдельные корзины выделяются для времени ≤ 10 минут и > 40 минут. Включите такие корзины с помощью [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) и [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). При явном указании границ [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) и [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/) задайте [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) и [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) в `false`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

Презентация в PowerPoint показывает количества в корзинах **3, 4, 4, 4 и 2**. Корзина «underflow» включает `5, 10, 10`, её порог включительный. Корзина «overflow» содержит только `41, 50`, её порог исключительный; значения ровно `40` остаются в предыдущем интервале. Внутренние корзины включают значения, большие их нижней границы и ≤ верхней границы.

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **Задать количество корзин**

Для фиксированного уровня детализации вместо фиксированных интервалов запросите пять корзин для тех же данных. В этом примере корзины «underflow» и «overflow» отключены. Диаграмма определяет ширину на основе диапазона данных, поэтому границы могут изменяться между отчётами.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

Пять корзин имеют количества **4, 4, 4, 4 и 1**. Сравните это распределение с результатом фиксированной ширины выше: входные значения одинаковы, но границы различаются.

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **Создать радиальные диаграммы**

Радиальные диаграммы отображают многовариантные данные в двумерном формате, позволяя легко сравнивать несколько переменных одновременно. Они особенно полезны для выявления шаблонов, сильных и слабых сторон по множеству метрик или характеристик.

В этом примере используется [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для создания радиальной диаграммы с серией и категориями по умолчанию, после чего презентация сохраняется в формате PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

Результат:

![The Radar chart](radar_chart.png)

### **Создать диаграммы с несколькими категориями**

Диаграммы с несколькими категориями позволяют отображать данные, включающие более одной группировки, что даёт возможность сравнивать значения по нескольким измерениям одновременно. Они особенно полезны при анализе тенденций и взаимосвязей в сложных многослойных наборах данных.

В этом примере создаётся группированная столбчатая диаграмма с восемью категориями, расположенными в четырёх парах. Метод [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) задаёт каждой паре общий ярлык на уровне группировки 1, получая ось категорий с индивидуальными и групповыми метками.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

Результат:

![The multi category chart](multi_category_chart.png)

### **Создать картографические диаграммы**

Картографические диаграммы визуализируют географические данные, сопоставляя информацию с конкретными локациями (странами, штатами, городами). Они полезны для анализа региональных тенденций, демографических данных и пространственного распределения в наглядном виде.

В этом примере используется [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для создания картографической диаграммы с геоданными по умолчанию, после чего файл сохраняется для просмотра в PowerPoint.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

Результат:

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}
Изображение выше показывает сохранённую презентацию, открывшуюся в PowerPoint. Aspose.Slides корректно записывает картографическую диаграмму и её данные, но сама диаграмма не рисуется: при рендеринге слайда в изображение или преобразовании в PDF/SVG область диаграммы остаётся пустой. Другие фигуры на том же слайде не затрагиваются.
{{% /alert %}}

### **Создать комбинированные диаграммы**

Комбинированная диаграмма (или combo chart) объединяет два и более типов диаграмм в одном графике. Такая диаграмма позволяет выделять, сравнивать или исследовать различия между несколькими наборами данных, помогая установить их взаимосвязи.

![The combination chart](combination_chart.png)

В этом примере комбинируются две группированные столбчатые серии с линейной серией по четырём категориям. Столбцы используют главную вертикальную ось, а [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) размещает линию на вторичной вертикальной оси справа. Вспомогательные функции настраивают заголовок, легенду, подписи осей и сетку.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Обновить диаграммы**

Aspose.Slides для .NET позволяет обновлять диаграммы PowerPoint, изменяя их данные, форматирование и стили. Эта возможность упрощает поддержание презентаций в актуальном состоянии с динамичным содержимым и гарантирует, что диаграммы точно отражают текущие данные и визуальные стандарты.

В этом примере обновляется диаграмма с именем "My chart" на первом слайде существующей презентации. Требуются две колонные серии по три точки данных каждая, с метками категорий в колонке A и именами серий в первой строке первого листа. Пример использует [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) для изменения ячеек книги, обновляет значения серий, добавляет третью серию и меняет тип диаграммы на группированные цилиндры через [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **Установить диапазон данных для диаграммы**

Чтобы просмотреть диапазон, уже используемый существующей диаграммой, см. [Retrieve a Chart's Data Range](/slides/ru/net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides для .NET предоставляет гибкость определения конкретного диапазона данных из листа в качестве источника данных для вашей диаграммы. Это означает, что вы можете напрямую сопоставлять часть листа с диаграммой, контролируя, какие ячейки участвуют в сериях и категориях диаграммы. В результате вы легко обновляете и синхронизируете диаграммы с последними изменениями данных в листе, обеспечивая актуальность и точность информации в ваших презентациях PowerPoint.

В этом примере используется [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) для установки источника данных диаграммы с именем "My chart" на первом слайде существующей презентации в `Sheet1!A1:B4`. Книга диаграммы должна содержать указанный лист и заполненный диапазон с заголовком серии в первой строке, метками категорий в колонке A и тремя значениями в колонке B.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **Использовать маркеры по умолчанию в диаграммах**

При использовании маркеров по умолчанию каждая серия диаграммы автоматически получает уникальный символ маркера.

В этом примере используется [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) для создания диаграммы с двумя линейными сериями и легендой. Настройки [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) сохраняют автоматически назначенные символы маркеров. Первая серия содержит отрицательное значение и пропущенное значение, представленное `null`, вторая — значение для каждой категории.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Какие типы диаграмм поддерживает Aspose.Slides для .NET?**

Aspose.Slides для .NET поддерживает широкий спектр типов диаграмм, включая столбчатые, линейные, круговые, областные, точечные, гистограммы, радиальные и многие другие. Эта гибкость позволяет выбрать наиболее подходящий тип диаграммы для ваших задач визуализации данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), получайте нужный слайд по индексу и вызывайте метод добавления диаграммы, указывая тип диаграммы и начальные данные. Этот процесс напрямую интегрирует диаграмму в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её книге данных ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), очистив любые серии и категории по умолчанию и затем добавив свои пользовательские данные. Это позволяет программно обновлять диаграмму, отражая новейшие данные.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides для .NET предоставляет обширные возможности настройки. Вы можете изменять цвета, шрифты, подписи, легенды и другие элементы форматирования, чтобы адаптировать внешний вид диаграммы под конкретные требования дизайна.