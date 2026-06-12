---
title: Video‑frames beheren in presentaties met PHP
linktitle: Video‑frame
type: docs
weight: 10
url: /nl/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Leer hoe u programmatically video‑frames kunt toevoegen en extraheren in PowerPoint‑ en OpenDocument‑slides met Aspose.Slides voor PHP via Java. Snelle stapsgewijze handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en het betrokkenheidsniveau van uw publiek verhogen. 

PowerPoint stelt u in staat om video’s aan een dia in een presentatie toe te voegen op twee manieren:

* Voeg een lokale video toe of embed een lokale video (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u in staat te stellen video‑objecten aan een presentatie toe te voegen, biedt Aspose.Slides de klasse [Video](https://reference.aspose.com/slides/nl/php-java/aspose.slides/video/) , de klasse [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) en andere relevante types.

## **Maak Ingesloten Video‑frames**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie in te sluiten. 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) aan.  
1. Haal een verwijzing naar een dia op via de index.  
1. Voeg een [Video](https://reference.aspose.com/slides/nl/php-java/aspose.slides/video/) object toe en geef het pad naar het videobestand door om de video in de presentatie in te sluiten.  
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) object toe om een frame voor de video te maken.  
1. Sla de gewijzigde presentatie op. 

Deze PHP‑code laat zien hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```php
  # Instantieert de Presentation-klasse
  $pres = new Presentation("pres.pptx");
  try {
    # Laadt de video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Haalt de eerste dia op en voegt een video-frame toe
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Slaat de presentatie op naar schijf
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de methode [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/addvideoframe/):

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Video‑frames Maken met Video van Webbronnen**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video’s in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de web‑link aan uw presentatie toevoegen. 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) aan.  
1. Haal een verwijzing naar een dia op via de index.  
1. Voeg een [Video](https://reference.aspose.com/slides/nl/php-java/aspose.slides/video/) object toe en geef de link naar de video door.  
1. Stel een miniatuurafbeelding in voor het video‑frame.  
1. Sla de presentatie op. 

Deze PHP‑code laat zien hoe u een video van het internet aan een dia in een PowerPoint‑presentatie toevoegt:

```php
  # Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Video‑bijschriften Beheren**

Aspose.Slides stelt u in staat om ondertitels voor video‑frames in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en kunnen worden benaderd via de methode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Ondertitels aan een Video‑frame Toevoegen**

Om ondertitels aan een video‑frame toe te voegen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) aan.  
1. Voeg een video toe aan de presentatie.  
1. Voeg een [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) object toe aan een dia.  
1. Gebruik de collectie [CaptionsCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/) die wordt geretourneerd door [getCaptionTracks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/#getCaptionTracks) om een WebVTT‑ondertiteltrack toe te voegen.  
1. Sla de gewijzigde presentatie op. 

De volgende code laat zien hoe u ondertitels aan een video‑frame toevoegt:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Voegt een nieuw ondertiteltrack toe vanuit een WebVTT-bestand.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De klasse [CaptionsCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/) biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels uit een Video‑frame Extraheren**

Om ondertitels uit een video‑frame te extraheren:

1. Laad de presentatie die de video bevat.  
1. Zoek het doel-[VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) object.  
1. Itereer door de collectie [getCaptionTracks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/#getCaptionTracks).  
1. Sla elke ondertiteltrack op naar een `.vtt`‑bestand.  

De volgende code laat zien hoe u ondertitels uit een video‑frame kunt extraheren:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Slaat het ondertiteltrack op naar een WebVTT-bestand.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Elk [Captions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captions/) object geeft de ondertitel‑identifier, label, binaire gegevens en de ondertiteltekst weer als een UTF‑8‑string.

**Ondertitels uit een Video‑frame Verwijderen**

Om ondertitels uit een video‑frame te verwijderen:

1. Laad de presentatie die de video bevat.  
1. Haal het doel-[VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) object op.  
1. Verwijder ondertitel‑tracks uit de collectie [getCaptionTracks](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/#getCaptionTracks).  
1. Sla de gewijzigde presentatie op.  

De volgende code laat zien hoe u alle ondertitels uit een video‑frame kunt verwijderen:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // type: VideoFrame

    // Verwijdert alle ondertitels van het video-frame.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [remove](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/#remove) of [removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/#removeAt) in plaats van [clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/captionscollection/#clear).

## **Video Uit Dia’s Extraheren**

Naast het toevoegen van video’s aan dia’s, stelt Aspose.Slides u in staat om video’s die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) aan om de presentatie met de video te laden.  
2. Itereer door alle [Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slide/) objecten.  
3. Itereer door alle [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) te vinden.  
4. Sla de video op naar schijf.  

Deze PHP‑code laat zien hoe u de video van een presentatiedia kunt extraheren:

```php
  # Instantieert een Presentation-object dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Haalt de bestandsextensie op
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welke afspeelparameters van een video kunnen worden aangepast voor een VideoFrame?**

U kunt de [playback mode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/setplaymode/) (auto of bij klikken) en [looping](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/setplayloopmode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van het PPTX‑bestand?**

Ja. Wanneer u een lokale video insluit, worden de binaire gegevens in het document opgenomen, waardoor de presentatiegrootte evenredig toeneemt met de bestandsgrootte. Wanneer u een online video toevoegt, worden alleen een link en een miniatuurafbeelding ingesloten, waardoor de toename van de grootte kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/nl/php-java/aspose.slides/videoframe/setembeddedvideo/) binnen het frame vervangen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/video/getcontenttype/) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.