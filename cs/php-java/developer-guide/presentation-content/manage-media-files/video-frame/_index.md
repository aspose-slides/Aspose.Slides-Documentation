---
title: Správa video rámců v prezentacích pomocí PHP
linktitle: Video rámec
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
description: "Naučte se programově přidávat a extrahovat video rámy v snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Rychlý návod krok za krokem."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaši zprávu poutavější a zvýšit úroveň zapojení publika. 

PowerPoint vám umožňuje přidat videa do snímku v prezentaci dvěma způsoby:

* Přidat nebo vložit lokální video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, např. YouTube).

Aby vám umožnila přidávat videa (video objekty) do prezentace, poskytuje Aspose.Slides třídu [Video](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) a další relevantní typy.

## **Vytvoření vložených video rámců**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/) a předávejte cestu k video souboru pro vložení videa do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) pro vytvoření rámce pro video.
1. Uložte upravenou prezentaci. 

Tento PHP kód ukazuje, jak přidat lokálně uložené video do prezentace:

```php
  # Vytváří instanci třídy Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Načítá video
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Získá první snímek a přidá video rámec
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Ukládá prezentaci na disk
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Alternativně můžete přidat video předáním jeho cesty k souboru přímo metodě [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addvideoframe/) :

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

Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej do prezentace přidat pomocí jeho webového odkazu. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Získejte referenci na snímek pomocí jeho indexu. 
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/) a předávejte odkaz na video.
1. Nastavte miniaturu pro video rámec. 
1. Uložte prezentaci. 

Tento PHP kód ukazuje, jak přidat video z webu do snímku v PowerPoint prezentaci:

```php
  # Vytváří objekt Presentation, který představuje soubor prezentace
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

## **Oříznutí video rámce**

Aspose.Slides vám umožňuje řídit, která část videa se přehrává, nastavením hodnot trim-from-start a trim-from-end pomocí [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#setTrimFromEnd) . Obě hodnoty jsou udávány v milisekundách a definují, kolik času se přeskočí od začátku a konce videa. Tato nastavení mění nastavení přehrávání videa v prezentaci; neřezají ani jinak nemodifikují binární data vloženého videa.

**Nastavení oříznutí**

Pro vytvoření video rámce a nastavení jeho oříznutí:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/) do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) na snímek.
1. Nastavte hodnoty trim-from-start a trim-from-end pomocí [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#setTrimFromEnd) .
1. Uložte upravenou prezentaci.

Následující ukázka kódu přeskočí prvních 2,5 sekundy a poslední sekundu vloženého videa během přehrávání:

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

**Čtení nastavení oříznutí**

Pro prozkoumání existujících nastavení oříznutí načtěte prezentaci, najděte objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) mezi tvary na prvním snímku a přečtěte hodnoty pomocí [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getTrimFromStart) a [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getTrimFromEnd) .

Následující ukázka kódu najde první video rámec na prvním snímku a vypíše jeho nastavení oříznutí v milisekundách:

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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat skryté titulky pro video rámce v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné prostřednictvím metody [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getCaptionTracks) .

**Přidání titulků do video rámce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) .
1. Přidejte video do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) na snímek.
1. Použijte kolekci [CaptionsCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/) , která je vrácena metodou [getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getCaptionTracks) , k přidání WebVTT titulkové stopy.
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Přidá novou stopu titulků ze souboru WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/) také poskytuje přetížení, které vám umožní přidat titulky ze streamu.

**Extrahování titulků z video rámce**

1. Načtěte prezentaci, která obsahuje video.
1. Najděte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) .
1. Projděte kolekci [getCaptionTracks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/#getCaptionTracks) .
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
                // Uloží stopu titulků do souboru WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Každý objekt [Captions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captions/) zveřejňuje identifikátor titulků, štítek, binární data a text titulků jako řetězec UTF-8.

**Odstranění titulků z video rámce**

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

Pokud potřebujete odstranit jen jednu titulkovou stopu, použijte metodu [remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/captionscollection/#clear) .

## **Extrahování videa ze snímků**

Kromě přidávání videí do snímků vám Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) pro načtení prezentace obsahující video.
2. Projděte všechny objekty [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) .
3. Projděte všechny objekty [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) , abyste našli [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) .
4. Uložte video na disk.

Tento PHP kód ukazuje, jak extrahovat video ze snímku prezentace:

```php
  # Instancuje objekt Presentation, který představuje soubor prezentace
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

**Které parametry přehrávání videa lze změnit u VideoFrame?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/setplaymode/) (automaticky nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/setplayloopmode/) . Tyto možnosti jsou dostupné prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/) .

**Zvyšuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta v dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, je vložen odkaz a miniatura, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [obsah videa](https://reference.aspose.com/slides/cs/php-java/aspose.slides/videoframe/setembeddedvideo/) v rámci rámce při zachování geometrie tvaru; jedná se o běžný scénář aktualizace média v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/video/getcontenttype/) , který můžete přečíst a použít, např. při ukládání na disk.