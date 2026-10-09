---
title: .NET’te Sunumlarda Video Çerçevelerini Yönetme
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
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument slaytlarında programlı bir şekilde video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve bir izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for .NET, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını ayarlamanızı, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve YouTube videoları gibi çevrimiçi videolara bağlantıları destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sağlar.

## **Gömülü Bir Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme tamamlanana kadar açık kalır çünkü [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) sunum kullandığı sürece akışı kilitli tutar.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Yerel video yolunu doğrudan [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) metoduna da iletebilirsiniz. Bu örnek, yeni bir sunumun ilk slaytına videoyu gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Web Kaynağından Video ile Bir Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube videosu gibi çevrimiçi bir videoya bağlantı veren bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve küçük resim ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) ayarı otomatik oynatmayı talep eder. Küçük resmin indirilmesi ve videonun oynatılması internet erişimi gerektirir. Sunum görüntüleyicisi de çevrimiçi video oynatımını desteklemelidir.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Bir Videoyu Tam Ekran Modunda Oynatma**

Bir eğitim sunumunda, izleyicilerin detayları görebilmesi için bir yazılım demonstrasyonunu tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) `true` olarak ayarlayın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

Tam ekran oynatma, videonun nasıl gösterileceğini kontrol eder. Bağımsız olarak, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) videonun otomatik mi yoksa tıklamayla mı başlayacağını, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ise tekrar edip etmeyeceğini kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.Auto veya VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Bir eğitim sunumunda, bir demonstrasyon videosunu başlangıcına döndürmek, sunucunun videoyu tekrar oynatmasını hazır hâle getirir. Oynatma bittiğinde videoyu başa döndürmek için [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) `true` olarak ayarlayın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Oynatmanın bitmesi için döngüyü devre dışı bırakır ve oynatmayı tıklamayla başlatır. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Geri sarmak, videoyu yeniden başlatmadan başına döndürür. Bunun tersine, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) etkinleştirildiğinde oynatma otomatik olarak tekrarlanır. Videonun bitmesini ve tekrar oynatılmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) otomatik ya da tıklamayla başlangıcı bağımsız olarak kontrol eder; bu örnek, oynatmanın ne zaman başlayacağını sunucunun kontrol etmesi için [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) kullanır. Örnekte gösterildiği gibi döngü ayarından sonra oynatma modu ayarlanır. Geri sarmak, [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/)’dan bağımsız çalışır.

## **Bir Video Çerçevesini Budama**

[IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) ve [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) kullanarak oynatma sırasında videonun başlangıç ya da son kısmını atlayabilirsiniz. Her iki değer milisaniye cinsindendir. Budama, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Trim Ayarlarını Ayarla**

Bu örnek, yerel bir video gömer ve oynatma sırasında ilk 2,5 saniye ile son bir saniyeyi atlar. Oynanabilir bir bölüm kalması için 3,5 saniyeden uzun bir video kullanın.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Trim Ayarlarını Okuma**

Bu örnek, ilk slayttaki ilk video çerçevesinin trim değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer o slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenize olanak tanır. Altyazılar WebVTT biçiminde depolanır ve [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) özelliği aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve 'English' etiketiyle bir WebVTT altyazı izini ekler. Altyazı zaman damgaları videoyla eşleşmelidir. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Ardışık sayılar çıkış dosyalarını ayrı tutar. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir slayt içermelidir.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Her [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF-8 dizesi olarak sunar.

**Bir Video Çerçevesinden Altyazıları Kaldırma**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin var olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Sadece bir altyazı izini kaldırmanız gerekiyorsa, [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) yöntemlerini kullanın.

## **Bir Slayttan Video Çıkarma**

Slaytlara video eklemenin yanı sıra, Aspose.Slides sunumlara gömülü videoları çıkarmanıza da olanak tanır.

Bu örnek, her slayttan gömülü videoları ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar gömülü veri içermediği için atlanır. Konsol, her videonun MIME tipini ve toplam sayısını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde bildirilen medya tipine uygun olarak değiştirin.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **SSS**

**Bir video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**

Oynatma modunu (otomatik veya tıklamayla) ve döngüyü [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/), [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla mevcuttur.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde ikili veri belgeye dahil edilir, bu yüzden sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir videoya bağlanıp bir küçük resim eklediğinizde sunum, video verisi yerine bağlantıyı ve ön izleme görüntüsünü saklar, bu yüzden boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçeve içindeki [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) öğesini şeklin geometrisini koruyarak değiştirebilirsiniz; bu, mevcut bir yerleşimde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okuma ve örneğin diske kaydederken kullanabileceğiniz bir [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) vardır.