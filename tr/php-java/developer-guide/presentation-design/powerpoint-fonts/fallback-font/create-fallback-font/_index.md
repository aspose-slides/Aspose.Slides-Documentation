---
title: PHP'de Sunumlar İçin Yedek Yazı Tiplerini Belirleme
linktitle: Yedek Yazı Tipi
type: docs
weight: 10
url: /tr/php-java/create-fallback-font/
keywords:
- yedek yazı tipi
- yedek kural
- yazı tipi uygula
- yazı tipi değiştir
- Unicode aralığı
- eksik glif
- doğru glif
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP'i Java aracılığıyla kullanarak PPT, PPTX ve ODP dosyalarında yedek yazı tiplerini ayarlayın, her cihazda veya işletim sisteminde tutarlı metin görüntülenmesini sağlayın."
---
## **Genel Bakış**

Aspose.Slides, sunum renderleme ve dışa aktarma işlemleri için yedek yazı tipleri belirlemenizi sağlar. Yedek yazı tipleri, birincil yazı tipi belirli karakterler için glif içermediğinde kullanılır.

Yedek davranışı, yedek kurallar aracılığıyla yapılandırılır. Her kural, gerekli glifleri içerebilecek bir veya daha fazla yazı tipiyle bir Unicode aralığını ilişkilendirir. Farklı karakter aralıkları için kurallar tanımlayabilir, mevcut kurallardan yedek yazı tiplerini ekleyebilir veya kaldırabilir ve bir yedek yazı tipi kuralı koleksiyonunda birden fazla kuralı düzenleyebilirsiniz.

Yedek kuralları, çalışma zamanı render ayarlarıdır. Sunum dosyasını kendisi değiştirmez ve PPTX dosyasının içinde depolanmaz.

## **Yedek Kuralları**

Aspose.Slides, yedek bir yazı tipi uygulamak için kuralları belirlemek amacıyla [FontFallBackRule](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRule) sınıfını destekler. [FontFallBackRule](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRule) sınıfı, eksik glifleri aramak için kullanılan belirtilen Unicode aralığı ile doğru glifleri içerebilecek yazı tiplerinin bir listesini ilişkilendirir:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Birden fazla yol kullanarak yazı tipi listesini ekleyebilirsiniz:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Ayrıca mevcut [FontFallBackRule](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRule) nesnesine yedek yazı tipini [remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontfallbackrule/remove/) kaldırmak veya [addFallBackFonts](https://reference.aspose.com/slides/tr/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) eklemek de mümkündür.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRulesCollection) birden fazla Unicode aralığı için yedek yazı tipi değiştirme kurallarını belirtme ihtiyacı olduğunda, [FontFallBackRule](https://reference.aspose.com/slides/tr/php-java/aspose.slides/FontFallBackRule) nesnelerinin bir listesini düzenlemek için kullanılabilir.

{{% alert color="primary" title="Ayrıca" %}} 
- [Create Fallback Fonts Collection](/slides/tr/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Yedek yazı tipi, yazı tipi ikamesi ve yazı tipi gömme arasındaki fark nedir?**

Yedek bir yazı tipi, yalnızca birincil yazı tipinde eksik olan karakterler için kullanılır. [Font substitution](/slides/tr/php-java/font-substitution/) belirtilen tüm yazı tipini başka bir yazı tipine değiştirir. [Font embedding](/slides/tr/php-java/embedded-font/) yazı tiplerini çıktı dosyasının içine paketleyerek alıcıların metni amaçlandığı gibi görmesini sağlar.

**Yedek yazı tipleri, PDF, PNG veya SVG gibi dışa aktarımlarda mı yoksa yalnızca ekrandaki renderlamada mı uygulanır?**

Evet. Yedek, karakterlerin çizilmesi gerektiği ancak kaynak yazı tipinde bulunmadığı tüm [renderlama ve dışa aktarma işlemlerine](/slides/tr/php-java/convert-presentation/) etki eder.

**Yedek ayarlarını yapılandırmak sunum dosyasını kendisini değiştirir mi ve bu ayar gelecekteki açılışlarda kalıcı olur mu?**

Hayır. Yedek kuralları, kodunuzdaki çalışma zamanı render ayarlarıdır; .pptx dosyasının içinde depolanmaz ve PowerPoint’te görülmez.

**İşletim sistemi (Windows/Linux/macOS) ve yazı tipi dizinlerinin kümesi yedek seçiminde etkili olur mu?**

Evet. Motor, mevcut sistem klasörlerinden ve sağladığınız [ek yollar](/slides/tr/php-java/custom-font/) üzerinden yazı tiplerini çözer. Bir yazı tipi fiziksel olarak mevcut değilse, ona başvuran kural etkili olamaz.

**Yedek, WordArt, SmartArt ve grafiklerde çalışır mı?**

Evet. Bu nesneler metin içerdiğinde, eksik karakterleri renderlamak için aynı glif ikamesi mekanizması uygulanır.