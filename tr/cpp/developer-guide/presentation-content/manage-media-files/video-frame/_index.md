---
title: C++ Kullanarak Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/cpp/video-frame/
keywords:
- video ekle
- video oluştur
- video göm
- video çıkar
- video al
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for C++ slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını ayarlamanızı, açıklamaları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint yerel videoları ve YouTube videoları gibi çevrimiçi video bağlantılarını destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sağlar.

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza yerleştirmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına yerel bir videoyu gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme tamamlanana kadar açık kalır çünkü [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) sunum kullanıldığı sürece kilitli tutar.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

Yerel video yolunu doğrudan [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) metoduna da geçirebilirsiniz. Bu örnek, yeni bir sunumun ilk slaydına videoyu gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube videosu gibi çevrimiçi bir videoya bağlantı veren bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve küçük resim ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) yöntemi otomatik oynatmayı talep eder. Küçük resmin indirilmesi ve videonun oynatılması internet erişimi gerektirir. Sunum görüntüleyicisi de çevrimiçi video oynatımını desteklemelidir.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Videoyu Tam Ekran Modunda Oynatma**

Eğitim sunumunda, izleyicilerin ayrıntıları görebilmesi için bir yazılım demosunu tam ekran modunda oynatabilirsiniz. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) bu davranışı oynatma sırasında etkinleştirmek için `true` değerini kabul eder.

Bu örnek bir sunumu açar, ilk slaydın ilk [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Giriş sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Tam ekran oynatma, videonun nasıl gösterileceğini kontrol eder. Bağımsız olarak, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) videonun otomatik mi yoksa tıklamayla mı başlayacağını, [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ise tekrarlayıp tekrarlamayacağını kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sar**

Eğitim sunumunda, bir demo videosunu başına döndürmek, sunumcunun videoyu yeniden oynatmaya hazır olmasını sağlar. Oynatma tamamlandığında videoyu başa döndürmek için [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) metodunu `true` ile çağırın.

Bu örnek bir sunumu açar, ilk slaydın ilk [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Döngüyü devre dışı bırakır, böylece oynatma sona erebilir ve oynatmayı tıklamayla başlatır. Giriş sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Geri sarma videoyu tekrar başlatmadan başına döndürür. Buna karşılık, [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) etkinleştirildiğinde oynatma otomatik olarak tekrar eder. Videonun bitmesini ve yeniden oynatılmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) bağımsız olarak otomatik ya da tıklamayla başlatmayı kontrol eder; bu örnek, oynatmanın ne zaman başlayacağını sunumcunun kontrol etmesi için [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) kullanır. Örnekte gösterildiği gibi döngü ayarından sonra oynatma modu ayarlanır. Geri sarma, [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) ile bağımsız çalışır.

## **Video Çerçevesini Kırpma**

[IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) ve [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) yöntemlerini kullanarak oynatma sırasında videonun başlangıcının veya sonunun bir kısmını atlayabilirsiniz. Her iki değer de milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir video gömer ve oynatma sırasında ilk 2,5 saniyeyi ve son saniyeyi atlar. Oynatılabilir bir segment kalması için 3,5 saniyeden uzun bir video kullanın.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Kırpma Ayarlarını Okuma**

Bu örnek, ilk slaydın ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer o slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) yöntemi aracılığıyla sunulur.

### **Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve İngilizce etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları video ile eşleşmelidir. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

### **Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Ardışık sayılar çıktı dosyalarının farklı olmasını sağlar. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir slayt içermelidir.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Her [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) nesnesi, altyazı kimliğini, etiketini, ikili veriyi ve altyazı metnini UTF-8 dizesi olarak sunar.

### **Video Çerçevesinden Altyazı Silme**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin mevcut olduğu ve şeklin bir video çerçevesi olduğu varsayılır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) yöntemlerini kullanın.

### **Video Altyazılarını Arama**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) başlık, zaman çizgileri ve altyazı metni dahil olmak üzere tam WebVTT izini döndürür. Konuşulan bir ifadeyi ve zaman damgasını bulmak için ipuçlarını bellekte okuyun. Örneğin, 2. slaydın İngilizce izinde aşağıdaki metin bulunabilir:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Örnek, `captioned_media.pptx` dosyasını açar ve her slayttaki üst düzey video çerçevelerinin altyazı izlerini [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) kullanarak okur. Düz metin ipucunda zaman çizgisi `-->` içerir ve boş bir satır ipucunu sonlandırır. Altyazı “café” içerdiğinde, örnek slayt numarasını, iz etiketini, orijinal zaman çizgisini ve tam altyazıyı yazar. Arama büyük/küçük harf duyarsızdır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"captioned_media.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        auto videoFrame = AsCast<IVideoFrame>(shape);
        if (!videoFrame)
            continue;

        for (auto&& track : IterateOver(videoFrame->get_CaptionTracks()))
        {
            auto reader = MakeObject<StringReader>(track->get_DataAsString());
            for (auto timing = reader->ReadLine(); !timing.IsNull(); timing = reader->ReadLine())
            {
                if (!timing.Contains(u"-->"))
                    continue;

                String caption;
                for (auto line = reader->ReadLine(); !String::IsNullOrEmpty(line); line = reader->ReadLine())
                {
                    if (!String::IsNullOrEmpty(caption))
                        caption += u"\n";
                    caption += line;
                }

                if (caption.IndexOf(u"caf\u00E9", StringComparison::OrdinalIgnoreCase) >= 0)
                {
                    Console::WriteLine(String::Format(u"Slide {0} | {1} | {2}", slide->get_SlideNumber(), track->get_Label(), timing));
                    Console::WriteLine(caption);
                }
            }
        }
    }
}
presentation->Dispose();
```

“café” aranması, örnek iz için bir eşleşme üretir. Arama başlığı atlar ve zaman ayarını çıktıda korur.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

Bu örnek, gömülü videoları her slayttan ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri olmadığından atlanır. Konsol, her videonun MIME türünü ve toplam sayısını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde bildirilen medya türüne uygun şekilde değiştirin.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **SSS**

**Bir video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**  
Oynatma modunu ([oynatma modu](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)) (otomatik veya tıklamayla) ve [döngü](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) kontrol edebilirsiniz. Bu seçenekler [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) nesnesinin yöntemleri aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**  
Evet. Yerel bir video gömdüğünüzde ikili veri belgeye eklenir, bu nedenle sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir videoya bağlantı verip bir küçük resim eklediğinizde, sunum video verisi yerine bağlantıyı ve önizleme görüntüsünü saklar, bu yüzden boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**  
Evet. Çerçeve içindeki [video içeriğini](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) şeklin geometrisini koruyarak değiştirebilirsiniz; bu, mevcut bir yerleşimde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**  
Evet. Gömülü bir video, [içerik türü](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) olarak okuyabileceğiniz ve örneğin diske kaydederken kullanabileceğiniz bir bilgiye sahiptir.