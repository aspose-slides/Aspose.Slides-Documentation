---
title: Prezentációs diák SVG képekként Androidon
linktitle: Dia SVG-be
type: docs
weight: 50
url: /hu/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint SVG-be
- prezentáció SVG-be
- dia SVG-be
- PPT SVG-be
- PPTX SVG-be
- SVG exportálási beállítások
- interaktív SVG
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Exportálja a PowerPoint diákat SVG képekként Androidon, és szabályozza a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájl-formátum, amely jól működik webes kiadványokhoz, diavetítőkhez, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides for Android Java‑on keresztül minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűtípusok, képek és SVG elemek írásának szabályozását.

Használja a [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) elemet, ha az exportált SVG‑nek kompakt, a böngészők között kiszámítható vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG‑ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy adatfolyamba az [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) segítségével. Az alábbi példa a prezentáció minden diáját külön SVG fájlba exportálja.

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

A fájlnév a [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) segítségével kerül meghatározásra a ciklus indexe helyett. Egy adott alakzatot is exportálhat a [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) metódussal, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) szabályozza az SVG megjelenítését. Szövegdobozok esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) a szövegdobozt a renderelési területbe veszi bele, míg a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) meghatározza, hogy a doboz forgatása alkalmazásra kerül-e. Az [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) beállítást `true`‑ra állítsa, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

## **Szöveg és betűtípusok vezérlése**

SVG‑képbe exportáláskor szabályozhatja, hogy a szöveg szövegként maradjon vagy vektorgrafikává alakuljon, valamint hogy a külső betűtípusok hogyan legyenek felhasználva vagy hivatkozva. Az alábbi beállítások segítenek egyensúlyt teremteni a vizuális konzisztencia, a szövegkiválasztás és a betűtípus-függőségek között az exportált SVG‑ben.

### **Az összes szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) értékét `true`‑ra, hogy a diák összes szövege vektorgrafikaként kerüljön írásra. Ez kiküszöböli a betűtípus-függőségeket, és a vizuális eredményt konzisztenssé teszi a böngészők között, de a szöveg már nem választható vagy kereshető SVG‑szövegként.

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

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) értéket használ a külső betöltésű betűtípusokhoz. Válassza a [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) lehetőséget, ha külön betűtípusfájlokra szeretne hivatkozni, a [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) lehetőséget, ha a betűtípusadatot az SVG‑be szeretné beágyazni, vagy a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) lehetőséget, ha csak a külső betűtípusokat használó szöveget szeretné grafikaként megjeleníteni. A betűtípusok beágyazása előtt ellenőrizze a licencelést.

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

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) beállítást a beágyazott képek felbontásának csökkentésére, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) beállítást a levágott forrásterületek kihagyására, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) beállítást a JPEG kódolás minőségének szabályozására. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megőrzött képadatok árán.

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

## **Metafájl raszterizálási felbontásának szabályozása**

A [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) beállítás meghatározza az alacsonyabb felbontási határt a metafájlok SVG exportálás közbeni raszterizálásához. Használja részletesség és fájlméret egyensúlyozására, amikor EMF vagy WMF képet raszterizál. Nem definiál globális DPI‑t az SVG‑nek, és nem kényszeríti minden dián lévő elemet raszteres képpé konvertálni.

Letöltse a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy EMF képet tartalmaz szorosan elhelyezkedő átlós vonalakkal. Az alábbi példa az első diáját három raszterizálási felbontásban exportálja a [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) segítségével. Minden egyéb exportbeállítás változatlan, hogy az eredményeket össze lehessen hasonlítani.

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

A kimenetben az EMF minden SVG-ben egy beágyazott PNG‑vé vált. Az alábbi mérések a mellékelt prezentációra vonatkoznak; nem általános képlet a DPI pixelméretekre való átváltásához.

| Metafájl raszterizálási DPI | Beágyazott PNG méretei | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott raszter területet mutatja ugyanakkora nagyított megjelenítési méretben. A diagonális vonalak 72 DPI‑nél látható pixelesedést, magasabb felbontásoknál pedig simább éleket mutatnak, miközben az SVG fájl mérete nő. Az érték növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képet.

![Nagyított diagonális vonal részlet 72, 150 és 300 DPI‑nél](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) szabályozza a kép felbontáscsökkenést, és elfedheti a metafájl raszterizálási felbontás változtatásának hatását. A [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) a JPEG kódolás minőségét szabályozza, nem a metafájl raszterizálási felbontását.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Használja az [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) elemet, hogy minden SVG alakzatra beállítsa az [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) értékét. A szöveg `tspan` elemeire is az [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) értékek beállításához valósítsa meg az [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/)-t. Bármelyik vezérlőt hozzárendelheti a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) segítségével.

Az alábbi vezérlő a [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) metódust használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegspánkokhoz. Ez a generált azonosítókat megfelelővé teszi egy változatlan prezentáció utófeldolgozásához.

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

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)-ben hívja meg az [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) metódust egy [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon az exportált alakzathoz. A vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) segítségével rendelje hozzá, és definiálja a JavaScript függvényt az eredményt tartalmazó oldalban vagy SVG-dokumentumban.

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

A fogadó oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, akadálymentesítési fejlesztéseket és más interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) metódust használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) metódust, ha az összes szöveget a betűtípusoktól függetlennek kell lennie. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) metódust, ha csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a kapcsolt betűtípusfájlok kiválasztásával, ha a célkörnyezet képes kiszolgálni őket. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, a gyengébb JPEG‑minőség és a vektorizált szöveg mind más‑más minőség‑ és méretkompromisszumokat jelent.

**Módosíthatom-e az exportált SVG elemeket az export után?**

Igen. Rendeljen azonosítókat egy formázó vezérlő segítségével, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy böngésző‑szkriptjében.