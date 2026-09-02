---
title: Java Kullanarak Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/java/video-frame/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı nasıl yapılır rehberi."
---
## **Giriş**

Sunumda yerleştirilen doğru bir video, mesajınızı daha etkileyici hâle getirebilir ve izleyicilerinizin katılım seviyesini artırabilir. 

PowerPoint, bir sunumdaki slayta videoları iki şekilde eklemenize olanak tanır:

* Yerel bir video ekle veya göm (bilgisayarınızda depolanmış)
* Çevrimiçi bir video ekle (YouTube gibi bir web kaynağından).

Sunuma video (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideo/) arayüzü, [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) arayüzü ve diğer ilgili tipleri sunar. 

## **Gömülü Video Çerçeveleri Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sununuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. [Presentation ](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın referansını indeks aracılığıyla alın.  
1. Video dosyası yolunu geçirerek videoyu sunuma gömmek için bir [IVideo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideo/) nesnesi ekleyin.  
1. Video için bir çerçeve oluşturmak amacıyla bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesi ekleyin.  
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

Alternatif olarak, dosya yolunu doğrudan [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) yöntemine geçirerek video ekleyebilirsiniz:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Web Kaynaklarından Video İçeren Çerçeveler Oluşturma**

Microsoft [PowerPoint 2013 ve daha yeni sürümleri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us), sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi olarak (ör. YouTube’da) mevcutsa, web bağlantısı aracılığıyla sunuma ekleyebilirsiniz. 

1. [Presentation ](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın referansını indeks aracılığıyla alın.  
1. Bağlantıyı geçerek bir [IVideo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideo/) nesnesi ekleyin.  
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

## **Video Çerçevesini Kırpma**

Aspose.Slides, bir videonun oynatılacak kısmını, [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) ve [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayarak kontrol etmenizi sağlar. Her iki değer de milisaniye cinsinden belirtilir ve sırasıyla videonun başından ve sonundan ne kadar sürenin atlanacağını tanımlar. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya değiştirmez.

**Kırpma Ayarlarını Belirleme**

Bir video çerçevesi oluşturup kırpma ayarlarını belirlemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunuma bir [IVideo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideo/) nesnesi ekleyin.  
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) ve [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) aracılığıyla trim-from-start ve trim-from-end değerlerini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod örneği, gömülü bir videonun oynatılması sırasında ilk 2,5 saniyeyi ve son bir saniyeyi atlar:

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

Mevcut kırpma ayarlarını incelemek için bir sunum yükleyin, ilk slaydın şekilleri arasında bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesi bulun ve değerleri [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) ve [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--) aracılığıyla okuyun.

Aşağıdaki kod örneği, ilk slayttaki ilk video çerçevesini bulur ve kırpma ayarlarını milisaniye cinsinden rapor eder:

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

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) yöntemi aracılığıyla erişilir.

**Bir Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunuma bir video ekleyin.  
1. Bir slayta bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesi ekleyin.  
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) tarafından döndürülen [ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) aracılığıyla bir WebVTT altyazı izi ekleyin.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesine nasıl altyazı ekleneceğini gösterir:

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

[ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenize izin veren bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Video içeren sunumu yükleyin.  
1. Hedef [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) nesnesini bulun.  
1. [ICaptionsCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/) içindeki altyazı izleri üzerinde döngü yapın.  
1. Her bir altyazı izini `.vtt` dosyasına kaydedin.

Aşağıdaki kod, bir video çerçevesinden altyazıların nasıl çıkarılacağını gösterir:

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

Her [ICaptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve UTF-8 dizesi olarak altyazı metnini ortaya çıkarır.

**Bir Video Çerçevesinden Altyazı Silme**

Bir video çerçevesinden altyazı silmek için:

1. Video içeren sunumu yükleyin.  
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

Yalnızca tek bir altyazı izini kaldırmak istiyorsanız, [clear](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#clear--) yerine [remove](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/icaptionscollection/#removeAt-int-) yöntemlerini kullanın.

## **Slaytlardan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra Aspose.Slides, sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

1. Videoyu içeren sunumu yüklemek için [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Tüm [ISlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/islide/) nesneleri üzerinde döngü yapın.  
3. [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) nesneleri içinde bir [VideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/) bulmak için döngü yapın.  
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

                //Dosya uzantısını alır
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

[playback mode](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatik veya tıklama) ve [looping](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) kontrol edilebilir. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla bulunur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir ve sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde ise bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame içindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevedeki [video content](https://reference.aspose.com/slides/tr/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) değiştirilerek şeklin geometrisi korunabilir; bu, mevcut bir düzen içinde medyayı güncellemenin yaygın bir senaryosudur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/video/#getContentType--) okunabilir ve örneğin diske kaydederken kullanılabilir.