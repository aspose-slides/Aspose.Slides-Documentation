---
title: Audio-Frame
type: docs
weight: 10
url: /php-java/audio-frame/
keywords: "Audio hinzufügen, Audio-Frame, Audioeigenschaften, Audio extrahieren, Java, Aspose.Slides für PHP über Java"
description: "Audio zu PowerPoint-Präsentationen hinzufügen"
---

## **Audio-Frame erstellen**
Aspose.Slides für PHP über Java ermöglicht es Ihnen, Audiodateien in Folien hinzuzufügen. Die Audiodateien werden als Audio-Frames in Folien eingebettet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Laden Sie den Audiodateistream, den Sie in die Folie einbetten möchten.
4. Fügen Sie den eingebetteten Audio-Frame (der die Audiodatei enthält) zur Folie hinzu.
5. Stellen Sie [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) und `Volume` ein, die vom [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame)-Objekt bereitgestellt werden.
6. Speichern Sie die bearbeitete Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie einen eingebetteten Audio-Frame zu einer Folie hinzufügen:

```php
// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation();
  try {
    # Holt die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Lädt die wav-Audiodatei in den Stream
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

Wenn Sie eine Audiodatei zu einer Präsentation hinzufügen, erscheint das Audio als Frame mit einem standardmäßigen Standardbild (siehe das Bild im nächsten Abschnitt). Sie können das Vorschaubild des Audio-Frames ändern (setzen Sie Ihr bevorzugtes Bild).

Dieser PHP-Code zeigt Ihnen, wie Sie das Thumbnail oder Vorschaubild eines Audio-Frames ändern:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Fügt dem Slide einen Audio-Frame an einer bestimmten Position und Größe hinzu.
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

    # Speichert die bearbeitete Präsentation auf der Festplatte
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Audio-Wiedergabeoptionen ändern**

Aspose.Slides für PHP über Java ermöglicht es Ihnen, Optionen zu ändern, die die Wiedergabe oder Eigenschaften eines Audios steuern. Zum Beispiel können Sie die Lautstärke eines Audios anpassen, das Audio so einstellen, dass es wiederholt abgespielt wird, oder sogar das Audio-Symbol ausblenden.

Das **Audio-Options**-Fenster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint-Audiooptionen, die den Eigenschaften des Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame) entsprechen:
- Die Audio-Options **Start** Dropdown-Liste entspricht der [AudioFrame.PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayMode--) Eigenschaft
- Die Audio-Options **Lautstärke** entspricht der [AudioFrame.Volume](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getVolume--) Eigenschaft
- Die Audio-Options **Play Across Slides** entspricht der [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayAcrossSlides--) Eigenschaft
- Die Audio-Options **Loop until Stopped** entspricht der [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayLoopMode--) Eigenschaft
- Die Audio-Options **Hide During Show** entspricht der [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getHideAtShowing--) Eigenschaft
- Die Audio-Options **Rewind after Playing** entspricht der [AudioFrame.RewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getRewindAudio--) Eigenschaft

So ändern Sie die Audio-Wiedergabeoptionen:

1. [Erstellen](#create-audio-frame) oder holen Sie den Audio-Frame.
2. Setzen Sie neue Werte für die Audio-Frame-Eigenschaften, die Sie anpassen möchten.
3. Speichern Sie die bearbeitete PowerPoint-Datei.

Dieser PHP-Code demonstriert eine Operation, bei der die Optionen eines Audios angepasst werden:

```php
  $pres = new Presentation("AudioFrameEmbed_out.pptx");
  try {
    # Holt die AudioFrame-Form
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Setzt den Wiedergabemodus auf "Bei Klick abspielen"
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Setzt die Lautstärke auf Niedrig
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Setzt das Audio so, dass es über Folien abgespielt wird
    $audioFrame->setPlayAcrossSlides(true);
    # Deaktiviert die Schleife für das Audio
    $audioFrame->setPlayLoopMode(false);
    # Versteckt den AudioFrame während der Präsentation
    $audioFrame->setHideAtShowing(true);
    # Spult das Audio nach dem Abspielen zum Anfang zurück
    $audioFrame->setRewindAudio(true);
    # Speichert die PowerPoint-Datei auf der Festplatte
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Audio extrahieren**

Aspose.Slides für PHP über Java ermöglicht es Ihnen, den Sound zu extrahieren, der in Folienübergängen verwendet wird. Zum Beispiel können Sie den Sound extrahieren, der in einer bestimmten Folie verwendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse und laden Sie die Präsentation mit Folienübergängen.
2. Greifen Sie auf die gewünschte Folie zu.
3. Greifen Sie auf die [Folienübergänge](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) für die Folie zu.
4. Extrahieren Sie den Sound in Byte-Daten.

Dieser Code zeigt Ihnen, wie Sie das Audio, das in einer Folie verwendet wird, extrahieren:

```php
  # Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("AudioSlide.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Greift auf die gewünschte Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Holt die Übergangseffekte der Folien für die Folie
    $transition = $slide->getSlideShowTransition();
    # Extrahiert den Sound in ein Byte-Array
    $audio = $transition->getSound()->getBinaryData();
    echo("Länge: " . $Array->getLength($audio));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```