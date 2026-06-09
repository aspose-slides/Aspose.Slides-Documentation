---
title: PHP ile Sunumlarda Ses Yönetimi
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
description: "Aspose.Slides for PHP'te ses çerçevelerini oluşturun ve kontrol edin—PPT, PPTX ve ODP sunumlarında gömme, kırpma, döngü ve oynatma ayarlarını yapılandırmaya yönelik kod örnekleri."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te ses çerçeveleriyle nasıl çalışılacağını açıklar. Slaytlara gömülü ses ekleme, ses çerçevesi küçük resmini özelleştirme, ses oynatma seçeneklerini (ses düzeyi, döngü, gizleme, kırpma ve geçiş süreleri) yapılandırma ve slayt gösterisi geçişlerinde kullanılan sesleri çıkarma konularını gösterir.

## **Ses Çerçeveleri Oluşturma**

Aspose.Slides for PHP via Java, slaytlara ses dosyaları eklemenizi sağlar. Ses dosyaları slaytlara ses çerçeveleri olarak gömülür.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Slaydın indeksinden slayt referansını alın.
3. Slayta gömmek istediğiniz ses dosyası akışını yükleyin.
4. Gömülü ses çerçevesini (ses dosyasını içeren) slayta ekleyin.
5. [AudioFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/) nesnesi tarafından sunulan `PlayMode` ve `Volume` ayarlarını yapın.
6. Değiştirilmiş sunumu kaydedin.

Bu PHP kodu bir slayta gömülü ses çerçevesi eklemeyi gösterir:

```php
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekler
$pres = new Presentation();
try {
    # İlk slaytı alır
    $sld = $pres->getSlides()->get_Item(0);
    # wav ses dosyasını akışa yükler
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Ses Çerçevesini ekler
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Sesin Oynatma Modunu ve Ses Düzeyini ayarlar
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # PowerPoint dosyasını diske yazar
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Ses Çerçevesi Küçük Resmini Değiştirme**

Bir ses dosyasını sunuma eklediğinizde, ses standart bir varsayılan resimle bir çerçeve olarak görünür (aşağıdaki bölümdeki resme bakın). Ses çerçevesinin önizleme resmini (tercih ettiğiniz resmi) değiştirebilirsiniz.

Bu PHP kodu ses çerçevesinin küçük resmini veya önizleme resmini nasıl değiştireceğinizi gösterir:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Belirtilen konum ve boyutta slayta bir ses çerçevesi ekler.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Sunum kaynaklarına bir resim ekler.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Ses çerçevesi için resmi ayarlar.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----
	
	# Değiştirilmiş sunumu diske kaydeder
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Ses Oynatma Seçeneklerini Değiştirme**

Aspose.Slides for PHP via Java, bir sesin oynatılmasını veya özelliklerini kontrol eden seçenekleri değiştirmenizi sağlar. Örneğin, sesin ses düzeyini ayarlayabilir, sesin döngüde çalmasını sağlayabilir veya ses simgesini gizleyebilirsiniz.

Microsoft PowerPoint'teki **Audio Options** bölmesi:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** bölmesi, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/) özelliklerine karşılık gelir:

- **Start** açılır listesi, [AudioFrame::setPlayMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setPlayMode) yöntemiyle eşleşir
- **Volume** değeri, [AudioFrame::setVolume](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setVolume) yöntemiyle eşleşir
- **Play Across Slides** seçeneği, [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) yöntemiyle eşleşir
- **Loop until Stopped** seçeneği, [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setPlayLoopMode) yöntemiyle eşleşir
- **Hide During Show** seçeneği, [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setHideAtShowing) yöntemiyle eşleşir
- **Rewind after Playing** seçeneği, [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setRewindAudio) yöntemiyle eşleşir

PowerPoint **Editing** seçenekleri, Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/) özelliklerine karşılık gelir:

- **Fade In** seçeneği, [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setFadeInDuration) yöntemiyle eşleşir
- **Fade Out** seçeneği, [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setFadeOutDuration) yöntemiyle eşleşir
- **Trim Audio Start Time** seçeneği, [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setTrimFromStart) yöntemiyle eşleşir
- **Trim Audio End Time** değeri, ses süresinden [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setTrimFromEnd) metodunun değeri çıkarılarak elde edilir

PowerPoint'teki ses kontrol panelindeki **Volume controll** (Ses Kontrolü), [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#setVolumeValue) yöntemine karşılık gelir. Yüzde olarak ses seviyesini değiştirmenizi sağlar.

Ses Oynatma seçeneklerini nasıl değiştireceğiniz aşağıda gösterilmiştir:

1. [Сreate](#create-audio-frame) ya da Audio Frame’i alın.
2. Ayarlamak istediğiniz Audio Frame özelliklerine yeni değerler atayın.
3. Değiştirilmiş PowerPoint dosyasını kaydedin.

Bu PHP kodu, bir sesin seçeneklerinin ayarlandığı bir işlemi gösterir:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # AudioFrame şekli alınır
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Oynatma modunu tıklanınca çalacak şekilde ayarlar
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Ses seviyesini Düşük olarak ayarlar
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Sesin slaytlar boyunca çalmasını ayarlar
    $audioFrame->setPlayAcrossSlides(true);
    # Ses için döngüyü devre dışı bırakır
    $audioFrame->setPlayLoopMode(false);
    # Sunum sırasında AudioFrame'i gizler
    $audioFrame->setHideAtShowing(true);
    # Ses çalındıktan sonra başa sarar
    $audioFrame->setRewindAudio(true);
    # PowerPoint dosyasını diske kaydeder
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Bu PHP örneği, gömülü ses içeren yeni bir ses çerçevesi eklemeyi, kırpmayı ve geçiş sürelerini ayarlamayı gösterir:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Kesme başlangıç ofsetini 1.5 saniyeye ayarlar
    $audioFrame->setTrimFromStart(1500);
    // Kesme bitiş ofsetini 2 saniyeye ayarlar
    $audioFrame->setTrimFromEnd(2000);

    // Fade-in süresini 200 ms olarak ayarlar
    $audioFrame->setFadeInDuration(200);
    // Fade-out süresini 500 ms olarak ayarlar
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Aşağıdaki kod örneği, gömülü ses içeren bir ses çerçevesini alıp ses seviyesini %85’e ayarlamayı gösterir:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Bir ses çerçevesi şekli alır
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Ses seviyesini %85'e ayarlar
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Ses Altyazılarını Yönetme**

Aspose.Slides, [getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#getCaptionTracks) yöntemi aracılığıyla bir ses çerçevesine kapalı altyazılar eklemenizi sağlar. Bu yöntem bir [CaptionsCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/) döndürür; bu koleksiyon sayesinde WebVTT altyazı izleri ekleyebilir, mevcut izler arasında döngü yapabilir ve gerektiğinde silebilirsiniz.

**Ses Altyazılarını Ekleme**

[ getCaptionTracks](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/#getCaptionTracks) yöntemini kullanarak bir ses çerçevesine bir veya daha fazla altyazı izi ekleyin. Aşağıdaki örnekte bir ses dosyası slayta eklenir ve ardından bir `.vtt` dosyasından yeni bir altyazı izi yüklenir.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // WebVTT dosyasından yeni bir altyazı izi ekle.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Ses Altyazılarını Çıkarma**

Ses çerçevesine bağlı altyazı izlerini döngüleyebilir ve `.vtt` dosyaları olarak kaydedebilirsiniz. Her altyazı izi, ikili verisini ve benzersiz tanımlayıcısını dışa aktarma sırasında kullanmanıza olanak tanır.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // Her altyazı izini .vtt dosyası olarak kaydet.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Ses Altyazılarını Kaldırma**

Bir ses çerçevesinden altyazıları kaldırmak için [CaptionsCollection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/) tarafından sağlanan yöntemleri kullanın; örneğin [clear](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#remove) veya [removeAt](https://reference.aspose.com/slides/tr/php-java/aspose.slides/captionscollection/#removeAt). Aşağıdaki örnek, bir ses çerçevesinden tüm altyazı izlerini kaldırır.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // tür: AudioFrame

    // Ses çerçevesinden tüm altyazı izlerini kaldır.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ses Çıkarma**

Aspose.Slides for PHP via Java, slayt gösterisi geçişlerinde kullanılan sesleri çıkarmanıza olanak tanır. Örneğin, belirli bir slaytta kullanılan sesi çıkarabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun ve ses içeren sunumu yükleyin.
2. İlgili slaydın indeksinden slayt referansını alın.
3. Slayd için [slideshow transitions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/baseslide/#getSlideShowTransition) öğesine erişin.
4. Sesi bayt verisi olarak çıkarın.

Bu kod, bir slaytta kullanılan sesi nasıl çıkaracağınızı gösterir:

```php
# Sunum dosyasını temsil eden bir Presentation sınıfını örnekler
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# İstenen slayta erişir
	$slide = $pres->getSlides()->get_Item(0);
	# Slayt için slayt gösterisi geçiş efektlerini alır
	$transition = $slide->getSlideShowTransition();
	# Sesi bayt dizisi olarak çıkarır
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **SSS**

**Aynı ses varlığını birden çok slaytta dosya boyutunu artırmadan yeniden kullanabilir miyim?**

Evet. Ses varlığını sunumun ortak [audio collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getaudios/) içine bir kez ekleyin ve bu varlığı referans alan ek ses çerçeveleri oluşturun. Böylece medya verisinin tekrarlanması önlenir ve sunum boyutu kontrol altında tutulur.

**Mevcut bir ses çerçevesindeki sesi şekli yeniden oluşturmadan değiştirebilir miyim?**

Evet. Bağlantılı bir ses için, [link path](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/setlinkpathlong/)’i yeni dosyaya yönlendirin. Gömülü bir ses için, [embedded audio](https://reference.aspose.com/slides/tr/php-java/aspose.slides/audioframe/setembeddedaudio/) nesnesini sunumun [audio collection](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/getaudios/) içindeki başka bir nesneyle değiştirin. Çerçevenin biçimlendirmesi ve çoğu oynatma ayarı aynı kalır.

**Kırpma, sunumda saklanan temel ses verisini değiştirir mi?**

Hayır. Kırpma yalnızca oynatma sınırlarını ayarlar. Orijinal ses baytları dokunulmamış olarak kalır ve gömülü ses ya da sunumun ses koleksiyonu aracılığıyla erişilebilir.