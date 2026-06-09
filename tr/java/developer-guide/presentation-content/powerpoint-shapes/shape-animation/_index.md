---
title: Java Kullanarak Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/java/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyonu al
- animasyonu çıkar
- efekt ekle
- efekti al
- efekti çıkar
- efekt sesi
- animasyonu uygula
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [grafiklere](https://docs.aspose.com/slides/tr/java/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya bileşenlerine canlılık katar. 

## **Sunumlarda Neden Animasyon Kullanılır?**

* bilginin akışını kontrol edin  
* önemli noktaları vurgulayın  
* izleyicilerinizin ilgisini veya katılımını artırın  
* içeriğin okunmasını, sindirilmesini veya işlenmesini kolaylaştırın  
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çekin  

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorilerinde animasyonlar ve animasyon efektleri için birçok seçenek ve araç sunar. 

## **Aspose.Slides'ta Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmanız için gerekli sınıfları ve tipleri `Aspose.Slides.Animation` ad alanı altında sağlar,  
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttype) enum'ı altında **150'den fazla animasyon efekti** sunar. Bu efektler esasen PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.  

## **Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for Java, bir şeklin içindeki metne animasyon uygulamanıza olanak tanır. 

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slayt referansı edinin.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) ekleyin.  
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) içine metin ekleyin.  
5. Efektlerin ana dizisini alın.  
6. [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) üzerine bir animasyon efekti ekleyin.  
7. `TextAnimation.BuildType` özelliğini `BuildType` enum'ından gelen değerle ayarlayın.  
8. Sunumu bir PPTX dosyası olarak diske yazın.  

Bu Java kodu, AutoShape'e `Fade` efektini nasıl uygulayacağınızı ve metin animasyonunu *1. Düzey Paragraflar* değerine nasıl ayarlayacağınızı gösterir:

```java
// Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Metin ile yeni AutoShape ekler
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Slaytın ana dizisini alır.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Şekle Fade animasyon etkisi ekler
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Şekil metnini 1. seviye paragraflar ile animasyonlandırır
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX dosyasını diske kaydeder
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 
Metne animasyon uygulamanın yanı sıra tek bir [Paragraf](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph) üzerine de animasyon uygulayabilirsiniz. Bakın [**Animasyonlu Metin**](/slides/tr/java/animated-text/).
{{% /alert %}} 

## **PictureFrame'e Animasyon Uygulama**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slayt referansı alın.  
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe) ekleyin veya alın.  
4. Efektlerin ana dizisini alın.  
5. [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe) üzerine bir animasyon efekti ekleyin.  
6. Sunumu bir PPTX dosyası olarak diske yazın.  

Bu Java kodu, bir picture frame'e `Fly` efektini nasıl uygulayacağınızı gösterir:

```java
// Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
Presentation pres = new Presentation();
try {
    // Sunum görüntü koleksiyonuna eklenecek resmi yükler
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Slayta resim çerçevesi ekler
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Slaytın ana dizisini alır.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Resim çerçevesine Soldan Uçuş animasyon etkisi ekler
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX dosyasını diske kaydeder
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Şekle Animasyon Uygulama**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slayt referansı alın.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) ekleyin.  
4. Bir `Bevel` [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) ekleyin (bu nesne tıklandığında animasyon oynatılır).  
5. Bevel şekli üzerinde bir efekt dizisi oluşturun.  
6. Özel bir `UserPath` oluşturun.  
7. `UserPath`'e hareket komutları ekleyin.  
8. Sunumu bir PPTX dosyası olarak diske yazın.  

Bu Java kodu, bir şekle `PathFootball` (path football) efektini nasıl uygulayacağınızı gösterir:

```java
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Mevcut şekil için sıfırdan PathFootball etkisi oluşturur.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall animasyon etkisini ekler
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Bir çeşit "düğme" oluşturur.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Bu düğme için bir efekt dizisi oluşturur.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Özel bir kullanıcı yolu oluşturur. Nesnemiz sadece düğmeye tıklandıktan sonra hareket edecektir.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Oluşturulan yol boş olduğu için hareket komutları ekler.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBvh.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX dosyasını diske yazar
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekle Uygulanan Animasyon Efektlerini Alma**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/) arayüzündeki `getEffectsByShape` metodunun nasıl kullanılacağını gösterir.

**Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini alma**

Daha önce PowerPoint sunumlarındaki şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir:

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Slaytın ana animasyon dizisini alır.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // İlk slayttaki ilk şekli alır.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Şekle uygulanan animasyon efektlerini alır.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Örnek 2: Yer tutuculardan devralınanlar da dahil olmak üzere tüm animasyon efektlerini alma**

Eğer normal bir slayttaki bir şeklin, yerleşim slaytı ve/veya ana slayt üzerindeki yer tutucuları varsa ve bu yer tutuculara animasyon efektleri eklenmişse, şeklin tüm efektleri slayt gösterisi sırasında oynatılır; bu etkiler yer tutuculardan devralınanları da içerir.

Varsayalım ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var ve tek bir slaytı sadece **Made with Aspose.Slides** metni içeren bir altbilgi şekli içeriyor ve bu şekle **Random Bars** efekti uygulanmış.

![Slayt şekli animasyon efekti](slide-shape-animation.png)

Ayrıca altbilgi yer tutucusuna **layout** slaytında **Split** efekti uygulandığını varsayalım.

![Yerleşim şekli animasyon efekti](layout-shape-animation.png)

Ve son olarak, **master** slaytındaki altbilgi yer tutucusuna **Fly In** efekti uygulanmış.

![Ana slayt şekli animasyon efekti](master-shape-animation.png)

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arayüzündeki `getBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişmeyi ve altbilgi şekline uygulanan animasyon efektlerini, yerleşim ve ana slaytlardaki yer tutuculardan devralınanları da dahil ederek almayı gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Normal slayttaki şeklin animasyon efektlerini al.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Yerleşim slaydındaki yer tutucunun animasyon efektlerini al.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Ana slaydındaki yer tutucunun animasyon efektlerini al.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Çıktı:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Animasyon Efekti Zamanlama Özelliklerini Değiştirme**

Aspose.Slides for Java, bir animasyon efektinin Zamanlama (Timing) özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama bölmesidir:

![Animasyon Zamanlama bölmesi](shape-animation.png)

PowerPoint Zamanlama ve [Effect.Timing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IEffect#getTiming--) özellikleri arasındaki karşılıklar:

- PowerPoint Zamanlama **Start** (Başlat) açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITiming#getTriggerType--) özelliğiyle eşleşir.  
- PowerPoint Zamanlama **Duration** (Süre), [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITiming#getDuration--) özelliğiyle eşleşir. Bir animasyonun (saniye cinsinden) süresi, animasyonun bir döngüyü tamamlaması için geçen toplam süredir.  
- PowerPoint Zamanlama **Delay** (Gecikme), [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITiming#getTriggerDelayTime--) özelliğiyle eşleşir.  

Effect Timing özelliklerini şu şekilde değiştirirsiniz:

1. [Şekle animasyon uygula](#apply-animation-to-shape) ya da animasyon efektini alın.  
2. İhtiyacınız olan [Effect.Timing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IEffect#getTiming--) özelliklerine yeni değerler atayın.  
3. Değiştirilmiş PPTX dosyasını kaydedin.  

Bu Java kodu işlemi gösterir:

```java
// Sunum dosyasını temsil eden bir presentation sınıfını örnekler.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Slaytın ana dizisini alır.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ana dizinin ilk efektini alır.
    IEffect effect = sequence.get_Item(0);

    // Efektin TriggerType'ını tıklamayla başlatacak şekilde değiştirir
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Efektin süresini değiştirir
    effect.getTiming().setDuration(3f);

    // Efektin TriggerDelayTime'ını değiştirir
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX dosyasını diske kaydeder
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasyon Efekti Sesleri**

Aspose.Slides, animasyon efektlerindeki seslerle çalışmanıza olanak tanıyan aşağıdaki özellikleri sağlar: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Animasyon Efekti Sesi Ekleme**

Bu Java kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve bir sonraki efekt başladığında sesin durdurulacağını gösterir:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Sunum ses koleksiyonuna ses ekler
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Slaytın ana dizisini alır.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = sequence.get_Item(0);

    // Efekti "Ses Yok" için kontrol eder
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // İlk efekt için ses ekler
        firstEffect.setSound(effectSound);
    }

    // Slaytın ilk etkileşimli dizisini alır.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Efektin "Önceki sesi durdur" bayrağını ayarlar
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX dosyasını diske yazar
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Animasyon Efekti Sesini Çıkarma**

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeks aracılığıyla bir slayt referansı alın.  
3. Efektlerin ana dizisini edinin.  
4. Her animasyon efektiyle ilişkili gömülü [setSound(IAudio value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) sesini çıkarın.  

Bu Java kodu, bir animasyon efektine gömülü sesi nasıl çıkaracağınızı gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slaytın ana dizisini alır.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Efekt sesini byte dizisi olarak çıkarır
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animasyondan Sonra**

Aspose.Slides for Java, bir animasyon efektinin **After animation** (Animasyondan Sonra) özelliğini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Efekti bölmesi ve genişletilmiş menüsüdür:

![Animasyon Efekti bölmesi ve genişletilmiş menü](shape-after-animation.png)

PowerPoint Effect **After animation** (Animasyondan Sonra) açılır listesi aşağıdaki özelliklerle eşleşir: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) özelliği, animasyondan sonra türünü tanımlar :
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color) tipine eşittir;  
  * PowerPoint **Don't Dim** öğesi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#DoNotDim) tipine eşittir (varsayılan animasyondan sonra türüdür);  
  * PowerPoint **Hide After Animation** öğesi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) tipine eşittir;  
  * PowerPoint **Hide on Next Mouse Click** öğesi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) tipine eşittir;  
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) özelliği, bir animasyondan sonra renk formatını tanımlar. Bu özellik, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color) tipiyle birlikte çalışır. Türü başka bir tipe değiştirirseniz, animasyondan sonra renk temizlenir.  

Bu Java kodu, bir animasyondan sonra efektini nasıl değiştireceğinizi gösterir:

```java
    // Sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
    Presentation pres = new Presentation("AnimImage_out.pptx");
    try {
        ISlide firstSlide = pres.getSlides().get_Item(0);

        // Ana dizinin ilk efektini alır
        IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

        // After animation tipini Color olarak değiştirir
        firstEffect.setAfterAnimationType(AfterAnimationType.Color);

        // After animation karartma rengini ayarlar
        firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

        // PPTX dosyasını diske yazar
        pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
```

## **Metni Animasyonla**

Aspose.Slides, bir animasyon efektinin *Animate text* (Metni Animasyonla) bloğuyla çalışmanıza olanak tanıyan aşağıdaki özellikleri sağlar:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) efekti için bir metin animasyon türünü tanımlar. Şekil metni şu şekilde animasyonlanabilir:
  - Hepsi bir anda ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/tr/java/com.aspose.slides/animatetexttype/#AllAtOnce) tipi)  
  - Kelime bazında ([AnimateTextType.ByWord](https://reference.aspose.com/slides/tr/java/com.aspose.slides/animatetexttype/#ByWord) tipi)  
  - Harf bazında ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/animatetexttype/#ByLetter) tipi)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) animasyonlu metin parçaları (kelimeler veya harfler) arasındaki gecikmeyi ayarlar. Pozitif değer, efekt süresinin yüzde olarak belirlenmesini sağlar. Negatif değer ise saniye cinsinden gecikmeyi belirtir.  

Effect Animate text (Efekt Metni Animasyonla) özelliklerini şu şekilde değiştirebilirsiniz:

1. [Şekle animasyon uygula](#apply-animation-to-shape) ya da animasyon efektini alın.  
2. *By Paragraphs* (Paragraflara Göre) animasyon modunu kapatmak için `setBuildType(int value)` özelliğini [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/buildtype/#AsOneObject) değerine ayarlayın.  
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) ve [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) özelliklerine yeni değerler atayın.  
4. Değiştirilmiş PPTX dosyasını kaydedin.  

Bu Java kodu işlemi gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Efektin Metin animasyon tipini "As One Object" olarak değiştirir
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Efektin Metni Animasyon tipini "By word" olarak değiştirir
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Kelimeler arasındaki gecikmeyi efekt süresinin %20'si olarak ayarlar
    firstEffect.setDelayBetweenTextParts(20f);

    // PPTX dosyasını diske yazar
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Sunumu web'e yayınlarken animasyonların korunmasını nasıl sağlarım?**

[HTML5'e Dönüştür](/slides/tr/java/export-to-html5/) ve [seçenekleri](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/) etkinleştirerek şekil ve geçiş animasyonlarını aktif hale getirin. Düz HTML slayt animasyonlarını çalıştırmaz, HTML5 ise çalıştırır.

**Şekillerin z-order (katman sırası) değişikliği animasyonu nasıl etkiler?**

Animasyon ve çizim sırası birbirinden bağımsızdır: bir efekt, görünme/​kaybolma zamanını ve tipini kontrol eder, z-order ise neyin neyin üzerinde olacağını belirler. Görünür sonuç, ikisinin birleşimiyle tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efekti‑ve‑şekil modeli aynı mantığı izler.)

**Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?**

Genel olarak [animasyonlar desteklenir](/slides/tr/java/convert-powerpoint-to-video/), ancak nadir durumlarda veya belirli efektlerde farklı render sonuçları ortaya çıkabilir. Kullandığınız efektleri ve kütüphane sürümünü test etmeniz önerilir.