---
title: Beheer videoframes in presentaties in Python
linktitle: Videoframe
type: docs
weight: 10
url: /nl/python-net/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- videoframe
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u programmatisch video‑frames kunt toevoegen en extraheren in PowerPoint‑ en OpenDocument‑dia's met Aspose.Slides voor Python via .NET. Snelle stapsgewijze handleiding."
---
## **Introductie**

Video's kunnen helpen ideeën uit te leggen en een publiek te boeien. Aspose.Slides for Python via .NET stelt u in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingesloten videogegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om video‑gegevens en videoframes weer te geven, biedt Aspose.Slides de klasse [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , de klasse [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) en andere relevante typen.

## **Maak een ingesloten videoframe**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld sluit een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in points. De stroom blijft geopend tot het opslaan voltooid is omdat [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) deze vergrendeld houdt terwijl de presentatie deze gebruikt.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

U kunt ook een lokaal video‑pad rechtstreeks doorgeven aan [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Dit voorbeeld sluit de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Maak een videoframe met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een videoframe maken dat koppelt naar een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuurafbeelding toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De instelling [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) vraagt om automatisch afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieweergave moet ook online video‑afspelen ondersteunen.

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

## **Speel een video af in volledig scherm**

In een trainingspresentatie kunt u een software‑demonstratie in volledig scherm afspelen zodat het publiek de details kan zien. Stel [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) in op `True` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt de eerste [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) op de eerste dia en schakelt afspelen in volledig scherm in. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Afspelen in volledig scherm bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan regelt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) of deze automatisch start of bij een klik, en [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) bepaalt of ze wordt herhaald. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Video terugspoelen na het afspelen**

In een trainingspresentatie maakt het terugspoelen van een demonstratie‑video naar het begin de video klaar voor de presentator om opnieuw af te spelen. Stel [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) in op `True` om de video na afloop van het afspelen naar het begin te retourneren.

Dit voorbeeld opent een presentatie, zoekt de eerste [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) op de eerste dia en schakelt terugspoelen in. Het schakelt lus uit zodat het afspelen kan beëindigen en stelt het afspelen in op starten bij een klik. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Terugspoelen brengt de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt het inschakelen van [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) voor automatisch herhalen van het afspelen. Houd lus uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft om opnieuw te worden afgespeeld. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) regelt onafhankelijk automatisch of bij klik starten; dit voorbeeld gebruikt [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld wordt getoond. Terugspoelen werkt onafhankelijk van [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Trimmen van een videoframe**

Gebruik [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) en [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) om een gedeelte aan het begin of het einde van een video over te slaan tijdens het afspelen. Beide waarden worden opgegeven in milliseconden. Trimmen wijzigt de afspeelinstellingen zonder de ingesloten video‑gegevens te wijzigen.

**Triminstellingen instellen**

Dit voorbeeld sluit een lokale video in en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

**Triminstellingen lezen**

Dit voorbeeld drukt de trimwaarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het vorige voorbeeld geeft waarden van 2500 en 1000.

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

## **Beheer video‑ondertitels**

Aspose.Slides stelt u in staat ondertitels voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de eigenschap [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Ondertitels toevoegen aan een videoframe**

Dit voorbeeld sluit een lokale video in en voegt een WebVTT‑ondertiteltrack toe met het label English. De ondertitel‑tijdstempels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de ondertitels.

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

De klasse [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels extraheren uit een videoframe**

Dit voorbeeld slaat alle ondertiteltracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Sequentiële nummers houden de uitvoerbestanden onderscheidend. De console meldt het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

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

Elk [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) object geeft de ondertitel‑identifier, label, binaire gegevens en ondertiteltekst weer als een UTF‑8‑string.

**Ondertitels verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle ondertitels van het videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) of [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) in plaats van [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) .

## **Video extraheren van een dia**

Naast het toevoegen van video’s aan dia’s, stelt Aspose.Slides u in staat om video’s die in presentaties zijn ingesloten te extraheren.

Dit voorbeeld extraheert ingesloten video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gekoppelde video’s worden overgeslagen omdat ze geen ingesloten gegevens hebben. De console drukt het MIME‑type van elke video en het totale aantal af. De output gebruikt de generieke extensie `.bin`; wijzig deze indien nodig zodat deze overeenkomt met het gerapporteerde mediatype.

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

**Welke video‑afspeelparameters kunnen voor een videoframe worden gewijzigd?**

U kunt de [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (auto of bij klik) en het [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) beheren. Deze opties zijn beschikbaar via de eigenschappen van het object [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) .

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens toegevoegd aan het document, waardoor de presentatie‑grootte evenredig toeneemt met de bestandsgrootte. Wanneer u naar een online video linkt en een miniatuur toevoegt, slaat de presentatie de link en de voorbeeldafbeelding op in plaats van de video‑gegevens, waardoor de grootte‑toename meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) dat u kunt lezen en gebruiken, bijvoorbeeld wanneer u deze naar schijf opslaat.