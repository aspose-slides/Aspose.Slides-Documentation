---
title: Audio beheren in presentaties met PHP
linktitle: Audio‑frame
type: docs
weight: 10
url: /nl/php-java/audio-frame/
keywords:
- audio
- audio‑frame
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- PHP
- Aspose.Slides
description: "Audio‑frames maken en beheren in Aspose.Slides voor PHP—code‑voorbeelden om in te sluiten, bij te snijden, te loopen en de afspeelinstellingen te configureren voor PPT-, PPTX- en ODP‑presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u met audio‑frames in Aspose.Slides kunt werken. Het laat zien hoe u ingesloten audio aan dia's kunt toevoegen, de miniatuur van het audio‑frame kunt aanpassen, afspeelopties zoals volume, looping, verbergen, trimmen en fade‑tijden kunt configureren, en audio kunt extraheren die wordt gebruikt in diavoorstelling‑overgangen.

## **Audio‑frames maken**

Aspose.Slides for PHP via Java stelt u in staat om audiobestanden aan dia's toe te voegen. De audiobestanden worden in de dia's ingesloten als audio‑frames.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
2. Haal een referentie naar een dia op via de index.
3. Laad de audiobestandsstroom die u in de dia wilt insluiten.
4. Voeg het ingesloten audio‑frame (bevat het audiobestand) toe aan de dia.
5. Stel [PlayMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/AudioPlayModePreset) en `Volume` in die door het [AudioFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/)‑object worden aangeboden.
6. Sla de gewijzigde presentatie op.

Deze PHP‑code laat zien hoe u een ingesloten audio‑frame aan een dia toevoegt:

```php
// Instantieert een Presentation‑klasse die een presentiebestand vertegenwoordigt
$pres = new Presentation();
try {
    # Haalt de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Laadt het wav‑geluidsbestand naar een stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Voegt het audio‑frame toe
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Stelt de afspeelmodus en het volume van de audio in
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Schrijft het PowerPoint‑bestand naar schijf
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Miniatuur van het audio‑frame wijzigen**

Wanneer u een audiobestand aan een presentatie toevoegt, wordt de audio weergegeven als een frame met een standaard afbeelding (zie de afbeelding in de sectie hieronder). U kunt de voorbeeldafbeelding van het audio‑frame wijzigen (stel uw voorkeursafbeelding in).

Deze PHP‑code laat zien hoe u de miniatuur of voorbeeldafbeelding van een audio‑frame wijzigt:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Voegt een audio‑frame toe aan de dia met een opgegeven positie en grootte.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Voegt een afbeelding toe aan de presentatiemiddelen.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Stelt de afbeelding in voor het audio‑frame.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Slaat de gewijzigde presentatie op naar schijf
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Audio‑afspeelopties wijzigen**

Aspose.Slides for PHP via Java stelt u in staat om opties te wijzigen die de afspeelwijze of eigenschappen van audio regelen. U kunt bijvoorbeeld het volume van de audio aanpassen, de audio in een lus laten afspelen, of zelfs het audio‑pictogram verbergen.

Het **Audio‑opties**‑venster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑opties** die overeenkomen met de eigenschappen van Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/) :

- **Start**‑keuzelijst komt overeen met de [AudioFrame::setPlayMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setPlayMode) methode
- **Volume** komt overeen met de [AudioFrame::setVolume](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setVolume) methode
- **Play Across Slides** komt overeen met de [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) methode
- **Loop until Stopped** komt overeen met de [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setPlayLoopMode) methode
- **Hide During Show** komt overeen met de [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setHideAtShowing) methode
- **Rewind after Playing** komt overeen met de [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setRewindAudio) methode

PowerPoint **Bewerkings**‑opties die overeenkomen met de eigenschappen van Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/) :

- **Fade In** komt overeen met de [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setFadeInDuration) methode 
- **Fade Out** komt overeen met de [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setFadeOutDuration) methode 
- **Trim Audio Start Time** komt overeen met de [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setTrimFromStart) methode 
- **Trim Audio End Time**‑waarde is gelijk aan de audioduur min de waarde van de [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setTrimFromEnd) methode

De PowerPoint **volumeregelaar** op het audiobedieningspaneel komt overeen met de [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#setVolumeValue) methode. Hiermee kunt u het volume van de audio als percentage aanpassen.

Zo wijzigt u de audio‑afspeelopties:

1. [Create](#create-audio-frame) of haal het audio‑frame op.
2. Stel nieuwe waarden in voor de audio‑frame‑eigenschappen die u wilt aanpassen.
3. Sla het gewijzigde PowerPoint‑bestand op.

Deze PHP‑code demonstreert een bewerking waarbij de opties van een audio worden aangepast:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Haalt de AudioFrame vorm op
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Stelt de afspeelmodus in op afspelen bij klikken
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Stelt het volume in op laag
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Stelt de audio in om af te spelen over dia's
    $audioFrame->setPlayAcrossSlides(true);
    # Schakelt het loopen van de audio uit
    $audioFrame->setPlayLoopMode(false);
    # Verbergt de AudioFrame tijdens de diavoorstelling
    $audioFrame->setHideAtShowing(true);
    # Spoelt de audio terug naar het begin na het afspelen
    $audioFrame->setRewindAudio(true);
    # Slaat het PowerPoint bestand op naar schijf
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Dit PHP‑voorbeeld laat zien hoe u een nieuw audio‑frame met ingesloten audio toevoegt, het bijsnijdt en de fade‑tijden instelt:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Stelt de trim start offset in op 1,5 seconden
    // Stelt de trim eind offset in op 2 seconden
    // Stelt de fade-in duur in op 200 ms
    // Stelt de fade-out duur in op 500 ms

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

De volgende codevoorbeelden laten zien hoe u een audio‑frame met ingesloten audio ophaalt en het volume instelt op 85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Haalt een audio‑frame vorm op
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Stelt het audio‑volume in op 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Audiocapties beheren**

Aspose.Slides laat u toe om ondertitels toe te voegen aan een audio‑frame via de [getCaptionTracks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#getCaptionTracks) methode. Deze methode retourneert een [CaptionsCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/), waarmee u WebVTT‑ondertiteltracks kunt toevoegen, door bestaande tracks kunt itereren en ze kunt verwijderen indien nodig.

### **Audiocapties toevoegen**

Gebruik de [getCaptionTracks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/#getCaptionTracks) methode om één of meerdere ondertiteltracks aan een audio‑frame te koppelen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd en vervolgens wordt een nieuwe ondertiteltrack geladen vanuit een `.vtt`‑bestand.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Voeg een nieuw ondertiteltrack toe vanuit een WebVTT-bestand.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Audiocapties extraheren**

U kunt door de ondertiteltracks die aan een audio‑frame zijn gekoppeld itereren en ze opslaan als `.vtt`‑bestanden. Elke ondertiteltrack geeft zijn binaire gegevens en unieke identifier weer, die bij het exporteren van ondertitels kan worden gebruikt.

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
                // Bewaar elk ondertiteltrack als een .vtt-bestand.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Audiocapties verwijderen**

Om ondertitels van een audio‑frame te verwijderen, gebruikt u de methoden die door [CaptionsCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/) worden aangeboden, zoals [clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/#remove), of [removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/#removeAt). Het volgende voorbeeld verwijdert alle ondertiteltracks van een audio‑frame.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // type: AudioFrame

    // Verwijder alle ondertiteltracks van het audio‑frame.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Audio extraheren**

Aspose.Slides for PHP via Java stelt u in staat om het geluid dat wordt gebruikt bij diavoorstelling‑overgangen te extraheren. U kunt bijvoorbeeld het geluid extraheren dat in een specifieke dia wordt gebruikt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse en laad de presentatie die de audio bevat.
2. Haal de referentie naar de betreffende dia op via de index.
3. Open de [slideshow transitions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getSlideShowTransition) voor de dia.
4. Extraheer het geluid in byte‑gegevens.

Deze code laat zien hoe u het audio‑bestand dat in een dia wordt gebruikt, kunt extraheren:

```php
# Instantieert een Presentation‑klasse die een presentiebestand vertegenwoordigt
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Haalt de gewenste dia op
	$slide = $pres->getSlides()->get_Item(0);
	# Haalt de diavoorstelling‑overgangseffecten op voor de dia
	$transition = $slide->getSlideShowTransition();
	# Extraheert het geluid in een byte‑array
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Kan ik dezelfde audio‑bron hergebruiken op meerdere dia's zonder de bestandsgrootte op te blazen?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio‑collectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getaudios/) van de presentatie en maak extra audio‑frames die naar dat bestaande bestand verwijzen. Dit voorkomt duplicatie van mediagegevens en houdt de presentatiegrootte onder controle.

**Kan ik het geluid in een bestaand audio‑frame vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gekoppeld geluid werkt u het [link path](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/setlinkpathlong/) bij zodat het naar het nieuwe bestand verwijst. Voor een ingesloten geluid vervangt u het [embedded audio](https://reference.aspose.com/slides/nl/php-java/aspose.slides/audioframe/setembeddedaudio/)‑object door een ander uit de [audio‑collectie](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/getaudios/) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven behouden.

**Verandert trimmen de onderliggende audiogegevens die in de presentatie zijn opgeslagen?**

Nee. Trimmen past alleen de afspeelgrenzen aan. De oorspronkelijke audiobytes blijven onveranderd en zijn toegankelijk via de ingesloten audio of de audio‑collectie van de presentatie.