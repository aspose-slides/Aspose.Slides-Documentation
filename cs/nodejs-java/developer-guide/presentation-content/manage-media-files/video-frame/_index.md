---
title: Správa video snímků v prezentacích pomocí Node.js
linktitle: Snímek videa
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
description: "Naučte se programově přidávat a extrahovat video snímky v PowerPoint a OpenDocument slidech pomocí Aspose.Slides pro Node.js přes Java. Rychlý praktický průvodce."
---
## **Úvod**

Videa mohou pomoci vysvětlit nápady a zapojit publikum. Aspose.Slides pro Node.js prostřednictvím Javy vám umožňuje přidávat snímky videa do slidů, upravovat nastavení přehrávání, spravovat titulky a extrahovat vložená video data.

PowerPoint podporuje místní videa i odkazy na online videa, například videa z YouTube.

Aspose.Slides poskytuje třídu [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) třídu [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) a další relevantní typy.

## **Vytvoření vloženého snímku videa**

Pokud je video soubor, který chcete přidat do snímku, uložen lokálně, můžete vytvořit snímek videa pro vložení videa do vaší prezentace.

Tento příklad vloží místní video na první snímek existující prezentace a uloží výsledek. Souřadnice a rozměry snímku jsou v bodech. Proud zůstává otevřený, dokud se ukládání neukončí, protože [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) ho během používání prezentace zamkne.

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

Můžete také předat cestu k místnímu videu přímo metodě [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Tento příklad vloží video na první snímek nové prezentace. Video musí zůstat přístupné, dokud není prezentace uložena.

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

## **Vytvoření snímku videa s videem z webového zdroje**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) podporuje online videa v prezentacích. Můžete vytvořit snímek videa, který odkazuje na online video, například na YouTube video.

Tento příklad přidá odkaz na YouTube video a miniaturu na první snímek. Nahraďte identifikátor videa, pokud chcete použít jiné video. Metoda [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) požaduje automatické přehrávání. Stažení miniatury a přehrání videa vyžaduje připojení k internetu. Prohlížeč prezentací musí také podporovat přehrávání online videí.

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

## **Přehrání videa v režimu celé obrazovky**

V tréninkové prezentaci můžete přehrát ukázku softwaru v režimu celé obrazovky, aby publikum vidělo podrobnosti. Zavolejte metodu [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) s hodnotou `true`, aby se během přehrávání tento režim aktivoval.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) na první snímku a povolí přehrávání v režimu celé obrazovky. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím snímkem videa na první snímku.

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

Přehrávání v režimu celé obrazovky řídí, jak je video zobrazeno. Samostatně metoda [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) určuje, zda se spustí automaticky nebo po kliknutí, a metoda [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) určuje, zda se opakuje. Pro výběr chování spuštění nastavte režim přehrávání na [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). Příklad zachovává stávající nastavení spuštění a opakování.

## **Převinutí videa po přehrání**

V tréninkové prezentaci vrácení demonstračního videa na začátek zajišťuje, že je připraveno pro další přehrání prezentátorem. Zavolejte metodu [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) s hodnotou `true`, aby se video po dokončení přehrávání vrátilo na začátek.

Tento příklad otevře prezentaci, najde první [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) na první snímku a povolí převinutí. Vypne opakování, aby přehrávání mohlo skončit, a nastaví spuštění přehrávání po kliknutí. Vstupní prezentace musí obsahovat alespoň jeden snímek s existujícím snímkem videa na první snímku.

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

Převinutí vrací video na jeho začátek, aniž by jej znovu spustilo. Naopak volání [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) s hodnotou `true` způsobí automatické opakování přehrávání. Pokud chcete, aby video skončilo a zůstalo připravené k opětovnému přehrání, nechte opakování vypnuté. Metoda [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) samostatně řídí automatické nebo kliknutím spouštění; tento příklad používá [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/), aby prezentátor kontroloval, kdy se přehrávání spustí. Nastavte režim přehrávání po nastavení opakování, jak je ukázáno v příkladu. Převinutí funguje nezávisle na [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Ořezání snímku videa**

Použijte metody [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) a [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) pro přeskočení části začátku nebo konce videa během přehrávání. Obě hodnoty jsou v milisekundách. Ořezání mění nastavení přehrávání, aniž by upravovalo vložená video data.

**Nastavení ořezu**

Tento příklad vloží místní video a během přehrávání přeskočí první 2,5 sekundy a poslední sekundu. Použijte video delší než 3,5 sekundy, aby zůstala přehratelná část.

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

**Čtení nastavení ořezu**

Tento příklad vypíše hodnoty ořezu prvního snímku videa na první snímku v milisekundách. Prezentace musí obsahovat alespoň jeden snímek. Pokud tento snímek nemá žádný snímek videa, nic se nevytiskne. Předchozí příklad produkuje hodnoty 2500 a 1000.

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

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro snímky videa v prezentacích PowerPoint. Titulky jsou uloženy ve formátu WebVTT a jsou dostupné prostřednictvím metody [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

### **Přidání titulků do snímku videa**

Tento příklad vloží místní video a přidá stopu titulků WebVTT označenou jako English. Časové značky titulků by měly odpovídat videu. Uložená prezentace obsahuje jak video, tak jeho titulky.

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

### **Extrahování titulků ze snímku videa**

Tento příklad uloží všechny stopy titulků ze snímků videa na první snímku jako samostatné soubory WebVTT. Pořadová čísla udržují výstupní soubory odlišné. Konzole vypíše počet extrahovaných stop. Prezentace musí obsahovat alespoň jeden snímek.

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

Každý objekt [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) zpřístupňuje identifikátor titulku, popisek, binární data a text titulku jako řetězec UTF-8.

### **Odstranění titulků ze snímku videa**

Tento příklad odstraní všechny titulky ze snímku videa na první pozici tvaru na prvním snímku a uloží výsledek. Předpokládá, že snímek a tvar existují a že tvar je snímek videa.

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

Pokud potřebujete odstranit jen jednu stopu titulků, použijte metodu [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) nebo [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) místo [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

### **Vyhledávání titulků videa**

Metoda [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) vrací celou stopu WebVTT, včetně hlavičky, časových řádků a textu titulku. Můžete v paměti prohledávat text titulku a najít frázi a její časovou značku. Například anglická stopa na snímku 2 může obsahovat tento cue:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Tento příklad otevře `captioned_media.pptx` a použije [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) k načtení stop každého vrchního snímku videa na všech snímcích. V prostém textovém cue časová řádka obsahuje `-->` a prázdný řádek cue ukončuje. Pro každý titulek, který obsahuje „café“ v libovolném psaní, příklad vypíše číslo snímku, popisek stopy, původní časovou řádku a celý titulek.

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

Vyhledávání „café“ najde jednu shodu ve vzorové stopě. Vyhledávání přeskočí hlavičku stopy a zachová nastavení časování a zalomení řádku ve výstupu.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků umožňuje Aspose.Slides extrahovat videa vložená v prezentacích.

Tento příklad extrahuje vložená videa ze všech snímků do samostatných číslovaných binárních souborů. Odkazy na videa jsou přeskočeny, protože neobsahují žádná vložená data. Konzole vypíše MIME typ každého videa a celkový počet. Výstup používá obecnou příponu `.bin`; v případě potřeby ji změňte, aby odpovídala hlášenému typu média.

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

**Které parametry přehrávání videa lze změnit pro snímek videa?**

Můžete řídit [režim přehrávání](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automaticky nebo po kliknutí) a [opakování](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Tyto možnosti jsou dostupné prostřednictvím metod objektu [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte místní video, binární data jsou zahrnuta do dokumentu, takže se velikost prezentace zvětší úměrně velikosti souboru. Když odkazujete na online video a přidáte miniaturu, prezentace uloží pouze odkaz a náhledový obrázek místo video dat, takže nárůst velikosti je obvykle menší.

**Mohu nahradit video v existujícím snímku videa bez změny jeho polohy a velikosti?**

Ano. Můžete vyměnit [video obsah](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) uvnitř snímku a zachovat geometrii tvaru; jedná se o běžný scénář pro aktualizaci médií v existujícím rozvržení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/), který můžete přečíst a použít, například při ukládání na disk.