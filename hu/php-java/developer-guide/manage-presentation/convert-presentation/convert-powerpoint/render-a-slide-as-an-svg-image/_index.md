---
title: PowerPoint prezentációs diák renderelése SVG képekként PHP-ben
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
description: "Exportálja a PowerPoint diákat SVG képekként PHP-ben, és vezérelje a betűkészleteket, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájlformátum, amely jól működik webes publikálásnál, diavetítőkben, akadálymentesítési munkafolyamatokban és automatikus utófeldolgozásnál. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi a szöveg, betűkészletek, képek és SVG elemek írásának vezérlését.

Használja a [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) akkor, ha az exportált SVG-nek kompaktnak, a böngészők között kiszámíthatónak vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), válasszon ki egy diát, és írja ki egy adatfolyamba a [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) segítségével. Az alábbi példa a bemutató minden diáját külön SVG fájlként exportálja.

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

A fájlnév a [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) értékét használja a ciklusindex helyett. Egy adott alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) segítségével, ha egy diavetítő vagy weboldal csak azt az alakzatot igényli.

## **SVG kimenet konfigurálása**

Az [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) szabályozza az SVG megjelenítését. Szövegkereteknél a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) a szövegkeretet is belefoglalja a megjelenítési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) pedig meghatározza, hogy a keret forgatása alkalmazásra kerüljön-e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `true`‑ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

Diák SVG‑be exportálásakor szabályozhatja, hogy a szöveg szövegként maradjon vagy vektorgrafikává konvertálódjon, valamint hogy a külső betűkészletek hogyan legyenek beágyazva vagy hivatkozva. Az alábbi beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szövegkiválasztást és a betűkészlet‑függőségeket az exportált SVG-ben.

### **Minden szöveg vektorgrafikává alakítása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) értékét `true`‑ra, hogy a diák teljes szövege vektorgrafikaként kerüljön kiírásra. Ez megszünteti a betűkészlet‑függőségeket és a vizuális eredményt böngészőközti szinten egységesebbé teszi, de a szöveg már nem lesz kiválasztható vagy kereshető SVG‑szövegként.

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

A [SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) a [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) értékét használja a külsőleg betöltött betűkészletekhez. Válassza a `AddLinksToFontFiles` opciót, ha külön betűfájlokra szeretne hivatkozni, a `Embed` opciót a betűkészlet‑adatok SVG‑be ágyazásához, vagy a `Vectorize` opciót, ha csak a külső betűkészleteket használó szöveget kíván grafikaként megjeleníteni. Ellenőrizze a betűkészlet licencelését a beágyazás előtt.

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

A [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) segítségével csökkentheti a beágyazott képek felbontását, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) a levágott forrásterületek kihagyására, a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) pedig a JPEG kódolás minőségének szabályozására szolgál. Ezek a beállítások a fájlméretet csökkentik a kép pontosságának vagy a megőrzött képadatok költségén.

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

## **Metafájl rasterizálási felbontásának vezérlése**

A [SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) beállítja a metafájlok SVG exportálása során történő rasterizálásának alacsonyabb felbontáskorlátját. Használja a részletesség és a fájlméret egyensúlyozásához, amikor EMF vagy WMF képet rasterizál. Nem határozza meg a SVG globális DPI‑ját, és nem kényszeríti, hogy a dia minden objektuma raszteres képpé alakuljon.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely szorosan elhelyezkedő átlós vonalakkal rendelkező EMF képet tartalmaz. Az alábbi példa az első diát három rasterizálási felbontásban exportálja a [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) segítségével. A többi exportbeállítás változatlan marad, hogy az eredmények összehasonlíthatók legyenek.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

A kimenetben az EMF minden SVG-ben egy beágyazott PNG‑re konvertálódik. Az alábbi mérések a mellékelt bemutatóra vonatkoznak; nem általános képlet a DPI‑ról pixelméretre történő átváltáshoz.

| Metafájl rasterizálás DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott rasztert mutatja ugyanakkora nagyított megjelenítési mérettel. A diagonális vonalak látható pixelesedést mutatnak 72 DPI‑n, míg magasabb felbontásnál simább élűek, közben az SVG fájl mérete nő. Az érték növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képen.

![Nagyított átlós vonal részlet 72, 150 és 300 DPI](metafile-rasterization-comparison.png)

A [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl rasterizálási felbontás változtatásának hatását. A [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) a JPEG kódolás minőségét szabályozza, nem a metafájl rasterizálási felbontását.

## **Stabil azonosítók hozzárendelése alakzatokhoz és szöveghez**

Adjon meg egy formázási visszahívást a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)‑nek, hogy minden SVG alakzatra beállítsa a [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) értékét. A visszahívás a szöveg `tspan` elemeire is beállíthatja a [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) értékeket.

PhpJavaBridge nem tud PHP visszahívást meghívni a `writeAsSvg` során, ha adatfolyam módot használ. Helyezze a formázási logikát egy kis Java segédosztályba, fordítsa le, és adja hozzá a kapott JAR fájlt a bridge osztályútvonalához. A segéd a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)‑t használhatja, amely stabil a forma élettartama alatt, valamint egy ismételhető számlálót a szöveg‑spannekhez. Lásd a [Java implementation of `StableSvgIdController`](/slides/hu/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) segédkódot.

A lefordított `com.example.slides.StableSvgIdController` osztály bridge osztályútvonalához való hozzáadása után hozza létre példányát PHP‑ból, és rendelje hozzá a `SVGOptions`‑hoz:

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

Formázási visszahívásban hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler)‑t egy [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon egy exportált alakzathoz. A visszahívást a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)‑vel rendelje hozzá, és határozza meg a JavaScript függvényt az oldalon vagy az SVG dokumentumban, amely a kimenetet tartalmazza.

Az stabil azonosítókhoz hasonlóan a visszahívást Java segédosztályban kell megvalósítani, ha a PhpJavaBridge adatfolyam módot használ. A [Java implementation of `SvgEventController`](/slides/hu/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) egy ID‑t és egy `OnClick` kezelőt rendel a `ActionButton` nevű alakzathoz. Fordítsa le ezt a segédet, adja hozzá a bridge osztályútvonalához `com.example.slides.SvgEventController` néven, és használja PHP‑ból a következő módon:

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

A gazdaoldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diavetítőket, akadálymentesítési fejlesztéseket és egyéb interaktív SVG munkafolyamatokat.

## **FAQ**

**Mikor kell a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)‑t használni a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) helyett?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText), ha minden szöveget függetlené kell tenni a betűkészletektől. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/), ha csak a külső betűkészleteket használó szöveget kell grafikává konvertálni.

**Mi a legjobb módja az SVG méretének csökkentésére?**

Kezdje a beágyazott képek tömörítésével, a levágott képterületek törlésével, és a hivatkozott betűfájlok kiválasztásával, ha a célkörnyezet képes azokat kiszolgálni. Tesztelje az eredményt, mert az alacsonyabb képfelbontás, alacsonyabb JPEG minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszumokkal jár.

**Módosíthatom az exportált SVG elemeket az export után?**

Igen. Rendeljen ID‑ket egy formázási visszahívással, majd válassza ki a megfelelő SVG elemeket az utófeldolgozó eszközében vagy a böngésző‑szkriptben.