---
title: Hantera videoramar i presentationer med Python
linktitle: Videoram
type: docs
weight: 10
url: /sv/python-java/video-frame/
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
description: "Lär dig att programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via Java. Snabb användarguide."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides för Python via Java låter dig lägga till videoramar på bilder, justera uppspelningsinställningar, hantera bildtexter och extrahera inbäddade videodata.

PowerPoint stödjer lokala videor och länkar till online‑videor, såsom YouTube‑videor.

För att representera videodata och videoramar tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/python-java/aspose.slides/video/) klassen [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) och andra relevanta typer.

## **Skapa en inbäddad videoram**

Om videofilen du vill lägga till på din bild lagras lokalt kan du skapa en videoram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på första bilden i en befintlig presentation och sparar resultatet. Ramkoordinater och -dimensioner är i punkter. Python läser video‑bytarna från disk och JPype konverterar dem till en Java‑byte‑array innan videon läggs till i presentationen.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video)

    presentation.save("embedded_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Du kan också skicka en lokal videoväg direkt till [addVideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addVideoFrame). Detta exempel bäddar in videon på första bilden i en ny presentation. Videon måste förbli tillgänglig tills presentationen sparas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Skapa en videoram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stödjer online‑videor i presentationer. Du kan skapa en videoram som länkar till en online‑video, såsom en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyrbild på första bilden. Ersätt video‑identifieraren för att använda en annan video. Metoden [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) begär automatisk uppspelning. Nedladdning av miniatyrbilden och uppspelning av videon kräver internetåtkomst. Presentationsvisaren måste också stödja online‑videouppspelning.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_id = "aqz-KE-bpKQ"
    video_url = "https://www.youtube.com/embed/" + video_id
    video_frame = slide.getShapes().addVideoFrame(10, 10, 427, 240, video_url)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    thumbnail_url = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
    thumbnail = presentation.getImages().addImage(java_thumbnail_data)
    video_frame.getPictureFormat().getPicture().setImage(thumbnail)

    presentation.save("online_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Spela en video i helskärmsläge**

I en träningspresentation kan du spela en mjukvarudemonstration i helskärmsläge så publiken kan se detaljerna. Anropa [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode) med `True` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) på den första bilden och aktiverar helskärmsuppspelning. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setFullScreenMode(True)
            break

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Helskärmsuppspelning styr hur videon visas. Oberoende styr [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) om den startar automatiskt eller vid klick, och [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) om den upprepas. För att välja startbeteende, sätt uppspelningsläget till [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/). Exemplet bevarar de befintliga start- och loop‑inställningarna.

## **Spola tillbaka en video efter uppspelning**

I en träningspresentation gör att återföra en demonstrationsvideo till början den redo för presentatören att spela igen. Anropa [setRewindVideo](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setRewindVideo) med `True` för att återföra videon till början efter att uppspelningen är klar.

Detta exempel öppnar en presentation, hittar den första [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/) på den första bilden och aktiverar spolning tillbaka. Det inaktiverar loopning så uppspelningen kan slutföras och sätter uppspelning att starta vid klick. Indatapresentationen måste innehålla minst en bild med en befintlig videoram på den första bilden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame, VideoPlayModePreset

presentation = Presentation("training.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            shape.setRewindVideo(True)
            shape.setPlayLoopMode(False)
            shape.setPlayMode(VideoPlayModePreset.OnClick)
            break

    presentation.save("rewind_video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Att spola tillbaka återför videon till början utan att starta den igen. I kontrast upprepar ett anrop till [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode) med `True` uppspelningen automatiskt. Håll loopning inaktiverad när du vill att videon ska slutföras och vara redo för återuppspelning. [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) styr oberoende automatisk eller klick‑start; detta exempel använder [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/python-java/aspose.slides/videoplaymodepreset/) så presentatören kontrollerar när uppspelningen startar. Ställ in uppspelningsläget efter loop‑inställningen, som visas i exemplet. Spolning tillbaka fungerar oberoende av [setFullScreenMode](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setFullScreenMode).

## **Trimma en videoram**

Använd [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromStart) och [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setTrimFromEnd) för att hoppa över en del av början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimmning ändrar uppspelningsinställningarna utan att modifiera den inbäddade videodatan.

**Ange triminställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video längre än 3,5 sekunder så att ett spelbart segment återstår.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Läs triminställningar**

Detta exempel skriver ut trimvärdena för den första videoramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden inte har någon videoram skrivs inget ut. Det föregående exemplet ger värdena 2500 och 1000.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **Hantera videobildtexter**

Aspose.Slides låter dig hantera stängda bildtexter för videoramar i PowerPoint‑presentationer. Bildtexterna lagras i WebVTT‑format och exponeras via metoden [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#getCaptionTracks).

**Lägg till bildtexter i en videoram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑bildspår märkt English. Bildtextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både videon och dess bildtexter.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)

    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Lägg till ett nytt bildspår från en WebVTT-fil.
    video_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klassen [CaptionsCollection](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/) erbjuder också en överlagring som låter dig lägga till bildtexter från en ström.

**Extrahera bildtexter från en videoram**

Detta exempel sparar alla bildspår från videoramar på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdatafilerna åtskilda. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    track_count = 0
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                track_count += 1
                output_path = Path(f"captions_{track_count}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                output_path.write_bytes(caption_data)

    print(f"Caption tracks extracted: {track_count}")
finally:
    presentation.dispose()
```

Varje [Captions](https://reference.aspose.com/slides/python-java/aspose.slides/captions/)‑objekt visar bildtextens identifierare, etikett, binära data och bildtext som en UTF‑8‑sträng.

**Ta bort bildtexter från en videoram**

Detta exempel tar bort alla bildtexter från videoramen på den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns och att formen är en videoram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # Ta bort alla bildtexter från videoramen.
        video_frame.getCaptionTracks().clear()
        
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Om du behöver ta bort endast ett bildspår, använd metoderna [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) istället för [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska `.bin`‑ändelsen; ändra den för att matcha den rapporterade mediatypen vid behov.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("presentation_with_videos.pptx")
try:
    video_count = 0
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = Path(f"extracted_video_{video_count}.bin")
                video_data = bytes(video.getBinaryData())
                output_path.write_bytes(video_data)
                print(f"Video {video_count}: {video.getContentType()}")

    print(f"Embedded videos extracted: {video_count}")
finally:
    presentation.dispose()
```

## **FAQ**

**Vilka video‑uppspelningsparametrar kan ändras för en videoram?**

Du kan kontrollera [uppspelningsläge](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayMode) (auto eller vid klick) och [loopning](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setPlayLoopMode). Dessa alternativ är tillgängliga via objektets metoder för [VideoFrame](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas de binära data i dokumentet, så presentationens storlek växer proportionellt mot filens storlek. När du länkar till en online‑video och lägger till en miniatyrbild lagrar presentationen länken och förhandsbilden istället för videodata, så storleksökningen är vanligtvis mindre.

**Kan jag ersätta videon i en befintlig videoram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [videoinnehåll](https://reference.aspose.com/slides/python-java/aspose.slides/videoframe/#setEmbeddedVideo) inom ramen medan du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [innehållstyp](https://reference.aspose.com/slides/python-java/aspose.slides/video/#getContentType) som du kan läsa och använda, till exempel när du sparar den till disk.