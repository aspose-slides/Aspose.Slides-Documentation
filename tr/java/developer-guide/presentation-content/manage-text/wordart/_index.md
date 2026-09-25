---
title: Java'da WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/java/wordart/
keywords:
- WordArt
- WordArt oluştur
- WordArt şablonu
- WordArt efekti
- gölge efekti
- yansıma efekti
- parlaklık efekti
- WordArt dönüşümü
- 3B efekti
- dış gölge efekti
- iç gölge efekti
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin Java'da profesyonel metinle sunumları geliştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri metni dolgular, kenarlıklar, gölgeler, yansımalar, parlaklık, dönüşümler ve 3B biçimlendirme ile stillendirmeye olanak tanır. Bu makale, Microsoft Office yüklü olmadan Aspose.Slides for Java kullanarak PowerPoint sunumlarında bu efektleri nasıl oluşturup özelleştireceğinizi açıklar.

## **Basit bir WordArt Şablonu Oluşturma ve Metne Uygulama**

Aşağıdaki örnekler, metni, yazı tipini, desen dolgusu ve kenarlığı ayarlayarak basit bir WordArt stili oluşturur.

Her örnek yeni bir sunum oluşturur ve ilk slaytına bir dikdörtgen ekler; hiçbir giriş dosyasına ihtiyaç duyulmaz. İlk örnek metni "Aspose.Slides" olarak ayarlar. Şeklin konumu ve boyutları puan cinsinden ölçülür:

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

Yazı tipini Arial Black, 36 puan olarak ayarlayarak formatlamayı daha belirgin hale getirin:

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

Koyu turuncu ön plan ve beyaz arka plan ile bir [SmallGrid](https://reference.aspose.com/slides/tr/java/com.aspose.slides/patternstyle/#SmallGrid) deseni uygulayın, ardından 1 puan genişliğinde siyah bir metin kenarlığı ekleyin:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color darkOrange = new Color(255, 140, 0);
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

Oluşan metin:

![The simple WordArt template](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygulama**

Aşağıdaki örnekler, gölgeler, yansımalar, parlaklık, dönüşümler ve 3B efektlerin metne nasıl uygulanacağını gösterir.

### **Dış Gölge Efektlerini Uygulama**

Bir dış gölge, metnin arkasına gölge ekleyerek derinlik kazandırır. Rengini, yönünü, uzaklığını, bulanıklaştırma yarıçapını, ölçeğini ve eğimini özelleştirebilirsiniz.

Bu örnek, [enableOuterShadowEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) metodunu çağırır ve 4 puan bulanıklaştırma yarıçapı, 230 derece yön ve 30 puan uzaklıkta siyah bir gölge ayarlar. Ölçek değerleri %100 gölgenin boyutunu korur, yatay eğim ise %20 açıyla eğilir. Alfa dönüşümü opaklığı %32 olarak ayarlar:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Oluşan metin:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Dış ve ön tanımlı gölgeler birlikte kullanıldığında, yalnızca dış gölge uygulanır.
- Dış ve iç gölgeler aynı anda kullanılırsa, sonuç PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013’te efekt iki katı olur, PowerPoint 2007’de ise yalnızca dış gölge uygulanır.
{{% /alert %}}

### **Yansıma Efektlerini Uygulama**

Yansıma, metnin ayna gibi bir kopyasını oluşturur. Konumunu, ölçeğini, bulanıklığını ve opaklığını ayarlayarak görünümünü kontrol edebilirsiniz.

Bu örnek, [enableReflectionEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effectformat/#enableReflectionEffect--) metodunu çağırır ve yansımayı %‑100 ölçekle dikey ters çevirir. 0,5 puan bulanıklaştırma yarıçapı ve 4,72 puan uzaklık kullanır. Opaklık, yansımanın %0‑%60 konumları arasında %60’tan %0,9’a düşer:

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

Oluşan metin:

![The Reflection effect](reflection_effect.png)

### **Parlaklık Efektlerini Uygulama**

Parlaklık, metnin etrafına yumuşak renkli bir kenarlık ekler. Rengini, opaklığını ve yarıçapını ayarlayarak efekti kontrol edebilirsiniz.

Bu örnek, [enableGlowEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effectformat/#enableGlowEffect--) metodunu çağırır ve %54 opaklıkta, 7 puan yarıçaplı kırmızı bir parlaklık uygular:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Oluşan metin:

![The Glow effect](glow_effect.png)

### **WordArt Dönüşümlerini Uygulama**

WordArt dönüşümleri, bir metin bloğunu bükebilir, uzatabilir veya şekillendirebilir.

[setTransform](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframeformat/#setTransform-int-) metodunu [ArchUpPour](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textshapetype/#ArchUpPour) ile ayarlayarak tüm metin çerçevesini yukarı doğru kıvrımlı hale getirin:

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

Oluşan metin:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}

Aspose.Slides for Java, önceden tanımlı bir dizi [dönüşüm türü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textshapetype/) sunar.

{{% /alert %}}

### **Şekillere ve Metne 3B Efektleri Uygulama**

Bir şekle veya metnine 3B efektler uygulayabilirsiniz. Keskin kenarlar, ekstrüzyon, aydınlatma ve kamera ayarları sonucu belirler.

Aşağıdaki örnek, [ThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/) kullanarak dikdörtgene dairesel keskin kenarlar, turuncu ekstrüzyon ve koyu kırmızı kontur ekler. Keskin kenar boyutları, ekstrüzyon yüksekliği, kontur genişliği ve derinlik puan cinsindendir. Plastik bir malzeme, Z ekseni etrafında 40 derece döndürülmüş dengeli aydınlatma ve perspektif kamera görünümünü tanımlar:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
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

Oluşan şekil:

![The shape 3D effect](shape_3D_effect.png)

Bu örnek, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframeformat/#getThreeDFormat--) aracılığıyla metne benzer bir 3B biçimlendirme uygular. Daha küçük keskin kenarlar harf kenarlarını şekillendirirken, ekstrüzyon ve aydınlatma metne derinlik katar:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
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

Oluşan metin:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Metne veya şekline uygulanan 3B efektlerin ve bu efektlerin etkileşiminin belirli kuralları vardır. Metni ve onu içeren şekli içeren bir sahneyi düşünün. Bir 3B efekt, nesnenin 3B temsilini ve yerleştirildiği sahneyi içerir.

- Eğer hem şekil hem de metin için bir sahne ayarlanmışsa, şeklin sahnesi önceliklidir ve metnin sahnesi göz ardı edilir.
- Şeklin kendi sahnesi yok ancak bir 3B temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3B efekti yoksa, düz kabul edilir ve 3B efekt yalnızca metne uygulanır.

Bu davranışlar, [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/#getLightRig--) ve [ThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/java/com.aspose.slides/threedformat/#getCamera--) metodlarıyla ilgilidir.
{{% /alert %}}

Metnin düz kalmasını ve şeklin 3B biçimlendirmesini korumak için, hem ayarların karşılaştırıldığı hem de eksiksiz bir Java örneğinin bulunduğu [3B Şekilde Metni Düz Tutma](/slides/tr/java/3d-presentation/) bölümüne bakın.

## **SSS**

**Farklı yazı tipleri veya diller (ör. Arapça, Çince) ile WordArt efektlerini kullanabilir miyim?**

Evet, Aspose.Slides for Java Unicode’u destekler ve tüm yaygın yazı tipleri ve dillerle çalışır. WordArt efektleri (gölge, dolgu, kenarlık vb.) dilinden bağımsız olarak uygulanabilir; ancak yazı tipi bulunabilirliği ve render performansı sistem yazı tiplerine bağlıdır.

**WordArt efektlerini slayt master öğelerine uygulayabilir miyim?**

Evet, başlık yer tutucuları, altbilgi alanları veya arka plan metni gibi master slayt üzerindeki şekillere WordArt efektleri ekleyebilirsiniz. Master düzeninde yapılan değişiklikler, ilişkili tüm slaytlara otomatik olarak yansır.

**WordArt efektleri sunum dosyasının boyutunu etkiler mi?**

Biraz. Gölgeler, parlaklık ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme meta verileri eklediği için dosya boyutunu hafifçe artırabilir; ancak fark genellikle ihmal edilebilir düzeydedir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu önizleyebilir miyim?**

Evet, [ISlide.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/#getImage--) metodunu kullanarak WordArt içeren slaytları (PNG, JPEG vb.) resim olarak oluşturabilir veya [IShape.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getImage--) ile tek tek şekilleri resme dönüştürebilirsiniz. Böylece tam sunumu kaydetmeden veya dışa aktarmadan hafızada veya ekranda önizleme yapabilirsiniz.