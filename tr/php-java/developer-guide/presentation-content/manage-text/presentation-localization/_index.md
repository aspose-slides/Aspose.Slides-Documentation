---
title: PHP'de Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/php-java/presentation-localization/
keywords:
- dili değiştir
- yazım denetimi
- dil kimliği
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides kullanarak PowerPoint ve OpenDocument slayt yerelleştirmesini otomatikleştirin, pratik kod örnekleri ve ipuçlarıyla daha hızlı küresel dağıtım sağlayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak bir sunumdaki metnin `LanguageId` değerini nasıl ayarlayacağınızı açıklar. Sunumu nasıl açacağınızı, metin içeren bir şekil ekleyeceğinizi, bir metin bölümüne dil tanımlayıcısı atayacağınızı ve sonucu PPTX dosyası olarak kaydedeceğinizi gösterir.

## **Sunum ve Şekil Metni İçin Dili Değiştirme**
- Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
- Bir slaytın referansını, indeksini kullanarak alın.
- Slayta, [Rectangle](https://reference.aspose.com/slides/tr/php-java/aspose.slides/ShapeType#Rectangle) tipinde bir [AutoShape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/autoshape/) ekleyin.
- TextFrame'e biraz metin ekleyin.
- Metne [Set Language Id](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) atayın.
- Sunumu bir PPTX dosyası olarak yazın.

Yukarıdaki adımların uygulanması aşağıdaki örnekte gösterilmiştir.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Dil kimliği otomatik metin çevirisini tetikler mi?**

Hayır. Aspose.Slides içindeki [Language ID](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) imla denetimi ve dilbilgisi düzeltmesi için dili depolar, ancak metin içeriğini çevirmez veya değiştirmez. Bu, PowerPoint'in doğrulama için anladığı bir meta veridir.

**Dil kimliği, render sırasında tireleme ve satır sonlarını etkiler mi?**

Aspose.Slides içinde, [language ID](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) doğrulama içindir. Tireleme kalitesi ve satır kaydırma esasen [proper fonts](/slides/tr/php-java/powerpoint-fonts/) bulunabilirliğine ve yazı sisteminin düzen/satır sonu ayarlarına bağlıdır. Doğru renderı sağlamak için gerekli yazı tiplerini kullanılabilir hâle getirin, [font substitution rules](/slides/tr/php-java/font-substitution/) yapılandırın ve/veya [embed fonts](/slides/tr/php-java/embedded-font/) sunuma yerleştirin.

**Tek bir paragrafta farklı diller ayarlayabilir miyim?**

Evet. [Language ID](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseportionformat/#setLanguageId) metin bölümü seviyesinde uygulanır, bu nedenle tek bir paragraf birden çok dili ayrı doğrulama ayarlarıyla karıştırabilir.