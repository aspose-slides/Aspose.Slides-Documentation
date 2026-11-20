---
title: Gestisci i fotogrammi audio nelle presentazioni usando Python
linktitle: Fotogramma audio
type: docs
weight: 10
url: /it/python-java/audio-frame/
keywords:
- audio
- fotogramma audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- Python
- Aspose.Slides
description: "Incorpora audio nelle diapositive, modifica l'icona audio, configura la riproduzione, gestisci i sottotitoli WebVTT ed estrai i suoni delle transizioni delle diapositive con Aspose.Slides per Python via Java."
---
## **Panoramica**

Un fotogramma audio consente di riprodurre un suono su una diapositiva. Con Aspose.Slides for Python via Java, è possibile incorporare una clip audio, scegliere l'immagine che la rappresenta, regolare la riproduzione e allegare i sottotitoli. È inoltre possibile recuperare un suono assegnato a una transizione di diapositiva.

## **Crea fotogrammi audio**

Aggiungi i byte da `audio.wav` alla raccolta audio della presentazione, quindi usa [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) per incorporare una clip audio locale nella prima diapositiva. Le prime due coordinate posizionano il fotogramma sulla diapositiva, e i successivi due valori impostano la sua larghezza e altezza, tutti in punti. Questo esempio chiama [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) per avviare automaticamente la clip e chiama [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) per selezionare il preset alto.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifica la miniatura del fotogramma audio**

Per impostazione predefinita, un fotogramma audio mostra un'icona dell'altoparlante. Per visualizzare una miniatura personalizzata, aggiungi un'immagine alla presentazione con [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) e impostala sull'immagine del fotogramma con [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage). L'esempio utilizza un JPEG come miniatura per una clip audio incorporata.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifica le opzioni di riproduzione audio**

I controlli delle **Opzioni audio** di PowerPoint determinano quando inizia una clip, quanto è forte e come si comporta durante una presentazione.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Controllo PowerPoint | Aspose.Slides for Python via Java method |
| --- | --- |
| Avvio | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| Preset volume | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| Riproduci attraverso le diapositive | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Ripeti fino all'arresto | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Nascondi durante la presentazione | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| Riavvolgi dopo la riproduzione | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| Dissolvenza in ingresso | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| Dissolvenza in uscita | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Taglia l'ora di inizio audio | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| Taglia l'ora di fine audio | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Slider volume | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

L'esempio trova il primo fotogramma audio nella prima diapositiva, chiama [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) per avviare la riproduzione al clic e seleziona il preset volume basso. La clip continua attraverso le diapositive con il looping disabilitato. L'icona rimane nascosta durante la presentazione e la clip si riavvolge dopo la riproduzione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # Riproduci al clic a volume basso, su più diapositive, senza ripetizione.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # Nascondi il fotogramma durante la presentazione e riavvolgi dopo la riproduzione.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

Per una clip più lunga di 3,5 secondi, questo esempio salta i primi 1,5 secondi e gli ultimi 2 secondi. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) indica la durata da omettere dalla fine della clip. Per ottenere il tempo di fine mostrato in PowerPoint, sottrai quell'offset dalla durata totale della clip. La clip tagliata sfuma in ingresso per 200 millisecondi e sfuma in uscita per 500 millisecondi. Tutti e quattro i metodi accettano valori in millisecondi.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Taglia 1,5 secondi dall'inizio e 2 secondi dalla fine.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Imposta dissolvenza in ingresso a 200 ms e dissolvenza in uscita a 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per impostare il volume di riproduzione a una percentuale specifica, usa [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue). Questo esempio imposta il primo fotogramma audio nella prima diapositiva all'85%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **Gestisci i sottotitoli audio**

Ogni fotogramma audio fornisce l'accesso alle sue tracce di sottotitoli tramite [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks). Usa la collezione per allegare sottotitoli WebVTT alla clip, esportare le tracce esistenti o rimuoverle.

### **Aggiungi sottotitoli audio**

L'esempio incorpora una clip audio nella prima diapositiva e usa [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) per allegare una traccia WebVTT locale. Il primo argomento fornisce l'etichetta della traccia, e il secondo identifica il file contenente i sottotitoli temporizzati.

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Aggiungi una nuova traccia di sottotitoli da un file WebVTT.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Estrai i sottotitoli audio**

Questo esempio esporta ogni traccia di sottotitoli allegata a un fotogramma audio nella prima diapositiva. Scrive i byte restituiti da [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) in un file WebVTT e utilizza l'identificatore restituito da [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) come nome del file, in modo che ogni traccia abbia un output separato.

```python
from pathlib import Path

import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # Salva la traccia di sottotitoli come file .vtt.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **Rimuovi i sottotitoli audio**

Usa [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) per eliminare una traccia individuale. L'esempio utilizza [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) per rimuovere tutti i sottotitoli dal primo fotogramma audio nella prima diapositiva preservando la clip.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **Trova una riga nei sottotitoli audio**

Per trovare una riga nei sottotitoli audio della prima diapositiva, cerca il testo restituito da [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) in memoria. In un cue WebVTT di testo semplice, la riga di temporizzazione contiene `-->`, le righe di sottotitoli la seguono, e una riga vuota chiude il cue. Questo esempio stampa l'etichetta della traccia e ogni riga di sottotitolo contenente “café”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **Estrai audio**

Una transizione di diapositiva può avere un suono proprio. Per recuperarlo, chiama [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) sulla transizione della diapositiva. L'esempio accede ai byte restituiti da [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) e stampa il numero di byte. Se la prima diapositiva non ha suoni di transizione, stampa un messaggio invece.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **Domande frequenti**

**Posso riutilizzare la stessa clip audio su più diapositive senza duplicarla?**

Sì. Aggiungi la clip una sola volta alla [collezione audio](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) della presentazione e passa lo stesso oggetto audio a [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) per ogni diapositiva.

**Posso sostituire il suono in un fotogramma audio esistente?**

Sì. Per un suono collegato, usa [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) per puntare al file di sostituzione. Per un suono incorporato, seleziona un'altra clip dalla [collezione audio] della presentazione con [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio). Entrambi gli approcci preservano il fotogramma esistente.

**Il taglio modifica i dati audio memorizzati nella presentazione?**

No. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) e [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) impostano i limiti di riproduzione. È ancora possibile recuperare la clip completa da [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio).