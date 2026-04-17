---
title: Audio in Präsentationen mit PHP verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/php-java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Vorschaubild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- PHP
- Aspose.Slides
description: "Erstellen und steuern Sie Audio-Frames in Aspose.Slides für PHP — Codebeispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---
## **Audio-Frames erstellen**

Aspose.Slides für PHP via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in Folien als Audio-Frames eingebettet.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation).
2. Rufen Sie die Referenz einer Folie über deren Index ab.
3. Laden Sie den Audio‑Dateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie das eingebettete Audio‑Frame (das die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/AudioPlayModePreset) und `Volume`, die vom [AudioFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/) Objekt bereitgestellt werden.

Speichern Sie die geänderte Präsentation.

```php
// Instanziiert eine Presentation‑Klasse, die eine Präsentationsdatei darstellt
$pres = new Presentation();
try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Lädt die wav‑Sounddatei in einen Stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Fügt das Audio‑Frame hinzu
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Setzt den Wiedergabemodus und die Lautstärke des Audios
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Schreibt die PowerPoint‑Datei auf die Festplatte
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Audio-Frame-Vorschaubild ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im folgenden Abschnitt). Sie können das Vorschaubild des Audio‑Frames ändern (ein gewünschtes Bild festlegen).

```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Fügt der Folie ein Audio-Frame mit einer angegebenen Position und Größe hinzu.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Fügt ein Bild zu den Ressourcen der Präsentation hinzu.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Setzt das Bild für das Audio-Frame.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# Speichert die geänderte Präsentation auf die Festplatte
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für PHP via Java ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Beispielsweise können Sie die Lautstärke des Audios anpassen, das Audio in einer Schleife abspielen lassen oder sogar das Audiosymbol ausblenden.

Das **Audio Options**‑Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Start**‑Dropdown-Liste entspricht der Methode [AudioFrame::setPlayMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** entspricht der Methode [AudioFrame::setVolume](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** entspricht der Methode [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** entspricht der Methode [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** entspricht der Methode [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** entspricht der Methode [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setRewindAudio).

PowerPoint **Editing**‑Optionen, die den Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/) Eigenschaften entsprechen:

- **Fade In** entspricht der Methode [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** entspricht der Methode [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** entspricht der Methode [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der Methode [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setTrimFromEnd).

Der PowerPoint **Volume controll** im Audio‑Steuerfeld entspricht der Methode [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#setVolumeValue). Er ermöglicht das Ändern der Lautstärke des Audios als Prozentsatz.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder erhalten Sie das Audio‑Frame.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Holt das AudioFrame-Shape
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt den Wiedergabemodus auf Beim Klick
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Setzt die Lautstärke auf Niedrig
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    $audioFrame->setPlayAcrossSlides(true);
    # Deaktiviert die Schleife für das Audio
    $audioFrame->setPlayLoopMode(false);
    # Blendet das AudioFrame während der Bildschirmanzeige aus
    $audioFrame->setHideAtShowing(true);
    # Spult das Audio nach dem Abspielen zum Start zurück
    $audioFrame->setRewindAudio(true);
    # Speichert die PowerPoint-Datei auf die Festplatte
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Dieses PHP‑Beispiel zeigt, wie ein neues Audio‑Frame mit eingebettetem Audio hinzugefügt, beschnitten und die Fade‑Dauern gesetzt werden:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Legt den Trimm-Startversatz auf 1,5 Sekunden fest
    $audioFrame->setTrimFromStart(1500);
    // Legt den Trimm-Endversatz auf 2 Sekunden fest
    $audioFrame->setTrimFromEnd(2000);

    // Legt die Einblenddauer (Fade-In) auf 200 ms fest
    $audioFrame->setFadeInDuration(200);
    // Legt die Ausblenddauer (Fade-Out) auf 500 ms fest
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

Das folgende Codebeispiel zeigt, wie ein Audio‑Frame mit eingebettetem Audio abgerufen und die Lautstärke auf 85 % gesetzt wird:

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Holt ein Audio-Frame-Shape
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Setzt die Lautstärke des Audios auf 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Audio-Untertitel verwalten**

Aspose.Slides ermöglicht das Hinzufügen von geschlossenen Untertiteln zu einem Audio‑Frame über die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#getCaptionTracks). Diese Methode gibt eine [CaptionsCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/) zurück, mit der Sie WebVTT‑Untertitelspuren hinzufügen, vorhandene Spuren durchlaufen und bei Bedarf entfernen können.

**Audio-Untertitel hinzufügen**

Verwenden Sie die Methode [getCaptionTracks](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/#getCaptionTracks), um einer Audio‑Frame‑Instanz eine oder mehrere Untertitelspuren anzuhängen. Im folgenden Beispiel wird einer Folie eine Audiodatei hinzugefügt und anschließend eine neue Untertitelspur aus einer `.vtt`‑Datei geladen.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Fügt eine neue Untertitelspur aus einer WebVTT-Datei hinzu.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Audio-Untertitel extrahieren**

Sie können die mit einem Audio‑Frame verbundenen Untertitelspuren durchlaufen und als `.vtt`‑Dateien speichern. Jede Untertitelspur stellt ihre Binärdaten und eine eindeutige Kennung bereit, die beim Exportieren von Untertiteln verwendet werden kann.

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
                // Speichert jede Untertitelspur als .vtt-Datei.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Audio-Untertitel entfernen**

Um Untertitel aus einem Audio‑Frame zu entfernen, nutzen Sie die von [CaptionsCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/) bereitgestellten Methoden, wie [clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#remove) oder [removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/captionscollection/#removeAt). Das folgende Beispiel entfernt alle Untertitelspuren aus einem Audio‑Frame.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // Typ: AudioFrame

    // Entfernt alle Untertitelspuren aus dem Audio-Frame.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Audio extrahieren**

Aspose.Slides für PHP via Java ermöglicht das Extrahieren des in Folienübergängen verwendeten Sounds. Beispielsweise können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/Presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Rufen Sie die Referenz der entsprechenden Folie über deren Index ab.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser Code zeigt, wie Sie den in einer Folie verwendeten Sound extrahieren:

```php
# Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Greift auf die gewünschte Folie zu
	$slide = $pres->getSlides()->get_Item(0);
	# Holt die Folienübergangseffekte für die Folie
	$transition = $slide->getSlideShowTransition();
	# Extrahiert den Sound als Byte-Array
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Kann ich dieselbe Audiodatei in mehreren Folien wiederverwenden, ohne die Dateigröße zu vergrößern?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getaudios/) der Präsentation hinzu und erstellen Sie weitere Audio‑Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verlinkten Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/setlinkpathlong/) so, dass er auf die neue Datei zeigt. Für ein eingebettetes Audio ersetzen Sie das [embedded audio](https://reference.aspose.com/slides/de/php-java/aspose.slides/audioframe/setembeddedaudio/)‑Objekt durch ein anderes aus der [audio collection](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/getaudios/) der Präsentation. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Trimmen ändert nur die Wiedergabegrenzen. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio‑Collection der Präsentation zugänglich.