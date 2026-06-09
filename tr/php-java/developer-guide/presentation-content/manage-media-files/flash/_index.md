---
title: PHP'de Sunumlardan Flash Nesnelerini Çıkarma
linktitle: Flash
type: docs
weight: 10
url: /tr/php-java/flash/
keywords:
- flash çıkar
- flash nesnesi
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument slaytlarından Flash nesnelerini çıkarmayı, tam kod örnekleri ve en iyi uygulamaları öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunumlardan Flash nesnelerini nasıl çıkaracağınızı açıklar. Bir slaydın kontrol koleksiyonunda ad ile bir Flash denetimini bulmayı ve gömülü SWF nesne verileriyle çalışmayı gösterir.

## **Sunumlardan Flash Nesnelerini Çıkarma**

Aspose.Slides for PHP via Java, bir sunumdan flash nesnelerini çıkarmak için bir özellik sağlar. Flash denetimine ad ile erişebilir ve sunumdan çıkararak SWF nesne verilerini depolamayı da içerir.

```php
  # PPTX'i temsil eden Presentation sınıfını örnekleyin
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Flash içeriği çıkarılırken hangi sunum formatları desteklenir?**

[Aspose.Slides destekler](/slides/tr/php-java/supported-file-formats/) PPT ve PPTX gibi ana PowerPoint formatlarını, çünkü bu kapsayıcıları yükleyebilir ve kontrol koleksiyonlarına erişebilir, Flash ile ilgili ActiveX öğelerini de içerebilir.

**Flash içeren bir sunumu HTML5'e dönüştürüp Flash etkileşimini koruyabilir miyim?**

Hayır. Aspose.Slides, SWF içeriğini çalıştırmaz veya etkileşimini dönüştürmez. [HTML](/slides/tr/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/tr/php-java/export-to-html5/) dışa aktarımı desteklenirken, Flash modern tarayıcılarda destek sonu nedeniyle çalışmaz. Önerilen yol, dışa aktarmadan önce Flash'ı video veya HTML5 animasyonları gibi alternatiflerle değiştirmektir.

**Güvenlik açısından, Aspose.Slides bir sunumu okurken SWF dosyalarını çalıştırıyor mu?**

Hayır. Aspose.Slides, Flash'ı dosyada gömülü ikili veri olarak kabul eder ve işleme sırasında SWF içeriğini çalıştırmaz.

**OLE aracılığıyla diğer gömülü dosyalarla birlikte Flash içeren sunumları nasıl ele almalıyım?**

Aspose.Slides, [gömülü OLE nesnelerinin çıkarılmasını](/slides/tr/php-java/manage-ole/) destekler, böylece Flash denetimlerini ve diğer OLE‑gömülü belgeleri birlikte tek bir adımda işleyerek tüm ilgili gömülü içerikleri işleyebilirsiniz.