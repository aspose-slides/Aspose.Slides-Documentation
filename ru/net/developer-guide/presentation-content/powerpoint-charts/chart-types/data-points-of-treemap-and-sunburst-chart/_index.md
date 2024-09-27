---
title: Точки данных диаграммы "Карта дерева" и "Солнечный луч"
type: docs
url: /ru/net/data-points-of-treemap-and-sunburst-chart/
keywords: "Диаграмма солнечного луча, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте диаграмму солнечного луча в презентацию PowerPoint на C# или .NET"
---

Среди других типов диаграмм PowerPoint есть два "иерархических" типа - **Карта дерева** и **Солнечный луч** (также известный как График солнечного луча, Диаграмма солнечного луча, Радиальная диаграмма, Радиальный график или Многоуровневая круговая диаграмма). Эти диаграммы отображают иерархические данные, организованные в виде дерева - от листьев до顶端 ветки. Листья определяются данными серий, а каждая последующая вложенная группа определяется соответствующей категорией. Aspose.Slides для .NET позволяет форматировать точки данных диаграммы солнечного луча и карты дерева на C#.

Вот диаграмма солнечного луча, где данные в столбце Series1 определяют листовые узлы, в то время как другие столбцы определяют иерархические точки данных:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Давайте начнем с добавления новой диаграммы солнечного луча в презентацию:



```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="Смотрите также" %}} 
- [**Создание диаграммы солнечного луча**](/slides/ru/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}


Если необходимо отформатировать точки данных диаграммы, следует использовать следующее:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) классы 
и [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) свойство 
обеспечивают доступ к форматированию точек данных диаграмм карта дерева и солнечный луч. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
используется для доступа к многослойным категориям - он представляет контейнер для 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) объектов. 
По сути, это обертка для 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) с 
свойствами, добавленными, специфичными для точек данных. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) класс имеет 
два свойства: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) и 
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label), которые 
обеспечивают доступ к соответствующим настройкам.
## **Показать значение точки данных**
Показать значение точки данных "Лист 4":



```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)
## **Задать метку и цвет точки данных**
Задать метку данных "Ветка 1", чтобы показать название серии ("Series1") вместо имени категории. Затем установить цвет текста на желтый:



```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)
## **Задать цвет точки данных для ветки**
Изменить цвет ветки "С Stem 4":


```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)
