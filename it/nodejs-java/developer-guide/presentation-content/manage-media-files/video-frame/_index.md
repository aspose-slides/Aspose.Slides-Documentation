---
title: Gestire i frame video nelle presentazioni usando JavaScript
linktitle: Frame video
type: docs
weight: 10
url: /it/nodejs-java/video-frame/
keywords:
- aggiungere video
- creare video
- incorporare video
- estrarre video
- recuperare video
- frame video
- fonte web
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i frame video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per Node.js tramite Java. Guida pratica rapida."
---
## **Introduzione**

Un video ben posizionato in una presentazione può rendere il tuo messaggio più coinvolgente e aumentare il livello di partecipazione del pubblico. 

PowerPoint consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungere o incorporare un video locale (memorizzato sul tuo computer)
* Aggiungere un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/video/), la classe [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) e altri tipi pertinenti.

## **Crea un frame video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un frame video per incorporare il video nella tua presentazione. 

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation)class.
1. Ottieni un riferimento alla diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/video/) e passa il percorso del file video per incorporare il video nella presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) per creare un frame per il video.
1. Salva la presentazione modificata. 

Questo codice JavaScript mostra come aggiungere un video memorizzato localmente a una presentazione:

```javascript
// Istanzia la classe Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Carica il video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Ottiene la prima diapositiva e aggiunge un videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Salva la presentazione su disco
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternativamente, è possibile aggiungere un video passando direttamente il percorso del file al metodo [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Crea un frame video con video da fonte web**

Microsoft [PowerPoint 2013 e versioni successive](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporta i video di YouTube nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad esempio su YouTube), puoi aggiungerlo alla presentazione tramite il suo link web. 

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation)class
1. Ottieni un riferimento alla diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/video/) e passa il link al video.
1. Imposta una miniatura per il frame video. 
1. Salva la presentazione. 

Questo codice JavaScript mostra come aggiungere un video dal web a una diapositiva in una presentazione PowerPoint:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Ritaglia un frame video**

Aspose.Slides consente di controllare quale parte di un video viene riprodotta impostando i valori trim‑from‑start e trim‑from‑end tramite [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/settrimfromstart/) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/settrimfromend/). Entrambi i valori sono specificati in millisecondi e definiscono quanto tempo viene saltato dall'inizio e dalla fine del video, rispettivamente. queste impostazioni modificano le impostazioni di riproduzione del video nella presentazione; non tagliano né modificano i dati binari del video incorporato.

**Imposta le impostazioni di ritaglio**

Per creare un frame video e impostarne le impostazioni di ritaglio:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/)class.
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/video/) alla presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) a una diapositiva.
1. Imposta i valori trim‑from‑start e trim‑from‑end tramite [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/settrimfromstart/) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/settrimfromend/).
1. Salva la presentazione modificata.

Il seguente esempio di codice salta i primi 2,5 secondi e l'ultimo secondo di un video incorporato durante la riproduzione:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Leggi le impostazioni di ritaglio**

Per ispezionare le impostazioni di ritaglio esistenti, carica una presentazione, trova un oggetto [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) tra le forme della prima diapositiva e leggi i valori tramite [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) e [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/gettrimfromend/).

Il seguente esempio di codice trova il primo frame video nella prima diapositiva e ne riporta le impostazioni di ritaglio in millisecondi:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati in formato WebVTT e sono accessibili tramite il metodo [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Aggiungi sottotitoli a un frame video**

Per aggiungere sottotitoli a un frame video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/)class.
1. Aggiungi un video alla presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) a una diapositiva.
1. Usa la collezione [CaptionsCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/) per aggiungere una traccia di sottotitoli WebVTT.
1. Salva la presentazione modificata.

Il seguente codice mostra come aggiungere sottotitoli a un frame video:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Aggiunge una nuova traccia di sottotitoli da un file WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/) fornisce anche il metodo [addFromStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/#addFromStream) che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un frame video**

Per estrarre i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Trova l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) target.
1. Itera attraverso la collezione [CaptionsCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/).
1. Salva ogni traccia di sottotitoli in un file `.vtt`.

Il seguente codice mostra come estrarre i sottotitoli da un frame video:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Salva la traccia di sottotitoli in un file WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF‑8.

**Rimuovi i sottotitoli da un frame video**

Per rimuovere i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Ottieni l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) target.
1. Rimuovi le tracce di sottotitoli dalla collezione [CaptionsCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/).
1. Salva la presentazione modificata.

Il seguente codice mostra come rimuovere tutti i sottotitoli da un frame video:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // tipo: com.aspose.slides.VideoFrame

    // Rimuove tutti i sottotitoli dal frame video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/#removeAt) invece di [clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/#clear).

## **Estrai video da diapositiva**

Oltre ad aggiungere video alle diapositivi, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) per caricare la presentazione che contiene il video.
2. Itera attraverso tutti gli oggetti [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/).
3. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/).
4. Salva il video su disco.

Questo codice JavaScript mostra come estrarre il video da una diapositiva di presentazione:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Ottiene l'estensione del file
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un VideoFrame?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/setplayloopmode/). queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi la dimensione della presentazione cresce proporzionalmente alla dimensione del file. Quando aggiungi un video online, vengono incorporati un link e una miniatura, quindi l'aumento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza modificare la sua posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) all'interno del frame mantenendo intatta la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/video/getcontenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.