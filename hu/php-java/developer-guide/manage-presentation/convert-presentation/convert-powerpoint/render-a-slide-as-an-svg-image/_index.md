---
title: Prezentációs diák renderelése SVG képekként PHP-ben
linktitle: Dia SVG-re
type: docs
weight: 50
url: /hu/php-java/render-a-slide-as-an-svg-image/
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
- PHP
- Aspose.Slides
description: "Exportálja a PowerPoint diákot SVG képekként PHP-ben, és irányítsa a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy skálázható XML-alapú képfájlformátum, amely jól működik webes közzétételhez, diavetítőkhöz, akadálymentesítési munkafolyamatokhoz és automatikus utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG-fájlba exportál, és lehetővé teszi a szöveg, betűkészletek, képek és SVG-elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/) akkor, amikor az exportált SVG-nek kompaktnak, böngészők között kiszámíthatónak vagy interaktív használatra készen kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/), válasszon ki egy diát, és írja ki egy streambe a [Slide.writeAsSvg](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#writeAsSvg) segítségével. Az alábbi példa a prezentáció minden diáját külön SVG-fájlként exportálja.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

A fájlnév a [Slide.getSlideNumber](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getSlideNumber) értékét használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#writeAsSvg) segítségével, ha egy diavetítőnek vagy weboldalnak csak az adott alakzatra van szüksége.

## **SVG kimenet beállítása**

[A SVGOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/) szabályozza az SVG renderelését. Szövegkeretek esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setUseFrameSize) a szövegkeretet belefoglalja a renderelési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setUseFrameRotation) pedig meghatározza, hogy a keret forgatása alkalmazásra kerül-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `true`-ra, amikor a szöveget ligatúrák nélkül kell megjeleníteni.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Szöveg és betűkészletek vezérlése**

### **Minden szöveg vektorizálása**

A [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setVectorizeText) értékét `true`-ra állítva a dián lévő összes szöveget vektoros grafikaként írja ki. Ez megszünteti a betűkészlet-függőséget, és a vizuális eredményt egységesebbé teszi a böngészők között, de a szöveg már nem választható vagy kereshető SVG-szövegként.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Válassza ki, hogyan kezelje a külső betűkészleteket**

[A SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles`-t, ha külön fájlokra szeretne hivatkozni, az `Embed`-et, ha a betűkészlet adatot beágyazza az SVG-be, vagy a `Vectorize`-t, ha csak a külső betűkészleteket használó szöveget grafikaként jeleníti meg. Ellenőrizze a betűkészlet licencelését, mielőtt beágyazná a betűket.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Beágyazott képek méretének csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setPicturesCompression) a beágyazott képek felbontásának csökkentéséhez, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) a levágott forrásterületek kihagyásához, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setJpegQuality) a JPEG kódolás minőségének szabályozásához. Ezek a beállítások csökkentik a fájlméretet a kép pontosságának vagy a megmaradt képadatok árán.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Adjon meg egy formázási visszahívást a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setShapeFormattingController) segítségével, hogy minden SVG alakzathoz beállítsa a [SvgShape.setId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgshape/#setId) értékét. A visszahívás a szöveg `tspan` elemekhez is beállíthatja a [SvgTSpan.setId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgtspan/#setId) értékeket.

A PhpJavaBridge nem tud PHP visszahívást meghívni a `writeAsSvg`-ből, amikor stream módban fut. Helyezze a formázási logikát egy kis Java segédosztályba, fordítsa le, és adja hozzá a kapott JAR fájlt a bridge osztályútvonalához. A segéd a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getOfficeInteropShapeId) használhatja, amely stabil az alakzat életciklusa alatt, valamint egy újrahasználható számlálót a szövegszakaszaihoz. Tekintse meg a [Java implementation of `StableSvgIdController`](/slides/hu/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) segédkódot.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **SVG eseménykezelők hozzáadása**

Egy formázási visszahívásban hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgshape/#setEventHandler) egy [SvgEvent](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon hozzá egy exportált alakzathoz. A visszahívást a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setShapeFormattingController) segítségével rendelheti hozzá, és definiálja a JavaScript függvényt az eredményt hostoló oldalon vagy SVG-dokumentumban.

Az stabil azonosítókhoz hasonlóan a visszahívást Java segédben kell megvalósítani, amikor a PhpJavaBridge stream módot használ. A [Java implementation of `SvgEventController`](/slides/hu/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) egy `ActionButton` nevű alakzathoz rendel egy azonosítót és egy `OnClick` kezelőt. Fordítsa le ezt a segédet, adja hozzá a bridge osztályútvonalához `com.example.slides.SvgEventController` néven, és használja PHP-ból a következőképpen:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

A hostoldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, a hozzáférhetőségi fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **GYIK**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setVectorizeText) helyett a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgexternalfontshandling/) használni?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgoptions/#setVectorizeText) akkor, amikor minden szövegnek függetlennek kell lennie a betűkészletektől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgexternalfontshandling/) akkor, amikor csak a külső betűkészleteket használó szöveget kell grafikává alakítani.

**Mi a legjobb módja egy SVG kisebbé tételének?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészek törlésével, és a hivatkozott betűkészlet-fájlok kiválasztásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, a gyengébb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatom-e az exportált SVG elemeket az export után?**

Igen. Rendezzen azonosítókat egy formázási visszahíváson keresztül, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy a böngésző szkriptjében.