---
title: Hantera videoram i presentationer i Python
linktitle: Videoram
type: docs
weight: 10
url: /sv/python-net/video-frame/
keywords:
- lägga till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- videoram
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig att programatiskt lägga till och extrahera videoram i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via .NET. Snabb guide."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides för Python via .NET låter dig lägga till videoramverk till bilder, justera uppspelningsinställningar, hantera undertexter och extrahera inbäddad videodata.

PowerPoint stöder lokala videor och länkar till online‑videor, såsom YouTube‑videor.

För att representera videodata och videoramverk tillhandahåller Aspose.Slides klasserna [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) och [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/), samt andra relevanta typer.

## **Skapa ett inbäddat videoram**

Om videofilen du vill lägga till på din bild lagras lokalt kan du skapa ett videoram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramens koordinater och dimensioner anges i punkter. Strömmen förblir öppen tills sparandet är klart eftersom [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) låser den medan presentationen använder den.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Du kan också skicka en lokal videoväg direkt till [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli åtkomlig tills presentationen är sparad.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Skapa ett videoram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Du kan skapa ett videoram som länkar till en online‑video, såsom en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyrbild till den första bilden. Ersätt videoidentifieraren för att använda en annan video. Inställningen [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) begär automatisk uppspelning. Nedladdning av miniatyrbilden och uppspelning av videon kräver internetåtkomst. Presentationsvisaren måste också stödja uppspelning av online‑videor.

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

## **Spela upp en video i helskärmsläge**

I en träningspresentation kan du spela upp en programvarademonstration i helskärmsläge så publiken kan se detaljerna. Ställ in [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) till `True` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar det första [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) på den första bilden och aktiverar helskärmsuppspelning. Indata‑presentationen måste innehålla minst en bild med ett befintligt videoram på den första bilden.

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

Helskärmsuppspelning styr hur videon visas. Oberoende styr [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) om den startar automatiskt eller vid klick, och [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) styr om den upprepas. För att välja startbeteendet, ställ in uppspelningsläget till [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Exemplet bevarar de befintliga start‑ och loop‑inställningarna.

## **Spola tillbaka en video efter uppspelning**

I en träningspresentation gör återgång av en demonstrationsvideo till början den redo för presentatören att spela upp igen. Ställ in [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) till `True` för att återföra videon till början efter att uppspelningen är klar.

Detta exempel öppnar en presentation, hittar det första [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) på den första bilden och aktiverar spolning tillbaka. Det inaktiverar looping så att uppspelningen kan avslutas och ställer in uppspelning att starta vid klick. Indata‑presentationen måste innehålla minst en bild med ett befintligt videoram på den första bilden.

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

Spolning tillbaka för videon till början utan att starta den igen. I kontrast gör aktivering av [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) att uppspelningen upprepas automatiskt. Håll looping inaktiverad när du vill att videon ska slutföras och vara redo att spelas igen. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) styr oberoende automatisk eller klick‑start; detta exempel använder [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) så presentatören bestämmer när uppspelningen startar. Ställ in uppspelningsläget efter loop‑inställningen, som visas i exemplet. Spolning fungerar oberoende av [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Trimma ett videoram**

Använd [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) och [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) för att hoppa över en del i början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimming ändrar uppspelningsinställningarna utan att modifiera den inbäddade videodatan.

**Set Trim Settings**

Exemplet bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video som är längre än 3,5 sekunder så att ett spelbart segment kvarstår.

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

**Read Trim Settings**

Detta exempel skriver ut trim‑värdena för det första videoramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden saknar videoram skrivs inget ut. Det föregående exemplet ger värdena 2500 och 1000.

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

## **Hantera videobeskrivningar**

Aspose.Slides låter dig hantera stängda undertexter för videoramverk i PowerPoint‑presentationer. Undertexterna lagras i WebVTT‑format och exponeras via egenskapen [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

**Add Captions to a Video Frame**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår med etiketten English. Undertextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både videon och dess undertexter.

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

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/)‑klassen erbjuder också en överlagring som låter dig lägga till undertexter från en ström.

**Extract Captions from a Video Frame**

Detta exempel sparar alla undertextspår från videoramverk på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utskriftsfilerna unika. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

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

Varje [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/)‑objekt exponerar undertextens identifierare, etikett, binära data och undertextens text som en UTF‑8‑sträng.

**Remove Captions from a Video Frame**

Detta exempel tar bort alla undertexter från videoramen på den första formens position på den första bilden och sparar resultatet. Det antas att bilden och formen finns samt att formen är ett videoram.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Om du bara behöver ta bort ett undertextspår, använd [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) eller [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/)‑metoderna istället för [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska `.bin`‑filändelsen; ändra den för att matcha den rapporterade mediatypen vid behov.

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

**Vilka uppspelningsparametrar för en video kan ändras för ett videoram?**

Du kan styra [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (automatisk eller vid klick) och [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Dessa alternativ finns tillgängliga via objektets egenskaper för [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas de binära data i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du länkar till en online‑video och lägger till en miniatyrbild lagrar presentationen länken och förhandsbilden istället för videodata, så storleksökningen är vanligtvis mindre.

**Kan jag ersätta videon i ett befintligt videoram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) i ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) som du kan läsa och använda, till exempel när du sparar den till disk.