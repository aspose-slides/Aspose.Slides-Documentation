---
title: Python Kullanarak Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/python-java/video-frame/
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
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument slaytlarında programatik olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir uygulama rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve bir izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for Python via Java, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını düzenlemenizi, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve çevrimiçi videolara, örneğin YouTube videolarına bağlantıları destekler.

Video verilerini ve video çerçevelerini temsil etmek için, Aspose.Slides [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) sınıfını ve diğer ilgili türleri sağlar.

## **Gömülü Bir Video Çerçevesi Oluşturma**

Eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Python, video baytlarını diskinizden okur ve JPype, videonun sunuma eklenmesinden önce bunları bir Java bayt dizisine dönüştürür.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Yerel bir video yolunu doğrudan [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) yöntemine de geçirebilirsiniz. Bu örnek videoyu yeni bir sunumun ilk slaytına gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Web Kaynağından Video ile Bir Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) çevrimiçi videoları sunumlarda destekler. YouTube videosu gibi bir çevrimiçi videoya bağlanan bir video çerçevesi oluşturabilirsiniz.

Bu örnek, bir YouTube video bağlantısını ve küçük resmini ilk slayta ekler. Başka bir video kullanmak için video kimliğini değiştirin. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) yöntemi otomatik oynatmayı talep eder. Küçük resmi indirmek ve videoyu oynatmak internet erişimi gerektirir. Sunum görüntüleyicisinin de çevrimiçi video oynatımını desteklemesi gerekir.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tam Ekran Modunda Bir Videoyu Oynatma**

Bir eğitim sunumunda, izleyicinin ayrıntıları görebilmesi için bir yazılım demosunu tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için `True` ile [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) metodunu çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tam ekran oynatma, videonun nasıl gösterileceğini kontrol eder. Bağımsız olarak, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) otomatik mi yoksa tıklama üzerine mi başlayacağını, [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ise tekrarlanıp tekrarlanmayacağını kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sar**

Bir eğitim sunumunda, demo videosunu başlangıç noktasına geri döndürmek, konuşmacunun videoyu tekrar oynatmasını hazır hale getirir. Oynatma bittikten sonra videoyu başlangıca döndürmek için `True` ile [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) metodunu çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Döngüyü devre dışı bırakır, böylece oynatma sona erer ve başlangıcı tıklama üzerine ayarlar. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Geri sarmak, videoyu yeniden başlatmadan başına getirir. Bunun tersine, [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ile `True` ayarlandığında oynatma otomatik olarak tekrarlanır. Videonun bitmesini ve yeniden oynatmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) bağımsız olarak otomatik ya da tıklama üzerine başlatmayı kontrol eder; bu örnek, konuşmacının oynatmayı ne zaman başlatacağını kontrol etmesi için [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) kullanır. Döngü ayarından sonra oynatma modunu ayarlayın, örnekte gösterildiği gibi. Geri sarmak, [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) ile bağımsız çalışır.

## **Bir Video Çerçevesini Kırpma**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) ve [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) yöntemlerini kullanarak bir videonun başından veya sonundan bir bölümü atlayabilirsiniz. Her iki değer de milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir videoyu gömer ve oynatma sırasında ilk 2,5 saniye ile son bir saniyeyi atlar. Çalınabilir bir segment kalması için videonun 3,5 saniyeden uzun olduğundan emin olun.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Kırpma Ayarlarını Okuma**

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye olarak yazdırır. Sunum en az bir slayt içermelidir. Eğer o slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenize olanak tanır. Altyazılar WebVTT formatında saklanır ve [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) yöntemi aracılığıyla sunulur.

### **Bir Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve “English” etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoyla eşleşmelidir. Kaydedilen sunum, hem videoyu hem de altyazılarını içerir.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # WebVTT dosyasından yeni bir altyazı izi ekle.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) sınıfı ayrıca akıştan altyazı eklemenize izin veren bir aşırı yükleme sağlar.

### **Bir Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı ayrı WebVTT dosyaları olarak kaydeder. Sıralı numaralar, çıktı dosyalarının birbirinden farklı olmasını sağlar. Konsol, çıkarılan iz sayısını rapor eder. Sunum en az bir slayt içermelidir.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Her [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) nesnesi, altyazı kimliğini, etiketini, ikili veriyi ve altyazı metnini UTF-8 dizesi olarak sunar.

### **Bir Video Çerçevesinden Altyazı Silme**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları siler ve sonucu kaydeder. Slayt ve şeklin mevcut olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Video çerçevesindeki tüm altyazıları kaldır.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Sadece bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) yöntemlerini kullanın.

### **Video Altyazılarını Arama**

[Captions.getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) tam WebVTT izini, başlık, zaman satırları ve altyazı metni dahil olmak üzere döner. Altyazıları bellekte arayarak bir ifadeyi ve zaman damgasını bulabilirsiniz. Örneğin, 2. slayttaki bir İngilizce iz şu metni içerebilir.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Bu örnek `captioned_media.pptx` dosyasını açar ve her slayttaki üst düzey video çerçevelerinin izlerini okumak için [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) yöntemini kullanır. Düz metin işaretinde zaman satırı `-->` içerir ve boş bir satır işareti sonlandırır. “café” ifadesi (büyük/küçük harf farkı gözetmeksizin) içeren her altyazı için örnek, slayt numarasını, iz etiketini, orijinal zaman satırını ve tam altyazıyı yazar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("captioned_media.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, VideoFrame):
                continue
            for track in shape.getCaptionTracks():
                track_text = str(track.getDataAsString())
                lines = iter(track_text.splitlines())
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
                        print(f"Slide {slide.getSlideNumber()} | {track.getLabel()} | {timing}")
                        print(caption)
finally:
    presentation.dispose()
```

“café” araması örnek iz için bir eşleşme üretir. Arama, iz başlığını hariç tutar ve zaman ayarını ve satır sonlarını çıktıda korur.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

Bu örnek, her slayttan gömülü videoları ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri içermedikleri için atlanır. Konsol, her videonun MIME türünü ve toplam sayısını yazar. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde rapor edilen medya türüne göre değiştirin.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **SSS**

**Bir video çerçevesi için hangi oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (otomatik ya da tıklama üzerine) ve [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) nesnesinin yöntemleri aracılığıyla mevcuttur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir, bu da sunum boyutunun dosya boyutuna oranla artmasına neden olur. Çevrimiçi bir videoya bağlantı verip bir küçük resim eklediğinizde, sunum video verisi yerine bağlantı ve ön izleme görüntüsünü saklar; bu nedenle boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevenin şekil geometrisini koruyarak çerçeve içindeki [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) değiştirilebilir; bu, mevcut bir yerleşimde medyayı güncellemenin yaygın bir senaryosudur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) bilgisi okunabilir ve örneğin diske kaydederken kullanılabilir.