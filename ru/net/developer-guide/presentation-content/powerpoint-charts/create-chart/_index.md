---
title: Создание или обновление диаграмм PowerPoint презентаций в .NET
linktitle: Создание или обновление диаграмм
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
- диаграмма древовидной карты
- диаграмма акций
- диаграмма «коробка с усами»
- воронкообразная диаграмма
- лучевая диаграмма
- гистограмма
- радиальная диаграмма
- многокатегориальная диаграмма
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и настраивайте диаграммы в презентациях PowerPoint с помощью Aspose.Slides для .NET. Добавляйте, форматируйте и редактируйте диаграммы, используя практические примеры кода на C#."
---
## **Обзор**

В этой статье представлено полное руководство по созданию и настройке диаграмм с помощью Aspose.Slides для .NET. Вы узнаете, как программно добавить диаграмму на слайд, заполнить её данными и применить различные параметры форматирования, соответствующие вашим требованиям к дизайну. На протяжении всей статьи подробно показаны примеры кода, иллюстрирующие каждый шаг — от инициализации презентации и объекта диаграммы до настройки серий, осей и легенд. Следуя руководству, вы получите прочные знания о том, как интегрировать динамическое создание диаграмм в свои .NET‑приложения, упростив процесс создания презентаций, основанных на данных.

## **Создание диаграммы**

Диаграммы помогают быстро визуализировать данные и получать инсайты, которые не всегда очевидны из таблицы или электронных таблиц.

**Зачем создавать диаграммы?**

С помощью диаграмм вы можете:

* агрегировать, конденсировать или суммировать большие объёмы данных на одном слайде презентации;
* выявлять закономерности и тенденции в данных;
* определять направление и динамику данных во времени или относительно определённой единицы измерения;
* обнаруживать выбросы, аномалии, отклонения, ошибки и бессмысленные данные;
* передавать или представлять сложные данные.

В PowerPoint диаграммы создаются через функцию *Insert*, которая предоставляет шаблоны для разработки различных типов диаграмм. С помощью Aspose.Slides вы можете создавать как обычные диаграммы (на основе популярных типов), так и пользовательские диаграммы.

{{% alert color="info" %}} 
Используйте перечисление [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) из пространства имен [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Значения этого перечисления соответствуют различным типам диаграмм.
{{% /alert %}} 

### **Создание сгруппированных столбчатых диаграмм**

В этом разделе описывается, как создавать сгруппированные столбчатые диаграммы с помощью Aspose.Slides для .NET. Вы научитесь инициализировать презентацию, добавлять диаграмму и настраивать её элементы, такие как заголовок, данные, серии, категории и стиль. Выполните перечисленные шаги, чтобы увидеть, как генерируется обычная сгруппированная столбчатая диаграмма:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.ClusteredColumn`.
1. Добавьте заголовок к диаграмме.
1. Получите доступ к таблице данных диаграммы.
1. Очистите все серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Задайте цвет заливки для серии диаграммы.
1. Добавьте подписи к серии диаграммы.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код демонстрирует, как создать сгруппированную столбчатую диаграмму:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавить сгруппированную столбчатую диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Установить заголовок диаграммы.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Установить индекс листа данных диаграммы.
    int worksheetIndex = 0;

    // Получить рабочую книгу данных диаграммы.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Удалить автоматически сгенерированные серии и категории.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Добавить новые серии.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Добавить новые категории.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Получить первую серию диаграммы.
    IChartSeries series = chart.ChartData.Series[0];

    // Заполнить данные серии.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Установить цвет заливки для серии.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Получить вторую серию диаграммы.
    series = chart.ChartData.Series[1];

    // Заполнить данные серии.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Установить цвет заливки для серии.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Установить первую подпись для отображения названия категории.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Настроить серию для отображения значения в третьей подписи.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Сохранить презентацию на диск в файл PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Clustered Column chart](clustered_column_chart.png)

### **Создание точечных диаграмм**

Точечные диаграммы (также известные как scatter plots или x‑y графики) часто используют для поиска закономерностей или демонстрации корреляций между двумя переменными.

Используйте точечную диаграмму, когда:

* У вас есть парные числовые данные.
* Есть две переменные, которые логично сопоставляются.
* Вы хотите определить, связаны ли две переменные.
* Есть независимая переменная с несколькими значениями зависимой переменной.

Этот C#‑код показывает, как создать точечную диаграмму с различными маркерами серии:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    // Создать точечную диаграмму по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Установить индекс листа данных диаграммы.
    int worksheetIndex = 0;

    // Получить рабочую книгу данных диаграммы.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Удалить серию по умолчанию.
    chart.ChartData.Series.Clear();

    // Добавить новые серии.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Получить первую серию диаграммы.
    IChartSeries series = chart.ChartData.Series[0];

    // Добавить новую точку (1:3) в серию.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Добавить новую точку (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Изменить тип серии.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Изменить маркер серии диаграммы.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Получить вторую серию диаграммы.
    series = chart.ChartData.Series[1];

    // Добавить новую точку (5:2) в серию диаграммы.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Добавить новую точку (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Добавить новую точку (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Добавить новую точку (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Изменить маркер серии диаграммы.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Сохранить презентацию на диск в файл PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Scatter chart](scatter_chart.png)

### **Создание круговых диаграмм**

Круговые диаграммы лучше всего подходят для отображения соотношения части к целому, особенно когда данные содержат категориальные метки с числовыми значениями. Однако если в наборе данных много частей или меток, стоит рассмотреть возможность использования гистограммы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.Pie`.
1. Получите доступ к рабочей книге данных диаграммы ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Добавьте новые точки и задайте пользовательские цвета секторов круговой диаграммы.
1. Установите подписи для серий.
1. Включите линии‑выноски для подписей серий.
1. Задайте угол поворота круговой диаграммы.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать круговую диаграмму:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// Создать экземпляр класса Presentation.
using (Presentation presentation = new Presentation())
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    // Добавить диаграмму с данными по умолчанию.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Установить заголовок диаграммы.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Настроить первую серию для отображения значений.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Установить индекс листа данных диаграммы.
    int worksheetIndex = 0;

    // Получить рабочую книгу данных диаграммы.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Удалить автоматически сгенерированные серии и категории.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Добавить новые категории.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Добавить новую серию.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Заполнить данные серии.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Установить цвет сектора.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Установить границу сектора.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Установить границу сектора.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Установить границу сектора.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Создать пользовательские подписи для каждой категории в новой серии.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Настроить серию для отображения выноски (leader lines) в диаграмме.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Установить угол поворота секторов круговой диаграммы.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Сохранить презентацию на диск в файл PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Pie chart](pie_chart.png)

### **Создание линейных диаграмм**

Линейные диаграммы (также известные как line graphs) лучше всего использовать, когда нужно показать изменение значений во времени. С их помощью можно сравнивать большие объёмы данных, отслеживать изменения и тенденции, выделять аномалии в серии данных и многое другое.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.Line`.
1. Получите доступ к рабочей книге данных диаграммы ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать линейную диаграмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

По умолчанию точки на линейной диаграмме соединяются сплошными прямыми линиями. Чтобы соединить их пунктиром, укажите желаемый тип штриха следующим образом:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

Результат:

![The Line chart](line_chart.png)

### **Создание диаграмм древовидной карты**

Диаграммы древовидной карты лучше всего подходят для отображения объёма категорий продаж и быстрой визуализации крупных вкладчиков в каждой категории.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.Treemap`.
1. Получите доступ к рабочей книге данных диаграммы ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать диаграмму древовидной карты:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Ветка 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Ветка 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Treemap chart](treemap_chart.png)

### **Создание диаграмм акций**

Диаграммы акций отображают финансовые данные — цены открытия, максимумы, минимумы и закрытия, помогая анализировать рыночные тенденции и волатильность. Они предоставляют важную информацию о динамике акций, облегчая принятие решений инвесторами и аналитиками.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.OpenHighLowClose`.
1. Получите доступ к рабочей книге данных диаграммы ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Укажите формат HiLowLines.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать диаграмму акций:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Stock chart](stock_chart.png)

### **Создание диаграмм «коробка с усами»**

Диаграммы «коробка с усами» отображают распределение данных, суммируя ключевые статистические показатели — медиану, квартали и потенциальные выбросы. Они полезны в исследовательском анализе данных и статистических исследованиях для быстрого понимания изменчивости и выявления аномалий.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.BoxAndWhisker`.
1. Получите доступ к рабочей книге данных диаграммы ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать диаграмму «коробка с усами»:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Создание воронкообразных диаграмм**

Воронкообразные диаграммы визуализируют процессы, состоящие из последовательных этапов, где объём данных уменьшается от шага к шагу. Они помогают анализировать коэффициенты конверсии, выявлять узкие места и отслеживать эффективность процессов продаж или маркетинга.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.Funnel`.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать воронкообразную диаграмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Funnel chart](funnel_chart.png)

### **Создание лучевых диаграмм**

Лучевые диаграммы визуализируют иерархические данные, отображая уровни в виде концентрических кольцев. Они помогают иллюстрировать соотношения часть‑к‑целому и идеально подходят для представления вложенных категорий и подкатегорий в компактном виде.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.Sunburst`.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать лучевую диаграмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Ветка 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Ветка 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Sunburst chart](sunburst_chart.png)

### **Создание гистограмм**

Гистограммы используют для представления распределения числовых данных путем группировки значений в диапазоны (корзины). Они полезны для выявления частотных паттернов, асимметрии, разброса и обнаружения выбросов в наборе данных.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.Histogram`.
1. Получите доступ к рабочей книге данных диаграммы ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать гистограмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Histogram chart](histogram_chart.png)

### **Создание радиальных диаграмм**

Радиальные диаграммы отображают многомерные данные в двумерном виде, позволяя одновременно сравнивать несколько переменных. Они удобны для выявления шаблонов, сильных и слабых сторон по набору метрик или атрибутов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с некоторыми данными и укажите тип `ChartType.Radar`.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать радиальную диаграмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Radar chart](radar_chart.png)

### **Создание многокатегориальных диаграмм**

Многокатегориальные диаграммы позволяют отображать данные с более чем одной категориальной группировкой, давая возможность сравнивать значения по нескольким измерениям одновременно. Они особенно полезны при анализе тенденций и взаимосвязей в сложных, многослойных наборах данных.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте диаграмму с данными по умолчанию и укажите тип `ChartType.ClusteredColumn`.
1. Получите доступ к рабочей книге данных диаграммы ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Очистите серии и категории по умолчанию.
1. Добавьте новые серии и категории.
1. Добавьте новые данные диаграммы для серий.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как создать многокатегориальную диаграмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Добавить серию.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Сохранить презентацию с диаграммой.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Результат:

![The multi category chart](multi_category_chart.png)

### **Создание картографических диаграмм**

Картографические диаграммы визуализируют географические данные, сопоставляя информацию с конкретными локациями — странами, штатами или городами. Они полезны для анализа региональных тенденций, демографических данных и пространственного распределения в наглядном виде.

Этот C#‑код показывает, как создать картографическую диаграмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Результат:

![The Map chart](map_chart.png)

{{% alert color="info" %}} 
На изображении выше показана сохранённая презентация, открытая в PowerPoint. Aspose.Slides корректно записывает картографическую диаграмму и её данные, но сама диаграмма не отображается: при рендеринге слайда в изображение или конвертации в PDF или SVG область диаграммы остаётся пустой. Другие фигуры на том же слайде отображаются нормально.
{{% /alert %}} 

### **Создание комбинированных диаграмм**

Комбинированная (или combo) диаграмма объединяет два и более типов диаграмм в одном графике. Такая диаграмма позволяет выделять, сравнивать или анализировать различия между несколькими наборами данных, помогая увидеть их взаимосвязи.

![The combination chart](combination_chart.png)

Следующий C#‑код демонстрирует, как создать комбинированную диаграмму, показанную выше, в презентации PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Устанавливает заголовок диаграммы
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Устанавливает легенду диаграммы
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Удаляет автоматически сгенерированные серии и категории
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Добавляет новые категории
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Добавляет первую серию
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Устанавливает горизонтальную ось
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Устанавливает вертикальную ось
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Устанавливает цвет основных линий сетки по вертикали
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Устанавливает вторичную горизонтальную ось
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Устанавливает вторичную вертикальную ось
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Обновление диаграмм**

Aspose.Slides для .NET позволяет обновлять диаграммы PowerPoint, изменяя данные, форматирование и стиль. Эта возможность упрощает процесс поддержания презентаций в актуальном состоянии с динамическим содержимым и гарантирует, что диаграммы точно отражают текущие данные и визуальные стандарты.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), представляющего презентацию с диаграммой.
1. Получите ссылку на слайд, используя его индекс.
1. Пройдитесь по всем фигурам, чтобы найти диаграмму.
1. Получите доступ к таблице данных диаграммы.
1. Измените серию данных диаграммы, поменяв значения серии.
1. Добавьте новую серию и заполните её данными.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как обновить диаграмму:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Создать экземпляр класса Presentation, представляющего файл PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Установить индекс листа данных диаграммы.
            int worksheetIndex = 0;

            // Получить рабочую книгу данных диаграммы.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Изменить названия категорий диаграммы.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Получить первую серию диаграммы.
            IChartSeries series = chart.ChartData.Series[0];

            // Обновить данные серии.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Модификация названия серии.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Получить вторую серию диаграммы.
            series = chart.ChartData.Series[1];

            // Обновить данные серии.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Модификация названия серии.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Добавить новую серию.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Заполнить данные серии.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Сохранить презентацию с диаграммой.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Установка диапазона данных для диаграммы**

Чтобы посмотреть диапазон, уже используемый существующей диаграммой, см. [Retrieve a Chart's Data Range](/slides/ru/net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides для .NET предоставляет возможность задавать конкретный диапазон данных из рабочей книги в качестве источника данных диаграммы. Это позволяет напрямую привязывать часть листа к диаграмме, контролируя, какие ячейки участвуют в сериях и категориях. В результате вы можете легко обновлять и синхронизировать диаграммы с последними изменениями данных в листе, обеспечивая актуальность и точность информации в презентациях PowerPoint.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), представляющего презентацию с диаграммой.
1. Получите ссылку на слайд, используя его индекс.
1. Пройдитесь по всем фигурам, чтобы найти диаграмму.
1. Получите доступ к данным диаграммы и задайте диапазон.
1. Сохраните изменённую презентацию в формате PPTX.

Этот C#‑код показывает, как задать диапазон данных для диаграммы:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// Создать экземпляр класса Presentation, представляющего файл PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Получить первый слайд.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Использование стандартных маркеров в диаграммах**

При использовании стандартных маркеров в диаграммах каждой серии автоматически присваивается свой уникальный маркер.

Этот C#‑код показывает, как автоматически задать маркер для серии диаграммы:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Заполнить данные серии.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Какие типы диаграмм поддерживает Aspose.Slides для .NET?**

Aspose.Slides для .NET поддерживает широкий спектр типов диаграмм, включая столбчатые, линейные, круговые, областные, точечные, гистограммы, радиальные и многие другие. Эта гибкость позволяет выбрать наиболее подходящий тип диаграммы для ваших задач визуализации данных.

**Как добавить новую диаграмму на слайд?**

Чтобы добавить диаграмму, сначала создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), получите нужный слайд по его индексу, а затем вызовите метод добавления диаграммы, указав тип диаграммы и начальные данные. Этот процесс интегрирует диаграмму непосредственно в вашу презентацию.

**Как обновить данные, отображаемые в диаграмме?**

Вы можете обновить данные диаграммы, получив доступ к её рабочей книге данных ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), очистив серии и категории по умолчанию и добавив свои собственные данные. Это позволяет программно обновлять диаграмму, отражая последние данные.

**Можно ли настроить внешний вид диаграммы?**

Да, Aspose.Slides для .NET предоставляет обширные возможности настройки. Вы можете изменять цвета, шрифты, подписи, легенды и другие элементы форматирования, чтобы адаптировать внешний вид диаграммы под конкретные требования дизайна.