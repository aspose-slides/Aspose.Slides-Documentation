---
title: Hangkeretek kezelése prezentációkban PHP használatával
linktitle: Hangkeret
type: docs
weight: 10
url: /hu/php-java/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságai
- hang beállításai
- hang kinyerése
- PHP
- Aspose.Slides
description: "Ágyazz be hangot a diákba, módosítsd a hang ikont, állítsd be a lejátszást, kezeld a WebVTT feliratokat, és nyerd ki a diákátmenet hangjait az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

Az audio keret lehetővé teszi, hogy hangot játssz le egy dián. Az Aspose.Slides for PHP via Java segítségével beágyazhatsz egy audio klipet, kiválaszthatod a képét, amely azt reprezentálja, beállíthatod a lejátszást, és felveheted a feliratokat. A diákátmenethez rendelt hangot is lekérheted.

## **Hangkeretek létrehozása**

Használd a [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) metódust egy helyi audio klip beágyazásához az első diára. Az első két koordináta pozícionálja a keretet a dián, a következő két érték a szélességét és magasságát állítja be pontokban. Ez a példa meghívja a [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) metódust a klip automatikus indításához, és a [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) metódust a hangos előbeállítás kiválasztásához.

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

## **Az audio keret bélyegképének módosítása**

Alapértelmezés szerint egy audio keret a hangszóró ikont jeleníti meg. Egy egyéni bélyegkép megjelenítéséhez adj egy képet a prezentációhoz a [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) segítségével, és állítsd be a keret képeként a [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/) metódussal. A példa egy JPEG-et használ bélyegképként a beágyazott audio kliphez.

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

## **Az audio lejátszási beállítások módosítása**

A PowerPoint **Audio Options** vezérlői határozzák meg, hogy mikor indul a klip, milyen hangerővel szól, és hogyan viselkedik a diavetítés során.

![PowerPoint audio beállítási vezérlők egy audio kerethez](audio_frame_0.png)

| PowerPoint vezérlő | Aspose.Slides for PHP via Java metódus |
| --- | --- |
| Indítás | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Hangerő előbeállítás | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Lejátszás diák között | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Ismétlés leállításig | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Elrejtés bemutató alatt | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Visszatekerés lejátszás után | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Beúsztatás | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Kiesés | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Kezdeti idő vágása | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Vége idő vágása | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Hangerő csúszka | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

A példa megtalálja az első audio keretet az első dián, meghívja a [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) metódust a lejátszás kattintásra indításához, és az alacsony hangerő előbeállítást választja. A klip a diákon át folytatódik, a ciklus le van tiltva. Az ikon rejtve marad a bemutató alatt, és a klip a lejátszás után visszatekerődik.

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

3,5 másodpercnél hosszabb klip esetén ez a példa kihagyja az első 1,5 másodpercet és az utolsó 2 másodpercet. A [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) a klip végéről elhagyandó időt veszi. A PowerPointban látható végidő megszerzéséhez vonja le ezt az eltolást a teljes klip hosszából. A vágott klip 200 ms alatt húzódik be és 500 ms alatt húzódik ki. Mind a négy metódus értékei ezredmásodpercben értendők.

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

A lejátszási hangerő egy adott százalékra állításához használd a [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) metódust. Ez a példa az első audio keretet az első dián 85%-ra állítja.

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

## **Audio feliratok kezelése**

Minden audio keret hozzáférést biztosít a feliratsávjaihoz a [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) segítségével. Használd a gyűjteményt WebVTT feliratok csatolásához a kliphez, meglévő sávok exportálásához vagy eltávolításához.

### **Audio feliratok hozzáadása**

A példa egy audio klipet ágyaz be az első diára, és a [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) metódust használja egy helyi WebVTT sáv csatolásához. Az első argumentum a sáv címkéjét adja meg, a második pedig a időzített feliratokat tartalmazó fájlt határozza meg.

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

### **Audio feliratok kinyerése**

Ez a példa exportálja az első dián egy audio kerethez csatolt minden feliratsávot. A [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) által visszaadott bájtokat egy WebVTT fájlba írja, és a [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) által visszaadott azonosítót használja fájlnévként, így minden sáv külön kimenettel rendelkezik.

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

### **Audio feliratok eltávolítása**

Használd a [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) vagy [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) metódust egy egyedi sáv törléséhez. A példa a [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) metódust használja az első audio keret összes feliratának eltávolításához az első dián, miközben a klip megmarad.

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

### **Sor keresése audio feliratokban**

Hogy megtalálj egy sort az első dián az audio feliratokban, keresd a [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) által visszaadott szöveget a memóriában. Egy egyszerű szöveges WebVTT cue-ban az időzítő sor `-->` karaktert tartalmaz, ezt követik a feliratsorok, és egy üres sor zárja a cue-t. Ez a példa kiírja a sáv címkéjét és minden feliratsort, amely a „café” szót tartalmazza.

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

## **Audio kinyerése**

Egy diákátmenetnek is lehet saját hangja. Ennek lekéréséhez hívd meg a [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) metódust a diákátmeneten. A példa a [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) által visszaadott bájtokat érinti, és kiírja a bájtok számát. Ha az első diáknak nincs átmeneti hangja, akkor egy üzenetet ír ki.

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

## **GYIK**

**Can I reuse the same audio clip across multiple slides without duplicating it?**  
**Használhatom ugyanazt az audio klipet több dián anélkül, hogy többször megkettőzném?**  

Igen. Add hozzá a klipet egyszer a prezentáció [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) gyűjteményéhez, és minden dián a ugyanazt az audio objektumot adod át a [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) metódusnak.

**Can I replace the sound in an existing audio frame?**  
**Lecserélhetem a hangot egy meglévő audio keretben?**  

Igen. Hivatkozott hang esetén használd a [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) metódust, hogy a cserélni kívánt fájlra mutasson. Beágyazott hang esetén válassz egy másik klipet a prezentáció audio gyűjteményéből a [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) segítségével. Mindkét megközelítés megőrzi a meglévő keretet.

**Does trimming change the audio data stored in the presentation?**  
**Megváltoztatja a vágás a prezentációban tárolt audio adatot?**  

Nem. A [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) és a [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) csak a lejátszási határokat állítják be. A teljes klip továbbra is lekérhető a [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) metódussal.