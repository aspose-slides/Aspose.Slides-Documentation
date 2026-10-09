---
title: Gestisci i fotogrammi video nelle presentazioni in Python
linktitle: Fotogramma video
type: docs
weight: 10
url: /it/python-net/video-frame/
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
description: "Impara ad aggiungere ed estrarre programmaticamente i fotogrammi video in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via .NET. Guida pratica veloce."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides per Python via .NET consente di aggiungere fotogrammi video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e i fotogrammi video, Aspose.Slides fornisce la classe [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/), la classe [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) e altri tipi pertinenti.

## **Crea un fotogramma video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un fotogramma video per incorporare il video nella presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni del fotogramma sono espresse in punti. Lo stream rimane aperto fino al completamento del salvataggio perché [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) lo blocca mentre la presentazione lo utilizza.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Puoi anche passare un percorso video locale direttamente a [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve rimanere accessibile fino al salvataggio della presentazione.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Crea un fotogramma video con video da una fonte web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. Puoi creare un fotogramma video che punta a un video online, come un video di YouTube.

Questo esempio aggiunge un collegamento a un video YouTube e una miniatura alla prima diapositiva. Sostituisci l'identificatore del video per utilizzare un altro video. L'impostazione [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) richiede la riproduzione automatica. Il download della miniatura e la riproduzione del video richiedono l'accesso a Internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione di video online.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **Riproduci un video a schermo intero**

In una presentazione formativa, è possibile riprodurre una dimostrazione software a schermo intero affinché il pubblico possa vedere i dettagli. Imposta [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) su `True` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

La riproduzione a schermo intero controlla come viene visualizzato il video. In modo indipendente, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) controlla se inizia automaticamente o al clic, e [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). L'esempio mantiene le impostazioni di avvio e di ciclo esistenti.

## **Riavvolgi un video dopo la riproduzione**

In una presentazione formativa, riportare un video dimostrativo all'inizio lo rende pronto per il presentatore per riprodurlo nuovamente. Imposta [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) su `True` per riportare il video all'inizio dopo la fine della riproduzione.

Questo esempio apre una presentazione, trova il primo [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) nella prima diapositiva e abilita il riavvolgimento. Disabilita il ciclo in modo che la riproduzione possa terminare e imposta l'avvio della riproduzione al clic. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

Il riavvolgimento riporta il video all'inizio senza avviarlo di nuovo. Al contrario, abilitare [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) ripete automaticamente la riproduzione. Mantieni il ciclo disabilitato quando vuoi che il video termini e resti pronto per la riproduzione. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) controlla in modo indipendente l'avvio automatico o al clic; questo esempio utilizza [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) così il presentatore controlla quando inizia la riproduzione. Imposta la modalità di riproduzione dopo l'impostazione del ciclo, come mostrato nell'esempio. Il riavvolgimento funziona in modo indipendente da [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Ritaglia un fotogramma video**

Usa [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) e [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) per saltare una parte dell'inizio o della fine di un video durante la riproduzione. Entrambi i valori sono in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta le impostazioni di ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l'ultimo secondo durante la riproduzione. Usa un video più lungo di 3,5 secondi in modo che rimanga un segmento riproducibile.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**Leggi le impostazioni di ritaglio**

Questo esempio stampa i valori di ritaglio del primo fotogramma video nella prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha alcun fotogramma video, non viene stampato nulla. L'esempio precedente produce valori di 2500 e 1000.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono accessibili tramite la proprietà [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Aggiungi sottotitoli a un fotogramma video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT etichettata English. I timestamp dei sottotitoli devono corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) fornisce anche una sovraccarico che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un fotogramma video**

Questo esempio salva tutte le tracce di sottotitoli dai fotogrammi video nella prima diapositiva come file WebVTT separati. I numeri sequenziali mantengono i file di output distinti. La console riporta il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

Ogni oggetto [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i sottotitoli da un fotogramma video**

Questo esempio rimuove tutti i sottotitoli dal fotogramma video nella prima posizione della forma sulla prima diapositiva e salva il risultato. Suppone che la diapositiva e la forma esistano e che la forma sia un fotogramma video.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) o [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) invece di [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Estrai video da una diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari separati e numerati. I video collegati vengono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ciascun video e il conteggio totale. L'output utilizza l'estensione generica `.bin`; cambiala per corrispondere al tipo di media segnalato quando necessario.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un fotogramma video?**

Puoi controllare la [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi la dimensione della presentazione cresce proporzionalmente alla dimensione del file. Quando colleghi un video online e aggiungi una miniatura, la presentazione memorizza il collegamento e l'immagine di anteprima invece dei dati video, quindi l'aumento di dimensione è solitamente minore.

**Posso sostituire il video in un fotogramma video esistente senza modificarne posizione e dimensione?**

Sì. Puoi scambiare il [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) all'interno del fotogramma mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.