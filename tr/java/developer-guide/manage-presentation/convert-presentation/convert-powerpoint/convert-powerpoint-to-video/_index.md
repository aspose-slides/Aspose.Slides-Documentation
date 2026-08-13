---
title: Java'da PowerPoint Sunumlarını Videoya Dönüştürme
linktitle: PowerPoint'ten Videoya
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
- PPT'yi MP4'e aktar
- PPTX'i MP4'e aktar
- video dönüştürme
- PowerPoint
- Java
- Aspose.Slides
description: "Java'da PowerPoint sunumlarını videoya nasıl dönüştüreceğinizi öğrenin. İş akışınızı kolaylaştırmak için örnek kod ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint veya OpenDocument sunumunuzu video'ye dönüştürerek şu avantajları elde edersiniz:

**Artırılmış erişilebilirlik:** Tüm cihazlar, platformdan bağımsız olarak, varsayılan olarak video oynatıcılarıyla donatılmıştır; bu, kullanıcıların geleneksel sunum uygulamalarına kıyasla videoları açmasını veya oynatmasını kolaylaştırır.

**Daha geniş erişim:** Videolar, daha geniş bir kitleye ulaşmanızı ve bilgileri daha ilgi çekici bir formatta sunmanızı sağlar. Anketler ve istatistikler, insanların diğer biçimlere göre video içeriğini izlemeyi ve tüketmeyi tercih ettiğini göstermektedir; bu da mesajınızın daha etkili olmasını sağlar.

{{% alert color="info" %}} 
İşlem burada açıklanan sürecin canlı ve etkili bir uygulaması olduğu için [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/tr/video) aracımıza göz atmak isteyebilirsiniz.
{{% /alert %}} 

## **PowerPoint'ten Video Dönüştürme Aspose.Slides'ta**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/tr/java/aspose-slides-for-java-22-11-release-notes/) sürümünde, sunumu video'ye dönüştürme desteği ekledik. 

* **Aspose.Slides** kullanarak belirli bir FPS'ye (saniyedeki kare sayısı) karşılık gelen bir dizi çerçeve (sunum slaytlarından) üretin
* Çerçevelere dayanarak video oluşturmak için **ffmpeg** gibi bir üçüncü taraf aracı ([java için](https://github.com/bramp/ffmpeg-cli-wrapper)) kullanın. 

### **PowerPoint'i Video'ye Dönüştür**

1. POM dosyanıza bunu ekleyin:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.

4. PowerPoint'i video'ye dönüştüren Java kodunu çalıştırın.

Bu Java kodu, bir şekil ve iki animasyon efekti içeren bir sunumu video'ye nasıl dönüştüreceğinizi gösterir:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

Slaytlardaki nesnelere animasyon ekleyebilir ve slaytlar arasında geçişler kullanabilirsiniz.

{{% alert color="info" %}} 
Bu makalelere göz atmak isteyebilirsiniz: [PowerPoint Animation](https://docs.aspose.com/slides/tr/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/tr/java/shape-animation/), ve [Shape Effect](https://docs.aspose.com/slides/tr/java/shape-effect/).
{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha ilgi çekici ve eğlenceli kılar—ve videolar için de aynı şeyi yapar. Önceki sunum için koda bir slayt ve geçiş ekleyelim:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Bir gülümseme şekli ekler ve animasyon uygular

    // ...

    // Yeni bir slayt ekler ve animasyonlu geçiş ekler

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides ayrıca metin animasyonunu da destekler. Bu nedenle nesneler üzerindeki paragrafları animasyonla, birbiri ardına (gecikme bir saniye olarak ayarlanmış) görünür şekilde hareket ettiririz:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Metin ve animasyonlar ekler
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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

PowerPoint'ten video'ye dönüştürme görevlerini gerçekleştirmenizi sağlamak için Aspose.Slides, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationanimationsgenerator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationplayer/) sınıflarını sunar.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationanimationsgenerator/) size video için çerçeve boyutunu (daha sonra oluşturulacak) kurucu aracılığıyla ayarlamanızı sağlar. Sunum örneği geçirilirse, `Presentation.SlideSize` kullanılır ve [PresentationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationplayer/) tarafından kullanılan animasyonlar oluşturulur. 

Animasyonlar oluşturulduğunda, her sonraki animasyon için bir `NewAnimation` olayı tetiklenir; bu olay bir [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/) parametresi alır. Bu sınıf, ayrı bir animasyon için bir oynatıcıyı temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/) ile çalışmak için, [Duration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (animasyonun toplam süresi) özelliği ve [SetTimePosition](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) yöntemi kullanılır. Her animasyon konumu *0 ile süresi* arasında ayarlanır ve ardından `getFrame` yöntemi o anki animasyon durumuna karşılık gelen bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) döndürür:
```java
import com.aspose.slides.*;

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
            // ilk animasyon durumu bitmap'i
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // animasyonun son durumu
            // animasyonun son karesi
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // animasyonları oluştur - bu, yukarıda ele alınan olayları tetikler
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Tüm animasyonların bir sunumda aynı anda oynatılması için [PresentationPlayer](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationplayer/) sınıfı kullanılır. Bu sınıf, bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentationanimationsgenerator/) örneği ve efektler için FPS alır; ardından tüm animasyonlar için `FrameTick` olayını tetikleyerek onları oynatır:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Oluşturulan çerçeveler video üretmek için derlenebilir. Bkz. [Convert PowerPoint to Video](https://docs.aspose.com/slides/tr/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümü.

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

### Şifre korumalı sunumları dönüştürmek mümkün mü?

Evet, Aspose.Slides [şifre korumalı sunumlarla](/slides/tr/java/password-protected-presentation/) çalışmaya izin verir. Bu dosyaları işlerken, kütüphanenin sunum içeriğine erişebilmesi için doğru şifreyi sağlamanız gerekir.

### Aspose.Slides bulut çözümlerinde kullanılmayı destekliyor mu?

Evet, Aspose.Slides bulut uygulamaları ve hizmetlerine entegre edilebilir. Kütüphane, dosyaların toplu işlenmesi için yüksek performans ve ölçeklenebilirlik sağlayarak sunucu ortamlarında çalışacak şekilde tasarlanmıştır.

### Dönüştürme sırasında sunumlar için herhangi bir boyut sınırlaması var mı?

Aspose.Slides temelde her boyutta sunumu işleyebilir. Ancak çok büyük dosyalarla çalışırken ekstra sistem kaynaklarına ihtiyaç duyulabilir ve performansı artırmak için sunumun optimize edilmesi önerilir.