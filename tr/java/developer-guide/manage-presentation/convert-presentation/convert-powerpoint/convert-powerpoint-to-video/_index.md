---
title: PowerPoint Sunumlarını Java'da Videoya Dönüştür
linktitle: PowerPoint'ten Video'ya
type: docs
weight: 130
url: /tr/java/convert-powerpoint-to-video/
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
- video dönüştürme
- PowerPoint
- Java
- Aspose.Slides
description: "Java'da PowerPoint sunumlarını videoya nasıl dönüştüreceğinizi öğrenin. İş akışınızı kolaylaştırmak için örnek kodları ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint veya OpenDocument sunumunuzu videoya dönüştürerek şunları elde edersiniz:

**Artan erişilebilirlik:** Tüm cihazlar, platformdan bağımsız olarak, varsayılan olarak video oynatıcılarıyla gelir, bu da kullanıcıların geleneksel sunum uygulamalarına göre videoları açmasını veya oynatmasını kolaylaştırır.

**Daha geniş erişim:** Videolar daha büyük bir kitleye ulaşmanızı ve bilgiyi daha ilgi çekici bir formatta sunmanızı sağlar. Anketler ve istatistikler, insanların diğer formatlara göre video içeriğini izlemeyi ve tüketmeyi tercih ettiğini gösterir, bu da mesajınızı daha etkili kılar.

{{% alert color="primary" %}} 

Bu sayfada açıklanan sürecin canlı ve etkili bir uygulaması olduğu için [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) aracını kontrol etmek isteyebilirsiniz.

{{% /alert %}} 

## **Aspose.Slides'da PowerPoint'ten Video Dönüşümü**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/tr/java/aspose-slides-for-java-22-11-release-notes/) sürümünde sunumu videoya dönüştürme desteği ekledik. 

* **Aspose.Slides**'ı belirli bir FPS (saniyedeki kare sayısı) ile eşleşen bir dizi çerçeve (sunum slaytlarından) oluşturmak için kullanın
* Çerçevelere dayalı bir video oluşturmak için **ffmpeg** gibi bir üçüncü taraf aracı ([java için](https://github.com/bramp/ffmpeg-cli-wrapper)) kullanın. 

### **PowerPoint'i Video'ya Dönüştür**

1. POM dosyanıza şunu ekleyin:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg'yi [buradan](https://ffmpeg.org/download.html) indirin.

4. PowerPoint'ten video Java kodunu çalıştırın.

Bu Java kodu, bir şekil ve iki animasyon efekti içeren bir sunumu videoya nasıl dönüştüreceğinizi gösterir:

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

    // ffmpeg ikili dosyalarının klasörünü yapılandırın. Bu sayfaya bakın: https://github.com/rosenbjerg/FFMpegCore#installation
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

Slaytlardaki nesnelere animasyonlar uygulayabilir ve slaytlar arasında geçişler kullanabilirsiniz. 

{{% alert color="primary" %}} 

Şu makalelere göz atmak isteyebilirsiniz: [PowerPoint Animation](https://docs.aspose.com/slides/tr/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/tr/java/shape-animation/), ve [Shape Effect](https://docs.aspose.com/slides/tr/java/shape-effect/).

{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha ilgi çekici ve etkileyici kılar—ve videolar için de aynı etkiyi sağlar. Önceki sunumun koduna bir slayt ve geçiş daha ekleyelim:

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

Aspose.Slides ayrıca metin animasyonunu da destekler. Bu nedenle nesneler üzerindeki paragrafları animasyonlu hale getiririz; bunlar birbiri ardına (gecikme bir saniye olarak ayarlanmış) görünecektir:

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

## **Video Dönüşüm Sınıfları**

PowerPoint'ten video dönüşüm görevlerini gerçekleştirebilmeniz için Aspose.Slides, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationanimationsgenerator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationplayer/) sınıflarını sağlar.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationanimationsgenerator/) video (sonradan oluşturulacak) için çerçeve boyutunu yapıcı üzerinden ayarlamanızı sağlar. Sunumun bir örneğini gönderirseniz `Presentation.SlideSize` kullanılır ve [PresentationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationplayer/) tarafından kullanılan animasyonları üretir. 

Animasyonlar üretildiğinde, her sonraki animasyon için bir `NewAnimation` olayı tetiklenir; bu olayın parametresi [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/) olur. Bu sınıf ayrı bir animasyonun oynatıcısını temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/) ile çalışmak için [Duration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (animasyonun tam süresi) özelliği ve [SetTimePosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) yöntemi kullanılır. Her animasyon konumu *0 ile süresi* aralığında ayarlanır ve ardından `GetFrame` yöntemi o anki animasyon durumuna karşılık gelen bir BufferedImage döndürür:

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
            animationPlayer.setTimePosition(0); // başlangıç animasyon durumu
            try {
                // başlangıç animasyon durumu bitmap'i
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

Tüm animasyonların bir sunumda aynı anda oynatılması için [PresentationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationplayer/) sınıfı kullanılır. Bu sınıf, bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationanimationsgenerator/) örneği ve FPS değerini yapıcıya alır, ardından tüm animasyonlar için `FrameTick` olayını tetikleyerek çerçeveleri oynatır:

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

Oluşturulan çerçeveler daha sonra bir video üretmek için derlenebilir. Bkz. [Convert PowerPoint to Video](https://docs.aspose.com/slides/tr/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümü.

## **Desteklenen Animasyonlar ve Efektler**

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

**Hareket Yolları:**

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Arcs** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Turns** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Shapes** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Loops** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |
| **Custom Path** | ![destekleniyor](v.png) | ![destekleniyor](v.png) |

## **SSS**

**Şifre korumalı sunumları dönüştürmek mümkün mü?**

Evet, Aspose.Slides [şifre korumalı sunumlarla](/slides/tr/java/password-protected-presentation/) çalışabilir. Bu tür dosyaları işlerken doğru şifreyi sağlayarak kütüphanenin sunum içeriğine erişmesini sağlamalısınız.

**Aspose.Slides bulut çözümlerinde kullanılmayı destekliyor mu?**

Evet, Aspose.Slides bulut uygulamaları ve hizmetlerine entegre edilebilir. Kütüphane, sunucu ortamlarında çalışacak şekilde tasarlanmış olup, dosyaların toplu işlenmesi için yüksek performans ve ölçeklenebilirlik sunar.

**Dönüşüm sırasında sunumlar için boyut sınırlamaları var mı?**

Aspose.Slides neredeyse her boyuttaki sunumu işleyebilir. Ancak çok büyük dosyalarla çalışırken ek sistem kaynakları gerekebilir ve performansı artırmak için sunumu optimize etmeniz önerilebilir.