---
title: PHP Kullanarak Sunumlarda Video Çerçevelerini Yönetme
linktitle: Video Çerçevesi
type: docs
weight: 10
url: /tr/php-java/video-frame/
keywords:
- video ekle
- video oluştur
- videoyu göm
- videoyu çıkar
- videoyu al
- video çerçevesi
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument slaytlarında video çerçevelerini programlı olarak eklemeyi ve çıkarmayı öğrenin. Hızlı bir uygulama rehberi."
---
## **Giriş**

Bir sunumda iyi yerleştirilmiş bir video, mesajınızı daha etkileyici hâle getirebilir ve izleyicilerinizle etkileşim seviyesini artırabilir. 

PowerPoint, bir sunumdaki slayta video eklemenize iki şekilde izin verir:

* Yerel bir video ekleyin veya gömün (bilgisayarınızda saklanan)
* Bir çevrimiçi video ekleyin (YouTube gibi bir web kaynağından).

Sunuma videolar (video nesneleri) eklemenizi sağlamak için Aspose.Slides, [Video](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/) sınıfı, [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) sınıfı ve diğer ilgili türleri sağlar.

## **Gömülü Video Çerçeveleri Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunumunuza gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Bir slaytın referansını indeks üzerinden alın. 
1. Bir [Video](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/) nesnesi ekleyin ve video dosya yolunu sunuma gömmek için iletin.
1. [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesi ekleyerek video için bir çerçeve oluşturun.
1. Değiştirilmiş sunumu kaydedin. 

Bu PHP kodu, yerel olarak depolanan bir videoyu bir sunuma nasıl ekleyeceğinizi gösterir:

```php
  # Sunum sınıfını örnekler
  $pres = new Presentation("pres.pptx");
  try {
    # Videoyu yükler
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # İlk slaytı alır ve bir video çerçevesi ekler
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Sunumu diske kaydeder
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternatif olarak, videoyu dosya yolunu doğrudan [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addvideoframe/) metoduna geçirerek ekleyebilirsiniz:

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Web Kaynaklarından Video Kullanarak Video Çerçeveleri Oluşturma**

Microsoft [PowerPoint 2013 ve daha yenileri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlardaki YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi mevcutsa (ör. YouTube’da), sunumunuza web bağlantısı üzerinden ekleyebilirsiniz. 

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun
1. Bir slaytın referansını indeks üzerinden alın. 
1. Bir [Video](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/) nesnesi ekleyin ve videonun bağlantısını iletin.
1. Video çerçevesi için bir küçük resim ayarlayın. 
1. Sunumu kaydedin. 

Bu PHP kodu, web üzerinden bir video ekleyerek PowerPoint sunumunda bir slayta nasıl ekleyeceğinizi gösterir:

```php
  # Presentation dosyasını temsil eden bir Presentation nesnesi oluşturur
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Video Çerçevesini Kırpma**

Aspose.Slides, bir videonun hangi kısmının oynatılacağını, [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#setTrimFromStart) ve [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#setTrimFromEnd) aracılığıyla trim‑from‑start ve trim‑from‑end değerlerini ayarlayarak kontrol etmenizi sağlar. Her iki değer de milisaniye cinsindendir ve videonun başlangıcından ve sonundan atlanacak süreyi tanımlar. Bu ayarlar sunumdaki video oynatma ayarlarını değiştirir; gömülü video ikili verisini kesmez veya başka bir şekilde değiştirmez.

**Kırpma Ayarlarını Belirleme**

Bir video çerçevesi oluşturup kırpma ayarlarını belirlemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Sunuma bir [Video](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/) nesnesi ekleyin.
1. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesi ekleyin.
1. [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#setTrimFromStart) ve [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#setTrimFromEnd) aracılığıyla trim‑from‑start ve trim‑from‑end değerlerini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod örneği, gömülü bir videonun oynatılması sırasında ilk 2,5 saniyeyi ve son bir saniyeyi atlar:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Kırpma Ayarlarını Okuma**

Mevcut kırpma ayarlarını incelemek için bir sunumu yükleyin, ilk slaydın şekilleri arasında bir [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesi bulun ve değerleri [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getTrimFromStart) ve [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getTrimFromEnd) aracılığıyla okuyun.

Aşağıdaki kod örneği, ilk slayttaki ilk video çerçevesini bulur ve kırpma ayarlarını milisaniye cinsinden raporlar:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT biçiminde depolanır ve [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) yöntemi aracılığıyla sunulur.

**Bir Video Çerçevesine Altyazı Ekleme**

Bir video çerçevesine altyazı eklemek için:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
1. Sunuma bir video ekleyin.
1. Bir slayta bir [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesi ekleyin.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) tarafından döndürülen [CaptionsCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/) koleksiyonunu kullanarak bir WebVTT altyazı izi ekleyin.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesine altyazı eklemenizi gösterir:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // WebVTT dosyasından yeni bir altyazı izi ekler.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/) sınıfı ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Bir Video Çerçevesinden Altyazı Çıkarma**

Bir video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesini bulun.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) koleksiyonunda döngü yapın.
1. Her altyazı izini bir `.vtt` dosyasına kaydedin.

Aşağıdaki kod, bir video çerçevesinden altyazı çıkarmanızı gösterir:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Altyazı izini bir WebVTT dosyasına kaydeder.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Her [Captions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captions/) nesnesi, altyazı tanımlayıcısını, etiketini, ikili verisini ve altyazı metnini UTF‑8 dizesi olarak sunar.

**Bir Video Çerçevesinden Altyazı Silme**

Bir video çerçevesinden altyazı silmek için:

1. Videoyu içeren sunumu yükleyin.
1. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesini alın.
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) koleksiyonundan altyazı izlerini kaldırın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki kod, bir video çerçevesindeki tüm altyazıları nasıl kaldıracağınızı gösterir:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // tür: VideoFrame

    // Video çerçevesindeki tüm altyazıları kaldırır.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Yalnızca tek bir altyazı izini kaldırmanız gerektiğinde, [clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#removeAt) yöntemlerini kullanın.

## **Slaytlardan Video Çıkarma**

Gömülü videoları slaytlardan çıkarmanıza da izin verir.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının örneğini oluşturun.
2. Tüm [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) nesneleri üzerinde yineleme yapın.
3. Tüm [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesneleri üzerinde yineleme yaparak bir [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) bulun.
4. Videoyu diske kaydedin.

Bu PHP kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesi oluşturur
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Dosya uzantısını alır
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**Video çerçevesi için hangi video oynatma parametreleri değiştirilebilir?**

Oynatma modunu (otomatik ya da tıklamayla) ve döngüyü kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla kullanılabilir.

**Video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömdüğünüzde, ikili veri belgeye dahil edilir ve sunum boyutu dosya boyutuyla orantılı olarak artar. Çevrimiçi bir video eklediğinizde ise yalnızca bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha az olur.

**Mevcut bir VideoFrame içindeki videoyu konumunu ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. [video content](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/setembeddedvideo/) öğesini çerçeve içinde değiştirerek şeklin geometrisini koruyabilirsiniz; bu, mevcut bir düzenin medyasını güncellemek için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/getcontenttype/) vardır ve bu bilgiyi okuyarak örneğin diske kaydederken kullanabilirsiniz.