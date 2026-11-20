---
title: Správa video snímků v prezentacích pomocí PHP
linktitle: Video snímek
type: docs
weight: 10
url: /cs/php-java/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video snímek
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro PHP přes Java. Rychlý návod jak na to."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zaujmout publikum. Aspose.Slides pro PHP přes Java vám umožňuje přidávat snímky videa do snímků, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje lokální videa i odkazy na online videa, například videa na YouTube.

Pro reprezentaci video dat a snímků videa poskytuje Aspose.Slides třídu [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/), třídu [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) a další související typy.

## **Vytvořit vložený snímek videa**

Pokud je video soubor, který chcete přidat na snímek, uložen lokálně, můžete vytvořit snímek videa a vložit video do vaší prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry snímku jsou v bodech. Proud zůstává otevřený až do dokončení ukládání, protože [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) jej udržuje uzamčený, dokud je prezentace používá.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Můžete také předat cestu k lokálnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné až do uložení prezentace.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vytvořit snímek videa s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit snímek videa, který odkazuje na online video, například video z YouTube.

Tento příklad přidá odkaz na YouTube video a miniaturu na první snímek. Nahraďte identifikátor videa, pokud chcete použít jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) požaduje automatické přehrávání. Stahování miniatury a přehrávání videa vyžaduje připojení k internetu. Prohlížeč prezentací musí také podporovat přehrávání online videí.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Přehrát video v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) s `true`, čímž povolíte toto chování během přehrávání.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) na první snímek a povolí přehrávání na celou obrazovku. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na první snímku.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Přehrávání na celou obrazovku řídí, jak je video zobrazeno. Samostatně [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) určuje, zda se spustí automaticky nebo po kliknutí, a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) určuje, zda se opakuje. Pro výběr chování při spuštění nastavte režim přehrávání na [VideoPlayModePreset::Auto nebo VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení spuštění a opakování.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek připraví video pro další přehrání prezentátorem. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) s `true`, čímž vrátíte video na začátek po dokončení přehrávání.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) na první snímek a povolí přetočení. Zakáže opakování, aby přehrávání mohlo skončit, a nastaví přehrávání tak, aby se spouštělo po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na první snímku.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Přetočení vrátí video na začátek, aniž by jej okamžitě spustilo. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) s `true` způsobí automatické opakování přehrávání. Ponechte opakování zakázáno, pokud chcete, aby video skončilo a zůstalo připravené k opakovanému přehrání. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) samostatně řídí automatické nebo kliknutím spouštění; tento příklad používá [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) , takže prezentátor řídí, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení opakování, jak je ukázáno v příkladu. Přetočení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Uříznout snímek videa**

Použijte [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd), abyste během přehrávání přeskočili část začátku nebo konce videa. Obě hodnoty jsou v milisekundách. Oříznutí mění nastavení přehrávání, aniž by měnilo vložená video data.

**Nastavit nastavení oříznutí**

Tento příklad vloží lokální video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstala přehratelná část.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Přečíst nastavení oříznutí**

Tento příklad vytiskne hodnoty oříznutí prvního video snímku na první snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud daný snímek nemá video snímek, nic se nevytiskne. Předchozí příklad produkuje hodnoty 2500 a 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Spravovat titulky videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video snímky v prezentacích PowerPoint. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné pomocí metody [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

### **Přidat titulky k video snímku**

Tento příklad vloží lokální video a přidá stopu titulků WebVTT označenou English. Časové razítka titulků by měla odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) také poskytuje přetížení, které umožňuje přidávat titulky ze streamu.

### **Extrahovat titulky z video snímku**

Tento příklad uloží všechny stopy titulků z video snímků na první snímek jako samostatné soubory WebVTT. Postupná čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Každý objekt [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) poskytuje identifikátor titulku, značku, binární data a text titulku jako řetězec UTF-8.

### **Odstranit titulky z video snímku**

Tento příklad odstraní všechny titulky z video snímku na první pozici objektu na první snímku a uloží výsledek. Předpokládá, že snímek a objekt existují a že objekt je video snímek.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

### **Vyhledat titulky ve videu**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) vrací kompletní stopu WebVTT, včetně hlavičky, časových řádků a textu titulků. Můžete prohledávat signály v paměti a najít řečenou frázi a její časové razítko. Například anglická stopa na snímku 2 může obsahovat následující text.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Příklad otevře `captioned_media.pptx` a použije [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks), aby načetl stopy každého video snímku nejvyšší úrovně na každém snímku. V prostém textovém cue časová řádka obsahuje `-->` a prázdný řádek ukončuje cue. Když titulky obsahují “café” v jakékoliv velikosti písmen, příklad vytiskne číslo snímku, označení stopy, původní časovou řádku a celý titulek.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Vyhledávání “café” vytvoří jeden výsledek pro ukázkovou stopu. Vyhledávání vylučuje hlavičku stopy a zachovává nastavení časování ve výstupu.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahovat video ze snímku**

Kromě přidávání videí na snímky umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných číslovaných binárních souborů. Propojená videa jsou přeskočena, protože nemají vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte tak, aby odpovídala hlášenému typu média.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Jaké parametry přehrávání videa lze změnit pro video snímek?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (automaticky nebo po kliknutí) a [opakovatelnost](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Tyto možnosti jsou dostupné prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta v dokumentu, takže velikost prezentace roste úměrně k velikosti souboru. Když se odkazujete na online video a přidáte miniaturu, prezentace ukládá odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video snímku bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) uvnitř snímku při zachování geometrie objektu; toto je běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType), který můžete přečíst a použít, například při ukládání na disk.