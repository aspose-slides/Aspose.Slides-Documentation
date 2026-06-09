---
title: Aspose.Slides for Java 15.7.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.7.0 API'siyle tanıtılan eklenen [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) veya [kaldırılan](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) sınıflar, metodlar, özellikler vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
#### **Enum com.aspose.slides.ImagePixelFormat eklendi**
Enum com.aspose.slides.ImagePixelFormat, oluşturulan görseller için piksel biçimini belirtmek amacıyla eklendi.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() yöntemi eklendi**
Bu yöntem, serinin indeksi, veri noktası indeksi, parentSeriesGroup, isColorVaried değerleri ve grafik stili temelinde veri noktasının otomatik rengini döndürür. Bu renk, fillType NotDefined olduğunda varsayılan olarak kullanılır.
#### **Metotlar getPixelFormat(), setPixelFormat(int) com.aspose.slides.ITiffOptions'a eklendi**
Metotlar getPixelFormat(), setPixelFormat(/ImagePixelFormat/int), oluşturulan TIFF görselleri için piksel biçimini belirtmek amacıyla com.aspose.slides.ITiffOptions ve com.aspose.slides.TiffOptions sınıflarına eklendi.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```