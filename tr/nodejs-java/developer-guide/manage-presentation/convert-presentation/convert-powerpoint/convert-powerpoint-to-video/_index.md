---
title: JavaScript'te PowerPoint Sunumlarını Videoya Dönüştürme
linktitle: PowerPoint'ten Video
type: docs
weight: 130
url: /tr/nodejs-java/convert-powerpoint-to-video/
keywords:
- PowerPoint'i dönüştür
- sunumu dönüştür
- PPT'yi dönüştür
- PPTX'i dönüştür
- PowerPoint'ten video
- sunumdan video
- PPT'den video
- PPTX'ten video
- PowerPoint'ten MP4
- sunumdan MP4
- PPT'den MP4
- PPTX'ten MP4
- PPT'yi MP4 olarak kaydet
- PPTX'i MP4 olarak kaydet
- PPT'yi MP4'e aktar
- PPTX'i MP4'e aktar
- video dönüşümü
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript'te PowerPoint sunumlarını videoya dönüştürmeyi öğrenin. İş akışınızı hızlandırmak için örnek kodları ve otomasyon tekniklerini keşfedin."
---
## **Giriş**

PowerPoint sunumunuzu video formatına dönüştürerek elde edersiniz 

* **Erişilebilirlik artışı:** Sunum açma uygulamalarına kıyasla, tüm cihazlar (platform fark etmeksizin) varsayılan olarak video oynatıcılarla donatılmıştır, bu yüzden kullanıcılar videoları açmayı veya oynatmayı daha kolay bulur.
* **Daha geniş erişim:** Videolar sayesinde büyük bir izleyici kitlesine ulaşabilir ve onları bir sunumda sıkıcı olabilecek bilgilerle hedefleyebilirsiniz. Çoğu anket ve istatistik, insanların videoları diğer içerik biçimlerinden daha fazla izlediğini ve tükettiğini, ve genellikle bu tür içerikleri tercih ettiğini gösterir.

{{% alert color="primary" %}} 

Burada açıklanan sürecin canlı ve etkili bir uygulaması olduğundan, [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/tr/conversion/ppt-to-word) adresine göz atmak isteyebilirsiniz.

{{% /alert %}} 

## **Aspose.Slides'da PowerPoint'ten Videoya Dönüştürme**

Aspose.Slides sunumdan videoya dönüşümü destekler.

* **Aspose.Slides** kullanarak, belirli bir FPS (saniyedeki kare) değerine karşılık gelen bir dizi kare (sunum slaytlarından) oluşturun
* **ffmpeg** gibi bir üçüncü taraf aracını ([java için](https://github.com/bramp/ffmpeg-cli-wrapper)) kareler üzerine bir video oluşturmak için kullanın. 

### **PowerPoint'ten Videoya Dönüştürme**

1. ffmpeg'i [buradan](https://ffmpeg.org/download.html) indirin.

2. PowerPoint'ten video JavaScript kodunu çalıştırın.

Bu JavaScript kodu, bir şekil ve iki animasyon efekti içeren bir sunumu videoya nasıl dönüştüreceğinizi gösterir:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Bir gülümseme şekli ekler ve ardından animasyon uygular
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg ikili dosyalarının klasörünü yapılandır. Bu sayfaya bak: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Video Efektleri**

Slaytlardaki nesnelere animasyonlar uygulayabilir ve slaytlar arasında geçişler kullanabilirsiniz.

{{% alert color="primary" %}} 

Bu makalelere göz atmak isteyebilirsiniz: [PowerPoint Animation](https://docs.aspose.com/slides/tr/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/tr/nodejs-java/shape-animation/), ve [Shape Effect](https://docs.aspose.com/slides/tr/nodejs-java/shape-effect/).

{{% /alert %}} 

Animasyonlar ve geçişler slayt gösterilerini daha çekici ve ilginç hâle getirir—ve videolar için de aynı şeyi yapar. Önceki sunumun koduna bir slayt ve geçiş daha ekleyelim:

```javascript
// Bir gülümseme şekli ekler ve animasyon uygular
// ...
// Yeni bir slayt ekler ve animasyonlu geçiş ekler
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides ayrıca metin animasyonunu da destekler. Bu yüzden nesneler üzerindeki paragrafları birbiri ardına (gecikme bir saniye olarak ayarlanmış) görünecek şekilde canlandırıyoruz:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Metin ve animasyonları ekler
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg ikili dosyaları klasörünü yapılandır. Bu sayfaya bak: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Video Dönüştürme Sınıfları**

PowerPoint'ten videoya dönüşüm görevlerini gerçekleştirmenize olanak sağlamak için Aspose.Slides, [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationanimationsgenerator/) ve [PresentationPlayer](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationplayer/) sınıflarını sunar.

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationanimationsgenerator/) video için (sonradan oluşturulacak) kare boyutunu yapıcı (constructor) aracılığıyla ayarlamanızı sağlar. Sunumun bir örneğini geçirirseniz, `Presentation.getSlideSize` kullanılır ve [PresentationPlayer](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationplayer/) tarafından kullanılan animasyonları üretir.

Animasyonlar üretildiğinde, her sonraki animasyon için bir `NewAnimation` olayı oluşturulur; bu olayın sunum animasyon oynatıcı parametresi vardır. İkincisi, ayrı bir animasyon için oynatıcıyı temsil eden bir sınıftır.

Sunum animasyon oynatıcıyla çalışmak için `getDuration` (animasyonun tam süresi) yöntemi ve `setTimePosition` yöntemi kullanılır. Her animasyon konumu *0 ile süresi* aralığında ayarlanır ve ardından `getFrame` yöntemi o anki animasyon durumuna karşılık gelen bir BufferedImage döndürür:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Bir gülümseme şekli ekler ve animasyonu uygular
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// ilk animasyon durumu
            try {
                // ilk animasyon durumu bitmap'i
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// final state of the animation
            try {
                // animasyonun son karesi
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Bir sunumdaki tüm animasyonların aynı anda çalmasını sağlamak için [PresentationPlayer](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationplayer/) sınıfı kullanılır. Bu sınıf, yapıcısında bir [PresentationAnimationsGenerator](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentationanimationsgenerator/) örneği ve efektler için FPS alır ve ardından tüm animasyonları çalmak için `FrameTick` olayını tetikler:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Daha sonra oluşturulan kareler birleştirilerek bir video üretilebilir. [Convert PowerPoint to Video](https://docs.aspose.com/slides/tr/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) bölümüne bakın.

## **Desteklenen Animasyonlar ve Efektler**

**Giriş**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Görünme** | ![not supported](x.png) | ![supported](v.png) |
| **Solma** | ![supported](v.png) | ![supported](v.png) |
| **Uçuş** | ![supported](v.png) | ![supported](v.png) |
| **Yüzme** | ![supported](v.png) | ![supported](v.png) |
| **Bölme** | ![supported](v.png) | ![supported](v.png) |
| **Silme** | ![supported](v.png) | ![supported](v.png) |
| **Şekil** | ![supported](v.png) | ![supported](v.png) |
| **Döner** | ![supported](v.png) | ![supported](v.png) |
| **Rastgele Çubuklar** | ![supported](v.png) | ![supported](v.png) |
| **Büyü & Dönüş** | ![not supported](x.png) | ![supported](v.png) |
| **Yakınlaştırma** | ![supported](v.png) | ![supported](v.png) |
| **Dönme** | ![supported](v.png) | ![supported](v.png) |
| **Sıçrama** | ![supported](v.png) | ![supported](v.png) |

**Vurgu**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Darbe** | ![not supported](x.png) | ![supported](v.png) |
| **Renk Darbesi** | ![not supported](x.png) | ![supported](v.png) |
| **Dengesiz** | ![supported](v.png) | ![supported](v.png) |
| **Dönme** | ![supported](v.png) | ![supported](v.png) |
| **Büyü/Küçül** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturasyon** | ![not supported](x.png) | ![supported](v.png) |
| **Koyulaştır** | ![not supported](x.png) | ![supported](v.png) |
| **Aydınlat** | ![not supported](x.png) | ![supported](v.png) |
| **Şeffaflık** | ![not supported](x.png) | ![supported](v.png) |
| **Nesne Rengi** | ![not supported](x.png) | ![supported](v.png) |
| **Tamamlayıcı Renk** | ![not supported](x.png) | ![supported](v.png) |
| **Çizgi Rengi** | ![not supported](x.png) | ![supported](v.png) |
| **Doldurma Rengi** | ![not supported](x.png) | ![supported](v.png) |

**Çıkış**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Görünmez Olma** | ![not supported](x.png) | ![supported](v.png) |
| **Solma** | ![supported](v.png) | ![supported](v.png) |
| **Uçuş Çıkışı** | ![supported](v.png) | ![supported](v.png) |
| **Yüzme Çıkışı** | ![supported](v.png) | ![supported](v.png) |
| **Bölme** | ![supported](v.png) | ![supported](v.png) |
| **Silme** | ![supported](v.png) | ![supported](v.png) |
| **Şekil** | ![supported](v.png) | ![supported](v.png) |
| **Rastgele Çubuklar** | ![supported](v.png) | ![supported](v.png) |
| **Küçül & Dönüş** | ![not supported](x.png) | ![supported](v.png) |
| **Yakınlaştırma** | ![supported](v.png) | ![supported](v.png) |
| **Dönme** | ![supported](v.png) | ![supported](v.png) |
| **Sıçrama** | ![supported](v.png) | ![supported](v.png) |

**Hareket Yolları**:

| Animasyon Türü | Aspose.Slides | PowerPoint |
|---|---|---|
| **Çizgiler** | ![supported](v.png) | ![supported](v.png) |
| **Yaylar** | ![supported](v.png) | ![supported](v.png) |
| **Dönüşler** | ![supported](v.png) | ![supported](v.png) |
| **Şekiller** | ![supported](v.png) | ![supported](v.png) |
| **Döngüler** | ![supported](v.png) | ![supported](v.png) |
| **Özel Yol** | ![supported](v.png) | ![supported](v.png) |

## **SSS**

**Şifre korumalı sunumları dönüştürmek mümkün mü?**

Evet, Aspose.Slides şifre korumalı sunumlarla çalışmaya izin verir. Bu dosyaları işlerken, kütüphanenin sunumun içeriğine erişebilmesi için doğru şifreyi sağlamanız gerekir.

**Aspose.Slides bulut çözümlerinde kullanılmayı destekliyor mu?**

Evet, Aspose.Slides bulut uygulamaları ve hizmetleriyle bütünleştirilebilir. Kütüphane, sunucu ortamlarında çalışacak şekilde tasarlanmıştır ve dosyaların toplu işlenmesi için yüksek performans ve ölçeklenebilirlik sağlar.

**Dönüştürme sırasında sunumların boyutunda herhangi bir sınırlama var mı?**

Aspose.Slides, neredeyse her boyuttaki sunumu işleyebilir. Ancak, çok büyük dosyalarla çalışırken ek sistem kaynakları gerekebilir ve performansı artırmak için sunumu optimize etmeniz önerilebilir.