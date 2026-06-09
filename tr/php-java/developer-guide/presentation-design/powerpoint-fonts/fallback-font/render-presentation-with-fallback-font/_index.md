---
title: PHP'de Yedek Yazı Tipleriyle Sunumları Renderleme
linktitle: Sunumları Renderle
type: docs
weight: 30
url: /tr/php-java/render-presentation-with-fallback-font/
keywords:
- yedek yazı tipi
- PowerPoint renderleme
- sunum renderleme
- slayt renderleme
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP'de Java aracılığıyla yedek yazı tipleriyle sunumları renderleyin – adım adım kod örnekleriyle PPT, PPTX ve ODP arasında metnin tutarlı kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, yedek yazı tipi kurallarını kullanarak sunumları renderlemenizi sağlar. Bu makale, bir yedek yazı tipi kural koleksiyonu oluşturma, kuralları yedek yazı tiplerini kaldırarak veya ekleyerek değiştirme ve koleksiyonu `FontsManager::setFontFallBackRulesCollection` yöntemine atama işlemlerini gösterir.

Yedek yazı tipi kurallar koleksiyonu sunumun `FontsManager`'ına atandıktan sonra, kurallar kaydetme, renderleme ve sunumu dönüştürme gibi işlemler sırasında uygulanır. Örnek, bir slayt küçük resmini renderlerken ve PNG görüntüsü olarak kaydederken yapılandırılmış kuralların nasıl kullanılacağını gösterir.

## **Yedek Yazı Tipi Kurallarıyla Bir Slaytı Renderleme**

1. Biz [yedek yazı tipi kurallar koleksiyonu oluşturuyoruz](/slides/tr/php-java/create-fallback-fonts-collection/).
2. [Remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) bir yedek yazı tipi kuralını kaldırır ve [addFallBackFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) başka bir kurala ekler.
3. Kurallar koleksiyonunu [getFontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) yöntemine ayarlayın.
4. [Presentation.save](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#save-java.lang.String-int-) yöntemiyle sunumu aynı formatta kaydedebilir veya başka bir formatta kaydedebiliriz. Yedek yazı tipi kurallar koleksiyonu [FontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontsManager)'a ayarlandıktan sonra, bu kurallar sunum üzerindeki tüm işlemler sırasında uygulanır: kaydetme, renderleme, dönüştürme vb.

```php
  # Yeni bir kural koleksiyonu örneği oluştur
  $rulesList = new FontFallBackRulesCollection();
  # bir dizi kural oluştur
  $rulesList->add(new FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
  foreach($rulesList as $fallBackRule) {
    # Yüklenen kurallardan Yedek Yazı Tipi "Tahoma"'yı kaldırmaya çalışılıyor
    $fallBackRule->remove("Tahoma");
    # Ve belirtilen aralık için kuralları güncellemeye
    if (java_values($fallBackRule->getRangeEndIndex()) >= 0x4000 && java_values($fallBackRule->getRangeStartIndex()) < 0x5000) {
      $fallBackRule->addFallBackFonts("Verdana");
    }
  }
  # Ayrıca listeden mevcut kuralları kaldırabiliriz
  if (java_values($rulesList->size()) > 0) {
    $rulesList->remove($rulesList->get_Item(0));
  }
  $pres = new Presentation("input.pptx");
  try {
    # Kullanım için hazırlanmış kural listesini atama
    $pres->getFontsManager()->setFontFallBackRulesCollection($rulesList);
    # Başlatılmış kural koleksiyonu kullanılarak thumbnail renderleme ve JPEG olarak kaydetme
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Görüntüyü JPEG formatında diske kaydet
    try {
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
[PHP'de PPT ve PPTX'i JPG'ye Dönüştürme](/slides/tr/php-java/convert-powerpoint-to-jpg/) hakkında daha fazla bilgi edinin.
{{% /alert %}}