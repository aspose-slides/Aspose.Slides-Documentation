---
title: Android'de Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/androidjava/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- canlandırılmış şekil
- canlandırılmış metin
- animasyon ekle
- animasyon al
- animasyonu çıkar
- efekt ekle
- efekt al
- efekti çıkar
- efekt sesi
- animasyonu uygula
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint sunumlarında şekil animasyonlarını nasıl oluşturup özelleştireceğinizi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [grafiklere](https://docs.aspose.com/slides/tr/androidjava/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya bileşenlerine hayat verir.

## **Sunumlarda Animasyon Kullanmanın Nedenleri?**

* bilginin akışını kontrol edin
* önemli noktaları vurgulayın
* izleyicilerinizin ilgisini veya katılımını artırın
* içeriği daha kolay okunur, özümsenebilir veya işlenebilir hâle getirin
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çekin

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorilerinde animasyonlar ve animasyon efektleri için birçok seçenek ve araç sunar.

## **Aspose.Slides'ta Animasyonlar**

* Aspose.Slides, `Aspose.Slides.Animation` ad alanı altında animasyonlarla çalışmanız için gereken sınıf ve tipleri sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttype) enum'ı altında **150'den fazla animasyon efekti** sunar. Bu efektler temelde PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Bir Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for Android via Java, bir şeklin içindeki metne animasyon uygulamanıza imkan verir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksini kullanarak bir referans alın.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) ekleyin.  
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) üzerine metin ekleyin.  
5. Efektlerin ana sırasını alın.  
6. [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) üzerine bir animasyon efekti ekleyin.  
7. `TextAnimation.BuildType` özelliğini `BuildType` enum'ından gelen değerle ayarlayın.  
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu Java kodu, AutoShape'e `Fade` efektini nasıl uygulayacağınızı ve metin animasyonunu *By 1st Level Paragraphs* değerine nasıl ayarlayacağınızı gösterir:

```java
// Bir sunum dosyasını temsil eden sunum sınıfını örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Metinli yeni bir AutoShape ekler
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Slayın ana sırasını alır.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Şekle Fade animasyon efektini ekler
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Şeklin metnini birinci seviye paragraflara göre canlandırır
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX dosyasını diske kaydeder
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Metinlere animasyon uygulamanın yanı sıra, tek bir [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph) üzerinde de animasyon uygulayabilirsiniz. Bakınız [**Animated Text**](/slides/tr/androidjava/animated-text/).

{{% /alert %}} 

## **Bir PictureFrame'e Animasyon Uygulama**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksini kullanarak bir referans alın.  
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe) ekleyin veya alın.  
4. Efektlerin ana sırasını alın.  
5. [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe) üzerine bir animasyon efekti ekleyin.  
6. Sunumu bir PPTX dosyası olarak diske yazın.

Bu Java kodu, bir resim çerçevesine `Fly` efektini nasıl uygulayacağınızı gösterir:

```java
// Bir sunum dosyasını temsil eden sunum sınıfını oluşturur.
Presentation pres = new Presentation();
try {
    // Sunum görüntü koleksiyonuna eklenecek görüntüyü yükler
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Slayta resim çerçevesi ekler
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Slayın ana sırasını alır.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Resim çerçevesine soldan gelen Fly animasyon efektini ekler
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX dosyasını diske kaydeder
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekle Animasyon Uygulama**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksini kullanarak bir referans alın.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) ekleyin.  
4. Bir `Bevel` [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) ekleyin (bu nesne tıklandığında animasyon oynatılır).  
5. Bevel şekli üzerinde bir efekt sırası oluşturun.  
6. Özel bir `UserPath` oluşturun.  
7. `UserPath`'e hareket için komutlar ekleyin.  
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu Java kodu, bir şekle `PathFootball` (yol futbolu) efektini nasıl uygulayacağınızı gösterir:

```java
// PPTX dosyasını temsil eden bir Presentation sınıfını örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Var olan şekil için sıfırdan PathFootball efekti oluşturur.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootball animasyon efektini ekler
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Bir çeşit "düğme" oluşturur.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Bu düğme için bir efekt sırası oluşturur.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Özel bir kullanıcı yolu oluşturur. Nesnemiz yalnızca düğmeye tıklandıktan sonra hareket ettirilecektir.
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

## **Bir Şekle Uygulanan Animasyon Efektlerini Almak**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/) arayüzündeki `getEffectsByShape` metodunun nasıl kullanılacağını gösterir.

**Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini alın**

Daha önce, PowerPoint sunumlarındaki şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Slaytın ana animasyon sırasını alır.
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

**Örnek 2: Yer tutuculardan devralınanlar dahil tüm animasyon efektlerini alın**

Normal bir slayttaki bir şeklin, düzen slaytı ve/veya ana slayt üzerindeki yer tutucuları varsa ve bu yer tutuculara animasyon efektleri eklenmişse, şeklin tüm efektleri slayt gösterisi sırasında oynatılacak, yer tutuculardan devralınanlar da dahil.

Diyelim ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var ve bu dosyada yalnızca "Made with Aspose.Slides" metni içeren bir altbilgi şekli bulunan bir slayt var ve şekle **Random Bars** efekti uygulanmış.

![Slayt şekil animasyon efekti](slide-shape-animation.png)

Ayrıca **layout** slaydındaki altbilgi yer tutucusuna **Split** efektinin uygulandığını varsayalım.

![Düzen şekil animasyon efekti](layout-shape-animation.png)

Ve nihayet, **master** slaydındaki altbilgi yer tutucusuna **Fly In** efekti uygulanmıştır.

![Ana slayt şekil animasyon efekti](master-shape-animation.png)

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzündeki `getBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişmeyi ve altbilgi şekline uygulanan animasyon efektlerini, düzen ve ana slaytlardaki yer tutuculardan devralınanlar dahil olmak üzere, almayı gösterir.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Normal slaydaki şeklin animasyon efektlerini al.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Düzen slaydındaki yer tutucunun animasyon efektlerini al.
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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Animasyon Efekti Zamanlama Özelliklerini Değiştirme**

Aspose.Slides for Android via Java, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama bölmesidir:

![Animasyon Zamanlama örneği](shape-animation.png)

Bunlar, PowerPoint Zamanlaması ile [Effect.Timing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IEffect#getTiming--) özellikleri arasındaki eşleşmelerdir:

- PowerPoint Zamanlaması **Start** açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITiming#getTriggerType--) özelliğiyle eşleşir.
- PowerPoint Zamanlaması **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITiming#getDuration--) özelliğiyle eşleşir. Bir animasyonun (saniye cinsinden) süresi, animasyonun bir döngüyü tamamlaması için gereken toplam süredir.
- PowerPoint Zamanlaması **Delay**, [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) özelliğiyle eşleşir.

Efekt Zamanlama özelliklerini değiştirme yöntemi şu şekildedir:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.  
2. İhtiyacınız olan [Effect.Timing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IEffect#getTiming--) özelliklerine yeni değerler atayın.  
3. Değiştirilmiş PPTX dosyasını kaydedin.

Bu Java kodu işlemi gösterir:

```java
// Sunum dosyasını temsil eden bir presentation sınıfını örnekler.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Slaydın ana sırasını alır.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ana sıranın ilk efektini alır.
    IEffect effect = sequence.get_Item(0);

    // Efektin TriggerType'ını tıklama ile başlatacak şekilde değiştirir
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

## **Animasyon Efekti Sesi**

Aspose.Slides, animasyon efektlerinde seslerle çalışmanıza olanak tanıyan şu özellikleri sağlar:

- [setSound(IAudio value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Bir Animasyon Efekti Sesi Ekleme**

Bu Java kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve sonraki efekt başladığında nasıl durduracağınızı gösterir:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Sunumun ses koleksiyonuna ses ekler
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Slaydın ana sırasını alır.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Ana sıranın ilk efektini alır
    IEffect firstEffect = sequence.get_Item(0);

    // Efekti "No Sound" için kontrol eder
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // İlk efekt için ses ekler
        firstEffect.setSound(effectSound);
    }

    // Slaydın ilk etkileşimli sırasını alır.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Efektin "Stop previous sound" bayrağını ayarlar
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX dosyasını diske yazar
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Bir Animasyon Efekti Sesini Çıkarma**

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksini kullanarak bir referans alın.  
3. Efektlerin ana sırasını alın.  
4. Her bir animasyon efektine gömülü olan [setSound(IAudio value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) sesini çıkarın.

Bu Java kodu, bir animasyon efektine gömülü sesi nasıl çıkaracağınızı gösterir:

```java
// Bir sunum dosyasını temsil eden bir presentation sınıfını örnekler.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slaydın ana sırasını alır.
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

Aspose.Slides for Android via Java, bir animasyon efektinin After animation (Animasyondan Sonra) özelliğini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Efekti bölmesi ve genişletilmiş menüdür:

![Animasyon Efekti örnek1](shape-after-animation.png)

PowerPoint Efekti **After animation** açılır listesi şu özelliklerle eşleşir:

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) özelliği, After animation tipini tanımlar:
  * PowerPoint **More Colors**, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#Color) tipiyle eşleşir;
  * PowerPoint **Don't Dim** listesi, [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) tipiyle eşleşir (varsayılan animasyondan sonra tipi);
  * PowerPoint **Hide After Animation** öğesi, [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) tipiyle eşleşir;
  * PowerPoint **Hide on Next Mouse Click** öğesi, [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) tipiyle eşleşir;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) özelliği, bir animasyondan sonraki renk formatını tanımlar. Bu özellik, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#Color) tipiyle birlikte çalışır. Tipi başka bir şeye değiştirirseniz, animasyondan sonraki renk temizlenir.

Bu Java kodu, bir animasyondan sonraki efekti nasıl değiştireceğinizi gösterir:

```java
// Sunum dosyasını temsil eden bir presentation sınıfını örnekler
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ana sırasının ilk efektini alır
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

## **Metni Canlandırma**

Aspose.Slides, bir animasyon efektinin *Animate text* (Metni Canlandır) bloğu ile çalışmanıza olanak tanıyan şu özellikleri sunar:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) efekti için animate text tipini tanımlar. Şekil metni aşağıdaki şekilde canlandırılabilir:
  * Hepsi bir anda ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) tipi)
  * Kelime kelime ([AnimateTextType.ByWord](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/animatetexttype/#ByWord) tipi)
  * Harf harf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/animatetexttype/#ByLetter) tipi)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) canlandırılmış metin parçaları (kelimeler veya harfler) arasına gecikme ekler. Pozitif değer, efekt süresinin yüzde oranını belirtir. Negatif değer, saniye cinsinden gecikmeyi belirler.

Efekt Animate text (Metni Canlandır) özelliklerini değiştirme yöntemi şu şekildedir:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.  
2. [setBuildType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) özelliğini [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/buildtype/#AsOneObject) değerine ayarlayarak *By Paragraphs* animasyon modunu kapatın.  
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) ve [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) özelliklerine yeni değerler atayın.  
4. Değiştirilmiş PPTX dosyasını kaydedin.

Bu Java kodu işlemi gösterir:

```java
// Sunum dosyasını temsil eden bir presentation sınıfını örnekler.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ana sıranın ilk efektini alır
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Efektin Metin animasyon tipini "As One Object" olarak değiştirir
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Efektin Animate text tipini "By word" olarak değiştirir
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

**Sunumu web'e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?**

[Export to HTML5](/slides/tr/androidjava/export-to-html5/) ve [shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [transition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animasyonlarından sorumlu [options](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/) ayarlarını etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

**Şekillerin z-sırasını (katman sırasını) değiştirmek animasyonu nasıl etkiler?**

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünme/görünme kaybolma zamanlamasını ve tipini kontrol eder, [z-order](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getZOrderPosition--) ise hangi öğenin diğerinin üzerini kapladığını belirler. Görünür sonuç, ikisinin kombinasyonu ile tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efektler ve şekiller modeli aynı mantığı izler.)

**Belirli efektler için animasyonları videoya dönüştürürken kısıtlamalar var mı?**

Genel olarak, [animasyonlar desteklenir](/slides/tr/androidjava/convert-powerpoint-to-video/), ancak nadir durumlarda ya da belirli efektlerde farklı işlenebilir. Kullandığınız efektlerle ve kütüphane sürümüyle test etmeniz önerilir.