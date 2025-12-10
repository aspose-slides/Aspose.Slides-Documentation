---
title: Оптимизация вычислений диаграмм для презентаций в .NET
linktitle: Вычисления диаграмм
type: docs
weight: 50
url: /ru/net/chart-calculations/
keywords:
- вычисления диаграмм
- элементы диаграммы
- позиция элемента
- фактическая позиция
- дочерний элемент
- родительский элемент
- значения диаграммы
- фактическое значение
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Поймите вычисления диаграмм, обновление данных и контроль точности в Aspose.Slides for .NET для PPT и PPTX, с практическими примерами кода на C#."
---

## **Вычисление фактических значений элементов диаграммы**
Aspose.Slides for .NET предоставляет простой API для получения этих свойств. Это поможет вам вычислить фактические значения элементов диаграммы. Фактические значения включают положение элементов, реализующих интерфейс IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight), а также фактические значения осей (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
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




## **Вычисление фактической позиции родительских элементов диаграммы**
Aspose.Slides for .NET предоставляет простой API для получения этих свойств. Свойства IActualLayout предоставляют информацию о фактической позиции родительского элемента диаграммы. Необходимо предварительно вызвать метод IChart.ValidateChartLayout(), чтобы заполнить свойства фактическими значениями.
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




## **Скрытие элементов диаграммы**
Эта тема помогает понять, как скрыть информацию в диаграмме. С помощью Aspose.Slides for .NET вы можете скрыть **Заголовок, Вертикальную ось, Горизонтальную ось** и **Линии сетки** в диаграмме. Приведённый ниже пример кода показывает, как использовать эти свойства.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Скрытие заголовка диаграммы
    chart.HasTitle = false;

    ///Скрытие оси значений
    chart.Axes.VerticalAxis.IsVisible = false;

    //Видимость оси категорий
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Скрытие легенды
    chart.HasLegend = false;

    //Скрытие основных линий сетки
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Установка цвета линии серии
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **Часто задаваемые вопросы**

**Работают ли внешние книги Excel в качестве источника данных и как это влияет на пересчёт?**

Да. Диаграмма может ссылаться на внешнюю книгу: при подключении или обновлении внешнего источника формулы и значения берутся из этой книги, и диаграмма отражает изменения во время операций открытия/редактирования. API позволяет вам [указать путь к внешней книге](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) и управлять связанными данными.

**Могу ли я вычислять и отображать линии тренда без самостоятельной реализации регрессии?**

Да. [Линии тренда](/slides/ru/net/trend-line/) (линейные, экспоненциальные и другие) добавляются и обновляются Aspose.Slides; их параметры автоматически пересчитываются на основе данных серии, поэтому вам не нужно реализовывать собственные расчёты.

**Если презентация содержит несколько диаграмм со внешними ссылками, могу ли я управлять тем, какую книгу каждый график использует для вычисленных значений?**

Да. Каждая диаграмма может указывать на свою собственную [внешнюю книгу](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/), либо вы можете создавать/заменять внешнюю книгу для каждой диаграммы независимо от остальных.