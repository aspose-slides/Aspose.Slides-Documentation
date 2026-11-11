---
title: Prezentációs diák SVG képekként történő renderelése PHP-ben
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
description: "Exportálja a PowerPoint diákat SVG képekként PHP-ben, és szabályozza a betűtípusokat, szöveget, képeket, azonosítókat és eseményeket az Aspose.Slides segítségével."
---
## **Áttekintés**

Az SVG egy méretezhető XML-alapú képfájlformátum, amely jól működik webes közzétételhez, diaolvasókhoz, akadálymentesítési munkafolyamatokhoz és automatizált utófeldolgozáshoz. Az Aspose.Slides minden diát külön SVG fájlba exportál, és lehetővé teszi, hogy szabályozza, hogyan íródnak a szövegek, betűkészletek, képek és SVG elemek.

Használja a [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) lehetőséget, ha az exportált SVG-nek kompakt, böngészők között kiszámítható vagy interaktív használatra késznek kell lennie.

## **Dia exportálása SVG-ként**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)-t, válasszon ki egy diát, és írja egy adatfolyamba a [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) segítségével. Az alábbi példa minden diát külön SVG fájlként exportál.

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

A fájlnév a [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) értékét használja a ciklusindex helyett. Egyetlen alakzatot is exportálhat a [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) segítségével, ha a diaolvasónak vagy weboldalnak csak az az alakzat szükséges.

## **SVG kimenet konfigurálása**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) szabályozza az SVG megjelenítését. Szövegdobozok esetén a [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) belefoglalja a szövegdobozt a megjelenítési területbe, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) pedig meghatározza, hogy a keret forgatása alkalmazásra kerüljön‑e. Állítsa a [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) értékét `true`‑ra, ha a szöveget ligatúrák nélkül kell megjeleníteni.

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

## **Vonalvég vágásának szabályozása nyílhegyeknél**

Az SVG 1.1 nem tartalmaz marker inset beállítást, amely meghatározná, hol álljon le a vonal a nyílhegy alatt. Alapértelmezés szerint az Aspose.Slides lerövidíti az exportált vonalat, hogy a vonal ne lógjon ki a markerből. Hívja a [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) metódust `true`‑val, hogy a vonal a teljes eredeti végpontig legyen rajzolva. Ez a beállítás csak az SVG kimenetet érinti; a vonal pozíciója és hossza a dián változatlan marad.

A példa háromszög‑ és rombusz‑nyílhegyeket rajzol 2‑ és 10‑pontos vonalakon. Kétszer exportálja ugyanazt a diát, csak a vágás beállítását változtatva.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Az összehasonlítás a 10‑pontos vonalon lévő háromszög‑nyílhegyet mutatja. Ha a vágás be van kapcsolva, a csúcs éles. Ha ki van kapcsolva, a vonal kinyúl a nyílhegy ferde oldalain, és lapos vége lesz.

![Nagyított 10‑pontos háromszög éles csúccsal, ha a vágás be van kapcsolva, és lapos véggel, ha ki van kapcsolva](line-end-cropping.png)

A példában szereplő többi vonalon a kinyúló vonal kevésbé látható a 2‑pontos háromszögnél. A kitöltött rombusz mindkét szélességnél lefedi a vonal végét.

## **Szöveg és betűtípusok vezérlése**

SVG‑be exportáláskor szabályozhatja, hogy a szöveg szövegként marad‑e vagy vektorgrafikává alakul‑e, és hogy a külső betűtípusok hogyan legyenek beágyazva vagy hivatkozva. Az alábbi beállítások segítenek egyensúlyba hozni a vizuális konzisztenciát, a szövegkiválasztást és a betűtípus‑függőségeket az exportált SVG‑ben.

### **Minden szöveg vektorizálása**

Állítsa a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) értékét `true`‑ra, hogy minden diaszöveget vektorgrafikaként írjon. Ezzel megszűnnek a betűtípus‑függőségek, és a megjelenés böngészők között egységesebb, de a szöveg már nem lesz kiválasztható vagy kereshető SVG‑szövegként.

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

### **Válassza ki, hogyan kezelje a külső betűtípusokat**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) egy [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) értéket használ a külsőleg betöltött betűtípusokhoz. Válassza a `AddLinksToFontFiles` opciót, ha külön betűfájlokra szeretne hivatkozni, az `Embed` opciót, ha a betűkészlet adatát be szeretné ágyazni az SVG‑be, vagy a `Vectorize` opciót, ha csak a külső betűtípust használó szöveget kívánja grafikai elemmé alakítani. A betűtípusok beágyazása előtt ellenőrizze a licencelést.

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

## **Beágyazott képméret csökkentése**

Használja a [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) lehetőséget a beágyazott képek felbontásának csökkentésére, a [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) lehetőséget a levágott forrásterületek elhagyására, és a [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) lehetőséget a JPEG kódolás minőségének szabályozására. Ezek a beállítások a fájlméretet csökkentik, de a kép hűsége vagy a megőrzött képadatok költségén.

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

## **Metafájl raszterizálási felbontásának vezérlése**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) alacsonyabb felbontási határt állít be a metafájlok raszterizálásához SVG exportálás közben. Ezzel a részletesség és a fájlméret egyensúlyát szabályozhatja, ha egy EMF vagy WMF képet raszterizál. Nem definiál globális DPI‑t az SVG‑nek, és nem kényszeríti, hogy a dia minden objektuma raszteres képpé váljon.

Töltse le a [metafile-rasterization.pptx](metafile-rasterization.pptx) fájlt, amely egy EMF képet tartalmaz szorosan elhelyezkedő átlós vonalakkal. Az alábbi példa az első diát három raszterizálási felbontáson exportálja a [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/) segítségével. Az összes többi exportbeállítás azonos marad, hogy az eredményeket össze lehessen hasonlítani.

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

| Metafájl raszterizálási DPI | Beágyazott PNG méretek | SVG fájlméret (bájt) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Az alábbi összehasonlítás ugyanazt a beágyazott raszteres területet mutatja azonos nagyított megjelenítési mérettel. A 72 DPI‑nál látható pixelálás, a magasabb felbontáson simább élek, míg a SVG‑fájl mérete nő. A felbontás növelése nem feltétlenül javít minden részletet vagy változtat minden exportált képet.

![Nagyított átlós vonal részlete 72, 150 és 300 DPI‑n](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) szabályozza a képfelbontás csökkentését, és elrejtheti a metafájl raszterizálási felbontás változtatásának hatását. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) a JPEG kódolás minőségét, nem pedig a metafájl raszterizálási felbontását szabályozza.

## **Állandó azonosítók hozzárendelése alakzatokhoz és szöveghez**

Adjon meg egy formázási visszahívást a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) számára, hogy minden SVG alakzatra beállítsa a [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) értékét. A visszahívás a szöveg `tspan` elemeire is beállíthatja a [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) értékeket.

A PhpJavaBridge nem tud PHP visszahívást meghívni a `writeAsSvg`‑ből, ha adatfolyam‑módban fut. Helyezze a formázási logikát egy kis Java segédosztályba, fordítsa le, és adja hozzá a kapott JAR fájlt a bridge osztályúthoz. A segéd a [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) metódust használhatja, amely az alakzat élettartama alatt stabil, valamint egy ismételhető számlálót a szöveg‑spannekhez. Tekintse meg a [Java implementation of `StableSvgIdController`](/slides/hu/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) segédkódot.

A lefordított `com.example.slides.StableSvgIdController` osztály bridge osztályúthoz történő hozzáadása után példányosítsa PHP‑ból, és rendelje az `SVGOptions`‑hoz:

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

Egy formázási visszahívásban hívja meg a [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) metódust egy [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) értékkel, hogy JavaScript eseménykezelőt adjon egy exportált alakzathoz. A visszahívást a [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) segítségével rendelje, és definiálja a JavaScript függvényt az eredményt befogadó oldalon vagy SVG‑dokumentumban.

Az állandó azonosítókhoz hasonlóan a visszahívást Java segédben kell megvalósítani, ha a PhpJavaBridge adatfolyam‑módban dolgozik. A [Java implementation of `SvgEventController`](/slides/hu/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) egy `ActionButton` nevű alakzathoz ad egy azonosítót és egy `OnClick` kezelőt. Fordítsa le ezt a segédet, adja hozzá a bridge osztályúthoz `com.example.slides.SvgEventController` néven, és használja PHP‑ból a következő módon:

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

A host oldal definiálhatja a kezelő által hivatkozott JavaScript függvényt. Az azonosítók és eseménykezelők hozzárendelése lehetővé teszi a diaolvasók, az akadálymentesítési fejlesztések és egyéb interaktív SVG munkafolyamatok használatát.

## **GYIK**

**When should I use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) instead of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Használja a [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) lehetőséget, ha minden szövegnek függetlennek kell lennie a betűtípusoktól. Használja a [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) lehetőséget, ha csak a külső betűtípust használó szöveget szeretné grafikává alakítani.

**What is the best way to make an SVG smaller?**

Kezdje a beágyazott képek tömörítésével, a levágott képrészek törlésével, és a kapcsolt betűfájlok használatával, ha a célkörnyezet képes ezeket kiszolgálni. Tesztelje az eredményt, mivel az alacsonyabb képfelbontás, az alacsonyabb JPEG‑minőség és a vektorizált szöveg mind különböző minőség‑ és méret‑kompromisszal jár.

**Can I modify exported SVG elements after export?**

Igen. Rendeljen azonosítókat egy formázási visszahívással, majd válassza ki a megfelelő SVG elemeket a poszt‑feldolgozó eszközében vagy böngésző‑szkriptjében.