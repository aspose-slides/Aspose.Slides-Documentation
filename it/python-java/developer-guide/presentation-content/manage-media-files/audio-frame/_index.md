---
title: Gestire l'audio nelle presentazioni con Python
linktitle: Fotogramma audio
type: docs
weight: 10
url: /it/python-java/audio-frame/
keywords:
- audio
- fotogramma audio
- miniatura
- aggiungere audio
- proprietà audio
- opzioni audio
- estrarre audio
- Python
- Aspose.Slides
description: "Crea e controlla i fotogrammi audio in Aspose.Slides per Python via Java—esempi di codice per incorporare, ritagliare, ripetere e configurare la riproduzione in presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come lavorare con i fotogrammi audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare la miniatura del fotogramma audio, configurare le opzioni di riproduzione come volume, ripetizione, nascondere, ritaglio e durata delle dissolvenze, ed estrarre l'audio utilizzato nelle transizioni della presentazione.

## **Creare fotogrammi audio**

Aspose.Slides per Python via Java consente di aggiungere file audio alle diapositive. I file audio sono incorporati nelle diapositive come fotogrammi audio. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva tramite il suo indice.
3. Leggi il file audio che desideri incorporare nella diapositiva.
4. Aggiungi il fotogramma audio incorporato (contenente il file audio) alla diapositiva.
5. Usa [setPlayMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setPlayMode) e [setVolume](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setVolume) esposti dall'oggetto [AudioFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/).
6. Salva la presentazione modificata.

Questo codice Python mostra come aggiungere un fotogramma audio incorporato a una diapositiva:

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

## **Modificare la miniatura del fotogramma audio**

Quando aggiungi un file audio a una presentazione, l'audio appare come un fotogramma con un'immagine predefinita standard (vedi l'immagine nella sezione sotto). Puoi modificare l'immagine di anteprima del fotogramma audio con un'immagine a tua scelta.

Questo codice Python mostra come cambiare la miniatura o l'immagine di anteprima di un fotogramma audio:

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
    audio_data = Path("sample2.mp3").read_bytes()
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

## **Modificare le opzioni di riproduzione audio**

Aspose.Slides per Python via Java consente di modificare le opzioni che controllano la riproduzione audio o le proprietà. Ad esempio, puoi regolare il volume audio, impostare l'audio in loop o persino nascondere l'icona audio.

Il pannello **Audio Options** in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Audio Options** di PowerPoint corrispondenti alle proprietà Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/) sono:

- L'elenco a discesa **Start** corrisponde al metodo [setPlayMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** corrisponde al metodo [setVolume](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** corrisponde al metodo [setPlayAcrossSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** corrisponde al metodo [setPlayLoopMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** corrisponde al metodo [setHideAtShowing](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** corrisponde al metodo [setRewindAudio](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setRewindAudio)

Le opzioni **Editing** di PowerPoint corrispondenti alle proprietà Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/) sono:

- **Fade In** corrisponde al metodo [setFadeInDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fade Out** corrisponde al metodo [setFadeOutDuration](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim Audio Start Time** corrisponde al metodo [setTrimFromStart](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim Audio End Time** il valore corrisponde alla durata dell'audio meno il valore impostato dal metodo [setTrimFromEnd](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setTrimFromEnd)

Il **Volume control** di PowerPoint nel pannello di controllo audio corrisponde al metodo [setVolumeValue](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setVolumeValue). Consente di modificare il volume audio in percentuale.

Questo è come modificare le opzioni di riproduzione audio:

1. [Create](#create-audio-frames) o ottieni il fotogramma audio.
2. Imposta nuovi valori per le proprietà del fotogramma audio che desideri modificare.
3. Salva il file PowerPoint modificato.

Questo codice Python dimostra un'operazione in cui le opzioni audio vengono regolate:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
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
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

Questo esempio Python mostra come aggiungere un nuovo fotogramma audio con audio incorporato, ritagliarlo e impostare le durate della dissolvenza:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpile.JArray(jpile.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # Ritaglia 1.5 secondi dall'inizio e 2 secondi dalla fine.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # Imposta fade-in a 200 ms e fade-out a 500 ms.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il seguente esempio di codice mostra come recuperare un fotogramma audio con audio incorporato e impostare il suo volume all'85%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Gestire i sottotitoli audio**

Aspose.Slides consente di aggiungere sottotitoli chiusi a un fotogramma audio tramite il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#getCaptionTracks). Questo metodo restituisce una [CaptionsCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/), che permette di aggiungere tracce di sottotitoli WebVTT, iterare le tracce esistenti e rimuoverle quando necessario.

**Aggiungere sottotitoli audio**

Utilizza il metodo [getCaptionTracks](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#getCaptionTracks) per collegare una o più tracce di sottotitoli a un fotogramma audio. Nell'esempio seguente, un file audio viene aggiunto a una diapositiva, quindi una nuova traccia di sottotitoli viene caricata da un file `.vtt`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # Aggiungi una nuova traccia di sottotitoli da un file WebVTT.
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Estrarre i sottotitoli audio**

Puoi iterare le tracce di sottotitoli associate a un fotogramma audio e salvarle come file `.vtt`. Ogni traccia di sottotitoli espone i propri dati binari e un identificatore unico, che può essere utilizzato durante l'esportazione dei sottotitoli.

```python
from pathlib import Path

import jpype
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
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**Rimuovere i sottotitoli audio**

Per rimuovere i sottotitoli da un fotogramma audio, utilizza i metodi forniti da [CaptionsCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/), come [clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/#remove) o [removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/captionscollection/#removeAt). L'esempio seguente rimuove tutte le tracce di sottotitoli da un fotogramma audio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **Estrarre audio**

Aspose.Slides per Python via Java consente di estrarre il suono utilizzato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono utilizzato in una diapositiva specifica.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente l'audio.
2. Ottieni un riferimento alla diapositiva pertinente tramite il suo indice.
3. Accedi alle [slideshow transitions](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getSlideShowTransition) per la diapositiva.
4. Estrai il suono come dati byte.

Questo codice Python mostra come estrarre l'audio utilizzato in una diapositiva:

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
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**Posso riutilizzare lo stesso elemento audio su più diapositive senza aumentare la dimensione del file?**

Sì. Aggiungi l'audio una sola volta alla [audio collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getAudios) condivisa della presentazione e crea ulteriori fotogrammi audio che fanno riferimento a tale risorsa esistente. In questo modo si evita la duplicazione dei dati multimediali e si mantiene la dimensione della presentazione sotto controllo.

**Posso sostituire il suono in un fotogramma audio esistente senza ricreare la forma?**

Sì. Per un suono collegato, aggiorna il [link path](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setLinkPathLong) per puntare al nuovo file. Per un suono incorporato, sostituisci l'oggetto [embedded audio](https://reference.aspose.com/slides/it/python-java/aspose.slides/audioframe/#setEmbeddedAudio) con un altro presente nella [audio collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getAudios) della presentazione. La formattazione del fotogramma e la maggior parte delle impostazioni di riproduzione rimangono inalterate.

**Il ritaglio modifica i dati audio sottostanti memorizzati nella presentazione?**

No. Il ritaglio regola solo i limiti di riproduzione. I byte audio originali rimangono intatti e accessibili tramite l'audio incorporato o la [audio collection](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getAudios) della presentazione.