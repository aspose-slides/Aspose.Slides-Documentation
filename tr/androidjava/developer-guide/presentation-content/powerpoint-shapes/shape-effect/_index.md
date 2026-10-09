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
- parlama efekti
- yumuşak kenarlar efekti
- efekt biçimi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, bunlar [doldurmalar](/slides/tr/androidjava/shape-formatting/#gradient-fill) veya anahatlardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar yaratabilir, şeklin parıltısını yayabilirsiniz vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iyi görünmesi bilinen iki veya daha fazla efektin kombinasyonlarıdır. Bu sayede bir preset seçerek, güzel bir kombinasyon bulmak için farklı efektleri test etmek veya birleştirmek için zaman harcamak zorunda kalmazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Android via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklaşma yarıçapını sunumunuzun tasarımına uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanır ve şeklin slayt üzerinde yükselmiş izlenimini verir. Renk, yön, mesafe ve bulanıklaşma yarıçapını şablonunuzun aydınlatması ve stiline uyacak şekilde ayarlayın.

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

![Gölge etkisi](shadow_effect.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden üretirken, bir kart veya panele gömülü bir görünüm vermek için iç gölge kullanın. Dış gölge şeklin dışına uzanır ve yükselmiş görünürken, iç gölge kenarların içini gölgelendirir.

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklaşma yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Java örneği, koyu gri bir iç gölgeyle açık mavi bir kart oluşturur ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derecedir, mesafesi 7 puan ve bulanıklaşma yarıçapı 6 puandır:

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

İç gölgeyi kaldırmak için, şeklin effect format'ında [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for Android via Java'da bir yansıma efekti uygulamak için, şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm vererek sunumlarınızın estetiğini artırır. Basit bir kodla kolayca uygulanabilir ve tutarlı bir tasarım için birden fazla öğeye hızlıca uygulanmasını sağlar.

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

## **Parlama Efekti Uygulama**

Aspose.Slides for Android via Java'da bir şekle parlama efekti uygulamak için, şekillerin etrafına yumuşak, ışıldayan bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimum kodla kolayca uygulanabilir ve slaytlarınızın genel görünümünü iyileştirir.

Bu Java kodu, bir şekle [parlama efekti](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) nasıl uygulanacağını gösterir:

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

![Parlama efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for Android via Java'da yumuşak kenarlar efekti uygulamak için, bir şeklin kenarları etrafında pürüzsüz ve bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha nazik ve incelikli bir görünüm ekler; hafif, daha yumuşak bir görünüme ihtiyaç duyan tasarımlar için mükemmeldir. Sunumunuzdaki çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

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

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parlama gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Autoshape'ler, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerinde uygulanır.