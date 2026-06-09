---
title: Java Kullanarak Sunumlarda Ses Yönetimi
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/java/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkarma
- Java
- Aspose.Slides
description: "Aspose.Slides for Java içinde ses çerçevelerini oluşturun ve kontrol edin—PPT, PPTX ve ODP sunumları boyunca gömme, kırpma, döngü ve oynatma ayarlarını yapılandırmak için kod örnekleri."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde ses çerçeveleriyle nasıl çalışılacağını açıklar. Gömülü sesi slaytlara eklemenin, ses çerçevesi küçük resmini özelleştirmenin, ses seviyesini, döngüyü, gizlemeyi, kırpmayı ve geçiş sürelerini yapılandırmanın ve slayt gösterisi geçişlerinde kullanılan sesin çıkarılmasının nasıl yapılacağını gösterir.

## **Ses Çerçeveleri Oluşturma**

Aspose.Slides for Java, slaytlara ses dosyaları eklemenizi sağlar. Ses dosyaları slaytlara ses çerçeveleri olarak gömülür. 

1. Bir [Sunum](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını, indeksini kullanarak alın.
3. Slayda gömmek istediğiniz ses dosyası akışını yükleyin.
4. Gömülü ses çerçevesini (ses dosyasını içeren) slayta ekleyin.
5. [PlayMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/AudioPlayModePreset) ve [IAudioFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IAudioFrame) nesnesi tarafından sunulan `Volume` değerini ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Bu Java kodu, bir slayta gömülü ses çerçevesi eklemenin nasıl yapılacağını gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);

    // wav ses dosyasını akışa yükler
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Ses Çerçevesini ekler
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Sesin Oynatma Modunu ve Ses seviyesini ayarlar
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPoint dosyasını diske yazar
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Bir sunuma ses dosyası eklediğinizde, ses standart bir varsayılan resimle bir çerçeve olarak görünür (aşağıdaki bölümdeki resme bakın). Ses çerçevesinin ön izleme resmini (istediğiniz resmi ayarlayarak) değiştirirsiniz.

Bu Java kodu, bir ses çerçevesinin küçük resmini veya ön izleme resmini nasıl değiştireceğinizi gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Belirtilen konum ve boyutla slayta bir ses çerçevesi ekler.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Sunum kaynaklarına bir resim ekler.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ses çerçevesi için resmi ayarlar.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // Değiştirilmiş sunumu diske kaydeder
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for Java, bir sesin oynatılmasını veya özelliklerini kontrol eden seçenekleri değiştirmenize olanak tanır. Örneğin, sesin seviyesini ayarlayabilir, sesi döngü halinde çalacak şekilde yapılandırabilir ya da ses simgesini gizleyebilirsiniz.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Ses Seçenekleri**, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/AudioFrame) özelliklerine karşılık gelir:

- **Başlat** açılır listesi, [AudioFrame.setPlayMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setPlayMode-int-) metoduyla eşleşir
- **Ses** [AudioFrame.setVolume](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setVolume-int-) metodu ile eşleşir
- **Tüm Slaytlar Üzerinde Çal** [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-) metodu ile eşleşir
- **Durdurulana Kadar Döngü** [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-) metodu ile eşleşir
- **Sunum Sırasında Gizle** [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-) metodu ile eşleşir
- **Çaldıktan Sonra Geri Sar** [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-) metodu ile eşleşir

PowerPoint **Düzenleme** seçenekleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/AudioFrame) özelliklerine karşılık gelir:

- **Yumuşak Giriş** [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setFadeInDuration-float-) metodu ile eşleşir 
- **Yumuşak Çıkış** [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-) metodu ile eşleşir 
- **Ses Başlangıç Zamanını Kırp** [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setTrimFromStart-float-) metodu ile eşleşir 
- **Ses Bitiş Zamanını Kırp** değeri, ses süresinden [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-) metodunun değeri çıkarılarak elde edilir

PowerPoint ses kontrol panelindeki **Ses Kontrolü**, [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/audioframe/#setVolumeValue-float-) metoduna karşılık gelir. Ses seviyesini yüzde olarak değiştirmenizi sağlar.

Ses Oynatma seçeneklerini değiştirmenin yolu şudur:

1. [Oluştur](#create-audio-frame) veya Ses Çerçevesini alın.
2. Ayarlamak istediğiniz Ses Çerçevesi özellikleri için yeni değerler belirleyin.
3. Değiştirilmiş PowerPoint dosyasını kaydedin.

Bu Java kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame şekli alınır
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Oynatma modunu tıklamayla oynatacak şekilde ayarlar
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Ses seviyesini Düşük olarak ayarlar
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Sesin slaytlar arasında çalmasını ayarlar
    audioFrame.setPlayAcrossSlides(true);

    // Ses için döngüyü devre dışı bırakır
    audioFrame.setPlayLoopMode(false);

    // Ses Çerçevesini slayt gösterisi sırasında gizler
    audioFrame.setHideAtShowing(true);

    // Sesin çalındıktan sonra başa sarmasını ayarlar
    audioFrame.setRewindAudio(true);

    // PowerPoint dosyasını diske kaydeder
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu Java örneği, gömülü sesli yeni bir ses çerçevesi eklemeyi, kırpmayı ve yumuşak geçiş sürelerini ayarlamayı göstermektedir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Kırpma başlangıç ofsetini 1.5 saniyeye ayarlar
    audioFrame.setTrimFromStart(1500f);
    // Kırpma bitiş ofsetini 2 saniyeye ayarlar
    audioFrame.setTrimFromEnd(2000f);

    // Yumuşak giriş süresini 200 ms olarak ayarlar
    audioFrame.setFadeInDuration(200f);
    // Yumuşak çıkış süresini 500 ms olarak ayarlar
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Aşağıdaki kod örneği, gömülü sesli bir ses çerçevesini nasıl alacağınızı ve ses seviyesini %85 olarak nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Bir ses çerçevesi şekli alır
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Ses seviyesini %85 olarak ayarlar
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, bir ses çerçevesine kapalı altyazı eklemenizi [getCaptionTracks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) yöntemiyle sağlar. Bu yöntem, WebVTT altyazı izleri eklemenize, mevcut izler arasında dolaşmanıza ve gerektiğinde kaldırmanıza olanak tanıyan bir [ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) döndürür.

**Ses Altyazılarını Ekle**

[getCaptionTracks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) yöntemini kullanarak bir ses çerçevesine bir veya daha fazla altyazı izi ekleyin. Aşağıdaki örnekte, bir ses dosyası slayta eklenir ve ardından yeni bir altyazı izi `.vtt` dosyasından yüklenir.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT dosyasından yeni bir altyazı izi ekle.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ses Altyazılarını Çıkarma**

Bir ses çerçevesine bağlı altyazı izlerini dolaşabilir ve bunları `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi ikili verisini ve benzersiz tanımlayıcısını ortaya çıkarır; bu, altyazıları dışa aktarırken kullanılabilir.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Altyazı izini .vtt dosyası olarak kaydet.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazıları kaldırmak için [ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) tarafından sağlanan yöntemleri, örneğin [clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), veya [removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#removeAt-int-) kullanın. Aşağıdaki örnek, bir ses çerçevesindeki tüm altyazı izlerini kaldırır.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Ses çerçevesindeki tüm altyazı izlerini kaldır.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ses Çıkarma**

Aspose.Slides for Java, slayt gösterisi geçişlerinde kullanılan sesi çıkarmanıza olanak tanır. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. Ses içeren bir sunumu yüklemek için bir [Sunum](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
2. İlgili slaydın referansını indeksini kullanarak alın.
3. Slayt için [slideshow transitions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) öğelerine erişin.
4. Sesi bayt verisi olarak çıkarın.

Bu Java kodu, bir slaytta kullanılan sesin nasıl çıkarılacağını gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // İstenen slayta erişir
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Slayt için slayt gösterisi geçiş efektlerini alır
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Sesi bayt dizisi olarak çıkarır
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Aynı ses varlığını birden fazla slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Sesi, sunumun ortak [audio collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getAudios--)'ına bir kez ekleyin ve mevcut varlığı referans alan ek ses çerçeveleri oluşturun. Bu, medya verisinin çoğaltılmasını önler ve sunum boyutunun kontrol altında kalmasını sağlar.

**Varolan bir ses çerçevesindeki sesi şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link path](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) değerini yeni dosyaya işaret edecek şekilde güncelleyin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/#getAudios--)'ındaki başka bir sesle değiştirin. Çerçevenin biçimlendirmesi ve çoğu oynatma ayarı aynı kalır.

**Kırpma, sunumda depolanan temel ses verisini değiştirir mi?**

Hayır. Kırpma yalnızca oynatma sınırlarını ayarlar. Orijinal ses baytları dokunulmadan kalır ve gömülü ses ya da sunumun ses koleksiyonu aracılığıyla erişilebilir.