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
- videó lekérdezése
- videókeret
- web forrás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg programozottan videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for PHP via Java használatával. Gyors gyakorlati útmutató."
---
## **Bevezetés**

A videók segíthetnek a gondolatok magyarázatában és a közönség bevonásában. Az Aspose.Slides for PHP via Java lehetővé teszi videókeretek hozzáadását a diákhoz, a lejátszási beállítások módosítását, a feliratok kezelését és a beágyazott videóadatok kinyerését.

PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube‑videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) osztályt és egyéb kapcsolódó típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videofájl helyben van tárolva, létrehozhatsz egy videókeretet, amely beágyazza a videót a bemutatóba.

Ez a példa egy helyi videót ágyaz be egy meglévő bemutató első diájára, majd elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A folyam (stream) nyitva marad a mentés befejezéséig, mivel a [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a bemutató használja.

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

Megadhatod a helyi videó elérési útját közvetlenül a [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) metódusnak. Ez a példa a videót egy új bemutató első diájára ágyazza be. A videónak a mentés befejezéséig hozzáférhetőnek kell maradnia.

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

## **Videókeret létrehozása webes forrásból származó videóval**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a bemutatókban. Létrehozhatsz egy videókeretet, amely egy online videóra mutat, például egy YouTube‑videóra.

Ez a példa egy YouTube videó hivatkozást és előnézeti képet ad hozzá az első diához. Cseréld ki a videó azonosítót, ha másik videót szeretnél használni. A [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) metódus automatikus lejátszást kér. Az előnézeti kép letöltése és a videó lejátszása internetkapcsolatot igényel. A bemutató megjelenítőnek is támogatnia kell az online videó lejátszást.

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

## **Videó lejátszása teljes képernyős módban**

Egy oktatási bemutatóban lejátszhatsz egy szoftver demonstrációt teljes képernyőn, hogy a közönség lássa a részleteket. Hívd meg a [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) metódust `true` értékkel a viselkedés engedélyezéséhez a lejátszás során.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) a első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti bemutatónak legalább egy, az első dián létező videókerettel kell rendelkeznie.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül, a [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) határozza meg, automatikusan vagy kattintásra indul-e, a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) pedig szabályozza az ismétlést. A kezdési viselkedés kiválasztásához állítsd be a lejátszási módot a [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) értékre. A példa megtartja a meglévő kezdési és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy oktatási bemutatóban a demonstrációs videó elejére visszatekerése lehetővé teszi, hogy az előadó újra lejátszhassa. Hívd meg a [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) metódust `true` értékkel, hogy a videó a lejátszás befejezése után visszatérjen a kezdethez.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) a első dián, és engedélyezi a visszatekerést. Letiltja az ismétlést, hogy a lejátszás befejeződhessen, és beállítja a lejátszást kattintásra indítva. A bemeneti bemutatónak legalább egy, az első dián létező videókerettel kell rendelkeznie.

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

A visszatekerés a videót a kezdetéhez viszi anélkül, hogy újraindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) `true` értékkel való meghívása automatikusan ismétli a lejátszást. Kapcsold ki az ismétlést, ha azt szeretnéd, hogy a videó befejeződjön és készen álljon az újra lejátszásra. A [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) függetlenül szabályozza az automatikus vagy kattintásra indított indítást; ez a példa a [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) értéket használja, így az előadó szabályozza a lejátszás kezdetét. Állítsd be a lejátszási módot a ciklusbeállítás után, ahogyan a példában látható. A visszatekerés független a [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) működésétől.

## **Videókeret vágása**

A [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) használatával kihagyhatod a videó elejének vagy végének egy részét a lejátszás során. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videóadatot változtatná.

**Vágási beállítások beállítása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használj legalább 3,5 másodpercnél hosszabb videót, hogy lejátszható szegmens maradjon.

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

**Vágási beállítások olvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A bemutatónak legalább egy diát kell tartalmaznia. Ha azon a dián nincs videókeret, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket eredményez.

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

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a zárt feliratok kezelését a PowerPoint bemutatók videókereteihez. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és hozzáad egy WebVTT feliratsp tracket 'English' címkével. A felirat időbélyegeinek egyezniük kell a videóval. A mentett bemutató tartalmazza a videót és a feliratokat is.

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

A [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) osztály továbbá egy túlterhelést biztosít, amely lehetővé teszi feliratok hozzáadását egy folyam (stream) segítségével.

**Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorozatszámok biztosítják, hogy a kimeneti fájlok különbözőek legyenek. A konzol jelzi a kinyert sávok számát. A bemutatónak legalább egy diát kell tartalmaznia.

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

Minden [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) objektum kiállítja a feliratazonosítót, a címkét, a bináris adatot és a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián, az első alakzat pozíciójában lévő videókeretről, és elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat egy videókeret.

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

Ha csak egy feliratsáv eltávolítására van szükség, használd a [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) vagy [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) metódusokat a [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diáról**

A videók diákhoz adásán túl az Aspose.Slides lehetővé teszi a bemutatókba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A hivatkozott videókat kihagyja, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME‑típusát és a teljes darabszámot. A kimenet általános `.bin` kiterjesztést használ; szükség esetén változtasd meg a jelentett médiatípusnak megfelelően.

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

## **GYIK**

**Milyen videólejátszási paraméterek módosíthatók egy videókeretnél?**

A [lejátszási mód](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (automatikus vagy kattintásra) és az [ismétlés](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) módja módosítható. Ezek az opciók a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**Beépített videó növeli a PPTX fájl méretét?**

Igen. Ha helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a bemutató mérete a fájl méretével arányosan nő. Ha online videóra hivatkozol és előnézeti képet adsz hozzá, a bemutató a hivatkozást és a előnézeti képet tárolja a videóadat helyett, így a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [videótartalmat](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) cserélheted a kereten belül a forma geometriai adatait megtartva; ez egy gyakori eset a médiák frissítésére meglévő elrendezésben.

**Megállapítható egy beágyazott videó tartalom típusa (MIME)?**

Igen. Egy beágyazott videónak van egy [tartalom típusa](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType), amelyet kiolvashatsz és használhatsz, például amikor lemented a lemezre.