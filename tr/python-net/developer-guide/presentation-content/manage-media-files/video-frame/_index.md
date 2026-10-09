---
title: Python'da Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/python-net/video-frame/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument slaytlarında video çerçevelerini programlı olarak eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve bir izleyiciyi çekmeye yardımcı olabilir. Aspose.Slides for Python via .NET, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını ayarlamanızı, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve YouTube videoları gibi çevrimiçi videolara bağlantıları destekler.

Video verilerini ve video çerçevelerini temsil etmek için, Aspose.Slides [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) sınıfını ve diğer ilgili türleri sağlar.

## **Gömülü Video Çerçevesi Oluşturma**

Slaydınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme tamamlanana kadar açık kalır çünkü [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) sunum kullanıldığı sürece kilitli tutar.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Yerel bir video yolunu doğrudan [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) işlevine de geçirebilirsiniz. Bu örnek, yeni bir sunumun ilk slaytına videoyu gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube videosu gibi çevrimiçi bir videoya bağlanan bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve küçük resim ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ayarı otomatik oynatımı talep eder. Küçük resmi indirmek ve videoyu oynatmak internet erişimi gerektirir. Sunum görüntüleyicisi ayrıca çevrimiçi video oynatımını desteklemelidir.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Videoyu Tam Ekran Modunda Oynatma**

Bir eğitim sunumunda, izleyicilerin detayları görebilmesi için bir yazılım demosunu tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) değerini `True` olarak ayarlayın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

Tam ekran oynatma, videonun nasıl gösterileceğini kontrol eder. Bağımsız olarak, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) otomatik mi yoksa tıklamayla mı başlayacağını ve [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) tekrar edip etmeyeceğini denetler. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Bir eğitim sunumunda, gösterim videosunu başına geri döndürmek, sunumcunun videoyu tekrar oynatmaya hazır olmasını sağlar. Oynatma bittiğinde videoyu başa döndürmek için [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) değerini `True` olarak ayarlayın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Oynatmanın bitmesi için döngüyü devre dışı bırakır ve oynatmayı tıklamayla başlamaya ayarlar. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Geri sarmak, videoyu tekrar başlatmadan başına döndürür. Buna karşılık, [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) etkinleştirildiğinde oynatma otomatik olarak tekrar eder. Videonun bitmesini ve yeniden oynatmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) bağımsız olarak otomatik ya da tıklamayla başlatmayı kontrol eder; bu örnek, oynatmanın ne zaman başlayacağını sunumcunun kontrol etmesi için [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) kullanır. Örnekte gösterildiği gibi döngü ayarından sonra oynatma modu ayarlanır. Geri sarmak, [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/)’dan bağımsız çalışır.

## **Video Çerçevesini Kırpma**

[VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) ve [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) kullanarak oynatma sırasında videonun başlangıcının veya sonunun bir kısmını atlayabilirsiniz. Her iki değer milisaniye cinsindedir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir video gömer ve oynatma sırasında ilk 2,5 saniyeyi ve son bir saniyeyi atlar. Oynanabilir bir segment kalması için 3,5 saniyeden uzun bir video kullanın.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Kırpma Ayarlarını Okuma**

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer o slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) özelliği aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve İngilizce etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoyla eşleşmelidir. Kaydedilen sunum, videoyu ve altyazılarını içerir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) sınıfı ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Ardışık numaralar çıktı dosyalarının farklı olmasını sağlar. Konsol, çıkarılan iz sayısını rapor eder. Sunum en az bir slayt içermelidir.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Her [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketi, ikili veriyi ve altyazı metnini UTF-8 dizesi olarak sunar.

**Bir Video Çerçevesinden Altyazı Kaldırma**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin mevcut olduğu ve şeklin bir video çerçevesi olduğu varsayılır.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) yerine [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) veya [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) yöntemlerini kullanın.

## **Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

Bu örnek, her slayttan gömülü videoları ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri olmadığından atlanır. Konsol, her videonun MIME türünü ve toplam sayısını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde rapor edilen medya türüne uygun olarak değiştirin.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **SSS**

**Bir video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**

Video çerçevesinin [oynatma modu](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (otomatik ya da tıklamayla) ve [döngü](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) (döngü) parametrelerini kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir ve sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir videoya bağlanıp bir küçük resim eklediğinizde, sunum videoyu değil bağlantıyı ve önizleme görüntüsünü depolar; bu nedenle boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevenin içindeki [video içeriği](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) değiştirerek şeklin geometriğini koruyabilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [içerik türü](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) vardır ve bunu okuyup, örneğin diske kaydederken kullanabilirsiniz.