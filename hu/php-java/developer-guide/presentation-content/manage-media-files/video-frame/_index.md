---
title: Videókeretek kezelése prezentációkban PHP használatával
linktitle: Videókeret
type: docs
weight: 10
url: /hu/php-java/video-frame/
keywords:
- video hozzáadása
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
description: "Tanulja meg, hogyan lehet programozottan videókereteket hozzáadni és kinyerni PowerPoint és OpenDocument diákban az Aspose.Slides for PHP via Java használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek magyarázatában és a közönség bevonásában. Az Aspose.Slides for PHP via Java lehetővé teszi, hogy videókereteket adjon a diákhoz, módosítsa a lejátszási beállításokat, kezelje a feliratokat, és kinyerje a beágyazott videó adatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube‑videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) osztályt, és más releváns típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó bemutatóba való beágyazásához.

Ez a példa egy helyi videót ágyaz be a meglévő bemutató első diájára, és elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A stream nyitva marad a mentés befejezéséig, mert a [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a bemutató használja.

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

Átadhatja a helyi videó elérési útját közvetlenül a [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame) metódusnak. Ez a példa a videót egy új bemutató első diájára ágyazza be. A videónak elérhetőnek kell maradnia, amíg a bemutatót el nem mentik.

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

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatója az online videók beillesztését a bemutatókba. Létrehozhat egy videókeretet, amely egy online videóra hivatkozik, például egy YouTube‑videóra.

Ez a példa egy YouTube‑videó hivatkozást és miniatűr képet ad az első diához. Cserélje ki a videó azonosítót egy másik videó használatához. A [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) metódus automatikus lejátszást kér. A miniatűr letöltése és a videó lejátszása internetkapcsolatot igényel. A bemutató megjelenítőnek szintén támogatnia kell az online videó lejátszását.

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

Egy képzési bemutatóban lejátszhat egy szoftverdemonstrációt teljes képernyőn, hogy a közönség lássa a részleteket. Hívja meg a [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) metódust `true` értékkel, hogy ezt a viselkedést engedélyezze a lejátszás során.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) keretet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen az első dián már létező videókeret van.

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

A teljes képernyős lejátszás szabályozza, hogy a videó hogyan jelenik meg. Függetlenül, a [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) szabályozza, automatikusan vagy kattintásra indul-e, és a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) azt, hogy ismétlődik-e. A kezdési viselkedés kiválasztásához állítsa be a lejátszási módot a [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) értékre. A példa megtartja a meglévő kezdési és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy képzési bemutatóban a demonstrációs videó visszatekerése az elejére lehetővé teszi, hogy az előadó újból lejátszhassa. Hívja meg a [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) metódust `true` értékkel, hogy a videó a lejátszás befejezése után visszatérjen az elejére.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) keretet az első dián, és engedélyezi a visszatekerést. Kikapcsolja a ciklikus lejátszást, hogy a lejátszás befejeződhessen, és beállítja, hogy kattintásra induljon. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen az első dián már létező videókeret van.

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

A visszatekerés a videót az elejére helyezi anélkül, hogy újra elindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) `true` értékkel való meghívása automatikusan ismétli a lejátszást. Tartsa a ciklikus lejátszást kikapcsolva, ha azt szeretné, hogy a videó befejeződjön és készen álljon az újrajátszásra. A [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) önállóan szabályozza az automatikus vagy kattintásos indítást; ez a példa a [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) értéket használja, hogy az előadó ellenőrizhesse, mikor kezdődjön a lejátszás. Állítsa be a lejátszási módot a ciklus beállítása után, ahogy a példában látható. A visszatekerés függetlenül működik a [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) beállítástól.

## **Videókeret vágása**

Használja a [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) és a [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) metódusokat a videó elejének vagy végének egy részének kihagyásához a lejátszás során. Mindkét érték ezredmásodpercben van. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatot módosítaná.

**Vágási beállítások megadása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy lejátszható szegmens maradjon.

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

**Vágási beállítások kiolvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A bemutatónak legalább egy diát kell tartalmaznia. Ha az a dia nem tartalmaz videókeretet, semmit sem ír ki. Az előző példa 2500 és 1000 értékeket ad.

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

Az Aspose.Slides lehetővé teszi a zárt feliratok kezelését a PowerPoint bemutatók videókereteihez. A feliratok WebVTT formátumban vannak tárolva, és a [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

### **Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és egy English (angol) címkéjű WebVTT felirat sávot ad hozzá. A felirat időbélyegeinek meg kell egyezniük a videóval. A mentett bemutató tartalmazza a videót és a feliratokat is.

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

A [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) osztály is biztosít egy túlterhelést, amely lehetővé teszi feliratok hozzáadását streamből.

### **Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorozatszámok biztosítják a kimeneti fájlok egyediségét. A konzol jelentést ad a kinyert sávok számáról. A bemutatónak legalább egy diát kell tartalmaznia.

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

Minden [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatait, és a felirat szövegét UTF‑8 karakterláncként.

### **Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában lévő videókeretről, és elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

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

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) metódusokat a [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) helyett.

### **Videó feliratok keresése**

A [Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) visszaadja a teljes WebVTT sávot, beleértve a fejlécet, az időzítési sorokat és a felirat szöveget. A memóriában kereshet a képletek között, hogy megtalálja a kimondott kifejezést és annak időbélyegét. Például a 2. dián egy angol sáv a következő szöveget tartalmazhatja.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

A példa megnyitja a `captioned_media.pptx` fájlt, és a [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) metódust használja, hogy beolvassa minden dia minden felső szintű videókeretének sávjait. Egy egyszerű szöveges képletben az időzítési sor `-->` karaktert tartalmaz, és egy üres sor jelzi a képlet végét. Ha a felirat tartalmazza a „café” szót bármilyen betűméretben, a példa kiírja a dia számát, a sáv címkéjét, az eredeti időzítési sort és a teljes feliratot.

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

A „café” keresése egy egyezést ad a minta sávra. A keresés kizárja a sávfejlécet, és megőrzi az időzítési beállítást a kimenetben.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Videó kinyerése diából**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a bemutatókba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A hivatkozott videók kihagyásra kerülnek, mivel nem tartalmaznak beágyazott adatot. A konzol kiírja minden videó MIME‑típusát és a teljes számot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén változtassa meg a jelentett média típusnak megfelelően.

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

**Milyen videó lejátszási paraméterek módosíthatók egy videókeretnél?**

Megadhatja a [lejátszási módot](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (automatikus vagy kattintásra) és a [ciklust](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a bemutató mérete a fájlmérettel arányosan nő. Ha online videóra hivatkozik és egy miniatűrt ad hozzá, a bemutató a hivatkozást és az előnézeti képet tárolja a videóadat helyett, így a mérettömeg általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben a pozíció és a méret módosítása nélkül?**

Igen. Cserélheti a keretben lévő [videótartalmat](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) anélkül, hogy a forma geometriáját megváltoztatná; ez gyakori eset a médiák frissítésére egy meglévő elrendezésben.

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videónak van [tartalomtípusa](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType), amelyet kiolvashat és felhasználhat, például amikor lemezre menti.