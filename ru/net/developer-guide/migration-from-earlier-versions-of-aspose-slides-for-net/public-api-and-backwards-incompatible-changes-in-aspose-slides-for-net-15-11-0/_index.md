---
title: Публичный API и изменения, несовместимые с прошлой версией в Aspose.Slides для .NET 15.11.0
type: docs
weight: 210
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
---

{{% alert color="primary" %}} 

На этой странице перечислены все [добавленные](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) или [удаленные](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) классы, методы, свойства и другие изменения, введенные в API Aspose.Slides для .NET 15.11.0.

{{% /alert %}} 
## **Изменения публичного API**

#### **Устаревшие свойства в классе DataLabelCollection были удалены**
Устаревшие свойства в классе DataLabelCollection были удалены:
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
Новое свойство FirstSlideNumber, добавленное в класс Presentation, позволяет получать или устанавливать номер первого слайда в презентации.

Когда указывается новое значение FirstSlideNumber, все номера слайдов пересчитываются.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

``` 