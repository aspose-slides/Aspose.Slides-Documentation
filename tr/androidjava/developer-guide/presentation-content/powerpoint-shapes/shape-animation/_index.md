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
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint sunumlarında şekil animasyonlarını oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [charts](https://docs.aspose.com/slides/tr/androidjava/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya onun bileşenlerine hayat katar.

## **Sunumlarda Animasyonları Neden Kullanmalısınız?**

* bilgi akışını kontrol edin
* önemli noktaları vurgulayın
* izleyicilerinizin ilgisini veya katılımını artırın
* içeriği okumayı, özümsenmeyi veya işlemeyi daha kolay hale getirin
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çekin

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorilerindeki animasyonlar ve animasyon efektleri için birçok seçenek ve araç sunar. 

## **Aspose.Slides'da Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmanız için gereken sınıfları ve türleri `Aspose.Slides.Animation` ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttype) adlı enum altında **150'den fazla animasyon efekti** sunar. Bu efektler esasen PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Bir Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for Android via Java, bir şeklin içindeki metne animasyon uygulamanıza olanak tanır.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slayt referansı alın.
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) ekleyin.
4. Metni [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) ekleyin.
5. Ana bir efekt dizisi alın.
6. Bir animasyon efektini [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) ekleyin.
7. `TextAnimation.BuildType` özelliğini `BuildType` enum'undan gelen değere ayarlayın.
8. Sunumu PPTX dosyası olarak diske yazın.

Bu Java kodu, `Fade` efektini AutoShape'e nasıl uygulayacağınızı ve metin animasyonunu *By 1st Level Paragraphs* değerine nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden bir sunum sınıfı örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Metin içeren yeni bir AutoShape ekler
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Slaytın ana dizisini alır.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Şekle Fade animasyon etkisi ekler
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Şekil metnini 1. seviye paragraf bazında canlandırır
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX dosyasını diske kaydeder
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Metne animasyon uygulamanın yanı sıra tek bir [Paragraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph) üzerine de animasyon uygulayabilirsiniz. Bakın [**Animated Text**](/slides/tr/androidjava/animated-text/).

{{% /alert %}} 

## **PictureFrame'e Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slayt referansı alın.
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe) ekleyin veya alın.
4. Ana efekt dizisini alın.
5. Bir animasyon efektini [PictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/pictureframe) ekleyin.
6. Sunumu PPTX dosyası olarak diske yazın.

Bu Java kodu, bir picture frame'e `Fly` efektini nasıl uygulayacağınızı gösterir:

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden bir sunum sınıfı örnekler.
Presentation pres = new Presentation();
try {
    // Sunumun resim koleksiyonuna eklenecek görüntüyü yükler
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
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekle Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slayt referansı alın.
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) ekleyin.
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape) ekleyin (bu nesne tıklandığında animasyon oynatılır).
5. `Bevel` şekli üzerinde bir efekt dizisi oluşturun.
6. Özel bir `UserPath` oluşturun.
7. `UserPath`'e hareket komutları ekleyin.
8. Sunumu PPTX dosyası olarak diske yazın.

Bu Java kodu, bir şekle `PathFootball` (path football) efektini nasıl uygulayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// PPTX dosyasını temsil eden bir Presentation sınıfı örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall animasyon etkisini ekler
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Bir çeşit "buton" oluşturur.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Bu buton için bir efekt dizisi oluşturur.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Özel bir kullanıcı yolu oluşturur. Nesnemiz yalnızca butona tıklandıktan sonra hareket ettirilecektir.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Oluşturulan yol boş olduğundan hareket komutları ekler.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // PPTX dosyasını diske yazar
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekle Uygulanan Animasyon Efektlerini Almak**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/) arayüzündeki `getEffectsByShape` metodunun nasıl kullanılacağını gösterir.

**Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini al**

Daha önce, PowerPoint sunumlarında şekillere animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir:

```java
import com.aspose.slides.*;

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

**Örnek 2: Yer tutuculardan devralınanlar da dahil olmak üzere tüm animasyon efektlerini al**

Normal bir slayttaki bir şeklin yer tutucuları, düzen slaytında ve/veya ana slaytta bulunuyorsa ve bu yer tutuculara animasyon efektleri eklenmişse, slayt gösterisi sırasında şeklin tüm efektleri, yer tutuculardan devralınanlar da dahil, oynatılır.

Örneğin bir `sample.pptx` PowerPoint sunum dosyamız var ve içinde sadece "Made with Aspose.Slides" metni bulunan bir altbilgi şekli var; bu şekle **Random Bars** efekti uygulanmış.

![Slide shape animation effect](slide-shape-animation.png)

Ayrıca altbilgi yer tutucusuna **layout** slaytında **Split** efekti uygulandığını varsayalım.

![Layout shape animation effect](layout-shape-animation.png)

Ve son olarak, **master** slaytındaki altbilgi yer tutucusuna **Fly In** efekti uygulandı.

![Master shape animation effect](master-shape-animation.png)

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) arayüzündeki `getBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişip, altbilgi şekline uygulanmış animasyon efektlerini, düzen ve ana slaytlardaki yer tutuculardan devralınanları da dahil olmak üzere nasıl alacağınızı gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Normal slayttaki şeklin animasyon efektlerini al.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Düzen slaytındaki yer tutucunun animasyon efektlerini al.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Master slayttaki yer tutucunun animasyon efektlerini al.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

Aspose.Slides for Android via Java, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama bölmesidir:

![example1_image](shape-animation.png)

PowerPoint Zamanlaması ile [Effect.Timing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IEffect#getTiming--) özellikleri arasındaki eşleşmeler:

- PowerPoint Zamanlaması **Start** açılan listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITiming#getTriggerType--) özelliğiyle eşleşir.
- PowerPoint Zamanlaması **Duration** ise [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITiming#getDuration--) özelliğiyle eşleşir. Bir animasyonun (saniye cinsinden) süresi, animasyonun bir döngüyü tamamlaması için geçen toplam zamandır.
- PowerPoint Zamanlaması **Delay** ise [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) özelliğiyle eşleşir.

Effect Zamanlama özelliklerini şu şekilde değiştirirsiniz:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.
2. İhtiyacınız olan [Effect.Timing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IEffect#getTiming--) özelliklerine yeni değerler atayın.
3. Değiştirilmiş PPTX dosyasını kaydedin.

Bu Java kodu işlemi göstermektedir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Slaytın ana dizisini alır.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ana dizinin ilk efektini alır.
    IEffect effect = sequence.get_Item(0);

    // Etkinin TriggerType'ını tıklamayla başlaması için değiştirir
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Etkinin süresini değiştirir
    effect.getTiming().setDuration(3f);

    // Etkinin TriggerDelayTime'ını değiştirir
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX dosyasını diske kaydeder
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasyon Efekti Sesi**

Aspose.Slides, animasyon efektlerindeki seslerle çalışmanıza olanak tanıyan aşağıdaki özellikleri sağlar: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Bir Animasyon Efekti Sesi Ekleme**

Bu Java kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve sonraki efekt başladığında sesi nasıl durduracağınızı gösterir:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Sunuma ses ekler (ses koleksiyonuna).
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

### **Bir Animasyon Efekti Sesi Çıkarma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slayt referansı alın. 
3. Ana efekt dizisini alın. 
4. Her bir animasyon efektine gömülü olan [setSound(IAudio value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) metodunu çıkarın.

Bu Java kodu, bir animasyon efektine gömülü sesi nasıl çıkaracağınızı gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slaytın ana dizisini alır.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Efekt sesini bayt dizisi olarak çıkarır
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Animasyondan Sonra**

Aspose.Slides for Android via Java, bir animasyon efektinin **After animation** özelliğini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Efekti bölmesi ve genişletilmiş menüsüdür:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** açılan listesi aşağıdaki özelliklerle eşleşir: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) özelliği, After animation tipini tanımlar:
  * PowerPoint **More Colors** seçeneği, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#Color) tipiyle eşleşir;
  * PowerPoint **Don't Dim** seçeneği, [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) tipiyle eşleşir (varsayılan after animation tipi);
  * PowerPoint **Hide After Animation** seçeneği, [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) tipiyle eşleşir;
  * PowerPoint **Hide on Next Mouse Click** seçeneği, [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) tipiyle eşleşir;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) özelliği, bir after animation renk formatı tanımlar. Bu özellik, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#Color) tipiyle birlikte çalışır. Tipi başka bir değere değiştirirseniz, after animation rengi temizlenir.

Bu Java kodu, bir after animation efektini nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler
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

## **Metni Canlandırma**

Aspose.Slides, bir animasyon efektinin *Animate text* bloğuyla çalışmanıza olanak tanıyan aşağıdaki özellikleri sağlar:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) metin animasyonu tipini tanımlar. Şekil metni şu şekillerde animasyonlanabilir:
  - Hepsi birden ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) tipi)
  - Kelime kelime ([AnimateTextType.ByWord](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/animatetexttype/#ByWord) tipi)
  - Harf harf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/animatetexttype/#ByLetter) tipi)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) animasyonlu metin parçaları (kelimeler veya harfler) arasına bir gecikme ekler. Pozitif bir değer, efekt süresinin yüzde oranını belirtir. Negatif bir değer ise gecikmeyi saniye cinsinden belirtir.

Effect Animate text özelliklerini şu şekilde değiştirebilirsiniz:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.
2. *By Paragraphs* animasyon modunu kapatmak için [setBuildType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) özelliğini [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/buildtype/#AsOneObject) değerine ayarlayın.
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) ve [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) özelliklerine yeni değerler atayın.
4. Değiştirilmiş PPTX dosyasını kaydedin.

Bu Java kodu işlemi göstermektedir:

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Efektin Metin animasyon tipini "As One Object" olarak değiştirir
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Efektin Metin canlandırma tipini "By word" olarak değiştirir
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

### Sunumu web'e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?

[Export to HTML5](/slides/tr/androidjava/export-to-html5/) ve [options](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/) içinde şekil ([shape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-)) ve geçiş ([transition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)) animasyonlarından sorumlu ayarları etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

### Şekillerin z-order (katman sırası) değişikliği animasyonu nasıl etkiler?

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünüp kaybolma zamanlamasını ve tipini kontrol ederken, [z-order](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/shape/#getZOrderPosition--) neyin neyi örteceğini belirler. Görülen sonuç, bunların birleşimiyle tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efekt‑ve‑şekil modeli de aynı mantığı izler.)

### Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?

Genel olarak [animasyonlar desteklenir](/slides/tr/androidjava/convert-powerpoint-to-video/), ancak nadir durumlar ya da belirli efektler farklı şekilde render edilebilir. Kullandığınız efektlerle ve kütüphane sürümüyle test yapmanız tavsiye edilir.