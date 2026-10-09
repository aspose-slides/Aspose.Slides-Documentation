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
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument slaytlarında video çerçevelerini programlı olarak eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve bir izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for Python via Java, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını ayarlamanızı, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve YouTube videoları gibi çevrimiçi videolara bağlantıları destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) sınıfı, [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) sınıfı ve diğer ilgili tipleri sağlar.

## **Yerleşik Video Çerçevesi Oluşturma**

Slayta eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza yerleştirmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video yerleştirir ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Python, video baytlarını diskten okur ve JPype, video sunuma eklenmeden önce bunları bir Java bayt dizisine dönüştürür.

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

Yerel bir video yolunu doğrudan [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame) metoduna da geçirebilirsiniz. Bu örnek, yeni bir sunumun ilk slaytına videoyu yerleştirir. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube videosu gibi çevrimiçi bir videoya bağlantı veren bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve küçük resim ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) yöntemi otomatik oynatmayı talep eder. Küçük resmi indirmek ve videoyu oynatmak internet erişimi gerektirir. Sunum görüntüleyicisi de çevrimiçi video oynatımını desteklemelidir.

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

## **Bir Videoyu Tam Ekran Modunda Oynatma**

Bir eğitim sunumunda, izleyicilerin ayrıntıları görebilmesi için bir yazılım demosunu tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için `True` ile [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) çağırın.

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

Tam ekran oynatma, videonun nasıl görüntüleneceğini kontrol eder. Bağımsız olarak, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) otomatik mi yoksa tıklamayla mı başlayacağını, [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) ise tekrarlanıp tekrarlanmayacağını kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Bir eğitim sunumunda, bir demo videosunu başına döndürmek, sunumcunun tekrar oynatmaya hazır olmasını sağlar. Oynatma bittiğinde videoyu başa döndürmek için `True` ile [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Oynatmanın bitmesi için döngüyü devre dışı bırakır ve oynatmayı tıklamayla başlatır. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

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

Geri sarmak, videoyu tekrar başlatmadan başına döndürür. Buna karşılık, `True` ile [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) çağırmak oynatmayı otomatik olarak tekrar eder. Videonun bitmesini ve yeniden oynatılmaya hazır kalmasını istediğinizde döngüyü kapalı tutun. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) bağımsız olarak otomatik ya da tıklamayla başlangıcı kontrol eder; bu örnek, sunumcunun oynatmayı ne zaman başlatacağını kontrol etmesi için [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) kullanır. Örnekte gösterildiği gibi döngü ayarından sonra oynatma modu ayarlanır. Geri sarmak, [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) ile bağımsız çalışır.

## **Bir Video Çerçevesini Kırpma**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) ve [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) metodlarını kullanarak oynatma sırasında videonun başlangıcındaki veya sonundaki bir bölümü atlayabilirsiniz. Her iki değer de milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir video yerleştirir ve oynatma sırasında ilk 2,5 saniyeyi ve son saniyeyi atlar. Oynatılabilir bir bölüm kalması için 3,5 saniyeden uzun bir video kullanın.

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

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer o slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```python
import jpide
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

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks) yöntemi aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video yerleştirir ve İngilizce etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları video ile eşleşmelidir. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

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

    # Yeni bir altyazı izini bir WebVTT dosyasından ekle.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) sınıfı aynı zamanda bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Ardışık sayılar çıkış dosyalarını farklı tutar. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir slayt içermelidir.

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

Her [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF-8 dizesi olarak sunar.

**Bir Video Çerçevesinden Altyazı Kaldırma**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin mevcut olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

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
        # Video çerçevesinden tüm altyazıları kaldır.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Sadece bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) yöntemlerini kullanın.

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da izin verir.

Bu örnek, gömülü videoları her slayttan ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri içermedikleri için atlanır. Konsol, her videonun MIME tipini ve toplam sayısını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; ihtiyaç duyulduğunda bildirilen medya türüne göre değiştirin.

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

## **FAQ**

**Bir video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**

Oynatma modunu ([playback mode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (otomatik veya tıklamayla) ve [looping](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode)) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) nesnesinin yöntemleri aracılığıyla mevcuttur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye eklenir, bu nedenle sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir videoya bağlantı verip bir küçük resim eklediğinizde, sunum videonun kendisi yerine bağlantıyı ve ön izleme resmini depolar, bu yüzden boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçeve içindeki [video content](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) öğesini şeklin geometrisini koruyarak değiştirebilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun, örneğin diske kaydederken okuyup kullanabileceğiniz bir [content type](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) vardır.