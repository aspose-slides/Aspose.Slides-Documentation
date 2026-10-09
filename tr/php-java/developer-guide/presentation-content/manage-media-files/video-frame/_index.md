---
title: PHP ile Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/php-java/video-frame/
keywords:
- video ekle
- video oluştur
- video gömme
- video çıkar
- video getir
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument slaytlarında programlı olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Videolar fikirleri açıklamaya ve izleyiciyi etkilemeye yardımcı olabilir. Aspose.Slides for PHP via Java, slaytlara video çerçeveleri eklemenizi, oynatma ayarlarını düzenlemenizi, altyazıları yönetmenizi ve gömülü video verilerini çıkarmanızı sağlar.

PowerPoint, yerel videoları ve YouTube gibi çevrimiçi videoların bağlantılarını destekler.

Video verilerini ve video çerçevelerini temsil etmek için Aspose.Slides, [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) sınıfı, [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) sınıfı ve diğer ilgili türleri sunar.

## **Gömülü Bir Video Çerçevesi Oluşturma**

Slayda eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, sunumda videoyu gömmek için bir video çerçevesi oluşturabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına yerel bir video gömer ve sonucu kaydeder. Çerçeve koordinatları ve boyutları puan cinsindendir. Akış, kaydetme tamamlanana kadar açık kalır çünkü [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) sunum onu kullandığı sürece kilitli tutar.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Ayrıca yerel video yolunu doğrudan [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) metoduna geçirebilirsiniz. Bu örnek, yeni bir sunumun ilk slaytına videoyu gömer. Video, sunum kaydedilene kadar erişilebilir olmalıdır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Web Kaynağından Video ile Bir Video Çerçevesi Oluşturma**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) çevrimiçi videoları sunumlarda destekler. YouTube gibi bir çevrimiçi videoya bağlanan bir video çerçevesi oluşturabilirsiniz.

Bu örnek, ilk slayta bir YouTube video bağlantısı ve önizleme resmi ekler. Başka bir video kullanmak için video tanımlayıcısını değiştirin. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) metodu otomatik oynatmayı talep eder. Önizleme resmini indirmek ve videoyu oynatmak internet erişimi gerektirir. Sunum görüntüleyicisinin de çevrimiçi video oynatımını desteklemesi gerekir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Videoyu Tam Ekran Modunda Oynatma**

Eğitim sunumunda, izleyicilerin ayrıntıları görebilmesi için bir yazılım demo‑sunuunu tam ekran modunda oynatabilirsiniz. Oynatma sırasında bu davranışı etkinleştirmek için `true` ile [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) öğesini bulur ve tam ekran oynatmayı etkinleştirir. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tam ekran oynatma, videonun nasıl görüntüleneceğini denetler. Bağımsız olarak, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) otomatik mi yoksa tıklamayla mı başlayacağını, [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) ise tekrar edip etmeyeceğini kontrol eder. Başlangıç davranışını seçmek için oynatma modunu [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) olarak ayarlayın. Örnek, mevcut başlangıç ve döngü ayarlarını korur.

## **Oynatmadan Sonra Videoyu Geri Sarma**

Eğitim sunumunda, bir demo videosunu başa döndürmek, sunumcunun videoyu tekrar oynatmasını hazır hâle getirir. Oynatma bittiğinde videoyu başa döndürmek için `true` ile [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) çağırın.

Bu örnek bir sunumu açar, ilk slayttaki ilk [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) öğesini bulur ve geri sarmayı etkinleştirir. Döngüyü devre dışı bırakır, böylece oynatma tamamlanabilir ve oynatmayı tıklamayla başlatır. Girdi sunumu, ilk slaytta mevcut bir video çerçevesi içeren en az bir slayt içermelidir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Geri sarma, videoyu başa döndürür ancak tekrar başlatmaz. Buna karşılık, `true` ile [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) çağırmak, oynatmayı otomatik olarak tekrar eder. Videonun bitmesini ve tekrar oynatılmaya hazır kalmasını istediğinizde döngüyü devre dışı bırakın. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) bağımsız olarak otomatik ya da tıklamayla başlangıcı kontrol eder; bu örnek, sunumcunun oynatmayı ne zaman başlatacağını belirlemesi için [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) kullanır. Döngü ayarından sonra oynatma modunu ayarlayın, örnekte gösterildiği gibi. Geri sarma, [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) ile bağımsız çalışır.

## **Bir Video Çerçevesini Kırpma**

Oynatma sırasında bir videonun başlangıç veya son kısmını atlamak için [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) ve [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) kullanın. Her iki değer de milisaniye cinsindendir. Kırpma, gömülü video verisini değiştirmeden oynatma ayarlarını değiştirir.

**Kırpma Ayarlarını Belirleme**

Bu örnek, yerel bir video gömer ve oynatma sırasında ilk 2,5 saniye ile son bir saniyeyi atlar. Oynanabilir bir segment kalması için videonun 3,5 saniyeden uzun olması gerekir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Kırpma Ayarlarını Okuma**

Bu örnek, ilk slayttaki ilk video çerçevesinin kırpma değerlerini milisaniye olarak yazdırır. Sunum en az bir slayt içermelidir. Eğer bu slaytta video çerçevesi yoksa hiçbir şey yazdırılmaz. Önceki örnek 2500 ve 1000 değerlerini üretir.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenize olanak tanır. Altyazılar WebVTT formatında saklanır ve [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) yöntemi aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bu örnek, yerel bir video gömer ve İngilizce etiketiyle bir WebVTT altyazı izi ekler. Altyazı zaman damgaları videoyla eşleşmelidir. Kaydedilen sunum hem videoyu hem de altyazılarını içerir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) sınıfı ayrıca bir akıştan altyazı eklemenize izin veren bir aşırı yükleme sağlar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bu örnek, ilk slayttaki video çerçevelerinden tüm altyazı izlerini ayrı WebVTT dosyaları olarak kaydeder. Ardışık numaralar çıktı dosyalarının farklı olmasını sağlar. Konsol, çıkarılan iz sayısını raporlar. Sunum en az bir slayt içermelidir.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Her [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketi, ikili veriyi ve UTF‑8 dizesi olarak altyazı metnini ortaya koyar.

**Bir Video Çerçevesinden Altyazı Kaldırma**

Bu örnek, ilk slayttaki ilk şekil konumundaki video çerçevesinden tüm altyazıları kaldırır ve sonucu kaydeder. Slayt ve şeklin mevcut olduğunu ve şeklin bir video çerçevesi olduğunu varsayar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Yalnızca tek bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) metodlarını kullanın.

## **Bir Slayttan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides gömülü videoları sunumlardan çıkarmanıza da olanak tanır.

Bu örnek, her slayttan gömülü videoları ayrı, numaralı ikili dosyalara çıkarır. Bağlantılı videolar, gömülü veri içermediği için atlanır. Konsol, her bir videonun MIME tipini ve toplam sayısını yazdırır. Çıktı, genel `.bin` uzantısını kullanır; gerektiğinde bildirilen medya tipine göre değiştirilebilir.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **SSS**

**Bir video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (otomatik ya da tıklamayla) ve [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) kontrol edilebilir. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) nesnesinin metodları aracılığıyla kullanılabilir.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde ikili veri belgeye dahil edilir, bu yüzden sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir videoya bağlanıp önizleme resmi eklediğinizde, sunum video verisi yerine bağlantıyı ve ön izleme resmini saklar; bu yüzden boyut artışı genellikle daha küçüktür.

**Mevcut bir video çerçevesindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçeve içindeki [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) değiştirilebilir, şeklin geometrisi korunur; bu, mevcut bir yerleşimde medyayı güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik tipi (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) okunabilir ve örneğin diske kaydederken kullanılabilir.