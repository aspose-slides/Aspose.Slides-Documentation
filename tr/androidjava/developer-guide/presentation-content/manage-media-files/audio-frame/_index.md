---
title: Android'de Sunumlarda Ses Yönetimi
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/androidjava/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkar
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'de ses çerçevelerini oluşturun ve kontrol edin—gömme, kırpma, döngü ve PPT, PPTX ve ODP sunumlarında oynatmayı yapılandırma için Java örnekleri."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'de ses çerçeveleriyle nasıl çalışılacağını açıklar. Slaytlara gömülü ses ekleme, ses çerçevesi küçük resmini özelleştirme, ses düzeyi, döngü, gizleme, kırpma ve geçiş süreleri gibi oynatma seçeneklerini yapılandırma ve slayt gösterisi geçişlerinde kullanılan sesleri çıkarma konularını gösterir.

## **Ses Çerçeveleri Oluşturma**
Aspose.Slides for Android via Java, slaytlara ses dosyaları eklemenizi sağlar. Ses dosyaları, slaytlara ses çerçeveleri olarak gömülür.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Slaydın referansını dizini aracılığıyla alın.
3. Slayta gömmek istediğiniz ses dosyası akışını yükleyin.
4. Gömülü ses çerçevesini (ses dosyasını içeren) slayta ekleyin.
5. [PlayMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioPlayModePreset) ve [IAudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IAudioFrame) nesnesi tarafından sunulan `Volume` değerini ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Bu Java kodu, bir slayta gömülü ses çerçevesi nasıl eklenir gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler
Presentation pres = new Presentation();
try {
    // İlk slaytı alır
    ISlide sld = pres.getSlides().get_Item(0);

    // wav ses dosyasını akışa yükler
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Ses Çerçevesini ekler
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Sesin Oynatma Modu ve Ses Düzeyini ayarlar
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

Bir sunuma ses dosyası eklediğinizde, ses standart bir varsayılan resimle çerçeve olarak görünür (aşağıdaki bölümdeki resme bakın). Ses çerçevesinin önizleme resmini (isteğinize göre bir resmi ayarlayarak) değiştirebilirsiniz.

Bu Java kodu, bir ses çerçevesinin küçük resmini veya önizleme resmini nasıl değiştireceğinizi gösterir:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Slayta belirtilen konum ve boyutta bir ses çerçevesi ekler.
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

    //Değiştirilmiş sunumu diske kaydeder
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for Android via Java, sesin oynatımını veya özelliklerini kontrol eden seçenekleri değiştirmenizi sağlar. Örneğin, sesin ses düzeyini ayarlayabilir, sesi döngüde çalacak şekilde ayarlayabilir veya ses simgesini gizleyebilirsiniz.

Microsoft PowerPoint'teki **Ses Seçenekleri** bölmesi:

![example1_image](audio_frame_0.png)

PowerPoint **Ses Seçenekleri**, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioFrame) özelliklerine karşılık gelir:

- **Start** açılır listesi, [AudioFrame.PlayMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) özelliğiyle eşleşir
- **Volume** [AudioFrame.Volume](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioFrame#getVolume--) özelliğiyle eşleşir
- **Play Across Slides** [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) özelliğiyle eşleşir
- **Loop until Stopped** [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) özelliğiyle eşleşir
- **Hide During Show** [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) özelliğiyle eşleşir
- **Rewind after Playing** [AudioFrame.RewindAudio](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) özelliğiyle eşleşir

PowerPoint **Düzenleme** seçenekleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/audioframe/) özelliklerine karşılık gelir:

- **Fade In** [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) özelliğiyle eşleşir
- **Fade Out** [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) özelliğiyle eşleşir
- **Trim Audio Start Time** [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) özelliğiyle eşleşir
- **Trim Audio End Time** değeri, ses süresinden [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) özelliğinin değeri çıkarılarak elde edilir

PowerPoint'teki ses denetim panelindeki **Volume kontrol**ü, [AudioFrame.VolumeValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) özelliğine karşılık gelir. Ses düzeyini yüzde olarak değiştirmenizi sağlar.

Ses Oynatma seçeneklerini nasıl değiştireceğiniz aşağıdadır:

1. [Oluştur](#create-audio-frame) veya Ses Çerçevesini alın.
2. Ayarlamak istediğiniz Ses Çerçevesi özellikleri için yeni değerler belirleyin.
3. Değiştirilmiş PowerPoint dosyasını kaydedin.

Bu Java kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame şekilini alır
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Oynatma modunu tıklamayla çalmaya ayarlar
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Ses düzeyini Düşük olarak ayarlar
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Sesin slaytlar arasında çalmasını ayarlar
    audioFrame.setPlayAcrossSlides(true);

    // Ses için döngüyü devre dışı bırakır
    audioFrame.setPlayLoopMode(false);

    // Slayt gösterisi sırasında AudioFrame'i gizler
    audioFrame.setHideAtShowing(true);

    // Oynatmadan sonra sesi başa sarar
    audioFrame.setRewindAudio(true);

    // PowerPoint dosyasını diske kaydeder
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu Java örneği, gömülü sesli yeni bir ses çerçevesi eklemeyi, kırpmayı ve geçiş sürelerini ayarlamayı gösterir:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Kırpma başlangıç ofsetini 1.5 saniyeye ayarlar
    audioFrame.setTrimFromStart(1500f);
    // Kırpma bitiş ofsetini 2 saniyeye ayarlar
    audioFrame.setTrimFromEnd(2000f);

    // Fade-in süresini 200 ms olarak ayarlar
    audioFrame.setFadeInDuration(200f);
    // Fade-out süresini 500 ms olarak ayarlar
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Aşağıdaki kod örneği, gömülü sesli bir ses çerçevesini nasıl alacağınızı ve ses düzeyini %85'e nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Bir ses çerçevesi şekli alır
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Ses hacmini %85 olarak ayarlar
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, [getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) yöntemi aracılığıyla bir ses çerçevesine kapalı altyazı eklemenizi sağlar. Bu yöntem, WebVTT altyazı izleri eklemenize, mevcut izler arasında dolaşmanıza ve gerektiğinde kaldırmanıza olanak tanıyan bir [ICaptionsCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/) döndürür.

**Ses Altyazılarını Ekle**

[getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) yöntemini kullanarak bir ses çerçevesine bir veya daha fazla altyazı izi ekleyin. Aşağıdaki örnekte, bir ses dosyası slayta eklenir ve ardından yeni bir altyazı izi `.vtt` dosyasından yüklenir.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT dosyasından yeni bir altyazı izi ekle.
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ses Altyazılarını Çıkarma**

Bir ses çerçevesiyle ilişkilendirilmiş altyazı izleri arasında dolaşabilir ve bunları `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi, dışa aktarırken kullanılabilecek ikili veri ve benzersiz kimliğini sunar.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Altyazı izini .vtt dosyası olarak kaydet.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazıları kaldırmak için [ICaptionsCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/) tarafından sağlanan yöntemleri kullanın; örneğin [clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), veya [removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-). Aşağıdaki örnek, bir ses çerçevesindeki tüm altyazı izlerini kaldırır.

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

Aspose.Slides for Android via Java, slayt gösterisi geçişlerinde kullanılan sesleri çıkarmanıza olanak tanır. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. Ses içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. İlgili slaydın referansını dizini aracılığıyla alın.
3. Slayt için [slideshow transitions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) öğesine erişin.
4. Sesi bayt verisi olarak çıkarın.

Bu Java kodu, bir slaytta kullanılan sesin nasıl çıkarılacağını gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // İstenen slaytı erişir
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Slayt için slayt gösterisi geçiş efektlerini alır
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Ses verisini bayt dizisinde çıkarır
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Aynı ses varlığını birden fazla slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Ses dosyasını bir kez sunumun ortak [audio collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getAudios--)'ına ekleyin ve bu mevcut varlığı referans alan ek ses çerçeveleri oluşturun. Bu, medya verisinin çoğaltılmasını önler ve sunum boyutunun kontrol altında kalmasını sağlar.

**Mevcut bir ses çerçevesindeki sesi şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, yeni dosyaya işaret edecek şekilde [link path](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-)i güncelleyin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/#getAudios--)'undaki başka bir sesle değiştirin. Çerçevenin biçimlendirmesi ve çoğu oynatma ayarı aynı kalır.

**Kırpma, sunumda depolanan temel ses verisini değiştirir mi?**

Hayır. Kırpma yalnızca oynatma sınırlarını ayarlar. Orijinal ses baytları dokunulmadan kalır ve gömülü ses ya da sunumun ses koleksiyonu aracılığıyla erişilebilir.