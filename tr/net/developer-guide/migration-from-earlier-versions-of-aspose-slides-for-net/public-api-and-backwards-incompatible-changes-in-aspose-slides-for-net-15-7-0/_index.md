---
title: Aspose.Slides for .NET 15.7.0'de Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 15.7.0 API'siyle tanıtılan [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) veya [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **Enum ImagePixelFormat Eklendi**
Oluşturulan görseller için piksel formatını belirtmek amacıyla Aspose.Slides.Export.ImagePixelFormat enum'u eklendi.
#### **IChartDataPoint.GetAutomaticDataPointColor() Metodu Eklendi**
Seri indeksi, veri noktası indeksi, ParentSeriesGroup, IsColorVaried özelliği ve grafik stili temelinde veri noktasının otomatik rengini döndürür.
FillType NotDefined olduğunda bu renk varsayılan olarak kullanılır.
#### **RenderToGraphics Metodu Slide'a Eklendi**
Aspose.Slides.Slide içinde bir slaytı Graphics nesnesine renderlemek için RenderToGraphics metodu (ve aşırı yüklemeleri) eklendi.
#### **PixelFormat Özelliği ITiffOptions ve TiffOptions'a Eklendi**
Oluşturulan TIFF görselleri için piksel formatı belirtmek amacıyla Aspose.Slides.Export.ITiffOptions ve Aspose.Slides.Export.TiffOptions sınıflarına PixelFormat özelliği eklendi.