---
title: Prezentációs diák renderelése SVG képekként Java-ban
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
description: "Exportálja a PowerPoint diákat SVG képként Java-ban, és vezérelje a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képfájl-formátum, amely jól működik webszerkesztéshez, diavetítők számára, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűk, képek és SVG elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) akkor, amikor az exportált SVG-nek kompaktnak, böngészők között előreláthatónak vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG formátumba**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), válasszon ki egy diát, és írja ki egy adatfolyamra az [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) segítségével. A következő példa minden diát külön SVG fájlként exportál a prezentációból.

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

A fájlnév az [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) használatával jön létre, a ciklusindex helyett. Egyedi alakzatot is exportálhat a [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) segítségével, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) szabályozza az SVG renderelést. Szövegkereteknél a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) a szövegkeretet is belefoglalja a megjelenítési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) pedig meghatározza, hogy a keret forgatása alkalmazásra kerüljön-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

## **Vonalvégek levágásának szabályozása nyílhegyeknél**

Az SVG 1.1 nem rendelkezik marker inset beállítással, amely meghatározná, hol álljon meg a vonal a nyílfej alatt. Alapértelmezés szerint az Aspose.Slides lerövidíti az exportált vonalat, hogy a vonalstílus ne nyúljon ki a markerből. Hívja meg a [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) `true` értékkel, hogy a vonal teljesen a vonal eredeti végpontjáig legyen rajzolva. Ez a beállítás csak az SVG kimenetet érinti. A vonal a dián megőrzi helyzetét és hosszát.

A példa háromszög és rombusz nyílfejeket rajzol 2 és 10 pont széles vonalakra. Kétszer exportálja ugyanazt a diát, csak a levágás beállítást módosítva.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

A összehasonlítás a háromszög nyílfejet mutatja a 10 pontos vonalon. Levágás engedélyezve a csúcs éles, levágás letiltva a vonalstílus átnyúlik a marker ferde oldalain, és lapos véget hagy.

![Nagyított 10 pontos háromszög éles csúccsal, ha a levágás engedélyezett, és lapos véggel, ha a levágás le van tiltva](line-end-cropping.png)

A példában szereplő többi vonalnál a kiálló vonalstílus kevésbé látható a 2 pontos háromszögnél. A kitöltött rombusz mindkét szélességnél lefedi a vonal végét.

## **Szöveg és betűkészletek vezérlése**

SVG-be exportálva a diákat szabályozhatja, hogy a szöveg szöveg marad-e vagy vektorgrafikává alakul, valamint hogy a külső betűkészletek hogyan legyenek beágyazva vagy hivatkozva. A következő beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szövegkijelölést és a betűkészlet-függőségeket az exportált SVG-ben.

### **Minden szöveg vektorizálása**

A [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) `true` értékre állításával a diák összes szövege vektorgrafikaként kerül kiírásra. Ez megszünteti a betűkészlet-függőségeket és a vizuális eredményt konzisztenssé teszi a böngészők között, de a szöveg már nem lesz kijelölhető vagy kereshető SVG szövegként.

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

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles` opciót a különálló betűfájlokra való hivatkozáshoz, az `Embed`-et a betűadatok SVG-be ágyazásához, vagy a `Vectorize`-t, hogy csak a külső betűkészleteket használó szöveg legyen grafika. Ellenőrizze a betűkészlet licencét az ágyazás előtt.

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

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) a levágott forrásterületek kihagyásához, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) a JPEG kódolási minőség szabályozásához. Ezek a beállítások csökkentik a fájlméretet a kép pontosságának vagy a megtartott képadatok árán.

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

## **Metafájl rasterizációs felbontásának vezérlése**

A [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) beállítja a minimális felbontási határt a metafájlok SVG-export során történő rasterizálásához. Használja a részletek és a fájlméret egyensúlyozásához, amikor egy EMF vagy WMF kép kerül rasterizálásra. Nem definiál globális DPI‑t a SVG-hez, és nem kényszeríti minden diáelemet raszter képpé.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy szorosan elhelyezkedő átlós vonalakat tartalmazó EMF képet tartalmaz. A következő példa az első diát három rasterizációs felbontással exportálja az [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) segítségével. Minden más exportbeállítás azonos marad, hogy az eredményeket össze lehessen hasonlítani.

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

A kimenetben az EMF minden SVG-ben egy beágyazott PNG-vé alakult. A következő mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI pixelméretre történő átváltásához.

| Metafájl rasterizációs DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert ugyanakkora nagyított megjelenítési méreten mutatja. A diagonális vonalak látható pixelesítést mutatnak 72 DPI-nél, míg magasabb felbontásnál simább élűek, eközben az SVG fájl mérete nő. Az érték növelése nem feltétlenül javít minden részletet vagy módosít minden exportált képet.

![Nagyított diagonális vonal részlet 72, 150 és 300 DPI-n](metafile-rasterization-comparison.png)

A [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) szabályozza a kép felbontáscsökkentést, és elrejtheti a metafájl rasterizációs felbontás változásának hatását. A [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) a JPEG kódolási minőséget szabályozza, nem a metafájl rasterizációs felbontást.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja az [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/)‑t az [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) beállításához minden SVG alakzathoz. Ahhoz, hogy a szöveg `tspan` elemein is beállítsa az [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) értékeket, valósítsa meg az [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Bármelyik vezérlőt rendelje hozzá a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) segítségével.

A következő vezérlő a [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) értéket használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegspánokhoz. Ez a generált azonosítókat alkalmasá teszi egy változatlan prezentáció utófeldolgozásához.

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

Az [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/)‑ben hívja meg a [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) egy [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. A vezérlőt rendelje hozzá a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) használatával, és definiálja a JavaScript függvényt az oldalon vagy az SVG-dokumentumban, amely a kimenetet tartalmazza.

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

A gazdaoldal definiálhatja a kézkezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, akadálymentesítési fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)‑t használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)‑t, ha minden szöveget függetlennek kell tenni a betűkészletektől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)‑t, ha csak a külső betűkészleteket használó szövegeket kívánja grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészletek törlésével, és a linkelt betűfájlok kiválasztásával, ha a célkörnyezet képes kiszolgálni azokat. Tesztelje az eredményt, mert az alacsonyabb képfelbontás, alacsonyabb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatok exportált SVG elemeket az export után?**

Igen. Rendeljen azonosítókat egy formázási vezérlővel, majd válassza ki a megfelelő SVG elemeket a utófeldolgozó eszközében vagy böngészőszkriptjében.