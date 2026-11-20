---
title: Hantera ljudramar i presentationer på Android
linktitle: Ljudram
type: docs
weight: 10
url: /sv/androidjava/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- Android
- Java
- Aspose.Slides
description: "Bädda in ljud i bilder, ändra ljudikonen, konfigurera uppspelning, hantera WebVTT-textning och extrahera ljud från bildövergångar med Aspose.Slides för Android via Java."
---
## **Översikt**

En ljudram låter dig spela ett ljud på en bild. Med Aspose.Slides for Android via Java kan du bädda in ett ljudklipp, välja bilden som representerar det, justera uppspelning och bifoga bildtexter. Du kan också hämta ett ljud som är tilldelat en bildövergång.

## **Skapa ljudramar**

Använd [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) för att bädda in ett lokalt ljudklipp på den första bilden. De två första koordinaterna placerar ramen på bilden, och de två nästa värdena anger dess bredd och höjd, alla i punkter. Detta exempel anropar [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) för att starta klippet automatiskt och anropar [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) för att välja den högsta volyminställningen.

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

## **Ändra ljudramens miniatyrbild**

Som standard visar en ljudram en högtalarikon. För att visa en anpassad miniatyrbild, lägg till en bild i presentationen med [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) och sätt den på ramens bild med [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). Exemplet använder en JPEG som miniatyrbild för ett inbäddat ljudklipp.

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

## **Ändra ljuduppspelningsalternativ**

PowerPoints **Audio Options**-kontroller bestämmer när ett klipp startar, hur högt det låter och hur det beter sig under en bildspel.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑kontroll | Aspose.Slides for Android via Java method |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Volymförinställning | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Spela över bilder | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Upprepa tills stoppad | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Dölj under visning | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Spola tillbaka efter uppspelning | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Tona in | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Tona ut | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Trimma ljudets starttid | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Trimma ljudets sluttid | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volymreglage | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

Exemplet hittar den första ljudramen på den första bilden, anropar [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) för att starta uppspelning vid ett klick och väljer den låga volymförinställningen. Klippet fortsätter över bilder med loopning avstängd. Ikonen förblir dold under visningen, och klippet spolar tillbaka efter uppspelning.

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

För ett klipp som är längre än 3,5 sekunder hoppar detta exempel över de första 1,5 sekunderna och de sista 2 sekunderna. [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) tar emot den varaktighet som ska utelämnas från klippets slut. För att få den sluttid som visas i PowerPoint, subtrahera detta offset från hela klippets varaktighet. Det trimmade klippet tonar in på 200 ms och tonar ut på 500 ms. Alla fyra metoder tar värden i millisekunder.

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

För att ange uppspelningsvolymen till en specifik procentsats, använd [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Detta exempel sätter den första ljudramen på den första bilden till 85 %.

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

## **Hantera ljudtextning**

Varje ljudram ger åtkomst till sina textningsspår via [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--). Använd samlingen för att bifoga WebVTT‑textning till klippet, exportera befintliga spår eller ta bort dem.

### **Lägg till ljudtextning**

Exemplet bäddar in ett ljudklipp på den första bilden och använder [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) för att bifoga ett lokalt WebVTT‑spår. Det första argumentet anger spårets etikett och det andra identifierar filen som innehåller tidskodad textning.

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

### **Extrahera ljudtextning**

Detta exempel exporterar varje textningsspår som är bifogat en ljudram på den första bilden. Det skriver de byte som returneras av [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) till en WebVTT‑fil och använder identifieraren som returneras av [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) som filnamn så att varje spår får en separat utdata.

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

### **Ta bort ljudtextning**

Använd [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) eller [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) för att ta bort ett enskilt spår. Exemplet använder [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) för att ta bort all textning från den första ljudramen på den första bilden samtidigt som klippet bevaras.

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

### **Hitta en rad i ljudtextning**

För att hitta en rad i ljudtextningen på den första bilden, sök i texten som returneras av [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) i minnet. I en ren text‑WebVTT‑cue innehåller tidradens `-->`, följt av textningsraderna och en tom rad avslutar cue:n. Detta exempel skriver ut spårets etikett och varje textningsrad som innehåller “café”.

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

## **Extrahera ljud**

En bildövergång kan ha sitt eget ljud. För att hämta det, anropa [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) på bildövergången. Exemplet får åtkomst till de byte som returneras av [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) och skriver ut antalet byte. Om den första bilden saknar övergångsljud skrivs ett meddelande istället.

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

**Kan jag återanvända samma ljudklipp på flera bilder utan att duplicera det?**

Ja. Lägg till klippet en gång i presentationens [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) och skicka samma ljudobjekt till [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) för varje bild.

**Kan jag ersätta ljudet i en befintlig ljudram?**

Ja. För ett länkat ljud, använd [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) för att peka på ersättningsfilen. För ett inbäddat ljud, välj ett annat klipp från presentationens ljudsamling med [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Båda metoderna bevarar den befintliga ramen.

**Ändrar trimning ljuddata som lagras i presentationen?**

Nej. [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) och [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) anger uppspelningsgränser. Du kan fortfarande hämta hela klippet från [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).