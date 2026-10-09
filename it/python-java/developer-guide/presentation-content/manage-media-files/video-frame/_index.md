---
title: Gestire i fotogrammi video nelle presentazioni usando Python
linktitle: Fotogramma video
type: docs
weight: 10
url: /it/python-java/video-frame/
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
- Python
- Aspose.Slides
description: "Impara a aggiungere ed estrarre programmaticamente fotogrammi video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per Python tramite Java. Guida rapida passo-passo."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides per Python tramite Java consente di aggiungere fotogrammi video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e i fotogrammi video, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) e altri tipi pertinenti.

## **Crea un fotogramma video incorporato**

Se il file video che desideri aggiungere alla diapositiva è archiviato localmente, puoi creare un fotogramma video per incorporare il video nella presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni del fotogramma sono espresse in punti. Python legge i byte del video dal disco, e JPype li converte in un array di byte Java prima che il video venga aggiunto alla presentazione.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Puoi anche passare direttamente un percorso video locale a [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve rimanere accessibile fino al salvataggio della presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Crea un fotogramma video con video da una fonte web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. È possibile creare un fotogramma video che collega a un video online, come un video di YouTube.

Questo esempio aggiunge un collegamento e una miniatura di un video YouTube alla prima diapositiva. Sostituisci l'identificatore del video per utilizzare un altro video. Il metodo [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) richiede la riproduzione automatica. Il download della miniatura e la riproduzione del video richiedono l'accesso a Internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione di video online.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Riproduci un video in modalità a schermo intero**

In una presentazione formativa, puoi riprodurre una dimostrazione software in modalità a schermo intero in modo che il pubblico possa vedere i dettagli. Chiama [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) con `True` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La riproduzione a schermo intero controlla come il video viene visualizzato. In modo indipendente, [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) controlla se parte automaticamente o al clic, e [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). L'esempio preserva le impostazioni esistenti di avvio e ciclo.

## **Riavvolgi un video dopo la riproduzione**

In una presentazione formativa, riportare un video dimostrativo all'inizio lo rende pronto per essere riprodotto nuovamente dal presentatore. Chiama [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) con `True` per riportare il video all'inizio dopo la fine della riproduzione.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) nella prima diapositiva e abilita il riavvolgimento. Disattiva il ciclo in modo che la riproduzione possa terminare e imposta l'avvio della riproduzione al clic. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il riavvolgimento riporta il video all'inizio senza avviarlo nuovamente. Al contrario, chiamare [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) con `True` ripete automaticamente la riproduzione. Mantieni il ciclo disattivato quando vuoi che il video termini e rimanga pronto per essere riprodotto di nuovo. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) controlla in modo indipendente l'avvio automatico o al clic; questo esempio utilizza [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) in modo che il presentatore controlli l'inizio della riproduzione. Imposta la modalità di riproduzione dopo l'impostazione del ciclo, come mostrato nell'esempio. Il riavvolgimento funziona in modo indipendente da [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Ritaglia un fotogramma video**

Usa [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) per saltare parte dell'inizio o della fine di un video durante la riproduzione. Entrambi i valori sono espressi in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta le impostazioni di ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l'ultimo secondo durante la riproduzione. Usa un video più lungo di 3,5 secondi in modo che rimanga un segmento riproducibile.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Leggi le impostazioni di ritaglio**

Questo esempio stampa i valori di ritaglio del primo fotogramma video nella prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha un fotogramma video, non viene stampato nulla. L'esempio precedente produce valori di 2500 e 1000.

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

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati in formato WebVTT e sono accessibili tramite il metodo [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Aggiungi i sottotitoli a un fotogramma video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT denominata English. I timestamp dei sottotitoli devono corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Aggiungi una nuova traccia di sottotitoli da un file WebVTT.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) fornisce anche una sovraccarico che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un fotogramma video**

Questo esempio salva tutte le tracce di sottotitoli dai fotogrammi video nella prima diapositiva come file WebVTT separati. I numeri sequenziali tengono distinti i file di output. La console riporta il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

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

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF‑8.

**Rimuovi i sottotitoli da un fotogramma video**

Questo esempio rimuove tutti i sottotitoli dal fotogramma video nella prima posizione della forma sulla prima diapositiva e salva il risultato. Suppone che la diapositiva e la forma esistano e che la forma sia un fotogramma video.

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
        # Rimuovi tutti i sottotitoli dal fotogramma video.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) invece di [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Estrai video da una diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari numerati separati. I video collegati vengono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ogni video e il conteggio totale. L'output utilizza l'estensione generica `.bin`; modificala per corrispondere al tipo di media riportato quando necessario.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un fotogramma video?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto o al clic) e il [ciclo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). queste opzioni sono disponibili tramite i metodi dell'oggetto [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi le dimensioni della presentazione crescono proporzionalmente alla dimensione del file. Quando colleghi a un video online e aggiungi una miniatura, la presentazione memorizza il collegamento e l'immagine di anteprima anziché i dati video, quindi l'aumento di dimensione è generalmente minore.

**Posso sostituire il video in un fotogramma video esistente senza cambiare la sua posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) all'interno del fotogramma mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.