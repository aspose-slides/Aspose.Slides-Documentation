---
title: Настройка точек данных в диаграммах Treemap и Sunburst в .NET
linktitle: Точки данных в диаграммах Treemap и Sunburst
type: docs
url: /ru/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- диаграмма treemap
- диаграмма sunburst
- точка данных
- цвет подписи
- цвет ветки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как управлять точками данных в диаграммах treemap и sunburst с помощью Aspose.Slides for .NET, совместимых с форматами PowerPoint."
---

Среди прочих типов диаграмм PowerPoint существуют два «иерархических» типа — **Treemap** и **Sunburst** (также известные как Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph или Multi Level Pie Chart). Эти диаграммы отображают иерархические данные, организованные в виде дерева — от листов к вершине ветви. Листья определяются точками данных серии, а каждый последующий вложенный уровень группировки определяется соответствующей категорией. Aspose.Slides for .NET позволяет форматировать точки данных диаграмм Sunburst и Treemap на C#.

Ниже приведён пример диаграммы Sunburst, где данные в столбце Series1 определяют листовые узлы, а остальные столбцы задают иерархические точки данных:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Начнём с добавления новой диаграммы Sunburst в презентацию:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="Смотрите также" %}} 
- [**Создание диаграммы Sunburst**](/slides/ru/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

Если необходимо форматировать точки данных диаграммы, следует использовать следующее:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) классы 
и свойство [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) 
предоставляют доступ к форматированию точек данных диаграмм Treemap и Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) 
используется для доступа к многоуровневым категориям — он представляет контейнер объектов 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel). 
По сути это оболочка для 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) с 
добавленными свойствами, специфичными для точек данных. 
Класс [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) имеет 
два свойства: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) и 
[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label), 
которые предоставляют доступ к соответствующим настройкам.

## **Показать значение точки данных**
Показать значение точки данных "Leaf 4":
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Установить подпись и цвет точки данных**
Установить подпись точки данных "Branch 1" так, чтобы отображалось имя серии ("Series1") вместо имени категории. Затем установить цвет текста в желтый:
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Установить цвет ветки точки данных**
Изменить цвет ветки "Stem 4":
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

## **FAQ**

**Могу ли я изменить порядок (сортировку) сегментов в Sunburst/Treemap?**

Нет. PowerPoint автоматически сортирует сегменты (обычно по убыванию значений по часовой стрелке). Aspose.Slides воспроизводит это поведение: изменить порядок напрямую нельзя; необходимо выполнить предварительную обработку данных.

**Как тема презентации влияет на цвета сегментов и подписей?**

Цвета диаграммы наследуют [тему/палитру](/slides/ru/net/presentation-theme/) презентации, если только вы явно не задаёте заливки/шрифты. Для согласованных результатов фиксируйте сплошные заливки и форматирование текста на необходимых уровнях.

**Сохранит ли экспорт в PDF/PNG пользовательские цвета ветвей и настройки подписей?**

Да. При экспорте презентации настройки диаграммы (заливки, подписи) сохраняются в выходных форматах, поскольку Aspose.Slides рендерит их с применённым форматированием.

**Могу ли я вычислить фактические координаты подписи/элемента для пользовательского размещения наложения поверх диаграммы?**

Да. После того как макет диаграммы проверен, свойства `ActualX`/`ActualY` доступны для элементов (например, для [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/)), что помогает точно позиционировать наложения.