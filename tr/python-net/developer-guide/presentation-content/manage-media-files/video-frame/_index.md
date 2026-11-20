---
title: Sunumlarda Video Çerçevelerini Python ile Yönetme
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
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı nasıl‑yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya yardımcı olabilir ve izleyiciyi dahil edebilir. Aspose.Slides for Python via .NET, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını ayarlamanızı, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve YouTube videoları gibi çevrimiçi videolara bağlantıları destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) sınıfını ve diğer ilgili türleri sağlar.

## **Gömülü Bir Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanmışsa, sunumunuzda videoyu gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme tamamlanana kadar açıktır çünkü [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) sunum tarafından kullanılırken kilitli kalmasını sağlar.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Yerel bir video yolunu doğrudan [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/) yöntemine de geçirebilirsiniz. Bu örnek, yeni bir sunumun ilk slaytına videoyu gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube videosu gibi bir çevrimiçi videoya bağlantı veren bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve önizleme görseli ekler. Başka bir video kullanmak için video kimliğini değiştirin. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) ayarı otomatik oynatmayı talep eder. Önizleme görselinin indirilmesi ve videonun oynatılması internet erişimi gerektirir. Sunum görüntüleyicisinin de çevrimiçi video oynatımını desteklemesi gerekir.

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

## **Tam Ekran Modunda Video Oynatma**

Eğitim sunumunda, izleyicinin ayrıntıları görebilmesi için bir yazılım demosunu tam ekran modunda oynatabilirsiniz. Bu davranışı oynatma sırasında etkinleştirmek için [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) özelliğini `True` yapın.

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

Tam ekran oynatma, videonun nasıl görüntüleneceğini denetler. Bağımsız olarak, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) otomatik mi yoksa tıklamayla mı başlayacağını, [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) ise tekrarlayıp tekrarlamayacağını kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sar**

Eğitim sunumunda, bir demo videosunu başa döndürmek, sunumu yapan kişinin videoyu tekrar oynatmasını hazır hâle getirir. Oynatma tamamlandıktan sonra videoyu başa döndürmek için [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) özelliğini `True` yapın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Döngüyü devre dışı bırakır, böylece oynatma tamamlanabilir ve tıklamayla başlamasını ayarlar. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

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

Geri sarma, videoyu tekrar başlatmadan başlangıç noktasına getirir. Buna karşılık, [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) etkinleştirildiğinde oynatma otomatik olarak tekrarlanır. Videoyu bitirip tekrar oynatmaya hazır tutmak istediğinizde döngüyü devre dışı bırakın. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) bağımsız olarak otomatik ya da tıklamayla başlangıcı denetler; bu örnek, sunumu yapan kişinin ne zaman oynatmaya başlayacağını kontrol etmesi için [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) kullanır. Döngü ayarından sonra oynatma modunu ayarlayın, örnekte gösterildiği gibi. Geri sarma, [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) özelliğinden bağımsız çalışır.

## **Video Çerçevesini Kırpma**

[VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) ve [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) kullanarak bir videonun başından ya da sonundan bir kısmını oynatma sırasında atlayabilirsiniz. Her iki değer de milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir videoyu gömer ve oynatma sırasında ilk 2,5 saniyeyi ve son bir saniyeyi atlar. Oynatılabilir bir segment kalması için 3,5 saniyeden uzun bir video kullanın.

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

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

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

### **Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve “English” etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoya uygun olmalıdır. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

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

### **Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyalarına kaydeder. Sıralı sayılar, çıktı dosyalarının farklı olmasını sağlar. Konsol, çıkarılan iz sayısını bildirir. Sunum en az bir slayt içermelidir.

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

Her [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve UTF‑8 dizesi olarak altyazı metnini sunar.

### **Video Çerçevesinden Altyazı Silme**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin var olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Yalnızca tek bir altyazı izini silmek istiyorsanız, [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) yerine [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) veya [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) yöntemlerini kullanın.

### **Video Altyazılarını Arama**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) tüm WebVTT izini, başlık, zaman satırları ve altyazı metni dahil olmak üzere döndürür. Örneğin, ikinci slayttaki bir İngilizce iz şu ipucu içerebilir:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Bu örnek `captioned_media.pptx` dosyasını açar ve her slayttaki üst‑düzey video çerçevelerinin [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) izlerini okur. Düz metin ipuçları için `-->` içeren zaman satırını bulur ve bir sonraki boş satıra ya da iz sonuna kadar olan altyazı satırlarını toplar. Altyazı metninde “café” sözcüğünü büyük/küçük harf duyarsız olarak arar ve eşleşen her satır için slayt numarasını, iz etiketini, orijinal zaman satırını ve tam altyazıyı yazar.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue

                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)

                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

Örnek iz bir eşleşme üretir. Başlıktaki “Café” altyazı metni dışındadır ve çıktı zaman ayarını ve her iki altyazı satırını korur.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da izin verir.

Bu örnek, her slayttan gömülü videoları ayrı numaralı ikili dosyalara çıkarır. Bağlantılı videolar atlanır çünkü gömülü veri içermezler. Konsol her videonun MIME tipini ve toplam sayısını yazar. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde bildirilen medya tipine göre uzantıyı değiştirebilirsiniz.

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

[playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (otomatik veya tıklamayla) ve [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) kontrol edilebilir. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla sunulur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömülürse, ikili veri belgeye dahil edilir ve sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video bağlantısı ve önizleme görseli eklenirse, sunum yalnızca bağlantıyı ve önizleme görselini saklar; bu genellikle daha az boyut artışı demektir.

**Mevcut bir video çerçevesindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevenin içinde [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) değiştirilirken şeklin geometrisi korunur; bu, mevcut bir yerleşimde medyanın güncellenmesi için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) okunabilir ve örneğin diske kaydederken kullanılabilir.