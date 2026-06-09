---
title: PHP'de Sunum Slaytlarını Karşılaştırma
linktitle: Slaytları Karşılaştır
type: docs
weight: 50
url: /tr/php-java/compare-slides/
keywords:
- slaytları karşılaştır
- slayt karşılaştırması
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını Aspose.Slides for PHP via Java ile programlı olarak karşılaştırın. Kod içinde slayt farklarını hızlı bir şekilde belirleyin."
---
## **Giriş**

Aspose.Slides, `BaseSlide` sınıfı tarafından sağlanan `equals` yöntemiyle slaytları, slayt düzenlerini ve ana slaytları karşılaştırmanıza olanak tanır. Bu yöntem, karşılaştırılan slaytlar yapı ve statik içerik açısından aynı olduğunda `true` döndürür.

## **İki Slaytı Karşılaştırma**

Equals yöntemi, [BaseSlide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/BaseSlide) sınıfına eklenmiştir. Yapı ve statik içerik açısından aynı olan slayt/düzen ve ana slaytlar için true döndürür.  

İki slayt, tüm şekiller, stiller, metinler, animasyonlar ve diğer ayarlar vb. aynıysa eşittir. Karşılaştırma, SlideId gibi benzersiz tanımlayıcı değerlerini ve Tarih Yer Tutucusu'ndaki mevcut tarih değeri gibi dinamik içeriği hesaba katmaz.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **SSS**

**Bir slaytın gizli olması, slaytların karşılaştırmasını etkiler mi?**

[Hidden status](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/gethidden/) bir sunum/oynatım düzeyinde özelliktir, görsel içerik değildir. İki özel slaytın eşitliği, yapı ve statik içerikleriyle belirlenir; bir slaytın gizli olması tek başına slaytların farklı olduğu anlamına gelmez.

**Köprüler ve parametreleri dikkate alınıyor mu?**

Evet. Bağlantılar, bir slaytın statik içeriğinin bir parçasıdır. URL veya köprü eylemi farklı ise, bu genellikle statik içerikte bir fark olarak değerlendirilir.

**Bir grafik harici bir Excel dosyasına referans veriyorsa, dosyanın içeriği hesaba katılır mı?**

Hayır. Karşılaştırma, yalnızca slaytların kendileri temel alınarak yapılır. Dış veri kaynakları genellikle karşılaştırma sırasında okunmaz; yalnızca slaytın yapısında ve statik durumunda bulunanlar dikkate alınır.