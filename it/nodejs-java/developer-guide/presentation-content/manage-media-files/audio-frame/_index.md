---
title: Gestisci l'audio nelle presentazioni usando JavaScript
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
description: "Crea e controlla i frame audio in Aspose.Slides per Node.js—esempi per incorporare, ritagliare, ripetere e configurare la riproduzione in presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come lavorare con i frame audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare la miniatura del frame audio, configurare le opzioni di riproduzione come volume, ripetizione, nascondere, ritaglio e durata della dissolvenza, ed estrarre l’audio usato nelle transizioni della presentazione.

## **Crea Frame Audio**

Aspose.Slides for Node.js via Java consente di aggiungere file audio alle diapositive. I file audio sono incorporati nelle diapositive come frame audio.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Carica lo stream del file audio che desideri incorporare nella diapositiva.
4. Aggiungi il frame audio incorporato (contenente il file audio) alla diapositiva.
5. Imposta [PlayMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AudioPlayModePreset) e `Volume` esposti dall’oggetto [AudioFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AudioFrame).
6. Salva la presentazione modificata.

Questo codice JavaScript mostra come aggiungere un frame audio incorporato a una diapositiva:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione
const pres = new aspose.slides.Presentation();
try {
    // Ottiene la prima diapositiva
    const sld = pres.getSlides().get_Item(0);
    // Carica il file audio wav in uno stream
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Aggiunge il Frame Audio
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Imposta la modalità di riproduzione e il volume dell'audio
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Scrive il file PowerPoint su disco
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifica Miniatura del Frame Audio**

Quando aggiungi un file audio a una presentazione, l’audio appare come un frame con un’immagine predefinita standard (vedi l’immagine nella sezione sottostante). Puoi cambiare l’immagine di anteprima del frame audio (imposta la tua immagine preferita).

Questo codice JavaScript mostra come cambiare la miniatura o l’immagine di anteprima di un frame audio:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Aggiunge un frame audio alla diapositiva con posizione e dimensione specificate.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Aggiunge un'immagine alle risorse della presentazione.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Imposta l'immagine per il frame audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Salva la presentazione modificata su disco
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Modifica Opzioni di Riproduzione Audio**

Aspose.Slides for Node.js via Java consente di modificare le opzioni che controllano la riproduzione o le proprietà di un audio. Ad esempio, è possibile regolare il volume, impostare la riproduzione in loop o anche nascondere l’icona audio.

Il riquadro **Opzioni audio** in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Opzioni audio** di PowerPoint che corrispondono alle proprietà [AudioFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/) di Aspose.Slides:
- **Start** elenco a discesa corrisponde al metodo [AudioFrame.setPlayMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** corrisponde al metodo [AudioFrame.setVolume](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** corrisponde al metodo [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** corrisponde al metodo [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** corrisponde al metodo [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** corrisponde al metodo [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Le opzioni **Modifica** di PowerPoint che corrispondono alle proprietà [AudioFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/) di Aspose.Slides:
- **Fade In** corrisponde al metodo [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** corrisponde al metodo [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** corrisponde al metodo [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** il valore è uguale alla durata audio meno il valore del metodo [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Il **controllo del volume** di PowerPoint sul pannello di controllo audio corrisponde al metodo [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Consente di modificare il volume audio in percentuale.

Ecco come modificare le Opzioni di Riproduzione Audio:

1. [Crea](#create-audio-frame) o ottieni il Frame Audio.
2. Imposta nuovi valori per le proprietà del Frame Audio che desideri modificare.
3. Salva il file PowerPoint modificato.

Questo codice JavaScript dimostra un’operazione in cui le opzioni di un audio vengono regolate:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Ottiene la forma AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Imposta la modalità di riproduzione su 'al clic'
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Imposta il volume su Basso
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Imposta l'audio per la riproduzione su più diapositive
    audioFrame.setPlayAcrossSlides(true);
    // Disabilita il loop per l'audio
    audioFrame.setPlayLoopMode(false);
    // Nasconde il frame audio durante la presentazione
    audioFrame.setHideAtShowing(true);
    // Riavvolge l'audio all'inizio dopo la riproduzione
    audioFrame.setRewindAudio(true);
    // Salva il file PowerPoint su disco
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Questo esempio JavaScript mostra come aggiungere un nuovo frame audio con audio incorporato, ritagliarlo e impostare le durate della dissolvenza:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Imposta l'offset di inizio del trimming a 1,5 secondi
    // Imposta l'offset di fine del trimming a 2 secondi
    // Imposta la durata del fade-in a 200 ms
    // Imposta la durata del fade-out a 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Il seguente esempio di codice mostra come recuperare un frame audio con audio incorporato e impostarne il volume all’85%:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Ottiene una forma di frame audio
    const audioFrame = slide.getShapes().get_Item(0);

    // Imposta il volume dell'audio all'85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gestisci Didascalie Audio**

Aspose.Slides consente di aggiungere didascalie chiuse a un frame audio tramite il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Questo metodo restituisce un oggetto [CaptionsCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/), che permette di aggiungere tracce didascalia WebVTT, scorrere le tracce esistenti e rimuoverle quando necessario.

### **Aggiungi Didascalie Audio**

Usa il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) per associare una o più tracce di didascalia a un frame audio. Nell’esempio seguente, un file audio viene aggiunto a una diapositiva, quindi viene caricata una nuova traccia di didascalia da un file `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Aggiungi una nuova traccia di didascalia da un file WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Estrai Didascalie Audio**

Puoi scorrere le tracce di didascalia associate a un frame audio e salvarle come file `.vtt`. Ogni traccia di didascalia espone i suoi dati binari e l’identificatore unico, che può essere usato durante l’esportazione delle didascalie.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Salva la traccia di didascalia come file .vtt.
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

### **Rimuovi Didascalie Audio**

Per rimuovere le didascalie da un frame audio, utilizza i metodi forniti da [CaptionsCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/), come [clear](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/captionscollection/#removeAt). L’esempio seguente rimuove tutte le tracce di didascalia da un frame audio.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // tipo: aspose.slides.AudioFrame

    // Rimuovi tutte le tracce di didascalia dal frame audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Estrai Audio**

Aspose.Slides for Node.js via Java consente di estrarre il suono utilizzato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono utilizzato in una diapositiva specifica.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation) e carica la presentazione che contiene l’audio.
2. Ottieni il riferimento della diapositiva pertinente tramite il suo indice.
3. Accedi alle [slideshow transitions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) della diapositiva.
4. Estrai il suono in dati byte.

Questo codice JavaScript mostra come estrarre l’audio usato in una diapositiva:

```javascript
// Istanzia una classe Presentation che rappresenta un file di presentazione
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Accede alla diapositiva desiderata
    const slide = pres.getSlides().get_Item(0);
    // Ottiene gli effetti di transizione dello slideshow per la diapositiva
    const transition = slide.getSlideShowTransition();
    // Estrae il suono in un array di byte
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso riutilizzare lo stesso file audio in più diapositive senza aumentare la dimensione del file?**

Sì. Aggiungi l’audio una sola volta alla [audio collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getaudios/) condivisa della presentazione e crea frame audio aggiuntivi che facciano riferimento a quell’asset esistente. Questo evita la duplicazione dei dati multimediali e mantiene la dimensione della presentazione sotto controllo.

**Posso sostituire il suono in un frame audio esistente senza ricreare la forma?**

Sì. Per un suono collegato, aggiorna il [link path](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) per puntare al nuovo file. Per un suono incorporato, sostituisci l’oggetto [embedded audio](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) con un altro presente nella [audio collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getaudios/) della presentazione. La formattazione del frame e la maggior parte delle impostazioni di riproduzione rimangono inalterate.

**Il trim modifica i dati audio sottostanti memorizzati nella presentazione?**

No. Il trimming regola solo i limiti di riproduzione. I byte originali dell’audio rimangono intatti e accessibili tramite l’audio incorporato o la [audio collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getaudios/) della presentazione.