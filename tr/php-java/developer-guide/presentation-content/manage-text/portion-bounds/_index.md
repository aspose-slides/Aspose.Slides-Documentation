---
title: PHP'de Sunumlardan Metin Bölüm Sınırlarını Al
linktitle: Bölüm Sınırları
type: docs
weight: 47
url: /tr/php-java/portion-bounds/
keywords:
- metin bölüm sınırları
- metin bölümü
- metin parçası
- metin koordinatları
- metin konumu
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint sunumlarında metin bölümü sınırlarını nasıl alacağınızı öğrenin."
---
## **Genel Bakış**

Bir metin bölümü, bir paragraftaki belirli bir metin parçacığını temsil eder ve bu parçacıkla çevredeki içerikten bağımsız olarak çalışmanıza olanak tanır. Aspose.Slides'te, bir metin parçacığının sınırlarını almanız, bir paragrafın yalnızca bir kısmına biçimlendirme uygulamanız veya metin davranışını daha ayrıntılı bir seviyede kontrol etmeniz gerektiğinde bölümler kullanılabilir.

Bu makale, bir bölümün sınırlayıcı dikdörtgenini elde etmek için [Portion::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/getrect/) kullanımını gösterir. Ayrıca, bir bölümün başlangıç koordinatlarını elde etmek için [Portion::getCoordinates](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/getcoordinates/) kullanımını gösterir. Ek olarak, tek bir metin parçacığına hiperlink ekleme, biçimlendirmenin bölüm, paragraf, metin çerçevesi ve tema kalıtımı üzerinden nasıl çözümlendiğini anlama ve belirtilen bir yazı tipinin bulunmadığı durumları ele alma gibi yaygın bölümle ilgili senaryoları vurgular.

## **Metin Bölümünün Sınırlarını Al**

Metin bölümünün sınırlayıcı dikdörtgenini almak için [Portion::getRect](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/getrect/) kullanın:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Metin Bölümünün Koordinatlarını Al**

Bir metin bölümünün başlangıç koordinatlarını almak için [Portion::getCoordinates](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/getcoordinates/) kullanın:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Bir paragraftaki metnin yalnızca bir kısmına hiperlink uygulayabilir miyim?**

Evet, bir bölüme [hiperlink atayabilirsiniz](/slides/tr/php-java/manage-hyperlinks/); yalnızca o parçacık tıklanabilir olur, tüm paragraf değil.

**Stil kalıtımı nasıl çalışır: bir bölüm neyi geçersiz kılar ve neyi paragraftan ya da metin çerçevesinden alır?**

Bölüm düzeyindeki özellikler en yüksek önceliğe sahiptir. Bir özellik [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) üzerinde ayarlanmamışsa, Aspose.Slides onu [Paragraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/paragraph/) üzerinden alır. Orada da ayarlanmamışsa, Aspose.Slides [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) veya [theme](https://reference.aspose.com/slides/tr/php-java/aspose.slides/theme/) stilini kullanır.

**Bir bölüm için belirtilen yazı tipi hedef makine veya sunucuda bulunmazsa ne olur?**

[Yazı tipi ikame kuralları](/slides/tr/php-java/font-selection-sequence/) uygulanır. Metin yeniden akış gösterebilir: metrikler, hecelemenin ve genişliğin değişmesi, hassas konumlandırma için önemlidir.

**Paragrafın geri kalanından bağımsız olarak bölüme özgü metin dolgu şeffaflığını veya bir geçişi ayarlayabilir miyim?**

Evet, [Portion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/portion/) düzeyinde metin rengi, dolgu ve şeffaflık komşu parçacıklardan farklı olabilir.