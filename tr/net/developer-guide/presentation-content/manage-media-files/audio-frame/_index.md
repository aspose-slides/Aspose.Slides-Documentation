---
title: .NET’te Sunumlarda Ses Çerçevelerini Yönetme
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
- ses çıkarma
- .NET
- C#
- Aspose.Slides
description: "Sesleri slaytlara gömün, ses simgesini değiştirin, oynatmayı yapılandırın, WebVTT altyazılarını yönetin ve Aspose.Slides for .NET ile slayt geçiş seslerini çıkarın."
---
## **Genel Bakış**

Bir ses çerçevesi, slayt üzerinde bir ses çalmanıza olanak tanır. Aspose.Slides for .NET ile bir ses klibi gömebilir, onu temsil eden görüntüyü seçebilir, oynatmayı ayarlayabilir ve altyazılar ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluşturma**

Yerel bir ses klibini ilk slayta gömmek için [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/)’ı kullanın. İlk iki koordinat çerçevenin slayttaki konumunu, sonraki iki değer ise genişlik ve yüksekliğini, tümü puan cinsinden ayarlar. Bu örnek, klibi otomatik olarak başlatmak için [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) ve yüksek ses ön ayarını ayarlamak için [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) belirler.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Varsayılan olarak, bir ses çerçevesi hoparlör simgesi gösterir. Özel bir küçük resim görüntülemek için sunuma [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) ile bir görüntü ekleyin ve çerçevenin [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) özelliğine atayın. Örnek, gömülü bir ses klibi için küçük resim olarak JPEG kullanır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Ses Oynatma Seçeneklerini Değiştirme**

PowerPoint'in **Audio Options** denetimleri, bir klibin ne zaman başlayacağını, ne kadar yüksek sesle çalacağını ve slayt gösterisi sırasında nasıl davranacağını belirler.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint denetimi | Aspose.Slides özelliği |
| --- | --- |
| Başlat | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Ses ön ayarı | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Slaytlar Arasında Oynat | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Durdurulana Kadar Döngü | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Gösteri Sırasında Gizle | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Oynatmadan Sonra Geri Sar | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Yumuşak Giriş | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Yumuşak Çıkış | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Ses Başlangıç Zamanını Kırp | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Ses Bitiş Zamanını Kırp | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Ses Kaydırıcısı | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, oynatmayı tıklamayla başlatmak için [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) ayarlar ve düşük ses ön ayarını seçer. Klib, döngü devre dışı bırakılarak slaytlar arasında devam eder. Simge gösteri sırasında gizli kalır ve klip oynatmadan sonra geri sarar.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

3,5 saniyeden uzun bir klip için bu örnek, ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) klibin sondan çıkarılacak süresini ölçer. PowerPoint'te gösterilen bitiş zamanını elde etmek için bu offseti tam klip süresinden çıkarın. Kırpılmış klip 200 milisaniye içinde yumuşak giriş ve 500 milisaniye içinde yumuşak çıkış yapar. Tüm dört özellik milisaniye cinsinden değer alır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Oynatma ses seviyesini belirli bir yüzdeye ayarlamak için [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) kullanın. Bu örnek, ilk slayttaki ilk ses çerçevesini %85 olarak ayarlar.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Ses Altyazılarını Yönetme**

Her ses çerçevesinin bir [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) koleksiyonu vardır. Klipe WebVTT altyazıları eklemek, mevcut izleri dışa aktarmak veya silmek için kullanın.

### **Ses Altyazısı Ekleme**

Örnek, ilk slayta bir ses klibi gömer ve yerel bir WebVTT izini eklemek için [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) kullanır. İlk argüman iz etiketini, ikincisi zamanlı altyazıları içeren dosyayı belirtir.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Ses Altyazılarını Dışa Aktarma**

Bu örnek, ilk slayttaki bir ses çerçevesine eklenmiş her altyazı izini dışa aktarır. İz'in [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) değerini bir WebVTT dosyasına yazar ve dosya adı olarak [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) kullanır, böylece her iz ayrı bir çıktıya sahip olur.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Ses Altyazılarını Kaldırma**

Bireysel bir izi silmek için [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) kullanın. Örnek, klibi korurken ilk slayttaki ilk ses çerçevesinden tüm altyazıları kaldırmak için [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) kullanır.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Ses Altyazılarında Bir Satır Bulma**

İlk slayttaki ses altyazılarında bir satır bulmak için her iz'in [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) değerini bellekte okuyun. Düz metin bir WebVTT işaretinde zaman çizgisi `-->` içerir, altyazı satırları ondan sonra gelir ve boş bir satır işareti sonlandırır. Bu örnek, iz etiketini ve “café” içeren her altyazı satırını yazdırır.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Ses Çıkarma**

Bir slayt geçişi kendi sesine sahip olabilir. Onu almak için geçişin [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) özelliğini okuyun. Örnek, sesin [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) değerine erişir ve boyutunu bayt olarak yazdırır. İlk slaytta geçiş sesi yoksa, bunun yerine bir mesaj yazdırır.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **SSS**

**Aynı ses klibini birden fazla slaytta çoğaltmadan yeniden kullanabilir miyim?**

Evet. Klibi sunumun [ses koleksiyonu](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) içine bir kez ekleyin ve her slayt için aynı ses nesnesini [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/)’a geçirin.

**Mevcut bir ses çerçevesindeki sesi değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) özelliğini yeni dosyaya işaret edecek şekilde güncelleyin. Gömülü bir ses için, sunumun ses koleksiyonundaki başka bir klibi [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/)’a atayın. Her iki yaklaşım da mevcut çerçeveyi korur.

**Kırpma, sunumda depolanan ses verisini değiştirir mi?**

Hayır. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) ve [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) oynatma sınırlarını ayarlar. Tam klibi hâlâ [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/)’dan alabilirsiniz.