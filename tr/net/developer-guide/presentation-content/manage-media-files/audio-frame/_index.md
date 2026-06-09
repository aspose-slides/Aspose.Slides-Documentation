---
title: .NET'te Sunumlarda Ses Çerçevelerini Yönetme
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/net/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- sesi çıkar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te ses çerçevelerini oluşturun ve kontrol edin—C# örnekleriyle gömme, kırpma, döngü ve PPT, PPTX ve ODP sunumları boyunca oynatma ayarlarını yapılandırma."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'da ses çerçeveleriyle nasıl çalışılacağını açıklar. Slaytlara gömülü ses ekleme, ses çerçevesi küçük resmini özelleştirme, ses seviyesini, döngüyü, gizlemeyi, kırpmayı ve solma sürelerini içeren oynatma seçeneklerini yapılandırma ve slayt gösterisi geçişlerinde kullanılan sesi çıkartma konularını gösterir.

## **Ses Çerçeveleri Oluşturma**

Aspose.Slides for .NET, slaytlara ses dosyaları eklemenize olanak tanır. Ses dosyaları, slaytlara ses çerçeveleri olarak gömülür. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İndeks aracılığıyla bir slaydın referansını alın.
3. Slayta gömmek istediğiniz ses dosyası akışını yükleyin.
4. Gömülü ses çerçevesini (ses dosyasını içeren) slayta ekleyin.
5. [PlayMode](https://reference.aspose.com/slides/tr/net/aspose.slides/audioplaymodepreset) ve `Volume` değerini [IAudioFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe) nesnesi aracılığıyla ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Bu C# kodu, bir slayta gömülü ses çerçevesi eklemenin nasıl yapılacağını gösterir:

```c#
// Bir sunum dosyasını temsil eden sunum sınıfını örnekler
using (Presentation pres = new Presentation())
{
    // İlk slaydı alır
    ISlide sld = pres.Slides[0];
    
    // wav ses dosyasını akışa yükler
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Ses Çerçevesini ekler
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Sesin Oynatma Modunu ve Ses Seviyesini ayarlar
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // PowerPoint dosyasını diske yazar
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Bir sunuma ses dosyası eklediğinizde, ses standart varsayılan bir görüntüyle çerçeve olarak görünür (aşağıdaki bölümdeki resmi bakınız). Ses çerçevesinin küçük resmini değiştirebilir (tercih ettiğiniz görüntüyü ayarlayabilirsiniz).

Bu C# kodu, bir ses çerçevesinin küçük resmini veya ön izleme görüntüsünü değiştirmenin nasıl yapılacağını gösterir:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Slayta belirtilen konum ve boyutta bir ses çerçevesi ekler.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Sunum kaynaklarına bir resim ekler.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Ses çerçevesi için resmi ayarlar.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//Değiştirilmiş sunumu diske kaydeder
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for .NET, bir sesin oynatımını veya özelliklerini kontrol eden seçenekleri değiştirmenize olanak tanır. Örneğin, ses seviyesini ayarlayabilir, sesi döngü halinde oynatacak şekilde ayarlayabilir veya ses simgesini gizleyebilirsiniz.

Microsoft PowerPoint'teki **Ses Seçenekleri** bölmesi:

![example1_image](audio_frame_0.png)

PowerPoint **Ses Seçenekleri**, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe) özelliklerine karşılık gelir:

- **Start** açılır menüsü, [AudioFrame.PlayMode](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/properties/playmode) özelliğiyle eşleşir 
- **Volume**, [AudioFrame.Volume](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/properties/volume) özelliğiyle eşleşir 
- **Play Across Slides**, [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/properties/playacrossslides) özelliğiyle eşleşir 
- **Loop until Stopped**, [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/properties/playloopmode) özelliğiyle eşleşir 
- **Hide During Show**, [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/properties/hideatshowing) özelliğiyle eşleşir 
- **Rewind after Playing**, [AudioFrame.RewindAudio](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/properties/rewindaudio) özelliğiyle eşleşir 

PowerPoint **Düzenleme** seçenekleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe) özelliklerine karşılık gelir:

- **Fade In**, [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/fadeinduration/) özelliğiyle eşleşir 
- **Fade Out**, [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/fadeoutduration/) özelliğiyle eşleşir 
- **Trim Audio Start Time**, [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/trimfromstart/) özelliğiyle eşleşir 
- **Trim Audio End Time** değeri, ses süresinden [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/trimfromend/) özelliğinin değeri çıkarılarak elde edilir

PowerPoint ses kontrol panelindeki **Volume controll**, [AudioFrame.VolumeValue](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/volumevalue/) özelliğine karşılık gelir. Ses seviyesini yüzde olarak değiştirmenizi sağlar.

Ses Oynatma seçeneklerini nasıl değiştireceğiniz aşağıdadır:

1. [Create](#create-audio-frame) veya Audio Frame'i alın.
2. Ayarlamak istediğiniz Audio Frame özellikleri için yeni değerler ayarlayın.
3. Değiştirilmiş PowerPoint dosyasını kaydedin.

Bu C# kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrame şekilini alır
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Oynatma modunu tıklayınca oynatılacak şekilde ayarlar
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Ses seviyesini Düşük olarak ayarlar
    audioFrame.Volume = AudioVolumeMode.Low;

    // Sesin slaytlar arasında çalmasını ayarlar
    audioFrame.PlayAcrossSlides = true;

    // Ses için döngüyü devre dışı bırakır
    audioFrame.PlayLoopMode = false;

    // Slayt gösterisi sırasında AudioFrame'i gizler
    audioFrame.HideAtShowing = true;

    // Oynattıktan sonra sesi başa sarar
    audioFrame.RewindAudio = true;

    // PowerPoint dosyasını diske kaydeder
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Bu C# örneği, gömülü sesli yeni bir ses çerçevesi ekleme, kırpma ve solma sürelerini ayarlama yolunu gösterir:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Kırpma başlangıç ofsetini 1.5 saniyeye ayarlar
    audioFrame.TrimFromStart = 1500f;
    // Kırpma bitiş ofsetini 2 saniyeye ayarlar
    audioFrame.TrimFromEnd = 2000f;

    // Fade-in süresini 200 ms'ye ayarlar
    audioFrame.FadeInDuration = 200f;
    // Fade-out süresini 500 ms'ye ayarlar
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Aşağıdaki kod örneği, gömülü sesli bir ses çerçevesini alıp ses seviyesini %85'e ayarlamanın nasıl yapılacağını gösterir:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Bir ses çerçevesi şekli alır
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Ses seviyesini %85'e ayarlar
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, bir ses çerçevesine kapalı altyazılar eklemenize [CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudioframe/captiontracks/) özelliği aracılığıyla izin verir. Bu özellik, WebVTT altyazı izlerini eklemenize, mevcut izler arasında dolaşmanıza ve gerektiğinde kaldırmanıza olanak tanıyan bir [ICaptionsCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptionscollection/) döndürür.

**Ses Altyazılarını Ekle**

[CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudioframe/captiontracks/) özelliğini kullanarak bir ses çerçevesine bir veya daha fazla altyazı izi ekleyin. Aşağıdaki örnekte bir ses dosyası slayta eklenir ve ardından yeni bir altyazı izi `.vtt` dosyasından yüklenir.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT dosyasından yeni bir altyazı izi ekle.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Ses Altyazılarını Çıkarma**

Bir ses çerçevesiyle ilişkili altyazı izlerini dolaşabilir ve `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi, ikili verisini ve benzersiz tanımlayıcısını sunar; bu, altyazılar dışa aktarılırken kullanılabilir.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Altyazı izini .vtt dosyası olarak kaydet.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazıları kaldırmak için [ICaptionsCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptionscollection/) tarafından sağlanan yöntemleri, örneğin [Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptionscollection/remove/), veya [RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptionscollection/removeat/) kullanın. Aşağıdaki örnek, bir ses çerçevesinden tüm altyazı izlerini kaldırır.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Ses çerçevesinden tüm altyazı izlerini kaldır.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Ses Çıkarma**

Aspose.Slides for .NET, slayt gösterisi geçişlerinde kullanılan sesi çıkarmanıza olanak tanır. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. Ses içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının örneğini oluşturun ve sunumu yükleyin.
2. İlgili slaydın referansını indeks üzerinden alın.
3. Slayt için slayt gösterisi geçişlerine erişin.
4. Sesi bayt verisi olarak çıkarın.

Bu C# kodu, bir slaytta kullanılan sesin nasıl çıkarılacağını gösterir:

```c#
string presName = "AudioSlide.pptx";

// Bir sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation(presName);

// Slaytı erişir
ISlide slide = pres.Slides[0];

// Slayt için slayt gösterisi geçiş efektlerini alır
ISlideShowTransition transition = slide.SlideShowTransition;

// Sesi bayt dizisine çıkarır
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **SSS**

**Aynı ses varlığını birden fazla slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Ses dosyasını yalnızca bir kez sunumun ortak [audio collection](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/audios/) öğesine ekleyin ve mevcut varlığı referans alan ek ses çerçeveleri oluşturun. Bu, ortam verilerinin çoğaltılmasını önler ve sunum boyutunun kontrol altında kalmasını sağlar.

**Mevcut bir ses çerçevesindeki sesi şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link path](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/linkpathlong/)’i yeni dosyaya işaret edecek şekilde güncelleyin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/net/aspose.slides/audioframe/embeddedaudio/) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/audios/) içindeki başka bir nesneyle değiştirin. Çerçevenin biçimlendirmesi ve çoğu oynatma ayarı aynı kalır.

**Kırpma, sunumda saklanan temel ses verisini değiştirir mi?**

Hayır. Kırpma yalnızca oynatma sınırlarını ayarlar. Orijinal ses baytları dokunulmadan kalır ve gömülü ses ya da sunumun audio collection’ı aracılığıyla erişilebilir.