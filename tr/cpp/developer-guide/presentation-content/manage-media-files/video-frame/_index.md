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
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument slaytlarında video çerçevelerini programlı olarak eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Sunumda iyi yerleştirilmiş bir video, mesajınızı daha etkileyici hale getirebilir ve izleyicilerinizle etkileşim seviyesini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenizi iki şekilde sağlar:

* Yerel bir video ekleyin veya gömün (makinenizde depolanmış)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından). 

Bir sunuma videolar (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sunar. 

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunuma gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın. 
1. [IVideo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideo/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosyasının yolunu geçirin. 
1. [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesi ekleyerek video için bir çerçeve oluşturun.  
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

Alternatif olarak, videoyu doğrudan dosya yolunu [AddVideoFrame()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addvideoframe/) yöntemine geçirerek ekleyebilirsiniz:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint 2013 ve sonrası](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sürümleri, sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi olarak mevcutsa (ör. YouTube’da), web bağlantısı aracılığıyla sunuma ekleyebilirsiniz. 

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun
1. Bir slaydın referansını indeksine göre alın. 
1. [IVideo](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideo/) nesnesi ekleyin ve videonun bağlantısını geçirin.
1. Video çerçevesi için bir küçük resim ayarlayın. 
1. Sunumu kaydedin. 

Bu C++ kodu, web üzerindeki bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

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

// Videonun Oynatma Modu ve Ses Düzeyini ayarlar
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Sunumu diske kaydeder
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) yöntemi aracılığıyla sunulur.

**Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Sunuma bir video ekleyin.
1. Bir slayta [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesi ekleyin.
1. [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) tarafından döndürülen [ICaptionsCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/) kullanarak bir WebVTT altyazı izi ekleyin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesine altyazı nasıl ekleneceğini gösterir:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.
2. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesini bulun.
3. [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) tarafından döndürülen altyazı izleri arasında döngü yapın.
4. Her bir altyazı izini bir `.vtt` dosyasına kaydedin.

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

Her [ICaptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı verisini UTF-8 dizesi olarak sunar.

**Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.
2. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/) nesnesini alın.
3. [get_CaptionTracks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ivideoframe/get_captiontracks/) tarafından döndürülen koleksiyondan altyazı izlerini kaldırın.
4. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesinden tüm altyazıların nasıl kaldırılacağını gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Video çerçevesindeki tüm altyazıları kaldırır.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [Clear](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icaptionscollection/removeat/) yöntemlerini kullanın.

## **Bir Slayttan Video Çıkarma**

Slaytlara video eklemenin yanı sıra, Aspose.Slides sunumlara gömülmüş videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının örneğini oluşturun. 
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islide/) nesneleri üzerinde döngü yapın.
3. Bir [VideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/) bulmak için tüm [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesneleri üzerinde döngü yapın. 
4. Videoyu diske kaydedin.

Bu C++ kodu, sunum slaytındaki videoyu nasıl çıkaracağınızı gösterir:

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

Oynatma modunu ([playback mode](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/set_playmode/) – otomatik veya tıklamayla) ve döngüyü ([looping](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/set_playloopmode/)) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir videoyu gömdüğünüzde, ikili veri belgeye eklenir ve bu nedenle sunumun boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde ise bir bağlantı ve küçük resim gömülür, bu nedenle boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevedeki [video content](https://reference.aspose.com/slides/tr/cpp/aspose.slides/videoframe/set_embeddedvideo/) öğesini, şeklin geometrisini koruyarak değiştirebilirsiniz; bu, mevcut bir yerleşimde medyanın güncellenmesi için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okuyabileceğiniz ve örneğin diske kaydederken kullanabileceğiniz bir [content type](https://reference.aspose.com/slides/tr/cpp/aspose.slides/video/get_contenttype/) (içerik türü) vardır.