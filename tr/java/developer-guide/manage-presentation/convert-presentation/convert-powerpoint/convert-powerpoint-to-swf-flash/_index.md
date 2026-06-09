---
title: PowerPoint Sunumlarını Java'da SWF Flash'e Dönüştür
linktitle: PowerPoint'tan SWF'e
type: docs
weight: 80
url: /tr/java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan SWF'e
- sunumdan SWF'e
- slayttan SWF'e
- PPT'den SWF'e
- PPTX'ten SWF'e
- PowerPoint'tan Flash'e
- sunumdan Flash'e
- slayttan Flash'e
- PPT'den Flash'e
- PPTX'ten Flash'e
- PPT'yi SWF olarak kaydet
- PPTX'i SWF olarak kaydet
- PPT'yi SWF'ye aktar
- PPTX'i SWF'ye aktar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides ile Java'da PowerPoint (PPT/PPTX) dosyalarını SWF Flash'e dönüştürün. Adım adım kod örnekleri, hızlı ve kaliteli çıktı, PowerPoint otomasyonu yok."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını SWF'ye nasıl dönüştüreceğinizi açıklar. Sunumu bir SWF dosyası olarak kaydetmek için [Presentation.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemini ve izleyici ayarları ile notlar veya yorumların düzenini içeren dışa aktarmayı [SwfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/swfoptions/) ile nasıl yapılandıracağınızı gösterir.

## **Sunumları Flash'a Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfı tarafından sunulan [save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemi, tüm sunumu **SWF** belgesine dönüştürmek için kullanılabilir. Aşağıdaki örnek, [**SWFOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/SwfOptions) sınıfı tarafından sağlanan seçeneklerle bir sunumu **SWF** belgesine nasıl dönüştüreceğinizi gösterir. Ayrıca, oluşturulan SWF'e yorumları eklemek için [**ISWFOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ISwfOptions) sınıfı ve [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/INotesCommentsLayoutingOptions) arayüzü kullanılabilir.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Sunumu kaydetme
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Gizli slaytları SWF'ye dahil edebilir miyim?**

Evet. Gizli slaytları, [setShowHiddenSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) yöntemini [SwfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/swfoptions/) içinde etkinleştirerek dahil edebilirsiniz. Varsayılan olarak gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve nihai SWF boyutunu nasıl kontrol edebilirim?**

Dosya boyutu ile görüntü kalitesini dengelemek için [setCompressed](https://reference.aspose.com/slides/tr/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) yöntemini ve JPEG kalitesini [adjust JPEG quality](https://reference.aspose.com/slides/tr/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) ayarlayın.

**'setViewerIncluded' ne işe yarar ve ne zaman devre dışı bırakılmalıdır?**

[setViewerIncluded](https://reference.aspose.com/slides/tr/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) gömülü bir oynatıcı arayüzü (navigasyon kontrolleri, paneller, arama) ekler. Kendi oynatıcınızı kullanacaksanız veya UI olmadan sade bir SWF çerçevesine ihtiyacınız varsa bunu devre dışı bırakın.

**İhracat makinesinde kaynak bir yazı tipi eksik olursa ne olur?**

Aspose.Slides, [SwfOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/swfoptions/) içindeki [setDefaultRegularFont](https://reference.aspose.com/slides/tr/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) yöntemiyle belirttiğiniz yazı tipini kullanarak istenmeyen bir yedekleme oluşmasını önler.