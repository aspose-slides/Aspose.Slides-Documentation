---
title: Beheer videoframes in presentaties op Android
linktitle: Videoframe
type: docs
weight: 10
url: /nl/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Leer hoe u via Java video-frames programmatisch kunt toevoegen en extraheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android. Snelle stapsgewijze handleiding."
---
## **Introductie**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en de betrokkenheid van uw publiek verhogen. 

PowerPoint stelt u in staat om video's toe te voegen aan een dia in een presentatie op twee manieren:

* Een lokale video toevoegen of insluiten (opgeslagen op uw computer)
* Een online video toevoegen (van een webbron zoals YouTube).

Om video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) interface en andere relevante typen.

## **Een ingebedde videoframe maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een videoframe maken om de video in uw presentatie in te sluiten. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)klasse.
1. Haal een referentie naar een dia op via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideo/) object toe en geef het pad van het videobestand op om de video in de presentatie in te sluiten.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) object toe om een frame voor de video te maken.
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

    // Slaat de presentatie op schijf
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

U kunt ook een video toevoegen door het bestandspad direct door te geven aan de [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) methode:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Een videoframe maken met video van een webbron**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video's in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de web‑link aan uw presentatie toevoegen. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)klasse
1. Haal een referentie naar een dia op via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideo/) object toe en geef de koppeling naar de video op.
1. Stel een miniatuurafbeelding in voor het videoframe.
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

    // Laadt miniatuur
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

## **Video‑bijschriften beheren**

Aspose.Slides stelt u in staat om ondertitels voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) methode.

**Ondertitels toevoegen aan een videoframe**

Om ondertitels aan een videoframe toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.
1. Voeg een video toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) object toe aan een dia.
1. Gebruik de [ICaptionsCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/) die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) om een WebVTT‑ondertiteltrack toe te voegen.
1. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u ondertitels aan een videoframe toevoegt:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuwe ondertiteltrack toe vanaf een WebVTT-bestand.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De [ICaptionsCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/) interface biedt ook een overload waarmee u ondertitels uit een stream kunt toevoegen.

**Ondertitels extraheren uit een videoframe**

Om ondertitels uit een videoframe te extraheren:

1. Laad de presentatie die de video bevat.
1. Zoek het doel-[IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) object.
1. Itereer door de ondertiteltracks die worden geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Sla elke ondertiteltrack op in een `.vtt`‑bestand.

De volgende code laat zien hoe u ondertitels uit een videoframe kunt extraheren:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Slaat de ondertiteltrack op in een WebVTT-bestand.
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

Elk [ICaptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptions/) object geeft de ondertitel‑identificatie, label, binaire gegevens en ondertitelgegevens weer als een UTF‑8‑string.

**Ondertitels verwijderen uit een videoframe**

Om ondertitels uit een videoframe te verwijderen:

1. Laad de presentatie die de video bevat.
1. Haal het doel-[IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) object op.
1. Verwijder ondertiteltracks uit de collectie die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u alle ondertitels uit een videoframe verwijdert:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Verwijdert alle ondertitels van het videoframe.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de [remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) methoden in plaats van [clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Video extraheren van een dia**

Naast het toevoegen van video's aan dia's, stelt Aspose.Slides u in staat om video's die in presentaties zijn ingebed te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse om de presentatie die de video bevat te laden.
2. Itereer door alle [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) objecten.
3. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/) te vinden.
4. Sla de video op schijf op.

Deze Java‑code laat zien hoe u de video van een presentatiedia kunt extraheren:

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

## **Veelgestelde vragen**

**Welke videoweergave‑parameters kunnen worden gewijzigd voor een VideoFrame?**

U kunt de [playback mode](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch of bij klik) en het [looping](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig groeit met de bestandsgrootte. Wanneer u een online video toevoegt, worden een link en een miniatuurafbeelding ingesloten, waardoor de toename van de grootte kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het inhoudstype (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/video/#getContentType--) die u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.