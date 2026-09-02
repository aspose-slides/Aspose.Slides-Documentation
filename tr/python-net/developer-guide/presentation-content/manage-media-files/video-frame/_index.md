---
title: Python'da Sunumlara Video Eklemek
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
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçeveleri eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Bir sunumda iyi yerleştirilmiş bir video, mesajınızı daha etkileyici kılabilir ve izleyicilerinizle etkileşim seviyelerini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenizi iki şekilde sağlar:

* Yerel bir video ekleyin veya gömün (bilgisayarınızda depolanmış)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Sunuma video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [Video](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/) sınıfını, [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) sınıfını ve diğer ilgili türleri sağlar. 

## **Gömülü Video Çerçevesi Oluşturma**

Yerel olarak depolanan bir video dosyasını slaytınıza eklemek istiyorsanız, videoyu sunuma gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. İndeks aracılığıyla bir slaydın referansını alın. 
1. Bir [Video](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosya yolunu geçin. 
1. Video için bir çerçeve oluşturmak üzere bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesi ekleyin.  
1. Değiştirilmiş sunumu kaydedin. 

Bu Python kodu, yerel olarak depolanan bir videoyu sunuma nasıl ekleyeceğinizi gösterir:

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

Alternatif olarak, `add_video_frame(x, y, width, height, fname)` yöntemine dosya yolunu doğrudan geçirerek bir video ekleyebilirsiniz:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) yeni sürümleri, sunumlarda çevrimiçi videoları destekler. Kullanmak istediğiniz video çevrimiçi olarak mevcutsa (ör. YouTube'da), web bağlantısı aracılığıyla sunuma ekleyebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun
1. İndeks aracılığıyla bir slaydın referansını alın. 
1. Bir [Video](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/) nesnesi ekleyin ve video bağlantısını geçin.
1. Video çerçevesi için bir küçük resim ayarlayın. 
1. Sunumu kaydedin. 

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

## **Video Çerçevesini Kesme**

Aspose.Slides, bir videonun hangi kısmının oynatılacağını, [VideoFrame.trim_from_start](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/trim_from_start/) ve [VideoFrame.trim_from_end](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/trim_from_end/) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayarak kontrol etmenizi sağlar. Her iki değer milisaniye cinsindendir ve videonun başlangıcından ve sonundan atlanacak süreyi tanımlar. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya değiştirmez.

**Kesme Ayarlarını Belirleme**

Bir video çerçevesi oluşturup kesme ayarlarını belirlemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Sunuma bir [Video](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/) nesnesi ekleyin.
1. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesi ekleyin.
1. [VideoFrame.trim_from_start](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/trim_from_start/) ve [VideoFrame.trim_from_end](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/trim_from_end/) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod örneği, gömülü bir videonun oynatma sırasında ilk 2,5 saniyesini ve son bir saniyesini atlar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Kesme Ayarlarını Okuma**

Mevcut kesme ayarlarını incelemek için bir sunumu yükleyin, ilk slaydın şekilleri arasında bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesi bulun ve değerleri [VideoFrame.trim_from_start](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/trim_from_start/) ve [VideoFrame.trim_from_end](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/trim_from_end/) aracılığıyla okuyun.

Aşağıdaki kod örneği, ilk slayttaki ilk video çerçevesini bulur ve kesme ayarlarını milisaniye cinsinden raporlar:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/caption_tracks/) özelliği aracılığıyla ortaya çıkar.

**Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Sunuma bir video ekleyin.
1. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesi ekleyin.
1. [caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/caption_tracks/) tarafından döndürülen [CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/) kullanarak bir WebVTT altyazı izi ekleyin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesine altyazı eklemenizi gösterir:

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

[CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/) sınıfı ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesini bulun.
1. [caption_tracks](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/caption_tracks/) koleksiyonunda döngü yapın.
1. Her altyazı izini bir `.vtt` dosyasına kaydedin.

Aşağıdaki kod, bir video çerçevesinden altyazı nasıl çıkarılacağını gösterir:

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

Her [Captions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captions/) nesnesi altyazı kimliğini, etiketini, ikili verisini ve UTF-8 dizesi olarak altyazı metnini ortaya çıkarır.

**Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesini alın.
1. [CaptionsCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/) üzerinden altyazı izlerini kaldırın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesinden tüm altyazıların nasıl kaldırılacağını gösterir:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # tür: slides.VideoFrame

    # Video çerçevesindeki tüm altyazıları kaldırır.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Yalnızca tek bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/clear/) yerine [remove](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/remove/) veya [remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides/captionscollection/remove_at/) yöntemlerini kullanın.

## **Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlardaki gömülü videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının örneğini oluşturun. 
2. Tüm [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) nesnelerinde dolaşın.
3. Tüm [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) nesnelerinde dolaşarak bir [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) bulun. 
4. Videoyu diske kaydedin.

Bu Python kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```python
import aspose.slides as slides

# Sunum dosyasını temsil eden bir Presentation nesnesi oluşturur
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

[playback mode](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/play_mode/) (otomatik veya tıklamayla) ve [looping](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/play_loop_mode/) kontrol edebilirsiniz. Bu seçenekler [VideoFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde ikili veri belgeye dahil edilir, bu nedenle sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevenin geometrisini korurken çerçevedeki [video content](https://reference.aspose.com/slides/tr/python-net/aspose.slides/videoframe/embedded_video/) değiştirilebilir; bu, mevcut bir düzenin medyasını güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okunup kullanılabilecek bir [content type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/video/content_type/) vardır, örneğin diske kaydederken.