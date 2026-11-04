---
title: Android'de Sunumlarda Şekil Efektlerini Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/androidjava/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı ve profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, [doldurmalar](/slides/tr/androidjava/shape-formatting/#gradient-fill) veya kenar çizgilerinden farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerindeki ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilirsiniz, vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iyi göründüğü bilinen iki veya daha fazla efektin kombinasyonlarıdır. Böylece, bir preset seçerek farklı efektleri denemek veya birleştirmek için zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Android via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunumunuzun tasarımına uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Dış gölgeyi, bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş izlenimini yaratır. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun ışıklandırması ve stiline uygun şekilde ayarlayın.

Bu Java kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, bir kartın veya panelin içe doğru gömülmüş bir görünüm kazanması için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların içini gölgeler.

Bu yöntemi [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklık yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Java örneği, koyu gri iç gölgeye sahip açık mavi bir kart oluşturur ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derece, mesafesi 7 puan ve bulanıklık yarıçapı 6 puandır:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![İç gölgeli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için şeklin effect formatı üzerinde [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for Android via Java'da bir yansıma efekti uygulamak için şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm vererek sunumlarınızın estetiğini artırır. Basit kodla uygulanması kolaydır, tutarlı bir tasarım için birden çok öğeye hızlıca uygulanmasını sağlar.

Bu Java kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Yansıma efekti](reflection_effect.png)

## **Parıltı Efekti Uygulama**

Aspose.Slides for Android via Java'da bir şekle parıltı efekti uygulamak için şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Az kodla uygulanması kolaydır, slaytlarınızın genel görünümünü iyileştirir.

Bu Java kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for Android via Java'da yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm ekler; hafif, daha yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Sunumunuzdaki çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu Java kodu, bir şekle [yumuşak kenarlar efekti](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) nasıl uygulanacağını gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Yumuşak kenarlar efekti](soft_edges_effect.png)

## **Bulanıklık Efekti Uygulama**

Şekil bulanıklığını kullanarak bir şeklin doldurmasını ve kenar çizgisini yumuşatabilir, şeklin düzenlenebilirliğini koruyabilirsiniz. Şeklin effect formatı üzerinde [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metodunu çağırın. Yarıçap, puan (1/72 inç) cinsinden ölçülür: negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bulanıklık üretir. Sıfır yarıçap görünümü değiştirmez.

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) ayarı, efektin görünür sınırlarını kontrol eder. `false` ile bulanıklık, kenar çizgisi dahil orijinal boyanmış sınırlara kırpılır. `true` ile bulanıklık bu sınırların ötesine uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma aynı doldurma, kenar ve şekil boyutlarını kullanır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Bulanıklık yarıçapları 5 ve 15 puan olan, grow devre dışı ve etkin durumlarda orijinal dikdörtgen karşılaştırması](shape_blur_comparison.png)

Bu Java örneği, koyu mavi kenarlıklı turuncu bir dikdörtgen oluşturur, 5 puanlık bir bulanıklık uygular ve ardından [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metodunu tekrar çağırarak 15 puanlık bir bulanıklığa günceller. Her iki bulanık durumu da kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) metodunu çağırarak bulanıklığı kaldırılmış şekli kaydeder.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Şekil bulanıklığı doldurma ve kenarı birlikte etkiler. Yumuşak kenarlar efekti şeklin kenarlarını solarken, gölge bulanıklığı sadece gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görüntüye dönüştürmeden doğrudan şeklin effect formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden çok efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, grup şekillere efekt uygulayabilirsiniz. Efekt tüm gruba uygulanır.