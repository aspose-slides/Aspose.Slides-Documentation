---
title: Sunumlarda PHP Kullanarak Metin Bölümlerini Yönetme
linktitle: Metin Bölümü
type: docs
weight: 70
url: /tr/php-java/portion/
keywords:
- metin bölümü
- metin kısmı
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında metin bölümlerini nasıl yöneteceğinizi öğrenin, performans ve özelleştirmeyi artırın."
---
## **Giriş**

Bir metin bölümü, bir paragraftaki belirli bir metin parçasını temsil eder ve bu parçayla çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides içinde, bir metin parçasının konumunu almak, yalnızca bir paragrafın bir kısmına biçimlendirme uygulamak veya metin davranışını daha ayrıntılı bir seviyede kontrol etmek istediğinizde bölümler kullanılabilir.

## **Bir Metin Bölümünün Koordinatlarını Almak**
[**getCoordinates()**](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/getcoordinates/) yöntemi, bölümün başlangıcının koordinatlarını almanıza olanak tanıyan [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) sınıfına eklenmiştir.

```php
  # PPTX'i temsil eden Presentation sınıfını örnekle
  $pres = new Presentation();
  try {
    # Sunum bağlamını yeniden şekillendir
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Tek bir paragraftaki metnin yalnızca bir kısmına hiperlink uygulayabilir miyim?**

Evet, bir bölüme ayrı ayrı [bir hiperlink atamak](/slides/tr/php-java/manage-hyperlinks/) atayabilirsiniz; yalnızca o parça tıklanabilir olur, bütün paragraf değil.

**Stil kalıtımı nasıl çalışır: bir Portion neyi geçersiz kılar ve neler Paragraph/TextFrame'den alınır?**

Portion düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) üzerinde ayarlanmadıysa, motor bunu [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) üzerinden alır; orada da ayarlanmadıysa, [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) ya da [theme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/theme/) stilinden alınır.

**Bir Portion için belirtilen yazı tipi hedef makine/sunucuda eksikse ne olur?**

[Font substitution rules](/slides/tr/php-java/font-selection-sequence/) uygulanır. Metin yeniden akabilir: ölçümler, hecelenme ve genişlik değişebilir, bu da kesin konumlandırma için önemlidir.

**Bir Portion'a özgü metin dolgu şeffaflığını veya degradeyi paragrafın geri kalanından bağımsız olarak ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) düzeyinde metin rengi, dolgu ve şeffaflık komşu bölümlerden farklı olabilir.