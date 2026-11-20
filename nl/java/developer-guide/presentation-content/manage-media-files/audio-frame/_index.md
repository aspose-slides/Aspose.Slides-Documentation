---
title: Beheer audioframes in presentaties met Java
linktitle: Audioframe
type: docs
weight: 10
url: /nl/java/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- Java
- Aspose.Slides
description: "Audio insluiten in dia's, het audio-icoon wijzigen, afspelen configureren, WebVTT-bijschriften beheren en overgangsgeluiden van dia's extraheren met Aspose.Slides for Java."
---
## **Overzicht**

Een audioframe stelt u in staat een geluid op een dia af te spelen. Met Aspose.Slides for Java kunt u een audiobestand insluiten, de afbeelding kiezen die het weergeeft, de weergave aanpassen en bijschriften toevoegen. U kunt ook een geluid ophalen dat is toegewezen aan een dia‑overgang.

## **Audioframes maken**

Gebruik [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) om een lokaal audiobestand in te sluiten op de eerste dia. De eerste twee coördinaten plaatsen het frame op de dia, en de volgende twee waarden stellen de breedte en hoogte in, allemaal in punten. Dit voorbeeld roept [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) aan om het fragment automatisch te starten en roept [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) aan om de luidere voorinstelling te kiezen.

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

## **Miniatuur van het audioframe wijzigen**

Standaard toont een audioframe een luidsprekersymbool. Om een aangepaste miniatuur weer te geven, voegt u een afbeelding toe aan de presentatie met [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) en stelt u deze in op de afbeelding van het frame met [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). Het voorbeeld gebruikt een JPEG als miniatuur voor een ingesloten audiobestand.

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

## **Audio afspeelopties wijzigen**

De **Audio‑opties**‑besturingen van PowerPoint bepalen wanneer een fragment start, hoe hard het klinkt en hoe het zich gedraagt tijdens een diavoorstelling.

![Audio‑opties van PowerPoint voor een audioframe](audio_frame_0.png)

| PowerPoint‑besturing | Aspose.Slides for Java‑methode |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Volume‑voorinstelling | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Afspelen over dia's | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Lus tot gestopt | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Verbergen tijdens vertoning | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Terugspoelen na afspelen | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade‑in | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade‑out | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Audio starttijd bijsnijden | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Audio eindtijd bijsnijden | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volumeschuifbalk | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Het voorbeeld zoekt het eerste audioframe op de eerste dia, roept [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) aan om de weergave bij een klik te starten, en kiest de lage volume‑voorinstelling. Het fragment wordt voortgezet over dia's met uitschakelde lus. Het pictogram blijft verborgen tijdens de vertoning, en het fragment spoelt terug na het afspelen.

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

Voor een fragment langer dan 3,5 seconden slaat dit voorbeeld de eerste 1,5 seconde en de laatste 2 seconden over. [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) neemt de duur die van het einde van het fragment moet worden weggelaten. Om de eindtijd te krijgen die in PowerPoint wordt weergegeven, trekt u die offset af van de volledige fragmentduur. Het bijgesneden fragment fade‑in over 200 milliseconden en fade‑out over 500 milliseconden. Alle vier methoden nemen waarden in milliseconden.

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

Om het afspeelvolume op een specifiek percentage in te stellen, gebruikt u [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Dit voorbeeld stelt het eerste audioframe op de eerste dia in op 85%.

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

## **Audio‑bijschriften beheren**

Elk audioframe biedt toegang tot zijn bijschrift‑tracks via [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Gebruik de collectie om WebVTT‑bijschriften aan het fragment toe te voegen, bestaande tracks te exporteren of ze te verwijderen.

### **Audio‑bijschriften toevoegen**

Het voorbeeld sluit een audiobestand in op de eerste dia en gebruikt [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) om een lokale WebVTT‑track toe te voegen. Het eerste argument levert het track‑label, en het tweede identificeert het bestand dat de getimede bijschriften bevat.

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

### **Audio‑bijschriften extraheren**

Dit voorbeeld exporteert elke bijschrift‑track die aan een audioframe op de eerste dia is gekoppeld. Het schrijft de bytes die door [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) worden geretourneerd naar een WebVTT‑bestand en gebruikt de identifier die door [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) wordt geretourneerd als bestandsnaam zodat elke track een aparte output krijgt.

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

### **Audio‑bijschriften verwijderen**

Gebruik [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) om een individuele track te verwijderen. Het voorbeeld gebruikt [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) om alle bijschriften van het eerste audioframe op de eerste dia te verwijderen, terwijl het fragment behouden blijft.

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

### **Een regel in audio‑bijschriften vinden**

Om een regel in de audio‑bijschriften op de eerste dia te vinden, doorzoekt u de tekst die door [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) wordt geretourneerd in het geheugen. In een platte‑tekst WebVTT‑cue bevat de timing‑regel `-->`, de bijschrift‑regels volgen, en een lege regel beëindigt de cue. Dit voorbeeld drukt het track‑label en elke bijschrift‑regel af die “café” bevat.

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

## **Audio extraheren**

Een dia‑overgang kan een eigen geluid hebben. Om dat op te halen, roept u [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) aan op de dia‑overgang. Het voorbeeld krijgt toegang tot de bytes die door [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) worden geretourneerd en drukt het aantal bytes af. Als de eerste dia geen overgangsgeluid heeft, wordt in plaats daarvan een bericht afgedrukt.

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

**Kan ik hetzelfde audiobestand meerdere keren gebruiken op verschillende dia's zonder het te dupliceren?**

Ja. Voeg het fragment één keer toe aan de [audio‑collectie](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) en geef hetzelfde audio‑object door aan [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) voor elke dia.

**Kan ik het geluid in een bestaand audioframe vervangen?**

Ja. Voor een gekoppeld geluid gebruikt u [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) om naar het vervangende bestand te wijzen. Voor een ingebed geluid selecteert u een ander fragment uit de audio‑collectie van de presentatie met [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Beide benaderingen behouden het bestaande frame.

**Verandert het bijsnijden de audiogegevens die in de presentatie zijn opgeslagen?**

Nee. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) en [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) stellen de afspeelgrenzen in. U kunt nog steeds het volledige fragment ophalen via [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).