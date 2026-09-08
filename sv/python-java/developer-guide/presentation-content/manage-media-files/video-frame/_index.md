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
description: "Lär dig programatiskt att lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Python via Java. Snabb guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsgraden hos din publik.

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (sparad på din dator)
* Lägg till en online‑video (från en webbkälla som YouTube).

För att låta dig lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/sv/python-java/aspose.slides/video/) , klassen [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/) , och andra relevanta typer.

## **Skapa inbäddade videoramverk**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa en videoram för att bädda in videon i din presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/python-java/aspose.slides/video/)‑objekt och skicka videofilens data för att bädda in videon i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objekt för att skapa en ram för videon.
1. Spara den modifierade presentationen.

Den här Python‑koden visar hur du lägger till en lokalt lagrad video i en presentation:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [addVideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addVideoFrame) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **Skapa videoramar med video från webbkällor**

Microsoft [PowerPoint 2013 och nyare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stödjer YouTube‑videor i presentationer. Om videon du vill använda är tillgänglig online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objekt och skicka länken till videon.
1. Ställ in en miniatyrbild för videoramen.
1. Spara presentationen.

Den här Python‑koden visar hur du lägger till en video från webben på en bild i en PowerPoint‑presentation:

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # Ladda miniatyrbilden.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trimma en videoram**

Aspose.Slides låter dig kontrollera vilken del av en video som spelas genom att sätta värdena trim‑from‑start och trim‑from‑end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#setTrimFromStart) och [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#setTrimFromEnd) . Båda värdena anges i millisekunder och definierar hur mycket tid som hoppas över från början respektive slutet av videon. Dessa inställningar ändrar videouppspelningsinställningarna i presentationen; de klipper inte eller modifierar den inbäddade videons binära data.

**Ställ in triminställningar**

För att skapa en videoram och ange dess triminställningar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) .
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/python-java/aspose.slides/video/)‑objekt i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objekt på en bild.
1. Sätt värdena trim‑from‑start och trim‑from‑end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#setTrimFromStart) och [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Spara den modifierade presentationen.

Följande kodexempel hoppar över de första 2,5 sekunderna och den sista sekunden av en inbäddad video under uppspelning:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Läs triminställningar**

För att granska befintliga triminställningar, öppna en presentation, hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objekt bland formerna på den första bilden och läs värdena via [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#getTrimFromStart) och [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#getTrimFromEnd) .

Följande kodexempel hittar den första videoramen på den första bilden och rapporterar dess triminställningar i millisekunder:

```python
import jpype
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

## **Hantera videobeskrivningar**

Aspose.Slides låter dig hantera stängda undertexter för videoramar i PowerPoint‑presentationer. Undertexter lagras i WebVTT‑format och exponeras via metoden [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#getCaptionTracks) .

**Lägg till undertexter på en videoram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) .
1. Lägg till en video i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objekt på en bild.
1. Använd [CaptionsCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/) som returneras av [getCaptionTracks](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#getCaptionTracks) för att lägga till ett WebVTT‑undertextspår.
1. Spara den modifierade presentationen.

Följande kod visar hur du lägger till undertexter på en videoram:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # Lägg till ett nytt undertextspår från en WebVTT-fil.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Klassen [CaptionsCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/) erbjuder också en overload som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en videoram**

1. Läs in presentationen som innehåller videon.
1. Hitta mål‑[VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objektet.
1. Iterera igenom undertextspåren i [CaptionsCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/) .
1. Spara varje undertextspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar undertexter från en videoram:

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
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # Spara undertextspåret till en WebVTT-fil.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

Varje [Captions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captions/)‑objekt presenterar undertextens identifierare, etikett, binärdata och undertext som en UTF‑8‑sträng.

**Ta bort undertexter från en videoram**

1. Läs in presentationen som innehåller videon.
1. Hämta mål‑[VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objektet.
1. Ta bort undertextspår från [CaptionsCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/) .
1. Spara den modifierade presentationen.

Följande kod visar hur du tar bort alla undertexter från en videoram:

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
        # Ta bort alla undertexter från videoramen.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/#removeAt) istället för [clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från bilder**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) för att läsa in presentationen som innehåller videon.
2. Iterera igenom alla [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/)‑objekt.
3. Iterera igenom alla [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/)‑objekt för att hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/) .
4. Spara videon till disk.

Den här Python‑koden visar hur du extraherar videon på en presentationsbild:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**Vilka videouppspelningsparametrar kan ändras för en VideoFrame?**

Du kan kontrollera [uppspelningsläge](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#setPlayMode) (automatiskt eller vid klick) och [loopning](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#setPlayLoopMode). Dessa alternativ är tillgängliga via egenskaperna på [VideoFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/)‑objektet.

**Påverkar det att lägga till en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyrbild in, så storleksökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video‑innehållet](https://reference.aspose.com/slides/sv/python-java/aspose.slides/videoframe/#setEmbeddedVideo) i ramen samtidigt som du behåller formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/python-java/aspose.slides/video/#getContentType) som du kan läsa och använda, till exempel när du sparar den till disk.