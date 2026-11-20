---
title: Beheer videoframes in presentaties met Python
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
description: "Leer hoe u programmatic videoframes kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Python via .NET. Snelle stapsgewijze gids."
---
## **Inleiding**

Video’s kunnen helpen ideeën te verduidelijken en een publiek te betrekken. Aspose.Slides voor Python via .NET stelt u in staat videoframes aan dia’s toe te voegen, afspeelinstellingen aan te passen, ondertitels te beheren en ingesloten videogegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om videogegevens en videoframes te vertegenwoordigen, levert Aspose.Slides de [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/)‑klasse, de [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)‑klasse en andere relevante typen.

## **Een ingesloten videoframe maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten.

Dit voorbeeld voegt een lokale video in op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in points. De stream blijft geopend tot het opslaan voltooid is, omdat [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) deze vergrendeld houdt terwijl de presentatie er gebruik van maakt.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

U kunt ook direct een lokaal video‑pad doorgeven aan [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Dit voorbeeld voegt de video in op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven tot de presentatie is opgeslagen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Een videoframe maken met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. U kunt een videoframe maken dat naar een online video linkt, bijvoorbeeld een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videolink en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)‑instelling vraagt om automatisch afspelen. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatiekijker moet ook online video‑afspelen ondersteunen.

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

## **Een video afspelen in volledig‑schermmodus**

In een trainingspresentatie kunt u een software‑demo in volledig‑schermmodus afspelen zodat het publiek de details kan zien. Stel [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) in op `True` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, vindt de eerste [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) op de eerste dia en schakelt afspelen in volledig scherm in. De invoerpresentatie moet ten minste één dia bevatten met een bestaand videoframe op de eerste dia.

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

Volledig‑scherm‑afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan bepaalt [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) of deze automatisch of bij klikken start, en [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) of hij wordt herhaald. Om het startgedrag te kiezen, stelt u de afspeelmodus in op [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Een video terugspoelen na afspelen**

In een trainingspresentatie maakt het terugspoelen van een demonstratievideo naar het begin het mogelijk om deze opnieuw af te spelen. Stel [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) in op `True` om de video na afloop van het afspelen naar het begin terug te brengen.

Dit voorbeeld opent een presentatie, vindt de eerste [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) op de eerste dia en schakelt terugspoelen in. Het schakelt lus uit zodat het afspelen kan eindigen en stelt het afspelen in op starten bij klikken. De invoerpresentatie moet ten minste één dia bevatten met een bestaand videoframe op de eerste dia.

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

Terugspoelen brengt de video terug naar het begin zonder hem opnieuw te starten. Daarentegen herhaalt het inschakelen van [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) het afspelen automatisch. Houd de lus uitgeschakeld wanneer u wilt dat de video eindigt en klaar blijft voor opnieuw afspelen. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) bepaalt onafhankelijk automatisch of bij‑klikken starten; dit voorbeeld gebruikt [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) zodat de presentator beslist wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals in het voorbeeld wordt weergegeven. Terugspoelen werkt onafhankelijk van [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Een videoframe inkorten**

Gebruik [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) en [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) om het begin‑ of einddeel van een video over te slaan tijdens het afspelen. Beide waarden worden in milliseconden opgegeven. Inkorten verandert de afspeelinstellingen zonder de ingesloten videogegevens te wijzigen.

**Triminstellingen instellen**

Dit voorbeeld voegt een lokale video in en slaat de eerste 2,5 secondes en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 secondes zodat er een speelbaar segment overblijft.

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

Dit voorbeeld print de trimwaarden van het eerste videoframe op de eerste dia in milliseconden. De presentatie moet ten minste één dia bevatten. Als die dia geen videoframe heeft, wordt er niets geprint. Het voorgaande voorbeeld geeft waarden van 2500 en 1000.

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

## **Video‑bijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften voor videoframes in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en zijn blootgesteld via de eigenschap [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

### **Bijschriften toevoegen aan een videoframe**

Dit voorbeeld voegt een lokale video in en voegt een WebVTT‑bijschrifttrack met de naam English toe. De tijdstempels van de bijschriften moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de bijschriften.

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

De [CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/)‑klasse biedt ook een overload waarmee u bijschriften vanuit een stream kunt toevoegen.

### **Bijschriften extraheren uit een videoframe**

Dit voorbeeld slaat alle bijschrifttracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Opeenvolgende nummers houden de uitvoerbestanden verschillend. De console meldt het aantal geëxtraheerde tracks. De presentatie moet ten minste één dia bevatten.

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

Elk [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/)‑object geeft de bijschrift‑identifier, het label, binaire data en de bijschrift‑tekst als een UTF‑8‑string weer.

### **Bijschriften verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle bijschriften van het videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Als u slechts één bijschrifttrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) of [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) in plaats van [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **Video‑bijschriften doorzoeken**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) retourneert de volledige WebVTT‑track, inclusief header, timing‑regels en bijschrifttekst. Bijvoorbeeld, een Engelse track op dia 2 kan de volgende cue bevatten:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Dit voorbeeld opent `captioned_media.pptx` en leest de [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) van elk bovenliggend videoframe op elke dia. Voor elke plain‑text cue zoekt het de timing‑regel die `-->` bevat en verzamelt de bijschriftregels tot de volgende lege regel of het einde van de track. Het zoekt in de bijschrifttekst naar “café” ongeacht hoofdletters en print het dia‑nummer, track‑label, originele timing‑regel en volledige bijschrift voor elke overeenkomst.

```python
import aspose.slides as slides

with slides.Presentation("captioned_media.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.VideoFrame):
                continue

            for track in shape.caption_tracks:
                lines = iter(track.data_as_string.splitlines())
                for timing in lines:
                    if "-->" not in timing:
                        continue

                    caption_lines = []
                    for line in lines:
                        if not line:
                            break
                        caption_lines.append(line)

                    caption = "\n".join(caption_lines)
                    if "café" in caption.casefold():
                        print(f"Slide {slide.slide_number} | {track.label} | {timing}")
                        print(caption)
```

De voorbeeldtrack levert één overeenkomst op. “Café” in de header staat buiten de bijschrifttekst, en de uitvoer behoudt de timing‑instelling en beide bijschriftregels.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Video extraheren van een dia**

Naast het toevoegen van video’s aan dia’s, stelt Aspose.Slides u in staat video’s die in presentaties zijn ingebed te extraheren.

Dit voorbeeld extraheert ingesloten video’s van elke dia naar afzonderlijke genummerde binaire bestanden. Gekoppelde video’s worden overgeslagen omdat ze geen ingesloten data hebben. De console print het MIME‑type van elke video en het totale aantal. De output gebruikt de generieke `.bin`‑extensie; wijzig deze om overeen te komen met het gerapporteerde mediatype indien nodig.

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

**Welke videoweergave‑parameters kunnen voor een videoframe worden aangepast?**

U kunt de [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (auto of bij klik) en [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de bestandsomvang van de PPTX?**

Ja. Wanneer u een lokale video inbedt, wordt de binaire data in het document opgenomen, waardoor de presentatiemaat evenredig toeneemt met de bestandsgrootte. Wanneer u naar een online video linkt en een miniatuur toevoegt, slaat de presentatie alleen de koppeling en de voorbeeldafbeelding op in plaats van de videogegevens, waardoor de omvangstoename meestal kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en afmetingen te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) binnen het frame omwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het inhoudstype (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.