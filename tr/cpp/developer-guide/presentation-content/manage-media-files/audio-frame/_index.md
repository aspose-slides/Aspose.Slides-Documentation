---
title: C++ Kullanarak Sunumlarda Ses Çerçevelerini Yönetme
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
- ses çıkarma
- C++
- Aspose.Slides
description: "Sesleri slaytlara göm, ses simgesini değiştir, oynatmayı yapılandır, WebVTT altyazılarını yönet ve Aspose.Slides for C++ ile slayt geçiş seslerini çıkar."
---
## **Genel Bakış**

Bir ses çerçevesi, bir slaytta ses çalmanıza olanak tanır. Aspose.Slides for C++ ile bir ses klibini gömebilir, onu temsil eden resmi seçebilir, oynatmayı ayarlayabilir ve altyazılar ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluşturma**

İlk slayta yerel bir ses klibini gömmek için [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) kullanın. İlk iki koordinat çerçevenin slaytta konumunu, sonraki iki değer ise genişlik ve yüksekliğini, tümü puan cinsinden belirler. Bu örnek, klibi otomatik olarak başlatmak için [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) çağırır ve yüksek ses ön ayarını seçmek için [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) çağırır.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Varsayılan olarak, bir ses çerçevesi bir hoparlör simgesi gösterir. Özel bir küçük resim göstermek için sunuma [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) ile bir görüntü ekleyin ve bunu çerçevenin resmi olarak [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) ile ayarlayın. Örnek, gömülü bir ses klibi için küçük resim olarak bir JPEG kullanır.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **Ses Oynatma Seçeneklerini Değiştirme**

PowerPoint'in **Audio Options** denetimleri, bir klibin ne zaman başlayacağını, ses seviyesini ve slayt gösterisi sırasında nasıl davranacağını belirler.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint denetimi | Aspose.Slides for C++ yöntemi |
| --- | --- |
| Başlat | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| Ses ön ayarı | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| Slaytlar arasında oynat | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| Durdurulana kadar döngü | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| Gösteri sırasında gizle | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| Oynatma sonrası geri sar | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| Yavaşça gir | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| Yavaşça çık | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| Ses başlangıç zamanını kırp | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| Ses son zamanını kırp | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| Ses kaydırıcısı | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, tıklamayla oynatmayı başlatmak için [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) çağırır ve düşük ses ön ayarını seçer. Klip, döngü kapalıyken slaytlar arasında devam eder. Simge gösteri sırasında gizli kalır ve klip oynatmadan sonra geri sarar.

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

3,5 saniyeden uzun bir klip için bu örnek, ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) metoduna verilen argüman, klibin sonundan çıkarılacak süreyi belirtir. PowerPoint'te gösterilen son zamanı elde etmek için bu ofseti tam klip süresinden çıkarın. Kırpılan klip 200 milisaniye içinde yavaşça girer ve 500 milisaniye içinde yavaşça çıkar. Tüm dört ayarlayıcı milisaniye cinsinden değer alır.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

Oynatma ses seviyesini belirli bir yüzdeye ayarlamak için [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) kullanın. Bu örnek, ilk slayttaki ilk ses çerçevesini %85 olarak ayarlar.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **Ses Altyazılarını Yönetme**

Her ses çerçevesi, altyazı koleksiyonunu [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/) aracılığıyla sunar. Bu özelliği, klibe WebVTT altyazıları eklemek, mevcut izleri dışa aktarmak veya kaldırmak için kullanın.

### **Ses Altyazısı Ekleme**

Örnek, ilk slayta bir ses klibi gömer ve [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) kullanarak yerel bir WebVTT izini ekler. İlk argüman iz etiketini, ikinci argüman ise zamanlı altyazıları içeren dosyayı belirtir.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **Ses Altyazılarını Dışa Aktarma**

Bu örnek, ilk slayttaki bir ses çerçevesine ekli her altyazı izini dışa aktarır. [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) tarafından döndürülen baytları bir WebVTT dosyasına yazar ve [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) tarafından döndürülen değeri dosya adı olarak kullanır; böylece her iz ayrı bir çıktı elde eder.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **Ses Altyazılarını Kaldırma**

Tek bir izi silmek için [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) kullanın. Örnek, klibi korurken ilk slayttaki ilk ses çerçevesinden tüm altyazıları kaldırmak için [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) kullanır.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **Ses Altyazılarında Bir Satır Bulma**

İlk slaydaki ses altyazılarında bir satır bulmak için her izde [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) çağırarak WebVTT metnini bellekte okuyun. Düz metin bir WebVTT işaretinde zaman satırı `-->` içerir, altyazı satırları ondan sonra gelir ve boş bir satır işareti sonlandırır. Bu örnek, iz etiketini ve “café” içeren her altyazı satırını yazdırır.

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **Ses Dışa Aktarma**

Bir slayt geçişinin kendi sesi olabilir. Onu almak için geçişte [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) çağırın. Örnek, ses baytlarını [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) ile alır ve bayt sayısını yazdırır. İlk slaytta geçiş sesi yoksa, bunun yerine bir mesaj yazdırır.

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **SSS**

**Aynı ses klibini birden çok slaytta yeniden kullanabilir miyim, kopyalamadan?**

Evet. Klipi yalnızca bir kez sunumun [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) kısmına ekleyin ve her slayt için aynı ses nesnesini [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) ile iletin.

**Mevcut bir ses çerçevesindeki sesi değiştirilebilir miyim?**

Evet. Bağlantılı bir ses için, değiştirme dosyasının yolunu [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) ile belirtin. Gömülü bir ses için, sunumun ses koleksiyonundan başka bir klibi [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/) metoduna geçirin. Her iki yöntem de mevcut çerçeveyi korur.

**Kırpma, sunumda depolanan ses verisini değiştirir mi?**

Hayır. [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) ve [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) oynatma sınırlarını belirler. Tam klibi hâlâ [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/) ile alabilirsiniz.