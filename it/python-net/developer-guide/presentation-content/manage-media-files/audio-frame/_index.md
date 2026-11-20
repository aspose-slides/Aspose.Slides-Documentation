---
title: Gestisci i fotogrammi audio nelle presentazioni con Python
linktitle: Fotogramma Audio
type: docs
weight: 10
url: /it/python-net/audio-frame/
keywords:
- audio
- fotogramma audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- WebVTT
- Python
- Aspose.Slides
description: "Incorpora audio nelle diapositive, modifica l'icona audio, configura la riproduzione, gestisci le didascalie WebVTT ed estrai i suoni di transizione delle diapositive con Aspose.Slides per Python via .NET."
---
## **Panoramica**

Un fotogramma audio ti consente di riprodurre un suono su una diapositiva. Con Aspose.Slides per Python via .NET, puoi incorporare una clip audio, scegliere l'immagine che la rappresenta, regolare la riproduzione e allegare didascalie. Puoi anche recuperare un suono assegnato a una transizione della diapositiva.

## **Crea Fotogrammi Audio**

Usa [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) per incorporare una clip audio locale nella prima diapositiva. Le prime due coordinate posizionano il fotogramma sulla diapositiva e le successive due impostano la sua larghezza e altezza, tutti in punti. Questo esempio imposta [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) per avviare automaticamente la clip e [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) sul preset alto.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Modifica l'Anteprima del Fotogramma Audio**

Per impostazione predefinita, un fotogramma audio mostra un'icona dell'altoparlante. Per visualizzare una miniatura personalizzata, aggiungi un'immagine alla presentazione con [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) e assegnala alla proprietà [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) del fotogramma. L'esempio utilizza un JPEG come miniatura per una clip audio incorporata.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Modifica le Opzioni di Riproduzione Audio**

I controlli **Audio Options** di PowerPoint determinano quando una clip inizia, quanto è alta e come si comporta durante una presentazione.

![Controlli Audio Options di PowerPoint per un fotogramma audio](audio_frame_0.png)

| Controllo PowerPoint | Proprietà Aspose.Slides |
| --- | --- |
| Avvio | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Preset volume | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Riproduci attraverso le diapositive | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Loop fino a interruzione | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Nascondi durante la presentazione | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Riavvolgi dopo la riproduzione | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Dissolvenza in entrata | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Dissolvenza in uscita | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Taglia inizio audio | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Taglia fine audio | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Cursore volume | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

L'esempio trova il primo fotogramma audio nella prima diapositiva, imposta [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) per avviare la riproduzione al clic e seleziona il preset volume basso. La clip continua attraverso le diapositive con il looping disabilitato. L'icona rimane nascosta durante la presentazione e la clip si riavvolge dopo la riproduzione.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```
Per una clip più lunga di 3,5 secondi, questo esempio salta i primi 1,5 secondi e gli ultimi 2 secondi. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) misura la durata da omettere alla fine della clip. Per ottenere il tempo finale mostrato in PowerPoint, sottrai quell'offset dalla durata totale della clip. La clip tagliata sfuma in ingresso in 200 millisecondi e sfuma in uscita in 500 millisecondi. Tutte e quattro le proprietà accettano valori in millisecondi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```
Per impostare il volume di riproduzione a una percentuale specifica, usa [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Questo esempio imposta il primo fotogramma audio nella prima diapositiva al 85%.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Gestisci le Didascalie Audio**

Ogni fotogramma audio ha una collezione [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). Usala per allegare didascalie WebVTT alla clip, esportare le tracce esistenti o rimuoverle.

### **Aggiungi Didascalie Audio**

L'esempio incorpora una clip audio nella prima diapositiva e utilizza [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) per allegare una traccia WebVTT locale. Il primo argomento fornisce l'etichetta della traccia, e il secondo identifica il file contenente le didascalie temporizzate.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```
### **Estrai Didascalie Audio**

Questo esempio esporta ogni traccia di didascalia allegata a un fotogramma audio nella prima diapositiva. Scrive il [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) della traccia in un file WebVTT e utilizza il suo [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) come nome file in modo che ogni traccia abbia un output separato.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```
### **Rimuovi Didascalie Audio**

Usa [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) o [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) per eliminare una traccia individuale. L'esempio utilizza [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) per rimuovere tutte le didascalie dal primo fotogramma audio nella prima diapositiva preservando la clip.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```
### **Trova una Riga nelle Didascalie Audio**

Per trovare una riga nelle didascalie audio della prima diapositiva, leggi in memoria il [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) di ogni traccia. In un cue WebVTT di testo semplice, la riga di timing contiene `-->`, le righe di didascalia la seguono e una riga vuota termina il cue. Questo esempio stampa l'etichetta della traccia e ogni riga di didascalia contenente “café”.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```
## **Estrai Audio**

Una transizione della diapositiva può avere un suono proprio. Per recuperarlo, leggi la proprietà [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) della transizione. L'esempio accede al [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) del suono e stampa la sua dimensione in byte. Se la prima diapositiva non ha suono di transizione, stampa invece un messaggio.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```
## **FAQ**

**Posso riutilizzare la stessa clip audio su più diapositive senza duplicarla?**

Sì. Aggiungi la clip una sola volta alla [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) della presentazione e passa lo stesso oggetto audio a [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) per ogni diapositiva.

**Posso sostituire il suono in un fotogramma audio esistente?**

Sì. Per un suono collegato, aggiorna [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) per puntare al file di sostituzione. Per un suono incorporato, assegna un'altra clip dalla collezione audio della presentazione a [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Entrambi gli approcci conservano il fotogramma esistente.

**Il ritaglio modifica i dati audio memorizzati nella presentazione?**

No. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) e [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) impostano i limiti di riproduzione. È ancora possibile recuperare la clip completa da [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).