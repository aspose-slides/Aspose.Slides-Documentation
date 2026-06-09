---
title: Android'de PowerPoint Sunumlarını Videoya Dönüştürme
linktitle: PowerPoint'ten Video
type: docs
weight: 130
url: /tr/androidjava/convert-powerpoint-to-video/
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
- PPTX'ten MP4'e
- PPT'yi MP4 olarak kaydet
- PPTX'i MP4 olarak kaydet
- PPT'yi MP4'e dışa aktar
- PPTX'i MP4'e dışa aktar
- video dönüşümü
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Java'da PowerPoint sunumlarını videoya nasıl dönüştüreceğinizi öğrenin. İş akışınızı kolaylaştırmak için örnek kod ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint sunumunuzu videoya dönüştürerek şunları elde edersiniz  

* **Erişilebilirlik artışı:** Tüm cihazlar (platforma bakılmaksızın) varsayılan olarak video oynatıcılarıyla donatılmıştır; bu, kullanıcıların videoları açıp oynatmasını sunum‑açma uygulamalarına göre daha kolay hâle getirir.
* **Daha geniş kitle:** Videolar sayesinde büyük bir izleyici kitlesine ulaşabilir ve onları, bir sunumda sıkıcı olabilecek bilgilerle hedefleyebilirsiniz. Çoğu anket ve istatistik, insanların diğer içerik türlerine kıyasla videoları daha çok izlediğini ve tükettiğini, ayrıca bu tür içerikleri genellikle tercih ettiklerini göstermektedir.

{{% alert color="primary" %}} 

İsterseniz [**PowerPoint'tan Video'ya Çevrimiçi Dönüştürücü**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) inceleyebilirsiniz; çünkü burada anlatılan sürecin canlı ve etkili bir uygulamasıdır.

{{% /alert %}} 

## **Aspose.Slides’da PowerPoint‑tan Video Dönüştürme**

Aspose.Slides, sunum‑dan‑video dönüşümünü destekler.

* **Aspose.Slides** kullanarak, belirli bir FPS (saniyedeki kare sayısı) değerine karşılık gelen bir dizi çerçeve (sunum slaytlarından) oluşturun
* **ffmpeg** gibi bir üçüncü taraf aracı ([java için](https://github.com/bramp/ffmpeg-cli-wrapper)) kullanarak bu çerçevelerden bir video oluşturun. 

### **PowerPoint'tan Video'ya Dönüştürme**

1. POM dosyanıza şu satırı ekleyin:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.

4. PowerPoint‑ten video Java kodunu çalıştırın.

Bu Java kodu, bir şekil ve iki animasyon efekti içeren bir sunumu nasıl video hâline getireceğinizi gösterir:

```java
Presentation presentation = new Presentation();
try {
    // Bir gülümseme şekli ekler ve ardından animasyon uygular
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg ikili dosyaları klasörünü yapılandırın. Bu sayfaya bakın: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Video Efektleri**

Slaytlardaki nesnelere animasyon uygulayabilir ve slaytlar arasında geçişler kullanabilirsiniz. 

{{% alert color="primary" %}} 

Şu makalelere göz atmak isteyebilirsiniz: [PowerPoint Animasyonu](https://docs.aspose.com/slides/tr/androidjava/powerpoint-animation/), [Şekil Animasyonu](https://docs.aspose.com/slides/tr/androidjava/shape-animation/), ve [Şekil Efekti](https://docs.aspose.com/slides/tr/androidjava/shape-effect/).

{{% /alert %}} 

Animasyonlar ve geçişler, slayt gösterilerini daha ilgi çekici ve etkileyici hâle getirir—ve aynı etkiyi videolara da uygular. Önceki sunum koduna bir slayt ve geçiş daha ekleyelim:

```java
// Bir gülümseme şekli ekler ve animasyon uygular

// ...

// Yeni bir slayt ekler ve animasyonlu geçiş ekler

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides ayrıca metin animasyonlarını da destekler. Nesneler üzerindeki paragrafları, birbirini bir saniyelik gecikmeyle takip edecek şekilde canlandırıyoruz:

```java
Presentation presentation = new Presentation();
try {
    // Metin ve animasyon ekler
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg ikili dosyaları klasörünü yapılandırın. Bu sayfaya bakın: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Video Dönüştürme Sınıfları**

PowerPoint‑tan video dönüşüm görevlerini gerçekleştirmenizi sağlamak için Aspose.Slides, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationanimationsgenerator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationplayer/) sınıflarını sunar.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationanimationsgenerator/) video (daha sonra oluşturulacak) için çerçeve boyutunu yapıcı yöntemi aracılığıyla ayarlamanıza olanak tanır. Sunumu bir örnek olarak geçirirseniz `Presentation.SlideSize` kullanılır ve [PresentationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationplayer/) tarafından kullanılan animasyonları üretir.

Animasyonlar oluşturulduğunda, her ardışık animasyon için `NewAnimation` olayı tetiklenir; bu olayda [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/) parametresi bulunur. Bu sınıf, ayrı bir animasyonun oynatıcısını temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/) ile çalışmak için [Duration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (animasyonun tam süresi) özelliği ve [SetTimePosition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) yöntemi kullanılır. Her animasyon konumu *0 ile süresi* arasına ayarlanır ve ardından `GetFrame` yöntemi, o anki animasyon durumuna karşılık gelen bir BufferedImage döndürür:

```java
Presentation presentation = new Presentation();
try {
    // Bir gülümseme şekli ekler ve animasyon uygular
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // ilk animasyon durumu
            try {
                // ilk animasyon durumu bitmap'i
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // animasyonun son durumu
            try {
                // animasyonun son karesi
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Bir sunumdaki tüm animasyonların aynı anda oynatılmasını sağlamak için [PresentationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationplayer/) sınıfı kullanılır. Bu sınıf, bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationanimationsgenerator/) örneği ve FPS değerini yapıcıda alır, ardından tüm animasyonlar için `FrameTick` olayını tetikleyerek oynatılmalarını sağlar:

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Oluşturulan çerçeveler daha sonra birleştirilerek video üretilir. Bkz. [PowerPoint‑ten Video'ya Dönüştürme](https://docs.aspose.com/slides/tr/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümü.

## **Desteklenen Animasyonlar ve Efektler**

**Giriş**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Vurgu**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Çıkış**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Hareket Yolları**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **SSS**

**Parola korumalı sunumları dönüştürmek mümkün mü?**

Evet, Aspose.Slides, [parola‑korumalı sunumlarla](/slides/tr/androidjava/password-protected-presentation/) çalışmaya izin verir. Bu dosyaları işlerken, kütüphanenin sunum içeriğine erişebilmesi için doğru parolayı sağlamalısınız.

**Aspose.Slides bulut çözümlerinde kullanılabilir mi?**

Evet, Aspose.Slides bulut uygulamaları ve hizmetlerine entegre edilebilir. Kütüphane, sunucu ortamlarında çalışacak şekilde tasarlanmıştır; bu da dosyaların toplu işlenmesinde yüksek performans ve ölçeklenebilirlik sağlar.

**Dönüşüm sırasında sunumların boyutlarıyla ilgili sınırlamalar var mı?**

Aspose.Slides, temelde her boyutta sunumu işleyebilir. Ancak çok büyük dosyalarla çalışırken ek sistem kaynakları gerekebilir ve performansı artırmak için sunumu optimize etmeniz önerilir.