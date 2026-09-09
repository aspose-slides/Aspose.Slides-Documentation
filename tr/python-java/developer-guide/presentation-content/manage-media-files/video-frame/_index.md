---
title: Sunumlarda Python Kullanarak Video Çerçevelerini Yönetme
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
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl-yapılır rehberi."
---
## **Giriş**

Bir sunumda iyi konumlandırılmış bir video, mesajınızı daha etkileyici hale getirebilir ve izleyicilerinizle etkileşim seviyesini artırabilir.

PowerPoint, bir sunumdaki slayta video eklemenizi iki şekilde sağlar:

* Yerel bir video ekle veya göm (bilgisayarınızda depolanmış)
* Çevrimiçi bir video ekle (YouTube gibi bir web kaynağından).

Sunuma video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [Video](https://reference.aspose.com/slides/tr/python-java/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) sınıfını ve diğer ilgili türleri sunar.

## **Gömülü Video Çerçeveleri Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunuma gömmek için bir video çerçevesi oluşturabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizinine göre bir slayta referans alın.
3. Bir [Video](https://reference.aspose.com/slides/tr/python-java/aspose.slides/video/) nesnesi ekleyin ve video dosyası verilerini geçirerek videoyu sunuma gömün.
4. Video için bir çerçeve oluşturmak üzere bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesi ekleyin.
5. Değiştirilmiş sunumu kaydedin.

Bu Python kodu, yerel olarak depolanmış bir videoyu sunuma nasıl ekleyeceğinizi gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternatif olarak, videoyu dosya yolunu doğrudan [addVideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addVideoFrame) yöntemine geçirerek ekleyebilirsiniz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Web Kaynaklarından Video ile Video Çerçeveleri Oluşturma**

Microsoft [PowerPoint 2013 ve üzeri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi olarak mevcutsa (örneğin YouTube'da), web bağlantısı aracılığıyla sunuma ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Dizinine göre bir slayta referans alın.
3. Bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesi ekleyin ve videonun bağlantısını geçirin.
4. Video çerçevesi için bir küçük resim ayarlayın.
5. Sunumu kaydedin.

Bu Python kodu, web üzerinden bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Küçük resmi yükle.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Video Çerçevesini Kesme**

Aspose.Slides, videonun hangi bölümünün oynatılacağını [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#setTrimFromStart) ve [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#setTrimFromEnd) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayarak kontrol etmenizi sağlar. Her iki değer milisaniye cinsindendir ve videonun başından ve sonundan ne kadar sürenin atlanacağını belirler. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya başka şekilde değiştirmez.

**Kesme Ayarlarını Belirleme**

Bir video çerçevesi oluşturmak ve onun kesme ayarlarını belirlemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Sunuma bir [Video](https://reference.aspose.com/slides/tr/python-java/aspose.slides/video/) nesnesi ekleyin.
3. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesi ekleyin.
4. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#setTrimFromStart) ve [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#setTrimFromEnd) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayın.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod örneği, gömülü bir videonun oynatılması sırasında ilk 2,5 saniyeyi ve son saniyeyi atlar:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Kesme Ayarlarını Okuma**

Mevcut kesme ayarlarını incelemek için bir sunumu yükleyin, ilk slayttaki şekiller arasında bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesi bulun ve değerleri [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#getTrimFromStart) ve [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#getTrimFromEnd) aracılığıyla okuyun.

Aşağıdaki kod örneği, ilk slayttaki ilk video çerçevesini bulur ve kesme ayarlarını milisaniye cinsinden raporlar:

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

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#getCaptionTracks) yöntemi aracılığıyla erişilebilir.

**Bir Video Çerçevesine Altyazı Ekleme**

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Sunuma bir video ekleyin.
3. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesi ekleyin.
4. [getCaptionTracks](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#getCaptionTracks) tarafından döndürülen [CaptionsCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/) kullanarak bir WebVTT altyazı parçası ekleyin.
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesine altyazı eklemenizi gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # WebVTT dosyasından yeni bir altyazı parçası ekle.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/) sınıfı ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

1. Videoyu içeren sunumu yükleyin.
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesini bulun.
3. [CaptionsCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/) içindeki altyazı parçalarını döngü ile gezinin.
4. Her altyazı parçasını bir `.vtt` dosyasına kaydedin.

Aşağıdaki kod, bir video çerçevesinden altyazı nasıl çıkarılacağını gösterir:

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Altyazı parçasını bir WebVTT dosyasına kaydet.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Her bir [Captions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF-8 dizesi olarak sunar.

**Bir Video Çerçevesinden Altyazı Kaldırma**

1. Videoyu içeren sunumu yükleyin.
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesini alın.
3. [CaptionsCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/) içindeki altyazı parçalarını kaldırın.
4. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesinden tüm altyazıların nasıl kaldırılacağını gösterir:

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

Yalnızca bir altyazı parçasını kaldırmanız gerektiğinde, [clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/captionscollection/#removeAt) yöntemlerini kullanın.

## **Slaytlardan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides, sunumlara gömülmüş videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Tüm [Slide](https://reference.aspose.com/slides/tr/python-java/aspose.slides/slide/) nesnelerini döngü ile gezinin.
3. Tüm [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) nesnelerini döngü ile gezerek bir [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) bulun.
4. Videoyu diske kaydedin.

Bu Python kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **SSS**

**Bir VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**

Oynatma modunu ([playback mode](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#setPlayMode), otomatik veya tıklamayla) ve döngüyü ([looping](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#setPlayLoopMode)) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla mevcuttur.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir, bu nedenle sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde, bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Şeklin geometrisini koruyarak çerçevedeki [video içeriğini](https://reference.aspose.com/slides/tr/python-java/aspose.slides/videoframe/#setEmbeddedVideo) değiştirebilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemenin yaygın bir senaryosudur.

**Gömülü bir videonun içerik tipi (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okunup kullanılabilecek bir [content type](https://reference.aspose.com/slides/tr/python-java/aspose.slides/video/#getContentType) (içerik tipi) vardır, örneğin diske kaydederken.