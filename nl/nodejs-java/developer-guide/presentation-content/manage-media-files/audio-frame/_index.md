---
title: Audio‑frames beheren in presentaties met JavaScript
linktitle: Audio‑frame
type: docs
weight: 10
url: /nl/nodejs-java/audio-frame/
keywords:
- geluid
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- Node.js
- JavaScript
- Aspose.Slides
description: "Audio insluiten in dia's, het audio‑icoon wijzigen, de weergave configureren, WebVTT‑bijschriften beheren en geluiden van dia‑overgangen extraheren met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Een audio‑frame stelt u in staat een geluid op een dia af te spelen. Met Aspose.Slides voor Node.js via Java kunt u een audioclip insluiten, de afbeelding kiezen die het vertegenwoordigt, de weergave aanpassen en bijschriften toevoegen. U kunt ook een geluid ophalen dat aan een dia‑overgang is toegewezen.

## **Audio‑frames maken**

Gebruik [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) om een lokale audioclip in te sluiten op de eerste dia. De eerste twee coördinaten positioneren het frame op de dia, en de volgende twee waarden stellen de breedte en hoogte in, allemaal in points. Dit voorbeeld roept [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) aan om de clip automatisch te starten en roept [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) aan om de luide voorinstelling te selecteren.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Miniatuur van audio‑frame wijzigen**

Standaard toont een audio‑frame een luidspreker‑icoon. Om een aangepaste miniatuur weer te geven, voegt u een afbeelding toe aan de presentatie met [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) en stelt u deze in op de afbeelding van het frame met [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). Het voorbeeld gebruikt `eagle.jpeg` als miniatuur voor een ingesloten audioclip.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Audio‑afspeelopties wijzigen**

De **Audio‑opties** van PowerPoint bepalen wanneer een clip start, hoe luid deze klinkt en hoe hij zich gedraagt tijdens een diavoorstelling.

![PowerPoint-audioptie‑besturingselementen voor een audio‑frame](audio_frame_0.png)

| PowerPoint‑besturing | Aspose.Slides voor Node.js via Java‑methode |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Voorinstelling volume | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Afspelen over dia's | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Herhalen tot gestopt | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Verbergen tijdens voorstelling | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Terugspoelen na afspelen | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Infaden | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Uitfaden | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Begin tijd audio bijsnijden | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Eind tijd audio bijsnijden | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volumeschuifregelaar | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Het voorbeeld zoekt het eerste audio‑frame op de eerste dia, roept [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) aan om de weergave te starten bij een klik, en selecteert de lage volume‑voorinstelling. De clip blijft over dia's afspelen met herhalen uitgeschakeld. Het icoon blijft verborgen tijdens de voorstelling, en de clip wordt na het afspelen teruggespoeld.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Voor een clip langer dan 3,5 seconden slaat dit voorbeeld de eerste 1,5 seconde en de laatste 2 seconden over. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) neemt de duur die van het einde van de clip moet worden weggelaten. Om de eindtijd te krijgen die in PowerPoint wordt weergegeven, trekt u die offset af van de volledige clipduur. De bijgesneden clip fade‑in over 200 milliseconden en fade‑out over 500 milliseconden. Alle vier methoden nemen waarden in milliseconden.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om het afspeelvolume op een specifiek percentage in te stellen, gebruikt u [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Dit voorbeeld stelt het eerste audio‑frame op de eerste dia in op 85%.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Audio‑bijschriften beheren**

Elk audio‑frame biedt toegang tot zijn bijschrift‑tracks via [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Gebruik de collectie om WebVTT‑bijschriften aan de clip toe te voegen, bestaande tracks te exporteren of ze te verwijderen.

### **Audio‑bijschriften toevoegen**

Het voorbeeld sluit een audioclip in op de eerste dia en gebruikt [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) om een lokale WebVTT‑track toe te voegen. Het eerste argument levert het track‑label, en het tweede identificeert het bestand dat de getimede bijschriften bevat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Audio‑bijschriften extraheren**

Dit voorbeeld exporteert elke bijschrift‑track die aan een audio‑frame op de eerste dia is gekoppeld. Het schrijft de bytes die door [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) worden geretourneerd naar een WebVTT‑bestand en gebruikt de identifier die door [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) wordt geretourneerd als bestandsnaam zodat elke track een afzonderlijke output heeft.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Audio‑bijschriften verwijderen**

Gebruik [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) om een individuele track te verwijderen. Het voorbeeld gebruikt [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) om alle bijschriften van het eerste audio‑frame op de eerste dia te verwijderen terwijl de clip behouden blijft.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Een regel in audio‑bijschriften vinden**

Om een regel in de audio‑bijschriften op de eerste dia te vinden, zoekt u in het geheugen naar de tekst die door [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) wordt geretourneerd. In een platte‑tekst WebVTT‑cue bevat de timing‑regel `-->`, de bijschrift‑regels volgen deze, en een lege regel beëindigt de cue. Dit voorbeeld print het track‑label en elke bijschrift‑regel die “café” bevat.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Audio extraheren**

Een dia‑overgang kan zijn eigen geluid hebben. Om dit op te halen, roept u [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) aan op de dia‑overgang. Het voorbeeld krijgt toegang tot de bytes die door [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) worden geretourneerd en print het aantal bytes. Als de eerste dia geen overgangsgeluid heeft, wordt in plaats daarvan een bericht geprint.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Kan ik dezelfde audioclip op meerdere dia's hergebruiken zonder deze te dupliceren?**

Ja. Voeg de clip één keer toe aan de [audio collectie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) van de presentatie en geef hetzelfde audio‑object door aan [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) voor elke dia.

**Kan ik het geluid in een bestaand audio‑frame vervangen?**

Ja. Voor een gekoppeld geluid gebruikt u [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) om naar het vervangende bestand te verwijzen. Voor een ingebed geluid selecteert u een andere clip uit de audio‑collectie van de presentatie met [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Beide benaderingen behouden het bestaande frame.

**Verandert bijsnijden de audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) en [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) stellen afspeelgrenzen in. U kunt nog steeds de volledige clip ophalen via [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).