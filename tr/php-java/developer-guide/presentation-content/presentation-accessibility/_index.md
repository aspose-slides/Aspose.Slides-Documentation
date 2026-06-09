---
title: PHP'de Sunum Erişilebilirliğini Yönet
linktitle: Sunum Erişilebilirliği
type: docs
weight: 30
url: /tr/php-java/presentation-accessibility/
keywords:
- sunum erişilebilirliği
- dekoratif olarak işaretle
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides'in PPT, PPTX ve ODP dosyalarında sunum erişilebilirliği kontrollerini otomatikleştirmeye nasıl yardımcı olduğunu keşfedin—ekran okuyucu deneyimini geliştirin ve uyumluluğu artırın."
---
## **Genel Bakış**

Sunum erişilebilirliği, ekran okuyucular, braille ekranlar veya sadece klavye ile gezinme gibi yardımcı teknolojileri kullanan kişilerin slaytlarınızı, görme engelli ve fare kullanan izleyiciler kadar etkili bir şekilde anlamasını ve gezinmesini sağlar. İyi uygulamalar, net bir okuma sırasına, bilgilendirici görseller için anlamlı alternatif metne, yeterli renk kontrastına, okunabilir tipografiye, açıklayıcı bağlantı metnine odaklanır ve anlamı yalnızca renk veya konumla iletmekten kaçınır. Erişilebilirlik baştan planlandığında, sonuç daha temiz bir yapı, daha tutarlı görseller ve her izleyiciye ek çözümler olmadan ulaşan içeriktir.

## **Dekoratif Olarak İşaretle**

‘Dekoratif olarak işaretle’ işareti, yalnızca süs amaçlı görselleri işaretleyerek ekran okuyucuların bunları atlamasını sağlar, gürültüyü azaltır ve anlamlı içeriğe odaklanmayı korur. Bu işareti arka planlar, süslemeler ve boşluk ayırıcılarına uygulayın—hiçbir zaman bilgi taşıyan grafikler, ikonlar veya resimler için kullanmayın. Aspose.Slides bu işareti tespit ve doğrulama için sunar, otomatik erişilebilirlik kontrolleri ve temizlik yapılmasına olanak tanır.

![Dekoratif Olarak İşaretle](mark_as_decorative.png)

Aşağıdaki kod örneği, bir şeklin dekoratif olarak işaretlenip işaretlenmediğini belirlemenin yolunu gösterir.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```