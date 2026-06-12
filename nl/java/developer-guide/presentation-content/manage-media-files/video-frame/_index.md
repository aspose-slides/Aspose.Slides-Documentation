---
title: "Beheer videoframes in presentaties met Java"
linktitle: "Videoframe"
type: docs
weight: 10
url: /nl/java/video-frame/
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
- Java
- Aspose.Slides
description: "Leer om programmatisch videoframes toe te voegen en te extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor Java. Snelle handleiding."
---
## **Introductie**

Een goed geplaatste video in een presentatie kan uw boodschap krachtiger maken en de betrokkenheid van uw publiek verhogen. 

PowerPoint biedt twee manieren om video's aan een dia in een presentatie toe te voegen:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u in staat te stellen video's (video‑objecten) aan een presentatie toe te voegen, levert Aspose.Slides de [IVideo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/) interface en andere relevante typen. 

## **Maak ingesloten videoframes**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie te embedden. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)class.
1. Verkrijg een referentie naar een dia via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideo/) object toe en geef het pad naar het videobestand door om de video in de presentatie te embedden. 
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/) object toe om een frame voor de video te maken.  
1. Sla de gewijzigde presentatie op. 

Deze Java‑code laat zien hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```java
// Instantieert de Presentation-klasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Laadt de video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Haalt de eerste dia op en voegt een videoframe toe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Slaat de presentatie op naar schijf
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) methode:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Maak videoframes met video van webbronnen**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video's in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze aan uw presentatie toevoegen via de web‑link. 

1. Maak een instantie van [Presentation ](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)class
1. Verkrijg een referentie naar een dia via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideo/) object toe en geef de link naar de video door.
1. Stel een miniatuur­afbeelding in voor het videoframe. 
1. Sla de presentatie op. 

Deze Java‑code laat zien hoe u een video van het web aan een dia in een PowerPoint‑presentatie toevoegt:

```java
// Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt
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
    // Voegt een videoframe toe
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Laadt miniatuurafbeelding
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

## **Beheer video‑onderschriften**

Aspose.Slides maakt het mogelijk om ondertitels (closed captions) voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) methode.

**Ondertitels aan een videoframe toevoegen**

Om ondertitels aan een videoframe toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) class.
1. Voeg een video toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/) object toe aan een dia.
1. Gebruik de [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/) die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) om een WebVTT‑ondertiteltrack toe te voegen.
1. Sla de gewijzigde presentatie op.

De volgende code toont hoe u ondertitels aan een videoframe toevoegt:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuw ondertiteltrack toe vanuit een WebVTT-bestand.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/) interface biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels uit een videoframe extraheren**

Om ondertitels uit een videoframe te extraheren:

1. Laad de presentatie die de video bevat.
1. Zoek het doel-[IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/) object.
1. Loop door de ondertitel‑tracks in de [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/).
1. Sla elke ondertitel‑track op als een `.vtt`‑bestand.

De volgende code toont hoe u ondertitels uit een videoframe extrahert:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Slaat het ondertiteltrack op als een WebVTT-bestand.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Elk [ICaptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptions/) object geeft de ondertitel‑identifier, het label, de binaire data en de ondertiteltekst als een UTF‑8‑string weer.

**Ondertitels uit een videoframe verwijderen**

Om ondertitels uit een videoframe te verwijderen:

1. Laad de presentatie die de video bevat.
1. Verkrijg het doel-[IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/) object.
1. Verwijder ondertitel‑tracks uit de [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/).
1. Sla de gewijzigde presentatie op.

De volgende code toont hoe u alle ondertitels uit een videoframe verwijdert:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Verwijdert alle ondertitels uit het videoframe.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één ondertitel‑track wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#removeAt-int-) methode in plaats van [clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#clear--).

## **Video extraheren uit dia's**

Naast het toevoegen van video's aan dia's, maakt Aspose.Slides het mogelijk om video's die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) class om de presentatie met de video te laden. 
2. Loop door alle [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/) objecten.
3. Loop door alle [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/) te vinden. 
4. Sla de video op schijf.

Deze Java‑code laat zien hoe u de video uit een presentatiedia extrahert:

```java
// Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt 
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

                // Haalt de bestandsextensie op
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

**Welke afspeel‑parameters kunnen voor een VideoFrame worden aangepast?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch of bij klik) en de [herhaalmodus](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video embedt, worden de binaire gegevens in het document opgenomen, waardoor de presentatiesize evenredig toeneemt met de bestandsgrootte. Wanneer u een online video toevoegt, worden alleen een link en een miniatuur‑afbeelding ingebed, waardoor de toename kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder positie en grootte te wijzigen?**

Ja. U kunt de [video‑inhoud](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/video/#getContentType--) dat u kunt uitlezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.