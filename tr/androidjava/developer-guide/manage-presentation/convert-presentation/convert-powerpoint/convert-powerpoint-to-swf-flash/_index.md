---
title: PowerPoint Sunumlarını Android'de SWF Flash'e Dönüştür
linktitle: PowerPoint'tan SWF'ye
type: docs
weight: 80
url: /tr/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- slaytı dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan SWF'ye
- sunumdan SWF'ye
- slayttan SWF'ye
- PPT'den SWF'ye
- PPTX'ten SWF'ye
- PowerPoint'tan Flash'e
- sunumdan Flash'e
- slayttan Flash'e
- PPT'den Flash'e
- PPTX'ten Flash'e
- PPT'yi SWF olarak kaydet
- PPTX'i SWF olarak kaydet
- PPT'yi SWF'ye dışa aktar
- PPTX'i SWF'ye dışa aktar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Aspose.Slides ile Java’da PowerPoint (PPT/PPTX) dosyalarını SWF Flash’e dönüştürün. Adım adım kod örnekleri, hızlı kaliteli çıktı, PowerPoint otomasyonu gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını SWF'ye dönüştürmenin nasıl yapılacağını açıklar. Bir sunumu [Presentation.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemiyle SWF dosyası olarak kaydetmeyi ve dışa aktarmayı [SwfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/swfoptions/) ile, izleyici ayarları ve notlar ya da yorum düzeni dahil olmak üzere nasıl yapılandırılacağını gösterir.

## **PPT(X)'ı SWF'ye Dönüştür**
[Save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) yöntemi, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfı tarafından sunulan, tüm sunumu **SWF** belgesine dönüştürmek için kullanılabilir. Aşağıdaki örnek, [**SWFOptions**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/SwfOptions) sınıfı tarafından sağlanan seçenekleri kullanarak bir sunumu **SWF** belgesine nasıl dönüştüreceğinizi gösterir. Ayrıca, oluşturulan SWF'ye yorumları dahil etmek için [**ISWFOptions**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ISwfOptions) sınıfı ve [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) arayüzünü kullanabilirsiniz.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    SwfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Sunumu kaydetme
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Gizli slaytları SWF'ye dahil edebilir miyim?**

Evet. Gizli slaytları, [SwfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/swfoptions/) içindeki [setShowHiddenSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) yöntemiyle etkinleştirerek. Varsayılan olarak, gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve nihai SWF boyutunu nasıl kontrol edebilirim?**

Dosya boyutu ve görüntü kalitesini dengelemek için [setCompressed](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) yöntemini ve [adjust JPEG quality](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) ayarını kullanın.

**'setViewerIncluded' ne işe yarar ve ne zaman devre dışı bırakmalıyım?**

[setViewerIncluded](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) gömülü bir oynatıcı arayüzü (navigasyon kontrolleri, paneller, arama) ekler. Kendi oynatıcınızı kullanmayı planlıyorsanız veya UI olmadan çıplak bir SWF çerçevesine ihtiyacınız varsa devre dışı bırakın.

**Dışa aktarma makinesinde kaynak bir yazı tipi eksikse ne olur?**

Aspose.Slides, istem dışı bir yedeklemeyi önlemek için [SwfOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/swfoptions/) içindeki [setDefaultRegularFont](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) ile belirttiğiniz yazı tipini otomatik olarak ikame eder.