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
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro PHP přes Java. Rychlý návod."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zaujmout publikum. Aspose.Slides pro PHP přes Java vám umožňuje přidávat video snímky do snímků, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje lokální videa i odkazy na online videa, například videa na YouTube.

K reprezentaci video dat a video snímků poskytuje Aspose.Slides třídu [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) a další relevantní typy.

## **Vytvořit vložený video snímek**

Pokud je video soubor, který chcete přidat do snímku, uložen místně, můžete vytvořit video snímek pro vložení videa do vaší prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry snímku jsou v bodech. Proud zůstává otevřený až do dokončení ukládání, protože [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) jej udržuje uzamčený, dokud ho prezentace používá.

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

## **Vytvořit video snímek s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video snímek, který odkazuje na online video, například video na YouTube.

Tento příklad přidá odkaz na YouTube video a náhledový obrázek na první snímek. Nahraďte identifikátor videa, abyste použili jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) požaduje automatické přehrávání. Stažení náhledu a přehrání videa vyžadují přístup k internetu. Prohlížeč prezentací také musí podporovat přehrávání online videa.

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

## **Přehrát video v režimu na celou obrazovku**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu na celou obrazovku, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) s `true`, abyste během přehrávání povolili toto chování.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) na první snímku a povolí přehrávání na celou obrazovku. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na první snímku.

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

Přehrávání na celou obrazovku určuje, jak je video zobrazeno. Samostatně metoda [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) řídí, zda se spustí automaticky nebo po kliknutí, a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) určuje, zda se opakuje. Pro výběr chování při spuštění nastavte režim přehrávání na [VideoPlayModePreset::Auto nebo VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). Příklad zachovává existující nastavení startu a opakování.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení ukázkového videa na začátek jej připraví pro další přehrání prezentátorem. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) s `true`, aby se video po dokončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) na první snímku a povolí přetočení. Zakáže opakování, aby přehrávání mohlo skončit, a nastaví spuštění přehrávání po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na první snímku.

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

Přetočení vrátí video na začátek, aniž by se spustilo znovu. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) s `true` automaticky opakuje přehrávání. Nechte opakování zakázáno, když chcete, aby video skončilo a zůstalo připravené k opětovnému přehrání. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) samostatně řídí automatické nebo kliknutím spouštění; tento příklad používá [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/), takže prezentátor řídí, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Přetočení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Oříznout video snímek**

Použijte [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd), abyste během přehrávání přeskočili část začátku nebo konce videa. Obě hodnoty jsou v milisekundách. Oříznutí mění nastavení přehrávání, aniž by upravovalo vložená video data.

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

Tento příklad vypíše hodnoty oříznutí prvního video snímku na první slide v milisekundách. Prezentace musí obsahovat alespoň jeden slide. Pokud tento slide neobsahuje video snímek, nic se nevytiskne. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

Aspose.Slides vám umožňuje spravovat skryté titulky pro video snímky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou zpřístupněny pomocí metody [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Přidat titulky k video snímku**

Tento příklad vloží lokální video a přidá stopu titulků WebVTT označenou English. Časové značky titulků by měly odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

Třída [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) také poskytuje přetížení, které vám umožní přidat titulky ze streamu.

**Extrahovat titulky z video snímku**

Tento příklad uloží všechny stopy titulků z video snímků na první slide jako samostatné soubory WebVTT. Sekvenční čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden slide.

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

Každý objekt [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) vystavuje identifikátor titulku, popisek, binární data a text titulku jako řetězec UTF-8.

**Odstranit titulky z video snímku**

Tento příklad odstraní všechny titulky z video snímku na první pozici tvaru na první slide a uloží výsledek. Předpokládá, že slide a tvar existují a že tvar je video snímek.

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

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metodu [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Extrahovat video ze snímku**

Kromě přidávání videí do snímků vám Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech slide do samostatných, číslovaných binárních souborů. Odkazovaná videa jsou přeskočena, protože nemají vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte tak, aby odpovídala hlášenému typu média.

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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit u video snímku?**

Můžete ovládat [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto nebo po kliknutí) a [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Tyto možnosti jsou dostupné prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) .

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte náhledový obrázek, prezentace uloží odkaz a preview obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video snímku bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) uvnitř snímku při zachování geometrie tvaru; to je běžný scénář pro aktualizaci médií v existujícím rozložení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType), který můžete přečíst a použít, například při ukládání na disk.