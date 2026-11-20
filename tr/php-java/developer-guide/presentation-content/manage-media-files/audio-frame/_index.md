---
title: PHP Kullanarak Sunumlarda Ses Çerçevelerini Yönetme
linktitle: Ses Çerçevesi
type: docs
weight: 10
url: /tr/php-java/audio-frame/
keywords:
- ses
- ses çerçevesi
- küçük resim
- ses ekle
- ses özellikleri
- ses seçenekleri
- ses çıkarma
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile slaytlara ses yerleştirin, ses simgesini değiştirin, oynatmayı yapılandırın, WebVTT altyazılarını yönetin ve slayt geçişi seslerini çıkarın."
---
## **Genel Bakış**

Bir ses çerçevesi, bir slaytta ses çalmanızı sağlar. Aspose.Slides for PHP via Java ile bir ses klibini yerleştirebilir, onu temsil eden resmi seçebilir, oynatmayı ayarlayabilir ve altyazı ekleyebilirsiniz. Ayrıca bir slayt geçişine atanmış bir sesi de alabilirsiniz.

## **Ses Çerçeveleri Oluşturma**

Yerel bir ses klibini ilk slayta yerleştirmek için [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) kullanın. İlk iki koordinat çerçeveyi slaytta konumlandırır, sonraki iki değer ise genişliğini ve yüksekliğini, hepsi puan cinsinden, ayarlar. Bu örnek, klibi otomatik olarak başlatmak için [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) çağırır ve yüksek ses ön ayarını seçmek için [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) çağırır.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Varsayılan olarak, bir ses çerçevesi bir hoparlör simgesi gösterir. Özel bir küçük resim göstermek için, [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) ile sunuma bir resim ekleyin ve çerçevenin resmini [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) ile ayarlayın. Örnek, gömülü ses klibi için küçük resim olarak bir JPEG kullanır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ses Çalma Seçeneklerini Değiştirme**

PowerPoint'in **Audio Options** denetimleri, bir klibin ne zaman başlayacağını, sesinin ne kadar yüksek olacağını ve slayt gösterisi sırasında nasıl davranacağını belirler.

![Bir ses çerçevesi için PowerPoint Ses Seçenekleri denetimleri](audio_frame_0.png)

| PowerPoint denetimi | Aspose.Slides for PHP via Java metodu |
| --- | --- |
| Başlat | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Ses ön ayarı | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Slaytlar boyunca oynat | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Durdurulana kadar döngü | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Gösteri sırasında gizle | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Oynatma sonrası geri sar | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Yavaşça gir | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Yavaşça çık | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Ses başlangıç zamanını kırp | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Ses bitiş zamanını kırp | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Ses kaydırıcısı | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

Örnek, ilk slayttaki ilk ses çerçevesini bulur, tıklamayla oynatmayı başlatmak için [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) çağırır ve düşük ses ön ayarını seçer. Klip, döngü devre dışı bırakılarak slaytlar arasında devam eder. Simge gösteri sırasında gizli kalır ve klip oynatmadan sonra geri sarar.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

3,5 saniyeden uzun bir klip için bu örnek ilk 1,5 saniyeyi ve son 2 saniyeyi atlar. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) klibin sonundan çıkarılacak süreyi alır. PowerPoint'te gösterilen bitiş zamanını elde etmek için bu offseti tam klip süresinden çıkarın. Kırpılan klip 200 milisaniye içinde yavaşça girer ve 500 milisaniye içinde yavaşça çıkar. Dört yöntem de milisaniye cinsinden değer alır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Oynatma ses seviyesini belirli bir yüzdeye ayarlamak için [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) kullanın. Bu örnek, ilk slayttaki ilk ses çerçevesini %85 olarak ayarlar.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **Ses Alt Yazılarını Yönetme**

Her ses çerçevesi, [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) aracılığıyla altyazı parçacıklarına erişim sağlar. Koleksiyonu kullanarak klibe WebVTT altyazı ekleyebilir, mevcut parçacıkları dışa aktarabilir veya silebilirsiniz.

### **Ses Alt Yazısı Ekleme**

Örnek, ilk slayta bir ses klibi yerleştirir ve [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) kullanarak yerel bir WebVTT parçacığını ekler. İlk argüman parçacık etiketini, ikincisi zamanlı altyazı dosyasını belirtir.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ses Alt Yazılarını Dışa Aktarma**

Bu örnek, ilk slayttaki bir ses çerçevesine eklenmiş her altyazı parçacığını dışa aktarır. [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) tarafından döndürülen baytları bir WebVTT dosyasına yazar ve [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) tarafından döndürülen tanımlayıcıyı dosya adı olarak kullanır; böylece her parçacık ayrı bir çıktı oluşturur.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Ses Alt Yazılarını Kaldırma**

Tek bir parçacığı silmek için [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) kullanın. Örnek, ilk slayttaki ilk ses çerçevesindeki tüm altyazıları klibi koruyarak kaldırmak için [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) kullanır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **Ses Alt Yazılarında Bir Satırı Bulma**

İlk slayttaki ses altyazılarında bir satırı bulmak için, [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) tarafından döndürülen metni bellekte arayın. Düz metin bir WebVTT ipucu içinde zaman satırı `-->` içerir, altyazı satırları bunun ardından gelir ve boş bir satır ipucunu sonlandırır. Bu örnek, parçacık etiketini ve “café” içeren her altyazı satırını yazdırır.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Ses Çıkarma**

Bir slayt geçişinin kendi sesi olabilir. Onu almak için slayt geçişinde [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) yöntemi çağırın. Örnek, [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) tarafından döndürülen baytları alır ve bayt sayısını yazar. İlk slaytta geçiş sesi yoksa bunun yerine bir mesaj yazar.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Aynı ses klibini birden çok slaytta kopyalamadan tekrar kullanabilir miyim?**

Evet. Klibi sunumun [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) içine bir kez ekleyin ve aynı ses nesnesini her slayt için [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) ile iletin.

**Mevcut bir ses çerçevesindeki sesi değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, değiştirme dosyasına işaret etmek üzere [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) kullanın. Gömülü bir ses için, sunumun ses koleksiyonundan başka bir klibi [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) ile seçin. Her iki yaklaşım da mevcut çerçeveyi korur.

**Kırpma, sunumda saklanan ses verisini değiştirir mi?**

Hayır. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) ve [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) oynatma sınırlarını ayarlar. [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) ile hâlâ tam klibi alabilirsiniz.