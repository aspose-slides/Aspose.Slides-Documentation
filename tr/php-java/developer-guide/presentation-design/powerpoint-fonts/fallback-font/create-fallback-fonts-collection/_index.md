---
title: "PHP'de Yedek Yazı Tipi Koleksiyonlarını Yapılandırın"
linktitle: "Yedek Yazı Tipi Koleksiyonu"
type: docs
weight: 20
url: /tr/php-java/create-fallback-fonts-collection/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi koleksiyonu
- yazı tipini yapılandır
- yazı tipini kur
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java'da yedek yazı tipleri koleksiyonunu kurarak PowerPoint ve OpenDocument sunumlarında metnin tutarlı ve net kalmasını sağlayın."
---
## **Genel Bakış**

Aspose.Slides, bir sunum için yedek yazı tipi kurallarının bir koleksiyonunu yapılandırmanıza olanak tanır. Her yedek kural, `FontFallBackRule` sınıfı tarafından temsil edilir ve bir `FontFallBackRulesCollection`'a eklenebilir.

Koleksiyonu oluşturduktan sonra, sunumun `FontsManager`'ının `setFontFallBackRulesCollection` yöntemi ile atayabilirsiniz. `FontsManager`, sunum genelinde yazı tiplerini kontrol eder ve her `Presentation` örneğinin kendi `FontsManager`'ı vardır.

`FontsManager`, yedek yazı tipi koleksiyonuyla başlatıldıktan sonra, belirtilen yedek yazı tipleri sunumun oluşturulması sırasında uygulanır.

## **Yedek Kuralları Uygula**

[FontFallBackRule](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRule) sınıfının örnekleri [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRulesCollection) içine düzenlenebilir. Koleksiyondan kuralları eklemek veya kaldırmak mümkündür.

Daha sonra bu koleksiyon, [FontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontsManager) sınıfının [FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRulesCollection) metoduna atanabilir. FontsManager, sunum genelinde yazı tiplerini kontrol eder.

Her [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation), kendi [FontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontsManager) sınıfı örneğiyle bir [getFontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#getFontsManager) metoduna sahiptir.

Aşağıda belirli bir sunumun [FontsManager](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation#getFontsManager) içine yedek yazı tipi kuralı koleksiyonu oluşturup atamanın bir örneği verilmiştir:

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

`FontsManager` yedek yazı tipi koleksiyonuyla başlatıldıktan sonra, yedek yazı tipleri sunum oluşturulması sırasında uygulanır.

{{% alert color="primary" %}} 
Daha fazla bilgi için [Farklı Yazı Tipi ile Sunumu Oluşturma](/slides/tr/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **SSS**

**Yedek kurallarım PPTX dosyasına gömülüp kaydedildikten sonra PowerPoint'te görünür mü?**

Hayır. Yedek kurallar, çalışma zamanı oluşturma ayarlarıdır; PPTX dosyasına serileştirilmezler ve PowerPoint kullanıcı arayüzünde görünmezler.

**Yedek, SmartArt, WordArt, grafikler ve tablolar içindeki metne uygulanır mı?**

Evet. Bu nesnelerdeki herhangi bir metin için aynı glif-değiştirme mekanizması kullanılır.

**Aspose, kütüphane ile birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Yazı tiplerini kendi tarafınızda ekler ve kullanırsınız; sorumluluk size aittir.

**Eksik yazı tipleri için değiştirme/değiştirme ve eksik glifler için yedekleme birlikte kullanılabilir mi?**

Evet. Bunlar aynı yazı tipi çözümleme ardışık düzeninin bağımsız aşamalarıdır: önce motor, yazı tipi kullanılabilirliğini ([replacement](/slides/tr/php-java/font-replacement/)/[substitution](/slides/tr/php-java/font-substitution/)) çözer, ardından yedekleme, mevcut yazı tiplerindeki eksik glifleri tamamlar.