---
title: Sunumlarda Video Çerçevelerini Node.js Kullanarak Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/nodejs-java/video-frame/
keywords:
- video ekle
- video oluştur
- video gömme
- video çıkar
- video al
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument slaytlarına programlı olarak video çerçeveleri eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for Node.js via Java, slaytlara video çerçeveleri eklemenize, oynatma ayarlarını düzenlemenize, altyazıları yönetmenize ve gömülü video verilerini çıkarmanıza olanak tanır.

PowerPoint, yerel videoları ve YouTube videoları gibi çevrimiçi videoların bağlantılarını destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) sınıfı, [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) sınıfı ve diğer ilgili türleri sağlar.

## **Gömülü Bir Video Çerçevesi Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme işlemi bitene kadar açık kalır çünkü [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) sunum tarafından kullanılırken akışı kilitli tutar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Ayrıca yerel video yolunu doğrudan [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) metoduna geçirebilirsiniz. Bu örnek, videoyu yeni bir sunumun ilk slaytına gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Web Kaynağından Video ile Bir Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site), sunumlardaki çevrimiçi videoları destekler. YouTube videosu gibi çevrimiçi bir videoya bağlantı veren bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve önizleme resmi ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) yöntemi otomatik oynatmayı talep eder. Önizleme resmini indirmek ve videoyu oynatmak internet erişimi gerektirir. Sunum görüntüleyicisinin de çevrimiçi video oynatımını desteklemesi gerekir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Videoyu Tam Ekran Modunda Oynatma**

Eğitim sunumunda, izleyicilerin ayrıntıları görebilmesi için bir yazılım demosunu tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) metodunu `true` ile çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Giriş sunumu, ilk slaytta mevcut bir video çerçevesi bulunan en az bir slayt içermelidir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tam ekran oynatma, videonun nasıl gösterileceğini kontrol eder. Bağımsız olarak, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) otomatik mi yoksa tıklamayla mı başlayacağını, [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) ise tekrarlanıp tekrarlanmayacağını yönetir. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Al**

Eğitim sunumunda, demo videosunu başına döndürmek, sunucunun videoyu tekrar oynatmaya hazır olmasını sağlar. Oynatma bittiğinde videoyu başa döndürmek için [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) metodunu `true` ile çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) öğesini bulur ve geri almayı etkinleştirir. Döngüyü devre dışı bırakır, böylece oynatma tamamlanabilir ve oynatmayı tıklamayla başlatır. Giriş sunumu, ilk slaytta mevcut bir video çerçevesi bulunan en az bir slayt içermelidir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Geri alma, videoyu tekrar başlatmadan başına döndürür. Buna karşılık, [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) metodunu `true` ile çağırmak oynatmayı otomatik olarak tekrarlar. Videonun bitmesini ve tekrar oynatmaya hazır kalmasını istediğinizde döngüyü devre dışı tutun. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) bağımsız olarak otomatik ya da tıklamayla başlamayı kontrol eder; bu örnek, oynatmanın ne zaman başlayacağını sunucunun kontrol etmesi için [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) kullanır. Örnekte gösterildiği gibi, döngü ayarından sonra oynatma modunu ayarlayın. Geri alma, [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) metodundan bağımsız çalışır.

## **Bir Video Çerçevesini Kırpma**

Oynatma sırasında videonun başlangıcından veya sonundan bir kısmı atlamak için [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) ve [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) yöntemlerini kullanın. Her iki değer de milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir video gömer ve oynatma sırasında ilk 2,5 saniye ile son bir saniyeyi atlar. Oynanabilir bir segmentin kalması için videonun 3,5 saniyeden uzun olmasına dikkat edin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Kırpma Ayarlarını Okuma**

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye cinsinden yazdırır. Sunum en az bir slayt içermelidir. O slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) yöntemi aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve English etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoyla eşleşmelidir. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) sınıfı ayrıca akıştan altyazı eklemek için [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) metodunu sağlar.

**Bir Video Çerçevesinden Altyazıları Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Ardışık sayılar çıktı dosyalarını ayırır. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir slayt içermelidir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Her [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketi, ikili veriyi ve altyazı metnini UTF‑8 dizesi olarak sunar.

**Bir Video Çerçevesinden Altyazıları Kaldırma**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin mevcut olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sadece bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) metodlarını kullanın.

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlarda gömülü videoları çıkarmanıza da olanak tanır.

Bu örnek, her slayttan gömülü videoları ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri olmadığından atlanır. Konsol, her videonun MIME tipini ve toplam sayılarını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde rapor edilen medya tipine uygun olarak değiştirin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bir video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (otomatik veya tıklamayla) ve [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) nesnesinin yöntemleri aracılığıyla kullanılabilir.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir ve böylece sunum boyutu dosya büyüklüğüyle orantılı olarak artar. Çevrimiçi bir videoya bağlandığınızda ve önizleme resmi eklediğinizde, sunum videonun kendisi yerine bağlantıyı ve ön izleme resmini saklar; bu nedenle boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevedeki [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) değiştirilebilir ve şeklin geometrisini koruyarak medya güncellenebilir; bu, mevcut bir yerleşimde medyayı güncellemenin yaygın bir senaryosudur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) değeri vardır ve bunu okuyabilir, örneğin diske kaydederken kullanabilirsiniz.