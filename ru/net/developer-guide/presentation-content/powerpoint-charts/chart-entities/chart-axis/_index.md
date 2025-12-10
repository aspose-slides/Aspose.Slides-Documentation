---
title: Настройка осей диаграмм в презентациях на .NET
linktitle: Ось диаграммы
type: docs
url: /ru/net/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настройка оси
- манипулирование осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- положение оси
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для .NET, чтобы настраивать оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---

## **Получить максимальные значения по вертикальной оси на диаграммах**
Aspose.Slides for .NET позволяет получить минимальные и максимальные значения по вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите фактическое максимальное значение оси.
1. Получите фактическое минимальное значение оси.
1. Получите фактическую основную единицу оси.
1. Получите фактическую вспомогательную единицу оси.
1. Получите фактический масштаб основной единицы оси.
1. Получите фактический масштаб вспомогательной единицы оси.

Этот пример кода — реализация перечисленных шагов — показывает, как получить требуемые значения на C#:
```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Сохраняет презентацию
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **Поменять местами данные между осями**
Aspose.Slides позволяет быстро поменять местами данные между осями — данные, отображаемые по вертикальной оси (y‑axis), перемещаются на горизонтальную ось (x‑axis) и наоборот.

Этот код на C# показывает, как выполнить задачу обмена данными между осями в диаграмме:
```c#
	// Создает пустую презентацию
	using (Presentation pres = new Presentation())
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

		// Меняет местами строки и столбцы
		chart.ChartData.SwitchRowColumn();
			   
		// Сохраняет презентацию
		 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
	 }
```


## **Отключить вертикальную ось для линейных диаграмм**
Этот код на C# показывает, как скрыть вертикальную ось для линейной диаграммы:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Отключить горизонтальную ось для линейных диаграмм**
Этот код показывает, как скрыть горизонтальную ось для линейной диаграммы:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Изменить категориальную ось**
С помощью свойства **CategoryAxisType** вы можете указать предпочитаемый тип категориальной оси (**date** или **text**). Этот код на C# демонстрирует операцию: 
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```


## **Установить формат даты для значений категориальной оси**
Aspose.Slides for .NET позволяет установить формат даты для значения категориальной оси. Операция продемонстрирована в этом коде на C#:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Установить угол поворота заголовка оси диаграммы**
Aspose.Slides for .NET позволяет установить угол поворота заголовка оси диаграммы. Этот код на C# демонстрирует операцию:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Установить положение оси на категориальной или значимой оси**
Aspose.Slides for .NET позволяет установить позицию оси в категориальной или значимой оси. Этот код на C# показывает, как выполнить задачу:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **Включить отображение подписи единицы измерения на оси значений диаграммы**
Aspose.Slides for .NET позволяет настроить диаграмму так, чтобы отображалась подпись единицы измерения на оси значений диаграммы. Этот код на C# демонстрирует операцию:
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Как задать значение, при котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют параметр [crossing setting](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/): вы можете выбрать пересечение в нуле, на максимальной категории/значении или в конкретном числовом значении. Это полезно для сдвига оси X вверх или вниз или для выделения базовой линии.

**Как позиционировать метки делений относительно оси (рядом, снаружи, внутри)?**

Установите [label position](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) в значение "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно на небольших диаграммах.