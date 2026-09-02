---
title: Videokeretek kezelése bemutatókban JavaScript használatával
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
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki videokereteket programozott módon PowerPoint és OpenDocument diáiban az Aspose.Slides for Node.js Java használatával. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó egy bemutatóban meggyőzőbbé teheti az üzenetet, és növelheti a közönség elköteleződését.  

A PowerPoint két módon teszi lehetővé a videók hozzáadását egy diára a bemutatóban:

* Helyi videó hozzáadása vagy beágyazása (a gépén tárolt)  
* Online videó hozzáadása (például YouTube-ról származó webes forrásból).  

Az Aspose.Slides biztosítja a [Video](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/) osztályt, a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) osztályt és más releváns típusokat, hogy videókat (videoobjektumokat) adhasson hozzá egy bemutatóhoz.

## **Beágyazott Videokeret Létrehozása**

Ha a diára hozzáadni kívánt videofájl helyileg van tárolva, létrehozhat egy videokeretet a videó bemutatóba való beágyazásához.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciaját az indexén keresztül.  
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/) objektumot, és adja meg a videofájl útvonalát a videó bemutatóba való beágyazásához.  
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot a videó keretének létrehozásához.  
1. Mentse el a módosított bemutatót.  

Ez a JavaScript kód megmutatja, hogyan lehet helyileg tárolt videót hozzáadni egy bemutatóhoz:

```javascript
// Példányosítja a Presentation osztályt
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Betölti a videót
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Lekéri az első diát és hozzáad egy videokeretet
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Elmenti a bemutatót a lemezre
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternatív megoldásként videót adhat hozzá, ha a fájl útvonalát közvetlenül átadja az [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) metódusnak:

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

## **Webes Forrásból Származó Videóval Videokeret Létrehozása**

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube videókat a bemutatókban. Ha a használni kívánt videó online elérhető (például YouTube-on), hozzáadhatja azt a bemutatóhoz a webes hivatkozáson keresztül.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
1. Szerezze meg egy dia referenciaját az indexén keresztül.  
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/) objektumot, és adja meg a videó hivatkozását.  
1. Állítson be egy miniatűrképet a videókerethez.  
1. Mentse el a bemutatót.  

Ez a JavaScript kód megmutatja, hogyan lehet webes videót egy diára a PowerPoint bemutatóban hozzáadni:

```javascript
// Példányosít egy Presentation objektumot, amely egy prezentációs fájlt reprezentál
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

## **Videokeret Vágása**

Az Aspose.Slides lehetővé teszi, hogy a videó lejátszott részét a trim‑from‑start és trim‑from‑end értékek beállításával irányítsa a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/settrimfromstart/) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/settrimfromend/) segítségével. Mindkét értéket ezredmásodpercben kell megadni, és meghatározzák, hogy a videó elejéről és végéről mennyi időt hagyjon ki. Ezek a beállítások a bemutatóban a videó lejátszási beállításait módosítják; nem vágják vagy egyéb módon nem módosítják a beágyazott videó bináris adatát.  

**Vágási Beállítások Beállítása**

Videokeret létrehozásához és a vágási beállítások megadásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
1. Adjon hozzá egy [Video](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/) objektumot a bemutatóhoz.  
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot egy diára.  
1. Állítsa be a trim‑from‑start és trim‑from‑end értékeket a [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/settrimfromstart/) és a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/settrimfromend/) segítségével.  
1. Mentse el a módosított bemutatót.  

Az alábbi kódpélda kihagyja a beágyazott videó első 2,5 másodpercét és az utolsó másodpercét lejátszáskor:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Vágási Beállítások Olvasása**

A meglévő vágási beállítások ellenőrzéséhez töltse be a bemutatót, keresse meg az első dián a formák között a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot, és olvassa ki az értékeket a [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) és a [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/gettrimfromend/) segítségével.  

Az alábbi kódpélda megtalálja az első videokeretet az első dián, és ezredmásodpercben jelzi a vágási beállításait:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Videó Feliratok Kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését PowerPoint bemutatókban. A feliratok WebVTT formátumban tárolódnak, és a [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) metóduson keresztül érhetők el.  

**Feliratok Hozzáadása Videokerethez**

Feliratok hozzáadásához egy videokerethez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
1. Adjon hozzá egy videót a bemutatóhoz.  
1. Adjon hozzá egy [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot egy diára.  
1. Használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) gyűjteményt egy WebVTT feliratsáv hozzáadásához.  
1. Mentse el a módosított bemutatót.  

Az alábbi kód megmutatja, hogyan adhat feliratokat egy videokerethez:

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

A [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) osztály a [addFromStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#addFromStream) metódust is biztosítja, amely lehetővé teszi feliratok hozzáadását egy adatfolyamból.  

**Feliratok Kinyerése Videokeretből**

Feliratok kinyeréséhez egy videokeretből:

1. Töltse be a videót tartalmazó bemutatót.  
1. Keresse meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot.  
1. Iteráljon végig a [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) gyűjteményen.  
1. Mentse minden feliratsávot egy `.vtt` fájlba.  

Az alábbi kód megmutatja, hogyan nyerhetők ki a feliratok egy videokeretből:

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
                // A feliratsáv mentése WebVTT fájlba.
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

Minden [Captions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captions/) objektum megjeleníti a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF‑8 karakterláncként.  

**Feliratok Törlése Videokeretből**

Feliratok törléséhez egy videokeretből:

1. Töltse be a videót tartalmazó bemutatót.  
1. Szerezze meg a cél [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot.  
1. Távolítsa el a feliratsávokat a [CaptionsCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/) gyűjteményből.  
1. Mentse el a módosított bemutatót.  

Az alábbi kód megmutatja, hogyan lehet az összes feliratot egy videokeretből eltávolítani:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // típus: com.aspose.slides.VideoFrame

    // Eltávolítja az összes feliratot a videokeretből.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha csak egy feliratsávot szeretne eltávolítani, használja a [remove](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#remove) vagy a [removeAt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#removeAt) metódusokat a [clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/captionscollection/#clear) helyett.  

## **Videó Kinyerése Diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a bemutatókba beágyazott videók kinyerését.  

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból a videót tartalmazó bemutató betöltéséhez.  
2. Iteráljon végig az összes [Slide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/) objektumon.  
3. Iteráljon végig az összes [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) objektumon, hogy megtalálja a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) elemet.  
4. Mentse el a videót a lemezre.  

Ez a JavaScript kód megmutatja, hogyan lehet kinyerni egy videót a bemutató egy diájáról:

```javascript
// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
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

**Mely videólejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/setplayloopmode/) beállítását szabályozhatja. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.  

**A videó hozzáadása befolyásolja-e a PPTX fájl méretét?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a bemutató mérete arányosan nő a fájlmérettel. Ha online videót ad hozzá, egy hivatkozás és egy miniatűrkép kerül beágyazásra, ezért a méretnövekedés kisebb.  

**Lecserélhetem a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A kereten belül kicserélheti a [video content](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) tartalmát, miközben megőrzi a forma geometriai adatait; ez gyakori a meglévő elrendezésben lévő média frissítéséhez.  

**Megállapítható-e egy beágyazott videó tartalomtípusa (MIME)?**

Igen. A beágyazott videónak van egy [content type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/video/getcontenttype/) értéke, amelyet leolvashat és felhasználhat, például a lemezre mentéskor.