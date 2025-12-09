---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides для .NET 15.11.0
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
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) или [удалённых](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) классов, методов, свойств и т.д., а также других изменений, введённых в API Aspose.Slides for .NET 15.11.0.

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

#### **В класс Presentation добавлено новое свойство FirstSlideNumber**
Новое свойство FirstSlideNumber, добавленное в Presentation, позволяет получить или установить номер первой слайды в презентации.

При указании нового значения FirstSlideNumber нумерация всех слайдов пересчитывается.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```