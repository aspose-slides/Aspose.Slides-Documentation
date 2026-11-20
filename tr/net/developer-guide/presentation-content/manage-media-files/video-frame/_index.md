---
title: ".NET'te Sunumlarda Video Çerçevelerini Yönetme"
linktitle: "Video Çerçevesi"
type: docs
weight: 10
url: /tr/net/video-frame/
keywords:
- "video ekle"
- "video oluştur"
- "video göm"
- "video çıkar"
- "video al"
- "video çerçevesi"
- "web kaynağı"
- "PowerPoint"
- "OpenDocument"
- "sunum"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for .NET, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını düzenlemenizi, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve YouTube videoları gibi çevrimiçi videoların bağlantılarını destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sağlar.

## **Gömülü Bir Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları point birimindedir. Akış, kaydetme tamamlanana kadar açık kalır çünkü [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) sunum kullanılırken akışı kilitli tutar.

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

Yerel video yolunu doğrudan [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) yöntemine de aktarabilirsiniz. Bu örnek, videoyu yeni bir sunumun ilk slaytına gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Video Sesini Hassas Bir Şekilde Ayarlama**

Aspose.Slides for .NET 26.11 veya daha yeni sürümlerde, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) 0 ile 100 arasında kayan noktalı bir yüzde ayarlar. [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) ön ayarları çok kaba olduğunda bunu kullanın. Örneğin, `75.5f` %75,5 ses ister.

Bu örnek, [Aspose.Slides for .NET](/slides/tr/net/installation/) 26.11 veya daha yeni bir sürüm ve yerel bir `video.mp4` dosyası gerektirir. Videoyu gömer, oynatmayı açıkça başlatır, sunumu kaydeder ve saklanan yüzdeyi geri okur.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Girişi kendiniz doğrulayın; ayarlayıcının belge dışı değerleri reddetmesine güvenmeyin. 26.11 sürümünde Düşük, Orta ve Yüksek ön ayarları sırasıyla 20, 50 ve 80 değerlerine karşılık gelir. Bir ön ayar ayarlamak önceki yüzdeyi değiştirebilir, bu yüzden kesin bir değere ihtiyacınız olduğunda yüzdeyi en son atayın. Açık sessiz ayarı için [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) kullanın; sayısal sıfır ve ön ayar enumu birbirinin yerine geçebilen durumlar değildir.

Bağlantılı bir video yapılandırırken de [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) özelliğini açıkça ayarlayın ve medya dosyasını izleyiciye erişilebilir tutun. Kaydetme ve yeniden açma, saklanan ayarı doğrular; gerçek oynatma ve ses seviyesi, sunum oynatıcıya ve onun ses ayarlarına bağlıdır.

## **Web Kaynağından Video ile Bir Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube videosu gibi çevrimiçi bir videoya bağlanan bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve küçük resmi ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) ayarı otomatik oynatmayı talep eder. Küçük resmi indirmek ve videoyu oynatmak internet erişimi gerektirir. Sunum görüntüleyicisi de çevrimiçi video oynatmayı desteklemelidir.

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

## **Videoyu Tam Ekran Modunda Oynatma**

Bir eğitim sunumunda, izleyicilerin detayları görebilmesi için bir yazılım gösterimini tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) özelliğini `true` olarak ayarlayın.

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

Tam ekran oynatma, videonun nasıl görüntüleneceğini kontrol eder. Bağımsız olarak, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) videonun otomatik mi yoksa tıklamayla mı başlayacağını, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ise tekrar edip etmeyeceğini belirler. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.Auto veya VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Bir eğitim sunumunda, gösterim videosunu başlangıcına döndürmek, sunumcunun videoyu tekrar oynatmaya hazır hale gelmesini sağlar. Oynatma bittiğinde videoyu başa döndürmek için [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) özelliğini `true` olarak ayarlayın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Oynatmanın bitebilmesi için döngüyü devre dışı bırakır ve oynatmayı tıklamayla başlamasını ayarlar. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

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

Geri sarmak, videoyu tekrar başlatmadan başa döndürür. Buna karşılık, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) etkinleştirildiğinde oynatma otomatik olarak tekrarlanır. Videonun bitmesini ve tekrar oynatılmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) bağımsız olarak otomatik veya tıklamayla başlangıcı kontrol eder; bu örnek, oynatmanın ne zaman başlayacağını sunumcunun kontrol etmesi için [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) kullanır. Döngü ayarından sonra oynatma modunu ayarlayın, örnekte gösterildiği gibi. Geri sarma, [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) özelliğinden bağımsız olarak çalışır.

## **Bir Video Çerçevesini Kırpma**

[IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) ve [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) kullanarak oynatma sırasında bir videonun başlangıcının veya sonunun bir kısmını atlayabilirsiniz. Her iki değer milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir videoyu gömer ve oynatma sırasında ilk 2,5 saniyeyi ve son saniyeyi atlar. Oynanabilir bir bölüm kalması için videonun 3,5 saniyeden uzun olmasını sağlayın.

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

**Kırpma Ayarlarını Okuma**

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

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

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenize olanak tanır. Altyazılar WebVTT formatında saklanır ve [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) özelliği aracılığıyla erişilebilir.

### **Bir Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve İngilizce etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoyla eşleşmelidir. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

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

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) arabirimi ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

### **Bir Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Sıralı sayılar, çıktı dosyalarının birbirinden farklı olmasını sağlar. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir slayt içermelidir.

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

Her [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili veriyi ve altyazı metnini UTF-8 dizesi olarak ortaya çıkarır.

### **Bir Video Çerçevesinden Altyazı Kaldırma**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin mevcut olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

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

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) yerine [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) veya [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) yöntemlerini kullanın.

### **Video Altyazılarını Arama**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) tam WebVTT izini, başlığı, zaman çizgilerini ve altyazı metnini döndürür. Konuşulan bir ifadeyi ve zaman damgasını bulmak için ipuçlarını bellekte okuyun. Örneğin, 2. slaydın bir İngilizce izi aşağıdaki metni içerebilir:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Örnek, her slaytı ziyaret eder ve üst düzey video çerçevelerinin izlerini [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) aracılığıyla okur. Düz metin ipucunda zaman çizgisi `-->` içerir ve boş bir satır ipucunu sonlandırır. Altyazı metni “café” içerdiğinde örnek, slayt numarasını, iz etiketini, orijinal zaman çizgisini ve tam altyazıyı yazdırır.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

“café” araması, örnek iz için bir eşleşme üretir. Başlık ve zaman ayarı ipucu metninin dışındadır.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Bir Slayttan Video Çıkarma**

Slaytlara video eklemenin yanı sıra, Aspose.Slides sunumlara gömülmüş videoları çıkarmanıza da olanak tanır.

Bu örnek, her slayttan gömülü videoları ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri olmadığından atlanır. Konsol, her videonun MIME tipini ve toplam sayısını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde bildirilen medya tipine uyması için uzantıyı değiştirin.

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
[playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (otomatik veya tıklama) ve [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla mevcuttur.

**Video eklemek PPTX dosya boyutunu etkiler mi?**  
Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir ve bu nedenle sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir videoya bağlandığınızda ve bir küçük resim eklediğinizde, sunum video verisi yerine bağlantıyı ve ön izleme görüntüsünü saklar; bu yüzden boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**  
Evet. Çerçevenin içindeki [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) öğesini şeklin geometrisini koruyarak değiştirebilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**  
Evet. Gömülü bir videonun, örneğin diske kaydederken kullanabileceğiniz bir [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) vardır ve bunu okuyabilirsiniz.