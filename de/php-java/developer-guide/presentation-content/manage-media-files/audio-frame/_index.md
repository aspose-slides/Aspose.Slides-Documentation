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
description: "Audio-Frames in Aspose.Slides für PHP erstellen und steuern – Codebeispiele zum Einbetten, Trimmen, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---

## **Audio-Frames erstellen**

Aspose.Slides for PHP via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in Folien als Audio-Frames eingebettet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Laden Sie den Audio-Datei-Stream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) und `Volume`, die vom [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) Objekt bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie einen eingebetteten Audio‑Frame zu einer Folie hinzufügen:
```php
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
$pres = new Presentation();
try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Lädt die wav-Sounddatei in einen Stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Fügt den Audio-Frame hinzu
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Setzt den Wiedergabemodus und die Lautstärke des Audios
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Schreibt die PowerPoint-Datei auf die Festplatte
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **Thumbnail des Audio-Frames ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, erscheint das Audio als Frame mit einem Standard‑Standardbild (siehe das Bild im Abschnitt unten). Sie können das Vorschaubild des Audio‑Frames ändern (setzen Sie Ihr bevorzugtes Bild).

Dieser PHP‑Code zeigt, wie Sie das Thumbnail bzw. das Vorschaubild eines Audio‑Frames ändern:
```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Fügt der Folie einen Audio-Frame mit angegebener Position und Größe hinzu.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# Fügt ein Bild zu den Präsentationsressourcen hinzu.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# Setzt das Bild für den Audio-Frame.
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


## **Audio‑Wiedergabeoptionen ändern**

Aspose.Slides for PHP via Java ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Beispielsweise können Sie die Lautstärke eines Audios anpassen, das Audio schleifen lassen oder das Audiosymbol ausblenden.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) properties:

- **Start**‑Dropdown‑Liste entspricht der Methode [AudioFrame::setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** entspricht der Methode [AudioFrame::setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** entspricht der Methode [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** entspricht der Methode [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** entspricht der Methode [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** entspricht der Methode [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio)

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) properties:

- **Fade In** entspricht der Methode [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** entspricht der Methode [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** entspricht der Methode [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time**‑Wert entspricht der Audiodauer abzüglich des Werts der Methode [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Der PowerPoint‑**Volume‑Regler** in der Audiosteuerungs‑Leiste entspricht der Methode [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Mit ihr können Sie die Lautstärke des Audios als Prozentsatz ändern.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. Erstellen Sie das Audio‑Frame ([Сreate](#create-audio-frame)) oder holen Sie es.
2. Setzen Sie neue Werte für die Audio‑Frame‑Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint‑Datei.

Dieser PHP‑Code demonstriert eine Operation, bei der die Optionen eines Audios angepasst werden:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Holt das AudioFrame-Shape
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt den Wiedergabemodus auf Klick
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Setzt die Lautstärke auf niedrig
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Setzt das Audio abspielbar über Folien hinweg
    $audioFrame->setPlayAcrossSlides(true);
    # Deaktiviert die Schleife für das Audio
    $audioFrame->setPlayLoopMode(false);
    # Versteckt das AudioFrame während der Bildschirmanzeige
    $audioFrame->setHideAtShowing(true);
    # Spult das Audio nach dem Abspielen zum Anfang zurück
    $audioFrame->setRewindAudio(true);
    # Speichert die PowerPoint-Datei auf die Festplatte
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


Dieses PHP‑Beispiel zeigt, wie Sie einen neuen Audio‑Frame mit eingebettetem Audio hinzufügen, zuschneiden und die Fade‑Dauern festlegen:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Setzt den Trimm-Startversatz auf 1,5 Sekunden
    $audioFrame->setTrimFromStart(1500);
    // Setzt den Trimm-Endversatz auf 2 Sekunden
    $audioFrame->setTrimFromEnd(2000);

    // Setzt die Einblenddauer auf 200 ms
    $audioFrame->setFadeInDuration(200);
    // Setzt die Ausblenddauer auf 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


Das folgende Code‑Beispiel zeigt, wie Sie einen Audio‑Frame mit eingebettetem Audio abrufen und seine Lautstärke auf 85 % setzen:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Holt das Audio-Frame-Shape
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Setzt die Lautstärke des Audios auf 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **Audio extrahieren**

Aspose.Slides for PHP via Java ermöglicht das Extrahieren des bei Folien‑Übergängen verwendeten Sounds. Beispielsweise können Sie den Sound einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie die Referenz der betreffenden Folie über ihren Index.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) der Folie zu.
4. Extrahieren Sie den Sound als Byte‑Daten.

Dieser Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:
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

**Kann ich dasselbe Audio‑Asset auf mehreren Folien wiederverwenden, ohne die Dateigröße zu vergrößern?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) der Präsentation hinzu und erstellen Sie zusätzliche Audio‑Frames, die auf dieses vorhandene Asset verweisen. Das vermeidet das Duplizieren von Mediendaten und hält die Präsentationsgröße unter Kontrolle.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Sound aktualisieren Sie den [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) auf die neue Datei. Für einen eingebetteten Sound tauschen Sie das [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/)‑Objekt gegen ein anderes aus der [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) der Präsentation aus. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Verändert das Trimmen die zugrunde liegenden Audiodaten, die in der Präsentation gespeichert sind?**

Nein. Beim Trimmen werden nur die Wiedergabebereiche angepasst. Die ursprünglichen Audiodaten bleiben unverändert und über das eingebettete Audio bzw. die Audio‑Collection der Präsentation zugänglich.