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

En välplacerad video i en presentation kan göra ditt budskap mer övertygande och öka engagemangsnivån hos din publik. 

PowerPoint låter dig lägga till videor på en bild i en presentation på två sätt:

* Lägg till eller bädda in en lokal video (lagrad på din maskin)
* Lägg till en online-video (från en webbkälla såsom YouTube).

För att låta dig lägga till videor (videoobjekt) i en presentation tillhandahåller Aspose.Slides klassen [Video](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/), klassen [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/) och andra relevanta typer.

## **Skapa inbäddade video‑ramar**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa en videoram för att bädda in videon i din presentation. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/)‑objekt och ange videofilens sökväg för att bädda in videon i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/)‑objekt för att skapa en ram för videon.
1. Spara den ändrade presentationen. 

Denna PHP‑kod visar hur du lägger till en lokalt lagrad video i en presentation:

```php
  # Skapar en instans av Presentation-klassen
  $pres = new Presentation("pres.pptx");
  try {
    # Läser in videon
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

Alternativt kan du lägga till en video genom att skicka dess filsökväg direkt till metoden [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addvideoframe/):

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


## **Skapa video‑ramar med video från webbkällor**

Microsoft [PowerPoint 2013 och senare](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) stöder YouTube‑videor i presentationer. Om videon du vill använda finns online (t.ex. på YouTube) kan du lägga till den i din presentation via dess webblänk. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett [Video](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/)‑objekt och ange länken till videon.
1. Ställ in en miniatyr för video‑ramen. 
1. Spara presentationen. 

Denna PHP‑kod visar hur du lägger till en video från webben på en bild i en PowerPoint‑presentation:

```php
  # Skapar ett Presentation-objekt som representerar en presentationsfil
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

## **Hantera video‑undertexter**

Aspose.Slides låter dig hantera stängda undertexter för video‑ramar i PowerPoint‑presentationer. Undertexterna lagras i WebVTT‑format och kan nås via metoden [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Lägg till undertexter på en video‑ram**

För att lägga till undertexter på en video‑ram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Lägg till en video i presentationen.
1. Lägg till ett [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/)-objekt på en bild.
1. Använd samlingen [CaptionsCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/) som returneras av [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks) för att lägga till ett WebVTT‑undertextspår.
1. Spara den ändrade presentationen.

Följande kod visar hur du lägger till undertexter på en video‑ram:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Lägger till ett nytt undertextspår från en WebVTT-fil.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Klassen [CaptionsCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/) erbjuder också en överlagring som låter dig lägga till undertexter från en ström.

**Extrahera undertexter från en video‑ram**

För att extrahera undertexter från en video‑ram:

1. Läs in presentationen som innehåller videon.
1. Hitta mål‑objektet [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/).
1. Iterera igenom samlingen [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Spara varje undertextspår till en `.vtt`‑fil.

Följande kod visar hur du extraherar undertexter från en video‑ram:

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
                // Sparar undertextspåret till en WebVTT-fil.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Varje [Captions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captions/)‑objekt exponerar undertextens identifierare, etikett, binära data och undertextens text som en UTF‑8‑sträng.

**Ta bort undertexter från en video‑ram**

För att ta bort undertexter från en video‑ram:

1. Läs in presentationen som innehåller videon.
1. Hämta mål‑objektet [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/).
1. Ta bort undertextspår från samlingen [getCaptionTracks](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Spara den ändrade presentationen.

Följande kod visar hur du tar bort alla undertexter från en video‑ram:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // typ: VideoFrame

    // Tar bort alla undertexter från videoramen.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om du bara behöver ta bort ett undertextspår, använd metoderna [remove](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#remove) eller [removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#removeAt) istället för [clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/captionscollection/#clear).

## **Extrahera video från bilder**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) för att läsa in presentationen som innehåller videon.
2. Iterera genom alla [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/)‑objekt.
3. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/)‑objekt för att hitta ett [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/).
4. Spara videon på disk.

Denna PHP‑kod visar hur du extraherar videon på en presentationsbild:

```php
  # Skapar ett Presentation-objekt som representerar en presentationsfil
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

Du kan styra [playback mode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/setplaymode/) (auto eller vid klick) och [looping](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/setplayloopmode/). Dessa alternativ är tillgängliga via egenskaperna för objektet [VideoFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/).

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas de binära data i dokumentet, vilket gör att presentationens storlek ökar i proportion till filens storlek. När du lägger till en online‑video bäddas en länk och en miniatyr in, så ökningen av storlek är mindre.

**Kan jag ersätta videon i en befintlig VideoFrame utan att ändra dess position och storlek?**

Ja. Du kan byta ut [video content](https://reference.aspose.com/slides/sv/php-java/aspose.slides/videoframe/setembeddedvideo/) inom ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/video/getcontenttype/) som du kan läsa och använda, till exempel när du sparar den på disk.