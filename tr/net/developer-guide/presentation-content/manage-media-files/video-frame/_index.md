---
title: .NET'te Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/net/video-frame/
keywords:
- video ekle
- video oluştur
- video gömme
- video çıkar
- video al
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument slaytlarında video çerçevelerini programlı olarak eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Bir sunumda iyi konumlandırılmış bir video, mesajınızı daha etkileyici hale getirebilir ve izleyicilerinizle etkileşim seviyelerini artırabilir. 

PowerPoint, sunumda bir slayta video eklemenize iki şekilde izin verir:

* Yerel bir videoyu ekleyin veya gömün (makinenizde saklanan)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından). 

Sunumda video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideo/) arabirimini, [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) arabirimini ve diğer ilgili türleri sağlar. 

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizin üzerinden bir slaydın referansını alın.  
1. Bir [IVideo](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideo/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosya yolunu geçirin.  
1. Videoyu bir çerçeveye yerleştirmek için bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. Değiştirilmiş sunumu kaydedin.  

Bu C# kodu, yerel olarak depolanan bir videoyu sunuma nasıl ekleyeceğinizi gösterir:

```c#
// Presentation sınıfının bir örneğini oluşturur
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Videoyu yükler
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // İlk slaytı alır ve bir video çerçevesi ekler
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Sunumu diske kaydeder
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternatif olarak, video dosya yolunu doğrudan [AddVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addvideoframe/) metoduna geçirerek bir video ekleyebilirsiniz:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**
Microsoft [PowerPoint 2013 ve üzeri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi olarak mevcutsa (ör. YouTube'da), web bağlantısı aracılığıyla sunumunuza ekleyebilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
1. Dizin üzerinden bir slaydın referansını alın.  
1. Bir [IVideo](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideo/) nesnesi ekleyin ve videoya ait bağlantıyı geçirin.  
1. Video çerçevesi için bir ön izleme resmi ayarlayın.  
1. Sunumu kaydedin.  

Bu C# kodu, web'den bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

```c#
public static void Run()
{
    // Bir sunum dosyasını temsil eden Presentation nesnesinin bir örneğini oluşturur 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Bir VideoFrame ekler
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Ön izleme resmini yükler
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) özelliği aracılığıyla sunulur.

**Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun.  
1. Sunuma bir video ekleyin.  
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. Bir WebVTT altyazı izi eklemek için [CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) koleksiyonunu kullanın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, bir video çerçevesine altyazı eklemenin nasıl yapılacağını gösterir:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // WebVTT dosyasından yeni bir altyazı izi ekler.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptionscollection/) arabirimi ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesini bulun.  
1. [CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) koleksiyonunda döngü yapın.  
1. Her altyazı izini bir `.vtt` dosyasına kaydedin.  

Aşağıdaki kod, bir video çerçevesinden altyazı çıkarmanın nasıl yapılacağını gösterir:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Altyazı izini bir WebVTT dosyasına kaydeder.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Her bir [ICaptions](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptions/) nesnesi altyazı kimliğini, etiketini, ikili veriyi ve altyazı metnini UTF-8 dizesi olarak sunar.

**Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesini alın.  
1. [CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) koleksiyonundan altyazı izlerini kaldırın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, bir video çerçevesinden tüm altyazıları kaldırmanın nasıl yapılacağını gösterir:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Video çerçevesindeki tüm altyazıları kaldırır.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Yalnızca tek bir altyazı izini kaldırmanız gerekiyorsa, [Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/captionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/captionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/captionscollection/removeat/) metodlarını kullanın.

## **Slayttan Video Çıkarma**
Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlara gömülü videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfı örneği oluşturun.  
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide) nesnelerinde dolaşın.  
3. Bir [VideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe) bulmak için tüm [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) nesnelerinde dolaşın.  
4. Videoyu diske kaydedin.  

Bu C# kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```c#
// Bir sunum dosyasını temsil eden Presentation nesnesinin bir örneğini oluşturur
Presentation presentation = new Presentation("Video.pptx");

// Slaytlar arasında döner
foreach (ISlide slide in presentation.Slides)
{
    // Şekiller arasında döner
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Video içeren VideoFrame bulunduğunda videoyu diske kaydeder
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **SSS**

**Bir VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**  
[playback mode](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/playmode/) (otomatik veya tıklama) ve [looping](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/playloopmode/) kontrol edilebilir. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılır.  

**Video eklemek PPTX dosya boyutunu etkiler mi?**  
Evet. Yerel bir video gömülürken ikili veri belgeye eklenir, bu yüzden sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde bir bağlantı ve ön izleme resmi gömülür, bu nedenle boyut artışı daha azdır.  

**Mevcut bir VideoFrame'deki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**  
Evet. Çerçeve içindeki [video content](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/embeddedvideo/) değiştirilebilir, şeklin geometrisi korunur; bu, mevcut bir yerleşimde medyanın güncellenmesi için yaygın bir senaryodur.  

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**  
Evet. Gömülü bir videonun okunup kullanılabilecek bir [content type](https://reference.aspose.com/slides/tr/net/aspose.slides/video/contenttype/) vardır, örneğin diske kaydederken.