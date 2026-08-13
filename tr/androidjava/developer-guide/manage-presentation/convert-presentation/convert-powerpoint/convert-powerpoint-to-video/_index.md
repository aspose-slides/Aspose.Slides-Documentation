---
title: Android'de PowerPoint Sunumlarını Videoya Dönüştürme
linktitle: PowerPoint'ten Video'ya
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
- video dönüştürme
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Java'da PowerPoint sunumlarını videoya nasıl dönüştüreceğinizi öğrenin. İş akışınızı hızlandırmak için örnek kod ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint sunumunuzu video'ya dönüştürerek şunları elde edersiniz

* **Erişilebilirlik artışı:** Tüm cihazlar (platformdan bağımsız) varsayılan olarak video oynatıcılarla donatılmıştır; bu nedenle kullanıcılar video açmayı veya oynatmayı daha kolay bulur.
* **Daha geniş kitle:** Videolar sayesinde geniş bir izleyici kitlesine ulaşabilir ve onları bir sunumda sıkıcı olabilecek bilgilerle hedefleyebilirsiniz. Çoğu anket ve istatistik, insanların diğer içerik türlerine göre videoları daha çok izlediğini ve tükettiklerini, ayrıca genellikle bu tür içerikleri tercih ettiklerini göstermektedir.

## **Aspose.Slides’da PowerPoint'ten Video Dönüştürme**

Aspose.Slides, sunumdan video dönüşümünü destekler.

* **Aspose.Slides**'ı, belirli bir FPS'ye (saniyedeki kare sayısı) karşılık gelen bir dizi çerçeve (sunum slaytlarından) oluşturmak için kullanın
* **ffmpeg** gibi üçüncü taraf bir araç ([java için](https://github.com/bramp/ffmpeg-cli-wrapper)) kullanarak çerçevelerden bir video oluşturun. 

### **PowerPoint'i Video'ya Dönüştürme**

1. POM dosyanıza şunu ekleyin:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.

3. PowerPoint'ten video'ya Java kodunu çalıştırın.

Bu Java kodu, bir şekil ve iki animasyon efekti içeren bir sunumu video'ya nasıl dönüştüreceğinizi gösterir:
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

    // ffmpeg ikili dosyaları klasörünü yapılandır. Bu sayfayı inceleyin: https://github.com/bramp/ffmpeg-cli-wrapper
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

{{% alert color="info" %}} 

Görmek isteyebileceğiniz makaleler: [PowerPoint Animasyonu](https://docs.aspose.com/slides/tr/androidjava/powerpoint-animation/), [Şekil Animasyonu](https://docs.aspose.com/slides/tr/androidjava/shape-animation/), ve [Şekil Efekti](https://docs.aspose.com/slides/tr/androidjava/shape-effect/).

{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha çekici ve ilginç hâle getirir — videolar için de aynı şeyi yaparlar. Önceki sunum koduna bir slayt ve geçiş daha ekleyelim:
```java
import com.aspose.slides.*;
import java.awt.Color;

// Yukarıda oluşturulan animasyonlu gülümseme şekli içeren sunum.
Presentation presentation = new Presentation();
try {
    //    Yeni bir slayt ekler ve animasyonlu geçiş ekler

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides ayrıca metin animasyonunu da destekler. Bu yüzden nesneler üzerindeki paragrafları animasyonlu hale getiririz; bu paragraflar birbiri ardına (gecikme bir saniye olarak ayarlanmış) görünür:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    // ffmpeg ikili dosyaları klasörünü yapılandır. Bu sayfayı inceleyin: https://github.com/bramp/ffmpeg-cli-wrapper
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

PowerPoint'ten video dönüşüm görevlerini gerçekleştirmenize olanak sağlamak için Aspose.Slides, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationanimationsgenerator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationplayer/) sınıflarını sunar.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationanimationsgenerator/) sınıfı, video (daha sonra oluşturulacak) için çerçeve boyutunu kurucusu aracılığıyla ayarlamanıza olanak tanır. Sunum örneğini geçirirseniz, `Presentation.SlideSize` kullanılacak ve [PresentationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationplayer/) tarafından kullanılan animasyonları üretir.

Animasyonlar üretildiğinde, her ardışık animasyon için bir `NewAnimation` olayı üretilir; bu olayın [IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/) parametresi vardır. Bu sınıf, ayrı bir animasyon için oynatıcıyı temsil eder.

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/) ile çalışmak için, [Duration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (animasyonun tam süresi) özelliği ve [SetTimePosition](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) yöntemi kullanılır. Her animasyon konumu *0 ile süre* aralığında ayarlanır ve ardından `getFrame` yöntemi, o anda animasyon durumuna karşılık gelen bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) döndürür:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Gülümseme şekli ekler ve animasyon uygular
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
            // başlangıç animasyon durumu bitmap'i
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // animasyonun son durumu
            // animasyonun son karesi
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Animasyonları oluştur. Yukarıdaki geri çağırma her biri için çalışır.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Bütün animasyonların aynı anda oynatılması için [PresentationPlayer](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationplayer/) sınıfı kullanılır. Bu sınıf, bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentationanimationsgenerator/) örneği ve FPS'i alır, ardından tüm animasyonlar için `FrameTick` olayını çağırarak oynatır:
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

Ardından oluşturulan çerçeveler birleştirilerek video üretilir. Bkz. [Convert PowerPoint to Video](https://docs.aspose.com/slides/tr/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümü.

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
| **Shape** | ![destekleniyorum](v.png) | ![destekleniyor](v.png) |
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

## **SSS**

### Şifre korumalı sunumları dönüştürmek mümkün mü?

Evet, Aspose.Slides, [şifre korumalı sunumlarla](/slides/tr/androidjava/password-protected-presentation/) çalışmaya izin verir. Böyle dosyaları işlerken doğru şifreyi sağlamanız gerekir, böylece kütüphane sunumun içeriğine erişebilir.

### Aspose.Slides bulut çözümlerinde kullanımını destekliyor mu?

Evet, Aspose.Slides, bulut uygulamaları ve hizmetlerine entegre edilebilir. Kütüphane, sunucu ortamlarında çalışacak şekilde tasarlanmış olup, dosyaların toplu işlenmesi için yüksek performans ve ölçeklenebilirlik sağlar.

### Dönüştürme sırasında sunumların boyutlarıyla ilgili sınırlamalar var mı?

Aspose.Slides, neredeyse her boyuttaki sunumu işleyebilir. Ancak, çok büyük dosyalarla çalışırken ek sistem kaynakları gerekebilir ve performansı artırmak için sunumu optimize etmeniz önerilir.