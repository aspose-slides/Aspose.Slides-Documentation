---
title: Настройка круговых диаграмм в презентациях в .NET
linktitle: Круговая диаграмма
type: docs
url: /ru/net/pie-chart/
keywords:
- круговая диаграмма
- управление диаграммой
- настройка диаграммы
- параметры диаграммы
- настройки диаграммы
- параметры построения
- цвет сектора
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и настраивайте круговые диаграммы в .NET с помощью Aspose.Slides. Конфигурируйте вторичные графики, отображайте подписи данных и применяйте автоматическое раскрашивание секторов в PowerPoint."
---
## **Обзор**

В этой статье объясняется, как работать с круговыми диаграммами в Aspose.Slides. Показано, как настроить параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie, а также как включить автоматическое раскрашивание секторов для обычной круговой диаграммы.

Примеры сосредоточены на задачах настройки диаграмм, таких как добавление диаграммы на слайд, корректировка настроек рядов и меток, замена данных диаграммы по умолчанию пользовательскими категориями и значениями, а также сохранение обновлённой презентации.

## **Параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie**

Aspose.Slides for .NET поддерживает параметры вторичного графика для диаграмм Pie of Pie и Bar of Pie. Эти параметры управляют размером вторичного графика и тем, как точки данных распределяются между двумя графиками.

В следующем примере создаётся диаграмма Pie of Pie в новой презентации и отображаются значения точек данных в виде меток. Свойство [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) задаёт размер вторичного графика как 149% от основного графика. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) выбирает разбивку по процентам, а [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) устанавливает порог в 53%.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Выбор категорий для вторичного графика**

Используйте пользовательскую разбивку, когда нужно сгруппировать определённые категории во вторичном графике независимо от их процентных значений. Например, в отчёте о продажах можно показать Online и Events вместе, чтобы читатели могли сравнить эти два канала, даже если они составляют 35% и 10% от общей продажи.

Установите [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) в значение [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) и выберите точки через [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Метод [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) коллекции принимает либо нулевой индекс в ряду, либо объект точки данных. В этом примере индекс 1 выбирает Online, а точка с индексом 3 выбирает Events. Partners также временно добавляется, затем исключается с помощью [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Замените данные по умолчанию продажами по каналам.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Выберите Online по его нулевому индексу и Events по объекту точки данных.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Исключите Partners из выбора без удаления его исходных данных.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) и Events (10) отображаются как отдельные сектора во вторичном графике. В основном графике они представлены одним объединённым сектором со значением 45, вместе с Retail (40) и Partners (15). Удаление Partners из пользовательского выбора сохраняет его в основном графике; категория и её значение не удаляются из исходных данных диаграммы.

На следующем изображении показана сохранённая презентация в PowerPoint:

![Диаграмма Pie of Pie с Online и Events во вторичном графике и их объединённым значением 45 в основном графике](pie_of_pie_custom.png)

## **Установка автоматических цветов секторов круговой диаграммы**

Aspose.Slides for .NET может автоматически назначать разные цвета секторам круговой диаграммы. В следующем примере создаётся круговая диаграмма с заголовком по центру и заменяются данные по умолчанию тремя квартальными категориями и их значениями. Свойство [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) отображает значения 20, 50 и 30 в виде меток, а [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) включает различный цвет для каждого сектора.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Добавьте центрированный заголовок диаграммы.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Замените данные по умолчанию, используя первый лист.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Отобразите значения и назначьте разные цвета секторам.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **Часто задаваемые вопросы**

**Поддерживаются ли варианты Pie of Pie и Bar of Pie?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) вторичный график для круговых диаграмм, включая типы Pie of Pie и Bar of Pie.

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (например, PNG) без экспорта всей презентации.