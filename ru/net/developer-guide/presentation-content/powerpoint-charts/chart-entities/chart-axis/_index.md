---
title: Настройка осей диаграмм в презентациях на .NET
linktitle: Ось диаграммы
type: docs
url: /ru/net/chart-axis/
keywords:
- ось диаграммы
- вертикальная ось
- горизонтальная ось
- настроить ось
- управлять осью
- управление осью
- свойства оси
- максимальное значение
- минимальное значение
- линия оси
- формат даты
- заголовок оси
- позиция оси
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для .NET, чтобы настраивать оси диаграмм в презентациях PowerPoint для отчетов и визуализаций."
---

## **Получение максимальных значений на вертикальной оси диаграмм**
Aspose.Slides for .NET позволяет получать минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите доступ к первому слайду.
1. Добавьте диаграмму с данными по умолчанию.
1. Получите фактическое максимальное значение на оси.
1. Получите фактическое минимальное значение на оси.
1. Получите фактическую основную единицу измерения оси.
1. Получите фактическую вспомогательную единицу измерения оси.
1. Получите фактический масштаб основной единицы оси.
1. Получите фактический масштаб вспомогательной единицы оси.

Этот пример кода — реализация перечисленных шагов — показывает, как получить требуемые значения в C#:
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


## **Перемещение данных между осями**
Aspose.Slides позволяет быстро менять местами данные между осями — данные, отображаемые на вертикальной оси (y‑axis), перемещаются на горизонтальную ось (x‑axis) и наоборот.

Этот код на C# демонстрирует, как выполнить задачу перемещения данных между осями диаграммы:
```c#
 // Creates empty presentation
// Создает пустую презентацию
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Switches rows and columns
	//Переставляет строки и столбцы
	chart.ChartData.SwitchRowColumn();
		   
	// Saves presentation
	 // Сохраняет презентацию
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **Отключение вертикальной оси для линейных диаграмм**

Этот код на C# показывает, как скрыть вертикальную ось линейной диаграммы:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Отключение горизонтальной оси для линейных диаграмм**

Этот код показывает, как скрыть горизонтальную ось линейной диаграммы:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Изменение категории оси**

Используя свойство **CategoryAxisType**, вы можете указать предпочтительный тип категории оси (**date** или **text**). Этот код на C# демонстрирует операцию:
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


## **Установка формата даты для значения оси категории**
Aspose.Slides for .NET позволяет задавать формат даты для значения оси категории. Операция продемонстрирована в этом коде на C#:
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


## **Установка угла поворота заголовка оси диаграммы**
Aspose.Slides for .NET позволяет задавать угол поворота заголовка оси диаграммы. Этот код на C# демонстрирует операцию:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Установка позиции оси в категории или оси значений**
Aspose.Slides for .NET позволяет задать позицию оси в категории или оси значений. Этот код на C# показывает, как выполнить задачу:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **Включение подписи единицы измерения на оси значений диаграммы**
Aspose.Slides for .NET позволяет настроить диаграмму так, чтобы отображалась подпись единицы измерения на её оси значений. Этот код на C# демонстрирует операцию:
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

Оси предоставляют [настройку пересечения](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/): вы можете выбрать пересечение в нуле, в максимальном значении категории/значения или в определённом числовом значении. Это удобно для смещения оси X вверх или вниз или для выделения базовой линии.

**Как разместить подписи делений относительно оси (рядом, снаружи, внутри)?**

Установите [позицию подписи](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) в значение "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно на небольших диаграммах.