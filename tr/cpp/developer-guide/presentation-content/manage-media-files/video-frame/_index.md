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
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument slaytlarında programatik olarak video çerçeveleri eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır kılavuzu."
---
## **Giriş**

Videolar fikirleri açıklamaya yardımcı olabilir ve izleyiciyi etkileşime sokabilir. Aspose.Slides for C++ slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını ayarlamanızı, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint yerel videoları ve YouTube gibi çevrimiçi video bağlantılarını destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili tipleri sağlar.

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek mevcut bir sunumun ilk sl aytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları point cinsindendir. Akış, sunum kullanıldığı sürece kilitli tutan [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) nedeniyle kaydetme tamamlanana kadar açık kalır.

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

Ayrıca yerel video yolunu doğrudan [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) yöntemine geçirebilirsiniz. Bu örnek yeni bir sunumun ilk sl aytına videoyu gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube gibi bir çevrimiçi videoya bağlanan bir video çerçevesi oluşturabilirsiniz.

Bu örnek ilk sl ayta bir YouTube video bağlantısı ve küçük resim ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) yöntemi otomatik oynatmayı talep eder. Küçük resmi indirmek ve videoyu oynatmak internet erişimi gerektirir. Sunum görüntüleyicisinin de çevrimiçi video oynatmayı desteklemesi gerekir.

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

Bir eğitim sunumunda, yazılım demonstrasyonunu tam ekran modunda oynatabilirsiniz; böylece izleyiciler ayrıntıları görebilir. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) `true` alarak bu davranışı oynatma sırasında etkinleştirir.

Bu örnek bir sunumu açar, ilk sl ayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Giriş sunumu, ilk sl aytta mevcut bir video çerçevesi içeren en az bir sl ayt içermelidir.

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

Tam ekran oynatma, videonun nasıl görüntüleneceğini kontrol eder. Bağımsız olarak, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) otomatik mi yoksa tıklama ile mi başlayacağını, [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ise tekrar edip etmeyeceğini kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Bir eğitim sunumunda, bir demonstrasyon videosunu başa döndürmek, sunumcunun videoyu tekrar oynatmasını hazır hale getirir. `true` parametresiyle [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) çağırarak oynatma bittikten sonra videoyu başa sarabilirsiniz.

Bu örnek bir sunumu açar, ilk sl ayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Döngüyü devre dışı bırakır, böylece oynatma tamamlanabilir ve oynatmayı tıklamayla başlatır. Giriş sunumu, ilk sl aytta mevcut bir video çerçevesi içeren en az bir sl ayt içermelidir.

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

Geri sarma, videoyu başa döndürür ancak tekrar başlatmaz. Buna karşılık, [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) etkinleştirildiğinde oynatma otomatik olarak tekrarlanır. Videonun bitmesini ve tekrar oynatılmaya hazır kalmasını istiyorsanız döngüyü devre dışı bırakın. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) bağımsız olarak otomatik ya da tıklama ile başlatmayı kontrol eder; bu örnek [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) kullanır, böylece sunumcu oynatmanın ne zaman başlayacağını kontrol eder. Döngü ayarının ardından oynatma modunu ayarlayın, örnekte gösterildiği gibi. Geri sarma, [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) ile bağımsız olarak çalışır.

## **Video Çerçevesini Kesme**

[IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) ve [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) yöntemleriyle bir videonun başlangıç ya da son kısmını oynatma sırasında atlayabilirsiniz. Her iki değer milisaniye cinsindendir. Kesme, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kesme Ayarlarını Belirleme**

Bu örnek yerel bir video gömer ve oynatma sırasında ilk 2.5 saniye ile son bir saniyeyi atlar. Oynatılabilir bir segment kalması için videonun 3.5 saniyeden uzun olması gerekir.

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

**Kesme Ayarlarını Okuma**

Bu örnek ilk sl ayttaki ilk video çerçevesinin kesme değerlerini milisaniye olarak yazdırır. Sunum en az bir sl ayt içermelidir. Eğer o sl aytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

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

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenize olanak tanır. Altyazılar WebVTT formatında depolanır ve [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) yöntemi aracılığıyla sunulur.

**Video Çerçevesine Altyazı Ekleme**

Bu örnek yerel bir video gömer ve "English" etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoya uygun olmalıdır. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

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

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) arayüzü, bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme de sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Bu örnek ilk sl ayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Sıralı numaralar çıktı dosyalarının birbirinden farklı olmasını sağlar. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir sl ayt içermelidir.

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

Her [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketi, ikili veriyi ve UTF‑8 dizgesi olarak altyazı metnini sunar.

**Video Çerçevesinden Altyazı Kaldırma**

Bu örnek ilk sl ayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Sl ayt ve şeklin mevcut olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

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

Yalnızca tek bir altyazı izini kaldırmanız gerekiyorsa, [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) yöntemlerini kullanın.

## **Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides gömülü videoları sunumlardan çıkarmanıza olanak tanır.

Bu örnek gömülü videoları her sl ayttan ayrı numaralı ikili dosyalara çıkarır. Bağlantılı videolar atlanır çünkü gömülü veri içermezler. Konsol her videonun MIME tipini ve toplam sayısını yazdırır. Çıktı `.bin` uzantısını kullanır; gerektiğinde bildirilen medya tipine göre değiştirilebilir.

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

[oynatma modu](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (otomatik veya tıklama) ve [döngüleme](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) kontrol edilebilir. Bu seçenekler [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) nesnesinin yöntemleri aracılığıyla sunulur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde ikili veri belgede yer alır ve sunum boyutu dosya boyutu ile orantılı olarak artar. Çevrimiçi bir videoya bağlanıp küçük resim eklediğinizde, sunum video verisi yerine bağlantı ve ön izleme görüntüsünü saklar; bu yüzden boyut artışı genellikle daha az olur.

**Mevcut bir video çerçevesindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. [video içeriğini](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) çerçeve içinde değiştirerek şeklin geometrisini koruyabilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemenin yaygın bir senaryosudur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [içerik türü](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) vardır ve bunu okuyarak örneğin diske kaydederken kullanabilirsiniz.