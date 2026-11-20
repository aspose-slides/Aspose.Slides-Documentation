---
title: Gestire i frame audio nelle presentazioni usando Java
linktitle: Frame audio
type: docs
weight: 10
url: /it/java/audio-frame/
keywords:
- audio
- frame audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- Java
- Aspose.Slides
description: "Incorpora audio nelle diapositive, cambia l'icona audio, configura la riproduzione, gestisci i sottotitoli WebVTT e estrai i suoni di transizione delle diapositive con Aspose.Slides per Java."
---
## **Panoramica**

Un frame audio consente di riprodurre un suono su una diapositiva. Con Aspose.Slides per Java, è possibile incorporare una clip audio, scegliere l'immagine che la rappresenta, regolare la riproduzione e allegare i sottotitoli. È inoltre possibile recuperare un suono assegnato a una transizione di diapositiva.

## **Crea frame audio**

Utilizza [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) per incorporare una clip audio locale nella prima diapositiva. Le prime due coordinate posizionano il frame sulla diapositiva, e i successivi due valori impostano la sua larghezza e altezza, tutti in punti. Questo esempio chiama [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) per avviare automaticamente la clip e chiama [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) per selezionare il preset di volume alto.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifica l'anteprima del frame audio**

Per impostazione predefinita, un frame audio visualizza un'icona dell'altoparlante. Per visualizzare un'anteprima personalizzata, aggiungi un'immagine alla presentazione con [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) e impostala sull'immagine del frame con [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). L'esempio utilizza un JPEG come anteprima per una clip audio incorporata.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifica le opzioni di riproduzione audio**

I controlli delle **Opzioni audio** di PowerPoint determinano quando inizia una clip, quanto è forte e come si comporta durante una presentazione.

![Controlli delle Opzioni audio di PowerPoint per un frame audio](audio_frame_0.png)

| Controllo PowerPoint | Metodo Aspose.Slides per Java |
| --- | --- |
| Avvia | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Preset volume | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Riproduci su più diapositive | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Riproduci in loop fino all'arresto | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Nascondi durante la presentazione | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Riavvolgi dopo la riproduzione | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Dissolvenza in ingresso | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Dissolvenza in uscita | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Taglia inizio audio | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Taglia fine audio | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Cursore volume | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

L'esempio trova il primo frame audio nella prima diapositiva, chiama [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) per avviare la riproduzione con un clic e seleziona il preset di volume basso. La clip continua su più diapositive con il loop disattivato. L'icona rimane nascosta durante la presentazione e la clip si riavvolge dopo la riproduzione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Per una clip più lunga di 3,5 secondi, questo esempio salta i primi 1,5 secondi e gli ultimi 2 secondi. [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) prende la durata da omettere dalla fine della clip. Per ottenere il tempo finale visualizzato in PowerPoint, sottrai tale offset dalla durata totale della clip. La clip tagliata sfuma in ingresso per 200 millisecondi e sfuma in uscita per 500 millisecondi. Tutti e quattro i metodi accettano valori in millisecondi.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per impostare il volume di riproduzione a una percentuale specifica, utilizza [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Questo esempio imposta il primo frame audio nella prima diapositiva all'85%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Gestisci i sottotitoli audio**

Ogni frame audio fornisce l'accesso alle sue tracce di sottotitoli tramite [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Usa la collezione per allegare sottotitoli WebVTT alla clip, esportare le tracce esistenti o rimuoverle.

### **Aggiungi sottotitoli audio**

L'esempio incorpora una clip audio nella prima diapositiva e utilizza [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) per allegare una traccia WebVTT locale. Il primo argomento fornisce l'etichetta della traccia, e il secondo identifica il file contenente i sottotitoli temporizzati.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Estrai i sottotitoli audio**

Questo esempio esporta ogni traccia di sottotitoli allegata a un frame audio nella prima diapositiva. Scrive i byte restituiti da [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) in un file WebVTT e utilizza l'identificatore restituito da [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) come nome del file in modo che ogni traccia abbia un output separato.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```

### **Rimuovi i sottotitoli audio**

Utilizza [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) per eliminare una traccia singola. L'esempio usa [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) per rimuovere tutti i sottotitoli dal primo frame audio nella prima diapositiva conservando la clip.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Trova una riga nei sottotitoli audio**

Per trovare una riga nei sottotitoli audio sulla prima diapositiva, cerca il testo restituito da [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) in memoria. In un cue WebVTT in testo semplice, la riga di temporizzazione contiene `-->`, le righe dei sottotitoli la seguono, e una riga vuota termina il cue. Questo esempio stampa l'etichetta della traccia e ogni riga di sottotitolo contenente “café”.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\R")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Estrai audio**

Una transizione di diapositiva può avere un proprio suono. Per recuperarlo, chiama [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) sulla transizione della diapositiva. L'esempio accede ai byte restituiti da [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) e stampa il numero di byte. Se la prima diapositiva non ha suono di transizione, stampa un messaggio.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Posso riutilizzare la stessa clip audio su più diapositive senza duplicarla?**

Sì. Aggiungi la clip una sola volta alla [collezione audio](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) della presentazione e passa lo stesso oggetto audio a [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) per ogni diapositiva.

**Posso sostituire il suono in un frame audio esistente?**

Sì. Per un suono collegato, usa [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) per puntare al file di sostituzione. Per un suono incorporato, seleziona un'altra clip dalla collezione audio della presentazione con [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Entrambi gli approcci preservano il frame esistente.

**Il ritaglio modifica i dati audio memorizzati nella presentazione?**

No. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) e [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) impostano i limiti di riproduzione. È ancora possibile recuperare la clip completa da [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).