---
title: JavaScript Kullanarak Sunumlarda Şekil Animasyonları Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/nodejs-java/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyonu uygula
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js via Java kullanarak PowerPoint sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [grafikler](/slides/tr/nodejs-java/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya bileşenlerine yaşam katar.

## **Neden Sunumlarda Animasyon Kullanılır?**

* bilgi akışını kontrol et
* önemli noktaları vurgula
* izleyicilerinizin ilgisini veya katılımını artır
* içeriği okumayı, özümsemeyi veya işlemeyi kolaylaştır
* okuyucularınızın veya izleyicilerinizin sunumdaki önemli bölümlere dikkatini çek

PowerPoint, **entrance**, **exit**, **emphasis** ve **motion paths** kategorilerinde animasyonlar ve animasyon efektleri için birçok seçenek ve araç sunar. 

## **Aspose.Slides'ta Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için gereken sınıfları ve türleri `Aspose.Slides.Animation` ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttype) sayenumerasyonunda **150'den fazla animasyon efekti** sağlar. Bu efektler temelde PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for Node.js via Java, bir şeklin içindeki metne animasyon uygulamanızı sağlar.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slayt referansı edinin.
3. `rectangle` bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape) ekleyin.
4. [AutoShape.addTextFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) kullanarak metin ekleyin.
5. Efektlerin ana sırasını alın.
6. [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape) bir animasyon efekti ekleyin.
7. `TextAnimation.setBuildType` metodunu `BuildType` sayenumerasyonundan gelen değerle çağırın.
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu Javascript kodu, `Fade` efektini AutoShape'e nasıl uygulayacağınızı ve metin animasyonunu *By 1st Level Paragraphs* değerine nasıl ayarlayacağınızı gösterir:

```javascript
// Sunum dosyasını temsil eden bir sunum sınıfını örnekleştirir.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Metinle yeni AutoShape ekler
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Slaydın ana sırasını alır.
    var sequence = sld.getTimeline().getMainSequence();
    // Şekle Fade animasyon efekti ekler
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Şekil metnini birinci seviye paragraflara göre canlandırır
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // PPTX dosyasını diske kaydet
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Metne animasyon uygulamanın yanı sıra tek bir [Paragraf](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph) üzerine de animasyon uygulayabilirsiniz. Bakın [**Animasyonlu Metin**](/slides/tr/nodejs-java/animated-text/).

{{% /alert %}} 

## **PictureFrame'e Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slayt referansı edinin.
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe) ekleyin veya edinin.
4. Efektlerin ana sırasını alın.
5. [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe) bir animasyon efekti ekleyin.
6. Sunumu bir PPTX dosyası olarak diske yazın.

Bu Javascript kodu, `Fly` efektini bir resim çerçevesine nasıl uygulayacağınızı gösterir:

```javascript
// Sunum dosyasını temsil eden bir sunum sınıfını örnekleştirir.
var pres = new aspose.slides.Presentation();
try {
    // Sunumun görüntü koleksiyonuna eklenecek resmi yükler
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Slayta resim çerçevesi ekler
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Slaydın ana sırasını alır.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Resim çerçevesine Soldan Uçuş animasyon efekti ekler
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // PPTX dosyasını diske kaydeder
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekle Animasyon Uygulama**

1.   [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2.   İndeks aracılığıyla bir slayt referansı edinin.
3.   `rectangle` bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape) ekleyin.
4.   `Bevel` bir [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape) ekleyin (bu nesne tıklandığında animasyon oynatılır).
5.   `Bevel` şekli üzerinde bir efekt sırası oluşturun.
6.   Özel bir `UserPath` oluşturun.
7.   `UserPath`'e hareket komutları ekleyin.
8.   Sunumu bir PPTX dosyası olarak diske yazın.

Bu Javascript kodu, bir şekle `PathFootball` (yol futbolu) efektini nasıl uygulayacağınızı gösterir:

```javascript
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekleştirir.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // PathFootBall animasyon efektini ekler
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Bir çeşit "button" oluşturur.
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Bu buton için bir efekt sırası oluşturur.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Özel bir kullanıcı yolu oluşturur. Nesnemiz yalnızca butona tıklandıktan sonra hareket ettirilecektir.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Oluşturulan yol boş olduğundan hareket komutları ekler
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // PPTX dosyasını diske yazar
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Şekle Uygulanan Animasyon Efektlerini Al**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini elde etmek için [Sequence](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/) sınıfından `getEffectsByShape` metodunun nasıl kullanılacağını gösterir.

**Örnek 1: Normal bir slayt üzerindeki bir şekle uygulanan animasyon efektlerini alın**

Önceden, PowerPoint sunumlarındaki şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumunda ilk normal slaydın ilk şekline uygulanan efektleri nasıl alacağınızı gösterir:

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Slaydın ana animasyon sırasını alır.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // İlk slayttaki ilk şekli alır.
    var shape = firstSlide.getShapes().get_Item(0);

    // Şekle uygulanan animasyon efektlerini alır.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Örnek 2: Yer tutuculardan miras alınanlar dahil tüm animasyon efektlerini alın**

Normal bir slayttaki bir şeklin, düzen slaytında ve/veya ana slaytta yer tutucuları varsa ve bu yer tutuculara animasyon efektleri eklenmişse, o zaman şeklin tüm efektleri slayt gösterisi sırasında oynatılacak, yer tutuculardan miras alınanlar dahil.

Diyelim ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var; tek bir slaytı var ve sadece altbilgi şeklinde "Made with Aspose.Slides" metni bulunuyor ve şekle **Random Bars** efekti uygulanmış.

![Slayt şekil animasyon efekti](slide-shape-animation.png)

Ayrıca, **Split** efektinin **layout** slaydındaki altbilgi yer tutucusuna uygulandığını varsayalım.

![Düzen şekil animasyon efekti](layout-shape-animation.png)

Son olarak, **Fly In** efektinin **master** slaydındaki altbilgi yer tutucusuna uygulandığını varsayalım.

![Ana slayt şekil animasyon efekti](master-shape-animation.png)

Aşağıdaki örnek kod, [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) sınıfından `getBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişmeyi ve altbilgi şekline uygulanan animasyon efektlerini, düzen ve ana slaytlardaki yer tutuculardan miras alınanlar dahil, almayı gösterir:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Normal slaydaki şeklin animasyon efektlerini al.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Düzen slaydındaki yer tutucunun animasyon efektlerini al.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Ana slaydındaki yer tutucunun animasyon efektlerini al.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Uç, Alt
Type: 134, subtype: 45            // Böl, Dikeyİçeri
Type: 126, subtype: 22            // Rastgele Çubuklar, Yatay
```

## **Animasyon Efekti Zamanlama Özelliklerini Değiştir**

Aspose.Slides for Node.js via Java, bir animasyon efektinin Zamanlama özelliklerini değiştirmenizi sağlar.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama panelidir:

![örnek1_resim](shape-animation.png)

PowerPoint Zamanlama ile [Effect.Timing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Effect#getTiming--) özellikleri arasındaki eşleşmeler şunlardır:

- PowerPoint Zamanlama **Start** açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Timing#getTriggerType--) özelliğiyle eşleşir.
- PowerPoint Zamanlama **Duration**, [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Timing#getDuration--) özelliğiyle eşleşir. Bir animasyonun (saniye cinsinden) süresi, bir döngünün tamamlanması için geçen toplam süredir.
- PowerPoint Zamanlama **Delay**, [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) özelliğiyle eşleşir.

Efekt Zamanlama özelliklerini nasıl değiştirirsiniz:

1. [Uygula](#apply-animation-to-shape) ya da animasyon efektini alın.
2. İhtiyacınız olan [Effect.Timing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Effect#getTiming--) özellikleri için yeni değerler ayarlayın.
3. Değiştirilmiş PPTX dosyasını kaydedin.

```javascript
// Sunum dosyasını temsil eden bir sunum sınıfını örnekleştirir.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Slaydın ana sırasını alır.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Ana sıranın ilk efektini alır.
    var effect = sequence.get_Item(0);
    // Efektin TriggerType'ını tıklamayla başlatacak şekilde değiştirir
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Efekt süresini değiştirir
    effect.getTiming().setDuration(3.0);
    // Efektin TriggerDelayTime'ını değiştirir
    effect.getTiming().setTriggerDelayTime(0.5);
    // PPTX dosyasını diske kaydeder
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animasyon Efekti Ses**

Aspose.Slides, animasyon efektlerinde seslerle çalışmanıza izin veren bu özellikleri sağlar:

- [setSound(IAudio value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Animasyon Efekti Sesi Ekle**

Bu Javascript kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve bir sonraki efekt başladığında nasıl durduracağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Sunuma ses koleksiyonuna ses ekler
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Slaydın ana sırasını alır.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Ana sıranın ilk efektini alır
    var firstEffect = sequence.get_Item(0);
    // Efekti "Ses Yok" için kontrol eder
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // İlk efekt için ses ekler
        firstEffect.setSound(effectSound);
    }
    // Slaydın ilk etkileşimli sırasını alır.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Efektin "Önceki sesi durdur" bayrağını ayarlar
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // PPTX dosyasını diske yazar
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Animasyon Efekti Sesini Çıkar**

1.   [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2.   İndeks aracılığıyla bir slayt referansı edinin. 
3.   Efektlerin ana sırasını alın. 
4.   Her animasyon efektine gömülmüş [setSound(IAudio value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) metodunu çıkarın.

Bu Javascript kodu, bir animasyon efektine gömülü sesin nasıl çıkarılacağını gösterir:

```javascript
// Sunum dosyasını temsil eden bir sunum sınıfını örnekleştirir.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Slaydın ana sırasını alır.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Efekt sesini bayt dizisi olarak çıkarır
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Animasyondan Sonra**

Aspose.Slides for Node.js via Java, bir animasyon efektinin After animation özelliğini değiştirmenizi sağlar.

Bu, Microsoft PowerPoint'teki Animasyon Efekti paneli ve genişletilmiş menüsüdür:

![örnek1_resim](shape-after-animation.png)

PowerPoint Effect **After animation** açılır listesi bu özelliklerle eşleşir:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) metodu, After animation tipini tanımlar;
  * PowerPoint **More Colors**, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#Color) tipine karşılık gelir;
  * PowerPoint **Don't Dim**, [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) tipine karşılık gelir (varsayılan after animation tipi);
  * PowerPoint **Hide After Animation**, [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) tipine karşılık gelir;
  * PowerPoint **Hide on Next Mouse Click**, [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) tipine karşılık gelir;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) metodu, after animation renk formatını tanımlar. Bu metod, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#Color) tipiyle birlikte çalışır. Tipi başka bir şeye değiştirirseniz, after animation rengi temizlenir.

Bu Javascript kodu, bir after animation efektini nasıl değiştireceğinizi gösterir:

```javascript
// Sunum dosyasını temsil eden bir sunum sınıfını örnekleştirir
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Ana sıranın ilk efektini alır
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // After animation tipini Renk olarak değiştirir
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // After animation kararma rengini ayarlar
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // PPTX dosyasını diske yazar
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Metni Canlandır**

Aspose.Slides, bir animasyon efektinin *Animate text* bloğuyla çalışmanıza izin veren bu özellikleri sağlar:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) efekti için *Animate text* tipini tanımlar. Şekil metni şu şekilde animasyonlanabilir:
  - Hepsi bir anda ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) tipi)
  - Kelime kelime ([AnimateTextType.ByWord](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/animatetexttype/#ByWord) tipi)
  - Harfe harfe ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/animatetexttype/#ByLetter) tipi)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) animasyonlu metin parçaları (kelimeler veya harfler) arasında bir gecikme belirler. Pozitif bir değer, efekt süresinin yüzdesini belirtir. Negatif bir değer, saniye cinsinden gecikmeyi belirtir.

Efekt Animate text özelliklerini nasıl değiştirirsiniz:

1.   [Uygula](#apply-animation-to-shape) ya da animasyon efektini alın.
2.   [setBuildType(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) metodunu [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/buildtype/#AsOneObject) değerine ayarlayarak *By Paragraphs* animasyon modunu devre dışı bırakın.
3.   Yeni değerleri [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) ve [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) özelliklerine ayarlayın.
4.   Değiştirilmiş PPTX dosyasını kaydedin.

```javascript
// Sunum dosyasını temsil eden bir sunum sınıfını örnekleştirir.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Ana sıranın ilk efektini alır
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Efektin Metin animasyon tipini "Tek Nesne Olarak" değiştirir
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Efektin Metni Canlandırma tipini "Kelimeye göre" değiştirir
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Kelimeler arasındaki gecikmeyi efekt süresinin %20'si olarak ayarlar
    firstEffect.setDelayBetweenTextParts(20.0);
    // PPTX dosyasını diske yazar
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Sunumu web'e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?**

[HTML5'e Dönüştür](/slides/tr/nodejs-java/export-to-html5/) ve animasyonlu şekiller ([setanimateshapes]()) ve geçişler ([setanimatetransitions]()) için sorumlu [options](/slides/tr/nodejs-java/aspose.slides/html5options/) ayarlarını etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

**Şekillerin z-order (katman sırası) değiştirilmesi animasyonu nasıl etkiler?**

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünürlük zamanlamasını ve tipini kontrol eder, [z-order](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/getzorderposition/) ise neyin neyi örteceğini belirler. Görünür sonuç, bunların birleşimiyle tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efekt‑ve‑şekil modeli aynı mantığı izler.)

**Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?**

Genel olarak, [animasyonlar desteklenir](/slides/tr/nodejs-java/convert-powerpoint-to-video/), ancak nadir durumlarda veya belirli efektlerde farklı renderlanabilir. Kullandığınız efektleri ve kütüphane sürümünü test etmeniz önerilir.