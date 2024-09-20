---
title: Ось графика
type: docs
url: /net/chart-axis/
keywords: "Ось графика PowerPoint, Презентационные графики, C#, .NET, Манипуляция осью графика, Данные графика"
description: "Редактирование оси графика PowerPoint на C# или .NET"
---


## **Получение максимальных значений на вертикальной оси графиков**
Aspose.Slides для .NET позволяет вам получать минимальные и максимальные значения на вертикальной оси. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите доступ к первому слайду.
1. Добавьте график с данными по умолчанию.
1. Получите фактическое максимальное значение на оси.
1. Получите фактическое минимальное значение на оси.
1. Получите фактический основной интервал оси.
1. Получите фактический вспомогательный интервал оси.
1. Получите фактическую шкалу основного интервала оси.
1. Получите фактическую шкалу вспомогательного интервала оси.

Этот пример кода — реализация вышеуказанных шагов — показывает, как получить необходимые значения на C#:

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


## **Обмен данными между осями**
Aspose.Slides позволяет вам быстро обмениваться данными между осями — данные, представленные на вертикальной оси (ось Y), перемещаются на горизонтальную ось (ось X) и наоборот.

Этот код на C# показывает, как выполнить задачу обмена данными между осями на графике:

```c#
// Создает пустую презентацию
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Меняет строки и столбцы местами
	chart.ChartData.SwitchRowColumn();
		   
	// Сохраняет презентацию
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Отключение вертикальной оси для линейных графиков**

Этот код на C# показывает, как скрыть вертикальную ось для линейного графика:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Отключение горизонтальной оси для линейных графиков**

Этот код показывает, как скрыть горизонтальную ось для линейного графика:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Изменение категории оси**

Используя свойство **CategoryAxisType**, вы можете указать предпочитаемый тип категории оси (**дата** или **текст**). Этот код на C# демонстрирует операцию:

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
Aspose.Slides для .NET позволяет вам установить формат даты для значения оси категории. Эта операция демонстрируется в следующем коде на C#:

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

## **Установка угла поворота для заголовка оси графика**
Aspose.Slides для .NET позволяет вам установить угол поворота для заголовка оси графика. Этот код на C# демонстрирует операцию:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Установка оси позиции в категории или значении оси**
Aspose.Slides для .NET позволяет вам установить ось позиции в категории или значении оси. Этот код на C# показывает, как выполнить задачу:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Включение метки единицы отображения на оси значения графика**
Aspose.Slides для .NET позволяет вам настроить график для отображения метки единицы на своей оси значения графика. Этот код на C# демонстрирует операцию:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```