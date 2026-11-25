---
title: Android'de Sunumlarda Şekil Efektlerini Uygula
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/androidjava/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıtma efekti
- parlama efekti
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

PowerPoint'teki etkiler bir şekli öne çıkarmak için kullanılabilirken, [dolgu](/slides/tr/androidjava/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar oluşturabilir, şeklin parlaklığını yayabilir vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle PowerPoint, **Preset** altında seçenekler sunar. Preset seçenekleri, iyi görünmesi bilinen iki veya daha fazla etkinin kombinasyonlarıdır. Böylece bir ön ayar seçerek, hoş bir kombinasyon bulmak için farklı efektleri test etmek veya birleştirmek için zaman harcamazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Android via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Dış gölgeyi, bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş gibi görünmesini sağlar. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun ışıklandırması ve stiline uygun şekilde ayarlayın.

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

### **İç Gölge Uygula**

Bir şablonun görsel stilini yeniden üretecekseniz, kartın veya panelin gömülü bir görünüme sahip olması için iç gölgeyi kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünürken, iç gölge kenarların içini gölgeler.

[enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklık yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Java örneği, koyu gri bir iç gölgeye sahip açık mavi bir kart oluşturur ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derecedir, mesafesi 7 puan ve bulanıklık yarıçapı 6 puandır:

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

![İç gölgeyle açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için şeklin efekt formatında [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) çağırın.

### **Ön Ayarlı Gölge Uygula, Değiştir ve Kaldır**

[enablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) çağırın ve bir [PresetShadowType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presetshadowtype/) seçmek için [setPreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresetshadow/#setPreset-int-) kullanın. Aynı şekil üzerinde stilleri değiştirmek için ön ayarı değiştirin. Doldurmayı ve kenarlığı koruyarak gölgeyi kaldırmak için [disablePresetShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) çağırın.

Bu örnek, bir slayt üzerinde yan yana dört aşamayı gösterir. Her iki gölge de 10 puan kaydırılmıştır. 225° yön ilk gölgeyi dikdörtgenin üstüne ve soluna, 45° yön ise ikincisini altına ve sağına yerleştirir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

| Orijinal | İlk ön ayar | İkinci ön ayar | Kaldırıldıktan sonra |
| :---: | :---: | :---: | :---: |
| ![Gölge yok](preset_shadow_original.png) | ![Üst Sol Gölge](preset_shadow_top_left.png) | ![Alt Sağ Gölge](preset_shadow_bottom_right.png) | ![Kaldırıldıktan sonra gölge yok](preset_shadow_removed.png) |

## **Yansıtma Efekti Uygulama**

Aspose.Slides for Android via Java'da bir yansıtma efekti uygulamak için şekillere aynalı bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit bir kodla uygulanması kolaydır ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu Java kodu, bir şekle [yansıtma efekti](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) nasıl uygulanacağını gösterir:

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

![Yansıtma efekti](reflection_effect.png)

## **Parıltı Efekti Uygulama**

Aspose.Slides for Android via Java'da bir şekle parıltı efekti uygulamak için şekillerin etrafına yumuşak ve ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarır ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Az kodla uygulanması kolaydır ve slaytlarınızın genel görünümünü iyileştirir.

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

Aspose.Slides for Android via Java'da bir yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve rafine bir görünüm ekler; nazik ve yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Yarıçap gibi parametreleri kolayca ayarlayarak sunumunuzdaki çeşitli şekillerde istenen etkiyi elde edebilirsiniz.

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

Şekil bulanıklığını, şeklin dolgusunu ve kenarlığını yumuşatmak için kullanın; şekil düzenlenebilir kalır. Şeklin efekt formatında [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) çağırın. Yarıçap puan (1/72 inç) cinsindendir: negatif olmayan bir değer kullanın; daha büyük değerler daha güçlü bulanıklık üretir. Sıfır yarıçap görünümü değiştirmez.

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) ayarı, etkinin görünür sınırlarını kontrol eder. `false` olduğunda bulanıklık, orijinal boyanmış sınırların (kenarlık dahil) içine kırpılır. `true` olduğunda bulanıklık bu sınırların ötesine uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı dolgu, kenarlık ve şekil boyutlarını bütün boyunca kullanır. Üst satır `grow = false`; alt satır `grow = true`.

![Orijinal dikdörtgen, 5 ve 15 puan bulanıklık yarıçaplarıyla, grow devre dışı ve etkin durumlarda karşılaştırması](shape_blur_comparison.png)

Bu Java örneği, turuncu bir dikdörtgen ve koyu mavi bir kenarlık oluşturur, 5 puan bulanıklık uygular ve ardından [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) tekrar çağrılarak 15 puana yükseltir. İki bulanık durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) çağırarak şekli bulanıklık olmadan kaydeder.

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

Şekil bulanıklığı, dolgu ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti şeklin kenarlarını soluklaştırırken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek şekli bir görüntüye dönüştürmeden doğrudan şeklin efekt formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıtma ve parlama gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomoşekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, grup içindeki tüm şekillere etkileri uygulayabilirsiniz. Efekt tüm grup üzerine uygulanır.