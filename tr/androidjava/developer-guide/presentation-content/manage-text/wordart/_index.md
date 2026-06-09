---
title: Android'de WordArt Efektlerini Oluşturma ve Uygulama
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
- Görüntü Efekti
- Parlaklık Efekti
- WordArt Dönüşümü
- 3D Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- PowerPoint
- Sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin Java’da profesyonel metinle sunumları iyileştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel olarak çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, Microsoft PowerPoint’te olduğu gibi WordArt’ı programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office kurulumu gerektirmez. Bu makale, WordArt ile çalışmanın bir özetini sunar; metin dönüşümleri, dolgu stilleri, konturlar, gölgeler ve diğer biçimlendirme seçeneklerini nasıl uygulayacağınızı açıklayarak sunum içeriğinizi daha ifadeli ve ilgi çekici hale getirir. WordArt, metni bir grafik nesnesi olarak ele almanızı sağlar. Metni daha çekici veya fark edilir kılmak için uygulanan efektler veya özel değişikliklerden oluşur.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

**Aspose.Slides Kullanarak** 

İlk olarak, bu Java koduyla basit bir metin oluşturuyoruz: 

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
Şimdi, metnin yazı tipi yüksekliğini daha büyük bir değere ayarlayarak etkinin daha belirgin olmasını aşağıdaki kodla sağlıyoruz:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint’te WordArt efektleri menüsüne gidin:

![todo:image_alt_text](image-20200930113926-1.png)

Sağdaki menüden önceden tanımlı bir WordArt efekti seçebilirsiniz. Soldaki menüden ise yeni bir WordArt için ayarları belirleyebilirsiniz. 

Mevcut bazı parametreler veya seçenekler şunlardır:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, metne [SmallGrid](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/PatternStyle#SmallGrid) desen rengini uyguluyor ve bu kodla 1 birim genişliğinde siyah bir metin kenarlığı ekliyoruz:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Elde edilen metin:

![todo:image_alt_text](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygulayın**

**Microsoft PowerPoint Kullanarak**

Program arayüzünden bir metne, metin bloğuna, şekle veya benzer bir öğeye bu efektleri uygulayabilirsiniz:

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parlaklık efektleri bir metne; 3D Biçim ve 3D Döndürme efektleri bir metin bloğuna; Yumuşak Kenarlar özelliği ise bir Şekil Nesnesine (3D Biçim özelliği ayarlı olmasa bile) uygulanabilir. 

### **Gölge Efektlerini Uygulayın**

Burada yalnızca metinle ilgili özellikleri ayarlamayı amaçlıyoruz. Java’da aşağıdaki kodla metne gölge efekti uyguluyoruz:

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

PresetShadow ile bir metne (önceden tanımlı değerler kullanılarak) gölge uygulanabilir. 

**Microsoft PowerPoint Kullanarak**

PowerPoint’te yalnızca bir gölge türü kullanabilirsiniz. İşte bir örnek:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides aslında iki gölge türünü aynı anda uygulamanıza izin verir: InnerShadow ve PresetShadow.

**Notlar:**

- OuterShadow ve PresetShadow birlikte kullanıldığında yalnızca OuterShadow efekti uygulanır. 
- OuterShadow ve InnerShadow aynı anda kullanılırsa, uygulanacak efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013’te efekt iki katına çıkar. PowerPoint 2007’de ise OuterShadow efekti uygulanır. 

### **Metne Yansıma Efektleri Uygulayın**

Java’da aşağıdaki kod örneğiyle metne yansıma ekliyoruz:

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

### **Metne Parlaklık Efektleri Uygulayın**

Aşağıdaki kodla metne parlaklık efekti ekleyerek metnin parlamasını ya da öne çıkmasını sağlıyoruz:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Gölge, yansıma ve parlaklık parametrelerini değiştirebilirsiniz. Efekt özellikleri, metnin her bölümüne ayrı ayrı uygulanır. 

{{% /alert %}} 

### **WordArt’ta Dönüşümleri Kullanın**

Aşağıdaki kodla metnin tamamına uygulanacak Transform özelliğini kullanıyoruz:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Sonuç:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint ve Aspose.Slides for Android via Java, belirli sayıda önceden tanımlı dönüşüm türü sunar.

{{% /alert %}} 

**PowerPoint Kullanarak**

Önceden tanımlı dönüşüm türlerine erişmek için şu yolu izleyin: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides Kullanarak**

Bir dönüşüm türü seçmek için TextShapeType enum’ını kullanın. 

### **Metin ve Şekillere 3D Efektleri Uygulayın**

Aşağıdaki örnek kodla bir metin şekline 3D efekt uyguluyoruz:

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

Elde edilen metin ve şekli:

![todo:image_alt_text](image-20200930114816-9.png)

Java koduyla metne 3D efekt uyguluyoruz:

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

Metinlere veya şekillerine 3D efektlerinin uygulanması ve efektler arasındaki etkileşimler belirli kurallara dayanır. 

Bir metin ve o metni içeren şekil için bir sahne düşünün. 3D efekt, 3D nesne temsili ve nesnenin yerleştirildiği sahneyi içerir. 

- Sahne hem şekil hem de metin için ayarlandığında, şekil sahnesi daha yüksek önceliğe sahiptir—metin sahnesi yoksayılır. 
- Şeklin kendi sahnesi yoksa ancak 3D temsili varsa, metin sahnesi kullanılır. 
- Aksi takdirde—şeklin başlangıçta 3D efekti yoksa—şekil düz kalır ve 3D efekt yalnızca metne uygulanır. 

Bu açıklamalar ThreeDFormat.getLightRig() ve ThreeDFormat.getCamera() metodlarıyla ilişkilidir.

{{% /alert %}} 

## **Metne Dış Gölge Efektleri Uygulayın**
Aspose.Slides for Android via Java, [**IOuterShadow**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioutershadow/) ve [**IInnerShadow**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iinnershadow/) sınıflarını sağlar; bu sınıflar [TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/textframe/) tarafından taşıyan bir metne gölge efektleri eklemenize olanak tanır. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İndeksini kullanarak bir slayt referansı alın.  
3. Slayta Rectangle türünde bir AutoShape ekleyin.  
4. AutoShape ile ilişkili TextFrame’e erişin.  
5. AutoShape’in FillType özelliğini NoFill olarak ayarlayın.  
6. OuterShadow sınıfının bir örneğini oluşturun.  
7. Gölgenin BlurRadius değerini ayarlayın.  
8. Gölgenin Direction değerini ayarlayın.  
9. Gölgenin Distance değerini ayarlayın.  
10. RectanglelAlign değerini TopLeft olarak ayarlayın.  
11. Gölgenin PresetColor değerini Black olarak ayarlayın.  
12. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Yukarıdaki adımları uygulayan Java örnek kodu, dış gölge efektini bir metne nasıl uygulayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    // Slayt referansını al
    ISlide sld = pres.getSlides().get_Item(0);

    // Rectangle tipinde bir AutoShape ekle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Rectangle'a TextFrame ekle
    ashp.addTextFrame("Aspose TextBox");

    // Metnin gölgesini alabilmek için şekil dolgusunu devre dışı bırak
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Dış gölge ekle ve gerekli tüm parametreleri ayarla
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

## **Şekillere İç Gölge Efektleri Uygulayın**
Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Bir slayt referansı alın.  
3. Rectangle türünde bir AutoShape ekleyin.  
4. InnerShadowEffect’i etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. ColorType değerini Scheme olarak belirleyin.  
7. Scheme Color değerini ayarlayın.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Yukarıdaki adımlara dayanan bu örnek kod, Java’da iki şekil arasında bir bağlayıcı eklemenizi gösterir:

```java
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

**WordArt efektlerini farklı yazı tipleri veya alfabeler (ör. Arapça, Çince) ile kullanabilir miyim?**

Evet, Aspose.Slides Unicode’u destekler ve tüm büyük yazı tipleri ve alfabelerle çalışır. Gölge, dolgu ve kontur gibi WordArt efektleri dil bağımsız olarak uygulanabilir; ancak yazı tipi bulunabilirliği ve render edilmesi sistem yazı tiplerine bağlıdır.

**WordArt efektlerini slayt ana düzeni öğelerine uygulayabilir miyim?**

Evet, WordArt efektlerini ana slaytlardaki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine uygulayabilirsiniz. Ana düzen üzerinde yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Biraz. Gölge, parlaklık ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme meta verileri nedeniyle dosya boyutunu hafifçe artırabilir, ancak fark genellikle ihmal edilebilir düzeydedir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu önizleyebilir miyim?**

Evet, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) veya [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) arayüzlerinden `getImage` metodunu kullanarak WordArt içeren slaytları resim (PNG, JPEG vb.) olarak render edebilirsiniz. Bu sayede tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte veya ekranda önizleyebilirsiniz.