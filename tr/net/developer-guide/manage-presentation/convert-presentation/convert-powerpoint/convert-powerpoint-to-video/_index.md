---
title: PowerPoint Sunumlarını .NET'te Videoya Dönüştürme
linktitle: PowerPoint'ten Videoya
type: docs
weight: 130
url: /tr/net/convert-powerpoint-to-video/
keywords:
- PowerPoint dönüştür
- sunumu dönüştür
- PPT dönüştür
- PPTX dönüştür
- PowerPoint'ten videoya
- sunumdan videoya
- PPT'den videoya
- PPTX'ten videoya
- PowerPoint'ten MP4'e
- sunumdan MP4'e
- PPT'den MP4'e
- PPTX'den MP4'e
- PPT'yi MP4 olarak kaydet
- PPTX'i MP4 olarak kaydet
- PPT'yi MP4'e dışa aktar
- PPTX'i MP4'e dışa aktar
- video dönüştürme
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: ".NET'te PowerPoint sunumlarını videoya nasıl dönüştüreceğinizi öğrenin. İş akışınızı hızlandırmak için örnek C# kodu ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint ya da OpenDocument sunumunuzu videoya dönüştürerek şunları elde edersiniz:

**Arttırılmış erişilebilirlik:** Tüm cihazlar, platformdan bağımsız olarak, varsayılan olarak video oynatıcılarıyla gelir, bu da kullanıcıların geleneksel sunum uygulamalarına göre videoları açmasını veya oynatmasını kolaylaştırır.

**Daha geniş erişim:** Videolar, daha geniş bir izleyici kitlesine ulaşmanızı ve bilgiyi daha ilgi çekici bir formatta sunmanızı sağlar. Anketler ve istatistikler, insanların diğer formatlara göre video içeriğini izlemeyi ve tüketmeyi tercih ettiğini gösterir, bu da mesajınızın daha etkili olmasını sağlar.

{{% alert color="primary" %}} 

Aşağıdaki [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/tr/video) göz atın çünkü burada açıklanan sürecin canlı ve etkili bir uygulamasını sunar.

{{% /alert %}} 

Aspose.Slides for .NET'te sunumları videoya dönüştürme desteği ekledik.

* Aspose.Slides for .NET'i kullanarak sunum slaytlarından belirli bir kare hızı (FPS) ile çerçeveler oluşturun.  
* Ardından, ffmpeg gibi bir üçüncü taraf yardımcı programı kullanarak bu çerçeveleri bir videoya derleyin.

## **PowerPoint Sunumunu Videoya Dönüştürme**

1. Projenize Aspose.Slides ve FFMpegCore kütüphanesini eklemek için `dotnet add package` komutunu kullanın:  
   * `dotnet add package Aspose.Slides.NET --version 22.11.0` çalıştırın  
   * `dotnet add package FFMpegCore --version 4.8.0` çalıştırın  
2. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.  
3. FFMpegCore, indirilen ffmpeg'in yolunu belirtmenizi ister (örneğin, "C:\tools\ffmpeg" klasörüne çıkarıldı):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. PowerPoint‑to‑video dönüşüm kodunu çalıştırın.

Bu C# kodu, bir şekil ve iki animasyon efekti içeren bir sunumu videoya dönüştürmeyi gösterir:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // daha önce C:\tools\ffmpeg'e çıkardığımız FFmpeg ikili dosyalarını kullanacak.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Bir gülümseme şekli ekleyin ve ardından animasyon ekleyin.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // ffmpeg ikili dosyaları klasörünü yapılandırın. Bu sayfaya bakın: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Kareleri bir webm videosuna dönüştürün.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Video Efektleri**

Aspose.Slides for .NET kullanarak bir PowerPoint sunumunu videoya dönüştürürken, çıkışın görsel kalitesini artırmak için çeşitli video efektleri uygulayabilirsiniz. Bu efektler, final videoda slaytların görünümünü pürüzsüz geçişler, animasyonlar ve diğer görsel öğeler ekleyerek kontrol etmenizi sağlar. Bu bölüm, mevcut video efekt seçeneklerini açıklar ve nasıl uygulanacağını gösterir.

{{% alert color="primary" %}} 

Bakınız:  
- [C# ile PowerPoint Sunumlarını Animasyonlarla Geliştirme]((https://docs.aspose.com/slides/tr/net/powerpoint-animation/))  
- [Şekil Animasyonu]((https://docs.aspose.com/slides/tr/net/shape-animation/))  
- [C# Kullanarak PowerPoint'te Şekil Efektlerini Uygulama]((https://docs.aspose.com/slides/tr/net/shape-effect/))

{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha ilgi çekici hâle getirir — videolar için de aynı şey geçerlidir. Önceki sunum koduna bir slayt ve geçiş ekleyelim:

```c#
// Bir gülümseme şekli ekleyin ve animasyon uygulayın.
// ...

// Yeni bir slayt ekleyin ve animasyonlu bir geçiş ekleyin.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides ayrıca metin animasyonlarını da destekler. Bu örnekte, nesneler üzerindeki paragraf ları birbiri ardına, aralarında bir saniyelik gecikme olacak şekilde animasyonluyoruz:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Metin ve animasyonlar ekle.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // ffmpeg ikili dosyaları klasörünü yapılandırın. Bu sayfaya bakın: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Kareleri bir webm videosuna dönüştürün.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Video Dönüştürme Sınıfları**

PowerPoint‑to‑video dönüşüm görevlerini etkinleştirmek için Aspose.Slides for .NET, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationanimationsgenerator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationplayer/) sınıflarını sağlar.

`PresentationAnimationsGenerator`, video için çerçeve boyutunu (daha sonra oluşturulacak) ve saniyedeki kare (FPS) değerini kurucusu aracılığıyla ayarlamanıza olanak tanır. Bir sunum örneği geçirirseniz, `Presentation.SlideSize` kullanılacak ve bu sınıf, [PresentationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationplayer/) tarafından kullanılan animasyonları üretir.

Animasyonlar üretildiğinde, her ardışık animasyon için bir `NewAnimation` olayı tetiklenir; bu olay bir [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipresentationanimationplayer/) parametresi içerir. Bu sınıf, tek bir animasyonun oynatıcısını temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipresentationanimationplayer/) ile çalışırken, tam animasyon süresini veren `Duration` özelliğini ve `SetTimePosition` metodunu kullanırsınız. Her animasyon konumu *0 ile duration* aralığında ayarlanır ve `GetFrame` metodu o noktadaki animasyon durumunu gösteren bir Bitmap döndürür.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Bir gülümseme şekli ekleyin ve animasyon uygulayın.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // Animasyonun ilk durumu.
            Bitmap bitmap = animationPlayer.GetFrame();  // Animasyonun ilk durumu bitmap'i.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // Animasyonun son durumu.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // Animasyonun son karesi.
            lastBitmap.Save("last.png");
        };
    }
}
```

Tüm animasyonların aynı anda oynatılmasını sağlamak için [PresentationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationplayer/) sınıfı kullanılır. Bu sınıf, kurucusunda bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationanimationsgenerator/) örneği ve efektler için bir FPS değeri alır, ardından tüm animasyonları oynatmak için `FrameTick` olayını tetikler:

```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Oluşturulan çerçeveler daha sonra birleştirilerek video üretilir. Bununla ilgili ayrıntıyı [PowerPoint Sunumunu Videoya Dönüştürme](/slides/tr/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) bölümünde bulabilirsiniz.

## **Desteklenen Animasyonlar ve Efektler**

Aspose.Slides for .NET kullanarak bir PowerPoint sunumunu videoya dönüştürürken, çıkışta hangi animasyonların ve efektlerin desteklendiğini anlamak önemlidir. Aspose.Slides, solma, kaydırma, yakınlaştırma ve döndürme gibi yaygın giriş, çıkış ve vurgu efektlerinin geniş bir yelpazesini destekler. Ancak bazı ileri düzey veya özel animasyonlar tam olarak korunmayabilir ya da final videoda farklı görünebilir. Aşağıda desteklenen animasyon ve efektler özetlenmiştir.

**Giriş**:

| Animasyon Tipi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Görünme** | ![not supported](x.png) | ![supported](v.png) |
| **Soldurma** | ![supported](v.png) | ![supported](v.png) |
| **Uçuş İçeri** | ![supported](v.png) | ![supported](v.png) |
| **Yüzme İçeri** | ![supported](v.png) | ![supported](v.png) |
| **Bölünme** | ![supported](v.png) | ![supported](v.png) |
| **Silme** | ![supported](v.png) | ![supported](v.png) |
| **Şekil** | ![supported](v.png) | ![supported](v.png) |
| **Tekerlek** | ![supported](v.png) | ![supported](v.png) |
| **Rastgele Çubuklar** | ![supported](v.png) | ![supported](v.png) |
| **Büyü & Dön** | ![not supported](x.png) | ![supported](v.png) |
| **Yakınlaştırma** | ![supported](v.png) | ![supported](v.png) |
| **Dönme** | ![supported](v.png) | ![supported](v.png) |
| **Sıçrama** | ![supported](v.png) | ![supported](v.png) |

**Vurgu**:

| Animasyon Tipi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Darbe** | ![not supported](x.png) | ![supported](v.png) |
| **Renk Darbesi** | ![not supported](x.png) | ![supported](v.png) |
| **Osilasyon** | ![supported](v.png) | ![supported](v.png) |
| **Dönme** | ![supported](v.png) | ![supported](v.png) |
| **Büyü/Küçül** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturasyon** | ![not supported](x.png) | ![supported](v.png) |
| **Karanlıklaştırma** | ![not supported](x.png) | ![supported](v.png) |
| **Aydınlatma** | ![not supported](x.png) | ![supported](v.png) |
| **Şeffaflık** | ![not supported](x.png) | ![supported](v.png) |
| **Nesne Rengi** | ![not supported](x.png) | ![supported](v.png) |
| **Tamamlayıcı Renk** | ![not supported](x.png) | ![supported](v.png) |
| **Çizgi Rengi** | ![not supported](x.png) | ![supported](v.png) |
| **Dolgu Rengi** | ![not supported](x.png) | ![supported](v.png) |

**Çıkış**:

| Animasyon Tipi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Kaybolma** | ![not supported](x.png) | ![supported](v.png) |
| **Soldurma** | ![supported](v.png) | ![supported](v.png) |
| **Uçuş Dışarı** | ![supported](v.png) | ![supported](v.png) |
| **Yüzme Dışarı** | ![supported](v.png) | ![supported](v.png) |
| **Bölünme** | ![supported](v.png) | ![supported](v.png) |
| **Silme** | ![supported](v.png) | ![supported](v.png) |
| **Şekil** | ![supported](v.png) | ![supported](v.png) |
| **Rastgele Çubuklar** | ![supported](v.png) | ![supported](v.png) |
| **Küçül & Dön** | ![not supported](x.png) | ![supported](v.png) |
| **Yakınlaştırma** | ![supported](v.png) | ![supported](v.png) |
| **Dönme** | ![supported](v.png) | ![supported](v.png) |
| **Sıçrama** | ![supported](v.png) | ![supported](v.png) |

**Hareket Yolları**:

| Animasyon Tipi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Çizgiler** | ![supported](v.png) | ![supported](v.png) |
| **Kemerler** | ![supported](v.png) | ![supported](v.png) |
| **Dönüşler** | ![supported](v.png) | ![supported](v.png) |
| **Şekiller** | ![supported](v.png) | ![supported](v.png) |
| **Döngüler** | ![supported](v.png) | ![supported](v.png) |
| **Özel Yol** | ![supported](v.png) | ![supported](v.png) |

## **Desteklenen Slayt Geçiş Efektleri**

Slayt geçiş efektleri, bir videoda slaytlar arasındaki değişiklikleri pürüzsüz ve görsel açıdan çekici hâle getirmede önemli bir rol oynar. Aspose.Slides for .NET, orijinal sunumunuzun akışını ve stilini korumak için çeşitli yaygın geçiş efektlerini destekler. Aşağıda dönüşüm sırasında desteklenen geçiş efektleri listelenmiştir.

**İnce**:

| Geçiş Tipi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Heyecanlı**:

| Geçiş Tipi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x/png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Dinamik İçerik**:

| Geçiş Tipi | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **Sıkça Sorulan Sorular**

**Şifre korumalı sunumları dönüştürmek mümkün mü?**

Evet, Aspose.Slides for .NET şifreyle korunan sunumlarla çalışmaya izin verir. Bu dosyaları işlerken doğru şifreyi sağlamanız gerekir; böylece kütüphane sunumun içeriğine erişebilir.

**Aspose.Slides for .NET bulut çözümlerinde kullanılabilir mi?**

Evet, Aspose.Slides for .NET bulut uygulamaları ve hizmetlerine entegre edilebilir. Kütüphane, sunucu ortamlarında çalışmak üzere tasarlanmıştır ve toplu dosya işleme için yüksek performans ve ölçeklenebilirlik sunar.

**Dönüştürme sırasında sunumların boyutlarıyla ilgili sınırlamalar var mı?**

Aspose.Slides for .NET neredeyse herhangi bir boyuttaki sunumu işleyebilir. Ancak çok büyük dosyalarla çalışırken ek sistem kaynaklarına ihtiyaç duyulabilir ve performansı artırmak için sunumu optimize etmek önerilir.