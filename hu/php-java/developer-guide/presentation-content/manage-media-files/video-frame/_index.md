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
description: "Tanulja meg programozott módon videókeretek hozzáadását és kinyerését a PowerPoint és OpenDocument diákon az Aspose.Slides for PHP via Java segítségével. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó a bemutatóban meggyőzőbbé teheti az üzenetedet és növelheti a közönséged elköteleződését. 

A PowerPoint lehetővé teszi, hogy a prezentáció egy diájához videókat adj hozzá két módon:

* Helyi videó hozzáadása vagy beágyazása (a gépedre mentve)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

Annak érdekében, hogy videókat (videoobjektumokat) adhass a prezentációhoz, az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) osztályt és a hozzá kapcsolódó típusokat.

## **Beágyazott videókeretek létrehozása**

Ha a diához hozzáadni kívánt videofájl helyileg van tárolva, létrehozhatsz egy videókeretet, amelybe beágyazod a videót a prezentációban. 

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezd meg a dia referenciáját az indexe alapján. 
1. Adj hozzá egy [Video](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/) objektumot, és add meg a video fájl elérési útját a videó prezentációba való beágyazásához.
1. Adj hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot a videó számára keret létrehozásához.
1. Mentsd el a módosított prezentációt. 

Ez a PHP kód bemutatja, hogyan adhatunk hozzá egy helyi videót a prezentációhoz:

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

Alternatívaként a videót közvetlenül a [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addvideoframe/) metódusnak átadott fájlútvonal paraméterrel is hozzáadhatod:

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


## **Videókeretek létrehozása webes forrású videóval**

A Microsoft [PowerPoint 2013 és újabb verziói](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatják a YouTube videókat a prezentációkban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatod a prezentációhoz a webes hivatkozásán keresztül. 

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból
1. Szerezd meg a dia referenciáját az indexe alapján. 
1. Adj hozzá egy [Video](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/) objektumot, és add meg a videó hivatkozását.
1. Állíts be egy miniatűrt a videókerethez. 
1. Mentsd el a prezentációt. 

Ez a PHP kód bemutatja, hogyan adhatunk hozzá egy webről származó videót egy PowerPoint diahoz:

```php
  # Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
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

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint prezentációk videókereteihez zárt feliratokat kezelj. A feliratok WebVTT formátumban vannak tárolva, és a [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Feliratok videókerethez adásához:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Adj hozzá egy videót a prezentációhoz.
1. Adj hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot egy diára.
1. Használd a [CaptionsCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/) gyűjteményt, amelyet a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) ad vissza, hogy WebVTT feliratrajon legyen hozzáadva.
1. Mentsd el a módosított prezentációt.

Az alábbi kód bemutatja, hogyan adhatunk feliratokat egy videókerethez:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Új feliratrácsot ad hozzá egy WebVTT fájlból.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A [CaptionsCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/) osztály további túlterhelést is biztosít, amely lehetővé teszi, hogy a feliratokat adatfolyamból adjuk hozzá.

**Feliratok kinyerése videókeretből**

Feliratok kinyeréséhez egy videókeretből:

1. Töltsd be a videót tartalmazó prezentációt.
1. Találd meg a célzott [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot.
1. Iteráld végig a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) gyűjteményt.
1. Mentsd el minden feliratrajon egy `.vtt` fájlba.

Az alábbi kód bemutatja, hogyan nyerheted ki a feliratokat egy videókeretből:

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
                // Elmenti a feliratrácsot egy WebVTT fájlba.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Minden [Captions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF-8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Feliratok eltávolításához videókeretből:

1. Töltsd be a videót tartalmazó prezentációt.
1. Szerezd meg a célzott [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektumot.
1. Távolítsd el a feliratrajont a [getCaptionTracks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/#getCaptionTracks) gyűjteményből.
1. Mentsd el a módosított prezentációt.

Az alábbi kód bemutatja, hogyan távolíthatod el az összes feliratot egy videókeretből:

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

Ha csak egy feliratrajont kell eltávolítani, a [remove](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#removeAt) metódusokat használd a [clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diákból**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból a videót tartalmazó prezentáció betöltéséhez.
2. Iteráld végig az összes [Slide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) objektumot.
3. Iteráld végig az összes [Shape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/) objektumot, hogy megtaláld a [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) elemet.
4. Mentsd el a videót lemezre.

Ez a PHP kód bemutatja, hogyan nyerheted ki a videót egy prezentációs diárról:

```php
  # Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
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

**Mely videó lejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/setplaymode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/setplayloopmode/) beállításait tudod szabályozni. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan növekszik a fájlmérettel. Online videó hozzáadásakor csak egy hivatkozás és egy miniatűr kerül beágyazásra, ezért a méretnövekedés kisebb.

**Lecserélhetem a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A kereten belül kicserélheted a [video content](https://reference.aspose.com/slides/hu/php-java/aspose.slides/videoframe/setembeddedvideo/) elemet, miközben megőrzöd a forma geometriáját; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Megállapítható-e egy beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/hu/php-java/aspose.slides/video/getcontenttype/) információval, amelyet kiolvashatsz és felhasználhatsz, például lemezre mentéskor.