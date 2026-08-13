---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides для .NET 15.8.0
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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 
Эта страница перечисляет все добавленные или удалённые классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides для .NET 15.8.0.
{{% /alert %}} 
## **Изменения публичного API**
#### **Свойство DoughnutHoleSize было добавлено в IChartSeries и ChartSeries**
Указывает размер отверстия в кольцевой диаграмме.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}
```