---
title: Область построения графика
type: docs
url: /net/chart-plot-area/
keywords: "Область построения графика Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Получите ширину, высоту области построения графика. Установите режим компоновки. Презентация PowerPoint на C# или .NET"
---

## **Получить ширину, высоту области построения графика**
Aspose.Slides для .NET предоставляет простой API для. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Получите доступ к первому слайду.
1. Добавьте график с умолчаниями.
1. Вызовите метод IChart.ValidateChartLayout() перед получением актуальных значений.
1. Получите фактическое положение X (слева) элемента графика относительно левого верхнего угла графика.
1. Получите фактическую верхнюю границу элемента графика относительно левого верхнего угла графика.
1. Получите фактическую ширину элемента графика.
1. Получите фактическую высоту элемента графика.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Сохранить презентацию с графиком
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Установить режим компоновки области построения графика**
Aspose.Slides для .NET предоставляет простой API для установки режима компоновки области построения графика. Свойство **LayoutTargetType** было добавлено в классы **ChartPlotArea** и **IChartPlotArea**. Если компоновка области построения определена вручную, это свойство указывает, следует ли располагать область построения внутри (не включая оси и подписи к осям) или снаружи (включая оси и подписи к осям). Существует два возможных значения, определённых в перечислении **LayoutTargetType**.

- **LayoutTargetType.Inner** - указывает, что размер области построения будет определять размер области построения, не включая метки и подписи к осям.
- **LayoutTargetType.Outer** - указывает, что размер области построения будет определять размер области построения, меток и подписей к осям.

Пример кода приведён ниже.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```