---
title: Sunumlarda Şekil Animasyonlarını .NET'te Uygula
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

Animasyonlar, metinlere, görsellere, şekillere veya [grafiklere](/slides/tr/net/animated-charts/) uygulanabilen görsel efektlerdir. Sunumlara veya sunum öğelerine hayat verir. 

## **Sunumlarda Animasyon Kullanmanın Nedenleri?**

* bilgi akışını kontrol edin
* önemli noktaları vurgulayın
* dinleyicilerinizin ilgisini veya katılımını artırın
* içeriği okumayı, özümsenmeyi veya işlemeyi daha kolay hale getirin
* okuyucularınızın veya izleyicilerinizin dikkatini sunumdaki önemli bölümlere çekin

PowerPoint, **giriş**, **çıkış**, **vurgulama** ve **hareket yolları** kategorilerinde animasyonlar ve animasyon efektleri için birçok seçenek ve araç sunar. 

## **Aspose.Slides'da Animasyonlar**

* Aspose.Slides, animasyonlarla çalışmak için gereken sınıfları ve tipleri [Aspose.Slides.Animation](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/) ad alanı altında sağlar,
* Aspose.Slides, [EffectType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effecttype) enum'ı altında **150'den fazla animasyon efekti** sağlar. Bu efektler, PowerPoint'te kullanılan (veya eşdeğer) efektlerle temelde aynıdır. 

## **Bir Metin Kutusuna Animasyon Uygulama**

Aspose.Slides for .NET, bir şeklin metnine animasyon uygulamanıza olanak tanır. 

1. Bir [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) ekleyin.  
4. Metni [IAutoShape.TextFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/properties/textframe) ekleyin.  
5. Ana bir efekt dizisini alın.  
6. [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) bir animasyon efekti ekleyin.  
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/textanimation/properties/buildtype) özelliğini [BuildType Enumeration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/buildtype) değerine ayarlayın.  
8. Sunumu bir PPTX dosyası olarak diske yazın.  

Bu C# kodu, `Fade` efektini AutoShape'e uygulamayı ve metin animasyonunu *By 1st Level Paragraphs* değerine ayarlamayı gösterir:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Yeni bir AutoShape'i metinle ekler
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Paragraf bazlı inşa için geçiş yapılacak şey olması için üç paragraf ekler.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Slaytın ana dizisini alır.
    ISequence sequence = sld.Timeline.MainSequence;

    // Şekle Fade animasyon efekti ekler
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Şekil metnini birinci seviye paragraflara göre animasyonlandırır
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX dosyasını diske kaydeder
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Metne animasyon uygulamanın yanı sıra tek bir [Paragraph](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraph) öğesine de animasyon uygulayabilirsiniz. [**Animasyonlu Metin**](/slides/tr/net/animated-text/) adresine bakın.  

{{% /alert %}} 

## **Bir PictureFrame'e Animasyon Uygulama**

1. Bir [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Slayta bir [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe) ekleyin veya edinin.  
5. Ana efekt dizisini alın.  
6. [PictureFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframe) bir animasyon efekti ekleyin.  
8. Sunumu bir PPTX dosyası olarak diske yazın.  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
using (Presentation pres = new Presentation())
{
    // Sunumun görüntü koleksiyonuna eklenecek resmi yükler
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Slayta resim çerçevesi ekler
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Slaytın ana dizisini alır.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Resim çerçevesine Soldan Uçuş animasyon efekti ekler
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX dosyasını diske kaydeder
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Bir Şekle Animasyon Uygulama**

1. Bir [Presentation](http://www.aspose.com/api/net/slides/tr/aspose.slides/) sınıfının örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Bir `rectangle` [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) ekleyin.  
4. Bir `Bevel` [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape) ekleyin (bu nesne tıklandığında animasyon oynatılır).  
5. `Bevel` şekli üzerinde bir efekt dizisi oluşturun.  
6. Özel bir `UserPath` oluşturun.  
7. `UserPath`'e hareket komutları ekleyin.  
8. Sunumu bir PPTX dosyası olarak diske yazın.  

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Mevcut şekil için sıfırdan PathFootball efekti oluşturur.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBall animasyon efektini ekler.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Bir çeşit "buton" oluşturur.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Buton için bir efekt dizisi oluşturur.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Özel bir kullanıcı yolu oluşturur. Nesnemiz sadece butona tıklandıktan sonra hareket ettirilecek.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Oluşturulan yol boş olduğundan hareket komutları ekler.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTX dosyasını diske yazar
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Bir Şekle Uygulanan Animasyon Efektlerini Al**

Aşağıdaki örnekler, bir şekle uygulanan tüm animasyon efektlerini almak için [ISequence](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/isequence/) arayüzündeki `GetEffectsByShape` yönteminin nasıl kullanılacağını gösterir.  

**Örnek 1: Normal bir slaytta bir şekle uygulanan animasyon efektlerini alın**

Daha önce, PowerPoint sunumlarına şekiller için animasyon efektleri eklemeyi öğrendiniz. Aşağıdaki örnek kod, `AnimExample_out.pptx` sunumundaki ilk normal slayttaki ilk şekle uygulanan efektleri nasıl alacağınızı gösterir.  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

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

Eğer normal bir slayttaki bir şeklin, düzen slaytı ve/veya ana slayt üzerindeki yer tutucuları varsa ve bu yer tutuculara animasyon efektleri eklenmişse, şeklin tüm efektleri slayt gösterisi sırasında, yer tutuculardan miras alınanlar dahil, oynatılacaktır.  

Diyelim ki `sample.pptx` adlı bir PowerPoint sunum dosyamız var; bu dosya tek bir slayt içeriyor ve sadece altbilgi şekli içinde "Made with Aspose.Slides" metni bulunuyor ve şekle **Random Bars** efekti uygulanmış.  

![Slayt şekil animasyon efekti](slide-shape-animation.png)  

Ayrıca, **layout** slaydındaki altbilgi yer tutucusuna **Split** efektinin uygulandığını varsayalım.  

![Düzen şekil animasyon efekti](layout-shape-animation.png)  

Son olarak, **master** slaydındaki altbilgi yer tutucusuna **Fly In** efekti uygulanmıştır.  

![Ana slayt şekil animasyon efekti](master-shape-animation.png)  

Aşağıdaki örnek kod, [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arayüzündeki `GetBasePlaceholder` yöntemini kullanarak şekil yer tutucularına erişmeyi ve altbilgi şekline uygulanan animasyon efektlerini, düzen ve ana slaytlardaki yer tutuculardan miras alınanlar dahil, almayı gösterir.  

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

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

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

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

## **Animasyon Efekti Zamanlama Özelliklerini Değiştir**

Aspose.Slides for .NET, bir animasyon efektinin Zamanlama özelliklerini değiştirmenize olanak tanır.  

Bu, Microsoft PowerPoint'teki Animasyon Zamanlaması bölmesi ve genişletilmiş menüdür:  

![Animasyon Zamanlaması görüntüsü](shape-animation.png)  

- PowerPoint Zamanlaması **Start** açılır listesi, [Effect.Timing.TriggerType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/properties/triggertype) özelliğiyle eşleşir.  
- PowerPoint Zamanlaması **Duration**, [Effect.Timing.Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/properties/duration) özelliğiyle eşleşir. Bir animasyonun süresi (saniye cinsinden), animasyonun bir döngüyü tamamlaması için geçen toplam zamandır.  
- PowerPoint Zamanlaması **Delay**, [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/properties/triggerdelaytime) özelliğiyle eşleşir.  
- PowerPoint Zamanlaması **Repeat** açılır listesi aşağıdaki özelliklerle eşleşir:  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatcount) özelliği, efektin tekrarlanma *sayısını* açıklar;  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilendslide) bayrağı, efektin slayt sonuna kadar tekrarlanıp tekrarlanmayacağını belirtir;  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/repeatuntilnextclick) bayrağı, efektin bir sonraki tıklamaya kadar tekrarlanıp tekrarlanmayacağını belirtir.  
- PowerPoint Zamanlaması **Rewind when done playing** onay kutusu, [Effect.Timing.Rewind](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itiming/rewind/) özelliğiyle eşleşir.  

Efekt Zamanlama özelliklerini değiştirmek için şu adımları izleyin:  

1. Animasyon efektini [Apply](#apply-animation-to-shape) edin veya alın.  
2. İhtiyacınız olan [Effect.Timing](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/properties/timing) özelliklerine yeni değerler atayın.  
3. Değiştirilmiş PPTX dosyasını kaydedin.  

Bu C# kodu işlemi gösterir:  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Slaytın ana dizisini alır.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ana dizinin ilk efektini alır.
    IEffect effect = sequence[0];

    // Efektin TriggerType değerini tıklamayla başlaması için değiştirir.
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Efektin süresini değiştirir.
    effect.Timing.Duration = 3f;

    // Efektin tetikleme gecikme süresini değiştirir.
    effect.Timing.TriggerDelayTime = 0.5f;

    // Eğer efektin Repeat (tekrar) değeri "none" ise
    if (effect.Timing.RepeatCount == 1f)
    {
        // Efektin Repeat özelliğini "Sonraki Tıklamaya Kadar" olarak değiştirir.
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Efektin Repeat özelliğini "Slayt Sonuna Kadar" olarak değiştirir.
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Efektin Rewind (geri sar) özelliğini açar.
        effect.Timing.Rewind = true;
    
    // PPTX dosyasını diske kaydeder.
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Animasyon Efekti Sesi**

Aspose.Slides, animasyon efektlerinde seslerle çalışmanıza olanak tanıyan şu özellikleri sağlar:  
- [IEffect.Sound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Animasyon Efekti Sesi Ekle**

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Sunuma ses ekler
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

	// Efektin "Önceki sesi durdur" bayrağını ayarlar
	interactiveSequence[0].StopPreviousSound = true;

	// PPTX dosyasını diske yazar
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Animasyon Efekti Sesini Çıkar**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Ana efekt dizisini alın.  
4. [Sound](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/effect/sound/) öğesini her animasyon efektine gömülü olarak çıkarın.  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Slaytın ana dizisini alır.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Efekt sesini bayt dizisi olarak çıkarır
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Animasyondan Sonra**

Aspose.Slides for .NET, bir animasyon efektinin After animation (Animasyondan Sonra) özelliğini değiştirmenize olanak tanır.  

![Animasyondan Sonra görüntüsü](shape-after-animation.png)  

PowerPoint Efekti **After animation** açılır listesi aşağıdaki özelliklerle eşleşir:  

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/afteranimationtype/) özelliği, After animation tipini tanımlar:  
  * PowerPoint **More Colors** seçeneği, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir;  
  * PowerPoint **Don't Dim** öğesi, [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir (varsayılan animasyondan sonra tipi);  
  * PowerPoint **Hide After Animation** öğesi, [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir;  
  * PowerPoint **Hide on Next Mouse Click** öğesi, [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) tipine karşılık gelir;  
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/afteranimationcolor/) özelliği, animasyondan sonraki bir renk biçimini tanımlar. Bu özellik, [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/afteranimationtype/) tipiyle birlikte çalışır. Tipi başka bir değere değiştirirseniz, animasyondan sonraki renk temizlenir.  

Bu C# kodu, bir animasyondan sonraki efekti nasıl değiştireceğinizi gösterir:  

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Animasyondan sonraki türü Renk olarak değiştirir
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Animasyondan sonraki karartma rengini ayarlar
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX dosyasını diske yazar
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Metni Animasyonlu Hale Getir**

Aspose.Slides, bir animasyon efektinin *Animate text* (Metni Animasyonlu) bloğuyla çalışmanıza olanak tanıyan şu özellikleri sağlar:  

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/animatetexttype/) özelliği, efektin animasyon metin tipini tanımlar. Şekil metni şu şekilde animasyonlanabilir:  
  * Hepsi birden ([AnimateTextType.AllAtOnce] tipi)  
  * Kelime kelime ([AnimateTextType.ByWord] tipi)  
  * Harf harf ([AnimateTextType.ByLetter] tipi)  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/ieffect/delaybetweentextparts/) animasyonlu metin parçaları (kelimeler veya harfler) arasındaki gecikmeyi ayarlar. Pozitif değer, efekt süresinin yüzdesini belirtir. Negatif değer saniye cinsinden gecikmeyi belirtir.  

Efektin Animate text (Metni Animasyonlu) özelliklerini şu şekilde değiştirebilirsiniz:  

1. Animasyon efektini [Apply](#apply-animation-to-shape) edin veya alın.  
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/tr/net/aspose.slides.animation/itextanimation/buildtype/) özelliğini [BuildType.AsOneObject] değerine ayarlayarak *By Paragraphs* animasyon modunu devre dışı bırakın.  
3. [IEffect.AnimateTextType] ve [IEffect.DelayBetweenTextParts] özelliklerine yeni değerler atayın.  
4. Değiştirilmiş PPTX dosyasını kaydedin.  

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Ana dizinin ilk efektini alır
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Efektin Metin animasyon tipini "As One Object" olarak değiştirir
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Efektin Animate text tipini "By word" olarak değiştirir
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Kelimeler arasındaki gecikmeyi efekt süresinin %20'si olarak ayarlar
    firstEffect.DelayBetweenTextParts = 20f;

    // PPTX dosyasını diske yazar
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **SSS**

### Sunumu web’e yayınlarken animasyonların korunmasını nasıl sağlayabilirim?

[HTML5'e Dışa Aktar](/slides/tr/net/export-to-html5/) ve şekil ([şekil](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animateshapes/)) ve geçiş ([geçiş](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animatetransitions/)) animasyonlarından sorumlu [seçenekler](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/) etkinleştirin. Düz HTML slayt animasyonlarını oynatmaz, HTML5 ise oynatır.  

### Şekillerin z-sırasını (katman sırasını) değiştirmek animasyonu nasıl etkiler?

Animasyon ve çizim sırası bağımsızdır: bir efekt, görünme/görünme kaybolma zamanlamasını ve tipini kontrol eder, [z-order](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/zorderposition/) ise nelerin neyi örtüştüğünü belirler. Görünür sonuç, bu ikisinin birleşimiyle tanımlanır. (Bu, genel PowerPoint davranışıdır; Aspose.Slides efektler‑ve‑şekiller modeli aynı mantığı izler.)  

### Belirli efektler için animasyonları videoya dönüştürürken sınırlamalar var mı?

Genel olarak, [animasyonlar desteklenir](/slides/tr/net/convert-powerpoint-to-video/), ancak nadir durumlarda veya belirli efektlerde farklı işlenebilir. Kullanmakta olduğunuz efektlerle ve kullandığınız kütüphane sürümüyle test etmeniz önerilir.