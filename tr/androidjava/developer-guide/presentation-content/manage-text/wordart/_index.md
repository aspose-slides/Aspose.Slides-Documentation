---
title: Android'de WordArt Efektleri Oluştur ve Uygula
linktitle: WordArt
type: docs
weight: 110
url: /tr/androidjava/wordart/
keywords:
- WordArt
- WordArt Oluştur
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Yansıma Efekti
- Parıltı Efekti
- WordArt Dönüşümü
- 3B Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'da WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin Android'de profesyonel metinle sunumları geliştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, metni dolgu, kenarlık, gölge, yansıma, parıltı, dönüşüm ve 3B biçimlendirme ile stil vermenizi sağlar. Bu makale, Microsoft Office kurulu olmadan, Aspose.Slides for Android via Java kullanarak PowerPoint sunumlarında bu efektleri nasıl oluşturup özelleştireceğinizi açıklar.

## **Basit Bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

Aşağıdaki örnekler, metin, yazı tipi, desen dolgu ve kenarlık ayarlanarak basit bir WordArt stili oluşturur.

Her örnek yeni bir sunum oluşturur ve ilk slayta bir dikdörtgen ekler; giriş dosyasına gerek yoktur. İlk örnek, metni "Aspose.Slides" olarak ayarlar. Şeklin konumu ve boyutları puan cinsinden ölçülür:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Biçimlendirmenin daha belirgin olmasını sağlamak için yazı tipini Arial Black, 36 puan olarak ayarlayın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Koyu turuncu ön plan ve beyaz arka planlı bir [SmallGrid](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/patternstyle/#SmallGrid) deseni uygulayın, ardından 1 puan genişliğinde siyah bir metin kenarlığı ekleyin:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygulama**

Aşağıdaki örnekler, metne gölgeler, yansımalar, parıltı, dönüşümler ve 3B efektler nasıl uygulanır gösterir.

### **Dış Gölge Efektlerini Uygula**

Dış gölge, metnin arkasına bir gölge koyarak derinlik ekler. Renk, yön, mesafe, bulanıklık yarıçapı, ölçek ve eğim gibi özelliklerini özelleştirebilirsiniz.

Bu örnek, [enableOuterShadowEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) metodunu çağırır ve 4 puan bulanıklık yarıçapı, 230 derece yön ve 30 puan mesafe ile siyah bir gölge ayarlar. Ölçek değerleri 100 gölgenin boyutunu korur, yatay eğim ise 20 derece eğer. Alfa dönüşümü ise opaklığını %32 olarak ayarlar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan metin:

![Dış Gölge efekti](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Dış ve önceden ayarlanmış gölgeler birlikte kullanıldığında, yalnızca dış gölge uygulanır.
- Dış ve iç gölgeler aynı anda kullanılırsa, ortaya çıkan etki PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te etki iki katına çıkar, PowerPoint 2007'de ise sadece dış gölge uygulanır.
{{% /alert %}}

### **Yansıma Efektlerini Uygula**

Yansıma, metnin ayna gibi bir kopyasını oluşturur. Konumunu, ölçeğini, bulanıklığını ve opaklığını ayarlayarak görünümünü kontrol edebilirsiniz.

Bu örnek, [enableReflectionEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) metodunu çağırır ve -%100 ölçekle yansıma dikey olarak ters çevirir. 0,5 puan bulanıklık yarıçapı ve 4,72 puan mesafe kullanır. Opaklık, yansımanın 0% ile 60% arasındaki konumlarında %60'tan %0,9'a düşer:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan metin:

![Yansıma efekti](reflection_effect.png)

### **Parıltı Efektlerini Uygula**

Parıltı, metnin etrafına yumuşak renkli bir kenarlık ekler. Renk, opaklık ve yarıçapını ayarlayarak efekti kontrol edebilirsiniz.

Bu örnek, [enableGlowEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) metodunu çağırır ve %54 opaklık ve 7 puan yarıçapta kırmızı bir parıltı uygular:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan metin:

![Parıltı efekti](glow_effect.png)

### **WordArt Dönüşümlerini Uygula**

WordArt dönüşümleri, bir metin bloğunu bükebilir, uzatabilir veya saptırabilir.

[setTransform](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) yöntemini [ArchUpPour](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) değerine ayarlayarak tüm metin çerçevesini yukarı doğru eğrileştirin:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java, önceden tanımlanmış bir dizi [dönüşüm tipi](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textshapetype/) sunar.
{{% /alert %}}

### **Şekillere ve Metne 3B Efektler Uygula**

Bir şekle veya şeklin metnine 3B efektler uygulayabilirsiniz. Koni kenarları (bevel), ekstrüzyon, aydınlatma ve kamera ayarları ortaya çıkan görünümü kontrol eder.

Aşağıdaki örnek, [ThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/) kullanarak dikdörtgene dairesel kenarlıklar, turuncu ekstrüzyon ve koyu kırmızı bir kontur ekler. Kenarlık boyutları, ekstrüzyon yüksekliği, kontur genişliği ve derinlik puan cinsinden ölçülür. Plastik bir malzeme, Z ekseni etrafında 40 derece döndürülmüş dengeli aydınlatma ve bir perspektif kamera görünümünü tanımlar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan şekil:

![Şekil 3B efekti](shape_3D_effect.png)

Bu örnek, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--) kullanarak metne benzer 3B biçimlendirme uygular. Daha küçük kenarlıklar harf kenarlarını şekillendirirken, ekstrüzyon ve aydınlatma metne derinlik katar:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan metin:

![Metin 3B efekti](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Metne veya şekillerine 3B efektlerin uygulanması—ve bu efektler arasındaki etkileşim—belirli kurallara tabidir. Metin ve onu içeren şekli kapsayan bir sahneyi düşünün. Bir 3B efekt, nesnenin 3B temsilini ve yerleştirildiği sahneyi içerir.

- Şekil ve metin için sahne her ikisi için de ayarlanmışsa, şeklin sahnesi öncelikli olur ve metnin sahnesi göz ardı edilir.
- Şeklin kendi sahnesi yok ama bir 3B temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3B efekti yoksa, düz olarak kabul edilir ve 3B efekt yalnızca metne uygulanır.

Bu davranışlar, [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/#getLightRig--) ve [ThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/threedformat/#getCamera--) metodlarıyla ilgilidir.
{{% /alert %}}

Metni düz ve okunaklı tutarken şeklin 3B biçimlendirmesini korumak için, her iki ayarın karşılaştırmasını ve eksiksiz bir Java örneğini görmek üzere [Keep Text Flat on a 3D Shape](/slides/tr/androidjava/3d-presentation/) sayfasına bakın.

## **SSS**

**WordArt efektlerini farklı yazı tipleri veya betiklerle (ör. Arapça, Çince) kullanabilir miyim?**

Evet, Aspose.Slides for Android via Java Unicode'u destekler ve tüm büyük yazı tipleri ve betiklerle çalışır. Gölge, dolgu ve kenarlık gibi WordArt efektleri, dil ne olursa olsun uygulanabilir, ancak yazı tipi kullanılabilirliği ve renderleme sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt ana tasarım öğelerine uygulayabilir miyim?**

Evet, ana slaytlardaki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine WordArt efektleri uygulayabilirsiniz. Ana taslakta yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Biraz. Gölge, parıltı ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme meta verileri nedeniyle dosya boyutunu hafifçe artırabilir, ancak fark genellikle ihmal edilebilir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu önizleyebilir miyim?**

Evet, [ISlide.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/#getImage--) veya [IShape.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getImage--) kullanarak WordArt içeren slaytları görüntülere (ör. PNG, JPEG) renderleyebilirsiniz. Bu, tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte veya ekranda önizlemenizi sağlar.