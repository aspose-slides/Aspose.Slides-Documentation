---
title: Gestisci i frame video nelle presentazioni su Android
linktitle: Frame video
type: docs
weight: 10
url: /it/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i frame video in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Android via Java. Guida rapida passo‑passo."
---
## **Introduzione**

Un video posizionato in modo appropriato in una presentazione può rendere il tuo messaggio più persuasivo e aumentare il livello di coinvolgimento del pubblico.

PowerPoint ti consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungi o incorpora un video locale (memorizzato sul tuo computer)
* Aggiungi un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce l’interfaccia [IVideo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideo/), l’interfaccia [IVideoFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/) e altri tipi pertinenti.

## **Crea un frame video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un frame video per incorporare il video nella presentazione.

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation)class.
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideo/) e passa il percorso del file video per incorporare il video nella presentazione.
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/) per creare un frame per il video.
1. Salva la presentazione modificata.

Questo codice Java mostra come aggiungere un video memorizzato localmente a una presentazione:

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Carica il video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Ottiene la prima diapositiva e aggiunge un videoframe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Salva la presentazione su disco
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

In alternativa, puoi aggiungere un video passando direttamente il suo percorso file al metodo [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Crea un frame video con video da una fonte web**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporta i video di YouTube nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad es. su YouTube), puoi aggiungerlo alla presentazione tramite il suo collegamento web.

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation)class
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideo/) e passa il collegamento al video.
1. Imposta una miniatura per il frame video.
1. Salva la presentazione.

Questo codice Java mostra come aggiungere un video dal web a una diapositiva in una presentazione PowerPoint:

```java
// Instanzia un oggetto Presentation che rappresenta un file di presentazione 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Aggiunge un videoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Carica la miniatura
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Gestisci i sottotitoli video**

Aspose.Slides ti consente di gestire i sottotitoli chiusi per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono esposti tramite il metodo [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Aggiungi i sottotitoli a un frame video**

Per aggiungere i sottotitoli a un frame video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/)class.
1. Aggiungi un video alla presentazione.
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/) a una diapositiva.
1. Usa la [ICaptionsCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/) restituita da [getCaptionTracks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) per aggiungere una traccia di sottotitoli WebVTT.
1. Salva la presentazione modificata.

Il codice seguente mostra come aggiungere i sottotitoli a un frame video:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Aggiunge una nuova traccia di sottotitoli da un file WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/) fornisce anche una sovraccarico che consente di aggiungere i sottotitoli da uno stream.

**Estrai i sottotitoli da un frame video**

Per estrarre i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Individua l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/) di destinazione.
1. Itera tra le tracce di sottotitoli restituite da [getCaptionTracks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Salva ciascuna traccia di sottotitoli in un file `.vtt`.

Il codice seguente mostra come estrarre i sottotitoli da un frame video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Salva la traccia di sottotitoli in un file WebVTT.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e i dati del sottotitolo come stringa UTF‑8.

**Rimuovi i sottotitoli da un frame video**

Per rimuovere i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Ottieni l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/) di destinazione.
1. Rimuovi le tracce di sottotitoli dalla collezione restituita da [getCaptionTracks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Salva la presentazione modificata.

Il codice seguente mostra come rimuovere tutti i sottotitoli da un frame video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Rimuove tutti i sottotitoli dal frame video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se devi rimuovere solo una traccia di sottotitoli, utilizza i metodi [remove](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) invece di [clear](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Estrai video da una diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation)per caricare la presentazione contenente il video.
2. Itera tra tutti gli oggetti [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/).
3. Itera tra tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/videoframe/).
4. Salva il video su disco.

Questo codice Java mostra come estrarre il video da una diapositiva di una presentazione:

```java
// Istanzia un oggetto Presentation che rappresenta un file di presentazione 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Ottiene l'estensione del file
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un VideoFrame?**

È possibile controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inseriti nel documento, quindi la dimensione della presentazione cresce in proporzione alla dimensione del file. Quando aggiungi un video online, vengono incorporati un collegamento e una miniatura, quindi l'incremento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza cambiare la sua posizione e dimensione?**

Sì. È possibile scambiare il [contenuto video](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) all'interno del frame mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato possiede un [tipo di contenuto](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/video/#getContentType--) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.