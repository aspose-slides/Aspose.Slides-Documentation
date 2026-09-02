---
title: Dia előadások renderelése SVG képekként Java-ban
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- prezentáció SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "PowerPoint diák exportálása SVG képekként Java-ban, és betűkészletek, szöveg, képek, azonosítók és események kezelése az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képformátum, amely jól működik webes kiadványok, diavetítők, akadálymentesítési munkafolyamatok és automatikus utófeldolgozás esetén. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan íródnak a szövegek, betűk, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/) opciót, ha az exportált SVG-nek kompaktnek, böngészők között kiszámíthatónak vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba a [ISlide.writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) metódussal. Az alábbi példa a bemutató minden diáját külön SVG fájlként exportálja.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

A fájlnév a [ISlide.getSlideNumber](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islide/#getSlideNumber--) metódust használja a ciklus indexe helyett. Egyedi alakzatot is exportálhat a [IShape.writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) metódussal, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/) szabályozza az SVG megjelenítést. Szövegkereteknél a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) beépíti a szövegkeretet a renderelési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) pedig meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) értékét `true`-ra, ha a szöveget ligaturek nélkül kell renderelni.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg és betűk kezelése**

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) értékét `true`-ra, hogy a diák összes szövege vektoros grafikaként legyen kiírva. Ez megszünteti a betűtípus-függőségeket és a vizuális eredményt konzisztenssé teszi a böngészők között, de a szöveg már nem választható vagy kereshető SVG szövegként.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Válassza ki, hogyan kezelje a külső betűket**

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgexternalfontshandling/) értéket használ a külsőként betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles` lehetőséget, ha külön betűkészlet-fájlokra hivatkozik, a `Embed` lehetőséget a betűadatok SVG-be ágyazásához, vagy a `Vectorize` lehetőséget, ha csak a külső betűket használó szöveget grafikaként szeretné renderelni. Ellenőrizze a betűk licencelését, mielőtt ágyazná őket.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Beágyazott kép méretének csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) beállítást a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) beállítást a vágott forrásterületek kihagyásához, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) beállítást a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megtartott képadatok költségén.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja a [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgshapeformattingcontroller/) interfészt, hogy minden SVG alakzatra beállítsa az [ISvgShape.setId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) értéket. A szöveg `tspan` elemeire is [ISvgTSpan.setId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) értékek beállításához valósítsa meg a [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) interfészt. Bármelyik vezérlőt rendelje az [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) metódussal.

Az alábbi vezérlő a [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) metódust használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegspánkokhoz. Ez a generált azonosítókat alkalmasá teszi egy változatlan bemutató utófeldolgozásához.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **SVG eseménykezelők hozzáadása**

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgshapeformattingcontroller/)-ban hívja meg az [ISvgShape.setEventHandler](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) metódust egy [SvgEvent](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. Rendelje a vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) segítségével, és definiálja a JavaScript függvényt az eredményt kiszolgáló oldalon vagy SVG dokumentumban.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

A gazda oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, akadálymentesítési fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) metódust használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) metódust, ha az összes szövegnek függetlennek kell lennie a betűkészletektől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/svgexternalfontshandling/) beállítást, ha csak a külső betűket használó szöveget kell grafikává konvertálni.

**Mi a leghatékonyabb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a vágott képrészletek törlésével, és a kapcsolt betűkészlet-fájlok kiválasztásával, ha a célkörnyezet képes ezeket kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, alacsonyabb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méretkompromisszumokkal jár.

**Módosíthatom az exportált SVG elemeket az exportálás után?**

Igen. Rendeljünk azonosítókat egy formázási vezérlő segítségével, majd válasszuk ki a megfelelő SVG elemeket az utófeldolgozó eszközben vagy böngésző‑szkriptben.