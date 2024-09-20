---
title: Расчеты графиков
type: docs
weight: 50
url: /net/chart-calculations/
keywords: "Расчеты графиков, элементы графика, позиция элемента, значения графиков C#, Csharp, Aspose.Slides для .NET"
description: "Расчеты и значения графиков PowerPoint на C# или .NET"
---

## **Вычислить фактические значения элементов графика**
Aspose.Slides для .NET предоставляет простой API для получения этих свойств. Это поможет вам вычислить фактические значения элементов графика. Фактические значения включают позицию элементов, реализующих интерфейс IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) и фактические значения осей (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Сохранение презентации
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```



## **Вычислить фактическую позицию родительских элементов графика**
Aspose.Slides для .NET предоставляет простой API для получения этих свойств. Свойства IActualLayout предоставляют информацию о фактической позиции родительского элемента графика. Необходимо предварительно вызвать метод IChart.ValidateChartLayout(), чтобы заполнить свойства фактическими значениями.

```c#
// Создание пустой презентации
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```



## **Скрыть информацию из графика**
Эта тема поможет вам понять, как скрыть информацию из графика. Используя Aspose.Slides для .NET, вы можете скрыть **Заголовок, Вертикальную Ось, Горизонтальную Ось** и **Сеточные Линии** из графика. Ниже приведен пример кода, который демонстрирует, как использовать эти свойства.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Скрыть заголовок графика
    chart.HasTitle = false;

    ///Скрыть значения оси
    chart.Axes.VerticalAxis.IsVisible = false;

    // Видимость оси категории
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Скрыть легенду
    chart.HasLegend = false;

    //Скрыть основные сеточные линии
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Установить цвет линии серии
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```