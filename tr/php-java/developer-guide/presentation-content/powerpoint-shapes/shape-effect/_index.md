---
title: PHP Kullanarak Sunumlarda Şekil Efektleri Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/php-java/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parlama efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, doldurmalara [doldurmalara](/slides/tr/php-java/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilir vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle PowerPoint, **Preset** altında seçenekler sunar. Ön tanımlı seçenekler, iyi göründüğü bilinen iki ya da daha fazla efektin kombinasyonlarıdır. Böylece bir ön tanımlı seçerek farklı efektleri deneme veya birleştirme konusunda zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for PHP via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklaştırma yarıçapını sunum tasarımınıza göre özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Dış gölge, bir kartın ya da panelin slayt arka planına karşı öne çıkmasını sağlar. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş izlenimini verir. Renk, yön, mesafe ve bulanıklaştırma yarıçapını şablonunuzun aydınlatması ve stiline göre ayarlayın.

Bu PHP kodu bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) nasıl uygulanacağını gösterir:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygula**

Bir şablonun görsel stilini yeniden üretirken, bir kartın ya da panelin gömülü bir görünüm kazanması için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların iç kısmını gölgeler.

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklaştırma yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu PHP örneği, açık mavi bir kartı koyu gri bir iç gölge ile oluşturur ve bir PPTX dosyası olarak kaydeder. Gölge yönü 225 derecedir, mesafesi 7 puan, bulanıklaştırma yarıçapı 6 puandır:
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![İç gölgelikli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için şeklin efekt formatı üzerinde [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) metodunu çağırın.

### **Ön Tanımlı Gölge Uygula, Değiştir ve Kaldır**

[enablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enablePresetShadowEffect) metodunu çağırarak bir ön tanımlı gölgeyi etkinleştirin. [setPreset](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadow/#setPreset) metodunu kullanarak bir [PresetShadowType](https://reference.aspose.com/slides/php-java/aspose.slides/presetshadowtype/) seçin veya aynı şekil üzerinde farklı bir stile geçiş yapın. Gölgeyi doldurma ve kenarlığı koruyarak kaldırmak için [disablePresetShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disablePresetShadowEffect) metodunu çağırın.

Bu PHP örneği, ilk üç aşamadan sonra dikdörtgeni klonlayarak dört aşamayı aynı slaytta yan yana karşılaştırmanızı sağlar. Her iki gölge de 10 puan kaydırılmıştır. 225° yön, ilk gölgeyi dikdörtgenin üst soluna yerleştirirken, 45° yön ikinci gölgeyi alt sağa yerleştirir.
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\PresetShadowType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(800, 120, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $shape = $shapes->addAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 70, 130, 180);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $lineFill = $shape->getLineFormat()->getFillFormat();
    $lineFill->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $lineFill->getSolidFillColor()->setColor($lineColor);
    $shape->getTextFrame()->setText("No shadow");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
    $shapes->addClone($shape);

    $shape->setX(215);
    $effects = $shape->getEffectFormat();
    $effects->enablePresetShadowEffect();
    $shadow = $effects->getPresetShadowEffect();
    $shadow->setPreset(PresetShadowType::TopLeftDropShadow);
    $shadow->setDistance(10);
    $shadow->setDirection(225);
    $shape->getTextFrame()->setText("TopLeftDropShadow");
    $shapes->addClone($shape);

    $shape->setX(415);
    $shadow->setPreset(PresetShadowType::BottomRightDropShadow);
    $shadow->setDirection(45);
    $shape->getTextFrame()->setText("BottomRightDropShadow");
    $shapes->addClone($shape);

    $shape->setX(615);
    $effects->disablePresetShadowEffect();
    $shape->getTextFrame()->setText("No shadow");

    $presentation->save("preset_shadows.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Orijinal | İlk ön tanımlı | İkinci ön tanımlı | Kaldırma sonrası |
| :---: | :---: | :---: | :---: |
| ![Gölge yok](preset_shadow_original.png) | ![Üst Sol Düşen Gölge](preset_shadow_top_left.png) | ![Alt Sağ Düşen Gölge](preset_shadow_bottom_right.png) | ![Kaldırma sonrası gölge yok](preset_shadow_removed.png) |

## **Yansıma Efekti Uygulama**

Aspose.Slides for PHP via Java'da yansıma efekti uygulamak için şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha şık ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kod ile kolayca uygulanabilir ve birden çok öğeye tutarlı bir tasarım uygulanmasını sağlar.

Bu PHP kodu bir şekle [yansıma efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) nasıl uygulanacağını gösterir:
```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Yansıma efekti](reflection_effect.png)

## **Parlama Efekti Uygulama**

Aspose.Slides for PHP via Java'da bir şekle parlama efekti eklemek için şeklin etrafına yumuşak, ışıldayan bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici bir görsel öğe ekler. Az kodla kolayca uygulanır ve slaytlarınızın genel görünümünü iyileştirir.

Bu PHP kodu bir şekle [parlama efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) nasıl uygulanacağını gösterir:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Parlama efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for PHP via Java'da yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve rafine bir görünüm ekler; özellikle nazik ve yumuşak bir görünüm gerektiren tasarımlar için idealdir. Çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu PHP kodu bir şekle [yumuşak kenarlar efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) nasıl uygulanacağını gösterir:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Yumuşak kenarlar efekti](soft_edges_effect.png)

## **Bulanıklaştırma Efekti Uygulama**

Şekil bulanıklaştırma, şeklin doldurma ve kenarlığını yumuşatarak şekli düzenlenebilir tutar. Şeklin efekt formatı üzerinde [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) metodunu çağırın. Yarıçap, puan cinsinden ölçülür (1/72 inç): negatif olmayan bir değer kullanın; daha yüksek değerler daha güçlü bulanıklık üretir. Yarıçap sıfır olduğunda görünüm değişmez.

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) ayarı, etkinin görünen sınırlarını kontrol eder. `false` olduğunda bulanıklık, orijinal boyanmış sınırlarla (kenarlık dahil) sınırlanır. `true` olduğunda bulanıklık bu sınırların dışına uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı doldurma, kenarlık ve şekil boyutlarını tüm boyunca kullanır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Orijinal dikdörtgen, 5 ve 15 puan bulanıklık yarıçaplarıyla, büyütme devre dışı ve etkin durumlarla karşılaştırılmıştır](shape_blur_comparison.png)

Bu PHP örneği, turuncu bir dikdörtgeni koyu mavi bir kenarlıkla oluşturur, 5 puan bulanıklık uygular, ardından [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) tekrar çağrılarak 15 puana yükseltir. Her iki bulanıklı durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) çağrısıyla bulanıklaştırması kaldırılmış şekli kaydeder.
```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Şekil bulanıklaştırması, doldurma ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti, şeklin kenarlarını siler; gölge bulanıklığı ise yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek şekli bir görüntüye dönüştürmeden doğrudan şeklin efekt formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, aynı şekle gölge, yansıma ve parlama gibi farklı efektleri birleştirerek daha dinamik bir görünüm elde edebilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerinde uygulanır.