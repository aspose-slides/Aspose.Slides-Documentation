---
title: Správa video rámců v prezentacích pomocí JavaScriptu
linktitle: Video rámec
type: docs
weight: 10
url: /cs/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámy v slidech PowerPoint a OpenDocument pomocí Aspose.Slides pro Node.js přes Java. Rychlý návod krok za krokem."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaši zprávu přesvědčivější a zvýšit úroveň zapojení publika.

PowerPoint umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:

* Přidat nebo vložit lokální video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, například YouTube).

Aby bylo možné do prezentace přidávat videa (video objekty), poskytuje Aspose.Slides třídu [Video](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/video/) , třídu [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) a další související typy.

## **Vytvoření vloženého video rámce**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do prezentace.

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation)class.
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/video/) a předáte cestu k video souboru pro vložení videa do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) pro vytvoření rámce pro video.
1. Uložte upravenou prezentaci.

Tento JavaScript kód ukazuje, jak přidat lokálně uložené video do prezentace:

```javascript
// Vytváří instanci třídy Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Načítá video
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Získá první snímek a přidá video rámec
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Uloží prezentaci na disk
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Případně můžete přidat video předáním cesty k souboru přímo do metody [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

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

## **Vytvoření video rámce s videem z webového zdroje**

Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej přidat do prezentace pomocí jeho webového odkazu.

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation)class
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/video/) a předáte odkaz na video.
1. Nastavte náhled pro video rámec.
1. Uložte prezentaci.

Tento JavaScript kód ukazuje, jak přidat video z webu do snímku v PowerPoint prezentaci:

```javascript
// Vytváří objekt Presentation, který představuje soubor prezentace
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

## **Oříznutí video rámce**

Aspose.Slides vám umožňuje řídit, která část videa se přehraje, nastavením hodnot trim-from-start a trim-from-end pomocí metod [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/settrimfromstart/) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/settrimfromend/). Obě hodnoty jsou uváděny v milisekundách a určují, kolik času se přeskočí od začátku a konce videa. Tato nastavení mění nastavení přehrávání videa v prezentaci; neodstraňují ani jinak nemodifikují binární data vloženého videa.

**Nastavení ořezu**

Pro vytvoření video rámce a nastavení jeho ořezu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) class.
1. Přidejte objekt [Video](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/video/) do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) na snímek.
1. Nastavte hodnoty trim-from-start a trim-from-end pomocí [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/settrimfromstart/) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/settrimfromend/).
1. Uložte upravenou prezentaci.

Následující příklad kódu přeskočí prvních 2,5 sekundy a poslední sekundu vloženého videa během přehrávání:

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

**Čtení nastavení ořezu**

Pro zkontrolování existujících nastavení ořezu načtěte prezentaci, najděte objekt [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) mezi tvary na prvním snímku a přečtěte hodnoty pomocí [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) a [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/gettrimfromend/).

Následující příklad kódu najde první video rámec na prvním snímku a vypíše jeho nastavení ořezu v milisekundách:

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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámečky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou dostupné přes metodu [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Přidání titulků do video rámce**

Pro přidání titulků do video rámce:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) class.
1. Přidejte video do prezentace.
1. Přidejte objekt [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) na snímek.
1. Použijte kolekci [CaptionsCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/) k přidání WebVTT stopy titulků.
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak přidat titulky do video rámce:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Přidá novou stopu titulků z WebVTT souboru.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Třída [CaptionsCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/) také poskytuje metodu [addFromStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/#addFromStream), která umožňuje přidat titulky ze streamu.

**Extrahování titulků z video rámce**

Pro extrahování titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Najděte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/).
1. Projděte kolekci [CaptionsCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/).
1. Uložte každou stopu titulků do souboru `.vtt`.

Následující kód ukazuje, jak extrahovat titulky z video rámce:

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
                // Uloží stopu titulků do souboru WebVTT.
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

Každý objekt [Captions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captions/) obsahuje identifikátor titulu, štítek, binární data a text titulu jako řetězec UTF-8.

**Odstranění titulků z video rámce**

Pro odstranění titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Získejte cílový objekt [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/).
1. Odstraňte stopy titulků z kolekce [CaptionsCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/).
1. Uložte upravenou prezentaci.

Následující kód ukazuje, jak odstranit všechny titulky z video rámce:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // typ: com.aspose.slides.VideoFrame

    // Odstraní všechny titulky z video rámce.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metodu [remove](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides také extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) class pro načtení prezentace obsahující video.
2. Projděte všechny objekty [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/).
3. Projděte všechny objekty [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) a najděte [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/).
4. Uložte video na disk.

Tento JavaScript kód ukazuje, jak extrahovat video na snímku prezentace:

```javascript
// Vytvoří objekt Presentation, který představuje soubor prezentace
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
                // Získá příponu souboru
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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/setplaymode/) (automaticky nebo na kliknutí) a [opakování](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Tyto možnosti jsou dostupné přes vlastnosti objektu [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta v dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, je vložen pouze odkaz a náhled, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) v rámci rámce při zachování geometrie tvaru; jedná se o běžný scénář pro aktualizaci médií v existujícím rozložení.

**Lze zjistit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/video/getcontenttype/), který můžete načíst a použít, například při ukládání na disk.