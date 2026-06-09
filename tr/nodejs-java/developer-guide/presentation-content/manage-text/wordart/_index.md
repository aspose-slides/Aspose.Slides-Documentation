---
title: JavaScript'te WordArt Efektleri Oluşturma ve Uygulama
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
- görünüm efekti
- parıltı efekti
- WordArt dönüşümü
- 3B efekti
- dış gölge efekti
- iç gölge efekti
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım kılavuz, geliştiricilerin sunumları profesyonel metinle iyileştirmelerine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel açıdan çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, Microsoft PowerPoint'te olduğu gibi WordArt'ı programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmasına gerek yok. Bu makale, WordArt ile çalışmanın bir genel bakışını sunar; metin dönüşümlerini, dolgu stillerini, hatları, gölgeleri ve diğer biçimlendirme seçeneklerini uygulayarak sunum içeriğinizi daha ifade edici ve çekici hale getirmenizi açıklar. WordArt, metni grafik nesnesi gibi ele almanızı sağlar. Metni daha çekici veya fark edilir kılmak için uygulanan efektler veya özel değişikliklerden oluşur.

## **Basit Bir WordArt Şablonu Oluşturma ve Metne Uygulama**

**Using Aspose.Slides**

İlk olarak, bu JavaScript kodunu kullanarak basit bir metin oluşturuyoruz:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Şimdi, bu kodla metnin yazı tipi yüksekliğini daha büyük bir değere ayarlayarak efekti daha belirgin hale getiriyoruz:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Using Microsoft PowerPoint**

Microsoft PowerPoint'te WordArt efektleri menüsüne gidin:

![todo:image_alt_text](image-20200930113926-1.png)

Sağdaki menüden önceden tanımlanmış bir WordArt efekti seçebilirsiniz. Soldaki menüden yeni bir WordArt için ayarları belirleyebilirsiniz.

Bunlar mevcut parametreler veya seçeneklerden bazılarıdır:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Burada, metne [SmallGrid](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/PatternStyle#SmallGrid) desen rengini uygular ve bu kodla 1 genişliğinde siyah bir metin kenarlığı ekleriz:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

Ortaya çıkan metin:

![todo:image_alt_text](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygulama**

**Using Microsoft PowerPoint**

Programın sınıfından, bir metne, metin bloğuna, şekle veya benzeri bir öğeye bu efektleri uygulayabilirsiniz:

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parıltı efektleri bir metne uygulanabilir; 3B Biçim ve 3B Döndürme efektleri bir metin bloğuna uygulanabilir; Yumuşak Kenarlar özelliği bir Şekil Nesnesine uygulanabilir (3B Biçim özelliği ayarlanmamış olsa da etkisi vardır). 

### **Gölge Efektlerini Uygulama**

Burada yalnızca bir metne ilişkin özellikleri ayarlamayı amaçlıyoruz. JavaScript'te bu kodla metne gölge efektini uyguluyoruz:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

Aspose.Slides API, üç tür gölgeyi destekler: OuterShadow, InnerShadow ve PresetShadow.

PresetShadow ile bir metne (önceden tanımlı değerler kullanılarak) gölge uygulayabilirsiniz. 

**Using Microsoft PowerPoint**

PowerPoint'te yalnızca bir tür gölge kullanabilirsiniz. İşte bir örnek:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides, aynı anda iki tür gölge uygulamanıza olanak tanır: InnerShadow ve PresetShadow.

**Notlar:**

- OuterShadow ve PresetShadow birlikte kullanıldığında, yalnızca OuterShadow efekti uygulanır. 
- OuterShadow ve InnerShadow aynı anda kullanılırsa, uygulanan efekt PowerPoint sürümüne bağlıdır. Örneğin PowerPoint 2013'te efekt iki katına çıkar. Ancak PowerPoint 2007'de OuterShadow efekti uygulanır. 

### **Metinlere Görünüm Uygulama**

Bu JavaScript kod örneği ile metne görünüm ekliyoruz:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Metinlere Parıltı Efekti Uygulama**

Metni parlak veya öne çıkarmak için bu kodla parıltı efektini uyguluyoruz:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Gölge, görünüm ve parıltı parametrelerini değiştirebilirsiniz. Efektlerin özellikleri metnin her bölümüne ayrı ayrı ayarlanır. 

{{% /alert %}} 

### **WordArt'ta Dönüşümleri Kullanma**

Bu kodla Transform özelliğini (tüm metin bloğu için geçerli) kullanıyoruz:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Sonuç:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Hem Microsoft PowerPoint hem de Aspose.Slides for Node.js via Java, belirli sayıda önceden tanımlı dönüşüm türü sağlar.

{{% /alert %}} 

**PowerPoint Kullanarak**

Önceden tanımlı dönüşüm türlerine erişmek için şu yolu izleyin: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides Kullanarak**

Bir dönüşüm türü seçmek için TextShapeType enum'ını kullanın. 

### **Metinlere ve Şekillere 3B Efektleri Uygulama**

Bu örnek kodla bir metin şekline 3B efekt uyguluyoruz:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Ortaya çıkan metin ve şekli:

![todo:image_alt_text](image-20200930114816-9.png)

Bu JavaScript kodu ile metne 3B efekt uyguluyoruz:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Metinlere veya şekillerine 3B efektlerin uygulanması ve efektler arasındaki etkileşimler belirli kurallara dayanır. 

Metin ve metni içeren şekil için bir sahneyi düşünün. 3B efekt, 3B nesne temsili ve nesnenin yerleştirildiği sahneyi içerir. 

- Hem şekil hem de metin için sahne ayarlanmışsa, şekil sahnesi daha yüksek önceliğe sahiptir—metin sahnesi yoksayılır. 
- Şeklin kendi sahnesi yok ama 3B temsili varsa, metin sahnesi kullanılır. 
- Aksi takdirde—şeklin başlangıçta 3B efekti yoksa—şekil düz olur ve 3B efekt yalnızca metne uygulanır. 

Bu açıklamalar, ThreeDFormat.getLightRig() ve ThreeDFormat.getCamera() metodlarıyla ilişkilidir. 

{{% /alert %}} 

## **Metinlere Dış Gölge Efektleri Uygulama**

Aspose.Slides for Node.js via Java, [**OuterShadow**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/outershadow/) ve [**InnerShadow**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/innershadow/) sınıflarını sunar; bu sınıflar [TextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textframe/) tarafından taşıyan bir metne gölge efektleri uygulamanıza olanak tanır. Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksini kullanarak referansını alın.  
3. Slayta Rectangle (dikdörtgen) tipinde bir AutoShape ekleyin.  
4. AutoShape ile ilişkili TextFrame'e erişin.  
5. AutoShape'in FillType özelliğini NoFill olarak ayarlayın.  
6. OuterShadow sınıfının bir örneğini oluşturun.  
7. Gölgenin BlurRadius (bulanıklık yarıçapı) değerini ayarlayın.  
8. Gölgenin Direction (yön) değerini ayarlayın.  
9. Gölgenin Distance (mesafe) değerini ayarlayın.  
10. RectanglelAlign (dikdörtgen hizalama) değerini TopLeft olarak ayarlayın.  
11. Gölgenin PresetColor (önceden tanımlı renk) değerini Black olarak ayarlayın.  
12. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Bu Java örnek kodu—yukarıdaki adımların bir uygulamasıdır—size bir metne dış gölge efektini nasıl uygulayacağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Slayın referansını al
    var sld = pres.getSlides().get_Item(0);
    // Dikdörtgen tipinde bir AutoShape ekle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Dikdörtgene TextFrame ekle
    ashp.addTextFrame("Aspose TextBox");
    // Metnin gölgesini elde etmek istiyorsak şekil dolgusunu devre dışı bırak
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Dış gölge ekle ve tüm gerekli parametreleri ayarla
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Sunumu diske kaydet
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekillere İç Gölge Efekti Uygulama**

Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın bir referansını alın.  
3. Rectangle tipinde bir AutoShape ekleyin.  
4. InnerShadowEffect özelliğini etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. ColorType değerini Scheme olarak ayarlayın.  
7. Scheme Color (şema rengi) değerini belirleyin.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Bu örnek kod (yukarıdaki adımlara dayanarak) size JavaScript'te iki şekil arasında bir bağlayıcı (connector) eklemenin nasıl yapılacağını gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Slayın referansını al
    var slide = pres.getSlides().get_Item(0);
    // Dikdörtgen tipinde bir AutoShape ekle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Dikdörtgene TextFrame ekle
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // InnerShadowEffect'i etkinleştir
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Tüm gerekli parametreleri ayarla
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // ColorType'ı Scheme olarak ayarla
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Scheme rengini ayarla
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Sunumu kaydet
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Farklı yazı tipleri veya skriptlerle (ör. Arapça, Çince) WordArt efektleri kullanabilir miyim?**

**Evet**, Aspose.Slides Unicode'u destekler ve tüm büyük yazı tipleri ve skriptlerle çalışır. Gölge, dolgu ve kontur gibi WordArt efektleri dili ne olursa olsun uygulanabilir; ancak yazı tipi bulunabilirliği ve görüntülenmesi sistem yazı tiplerine bağlı olabilir.

**Slide master öğelerine WordArt efektleri uygulayabilir miyim?**

**Evet**, master slaytlardaki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine WordArt efektleri uygulayabilirsiniz. Master düzeninde yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

**Biraz**. Gölge, parıltı ve degrade dolgular gibi WordArt efektleri, ek biçimlendirme meta verileri nedeniyle dosya boyutunu hafifçe artırabilir, ancak fark genellikle ihmal edilebilir.

**WordArt efektlerinin sonucunu sunumu kaydetmeden ön izleyebilir miyim?**

**Evet**, WordArt içeren slaytları [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) veya [Slide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slide/) sınıflarının `getImage` yöntemiyle görüntülere (PNG, JPEG vb.) dönüştürebilirsiniz. Böylece tam sunumu kaydetmeden veya dışa aktarmadan önce bellekte ya da ekranda ön izleme yapabilirsiniz.