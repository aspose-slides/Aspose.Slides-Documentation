---
title: Presentasyonlarda PHP ile Video Çerçevelerini Yönetme
linktitle: Video Çerçeve
type: docs
weight: 10
url: /tr/php-java/video-frame/
keywords:
- video ekle
- video oluştur
- video göm
- video çıkar
- video al
- video çerçeve
- web kaynağı
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument slaytlarında programatik olarak video çerçevelerini eklemeyi ve çıkarmayı öğrenin. Hızlı bir nasıl yapılır rehberi."
---
## **Giriş**

Bir sunumda iyi konumlandırılmış bir video, mesajınızı daha etkileyici hâle getirebilir ve izleyicinizle etkileşim seviyesini artırabilir. 

PowerPoint, bir sunumdaki slayta videoları iki şekilde eklemenize olanak tanır:

* Yerel bir video ekleyin veya gömün (bilgisayarınızda depolanan)
* Çevrimiçi bir video ekleyin (YouTube gibi bir web kaynağından).

Video nesnelerini (video objects) bir sunuma eklemenizi sağlamak için, Aspose.Slides [Video](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/) sınıfı, [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) sınıfı ve diğer ilgili türleri sağlar.

## **Gömülü Video Çerçeveleri Oluşturma**

Slaytınıza eklemek istediğiniz video dosyası yerel olarak depolanıyorsa, videoyu sunuma gömmek için bir video çerçevesi oluşturabilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. [Video](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/) nesnesi ekleyin ve videoyu sunuma gömmek için video dosya yolunu geçin.  
1. [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesi ekleyerek video için bir çerçeve oluşturun.  
1. Değiştirilmiş sunumu kaydedin.  

Bu PHP kodu, yerel olarak depolanan bir videoyu bir sunuma nasıl ekleyeceğinizi gösterir:

```php
  # Presentation sınıfını örnekler
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

Alternatif olarak, video dosya yolunu doğrudan [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shapecollection/addvideoframe/) metoduna geçirerek bir video ekleyebilirsiniz:

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


## **Web Kaynaklarından Video Çerçeveleri Oluşturma**

Microsoft [PowerPoint 2013 ve daha yeni sürümleri](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) sunumlarda YouTube videolarını destekler. Kullanmak istediğiniz video çevrimiçi (ör. YouTube’da) ise, web bağlantısı aracılığıyla sunuma ekleyebilirsiniz. 

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. [Video](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/) nesnesi ekleyin ve video bağlantısını geçin.  
1. Video çerçevesi için bir küçük resim (thumbnail) ayarlayın.  
1. Sunumu kaydedin.  

Bu PHP kodu, web üzerinden bir video ekleyerek bir PowerPoint sunumundaki slayta nasıl ekleyeceğinizi gösterir:

```php
  # Bir sunum dosyasını temsil eden Presentation nesnesini örnekler
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

## **Video Altyazılarını Yönetme**

Aspose.Slides, PowerPoint sunumlarındaki video çerçeveleri için kapalı altyazıları yönetmenizi sağlar. Altyazılar WebVTT formatında depolanır ve [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) yöntemi aracılığıyla kullanılabilir.

**Video Çerçevesine Altyazı Ekleme**

Video çerçevesine altyazı eklemek için:

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Sunuma bir video ekleyin.  
1. Bir slayta [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesi ekleyin.  
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) tarafından döndürülen [CaptionsCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/) koleksiyonunu kullanarak bir WebVTT altyazı izi ekleyin.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, video çerçevesine altyazı eklemeyi gösterir:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Yeni bir altyazı izini WebVTT dosyasından ekler.
    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/) sınıfı ayrıca bir akıştan altyazı eklemenizi sağlayan bir aşırı yükleme sunar.

**Video Çerçevesinden Altyazı Çıkarma**

Video çerçevesinden altyazı çıkarmak için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesini bulun.  
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) koleksiyonu üzerinde yineleme yapın.  
1. Her bir altyazı izini bir `.vtt` dosyasına kaydedin.  

Aşağıdaki kod, video çerçevesinden altyazı çıkarmayı gösterir:

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

Her bir [Captions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captions/) nesnesi altyazı tanımlayıcısını, etiketini, ikili verisini ve UTF‑8 dizesi olarak altyazı metnini ortaya koyar.

**Video Çerçevesinden Altyazı Silme**

Video çerçevesinden altyazı silmek için:

1. Videoyu içeren sunumu yükleyin.  
1. Hedef [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesini alın.  
1. [getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/#getCaptionTracks) koleksiyonundan altyazı izlerini kaldırın.  
1. Değiştirilmiş sunumu kaydedin.  

Aşağıdaki kod, bir video çerçevesindeki tüm altyazıları kaldırmayı gösterir:

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

Yalnızca tek bir altyazı izini kaldırmanız gerekiyorsa, [clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#clear) yerine [remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#removeAt) metodlarını kullanın.

## **Slaytlardan Video Çıkarma**

Videoları slaytlara eklemenin yanı sıra, Aspose.Slides sunumlardaki gömülü videoları çıkarmanıza da izin verir.

1. Videoyu içeren sunumu yüklemek için bir [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneği oluşturun.  
2. Tüm [Slide](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slide/) nesneleri üzerinde yineleme yapın.  
3. Tüm [Shape](https://reference.aspose.com/slides/tr/php-java/aspose.slides/shape/) nesneleri arasında bir [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) bulmak için arama yapın.  
4. Videoyu diske kaydedin.  

Bu PHP kodu, bir sunum slaydındaki videoyu nasıl çıkaracağınızı gösterir:

```php
  # Sunum dosyasını temsil eden bir Presentation nesnesini örnekler
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

**Bir VideoFrame için hangi oynatma parametreleri değiştirilebilir?**

[playback mode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/setplaymode/) (otomatik veya tıklama) ve [looping](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/setplayloopmode/) kontrol edebilirsiniz. Bu seçenekler, [VideoFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/) nesnesinin özellikleri aracılığıyla bulunur.

**Bir video eklemek PPTX dosya boyutunu etkiler mi?**

Evet. Yerel bir video gömülürken ikili veri belgeye eklenir, bu da sunum boyutunun dosya boyutuyla orantılı artmasına neden olur. Çevrimiçi bir video eklediğinizde ise bir bağlantı ve küçük resim gömülür, bu yüzden boyut artışı daha küçüktür.

**Mevcut bir VideoFrame’in videosunu konum ve boyutunu değiştirmeden değiştirebilir miyim?**

Evet. Çerçevenin geometrisini koruyarak [video content](https://reference.aspose.com/slides/tr/php-java/aspose.slides/videoframe/setembeddedvideo/) değiştirebilirsiniz; bu, mevcut bir yerleşimde medyanın güncellenmesi için yaygın bir senaryodur.

**Gömülü bir videonun içerik türü (MIME) belirlenebilir mi?**

Evet. Gömülü bir videonun [content type](https://reference.aspose.com/slides/tr/php-java/aspose.slides/video/getcontenttype/) vardır ve bunu okuyup, örneğin diske kaydederken kullanabilirsiniz.