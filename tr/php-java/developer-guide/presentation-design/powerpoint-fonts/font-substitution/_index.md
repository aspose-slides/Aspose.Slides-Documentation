---
title: PHP Kullanarak Sunumlarda Yazı Tipi İkamesi Yapılandırma
linktitle: Yazı Tipi İkamesi
type: docs
weight: 70
url: /tr/php-java/font-substitution/
keywords:
- yazı tipi
- ikame yazı tipi
- yazı tipi ikamesi
- yazı tipi değiştirme
- yazı tipi değişimi
- ikame kuralı
- değiştirme kuralı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını diğer dosya biçimlerine dönüştürürken Aspose.Slides for PHP via Java'da optimal yazı tipi ikamesini etkinleştirin."
---
## **Giriş**

Yazı tipi ikame, Aspose.Slides'in orijinal sunumda kullanılan yazı tipi render veya dönüşüm sırasında mevcut olmadığında başka bir yazı tipini kullanmasını sağlar. `FontsManager` sınıfının `getSubstitutions` metodunu kullanarak hangi yazı tiplerinin ikame edildiğini kontrol edebilirsiniz.

Aspose.Slides ayrıca yazı tipi ikame kurallarını tanımlamanıza da izin verir. Örneğin, erişilemeyen bir yazı tipinin başka bir mevcut yazı tipiyle değiştirilmesini belirtebilir ve ardından bu kuralları sunumun yazı tipi yöneticisi üzerinden uygulayabilirsiniz.

## **Yazı Tipi İkame Kurallarını Ayarlama**

Aspose.Slides, belirli koşullarda (örneğin bir yazı tipine erişilemediğinde) ne yapılacağını belirleyen kuralları aşağıdaki şekilde ayarlamanıza olanak tanır:

1. İlgili sunumu yükleyin.
2. Değiştirilecek yazı tipini yükleyin.
3. Yeni yazı tipini yükleyin.
4. Değiştirme için bir kural ekleyin.
5. Kuralı sunumun yazı tipi değiştirme kural koleksiyonuna ekleyin.
6. Etkiyi gözlemlemek için slayt görselini oluşturun.

Bu PHP kodu yazı tipi ikame sürecini göstermektedir:

```php
  # Bir sunumu yükler
  $pres = new Presentation("Fonts.pptx");
  try {
    # Değiştirilecek kaynak yazı tipini yükler
    $sourceFont = new FontData("SomeRareFont");
    # Yeni yazı tipini yükler
    $destFont = new FontData("Arial");
    # Yazı tipi değiştirme için bir kural ekler
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Kuralı yazı tipi ikame kuralları koleksiyonuna ekler
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Kural listesine bir yazı tipi kural koleksiyonu ekler
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Arial yazı tipi, SomeRareFont erişilemez olduğunda onun yerine kullanılacaktır
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Görseli JPEG formatında diske kaydeder
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
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

{{%  alert title="NOTE"  color="warning"   %}} 

[**Yazı Tipi Değiştirme**](/slides/tr/php-java/font-replacement/) görmek isteyebilirsiniz.

{{% /alert %}}

## **Matematik Denklemi Yazı Tipleri için Sınırlamalar**

Yazı tipi ikame kuralları, render ve dönüşüm sırasında kullanılan standart yazı tipi seçme sürecine katılır. Aspose.Slides'in yapılandırılmış kurala göre erişilemeyen bir yazı tipini başka bir mevcut yazı tipiyle değiştirebildiği normal metin senaryoları için uygundur.

Ancak Office matematik denklemlerinde önemli bir sınırlama vardır. Bir denklem **Cambria Math** ile oluşturulduysa, Aspose.Slides denklemin yerleşimini doğru şekilde hesaplamak ve renderlamak için hâlâ orijinal **Cambria Math** yazı tipine ihtiyaç duyabilir. Bu nedenle **Cambria Math**'ı **STIX Two Math** gibi başka bir matematik yazı tipiyle ikame etmek, denklem renderlaması için desteklenmez ve hâlâ **Cambria Math**'ın gerekli olduğunu belirten bir istisna ortaya çıkabilir.

Bu tür sunumları başarılı bir şekilde dönüştürmek için, çalışma zamanında **Cambria Math**'ın Aspose.Slides tarafından erişilebilir olduğundan emin olun. Yazı tipini işletim sistemine kurabilir veya bir [external font](/slides/tr/php-java/custom-font/) olarak sağlayarak render ve dönüşüm sırasında normal yazı tipi seçme sürecine katılmasını sağlayabilirsiniz.

Bu sınırlama yalnızca denklem renderlamasına özgüdür. Yukarıda açıklanan standart yazı tipi ikame kuralları, orijinal yazı tipi erişilemediğinde normal sunum metni için hâlâ geçerlidir.

## **SSS**

**Yazı tipi değiştirme ile ikame arasındaki fark nedir?**

[Değiştirme](/slides/tr/php-java/font-replacement/) tüm sunum boyunca bir yazı tipinin başka bir yazı tipine zorla geçersiz kılınmasıdır. İkame, belirli bir koşulda (örneğin orijinal yazı tipi mevcut değilse) tetiklenen ve ardından atanmış bir yedek yazı tipinin kullanıldığı bir kuraldır.

**İkame kuralları tam olarak ne zaman uygulanır?**

Kurallar, yükleme, render ve dönüşüm sırasında değerlendirilen standart [font selection](/slides/tr/php-java/font-selection-sequence/) dizisine katılır; seçilen yazı tipi mevcut değilse, değiştirme veya ikame uygulanır.

**Ne yazık ki hiçbir değiştirme veya ikame yapılandırılmamış ve sistemde yazı tipi eksikse varsayılan davranış nedir?**

Kütüphane, PowerPoint'in davranışına benzer şekilde, en yakın mevcut sistem yazı tipini seçmeye çalışır.

**İkameyi önlemek için çalışma zamanında özel dış yazı tipleri ekleyebilir miyim?**

Evet. Kütüphane, seçim ve renderlama sırasında (sonraki dönüşümler dahil) dikkate alması için çalışma zamanında [add external fonts](/slides/tr/php-java/custom-font/) ekleyebilir ve böylece ikame ihtiyacını azaltabilirsiniz.

**Aspose kütüphanesiyle birlikte herhangi bir yazı tipi dağıtıyor mu?**

Hayır. Aspose, ücretli veya ücretsiz yazı tipleri dağıtmaz; yazı tiplerini kendi takdiriniz ve sorumluluğunuzla ekler ve kullanırsınız.

**Windows, Linux ve macOS üzerinde ikame davranışında farklılıklar var mı?**

Evet. Yazı tipi keşfi, işletim sisteminin yazı tipi dizinlerinden başlar. Varsayılan mevcut yazı tipleri ve arama yolları platformlar arasında farklılık gösterir; bu da kullanılabilirliği ve ikame ihtiyacını etkiler.

**Toplu dönüşümler sırasında beklenmeyen ikameleri en aza indirmek için ortamı nasıl hazırlamalıyım?**

Makineler veya konteynerler arasında yazı tipi kümesini senkronize edin, çıktı belgeleri için gerekli [add the external fonts](/slides/tr/php-java/custom-font/) ekleyin ve mümkün olduğunda sunumlara [embed fonts](/slides/tr/php-java/embedded-font/) gömün böylece seçilen yazı tipleri render sırasında mevcut olur.