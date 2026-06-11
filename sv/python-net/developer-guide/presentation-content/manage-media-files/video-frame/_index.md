---
title: Lägg till videor i presentationer i Python
linktitle: Videoruta
type: docs
weight: 10
url: /sv/python-net/video-frame/
keywords:
- lägga till video
- skapa video
- bädda in video
- extrahera video
- hämta video
- videoruta
- webbkälla
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig att programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument‑bilder med Aspose.Slides för Python via .NET. Snabb praktisk guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsnivåerna hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (sparad på din dator)
* Lägg till en online‑video (från en webbkälla såsom YouTube).

För att du ska kunna lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/sv/python-net/aspose.slides/video/) , klassen [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/) , och andra relevanta typer. 

## **Skapa inbäddad videoruta**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa en videoruta för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/python-net/aspose.slides/video/)‑objekt och ange videofilens sökväg för att bädda in videon i presentationen. 
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/)‑objekt för att skapa en ram för videon.  
1. Spara den ändrade presentationen. 

Den här Python‑koden visar hur du lägger till en lokalt lagrad video i en presentation:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # Hämtar den första bilden och lägger till en videoruta
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # Sparar presentationen till disk
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden `add_video_frame(x, y, width, height, fname)`:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **Skapa videoruta med video från webbkälla**

Microsoft [PowerPoint 2013 och nyare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stöder YouTube‑videor i presentationer. Om videon du vill använda finns online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/python-net/aspose.slides/video/)‑objekt och ange länken till videon.
1. Ange en miniatyrbild för videorutan. 
1. Spara presentationen. 

Den här Python‑koden visar hur du lägger till en video från webben på en bild i en PowerPoint‑presentation:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # Lägger till en videoruta
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # Laddar miniatyrbild
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera videobildtexter**

Aspose.Slides låter dig hantera undertexter för videorutor i PowerPoint‑presentationer. Undertexter lagras i WebVTT‑format och exponeras via egenskapen [VideoFrame.caption_tracks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/caption_tracks/) . 

**Lägg till undertexter i en videoruta**

För att lägga till undertexter i en videoruta:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
1. Lägg till en video i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/)‑objekt på en bild.
1. Använd [CaptionsCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/) som returneras av [caption_tracks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/caption_tracks/) för att lägga till ett WebVTT‑undertextspår.
1. Spara den ändrade presentationen.

Följande kod visar hur du lägger till undertexter i en videoruta:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # Lägger till ett nytt undertextspår från en WebVTT-fil.
    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

Klassen [CaptionsCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/) har också en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en videoruta**

För att extrahera undertexter från en videoruta:

1. Läs in presentationen som innehåller videon.
1. Hitta målovrket [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/)‑objekt.
1. Iterera genom samlingen [caption_tracks](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/caption_tracks/) .
1. Spara varje undertextspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar undertexter från en videoruta:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # Sparar undertextspåret till en WebVTT-fil.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

Varje [Captions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captions/)‑objekt exponerar undertextens identifierare, etikett, binära data och undertexttext som en UTF‑8‑sträng.

**Ta bort undertexter från en videoruta**

För att ta bort undertexter från en videoruta:

1. Läs in presentationen som innehåller videon.
1. Hämta målovrket [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/)‑objekt.
1. Ta bort undertextspår från [CaptionsCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/) .
1. Spara den ändrade presentationen.

Följande kod visar hur du tar bort alla undertexter från en videoruta:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # typ: slides.VideoFrame

    # Tar bort alla undertexter från videoramen.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/remove/) eller [remove_at](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/remove_at/) istället för [clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides/captionscollection/clear/) .

## **Extrahera video från bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) för att läsa in presentationen som innehåller videon. 
2. Iterera genom alla [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/)‑objekt.
3. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/)‑objekt för att hitta en [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/) . 
4. Spara videon till disk.

Den här Python‑koden visar hur du extraherar videon på en presentationsbild:

```python
import aspose.slides as slides

# Skapar ett Presentation-objekt som representerar en presentationsfil
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**Vilka videouppspelningsparametrar kan ändras för en VideoFrame?**

Du kan styra [playback mode](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/play_mode/) (automatiskt eller vid klick) och [looping](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/play_loop_mode/) . Dessa alternativ finns tillgängliga via egenskaperna för objektet [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/) .

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas de binära data i dokumentet, så presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyrbild in, så storleksökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/embedded_video/) i ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/video/content_type/) som du kan läsa och använda, till exempel när du sparar den till disk.