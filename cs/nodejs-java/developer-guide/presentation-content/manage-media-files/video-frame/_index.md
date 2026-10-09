---
title: Správa video snímků v prezentacích pomocí Node.js
linktitle: Video snímek
type: docs
weight: 10
url: /cs/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro Node.js přes Java. Rychlý praktický návod."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zapojit publikum. Aspose.Slides pro Node.js přes Java vám umožňuje přidávat video snímky do snímků, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená videodata.

PowerPoint podporuje místní videa i odkazy na online videa, například videa YouTube.

Pro reprezentaci video dat a video snímků Aspose.Slides poskytuje třídu [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) třídu [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) a další relevantní typy.

## **Vytvořit vložený video snímek**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit video snímek pro vložení videa do vaší prezentace.

Tento příklad vloží lokální video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry snímku jsou v bodech. Proud zůstává otevřený až do dokončení uložení, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) jej uzamkne, dokud je prezentace používá.

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

Můžete také předat cestu k lokálnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné až do uložení prezentace.

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

## **Vytvořit video snímek s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit video snímek, který odkazuje na online video, například video YouTube.

Tento příklad přidá odkaz na YouTube video a náhledový obrázek na první snímek. Nahraďte identifikátor videa, pokud chcete použít jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) požaduje automatické přehrávání. Stahování náhledového obrázku a přehrávání videa vyžaduje přístup k internetu. Prohlížeč prezentací také musí podporovat přehrávání online videí.

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

## **Přehrát video v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo detaily. Zavolejte [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) s `true` pro povolení tohoto chování během přehrávání.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) na první snímku a povolí přehrávání na celou obrazovku. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na prvním snímku.

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

Režim celé obrazovky řídí, jak je video zobrazeno. Samostatně [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) určuje, zda se spustí automaticky nebo po kliknutí, a [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) určuje, zda se opakuje. Pro výběr chování při spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto nebo VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Příklad zachovává existující nastavení startu a smyčky.

## **Přetočit video po přehrání**

V tréninkové prezentaci vrácení ukázkového videa na začátek ho připraví pro opětovné přehrání prezentátorem. Zavolejte [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) s `true` pro vrácení videa na začátek po dokončení přehrávání.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) na prvním snímku a povolí přetáčení. Vypne smyčku, aby přehrávání mohlo skončit, a nastaví přehrávání na start po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím video snímkem na prvním snímku.

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

Přetáčení vrátí video na začátek, aniž by jej znovu spustilo. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) s `true` způsobí automatické opakování přehrávání. Udržujte smyčku vypnutou, pokud chcete, aby video skončilo a zůstalo připravené k opětovnému přehrání. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) samostatně řídí automatické nebo po‑kliknutí spuštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) , takže prezentátor řídí, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení smyčky, jak je ukázáno v příkladu. Přetáčení funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Oříznout video snímek**

Použijte [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) , abyste při přehrávání přeskočili část na začátku nebo na konci videa. Obě hodnoty jsou v milisekundách. Ořezávání mění nastavení přehrávání bez úpravy vložených video dat.

**Nastavit nastavení ořezu**

Tento příklad vloží lokální video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstala přehratelná část.

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

**Přečíst nastavení ořezu**

Tento příklad vytiskne hodnoty ořezu prvního video snímku na první snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá video snímek, nic se nevytiskne. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

## **Spravovat titulky videa**

Aspose.Slides vám umožňuje spravovat skryté titulky pro video snímky v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou přístupné pomocí metody [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Přidat titulky do video snímku**

Tento příklad vloží lokální video a přidá WebVTT stopu titulků označenou English. Časová razítka titulků by měla odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

Třída [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) také poskytuje metodu [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) pro přidání titulků ze streamu.

**Extrahovat titulky z video snímku**

Tento příklad uloží všechny stopy titulků z video snímků na první snímku jako samostatné WebVTT soubory. Postupná čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

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

Každý objekt [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) vystavuje identifikátor titulků, popisek, binární data a text titulků jako řetězec UTF-8.

**Odstranit titulky z video snímku**

Tento příklad odstraní všechny titulky z video snímku na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá, že snímek a tvar existují a že tvar je video snímek.

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

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt), místo [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extrahovat video ze snímku**

Kromě přidávání videí do snímků vám Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných, číslovaných binárních souborů. Propojená videa jsou přeskočena, protože nemají vložená data. Konzole vypíše typ MIME každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; při potřebě ji změňte tak, aby odpovídala hlášenému typu média.

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

## **Často kladené otázky**

**Které parametry přehrávání videa lze u video snímku změnit?**

Můžete ovládat [režim přehrávání](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Tyto možnosti jsou dostupné prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když odkazujete na online video a přidáte náhledový obrázek, prezentace ukládá odkaz a obrázek náhledu místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím video snímku bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) uvnitř snímku při zachování geometrie tvaru; to je běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/), který můžete přečíst a použít, například při ukládání na disk.