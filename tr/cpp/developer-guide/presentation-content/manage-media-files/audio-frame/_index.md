---
title: Sunumlarda Ses Yönetimi C++ Kullanarak
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/cpp/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkar
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde ses çerçevelerini oluşturun ve kontrol edin—PPT, PPTX ve ODP sunumları boyunca gömme, kırpma, döngü ve oynatma ayarlarını yapılandırmak için kod örnekleri."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te ses çerçeveleriyle nasıl çalışılacağını açıklar. Slaytlara gömülü ses eklemeyi, ses çerçevesi küçük resmini özelleştirmeyi, ses seviyesi, döngü, gizleme, kırpma ve solma süreleri gibi oynatma seçeneklerini yapılandırmayı ve slayt gösterisi geçişlerinde kullanılan sesleri çıkarmayı gösterir.

## **Ses Çerçeveleri Oluşturma**

Aspose.Slides for C++, slaytlara ses dosyaları eklemenizi sağlar. Ses dosyaları, slaytlara ses çerçeveleri olarak gömülür. 

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun.
2. Bir slaydın referansını indeksine göre alın.
3. Slayta gömmek istediğiniz ses dosyası akışını yükleyin.
4. Gömülü ses çerçevesini (ses dosyasını içeren) slayta ekleyin.
5. [IAudioFrame](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_audio_frame) nesnesi tarafından sunulan [PlayMode](https://reference.aspose.com/slides/tr/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) ve `Volume` değerlerini ayarlayın.
6. Değiştirilen sunumu kaydedin.

Bu C++ kodu, bir slayta gömülü ses çerçevesi eklemenin nasıl yapılacağını gösterir:

``` cpp
// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleştirir
auto pres = System::MakeObject<Presentation>();

// İlk slaytı alır
auto sld = pres->get_Slides()->idx_get(0);

// wav ses dosyasını akışa yükler
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Ses Çerçevesini ekler
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Sesin Oynatma Modu ve Ses Seviyesini ayarlar
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// PowerPoint dosyasını diske yazar
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Bir sunuma ses dosyası eklediğinizde, ses standart bir varsayılan görüntüyle bir çerçeve olarak görünür (aşağıdaki bölüme bakın). Ses çerçevesinin küçük resmini (istediğiniz resmi ayarlayarak) değiştirebilirsiniz.

Bu C++ kodu, bir ses çerçevesinin küçük resmini veya önizleme görüntüsünü nasıl değiştireceğinizi gösterir:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Belirtilen konum ve boyutla slayta bir ses çerçevesi ekler.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Sunum kaynaklarına bir resim ekler.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Ses çerçevesi için resmi ayarlar.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
// Değiştirilmiş sunumu diske kaydeder
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for C++, bir sesin oynatma veya özelliklerini kontrol eden seçenekleri değiştirmenizi sağlar. Örneğin, sesin seviyesini ayarlayabilir, sesi döngü halinde çalacak şekilde ayarlayabilir veya ses simgesini gizleyebilirsiniz.

Microsoft PowerPoint içindeki **Audio Options** bölmesi:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** öğeleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/) metodlarına karşılık gelir:

- **Start** açılır listesi, [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_playmode/) metoduna karşılık gelir
- **Volume** [AudioFrame::set_Volume](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_volume/) metoduna karşılık gelir
- **Play Across Slides** [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_playacrossslides/) metoduna karşılık gelir
- **Loop until Stopped** [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_playloopmode/) metoduna karşılık gelir
- **Hide During Show** [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_hideatshowing/) metoduna karşılık gelir
- **Rewind after Playing** [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_rewindaudio/) metoduna karşılık gelir

PowerPoint **Editing** seçenekleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/) özelliklerine karşılık gelir:

- **Fade In** [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_fadeinduration/) metoduna karşılık gelir
- **Fade Out** [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_fadeoutduration/) metoduna karşılık gelir
- **Trim Audio Start Time** [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_trimfromstart/) metoduna karşılık gelir
- **Trim Audio End Time** değeri, ses süresinden [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_trimfromend/) metodunun değeri çıkarılarak elde edilir

PowerPoint ses kontrol panelindeki **Volume** denetimi, [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_volumevalue/) metoduna karşılık gelir. Ses hacmini yüzde olarak değiştirmenizi sağlar.

Ses Oynatma seçeneklerini nasıl değiştireceğiniz aşağıda gösterilmiştir:

1. [Create](#creating-audio-frame) veya Audio Frame'i alın.
2. Ayarlamak istediğiniz Audio Frame özellikleri için yeni değerler belirleyin.
3. Değiştirilen PowerPoint dosyasını kaydedin.

Bu C++ kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Bir şekil al
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Şekli AudioFrame şekline dönüştürür
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Oynatma modunu tıklamayla çalmaya ayarlar
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Ses seviyesini Düşük olarak ayarlar
audioFrame->set_Volume(AudioVolumeMode::Low);

// Sesin slaytlar arasında çalmasını ayarlar
audioFrame->set_PlayAcrossSlides(true);

// Ses için döngüyü devre dışı bırakır
audioFrame->set_PlayLoopMode(false);

// Slayt gösterisi sırasında AudioFrame'i gizler
audioFrame->set_HideAtShowing(true);

// Ses çaldıktan sonra başa sarmayı ayarlar
audioFrame->set_RewindAudio(true);

// PowerPoint dosyasını diske kaydeder
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Bu C++ örneği, gömülü sesli yeni bir ses çerçevesi eklemeyi, kırpmayı ve solma sürelerini ayarlamayı gösterir:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Kırpma başlangıç ofsetini 1,5 saniye olarak ayarlar
audioFrame->set_TrimFromStart(1500);
// Kırpma bitiş ofsetini 2 saniye olarak ayarlar
audioFrame->set_TrimFromEnd(2000);

// Fade-in süresini 200 ms olarak ayarlar
audioFrame->set_FadeInDuration(200);
// Fade-out süresini 500 ms olarak ayarlar
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Aşağıdaki kod örneği, gömülü sesli bir ses çerçevesini nasıl alacağınızı ve ses seviyesini %85 olarak nasıl ayarlayacağınızı gösterir:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Bir ses çerçevesi şekli alır
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Ses seviyesini %85 olarak ayarlar
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, bir ses çerçevesine kapalı altyazı eklemenizi [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudioframe/get_captiontracks/) metodu aracılığıyla sağlar. Bu metod, WebVTT altyazı izleri eklemenize, mevcut izleri dolaşmanıza ve gerektiğinde kaldırmanıza olanak tanıyan bir [ICaptionsCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/) döndürür.

**Ses Altyazılarını Ekle**

Bir ses çerçevesine bir veya daha fazla altyazı izi eklemek için [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudioframe/get_captiontracks/) metodunu kullanın. Aşağıdaki örnekte, bir ses dosyası slayta eklenir ve ardından yeni bir altyazı izi `.vtt` dosyasından yüklenir.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Ses Altyazılarını Çıkarma**

Bir ses çerçevesine ilişkilendirilmiş altyazı izlerini dolaşabilir ve `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi, dışa aktarma sırasında kullanılabilecek ikili verisini ve benzersiz tanımlayıcısını sunar.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Her altyazı izini .vtt dosyası olarak kaydet.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazıları kaldırmak için, [ICaptionsCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/) tarafından sağlanan [Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/remove/), veya [RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/removeat/) gibi metodları kullanın. Aşağıdaki örnek, bir ses çerçevesinden tüm altyazı izlerini kaldırır.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Ses çerçevesinden tüm altyazı izlerini kaldır.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ses Çıkarma**

Aspose.Slides, slayt gösterisi geçişlerinde kullanılan sesi çıkarmanıza olanak tanır. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.presentation) sınıfının bir örneğini oluşturun ve ses içeren sunumu yükleyin.
2. İlgili slaydın referansını indeksine göre alın.
3. Slaydın slayt gösterisi geçişlerine erişin.
4. Sesi bayt verisi olarak çıkarın.

Bu C++ kodu, bir slaytta kullanılan sesi nasıl çıkaracağınızı gösterir:

``` cpp
String presName = u"AudioSlide.pptx";

// Bir sunum dosyasını temsil eden Presentation sınıfını örnekleştirir
auto pres = System::MakeObject<Presentation>(presName);

// İstenen slayta erişir
auto slide = pres->get_Slides()->idx_get(0);

// Slayt için slayt gösterisi geçiş efektlerini alır
auto transition = slide->get_SlideShowTransition();

// Sesi bayt dizisi olarak çıkarır
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **SSS**

**Aynı ses öğesini birden çok slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Sesi, sunumun ortak [audio collection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_audios/) bölümüne bir kez ekleyin ve mevcut varlığa referans veren ek ses çerçeveleri oluşturun. Bu, medya verisinin çoğaltılmasını önler ve sunum boyutunun kontrol altında kalmasını sağlar.

**Mevcut bir ses çerçevesindeki sesi, şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link path](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_linkpathlong/) öğesini yeni dosyayı gösterecek şekilde güncelleyin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/cpp/aspose.slides/audioframe/set_embeddedaudio/) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/get_audios/) bölümünden başka bir nesneyle değiştirin. Çerçevenin biçimlendirmesi ve çoğu oynatma ayarı aynı kalır.

**Kırpma, sunumda depolanan temel ses verisini değiştirir mi?**

Hayır. Kırpma yalnızca oynatma sınırlarını ayarlar. Orijinal ses baytları değiştirilmez ve gömülü ses veya sunumun audio collection'ı aracılığıyla erişilebilir durumda kalır.