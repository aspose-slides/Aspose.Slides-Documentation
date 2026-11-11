---
title: Prezentációs diák renderelése SVG képekként Java-ban
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-re
- bemutató SVG-re
- dia SVG-re
- PPT SVG-re
- PPTX SVG-re
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként Java-ban, és szabályozza a betűket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képformátum, amely jól működik webes közzétételhez, diavetítőknek, hozzáférhetőségi munkafolyamatokhoz és automatikus utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan íródnak a szövegek, betűk, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) elemet, amikor az exportált SVG-nek kompakt, böngészők között kiszámítható, vagy interaktív használatra készen kell állnia.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba az [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) metódussal. A következő példában a bemutató minden diáját külön SVG fájlba exportálja.

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

A fájlnév az [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) metódust használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) metódussal, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

Az [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) szabályozza az SVG megjelenítését. Szövegkeretek esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) a szövegkeretet a renderelési területbe vonja be, és a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

## **Szöveg és betűk ellenőrzése**

Diák SVG-be exportálásakor szabályozhatja, hogy a szöveg szövegként maradjon vagy vektorgrafikává alakuljon, valamint azt, hogy a külső betűkészletek hogyan legyenek beágyazva vagy hivatkozva. A következő beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szövegkijelölést és a betűkészlet-függőségeket az exportált SVG-ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) értékét `true`-ra, hogy az összes diaszöveget vektorgrafikaként írja. Ez megszünteti a betűkészlet-függőségeket, és a vizuális eredményt böngészők között egységesebbé teszi, de a szöveg már nem választható vagy kereshető SVG-szövegként.

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

### **Válassza ki, hogyan kezelje a külső betűkészleteket**

Az [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles` lehetőséget, ha külön betűfájlokra szeretne hivatkozni, az `Embed` opciót a betűadatok SVG-be ágyazásához, vagy a `Vectorize` lehetőséget, hogy csak a külső betűket használó szöveget grafikai formában jelenítse meg. Ellenőrizze a betűkészletek licencelését az ágyazás előtt.

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

## **Beágyazott képek méretének csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) metódust a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) metódust a levágott forrásterületek kihagyásához, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) metódust a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megtartott képadatoknak a költségén.

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

## **Metafájl raszterezési felbontásának szabályozása**

Az [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) az SVG exportálás során a metafájlok raszterezésének alsó felbontási határát állítja be. Ezt a részletesség és a fájlméret egyensúlyozására használja, amikor EMF vagy WMF kép kerül raszterezésre. Nem definiál globális DPI-t az SVG-hez, és nem kényszeríti minden dián lévő objektumot raszterképpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy szorosan elhelyezett átlós vonalakat tartalmazó EMF képet tartalmaz. A következő példa az első diát három raszterezési felbontásban exportálja a [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) metóduson keresztül. Az összes többi exportálási beállítás azonos marad, hogy az eredményeket össze lehessen hasonlítani.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

A kimenetben az EMF minden SVG-ben egy beágyazott PNG-vé vált. A következő mérések a mellékelt bemutatóhoz tartoznak; nem általános képlet a DPI pixelméretre való átváltásához.

| Metafájl raszterezési DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja ugyanazon nagyított megjelenítési méretben. A diagonális vonalak látható pixelesedést mutatnak 72 DPI-n, míg magasabb felbontásoknál simább élek jelennek meg, és az SVG fájl mérete nő. A felbontás növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képet.

![Nagyított átlós vonal részlete 72, 150 és 300 DPI-n](metafile-rasterization-comparison.png)

Az [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) szabályozza a kép felbontáscsökkentést, és elfedheti a metafájl raszterezési felbontás változtatásának hatását. Az [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) a JPEG kódolás minőségét szabályozza, nem a metafájl raszterezési felbontását.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja a [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) interfészt, hogy minden SVG alakzatra beállítsa az [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) értéket. A szöveg `tspan` elemeire is az [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) értékek beállításához valósítsa meg a [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) interfészt. Bármelyik vezérlőt állítsa be a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) metódussal.

A következő vezérlő a [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) metódust használja, amely az alakzat életciklusa során stabil, valamint egy ismételhető számlálót a szöveges spanokhoz. Ez a generált azonosítókat alkalmassá teszi egy változatlan bemutató utófeldolgozásához.

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

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/)-on belül hívja meg az [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) metódust egy [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon egy exportált alakzathoz. Állítsa be a vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) metódussal, és definiálja a JavaScript függvényt a eredményt tartalmazó oldalon vagy SVG-dokumentumban.

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

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, a hozzáférhetőségi fejlesztéseket és más interaktív SVG munkafolyamatokat.

## **FAQ**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) helyett a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) használni?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) metódust, amikor minden szövegnek függetlennek kell lennie a betűkészlettől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) lehetőséget, ha csak a külső betűket használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a linkelt betűfájlok választásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mert az alacsonyabb képfelbontás, az alacsonyabb JPEG minőség és a vektorgrafikává konvertált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatok exportált SVG elemeket az export után?**

Igen. Rendeljen azonosítókat egy formázó vezérlő segítségével, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy a böngésző‑szkriptben.