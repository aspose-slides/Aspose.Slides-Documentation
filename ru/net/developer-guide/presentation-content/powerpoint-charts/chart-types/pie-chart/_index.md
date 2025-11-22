---
title: Круговая диаграмма
type: docs
url: /ru/net/pie-chart/
keywords: "Круговая диаграмма, параметры построения, цвета секторов, презентация PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Параметры построения круговой диаграммы и цвета секторов в презентации PowerPoint на C# или .NET"
---

## **Вторичные параметры построения для диаграмм Pie of Pie и Bar of Pie**
Aspose.Slides for .NET теперь поддерживает вторичные параметры построения для диаграмм Pie of Pie и Bar of Pie. В этом разделе мы посмотрим на пример, как указать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте диаграмму на слайд.
1. Укажите вторичные параметры построения диаграммы.
1. Сохраните презентацию на диск.

В примере ниже мы задали различные свойства диаграммы Pie of Pie.
```c#
// Создайте экземпляр класса Presentation
Presentation presentation = new Presentation();

// Добавьте диаграмму на слайд
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Установите различные свойства
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Сохраните презентацию на диск
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```





## **Установка автоматических цветов секторов круговой диаграммы**
Aspose.Slides for .NET предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода применяет указанные выше свойства.

1. Создайте экземпляр класса Presentation.
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите для первой серии отображение значений.
1. Установите индекс листа данных диаграммы.
1. Получите лист данных диаграммы.
1. Удалите автоматически сгенерированные серии и категории.
1. Добавьте новые категории.
1. Добавьте новую серию.

Сохраните изменённую презентацию в файл PPTX.
```c#
// Создайте экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
	// Создайте экземпляр класса Presentation, представляющего файл PPTX
	Presentation presentation = new Presentation();

	// Получите первый слайд
	ISlide slides = presentation.Slides[0];

	// Добавьте диаграмму с данными по умолчанию
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Установка заголовка диаграммы
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Установите отображение значений для первой серии
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Установка индекса листа данных диаграммы
	int defaultWorksheetIndex = 0;

	// Получение листа данных диаграммы
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Удалите автоматически сгенерированные серии и категории
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Добавление новых категорий
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Добавление новой серии
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Теперь заполняем данные серии
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Поддерживаются ли варианты 'Pie of Pie' и 'Bar of Pie'?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) вторичное построение для круговых диаграмм, включая типы 'Pie of Pie' и 'Bar of Pie'.

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (например, PNG) без всей презентации.