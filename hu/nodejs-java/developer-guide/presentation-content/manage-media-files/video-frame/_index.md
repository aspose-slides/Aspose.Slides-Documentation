---
title: Videókeretek kezelése bemutatókban Node.js használatával
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
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg programozott módon videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for Node.js via Java használatával. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek magyarázatában és a közönség bevonásában. Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy videókereteket adjon a diához, módosítsa a lejátszási beállításokat, kezelje a feliratozást, és kinyerje a beágyazott videó adatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube‑videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) osztályt és más kapcsolódó típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára felvenni kívánt videófájl helyileg tárolódik, létrehozhat egy videókeretet a videó bemutatóba ágyazásához.

Ez a példa egy helyi videót ágyaz be egy meglévő bemutató első diájára, majd elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A folyam (stream) nyitva marad, amíg a mentés be nem fejeződik, mivel a [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a bemutató használja.

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

A helyi videó útvonalát közvetlenül átadhatja a [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) metódusnak is. Ez a példa a videót egy új bemutató első diájára ágyazza be. A videónak a mentés befejezéséig elérhetőnek kell maradnia.

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

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a bemutatókban. Létrehozhat egy videókeretet, amely egy online videóra, például egy YouTube‑videóra hivatkozik.

Ez a példa a YouTube‑videó hivatkozást és bélyegképet adja hozzá az első diához. Cserélje le a videóazonosítót egy másik videó használatához. A [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) metódus automatikus lejátszást kér. A bélyegkép letöltéséhez és a videó lejátszásához internetkapcsolat szükséges. A bemutató megjelenítőnek is támogatnia kell az online videó lejátszását.

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

Egy oktatási bemutatóban lejátszhatja a szoftverbemutatót teljes képernyős módban, hogy a közönség lássa a részleteket. Hívja meg a [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) metódust `true` értékkel a lejátszás közbeni viselkedés engedélyezéséhez.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen már létezik egy videókeret az első dián.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül attól, a [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) szabályozza, hogy automatikusan vagy kattintásra induljon, a [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) pedig azt, hogy ismétlődjön-e. A kezdési viselkedés kiválasztásához állítsa be a lejátszási módot a [VideoPlayModePreset.Auto vagy VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). A példa megőrzi a meglévő kezdési és ismétlődési beállításokat.

## **Videó visszatekercselése a lejátszás után**

Egy oktatási bemutatóban a bemutatóvideó elejére való visszatérés lehetővé teszi, hogy a prezentáló újra lejátszhassa azt. Hívja meg a [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) metódust `true` értékkel, hogy a lejátszás befejeződése után a videó az elejére kerüljön.

Ez a példa megnyit egy bemutatót, megtalálja az első [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) elemet az első dián, és engedélyezi a visszatekercselést. Kikapcsolja az ismétlést, hogy a lejátszás befejeződhessen, és beállítja a lejátszást kattintásra indítandó módra. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen már létezik egy videókeret az első dián.

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

A visszatekercselés a videót az elejére helyezi, anélkül hogy újraindulna. Ezzel szemben a [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) `true` értékkel való hívása automatikusan ismétli a lejátszást. Tartsa az ismétlést kikapcsolva, ha azt szeretné, hogy a videó befejeződjön és készen álljon az újra lejátszásra. A [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) önállóan szabályozza az automatikus vagy kattintásra indított indítást; ez a példa a [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) beállítást használja, hogy a prezentáló vezérelje a lejátszás indítását. Állítsa be a lejátszási módot az ismétlés beállítása után, ahogyan a példában látható. A visszatekercselés független a [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) működésétől.

## **Videókeret vágása**

Használja a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) metódusokat a videó elejének vagy végének egy részének kihagyásához lejátszás közben. Mindkét érték ezredmásodpercben van megadva. A vágás a lejátszási beállításokat módosítja anélkül, hogy a beágyazott videó adatot változtatná.

**Vágási beállítások beállítása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy maradjon lejátszható szegmens.

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

**Vágási beállítások olvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A bemutatónak legalább egy diát kell tartalmaznia. Ha az a dia nem tartalmaz videókeretet, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket eredményez.

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

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését PowerPoint bemutatókban. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

### **Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és egy 'English' címkéjű WebVTT feliratsávot ad hozzá. A felirat időbélyegeinek egyezniük kell a videóval. A mentett bemutató tartalmazza a videót és a feliratokat egyaránt.

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

A [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) osztály továbbá a [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) metódust is biztosítja feliratok folyamokból való hozzáadásához.

### **Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek minden feliratsávját különálló WebVTT fájlokként menti. A sorrendi számok az egyedi kimeneti fájlok biztosítását szolgálják. A konzol jelzi a kinyert sávok számát. A bemutatónak legalább egy diát kell tartalmaznia.

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

Minden [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) objektum exponálja a felirat azonosítóját, címkéjét, bináris adatát és felirat szövegét UTF‑8 karakterláncként.

### **Feliratok eltávolítása videókeretből**

Ez a példa eltávolítja az összes feliratot az első dián az első alakzat pozíciójában lévő videókeretből, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat egy videókeret.

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

Ha csak egy feliratsávot kell eltávolítania, használja a [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) metódusokat a [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) helyett.

### **Videó feliratok keresése**

A [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) metódus visszaadja a teljes WebVTT sávot, beleértve a fejlécet, idővonalakat és a felirat szövegét. A memóriában kereshet a felirat szövegében kifejezést és annak időbélyegét. Például a 2. diához tartozó angol sáv tartalmazhatja ezt a jelzést:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Ez a példa megnyitja a `captioned_media.pptx` fájlt, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) használatával beolvassa minden dia minden felső szintű videókeretének sávjait. Egy egyszerű szöveges jelzésnél az idővonal `-->` karaktert tartalmaz, és egy üres sor zárja a jelzést. Minden olyan felirat esetén, amely bármilyen betűmérettel tartalmazza a „café” szót, a példa kiírja a dia számát, a sáv címkéjét, az eredeti idővonalat és a teljes feliratot.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A „café” keresése egy egyezést talál a mintasávban. A keresés átugorja a sáv fejlécét, és megőrzi az időbeállítást és a sortörést a kimenetben.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Videó kinyerése diáról**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a bemutatókba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat különálló, számozott bináris fájlokba. A hivatkozott videókat kihagyja, mivel nincs beágyazott adataik. A konzol kiírja minden videó MIME‑típusát és a teljes számot. A kimenet általános `.bin` kiterjesztést használ; szükség esetén módosítsa a jelentett média típusnak megfelelően.

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

**Milyen videó lejátszási paramétereket lehet módosítani egy videókeretnél?**

A [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) vezérelhető. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a bemutató mérete arányosan nő a fájl méretével. Ha online videóra hivatkozik és bélyegképet ad hozzá, a bemutató a hivatkozást és a előnézeti képet tárolja a videóadatok helyett, így a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) cserélhető a keretben a forma geometria megtartása mellett; ez gyakori forgatókönyv a médiák frissítéséhez egy meglévő elrendezésben.

**Megállapítható a beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videónak van [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) típusa, amelyet kiolvashat és felhasználhat, például a lemezre mentéskor.