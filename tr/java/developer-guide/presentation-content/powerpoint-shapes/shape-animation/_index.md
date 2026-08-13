---
title: Java ile Sunumlarda Şekil Animasyonları Uygulama
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
- animasyon al
- animasyonu çıkar
- efekt ekle
- efekti al
- efekti çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görsellere, şekillere veya [charts](https://docs.aspose.com/slides/tr/java/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya bunların bileşenlerine hayat verir. 

## **Sunumlarda Neden Animasyon Kullanılır?**

* bilgi akışını kontrol etme
* önemli noktaları vurgulama
* izleyicilerin ilgisini veya katılımını artırma
* içeriği okumayı, özümsemeyi veya işlemi kolaylaştırma
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çekme

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorileri boyunca animasyonlar ve animasyon efektleri için birçok seçenek ve araç sunar. 

## **Aspose.Slides'ta Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için gerekli sınıfları ve tipleri `Aspose.Slides.Animation` ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttype) enumeration altında **150'den fazla animasyon efekti** sunar. Bu efektler temelde PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Bir Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for Java, bir şeklin metnine animasyon uygulamanıza olanak tanır. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slayt referansını indeksine göre alın.
3. `rectangle` bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) ekleyin. 
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) içine metin ekleyin.
5. Ana efekt dizisini alın.
6. [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) üzerine bir animasyon efekti ekleyin. 
7. `TextAnimation.BuildType` özelliğini `BuildType` enumeration'ındaki değere ayarlayın.
8. Sunumu bir PPTX dosyası olarak diske yazın.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Yeni bir AutoShape'ı metinle ekler
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Slaydın ana dizisini alır.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Şekle Fade animasyon efekti ekler
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Şekil metnini 1. seviye paragraflara göre animasyonlandırır
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // PPTX dosyasını diske kaydeder
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Metinlere animasyon uygulamanın yanı sıra, tek bir [Paragraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph) üzerine de animasyon uygulayabilirsiniz. Bkz. [**Animated Text**](/slides/tr/java/animated-text/).

{{% /alert %}} 

## **PictureFrame'e Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slayt referansını indeksine göre alın.
3. [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe) ekleyin veya alın. 
4. Ana efekt dizisini alın.
5. [PictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/pictureframe) üzerine bir animasyon efekti ekleyin.
6. Sunumu bir PPTX dosyası olarak diske yazın.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
Presentation pres = new Presentation();
try {
    // Sunumun resim koleksiyonuna eklenecek resmi yükler
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Slayta resim çerçevesi ekler
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Slaydın ana dizisini alır.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Resim çerçevesine Soldan Uçuş animasyon efekti ekler
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX dosyasını diske kaydeder
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bir Şekle Animasyon Uygulama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slayt referansını indeksine göre alın.
3. `rectangle` bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) ekleyin. 
4. `Bevel` bir [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape) ekleyin (bu nesne tıklandığında animasyon oynatılır).
5. `Bevel` şekli üzerinde bir efekt dizisi oluşturun.
6. Özel bir `UserPath` oluşturun.
7. `UserPath`'e hareket komutları ekleyin.
8. Sunumu bir PPTX dosyası olarak diske yazın.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Bir PPTX dosyasını temsil eden Presentation sınıfını örnekler.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // PathFootBall animasyon efektini ekler
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

## **Bir Şekle Uygulanan Animasyon Efektlerini Getirme**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/) arabirimindeki `getEffectsByShape` metodunun nasıl kullanılacağını gösterir.

**Örnek 1: Normal bir slayttaki bir şekle uygulanan animasyon efektlerini alma**

Daha önce, PowerPoint sunumlarındaki şekillere animasyon efektleri eklemenin nasıl yapılacağını öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slaydın ilk şekline uygulanan efektleri nasıl alacağınızı gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Slaydın ana animasyon dizisini alır.
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

**Örnek 2: Yer tutuculardan miras alınanlar dahil tüm animasyon efektlerini alma**

Normal bir slayttaki bir şeklin yer tutucuları, düzen (layout) slaytı ve/veya ana (master) slaytta bulunuyorsa ve bu yer tutuculara animasyon efektleri eklenmişse, şeklin tüm efektleri slayt gösterisi sırasında oynatılacak, yer tutuculardan miras alınanlar dahil.

`sample.pptx` adında bir PowerPoint sunum dosyamız olduğunu varsayalım; bu dosyada tek bir slayt var ve sadece altbilgi (footer) şeklinde "Made with Aspose.Slides" metni bulunuyor ve şekle **Random Bars** efekti uygulanmış.

![Slide shape animation effect](slide-shape-animation.png)

Ayrıca altbilgi yer tutucusuna **layout** slaytında **Split** efektinin uygulandığını varsayalım.

![Layout shape animation effect](layout-shape-animation.png)

Ve son olarak altbilgi yer tutucusuna **master** slaytında **Fly In** efektinin uygulandığını varsayalım.

![Master shape animation effect](master-shape-animation.png)

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arabirimindeki `getBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişmeyi ve layout ve master slaytlarda bulunan yer tutuculardan miras alınanlar dahil altbilgi şekline uygulanan animasyon efektlerini almayı gösterir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Animasyon Efekti Zamanlama Özelliklerini Değiştirme**

Aspose.Slides for Java, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint’teki Animasyon Zamanlama bölmesidir:

![example1_image](shape-animation.png)

PowerPoint Zamanlama ile [Effect.Timing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IEffect#getTiming--) özellikleri arasındaki eşleşmeler:

- PowerPoint Zamanlama **Start** açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITiming#getTriggerType--) özelliği ile eşleşir. 
- PowerPoint Zamanlama **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITiming#getDuration--) özelliği ile eşleşir. Bir animasyonun (saniye cinsinden) süresi, animasyonun bir döngüyü tamamlaması için geçen toplam süredir. 
- PowerPoint Zamanlama **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ITiming#getTriggerDelayTime--) özelliği ile eşleşir. 

Effect Timing özelliklerini nasıl değiştirirsiniz:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.
2. İhtiyacınız olan [Effect.Timing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IEffect#getTiming--) özellikleri için yeni değerler ayarlayın. 
3. Değiştirilmiş PPTX dosyasını kaydedin.

```java
import com.aspose.slides.*;

// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Slaydın ana dizisini alır.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ana dizinin ilk efektini alır.
    IEffect effect = sequence.get_Item(0);

    // Efektin TriggerType'ını tıklamayla başlaması için değiştirir.
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Efektin süresini değiştirir.
    effect.getTiming().setDuration(3f);

    // Efektin TriggerDelayTime'ını değiştirir.
    effect.getTiming().setTriggerDelayTime(0.5f);

    // PPTX dosyasını diske kaydeder.
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animasyon Efekti Sesleri**

Aspose.Slides, animasyon efektlerindeki seslerle çalışmanıza olanak tanıyan aşağıdaki özellikleri sağlar: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Bir Animasyon Efekti Sesi Ekleme**

Bu Java kodu, bir animasyon efekti sesini nasıl ekleyeceğinizi ve bir sonraki efekt başladığında nasıl durduracağınızı gösterir:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Sunumun ses koleksiyonuna ses ekler
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Slaydın ana dizisini alır.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = sequence.get_Item(0);

    // Etkinin "Ses Yok" olup olmadığını kontrol eder
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // İlk efekt için ses ekler
        firstEffect.setSound(effectSound);
    }

    // Slaydın ilk etkileşimli dizisini alır.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Etkinin "Önceki sesi durdur" bayrağını ayarlar
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // PPTX dosyasını diske yazar
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Bir Animasyon Efekti Sesini Çıkarma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın. 
3. Ana efekt dizisini alın. 
4. [setSound(IAudio value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) her bir animasyon efektine gömülü olanı çıkarın. 

Bu Java kodu, bir animasyon efektine gömülü sesin nasıl çıkarılacağını gösterir:

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slaydın ana dizisini alır.
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

## **Animasyon Sonrası**

Aspose.Slides for Java, bir animasyon efektinin After animation (Animasyon Sonrası) özelliğini değiştirmenize olanak tanır.

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** açılır listesi aşağıdaki özelliklerle eşleşir: 

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) özelliği, After animation tipini tanımlar:
  * PowerPoint **More Colors** seçeneği, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color) türü ile eşleşir;
  * PowerPoint **Don't Dim** öğesi, [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#DoNotDim) türü (varsayılan animasyon sonrası tür) ile eşleşir;
  * PowerPoint **Hide After Animation** öğesi, [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) türü ile eşleşir;
  * PowerPoint **Hide on Next Mouse Click** öğesi, [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) türü ile eşleşir;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) özelliği, bir After animation renk formatı tanımlar. Bu özellik, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color) türüyle birlikte çalışır. Tipi başka bir değere değiştirirseniz, after animation rengi temizlenecektir.

Bu Java kodu, bir after animation efektini nasıl değiştireceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Bir sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
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

Aspose.Slides, bir animasyon efektinin *Animate text* bloğu ile çalışmanıza olanak tanıyan aşağıdaki özellikleri sağlar:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) özelliği, efektin animasyon metni tipini tanımlar. Şekil metni şu şekillerde animasyonlandırılabilir:
  - Hepsi bir anda ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/tr/java/com.aspose.slides/animatetexttype/#AllAtOnce) türü)
  - Kelime kelime ([AnimateTextType.ByWord](https://reference.aspose.com/slides/tr/java/com.aspose.slides/animatetexttype/#ByWord) türü)
  - Harfe harf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/animatetexttype/#ByLetter) türü)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) animasyonlu metin parçaları (kelimeler veya harfler) arasında bir gecikme ayarlar. Pozitif değer, efekt süresinin yüzdesini belirtir. Negatif değer ise saniye cinsinden gecikmeyi belirtir.

Effect Animate text özelliklerini nasıl değiştirirsiniz:

1. [Apply](#apply-animation-to-shape) veya animasyon efektini alın.
2. *By Paragraphs* animasyon modunu kapatmak için [setBuildType(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextanimation/#setBuildType-int-) özelliğini [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/buildtype/#AsOneObject) değerine ayarlayın.
3. [setAnimateTextType(int value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) ve [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) özellikleri için yeni değerler ayarlayın.
4. Değiştirilmiş PPTX dosyasını kaydedin.

```java
import com.aspose.slides.*;

// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Efektin Metin animasyon tipini "As One Object" olarak değiştirir
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Efektin Metni animasyon tipini "By word" olarak değiştirir
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

[Export to HTML5](/slides/tr/java/export-to-html5/) ve [options](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/) içinde [shape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [transition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) animasyonlarını etkinleştirin. Düz HTML kaydırma animasyonlarını oynatmaz, HTML5 ise oynatır.

### Şekillerin z-order (katman sırası) değiştirilmesi animasyonu nasıl etkiler?

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünme/gizlenme zamanlamasını ve tipini kontrol eder, [z-order](https://reference.aspose.com/slides/tr/java/com.aspose.slides/shape/#getZOrderPosition--) ise neyin neyi örtmesini belirler. Görünür sonuç, bu iki faktörün kombinasyonu ile tanımlanır. (Bu genel PowerPoint davranışıdır; Aspose.Slides efekt‑ve‑şekil modeli aynı mantığı izler.)

### Belirli efektler için animasyonların video'ya dönüştürülmesinde sınırlamalar var mı?

Genel olarak, [animations are supported](/slides/tr/java/convert-powerpoint-to-video/), ancak nadir durumlar veya belirli efektler farklı işlenebilir. Kullandığınız efektleri ve kütüphane sürümünü test etmeniz önerilir.