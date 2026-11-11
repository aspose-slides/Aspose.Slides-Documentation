---
title: "Dia bemutatók SVG képeként történő renderelése JavaScriptben"
linktitle: "Dia SVG-be"
type: docs
weight: 50
url: /hu/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint SVG-re"
- "bemutató SVG-re"
- "dia SVG-re"
- "PPT SVG-re"
- "PPTX SVG-re"
- "SVG exportálási beállítások"
- "interaktív SVG"
- "PowerPoint"
- "bemutató"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Exportálja a PowerPoint diákat SVG képeként JavaScriptben, és irányítsa a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájlformátum, amely jól működik webes közzétételnél, diavetítőkben, akadálymentesítési munkafolyamatokban és automatizált utófeldolgozásban. Az Aspose.Slides for Node.js Java-n keresztül minden diát külön SVG-fájlba exportál, és lehetővé teszi a szöveg, betűkészletek, képek és SVG-elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) akkor, amikor az exportált SVG-nek kompaktnak, böngészők között kiszámíthatónak vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba a [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) segítségével. A következő példa minden diát külön SVG-fájlként exportál.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

A fájlnév a [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) használatával jön létre a ciklusindex helyett. Egy egyedi alakzatra is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) segítségével, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) szabályozza az SVG megjelenítését. Szövegkeretek esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) a szövegkeretet is belefoglalja a renderelési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) pedig meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg és betűk szabályozása**

Diák SVG-be exportálásakor szabályozhatja, hogy a szöveg szövegként maradjon vagy vektorgrafikává alakuljon, illetve hogyan kerülnek beillesztésre vagy hivatkozásra a külső betűkészletek. A következő beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szövegkiválasztást és a betűkészlet-függőségeket az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) értékét `true`-ra, hogy minden diaszöveget vektorgrafikaként írjon ki. Ez megszünteti a betűkészlet-függőségeket és a megjelenést böngészők között egységesebbé teszi, de a szöveg már nem lesz kiválasztható vagy kereshető SVG-szövegként.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Válassza ki a külső betűkészletek kezelésének módját**

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) értéket használ a külső betöltésű betűkészletekhez. Válassza az `AddLinksToFontFiles` opciót, ha különálló betűfájlokra kíván hivatkozni, az `Embed` opciót a betűadatok SVG-be ágyazásához, vagy a `Vectorize` opciót, ha csak a külső betűkészleteket használó szöveget grafikai elemmé szeretné alakítani. Ellenőrizze a betűkészletek licencfeltételeit, mielőtt beágyazná őket.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Beágyazott képméret csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) funkciót a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) opciót a levágott forrásterületek kihagyásához, valamint a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) beállítást a JPEG kódolási minőség szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megőrzött képadatok költségén.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Metafájl raszterizálási felbontásának szabályozása**

A [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) beállítja az alacsonyabb felbontási határt a metafájlok SVG-exportálás közbeni raszterizálásához. Használja a részletesség és a fájlméret egyensúlyozásához, amikor EMF vagy WMF képet raszterizál. Nem határozza meg az SVG globális DPI-ját, és nem kényszeríti minden dián lévő objektumot raszterképpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely közeli átlós vonalakkal rendelkező EMF képet tartalmaz. A következő példa az első diát három raszterizálási felbontásban exportálja a [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) használatával. A többi exportbeállítás változatlan marad, hogy az eredményeket össze lehessen hasonlítani.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

A kimenetben az EMF minden SVG-ben egy beágyazott PNG-vé alakul. A következő mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI pixelméretekre való átváltásához.

| Metafájl raszterizálási DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott raszter területet mutatja azonos nagyított megjelenítési mérettel. A átlós vonalak látható pixelesedést mutatnak 72 DPI-n, magasabb felbontásoknál simább széleket, miközben az SVG-fájl nő. Az érték növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képet.

![Nagyított átlóvonal részlet 72, 150 és 300 DPI](metafile-rasterization-comparison.png)

A [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl raszterizálási felbontás változtatásának hatását. A [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) a JPEG kódolási minőséget szabályozza, nem a metafájl raszterizálási felbontást.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Adjon egy formázóvezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) metódusnak, hogy beállítsa a [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) értékét minden SVG-alakzatra. Egy olyan vezérlő, amely a szövegspánkokat is kezeli, beállíthatja a [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) értékeket a szöveg `tspan` elemein.

A következő vezérlő a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) metódust használja, amely az alakzat élettartama alatt stabil, és egy ismételhető számlálót a szövegspánkokhoz. Ez a generált azonosítókat alkalmasá teszi egy változatlan prezentáció utófeldolgozására.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **SVG eseménykezelők hozzáadása**

Egy formázóvezérlőben hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) metódust egy [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon egy exportált alakzathoz. Rendelje hozzá a vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) segítségével, és definiálja a JavaScript függvényt azon az oldalon vagy SVG-dokumentumban, amely a eredményt kiszolgálja.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

A host oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, az akadálymentesítési fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **FAQ**

**Mikor kell használni a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) metódust a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) metódust, amikor minden szövegnek függetlennek kell lennie a betűkészlettől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) metódust, amikor csak a külső betűkészleteket használó szöveget kell grafikává alakítani.

**Mi a legjobb módja egy SVG kisebbé tételének?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a hivatkozott betűfájlok választásával, ha a célkörnyezet képes ezeket kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, a alacsonyabb JPEG minőség és a vektorizált szöveg mind más-más minőség‑ és méretátmenetekkel jár.

**Módosíthatom az exportált SVG elemeket exportálás után?**

Igen. Rendelj hozzá azonosítókat egy formázóvezérlővel, majd válaszd ki a megfelelő SVG elemeket az utófeldolgozó eszközödben vagy böngésző‑szkriptben.