---
title: Python ile Sunumlarda Ses Yönetimi
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/python-java/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- sesi çıkar
- Python
- Aspose.Slides
description: "Aspose.Slides için Python üzerinden Java’da ses çerçeveleri oluşturun ve yönetin—gömme, kırpma, döngü ve PPT, PPTX ve ODP sunumları boyunca oynatmayı yapılandırma için kod örnekleri."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde ses çerçeveleriyle nasıl çalışılacağını açıklar. Gömülü sesi slaytlara ekleme, ses çerçevesi önizleme resmini özelleştirme, ses seviyesini, döngüyü, gizlemeyi, kırpmayı ve solma sürelerini ayarlama gibi oynatma seçeneklerini yapılandırma ve slayt gösterisi geçişlerinde kullanılan sesi çıkarma konularını gösterir.

## **Ses Çerçeveleri Oluşturma**

Aspose.Slides for Python via Java, ses dosyalarını slaytlara eklemenizi sağlar. Ses dosyaları slaytlara ses çerçeveleri olarak gömülür.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın referansını indeksine göre alın.
3. Slayta gömmek istediğiniz ses dosyasını okuyun.
4. Gömülü ses çerçevesini (içinde ses dosyası bulunduran) slayta ekleyin.
5. [AudioFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/) nesnesi tarafından sunulan [setPlayMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setPlayMode) ve [setVolume](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setVolume) metodlarını ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Bu Python kodu, bir slayta gömülü ses çerçevesi eklemenizi gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Bir ses dosyasını sunuma eklediğinizde, ses standart bir varsayılan görsel ile bir çerçeve olarak görünür (aşağıdaki bölümdeki görsele bakın). Ses çerçevesinin önizleme görselini (tercih ettiğiniz resmi) değiştirebilirsiniz.

Bu Python kodu, bir ses çerçevesinin küçük resmini veya önizleme görselini nasıl değiştireceğinizi gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for Python via Java, bir sesin oynatımını veya özelliklerini kontrol eden seçenekleri değiştirmenizi sağlar. Örneğin, ses seviyesini ayarlayabilir, sesi döngüde çalacak şekilde ayarlayabilir veya ses simgesini gizleyebilirsiniz.

Microsoft PowerPoint’teki **Audio Options** bölmesi:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** bölmesi, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/) özellikleriyle eşleşir:

- **Start** açılır listesi, [setPlayMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setPlayMode) metoduna karşılık gelir
- **Volume** , [setVolume](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setVolume) metoduna karşılık gelir
- **Play Across Slides** , [setPlayAcrossSlides](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) metoduna karşılık gelir
- **Loop until Stopped** , [setPlayLoopMode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setPlayLoopMode) metoduna karşılık gelir
- **Hide During Show** , [setHideAtShowing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setHideAtShowing) metoduna karşılık gelir
- **Rewind after Playing** , [setRewindAudio](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setRewindAudio) metoduna karşılık gelir

PowerPoint **Editing** seçenekleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/) özellikleriyle eşleşir:

- **Fade In** , [setFadeInDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setFadeInDuration) metoduna karşılık gelir 
- **Fade Out** , [setFadeOutDuration](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setFadeOutDuration) metoduna karşılık gelir 
- **Trim Audio Start Time** , [setTrimFromStart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setTrimFromStart) metoduna karşılık gelir 
- **Trim Audio End Time** değeri, ses süresinden [setTrimFromEnd](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setTrimFromEnd) metodunun değeri çıkarılarak elde edilir

PowerPoint’teki ses kontrol panelindeki **Volume control**, [setVolumeValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setVolumeValue) metoduna karşılık gelir. Ses seviyesini yüzde olarak değiştirmenizi sağlar.

Ses Oynatma seçeneklerini nasıl değiştirirsiniz:

1. [Сreate](#create-audio-frames) ya da Audio Frame’i alın.
2. Ayarlamak istediğiniz Audio Frame özellikleri için yeni değerleri belirleyin.
3. Değiştirilmiş PowerPoint dosyasını kaydedin.

Bu Python kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # Tıklama üzerine düşük sesle, slaytlar boyunca, döngü olmadan oynat.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Slayt gösterimi sırasında çerçeveyi gizle ve çaldıktan sonra geri sar.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Bu Python örneği, gömülü sesli yeni bir ses çerçevesi eklemeyi, kırpmayı ve solma sürelerini ayarlamayı gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Başlangıçtan 1,5 saniye ve sondan 2 saniye kırp.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Fade-in süresini 200 ms ve fade-out süresini 500 ms olarak ayarla.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki kod örneği, gömülü sese sahip bir ses çerçevesini alıp ses seviyesini %85’e ayarlamayı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, ses çerçevesine kapalı altyazılar eklemenizi [getCaptionTracks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#getCaptionTracks) metodu aracılığıyla sağlar. Bu metod, WebVTT altyazı izleri eklemenize, mevcut izler arasında dolaşmanıza ve gerektiğinde kaldırmanıza olanak tanıyan bir [CaptionsCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/) döndürür.

**Ses Altyazılarını Ekleme**

Bir ses çerçevesine bir veya daha fazla altyazı izi eklemek için [getCaptionTracks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#getCaptionTracks) metodunu kullanın. Aşağıdaki örnekte, bir ses dosyası slayta eklenir ve ardından yeni bir altyazı izi bir `.vtt` dosyasından yüklenir.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # WebVTT dosyasından yeni bir altyazı izi ekle.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Ses Altyazılarını Çıkarma**

Bir ses çerçevesiyle ilişkili altyazı izlerini dolaşabilir ve bunları `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi, ikili verisini ve benzersiz tanımlayıcısını dışa aktarırken kullanabileceğiniz şekilde sunar.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Altyazı izini .vtt dosyası olarak kaydet.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazı kaldırmak için [CaptionsCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/) tarafından sağlanan metodları kullanın; örneğin [clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/#removeAt). Aşağıdaki örnek, bir ses çerçevesindeki tüm altyazı izlerini kaldırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Ses Çıkarma**

Aspose.Slides for Python via Java, slayt gösterisi geçişlerinde kullanılan sesi çıkarmanıza izin verir. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun ve sesi içeren sunumu yükleyin.
2. İlgili slaytın referansını indeksine göre alın.
3. Slayt için [slideshow transitions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseslide/#getSlideShowTransition) erişin.
4. Sesi bayt veri olarak çıkarın.

Bu Python kodu, bir slaytta kullanılan sesi nasıl çıkaracağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **SSS**

**Aynı ses varlığını birden fazla slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Sesi bir kez sunumun ortak [audio collection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getAudios)’ına ekleyin ve mevcut varlığa referans veren ek ses çerçeveleri oluşturun. Bu, medya verisinin çoğaltılmasını önler ve sunum boyutunu kontrol altında tutar.

**Mevcut bir ses çerçevesindeki sesi şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link path](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setLinkPathLong)’i yeni dosyaya gösterecek şekilde güncelleyin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/python-java/aspose.slides/audioframe/#setEmbeddedAudio) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getAudios) içindeki başka bir nesneyle değiştirin. Çerçevenin biçimlendirmesi ve çoğu oynatma ayarı korunur.

**Kırpma, sunumda depolanan temel ses verisini değiştirir mi?**

Hayır. Kırpma yalnızca oynatma sınırlarını ayarlar. Orijinal ses baytları dokunulmamış olarak kalır ve gömülü ses ya da sunumun ses koleksiyonu aracılığıyla erişilebilir.