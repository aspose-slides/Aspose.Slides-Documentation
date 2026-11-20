---
title: Správa audio rámečků v prezentacích pomocí PHP
linktitle: Audio rámeček
type: docs
weight: 10
url: /cs/php-java/audio-frame/
keywords:
- audio
- audio rámeček
- náhled
- přidat zvuk
- vlastnosti zvuku
- možnosti zvuku
- extrahovat zvuk
- PHP
- Aspose.Slides
description: "Vložte audio do snímků, změňte ikonu audia, nakonfigurujte přehrávání, spravujte WebVTT titulky a extrahujte zvuky přechodů snímků pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Audio rámeček vám umožní přehrát zvuk na snímku. S Aspose.Slides for PHP via Java můžete vložit audio klip, vybrat obrázek, který jej představuje, nastavit přehrávání a připojit titulky. Také můžete získat zvuk přiřazený k přechodu snímku.

## **Vytvoření audio rámečků**

Použijte [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) k vložení místního audio klipu na první snímek. První dvě souřadnice určují umístění rámečku na snímku a další dvě hodnoty nastavují jeho šířku a výšku, vše v bodech. Tento příklad volá [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) pro automatické spuštění klipu a volá [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) pro výběr hlasitosti přednastavené jako vysoká.

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

## **Změna miniatury audio rámečku**

Ve výchozím nastavení audio rámeček zobrazí ikonu reproduktoru. Pro zobrazení vlastní miniatury přidejte obrázek do prezentace pomocí [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) a nastavte jej na obrázek rámečku pomocí [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). Příklad používá JPEG jako miniaturu pro vložený audio klip.

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

## **Změna možností přehrávání audia**

Možnosti **Audio** v PowerPointu určují, kdy klip začne, jak hlasitý bude a jak se bude chovat během prezentace.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Ovládací prvek PowerPoint | Metoda Aspose.Slides for PHP via Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

Příklad najde první audio rámeček na prvním snímku, zavolá [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) pro spuštění přehrávání po kliknutí a vybere přednastavenou nízkou hlasitost. Klip pokračuje napříč snímky s vypnutým opakováním. Ikona zůstane skryta během prezentace a klip se po přehrání přetočí zpět.

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

Pro klip delší než 3,5 s tento příklad přeskočí první 1,5 s a poslední 2 s. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) udává dobu, kterou je třeba odebrat od konce klipu. Pro získání koncového času zobrazeného v PowerPointu odečtěte tento posun od celkové délky klipu. Ořezaný klip se rozsvítí během 200 ms a zhasne během 500 ms. Všechny čtyři metody přijímají hodnoty v milisekundách.

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

Pro nastavení hlasitosti přehrávání na konkrétní procento použijte [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Tento příklad nastaví první audio rámeček na prvním snímku na 85 %.

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

## **Správa audio titulků**

Každý audio rámeček poskytuje přístup k jeho stopám titulků pomocí [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Použijte kolekci k připojení WebVTT titulků ke klipu, exportu existujících stop nebo jejich odebrání.

### **Přidání audio titulků**

Příklad vloží audio klip na první snímek a použije [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) k připojení místní WebVTT stopy. První argument udává název stopy a druhý identifikuje soubor obsahující časované titulky.

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

### **Export audio titulků**

Tento příklad exportuje každou stopu titulků připojenou k audio rámečku na prvním snímku. Zapíše bajty vrácené metodou [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) do souboru WebVTT a použije identifikátor vrácený metodou [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) jako název souboru, aby každá stopa měla samostatný výstup.

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

### **Odstranění audio titulků**

Použijte [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) k smazání jednotlivé stopy. Příklad používá [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) k odstranění všech titulků z prvního audio rámečku na prvním snímku při zachování klipu.

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

### **Vyhledání řádku v audio titulcích**

Pro vyhledání řádku v audio titulcích na prvním snímku prohledejte text vrácený metodou [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) v paměti. V prostém textovém WebVTT cue časová řádka obsahuje `-->`, následně řádky titulků a prázdná řádka ukončuje cue. Tento příklad vytiskne název stopy a každou řádku titulků obsahující „café“.

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

## **Export audia**

Přechod snímku může mít vlastní zvuk. Pro jeho získání zavolejte [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) na přechodu snímku. Příklad přistupuje k bajtům vráceným metodou [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) a vytiskne počet bajtů. Pokud první snímek nemá zvuk přechodu, vytiskne místo toho zprávu.

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

## **Často kladené otázky**

**Mohu použít stejný audio klip na více snímcích, aniž bych ho duplikoval?**

Ano. Přidejte klip jednou do [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) prezentace a předávejte stejný audio objekt metodě [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) pro každý snímek.

**Mohu v existujícím audio rámečku nahradit zvuk?**

Ano. Pro odkazovaný zvuk použijte [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) k nasměrování na náhradní soubor. Pro vložený zvuk vyberte jiný klip z audio kolekce prezentace metodou [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Obě metody zachovají existující rámeček.

**Mění ořezávání samotná audio data uložená v prezentaci?**

Ne. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) a [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) určují hranice přehrávání. Stále můžete získat celý klip pomocí [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).