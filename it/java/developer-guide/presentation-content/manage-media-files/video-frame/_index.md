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
description: "Impara ad aggiungere ed estrarre programmaticamente i fotogrammi video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per Java. Guida rapida passo-passo."
---
## **Introduzione**

Un video ben posizionato in una presentazione può rendere il tuo messaggio più efficace e aumentare i livelli di coinvolgimento del tuo pubblico. 

PowerPoint ti consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungere o incorporare un video locale (memorizzato sul tuo computer)
* Aggiungere un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce l'interfaccia [IVideo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideo/) , l'interfaccia [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideoframe/) e altri tipi pertinenti. 

## **Crea fotogrammi video incorporati**

Se il file video che desideri aggiungere alla tua diapositiva è memorizzato localmente, puoi creare un fotogramma video per incorporare il video nella tua presentazione. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) class.
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideo/) e passa il percorso del file video per incorporare il video nella presentazione. 
4. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideoframe/) per creare un fotogramma per il video.  
5. Salva la presentazione modificata. 

Questo codice Java mostra come aggiungere un video memorizzato localmente a una presentazione:

```java
// Istanzia la classe Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Carica il video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Ottiene la prima diapositiva e aggiunge un fotogramma video
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Salva la presentazione su disco
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

In alternativa, puoi aggiungere un video passando direttamente il suo percorso file al metodo [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Crea fotogrammi video con video da fonti web**

Microsoft [PowerPoint 2013 e versioni successive](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporta i video di YouTube nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad esempio su YouTube), puoi aggiungerlo alla tua presentazione tramite il suo link web. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) class
2. Ottieni il riferimento di una diapositiva tramite il suo indice. 
3. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideo/) e passa il collegamento al video.
4. Imposta una miniatura per il fotogramma video. 
5. Salva la presentazione. 

Questo codice Java mostra come aggiungere un video dal web a una diapositiva in una presentazione PowerPoint:

```java
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
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
    // Aggiunge un fotogramma video
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

Aspose.Slides ti consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono accessibili tramite il metodo [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Aggiungi sottotitoli a un fotogramma video**

Per aggiungere sottotitoli a un fotogramma video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) .
2. Aggiungi un video alla presentazione.
3. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideoframe/) a una diapositiva.
4. Usa la [ICaptionsCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/) restituita da [getCaptionTracks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) per aggiungere una traccia di sottotitoli WebVTT.
5. Salva la presentazione modificata.

Il codice seguente mostra come aggiungere sottotitoli a un fotogramma video:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
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

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/) fornisce anche un overload che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un fotogramma video**

Per estrarre i sottotitoli da un fotogramma video:

1. Carica la presentazione che contiene il video.
2. Trova l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideoframe/) di destinazione.
3. Itera le tracce di sottotitoli nella [ICaptionsCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/) .
4. Salva ogni traccia di sottotitoli in un file `.vtt`.

Il codice seguente mostra come estrarre i sottotitoli da un fotogramma video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Salva la traccia di sottotitoli in un file WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i sottotitoli da un fotogramma video**

Per rimuovere i sottotitoli da un fotogramma video:

1. Carica la presentazione che contiene il video.
2. Ottieni l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ivideoframe/) di destinazione.
3. Rimuovi le tracce di sottotitoli dalla [ICaptionsCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/) .
4. Salva la presentazione modificata.

Il codice seguente mostra come rimuovere tutti i sottotitoli da un fotogramma video:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Rimuove tutti i sottotitoli dal fotogramma video.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) o [removeAt](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/#removeAt-int-) invece di [clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Estrai video dalle diapositive**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) per caricare la presentazione contenente il video. 
2. Itera tutti gli oggetti [ISlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/) .
3. Itera tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/videoframe/) . 
4. Salva il video su disco.

Questo codice Java mostra come estrarre il video da una diapositiva di una presentazione:

```java
// Instanzia un oggetto Presentation che rappresenta un file di presentazione 
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

                // Ottiene l'estensione del file
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

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto o al clic) e il [looping](https://reference.aspose.com/slides/it/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/videoframe/) .

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari sono inclusi nel documento, quindi la dimensione della presentazione aumenta proporzionalmente alla dimensione del file. Quando aggiungi un video online, vengono incorporati un collegamento e una miniatura, quindi l'aumento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza modificare la sua posizione e dimensione?**

Sì. Puoi sostituire il [contenuto video](https://reference.aspose.com/slides/it/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) all'interno del fotogramma mantenendo la geometria della forma; è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/it/java/com.aspose.slides/video/#getContentType--) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.