---
title: "Python'da Sunumlara Video Ekleme"
linktitle: "Video Çerçevesi"
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

İyi konumlandırılmış bir video, bir sunumda mesajınızı daha etkileyici hâle getirebilir ve izleyicilerinizle etkileşim seviyesini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenize iki şekilde izin verir:

* Yerel bir video ekleyin veya yerleştirin (bilgisayarınızda depolanmış)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Sunumunuza video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [Video](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) sınıfını ve diğer ilgili tipleri sağlar. 

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Slaytın referansını indeks üzerinden alın. 
3. Bir [Video](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/) nesnesi ekleyin ve video dosyasının yolunu aktararak videoyu sunuma gömün. 
4. Videoya bir çerçeve oluşturmak için bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesi ekleyin.  
5. Değiştirilmiş sunumu kaydedin. 

Bu Python kodu, yerel olarak depolanmış bir videoyu sunuma nasıl ekleyeceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # İlk slaytı alır ve bir video çerçevesi ekler
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Sunumu diske kaydeder
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternatif olarak, videoyu doğrudan dosya yolunu `add_video_frame(x, y, width, height, fname)` yöntemine geçirerek ekleyebilirsiniz:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint 2013 ve üzeri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi olarak mevcutsa (ör. YouTube'da), web bağlantısı aracılığıyla sunumunuza ekleyebilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun
2. Slaytın referansını indeks üzerinden alın. 
3. Bir [Video](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/) nesnesi ekleyin ve videonun bağlantısını aktarın.
4. Video çerçevesi için bir küçük resim ayarlayın. 
5. Sunumu kaydedin. 

Bu Python kodu, web üzerinden bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Bir video çerçevesi ekler
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Küçük resmi yükler
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/caption_tracks/) özelliği aracılığıyla sunulur.

**Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Sunuma bir video ekleyin.
3. Slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesi ekleyin.
4. [caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/caption_tracks/) tarafından döndürülen [CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/)’i kullanarak bir WebVTT altyazı izi ekleyin.
5. Değiştirilmiş sunumu kaydedin.

İşte bir video çerçevesine altyazı eklemenizi gösteren kod:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # WebVTT dosyasından yeni bir altyazı izi ekler.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/) sınıfı, akıştan altyazı eklemenize izin veren bir aşırı yükleme de sağlar.

**Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesini bulun.
3. [caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/caption_tracks/) koleksiyonunda döngü yapın.
4. Her altyazı izini bir `.vtt` dosyasına kaydedin.

İşte bir video çerçevesinden altyazı çıkarmayı gösteren kod:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Altyazı izini bir WebVTT dosyasına kaydeder.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Her [Captions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF-8 dizesi olarak ortaya çıkarır.

**Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.
2. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesini alın.
3. [CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/)’den altyazı izlerini kaldırın.
4. Değiştirilmiş sunumu kaydedin.

İşte bir video çerçevesinden tüm altyazıları kaldırmayı gösteren kod:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # tür: slides.VideoFrame

    # Video çerçevesindeki tüm altyazıları kaldırır.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/clear/) yerine [remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/remove/) veya [remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/remove_at/) yöntemlerini kullanın.

## **Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlara gömülmüş videoları çıkarmanıza da izin verir.

1. Videoyu içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun. 
2. Tüm [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) nesnelerinde döngü yapın.
3. Bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) bulmak için tüm [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesnelerinde döngü yapın. 
4. Videoyu diske kaydedin.

Bu Python kodu, bir sunum slaytındaki videoyu nasıl çıkaracağınızı gösterir:

```python
import aspose.slides as slides

# Bir sunum dosyasını temsil eden Presentation nesnesini oluşturur
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **SSS**

**Bir VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**

Oynatma modunu ([playback mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/play_mode/)) (otomatik veya tıklamayla) ve döngüyü ([looping](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/play_loop_mode/)) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir videoyu gömdüğünüzde ikili veri belgeye dahil edilir, bu nedenle sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde bir bağlantı ve bir küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Şeklin geometrisini koruyarak çerçeve içindeki [video content](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/embedded_video/)’i değiştirebilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemenin yaygın bir senaryosudur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okuyup kullanabileceğiniz bir [content type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/content_type/) vardır, örneğin diske kaydederken.