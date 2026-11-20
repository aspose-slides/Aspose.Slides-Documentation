---
title: Audio keretek kezelése prezentációkban JavaScript használatával
linktitle: Audio keret
type: docs
weight: 10
url: /hu/nodejs-java/audio-frame/
keywords:
- hang
- hangkeret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerés
- Node.js
- JavaScript
- Aspose.Slides
description: "Hang beágyazása diákba, a hang ikon módosítása, lejátszás beállítása, WebVTT feliratok kezelése, valamint diaátmeneti hangok kinyerése az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

Az audio keret lehetővé teszi hang lejátszását a dián. Az Aspose.Slides for Node.js via Java segítségével beágyazhatsz egy hangklipet, kiválaszthatod a hozzá tartozó képet, szabályozhatod a lejátszást, és felveheted a feliratokat. A diaváltáshoz rendelt hangot is lekérheted.

## **Audio keretek létrehozása**

Használd a [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) metódust a helyi audio klip beágyazásához az első diára. Az első két koordináta helyezi a keretet a diához, a következő két érték állítja be a szélességét és magasságát, mind pontban. Ez a példa meghívja a [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) metódust a klip automatikus indításához, és a [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) metódust a hangos előre beállított érték kiválasztásához.

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

## **Az audio keret bélyegképének módosítása**

Alapértelmezés szerint egy audio keret a hangszóró ikont jeleníti meg. Egy egyéni bélyegkép megjelenítéséhez adj egy képet a prezentációhoz a [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) metódussal, és állítsd be a keret képként a [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) metódussal. A példa az `eagle.jpeg` fájlt használja bélyegképként a beágyazott audio kliphez.

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

## **Az audio lejátszási beállítások módosítása**

A PowerPoint **Audio Options** vezérlői határozzák meg, hogy mikor indul a klip, milyen hangos, és hogyan viselkedik a diavetítés során.

![PowerPoint Audio Options vezérlők egy audio kerethez](audio_frame_0.png)

| PowerPoint vezérlő | Aspose.Slides for Node.js via Java metódus |
| --- | --- |
| Indítás | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Hangerő előre beállított érték | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Lejátszás diákon át | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Ismétlés leállításig | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Elrejtés a vetítés során | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Visszatekerés lejátszás után | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Belenyúlás | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Kimenyúlás | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Audio vágás kezdőidő | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Audio vágás befejező idő | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Hangerő csúszka | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

A példa megtalálja az első audio keretet az első dián, meghívja a [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) metódust a lejátszás kattintásra indításához, és az alacsony hangerő előre beállított értéket választja. A klip diákon át folytatódik a ismétlés letiltásával. Az ikon rejtve marad a vetítés során, és a klip a lejátszás után visszatekeredik.

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

3,5 másodpercnél hosszabb klip esetén ez a példa kihagyja az első 1,5 másodpercet és az utolsó 2 másodpercet. A [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) metódus a klip végéről elhagyandó időt veszi át. A PowerPointban látható befejezési időhez vonjuk le ezt az eltolást a teljes klip időtartamából. A levágott klip 200 milliszekundumban belenyúlik és 500 milliszekundumban kimenyúlik. Mind a négy metódus értékét milliszekundumban várja.

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

A lejátszási hangerő konkrét százalékra állításához használd a [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) metódust. Ez a példa az első dián lévő első audio keretet 85%-ra állítja.

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

## **Audio feliratok kezelése**

Minden audio keret hozzáférést biztosít a felirat sávjaihoz a [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) metóduson keresztül. A gyűjteményt használhatod WebVTT feliratok csatolására a kliphez, meglévő sávok exportálására vagy eltávolítására.

### **Audio feliratok hozzáadása**

A példa egy audio klipet ágyaz be az első diára, és a [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) metódust használja egy helyi WebVTT sáv csatolásához. Az első argumentum a sáv címkéjét adja meg, a második a feliratok időzítését tartalmazó fájlt.

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

### **Audio feliratok kinyerése**

Ez a példa exportálja az első diához csatolt audio keret minden felirat sávját. A [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) által visszaadott bájtokat egy WebVTT fájlba írja, és a [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) által visszaadott azonosítót használja fájlnévként, hogy minden sáv külön kimenettel rendelkezzen.

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

### **Audio feliratok eltávolítása**

Használd a [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) vagy [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) metódust egy egyedi sáv törléséhez. A példa a [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) metódust használja, hogy az első diához tartozó első audio keret összes feliratát eltávolítsa, miközben a klip megmarad.

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

### **Sor keresése audio feliratokban**

Az első dián lévő audio feliratokban sor kereséséhez keresd a [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) által visszaadott szöveget a memóriában. Egy egyszerű szöveges WebVTT cue-ban az időzítési sor `-->` tartalmaz, a feliratsorok ezt követik, és egy üres sor zárja a cue-t. Ez a példa kiírja a sáv címkéjét és minden olyan feliratsort, amely tartalmazza a „café” szót.

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

## **Audio kinyerése**

Egy diaváltás saját hanggal rendelkezhet. A lekéréséhez hívd a [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) metódust a diaváltáson. A példa a [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) által visszaadott bájtokat érinti, és kiírja a bájtok számát. Ha az első diának nincs váltási hangja, akkor egy üzenetet ír ki.

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

## **GYIK**

**Újra felhasználhatom ugyanazt a hangklipet több dián anélkül, hogy duplikálnám?**

Igen. Add hozzá a klipet egyszer a prezentáció [audio gyűjtemény](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) gyűjteményéhez, és minden diára add át ugyanazt az audio objektumot a [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) hívásával.

**Lecserélhetem egy meglévő audio keret hangját?**

Igen. Kapcsolt hang esetén a [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) metódust használd a helyettesítő fájlra mutatásra. Beágyazott hang esetén válassz egy másik klipet a prezentáció audio gyűjteményéből a [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio) metódussal. Mindkét megközelítés megőrzi a meglévő keretet.

**A vágás megváltoztatja a prezentációban tárolt audio adatot?**

Nem. A [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) és a [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) metódusok a lejátszási határokat állítják be. A teljes klip továbbra is lekérhető a [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio) metódussal.