---
title: Prezentációs sablonok kezelése PHP-ben
linktitle: Prezentációs sablon
type: docs
weight: 10
url: /hu/php-java/presentation-theme/
keywords:
- PowerPoint sablon
- prezentációs sablon
- dia sablon
- sablon beállítása
- sablon módosítása
- sablon kezelése
- sablon szín
- kiegészítő paletta
- sablon betűkészlet
- sablon stílus
- sablon effektus
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a prezentációs sablonokat az Aspose.Slides PHP számára Java-n keresztül, hogy következetes márkázással hozhasson létre, testreszabhasson és konvertálhasson PowerPoint fájlokat."
---
## **Bevezetés**

A prezentációs sablon (theme) egy koordinált színek, betűtípusok, háttérstílusok, kitöltések, vonalak és effektusok halmazát határozza meg. A sablonra érzékeny objektumok ezeket a közös definíciókat használják, ahelyett, hogy minden vizuális tulajdonságot fix értékként tárolnának, így egy sablonváltoztatás egyszerre számos objektumot frissíthet.

Az Aspose.Slides-ben a prezentációszintű sablon a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) metóduson keresztül érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat sablonfelülbírálásokat. Egy mester felülírhatja a prezentáció sablonját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egységes dia felülírhatja a leszármazott sablont a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) segítségével. Gyakorlatban egy dia hatékony sablonja ezen öröklődési láncon keresztül kerül feloldásra: prezentációs sablon, mester felülbírálás, elrendezés felülbírálás és dia felülbírálás.

![A sablon összetevői: színek, betűk, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb sablonmunkafolyamatokat mutatják be: sablon vizsgálata, színek és betűk megváltoztatása, sablon másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint a hatékony értékek olvasása az öröklődés és a felülbírálások feloldása után.

## **Sablon vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) objektum a sablon színsémáját, betűtípus-sémáját és formátum-sémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) metódusokon keresztül teszi elérhetővé. Ezeknek a gyűjteményeknek a vizsgálata különösen hasznos, amikor egy prezentáció külső forrásból érkezik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa a fő sablon tulajdonságait olvassa be, és jelentést készít arról, hány háttér-, kitöltés-, vonal- és effektusstílus tárolódik a sablonban:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();
    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Ha egy fájl több mestert használ, ne feltételezze, hogy minden dia ugyanazzal a hatékony sablonnal rendelkezik. Vizsgálja meg a diával társított mestert, és használja a később ebben a cikkben bemutatott hatékony-sablon munkafolyamatot, amikor elrendezési vagy diaszintű felülbírálások fordulhatnak elő.

## **Sablonszínek módosítása**

A sablonra érzékeny kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolásból. Amikor módosítja a megfelelő bejegyzést a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/) gyűjteményben, minden, az adott sablonszínt még mindig hivatkozó objektum az új értékhez kerül újraértelmezésre. A közvetlen RGB-színt használó objektumok nem változnak a sablonszín frissítésekor.

Az alábbi végponttól végpontig tartó példa egy olyan alakzatot hoz létre, amely `Accent4`‑et használ, megváltoztatja a sablon `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);
    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Mivel a téglalap továbbra is `Accent4`‑hez van linkelve, látható színe pirosra változik a sablon módosítása után. Ha a sablonszínt közvetlen színre cseréli az alakzaton, a későbbi `Accent4`‑változtatások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettából**

A PowerPoint a sablonszínből világosabb és sötétebb variánsokat színtranszformációk alkalmazásával hoz létre. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colortransformoperation/) felsoroláson keresztül teszi elérhetővé.

![A fő sablonszínek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő sablonszínek.

**2** – A fő sablonszínekből előállított világosabb és sötétebb variánsok.

Az alábbi példa hat téglalapot hoz létre `Accent4`‑en alapulva, ötötön luminancia‑transzformációt alkalmaz, és elmenti az eredményt:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ezek a variánsok továbbra is a sablonszínen alapulnak. Ha `Accent4` később megváltozik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **`SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` nevet használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/) a sablonhelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon sablonhelyek alternatív nevei; nem olyan értékek, amelyeket dinamikusan konvertálnak az egyik formából a másikba.

## **Sablonbetűkészletek módosítása**

Egy sablonbetűkészlet tartalmaz egy fő betűkészletet a címsorokhoz és egy másodlagos betűkészletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) metódusok teszik ezeket a készleteket elérhetővé.

PowerPoint‑kompatibilis sablonbetűkészlet-azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő latin sablonbetűt használ, valamint egy törzssort, amely a kisebb latin sablonbetűt használ. Ezután módosítja a sablonbetűket, és elmenti az eredményt:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A címsor a fő betűt használja, a törzsszöveg pedig a kisebb betűt. A szöveg, amely kifejezett betűnevet tartalmaz a sablonazonosító helyett, nem vált automatikusan, amikor a sablonbetűkészlet megváltozik.

A fő és a kisebb betűgyűjtemények tartalmazhatnak betűtérképeket egyéni írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezek vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/php-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűkészletekről a [PowerPoint Fonts](/slides/hu/php-java/powerpoint-fonts/) oldalon találhatók.
{{% /alert %}}

## **Sablon másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Forrás sablon megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás mestert a célprezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) segítségével, majd klónozza a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) és a klónozott mester segítségével. Így a mester, az elrendezései és a kapcsolódó sablon együtt kerül át.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);
        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);
        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);
        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Ez a preferált munkafolyamat, amikor a forrás dia megjelenése azonos kell legyen a célhelyen. Ha egyszerűen csak tartalmat klónoz egy nem kapcsolódó célmesterre, a sablon‑alapú színek, betűk, háttér és effektusok megváltozhatnak.

### **Sablonértékek alkalmazása egy meglévő diára**

Ha a céldia a jelenlegi mesterén és elrendezésén marad, inicializáljon egy diaszintű felülbírálást a forrás sablonból. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódusok a három fő sablonkomponenst másolják a felülbírálásba.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Ez megváltoztatja a dia által használt sablont anélkül, hogy a többi dia örökölt sablonját módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódust.

### **Sablon felülbírálása egy elrendezésre**

Az elrendezés‑szintű felülbírálás az az elrendezést használó diákra vonatkozik, kivéve, ha egy konkrét dia saját felülbírálással rendelkezik. Ugyanazokat az inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslidethememanager/) segítségével lehet használni:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());
        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Használjon mester‑ vagy prezentáció‑szintű sablont, amikor sok elrendezésnek és diáknak közös alap‑designra van szüksége; használjon elrendezés‑felülbírálást, ha egy elrendezéscsaládnak eltérő stílusra van szüksége, és dia‑felülbírálást csak valódi kivételekhez. A túlzott diagyorsulású felülbírálások megnehezítik a későbbi globális sablonváltoztatások előrejelzését.

## **Sablon háttérstílusok frissítése**

A sablon háttérkitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) metódusban tárolódnak. A PowerPoint a felhasználói felületén több háttérválasztási lehetőséget mutathat, mint amennyi kitöltésdefiníció fizikailag tárolva van ebben a gyűjteményben, mivel a UI kombinálhatja a sablonkitöltéseket sablonszínekkel és egyéb stílusreferenciákkal.

![PowerPoint háttérstílus galéria egy prezentációs sablonhoz](presentation-design_8.png)

Mielőtt háttérstílust használna, vizsgálja meg a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) értéket. A `0`‑es stílusindex azt jelenti, hogy nincs sablon‑kitöltés; a pozitív értékek sablon háttér‑stílus referenciák. Ez különbözik a PHP gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne tételezze, hogy minden prezentáció ugyanannyi háttérkitöltés‑stílussal rendelkezik.

Az alábbi példa jelenti a rendelkezésre álló háttérkitöltés számát, egy sablon háttérreferenciát rendel az első mesterhez, majd elmenti a prezentációt:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);
    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A látható eredmény a mester által hivatkozott sablonbejegyzéstől, valamint az elrendezési vagy diaszintű háttérfelülbírálásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a mester háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) metódust, amikor a végső, örökölt háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne tekintse a stílusindexet nulla‑bázisú gyűjtemény‑indexnek. Kerülje a stílusszámok kódba ágyazását egy fájlból, és annak feltételezését, hogy egy másik fájlban ugyanúgy fog megjelenni; a sablonstílus‑definíciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázáshoz és a háttéröröklődéshez lásd a [Presentation Background](/slides/hu/php-java/presentation-background/) oldalt.
{{% /alert %}}

## **Sablon effektusok frissítése**

A sablon formátumsémája külön kitöltés, vonal és effektus stílusgyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) és [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑sablonok gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázást képviselik, de a kódnak mindig minden gyűjteményt ellenőriznie kell, ahelyett, hogy egy fix számra támaszkodna.

![Finom, közepes és intenzív sablon‑effektusok ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

PHP‑ban ezekhez a gyűjteményekhez való hozzáféréskor a gyűjtemény indexe nulla‑bázisú: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Egy alakzat stílushivatkozási indexei egy külön fogalom, amelyet a [ShapeStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapestyle/) téve elérhetővé. Egy sablonstílus módosítása azoknak az alakzatoknak a megjelenését változtatja meg, amelyek hivatkoznak arra a sablonstílusra; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, megváltoztatja az első vonalstílust, a harmadik kitöltésstílust, engedélyezi a külső árnyékot a harmadik effektusstílusban, majd elmenti az eredményt:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);
    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az ilyen slotokra hivatkozó alakzatok esetén az első sablonvonalstílus pirosra, a harmadik sablonkitöltésstílus szilárd erdőzöldre, a harmadik effektusstílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílushelyet hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülbírálja‑e a sablont.

![Sablon‑effektusstílusok módosítása után: vonal, kitöltés és árnyék beállítások](presentation-design_11.png)

## **Hatékony sablonértékek olvasása**

A nyers sablonobjektumok csak azt mutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, mit használ egy dia vagy alakzat az öröklődés és a lokális felülbírálások feloldása után. Diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) metódust kell hívni. Háttérre a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/), kitöltésre pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) metódust.

Az alábbi példa egy dia hatékony sablonját, háttérét és az első alakzat kitöltését olvassa be:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();
    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;
    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Használja a hatékony adatokat renderelési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/)‑et vizsgálja, könnyen elmulaszthat egy mestert, elrendezést, diát vagy alakzat‑felülbírálást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok sablont egyetlen diára anélkül, hogy a mestert módosítanám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidethememanager/)‑t, és inicializálja a felülbíráló sablont. A módosítás csak arra a diara vonatkozik; a többi dia továbbra is a meglévő sablonjait örökli.

**Mi a legbiztonságosabb módja egy sablon átvitelének egy prezentációból a másikba?**

Amikor egy diát áthelyez és meg akarja őrizni a forrás megjelenését, klónozza a forrás mestert a célba, majd a diát a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) segítségével klónozza. Így a mester, az elrendezések és a sablon együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és a felülbírálások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés sablonjának, valamint a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/). Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és a felülbírálások alkalmazása után.