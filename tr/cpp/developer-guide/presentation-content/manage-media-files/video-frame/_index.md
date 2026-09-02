---
title: Sunumlarda Video Çerçevelerini C++ ile Yönetme
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

Bir sunumda yerleştirilen iyi bir video, mesajınızı daha etkileyici hâle getirebilir ve izleyicilerinizle etkileşim seviyesini artırabilir. 

PowerPoint, bir sunumdaki bir slayta videoları iki şekilde eklemenizi sağlar:

* Yerel bir video ekleyin veya gömün (bilgisayarınızda depolanan)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Sunuma video nesneleri eklemenizi sağlamak için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sağlar. 

## **Gömülü Bir Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Bir slaytın referansını indeksine göre alın.  
1. Bir [IVideo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideo/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosyası yolunu geçirin.  
1. Videoya bir çerçeve oluşturmak için bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. Değiştirilmiş sunumu kaydedin.  

Bu C++ kodu, yerel olarak depolanmış bir videoyu sunuma nasıl ekleyeceğinizi gösterir:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

Alternatif olarak, videoyu doğrudan dosya yolunu [AddVideoFrame()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addvideoframe/) metoduna geçirerek ekleyebilirsiniz:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Web Kaynağından Video ile Bir Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) yeni sürümleri, sunumlardaki çevrimiçi videoları destekler. Kullanmak istediğiniz video çevrimiçi olarak (ör. YouTube’da) mevcutsa, web bağlantısı aracılığıyla sunumunuza ekleyebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Bir slaytın referansını indeksine göre alın.  
1. Bir [IVideo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideo/) nesnesi ekleyin ve videonun bağlantısını geçirin.  
1. Video çerçevesi için bir küçük resim ayarlayın.  
1. Sunumu kaydedin.  

Bu C++ kodu, bir web kaynağından video ekleyerek PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

```c++
// Belgeler dizininin yolu.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// İlk slayta erişir
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Bir Video Çerçevesi ekler 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Videonun Oynatma Modu ve Ses seviyesini ayarlar
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Sunumu diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bir Video Çerçevesini Kırpma**

Aspose.Slides, bir videonun hangi bölümünün oynatılacağını [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/set_trimfromstart/) ve [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/set_trimfromend/) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayarak kontrol etmenizi sağlar. Her iki değer de milisaniye cinsindendir ve videonun başından ve sonundan atlanan süreyi belirtir. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya değiştirmez.

**Kırpma Ayarlarını Ayarlama**

Bir video çerçevesi oluşturmak ve kırpma ayarlarını belirlemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunuma bir [IVideo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideo/) nesnesi ekleyin.  
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/set_trimfromstart/) ve [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/set_trimfromend/) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod örneği, gömülü bir videonun oynatılması sırasında ilk 2,5 saniyeyi ve son bir saniyeyi atlar:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Kırpma Ayarlarını Okuma**

Mevcut kırpma ayarlarını incelemek için bir sunumu yükleyin, ilk slayttaki şekiller arasında bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesi bulun ve değerleri [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_trimfromstart/) ve [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_trimfromend/) aracılığıyla okuyun.

Aşağıdaki kod örneği, ilk slayttaki ilk video çerçevesini bulur ve kırpma ayarlarını milisaniye cinsinden raporlar:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) yöntemi aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunuma bir video ekleyin.  
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) tarafından döndürülen [ICaptionsCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/)’ı kullanarak bir WebVTT altyazı izini ekleyin.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, bir video çerçevesine nasıl altyazı ekleyeceğinizi gösterir:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// WebVTT dosyasından yeni bir altyazı izi ekler.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesini bulun.  
1. [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) tarafından döndürülen altyazı izleri üzerinde döngü oluşturun.  
1. Her altyazı izini bir `.vtt` dosyasına kaydedin.  

Aşağıdaki kod, bir video çerçevesinden altyazı nasıl çıkarılacağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Altyazı izini bir WebVTT dosyasına kaydeder.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Her [ICaptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptions/) nesnesi, altyazı kimliği, etiketi, ikili verisi ve UTF-8 dizgesi olarak altyazı verisini ortaya koyar.

**Bir Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesini alın.  
1. [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) tarafından döndürülen koleksiyondan altyazı izlerini kaldırın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, bir video çerçevesindeki tüm altyazıların nasıl kaldırılacağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Video çerçevesinden tüm altyazıları kaldırır.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/removeat/) metodlarını kullanın.

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) nesneleri üzerinde döngü oluşturun.  
3. Tüm [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesneleri arasında bir [VideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/) bulmak için gezin.  
4. Videoyu diske kaydedin.  

Bu C++ kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```c++
// Belgeler dizininin yolu.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **SSS**

**Bir VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**  
[playback mode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/set_playmode/) (otomatik veya tıklamayla) ve [looping](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/set_playloopmode/) kontrol edilebilir. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla mevcuttur.

**Video eklemek PPTX dosya boyutunu etkiler mi?**  
Evet. Yerel bir video gömülürken ikili veri belgeye dahil edilir, bu yüzden sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde ise bir bağlantı ve küçük resim gömülür, bu nedenle boyut artışı daha azdır.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**  
Evet. Çerçeve içindeki [video content](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/set_embeddedvideo/) değiştirilebilir, şeklin geometrisi korunur; bu, mevcut bir yerleşimde medyanın güncellenmesi için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**  
Evet. Gömülü bir videonun okunup kullanılabilecek bir [content type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/video/get_contenttype/) vardır, örneğin diske kaydedildiğinde.