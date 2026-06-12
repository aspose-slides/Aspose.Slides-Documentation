---
title: Gestire l'audio nelle presentazioni usando Python
linktitle: Frame audio
type: docs
weight: 10
url: /it/python-net/audio-frame/
keywords:
- aggiungere audio
- incorporare audio
- frame audio
- file audio
- proprietà audio
- estrarre audio
- recuperare audio
- modificare audio
- opzioni di riproduzione
- modalità di riproduzione
- riproduci su più diapositive
- loop fino all'arresto
- nascondere durante la presentazione
- riavvolgere dopo la riproduzione
- volume audio
- immagine predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungi, estrai e gestisci facilmente i frame audio in PPT, PPTX e ODP con Aspose.Slides per Python tramite .NET. Esplora esempi di codice e migliora le tue presentazioni oggi."
---
## **Panoramica**

Questo articolo spiega come lavorare con i frame audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare la miniatura del frame audio, configurare le opzioni di riproduzione come volume, ripetizione, nascondere, ritaglio e durata di dissolvenza, ed estrarre l’audio utilizzato nelle transizioni della presentazione.

## **Creare frame audio**

Aspose.Slides per Python tramite .NET consente di aggiungere file audio alle diapositive. I file audio sono incorporati nelle diapositive come frame audio. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Carica lo stream del file audio che desideri incorporare nella diapositiva.
4. Aggiungi il frame audio incorporato (contenente il file audio) alla diapositiva.
5. Imposta [PlayMode](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioplaymodepreset) e `Volume` esposti dall'oggetto [IAudioFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/).
6. Salva la presentazione modificata.

Questo codice Python mostra come aggiungere un frame audio incorporato a una diapositiva:

```python
import aspose.slides as slides

# Istanzia una classe di presentazione che rappresenta un file di presentazione
with slides.Presentation() as pres:
    # Ottiene la prima diapositiva
    sld = pres.slides[0]

    # Carica il file audio wav nello stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Aggiunge il Frame Audio
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Imposta la Modalità di riproduzione e il Volume dell'audio
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Scrive il file PowerPoint su disco
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifica miniatura del frame audio**

Quando aggiungi un file audio a una presentazione, l’audio appare come un frame con un’immagine predefinita standard (vedi l’immagine nella sezione seguente). Puoi modificare la miniatura del frame audio (impostare l’immagine preferita).

Questo codice Python mostra come modificare la miniatura o l’immagine di anteprima di un frame audio:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiunge un frame audio alla diapositiva con una posizione e dimensione specificate.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Aggiunge un'immagine alle risorse della presentazione.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Imposta l'immagine per il frame audio.
        audioFrame.picture_format.picture.image = audioImage
        
        #Salva la presentazione modificata su disco
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifica opzioni di riproduzione audio**

Aspose.Slides per Python tramite .NET consente di modificare le opzioni che controllano la riproduzione o le proprietà di un audio. Ad esempio, è possibile regolare il volume di un audio, impostare la riproduzione in loop o persino nascondere l’icona audio.

Il pannello **Audio Options** di Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Audio Options** di PowerPoint corrispondenti alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/) :

- **Start** la lista a discesa corrisponde alla proprietà [AudioFrame.play_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/play_mode/) 
- **Volume** corrisponde alla proprietà [AudioFrame.volume](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/volume/) 
- **Play Across Slides** corrisponde alla proprietà [AudioFrame.play_across_slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Loop until Stopped** corrisponde alla proprietà [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Hide During Show** corrisponde alla proprietà [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Rewind after Playing** corrisponde alla proprietà [AudioFrame.rewind_audio](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/rewind_audio/) 

Opzioni **Editing** di PowerPoint corrispondenti alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/) :

- **Fade In** corrisponde alla proprietà [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Fade Out** corrisponde alla proprietà [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Trim Audio Start Time** corrisponde alla proprietà [AudioFrame.trim_from_start](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/trim_from_start/) 
- **Trim Audio End Time** il valore è pari alla durata dell’audio meno il valore della proprietà [AudioFrame.trim_from_end](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/trim_from_end/) 

Il **Volume controll** di PowerPoint sul pannello di controllo audio corrisponde alla proprietà [AudioFrame.volume_value](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/volume_value/) . Consente di modificare il volume dell’audio in percentuale.

Ecco come modificare le opzioni di riproduzione audio:

1. [Crea](#create-audio-frame) o ottieni il Frame Audio.
2. Imposta nuovi valori per le proprietà del Frame Audio che desideri modificare.
3. Salva il file PowerPoint modificato.

Questo codice Python dimostra un'operazione in cui le opzioni di un audio vengono regolate:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Ottiene la forma AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Imposta la modalità di riproduzione su riproduci al clic
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Imposta il volume su Basso
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Imposta l'audio per riprodursi su più diapositive
    audioFrame.play_across_slides = True

    # Disabilita il loop per l'audio
    audioFrame.play_loop_mode = False

    # Nasconde il frame audio durante la presentazione
    audioFrame.hide_at_showing = True

    # Riavvolge l'audio all'inizio dopo la riproduzione
    audioFrame.rewind_audio = True

    # Salva il file PowerPoint su disco
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Questo esempio Python mostra come aggiungere un nuovo frame audio con audio incorporato, ritagliarlo e impostare le durate di dissolvenza:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Imposta l'offset di inizio del ritaglio a 1,5 secondi
    # Imposta l'offset di fine del ritaglio a 2 secondi
    # Imposta la durata della dissolvenza in ingresso a 200 ms
    # Imposta la durata della dissolvenza in uscita a 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Il seguente esempio di codice mostra come recuperare un frame audio con audio incorporato e impostare il suo volume all'85%:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Ottiene una forma di frame audio
    audio_frame = pres.slides[0].shapes[0]

    # Imposta il volume audio all'85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gestire i sottotitoli audio**

Aspose.Slides consente di aggiungere didascalie chiuse a un frame audio tramite la proprietà [caption_tracks](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/caption_tracks/). Questa proprietà restituisce una [CaptionsCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/), che permette di aggiungere tracce di sottotitoli WebVTT, iterare le tracce esistenti e rimuoverle quando necessario.

**Aggiungere sottotitoli audio**

Utilizza la proprietà [caption_tracks](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/caption_tracks/) per collegare una o più tracce di sottotitoli a un frame audio. Nell'esempio seguente, un file audio viene aggiunto a una diapositiva e poi una nuova traccia di sottotitoli viene caricata da un file `.vtt`.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Aggiungi una nuova traccia di didascalie da un file WebVTT.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Estrarre sottotitoli audio**

Puoi iterare le tracce di sottotitoli associate a un frame audio e salvarle come file `.vtt`. Ogni traccia di sottotitoli espone i propri dati binari e l'identificatore univoco, che può essere usato durante l'esportazione dei sottotitoli.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Salva la traccia di sottotitoli come file .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Rimuovere i sottotitoli audio**

Per rimuovere i sottotitoli da un frame audio, utilizza i metodi forniti da [CaptionsCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/), come [clear](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/remove/), o [remove_at](https://reference.aspose.com/slides/it/python-net/aspose.slides/captionscollection/remove_at/). L'esempio seguente rimuove tutte le tracce di sottotitoli da un frame audio.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # tipo: slides.AudioFrame

    # Rimuovi tutte le tracce di sottotitoli dal frame audio.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Estrarre audio**
Aspose.Slides per Python tramite .NET consente di estrarre il suono utilizzato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono usato in una diapositiva specifica.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e carica la presentazione che contiene l’audio.
2. Ottieni il riferimento alla diapositiva pertinente tramite il suo indice.
3. Accedi alle transizioni della presentazione per la diapositiva.
4. Estrai il suono in dati byte.

Questo codice Python mostra come estrarre l’audio utilizzato in una diapositiva:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Accede alla diapositiva desiderata
    slide = pres.slides[0]  

    # Ottiene gli effetti di transizione della presentazione per la diapositiva
    transition = slide.slide_show_transition

    #Estrae il suono in un array di byte
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Posso riutilizzare lo stesso file audio in più diapositive senza aumentare le dimensioni del file?**

Sí. Aggiungi l’audio una sola volta alla [audio collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/audios/) condivisa della presentazione e crea frame audio aggiuntivi che fanno riferimento a quell'asset esistente. Questo evita la duplicazione dei dati multimediali e mantiene le dimensioni della presentazione sotto controllo.

**Posso sostituire il suono in un frame audio esistente senza ricreare la forma?**

Sí. Per un suono collegato, aggiorna il [link path](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/link_path_long/) per puntare al nuovo file. Per un suono incorporato, sostituisci l’oggetto [embedded audio](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/embedded_audio/) con un altro proveniente dalla [audio collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/audios/) della presentazione. La formattazione del frame e la maggior parte delle impostazioni di riproduzione rimangono intatte.

**Il ritaglio modifica i dati audio sottostanti memorizzati nella presentazione?**

No. Il ritaglio regola solo i limiti di riproduzione. I byte originali dell’audio rimangono intatti e accessibili tramite l’audio incorporato o la [audio collection](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/audios/) della presentazione.