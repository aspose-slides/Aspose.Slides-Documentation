---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для .NET 16.1.0
type: docs
weight: 220
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) или [удаленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) классов, методов, свойств и так далее, а также других изменений, введенных в API Aspose.Slides для .NET 16.1.0.

{{% /alert %}} 
## **Изменения публичного API**


#### **Свойство RotationAngle добавлено в интерфейсы IChartTextBlockFormat и ITextFrameFormat**
Свойство RotationAngle было добавлено в интерфейсы Aspose.Slides.Charts.IChartTextBlockFormat и Aspose.Slides.ITextFrameFormat. 
Оно задает пользовательский угол поворота, который применяется к тексту в ограничивающем прямоугольнике.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Пользовательский заголовок").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException перемещен из Aspose.Slides.Odp в пространство имен Aspose.Slides**