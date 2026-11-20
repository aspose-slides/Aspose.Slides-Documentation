---
title: Audio-Frames in Präsentationen mit Java verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/java/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturbild
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Java
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Sounds von Folienübergängen mit Aspose.Slides für Java extrahieren."
---
## **Übersicht**

Ein Audio‑Frame ermöglicht das Abspielen eines Sounds auf einer Folie. Mit Aspose.Slides für Java können Sie ein Audio‑Clip einbetten, das Bild auswählen, das es darstellt, die Wiedergabe anpassen und Untertitel anhängen. Sie können auch einen einem Folienübergang zugewiesenen Sound abrufen.

## **Audio‑Frames erstellen**

Verwenden Sie [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) , um einen lokalen Audioclip auf der ersten Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, und die nächsten beiden Werte setzen seine Breite und Höhe, alles in Punkten. Dieses Beispiel ruft [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) auf, um den Clip automatisch zu starten, und ruft [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) auf, um die laute Voreinstellung auszuwählen.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Miniaturbild des Audio‑Frames ändern**

Standardmäßig zeigt ein Audio‑Frame ein Lautsprechersymbol an. Um eine benutzerdefinierte Miniatur anzuzeigen, fügen Sie der Präsentation ein Bild mit [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) hinzu und setzen es mit [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) auf das Bild des Frames. Das Beispiel verwendet ein JPEG als Miniatur für einen eingebetteten Audioclip.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Audio‑Wiedergabeoptionen ändern**

Die **Audio-Optionen** von PowerPoint bestimmen, wann ein Clip startet, wie laut er ist und wie er sich während einer Bildschau verhält.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint control | Aspose.Slides for Java method |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Lautstärkepreset | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Während Folien wiedergeben | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Schleife bis Stopp | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Während der Vorführung ausblenden | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Nach Wiedergabe zurückspulen | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Einblenden | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Ausblenden | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Startzeit des Audios trimmen | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Endzeit des Audios trimmen | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Lautstärkeregler | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Das Beispiel findet den ersten Audio‑Frame auf der ersten Folie, ruft [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) auf, um die Wiedergabe bei einem Klick zu starten, und wählt die leise Lautstärkepreset aus. Der Clip läuft über Folien hinweg weiter, wobei die Schleife deaktiviert ist. Das Symbol bleibt während der Vorführung ausgeblendet, und der Clip wird nach der Wiedergabe zurückgespult.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) nimmt die Dauer, die am Ende des Clips weggelassen werden soll. Um die in PowerPoint angezeigte Endzeit zu erhalten, ziehen Sie diesen Versatz von der Gesamtdauer des Clips ab. Der beschnittene Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Methoden erwarten Werte in Millisekunden.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz zu setzen, verwenden Sie [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Dieses Beispiel setzt den ersten Audio‑Frame auf der ersten Folie auf 85 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```
## **Audio‑Untertitel verwalten**

Jeder Audio‑Frame bietet Zugriff auf seine Untertitelspuren über [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Verwenden Sie die Sammlung, um WebVTT‑Untertitel an den Clip anzuhängen, vorhandene Spuren zu exportieren oder zu entfernen.

### **Audio‑Untertitel hinzufügen**

Das Beispiel bettet einen Audioclip auf der ersten Folie ein und verwendet [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) , um eine lokale WebVTT‑Spur anzuhängen. Das erste Argument liefert die Spurbezeichnung und das zweite gibt die Datei mit den zeitgestempelten Untertiteln an.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Audio‑Untertitel extrahieren**

Dieses Beispiel exportiert jede an einen Audio‑Frame auf der ersten Folie angehängte Untertitelspur. Es schreibt die von [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) zurückgegebenen Bytes in eine WebVTT‑Datei und verwendet den von [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) zurückgegebenen Bezeichner als Dateinamen, sodass jede Spur eine separate Ausgabe hat.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```
### **Audio‑Untertitel entfernen**

Verwenden Sie [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) , um eine einzelne Spur zu löschen. Das Beispiel nutzt [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) , um alle Untertitel vom ersten Audio‑Frame auf der ersten Folie zu entfernen, wobei der Clip erhalten bleibt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```
### **Eine Zeile in Audio‑Untertiteln finden**

Um eine Zeile in den Audio‑Untertiteln auf der ersten Folie zu finden, durchsuchen Sie den von [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) zurückgegebenen Text im Speicher. In einer reinen Text‑WebVTT‑Cue enthält die Timing‑Zeile `-->`, die Untertitelzeilen folgen darauf, und eine leere Zeile beendet die Cue. Dieses Beispiel gibt die Spurbezeichnung und jede Untertitelzeile aus, die „café“ enthält.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\R")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```
## **Audio extrahieren**

Ein Folienübergang kann einen eigenen Sound haben. Um ihn abzurufen, rufen Sie [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) auf dem Folienübergang auf. Das Beispiel greift auf die von [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) zurückgegebenen Bytes zu und gibt die Anzahl der Bytes aus. Hat die erste Folie keinen Übergangssound, wird stattdessen eine Meldung ausgegeben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```
## **FAQ**

**Kann ich denselben Audioclip in mehreren Folien wiederverwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt an [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) für jede Folie.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen?**

Ja. Für einen verlinkten Sound verwenden Sie [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) , um auf die Ersatzdatei zu verweisen. Für einen eingebetteten Sound wählen Sie einen anderen Clip aus der Audio‑Sammlung der Präsentation mit [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) . Beide Ansätze bewahren den bestehenden Frame.

**Ändert das Trimmen die in der Präsentation gespeicherten Audiodaten?**

Nein. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) und [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) setzen nur Wiedergabegrenzen. Sie können den vollständigen Clip weiterhin über [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) abrufen.