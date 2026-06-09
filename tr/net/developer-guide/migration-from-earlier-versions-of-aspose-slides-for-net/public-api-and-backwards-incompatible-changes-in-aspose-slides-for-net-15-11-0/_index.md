---
title: Aspose.Slides for .NET 15.11.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma yaratan değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 15.11.0 API'siyle tanıtılan eklenmiş veya kaldırılmış sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler. [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) sınıflar vb.

{{% /alert %}} 
## **Public API Değişiklikleri**

#### **DataLabelCollection Sınıfındaki Eski Özellikler Silindi**
Obsolete properties in DataLabelCollection class have been deleted:
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

#### **Presentation Sınıfına Yeni FirstSlideNumber Özelliği Eklendi**
The new property FirstSlideNumber added to Presentation allows to get or to set the number of first slide in a presentation.

When a new FirstSlideNumber value is specified all slide numbers are recalculated.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```