---
title: Java Kullanarak Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/java/video-frame/
keywords:
- video ekleme
- video oluşturma
- video gömme
- video çıkarma
- video alma
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl‑yapılır rehberi."
---
## **Giriş**

İyi yerleştirilmiş bir video, mesajınızı daha çekici hâle getirebilir ve izleyicilerinizin katılım seviyesini artırabilir. 

PowerPoint, bir sunumdaki slayta videoları iki şekilde eklemenize izin verir:

* Yerel bir video ekleme veya gömme (bilgisayarınızda depolanan)
* Çevrimiçi bir video ekleme (YouTube gibi bir web kaynağından).

Sunuma video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sağlar. 

## **Gömülü Video Çerçeveleri Oluşturma**

Slayda eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. Create an instance of the [Presentation ](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation)class.
1. Slaytın indeks üzerinden referansını alın. 
1. Videoyu sunuma gömmek için video dosya yolunu geçerek bir [IVideo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideo/) nesnesi ekleyin. 
1. Video için bir çerçeve oluşturmak üzere bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. Değiştirilmiş sunumu kaydedin. 

Bu Java kodu, yerel olarak depolanmış bir videoyu sunuma nasıl ekleyeceğinizi gösterir:

```java
// Presentation sınıfını örnekler
Presentation pres = new Presentation("pres.pptx");
try {
    // Videoyu yükler
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // İlk slaytı alır ve bir video çerçevesi ekler
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Sunumu diske kaydeder
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternatif olarak, videonun dosya yolunu doğrudan [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) metoduna geçirebilirsiniz:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Web Kaynaklarından Video ile Video Çerçeveleri Oluşturma**

Microsoft [PowerPoint 2013 ve sonraki sürümleri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Eğer kullanmak istediğiniz video çevrimiçi olarak mevcutsa (ör. YouTube’da), web bağlantısı aracılığıyla sunuma ekleyebilirsiniz. 

1. Create an instance of [Presentation ](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation)class
1. Slaytın indeks üzerinden referansını alın. 
1. Bir [IVideo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideo/) nesnesi ekleyin ve videonun bağlantısını geçin.
1. Video çerçevesi için bir küçük resim ayarlayın. 
1. Sunumu kaydedin. 

Bu Java kodu, web üzerindeki bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekler 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Bir video çerçevesi ekler
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Küçük resmi yükler
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenize olanak tanır. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) yöntemi aracılığıyla elde edilir.

**Bir Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) class.
1. Sunuma bir video ekleyin.
1. Bir slayta [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesi ekleyin.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen [ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) nesnesini kullanarak bir WebVTT altyazı izi ekleyin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesine nasıl altyazı ekleyeceğinizi gösterir:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // WebVTT dosyasından yeni bir altyazı izi ekler.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesini bulun.
1. [ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) içindeki altyazı izlerini döngüyle gezinin.
1. Her altyazı izini bir `.vtt` dosyasına kaydedin.

Aşağıdaki kod, bir video çerçevesinden nasıl altyazı çıkaracağınızı gösterir:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Altyazı izini bir WebVTT dosyasına kaydeder.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Her [ICaptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve UTF‑8 dizesi olarak altyazı metnini ortaya çıkarır.

**Bir Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesini alın.
1. [ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) içindeki altyazı izlerini kaldırın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesindeki tüm altyazıların nasıl kaldırılacağını gösterir:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Video çerçevesindeki tüm altyazıları kaldırır.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca tek bir altyazı izini kaldırmanız gerekiyorsa, [remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#removeAt-int-) yöntemlerini, [clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#clear--) yerine kullanın.

## **Slaytlardan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlardaki gömülü videoları çıkarmanıza da izin verir.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) class to load the presentation containing the video. 
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) nesnelerini döngüyle gezinin.
3. [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesnelerini döngüyle gezerek bir [VideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/) bulun. 
4. Videoyu diske kaydedin.

Bu Java kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```java
// Bir sunum dosyasını temsil eden Presentation nesnesini örnekler 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // Dosya uzantısını alır
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Bir VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatik veya tıklamayla) ve [looping](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) kontrol edilebilir. Bu seçenekler [VideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye eklenir ve sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde bir bağlantı ve küçük resim gömülür, bu yüzden artış daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Şeklin geometrisini koruyarak çerçeve içindeki [video content](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) değiştirebilirsiniz; bu, mevcut bir yerleşimde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/video/#getContentType--) okunabilir ve örneğin diske kaydederken kullanılabilir.