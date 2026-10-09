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
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for Java, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını ayarlamanızı, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve YouTube videoları gibi çevrimiçi videolara bağlantıları destekler.

Video verilerini ve video çerçevelerini temsil etmek için, Aspose.Slides [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili türleri sağlar.

## **Gömülü Video Çerçevesi Oluşturma**

Eklemek istediğiniz video dosyası yerel olarak depolanmışsa, sunumunuza videoyu gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir videoyu gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme tamamlanana kadar açık kalır çünkü [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) sunum kullanılırken akışı kilitli tutar.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yerel bir video yolunu doğrudan [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) metoduna da geçirebilirsiniz. Bu örnek, videoyu yeni bir sunumun ilk slaytına gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Web Kaynağından Video Kullanarak Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube videosu gibi bir çevrimiçi videoya bağlanan bir video çerçevesi oluşturabilirsiniz.

Bu örnek, YouTube video bağlantısını ve küçük resmi ilk slayta ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) yöntemi otomatik oynatımı talep eder. Küçük resmin indirilmesi ve video oynatılması internet erişimi gerektirir. Sunum görüntüleyicisinin de çevrimiçi video oynatımını desteklemesi gerekir.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tam Ekran Modunda Video Oynatma**

Eğitim sunumunda, izleyicilerin detayları görebilmesi için bir yazılım demosunu tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) metodunu `true` ile çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tam ekran oynatma, videonun nasıl gösterileceğini denetler. Bağımsız olarak, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) videonun otomatik olarak mı yoksa tıklamayla mı başlayacağını, [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ise tekrarlanıp tekrarlanmayacağını kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.Auto veya VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Eğitim sunumunda, bir demo videosunu başına döndürmek, sunumcunun videoyu tekrar oynatmaya hazır hale getirir. Oynatma bittiğinde videoyu başa döndürmek için [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) metodunu `true` ile çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Oynatmanın bitmesi için döngüyü devre dışı bırakır ve oynatmayı tıklamayla başlaması için ayarlar. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Geri sarmak, videoyu tekrar başlatmadan başına döndürür. Buna karşılık, [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) metodunu `true` ile çağırmak oynatmayı otomatik olarak tekrarlar. Videonun bitmesini ve tekrar oynatılmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) bağımsız olarak otomatik ya da tıklamayla başlatmayı kontrol eder; bu örnek, oynatmanın ne zaman başlayacağını sunumcunun kontrol etmesi için [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) kullanır. Örnekte gösterildiği gibi döngü ayarından sonra oynatma modu ayarlanır. Geri sarma, [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-)'dan bağımsız çalışır.

## **Video Çerçevesini Kırpma**

[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) ve [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) yöntemlerini, oynatma sırasında videonun başlangıç veya son kısmını atlamak için kullanın. Her iki değer de milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir videoyu gömer ve oynatma sırasında ilk 2,5 saniyeyi ve son saniyeyi atlar. Oynanabilir bir bölüm kalması için 3,5 saniyeden uzun bir video kullanın.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Kırpma Ayarlarını Okuma**

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer o slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenize olanak tanır. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) yöntemi aracılığıyla erişilebilir.

**Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir videoyu gömer ve İngilizce etiketli bir WebVTT altyazı izi ekler. Altyazı zaman damgaları video ile eşleşmelidir. Kaydedilen sunum, hem videoyu hem de altyazılarını içerir.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) arayüzü ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Sıralı sayılar çıktı dosyalarının farklı olmasını sağlar. Konsol, çıkarılan iz sayısını rapor eder. Sunum en az bir slayt içermelidir.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Her [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketi, ikili veriyi ve altyazı metnini UTF-8 dizesi olarak sunar.

**Video Çerçevesinden Altyazı Kaldırma**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin mevcut olduğu ve şeklin bir video çerçevesi olduğu varsayılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Yalnızca bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) yerine [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) yöntemlerini kullanın.

## **Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlara gömülü videoları çıkarmanıza da olanak tanır.

Bu örnek, gömülü videoları her slayttan ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri olmadığı için atlanır. Konsol, her videonun MIME tipini ve toplam sayıyı yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde rapor edilen medya tipine göre değiştirin.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Bir video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**

Video çerçevesi için [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatik veya tıklamayla) ve [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) (döngü) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) nesnesinin metodları aracılığıyla mevcuttur.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir, bu da sunum boyutunun dosya boyutuyla doğru oranda artmasına neden olur. Çevrimiçi bir videoya bağlanıp küçük resim eklediğinizde, sunum video verisi yerine bağlantı ve ön izleme resmini saklar, bu yüzden boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevedeki [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) (video içeriğini) çerçevenin geometrisini koruyarak değiştirebilirsiniz; bu, mevcut bir düzen içinde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) (içerik türü) vardır ve bunu okuyabilir, örneğin diske kaydederken kullanabilirsiniz.