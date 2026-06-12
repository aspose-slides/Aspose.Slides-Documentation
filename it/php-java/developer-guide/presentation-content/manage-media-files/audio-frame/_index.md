---
title: Gestire l'audio nelle presentazioni con PHP
linktitle: Fotogramma audio
type: docs
weight: 10
url: /it/php-java/audio-frame/
keywords:
- audio
- fotogramma audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- PHP
- Aspose.Slides
description: "Crea e controlla i fotogrammi audio in Aspose.Slides per PHP—esempi di codice per incorporare, ritagliare, ripetere e configurare la riproduzione su presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come lavorare con i fotogrammi audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare la miniatura del fotogramma audio, configurare le opzioni di riproduzione come volume, ripetizione, nascondere, ritaglio e durate di dissolvenza, ed estrarre l’audio utilizzato nelle transizioni della presentazione.

## **Crea fotogrammi audio**

Aspose.Slides per PHP via Java consente di aggiungere file audio alle diapositive. I file audio sono incorporati nelle diapositive come fotogrammi audio.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Carica lo stream del file audio che desideri incorporare nella diapositiva.
4. Aggiungi il fotogramma audio incorporato (contenente il file audio) alla diapositiva.
5. Imposta [PlayMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/AudioPlayModePreset) e `Volume` esposti dall'oggetto [AudioFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/).
6. Salva la presentazione modificata.

Questo codice PHP mostra come aggiungere un fotogramma audio incorporato a una diapositiva:

```php
// Istanzia una classe Presentation che rappresenta un file di presentazione
$pres = new Presentation();
try {
    # Ottiene la prima diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Carica il file audio wav nello stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Aggiunge il fotogramma audio
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Imposta la modalità di riproduzione e il volume dell'audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Scrive il file PowerPoint su disco
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Modifica la miniatura del fotogramma audio**

Quando aggiungi un file audio a una presentazione, l'audio appare come un fotogramma con un'immagine predefinita standard (vedi l'immagine nella sezione sottostante). Puoi modificare l'immagine di anteprima del fotogramma audio (impostare l'immagine preferita).

Questo codice PHP mostra come modificare la miniatura o l'immagine di anteprima di un fotogramma audio:

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Aggiunge un fotogramma audio alla diapositiva con una posizione e dimensione specificate.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Aggiunge un'immagine alle risorse della presentazione.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Imposta l'immagine per il fotogramma audio.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Salva la presentazione modificata su disco
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Modifica le opzioni di riproduzione audio**

Aspose.Slides per PHP via Java consente di modificare le opzioni che controllano la riproduzione o le proprietà di un audio. Ad esempio, è possibile regolare il volume di un audio, impostare l'audio per la riproduzione in loop o anche nascondere l'icona audio.

La sezione **Opzioni audio** in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Opzioni audio** di PowerPoint che corrispondono alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/) :

- **Avvio** corrisponde al metodo [AudioFrame::setPlayMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** corrisponde al metodo [AudioFrame::setVolume](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setVolume)
- **Riproduci su tutte le diapositive** corrisponde al metodo [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Ripeti finché non interrotto** corrisponde al metodo [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Nascondi durante la presentazione** corrisponde al metodo [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Riavvolgi dopo la riproduzione** corrisponde al metodo [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setRewindAudio)

Opzioni di **Modifica** di PowerPoint che corrispondono alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/) :

- **Dissolvenza in ingresso** corrisponde al metodo [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Dissolvenza in uscita** corrisponde al metodo [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Taglia inizio audio** corrisponde al metodo [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Taglia fine audio** il valore è uguale alla durata dell'audio meno il valore di [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setTrimFromEnd) method

Il **controllo Volume** di PowerPoint nel pannello di controllo audio corrisponde al metodo [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#setVolumeValue). Consente di modificare il volume dell'audio in percentuale.

Ecco come modificare le opzioni di riproduzione audio:

1. [Crea](#create-audio-frame) o ottieni il Fotogramma audio.
2. Imposta nuovi valori per le proprietà del Fotogramma audio che desideri modificare.
3. Salva il file PowerPoint modificato.

Questo codice PHP dimostra un'operazione in cui le opzioni di un audio sono regolate:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Ottiene la forma AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Imposta la modalità di riproduzione su clic
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Imposta il volume su Basso
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Imposta l'audio per la riproduzione su tutte le diapositive
    $audioFrame->setPlayAcrossSlides(true);
    # Disabilita il loop per l'audio
    $audioFrame->setPlayLoopMode(false);
    # Nasconde il fotogramma audio durante la presentazione
    $audioFrame->setHideAtShowing(true);
    # Riavvolge l'audio all'inizio dopo la riproduzione
    $audioFrame->setRewindAudio(true);
    # Salva il file PowerPoint su disco
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Questo esempio PHP mostra come aggiungere un nuovo fotogramma audio con audio incorporato, ritagliarlo e impostare le durate di dissolvenza:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Imposta l'offset di inizio del ritaglio a 1,5 secondi
    $audioFrame->setTrimFromStart(1500);
    // Imposta l'offset di fine del ritaglio a 2 secondi
    $audioFrame->setTrimFromEnd(2000);

    // Imposta la durata della dissolvenza in ingresso a 200 ms
    $audioFrame->setFadeInDuration(200);
    // Imposta la durata della dissolvenza in uscita a 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Il seguente esempio di codice mostra come recuperare un fotogramma audio con audio incorporato e impostarne il volume all'85%:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Ottiene una forma di fotogramma audio
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Imposta il volume audio all'85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Gestisci i sottotitoli audio**

Aspose.Slides consente di aggiungere sottotitoli chiusi a un fotogramma audio tramite il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#getCaptionTracks). Questo metodo restituisce una [CaptionsCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/), che permette di aggiungere tracce di sottotitoli WebVTT, iterare le tracce esistenti e rimuoverle quando necessario.

**Add Audio Captions**

Utilizza il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/#getCaptionTracks) per collegare una o più tracce di sottotitoli a un fotogramma audio. Nell'esempio seguente, un file audio viene aggiunto a una diapositiva, quindi viene caricata una nuova traccia di sottotitoli da un file `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Aggiungi una nuova traccia di sottotitoli da un file WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extract Audio Captions**

Puoi iterare le tracce di sottotitoli associate a un fotogramma audio e salvarle come file `.vtt`. Ogni traccia di sottotitoli espone i suoi dati binari e l'identificatore univoco, che può essere usato durante l'esportazione dei sottotitoli.

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
                // Salva ogni traccia di sottotitoli come file .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Remove Audio Captions**

Per rimuovere i sottotitoli da un fotogramma audio, utilizza i metodi forniti da [CaptionsCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/), come [clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/#remove), o [removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/captionscollection/#removeAt). L'esempio seguente rimuove tutte le tracce di sottotitoli da un fotogramma audio.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // tipo: AudioFrame

    // Rimuove tutte le tracce di sottotitoli dal fotogramma audio.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Estrai audio**

Aspose.Slides per PHP via Java consente di estrarre il suono utilizzato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono utilizzato in una diapositiva specifica.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation) e carica la presentazione che contiene l'audio.
2. Ottieni il riferimento della diapositiva pertinente tramite il suo indice.
3. Accedi alle [slideshow transitions](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva.
4. Estrai il suono in dati byte.

Questo codice mostra come estrarre l'audio utilizzato in una diapositiva:

```php
# Istanzia una classe Presentation che rappresenta un file di presentazione
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Accede alla diapositiva desiderata
	$slide = $pres->getSlides()->get_Item(0);
	# Ottiene gli effetti di transizione della presentazione per la diapositiva
	$transition = $slide->getSlideShowTransition();
	# Estrae il suono in un array di byte
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Posso riutilizzare lo stesso asset audio su più diapositive senza aumentare la dimensione del file?**

Sì. Aggiungi l'audio una volta alla [audio collection](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getaudios/) condivisa della presentazione e crea fotogrammi audio aggiuntivi che fanno riferimento a quell'asset esistente. Questo evita di duplicare i dati multimediali e mantiene la dimensione della presentazione sotto controllo.

**Posso sostituire il suono in un fotogramma audio esistente senza ricreare la forma?**

Sì. Per un suono collegato, aggiorna il [link path](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/setlinkpathlong/) per puntare al nuovo file. Per un suono incorporato, sostituisci l'oggetto [embedded audio](https://reference.aspose.com/slides/it/php-java/aspose.slides/audioframe/setembeddedaudio/) con un altro proveniente dalla [audio collection](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getaudios/) della presentazione. La formattazione del fotogramma e la maggior parte delle impostazioni di riproduzione rimangono invariate.

**Il ritaglio modifica i dati audio sottostanti memorizzati nella presentazione?**

No. Il ritaglio regola solo i limiti di riproduzione. I byte audio originali rimangono intatti e accessibili tramite l'audio incorporato o la [audio collection](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getaudios/) della presentazione.