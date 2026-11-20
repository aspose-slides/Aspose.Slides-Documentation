---
title: Hantera videoramar i presentationer i Python
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
description: "Lär dig att programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via .NET. Snabb guide."
---
## **Introduktion**

Video kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides for Python via .NET låter dig lägga till videoramar till bilder, justera uppspelningsinställningar, hantera undertexter och extrahera inbäddade videodata.

PowerPoint stöder lokala videor och länkar till online‑videor, såsom YouTube‑videor.

För att representera videodata och videoramar tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) , klassen [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) , och andra relevanta typer.

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till på din bild lagras lokalt kan du skapa en videoram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramkoordinater och dimensioner är i punkter. Strömmen förblir öppen tills sparandet är klart eftersom [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/) håller den låst medan presentationen använder den.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

Du kan också skicka en lokal videoväg direkt till [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli tillgänglig tills presentationen sparas.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **Skapa en videoram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Du kan skapa en videoram som länkar till en online‑video, såsom en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyr på den första bilden. Byt ut video‑identifieraren för att använda en annan video. Inställningen [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) begär automatisk uppspelning. Hämtning av miniatyren och uppspelning av videon kräver internetåtkomst. Presentationsvisaren måste också stödja uppspelning av online‑videor.

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

## **Spela en video i helskärmsläge**

I en utbildningspresentation kan du spela en mjukvarudemonstration i helskärmsläge så publiken kan se detaljerna. Ställ in [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/) till `True` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) på den första bilden och aktiverar helskärmsuppspelning. Inmatningspresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Helskärmsuppspelning styr hur videon visas. Oberoende styr [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) om den startar automatiskt eller vid klick, och [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) styr om den upprepas. För att välja startbeteendet, ställ in uppspelningsläget till [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/). Exemplet behåller de befintliga start‑ och loop‑inställningarna.

## **Spola tillbaka en video efter uppspelning**

I en utbildningspresentation gör att återföra en demonstrationsvideo till början den redo för presentatören att spela igen. Ställ in [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/) till `True` för att återföra videon till början efter att uppspelningen är klar.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) på den första bilden och aktiverar återspolning. Det inaktiverar looping så att uppspelningen kan avslutas och ställer in uppspelning att starta vid klick. Inmatningspresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

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

Återspolning flyttar videon till början utan att starta den igen. I kontrast gör att aktivera [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/) att uppspelning upprepas automatiskt. Håll looping inaktiverad när du vill att videon ska avslutas och vara redo för återuppspelning. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) styr oberoende automatisk eller klick‑start; detta exempel använder [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/) så presentatören kontrollerar när uppspelningen startar. Ställ in uppspelningsläget efter loop‑inställningen, som visas i exemplet. Återspolning fungerar oberoende av [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/).

## **Trimma en videoram**

Använd [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) och [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/) för att hoppa över en del av början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimning ändrar uppspelningsinställningarna utan att modifiera den inbäddade videodatan.

**Ange triminställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video som är längre än 3,5 sekunder så att ett spelbart segment återstår.

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

**Läs triminställningar**

Detta exempel skriver ut trimvärdena för den första videoramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden saknar videoram skrivs inget ut. Föregående exempel ger värdena 2500 och 1000.

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

## **Hantera video‑undertexter**

Aspose.Slides låter dig hantera stängda undertexter för videoramar i PowerPoint‑presentationer. Undertexter sparas i WebVTT‑format och exponeras via egenskapen [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/).

### **Lägg till undertexter till en videoram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår märkt English. Undertextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både video och dess undertexter.

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

### **Extrahera undertexter från en videoram**

Detta exempel sparar alla undertextspår från videoramar på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdatafilerna åtskilda. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

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

Varje [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/)‑objekt exponerar undertextens identifierare, etikett, binärdata och undertextrösten som en UTF‑8‑sträng.

### **Ta bort undertexter från en videoram**

Detta exempel tar bort alla undertexter från videoramen på den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns och att formen är en videoram.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Om du behöver ta bort endast ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) eller [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) istället för [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/).

### **Sök video‑undertexter**

[Captions.data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) returnerar hela WebVTT‑spåret, inklusive dess rubrik, tidslinjer och undertexttext. Till exempel kan ett engelskt spår på bild 2 innehålla detta cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Detta exempel öppnar `captioned_media.pptx` och läser [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) för varje top‑nivå videoram på varje bild. För varje rentext‑cue hittar det tidslinjen som innehåller `-->` och samlar in undertextraderna fram till nästa tomma rad eller slutet av spåret. Det söker i undertexten efter “café” utan hänsyn till versaler och skriver ut bildnumret, spårets etikett, ursprunglig tidslinje och fullständig undertext för varje träff.

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

Exempelspåret ger en matchning. “Café” i rubriken ligger utanför undertexten, och utskriften bevarar tidsinställningen och båda undertextraderna.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska `.bin`‑ändelsen; ändra den för att matcha den rapporterade mediatypen vid behov.

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

**Vilka video‑uppspelningsparametrar kan ändras för en videoram?**

Du kan styra [playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) (auto eller vid klick) och [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/). Dessa alternativ är tillgängliga via egenskaperna på objektet [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, så presentationens storlek växer i proportion till filens storlek. När du länkar till en online‑video och lägger till en miniatyr sparar presentationen länken och förhandsbilden istället för videodata, så storleksökningen är vanligtvis mindre.

**Kan jag ersätta videon i en befintlig videoram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/) inom ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/) som du kan läsa och använda, till exempel när du sparar den till disk.