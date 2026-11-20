---
title: Hantera ljudramar i presentationer med Python
linktitle: Ljudram
type: docs
weight: 10
url: /sv/python-net/audio-frame/
keywords:
- ljud
- ljudram
- miniatyrbild
- lägg till ljud
- ljudegenskaper
- ljudalternativ
- extrahera ljud
- WebVTT
- Python
- Aspose.Slides
description: "Bädda in ljud i bilder, ändra ljudikonen, konfigurera uppspelning, hantera WebVTT-texter och extrahera bildspelsövergångsljud med Aspose.Slides för Python via .NET."
---
## **Översikt**

Ett ljudram gör att du kan spela upp ett ljud på en bild. Med Aspose.Slides för Python via .NET kan du bädda in ett ljudklipp, välja bilden som representerar det, justera uppspelning och bifoga texter. Du kan också hämta ett ljud som är tilldelat en bildspelsövergång.

## **Skapa ljudramar**

Använd [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) för att bädda in ett lokalt ljudklipp på den första bilden. De två första koordinaterna placerar ramen på bilden, och de två följande värdena anger dess bredd och höjd, alla i punkter. Detta exempel sätter [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) till att starta klippet automatiskt och [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) till den högsta volymförinställningen.

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

## **Ändra miniatyrbild för ljudram**

Som standard visar en ljudram en högtalarikon. För att visa en anpassad miniatyrbild, lägg till en bild i presentationen med [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) och tilldela den till ramens egenskap [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) . Exemplet använder en JPEG som miniatyrbild för ett inbäddat ljudklipp.

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

## **Ändra ljuduppspelningsalternativ**

PowerPoints **Audio Options**‑kontroller bestämmer när ett klipp startar, hur högt det låter och hur det beter sig under en bildspelsvisning.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint‑kontroll | Aspose.Slides‑egenskap |
| --- | --- |
| Start | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Volymförinställning | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Spela över bilder | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Upprepa tills stoppad | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Dölj under visning | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Spola tillbaka efter uppspelning | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Tona in | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Tona ut | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Trimma ljud starttid | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Trimma ljud sluttid | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Volymreglage | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Exemplet hittar den första ljudramen på den första bilden, sätter [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) till att starta uppspelning vid ett klick och väljer den låga volymförinställningen. Klippet fortsätter över bilder med upprepning inaktiverad. Ikonen förblir dold under visningen, och klippet spolar tillbaka efter uppspelning.

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

För ett klipp längre än 3,5 sekunder hoppar detta exempel över de första 1,5 sekunderna och de sista 2 sekunderna. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) mäter den varaktighet som ska utelämnas från klippets slut. För att få den sluttid som visas i PowerPoint, subtrahera den förskjutningen från hela klippets varaktighet. Det beskurna klippet tonar in under 200 ms och tonar ut under 500 ms. Alla fyra egenskaper använder värden i millisekunder.

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

För att sätta uppspelningsvolymen till en specifik procentsats, använd [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Detta exempel sätter den första ljudramen på den första bilden till 85 %.

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

## **Hantera ljudtexter**

Varje ljudram har en samling [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) . Använd den för att bifoga WebVTT‑texter till klippet, exportera befintliga spår eller ta bort dem.

### **Lägg till ljudtexter**

Exemplet bäddar in ett ljudklipp på den första bilden och använder [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) för att bifoga ett lokalt WebVTT‑spår. Det första argumentet anger spårets etikett och det andra identifierar filen som innehåller de tidskodade texterna.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Extrahera ljudtexter**

Detta exempel exporterar varje textspår som är bifogat en ljudram på den första bilden. Det skriver spårets [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) till en WebVTT‑fil och använder dess [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) som filnamn så att varje spår får en separat output.

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

### **Ta bort ljudtexter**

Använd [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) eller [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) för att ta bort ett enskilt spår. Exemplet använder [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) för att ta bort alla texter från den första ljudramen på den första bilden samtidigt som klippet bevaras.

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

### **Hitta en rad i ljudtexter**

För att hitta en rad i ljudtexterna på den första bilden, läs varje spårs [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) i minnet. I en ren text‑WebVTT‑cue innehåller tidslinjen `-->`, följt av textraderna, och en tom rad avslutar cue:n. Detta exempel skriver ut spårets etikett och varje textrad som innehåller “café”.

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

## **Extrahera ljud**

En bildspelsövergång kan ha ett eget ljud. För att hämta det, läs övergångens egenskap [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) . Exemplet får åtkomst till ljudets [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) och skriver ut dess storlek i byte. Om den första bilden saknar övergångsljud skriver det istället ut ett meddelande.

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

**Kan jag återanvända samma ljudklipp på flera bilder utan att duplicera det?**

Ja. Lägg till klippet en gång i presentationens [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) och skicka samma ljudobjekt till [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) för varje bild.

**Kan jag ersätta ljudet i en befintlig ljudram?**

Ja. För ett länkat ljud, uppdatera [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) så att det pekar på ersättningsfilen. För ett inbäddat ljud, tilldela ett annat klipp från presentationens ljudsamling till [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) . Båda metoderna bevarar den befintliga ramen.

**Ändrar trimning ljuddata som lagras i presentationen?**

Nej. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) och [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) sätter uppspelningsgränser. Du kan fortfarande hämta hela klippet från [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) .