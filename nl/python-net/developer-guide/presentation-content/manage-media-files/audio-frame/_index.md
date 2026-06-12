---
title: Audiobeheer in presentaties met Python
linktitle: Audioframe
type: docs
weight: 10
url: /nl/python-net/audio-frame/
keywords:
- audio toevoegen
- audio insluiten
- audioframe
- audiobestand
- audio-eigenschappen
- audio extraheren
- audio ophalen
- audio wijzigen
- afspeelopties
- afspeelmodus
- afspelen over dia's
- herhalen tot gestopt
- verbergen tijdens voorstelling
- terugspoelen na afspelen
- geluidsvolume
- standaardafbeelding
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Voeg eenvoudig audio-frames toe, extraheer ze en beheer ze in PPT, PPTX en ODP met Aspose.Slides voor Python via .NET. Bekijk codevoorbeelden & verbeter vandaag nog uw presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je met audio‑frames werkt in Aspose.Slides. Het laat zien hoe je ingebedde audio aan dia's toevoegt, de miniatuur van het audio‑frame aanpast, afspeelopties configureert zoals volume, herhalen, verbergen, bijsnijden en fade‑tijden, en audio extraheert die wordt gebruikt bij dia‑showovergangen.

## **Audio‑frames maken**

Aspose.Slides for Python via .NET maakt het mogelijk om audiobestanden aan dia's toe te voegen. De audiobestanden worden in de dia's ingebed als audio‑frames. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)-klasse.
2. Haal de referentie van een dia op via de index.
3. Laad de audiobestandsstroom die je in de dia wilt insluiten.
4. Voeg het ingebedde audio‑frame (dat het audiobestand bevat) toe aan de dia.
5. Stel [PlayMode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioplaymodepreset) en `Volume` in die beschikbaar zijn via het [IAudioFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/) object.
6. Sla de gewijzigde presentatie op.

Deze Python‑code laat zien hoe je een ingebed audio‑frame aan een dia toevoegt:

```python
import aspose.slides as slides

# Maak een instantie van een presentatieklasse die een presentatie‑bestand vertegenwoordigt
with slides.Presentation() as pres:
    # Haalt de eerste dia op
    sld = pres.slides[0]

    # Laadt het wav‑geluidsbestand naar een stream
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Voegt het audio‑frame toe
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Stelt de afspeelmodus en het volume van de audio in
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Schrijft het PowerPoint‑bestand naar schijf
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Miniatuur van audio‑frame wijzigen**

Wanneer je een audiobestand aan een presentatie toevoegt, verschijnt de audio als een frame met een standaard standaardafbeelding (zie de afbeelding in de onderstaande sectie). Je kunt de miniatuur van het audio‑frame wijzigen (stel je gewenste afbeelding in).

Deze Python‑code laat zien hoe je de miniatuur of voorbeeldafbeelding van een audio‑frame wijzigt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Voegt een audio‑frame toe aan de dia met een opgegeven positie en afmeting.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Voegt een afbeelding toe aan de presentatieresources.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Stelt de afbeelding in voor het audio‑frame.
        audioFrame.picture_format.picture.image = audioImage
        
        #Slaat de gewijzigde presentatie op schijf
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio‑afspeelopties wijzigen**

Aspose.Slides for Python via .NET maakt het mogelijk om opties te wijzigen die de weergave of eigenschappen van audio regelen. Je kunt bijvoorbeeld het volume van audio aanpassen, de audio herhaald laten afspelen, of zelfs het audio‑pictogram verbergen.

Het **Audio‑opties**‑venster in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio‑opties** die overeenkomen met de eigenschappen van Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/) :

- **Start**‑keuzelijst komt overeen met de eigenschap [AudioFrame.play_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/play_mode/) 
- **Volume** komt overeen met de eigenschap [AudioFrame.volume](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/volume/) 
- **Play Across Slides** komt overeen met de eigenschap [AudioFrame.play_across_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/play_across_slides/) 
- **Loop until Stopped** komt overeen met de eigenschap [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/play_loop_mode/) 
- **Hide During Show** komt overeen met de eigenschap [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/hide_at_showing/) 
- **Rewind after Playing** komt overeen met de eigenschap [AudioFrame.rewind_audio](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/rewind_audio/) 

PowerPoint **Bewerkings**‑opties die overeenkomen met de eigenschappen van Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/) :

- **Fade In** komt overeen met de eigenschap [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/fade_in_duration/) 
- **Fade Out** komt overeen met de eigenschap [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/fade_out_duration/) 
- **Trim Audio Start Time** komt overeen met de eigenschap [AudioFrame.trim_from_start](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/trim_from_start/) 
- **Trim Audio End Time**‑waarde is gelijk aan de audio‑duur min de waarde van de eigenschap [AudioFrame.trim_from_end](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/trim_from_end/) 

De PowerPoint **volumeregelaar** op het audio‑bedieningspaneel komt overeen met de eigenschap [AudioFrame.volume_value](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/volume_value/) . Hiermee kun je het audiovolume als percentage aanpassen.

Zo wijzig je de audio‑afspeelopties:

1. [Maak](#create-audio-frame) of haal het Audio Frame.
2. Stel nieuwe waarden in voor de Audio Frame‑eigenschappen die je wilt aanpassen.
3. Sla het gewijzigde PowerPoint‑bestand op.

Deze Python‑code toont een bewerking waarbij de opties van een audio worden aangepast:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Haalt het AudioFrame‑object op
    audioFrame = pres.slides[0].shapes[0]

    # Stelt de afspeelmodus in op afspelen bij klikken
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Stelt het volume in op laag
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Stelt de audio in om over dia's af te spelen
    audioFrame.play_across_slides = True

    # Schakelt het herhalen voor de audio uit
    audioFrame.play_loop_mode = False

    # Verbergt het AudioFrame tijdens de diavoorstelling
    audioFrame.hide_at_showing = True

    # Spoelt de audio terug naar het begin na het afspelen
    audioFrame.rewind_audio = True

    # Slaat het PowerPoint‑bestand op schijf
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Dit Python‑voorbeeld laat zien hoe je een nieuw audio‑frame met ingebedde audio toevoegt, het bijsnijdt, en de fade‑tijden instelt:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Stelt de startverschuiving voor bijsnijden in op 1,5 seconden
    audio_frame.trim_from_start = 1500.0
    # Stelt de eindverschuiving voor bijsnijden in op 2 seconden
    audio_frame.trim_from_end = 2000.0

    # Stelt de fade-in-duur in op 200 ms
    audio_frame.fade_in_duration = 200.0
    # Stelt de fade-out-duur in op 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

De volgende codevoorbeelden tonen hoe je een audio‑frame met ingebedde audio ophaalt en het volume instelt op 85 %:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Haalt een audio-frame object op
    audio_frame = pres.slides[0].shapes[0]

    # Stelt het audio-volume in op 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio‑bijschriften beheren**

Aspose.Slides maakt het mogelijk om gesloten bijschriften aan een audio‑frame toe te voegen via de eigenschap [caption_tracks](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/caption_tracks/). Deze eigenschap retourneert een [CaptionsCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/captionscollection/), waarmee je WebVTT‑bijschrift‑tracks kunt toevoegen, door bestaande tracks kunt itereren en ze kunt verwijderen indien nodig.

**Audio‑bijschriften toevoegen**

Gebruik de eigenschap [caption_tracks] om een of meer bijschrift‑tracks aan een audio‑frame te koppelen. In het volgende voorbeeld wordt een audiobestand aan een dia toegevoegd en vervolgens wordt een nieuwe bijschrift‑track geladen vanuit een `.vtt`‑bestand.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Voeg een nieuwe ondertiteltrack toe vanaf een WebVTT‑bestand.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Audio‑bijschriften extraheren**

Je kunt itereren door de bijschrift‑tracks die aan een audio‑frame zijn gekoppeld en ze opslaan als `.vtt`‑bestanden. Elke bijschrift‑track geeft zijn binaire gegevens en unieke identifier vrij, die gebruikt kunnen worden bij het exporteren van bijschriften.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Sla het ondertiteltrack op als een .vtt-bestand.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Audio‑bijschriften verwijderen**

Om bijschriften uit een audio‑frame te verwijderen, gebruik je de methoden van [CaptionsCollection], zoals [clear], [remove] of [remove_at]. Het volgende voorbeeld verwijdert alle bijschrift‑tracks uit een audio‑frame.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # type: slides.AudioFrame

    # Verwijder alle ondertiteltracks van het audioframe.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio extraheren**

Aspose.Slides for Python via .NET maakt het mogelijk om het geluid dat in dia‑showovergangen wordt gebruikt te extraheren. Je kunt bijvoorbeeld het geluid uit een specifieke dia extraheren.

1. Maak een instantie van de [Presentation]‑klasse en laad de presentatie die de audio bevat.
2. Haal de referentie van de desbetreffende dia op via de index.
3. Toegang tot de dia‑showovergangen voor de dia.
4. Extraheer het geluid als byte‑gegevens.

Deze Python‑code laat zien hoe je de audio uit een dia extraheert:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Haalt de gewenste dia op
    slide = pres.slides[0]  

    # Haalt de overgangseffecten van de dia op
    transition = slide.slide_show_transition

    #Extraheert het geluid in een byte-array
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**Kan ik hetzelfde audio‑bestand op meerdere dia's hergebruiken zonder de bestandsgrootte op te blazen?**

Ja. Voeg de audio één keer toe aan de gedeelde [audio collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/audios/) van de presentatie en maak extra audio‑frames die naar dat bestaande bestand verwijzen. Dit voorkomt duplicatie van mediagegevens en houdt de presentatiegrootte onder controle.

**Kan ik het geluid in een bestaand audio‑frame vervangen zonder de vorm opnieuw te maken?**

Ja. Voor een gekoppeld geluid, werk het [link path](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/link_path_long/) bij zodat het naar het nieuwe bestand verwijst. Voor een ingebed geluid, vervang het [embedded audio](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/embedded_audio/)‑object door een ander object uit de [audio collection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/audios/) van de presentatie. De opmaak van het frame en de meeste afspeelinstellingen blijven behouden.

**Verandert bijsnijden de onderliggende audio‑gegevens die in de presentatie zijn opgeslagen?**

Nee. Bijsnijden wijzigt alleen de afspeelgrenzen. De originele audiobytes blijven onaangeroerd en zijn toegankelijk via de ingebedde audio of de audio‑collectie van de presentatie.