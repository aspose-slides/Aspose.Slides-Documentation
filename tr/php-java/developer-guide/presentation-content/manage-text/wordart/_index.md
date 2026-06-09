---
title: PHP'de WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/php-java/wordart/
keywords:
- WordArt
- WordArt Oluştur
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Görünüm Efekti
- Parıltı Efekti
- WordArt Dönüşümü
- 3D Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- PowerPoint
- Sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin sunumları profesyonel metinle zenginleştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt etkileri, PowerPoint sunumlarınıza görsel olarak çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, WordArt'ı Microsoft PowerPoint'te olduğu gibi programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office yüklü olmadan. Bu makale, WordArt ile çalışmaya genel bir bakış sunar; metin dönüşümlerini, dolgu stillerini, konturları, gölgeleri ve diğer biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir ve sunum içeriğinizi daha ifade edici ve ilgi çekici hâle getirir. WordArt, metni grafiksel bir nesne gibi işlemeyi sağlar. Metni daha çekici veya fark edilir kılmak için uygulanmış etkiler veya özel değişikliklerden oluşur.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

**Aspose.Slides Kullanarak** 

İlk olarak, bu PHP kodunu kullanarak basit bir metin oluşturuyoruz:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Şimdi, bu kod aracılığıyla etkiyi daha belirgin hâle getirmek için metnin yazı tipi yüksekliğini daha büyük bir değere ayarlıyoruz:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint'te WordArt efektleri menüsüne gidin:

![todo:image_alt_text](image-20200930113926-1.png)

Sağdaki menüden önceden tanımlanmış bir WordArt efektini seçebilirsiniz. Soldaki menüden yeni bir WordArt için ayarları belirtebilirsiniz. 

Bunlar, mevcut bazı parametreler veya seçeneklerdir:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, metne [SmallGrid](https://reference.aspose.com/slides/tr/php-java/aspose.slides/patternstyle/#SmallGrid) desen rengini uyguluyor ve bu kodla 1 genişliğinde siyah bir metin kenarlığı ekliyoruz:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

```

Ortaya çıkan metin:

![todo:image_alt_text](image-20200930114108-4.png)

## **Diğer WordArt Efektlerini Uygulama**

**Microsoft PowerPoint Kullanarak**

Program arayüzünden, bu efektleri bir metne, metin bloğuna, şekle veya benzeri bir öğeye uygulayabilirsiniz:

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parıltı efektleri bir metne; 3D Biçim ve 3D Döndürme efektleri bir metin bloğuna; Yumuşak Kenarlar özelliği bir Şekil Nesnesine uygulanabilir (3D Biçim özelliği ayarlı olmasa bile etkisi vardır). 

### **Gölge Efektlerini Uygula**

Burada yalnızca bir metinle ilgili özellikleri ayarlamayı amaçlıyoruz. Bu kodu kullanarak metne gölge efekti uyguluyoruz :

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);

```

Aspose.Slides API'si üç tür gölgeyi destekler: OuterShadow, InnerShadow ve PresetShadow. 

PresetShadow ile bir metne (önceden ayarlanmış değerleri kullanarak) gölge uygulayabilirsiniz. 

**Microsoft PowerPoint Kullanarak**

PowerPoint'te tek bir gölge türü kullanabilirsiniz. İşte bir örnek:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides, aynı anda iki tür gölge uygulamanıza olanak tanır: InnerShadow ve PresetShadow.

**Notlar:** 

- OuterShadow ve PresetShadow birlikte kullanıldığında, yalnızca OuterShadow efekti uygulanır. 
- OuterShadow ve InnerShadow aynı anda kullanılırsa, ortaya çıkan veya uygulanan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki katına çıkar. Ancak PowerPoint 2007'de OuterShadow efekti uygulanır. 

### **Metne Yansıma Efektlerini Uygula**

Bu kod örneğiyle metne yansıma ekliyoruz :

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **Metne Parıltı Efektlerini Uygula**

Bu kodu kullanarak metne parıltı efekti uyguluyor ve metnin parlamasını veya öne çıkmasını sağlıyoruz:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Gölge, yansıma ve parıltı parametrelerini değiştirebilirsiniz. Efekt özellikleri metnin her bölümü için ayrı ayrı ayarlanır. 
{{% /alert %}} 

### **WordArt'ta Dönüşümleri Kullanma**

Bu kodla Transform özelliğini (metnin tüm bloğuna özgü) kullanıyoruz:

```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
```

Sonuç:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint ve Aspose.Slides for PHP via Java, belirli sayıda önceden tanımlanmış dönüşüm tipi sunar. 
{{% /alert %}} 

**PowerPoint Kullanarak**

Önceden tanımlanmış dönüşüm tiplerine erişmek için şu adımları izleyin: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides Kullanarak**

Dönüşüm tipini seçmek için TextShapeType enum'ını kullanın. 

### **Metin ve Şekillere 3D Efektleri Uygula**

Bu örnek kodla bir metin şekline 3D efekti ayarlıyoruz:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Ortaya çıkan metin ve şekli:

![todo:image_alt_text](image-20200930114816-9.png)

Bu PHP kodu ile metne 3D efekti uyguluyoruz:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Metinlere veya şekillerine 3D efektlerinin uygulanması ve efektler arasındaki etkileşimler belirli kurallara dayanır.

Bir metin ve o metni içeren şekil için bir sahne düşünün. 3D efekti, 3D nesne temsili ve nesnenin yerleştirildiği sahneyi içerir.

- Sahne hem şekil hem de metin için ayarlandığında, şekil sahnesi daha yüksek önceliğe sahiptir—metin sahnesi yok sayılır.
- Şeklin kendi sahnesi yok ama 3D temsili varsa, metin sahnesi kullanılır.
- Aksi takdirde—şeklin başlangıçta 3D efekti yoksa—şekil düz olur ve 3D efekt sadece metne uygulanır.

Bu açıklamalar ThreeDFormat.getLightRig() ve ThreeDFormat.getCamera() metodlarına bağlanır. 
{{% /alert %}} 

## **Metne Dış Gölge Efektleri Uygula**
Aspose.Slides for PHP via Java, [OuterShadow](https://reference.aspose.com/slides/tr/php-java/aspose.slides/outershadow/) ve [InnerShadow](https://reference.aspose.com/slides/tr/php-java/aspose.slides/innershadow/) sınıflarını sağlar; bu sınıflar, [TextFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/textframe/) içindeki bir metne gölge efektleri uygulamanıza imkan verir. Aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. İndeksini kullanarak bir slayt referansı alın.
3. Slayta Dikdörtgen tipinde bir AutoShape ekleyin.
4. AutoShape ile ilişkili TextFrame'e erişin.
5. AutoShape'in FillType özelliğini NoFill olarak ayarlayın.
6. OuterShadow sınıfının bir örneğini oluşturun.
7. Gölgenin BlurRadius değerini ayarlayın.
8. Gölgenin Direction (yön) değerini ayarlayın.
9. Gölgenin Distance (mesafe) değerini ayarlayın.
10. RectanglelAlign özelliğini TopLeft olarak ayarlayın.
11. Gölgenin PresetColor değerini Black olarak ayarlayın.
12. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.

Bu örnek kod —yukarıdaki adımların bir uygulaması— bir metne dış gölge efektini nasıl uygulayacağınızı gösterir:

```php
  $pres = new Presentation();
  try {
    # Slayt referansını al
    $sld = $pres->getSlides()->get_Item(0);
    # Dikdörtgen tipinde bir AutoShape ekle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Dikdörtgene TextFrame ekle
    $ashp->addTextFrame("Aspose TextBox");
    # Metnin gölgesini alabilmek için şekil dolgusunu devre dışı bırak
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Dış gölge ekle ve gerekli tüm parametreleri ayarla
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Sunumu diske kaydet
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Şekillere İç Gölge Efektleri Uygula**
Aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Slaytın bir referansını alın.
3. Dikdörtgen tipinde bir AutoShape ekleyin.
4. InnerShadowEffect'i etkinleştirin.
5. Gerekli tüm parametreleri ayarlayın.
6. ColorType'ı Scheme olarak ayarlayın.
7. Scheme rengini belirleyin.
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.

Bu örnek kod (yukarıdaki adımlara dayanarak) iki şekil arasında bir bağlayıcı eklemenizi gösterir :

```php
  $pres = new Presentation();
  try {
    # Slayt referansını al
    $slide = $pres->getSlides()->get_Item(0);
    # Dikdörtgen tipinde bir AutoShape ekle
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Dikdörtgene TextFrame ekle
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # İç Gölge Efektini etkinleştir
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Gerekli tüm parametreleri ayarla
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # RenkTipini Scheme olarak ayarla
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Şema Rengini ayarla
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Sunumu kaydet
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**WordArt efektlerini farklı yazı tipleri veya betiklerle (ör. Arapça, Çince) kullanabilir miyim?**

Evet, Aspose.Slides Unicode'u destekler ve tüm büyük yazı tipleri ve betiklerle çalışır. Gölge, dolgu ve kontur gibi WordArt efektleri dili ne olursa olsun uygulanabilir; ancak yazı tipi bulunabilirliği ve renderleme sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt ana şablon öğelerine uygulayabilir miyim?**

Evet, ana slaytlardaki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine WordArt efektleri uygulayabilirsiniz. Ana şablonda yapılan değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosyasının boyutunu etkiler mi?**

Biraz. Gölge, parıltı ve degrade dolgu gibi WordArt efektleri, ek biçimlendirme meta verileri nedeniyle dosya boyutunu biraz artırabilir, ancak fark genellikle önemsizdir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu ön izleyebilir miyim?**

Evet, [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) veya [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) sınıflarının `getImage` yöntemiyle WordArt içeren slaytları görüntülere (ör. PNG, JPEG) dönüştürebilirsiniz. Bu sayede tam sunumu kaydetmeden ya da dışa aktarmadan önce bellekte veya ekranda ön izleme yapabilirsiniz.