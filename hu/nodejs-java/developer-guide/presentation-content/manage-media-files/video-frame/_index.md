---
title: Videókeretek kezelése prezentációkban Node.js használatával
linktitle: Videókeret
type: docs
weight: 10
url: /hu/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg programozottan hozzáadni és kinyerni a videókereteket PowerPoint és OpenDocument diákba az Aspose.Slides for Node.js via Java használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek ötletek magyarázatában és a közönség bevonásában. Az Aspose.Slides for Node.js a Java segítségével lehetővé teszi videókeretek hozzáadását a diákhoz, a lejátszási beállítások módosítását, feliratok kezelését és a beágyazott videóadatok kinyerését.

A PowerPoint támogatja a helyi videókat és az online videókra, például YouTube videókra mutató hivatkozásokat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) osztályt és más releváns típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg van tárolva, létrehozhat egy videókeretet a videó prezentációba való beágyazásához.

Ez a példa beágyaz egy helyi videót egy meglévő prezentáció első diájára, és elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A folyam nyitva marad, amíg a mentés be nem fejeződik, mivel a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a prezentáció használja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

A helyi videó útvonalát közvetlenül is átadhatja a [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) metódusnak. Ez a példa beágyazza a videót egy új prezentáció első diájára. A videónak elérhetőnek kell maradnia a prezentáció mentéséig.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube videóra hivatkozik.

Ez a példa egy YouTube videó hivatkozást és előnézeti képet ad hozzá az első dián. Cserélje ki a videóazonosítót egy másik videó használatához. A [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) metódus automatikus lejátszást kér. Az előnézet letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek szintén támogatnia kell az online videó lejátszást.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Videó lejátszása teljes képernyős módban**

Egy képzési prezentációban lejátszhat egy szoftver bemutatót teljes képernyő módban, hogy a közönség láthassa a részleteket. Hívja meg a [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) metódust `true` értékkel a viselkedés lejátszás közbeni engedélyezéséhez.

Ez a példa megnyit egy prezentációt, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen létezik egy video keret az első dián.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül a [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) meghatározza, automatikusan vagy kattintásra indul-e, a [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) pedig azt, hogy ismétlődik-e. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) értékre. A példa megőrzi a meglévő kezdési és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Egy képzési prezentációban a bemutató videó elejére való visszatérés azt teszi lehetővé, hogy az előadó újra lejátszhassa. Hívja meg a [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) metódust `true` értékkel, hogy a lejátszás befejezése után a videó visszatérjen a kezdethez.

Ez a példa megnyit egy prezentációt, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a visszatekerést. Kikapcsolja az ismétlést, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen létezik egy video keret az első dián.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A visszatekerés a videót a kezdetére helyezi anélkül, hogy újra elindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) `true` értékkel való hívása automatikusan ismétli a lejátszást. Tartsa letiltva az ismétlést, ha azt szeretné, hogy a videó befejeződjön és készen álljon a újrajátszásra. A [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) függetlenül szabályozza az automatikus vagy kattintásos indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) értéket használja, hogy az előadó szabályozhassa a lejátszás kezdetét. Állítsa be a lejátszási módot az ismétlési beállítás után, ahogy a példában látható. A visszatekerés független a [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) működésétől.

## **Videókeret vágása**

Használja a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) metódusokat a videó elejének vagy végének egy részének kihagyásához a lejátszás során. Mindkét érték ezredmásodpercben van megadva. A vágás módosítja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatát megváltoztatná.

**Vágás beállítása**

Ez a példa beágyaz egy helyi videót, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy maradjon lejátszható szegmens.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Vágás beállításainak olvasása**

Ez a példa a első videókeret vágási értékeit millisecondumban írja ki az első dián. A prezentációnak legalább egy diát kell tartalmaznia. Ha az a dia nem tartalmaz videókeretet, semmi nem kerül kiírásra. Az előző példa 2500 és 1000 értékeket ad.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban vannak tárolva, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa beágyaz egy helyi videót, és hozzáad egy 'English' címkével ellátott WebVTT felirat sávot. A felirat időbélyegeinek egyezniük kell a videóval. A mentett prezentáció tartalmazza mind a videót, mind a feliratokat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) osztály emellett a [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) metódust is biztosítja feliratok folyamokból történő hozzáadásához.

**Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorozatszámok biztosítják a kimeneti fájlok egyediségét. A konzol jelzi a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Minden [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) objektum megjeleníti a felirat azonosítóját, címkéjét, bináris adatait és a felirat szövegét UTF-8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első forma pozíciójában lévő videókeretről, majd elmenti az eredményt. Feltételezi, hogy a dia és a forma létezik, és hogy a forma egy videókeret.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) metódust a [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diáról**

A videók diára való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A hivatkozott videók ki vannak hagyva, mivel nincs beágyazott adatuk. A konzol kiírja minden videó MIME típusát és a teljes darabszámot. A kimenet a generikus `.bin` kiterjesztést használja; ha szükséges, módosítsa a jelentett média típusnak megfelelően.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mely video lejátszási paraméterek módosíthatók egy videókeretnél?**

A [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) vezérelhető. Ezek a beállítások a [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) objektum metódusaiban érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájl méretével. Ha online videóra hivatkozik és előnézeti képet ad hozzá, a prezentáció a hivatkozást és a bélyegképet tárolja a videó adat helyett, ezért a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókereten a pozíció és méret megváltoztatása nélkül?**

Igen. A keretben lévő [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) kicserélhető a forma geometriájának megőrzése mellett; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Megállapítható-e egy beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videónak van [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) típusa, amelyet elolvashat és felhasználhat, például a lemezre mentéskor.