---
title: Hantera videorutor i presentationer på Android
linktitle: Videoruta
type: docs
weight: 10
url: /sv/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Lär dig programatiskt lägga till och extrahera videorutor i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Android via Java. Snabb guide."
---
## **Introduktion**

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsgraden hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (sparad på din dator)
* Lägg till en online‑video (från en webbkälla såsom YouTube).

För att låta dig lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides [IVideo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideo/)‑gränssnittet, [IVideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/)‑gränssnittet och andra relevanta typer.

## **Skapa en inbäddad videoruta**

Om videofilen du vill lägga till på din bild lagras lokalt kan du skapa en videoruta för att bädda in videon i din presentation. 

1. Skapa en instans av [Presentation ](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)klass.
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideo/)‑objekt och skicka videofilens sökväg för att bädda in videon i presentationen.
1. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/)‑objekt för att skapa en ram för videon.
1. Spara den ändrade presentationen. 

Denna Java‑kod visar hur du lägger till en lokalt lagrad video i en presentation:

```java
// Instansierar Presentation-klassen
Presentation pres = new Presentation("pres.pptx");
try {
    // Laddar videon
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Hämtar den första bilden och lägger till en videoruta
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Sparar presentationen på disk
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Skapa en videoruta med video från en webbkälla**

Nyare versioner av Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stöder online‑videor i presentationer. Om videon du vill använda finns online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk.

1. Skapa en instans av [Presentation ](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)klass
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideo/)‑objekt och skicka länken till videon.
1. Ställ in en miniatyrbild för videorutan. 
1. Spara presentationen. 

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
    // Lägger till en videoruta
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Laddar miniatyrbild
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

## **Trimma en videoruta**

Aspose.Slides låter dig kontrollera vilken del av en video som spelas upp genom att ange värdena trim‑from‑start och trim‑from‑end via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) och [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Båda värdena anges i millisekunder och definierar hur mycket tid som hoppas över i början respektive slutet av videon. Dessa inställningar ändrar uppspelningsinställningarna i presentationen; de kapar inte eller modifierar den inbäddade videons binära data.

**Ställ in triminställningar**

För att skapa en videoruta och ange dess triminställningar:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)klass.
1. Lägg till ett [IVideo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideo/)‑objekt i presentationen.
1. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/)‑objekt på en bild.
1. Ange trim‑from‑start och trim‑from‑end via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) och [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Spara den ändrade presentationen.

Följande kodexempel hoppar över de första 2,5 sekunderna och den sista sekunden av en inbäddad video under uppspelning:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Läs triminställningar**

För att inspektera befintliga triminställningar, ladda en presentation, hitta ett [IVideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/)‑objekt bland formerna på den första bilden och läs värdena via [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) och [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Följande kodexempel hittar den första videorutan på den första bilden och rapporterar dess triminställningar i millisekunder:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Hantera video‑textning**

Aspose.Slides låter dig hantera closed captions för videorutor i PowerPoint‑presentationer. Textningarna lagras i WebVTT‑format och exponeras via metoden [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Lägg till textning till en videoruta**

För att lägga till textning till en videoruta:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)klass.
1. Lägg till en video i presentationen.
1. Lägg till ett [IVideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/)‑objekt på en bild.
1. Använd den [ICaptionsCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/) som returneras av [getCaptionTracks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) för att lägga till ett WebVTT‑textningsspår.
1. Spara den ändrade presentationen.

Följande kod visar hur du lägger till textning till en videoruta:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Lägger till ett nytt textningsspår från en WebVTT-fil.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/)‑gränssnittet erbjuder också en överlagring som låter dig lägga till textning från en ström.

**Extrahera textning från en videoruta**

För att extrahera textning från en videoruta:

1. Ladda presentationen som innehåller videon.
1. Hitta mål‑[IVideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/)‑objektet.
1. Iterera igenom de textningsspår som returneras av [getCaptionTracks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Spara varje textningsspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar textning från en videoruta:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Sparar textningsspåret till en WebVTT-fil.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Varje [ICaptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptions/)‑objekt exponerar textnings‑identifieraren, etiketten, binärdata och textningsdata som en UTF‑8‑sträng.

**Ta bort textning från en videoruta**

För att ta bort textning från en videoruta:

1. Ladda presentationen som innehåller videon.
1. Hämta mål‑[IVideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/)‑objektet.
1. Ta bort textningsspår från den samling som returneras av [getCaptionTracks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Spara den ändrade presentationen.

Följande kod visar hur du tar bort all textning från en videoruta:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Tar bort all textning från videorutan.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om du bara behöver ta bort ett enskilt textningsspår, använd [remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) eller [removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) i stället för [clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/icaptionscollection/#clear--) .

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)klass för att ladda presentationen som innehåller videon.
2. Iterera genom alla [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/)‑objekt.
3. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)‑objekt för att hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/videoframe/) .
4. Spara videon på disk.

Denna Java‑kod visar hur du extraherar videon från en presentationsbild:

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

Du kan kontrollera [playback‑läget](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto eller vid klick) och [loopning](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Dessa alternativ är tillgängliga via egenskaperna på objektet [VideoFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/videoframe/) .

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas binärdata i dokumentet, vilket gör att presentationens storlek ökar i proportion till videons filstorlek. När du lägger till en online‑video bäddas en länk och en miniatyrbild in, så ökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [videoinnehållet](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) i rutan samtidigt som du behåller formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/video/#getContentType--) som du kan läsa och använda, t.ex. när du sparar den till disk.