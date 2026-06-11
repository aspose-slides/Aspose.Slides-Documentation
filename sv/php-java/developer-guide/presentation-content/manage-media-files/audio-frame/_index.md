---
title: Hantera ljud i presentationer med PHP
linktitle: Ljudram
type: docs
weight: 10
url: /sv/php-java/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- PHP
- Aspose.Slides
description: "Skapa och kontrollera ljudramar i Aspose.Slides för PHP—kodexempel för att bädda in, trimma, loopa och konfigurera uppspelning i PPT-, PPTX- och ODP-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med ljudramar i Aspose.Slides. Den visar hur man lägger till inbäddat ljud i bilder, anpassar miniatyrbilden för ljudramen, konfigurerar uppspelningsalternativ såsom volym, loopning, dölja, trimning och toningsvaraktigheter, samt extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**

Aspose.Slides för PHP via Java låter dig lägga till ljudfiler i bilder. Ljudfilerna inbäddas i bilder som ljudramar.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta en bilds referens via dess index.
3. Läs in ljudfilströmmen du vill inbädda i bilden.
4. Lägg till den inbäddade ljudramen (som innehåller ljudfilen) till bilden.
5. Ställ in [PlayMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/AudioPlayModePreset) och `Volume` som exponeras av objektet [AudioFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/).
6. Spara den ändrade presentationen.

Denna PHP‑kod visar hur du lägger till en inbäddad ljudram till en bild:

```php
// Instansierar en Presentation-klass som representerar en presentationsfil
$pres = new Presentation();
try {
    # Hämtar den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Laddar wav‑ljudfilen till en ström
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Lägger till ljudramen
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Ställer in uppspelningsläge och volym för ljudet
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Skriver PowerPoint‑filen till disk
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Ändra ljudramens miniatyrbild**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardförvald bild (se bilden i avsnittet nedan). Du kan ändra ljudramens förhandsbild (ange din föredragna bild).

Denna PHP‑kod visar hur du ändrar en ljudramens miniatyrbild eller förhandsbild:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Lägger till en ljudram på bilden med en angiven position och storlek.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Lägger till en bild i presentationens resurser.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Ställer in bilden för ljudramen.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----
	
	# Sparar den ändrade presentationen till disk
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Ändra ljuduppspelningsalternativ**

Aspose.Slides för PHP via Java låter dig ändra alternativ som styr ett ljuds uppspelning eller egenskaper. Till exempel kan du justera ett ljuds volym, ställa in ljudet att spelas i loop, eller till och med dölja ljudikonen.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/) egenskaper:

- **Start**‑rullgardinslistan matchar metoden [AudioFrame::setPlayMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** matchar metoden [AudioFrame::setVolume](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** matchar metoden [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** matchar metoden [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** matchar metoden [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** matchar metoden [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setRewindAudio).

PowerPoint **Editing**‑alternativ som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/) egenskaper:

- **Fade In** matchar metoden [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** matchar metoden [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** matchar metoden [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time** värdet är ljudets varaktighet minus värdet från metoden [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setTrimFromEnd).

PowerPoint **Volume control** på ljudkontrollpanelen motsvarar metoden [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#setVolumeValue). Den låter dig ändra ljudvolymen i procent.

Så här ändrar du ljuduppspelningsalternativen:

1. [Skapa](#create-audio-frame) eller hämta ljudramen.
2. Ställ in nya värden för de Audio Frame‑egenskaper du vill justera.
3. Spara den ändrade PowerPoint‑filen.

Denna PHP‑kod demonstrerar en operation där ett ljuds alternativ justeras:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Hämtar AudioFrame-formen
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Ställer in uppspelningsläget till att spela vid klick
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Ställer in volymen till Låg
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Ställer in ljudet att spelas över bilder
    $audioFrame->setPlayAcrossSlides(true);
    # Inaktiverar loop för ljudet
    $audioFrame->setPlayLoopMode(false);
    # Döljer AudioFrame under bildspelet
    $audioFrame->setHideAtShowing(true);
    # Spolar tillbaka ljudet till start efter uppspelning
    $audioFrame->setRewindAudio(true);
    # Sparar PowerPoint-filen till disk
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Detta PHP‑exempel visar hur man lägger till en ny ljudram med inbäddat ljud, trimmar den och anger toningsvaraktigheterna:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Ställer in trimnings startoffset till 1,5 sekunder
    $audioFrame->setTrimFromStart(1500);
    // Ställer in trimnings slutoffset till 2 sekunder
    $audioFrame->setTrimFromEnd(2000);

    // Ställer in fade-in varaktighet till 200 ms
    $audioFrame->setFadeInDuration(200);
    // Ställer in fade-out varaktighet till 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Följande kodexempel visar hur man hämtar en ljudram med inbäddat ljud och sätter dess volym till 85 %:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Hämtar en ljudramform
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Ställer in ljudvolymen till 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Hantera ljudtextning**

Aspose.Slides låter dig lägga till stängda undertexter till en ljudram via metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#getCaptionTracks). Denna metod returnerar en [CaptionsCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/), som låter dig lägga till WebVTT‑undertextspår, iterera genom befintliga spår och ta bort dem vid behov.

### **Lägg till ljudundertexter**

Använd metoden [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/#getCaptionTracks) för att bifoga ett eller flera undertextspår till en ljudram. I följande exempel läggs en ljudfil till en bild och sedan laddas ett nytt undertextspår från en `.vtt`‑fil.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Lägg till ett nytt undertextspår från en WebVTT-fil.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Extrahera ljudundertexter**

Du kan iterera genom de undertextspår som är kopplade till en ljudram och spara dem som `.vtt`‑filer. Varje undertextspår exponerar sina binära data och unika identifierare, vilka kan användas vid export av undertexter.

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
                // Spara varje undertextspår som en .vtt-fil.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Ta bort ljudundertexter**

För att ta bort undertexter från en ljudram, använd metoderna som erbjuds av [CaptionsCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/), såsom [clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#removeAt). Följande exempel tar bort alla undertextspår från en ljudram.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // typ: AudioFrame

    // Ta bort alla undertextspår från ljudramen.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extrahera ljud**

Aspose.Slides för PHP via Java låter dig extrahera ljudet som används i bildspelsövergångar. Till exempel kan du extrahera ljudet som används i en specifik bild.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) och ladda presentationen som innehåller ljudet.
2. Hämta den relevanta bildens referens via dess index.
3. Åtkomst till [slideshow transitions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseslide/#getSlideShowTransition) för bilden.
4. Extrahera ljudet som byte‑data.

Denna kod visar hur du extraherar ljudet som används i en bild:

```php
# Instansierar en Presentation-klass som representerar en presentationsfil
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Kommer åt den önskade bilden
	$slide = $pres->getSlides()->get_Item(0);
	# Hämtar bildspelsövergångseffekterna för bilden
	$transition = $slide->getSlideShowTransition();
	# Extraherar ljudet i en byte-array
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Kan jag återanvända samma ljudresurs på flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens delade [audio collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getaudios/) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta undviker duplicering av mediadata och håller presentationens storlek under kontroll.

**Kan jag ersätta ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/setlinkpathlong/) så att det pekar på den nya filen. För ett inbäddat ljud, byt ut objektet [embedded audio](https://reference.aspose.com/slides/sv/php-java/aspose.slides/audioframe/setembeddedaudio/) mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/getaudios/). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar trimning den underliggande ljuddata som lagras i presentationen?**

Nej. Trimning justerar endast uppspelningsgränserna. De ursprungliga ljudbytena förblir orörda och är tillgängliga via det inbäddade ljudet eller presentationens ljudsamling.