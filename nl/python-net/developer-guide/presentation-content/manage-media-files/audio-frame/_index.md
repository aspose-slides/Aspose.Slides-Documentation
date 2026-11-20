---
title: Audioframes Beheren in Presentaties met Python
linktitle: Audioframe
type: docs
weight: 10
url: /nl/python-net/audio-frame/
keywords:
- geluid
- audioframe
- miniatuur
- audio toevoegen
- audio-eigenschappen
- audio-opties
- audio extraheren
- WebVTT
- Python
- Aspose.Slides
description: "Insluiten van audio in dia's, het audio‑icoon wijzigen, afspelen configureren, WebVTT‑bijschriften beheren en geluiden van dia‑overgangen extraheren met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Een audio frame stelt u in staat een geluid af te spelen op een dia. Met Aspose.Slides for Python via .NET kunt u een audio fragment insluiten, de afbeelding kiezen die het representeert, de weergave aanpassen en bijschriften toevoegen. U kunt ook een geluid ophalen dat is toegewezen aan een dia overgang.

## **Audioframes Maken**

Gebruik [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) om een lokaal audio fragment in te sluiten op de eerste dia. De eerste twee coördinaten positioneren het frame op de dia, en de volgende twee waarden stellen de breedte en hoogte in, allemaal in points. Dit voorbeeld stelt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) in om het fragment automatisch te starten en [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) op de luide preset.

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

## **Miniatuur van het audio frame wijzigen**

Standaard toont een audio frame een luidspreker‑icoon. Om een aangepaste miniatuur weer te geven, voegt u een afbeelding toe aan de presentatie met [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) en wijst u deze toe aan de eigenschap [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/). Het voorbeeld gebruikt een JPEG als miniatuur voor een ingesloten audio fragment.

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

## **Audio-afspeelopties Wijzigen**

De **Audio‑opties** van PowerPoint bepalen wanneer een fragment start, hoe hard het klinkt en hoe het zich gedraagt tijdens een diavoorstelling.

![PowerPoint-audiogereedschappen voor een audio frame](audio_frame_0.png)

| PowerPoint control | Aspose.Slides property |
| --- | --- |
| Start | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Volume preset | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Play Across Slides | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Loop until Stopped | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Hide During Show | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Rewind after Playing | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Fade In | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Fade Out | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Trim Audio start time | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Trim Audio end time | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Volume slider | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Het voorbeeld vindt het eerste audio frame op de eerste dia, stelt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) in om de weergave te starten bij een klik, en selecteert de lage volume‑preset. Het fragment gaat door over dia's met herhalen uitgeschakeld. Het pictogram blijft verborgen tijdens de show, en het fragment wordt teruggespoeld na afspelen.

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

Voor een fragment langer dan 3,5 seconden slaat dit voorbeeld de eerste 1,5 seconden en de laatste 2 seconden over. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) meet de duur die weggelaten moet worden aan het einde van het fragment. Om de eindtijd te krijgen die in PowerPoint wordt weergegeven, trekt u die offset af van de volledige fragmentduur. Het bijgesneden fragment vloeit in gedurende 200 milliseconden en vloeit uit gedurende 500 milliseconden. Alle vier de eigenschappen gebruiken milliseconden als eenheid.

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

Om het afspeelvolume op een specifiek percentage in te stellen, gebruikt u [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Dit voorbeeld stelt het eerste audio frame op de eerste dia in op 85%.

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

## **Audio‑bijschriften Beheren**

Elk audio frame heeft een collectie [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). Gebruik deze om WebVTT-bijschriften aan het fragment toe te voegen, bestaande tracks te exporteren, of ze te verwijderen.

### **Audio‑bijschriften Toevoegen**

Het voorbeeld sluit een audio fragment in op de eerste dia en gebruikt [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) om een lokale WebVTT‑track toe te voegen. Het eerste argument levert het label van de track, en het tweede geeft het bestand met de getimede bijschriften aan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Audio‑bijschriften Exporteren**

Dit voorbeeld exporteert elke bijschrifttrack die aan een audio frame op de eerste dia is gekoppeld. Het schrijft de [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) van de track naar een WebVTT‑bestand en gebruikt de [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) als bestandsnaam zodat elke track een aparte output heeft.

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

### **Audio‑bijschriften Verwijderen**

Gebruik [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) of [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) om een individuele track te verwijderen. Het voorbeeld gebruikt [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) om alle bijschriften van het eerste audio frame op de eerste dia te verwijderen, terwijl het fragment behouden blijft.

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

### **Een Regel in Audio‑bijschriften Vinden**

Om een regel in de audio‑bijschriften op de eerste dia te vinden, leest u elke track's [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) in het geheugen. In een platte‑tekst WebVTT‑cue bevat de timing‑regel `-->`, gevolgd door de bijschriftregels, en een lege regel beëindigt de cue. Dit voorbeeld drukt het track‑label en elke bijschriftregel af die “café” bevat.

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

## **Audio Exporteren**

Een dia‑overgang kan een eigen geluid hebben. Om dit op te halen, leest u de eigenschap [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) van de overgang. Het voorbeeld krijgt toegang tot de [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) van het geluid en drukt de grootte in bytes af. Als de eerste dia geen overgangsgeluid heeft, wordt in plaats daarvan een bericht weergegeven.

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

**Kan ik hetzelfde audio fragment op meerdere dia's hergebruiken zonder het te dupliceren?**

Ja. Voeg het fragment één keer toe aan de [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) van de presentatie en geef hetzelfde audio‑object door aan [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) voor elke dia.

**Kan ik het geluid in een bestaand audio frame vervangen?**

Ja. Voor een gekoppeld geluid werkt u [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) bij zodat deze naar het vervangende bestand wijst. Voor een ingesloten geluid wijst u een ander fragment uit de audio‑collection van de presentatie toe aan [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Beide methoden behouden het bestaande frame.

**Verandert bijsnijden de audio‑data die in de presentatie is opgeslagen?**

Nee. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) en [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) stellen de afspeelgrenzen in. U kunt nog steeds het volledige fragment ophalen via [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).