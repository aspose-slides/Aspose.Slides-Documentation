---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 16.1.0
linktitle: Aspose.Slides для .NET 16.1.0
type: docs
weight: 220
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) классы, методы, свойства и т. д., а также другие изменения, внесённые в API Aspose.Slides for .NET 16.1.0.

{{% /alert %}} 
## **Изменения публичного API**


#### **Свойство RotationAngle добавлено в интерфейсы IChartTextBlockFormat и ITextFrameFormat**
Свойство RotationAngle добавлено в интерфейсы Aspose.Slides.Charts.IChartTextBlockFormat и Aspose.Slides.ITextFrameFormat.  
Оно задаёт пользовательский угол вращения, применяемый к тексту внутри ограничивающего прямоугольника.

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException перемещён из пространства имён Aspose.Slides.Odp в пространство имён Aspose.Slides**