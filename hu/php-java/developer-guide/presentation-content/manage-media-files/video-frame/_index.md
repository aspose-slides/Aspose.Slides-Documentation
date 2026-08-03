---
title: Videókeretek kezelése prezentációkban PHP használatával
linktitle: Videókeret
type: docs
weight: 10
url: /hu/php-java/video-frame/
keywords:
- videó hozzáadása
- videó létrehozása
- videó beágyazása
- videó kinyerése
- videó lekérése
- videókeret
- webes forrás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg programozottan hozzáadni és kinyerni a videókereteket PowerPoint és OpenDocument diákból az Aspose.Slides for PHP via Java használatával. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó a prezentációban hatékonyabbá teheti az üzenetét, és növelheti a közönség elkötelezettségét.  

A PowerPoint két módon teszi lehetővé a videók hozzáadását egy diához a prezentációban:

* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

Annak érdekében, hogy videókat (videóobjektumokat) adhasson a prezentációhoz, az Aspose.Slides a [Video](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) osztályt és más releváns típusokat biztosít.

## **Beágyazott videókeretek létrehozása**

Ha a diára felvenni kívánt videofájl helyileg van tárolva, létrehozhat egy videókeretet a videó prezentációba való beágyazásához.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg egy dia referenciáját az indexe alapján.  
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/) objektumot, és adja meg a videófájl elérési útját a videó prezentációba való beágyazásához.  
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot a videó számára keret létrehozásához.  
1. Mentse a módosított prezentációt.  

Ez a PHP kód bemutatja, hogyan adjon hozzá egy helyileg tárolt videót a prezentációhoz:

```php
  # Létrehozza a Presentation osztályt
  $pres = new Presentation("pres.pptx");
  try {
    # Betölti a videót
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Lekéri az első diát és hozzáad egy videókeretet
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Elmenti a prezentációt a lemezre
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternatív megoldásként egy videót hozzáadhat a fájl elérési útját közvetlenül a [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addvideoframe/) metódusnak átadva:

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

## **Videókeretek létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube videókat a prezentációkban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatja a prezentációhoz a webes hivatkozásán keresztül.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból  
1. Szerezze meg egy dia referenciáját az indexe alapján.  
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/) objektumot, és adja meg a videó linkjét.  
1. Állítson be egy miniatűr képet a videókerethez.  
1. Mentse a prezentációt.  

Ez a PHP kód bemutatja, hogyan adjon hozzá egy webes videót a PowerPoint diához:

```php
  # Létrehozza a Presentation objektumot, amely egy prezentációs fájlt reprezentál
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

## **Videókeret vágása**

Az Aspose.Slides lehetővé teszi egy videó lejátszott részének vezérlését a trim-from-start és trim-from-end értékek beállításával a [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#setTrimFromEnd) metódusokon keresztül. Mindkét érték ezredmásodpercben van megadva, és meghatározza, hogy a videó elejéről és végéről mennyi időt hagyjon ki. Ezek a beállítások módosítják a videó lejátszási paramétereit a prezentációban; nem vágják vagy módosítják a beágyazott videó bináris adatát.

**Trim beállítások megadása**

Videókeret létrehozásához és a trim beállításainak megadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/) objektumot a prezentációhoz.  
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot egy diához.  
1. Állítsa be a trim-from-start és trim-from-end értékeket a [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#setTrimFromEnd) metódusokkal.  
1. Mentse a módosított prezentációt.  

A következő kódrészlet kihagyja egy beágyazott videó lejátszása során az első 2,5 másodpercet és az utolsó másodpercet:

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

**Trim beállítások olvasása**

A meglévő trim beállítások megtekintéséhez töltse be a prezentációt, keresse meg az első dián a [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot a formák között, és olvassa ki az értékeket a [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getTrimFromStart) és a [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getTrimFromEnd) metódusokkal.  

A következő kódrészlet megtalálja az első videókeretet az első dián, és ezredmásodpercben jelenti a trim beállításait:

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

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban vannak tárolva, és a [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) metódussal érhetők el.

**Feliratok hozzáadása egy videókerethez**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Adjon hozzá egy videót a prezentációhoz.  
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot egy diához.  
1. Használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/) gyűjteményt, amelyet a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) visszaad, egy WebVTT feliratsáv hozzáadásához.  
1. Mentse a módosított prezentációt.  

A következő kód bemutatja, hogyan adjon feliratokat egy videókerethez:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Új feliratsáv hozzáadása egy WebVTT fájlból.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A [CaptionsCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/) osztály egy túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy adatfolyamból.

**Feliratok kinyerése egy videókeretből**

1. Töltse be a videót tartalmazó prezentációt.  
1. Keresse meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot.  
1. Iteráljon a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) gyűjteményen.  
1. Mentse minden feliratsávot egy `.vtt` fájlba.  

A következő kód bemutatja, hogyan nyerheti ki a feliratokat egy videókeretből:

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
                // Mentse a feliratsávot egy WebVTT fájlba.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Minden [Captions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captions/) objektum a feliratazonosítót, a címkét, a bináris adatot és a feliratszöveget UTF-8 karakterláncként teszi elérhetővé.

**Feliratok eltávolítása egy videókeretből**

1. Töltse be a videót tartalmazó prezentációt.  
1. Szerezze meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot.  
1. Távolítsa el a feliratsávokat a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) gyűjteményből.  
1. Mentse a módosított prezentációt.  

A következő kód bemutatja, hogyan távolíthatja el az összes feliratot egy videókeretből:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // típus: VideoFrame

    // Eltávolítja az összes feliratot a videókeretből.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ha csak egy feliratsávot kíván eltávolítani, használja a [remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#removeAt) metódusokat a [clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diákból**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését is.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból a videót tartalmazó prezentáció betöltéséhez.  
2. Iteráljon az összes [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) objektumon.  
3. Iteráljon az összes [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumon egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) megtalálásához.  
4. Mentse a videót a lemezre.  

Ez a PHP kód bemutatja, hogyan nyerheti ki a videót egy prezentációs diáról:

```php
  # Létrehozza a Presentation objektumot, amely egy prezentációs fájlt reprezentál
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Lekéri a fájl kiterjesztését
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

## **GYIK**

**Milyen videólejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/setplaymode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/setplayloopmode/) beállításokat tudja vezérelni. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektum tulajdonságaiban érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájlmérettel. Ha online videót ad hozzá, egy hivatkozás és egy miniatűr kerül beágyazásra, ezért a méretnövekedés kisebb.

**Lecserélhetem egy meglévő VideoFrame videóját a pozíció és méret módosítása nélkül?**

Igen. A [video content](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/setembeddedvideo/) cseréjével a keretben megőrizheti a forma geometriáját; ez gyakori eset a médiák frissítésére egy meglévő elrendezésben.

**Meghatározható-e egy beágyazott videó tartalom típusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik egy [content type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/getcontenttype/) értékkel, amelyet leolvashat és felhasználhat, például a lemezre mentéskor.