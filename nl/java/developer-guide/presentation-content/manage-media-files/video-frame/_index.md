---
title: Video frames beheren in presentaties met Java
linktitle: Video frame
type: docs
weight: 10
url: /nl/java/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u programmatisch video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Java. Snel stappenplan."
---
## **Inleiding**

Een goed geplaatst video‑fragment in een presentatie kan uw boodschap krachtiger maken en de betrokkenheid van uw publiek verhogen. 

PowerPoint biedt u twee manieren om video's toe te voegen aan een dia in een presentatie:

* Een lokale video toevoegen of insluiten (opgeslagen op uw computer)
* Een online video toevoegen (van een webbron zoals YouTube).

Om u in staat te stellen video's (video‑objecten) aan een presentatie toe te voegen, levert Aspose.Slides de [IVideo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideo/)‑interface, de [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/)‑interface en andere relevante typen. 

## **Ingebedde videokaders maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videokader maken om de video in uw presentatie in te sluiten. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideo/)‑object toe en geef het bestandspad van de video op om de video in de presentatie in te sluiten.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/)‑object toe om een kader voor de video te maken.  
1. Sla de aangepaste presentatie op. 

Deze Java‑code toont hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```java
// Instantieert de Presentation-klasse
Presentation pres = new Presentation("pres.pptx");
try {
    // Laadt de video
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Haalt de eerste dia op en voegt een videokader toe
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Slaat de presentatie op naar schijf
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

U kunt bovendien een video toevoegen door direct het bestandspad door te geven aan de [addVideoFrame(float x,float y,float width,float height,IVideo video)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)‑methode:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Videokaders maken met video van webbronnen**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video’s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de weblink aan uw presentatie toevoegen. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideo/)‑object toe en geef de link naar de video op.
1. Stel een miniatuurafbeelding in voor het videokader.
1. Sla de presentatie op. 

Deze Java‑code toont hoe u een video van het web toevoegt aan een dia in een PowerPoint‑presentatie:

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
    // Voegt een videoFrame toe
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

## **Een videokader trimmen**

Aspose.Slides laat u bepalen welk deel van een video wordt afgespeeld door de waarden *trim‑from‑start* en *trim‑from‑end* in te stellen via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Beide waarden worden opgegeven in milliseconden en bepalen hoeveel tijd respectievelijk aan het begin en het einde van de video wordt overgeslagen. Deze instellingen wijzigen het afspeelgedrag in de presentatie; ze knippen of wijzigen de binaire video‑data niet.

**Triminstellingen toepassen**

Om een videokader te maken en de trim‑instellingen toe te passen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideo/)‑object toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/)‑object toe aan een dia.
1. Stel de *trim‑from‑start*‑ en *trim‑from‑end*‑waarden in via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Sla de aangepaste presentatie op.

De volgende code‑voorbeeld slaat de eerste 2,5 secondes en de laatste seconde van een ingesloten video over tijdens het afspelen:

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

**Triminstellingen lezen**

Om bestaande trim‑instellingen te inspecteren, laad een presentatie, zoek een [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/)‑object onder de vormen op de eerste dia, en lees de waarden via [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) en [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

De volgende code‑voorbeeld vindt het eerste videokader op de eerste dia en geeft de trim‑instellingen in milliseconden weer:

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

## **Videobijschriften beheren**

Aspose.Slides stelt u in staat gesloten bijschriften voor videokaders in PowerPoint‑presentaties te beheren. Bijschriften worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--)‑methode.

**Bijschriften aan een videokader toevoegen**

Om bijschriften aan een videokader toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
1. Voeg een video toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/)‑object toe aan een dia.
1. Gebruik de [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/) die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) om een WebVTT‑bijschriftenspoor toe te voegen.
1. Sla de aangepaste presentatie op.

De volgende code toont hoe u bijschriften aan een videokader toevoegt:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuw bijschriftenspoor toe vanuit een WebVTT-bestand.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/)‑interface biedt ook een overload waarmee u bijschriften vanuit een stream kunt toevoegen.

**Bijschriften uit een videokader extraheren**

Om bijschriften uit een videokader te extraheren:

1. Laad de presentatie die de video bevat.
1. Zoek het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/)‑object.
1. Doorloop de bijschriftensporen in de [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/).
1. Sla elke bijschriftenspoor op als een `.vtt`‑bestand.

De volgende code toont hoe u bijschriften uit een videokader extraheren:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Slaat het bijschriftenspoor op naar een WebVTT-bestand.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Elk [ICaptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptions/)‑object exposeert de bijschrift‑identifier, label, binaire data en de bijschrift‑tekst als een UTF‑8‑string.

**Bijschriften uit een videokader verwijderen**

Om bijschriften uit een videokader te verwijderen:

1. Laad de presentatie die de video bevat.
1. Verkrijg het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ivideoframe/)‑object.
1. Verwijder de bijschriftensporen uit de [ICaptionsCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/).
1. Sla de aangepaste presentatie op.

De volgende code toont hoe u alle bijschriften uit een videokader verwijdert:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Verwijdert alle bijschriften van het videokader.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één bijschriftenspoor wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#removeAt-int-)‑methoden in plaats van [clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icaptionscollection/#clear--).

## **Video uit dia's extraheren**

Naast het toevoegen van video's aan dia's, maakt Aspose.Slides het mogelijk om ingesloten video's uit presentaties te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation)‑klasse om de presentatie met de video te laden. 
2. Doorloop alle [ISlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/)‑objecten.
3. Doorloop alle [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/) te vinden. 
4. Sla de video op schijf.

Deze Java‑code toont hoe u de video van een presentatiedia kunt extraheren:

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

**Welke afspeelparameters kunnen worden aangepast voor een VideoFrame?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch of bij klik) en de [herhaal‑instelling](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) aanpassen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video insluit, worden de binaire data in het document opgenomen, waardoor de presentatiegrootte evenredig stijgt met de bestandsgrootte. Wanneer u een online video toevoegt, worden alleen een link en een miniatuurafbeelding ingesloten, waardoor de toename kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video‑inhoud](https://reference.aspose.com/slides/nl/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario bij het bijwerken van media in een bestaande lay‑out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content‑type](https://reference.aspose.com/slides/nl/java/com.aspose.slides/video/#getContentType--) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.