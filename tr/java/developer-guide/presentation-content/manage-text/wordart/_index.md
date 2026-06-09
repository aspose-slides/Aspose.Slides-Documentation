---
title: Java'da WordArt Efektlerini Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/java/wordart/
keywords:
- WordArt
- WordArt Oluştur
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Görüntü Efekti
- Parıltı Efekti
- WordArt Dönüşümü
- 3B Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- PowerPoint
- Sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin Java'da profesyonel metinle sunumları geliştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel olarak çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, WordArt'ı Microsoft PowerPoint'te olduğu gibi programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmasa bile. Bu makale, WordArt ile çalışmaya genel bir bakış sunar; metin dönüşümleri, dolgu stilleri, kenarlıklar, gölgeler ve diğer biçimlendirme seçeneklerini uygulayarak sunum içeriğinizi daha ifadeli ve ilgi çekici hale getirmeyi gösterir. WordArt, metni bir grafik nesnesi gibi ele almanızı sağlar. Metni daha çekici veya fark edilir kılmak için uygulanan efektler veya özel değişikliklerden oluşur.

## **Basit bir WordArt Şablonu Oluşturma ve Metne Uygulama**

**Aspose.Slides Kullanarak** 

İlk olarak, bu Java kodunu kullanarak basit bir metin oluşturuyoruz: 

``` java
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
Şimdi, bu kod aracılığıyla efektin daha belirgin olmasını sağlamak için metnin yazı tipi yüksekliğini daha büyük bir değere ayarlıyoruz: 

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint'te WordArt efektleri menüsüne gidin: 

![todo:image_alt_text](image-20200930113926-1.png)

Sağdaki menüden önceden tanımlanmış bir WordArt efekti seçebilirsiniz. Soldaki menüden ise yeni bir WordArt için ayarları belirleyebilirsiniz. 

Bunlar mevcut parametreler veya seçeneklerden bazılarıdır: 

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, metne [SmallGrid](https://reference.aspose.com/slides/tr/java/com.aspose.slides/PatternStyle#SmallGrid) desen rengini uyguluyor ve bu kodla 1 genişliğinde siyah bir metin kenarlığı ekliyoruz: 

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Oluşan metin: 

![todo:image_alt_text](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygulama**

**Microsoft PowerPoint Kullanarak**

Programa arayüzünden, bu efektleri bir metne, metin bloğuna, şekle veya benzer bir öğeye uygulayabilirsiniz: 

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parıltı efektleri bir metne uygulanabilir; 3B Biçim ve 3B Dönme efektleri bir metin bloğuna uygulanabilir; Yumuşak Kenarlar özelliği bir Şekil Nesnesine uygulanabilir (3B Biçim özelliği ayarlanmamış olsa bile etkisi vardır). 

### **Gölge Efektlerini Uygulama**

Burada yalnızca bir metinle ilgili özellikleri ayarlamayı amaçlıyoruz. Java'da bu kodu kullanarak bir metne gölge efekti uyguluyoruz: 

``` java
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
```

Aspose.Slides API üç tür gölgeyi destekler: OuterShadow, InnerShadow ve PresetShadow. 
PresetShadow ile bir metne (önceden ayarlanmış değerler kullanılarak) gölge uygulayabilirsiniz. 

**Microsoft PowerPoint Kullanarak**

PowerPoint'te bir tür gölge kullanabilirsiniz. İşte bir örnek: 

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides, aynı anda iki tür gölge uygulamanıza izin verir: InnerShadow ve PresetShadow. 

{{% alert color="primary" %}} 
Notlar: 
- OuterShadow ve PresetShadow birlikte kullanıldığında, yalnızca OuterShadow efekti uygulanır. 
- OuterShadow ve InnerShadow aynı anda kullanıldığında, ortaya çıkan veya uygulanan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki katına çıkar. Ancak PowerPoint 2007'de OuterShadow efekti uygulanır. 
{{% /alert %}} 

### **Metinlere Görünüm Uygulama**

Bu Java kod örneği ile metne görüntü ekliyoruz: 

``` java
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
```

### **Metinlere Parıltı Efekti Uygulama**

Bu kodu kullanarak metne parıltı efekti uyguluyor, böylece ışıldamasını veya öne çıkmasını sağlıyoruz: 

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

İşlemin sonucu: 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Gölge, görüntü ve parıltı parametrelerini değiştirebilirsiniz. Efektlerin özellikleri metnin her bölümüne ayrı ayrı uygulanır. 
{{% /alert %}} 

### **WordArt'ta Dönüşümleri Kullanma**

Bu kod aracılığıyla Transform özelliğini (metnin tüm bloğu için geçerli) kullanıyoruz: 

``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Sonuç: 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint ve Aspose.Slides for Java, belirli sayıda önceden tanımlanmış dönüşüm türü sunar. 
{{% /alert %}} 

**PowerPoint Kullanarak**

Önceden tanımlı dönüşüm türlerine erişmek için şu adımları izleyin: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides Kullanarak**

Dönüşüm türünü seçmek için TextShapeType enum'ını kullanın. 

### **Metin ve Şekillere 3B Efektleri Uygulama**

Bu örnek kodu kullanarak bir metin şekline 3B efekt ayarlıyoruz: 

``` java
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
```

Oluşan metin ve şekli: 

![todo:image_alt_text](image-20200930114816-9.png)

Bu Java kodu ile metne 3B efekt uyguluyoruz: 

``` java
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
```

İşlemin sonucu: 

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Metinlere veya şekillerine 3B efektlerin uygulanması ve efektler arasındaki etkileşimler belirli kurallara dayanır. 

Bir metin ve onu içeren şekil için bir sahne düşünün. 3B efekt, 3B nesne temsilini ve nesnenin yerleştirildiği sahneyi içerir. 

- Hem şekil hem de metin için sahne ayarlandığında, şekil sahnesi daha yüksek önceliğe sahiptir—metin sahnesi göz ardı edilir. 
- Şeklin kendi sahnesi yoksa ancak 3B temsili varsa, metin sahnesi kullanılır. 
- Aksi takdirde—şeklin başta 3B efekti yoksa—şekil düz olur ve 3B efekt yalnızca metne uygulanır. 

Bu açıklamalar ThreeDFormat.getLightRig() ve ThreeDFormat.getCamera() metodlarıyla ilgilidir. 
{{% /alert %}} 

## **Metinlere Dış Gölge Efektleri Uygulama**
Aspose.Slides for Java, [**IOuterShadow**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioutershadow/) ve [**IInnerShadow**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iinnershadow/) sınıflarını sağlar; bu sınıflar [TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/textframe/) taşıyan bir metne gölge efektleri uygulamanıza izin verir. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İndeksini kullanarak bir slayt referansı alın.  
3. Slayta Dikdörtgen tipinde bir AutoShape ekleyin.  
4. AutoShape ile ilişkili TextFrame'e erişin.  
5. AutoShape'in FillType özelliğini NoFill olarak ayarlayın.  
6. OuterShadow sınıfını örnekleyin.  
7. Gölgenin BlurRadius değerini ayarlayın.  
8. Gölgenin Direction (yön) değerini ayarlayın.  
9. Gölgenin Distance (mesafe) değerini ayarlayın.  
10. RectanglelAlign değerini TopLeft olarak ayarlayın.  
11. Gölgenin PresetColor (önceden ayarlanmış renk) değerini Black olarak ayarlayın.  
12. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

```java
Presentation pres = new Presentation();
try {
    // Slaytın referansını al
    ISlide sld = pres.getSlides().get_Item(0);

    // Dikdörtgen tipinde bir AutoShape ekle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Dikdörtgene TextFrame ekle
    ashp.addTextFrame("Aspose TextBox");

    // Metnin gölgesini alabilmek için şekil dolgusunu devre dışı bırak
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dış gölge ekle ve tüm gerekli parametreleri ayarla
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Sunumu diske kaydet
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Şekillere İç Gölge Efekti Uygulama**
Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Slaydın bir referansını alın.  
3. Dikdörtgen tipinde bir AutoShape ekleyin.  
4. InnerShadowEffect'i etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. ColorType'ı Scheme olarak ayarlayın.  
7. Scheme rengini ayarlayın.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Bu örnek kod (yukarıdaki adımlara dayanarak) Java'da iki şekil arasında bir bağlayıcı eklemenizi gösterir: 

```java
Presentation pres = new Presentation();
try {
    // Slaytın referansını al
    ISlide slide = pres.getSlides().get_Item(0);

    // Dikdörtgen türünde bir AutoShape ekle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dikdörtgene TextFrame ekle
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // İç Gölge Efektini etkinleştir
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

**Farklı yazı tipleri veya diller (ör. Arapça, Çince) ile WordArt efektlerini kullanabilir miyim?**  
Evet, Aspose.Slides Unicode'u destekler ve tüm büyük yazı tipleri ve dillerle çalışır. Gölge, dolgu ve kenarlık gibi WordArt efektleri, dil ne olursa olsun uygulanabilir; ancak yazı tipi mevcutluğu ve işlenmesi sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt ana (master) öğelerine uygulayabilir miyim?**  
Evet, başlık yer tutucuları, altbilgiler veya arka plan metni gibi master slaytlardaki şekillere WordArt efektleri uygulayabilirsiniz. Master düzeninde yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosyasının boyutunu etkiler mi?**  
Biraz. Gölge, parıltı ve degrade doldurma gibi WordArt efektleri, ek biçimlendirme meta verileri nedeniyle dosya boyutunu hafifçe artırabilir, ancak fark genellikle ihmal edilebilir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu ön izleyebilir miyim?**  
Evet, [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) veya [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) arayüzlerinin `getImage` metodunu kullanarak WordArt içeren slaytları görüntülere (ör. PNG, JPEG) dönüştürebilirsiniz. Böylece tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte veya ekranda ön izleyebilirsiniz.