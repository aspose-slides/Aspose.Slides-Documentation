---
title: Beheer video‑frames in presentaties op Android
linktitle: Video‑frame
type: docs
weight: 10
url: /nl/androidjava/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video‑frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u video‑frames via code kunt toevoegen en extraheren in PowerPoint- en OpenDocument‑dia's met Aspose.Slides voor Android via Java. Snelle stapsgewijze handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en het betrokkenheidsniveau van uw publiek verhogen. 

PowerPoint stelt u in staat om video's op twee manieren aan een dia in een presentatie toe te voegen:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u in staat te stellen video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de interface [IVideo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideo/) , de interface [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/) , en andere relevante typen.

## **Maak een ingebedde video‑frame**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie in te sluiten. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)klasse.
1. Haal de referentie van een dia op via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideo/)‑object toe en geef het pad naar het videobestand door om de video in de presentatie in te sluiten.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/)‑object toe om een frame voor de video te maken.
1. Sla de aangepaste presentatie op. 

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

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de methode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **Maak een video‑frame met video van een webbron**

Nieuwere versies van Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunen online video’s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de web‑link aan uw presentatie toevoegen.

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)klasse
1. Haal de referentie van een dia op via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideo/)‑object toe en geef de link naar de video door.
1. Stel een miniatuurafbeelding in voor het video‑frame. 
1. Sla de presentatie op. 

Deze Java‑code laat zien hoe u een video van het internet aan een dia in een PowerPoint‑presentatie toevoegt:

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

    // Laadt thumbnail
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

## **Trimmen van een video‑frame**

Aspose.Slides stelt u in staat om te bepalen welk deel van een video wordt afgespeeld door de waarden trim‑from‑start en trim‑from‑end in te stellen via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-). Beide waarden worden opgegeven in milliseconden en geven aan hoeveel tijd vanaf het begin respectievelijk het einde van de video wordt overgeslagen. Deze instellingen wijzigen de afspeelinstellingen van de video in de presentatie; ze knippen of wijzigen de ingebedde videobinaire gegevens niet.

**Instellen van trim‑instellingen**

Om een video‑frame te maken en de trim‑instellingen in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideo/)‑object toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/)‑object toe aan een dia.
1. Stel de waarden trim‑from‑start en trim‑from‑end in via [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) en [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-).
1. Sla de aangepaste presentatie op.

Het volgende code‑voorbeeld slaat de eerste 2,5 seconde en de laatste seconde van een ingebedde video over tijdens het afspelen:

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

**Lezen van trim‑instellingen**

Om bestaande trim‑instellingen te inspecteren, laad een presentatie, zoek een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/)‑object tussen de vormen op de eerste dia en lees de waarden uit via [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) en [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--).

Het volgende code‑voorbeeld vindt het eerste video‑frame op de eerste dia en rapporteert de trim‑instellingen in milliseconden:

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

## **Beheer van video‑onderschriften**

Aspose.Slides stelt u in staat om gesloten ondertitels voor video‑frames in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Ondertitels toevoegen aan een video‑frame**

Om ondertitels aan een video‑frame toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
1. Voeg een video toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/)‑object toe aan een dia.
1. Gebruik de [ICaptionsCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/) die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) om een WebVTT‑ondertiteltrack toe te voegen.
1. Sla de aangepaste presentatie op.

De volgende code laat zien hoe u ondertitels aan een video‑frame toevoegt:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Voegt een nieuw ondertiteltrack toe vanaf een WebVTT-bestand.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De interface [ICaptionsCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/) biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels extraheren uit een video‑frame**

Om ondertitels uit een video‑frame te extraheren:

1. Laad de presentatie die de video bevat.
1. Zoek het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/)‑object.
1. Loop door de ondertiteltracks die worden geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Sla elke ondertiteltrack op als een `.vtt`‑bestand.

De volgende code laat zien hoe u ondertitels uit een video‑frame extrahert:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Slaat het ondertiteltrack op naar een WebVTT-bestand.
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

Elk [ICaptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptions/)‑object geeft de ondertitel‑identifier, label, binaire gegevens en ondertitelgegevens als een UTF‑8‑string weer.

**Ondertitels verwijderen uit een video‑frame**

Om ondertitels uit een video‑frame te verwijderen:

1. Laad de presentatie die de video bevat.
1. Haal het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/)‑object op.
1. Verwijder ondertiteltracks uit de collectie die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).
1. Sla de aangepaste presentatie op.

De volgende code laat zien hoe u alle ondertitels uit een video‑frame verwijdert:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // Verwijdert alle ondertitels van het video‑frame.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) of [removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) in plaats van [clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icaptionscollection/#clear--).

## **Video extraheren uit een dia**

Naast het toevoegen van video's aan dia’s, stelt Aspose.Slides u in staat om video's die in presentaties zijn ingebed te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)‑klasse om de presentatie te laden die de video bevat.
2. Doorloop alle [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/)‑objecten.
3. Doorloop alle [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/) te vinden.
4. Sla de video op schijf.

Deze Java‑code laat zien hoe u de video op een presentatiedia extrahereert:

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

                //Haalt de bestandsextensie op
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

**Welke video‑afspeelparameters kunnen worden gewijzigd voor een VideoFrame?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatisch of bij klik) en [herhalen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de grootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video embed, worden de binaire gegevens in het document opgenomen, waardoor de presentatiesgrootte evenredig met de bestandsgrootte groeit. Wanneer u een online video toevoegt, worden een link en een miniatuurafbeelding ingesloten, waardoor de toename van de grootte kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video‑inhoud](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay‑out.

**Kan het contenttype (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content type](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/video/#getContentType--) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.