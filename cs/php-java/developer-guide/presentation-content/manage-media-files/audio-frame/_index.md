---
title: "Správa audia v prezentacích pomocí PHP"
linktitle: "Audio rámec"
type: docs
weight: 10
url: /cs/php-java/audio-frame/
keywords:
- "zvuk"
- "audio rámec"
- "náhled"
- "přidat zvuk"
- "vlastnosti zvuku"
- "možnosti zvuku"
- "extrahovat zvuk"
- "PHP"
- "Aspose.Slides"
description: "Vytvořte a ovládejte audio rámy v Aspose.Slides pro PHP — příklady kódu pro vložení, oříznutí, smyčkování a nastavení přehrávání v prezentacích PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámci v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, přizpůsobit miniaturu audio rámce, nakonfigurovat možnosti přehrávání jako hlasitost, smyčkování, skrytí, oříznutí a dobu prolínání, a jak extrahovat zvuk použité v přechodech prezentace.

## **Vytvoření audio rámců**

Aspose.Slides pro PHP pomocí Java vám umožňuje přidávat zvukové soubory do snímků. Zvukové soubory jsou vkládány do snímků jako audio rámce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Načtěte stream zvukového souboru, který chcete vložit do snímku.
4. Přidejte vložený audio rámec (obsahující zvukový soubor) do snímku.
5. Nastavte [PlayMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/AudioPlayModePreset) a `Volume`, které jsou k dispozici u objektu [AudioFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/).
6. Uložte upravenou prezentaci.

Tento PHP kód vám ukazuje, jak přidat vložený audio rámec do snímku:

```php
// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
$pres = new Presentation();
try {
    # Získá první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Načte soubor wav zvuku do streamu
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Přidá audio rámec
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Nastaví režim přehrávání a hlasitost audia
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Zapíše soubor PowerPoint na disk
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Změna miniatury audio rámce**

Když přidáte zvukový soubor do prezentace, zvuk se zobrazí jako rámec se standardním výchozím obrázkem (viz obrázek v následující sekci). Můžete změnit náhledový obrázek audio rámce (nastavte svůj preferovaný obrázek).

Tento PHP kód vám ukazuje, jak změnit miniaturu nebo náhledový obrázek audio rámce:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Přidá audio rámec na snímek se zadanou pozicí a velikostí.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Přidá obrázek do zdrojů prezentace.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Nastaví obrázek pro audio rámec.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Uloží upravenou prezentaci na disk
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Změna možností přehrávání audia**

Aspose.Slides pro PHP pomocí Java umožňuje měnit možnosti, které ovlivňují přehrávání nebo vlastnosti audia. Například můžete upravit hlasitost audia, nastavit přehrávání ve smyčce nebo dokonce skrýt ikonu audia.

Panel **Audio Options** v Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Možnosti **Audio Options** v PowerPointu, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/) :

- **Start** rozbalovací seznam odpovídá metodě [AudioFrame::setPlayMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** odpovídá metodě [AudioFrame::setVolume](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** odpovídá metodě [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** odpovídá metodě [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** odpovídá metodě [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** odpovídá metodě [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setRewindAudio)

Možnosti **Editing** v PowerPointu, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/) :

- **Fade In** odpovídá metodě [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** odpovídá metodě [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** odpovídá metodě [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** má hodnotu rovnou délce zvuku minus hodnota z metody [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Regulátor **Volume** v ovládacím panelu audia v PowerPointu odpovídá metodě [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#setVolumeValue). Umožňuje změnit hlasitost audia v procentech.

Takto změníte možnosti přehrávání audia:

1. [Vytvořte](#create-audio-frame) nebo získejte Audio Frame.
2. Nastavte nové hodnoty pro vlastnosti Audio Frame, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

Tento PHP kód demonstruje operaci, při které jsou upraveny možnosti audia:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Získá tvar AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Nastaví režim přehrávání na přehrání po kliknutí
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Nastaví hlasitost na Nízkou
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Nastaví audio k přehrávání napříč snímky
    $audioFrame->setPlayAcrossSlides(true);
    # Zakáže smyčku pro audio
    $audioFrame->setPlayLoopMode(false);
    # Skryje AudioFrame během prezentace
    $audioFrame->setHideAtShowing(true);
    # Převine audio na začátek po přehrání
    $audioFrame->setRewindAudio(true);
    # Uloží soubor PowerPoint na disk
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Tento PHP příklad ukazuje, jak přidat nový audio rámec s vloženým zvukem, oříznout jej a nastavit doby prolínání:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Nastaví počáteční offset ořezu na 1,5 sekundy
    $audioFrame->setTrimFromStart(1500);
    // Nastaví koncový offset ořezu na 2 sekundy
    $audioFrame->setTrimFromEnd(2000);

    // Nastaví dobu fade-in na 200 ms
    $audioFrame->setFadeInDuration(200);
    // Nastaví dobu fade-out na 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Následující ukázka kódu ukazuje, jak načíst audio rámec s vloženým zvukem a nastavit jeho hlasitost na 85 %:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Získá tvar audio rámce
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Nastaví hlasitost audia na 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Správa titulků audia**

Aspose.Slides vám umožňuje přidat uzavřené titulky k audio rámci pomocí metody [getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#getCaptionTracks). Tato metoda vrací objekt [CaptionsCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/), který umožňuje přidávat stopy titulků WebVTT, procházet existující stopy a při potřebe je odstraňovat.

**Přidání titulků audia**

Použijte metodu [getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/#getCaptionTracks) k připojení jedné nebo více stop titulků k audio rámci. V následujícím příkladu je k snímku přidán zvukový soubor a poté je načtena nová stopa titulků ze souboru `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Přidejte novou stopu titulků z WebVTT souboru.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extrahování titulků audia**

Můžete procházet stopy titulků spojené s audio rámcem a uložit je jako soubory `.vtt`. Každá stopa titulků poskytuje svá binární data a jedinečný identifikátor, který lze použít při exportu titulků.

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
                // Uložte každou stopu titulků jako soubor .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Odstranění titulků audia**

Pro odstranění titulků z audio rámce použijte metody poskytované třídou [CaptionsCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/), jako jsou [clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#remove), nebo [removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#removeAt). Následující příklad odstraňuje všechny stopy titulků z audio rámce.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // typ: AudioFrame

    // Odstraní všechny stopy titulků z audio rámce.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extrahování audia**

Aspose.Slides pro PHP pomocí Java vám umožňuje extrahovat zvuk použitý v přechodech prezentace. Například můžete extrahovat zvuk použitý v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) a načtěte prezentaci obsahující zvuk.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Získejte [slideshow transitions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseslide/#getSlideShowTransition) pro tento snímek.
4. Extrahujte zvuk jako bajtová data.

Tento kód vám ukazuje, jak extrahovat zvuk použitý v snímku:

```php
# Vytvoří instanci třídy Presentation, která představuje soubor prezentace
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Přistoupí k požadovanému snímku
	$slide = $pres->getSlides()->get_Item(0);
	# Získá efekty přechodu prezentace pro snímek
	$transition = $slide->getSlideShowTransition();
	# Extrahuje zvuk do pole bajtů
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Mohu znovu použít stejný zvukový soubor na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte zvuk jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getaudios/) prezentace a vytvořte další audio rámce, které odkazují na tento existující prostředek. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu vyměnit zvuk v existujícím audio rámci, aniž bych znovu vytvářel tvar?**

Ano. U propojeného zvuku aktualizujte [link path](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/setlinkpathlong/) tak, aby ukazoval na nový soubor. U vloženého zvuku vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/php-java/aspose.slides/audioframe/setembeddedaudio/) za jiný z [audio collection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getaudios/) prezentace. Formátování rámce a většina nastavení přehrávání zůstane zachována.

**Změní oříznutí podkladová audio data uložená v prezentaci?**

Ne. Oříznutí upravuje pouze hranice přehrávání. Originální audio bajty zůstávají nedotčeny a jsou přístupné přes vložený zvuk nebo audio kolekci prezentace.