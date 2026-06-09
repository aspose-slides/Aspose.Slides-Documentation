---
title: Android'de Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'i Java aracılığıyla kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir uygulama kılavuzu."
---
## **Giriş**

Sunumda iyi yerleştirilmiş bir video, mesajınızı daha etkileyici hâle getirebilir ve izleyicilerinizle etkileşim seviyelerini artırabilir. 

PowerPoint, bir sunumdaki slayta videolar eklemenizi iki şekilde sağlar:

* Yerel bir video ekleyin veya gömün (makinenizde depolanmış)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Sunuma videolar (video nesneleri) eklemenizi sağlamak için, Aspose.Slides [IVideo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideo/) arabirimini, [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) arabirimini ve diğer ilgili türleri sunar.

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanmışsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytın referansını indeks üzerinden alın. 
1. Bir [IVideo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideo/) nesnesi ekleyin ve video dosyası yolunu geçerek videoyu sunuma gömün.
1. [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesi ekleyerek video için bir çerçeve oluşturun.
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

Alternatif olarak, dosya yolunu doğrudan [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) metoduna geçirerek bir video ekleyebilirsiniz:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint 2013 ve daha yeni sürümler](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi olarak mevcutsa (ör. YouTube’da), web bağlantısı üzerinden sunumunuza ekleyebilirsiniz. 

1. Bir [Presentation ](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun
1. Slaytın referansını indeks üzerinden alın. 
1. Bir [IVideo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideo/) nesnesi ekleyin ve videonun bağlantısını geçirin.
1. Video çerçevesi için bir küçük resim ayarlayın. 
1. Sunumu kaydedin. 

Bu Java kodu, web üzerinden bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

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

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) yöntemi aracılığıyla sunulur.

**Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Sunuma bir video ekleyin.
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesi ekleyin.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen [ICaptionsCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/) kullanarak bir WebVTT altyazı izini ekleyin.
1. Değiştirilmiş sunumu kaydedin.

İşte aşağıdaki kod, bir video çerçevesine altyazı eklemenizi gösterir:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Yeni bir WebVTT dosyasından altyazı izi ekler.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/) arabirimi, akıştan altyazı eklemenizi sağlayan bir aşırı yükleme daha sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesini bulun.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen altyazı izleri üzerinden döngü oluşturun.
1. Her bir altyazı izini bir `.vtt` dosyasına kaydedin.

Aşağıdaki kod, bir video çerçevesinden altyazı nasıl çıkarılacağını gösterir:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Altyazı izini bir WebVTT dosyasına kaydeder.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Her bir [ICaptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptions/) nesnesi, altyazı kimliğini, etiketini, ikili veriyi ve altyazı verisini UTF-8 dizesi olarak sunar.

**Video Çerçevesinden Altyazı Kaldırma**

Bir video çerçevesinden altyazı kaldırmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesini alın.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen koleksiyondan altyazı izlerini kaldırın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesinden tüm altyazıların nasıl kaldırılacağını gösterir:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Video çerçevesindeki tüm altyazıları kaldırır.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sadece bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#clear--) yerine [remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) yöntemlerini kullanın.

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) nesneleri üzerinden döngü oluşturun.
3. Bir [VideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/) bulmak için tüm [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) nesneleri üzerinden döngü oluşturun.
4. Videoyu diske kaydedin.

Bu Java kodu, bir sunum slaytındaki videoyu nasıl çıkaracağınızı gösterir:

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

**VideoFrame için hangi video oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatik veya tıklama ile) ve [looping](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) (döngü) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla mevcuttur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye eklenir ve bu nedenle sunumun boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde ise bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevenin içindeki [video içeriğini](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) şeklin geometriğini koruyarak değiştirebilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemenin yaygın bir senaryosudur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okuyabileceğiniz ve örneğin diske kaydederken kullanabileceğiniz bir [content type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/video/#getContentType--) (içerik türü) vardır.