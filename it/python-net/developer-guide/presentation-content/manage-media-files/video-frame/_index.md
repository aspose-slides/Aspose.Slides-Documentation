---
title: Aggiungere video alle presentazioni in Python
linktitle: Frame Video
type: docs
weight: 10
url: /it/python-net/video-frame/
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
- Python
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i frame video in diapositive PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET. Guida rapida passo-passo."
---
## **Introduzione**

Un video ben posizionato in una presentazione può rendere il tuo messaggio più accattivante e aumentare il livello di coinvolgimento del pubblico. 

PowerPoint consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungere o incorporare un video locale (memorizzato sul tuo computer)
* Aggiungere un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/it/python-net/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) e altri tipi pertinenti. 

## **Crea frame video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un frame video per incorporare il video nella presentazione. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
1. Ottieni il riferimento a una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/python-net/aspose.slides/video/) e passa il percorso del file video per incorporare il video nella presentazione. 
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) per creare un frame per il video.  
1. Salva la presentazione modificata. 

Questo codice Python mostra come aggiungere un video memorizzato localmente a una presentazione:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Ottiene la prima diapositiva e aggiunge un videoframe
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Salva la presentazione su disco
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

In alternativa, puoi aggiungere un video passando direttamente il percorso del file al metodo `add_video_frame(x, y, width, height, fname)` :

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Crea frame video con video da sorgente web**

Le versioni più recenti di Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) supportano i video online nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad esempio su YouTube), puoi aggiungerlo alla tua presentazione tramite il suo collegamento web.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) 
1. Ottieni il riferimento a una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/python-net/aspose.slides/video/) e passa il collegamento al video.
1. Imposta una miniatura per il frame video. 
1. Salva la presentazione. 

Questo codice Python mostra come aggiungere un video dal web a una diapositiva in una presentazione PowerPoint:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Aggiunge un videoFrame
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Carica la miniatura
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ritaglia un frame video**

Aspose.Slides consente di controllare quale parte di un video viene riprodotta impostando i valori trim-from-start e trim-from-end tramite [VideoFrame.trim_from_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/trim_from_end/). Entrambi i valori sono specificati in millisecondi e definiscono quanto tempo viene saltato dall'inizio e dalla fine del video, rispettivamente. queste impostazioni modificano le impostazioni di riproduzione del video nella presentazione; non tagliano né modificano i dati binari del video incorporato.

**Imposta le impostazioni di ritaglio**

Per creare un frame video e impostarne le impostazioni di ritaglio:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/python-net/aspose.slides/video/) alla presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) a una diapositiva.
1. Imposta i valori trim-from-start e trim-from-end tramite [VideoFrame.trim_from_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/trim_from_end/) .
1. Salva la presentazione modificata.

Il seguente esempio di codice salta i primi 2,5 secondi e l'ultimo secondo di un video incorporato durante la riproduzione:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Leggi le impostazioni di ritaglio**

Per ispezionare le impostazioni di ritaglio esistenti, carica una presentazione, trova un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) tra le forme della prima diapositiva e leggi i valori tramite [VideoFrame.trim_from_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/trim_from_end/) .

Il seguente esempio di codice trova il primo frame video sulla prima diapositiva e riporta le sue impostazioni di ritaglio in millisecondi:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati in formato WebVTT e sono esposti tramite la proprietà [VideoFrame.caption_tracks](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/caption_tracks/) .

**Aggiungi sottotitoli a un frame video**

Per aggiungere sottotitoli a un frame video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
1. Aggiungi un video alla presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) a una diapositiva.
1. Usa la [CaptionsCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/) restituita da [caption_tracks](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/caption_tracks/) per aggiungere una traccia di sottotitoli WebVTT.
1. Salva la presentazione modificata.

Il seguente codice mostra come aggiungere sottotitoli a un frame video:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Aggiunge una nuova traccia di sottotitoli da un file WebVTT.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/) fornisce anche un overload che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un frame video**

Per estrarre i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Trova l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) target.
1. Itera attraverso la collezione [caption_tracks](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Salva ogni traccia di sottotitoli in un file `.vtt` .

Il seguente codice mostra come estrarre i sottotitoli da un frame video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Salva la traccia di sottotitoli in un file WebVTT.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/it/python-net/aspose.slides/captions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i sottotitoli da un frame video**

Per rimuovere i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Ottieni l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) target.
1. Rimuovi le tracce di sottotitoli dalla [CaptionsCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/) .
1. Salva la presentazione modificata.

Il seguente codice mostra come rimuovere tutti i sottotitoli da un frame video:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # type: slides.VideoFrame

    # Rimuove tutti i sottotitoli dal frame video.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Se devi rimuovere solo una traccia di sottotitoli, utilizza i metodi [remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/remove/) o [remove_at](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/remove_at/) invece di [clear](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/clear/) .

## **Estrai video da diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per caricare la presentazione contenente il video. 
2. Itera attraverso tutti gli oggetti [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/) .
3. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) . 
4. Salva il video su disco.

Questo codice Python mostra come estrarre il video da una diapositiva della presentazione:

```python
import aspose.slides as slides

# Istanzia un oggetto Presentation che rappresenta un file di presentazione 
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un VideoFrame?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/play_mode/) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/play_loop_mode/) . Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) .

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi la dimensione della presentazione cresce in proporzione alla dimensione del file. Quando aggiungi un video online, vengono incorporati un collegamento e una miniatura, quindi l'aumento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza cambiare posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/embedded_video/) all'interno del frame mantenendo la geometria della forma; è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/it/python-net/aspose.slides/video/content_type/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.