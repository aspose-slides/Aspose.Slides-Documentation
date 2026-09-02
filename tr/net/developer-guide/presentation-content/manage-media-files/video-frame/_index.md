---
title: .NET'te Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Sunumda iyi yerleştirilmiş bir video, mesajınızı daha etkileyici kılabilir ve izleyicilerinizle etkileşim seviyelerini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenize iki şekilde izin verir:

* Yerel bir video ekleyin veya gömün (makinenizde depolanmış)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Sunuma video (video nesneleri) eklemenizi sağlamak için, Aspose.Slides [IVideo](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sağlar. 

## **Gömülü Video Çerçevesi Oluşturma**

Yerel olarak saklanan bir video dosyasını slaydınıza eklemek istiyorsanız, sunuma videoyu gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeks üzerinden alın.  
1. Bir [IVideo](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideo/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosya yolunu geçirin.  
1. Videoyu çerçevelemek için bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. Değiştirilmiş sunumu kaydedin.  

Bu C# kodu, yerel olarak depolanmış bir videoyu sunuma nasıl ekleyeceğinizi gösterir:

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
Alternatif olarak, videoyu dosya yolunu doğrudan [AddVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addvideoframe/) yöntemine geçirerek ekleyebilirsiniz:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**
Yeni Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sürümleri, sunumlarda çevrimiçi videoları destekler. Kullanmak istediğiniz video çevrimiçi (ör. YouTube) mevcutsa, web bağlantısı aracılığıyla sunuma ekleyebilirsiniz.

1. [Presentation ](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeks üzerinden alın.  
1. Bir [IVideo](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideo/) nesnesi ekleyin ve videoya bağlantıyı geçirin.  
1. Video çerçevesi için bir küçük resim ayarlayın.  
1. Sunumu kaydedin.  

Bu C# kodu, web üzerindeki bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

```c#
public static void Run()
{
    // Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
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

    // Küçük resmi yükler
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Video Çerçevesini Kırpma**

Aspose.Slides, bir videonun oynatılacak kısmını [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/trimfromstart/) ve [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/trimfromend/) aracılığıyla ayarlayarak kontrol etmenizi sağlar. Her iki değer de milisaniye cinsindendir ve videonun başından ve sonundan atlanacak zamanı tanımlar. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya başka bir şekilde değiştirmez.

**Kırpma Ayarlarını Belirleme**

Bir video çerçevesi oluşturup kırpma ayarlarını belirlemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunuma bir [IVideo](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideo/) nesnesi ekleyin.  
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/trimfromstart/) ve [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/trimfromend/) aracılığıyla kırpma değerlerini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod örneği, bir gömülü videonun oynatılması sırasında ilk 2,5 saniyeyi ve son bir saniyeyi atlar:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Kırpma Ayarlarını Okuma**

Mevcut kırpma ayarlarını incelemek için bir sunumu yükleyin, ilk slaydın şekilleri arasındaki bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesini bulun ve değerleri [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/trimfromstart/) ve [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/trimfromend/) üzerinden okuyun.

Aşağıdaki kod örneği, ilk slayttaki ilk video çerçevesini bulur ve kırpma ayarlarını milisaniye olarak raporlar:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) özelliği aracılığıyla erişilebilir.

**Video Çerçevesine Altyazı Ekleme**

Video çerçevesine altyazı eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunuma bir video ekleyin.  
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. [CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) koleksiyonunu kullanarak bir WebVTT altyazı izini ekleyin.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, bir video çerçevesine altyazı eklemenizi gösterir:

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

[ICaptionsCollection](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesini bulun.  
1. [CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) koleksiyonunda gezinin.  
1. Her altyazı izini bir `.vtt` dosyasına kaydedin.  

Aşağıdaki kod, bir video çerçevesinden altyazı çıkarmanızı gösterir:

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

Her [ICaptions](https://reference.aspose.com/slides/tr/net/aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF-8 dizesi olarak ortaya koyar.

**Video Çerçevesinden Altyazı Kaldırma**

Video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/) nesnesini alın.  
1. [CaptionTracks](https://reference.aspose.com/slides/tr/net/aspose.slides/ivideoframe/captiontracks/) koleksiyonundan altyazı izlerini kaldırın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, bir video çerçevesindeki tüm altyazıları nasıl kaldıracağınızı gösterir:

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

Yalnızca tek bir altyazı izini kaldırmak istiyorsanız, [Clear](https://reference.aspose.com/slides/tr/net/aspose.slides/captionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/tr/net/aspose.slides/captionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/tr/net/aspose.slides/captionscollection/removeat/) yöntemlerini kullanın.

## **Slayttan Video Çıkarma**
Video eklemenin yanı sıra, Aspose.Slides sunumlardaki gömülü videoları çıkarmanıza da izin verir.

1. Video içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/net/aspose.slides/islide) nesnelerinde gezin.  
3. [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape) nesnelerinde gezinerek bir [VideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe) bulun.  
4. Videoyu diske kaydedin.  

Bu C# kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```c#
// Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
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

## **FAQ**

**Bir VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/playmode/) (otomatik ya da tıklama) ve [looping](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/playloopmode/) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömülürse, ikili veri belgeye dahil edilir ve sunum boyutu dosya boyutu ile orantılı olarak artar. Çevrimiçi bir video eklenirse, bir bağlantı ve bir küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame’deki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçeve içindeki [video content](https://reference.aspose.com/slides/tr/net/aspose.slides/videoframe/embeddedvideo/) değiştirilirken şeklin geometrisi korunur; bu, mevcut bir düzenin medyasını güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okunup kullanılabilecek bir [content type](https://reference.aspose.com/slides/tr/net/aspose.slides/video/contenttype/) vardır, örneğin diske kaydederken.