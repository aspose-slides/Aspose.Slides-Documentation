---
title: Java Kullanarak Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/java/video-frame/
keywords:
- video ekle
- video oluşturma
- video gömme
- video çıkarma
- video al
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint ve OpenDocument slaytlarına programatik olarak video çerçeveleri eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for Java, slaytlara video çerçeveleri eklemenize, oynatma ayarlarını ayarlamanıza, altyazıları yönetmenize ve yerleşik video verilerini çıkarmanıza olanak tanır.

PowerPoint, yerel videoları ve YouTube gibi çevrimiçi videoların bağlantılarını destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) arayüzünü, [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) arayüzünü ve diğer ilgili tipleri sunar.

## **Gömülü Video Çerçevesi Oluşturma**

Slaydınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına yerel bir videoyu gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme tamamlanana kadar açık kalır çünkü [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) sunum kullanırken akışı kilitli tutar.

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

Yerel bir video yolunu doğrudan [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) metoduna da geçirebilirsiniz. Bu örnek, videoyu yeni bir sunumun ilk slaydına gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

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

## **Web Kaynağından Video ile Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) sunumlarda çevrimiçi videoları destekler. YouTube gibi bir çevrimiçi videoya bağlanan bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve küçük resim ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) metodu otomatik oynatmayı talep eder. Küçük resmin indirilmesi ve videonun oynatılması internet erişimi gerektirir. Sunum görüntüleyicisi de çevrimiçi video oynatımını desteklemelidir.

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

## **Videoyu Tam Ekran Modunda Oynatma**

Eğitim sunumunda, izleyicilerin detayları görebilmesi için bir yazılım gösterimini tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) metodunu `true` ile çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi bulunan en az bir slayt içermelidir.

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

Tam ekran oynatma, videonun nasıl gösterileceğini kontrol eder. Bağımsız olarak, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) otomatik mi yoksa tıklamayla mı başlayacağını, [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) ise tekrarlanıp tekrarlanmayacağını kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Eğitim sunumunda, gösterim videosunu başına döndürmek, sunumcunun videoyu tekrar oynatmasını sağlar. Oynatma bittiğinde videoyu başa döndürmek için [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) metodunu `true` ile çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Oynatmanın bitmesi için döngüyü devre dışı bırakır ve oynatmayı tıklamayla başlaması için ayarlar. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi bulunan en az bir slayt içermelidir.

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

Geri sarmak, videoyu yeniden başlatmadan başına getirir. Buna karşılık, [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) metodunu `true` ile çağırmak, oynatmayı otomatik olarak tekrar eder. Videonun bitmesini ve tekrar oynatılmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) bağımsız olarak otomatik ya da tıklamayla başlatmayı kontrol eder; bu örnek, sunumcunun oynatmayı ne zaman başlatacağını kontrol etmesi için [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) kullanır. Döngü ayarından sonra oynatma modunu ayarlayın, örnekte gösterildiği gibi. Geri sarmak, [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) metodundan bağımsız çalışır.

## **Video Çerçevesini Kırpma**

[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) ve [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) metodlarını kullanarak oynatma sırasında videonun başlangıcını ya da sonunu atlayabilirsiniz. Her iki değer milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek yerel bir videoyu gömer ve oynatma sırasında ilk 2,5 saniyeyi ve son bir saniyeyi atlar. Oynanabilir bir bölüm kalması için videonun 3,5 saniyeden uzun olması gerekir.

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

Bu örnek, ilk slaydın ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. Eğer bu slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

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

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) metoduyla erişilebilir.

### **Video Çerçevesine Altyazı Eklemek**

Bu örnek yerel bir videoyu gömer ve “English” etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoya eşleşmelidir. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

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

[ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) arayüzü, bir akıştan altyazı eklemenize olanak tanıyan bir aşırı yükleme de sağlar.

### **Video Çerçevesinden Altyazıları Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Çıktı dosyalarının farklı kalmasını sağlamak için ardışık numaralar kullanılır. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir slayt içermelidir.

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

Her [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF-8 dizesi olarak sunar.

### **Video Çerçevesinden Altyazıları Kaldırma**

Bu örnek, ilk slaydın ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin var olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

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

Sadece tek bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) yerine [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) veya [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) metodlarını kullanın.

### **Video Altyazılarını Arama**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) metodu, başlık, zamanlama satırları ve altyazı metni dahil olmak üzere tam WebVTT izini döndürür. Bellekteki ipuçlarını arayarak söylenen bir ifadeyi ve zaman damgasını bulabilirsiniz. Örneğin, 2. slayttaki bir İngilizce iz şu metni içerebilir.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Örnek, `captioned_media.pptx` dosyasını açar ve her slaydın üst‑seviyedeki video çerçevelerinin izlerini okumak için [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) metodunu kullanır. Düz metin ipucunda zamanlama satırı `-->` içerir ve boş bir satır ipucunun sonunu işaret eder. Altyazı “café” kelimesini herhangi bir harf büyük/küçük durumunda içerdiğinde, örnek slayt numarasını, iz etiketini, orijinal zaman satırını ve tam altyazıyı yazdırır.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

“café” için yapılan arama, örnek izde bir eşleşme üretir. Arama iz başlığını dışlar ve zaman ayarını çıktıda korur.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da izin verir.

Bu örnek, her slayttan gömülü videoları ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar atlanır çünkü gömülü veri içermezler. Konsol, her videonun MIME tipini ve toplam sayısını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde bildirilen medya tipine göre uzantıyı değiştirebilirsiniz.

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

**Bir video çerçevesi için hangi oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (otomatik ya da tıklamayla) ve [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) kontrol edilebilir. Bu seçenekler [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) nesnesinin metodları aracılığıyla sunulur.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömülürken ikili veri belgeye dahil edilir, bu da sunum boyutunun dosya boyutuyla orantılı olarak artmasına yol açar. Çevrimiçi bir videoya bağlantı verilir ve ön izleme resmi eklenirse, sunum bağlantıyı ve ön izleme resmini saklar; video verisi saklanmaz, bu yüzden boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevenin geometrisini koruyarak çerçevedeki [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) değiştirebilirsiniz; bu, mevcut bir yerleşimde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) okunabilir ve örneğin diske kaydederken kullanılabilir.