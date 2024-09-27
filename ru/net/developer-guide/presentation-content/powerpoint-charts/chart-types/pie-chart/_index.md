---
title: Пироговая диаграмма
type: docs
url: /ru/net/pie-chart/
keywords: "Пироговая диаграмма, параметры построения, цвета сегментов, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Параметры построения пироговой диаграммы и цвета сегментов в презентации PowerPoint на C# или .NET"
---

## **Вторые параметры построения для Пироговой диаграммы и Барной диаграммы**
Aspose.Slides для .NET теперь поддерживает вторые параметры построения для Пироговой диаграммы или Барной диаграммы. В этой теме мы рассмотрим на примере, как указать эти параметры с помощью Aspose.Slides. Для того чтобы указать свойства, пожалуйста, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте диаграмму на слайд.
1. Укажите вторые параметры построения диаграммы.
1. Запишите презентацию на диск.

В приведённом ниже примере мы установили разные свойства пироговой диаграммы.

```c#
// Создайте экземпляр класса Presentation
Presentation presentation = new Presentation();

// Добавьте диаграмму на слайд
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Установите разные свойства
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Запишите презентацию на диск
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Установка автоматических цветов сегментов пироговой диаграммы**
Aspose.Slides для .NET предоставляет простой API для установки автоматических цветов сегментов пироговой диаграммы. Пример кода применяет указанные выше настройки.

1. Создайте экземпляр класса Presentation.
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите первое множество для показа значений.
1. Установите индекс рабочего листа данных диаграммы.
1. Получите рабочий лист данных диаграммы.
1. Удалите автоматически сгенерированные множества и категории.
1. Добавьте новые категории.
1. Добавьте новые множества.

Запишите изменённую презентацию в файл PPTX.

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
	chart.ChartTitle.AddTextFrameForOverriding("Пример заголовка");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Установите первое множество для показа значений
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Установка индекса рабочего листа данных диаграммы
	int defaultWorksheetIndex = 0;

	// Получение рабочего листа данных диаграммы
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Удалите автоматически сгенерированные множества и категории
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Добавление новых категорий
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "Первый квартал"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "Второй квартал"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "Третий квартал"));

	// Добавление новых множеств
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Серия 1"), chart.Type);

	// Теперь заполним данные серии
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```