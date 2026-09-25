---
title: Node.js'te WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/nodejs-java/wordart/
keywords:
- WordArt
- WordArt oluştur
- WordArt şablonu
- WordArt efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
- WordArt dönüşümü
- 3B efekti
- dış gölge efekti
- iç gölge efekti
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'da WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin Node.js'te profesyonel metinle sunumları geliştirmesine yardımcı olur."
---
## **Overview**

WordArt efektleri, metni dolgu, kenarlık, gölge, yansıma, parıltı, dönüşüm ve 3B biçimlendirme ile stilize etmenizi sağlar. Bu makale, Microsoft Office yüklü olmadan, Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında bu efektlerin nasıl oluşturulacağını ve özelleştirileceğini açıklar.

## **Create a Simple WordArt Template and Apply It to Text**

Aşağıdaki örnekler, metni, yazı tipini, desen dolgusunu ve kenarlığı ayarlayarak basit bir WordArt stili oluşturur.

Her örnek yeni bir sunum oluşturur ve ilk slayta bir dikdörtgen ekler; hiçbir giriş dosyasına ihtiyaç yoktur. İlk örnek, metni "Aspose.Slides" olarak ayarlar. Şeklin konumu ve boyutları punto cinsindendir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Biçimlendirmeyi daha belirgin hale getirmek için yazı tipini 36 punto Arial Black olarak ayarlayın:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Koyu turuncu ön plan ve beyaz arka planla bir [SmallGrid] (https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/patternstyle/#SmallGrid) deseni uygulayın, ardından 1 punto genişliğinde siyah bir metin kenarlığı ekleyin:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Oluşan metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Apply Other WordArt Effects**

Aşağıdaki örnekler, gölgeler, yansımalar, parıltılar, dönüşümler ve 3B efektlerin metne nasıl uygulanacağını gösterir.

### **Apply Outer Shadow Effects**

Dış gölge, metnin arkasına bir gölge ekleyerek derinlik kazandırır. Renk, yön, mesafe, bulanıklaştırma yarıçapı, ölçek ve eğim gibi özelliklerini özelleştirebilirsiniz.

Bu örnek, [enableOuterShadowEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) metodunu çağırır ve 4 nokta bulanıklaştırma yarıçapı, 230 derece yön ve 30 nokta mesafe ile siyah bir gölge ayarlar. Ölçek değeri 100 gölgenin boyutunu korur, yatay eğim ise 20 derece ile gölgeyi eğer. Alfa dönüşümü opaklığı %32 olarak belirler:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Oluşan metin:

![Dış Gölge efekti](outer_shadow_effect.png)

{{% alert color="info" title="Not" %}}
- Dış ve önceden ayarlanmış gölgeler aynı anda kullanıldığında yalnızca dış gölge uygulanır.
- Dış ve iç gölgeler aynı anda kullanıldığında, sonuç PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki kat olur, PowerPoint 2007'de yalnızca dış gölge uygulanır.
{{% /alert %}}

### **Apply Reflection Effects**

Yansıma, metnin yansıtılmış bir kopyasını oluşturur. Konum, ölçek, bulanıklık ve opaklık ayarlarıyla görünümünü kontrol edebilirsiniz.

Bu örnek, [enableReflectionEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) metodunu çağırır ve yansımayı -100% ölçekle dikey olarak ters çevirir. 0,5 nokta bulanıklaştırma yarıçapı ve 4,72 nokta mesafe kullanır. Opaklık, yansımadaki konum %0 ile %60 arasında %60'tan %0,9'a düşer:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Oluşan metin:

![Yansıma efekti](reflection_effect.png)

### **Apply Glow Effects**

Parıltı, metnin etrafına yumuşak renkli bir kenarlık ekler. Renk, opaklık ve yarıçap ayarlarıyla efekti kontrol edebilirsiniz.

Bu örnek, [enableGlowEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) metodunu çağırır ve %54 opaklığa sahip kırmızı bir parıltı uygular; yarıçap 7 noktadır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Oluşan metin:

![Parıltı efekti](glow_effect.png)

### **Apply WordArt Transformations**

WordArt dönüşümleri, bir metin bloğunu bükebilir, uzatabilir veya eğebilir.

[setTransform](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#setTransform) metodunu [ArchUpPour](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) ile ayarlayarak tüm metin çerçevesini yukarı doğru kavisli hale getirin:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Oluşan metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="info" title="Not" %}}
Aspose.Slides for Node.js via Java, önceden tanımlanmış bir dizi [dönüşüm türü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textshapetype/) sağlar.
{{% /alert %}}

### **Apply 3D Effects to Shapes and Text**

Bir şekle veya şeklin metnine 3B efektler uygulayabilirsiniz. Burulma, ekstrüzyon, aydınlatma ve kamera ayarları nihai görünümü belirler.

Aşağıdaki örnek, dikdörtgene dairesel köşe yumuşatmaları, turuncu ekstrüzyon ve koyu kırmızı kontur eklemek için [ThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/) kullanır. Köşe yumuşatma boyutları, ekstrüzyon yüksekliği, kontur genişliği ve derinlik punto cinsindendir. Plastik bir malzeme, Z ekseni etrafında 40 derece döndürülmüş dengeli aydınlatma ve perspektif kamera görünümünü tanımlar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Oluşan şekil:

![Şekil 3B efekti](shape_3D_effect.png)

Bu örnek, [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) aracılığıyla metne benzer 3B biçimlendirme uygular. Daha küçük köşe yumuşatmaları harf kenarlarını şekillendirirken, ekstrüzyon ve aydınlatma metne derinlik kazandırır:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Oluşan metin:

![Metin 3B efekti](text_3D_effect.png)

{{% alert color="info" title="Not" %}}
Metne veya şekline 3B efektlerin uygulanması ve bu efektlerin etkileşimi belirli kurallara tabidir. Metni ve onu içeren şekli içeren bir sahneyi düşünün. Bir 3B efekt, nesnenin 3B temsili ve yerleştirildiği sahneyi kapsar.

- Eğer sahne hem şekil hem de metin için ayarlanmışsa, şeklin sahnesi önceliklidir ve metnin sahnesi göz ardı edilir.
- Şeklin kendi sahnesi yoksa ancak bir 3B temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3B efekti yoksa, düz olarak değerlendirilir ve 3B efekt yalnızca metne uygulanır.

Bu davranışlar, [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getLightRig) ve [ThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/threedformat/#getCamera) metodlarıyla ilgilidir.
{{% /alert %}}

Metnin düz kalmasını ve şeklin 3B biçimlendirmesini korumak için, her iki ayarın karşılaştırmasını ve tam bir JavaScript örneğini içeren [3B Şekilde Metni Düz Tutma](/slides/tr/nodejs-java/3d-presentation/) sayfasına bakın.

## **FAQ**

**Farklı yazı tipleri veya alfabeler (ör. Arapça, Çince) ile WordArt efektlerini kullanabilir miyim?**

Evet, Aspose.Slides for Node.js via Java Unicode desteği sunar ve tüm büyük yazı tipleri ve alfabelerle çalışır. WordArt efektleri (gölge, dolgu, kenarlık vb.) dil fark etmeksizin uygulanabilir; ancak yazı tipi bulunabilirliği ve renderlama sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt master öğelerine uygulayabilir miyim?**

Evet, başlık yer tutucuları, alt bilgi alanları veya arka plan metni gibi master slayt üzerindeki şekillere WordArt efektleri uygulayabilirsiniz. Master düzeninde yapılan değişiklikler, ilişkilendirilmiş tüm slaytlara yansır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Bir miktar etkiler. Gölge, parıltı ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme metası eklediği için dosya boyutunu hafifçe artırabilir, ancak fark genellikle önemsiz düzeydedir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu önizleyebilir miyim?**

Evet, WordArt içeren slaytları [Slide.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/#getImage) ile görüntülere (PNG, JPEG vb.) dönüştürebilir veya bireysel şekilleri [Shape.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage) ile renderlayabilirsiniz. Bu sayede tam sunumu kaydetmeden veya dışa aktarmadan önce bellekte ya da ekranda önizleme yapabilirsiniz.