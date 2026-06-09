---
title: Python ile Sunumlarda Ses Yönetimi
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/python-net/audio-frame/
keywords:
- ses ekleme
- ses gömme
- ses çerçevesi
- ses dosyası
- ses özellikleri
- ses çıkarma
- ses alma
- ses değiştirme
- oynatma seçenekleri
- oynatma modu
- slaytlar arasında oynatma
- durdurulana kadar döngü
- gösterim sırasında gizle
- çalma sonrası geri sar
- ses seviyesi
- varsayılan görüntü
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PPT, PPTX ve ODP dosyalarında ses çerçevelerini kolayca ekleyin, çıkarın ve yönetin. Kod örneklerini keşfedin ve sunumlarınızı bugün güçlendirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde ses çerçeveleriyle nasıl çalışılacağını açıklar. Kaydırmalara gömülü ses ekleme, ses çerçevesi küçük resmini özelleştirme, ses seviyesini, döngüyü, gizlemeyi, kırpmayı ve solma sürelerini içeren oynatma seçeneklerini yapılandırma ve slayt gösterisi geçişlerinde kullanılan sesi çıkarma işlemlerini gösterir.

## **Ses Çerçeveleri Oluşturma**

Aspose.Slides for Python via .NET, slaytlara ses dosyaları eklemenizi sağlar. Ses dosyaları slaytlara ses çerçeveleri olarak gömülür. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını dizini aracılığıyla alın.
3. Slayta gömmek istediğiniz ses dosyası akışını yükleyin.
4. Gömülü ses çerçevesini (ses dosyasını içeren) slayta ekleyin.
5. [PlayMode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioplaymodepreset) ve [IAudioFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/) nesnesinin sunduğu `Volume` değerini ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Bu Python kodu, bir slayta gömülü ses çerçevesi eklemenin nasıl yapılacağını gösterir:

```python
import aspose.slides as slides

# Bir sunum dosyasını temsil eden bir sunum sınıfı örnekleyin
with slides.Presentation() as pres:
    # İlk slaytı alır
    sld = pres.slides[0]

    # wav ses dosyasını akışa yükler
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Ses Çerçevesi ekler
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Sesin Oynatma Modunu ve Ses Seviyesini ayarlar
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # PowerPoint dosyasını diske yazar
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Bir sunuma ses dosyası eklediğinizde, ses standart bir varsayılan görüntüyle bir çerçeve olarak görünür (aşağıdaki bölümdeki görsele bakın). Ses çerçevesinin küçük resmini (tercih ettiğiniz resmi ayarlayarak) değiştirebilirsiniz.

Bu Python kodu, bir ses çerçevesinin küçük resmini veya ön izleme resmini nasıl değiştireceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Belirtilen konum ve boyutta slayta ses çerçevesi ekler.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Sunum kaynaklarına bir resim ekler.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Ses çerçevesi için resmi ayarlar.
        audioFrame.picture_format.picture.image = audioImage
        
        #Değiştirilmiş sunumu diske kaydeder
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for Python via .NET, sesin oynatımını veya özelliklerini kontrol eden seçenekleri değiştirmenizi sağlar. Örneğin, sesin seviyesini ayarlayabilir, sesin döngü halinde çalmasını belirleyebilir ya da ses simgesini gizleyebilirsiniz.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** bölümü, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/) özelliklerine karşılık gelir:

- **Start** açılır listesi, [AudioFrame.play_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/play_mode/) özelliğiyle eşleşir 
- **Volume** özelliği, [AudioFrame.volume](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/volume/) ile eşleşir 
- **Play Across Slides** özelliği, [AudioFrame.play_across_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/play_across_slides/) ile eşleşir 
- **Loop until Stopped** özelliği, [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/play_loop_mode/) ile eşleşir 
- **Hide During Show** özelliği, [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/hide_at_showing/) ile eşleşir 
- **Rewind after Playing** özelliği, [AudioFrame.rewind_audio](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/rewind_audio/) ile eşleşir 

PowerPoint **Editing** seçenekleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/) özelliklerine karşılık gelir:

- **Fade In** özelliği, [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/fade_in_duration/) ile eşleşir 
- **Fade Out** özelliği, [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/fade_out_duration/) ile eşleşir 
- **Trim Audio Start Time** özelliği, [AudioFrame.trim_from_start](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/trim_from_start/) ile eşleşir 
- **Trim Audio End Time** değeri, ses süresinden [AudioFrame.trim_from_end](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/trim_from_end/) değerinin çıkarılmasıyla elde edilir

PowerPoint ses kontrol panelindeki **Volume control** seçeneği, [AudioFrame.volume_value](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/volume_value/) özelliğine karşılık gelir. Ses seviyesini yüzde olarak değiştirmenizi sağlar.

Ses Oynatma seçeneklerini değiştirme adımları şunlardır:

1. [Create](#create-audio-frame) veya Audio Frame'i alın.
2. Ayarlamak istediğiniz Audio Frame özellikleri için yeni değerler belirleyin.
3. Değiştirilmiş PowerPoint dosyasını kaydedin.

Bu Python kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # AudioFrame şekilini alır
    audioFrame = pres.slides[0].shapes[0]

    # Oynatma modunu tıklanınca çalacak şekilde ayarlar
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Ses seviyesini Düşük olarak ayarlar
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Sesin slaytlar arasında çalmasını ayarlar
    audioFrame.play_across_slides = True

    # Ses için döngüyü devre dışı bırakır
    audioFrame.play_loop_mode = False

    # Ses çerçevesini sunum sırasında gizler
    audioFrame.hide_at_showing = True

    # Ses çalındıktan sonra başa sarar
    audioFrame.rewind_audio = True

    # PowerPoint dosyasını diske kaydeder
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Bu Python örneği, gömülü sesli yeni bir ses çerçevesi eklemeyi, kırpmayı ve solma sürelerini ayarlamayı gösterir:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Kırpma başlangıç ofsetini 1.5 saniye olarak ayarlar
    # Kırpma bitiş ofsetini 2 saniye olarak ayarlar

    # Fade-in süresini 200 ms olarak ayarlar
    # Fade-out süresini 500 ms olarak ayarlar

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki kod örneği, gömülü sesli bir ses çerçevesini alıp ses seviyesini %85 olarak ayarlamayı gösterir:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Ses çerçevesi şekli alır
    audio_frame = pres.slides[0].shapes[0]

    # Ses seviyesini %85 olarak ayarlar
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, bir ses çerçevesine kapalı altyazı eklemenizi [caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/caption_tracks/) özelliği aracılığıyla sağlar. Bu özellik bir [CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/) döndürür; böylece WebVTT altyazı izlerini ekleyebilir, mevcut izler arasında dolaşabilir ve gerektiğinde kaldırabilirsiniz.

### **Ses Altyazılarını Ekleme**

[caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/caption_tracks/) özelliğini kullanarak bir ses çerçevesine bir veya daha fazla altyazı izi ekleyin. Aşağıdaki örnekte, bir ses dosyası slayta eklenir ve ardından yeni bir altyazı izi `.vtt` dosyasından yüklenir.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # WebVTT dosyasından yeni bir altyazı izi ekle.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Ses Altyazılarını Çıkarma**

Bir ses çerçevesine bağlı altyazı izleri arasında dolaşabilir ve bunları `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi ikili verisini ve benzersiz kimliğini ortaya koyar; bu, altyazıları dışa aktarırken kullanılabilir.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Altyazı izini .vtt dosyası olarak kaydet.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

### **Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazıları kaldırmak için [CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/) tarafından sağlanan [clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/remove/), veya [remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/remove_at/) gibi yöntemleri kullanın. Aşağıdaki örnek, bir ses çerçevesinden tüm altyazı izlerini kaldırır.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # type: slides.AudioFrame

    # Ses çerçevesinden tüm altyazı izlerini kaldır.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Ses Çıkarma**

Aspose.Slides for Python via .NET, slayt gösterisi geçişlerinde kullanılan sesi çıkarmanıza olanak tanır. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturup ses içeren sunumu yükleyin.
2. İlgili slaydın referansını dizini aracılığıyla alın.
3. Slaydın slayt gösterisi geçişlerine erişin.
4. Sesi bayt verisi olarak çıkarın.

Bu Python kodu, bir slaytta kullanılan sesi çıkarmanın nasıl yapılacağını gösterir:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # İstenen slayta erişir
    slide = pres.slides[0]  

    # Slayt için slayt gösterisi geçiş efektlerini alır
    transition = slide.slide_show_transition

    #Ses verisini bayt dizisi olarak çıkarır
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **SSS**

**Aynı ses varlığını birden fazla slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Sesi bir kez sunumun ortak [audio collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/audios/)ine ekleyin ve mevcut varlığı referans alan ek ses çerçeveleri oluşturun. Bu, medya verisinin çoğaltılmasını önler ve sunum boyutunu kontrol altında tutar.

**Mevcut bir ses çerçevesindeki sesi şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link path](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/link_path_long/)i yeni dosyaya yönlendirin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/python-net/aspose.slides/audioframe/embedded_audio/) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/audios/)inden başka bir sesle değiştirin. Çerçevenin biçimlendirmesi ve çoğu oynatma ayarı aynı kalır.

**Kırpma, sunumda depolanan temel ses verisini değiştirir mi?**

Hayır. Kırpma sadece oynatma sınırlarını ayarlar. Orijinal ses baytları dokunulmadan kalır ve gömülü ses veya sunumun ses koleksiyonu aracılığıyla erişilebilir.