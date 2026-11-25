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
- parıltı efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, [dolgu](/slides/tr/java/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilirsiniz, vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri iki veya daha fazla etkinin bir araya getirildiği, güzel görünmesi bilinen kombinasyonlardır. Bu şekilde, bir preset seçerek farklı efektleri test etmek veya birleştirmek için zaman harcamazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunumunuzun tasarımıyla eşleşecek şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Dış gölge, bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlar. Gölge, şeklin kenarlarının dışına uzanarak şeklin slayt üzerinde yükselmiş gibi görünmesini yaratır. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun aydınlatması ve stiliyle eşleşecek şekilde ayarlayın.

Bu Java kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) nasıl uygulanacağını gösterir:

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

### **İç Gölge Uygula**

Bir şablonun görsel stilini yeniden üretirken, bir kartın veya panelin geriye doğru gömülmüş bir görünüm kazanması için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların iç kısmını karartır.

[enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklık yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Java örneği, açık mavi bir kart oluşturur, koyu gri bir iç gölge ekler ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derecedir, mesafesi 7 puan ve bulanıklık yarıçapı 6 puandır:

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

İç gölgeyi kaldırmak için şeklin effect formatında [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) metodunu çağırın.

### **Preset Gölge Uygula, Değiştir ve Kaldır**

[enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) metodunu çağırın ve bir [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/) seçmek için [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) metodunu kullanın. Stilleri değiştirmek için aynı şekilde preset'i değiştirin. Gölgeyi, dolgu ve kenarlığı koruyarak kaldırmak için [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) metodunu çağırın.

Bu örnek, bir slaytta yan yana dört aşamayı gösterir. Her iki gölge de 10 puan kaydırılmıştır. 225° yön, ilk gölgeyi dikdörtgenin sol üstüne yerleştirirken, 45° yön ikinci gölgeyi sağ alta yerleştirir.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Orijinal | İlk preset | İkinci preset | Kaldırma sonrası |
| :---: | :---: | :---: | :---: |
| ![Gölge yok](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![Kaldırma sonrası gölge yok](preset_shadow_removed.png) |

## **Yansıma Efekti Uygulama**

Aspose.Slides for Java'da bir yansıma efekti uygulamak için şekillere ayna gibi bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha pulsatil ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanabilir ve tutarlı bir tasarım sağlamak için çoklu öğelere hızlıca uygulanabilir.

Bu Java kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) nasıl uygulanacağını gösterir:

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

Aspose.Slides for Java'da bir şekle parıltı efekti uygulamak için şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri ön plana çıkarır ve sunumunuza çekici ve göz alıcı bir görsel öğe ekler. Minimum kodla kolayca uygulanabilir ve slaytlarınızın genel görünümünü iyileştirir.

Bu Java kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) nasıl uygulanacağını gösterir:

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

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for Java'da yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm kazandırır; özellikle nazik, yumuşak bir görünüm gerektiren tasarımlar için idealdir. İstediğiniz etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu Java kodu, bir şekle [yumuşak kenarlar efekti](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) nasıl uygulanacağını gösterir:

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

Şekil bulanıklığını kullanarak bir şeklin dolgu ve kenarlığını yumuşatın, şekli düzenlenebilir tutun. Şeklin effect formatında [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) metodunu çağırın. Yarıçap, noktalar (1/72 inç) cinsinden ölçülür: negatif olmayan bir değer kullanın, daha büyük değerler daha güçlü bulanıklık üretir. Yarıçap sıfır ise görünüm değişmez.

[getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) ayarı, etkinin görülebilir sınırlarını kontrol eder. `false` olduğunda, bulanıklık orijinal boyanmış sınırlarla, kenar dahil, kırpılır. `true` olduğunda, bulanıklık bu sınırların dışına uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı dolgu, kenarlık ve şekil boyutları kullanılarak yapılmıştır. Üst satır `grow = false`; alt satır `grow = true`.

![Orijinal dikdörtgen, 5 ve 15 noktalık bulanıklaştırma yarıçaplarıyla, grow devre dışı ve etkin iken karşılaştırma](shape_blur_comparison.png)

Bu Java örneği, turuncu bir dikdörtgen oluşturur, koyu mavi bir kenarlık ekler, 5 puanlık bir bulanıklık uygular ve ardından aynı dikdörtgene tekrar [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) çağırarak 15 puanlık bir bulanıklığa günceller. Her iki bulanıklaştırılmış durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) metodunu çağırarak bulanıklığı kaldırır ve şekli kaydeder.

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

Şekil bulanıklığı dolgu ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti, şeklin kenarlarını soluklaştırırken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görüntüye dönüştürmeden doğrudan şeklin effect formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplanmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt, tüm grup üzerinde uygulanır.