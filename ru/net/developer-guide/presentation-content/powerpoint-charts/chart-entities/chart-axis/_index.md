---
title: Ось диаграммы
type: docs
url: /ru/net/chart-axis/
keywords: "Ось диаграммы PowerPoint, Диаграммы презентаций, C#, .NET, Управление осью диаграммы, Данные диаграммы"
description: "Редактировать ось диаграммы PowerPoint на C# или .NET"
---

## **Получение максимальных значений на вертикальной оси диаграмм**
Aspose.Slides для .NET позволяет получить минимальные и максимальные значения на вертикальной оси. Перейдите к этим шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите доступ к первому слайду.
3. Добавьте диаграмму с данными по умолчанию.
4. Получите фактическое максимальное значение на оси.
5. Получите фактическое минимальное значение на оси.
6. Получите фактическую основную единицу оси.
7. Получите фактическую вспомогательную единицу оси.
8. Получите фактический масштаб основной единицы оси.
9. Получите фактический масштаб вспомогательной единицы оси.

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


## **Перемещение данных между осями**
Aspose.Slides позволяет быстро поменять местами данные между осями — данные, отображаемые на вертикальной оси (y‑axis), перемещаются на горизонтальную ось (x‑axis) и наоборот. 

Этот код на C# показывает, как выполнить задачу обмена данными между осями на диаграмме:
```c#
// Создает пустую презентацию
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Переключает строки и столбцы
	chart.ChartData.SwitchRowColumn();
		   
	// Сохраняет презентацию
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```


## **Отключение вертикальной оси для линейных диаграмм**

Этот код на C# показывает, как скрыть вертикальную ось для линейной диаграммы:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Отключение горизонтальной оси для линейных диаграмм**

Этот код показывает, как скрыть горизонтальную ось для линейной диаграммы:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Изменение оси категорий**

Используя свойство **CategoryAxisType**, вы можете указать предпочитаемый тип оси категорий (**date** или **text**). Этот код на C# демонстрирует операцию: 
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


## **Установка формата даты для значения оси категорий**
Aspose.Slides для .NET позволяет задать формат даты для значения оси категорий. Операция демонстрируется в этом коде на C#:
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


## **Установка угла вращения заголовка оси диаграммы**
Aspose.Slides для .NET позволяет задать угол вращения заголовка оси диаграммы. Этот код на C# демонстрирует операцию:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Установка позиции оси в оси категорий или значений**
Aspose.Slides для .NET позволяет задать позицию оси в оси категорий или значений. Этот код на C# показывает, как выполнить задачу:
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **Включение отображения единицы измерения на оси значений диаграммы**
Aspose.Slides для .NET позволяет настроить диаграмму для отображения метки единицы измерения на её оси значений. Этот код на C# демонстрирует операцию:
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **Часто задаваемые вопросы**

**Как задать значение, при котором одна ось пересекает другую (пересечение осей)?**

Оси предоставляют [настройку пересечения](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/): вы можете выбрать пересечение на нуле, на максимальном значении категории/значения или в конкретном числовом значении. Это полезно для смещения оси X вверх или вниз или для выделения базовой линии.

**Как можно разместить метки делений относительно оси (вбок, снаружи, внутри)?**

Установите [позицию метки](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) в значение "cross", "outside" или "inside". Это влияет на читаемость и помогает экономить место, особенно в небольших диаграммах.