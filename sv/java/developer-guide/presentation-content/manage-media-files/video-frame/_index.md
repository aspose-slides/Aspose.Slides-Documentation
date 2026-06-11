---
title: Hantera videoramar i presentationer med Java
linktitle: Videoram
type: docs
weight: 10
url: /sv/java/video-frame/
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
- Java
- Aspose.Slides
description: "Lär dig programatiskt att lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Java. Snabb guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsnivåerna hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (lagrad på din dator)
* Lägg till en online-video (från en webbkälla såsom YouTube).

För att du ska kunna lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides gränssnitten [IVideo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideo/) och [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideoframe/), samt andra relevanta typer. 

## **Skapa inbäddade videoramar**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa en videoram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation ](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideo/)‑objekt och skicka videofilens sökväg för att bädda in videon i presentationen. 
1. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideoframe/)‑objekt för att skapa en ram för videon.  
1. Spara den modifierade presentationen. 

Denna Java‑kod visar hur du lägger till en lokalt lagrad video i en presentation:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("pres.pptx");
try {
    // Läser in videon
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Hämtar den första bilden och lägger till en videoram
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Sparar presentationen till disken
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Skapa videoramar med video från webbkällor**

Microsoft [PowerPoint 2013 och nyare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stöder YouTube‑videor i presentationer. Om den video du vill använda är tillgänglig online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation ](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideo/)‑objekt och skicka länken till videon.
1. Ställ in en miniatyrebild för videoramen. 
1. Spara presentationen. 

Denna Java‑kod visar hur du lägger till en video från webben på en bild i en PowerPoint‑presentation:

```java
// Instansierar ett Presentation-objekt som representerar en presentationsfil 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Lägger till en videoram
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Laddar miniatyrebild
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Hantera videobeskrivningar**

Aspose.Slides låter dig hantera slutna bildtexter för videoramar i PowerPoint‑presentationer. Bildtexter lagras i WebVTT-format och exponeras via metoden [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideoframe/#getCaptionTracks--). 

**Lägg till bildtexter till en videoram**

För att lägga till bildtexter till en videoram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) .
1. Lägg till en video i presentationen.
1. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideoframe/)‑objekt på en bild.
1. Använd den [ICaptionsCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptionscollection/) som returneras av [getCaptionTracks](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) för att lägga till ett WebVTT‑bildspår.
1. Spara den modifierade presentationen.

Följande kod visar hur du lägger till bildtexter till en videoram:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Lägger till ett nytt bildtextspår från en WebVTT-fil.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gränssnittet [ICaptionsCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptionscollection/) erbjuder också en överlagring som låter dig lägga till bildtexter från en ström.

**Extrahera bildtexter från en videoram**

För att extrahera bildtexter från en videoram:

1. Läs in presentationen som innehåller videon.
1. Hitta mål‑objektet [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideoframe/).
1. Iterera igenom bildspåren i [ICaptionsCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptionscollection/).
1. Spara varje bildspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar bildtexter från en videoram:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Sparar bildspåret till en WebVTT-fil.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Varje [ICaptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptions/)‑objekt visar bildidentifieraren, etiketten, binära data och bildtexten som en UTF‑8‑sträng.

**Ta bort bildtexter från en videoram**

För att ta bort bildtexter från en videoram:

1. Läs in presentationen som innehåller videon.
1. Hämta mål‑objektet [IVideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ivideoframe/).
1. Ta bort bildspår från [ICaptionsCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptionscollection/).
1. Spara den modifierade presentationen.

Följande kod visar hur du tar bort alla bildtexter från en videoram:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Tar bort alla bildtexter från videoramen.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om du bara behöver ta bort ett bildspår, använd metoderna [remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) eller [removeAt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptionscollection/#removeAt-int-) istället för [clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icaptionscollection/#clear--).

## **Extrahera video från bilder**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) för att läsa in presentationen som innehåller videon. 
2. Iterera genom alla [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/)‑objekt.
3. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/)‑objekt för att hitta en [VideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/videoframe/). 
4. Spara videon till disk.

Denna Java‑kod visar hur du extraherar videon på en presentationsbild:

```java
// Instansierar ett Presentation-objekt som representerar en presentationsfil 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Hämtar filändelsen
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Vilka videouppspelningsparametrar kan ändras för en VideoFrame?**

Du kan kontrollera [uppspelningsläget](https://reference.aspose.com/slides/sv/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatiskt eller vid klick) och [loopning](https://reference.aspose.com/slides/sv/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Dessa alternativ finns tillgängliga via egenskaperna för [VideoFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/videoframe/)-objektet.

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas de binära data i dokumentet, så presentationens storlek växer proportionellt mot filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyrebild in, så storleksökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [videoinnehållet](https://reference.aspose.com/slides/sv/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) i ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [innehållstyp](https://reference.aspose.com/slides/sv/java/com.aspose.slides/video/#getContentType--) som du kan läsa och använda, exempelvis när du sparar den till disk.