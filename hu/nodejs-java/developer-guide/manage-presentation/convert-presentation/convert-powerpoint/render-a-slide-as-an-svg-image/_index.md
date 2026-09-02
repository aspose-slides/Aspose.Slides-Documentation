---
title: "Diák renderelése SVG képekként JavaScriptben"
linktitle: "Dia SVG-re"
type: docs
weight: 50
url: /hu/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint SVG-re"
- "prezentáció SVG-re"
- "dia SVG-re"
- "PPT SVG-re"
- "PPTX SVG-re"
- "SVG exportálási beállítások"
- "interaktív SVG"
- "PowerPoint"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Exportálja a PowerPoint diákat SVG képekként JavaScriptben, és vezérelje a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képformátum, amely jól működik webes publikálásnál, diavetítőkben, akadálymentesítési munkafolyamatokban és automatizált utófeldolgozásban. Az Aspose.Slides for Node.js via Java minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűtípusok, képek és SVG elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/) elemet, ha az exportált SVG-nek kompakt, böngészők között kiszámítható vagy interaktív használatra készen álló kell lennie.

## **Exportálás diáról SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba a [Slide.writeAsSvg](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/writeassvg/) segítségével. A következő példa minden diát exportál egy külön SVG fájlként.

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

A fájlnév a [Slide.getSlideNumber](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/getslidenumber/) metódust használja a ciklusindex helyett. Egyedi alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) segítségével, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

Az [SVGOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/) szabályozza az SVG renderelését. Szövegreziszek esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setuseframesize/) a szövegreziszt a renderelési területbe foglalja, és a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) meghatározza, hogy a réziszkörforgás alkalmazásra kerüljön-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell renderelni.

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

## **Szöveg és betűtípusok vezérlése**

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) értékét `true`-ra, hogy a diák összes szövegét vektoros grafikaként írja ki. Ez megszünteti a betűtípus függőségeket, és a vizuális eredményt böngészők között egységesebbé teszi, de a szöveg már nem választható vagy kereshető SVG szövegként.

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

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

Az [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. Válassza a `AddLinksToFontFiles` opciót, ha külön betűtípus-fájlokra szeretne hivatkozni, az `Embed` lehetőséget a betűtípus adatainak SVG-be ágyazásához, vagy a `Vectorize` beállítást, hogy csak a külső betűtípusokat használó szöveget grafikaként renderelje. Ellenőrizze a betűtípus licencet, mielőtt beágyazná a betűtípusokat.

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

## **Beágyazott képek méretének csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) beállítást a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) opciót a levágott forrásrégiók kihagyásához, valamint a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setjpegquality/) beállítást a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép hűség vagy a megőrzött képadatok kárára.

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

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Adjon át egy formázási vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) metódusnak, hogy a [SvgShape.setId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgshape/setid/) attribútumot állítsa be minden SVG alakzatra. Egy olyan vezérlő, amely a szövegrészeket is kezeli, beállíthatja a [SvgTSpan.setId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgtspan/setid/) értékeket a szöveg `tspan` elemein.

Az alábbi vezérlő a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) metódust használja, amely az alakzat élettartama alatt stabil, és ismételhető számlálót a szövegrészeihez. Ez a generált azonosítókat alkalmassá teszi a változatlan prezentáció utófeldolgozására.

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

Egy formázási vezérlőben hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgshape/seteventhandler/) metódust egy [SvgEvent](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. Adja hozzá a vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) segítségével, és definiálja a JavaScript függvényt az eredményt tartalmazó oldalon vagy SVG dokumentumban.

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

A fogadó oldal definiálhatja az eseménykezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, a hozzáférhetőségi fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kellene a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) metódust használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) metódust, ha az összes szövegnek függetlennek kell lennie a betűtípusoktól. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgexternalfontshandling/) opciót, ha csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a hivatkozott betűtípus-fájlok választásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, alacsonyabb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszal jár.

**Módosíthatom-e az exportált SVG elemeket az export után?**

Igen. Adjon azonosítókat egy formázási vezérlőn keresztül, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptben.