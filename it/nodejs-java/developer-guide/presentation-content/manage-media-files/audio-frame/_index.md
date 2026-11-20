---
title: Gestisci i frame audio nelle presentazioni usando JavaScript
linktitle: Frame audio
type: docs
weight: 10
url: /it/nodejs-java/audio-frame/
keywords:
- audio
- frame audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Incorpora audio nelle diapositive, modifica l'icona audio, configura la riproduzione, gestisci i sottotitoli WebVTT ed estrai i suoni di transizione delle diapositive con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Un frame audio consente di riprodurre un suono su una diapositiva. Con Aspose.Slides per Node.js via Java, è possibile incorporare una clip audio, scegliere l’immagine che la rappresenta, regolare la riproduzione e allegare i sottotitoli. È anche possibile recuperare un suono assegnato a una transizione di diapositiva.

## **Crea frame audio**

Usa [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) per incorporare una clip audio locale nella prima diapositiva. Le prime due coordinate posizionano il frame sulla diapositiva, e i successivi due valori impostano la sua larghezza e altezza, tutti in punti. Questo esempio chiama [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) per avviare automaticamente la clip e chiama [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) per selezionare il preset alto.

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

## **Modifica la miniatura del frame audio**

Per impostazione predefinita, un frame audio mostra un’icona di altoparlante. Per visualizzare una miniatura personalizzata, aggiungi un'immagine alla presentazione con [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) e impostala sull’immagine del frame con [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). L’esempio utilizza `eagle.jpeg` come miniatura per una clip audio incorporata.

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

## **Modifica le opzioni di riproduzione audio**

I controlli delle **Opzioni audio** di PowerPoint determinano quando una clip inizia, quanto è alta e come si comporta durante una presentazione.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Controllo PowerPoint | Aspose.Slides for Node.js via Java method |
| --- | --- |
| Avvio | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Preset volume | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Riproduci su più diapositive | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Ripeti fino a interruzione | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Nascondi durante la presentazione | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Riavvolgi dopo la riproduzione | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Dissolvenza in ingresso | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Dissolvenza in uscita | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Taglia tempo di inizio audio | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Taglia tempo di fine audio | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Slider volume | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

L’esempio trova il primo frame audio sulla prima diapositiva, chiama [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) per avviare la riproduzione al clic e seleziona il preset di volume basso. La clip continua su più diapositive con il looping disabilitato. L’icona rimane nascosta durante la presentazione, e la clip si riavvolge dopo la riproduzione.

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

Per una clip più lunga di 3,5 secondi, questo esempio salta i primi 1,5 secondi e gli ultimi 2 secondi. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) prende la durata da omettere alla fine della clip. Per ottenere il tempo di fine mostrato in PowerPoint, sottrai quell’intervallo dalla durata totale della clip. La clip tagliata sfuma in ingresso per 200 millisecondi e sfuma in uscita per 500 millisecondi. Tutti e quattro i metodi accettano valori in millisecondi.

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

Per impostare il volume di riproduzione a una percentuale specifica, usa [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Questo esempio imposta il primo frame audio sulla prima diapositiva all'85%.

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

## **Gestisci i sottotitoli audio**

Ogni frame audio fornisce l'accesso alle sue tracce di sottotitoli tramite [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Usa la collezione per allegare sottotitoli WebVTT alla clip, esportare le tracce esistenti o rimuoverle.

### **Aggiungi sottotitoli audio**

L’esempio incorpora una clip audio nella prima diapositiva e usa [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) per allegare una traccia WebVTT locale. Il primo argomento fornisce l’etichetta della traccia e il secondo identifica il file contenente i sottotitoli temporizzati.

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

### **Estrai i sottotitoli audio**

Questo esempio esporta ogni traccia di sottotitoli allegata a un frame audio sulla prima diapositiva. Scrive i byte restituiti da [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) in un file WebVTT e usa l’identificatore restituito da [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) come nome del file, così ogni traccia ha un output separato.

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

### **Rimuovi i sottotitoli audio**

Usa [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) per eliminare una singola traccia. L’esempio usa [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) per rimuovere tutti i sottotitoli dal primo frame audio sulla prima diapositiva mantenendo la clip.

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

### **Trova una riga nei sottotitoli audio**

Per trovare una riga nei sottotitoli audio sulla prima diapositiva, cerca il testo restituito da [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) in memoria. In un cue WebVTT di testo semplice, la riga di temporizzazione contiene `-->`, le righe di sottotitolo la seguono e una riga vuota termina il cue. Questo esempio stampa l’etichetta della traccia e ogni riga di sottotitolo contenente “café”.

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

## **Estrai audio**

Una transizione di diapositiva può avere un suono proprio. Per recuperarlo, chiama [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) sulla transizione della diapositiva. L’esempio accede ai byte restituiti da [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) e stampa il numero di byte. Se la prima diapositiva non ha suono di transizione, stampa un messaggio.

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

**Posso riutilizzare la stessa clip audio su più diapositive senza duplicarla?**

Sì. Aggiungi la clip una volta alla [collezione audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) della presentazione e passa lo stesso oggetto audio a [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) per ogni diapositiva.

**Posso sostituire il suono in un frame audio esistente?**

Sì. Per un suono collegato, usa [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) per puntare al file di sostituzione. Per un suono incorporato, seleziona un'altra clip dalla collezione audio della presentazione con [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Entrambi gli approcci preservano il frame esistente.

**Il ritaglio modifica i dati audio memorizzati nella presentazione?**

No. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) e [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) impostano i limiti di riproduzione. Puoi comunque recuperare la clip completa da [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).