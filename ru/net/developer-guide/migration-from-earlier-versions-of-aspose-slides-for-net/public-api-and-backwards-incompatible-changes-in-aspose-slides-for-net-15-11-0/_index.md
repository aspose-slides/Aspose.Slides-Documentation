---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.11.0
linktitle: Aspose.Slides для .NET 15.11.0
type: docs
weight: 210
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать решения по работе с презентациями PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в Aspose.Slides for .NET 15.11.0 API.

{{% /alert %}} 
## **Изменения публичного API**

#### **Устаревшие свойства в классе DataLabelCollection удалены**
Устаревшие свойства в классе DataLabelCollection удалены:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Новое свойство FirstSlideNumber было добавлено в класс Presentation**
Новое свойство FirstSlideNumber, добавленное в Presentation, позволяет получить или задать номер первого слайда в презентации.

Когда задаётся новое значение FirstSlideNumber, номера всех слайдов пересчитываются.

``` csharp
 using(var pres = new Presenation(path))
{
  int firstSlideNumber = pres.FirstSlideNumber;
  pres.FirstSlideNumber = 10;
  pres.Save(newPath, SaveFormat.Pptx);
}
```