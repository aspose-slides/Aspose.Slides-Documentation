---
title: PowerPoint Sunumlarını JavaScript'te SWF Flash'e Dönüştür
linktitle: PowerPoint'tan SWF'ye
type: docs
weight: 80
url: /tr/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint dönüştür
- sunum dönüştür
- slayt dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'tan SWF'ye
- sunumdan SWF'ye
- slayttan SWF'ye
- PPT'den SWF'ye
- PPTX'ten SWF'ye
- PowerPoint'tan Flash'a
- sunumdan Flash'a
- slayttan Flash'a
- PPT'den Flash'a
- PPTX'ten Flash'a
- PPT'yi SWF olarak kaydet
- PPTX'i SWF olarak kaydet
- PPT'yi SWF'ye dışa aktar
- PPTX'i SWF'ye dışa aktar
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PowerPoint (PPT/PPTX) dosyalarını SWF Flash formatına dönüştürün. Adım adım kod örnekleri, hızlı ve kaliteli çıktı, PowerPoint otomasyonu olmadan."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını SWF'ye dönüştürmeyi açıklar. Sunumu [Presentation.save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/#save) yöntemiyle bir SWF dosyası olarak kaydetmeyi ve [SwfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/swfoptions/) ile dışa aktarmayı, görüntüleyici ayarları ile notlar veya yorum düzenini nasıl yapılandıracağınızı gösterir.

## **PPT(X)'i SWF'ye Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfı tarafından sunulan [save](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) yöntemi, tüm sunumu **SWF** belgesine dönüştürmek için kullanılabilir. Aşağıdaki örnek, **SWFOptions** ([**SWFOptions**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SwfOptions)) sınıfı tarafından sağlanan seçenekleri kullanarak bir sunumu **SWF** belgesine nasıl dönüştüreceğinizi gösterir. Ayrıca, oluşturulan SWF içinde yorumları dahil etmek için **SWFOptions** sınıfı ve [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) sınıfını kullanabilirsiniz.

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Sunumu kaydetme
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**SWF'de gizli slaytları dahil edebilir miyim?**

Evet. [SwfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/swfoptions/) içinde bulunan [setShowHiddenSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) yöntemini kullanın. Varsayılan olarak gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve nihai SWF boyutunu nasıl kontrol edebilirim?**

Dosya boyutu ve görüntü kalitesini dengelemek için [setCompressed](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/swfoptions/setcompressed/) ve [setJpegQuality](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/swfoptions/setjpegquality/) yöntemlerini kullanın.

**'setViewerIncluded' ne amaçla kullanılır ve ne zaman kullanılmalıdır?**

[setViewerIncluded](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) gömülü bir oynatıcı UI'sı (navigasyon kontrolleri, paneller, arama) ekler. Kendi oynatıcınızı kullanmayı planlıyorsanız ya da UI'siz sade bir SWF çerçevesine ihtiyacınız varsa bunu kullanın.

**Kaynak font dışa aktarma makinesinde eksikse ne olur?**

Aspose.Slides, [SwfOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/swfoptions/) içinde [setDefaultRegularFont](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) yöntemiyle belirttiğiniz fontu, eksik olduğunda otomatik olarak başka bir fontla değiştirir ve istenmeyen bir yedekleme oluşmasını önler.