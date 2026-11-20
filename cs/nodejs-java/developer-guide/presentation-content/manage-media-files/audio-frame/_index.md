---
title: Správa audio rámců v prezentacích pomocí JavaScriptu
linktitle: Audio rámec
type: docs
weight: 10
url: /cs/nodejs-java/audio-frame/
keywords:
- audio
- audio rámec
- náhled
- přidat audio
- vlastnosti audia
- volby audia
- extrahovat audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Vkládejte audio do snímků, měňte ikonu audia, nastavujte přehrávání, spravujte titulky WebVTT a získávejte zvuky přechodů snímků pomocí Aspose.Slides pro Node.js via Java."
---
## **Přehled**

Audio rámec vám umožní přehrát zvuk na snímku. S Aspose.Slides pro Node.js via Java můžete vložit zvukový klip, vybrat obrázek, který jej reprezentuje, upravit přehrávání a připojit titulky. Můžete také získat zvuk přiřazený k přechodu snímku.

## **Vytvoření audio rámců**

Použijte [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) k vložení lokálního audio klipu na první snímek. První dva souřadnice umístí rámec na snímek a další dva hodnoty nastaví jeho šířku a výšku, vše v bodech. Tento příklad volá [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) pro automatické spuštění klipu a volá [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) pro výběr hlasité předvolby.

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

## **Změna miniatury audio rámce**

Ve výchozím nastavení zobrazuje audio rámec ikonu reproduktoru. Pro zobrazení vlastní miniatury přidejte do prezentace obrázek pomocí [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) a nastavte jej na obrázek rámce pomocí [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). Příklad používá `eagle.jpeg` jako miniaturu pro vložený audio klip.

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

## **Změna možností přehrávání audia**

Ovládací prvky **Audio Options** v PowerPointu určují, kdy klip začne, jak hlasitý je a jak se chová během prezentace.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Ovládací prvek PowerPointu | Metoda Aspose.Slides pro Node.js via Java |
| --- | --- |
| Spuštění | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Předvolba hlasitosti | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Přehrát přes snímky | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Opakovat dokud není zastaveno | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Skrýt během prezentace | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Převinout po přehrání | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Prolínání dovnitř | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Prolínání ven | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Oříznout čas začátku audia | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Oříznout čas konce audia | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Posuvník hlasitosti | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

Příklad najde první audio rámec na prvním snímku, zavolá [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode), aby spustil přehrávání kliknutím, a vybere předvolbu nízké hlasitosti. Klip pokračuje přes snímky s vypnutým opakováním. Ikona zůstává skrytá během prezentace a klip se po přehrání převine.

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

Pro klip delší než 3,5 sekundy tento příklad přeskočí první 1,5 sekundy a poslední 2 sekundy. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) určuje dobu, která se má vynechat na konci klipu. Pro získání koncového času zobrazeného v PowerPointu odečtěte tuto odchylku od celkové délky klipu. Oříznutý klip se během 200 milisekund plynule zesílí a během 500 milisekund plynule zeslabí. Všechny čtyři metody přijímají hodnoty v milisekundách.

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

Pro nastavení hlasitosti přehrávání na konkrétní procento použijte [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Tento příklad nastaví první audio rámec na prvním snímku na 85 %.

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

## **Správa audio titulků**

Každý audio rámec poskytuje přístup ke svým stopám titulků pomocí [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Použijte kolekci k připojení WebVTT titulků ke klipu, exportu existujících stop nebo jejich odebrání.

### **Přidání audio titulků**

Příklad vloží audio klip na první snímek a použije [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add), aby připojil místní WebVTT stopu. První argument poskytuje štítek stopy a druhý určuje soubor obsahující časované titulky.

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

### **Extrahování audio titulků**

Tento příklad exportuje každou stopu titulků připojenou k audio rámci na prvním snímku. Zapíše bajty vrácené metodou [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) do souboru WebVTT a použije identifikátor vrácený metodou [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) jako název souboru, aby každá stopa měla samostatný výstup.

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

### **Odstranění audio titulků**

Použijte [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt), abyste smazali jednotlivou stopu. Příklad použije [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear), aby odstranil všechny titulky z prvního audio rámce na prvním snímku při zachování klipu.

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

### **Vyhledání řádku v audio titulcích**

Pro vyhledání řádku v audio titulcích na prvním snímku prohledejte v paměti text vrácený metodou [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString). V prostém textovém WebVTT cue obsahuje časová řádka znak `-->`, řádky titulků následují a prázdná řádka ukončuje cue. Tento příklad vypíše štítek stopy a každou řádku titulků obsahující „café“.

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

## **Extrahování audia**

Přechod snímku může mít svůj vlastní zvuk. Pro jeho získání zavolejte [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) na přechodu snímku. Příklad získá bajty vrácené metodou [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) a vypíše jejich počet. Pokud první snímek nemá zvuk přechodu, vypíše místo toho zprávu.

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

## **Často kladené otázky**

**Mohu znovu použít stejný audio klip na více snímcích bez jeho duplikování?**

Ano. Přidejte klip jednou do [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) prezentace a předávejte stejný audio objekt do [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) pro každý snímek.

**Mohu nahradit zvuk v existujícím audio rámci?**

Ano. Pro odkazovaný zvuk použijte [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong), aby ukazoval na náhradní soubor. Pro vložený zvuk vyberte jiný klip z audio kolekce prezentace pomocí [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Oba přístupy zachovávají existující rámec.

**Změní oříznutí audio data uložená v prezentaci?**

Ne. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) a [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) nastavují hranice přehrávání. Stále můžete získat celý klip pomocí [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).