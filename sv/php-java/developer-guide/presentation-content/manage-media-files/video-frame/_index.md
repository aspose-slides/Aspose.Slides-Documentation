---
title: Hantera videoramar i presentationer med PHP
linktitle: Videoram
type: docs
weight: 10
url: /sv/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Lär dig att programatiskt lägga till och extrahera videoramar i PowerPoint- och OpenDocument-bilder med Aspose.Slides för PHP via Java. Snabb guide."
---
## **Introduktion**

En väl placerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsnivåerna hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (sparad på din maskin)
* Lägg till en online-video (från en webbkälla såsom YouTube).

För att låta dig lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/) , klassen [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) och andra relevanta typer.

## **Skapa inbäddade videoramar**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa en videoram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/) -objekt och skicka videofilens sökväg för att bädda in videon i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) -objekt för att skapa en ram för videon.
1. Spara den ändrade presentationen. 

Denna PHP‑kod visar hur du lägger till en lokalt lagrad video i en presentation:

```php
  # Instansierar Presentation-klassen
  $pres = new Presentation("pres.pptx");
  try {
    # Laddar videon
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Hämtar den första bilden och lägger till en videoram
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Sparar presentationen till disk
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addvideoframe/) :

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

## **Skapa videoramar med video från webbkällor**

Microsoft [PowerPoint 2013 och senare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stödjer YouTube‑videor i presentationer. Om videon du vill använda finns online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) 
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/) -objekt och skicka länken till videon.
1. Ställ in en miniatyrbild för videoramen. 
1. Spara presentationen. 

Denna PHP‑kod visar hur du lägger till en video från webben till en bild i en PowerPoint‑presentation:

```php
  # Instansierar ett Presentation-objekt som representerar en presentationsfil
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

## **Trimma en videoram**

Aspose.Slides låter dig styra vilken del av en video som spelas upp genom att ange värdena trim-from-start och trim-from-end via [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#setTrimFromStart) och [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#setTrimFromEnd). Båda värdena anges i millisekunder och definierar hur mycket tid som hoppas över i början respektive slutet av videon. Dessa inställningar ändrar videouppspelningsinställningarna i presentationen; de klipper inte eller på annat sätt modifierar den inbäddade videons binära data.

**Ställ in triminställningar**

För att skapa en videoram och ange dess trim‑inställningar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/) -objekt i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) -objekt på en bild.
1. Ange värdena trim-from-start och trim-from-end via [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#setTrimFromStart) och [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Spara den ändrade presentationen.

Följande kodexempel hoppar över de första 2,5 sekunderna och den sista sekunden av en inbäddad video under uppspelning:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Läs triminställningar**

För att inspektera befintliga trim‑inställningar, öppna en presentation, hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) -objekt bland formerna på den första bilden, och läs värdena via [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getTrimFromStart) och [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getTrimFromEnd) .

Följande kodexempel hittar den första videoramen på den första bilden och rapporterar dess trim‑inställningar i millisekunder:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Hantera videobildtexter**

Aspose.Slides låter dig hantera stängda bildtexter för videoramar i PowerPoint‑presentationer. Bildtexter lagras i WebVTT‑format och exponeras via metoden [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks) .

**Lägg till bildtexter till en videoram**

För att lägga till bildtexter till en videoram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) .
1. Lägg till en video i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) -objekt på en bild.
1. Använd samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/) som returneras av [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks) för att lägga till ett WebVTT‑bildtextspår.
1. Spara den ändrade presentationen.

Följande kod visar hur du lägger till bildtexter till en videoram:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Lägger till ett nytt bildtextspår från en WebVTT-fil.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Klassen [CaptionsCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/) erbjuder också en överlagring som låter dig lägga till bildtexter från en ström.

**Extrahera bildtexter från en videoram**

För att extrahera bildtexter från en videoram:

1. Läs in presentationen som innehåller videon.
1. Hitta mål-[VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) -objektet.
1. Iterera genom samlingen [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks) .
1. Spara varje bildtextspår till en .vtt‑fil.

Följande kod visar hur du extraherar bildtexter från en videoram:

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
                // Sparar bildtextspåret till en WebVTT-fil.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Varje [Captions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captions/) -objekt exponerar bildtextens identifierare, etikett, binärdata och bildtext som en UTF‑8‑sträng.

**Ta bort bildtexter från en videoram**

För att ta bort bildtexter från en videoram:

1. Läs in presentationen som innehåller videon.
1. Hämta mål-[VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) -objektet.
1. Ta bort bildtextspår från samlingen [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks) .
1. Spara den ändrade presentationen.

Följande kod visar hur du tar bort alla bildtexter från en videoram:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // typ: VideoFrame

    // Tar bort alla bildtexter från videoramen.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om du bara behöver ta bort ett bildtextspår, använd metoderna [remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#removeAt) i stället för [clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från bilder**

Förutom att lägga till videor i bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att läsa in presentationen som innehåller videon.
2. Iterera genom alla [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/) -objekt.
3. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/) -objekt för att hitta en [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) .
4. Spara videon till disk.

Denna PHP‑kod visar hur du extraherar videon på en presentationsbild:

```php
  # Instansierar ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Hämtar filändelsen
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

**Vilka videouppspelningsparametrar kan ändras för en VideoFrame?**

Du kan styra [uppspelningsläget](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/setplaymode/) (auto eller vid klick) och [loopning](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/setplayloopmode/). Dessa alternativ är tillgängliga via objektets egenskaper på [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) .

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas binary‑data i dokumentet, så presentationens storlek ökar proportionellt mot filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyrbild in, så storleksökningen blir mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video‑innehållet](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/setembeddedvideo/) i ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/getcontenttype/) som du kan läsa och använda, till exempel när du sparar den till disk.