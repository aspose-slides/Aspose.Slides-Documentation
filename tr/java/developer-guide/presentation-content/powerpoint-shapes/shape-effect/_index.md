---
title: Java Kullanarak Sunumlarda Şekil Efektlerini Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/java/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parlama efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, [dolgu](/slides/tr/java/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parıltısını yayabilir vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iyi görünmesi bilinen iki veya daha fazla efektin kombinasyonlarıdır. Böylece, bir preset seçerek farklı efektleri deneme veya birleştirme için zaman harcamadan hoş bir kombinasyon bulabilirsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklaştırma yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygulama**

Bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slaytın üzerinde yükselmiş gibi görünmesini sağlar. Renk, yön, mesafe ve bulanıklaştırma yarıçapını şablonunuzun ışıklandırması ve stiline göre ayarlayın.

Bu Java kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) uygulamayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygulama**

Bir şablonun görsel stilini yeniden oluştururken, bir kartın veya panelin geriye doğru eğimli görünmesini sağlamak için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş gibi görünmesini sağlarken, iç gölge kenarların içini gölgeler.

İlk olarak [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklaştırma yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Java örneği, açık mavi bir kartı koyu gri bir iç gölge ile oluşturur ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derece, mesafesi 7 puan ve bulanıklaştırma yarıçapı 6 puandır:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![İç gölgelikli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için, şeklin effect format'ında [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for Java'da bir yansıma efekti uygulamak için, şekillere ayna benzeri bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit bir kodla kolayca uygulanabilir ve tutarlı bir tasarım için birden fazla öğeye hızlıca uygulanmasını sağlar.

Bu Java kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) uygulamayı gösterir:

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

Aspose.Slides for Java'da bir şekle parlama efekti uygulamak için, şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimal bir kodla kolayca uygulanabilir ve slaytlarınızın genel görünümünü iyileştirir.

Bu Java kodu, bir şekle [parlama efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) uygulamayı gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Aspose.Slides for Java'da yumuşak kenarlar efekti uygulamak için, bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm katar ve nazik, daha yumuşak bir görünüm gerektiren tasarımlar için idealdir. Sunumunuzdaki çeşitli şekillerde istenen etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu Java kodu, bir şekle [yumuşak kenarlar efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) uygulamayı gösterir:

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

## **Bulanıklaştırma Efekti Uygulama**

Şekil bulanıklaştırma özelliğini kullanarak bir şeklin dolgu ve kenarlığını yumuşatabilir, şekli düzenlenebilir tutabilirsiniz. Şeklin effect format'ında [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metodunu çağırın. Yarıçap, puan cinsinden ölçülür (1/72 inç): negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bulanıklık üretir. Yarıçap sıfır olduğunda görünüm değişmez.

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) ayarı, efektin görünür sınırlarını kontrol eder. `false` ile bulanıklık, kenarlık dahil olmak üzere orijinal boyanmış sınırlara kesilir. `true` ile bulanıklık bu sınırların ötesine uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı dolgu, kenarlık ve şekil boyutlarını kullanır. Üst satır `grow = false`; alt satır `grow = true` kullanır.

![Büyüme devre dışı ve etkin olduğunda 5 ve 15 puan bulanık yarıçaplarıyla karşılaştırılan orijinal dikdörtgen](shape_blur_comparison.png)

Bu Java örneği, koyu mavi bir kenarlığa sahip turuncu bir dikdörtgen oluşturur, 5 puanlık bir bulanıklık uygular ve ardından [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metodunu tekrar çağırarak 15 puanlık bir bulanıklığa günceller. Her iki bulanık durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) metodunu çağırarak şekli bulanık olmadan kaydeder.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

Şekil bulanıklaştırma, dolgu ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti, şeklin kenarlarını soluklaştırır, gölge bulanıklaştırma ise yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görüntüye dönüştürmeden bulanıklığı doğrudan şeklin effect format'ına uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, bir şekil üzerinde gölge, yansıma ve parlama gibi farklı efektleri birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerine uygulanır.