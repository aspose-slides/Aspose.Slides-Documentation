---
title: Audio-Frames in Präsentationen auf Android verwalten
linktitle: Audio-Frame
type: docs
weight: 10
url: /de/androidjava/audio-frame/
keywords:
- Audio
- Audio-Frame
- Miniaturansicht
- Audio hinzufügen
- Audioeigenschaften
- Audiooptionen
- Audio extrahieren
- Android
- Java
- Aspose.Slides
description: "Audio in Folien einbetten, das Audiosymbol ändern, die Wiedergabe konfigurieren, WebVTT-Untertitel verwalten und Sound von Folienübergängen mit Aspose.Slides für Android via Java extrahieren."
---
## **Übersicht**

Ein Audio‑Frame ermöglicht das Abspielen eines Sounds auf einer Folie. Mit Aspose.Slides für Android via Java können Sie einen Audioclip einbetten, das Bild auswählen, das ihn darstellt, die Wiedergabe anpassen und Untertitel anhängen. Sie können außerdem einen einem Folienübergang zugewiesenen Sound abrufen.

## **Audio‑Frames erstellen**

Verwenden Sie [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-), um einen lokalen Audioclip auf der ersten Folie einzubetten. Die ersten beiden Koordinaten positionieren den Frame auf der Folie, die nächsten beiden Werte setzen Breite und Höhe, alles in Punkten. Dieses Beispiel ruft [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) auf, um den Clip automatisch zu starten, und [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) für die laute Voreinstellung.

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

## **Vorschaubild des Audio‑Frames ändern**

Standardmäßig zeigt ein Audio‑Frame ein Lautsprechersymbol an. Um ein benutzerdefiniertes Vorschaubild anzuzeigen, fügen Sie der Präsentation mit [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) ein Bild hinzu und setzen es mit [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) im Bild des Frames. Das Beispiel verwendet ein JPEG als Vorschaubild für einen eingebetteten Audioclip.

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

PowerPoints **Audio‑Optionen**‑Steuerelemente bestimmen, wann ein Clip startet, wie laut er ist und wie er sich während einer Bildschirmanzeige verhält.

![PowerPoint Audio-Optionen-Steuerelemente für einen Audio-Frame](audio_frame_0.png)

| PowerPoint‑Steuerelement | Aspose.Slides für Android via Java‑Methode |
| --- | --- |
| Starten | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Lautstärke‑Voreinstellung | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Wiedergabe über Folien hinweg | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Schleife bis Stopp | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Während der Ansicht ausblenden | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Nach dem Abspielen zurückspulen | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Einblenden | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Ausblenden | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Audio‑Startzeit trimmen | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Audio‑Endzeit trimmen | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Lautstärkeregler | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Das Beispiel findet den ersten Audio‑Frame auf der ersten Folie, ruft [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) auf, um die Wiedergabe bei einem Klick zu starten, und wählt die niedrige Lautstärke‑Voreinstellung. Der Clip wird über Folien hinweg fortgesetzt, wobei die Schleife deaktiviert ist. Das Symbol bleibt während der Bildschirmanzeige verborgen, und der Clip wird nach der Wiedergabe zurückgespult.

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

Für einen Clip, der länger als 3,5 Sekunden ist, überspringt dieses Beispiel die ersten 1,5 Sekunden und die letzten 2 Sekunden. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) gibt die Dauer an, die am Ende des Clips weggelassen werden soll. Um die Endzeit in PowerPoint zu erhalten, subtrahieren Sie diesen Versatz von der Gesamtdauer des Clips. Der getrimmte Clip blendet über 200 Millisekunden ein und über 500 Millisekunden aus. Alle vier Methoden erwarten Werte in Millisekunden.

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

Um die Wiedergabelautstärke auf einen bestimmten Prozentsatz zu setzen, verwenden Sie [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Dieses Beispiel setzt den ersten Audio‑Frame auf der ersten Folie auf 85 %.

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

Jeder Audio‑Frame bietet Zugriff auf seine Untertitelspuren über [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Verwenden Sie die Sammlung, um WebVTT‑Untertitel an den Clip anzuhängen, vorhandene Spuren zu exportieren oder zu entfernen.

### **Audio‑Untertitel hinzufügen**

Das Beispiel bettet einen Audioclip auf der ersten Folie ein und verwendet [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-), um eine lokale WebVTT‑Spur anzuhängen. Das erste Argument liefert die Spurlabel, das zweite identifiziert die Datei mit den zeitgestempelten Untertiteln.

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

Dieses Beispiel exportiert jede Untertitelspur, die an einem Audio‑Frame auf der ersten Folie angehängt ist. Es schreibt die von [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) zurückgegebenen Bytes in eine WebVTT‑Datei und verwendet den von [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) zurückgegebenen Bezeichner als Dateinamen, sodass jede Spur eine separate Ausgabe hat.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **Audio‑Untertitel entfernen**

Verwenden Sie [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) oder [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-), um eine einzelne Spur zu löschen. Das Beispiel nutzt [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--), um alle Untertitel des ersten Audio‑Frames auf der ersten Folie zu entfernen, wobei der Clip erhalten bleibt.

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

Um eine Zeile in den Audio‑Untertiteln auf der ersten Folie zu finden, durchsuchen Sie den von [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) im Speicher zurückgegebenen Text. In einem Klartext‑WebVTT‑Cue enthält die Zeitzeile `-->`, die Untertitelzeilen folgen ihr, und eine leere Zeile beendet den Cue. Dieses Beispiel gibt die Spurlabel und jede Untertitelzeile aus, die „café“ enthält.

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
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
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

Ein Folienübergang kann einen eigenen Sound haben. Um ihn abzurufen, rufen Sie [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) auf dem Folienübergang auf. Das Beispiel greift auf die von [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) zurückgegebenen Bytes zu und gibt die Anzahl der Bytes aus. Wenn die erste Folie keinen Übergangssound hat, wird stattdessen eine Meldung ausgegeben.

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

**Kann ich denselben Audioclip auf mehreren Folien verwenden, ohne ihn zu duplizieren?**

Ja. Fügen Sie den Clip einmal zur [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) der Präsentation hinzu und übergeben Sie dasselbe Audio‑Objekt an [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) für jede Folie.

**Kann ich den Sound in einem bestehenden Audio‑Frame ersetzen?**

Ja. Für einen verlinkten Sound verwenden Sie [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-), um auf die Ersatzdatei zu verweisen. Für einen eingebetteten Sound wählen Sie einen anderen Clip aus der Audio‑Sammlung der Präsentation mit [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Beide Ansätze erhalten den bestehenden Frame.

**Ändert das Trimmen die Audiodaten, die in der Präsentation gespeichert sind?**

Nein. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) und [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) setzen Wiedergabegrenzen. Sie können den vollständigen Clip weiterhin über [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) abrufen.