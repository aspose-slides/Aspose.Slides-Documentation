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
- цвет сектора
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как создавать и настраивать круговые диаграммы в .NET с помощью Aspose.Slides, экспортируемые в PowerPoint, ускоряя рассказ о данных за считанные секунды."
---

## **Варианты второго участка для диаграмм «Круг в круге» и «Полоска в круге»**
Aspose.Slides for .NET теперь поддерживает параметры второго участка для диаграмм «Круг в круге» или «Полоска в круге». В этой теме мы посмотрим на примере, как указать эти параметры с помощью Aspose.Slides. Чтобы задать свойства, выполните следующие шаги:

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Добавьте диаграмму на слайд.
1. Укажите параметры второго участка диаграммы.
1. Запишите презентацию на диск.

В приведенном ниже примере мы задаем различные свойства диаграммы «Круг в круге».
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





## **Установить автоматические цвета секторов круговой диаграммы**
Aspose.Slides for .NET предоставляет простой API для установки автоматических цветов секторов круговой диаграммы. Пример кода применяет указанные выше свойства.

1. Создайте экземпляр класса Presentation.
1. Получите первый слайд.
1. Добавьте диаграмму с данными по умолчанию.
1. Установите заголовок диаграммы.
1. Установите для первого ряда отображение значений.
1. Задайте индекс листа данных диаграммы.
1. Получите лист данных диаграммы.
1. Удалите сгенерированные по умолчанию ряды и категории.
1. Добавьте новые категории.
1. Добавьте новый ряд.

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
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Установить отображение значений для первого ряда
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Установка индекса листа данных диаграммы
	int defaultWorksheetIndex = 0;

	// Получение листа данных диаграммы
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Удалить автоматически созданные ряды и категории
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Добавление новых категорий
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Добавление нового ряда
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Заполнение данных ряда
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**Поддерживаются ли варианты «Круг в круге» и «Полоска в круге»?**

Да, библиотека [поддерживает](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) вторичный участок для круговых диаграмм, включая типы «Круг в круге» и «Полоска в круге».

**Могу ли я экспортировать только диаграмму как изображение (например, PNG)?**

Да, вы можете [экспортировать саму диаграмму как изображение](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (например, PNG) без всей презентации.