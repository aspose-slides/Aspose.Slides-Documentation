---
title: .NET'te PowerPoint Sunumlarını Videoya Dönüştürme
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
- PPTX'den videoya
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
description: "PowerPoint sunumlarını .NET'te videoya nasıl dönüştüreceğinizi öğrenin. İş akışınızı hızlandırmak için örnek C# kodu ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint veya OpenDocument sunumunuzu videoya dönüştürerek şu avantajları elde edersiniz:

**Artan erişilebilirlik:** Tüm cihazlar, platformdan bağımsız olarak, varsayılan olarak video oynatıcıya sahiptir, bu da geleneksel sunum uygulamalarına göre videoların açılmasını veya oynatılmasını kolaylaştırır.

**Daha geniş kitleye ulaşım:** Videolar, daha büyük bir izleyici kitlesine ulaşmanızı ve bilgileri daha etkileyici bir formatta sunmanızı sağlar. Anketler ve istatistikler, insanların diğer biçimlere göre video içeriğini izlemeyi ve tüketmeyi tercih ettiğini gösterir, bu da mesajınızın etkisini artırır.

{{% alert color="info" %}} 
{{% /alert %}} 

{{% alert color="info" %}} 
{{% /alert %}} 

{{% alert color="info" %}} 

Kontrol edin: [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/tr/video) çünkü buradaki sürecin canlı ve etkili bir uygulamasını sunar.

{{% /alert %}} 

Aspose.Slides for .NET'te sunumları videoya dönüştürme desteği ekledik.

* Aspose.Slides for .NET'i kullanarak sunum slaytlarından belirli bir kare hızı (FPS) ile kareler oluşturun.
* Ardından, bu kareleri bir video dosyasına derlemek için ffmpeg gibi üçüncü taraf bir yardımcı program kullanın.

## **PowerPoint Sunumunu Video'ya Dönüştürme**

1. Projeye Aspose.Slides ve FFMpegCore kütüphanesini eklemek için `dotnet add package` komutunu kullanın:
   * `dotnet add package Aspose.Slides.NET --version 22.11.0` komutunu çalıştırın
   * `dotnet add package FFMpegCore --version 4.8.0` komutunu çalıştırın
2. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.
3. FFMpegCore, indirilen ffmpeg'in yolunu (örn. "C:\tools\ffmpeg" dizinine çıkarıldı) belirtmenizi ister:  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. PowerPoint‑to‑video dönüştürme kodunu çalıştırın.

Aşağıdaki C# kodu, bir şekil ve iki animasyon etkisi içeren bir sunumu videoya nasıl dönüştüreceğinizi gösterir:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // daha önce C:\tools\ffmpeg klasörüne çıkardığımız FFmpeg ikili dosyalarını kullanacaktır.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Bir gülümseme şekli ekleyin ve ardından onu canlandırın.
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

Aspose.Slides for .NET kullanarak bir PowerPoint sunumunu videoya dönüştürürken, çıkışın görsel kalitesini artırmak için çeşitli video efektleri uygulayabilirsiniz. Bu efektler, slaytların videoda sorunsuz geçişler, animasyonlar ve diğer görsel öğeler ekleyerek nasıl görüneceğini kontrol etmenizi sağlar. Bu bölüm, mevcut video efekti seçeneklerini açıklar ve bunların nasıl uygulanacağını gösterir.

{{% alert color="info" %}} 

Bakınız:
- [C# ile PowerPoint Sunumlarını Animasyonlarla Zenginleştirme](https://docs.aspose.com/slides/tr/net/powerpoint-animation/)
- [Şekil Animasyonu](https://docs.aspose.com/slides/tr/net/shape-animation/)
- [C# Kullanarak PowerPoint’te Şekil Efektleri Uygulama](https://docs.aspose.com/slides/tr/net/shape-effect/)

{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha ilgi çekici ve eğlenceli hâle getirir — videolar için de aynı şey geçerlidir. Önceki sunum koduna bir slayt ve geçiş ekleyelim:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Bir gülümseme şekli ekleyin ve canlandırın (yukarıdaki koda bakın).

    // Yeni bir slayt ekleyin ve animasyonlu bir geçiş ekleyin.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides aynı zamanda metin animasyonlarını da destekler. Bu örnekte, nesneler üzerindeki paragrafları birbiri ardına, aralarında bir saniyelik gecikme olacak şekilde canlandırıyoruz:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Metin ve animasyon ekleyin.
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

PowerPoint‑to‑video dönüşüm görevlerini etkinleştirmek için Aspose.Slides for .NET, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationanimationsgenerator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationplayer/) sınıflarını sunar.

`PresentationAnimationsGenerator`, video için kare boyutunu (daha sonra oluşturulacak) ve FPS (saniyedeki kare sayısı) değerini kurucu aracılığıyla ayarlamanıza izin verir. Bir sunum örneği geçirirseniz, onun `Presentation.SlideSize` özelliği kullanılır ve oluşturulan animasyonlar [PresentationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationplayer/) tarafından kullanılır.

Animasyonlar oluşturulduğunda, her bir sonraki animasyon için bir `NewAnimation` olayı tetiklenir; bu olay bir [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipresentationanimationplayer/) parametresi içerir. Bu sınıf, tek bir animasyon için oynatıcıyı temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipresentationanimationplayer/) ile çalışmak için [Duration](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipresentationanimationplayer/duration/) özelliğini (animasyonun toplam süresini verir) ve [SetTimePosition](https://reference.aspose.com/slides/tr/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) metodunu kullanırsınız. Her animasyon konumu *0 ile duration* aralığında ayarlanır ve `GetFrame` metodu o anda animasyon durumunu gösteren bir Bitmap döndürür.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Bir gülümseme şekli ekleyin ve canlandırın.
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

            animationPlayer.SetTimePosition(0);        // Animasyonun ilk durumu.
            IImage image = animationPlayer.GetFrame(); // Animasyonun ilk durumu resmi.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // Animasyonun son durumu.
            IImage lastImage = animationPlayer.GetFrame();             // Animasyonun son çerçevesi.
            lastImage.Save("last.png");
        };
    }
}
```

Tüm animasyonların aynı anda oynatılması için [PresentationPlayer](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationplayer/) sınıfı kullanılır. Bu sınıf, bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/net/aspose.slides.export/presentationanimationsgenerator/) örneği ve efektler için bir FPS değeri alır, ardından tüm animasyonlar için `FrameTick` olayını tetikleyerek bunları oynatır:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Oluşturulan kareler daha sonra bir video dosyasına derlenebilir. Bkz. [PowerPoint Sunumunu Video'ya Dönüştürme](/slides/tr/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) bölümü.

## **Desteklenen Animasyonlar ve Efektler**

Aspose.Slides for .NET kullanarak bir PowerPoint sunumunu videoya dönüştürürken, çıktıda hangi animasyon ve efektlerin desteklendiğini anlamak önemlidir. Aspose.Slides, fade, fly in, zoom ve spin gibi yaygın giriş, çıkış ve vurgu efektlerinin geniş bir yelpazesini destekler. Ancak, bazı gelişmiş veya özel animasyonlar tam olarak korunmayabilir ya da videoda farklı görünebilir. Bu bölüm, desteklenen animasyon ve efektleri özetler.

**Giriş**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Fade** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Fly In** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Float In** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Split** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Wipe** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Shape** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Wheel** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Random Bars** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Grow & Turn** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Zoom** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Swivel** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Bounce** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |

**Vurgu**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Color Pulse** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Teeter** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Spin** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Grow/Shrink** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Desaturate** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Darken** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Lighten** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Transparency** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Object Color** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Complementary Color** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Line Color** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Fill Color** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |

**Çıkış**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Fade** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Fly Out** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Float Out** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Split** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Wipe** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Shape** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Random Bars** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Shrink & Turn** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Zoom** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Swivel** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Bounce** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |

**Hareket Yolları**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Arcs** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Turns** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Shapes** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Loops** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Custom Path** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |

## **Desteklenen Slayt Geçiş Efektleri**

Slayt geçiş efektleri, videoda slaytlar arasında sorunsuz ve görsel olarak çekici değişimler oluşturmak için önemli bir rol oynar. Aspose.Slides for .NET, orijinal sunumunuzun akışını ve stilini korumaya yardımcı olmak için yaygın olarak kullanılan çeşitli geçiş efektlerini destekler. Bu bölüm, dönüşüm sırasında hangi geçiş efektlerinin desteklendiğini vurgular.

**Subtle (Hafif)**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Fade** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Push** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Pull** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Wipe** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Split** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Reveal** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Random Bars** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Shape** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Uncover** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Cover** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Flash** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Strips** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |

**Exciting (Heyecanlı)**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Drape** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Curtains** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Wind** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Prestige** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Fracture** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Crush** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Peel Off** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Page Curl** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Airplane** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Origami** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Dissolve** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Checkerboard** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Blinds** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Clock** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Ripple** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Honeycomb** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Glitter** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Vortex** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Shred** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Switch** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Flip** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Gallery** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Cube** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Doors** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Box** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Comb** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Zoom** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Random** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |

**Dynamic Content (Dinamik İçerik)**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Ferris Wheel** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Conveyor** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Rotate** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Orbit** | ![desteklenmiyor](x.png) | ![destekleniyor](v.png) |
| **Fly Through** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |

## **SSS**

### Şifre korumalı sunumları dönüştürmek mümkün mü?

Evet, Aspose.Slides for .NET şifre korumalı sunumlarla çalışmayı destekler. Bu dosyaları işlerken doğru şifreyi sağlayarak kütüphanenin sunum içeriğine erişmesini sağlamalısınız.

### Aspose.Slides for .NET bulut çözümlerinde kullanılabilir mi?

Evet, Aspose.Slides for .NET bulut uygulamaları ve servislerine entegre edilebilir. Kütüphane, sunucu ortamlarında yüksek performans ve ölçeklenebilirlik sağlayacak şekilde tasarlanmıştır, bu da dosyaların toplu işlenmesi için idealdir.

### Dönüştürme sırasında sunumların boyutlarıyla ilgili bir sınırlama var mı?

Aspose.Slides for .NET neredeyse her boyutta sunumu işleyebilir. Ancak, çok büyük dosyalarla çalışırken ek sistem kaynaklarına ihtiyaç duyulabilir ve performansı artırmak için sunumu optimize etmeniz önerilir.