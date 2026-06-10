---
title: Hangkezelés prezentációkban PHP használatával
linktitle: Hangkeret
type: docs
weight: 10
url: /hu/php-java/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- PHP
- Aspose.Slides
description: "Audio keretek létrehozása és vezérlése az Aspose.Slides for PHP-ban – példakódok a beágyazáshoz, vágáshoz, ismétléshez és a lejátszás konfigurálásához PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat az audio keretekkel az Aspose.Slides-ben. Megmutatja, hogyan adhat beágyazott hangot a diához, testreszabhatja az audio keret bélyegképét, konfigurálhatja a lejátszási beállításokat, például hangerőt, ismétlést, elrejtést, vágást és áttűnési időket, valamint kinyerheti a diavetítés átmeneteihez használt hangot.

## **Audio keretek létrehozása**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy hangfájlokat adjon a diáknál. A hangfájlok beágyazott audio keretként kerülnek a diákba.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg a dia referenciáját az indexe alapján.
3. Töltse be a beágyazni kívánt hangfájl adatfolyamát.
4. Adja hozzá a beágyazott audio keretet (amely a hangfájlt tartalmazza) a diahoz.
5. Állítsa be a [PlayMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/AudioPlayModePreset) és a `Volume` értékeket, amelyeket a [AudioFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/) objektum biztosít.
6. Mentse el a módosított prezentációt.

Ez a PHP kód megmutatja, hogyan adjon beágyazott audio keretet egy diához:

```php
// Létrehozza a Presentation osztály egy példányát, amely egy prezentációs fájlt képvisel
$pres = new Presentation();
try {
    # Megkapja az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Betölti a wav hangfájlt adatfolyamként
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Hozzáadja az Audio Frame-et
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Beállítja a lejátszási módot és a hangerőt az Audio számára
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Kiírja a PowerPoint fájlt a lemezre
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Audio keret bélyegképének módosítása**

Amikor hangfájlt ad a prezentációhoz, a hang egy keretként jelenik meg egy szabványos alapértelmezett képpel (lásd az alábbi szekcióban látható képet). A hangkeret előnézeti képét módosíthatja (állítsa be a kívánt képet).

Ez a PHP kód megmutatja, hogyan módosíthatja egy audio keret bélyegképét vagy előnézeti képét:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Hozzáad egy audio keretet a diára a megadott pozícióval és mérettel.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Hozzáad egy képet a prezentáció erőforrásaihoz.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Beállítja a képet az audio kerethez.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Elmenti a módosított prezentációt a lemezre
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Audio lejátszási beállítások módosítása**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy megváltoztassa a hang lejátszását vagy tulajdonságait szabályozó beállításokat. Például módosíthatja a hangerőt, beállíthatja a hang ismételt lejátszását, vagy akár elrejtheti a hang ikont.

A Microsoft PowerPoint **Audio Options** ablaka:

![example1_image](audio_frame_0.png)

A PowerPoint **Audio Options** beállítások, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/) tulajdonságainak felelnek meg:

- **Start** legördülő lista megfelel az [AudioFrame::setPlayMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setPlayMode) metódusnak
- **Volume** megfelel az [AudioFrame::setVolume](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setVolume) metódusnak
- **Play Across Slides** megfelel az [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) metódusnak
- **Loop until Stopped** megfelel az [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setPlayLoopMode) metódusnak
- **Hide During Show** megfelel az [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setHideAtShowing) metódusnak
- **Rewind after Playing** megfelel az [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setRewindAudio) metódusnak

A PowerPoint **Editing** beállításai, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/) tulajdonságainak felelnek meg:

- **Fade In** megfelel a [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setFadeInDuration) metódusnak
- **Fade Out** megfelel a [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setFadeOutDuration) metódusnak
- **Trim Audio Start Time** megfelel a [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setTrimFromStart) metódusnak
- **Trim Audio End Time** értéke megegyezik a hang időtartamával mínusz a [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setTrimFromEnd) metódus értékével

A PowerPoint **Volume controll** a hangvezérlő panelen a [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#setVolumeValue) metódusnak felel meg. Lehetővé teszi a hangerő százalékos módosítását.

Így módosíthatja az Audio Play beállításokat:

1. [Сreate](#create-audio-frame) vagy szerezze be az Audio Frame-et.
2. Állítson be új értékeket az Audio Frame azon tulajdonságaihoz, amelyeket módosítani szeretne.
3. Mentse el a módosított PowerPoint fájlt.

Ez a PHP kód bemutat egy olyan műveletet, amelyben egy hang beállításai módosulnak:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Lekéri az AudioFrame alakzatot
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Beállítja a lejátszási módot kattintásra
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Beállítja a hangerőt alacsonyra
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Beállítja a hangot, hogy a diákon át lejátszódjon
    $audioFrame->setPlayAcrossSlides(true);
    # Letiltja a hang ismétlését
    $audioFrame->setPlayLoopMode(false);
    # Elrejti az AudioFrame-et a diavetítés alatt
    $audioFrame->setHideAtShowing(true);
    # Visszatekeri a hangot a kezdőpontra a lejátszás után
    $audioFrame->setRewindAudio(true);
    # Elmenti a PowerPoint fájlt a lemezre
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Ez a PHP példa megmutatja, hogyan adjon hozzá egy új audio keretet beágyazott hanggal, hogyan vágja le, és hogyan állítsa be az áttűnési időket:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Beállítja a vágás kezdőeltolását 1,5 másodpercre
    $audioFrame->setTrimFromStart(1500);
    // Beállítja a vágás befejező eltoltását 2 másodpercre
    $audioFrame->setTrimFromEnd(2000);

    // Beállítja a belépő áttűnés időtartamát 200 ms-re
    $audioFrame->setFadeInDuration(200);
    // Beállítja a kilépő áttűnés időtartamát 500 ms-re
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

A következő kódrészlet megmutatja, hogyan szerezzen be egy beágyazott hanggal rendelkező audio keretet, és állítsa be a hangerőét 85%-ra:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Lekéri egy audio keret alakzatot
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Beállítja a hanghangerőt 85%-ra
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Audio feliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#getCaptionTracks) metódussal zárt feliratokat adjon egy audio kerethez. Ez a metódus egy [CaptionsCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT feliratsávok hozzáadását, a meglévő sávok bejárását és azok szükség szerinti eltávolítását.

**Audio feliratok hozzáadása**

Használja a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/#getCaptionTracks) metódust, hogy egy vagy több feliratsávot csatoljon egy audio kerethez. A következő példában egy hangfájlt adnak hozzá egy diához, majd egy új feliratsávot töltenek be egy `.vtt` fájlból.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Új feliratsáv hozzáadása egy WebVTT fájlból.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Audio feliratok kinyerése**

Bejárhatja az audio kerethez társított feliratsávokat, és elmentheti őket `.vtt` fájlokként. Minden feliratsáv kiadja a bináris adatait és egyedi azonosítóját, amely felhasználható a feliratok exportálásakor.

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
                // Ments minden feliratsávot .vtt fájlként.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Audio feliratok eltávolítása**

Az audio keret feliratait a [CaptionsCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/) által biztosított metódusokkal távolíthatja el, például a [clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#remove), vagy a [removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#removeAt) metódusokkal. Az alábbi példa eltávolítja az összes feliratsávot egy audio keretből.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // típus: AudioFrame

    // Az összes feliratsáv eltávolítása az audio keretből.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Audio kinyerése**

Az Aspose.Slides for PHP via Java lehetővé teszi a diavetítés átmeneteihez használt hang kinyerését. Például kinyerheti egy adott dia hangját.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból, és töltse be a hangot tartalmazó prezentációt.
2. Szerezze meg a megfelelő dia referenciáját az indexe alapján.
3. Hozzáférjen a dia [slideshow transitions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseslide/#getSlideShowTransition) beállításaihoz.
4. Kinyerje a hangot bájt adatokként.

Ez a kód megmutatja, hogyan nyerje ki a dián használt hangot:

```php
# Létrehozza a Presentation osztály egy példányát, amely egy prezentációs fájlt képvisel
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Hozzáfér a kívánt diához
	$slide = $pres->getSlides()->get_Item(0);
	# Lekéri a diára vonatkozó diavetítés-átmeneti effektusokat
	$transition = $slide->getSlideShowTransition();
	# Kinyeri a hangot bájt tömbként
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **GYIK**

**Újra felhasználhatom ugyanazt a hangforrást több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a prezentáció közös [audio collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getaudios/) gyűjteményéhez, majd hozzon létre további audio kereteket, amelyek erre a meglévő eszközre hivatkoznak. Ez elkerüli a médiaadatok duplikálását, és a prezentáció méretét kontroll alatt tartja.

**Cserélhetem a hangot egy meglévő audio keretben a forma újra létrehozása nélkül?**

Igen. Egy hivatkozott hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/setlinkpathlong/) mezőt, hogy az új fájlra mutasson. Beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/php-java/aspose.slides/audioframe/setembeddedaudio/) objektumot egy másikra a prezentáció [audio collection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/getaudios/) gyűjteményéből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás módosítja a prezentációban tárolt hang alapvető adatait?**

Nem. A vágás csak a lejátszási határokat módosítja. Az eredeti hangbájtok érintetlenek maradnak, és elérhetők a beágyazott hang vagy a prezentáció audio collection-je segítségével.