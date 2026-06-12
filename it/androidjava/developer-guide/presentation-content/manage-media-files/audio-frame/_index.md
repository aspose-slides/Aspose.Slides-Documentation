---
title: Gestire l'audio nelle presentazioni su Android
linktitle: Fotogramma audio
type: docs
weight: 10
url: /it/androidjava/audio-frame/
keywords:
- audio
- fotogramma audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- Android
- Java
- Aspose.Slides
description: "Crea e controlla i fotogrammi audio in Aspose.Slides per Android—esempi Java per incorporare, ritagliare, ripetere e configurare la riproduzione in presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come lavorare con i fotogrammi audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare la miniatura del fotogramma audio, configurare le opzioni di riproduzione come volume, ripetizione, nascondere, ritaglio e durata delle dissolvenze, ed estrarre l’audio utilizzato nelle transizioni della presentazione.

## **Crea fotogrammi audio**
Aspose.Slides per Android via Java consente di aggiungere file audio alle diapositive. I file audio sono incorporati nelle diapositive come fotogrammi audio.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
2. Ottenere il riferimento di una diapositiva tramite il suo indice.
3. Caricare lo stream del file audio che si desidera incorporare nella diapositiva.
4. Aggiungere il fotogramma audio incorporato (contenente il file audio) alla diapositiva.
5. Impostare [PlayMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioPlayModePreset) e `Volume` esposti dall'oggetto [IAudioFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAudioFrame).
6. Salvare la presentazione modificata.

Questo codice Java mostra come aggiungere un fotogramma audio incorporato a una diapositiva:

```java
// Instanzia una classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation();
try {
    // Ottiene la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Carica il file audio wav nello stream
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Aggiunge il fotogramma audio
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

## **Modifica la miniatura del fotogramma audio**

Quando si aggiunge un file audio a una presentazione, l’audio appare come un fotogramma con un'immagine predefinita standard (vedi l’immagine nella sezione seguente). È possibile modificare l’immagine di anteprima del fotogramma audio (impostare l’immagine preferita).

Questo codice Java mostra come modificare la miniatura o l’immagine di anteprima di un fotogramma audio:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Aggiunge un fotogramma audio alla diapositiva con una posizione e dimensione specificate.
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

    // Imposta l'immagine per il fotogramma audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

//Salva la presentazione modificata su disco
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Modifica le opzioni di riproduzione audio**

Aspose.Slides per Android via Java consente di modificare le opzioni che controllano la riproduzione o le proprietà di un audio. Ad esempio, è possibile regolare il volume di un audio, impostare la riproduzione in loop o persino nascondere l’icona audio.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Opzioni audio** di PowerPoint corrispondenti alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioFrame) :

- L’elenco a discesa **Start** corrisponde alla proprietà [AudioFrame.PlayMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) .
- Il **Volume** corrisponde alla proprietà [AudioFrame.Volume](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioFrame#getVolume--) .
- L’opzione **Play Across Slides** corrisponde alla proprietà [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) .
- **Loop until Stopped** corrisponde alla proprietà [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) .
- **Hide During Show** corrisponde alla proprietà [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) .
- **Rewind after Playing** corrisponde alla proprietà [AudioFrame.RewindAudio](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) .

Le opzioni **Modifica** di PowerPoint che corrispondono alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/audioframe/) :

- **Fade In** corrisponde alla proprietà [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) .
- **Fade Out** corrisponde alla proprietà [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) .
- **Trim Audio Start Time** corrisponde alla proprietà [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) .
- **Trim Audio End Time** valore è uguale alla durata dell’audio meno il valore della proprietà [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) .

Il **controllo Volume** di PowerPoint nel pannello di controllo audio corrisponde alla proprietà [AudioFrame.VolumeValue](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . Consente di modificare il volume dell’audio in percentuale.

Ecco come modificare le opzioni di riproduzione audio:

1. [Crea](#create-audio-frame) o ottieni il Fotogramma audio.
2. Imposta nuovi valori per le proprietà del Fotogramma audio che desideri modificare.
3. Salva il file PowerPoint modificato.

Questo codice Java dimostra un'operazione in cui le opzioni di un audio vengono regolate:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Ottiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Imposta la modalità di riproduzione su clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Imposta il volume su Basso
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Imposta l'audio per riprodursi su più diapositive
    audioFrame.setPlayAcrossSlides(true);

    // Disabilita il loop per l'audio
    audioFrame.setPlayLoopMode(false);

    // Nasconde il fotogramma audio durante la presentazione
    audioFrame.setHideAtShowing(true);

    // Riavvolge l'audio all'inizio dopo la riproduzione
    audioFrame.setRewindAudio(true);

    // Salva il file PowerPoint su disco
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Questo esempio Java mostra come aggiungere un nuovo fotogramma audio con audio incorporato, ritagliarlo e impostare le durate delle dissolvenze:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Imposta l'offset iniziale del ritaglio a 1,5 secondi
    audioFrame.setTrimFromStart(1500f);
    // Imposta l'offset finale del ritaglio a 2 secondi
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

Il seguente esempio di codice mostra come recuperare un fotogramma audio con audio incorporato e impostarne il volume all'85%:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Ottiene la forma di un fotogramma audio
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Imposta il volume audio all'85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gestisci i sottotitoli audio**

Aspose.Slides consente di aggiungere sottotitoli chiusi a un fotogramma audio tramite il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) . Questo metodo restituisce una [ICaptionsCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/) , che permette di aggiungere tracce di sottotitoli WebVTT, iterare le tracce esistenti e rimuoverle quando necessario.

**Aggiungi sottotitoli audio**

Utilizza il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) per collegare una o più tracce di sottotitoli a un fotogramma audio. Nell'esempio seguente, un file audio viene aggiunto a una diapositiva, quindi viene caricata una nuova traccia di sottotitoli da un file `.vtt` .

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Aggiungi una nuova traccia di sottotitoli da un file WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Estrai i sottotitoli audio**

È possibile iterare le tracce di sottotitoli associate a un fotogramma audio e salvarle come file `.vtt`. Ogni traccia di sottotitoli espone i dati binari e l'identificatore unico, utili durante l'esportazione dei sottotitoli.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Salva la traccia di sottotitoli come file .vtt.
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**Rimuovi i sottotitoli audio**

Per rimuovere i sottotitoli da un fotogramma audio, utilizza i metodi forniti da [ICaptionsCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/) , come [clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/#clear--) , [remove](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) . L'esempio seguente rimuove tutte le tracce di sottotitoli da un fotogramma audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Rimuovi tutte le tracce di sottotitoli dal fotogramma audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Estrai audio**

Aspose.Slides per Android via Java consente di estrarre il suono utilizzato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono utilizzato in una diapositiva specifica.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) e caricare la presentazione contenente l’audio.
2. Ottenere il riferimento della diapositiva pertinente tramite il suo indice.
3. Accedere alle [slideshow transitions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) della diapositiva.
4. Estrarre il suono come dati byte.

Questo codice Java mostra come estrarre l’audio usato in una diapositiva:

```java
// Crea un'istanza della classe Presentation che rappresenta un file di presentazione
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

Sì. Aggiungi l’audio una sola volta alla [audio collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getAudios--) condivisa della presentazione e crea fotogrammi audio aggiuntivi che fanno riferimento a quell’asset esistente. Questo evita la duplicazione dei dati multimediali e mantiene le dimensioni della presentazione sotto controllo.

**Posso sostituire il suono in un fotogramma audio esistente senza ricreare la forma?**

Sì. Per un suono collegato, aggiorna il [link path](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) per puntare al nuovo file. Per un suono incorporato, sostituisci l’oggetto [embedded audio](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) con un altro presente nella [audio collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getAudios--) della presentazione. La formattazione del fotogramma e la maggior parte delle impostazioni di riproduzione rimangono invariate.

**Il ritaglio modifica i dati audio sottostanti memorizzati nella presentazione?**

No. Il ritaglio regola solo i limiti di riproduzione. I byte originali dell’audio rimangono intatti e accessibili tramite l’audio incorporato o la [audio collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getAudios--) della presentazione.