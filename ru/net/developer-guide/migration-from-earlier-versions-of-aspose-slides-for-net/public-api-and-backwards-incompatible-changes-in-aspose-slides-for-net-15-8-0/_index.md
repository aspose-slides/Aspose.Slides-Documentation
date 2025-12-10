---
title: Общедоступный API и обратные несовместимые изменения в Aspose.Slides для .NET 15.8.0
linktitle: Aspose.Slides для .NET 15.8.0
type: docs
weight: 190
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
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
description: "Обзор обновлений общедоступного API и разрывных изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) классы, методы, свойства и т.п., а также другие изменения, введённые в API Aspose.Slides for .NET 15.8.0.

{{% /alert %}} 
## **Public API Changes**
#### **Property DoughnutHoleSize Has Been Added to IChartSeries and ChartSeries**
Задает размер отверстия в кольцевой диаграмме.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```