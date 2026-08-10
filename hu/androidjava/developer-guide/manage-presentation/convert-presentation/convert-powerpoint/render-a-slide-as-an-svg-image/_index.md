---
title: "Diák renderelése SVG képekként Androidon"
linktitle: "Dia SVG-re"
type: docs
weight: 50
url: /hu/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint diák exportálása SVG képekként Androidon, és a betűtípusok, szöveg, képek, azonosítók és események kezelése az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képfájl-formátum, amely jól működik webes közzétételhez, diavetítőknek, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides for Android via Java minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan kerülnek kiírásra a szöveg, betűtípusok, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/) linket, ha az exportált SVG-nek kompakt, böngészők között kiszámítható vagy interaktív használatra készen kell állnia.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) objektumot, válasszon ki egy diát, és írja ki egy stream-be az [ISlide.writeAsSvg](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) metódussal. Az alábbi példa minden diát külön SVG fájlként exportál a bemutatóból.

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

A fájlnév a [ISlide.getSlideNumber](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islide/#getSlideNumber--) metódust használja a ciklus indexe helyett. Egy egyedi alakzatot is exportálhat a [IShape.writeAsSvg](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) metódussal, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

A [SVGOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/) szabályozza az SVG megjelenítést. A szövegdobozok esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) a szövegdobozt a megjelenítési területbe foglalja, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) pedig meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) értékét `true`-ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

## **Szöveg és betűtípusok kezelése**

### **Az összes szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) értékét `true`-ra, hogy a diák minden szövegét vektoros grafikaként írja ki. Ez megszünteti a betűtípus-függőségeket, és a vizuális eredményt konzisztenssé teszi a böngészők között, de a szöveg már nem lesz kiválasztható vagy kereshető SVG-szövegként.

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

### **Válassza ki, hogy a külső betűtípusok hogyan legyenek kezelve**

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. A [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgexternalfontshandling/) értékkel külön betűtípusfájlokra hivatkozhat, a [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgexternalfontshandling/) beágyazza a betűtípus adatokat az SVG-be, vagy a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgexternalfontshandling/) csak a külső betűtípusokat használó szöveget alakítja grafikává. Ellenőrizze a betűtípus licencelését a beágyazás előtt.

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

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) metódust a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) metódust a levágott forrásterületek kihagyásához, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) metódust a JPEG kódolás minőségének szabályozásához. Ezek a beállítások a fájlméretet csökkentik a kép hűség vagy a megőrzött képadatok költségével.

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

Használja a [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) vezérlőt, hogy minden SVG alakzatra beállítsa a [ISvgShape.setId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) értékét. A szöveg `tspan` elemeire is a [ISvgTSpan.setId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) érték beállításához implementálja a [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) interfészt. Bármelyik vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) metódussal rendelheti hozzá.

Az alábbi vezérlő a [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) metódust használja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szövegspánokhoz. Ez a generált azonosítókat alkalmasá teszi a változatlan bemutató utófeldolgozásához.

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

Egy [ISvgShapeFormattingController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) esetén hívja meg az [ISvgShape.setEventHandler](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) metódust egy [SvgEvent](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon hozzá az exportált alakzathoz. A vezérlőt a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) metódussal rendelje hozzá, és definiálja a JavaScript függvényt az oldalban vagy az SVG dokumentumban, amely a kimenetet tartalmazza.

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

A befogadó oldal meghatározhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, az akadálymentesítési fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) metódust használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.setVectorizeText] metódust, ha minden szövegnek függetlennek kell lennie a betűtípusoktól. Használja a [SvgExternalFontsHandling.Vectorize] metódust, ha csak a külső betűtípusokat használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja egy SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészletek törlésével, és a kapcsolt betűtípusfájlok kiválasztásával, ha a célkörnyezet képes ezeket kiszolgálni. Tesztelje az eredményt, mivel a képfelbontás csökkentése, a JPEG minőség csökkentése és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszal jár.

**Módosíthatom-e az exportált SVG elemeket az export után?**

Igen. Rendeljen azonosítókat egy formázó vezérlőn keresztül, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközben vagy böngésző‑szkriptben.