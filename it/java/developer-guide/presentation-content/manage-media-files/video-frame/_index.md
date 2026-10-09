---
title: Gestisci i fotogrammi video nelle presentazioni usando Java
linktitle: Fotogramma video
type: docs
weight: 10
url: /it/java/video-frame/
keywords:
- aggiungi video
- crea video
- incorpora video
- estrai video
- recupera video
- fotogramma video
- fonte web
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Impara a aggiungere ed estrarre programmaticamente fotogrammi video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per Java. Guida rapida passo-passo."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides for Java consente di aggiungere fotogrammi video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e i fotogrammi video, Aspose.Slides fornisce l'[interfaccia IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , l'[interfaccia IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) e altri tipi pertinenti.

## **Crea un fotogramma video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un fotogramma video per incorporare il video nella tua presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni del fotogramma sono espresse in punti. Lo stream rimane aperto fino al completamento del salvataggio perché [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) lo mantiene bloccato mentre la presentazione lo utilizza.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Puoi anche fornire direttamente un percorso video locale a [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve rimanere accessibile fino al salvataggio della presentazione.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Crea un fotogramma video con video da una fonte Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. Puoi creare un fotogramma video che si collega a un video online, ad esempio un video di YouTube.

Questo esempio aggiunge un collegamento a un video di YouTube e una miniatura alla prima diapositiva. Sostituisci l'identificatore del video per utilizzare un altro video. Il metodo [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) richiede la riproduzione automatica. Il download della miniatura e la riproduzione del video richiedono accesso a Internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione video online.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Riproduci un video in modalità a schermo intero**

In una presentazione formativa, puoi riprodurre una dimostrazione software in modalità a schermo intero affinché il pubblico possa vedere i dettagli. Chiama [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) con `true` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La riproduzione a schermo intero controlla come il video viene visualizzato. In modo indipendente, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controlla se il video parte automaticamente o al clic, e [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset.Auto o VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). L'esempio preserva le impostazioni di avvio e di ciclo esistenti.

## **Riavvolgi un video dopo la riproduzione**

In una presentazione formativa, riportare un video dimostrativo all'inizio lo rende pronto per essere riprodotto nuovamente dal presentatore. Chiama [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) con `true` per riportare il video all'inizio dopo il termine della riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) nella prima diapositiva e abilita il riavvolgimento. Disabilita il ciclo in modo che la riproduzione possa terminare e imposta la riproduzione per avviarsi al clic. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il riavvolgimento riporta il video all'inizio senza avviarlo nuovamente. Al contrario, chiamare [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) con `true` ripete la riproduzione automaticamente. Mantieni il ciclo disabilitato quando vuoi che il video termini e resti pronto per una nuova riproduzione. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controlla in modo indipendente l'avvio automatico o al clic; questo esempio utilizza [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) così il presentatore controlla quando la riproduzione inizia. Imposta la modalità di riproduzione dopo l'impostazione del ciclo, come mostrato nell'esempio. Il riavvolgimento funziona indipendentemente da [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Ritaglia un fotogramma video**

Utilizza [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) e [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) per saltare una parte dell'inizio o della fine di un video durante la riproduzione. Entrambi i valori sono espressi in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta le impostazioni di ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l'ultimo secondo durante la riproduzione. Usa un video più lungo di 3,5 secondi in modo che rimanga un segmento riproducibile.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Leggi le impostazioni di ritaglio**

Questo esempio stampa i valori di ritaglio del primo fotogramma video nella prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha un fotogramma video, non viene stampato nulla. L'esempio precedente produce valori di 2500 e 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono accessibili tramite il metodo [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Aggiungi sottotitoli a un fotogramma video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT etichettata English. I timestamp dei sottotitoli devono corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) fornisce anche una sovraccarico che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un fotogramma video**

Questo esempio salva tutte le tracce di sottotitoli dai fotogrammi video nella prima diapositiva come file WebVTT separati. I numeri sequenziali mantengono distinti i file di output. La console segnala il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i sottotitoli da un fotogramma video**

Questo esempio rimuove tutti i sottotitoli dal fotogramma video nella prima posizione della forma nella prima diapositiva e salva il risultato. Presume che la diapositiva e la forma esistano e che la forma sia un fotogramma video.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) invece di [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

## **Estrai video da una diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari separati e numerati. I video collegati vengono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ciascun video e il conteggio totale. L'output utilizza l'estensione generica `.bin`; modificala per corrispondere al tipo di media segnalato se necessario.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un fotogramma video?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatica o al clic) e il [ciclo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). queste opzioni sono disponibili tramite i metodi dell'oggetto [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari sono inclusi nel documento, quindi la dimensione della presentazione cresce in proporzione alla dimensione del file. Quando colleghi un video online e aggiungi una miniatura, la presentazione memorizza il collegamento e l'immagine di anteprima invece dei dati video, quindi l'aumento di dimensione è solitamente minore.

**Posso sostituire il video in un fotogramma video esistente senza modificare la sua posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) all'interno del fotogramma mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.