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
- parıltı efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, bunlar [doldurmalardan](/slides/tr/php-java/shape-formatting/#gradient-fill) veya kenar çizgilerinden farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parıltısını yayabilir vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyidir. Bu nedenle PowerPoint, **Preset** altında seçenekler sunar. Preset seçenekleri iki veya daha fazla efektin bir araya getirildiği, iyi görüneceği bilinen kombinasyonlardır. Böylece bir preset seçerek, güzel bir kombinasyon bulmak için farklı efektleri deneme veya birleştirme zahmetine girmezsiniz.

Aspose.Slides, [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) sınıfı altında bulunan özellikler ve yöntemler aracılığıyla PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanıza olanak tanır.

## **Gölge Efekti Uygulama**

Aspose.Slides for PHP via Java, şekiller için dış ve iç gölgeleri destekler. Renklerini, yönünü, mesafesini ve bulanıklaştırma yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Bir kartı veya paneli slayt arka planına karşı öne çıkarmak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanır ve şeklin slayt üzerinde yükseltilmiş izlenimini verir. Renk, yön, mesafe ve bulanıklaştırma yarıçapını şablonun aydınlatması ve stiline göre ayarlayın.

Bu PHP kodu, bir dikdörtgene [dış gölge efektini](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) uygulamayı gösterir:

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

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, bir kart veya panele geri çekilmiş bir görünüm vermek için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş gibi görünürken, iç gölge kenarların iç kısmını gölgeler.

[enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklaştırma yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu PHP örneği, açık mavi bir kartı koyu gri bir iç gölgeyle oluşturur ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derecedir, mesafesi 7 puan, bulanıklaştırma yarıçapı ise 6 puandır:

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

İç gölgeyi kaldırmak için şeklin effect formatı üzerinde [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for PHP via Java'da yansıma efekti uygulamak için şekillere bir ayna benzeri yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumların estetiğini artırır. Basit kodla uygulanması kolaydır ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu PHP kodu, bir şekle [yansıma efektini](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) uygulamayı gösterir:

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

Aspose.Slides for PHP via Java'da bir şekle parıltı efekti uygulamak için şekillerin etrafına yumuşak, ışıldayan bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici bir görsel öge ekler. Minimum kodla uygulanması kolaydır ve slaytların genel görünümünü iyileştirir.

Bu PHP kodu, bir şekle [parıltı efektini](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) uygulamayı gösterir:

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

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for PHP via Java'da yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve rafine bir görünüm ekleyerek nazik bir tasarım gerektiren durumlarda mükemmeldir. İstediğiniz etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu PHP kodu, bir şekle [yumuşak kenarlar efektini](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) uygulamayı gösterir:

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

Şekil bulanıklaştırma, şeklin doldurmasını ve kenar çizgisini yumuşatarak şekli düzenlenebilir tutar. Şeklin effect formatı üzerinde [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) metodunu çağırın. Yarıçap puan cinsindendir (1/72 inç): negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bulanıklaştırma üretir. Yarıçap sıfır olduğunda görünüm değişmez.

[getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) ayarı, etkinin görünür sınırlarını kontrol eder. `false` olduğunda, bulanıklaştırma orijinal boyanmış sınırlarla, kenar çizgisi dahil, sınırlanır. `true` olduğunda, bulanıklaştırma bu sınırların dışına uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı doldurma, kenar çizgisi ve şekil boyutları kullanılarak yapılmıştır. Üst satır `grow = false`; alt satır `grow = true` olarak ayarlanmıştır.

![Orijinal dikdörtgen, 5 ve 15 puanlık bulanıklaştırma yarıçaplarıyla, grow devre dışı ve etkin olarak karşılaştırma](shape_blur_comparison.png)

Bu PHP örneği, turuncu bir dikdörtgeni koyu mavi bir kenar çizgisiyle oluşturur, 5 puanlık bir bulanıklaştırma uygular, ardından [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) metodunu tekrar çağırarak 15 puanlık bir bulanıklaştırmaya yükseltir. Her iki bulanıklaştırılmış durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) metodunu çağırarak gölgesiz şekli kaydeder.

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

Şekil bulanıklaştırma, doldurma ve kenar çizgisini birlikte etkiler. Yumuşak kenarlar efekti şeklin kenarlarını solgunlaştırırken, gölge bulanıklaştırması yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görüntüye dönüştürmeden doğrudan şeklin effect formatına bulanıklaştırma uygular.

## **SSS**

**Aynı şekle birden çok efekt uygulayabilir miyim?**

Evet, bir şekle gölge, yansıma ve parıltı gibi farklı efektleri birleştirerek daha dinamik bir görünüm elde edebilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerine uygulanır.