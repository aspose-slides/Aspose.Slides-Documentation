---
title: Gestisci i frame video nelle presentazioni usando Node.js
linktitle: Frame video
type: docs
weight: 10
url: /it/nodejs-java/video-frame/
keywords:
- aggiungi video
- crea video
- incorpora video
- estrai video
- recupera video
- frame video
- fonte web
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara a aggiungere ed estrarre programmaticamente i frame video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per Node.js via Java. Guida pratica rapida."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides per Node.js tramite Java consente di aggiungere frame video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e i frame video, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/), la classe [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) e altri tipi pertinenti.

## **Crea un Frame Video Incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un frame video per incorporare il video nella tua presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni del frame sono in punti. Lo stream rimane aperto fino al termine del salvataggio perché [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) lo mantiene bloccato mentre la presentazione lo utilizza.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Puoi inoltre passare un percorso video locale direttamente a [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve rimanere accessibile fino al salvataggio della presentazione.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Crea un Frame Video con Video da una Fonte Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. Puoi creare un frame video che si collega a un video online, come un video di YouTube.

Questo esempio aggiunge un collegamento a un video di YouTube e una miniatura nella prima diapositiva. Sostituisci l’identificatore del video per usare un altro video. Il metodo [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) richiede la riproduzione automatica. Scaricare la miniatura e riprodurre il video richiede accesso a Internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione di video online.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riproduci un Video in Modalità Schermo Intero**

In una presentazione formativa, puoi riprodurre una dimostrazione software in modalità schermo intero così il pubblico può vedere i dettagli. Chiama [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) con `true` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) sulla prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con un frame video esistente sulla prima diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La riproduzione a schermo intero controlla come il video viene visualizzato. In modo indipendente, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) controlla se inizia automaticamente o al click, e [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). L’esempio preserva le impostazioni di avvio e ciclo esistenti.

## **Riavvolgi un Video Dopo la Riproduzione**

In una presentazione formativa, riportare un video dimostrativo all’inizio lo rende pronto per il presentatore per riprodurlo di nuovo. Chiama [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) con `true` per riportare il video all’inizio dopo che la riproduzione è terminata.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) sulla prima diapositiva e abilita il riavvolgimento. Disabilita il ciclo in modo che la riproduzione possa terminare e imposta la riproduzione per avviarsi al click. La presentazione di input deve contenere almeno una diapositiva con un frame video esistente sulla prima diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il riavvolgimento riporta il video all’inizio senza avviarlo nuovamente. Al contrario, chiamare [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) con `true` ripete automaticamente la riproduzione. Mantieni il ciclo disabilitato quando vuoi che il video termini e rimanga pronto per essere riprodotto. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) controlla in modo indipendente l’avvio automatico o al click; questo esempio utilizza [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) così il presentatore controlla quando avviare la riproduzione. Imposta la modalità di riproduzione dopo l’impostazione del ciclo, come mostrato nell’esempio. Il riavvolgimento funziona indipendentemente da [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Ritaglia un Frame Video**

Usa [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) per saltare una parte dell’inizio o della fine di un video durante la riproduzione. Entrambi i valori sono in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta le Impostazioni di Ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l’ultimo secondo durante la riproduzione. Usa un video più lungo di 3,5 secondi così rimane un segmento riproducibile.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Leggi le Impostazioni di Ritaglio**

Questo esempio stampa i valori di ritaglio del primo frame video sulla prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha un frame video, non viene stampato nulla. L’esempio precedente produce valori di 2500 e 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gestisci i Sottotitoli Video**

Aspose.Slides consente di gestire i sottotitoli (closed captions) per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati in formato WebVTT e sono esposti tramite il metodo [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

### **Aggiungi Sottotitoli a un Frame Video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT etichettata English. I timestamp dei sottotitoli devono corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) fornisce anche il metodo [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) per aggiungere sottotitoli da uno stream.

### **Estrai i Sottotitoli da un Frame Video**

Questo esempio salva tutte le tracce di sottotitoli dai frame video sulla prima diapositiva come file WebVTT separati. Numeri sequenziali mantengono distinti i file di output. La console segnala il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) espone l’identificatore del sottotitolo, l’etichetta, i dati binari e il testo del sottotitolo come stringa UTF‑8.

### **Rimuovi i Sottotitoli da un Frame Video**

Questo esempio rimuove tutti i sottotitoli dal frame video nella prima posizione della forma sulla prima diapositiva e salva il risultato. Si assume che la diapositiva e la forma esistano e che la forma sia un frame video.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) invece di [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

### **Cerca i Sottotitoli Video**

Il metodo [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) restituisce l’intera traccia WebVTT, includendo l’intestazione, le linee temporali e il testo del sottotitolo. Puoi cercare il testo del sottotitolo in memoria per trovare una frase e il suo timestamp. Ad esempio, una traccia English nella diapositiva 2 potrebbe contenere questo cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Questo esempio apre `captioned_media.pptx` e utilizza [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) per leggere le tracce di ciascun frame video di primo livello in ogni diapositiva. In un cue di testo semplice, la linea temporale contiene `-->` e una riga vuota termina il cue. Per ogni sottotitolo che contiene “café” in qualsiasi combinazione di lettere, l’esempio stampa il numero della diapositiva, l’etichetta della traccia, la linea temporale originale e il sottotitolo completo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Cercare “café” trova una corrispondenza nella traccia di esempio. La ricerca salta l’intestazione della traccia e preserva l’impostazione temporale e l’interruzione di riga nell’output.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Estrai Video da una Diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari numerati separati. I video collegati vengono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ciascun video e il contatore totale. L’output utilizza l’estensione generica `.bin`; modificala per corrispondere al tipo di media segnalato, se necessario.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un frame video?**

Puoi controllare la [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto o al click) e il [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Queste opzioni sono disponibili tramite i metodi dell’oggetto [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulle dimensioni del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi le dimensioni della presentazione crescono in proporzione alla dimensione del file. Quando colleghi a un video online e aggiungi una miniatura, la presentazione memorizza il collegamento e l’immagine di anteprima anziché i dati del video, quindi l’aumento di dimensione è solitamente minore.

**Posso sostituire il video in un frame video esistente senza cambiarne posizione e dimensioni?**

Sì. Puoi scambiare il [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) all’interno del frame mantenendo la geometria della forma; è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.