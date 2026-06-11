---
title: Hantera ljud i presentationer med Python
linktitle: Ljudram
type: docs
weight: 10
url: /sv/python-net/audio-frame/
keywords:
- lägga till ljud
- bädda in ljud
- ljudram
- ljudfil
- ljudegenskaper
- extrahera ljud
- hämta ljud
- ändra ljud
- uppspelningsalternativ
- uppspelningsläge
- spela över bilder
- loopa tills stoppad
- dölj under visning
- spola tillbaka efter uppspelning
- ljudvolym
- standardbild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lägg enkelt till, extrahera och hantera ljudramar i PPT, PPTX och ODP med Aspose.Slides för Python via .NET. Utforska kodexempel och förbättra dina presentationer idag."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med ljudramar i Aspose.Slides. Den visar hur du lägger till inbäddat ljud på bilder, anpassar miniatyren för ljudramen, konfigurerar uppspelningsalternativ som volym, loopning, dold, beskärning och fade‑tider samt hur du extraherar ljud som används i bildspelsövergångar.

## **Skapa ljudramar**

Aspose.Slides för Python via .NET låter dig lägga till ljudfiler på bilder. Ljudfilerna bäddas in i bilderna som ljudramar.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-klassen.
2. Hämta en bilds referens via dess index.
3. Ladda ljudfilens ström som du vill bädda in i bilden.
4. Lägg till den inbäddade ljudramen (som innehåller ljudfilen) på bilden.
5. Ställ in [PlayMode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioplaymodepreset) och `Volume` som exponeras av [IAudioFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/)-objektet.
6. Spara den ändrade presentationen.

Denna Python‑kod visar hur du lägger till en inbäddad ljudram på en bild:

```python
import aspose.slides as slides

# Instansierar en presentationsklass som representerar en presentationsfil
with slides.Presentation() as pres:
    # Hämtar den första bilden
    sld = pres.slides[0]

    # Laddar wav-ljudfilen till stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Lägger till ljudramen
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Ställer in uppspelningsläget och volymen för ljudet
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Skriver PowerPoint-filen till disken
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändra miniatyr för ljudram**

När du lägger till en ljudfil i en presentation visas ljudet som en ram med en standardstandardbild (se bilden i avsnittet nedan). Du kan ändra ljudramens miniatyr (ange din föredragna bild).

Denna Python‑kod visar hur du ändrar en ljudramens miniatyr eller förhandsgranskningsbild:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägger till en ljudram på bilden med en specificerad position och storlek.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Lägger till en bild i presentationsresurserna.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Ställer in bilden för ljudramen.
        audioFrame.picture_format.picture.image = audioImage
        
        #Sparar den modifierade presentationen till disk
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ändra alternativ för ljuduppspelning**

Aspose.Slides för Python via .NET låter dig ändra alternativ som styr ett ljuds uppspelning eller egenskaper. Till exempel kan du justera ett ljuds volym, sätta ljudet på loop eller till och med dölja ljudikonen.

**Audio Options**‑panelen i Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/)-egenskaper:

- **Start**‑rullgardinslistan motsvarar egenskapen [AudioFrame.play_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/play_mode/).
- **Volume** motsvarar egenskapen [AudioFrame.volume](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/volume/).
- **Play Across Slides** motsvarar egenskapen [AudioFrame.play_across_slides](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/play_across_slides/).
- **Loop until Stopped** motsvarar egenskapen [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/play_loop_mode/).
- **Hide During Show** motsvarar egenskapen [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/hide_at_showing/).
- **Rewind after Playing** motsvarar egenskapen [AudioFrame.rewind_audio](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/rewind_audio/).

PowerPoint **Editing**‑alternativ som motsvarar Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/)-egenskaper:

- **Fade In** motsvarar egenskapen [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/fade_in_duration/).
- **Fade Out** motsvarar egenskapen [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/fade_out_duration/).
- **Trim Audio Start Time** motsvarar egenskapen [AudioFrame.trim_from_start](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/trim_from_start/).
- **Trim Audio End Time** har värdet lika med ljudets totala varaktighet minus värdet i [AudioFrame.trim_from_end](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/trim_from_end/).

PowerPoint **Volume controll** på ljudkontrollpanelen motsvarar egenskapen [AudioFrame.volume_value](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/volume_value/). Den låter dig ändra ljudvolymen i procent.

Så här ändrar du alternativ för ljuduppspelning:

1. [Сreate](#create-audio-frame) eller hämta ljudramen.
2. Ställ in nya värden för de ljudramsegenskaper du vill justera.
3. Spara den ändrade PowerPoint‑filen.

Denna Python‑kod demonstrerar en operation där ett ljuds alternativ justeras:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Hämtar AudioFrame-formen
    audioFrame = pres.slides[0].shapes[0]

    # Ställer in uppspelningsläget till att spela vid klick
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Ställer in volymen till låg
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Ställer in ljudet att spelas över bilder
    audioFrame.play_across_slides = True

    # Inaktiverar loop för ljudet
    audioFrame.play_loop_mode = False

    # Döljer AudioFrame under bildspelet
    audioFrame.hide_at_showing = True

    # Spolar tillbaka ljudet till början efter uppspelning
    audioFrame.rewind_audio = True

    # Sparar PowerPoint-filen till disk
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Denna Python‑exempel visar hur du lägger till en ny ljudram med inbäddat ljud, beskär den och ställer in fade‑tiderna:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Ställer in trimningsstartoffset till 1,5 sekunder
    # Ställer in trimningsslutoffset till 2 sekunder
    # Ställer in fade-in-tiden till 200 ms
    # Ställer in fade-out-tiden till 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Följande kodexempel visar hur du hämtar en ljudram med inbäddat ljud och sätter volymen till 85 %:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Hämtar en ljudramform
    audio_frame = pres.slides[0].shapes[0]

    # Ställer in ljudvolymen till 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera ljudtexter**

Aspose.Slides låter dig lägga till stängda undertexter till en ljudram via egenskapen [caption_tracks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/caption_tracks/). Denna egenskap returnerar en [CaptionsCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/), som låter dig lägga till WebVTT‑undertextspår, iterera genom befintliga spår och ta bort dem vid behov.

**Lägg till ljudtexter**

Använd egenskapen [caption_tracks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/caption_tracks/) för att bifoga ett eller flera undertextspår till en ljudram. I följande exempel läggs en ljudfil till en bild och sedan laddas ett nytt undertextspår från en `.vtt`‑fil.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Lägg till ett nytt undertextspår från en WebVTT-fil.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Extrahera ljudtexter**

Du kan iterera genom de undertextspår som är kopplade till en ljudram och spara dem som `.vtt`‑filer. Varje undertextspår exponerar sina binära data och unika identifierare, som kan användas vid export av undertexter.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Spara undertextspåret som en .vtt-fil.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Ta bort ljudtexter**

För att ta bort undertexter från en ljudram, använd metoderna som tillhandahålls av [CaptionsCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/), såsom [clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/remove/), eller [remove_at](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/remove_at/). Följande exempel tar bort alla undertextspår från en ljudram.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # typ: slides.AudioFrame

    # Ta bort alla undertextspår från ljudramen.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahera ljud**
Aspose.Slides för Python via .NET låter dig extrahera ljudet som används i bildspelsövergångar. Till exempel kan du extrahera ljudet som används i en specifik bild.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-klassen och ladda presentationen som innehåller ljudet.
2. Hämta den relevanta bildens referens via dess index.
3. Åtkomst till bildspelsövergångarna för bilden.
4. Extrahera ljudet som byte‑data.

Denna Python‑kod visar hur du extraherar ljudet som används i en bild:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Hämtar den önskade bilden
    slide = pres.slides[0]  

    # Hämtar bildspelsövergångseffekterna för bilden
    transition = slide.slide_show_transition

    #Extraherar ljudet i byte array
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Kan jag återanvända samma ljudresurs på flera bilder utan att öka filstorleken?**

Ja. Lägg till ljudet en gång i presentationens delade [audio collection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/audios/) och skapa ytterligare ljudramar som refererar till den befintliga resursen. Detta undviker duplicering av mediadata och håller presentationsstorleken under kontroll.

**Kan jag ersätta ljudet i en befintlig ljudram utan att återskapa formen?**

Ja. För ett länkat ljud, uppdatera [link path](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/link_path_long/) så att det pekar på den nya filen. För ett inbäddat ljud, byt ut [embedded audio](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/embedded_audio/)‑objektet mot ett annat från presentationens [audio collection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/audios/). Ramens formatering och de flesta uppspelningsinställningar förblir intakta.

**Ändrar beskärning den underliggande ljuddata som lagras i presentationen?**

Nej. Beskärning justerar endast uppspelningsgränserna. De ursprungliga ljudbytarna förblir orörda och är åtkomliga genom det inbäddade ljudet eller presentationens ljudsamling.