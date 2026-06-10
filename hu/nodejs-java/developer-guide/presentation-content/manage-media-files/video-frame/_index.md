---
title: Videokeretek kezelése prezentációkban JavaScript használatával
linktitle: Videokeret
type: docs
weight: 10
url: /hu/nodejs-java/video-frame/
keywords:
- videó hozzáadása
- videó létrehozása
- videó beágyazása
- videó kinyerése
- videó lekérése
- videokeret
- webes forrás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet programozottan hozzáadni és kinyerni videokereteket a PowerPoint és OpenDocument diákkban az Aspose.Slides for Node.js segítségével Java nyelven. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó a bemutatóban hatásosabbá teheti az üzenetet, és növelheti a közönség bevonódását.

A PowerPoint két módon teszi lehetővé, hogy videókat adjon hozzá egy diára a bemutatóban:
* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)
* Online videó hozzáadása (webes forrásból, például YouTube).

Annak érdekében, hogy videókat (videoobjektumokat) adjon hozzá egy bemutatóhoz, az Aspose.Slides a [Video](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) osztályt és más kapcsolódó típusokat biztosít.

## **Beágyazott videokeret létrehozása**

Ha a diára hozzáadni kívánt videofájl helyileg van tárolva, létrehozhat egy videokeretet a videó bemutatóba ágyazásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/) objektumot, és adja meg a videofájl elérési útját a videó bemutatóba ágyazásához.
4. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot a videó keret létrehozásához.
5. Mentse el a módosított bemutatót.

```javascript
// Létrehozza a Presentation osztályt
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Betölti a videót
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Lekéri az első diát és hozzáad egy videokeretet
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Elmenti a prezentációt a lemezre
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternatív megoldásként a videót közvetlenül a [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) metódusnak a fájl útvonalának átadásával is hozzáadhatja:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Videokeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube videókat a bemutatókban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatja a bemutatóhoz a webes hivatkozásán keresztül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból
2. Szerezze meg egy dia referenciáját az indexe alapján.
3. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/) objektumot, és adja meg a videó hivatkozását.
4. Állítson be egy bélyegképet a videokerethez.
5. Mentse el a bemutatót.

```javascript
// Létrehozza a Presentation objektumot, amely egy prezentáció fájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi a videokeretek zárt feliratainak kezelését a PowerPoint bemutatókban. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.

**Feliratok hozzáadása videokerethez**

A feliratok videokerethez való hozzáadásához:
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
2. Adjon hozzá egy videót a bemutatóhoz.
3. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot egy diára.
4. Használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) gyűjteményt egy WebVTT felirat sáv hozzáadásához.
5. Mentse el a módosított bemutatót.

Az alábbi kód bemutatja, hogyan adhat feliratokat egy videokerethez:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Új feliratsáv hozzáadása egy WebVTT fájlból.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) osztály emellett a [addFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#addFromStream) metódust is biztosítja, amely lehetővé teszi feliratok hozzáadását egy adatfolyamból.

**Feliratok kinyerése videokeretből**

A feliratok videokeretből történő kinyeréséhez:
1. Töltse be a videót tartalmazó bemutatót.
2. Keresse meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot.
3. Iteráljon végig a [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) gyűjteményen.
4. Mentse minden feliratsávot egy `.vtt` fájlba.

Az alábbi kód bemutatja, hogyan nyerhet ki feliratokat egy videokeretből:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Mentés a feliratsáv WebVTT fájlba.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Minden [Captions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF-8 karakterláncként.

**Feliratok eltávolítása videokeretből**

A feliratok videokeretből való eltávolításához:
1. Töltse be a videót tartalmazó bemutatót.
2. Szerezze meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot.
3. Távolítsa el a feliratsávokat a [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) gyűjteményből.
4. Mentse el a módosított bemutatót.

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // típus: com.aspose.slides.VideoFrame

    // Eltávolítja az összes feliratot a videokeretről.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#removeAt) metódust a [clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#clear) helyett.

## **Videó kinyerése diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a bemutatókba ágyazott videók kinyerését.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból a videót tartalmazó bemutató betöltéséhez.
2. Iteráljon végig az összes [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) objektumon.
3. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumon, hogy megtalálja a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot.
4. Mentse a videót a lemezre.

```javascript
// Létrehozza a Presentation objektumot, amely egy prezentáció fájlt képvisel
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Lekéri a fájl kiterjesztését
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Mely videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/setplayloopmode/) módot szabályozhatja. Ezek a beállítások a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adatok a dokumentumba kerülnek, így a bemutató mérete arányosan nő a fájl méretével. Ha online videót ad hozzá, egy hivatkozás és egy bélyegkép kerül beágyazásra, így a méretnövekedés kisebb.

**Lecserélhetem-e a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) cserélhető a keretben a forma geometriai adatait megtartva; ez gyakori eset a médiák frissítésére egy meglévő elrendezésben.

**Meg lehet határozni egy beágyazott videó tartalom típusát (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/getcontenttype/) típusú információval, amelyet kiolvashat és felhasználhat, például a lemezre mentéskor.