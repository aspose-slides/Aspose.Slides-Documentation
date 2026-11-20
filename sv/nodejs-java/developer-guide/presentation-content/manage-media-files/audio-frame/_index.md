---
title: Hantera ljudramar i presentationer med JavaScript
linktitle: Ljudram
type: docs
weight: 10
url: /sv/nodejs-java/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- Node.js
- JavaScript
- Aspose.Slides
description: "Bädda in ljud i bilder, ändra ljudikonen, konfigurera uppspelning, hantera WebVTT-textning och extrahera ljud för bildövergångar med Aspose.Slides för Node.js via Java."
---
## **Översikt**

En ljudram gör att du kan spela upp ett ljud på en bild. Med Aspose.Slides för Node.js via Java kan du bädda in ett ljudklipp, välja bilden som representerar det, justera uppspelning och bifoga bildtexter. Du kan också hämta ett ljud som är tilldelat en bildövergång.

## **Skapa ljudramar**

Använd [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) för att bädda in ett lokalt ljudklipp på den första bilden. De två första koordinaterna placerar ramen på bilden, och de nästa två värdena anger dess bredd och höjd, alla i punkter. Detta exempel anropar [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) för att starta klippet automatiskt och anropar [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) för att välja det höga volympresetet.

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

## **Ändra ljudramens miniatyrbild**

Som standard visar en ljudram en högtalarikon. För att visa en anpassad miniatyr, lägg till en bild i presentationen med [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) och sätt den på ramens bild med [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). Exemplet använder `eagle.jpeg` som miniatyr för ett inbäddat ljudklipp.

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

## **Ändra ljuduppspelningsalternativ**

PowerPoints **Audioalternativ**‑kontroller bestämmer när ett klipp startar, hur högt det låter och hur det beter sig under en bildspelsvisning.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑kontroll | Aspose.Slides för Node.js via Java‑metod |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Volym‑preset | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Spela över bilder | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loopa tills stoppad | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Dölj under visning | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Spola tillbaka efter uppspelning | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Tona in | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Tona ut | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Beskär ljud starttid | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Beskär ljud sluttid | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volym‑reglage | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Exemplet hittar den första ljudramen på den första bilden, anropar [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) för att starta uppspelning vid ett klick och väljer det låga volympresetet. Klippet fortsätter över bilder med loopning inaktiverad. Ikonen hålls dold under visningen, och klippet spolas tillbaka efter uppspelning.

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

För ett klipp som är längre än 3,5 sekunder hoppar detta exempel över de första 1,5 sekunderna och de sista 2 sekunderna. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) tar den varaktighet som ska tas bort från klippets slut. För att få sluttiden som visas i PowerPoint, subtrahera detta offset från hela klippets varaktighet. Det beskurna klippet tonar in under 200 ms och tonar ut under 500 ms. Alla fyra metoder tar värden i millisekunder.

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

För att sätta uppspelningsvolymen till en specifik procent, använd [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Detta exempel sätter den första ljudramen på den första bilden till 85 %.

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

## **Hantera ljudtextning**

Varje ljudram ger åtkomst till sina bildspår via [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Använd samlingen för att bifoga WebVTT‑textning till klippet, exportera befintliga spår eller ta bort dem.

### **Lägg till ljudtextning**

Exemplet bäddar in ett ljudklipp på den första bilden och använder [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) för att fästa ett lokalt WebVTT‑spår. Det första argumentet anger spår‑etiketten, och det andra identifierar filen som innehåller de tidsbestämda undertexterna.

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

### **Extrahera ljudtextning**

Detta exempel exporterar varje bildspår som är fäst vid en ljudram på den första bilden. Det skriver de byte som returneras av [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) till en WebVTT‑fil och använder identifieraren som returneras av [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) som filnamn så att varje spår får en separat output.

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

### **Ta bort ljudtextning**

Använd [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) för att radera ett enskilt spår. Exemplet använder [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) för att ta bort all bildtextning från den första ljudramen på den första bilden samtidigt som klippet bevaras.

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

### **Hitta en rad i ljudtextning**

För att hitta en rad i ljudtextningen på den första bilden, sök i texten som returneras av [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) i minnet. I ett ren‑text WebVTT‑cues innehåller tidsraden `-->`, bildtextraderna följer den, och en tom rad avslutar cue:n. Detta exempel skriver ut spår‑etiketten och varje bildtextrad som innehåller “café”.

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

## **Extrahera ljud**

En bildövergång kan ha sitt eget ljud. För att hämta det, anropa [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) på bildövergången. Exemplet får tillgång till de byte som returneras av [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) och skriver ut antalet byte. Om den första bilden saknar övergångsljud skriver den ut ett meddelande istället.

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

## **FAQ**

**Kan jag återanvända samma ljudklipp på flera bilder utan att duplicera det?**

Ja. Lägg till klippet en gång i presentationens [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) och skicka samma ljudobjekt till [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) för varje bild.

**Kan jag ersätta ljudet i en befintlig ljudram?**

Ja. För ett länkat ljud, använd [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) för att peka på ersättningsfilen. För ett inbäddat ljud, välj ett annat klipp från presentationens ljudsamling med [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Båda metoderna bevarar den befintliga ramen.

**Ändrar trimming ljuddata som lagras i presentationen?**

Nej. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) och [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) sätter uppspelningsgränser. Du kan fortfarande hämta hela klippet via [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).