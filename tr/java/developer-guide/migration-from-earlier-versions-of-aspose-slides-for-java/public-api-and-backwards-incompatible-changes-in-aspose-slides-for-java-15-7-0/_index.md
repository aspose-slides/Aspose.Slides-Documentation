---
title: Aspose.Slides for Java 15.7.0'de Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyabilmek için Aspose.Slides for Java'daki genel API güncellemelerini ve geriye uyumsuz değişiklikleri inceleyin."
---
{{% alert color="info" %}} 
Bu sayfa, Aspose.Slides for Java 15.7.0 API'siyle tanıtılan eklenen veya kaldırılan sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Public API Değişiklikleri**
#### **Enum com.aspose.slides.ImagePixelFormat eklendi**
Enum com.aspose.slides.ImagePixelFormat, oluşturulan görüntüler için piksel formatı belirtmek amacıyla eklendi.
#### **com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() yöntemi eklendi**
Bu yöntem, seri indeksi, veri noktası indeksi, parentSeriesGroup, isColorVaried değerleri ve grafik stiline göre veri noktasının otomatik bir rengini döndürür. Bu renk, fillType NotDefined olduğunda varsayılan olarak kullanılır.
#### **Methods getPixelFormat(), setPixelFormat(int) com.aspose.slides.ITiffOptions'a eklendi**
Methods getPixelFormat(), setPixelFormat(/ImagePixelFormat/int) com.aspose.slides.ITiffOptions ve com.aspose.slides.TiffOptions'a, oluşturulan TIFF görüntüleri için piksel formatı belirtmek amacıyla eklendi.
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```