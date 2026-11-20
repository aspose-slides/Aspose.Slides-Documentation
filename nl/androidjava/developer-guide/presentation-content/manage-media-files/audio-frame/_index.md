---
title: Audioframes beheren in presentaties op Android
linktitle: Audioframe
type: docs
weight: 10
url: /nl/androidjava/audio-frame/
keywords:
- audio
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- Android
- Java
- Aspose.Slides
description: "Audio in dia's insluiten, het audio-icoon wijzigen, de weergave configureren, WebVTT-bijschriften beheren en geluiden van dia-overgangen extraheren met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een audioframe stelt u in staat een geluid af te spelen op een dia. Met Aspose.Slides for Android via Java kunt u een audioclipp invoegen, de afbeelding kiezen die het vertegenwoordigt, de weergave aanpassen en ondertitels toevoegen. U kunt ook een geluid ophalen dat aan een diaovergang is toegewezen.

## **Audioframes maken**

Gebruik [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) om een lokaal audioclipp in te voegen op de eerste dia. De eerste twee coördinaten plaatsen het frame op de dia, en de volgende twee waarden bepalen de breedte en hoogte, allemaal in punten. Dit voorbeeld roept [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) aan om de clip automatisch te starten en roept [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) aan om de harde voorinstelling te selecteren.

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

## **Thumbnail van audioframe wijzigen**

Standaard toont een audioframe een luidsprekericoon. Om een aangepaste thumbnail weer te geven, voegt u een afbeelding toe aan de presentatie met [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) en stelt u deze in op de afbeelding van het frame met [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). Het voorbeeld gebruikt een JPEG als thumbnail voor een ingevoegde audioclipp.

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

## **Audio-afspeelopties wijzigen**

De **Audio‑opties** van PowerPoint bepalen wanneer een clip start, hoe hard deze klinkt en hoe hij zich gedraagt tijdens een diavoorstelling.

![PowerPoint-audio-opties voor een audioframe](audio_frame_0.png)

| PowerPoint‑besturing | Aspose.Slides for Android via Java‑methode |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Volume‑preset | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Afspelen over dia's | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Lus tot gestopt | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Verbergen tijdens weergave | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Terugsponnen na afspelen | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade‑in | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade‑out | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Audio starttijd bijsnijden | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Audio eindtijd bijsnijden | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volumeschuifregelaar | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Het voorbeeld zoekt het eerste audioframe op de eerste dia, roept [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) aan om de weergave te starten bij een klik, en selecteert de lage volume‑preset. De clip gaat door over dia's met uitgeschakelde lus. Het icoon blijft verborgen tijdens de voorstelling, en de clip wordt na het afspelen teruggesponnen.

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

Voor een clip langer dan 3,5 seconden slaat dit voorbeeld de eerste 1,5 seconden en de laatste 2 seconden over. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) neemt de duur die van het einde van de clip moet worden weggelaten. Om de eindtijd te krijgen die in PowerPoint wordt getoond, trekt u die offset af van de totale clipduur. De bijgesneden clip fade‑in binnen 200 milliseconden en fade‑out binnen 500 milliseconden. Alle vier methoden accepteren waarden in milliseconden.

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

Om het afspeelvolume op een specifiek percentage in te stellen, gebruikt u [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Dit voorbeeld stelt het eerste audioframe op de eerste dia in op 85%.

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

Elk audioframe biedt toegang tot zijn bijschriftsporen via [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Gebruik de collectie om WebVTT‑bijschriften aan de clip toe te voegen, bestaande sporen te exporteren of te verwijderen.

### **Audio‑bijschriften toevoegen**

Het voorbeeld voegt een audioclipp in op de eerste dia en gebruikt [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) om een lokaal WebVTT‑spoor toe te voegen. Het eerste argument levert het spoorlabel, en het tweede identificeert het bestand met de getimede bijschriften.

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

Dit voorbeeld exporteert elk bijschriftspoor dat aan een audioframe op de eerste dia is gekoppeld. Het schrijft de bytes die [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) retourneert naar een WebVTT‑bestand en gebruikt de identifier die [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) retourneert als bestandsnaam zodat elk spoor een aparte output heeft.

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

### **Audio‑bijschriften verwijderen**

Gebruik [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) om een individueel spoor te verwijderen. Het voorbeeld gebruikt [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) om alle bijschriften van het eerste audioframe op de eerste dia te verwijderen terwijl de clip behouden blijft.

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

Om een regel in de audio‑bijschriften op de eerste dia te vinden, zoekt u in het geheugen naar de tekst die [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) retourneert. In een platte‑tekst WebVTT‑cue bevat de timing‑regel `-->`, de bijschriftregels volgen, en een lege regel beëindigt de cue. Dit voorbeeld drukt het spoorlabel en elke bijschriftregel af die “café” bevat.

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

## **Audio extraheren**

Een diaovergang kan een eigen geluid hebben. Om dit op te halen, roept u [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) aan op de diaovergang. Het voorbeeld krijgt toegang tot de bytes die [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) retourneert en drukt het aantal bytes af. Als de eerste dia geen overgangsgeluid heeft, wordt in plaats daarvan een bericht afgedrukt.

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

**Kan ik dezelfde audioclipp hergebruiken op meerdere dia's zonder deze te dupliceren?**

Ja. Voeg de clip één keer toe aan de [audio‑collectie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) van de presentatie en geef hetzelfde audio‑object door aan [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) voor elke dia.

**Kan ik het geluid in een bestaand audioframe vervangen?**

Ja. Voor een gekoppeld geluid gebruikt u [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) om naar het vervangende bestand te wijzen. Voor een ingebed geluid selecteert u een andere clip uit de audio‑collectie van de presentatie met [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Beide benaderingen behouden het bestaande frame.

**Verandert bijsnijden de audiogegevens die in de presentatie zijn opgeslagen?**

Nee. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) en [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) bepalen alleen de afspeelgrenzen. U kunt nog steeds de volledige clip ophalen via [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).