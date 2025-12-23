---
title: Audio in Präsentationen mit PHP verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/php-java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturansicht
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- PHP
- Aspose.Slides
description: "Erstellen und steuern Sie Audio-Frames in Aspose.Slides für PHP – Codebeispiele zum Einbetten, Zuschneiden, Schleifen und Konfigurieren der Wiedergabe in PPT-, PPTX- und ODP-Präsentationen."
---

## **Audio-Frames erstellen**

Aspose.Slides for PHP via Java ermöglicht das Hinzufügen von Audiodateien zu Folien. Die Audiodateien werden in den Folien als Audio-Frames eingebettet.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Holen Sie sich den Verweis auf eine Folie über deren Index.
3. Laden Sie den Audiodatei-Stream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Setzen Sie [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) und `Volume`, die vom Objekt [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame) bereitgestellt werden.
6. Speichern Sie die geänderte Präsentation.

Dieser PHP-Code zeigt, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:
```php
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
$pres = new Presentation();
try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Lädt die wav-Audiodatei in einen Stream
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Fügt den Audio-Frame hinzu
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Setzt den Play-Modus und die Lautstärke des Audios
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Schreibt die PowerPoint-Datei auf die Festplatte
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```


## **Miniaturansicht des Audio-Frames ändern**

Wenn Sie einer Präsentation eine Audiodatei hinzufügen, wird das Audio als Frame mit einem standardmäßigen Standardbild angezeigt (siehe das Bild im folgenden Abschnitt). Sie können das Vorschaubild des Audio-Frames ändern (Ihr gewünschtes Bild festlegen).

Dieser PHP-Code zeigt, wie Sie die Miniatur- oder Vorschaubild eines Audio-Frames ändern:
```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# Fügt der Folie einen Audio-Frame mit einer angegebenen Position und Größe hinzu.
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
```


## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides for PHP via Java ermöglicht das Ändern von Optionen, die die Wiedergabe oder Eigenschaften eines Audios steuern. Sie können zum Beispiel die Lautstärke eines Audios anpassen, das Audio in Schleife wiedergeben oder das Audiosymbol sogar ausblenden.

Der **Audio Options**‑Bereich in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, die den Aspose.Slides‑Eigenschaften des [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) entsprechen:

- **Start**‑Dropdown‑Liste entspricht der Methode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** entspricht der Methode [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** entspricht der Methode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** entspricht der Methode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** entspricht der Methode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** entspricht der Methode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio).

PowerPoint **Editing**‑Optionen, die den Aspose.Slides‑Eigenschaften des [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) entsprechen:

- **Fade In** entspricht der Methode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** entspricht der Methode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** entspricht der Methode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart).
- **Trim Audio End Time**‑Wert entspricht der Audiodauer minus dem Wert der Methode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd).

Der PowerPoint **Volume controll** im Audiosteuerungsfeld entspricht der Methode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Er ermöglicht das Ändern der Audio‑Lautstärke in Prozent.

So ändern Sie die Audio‑Wiedergabeoptionen:

1. [Сreate](#create-audio-frame) oder erhalten Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame-Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die geänderte PowerPoint-Datei.

Dieser PHP-Code demonstriert einen Vorgang, bei dem die Optionen eines Audios angepasst werden:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Ermittelt das AudioFrame-Shape
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt den Wiedergabemodus auf Beim Klicken
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Setzt die Lautstärke auf niedrig
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Setzt das Audio so, dass es über Folien hinweg abgespielt wird
    $audioFrame->setPlayAcrossSlides(true);
    # Deaktiviert die Schleife für das Audio
    $audioFrame->setPlayLoopMode(false);
    # Blendet das AudioFrame während der Bildpräsentation aus
    $audioFrame->setHideAtShowing(true);
    # Spult das Audio nach der Wiedergabe zum Anfang zurück
    $audioFrame->setRewindAudio(true);
    # Speichert die PowerPoint-Datei auf der Festplatte
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


Dieses PHP-Beispiel zeigt, wie Sie einen neuen Audio-Frame mit eingebettetem Audio hinzufügen, ihn zuschneiden und die Fade-Dauern festlegen:
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

    // Setzt die Fade-In-Dauer auf 200 ms
    $audioFrame->setFadeInDuration(200);
    // Setzt die Fade-Out-Dauer auf 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


Das folgende Codebeispiel zeigt, wie Sie einen Audio-Frame mit eingebettetem Audio abrufen und dessen Lautstärke auf 85 % setzen:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Ermittelt ein Audio-Frame-Shape
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Setzt die Audio-Lautstärke auf 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **Audio extrahieren**

Aspose.Slides for PHP via Java ermöglicht das Extrahieren des in Folienübergängen verwendeten Klangs. Sie können zum Beispiel den Klang einer bestimmten Folie extrahieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation, die das Audio enthält.
2. Holen Sie sich den Verweis auf die betreffende Folie über deren Index.
3. Greifen Sie auf die [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) der Folie zu.
4. Extrahieren Sie den Klang als Byte-Daten.

Dieser Code zeigt, wie Sie das in einer Folie verwendete Audio extrahieren:
```php
# Instanziert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Greift auf die gewünschte Folie zu
	$slide = $pres->getSlides()->get_Item(0);
	# Ermittelt die Folienübergangseffekte für die Folie
	$transition = $slide->getSlideShowTransition();
	# Extrahiert den Klang in ein Byte-Array
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```


## **FAQ**

**Kann ich dieselbe Audiodatei auf mehreren Folien wiederverwenden, ohne die Dateigröße zu erhöhen?**

Ja. Fügen Sie das Audio einmal zur geteilten [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) der Präsentation hinzu und erstellen Sie weitere Audio-Frames, die auf dieses vorhandene Asset verweisen. Dadurch wird das Duplizieren von Mediendaten vermieden und die Präsentationsgröße bleibt kontrollierbar.

**Kann ich den Klang in einem bestehenden Audio-Frame ersetzen, ohne die Form neu zu erstellen?**

Ja. Für einen verknüpften Klang aktualisieren Sie den [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) so, dass er auf die neue Datei verweist. Für einen eingebetteten Klang ersetzen Sie das [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/)‑Objekt durch ein anderes aus der [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) der Präsentation. Die Formatierung des Frames und die meisten Wiedergabeeinstellungen bleiben erhalten.

**Ändert das Trimmen die im Hintergrund gespeicherten Audiodaten der Präsentation?**

Nein. Trimmen ändert nur die Wiedergabegrenzen. Die ursprünglichen Audiodaten bleiben unverändert und sind über das eingebettete Audio oder die Audio-Collection der Präsentation zugänglich.