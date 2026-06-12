---
title: Gestire l'audio nelle presentazioni usando Java
linktitle: Frame audio
type: docs
weight: 10
url: /it/java/audio-frame/
keywords:
- audio
- frame audio
- miniatura
- aggiungere audio
- proprietà audio
- opzioni audio
- estrarre audio
- Java
- Aspose.Slides
description: "Crea e controlla i frame audio in Aspose.Slides per Java - esempi di codice per incorporare, ritagliare, riprodurre in loop e configurare la riproduzione in presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come lavorare con i frame audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare la miniatura del frame audio, configurare le opzioni di riproduzione come volume, loop, nascondere, ritaglio e durate di dissolvenza, ed estrarre l’audio usato nelle transizioni della presentazione.

## **Creare frame audio**

Aspose.Slides per Java consente di aggiungere file audio alle diapositive. I file audio vengono incorporati nelle diapositive come frame audio. 

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Caricare lo stream del file audio da incorporare nella diapositiva.
4. Aggiungere il frame audio incorporato (contenente il file audio) alla diapositiva.
5. Impostare [PlayMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/AudioPlayModePreset) e `Volume` esposti dall’oggetto [IAudioFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAudioFrame).
6. Salvare la presentazione modificata.

Questo codice Java mostra come aggiungere un frame audio incorporato a una diapositiva:

```java
// Istanzia una classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carica il file audio wav in uno stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Aggiunge il Frame Audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Imposta la modalità di riproduzione e il volume dell'audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Scrive il file PowerPoint su disco
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificare la miniatura del frame audio**

Quando si aggiunge un file audio a una presentazione, l’audio appare come un frame con un’immagine predefinita standard (vedi l’immagine nella sezione sottostante). È possibile cambiare l’immagine di anteprima del frame audio (impostare l’immagine preferita).

Questo codice Java mostra come modificare la miniatura o l’immagine di anteprima di un frame audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiunge un frame audio alla diapositiva con una posizione e dimensione specificate.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Aggiunge un'immagine alle risorse della presentazione.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Imposta l'immagine per il frame audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Salva la presentazione modificata su disco
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Modificare le opzioni di riproduzione audio**

Aspose.Slides per Java consente di modificare le opzioni che controllano la riproduzione o le proprietà di un audio. Ad esempio, è possibile regolare il volume, impostare la riproduzione in loop o nascondere l’icona audio.

Il riquadro **Audio Options** in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Audio Options** di PowerPoint corrispondenti alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/AudioFrame):

- **Start** elenca corrispondente al metodo [AudioFrame.setPlayMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** corrispondente al metodo [AudioFrame.setVolume](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** corrispondente al metodo [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** corrispondente al metodo [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** corrispondente al metodo [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** corrispondente al metodo [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

Le opzioni di **Editing** di PowerPoint corrispondenti alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/AudioFrame):

- **Fade In** corrispondente al metodo [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** corrispondente al metodo [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** corrispondente al metodo [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time** il valore è pari alla durata dell’audio meno il valore del metodo [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Il controllo **Volume** di PowerPoint sul pannello di controllo audio corrisponde al metodo [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/it/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Consente di modificare il volume audio in percentuale.

Ecco come modificare le opzioni di riproduzione audio:

1. [Create](#create-audio-frame) o ottenere il Frame Audio.
2. Impostare nuovi valori per le proprietà del Frame Audio che si desidera modificare.
3. Salvare il file PowerPoint modificato.

Questo codice Java dimostra un’operazione in cui le opzioni di un audio sono regolate:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Ottiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Imposta la modalità di riproduzione su clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Imposta il volume su Basso
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Imposta l'audio per essere riprodotto su tutte le diapositive
    audioFrame.setPlayAcrossSlides(true);

    // Disabilita il loop per l'audio
    audioFrame.setPlayLoopMode(false);

    // Nasconde il AudioFrame durante la presentazione
    audioFrame.setHideAtShowing(true);

    // Riavvolge l'audio all'inizio dopo la riproduzione
    audioFrame.setRewindAudio(true);

    // Salva il file PowerPoint su disco
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Questo esempio Java mostra come aggiungere un nuovo frame audio con audio incorporato, ritagliarlo e impostare le durate di dissolvenza:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Imposta l'offset di inizio del ritaglio a 1,5 secondi
    audioFrame.setTrimFromStart(1500f);
    // Imposta l'offset di fine del ritaglio a 2 secondi
    audioFrame.setTrimFromEnd(2000f);

    // Imposta la durata della dissolvenza in ingresso a 200 ms
    audioFrame.setFadeInDuration(200f);
    // Imposta la durata della dissolvenza in uscita a 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Il seguente esempio di codice mostra come recuperare un frame audio con audio incorporato e impostarne il volume all’85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Ottiene una forma di frame audio
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Imposta il volume audio all'85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gestire le didascalie audio**

Aspose.Slides consente di aggiungere didascalie chiuse a un frame audio tramite il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Questo metodo restituisce un’interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/), che permette di aggiungere tracce didascalia WebVTT, iterare quelle esistenti e rimuoverle quando necessario.

**Aggiungere didascalie audio**

Utilizzare il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) per associarne una o più a un frame audio. Nell’esempio seguente, un file audio viene aggiunto a una diapositiva, quindi viene caricata una nuova traccia didascalia da un file `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Aggiungi una nuova traccia didascalia da un file WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Estrarre le didascalie audio**

È possibile iterare le tracce didascalia associate a un frame audio e salvarle come file `.vtt`. Ogni traccia espone i dati binari e l’identificatore univoco, utilizzabili durante l’esportazione delle didascalie.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Salva la traccia di didascalia come file .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Rimuovere le didascalie audio**

Per rimuovere le didascalie da un frame audio, usare i metodi forniti da [ICaptionsCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/), come [clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), o [removeAt](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/#removeAt-int-). L’esempio seguente rimuove tutte le tracce didascalia da un frame audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Rimuove tutte le tracce di didascalia dal frame audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Estrarre audio**

Aspose.Slides per Java consente di estrarre il suono usato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono utilizzato in una diapositiva specifica.

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) e caricare la presentazione contenente l’audio.
2. Ottenere il riferimento alla diapositiva pertinente tramite il suo indice.
3. Accedere alle [slideshow transitions](https://reference.aspose.com/slides/it/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) della diapositiva.
4. Estrarre il suono in dati byte.

Questo codice Java mostra come estrarre l’audio usato in una diapositiva:

```java
// Istanzia una classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accede alla diapositiva desiderata
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ottiene gli effetti di transizione della presentazione per la diapositiva
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Estrae il suono in un array di byte
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso riutilizzare lo stesso asset audio in più diapositive senza aumentare la dimensione del file?**

Sì. Aggiungi l’audio una sola volta alla [audio collection](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getAudios--) condivisa della presentazione e crea frame audio aggiuntivi che fanno riferimento a quell’asset esistente. Questo evita la duplicazione dei dati multimediali e mantiene sotto controllo le dimensioni della presentazione.

**Posso sostituire il suono in un frame audio esistente senza ricreare la forma?**

Sì. Per un suono collegato, aggiorna il [link path](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) per puntare al nuovo file. Per un suono incorporato, sostituisci l’[embedded audio](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) con un altro presente nella [audio collection](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getAudios--) della presentazione. La formattazione del frame e la maggior parte delle impostazioni di riproduzione rimangono intatte.

**Il ritaglio modifica i dati audio sottostanti memorizzati nella presentazione?**

No. Il ritaglio regola solo i confini di riproduzione. I byte originali dell’audio rimangono invariati e accessibili tramite l’audio incorporato o la audio collection della presentazione.