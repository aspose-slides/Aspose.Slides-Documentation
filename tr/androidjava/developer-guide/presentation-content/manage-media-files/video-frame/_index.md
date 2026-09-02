---
title: Android'de Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçeve
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
description: "Aspose.Slides for Android via Java kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı nasıl‑yapılır kılavuzu."
---
## **Giriş**

Sunumda iyi yerleştirilmiş bir video, mesajınızı daha etkileyici hâle getirebilir ve izleyicinizle etkileşim seviyelerini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenizi iki şekilde sağlar:

* Yerel bir video ekleyin veya gömün (bilgisayarınızda depolanmış)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Sunuma video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideo/) arabirimini, [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) arabirimini ve diğer ilgili türleri sunar.

## **Gömülü Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunuma gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. Slaytın indeksine göre referansını alın. 
1. [IVideo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideo/) nesnesi ekleyin ve videoyu sunuya gömmek için video dosya yolunu geçin.
1. Video için bir çerçeve oluşturmak üzere bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesi ekleyin.
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

Alternatif olarak, video dosya yolunu doğrudan [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) metoduna geçirerek bir video ekleyebilirsiniz:

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

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) inin yeni sürümleri, sunularda çevrimiçi videoları destekler. Kullanmak istediğiniz video çevrimiçi olarak (ör. YouTube'da) mevcutsa, web bağlantısı aracılığıyla sununuza ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun
1. Slaytın indeksine göre referansını alın. 
1. Bir [IVideo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideo/) nesnesi ekleyin ve videonun bağlantısını geçin.
1. Video çerçevesi için bir küçük resim ayarlayın. 
1. Sunumu kaydedin. 

Bu Java kodu, web üzerindeki bir videoyu PowerPoint sunumundaki bir slayta nasıl ekleyeceğinizi gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation nesnesi örnekler
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

## **Video Çerçevesini Kırpma**

Aspose.Slides, bir videonun hangi bölümünün oynatılacağını [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) ve [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) aracılığıyla trim‑from‑start ve trim‑from‑end değerlerini ayarlayarak kontrol etmenizi sağlar. Her iki değer de milisaniye cinsindendir ve videonun başından ve sonundan kaç saniye atlanacağını tanımlar. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya başka bir şekilde değiştirmez.

**Kırpma Ayarlarını Belirleme**

Bir video çerçevesi oluşturup kırpma ayarlarını belirlemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Sunuma bir [IVideo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideo/) nesnesi ekleyin.
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesi ekleyin.
1. [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) ve [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) aracılığıyla trim‑from‑start ve trim‑from‑end değerlerini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod örneği, gömülü bir videonun oynatma sırasında ilk 2,5 saniyesini ve son bir saniyesini atlar:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Kırpma Ayarlarını Okuma**

Mevcut kırpma ayarlarını incelemek için bir sunumu yükleyin, ilk slayttaki şekiller arasında bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesi bulun ve değerleri [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) ve [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--) aracılığıyla okuyun.

Aşağıdaki kod örneği, ilk slayttaki ilk video çerçevesini bulur ve kırpma ayarlarını milisaniye olarak raporlar:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) yöntemi aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Sunuma bir video ekleyin.
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesi ekleyin.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen [ICaptionsCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/) aracını kullanarak bir WebVTT altyazı izini ekleyin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesine altyazı eklemeyi gösterir:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

[ICaptionsCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/) arabirimi ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yüklü metod da sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesini bulun.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen altyazı izleri arasında gezin.
1. Her altyazı izini bir `.vtt` dosyasına kaydedin.

Aşağıdaki kod, bir video çerçevesinden altyazı çıkarmayı gösterir:

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

Her bir [ICaptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptions/) nesnesi altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı verisini UTF‑8 dizesi olarak ortaya çıkarır.

**Bir Video Çerçevesinden Altyazı Silme**

Bir video çerçevesinden altyazı silmek için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) nesnesini alın.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen koleksiyondan altyazı izlerini kaldırın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesindeki tüm altyazıların nasıl kaldırılacağını gösterir:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Video çerçevesinden tüm altyazıları kaldırır.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca tek bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#clear--) yerine [remove](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) metodunu kullanın.

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides gömülü videoları sunumlardan çıkarmanıza da imkan tanır.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfı örneği oluşturun.
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/islide/) nesneleri arasında gezin.
3. [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) nesneleri arasında dolaşarak bir [VideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/) bulun.
4. Videoyu diske kaydedin.

Bu Java kodu, bir sunum slaytındaki videoyu nasıl çıkaracağınızı gösterir:

```java
// Sunum dosyasını temsil eden bir Presentation nesnesi örnekler 
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

[playback mode](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatik ya da tıklamayla) ve [looping](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) seçeneklerini kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde ikili veri belgeye dahil olur, bu da sunum boyutunun dosya boyutuyla orantılı olarak artmasına yol açar. Çevrimiçi bir video eklediğinizde bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Varolan bir VideoFrame içindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçeve içindeki [video content](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) öğesini değiştirerek şeklin geometrisini koruyabilirsiniz; bu, mevcut bir yerleşimde medyanın güncellenmesi için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun okunup kullanılabilecek bir [content type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/video/#getContentType--) özelliği vardır, örneğin diske kaydederken.