---
title: Správa video rámců v prezentacích pomocí PHP
linktitle: Video Rámec
type: docs
weight: 10
url: /cs/php-java/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámec
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámce v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro PHP přes Java. Rychlý praktický návod."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaši zprávu přesvědčivější a zvýšit úroveň zapojení publika. 

PowerPoint vám umožňuje přidat videa na snímek v prezentaci dvěma způsoby:

* Přidat nebo vložit místní video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, například YouTube).

Aby vám umožnil přidávat videa (video objekty) do prezentace, Aspose.Slides poskytuje třídu [Video](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) a další související typy.

## **Vytvoření vložených video rámců**

Pokud je video soubor, který chcete přidat na snímek, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace. 

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/) a předávejte cestu k video souboru k vložení videa do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) , aby se vytvořil rámec pro video.
1. Uložte upravenou prezentaci. 

Tento PHP kód ukazuje, jak přidat lokálně uložené video do prezentace:

```php
  # Vytváří instanci třídy Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Načte video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Získá první snímek a přidá video rámec
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Uloží prezentaci na disk
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternativně můžete přidat video předáním cesty k souboru přímo metodě [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addvideoframe/) :

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

## **Vytvoření video rámců s videem z webových zdrojů**

Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej do prezentace přidat prostřednictvím jeho webového odkazu. 

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/) a předávejte odkaz na video.
1. Nastavte miniaturu pro video rámec. 
1. Uložte prezentaci. 

Tento PHP kód ukazuje, jak přidat video z webu na snímek v PowerPoint prezentaci:

```php
  # Vytvoří objekt Presentation, který představuje soubor prezentace
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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat skryté titulky pro video rámy v PowerPoint prezentacích. Titulky jsou ukládány ve formátu WebVTT a jsou přístupné prostřednictvím metody [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getCaptionTracks) .

**Přidání titulků do video rámce**

Jak přidat titulky do video rámce:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Přidejte video do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) na snímek.
1. Použijte kolekci [CaptionsCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/) , vrácenou metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getCaptionTracks) , k přidání WebVTT titulkového stopy.
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Přidá novou titulkovou stopu ze souboru WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/) také poskytuje přetížení, které vám umožní přidat titulky ze streamu.

**Extrahování titulků z video rámce**

Jak extrahovat titulky z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Najděte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) .
1. Iterujte přes kolekci [getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getCaptionTracks) .
1. Uložte každou titulkovou stopu do souboru `.vtt` .

Následující kód ukazuje, jak extrahovat titulky z video rámce:

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
                // Uloží titulkovou stopu do souboru WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Každý objekt [Captions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captions/) poskytuje identifikátor titulku, popisek, binární data a text titulku jako řetězec UTF-8.

**Odstranění titulků z video rámce**

Jak odstranit titulky z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Získejte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) .
1. Odstraňte titulkové stopy z kolekce [getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getCaptionTracks) .
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky z video rámce:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // typ: VideoFrame

    // Odstraní všechny titulky z video rámce.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pokud potřebujete odstranit pouze jednu titulkovou stopu, použijte metodu [remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#clear).

## **Extrahování videa ze snímků**

Kromě přidávání videí na snímky vám Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) , abyste načetli prezentaci obsahující video.
2. Iterujte přes všechny objekty [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) .
3. Iterujte přes všechny objekty [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) , abyste našli [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) .
4. Uložte video na disk.

Tento PHP kód ukazuje, jak extrahovat video ze snímku prezentace:

```php
  # Vytvoří objekt Presentation, který představuje soubor prezentace
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Získá příponu souboru
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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/setplaymode/) (automaticky nebo při kliknutí) a [opakování](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/setplayloopmode/). Tyto možnosti jsou k dispozici prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) .

**Má přidání videa vliv na velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, jsou vloženy pouze odkaz a miniatura, takže nárůst velikosti je menší.

**Mohu nahradit video ve stávajícím VideoFrame bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [obsah videa](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/setembeddedvideo/) uvnitř rámce, při zachování geometrie tvaru; jedná se o běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/getcontenttype/) , který můžete číst a použít, například při ukládání na disk.