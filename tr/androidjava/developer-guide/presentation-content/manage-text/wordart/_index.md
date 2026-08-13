---
title: Android'de WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/androidjava/wordart/
keywords:
- WordArt
- WordArt oluştur
- WordArt şablonu
- WordArt efekti
- gölge efekti
- görünüm efekti
- parıltı efekti
- WordArt dönüşümü
- 3B efekti
- dış gölge efekti
- iç gölge efekti
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android için Aspose.Slides'ta WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin Java'da profesyonel metinle sunumları geliştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel açıdan çekici ve stilize metinler eklemenizi sağlar. Aspose.Slides ile geliştiriciler, Microsoft PowerPoint’te olduğu gibi WordArt’ı programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office kurulumu gerektirmez. Bu makale, WordArt ile çalışmaya yönelik bir genel bakış sunar; metin dönüşümleri, dolgu stilleri, kenarlıklar, gölgeler ve diğer biçimlendirme seçeneklerini nasıl uygulayacağınızı açıklar. WordArt, metni bir grafik nesne olarak ele almanıza olanak tanır. Metni daha çekici veya belirgin hâle getirmek için uygulanan efektler veya özel değişiklikler içerir.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

**Aspose.Slides Kullanarak** 

İlk olarak, bu Java kodunu kullanarak basit bir metin oluşturuyoruz: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Şimdi, bu kod aracılığıyla metnin yazı tipi yüksekliğini daha büyük bir değere ayarlayarak etkinin daha belirgin olmasını sağlıyoruz: 

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint’te WordArt efektleri menüsüne gidin:

![todo:image_alt_text](image-20200930113926-1.png)

Sağ menüden önceden tanımlanmış bir WordArt efekti seçebilirsiniz. Sol menüden yeni bir WordArt için ayarları belirleyebilirsiniz. 

Mevcut bazı parametreler veya seçenekler şunlardır:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, metne [SmallGrid](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PatternStyle#SmallGrid) desen rengini uygular ve bu kodla 1 birim genişliğinde siyah bir metin kenarlığı ekleriz:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

Oluşan metin:

![todo:image_alt_text](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygula**

**Microsoft PowerPoint Kullanarak**

Program arayüzünden bu efektleri bir metne, metin bloğuna, şekle veya benzer bir öğeye uygulayabilirsiniz:

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parıltı efektleri bir metne, 3B Biçim ve 3B Döndürme efektleri bir metin bloğuna; Yumuşak Kenarlar özelliği ise bir Şekil Nesnesine uygulanabilir (3B Biçim özelliği ayarlanmamış olsa bile etkisi vardır). 

### **Gölge Efektlerini Uygula**

Burada yalnızca bir metinle ilgili özellikleri ayarlamayı amaçlıyoruz. Bu Java kodu ile metne gölge etkisi uyguluyoruz:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

Aspose.Slides API üç tür gölgeyi destekler: OuterShadow, InnerShadow ve PresetShadow. 

PresetShadow ile önceden tanımlı değerleri kullanarak bir metne gölge uygulayabilirsiniz. 

**Microsoft PowerPoint Kullanarak**

PowerPoint’te bir tür gölge kullanılabilir. İşte bir örnek:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides aynı anda iki tür gölgeyi uygulamanıza izin verir: InnerShadow ve PresetShadow.

**Notlar:**

- OuterShadow ve PresetShadow birlikte kullanıldığında yalnızca OuterShadow efekti uygulanır. 
- OuterShadow ve InnerShadow aynı anda kullanılırsa, uygulanacak efekt PowerPoint sürümüne bağlıdır. Örneğin PowerPoint 2013’te efekt iki katına çıkar. PowerPoint 2007’de ise OuterShadow efekti uygulanır. 

### **Metne Yansıma Efektleri Uygula**

Bu Java kod örneği ile metne yansıma ekliyoruz:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
    if (pres != null) pres.dispose();
}
```

### **Metne Parıltı Efektleri Uygula**

Bu kodla metne parıltı efekti ekleyerek göz alıcı hâle getiriyoruz:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
Gölge, yansıma ve parıltı parametrelerini değiştirebilirsiniz. Efekt özellikleri metnin her bölümüne ayrı ayrı uygulanır. 
{{% /alert %}} 

### **WordArt içinde Dönüşümleri Kullan**

Bu kodla tüm metin bloğuna ait Transform özelliğini (yerleşik) kullanıyoruz:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

Sonuç:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Hem Microsoft PowerPoint hem de Android için Java üzerinden Aspose.Slides, belirli sayıda önceden tanımlı dönüşüm türü sunar. 
{{% /alert %}} 

**PowerPoint Kullanarak**

Önceden tanımlı dönüşüm türlerine ulaşmak için şu yolu izleyin: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides Kullanarak**

Bir dönüşüm türü seçmek için TextShapeType enum’ını kullanın. 

### **Metin ve Şekillere 3B Efektler Uygula**

Bu örnek kodla bir metin şekline 3B efekt uyguluyoruz:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Oluşan metin ve şekli:

![todo:image_alt_text](image-20200930114816-9.png)

Bu Java kodu ile metne 3B efekt uyguluyoruz:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
Metinlere veya şekillerine 3B efektlerin uygulanması ve efektler arasındaki etkileşim belirli kurallara dayanır. 

Bir metin ve o metni içeren şekil için bir sahne düşünün. 3B efekt, 3B nesne temsili ve nesnenin yerleştirildiği sahneyi içerir. 

- Sahne hem şekil hem de metin için ayarlanmışsa, şekil sahnesi daha yüksek önceliğe sahiptir—metin sahnesi yok sayılır. 
- Şeklin kendi sahnesi yok, ancak 3B temsili varsa, metin sahnesi kullanılır. 
- Aksi takdirde—şeklin başlangıçta 3B etkisi yoksa—şekil düz kalır ve 3B efekt yalnızca metne uygulanır. 

Bu açıklamalar ThreeDFormat.getLightRig() ve ThreeDFormat.getCamera() metodlarıyla ilişkilidir. 
{{% /alert %}} 

## **Metne Dış Gölge Efektleri Uygula**
Android için Java üzerinden Aspose.Slides, [**IOuterShadow**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioutershadow/) ve [**IInnerShadow**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinnershadow/) sınıflarını sağlar; bunlar [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) üzerinden taşınan bir metne gölge efekti uygulamanıza olanak tanır. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfından bir örnek oluşturun.  
2. İndeksini kullanarak bir slayt referansı alın.  
3. Slayta Rectangle tipinde bir AutoShape ekleyin.  
4. AutoShape ile ilişkili TextFrame’e erişin.  
5. AutoShape’in FillType özelliğini NoFill olarak ayarlayın.  
6. OuterShadow sınıfının bir örneğini oluşturun.  
7. Gölgenin BlurRadius değerini ayarlayın.  
8. Gölgenin Direction (yön) değerini ayarlayın.  
9. Gölgenin Distance (mesafe) değerini ayarlayın.  
10. RectangleAlign değerini TopLeft olarak belirleyin.  
11. Gölgenin PresetColor değerini Black olarak ayarlayın.  
12. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Bu adımları gösteren Java örnek kodu, dış gölge efektini bir metne nasıl uygulayacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Slayt referansını al
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle tipinde bir AutoShape ekle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle'a TextFrame ekle
    ashp.addTextFrame("Aspose TextBox");

    // Metnin gölgesini elde etmek için şekil dolgusunu devre dışı bırak
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dış gölge ekle ve tüm gerekli parametreleri ayarla
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    // Sunumu diske kaydet
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Şekillere İç Gölge Efektleri Uygula**
Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfından bir örnek oluşturun.  
2. Slayt referansını alın.  
3. Rectangle tipinde bir AutoShape ekleyin.  
4. InnerShadowEffect’i etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. ColorType değerini Scheme olarak belirleyin.  
7. Scheme rengini ayarlayın.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Bu adımlara dayanan örnek kod, Java’da iç gölge efektini bir metne nasıl uygulayacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Slayt referansını al
    ISlide slide = pres.getSlides().get_Item(0);

    // Rectangle tipinde bir AutoShape ekle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Rectangle'a TextFrame ekle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // InnerShadowEffect'i etkinleştir
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Gerekli tüm parametreleri ayarla
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // ColorType'ı Scheme olarak ayarla
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Scheme rengini ayarla
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Sunumu kaydet
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

### WordArt efektlerini farklı yazı tipleri veya betikler (ör. Arapça, Çince) ile kullanabilir miyim?

Evet, Aspose.Slides Unicode’u destekler ve tüm büyük yazı tipleri ve betiklerle çalışır. Gölge, dolgu ve kenarlık gibi WordArt efektleri dili ne olursa olsun uygulanabilir; ancak yazı tipi kullanılabilirliği ve render alınması sistem yazı tiplerine bağlı olabilir.

### WordArt efektlerini slayt ana şablonu öğelerine uygulayabilir miyim?

Evet, başlık yer tutucuları, dipnotlar veya arka plan metni gibi ana slayt üzerindeki şekillere WordArt efektleri uygulayabilirsiniz. Ana şablondaki değişiklikler tüm ilişkili slaytlara yansır.

### WordArt efektleri sunum dosyasının boyutunu etkiler mi?

Bir miktar. Gölge, parıltı ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme meta verileri eklediği için dosya boyutunu hafifçe artırabilir; ancak fark genellikle gözle görülür derecede değildir.

### WordArt efektlerinin sonucunu sunumu kaydetmeden önizleyebilir miyim?

Evet, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) veya [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) arayüzlerinden `getImage` metodunu kullanarak WordArt içeren slaytları PNG, JPEG gibi görüntülere aktarabilirsiniz. Bu sayede tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte ya da ekranda önizleyebilirsiniz.