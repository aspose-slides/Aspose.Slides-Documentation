---
title: Настройка круговых диаграмм в презентациях на .NET
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
- цвет секторов
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы в .NET с помощью Aspose.Slides, экспортировать их в PowerPoint и усиливать рассказ о данных за считанные секунды."
---

## **Параметры вторичного графика для диаграмм «Круг в круге» и «Полоска в круге»**
Aspose.Slides для .NET теперь поддерживает параметры вторичного графика для диаграмм «Круг в круге» или «Полоска в круге». В этой статье мы рассмотрим пример, показывающий, как задать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте диаграмму на слайд.
1. Укажите параметры вторичного графика диаграммы.
1. Запишите презентацию на диск.

В приведённом ниже примере мы задали различные свойства диаграммы «Круг в круге».
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

// Запишите презентацию на диск
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```





## **Установите автоматические цвета секторов круговой диаграммы**
Aspose.Slides для .NET предоставляет простой API для задания автоматических цветов секторов круговой диаграммы. Пример кода применяет указанные выше настройки.

1. Создайте экземпляр класса Presentation.
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Задайте заголовок диаграммы.
1. Установите у первой серии отображение значений.
1. Задайте индекс листа данных диаграммы.
1. Получите лист данных диаграммы.
1. Удалите серии и категории, созданные по умолчанию.
1. Добавьте новые категории.
1. Добавьте новую серию.

Запишите изменённую презентацию в файл PPTX.
```c#
// Создайте экземпляр класса Presentation, который представляет файл PPTX
using (Presentation presentation = new Presentation())
{
	// Создайте экземпляр класса Presentation, который представляет файл PPTX
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

	// Заполнение данных серии
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Поддерживаются варианты «Круг в круге» и «Полоска в круге»?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) вторичный график для круговых диаграмм, включая типы «Круг в круге» и «Полоска в круге».

**Можно ли экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать диаграмму как изображение](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (например, PNG) без полной презентации.