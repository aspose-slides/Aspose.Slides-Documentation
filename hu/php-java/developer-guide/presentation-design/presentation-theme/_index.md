---
title: Prezentációs témák kezelése PHP-ben
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/php-java/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- külső téma
- THMX
- téma szín
- kiegészítő paletta
- téma betűtípus
- téma stílus
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "A fő prezentációs témák az Aspose.Slides for PHP (Java használatával) létrehozásához, testreszabásához és PowerPoint fájlok konzisztens márkázással történő konvertálásához."
---
## **Bevezetés**

A prezentációs téma meghatároz egy egységes szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet. A témaérzékeny objektumok ezekre a megosztott meghatározásokra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ben a prezentáció szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) segítségével érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. A master a prezentáció témát a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egyedi dia a saját örökölt témáját a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) segítségével felülírhatja. Gyakorlatban egy dia hatékony témája ezen öröklődési lánc mentén kerül feloldásra: prezentációs téma, master felülírás, elrendezés felülírás és dia felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szekciók a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint az öröklődés és felülírások feloldása után kapott hatékony értékek olvasása.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) segítségével teszi elérhetővé. Ezeknek a gyűjteményeknek a módosítás előtti ellenőrzése különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példában kiolvassuk a fő téma tulajdonságait, és jelentést készítünk arról, hogy hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus van tárolva a témában:

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

Ha egy fájl több master‑diát használ, ne feltételezze, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizze a diával társított master‑diát, és használja a később ebben a cikkben bemutatott hatékony téma munkafolyamatot, ha elrendezés‑ vagy diafelülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szövegek a [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolás logikai színére hivatkozhatnak. Amikor módosítja a megfelelő bejegyzést a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/)‑ben, minden objektum, amely még mindig arra a téma‑színre hivatkozik, az új értékhez lesz feloldva. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg egy téma‑szín frissítésekor.

Az alábbi vég‑ponttól‑végig példa létrehoz egy alakzatot, amely a `Accent4` színt használja, megváltoztatja a téma `Accent4` színét pirosra, menti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4` színhez van kapcsolva, látható színe a téma módosítása után pirosra változik. Ha a sémaszínt közvetlen színnel cseréli le az alakzaton, a későbbi `Accent4` módosítások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma‑színből világosabb és sötétebb változatokat színtranszformációk alkalmazásával állít elő. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colortransformoperation/) felsorolásban teszi elérhetővé.

![Fő téma színek és a kiegészítő palettáról generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színeiből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre a `Accent4` alapján, ötötön lumineszcencia‑transzformációt alkalmaz, és elmenti az eredményt:

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

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha később a `Accent4` megváltozik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek egyik formából a másikba.

## **Téma betűtípusainak módosítása**

Egy téma betűtípus‑sémája tartalmaz egy fő betűkészletet a címsorokhoz és egy másodlagos betűkészletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) metódusok teszik ezeket a készleteket elérhetővé.

PowerPoint‑kompatibilis téma‑betűtípus azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő latin téma‑betűtípust használja, valamint egy törzssort, amely a másodlagos latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust követi, a törzsszöveg a másodlagos betűtípust használja. A szöveg, amelynek explicit betűtípus‑neve van a témaazonosító helyett, nem vált át automatikusan, amikor a téma betűtípus‑sémája megváltozik.

A fő és a másodlagos betűtípus‑gyűjtemények tartalmazhatnak betűtípus‑leképezéseket egyes írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a vizsgálatához, hozzáadásához, cseréjéhez vagy eltávolításához tekintse meg a [Script‑Specific Theme Fonts](/slides/hu/php-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információ a prezentáció betűtípusaival kapcsolatban a [PowerPoint Fonts](/slides/hu/php-java/powerpoint-fonts/) oldalon található.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolt problémákat oldanak meg.

### **Külső téma alkalmazása egy master‑függő diákra**

Használja a [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) metódust, ha egy PowerPoint témafájlt (`.thmx`) szeretne alkalmazni, és minden, egy adott master‑diára támaszkodó diát új stílusban szeretne megjeleníteni. Válassza ki a master‑diát a [Presentation::getMasters](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) gyűjteményből, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) képvisel, majd adja át a témafájl elérési útját a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master‑alapból.  
2. Alkalmazza a külső témát az új master‑ra.  
3. Hozzárendeli az új master‑t minden diához, amely korábban a kiválasztott master‑ra támaszkodott.  
4. Visszaadja a frissen létrehozott [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) objektumot.

Az alábbi példa egy külső témát alkalmaz az első master‑ra támaszkodó diákra, majd elmenti a prezentációt:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;
    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Érvénytelen, sérült vagy nem támogatott téma esetén [PptxReadException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxreadexception/) fordulhat elő. Érvényesítse a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentse a prezentációt.

Csak azok a diák kapnak új master‑t, amelyek a kiválasztott master‑ra támaszkodtak. Más master‑khez tartozó diák megőrzik meglévő master‑jaikat és témáikat. A témaérzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑stílusok a külső téma alapján kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és dia‑szintű felülírások felülbírálhatják az új master‑től örökölt értékeket.

A téma utalhat olyan betűtípusokra, amelyek nem érhetők el a futtatási környezetben. A konzisztens renderelés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/php-java/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/php-java/font-substitution/) lehetőséget.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényli a dia‑ vagy elrendezés‑szintű téma‑felülírások kézi létrehozását.

### **Különböző külső témák alkalmazása több‑master prezentációban**

Ha a megfelelő master előre nem ismert, szerezze be azt egy reprezentatív diáról a [Slide::getLayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) és a [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) segítségével. A témaalkalmazás előtt mentse el az eredeti master‑referenciákat, mivel minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szekció diáit használja a master‑k megtalálásához, és mindegyik csoportra egy másik külső témát alkalmaz:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;
            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Az első hívás csak a `$firstGroupMaster`‑ra támaszkodó diákra hat, a második hívás csak a `$secondGroupMaster`‑ra támaszkodó diákra. Más master‑khez tartozó diákok nem kerülnek újraformázásra.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, miközben megőrzi annak eredeti megjelenését, klónozza a forrás‑master‑t a cél‑prezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) segítségével, majd a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) és a klónozott master használatával klónozza. Így a master, annak elrendezései és a hozzá kapcsolódó téma együtt kerül átvitelre.

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

Ez a leginkább ajánlott megoldás, ha a forrás‑dia ugyanúgy kell, hogy kinézzen a cél‑prezentációban. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑master‑ra módosíthatja a téma‑színek, betűtípusok, háttér‑ és effektus‑beállítások megjelenését.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑dia a jelenlegi master‑ és elrendezés‑szintjén marad, inicializáljon egy dia‑szintű felülírást a forrástémából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/), a [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) és a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódusok a három fő téma‑komponenst másolják a felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy a többi dia által örökölt témát megváltoztatná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az arra az elrendezésre épülő diákra vonatkozik, hacsak egy adott dia nem rendelkezik saját felülírással. Ugyanazokat az inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslidethememanager/) segítségével is használhatja:

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

Használjon master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑designra van szüksége, elrendezés‑felülírást, ha egy elrendezés‑családnak különböző stílusra van szüksége, és dia‑felülírást csak valódi kivételekhez. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változások előrejelzését.

## **Téma háttér‑stílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/)‑ben tárolódnak. A PowerPoint a felhasználói felületen több háttér‑választási lehetőséget mutathat, mint a ténylegesen tárolt kitöltés‑definíciók száma, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑referenciákkal.

![PowerPoint háttér‑stílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttér‑stílust alkalmazna, ellenőrizze a tárolt gyűjteményt és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/)-et. A `0`‑ás stílus‑index azt jelenti, hogy nincs témához tartozó kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a PHP gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelentést készít a rendelkezésre álló háttér‑kitöltések számáról, egy témához kötött háttér‑referenciát rendeli az első master‑nek, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/)‑t, ha az öröklődés után a végső háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet null‑alapú gyűjtemény‑indexként. Kerülje a stílus‑számok kódba való beágyazását egy fájlból, és annak feltételezését, hogy egy másik fájlban ugyanazt a megjelenést eredményezi; a téma‑stílus‑definíciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/php-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/), a [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) és a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) exponálnak. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell a rögzített szám feltételezése helyett.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzaton alkalmazva](presentation-design_10.png)

PHP‑ban ezekhez a gyűjteményekhez a gyűjtemény‑index null‑alapú: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Egy alakzat stílus‑referencia indexei egy külön fogalom, a [ShapeStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapestyle/) által exponálva. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek erre a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, a harmadik effektus‑stílusban egy külső árnyékot aktivál, majd elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre, a harmadik effektus‑stílus pedig egy, 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy az egyes alakzatok melyik stílus‑helyre hivatkoznak, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok a vonal‑, kitöltés‑ és árnyék‑beállítások módosítása után](presentation-design_11.png)

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Egy dia esetén hívja meg a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) metódust. Egy háttér esetén használja a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/)-et, kitöltés esetén a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/)-et.

Az alábbi példa beolvassa egy dia hatékony témáját, háttérét és az első alakzat kitöltését:

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

Használja a hatékony adatokat renderelési diagnosztikához, validációhoz és összehasonlításhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/)‑t vizsgálja, muladhat egy master, elrendezés, dia vagy alakzat felülírás, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Érinti-e egy külső téma alkalmazása a prezentáció minden diáját?**

Nem. A [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) csak azokat a diákat rendezi újra, amelyek a kiválasztott master‑ra támaszkodnak. Más master‑t használó diák megőrzik meglévő témájukat.

**Alkalmazhatok‑e témát egyetlen diára a master módosítása nélkül?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidethememanager/)‑jét, és inicializálja a felülírt témát. A módosítás csak arra a diára vonatkozik; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból a másikba?**

Diák áthelyezésekor és eredeti megjelenésük megőrzésekor klónozza a forrás‑master‑t a cél‑prezentációba, majd a diát a klónozott master‑rel együtt a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) segítségével. Így a master, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és a felülírások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) metódusokat. Ezek az API‑k a öröklődés és a felülírások feloldása után visszaadják a feloldott értékeket.