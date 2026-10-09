---
title: "PHP Kullanarak Sunumlarda Şekil Efektlerini Uygulama"
linktitle: "Şekil Efekti"
type: docs
weight: 30
url: /tr/php-java/shape-effect/
keywords:
- "şekil efekti"
- "gölge efekti"
- "yansıma efekti"
- "parıltı efekti"
- "yumuşak kenar efekti"
- "efekt formatı"
- "PowerPoint"
- "sunum"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şeklin öne çıkmasını sağlamak için kullanılabilir, ancak [fills](/slides/tr/php-java/shape-formatting/#gradient-fill) veya konturlardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar yaratabilir, şeklin parıltısını yayabilir vb.

![Shape effect](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyidir. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iyi göründüğü bilinen iki veya daha fazla efektin birleşimleridir. Böylece bir preset seçerek farklı efektleri test etme veya birleştirme zamanını harcamazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for PHP via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunumunuzun tasarımıyla eşleştirecek şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Dış gölge, bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlar. Gölge, şeklin kenarlarının dışına uzanır ve şeklin slayt üzerindeki yükseltilmiş izlenimini verir. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun ışıklandırması ve stiline uyduracak şekilde ayarlayın.

Bu PHP kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) uygulamayı gösterir:

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

![Shadow effect](shadow_effect.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, kart veya panelin içe gömülü bir görünüm kazanması için iç gölge kullanın. Dış gölge, şeklin dışına uzanır ve yükseltilmiş görünürken, iç gölge kenarlarının iç kısmını gölgelendirir.

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklık yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu PHP örneği, açık mavi bir kart oluşturur, koyu gri bir iç gölge ekler ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derecedir, mesafesi 7 puan ve bulanıklık yarıçapı 6 puandır:

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

![İç gölgeli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için, şeklin effect formatı üzerinde [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for PHP via Java'da yansıma efekti uygulamak için, şekillere ayna gibi bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumunuzun estetiğini artırır. Basit kodla kolayca uygulanabilir ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu PHP kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) uygulamayı gösterir:

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

## **Parıltı Efekti Uygulama**

Aspose.Slides for PHP via Java'da bir şekle parıltı efekti uygulamak için, şeklin etrafına yumuşak, ışıldayan bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe katar. Az kodla kolayca uygulanır ve slaytların genel görünümünü iyileştirir.

Bu PHP kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) uygulamayı gösterir:

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

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenar Efekti Uygulama**

Aspose.Slides for PHP via Java'da yumuşak kenar efekti uygulamak için, şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm ekler, hafif ve yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Yarıçap gibi parametreleri kolayca ayarlayarak istediğiniz efekti çeşitli şekillerde elde edebilirsiniz.

Bu PHP kodu, bir şekle [yumuşak kenar efekti](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) uygulamayı gösterir:

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

![Yumuşak kenar efekti](soft_edges_effect.png)

## **FAQ**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Autoshape'lar, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplu şekillere efekt uygulayabilir miyim?**

Evet, gruplu şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerine uygulanır.