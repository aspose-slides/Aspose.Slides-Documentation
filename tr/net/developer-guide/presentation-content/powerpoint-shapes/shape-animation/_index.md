---
title: Sunumlarda Şekil Animasyonlarını .NET'te Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint sunumlarında şekil animasyonları oluşturmayı ve özelleştirmeyi keşfedin. Öne çıkın!"
---
## **Giriş**

Animasyonlar, metinlere, görüntülere, şekillere veya [grafiklere](/slides/tr/net/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara ya da bunların bileşenlerine hayat verir.

## **Sunumlarda Neden Animasyon Kullanılır?**

* bilgi akışını kontrol edin
* önemli noktaları vurgulayın
* izleyicilerinizin ilgisini veya katılımını artırın
* içeriği daha kolay okunur, özümsenir veya işlenir hâle getirin
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çekin

PowerPoint, **giriş**, **çıkış**, **vurgu** ve **hareket yolu** kategorileri içinde animasyonlar ve animasyon efektleri için çok sayıda seçenek ve araç sunar.

## **Aspose.Slides'da Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için gerekli sınıf ve türleri [Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/) ad alanı altında sağlar,
* Aspose.Slides, **150'den fazla animasyon efekti** ni [EffectType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttype)枚 (enum) altında sunar. Bu efektler temelde PowerPoint'te kullanılan aynı (veya eşdeğer) efektlerdir.

## **Bir Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for .NET, bir şeklin içindeki metne animasyon uygulamanıza olanak tanır.

1. [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) ekleyin.  
4. [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/properties/textframe) içine metin ekleyin.  
5. Efektlerin ana dizisini alın.  
6. [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) üzerine bir animasyon efekti ekleyin.  
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/textanimation/properties/buildtype) özelliğini [BuildType Enumeration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/buildtype) değerine ayarlayın.  
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu C# kodu, `Fade` efektini AutoShape'e uygulamayı ve metin animasyonunu *By 1st Level Paragraphs* değerine ayarlamayı gösterir:

```c#
// Bir sunum dosyasını temsil eden sunum sınıfını örnekler.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Yeni AutoShape'ı metinle ekler
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Slaytın ana dizisini alır.
    ISequence sequence = sld.Timeline.MainSequence;

    // Şekle Fade animasyon efektini ekler
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Şekil metnini 1. seviye paragraflara göre animasyonlar
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX dosyasını diske kaydeder
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Metne animasyon uygulamanın yanı sıra tek bir [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph) üzerine de animasyon uygulayabilirsiniz. [**Animasyonlu Metin**](/slides/tr/net/animated-text/) bölümüne bakın.

{{% /alert %}} 

## **PictureFrame'e Animasyon Uygulama**

1. [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe) ekleyin ya da alın.  
5. Efektlerin ana dizisini alın.  
6. [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe) üzerine bir animasyon efekti ekleyin.  
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu C# kodu, bir picture frame'e `Fly` efektini uygulamayı gösterir:

```c#
// Sunum dosyasını temsil eden bir sunum sınıfını örnekler.
using (Presentation pres = new Presentation())
{
    // Sunumun resim koleksiyonuna eklenecek resmi yükler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Slayta resim çerçevesi ekler
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Slaytın ana dizisini alır.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Resim çerçevesine Soldan Uçuş animasyon efektini ekler
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX dosyasını diske kaydeder
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Bir Şekle Animasyon Uygulama**

1. [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) ekleyin.  
4. Bir `Bevel` [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) ekleyin (bu nesne tıklandığında animasyon oynatılır).  
5. Bevel şekli üzerinde bir efekt dizisi oluşturun.  
6. Özel bir `UserPath` oluşturun.  
7. `UserPath`'e hareket etmek için komutlar ekleyin.  
8. Sunumu bir PPTX dosyası olarak diske yazın.

Bu C# kodu, bir şekle `PathFootball` (yol futbolu) efektini uygulamayı gösterir:

```c#
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Varolan şekil için sıfırdan PathFootball efekti oluşturur.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBall animasyon efektini ekler.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // "button" türünde bir şey oluşturur.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Buton için bir efekt dizisi oluşturur.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Özel bir kullanıcı yolu oluşturur. Nesnemiz sadece butona tıklandıktan sonra hareket ettirilecektir.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Oluşturulan yol boş olduğundan hareket komutları ekler.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTX dosyasını diske yazar.
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Bir Şekle Uygulanan Animasyon Efektlerini Alma**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/) arabirimindeki `GetEffectsByShape` metodunun nasıl kullanılacağını gösterir.

**Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini al**

Daha önce, PowerPoint sunumlarına şekiller eklemek için animasyon efektleri eklemeyi öğrenmiştiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir.

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Slaytın ana animasyon dizisini alır.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // İlk slayttaki ilk şekli alır.
    IShape shape = firstSlide.Shapes[0];

    // Şekle uygulanan animasyon efektlerini alır.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Örnek 2: Yer tutuculardan miras alınanlar dahil tüm animasyon efektlerini alın**

Normal bir slayttaki bir şeklin, yer tutucu (placeholder)ları düzen slaytı ve/veya ana slaytta bulunuyorsa ve bu yer tutuculara animasyon efektleri eklenmişse, slayt gösterisi sırasında şeklin tüm efektleri, yer tutuculardan miras alınanlar dahil oynatılır.

Diyelim ki içinde yalnızca bir altbilgi şekli ve metni "Made with Aspose.Slides" olan bir PowerPoint sunum dosyamız `sample.pptx` ve bu şekle **Random Bars** efekti uygulanmış.

![Slayt şekli animasyon efekti](slide-shape-animation.png)

Ayrıca altbilgi yer tutucusuna **layout** slaytında **Split** efektinin uygulandığını varsayalım.

![Düzen şekli animasyon efekti](layout-shape-animation.png)

Ve sonunda, **master** slaytındaki altbilgi yer tutucusuna **Fly In** efekti uygulanmıştır.

![Ana slayt şekli animasyon efekti](master-shape-animation.png)

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arabirimindeki `GetBasePlaceholder` metodunu kullanarak şekil yer tutucularına erişmeyi ve altbilgi şekline uygulanan animasyon efektlerini, layout ve master slaytlarda bulunan yer tutuculardan miras alınanlar dahil, nasıl alacağınızı gösterir.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Normal slayttaki şeklin animasyon efektlerini al.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Düzen slaydındaki yer tutucunun animasyon efektlerini al.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Ana slaydındaki yer tutucunun animasyon efektlerini al.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
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

Aspose.Slides for .NET, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Zamanlama bölmesi ve genişletilmiş menüsüdür:

![Animasyon Zamanlama](shape-animation.png)

Bu, PowerPoint Zamanlama **Start** açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/properties/triggertype) özelliği ile eşleşir.

- PowerPoint Zamanlama **Duration** (Süre), [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/properties/duration) özelliği ile eşleşir. Bir animasyonun süresi (saniye cinsinden), animasyonun bir döngüyü tamamlaması için gereken toplam zamandır.

- PowerPoint Zamanlama **Delay** (Gecikme), [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/properties/triggerdelaytime) özelliği ile eşleşir.

- PowerPoint Zamanlama **Repeat** açılır listesi şu özelliklerle eşleşir:
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatcount) özelliği, efektin *sayısını* tanımlar;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilendslide) bayrağı, efektin slayt sonuna kadar tekrarlanıp tekrarlanmayacağını belirtir;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilnextclick) bayrağı, efektin bir sonraki tıklamaya kadar tekrarlanıp tekrarlanmayacağını belirtir.

- PowerPoint Zamanlama **Rewind when done playing** (Oynatma tamamlandığında geri sar) onay kutusu, [Effect.Timing.Rewind](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/rewind/) özelliği ile eşleşir.

Efekt Zamanlama özelliklerini şu şekilde değiştirirsiniz:

1. [Apply](#apply-animation-to-shape) ya da animasyon efektini alın.  
2. Gereken [Effect.Timing](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/properties/timing) özelliklerine yeni değerler atayın.  
3. Değiştirilmiş PPTX dosyasını kaydedin.

Bu C# kodu işlemi göstermektedir:

```c#
 // Bir sunum dosyasını temsil eden sunum sınıfını örnekler.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Slaytın ana dizisini alır.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ana dizinin ilk efektini alır.
    IEffect effect = sequence[0];

    // Efektin TriggerType'ını tıklamayla başlaması için değiştirir
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Efektin süresini değiştirir
    effect.Timing.Duration = 3f;

    // Efektin TriggerDelayTime değerini değiştirir
    effect.Timing.TriggerDelayTime = 0.5f;

    // Efektin Repeat değeri "none" ise
    if (effect.Timing.RepeatCount == 1f)
    {
        // Efektin Repeat değerini "Bir Sonraki Tıklamaya Kadar" olarak değiştirir
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Efektin Repeat değerini "Slayt Sonuna Kadar" olarak değiştirir
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Efektin Rewind özelliğini etkinleştirir
        effect.Timing.Rewind = true;
    
    // PPTX dosyasını diske kaydeder
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Animasyon Efekti Sesleri**

Aspose.Slides, animasyon efektlerinde seslerle çalışmanızı sağlayan şu özellikleri sunar:

- [IEffect.Sound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/stopprevioussound/)  

### **Bir Animasyon Efekti Sesi Ekleme**

Bu C# kodu, bir animasyon efekti sesini eklemeyi ve bir sonraki efekt başladığında sesi durdurmayı gösterir:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Sunumun ses koleksiyonuna ses ekler
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Slaytın ana dizisini alır.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Ana dizinin ilk efektini alır
	IEffect firstEffect = sequence[0];

	// Efekti "Ses Yok" için kontrol eder
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// İlk efekt için ses ekler
		firstEffect.Sound = effectSound;
	}

	// Slaytın ilk etkileşimli dizisini alır.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Efektin "Önceki Sesi Durdur" bayrağını ayarlar
	interactiveSequence[0].StopPreviousSound = true;

	// PPTX dosyasını diske yazar
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Bir Animasyon Efekti Sesini Çıkarma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeks üzerinden alın.  
3. Efektlerin ana dizisini alın.  
4. Her bir animasyon efektine gömülü [Sound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/sound/) öğesini çıkarın.

Bu C# kodu, bir animasyon efektine gömülü sesi nasıl çıkaracağınızı gösterir:

```c#
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Slaytın ana dizisini alır.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Etki sesini byte dizisine çıkarır
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Animasyondan Sonra**

Aspose.Slides for .NET, bir animasyon efektinin After animation (animasyondan sonra) özelliğini değiştirmenize olanak tanır.

Bu, Microsoft PowerPoint'teki Animasyon Efekti bölmesi ve genişletilmiş menüdür:

![Animasyon Efekti](shape-after-animation.png)

PowerPoint Efekti **After animation** açılır listesi şu özelliklerle eşleşir:

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/afteranimationtype/) özelliği, animasyondan sonraki türü tanımlar:
  * PowerPoint **More Colors** seçeneği, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) türüyle eşleşir;
  * PowerPoint **Don't Dim** seçeneği, [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) türüyle eşleşir (varsayılan animasyondan sonraki tür);
  * PowerPoint **Hide After Animation** seçeneği, [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) türüyle eşleşir;
  * PowerPoint **Hide on Next Mouse Click** seçeneği, [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) türüyle eşleşir;
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/afteranimationcolor/) özelliği, animasyondan sonraki renk formatını tanımlar. Bu özellik, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) türüyle birlikte çalışır. Türü başka bir değere değiştirirseniz, animasyondan sonraki renk temizlenir.

Bu C# kodu, bir animasyondan sonra efektini nasıl değiştireceğinizi gösterir:

```c#
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // After animation tipini Color olarak değiştirir
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // After animation karartma rengini ayarlar
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX dosyasını diske yazar
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Metni Animasyonlu Hale Getirme**

Aspose.Slides, bir animasyon efektinin *Animate text* (Metni animasyonla) bloğu ile çalışmanızı sağlayan şu özellikleri sunar:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/animatetexttype/) özelliği, efektin animasyon metni tipini tanımlar. Şekil metni şu şekilde animasyonlanabilir:
  * Hepsi bir anda ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/animatetexttype/) tipi)
  * Kelime kelime ([AnimateTextType.ByWord](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/animatetexttype/) tipi)
  * Harf harf ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/animatetexttype/) tipi)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/delaybetweentextparts/) özellik, animasyonlu metin parçaları (kelimeler veya harfler) arasındaki gecikmeyi ayarlar. Pozitif değer, efekt süresinin yüzde olarak belirtilmesini, negatif değer ise saniye cinsinden gecikmeyi belirtir.

Efekt Animate text özelliklerini şu şekilde değiştirebilirsiniz:

1. [Apply](#apply-animation-to-shape) ya da animasyon efektini alın.  
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itextanimation/buildtype/) özelliğini, *By Paragraphs* animasyon modunu kapatmak için [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/buildtype/) değerine ayarlayın.  
3. [IEffect.AnimateTextType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/animatetexttype/) ve [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/delaybetweentextparts/) özellikleri için yeni değerler belirleyin.  
4. Değiştirilmiş PPTX dosyasını kaydedin.

Bu C# kodu işlemi göstermektedir:

```c#
// Bir sunum dosyasını temsil eden bir Presentation sınıfını örnekler.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Efektin Text animation tipini "As One Object" olarak değiştirir
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Efektin Animate text tipini "By word" olarak değiştirir
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Kelime arasındaki gecikmeyi efekt süresinin %20'si olarak ayarlar
    firstEffect.DelayBetweenTextParts = 20f;

    // PPTX dosyasını diske yazar
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Sunumu web'e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?**

[Export to HTML5](/slides/tr/net/export-to-html5/) ve şekil ([shape](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animateshapes/)) ve geçiş ([transition](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animatetransitions/)) animasyonlarından sorumlu [options](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/) seçeneklerini etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.

**Şekillerin z-sırası (katman sırası) değiştirilmesi animasyonu nasıl etkiler?**

Animasyon ve çizim sırası birbirinden bağımsızdır: bir efekt, görünme/görünmez olma zamanlamasını ve tipini kontrol ederken, [z-order](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/zorderposition/) hangi nesnenin diğerini kapatacağını belirler. Görünür sonuç, bu iki faktörün birleşimiyle tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efekt‑ve‑şekil modeli aynı mantığı izler.)

**Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?**

Genel olarak, [animasyonlar desteklenir](/slides/tr/net/convert-powerpoint-to-video/), ancak nadir durumlarda veya belirli efektlerde farklı renderlanabilir. Kullandığınız efektler ve kütüphane sürümü ile test etmeniz önerilir.