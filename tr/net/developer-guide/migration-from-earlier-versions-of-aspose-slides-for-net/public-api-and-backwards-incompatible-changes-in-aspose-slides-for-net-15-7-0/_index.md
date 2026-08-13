---
title: Aspose.Slides for .NET 15.7.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 
Bu sayfa, Aspose.Slides for .NET 15.7.0 API'siyle tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **Enum ImagePixelFormat Eklendi**
Aspose.Slides.Export.ImagePixelFormat enum'u, oluşturulan görüntüler için piksel formatı belirtmek amacıyla eklendi.
#### **IChartDataPoint.GetAutomaticDataPointColor() Metodu Eklendi**
Seri indeksi, veri noktası indeksi, ParentSeriesGroup, IsColorVaried özelliği ve grafik stili temel alınarak bir veri noktasının otomatik rengini döndürür.  
FillType NotDefined olduğunda bu renk varsayılan olarak kullanılır.
#### **RenderToGraphics Metodu Slide sınıfına Eklendi**
Aspose.Slides.Slide sınıfına, bir slaytı Graphics nesnesine renderlemek için RenderToGraphics metodu (ve aşırı yüklemeleri) eklendi.
#### **PixelFormat Özelliği ITiffOptions ve TiffOptions'a Eklendi**
Aspose.Slides.Export.ITiffOptions ve Aspose.Slides.Export.TiffOptions sınıflarına, oluşturulan TIFF görüntüleri için piksel formatı belirtmek amacıyla PixelFormat özelliği eklendi.