---
title: Presentasyonlarda JavaScript Kullanarak Ses Yönetimi
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/nodejs-java/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- sesi çıkar
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te ses çerçevelerini oluşturun ve yönetin—PPT, PPTX ve ODP sunumlarında gömme, kırpma, döngü ve oynatma ayarlarını yapılandırmaya yönelik örnekler."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde ses çerçeveleriyle nasıl çalışılacağını açıklar. Kaydırımlara gömülü ses ekleme, ses çerçevesi küçük resmini özelleştirme, ses seviyesi, döngü, gizleme, kırpma ve geçiş süreleri gibi oynatma seçeneklerini yapılandırma ve slayt gösterisi geçişlerinde kullanılan sesleri çıkarma yöntemlerini gösterir.

## **Ses Çerçeveleri Oluşturma**

Aspose.Slides for Node.js via Java, ses dosyalarını slaytlara eklemenizi sağlar. Ses dosyaları slaytlara ses çerçeveleri olarak gömülür.

1. Sunum sınıfının bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) örneğini oluşturun.
2. Slaytın referansını dizini aracılığıyla alın.
3. Slayta gömmek istediğiniz ses dosyası akışını yükleyin.
4. Gömülü ses çerçevesini (ses dosyasını içeren) slayta ekleyin.
5. [PlayMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AudioPlayModePreset) ve `Volume`'u [AudioFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/AudioFrame) nesnesi tarafından sunulan şekilde ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Bu JavaScript kodu, bir kaydırıma gömülü ses çerçevesi eklemenin nasıl yapılacağını gösterir:

```javascript
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler
const pres = new aspose.slides.Presentation();
try {
    // İlk slaytı alır
    const sld = pres.getSlides().get_Item(0);
    // wav ses dosyasını akışa yükler
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Ses Çerçevesini ekler
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Sesin Oynatma Modunu ve Ses Seviyesini ayarlar
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // PowerPoint dosyasını diske yazar
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Bir sunuma ses dosyası eklediğinizde, ses standart bir varsayılan resimle çerçeve olarak görünür (aşağıdaki bölüme bakın). Ses çerçevesinin önizleme resmini (istediğiniz resmi ayarlayarak) değiştirebilirsiniz.

Bu JavaScript kodu, bir ses çerçevesinin küçük resmi veya önizleme görüntüsünü nasıl değiştireceğinizi gösterir:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Belirtilen konum ve boyutla slayta bir ses çerçevesi ekler.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Sunum kaynaklarına bir resim ekler.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ses çerçevesi için resmi ayarlar.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Değiştirilmiş sunumu diske kaydeder
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for Node.js via Java, bir sesin oynatma davranışını veya özelliklerini kontrol eden seçenekleri değiştirmenize olanak tanır. Örneğin, ses seviyesini ayarlayabilir, sesi döngü halinde çalacak şekilde ayarlayabilir veya ses simgesini bile gizleyebilirsiniz.

Microsoft PowerPoint'teki **Audio Options** bölmesi:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** bölmesi, Aspose.Slides [AudioFrame] özelliklerine karşılık gelir:
- **Start** açılır listesi, [AudioFrame.setPlayMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setPlayMode) metoduna karşılık gelir
- **Volume** [AudioFrame.setVolume](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setVolume) metoduna karşılık gelir
- **Play Across Slides** [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) metoduna karşılık gelir
- **Loop until Stopped** [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) metoduna karşılık gelir
- **Hide During Show** [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) metoduna karşılık gelir
- **Rewind after Playing** [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setRewindAudio) metoduna karşılık gelir

PowerPoint **Editing** seçenekleri, Aspose.Slides [AudioFrame] özelliklerine karşılık gelir:
- **Fade In** [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) metoduna karşılık gelir 
- **Fade Out** [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) metoduna karşılık gelir 
- **Trim Audio Start Time** [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) metoduna karşılık gelir 
- **Trim Audio End Time** değeri, ses süresinden [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) metodunun değeri çıkarılarak elde edilir

PowerPoint **Volume control** ses kontrol panelindeki ses seviyesi, [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#setVolumeValue) metoduna karşılık gelir. Ses seviyesini yüzde olarak değiştirmenizi sağlar.

Ses Oynatma seçeneklerini nasıl değiştireceğiniz aşağıda gösterilmiştir:
1. [Create](#create-audio-frame) veya ses çerçevesini alın.
2. Ayarlamak istediğiniz Audio Frame özellikleri için yeni değerler atayın.
3. Değiştirilmiş PowerPoint dosyasını kaydedin.

Bu JavaScript kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame şekilini alır
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Oynatma modunu tıklayınca çalacak şekilde ayarlar
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Ses seviyesini Düşük olarak ayarlar
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Sesin slaytlar arasında çalmasını ayarlar
    audioFrame.setPlayAcrossSlides(true);
    // Ses için döngüyü devre dışı bırakır
    audioFrame.setPlayLoopMode(false);
    // Ses çerçevesini slayt gösterisi sırasında gizler
    audioFrame.setHideAtShowing(true);
    // Sesin çaldıktan sonra başa sarılmasını ayarlar
    audioFrame.setRewindAudio(true);
    // PowerPoint dosyasını diske kaydeder
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Bu JavaScript örneği, gömülü ses içeren yeni bir ses çerçevesi eklemeyi, kırpmayı ve geçiş sürelerini ayarlamayı gösterir:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Kırpma başlangıç ofsetini 1.5 saniyeye ayarlar
    audioFrame.setTrimFromStart(1500);
    // Kırpma bitiş ofsetini 2 saniyeye ayarlar
    audioFrame.setTrimFromEnd(2000);

    // Fade-in süresini 200 ms olarak ayarlar
    audioFrame.setFadeInDuration(200);
    // Fade-out süresini 500 ms olarak ayarlar
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Aşağıdaki kod örneği, gömülü ses içeren bir ses çerçevesini almayı ve ses seviyesini %85 olarak ayarlamayı gösterir:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Bir ses çerçevesi şekli alır
    const audioFrame = slide.getShapes().get_Item(0);

    // Ses seviyesini %85 olarak ayarlar
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, bir ses çerçevesine kapalı altyazı eklemenizi [getCaptionTracks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) metodu aracılığıyla sağlar. Bu metod, WebVTT altyazı izlerini eklemenize, mevcut izler arasında dolaşmanıza ve gerektiğinde kaldırmanıza olanak tanıyan bir [CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) döndürür.

**Ses Altyazılarını Ekleme**

[getCaptionTracks](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) metodunu kullanarak bir ses çerçevesine bir veya daha fazla altyazı izi ekleyin. Aşağıdaki örnekte, bir ses dosyası slayta eklenir ve ardından yeni bir altyazı izi `.vtt` dosyasından yüklenir.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT dosyasından yeni bir altyazı izi ekle.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ses Altyazılarını Çıkarma**

Bir ses çerçevesine ilişkilendirilmiş altyazı izleri arasında dolaşabilir ve bunları `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi ikili verisini ve benzersiz kimliğini ortaya çıkarır; bu, altyazıları dışa aktarırken kullanılabilir.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Caption izini .vtt dosyası olarak kaydet.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazıları kaldırmak için [CaptionsCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/) tarafından sağlanan [clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/captionscollection/#removeAt) gibi metodları kullanın. Aşağıdaki örnek, bir ses çerçevesindeki tüm altyazı izlerini kaldırır.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // tür: aspose.slides.AudioFrame

    // Ses çerçevesinden tüm altyazı izlerini kaldır.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ses Çıkarma**

Aspose.Slides for Node.js via Java, slayt gösterisi geçişlerinde kullanılan sesi çıkarmanıza olanak tanır. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. Ses içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfı örneği oluşturun ve sunumu yükleyin.
2. İlgili slaytın referansını dizini aracılığıyla alın.
3. Slayt için [slideshow transitions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) erişin.
4. Sesi bayt verisi olarak çıkarın.

Bu JavaScript kodu, bir slaytta kullanılan sesi nasıl çıkaracağınızı gösterir:

```javascript
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // İstenen slayta erişir
    const slide = pres.getSlides().get_Item(0);
    // Slayt için slayt gösterisi geçiş efekti alır
    const transition = slide.getSlideShowTransition();
    // Sesi bayt dizisi olarak çıkarır
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Aynı ses varlığını birden fazla slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Sesi, sunumun paylaşılan [audio collection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getaudios/) koleksiyonuna bir kez ekleyin ve mevcut varlığı referans alan ek ses çerçeveleri oluşturun. Bu, medya verilerinin çoğaltılmasını önler ve sunum boyutunu kontrol altında tutar.

**Mevcut bir ses çerçevesindeki sesi şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link path](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) değerini yeni dosyaya gösterecek şekilde güncelleyin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/getaudios/) koleksiyonundaki başka bir sesle değiştirin. Çerçevenin formatı ve çoğu oynatma ayarı aynı kalır.

**Kırpma, sunumda saklanan temel ses verisini değiştirir mi?**

Hayır. Kırpma yalnızca oynatma sınırlarını ayarlar. Orijinal ses baytları dokunulmamış olarak kalır ve gömülü ses ya da sunumun ses koleksiyonu aracılığıyla erişilebilir.