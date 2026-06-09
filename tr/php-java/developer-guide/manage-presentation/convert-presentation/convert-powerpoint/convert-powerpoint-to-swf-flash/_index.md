---
title: PowerPoint Sunumlarını PHP'de SWF Flash'e Dönüştürme
linktitle: PowerPoint'tan SWF'ye
type: docs
weight: 80
url: /tr/php-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint dönüştürme
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
- PPT'yi SWF'ye aktar
- PPTX'i SWF'ye aktar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) dosyalarını PHP'de Aspose.Slides ile SWF Flash formatına dönüştürün. Adım adım kod örnekleri, hızlı ve kaliteli çıktı, PowerPoint otomasyonu gerekmez."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını SWF'ye nasıl dönüştüreceğinizi açıklar. Sunumu bir SWF dosyası olarak kaydetmek için [Presentation::save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/save/) yöntemini ve ihracatı [SwfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/) ile nasıl yapılandıracağınızı, izleyici ayarları ve notlar ya da yorumlar düzeni dahil olmak üzere gösterir.

## **Sunumları Flash'e Dönüştür**

[Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfı tarafından sunulan [save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/save/) yöntemi, tüm sunumu bir **SWF** belgesine dönüştürmek için kullanılabilir. Aşağıdaki örnek, [SWFOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/) sınıfı tarafından sağlanan seçenekleri kullanarak bir sunumu **SWF** belgesine nasıl dönüştüreceğinizi gösterir. Ayrıca, oluşturulan SWF'ye yorumları eklemek için [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/notescommentslayoutingoptions/) sınıfını da kullanabilirsiniz.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Sunumu kaydetme
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**SWF'de gizli slaytları ekleyebilir miyim?**

Evet. Gizli slaytları [setShowHiddenSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/setshowhiddenslides/) yöntemiyle [SwfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/) içinde etkinleştirin. Varsayılan olarak, gizli slaytlar dışa aktarılmaz.

**Sıkıştırmayı ve nihai SWF boyutunu nasıl kontrol edebilirim?**

Dosya boyutu ve görüntü kalitesini dengelemek için [setCompressed](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/setcompressed/) yöntemini ve [JPEG kalitesini ayarlamayı](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/setjpegquality/) kullanın.

**'setViewerIncluded' ne işe yarar ve ne zaman devre dışı bırakılmalıdır?**

[setViewerIncluded](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/setviewerincluded/) gömülü bir oynatıcı UI'si (navigasyon kontrolleri, paneller, arama) ekler. Kendi oynatıcınızı kullanmayı planlıyorsanız veya UI olmadan sade bir SWF çerçevesine ihtiyacınız varsa devre dışı bırakın.

**Dışa aktarma makinesinde bir kaynak yazı tipi eksik olursa ne olur?**

Aspose.Slides, istenmeyen bir yedekleme olmasını önlemek için [SwfOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/swfoptions/) içindeki [setDefaultRegularFont](https://reference.aspose.com/slides/tr/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) yöntemiyle belirttiğiniz yazı tipini yerine koyacaktır.