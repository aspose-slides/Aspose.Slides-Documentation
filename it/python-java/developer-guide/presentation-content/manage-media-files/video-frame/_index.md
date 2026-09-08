---
title: Gestire i Frame Video nelle Presentazioni con Python
linktitle: Frame Video
type: docs
weight: 10
url: /it/python-java/video-frame/
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
description: "Impara ad aggiungere ed estrarre programmaticamente i frame video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per Python via Java. Guida rapida pratica."
---
## **Introduzione**

Un video posizionato bene in una presentazione può rendere il tuo messaggio più efficace e aumentare il livello di coinvolgimento del pubblico.

PowerPoint consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungi o incorpora un video locale (memorizzato sul tuo computer)
* Aggiungi un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/it/python-java/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) e altri tipi pertinenti.

## **Crea Frame Video Incorporati**

Se il file video che desideri aggiungere alla tua diapositiva è memorizzato localmente, puoi creare un frame video per incorporare il video nella tua presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/python-java/aspose.slides/video/) e passa i dati del file video per incorporare il video nella presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) per creare un frame per il video.
1. Salva la presentazione modificata.

Questo codice Python mostra come aggiungere un video memorizzato localmente a una presentazione:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In alternativa, puoi aggiungere un video passando direttamente il percorso del file al metodo [addVideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Crea Frame Video con Video da Fonti Web**

Microsoft [PowerPoint 2013 e versioni successive](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporta i video di YouTube nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad esempio su YouTube), puoi aggiungerlo alla tua presentazione tramite il suo link web.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Ottieni il riferimento a una diapositiva tramite il suo indice.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) e passa il collegamento al video.
1. Imposta una miniatura per il frame video.
1. Salva la presentazione.

Questo codice Python mostra come aggiungere un video dal web a una diapositiva in una presentazione PowerPoint:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Carica la miniatura.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ritaglia un Frame Video**

Aspose.Slides consente di controllare quale parte di un video viene riprodotta impostando i valori trim-from-start e trim-from-end tramite [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#setTrimFromEnd) . Entrambi i valori sono specificati in millisecondi e definiscono quanto tempo viene saltato dall'inizio e dalla fine del video, rispettivamente. Queste impostazioni modificano le impostazioni di riproduzione del video nella presentazione; non tagliano né modificano i dati binari del video incorporato.

**Imposta le Impostazioni di Ritaglio**

Per creare un frame video e impostare le sue impostazioni di ritaglio:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Aggiungi un oggetto [Video](https://reference.aspose.com/slides/it/python-java/aspose.slides/video/) alla presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) a una diapositiva.
1. Imposta i valori trim-from-start e trim-from-end tramite [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Salva la presentazione modificata.

Il seguente esempio di codice salta i primi 2,5 secondi e l'ultimo secondo di un video incorporato durante la riproduzione:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Leggi le Impostazioni di Ritaglio**

Per esaminare le impostazioni di ritaglio esistenti, carica una presentazione, trova un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) tra le forme della prima diapositiva e leggi i valori tramite [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#getTrimFromStart) e [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

Il seguente esempio di codice trova il primo frame video nella prima diapositiva e riporta le sue impostazioni di ritaglio in millisecondi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Gestisci i Sottotitoli Video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono disponibili tramite il metodo [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Aggiungi Sottotitoli a un Frame Video**

Per aggiungere sottotitoli a un frame video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
1. Aggiungi un video alla presentazione.
1. Aggiungi un oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) a una diapositiva.
1. Utilizza la [CaptionsCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/) restituita da [getCaptionTracks](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#getCaptionTracks) per aggiungere una traccia di sottotitoli WebVTT.
1. Salva la presentazione modificata.

Il seguente codice mostra come aggiungere sottotitoli a un frame video:

```python
from pathlib import Path

import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Aggiungi una nuova traccia di sottotitoli da un file WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/) fornisce anche un sovraccarico che consente di aggiungere sottotitoli da uno stream.

**Estrai i Sottotitoli da un Frame Video**

Per estrarre i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Trova l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) di destinazione.
1. Itera attraverso le tracce dei sottotitoli nella [CaptionsCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/) .
1. Salva ciascuna traccia di sottotitoli in un file `.vtt` .

Il seguente codice mostra come estrarre i sottotitoli da un frame video:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Salva la traccia di sottotitoli in un file WebVTT.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/it/python-java/aspose.slides/captions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i Sottotitoli da un Frame Video**

Per rimuovere i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Ottieni l'oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) di destinazione.
1. Rimuovi le tracce dei sottotitoli dalla [CaptionsCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/) .
1. Salva la presentazione modificata.

Il seguente codice mostra come rimuovere tutti i sottotitoli da un frame video:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Rimuovi tutti i sottotitoli dal frame video.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Se è necessario rimuovere solo una traccia di sottotitoli, utilizza i metodi [remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/#removeAt) invece di [clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/#clear) .

## **Estrai Video dalle Diapositive**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) per caricare la presentazione contenente il video.
2. Itera attraverso tutti gli oggetti [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) .
3. Itera attraverso tutti gli oggetti [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) .
4. Salva il video su disco.

Questo codice Python mostra come estrarre il video da una diapositiva di una presentazione:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un VideoFrame?**

È possibile controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#setPlayMode) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#setPlayLoopMode) . Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/) .

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari sono inclusi nel documento, quindi la dimensione della presentazione cresce proporzionalmente alla dimensione del file. Quando aggiungi un video online, viene incorporato un collegamento e una miniatura, quindi l'aumento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza cambiare la sua posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoframe/#setEmbeddedVideo) all'interno del frame mantenendo intatta la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/it/python-java/aspose.slides/video/#getContentType) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.