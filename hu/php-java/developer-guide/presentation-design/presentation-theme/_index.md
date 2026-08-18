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
description: "Kezelje a prezentációk fő témáit az Aspose.Slides PHP számára Java-n keresztül, hogy egységes márkázással hozzon létre, testreszabjon és konvertáljon PowerPoint fájlokat."
---
## **Bevezetés**

Egy prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témára érzékeny objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékkel tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ban a prezentáció szintű téma a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) segítségével érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. A master a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterthememanager/) segítségével felülírhatja a prezentáció témáját, míg egy elrendezés vagy egy egyedi dia a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) segítségével felülírhatja a örökölt témát. Gyakorlatban egy dia tényleges témája ezen öröklődési láncon keresztül kerül feloldásra: prezentációs téma, master felülírás, elrendezés felülírás és dia felülírás.

![Téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a hatékony értékek kiolvasása az öröklődés és felülírások feloldása után.

## **Téma vizsgálata**

A [MasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/), a [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) és a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) metódusokkal teszi elérhetővé. A gyűjtemények vizsgálata a módosítások előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stíluselemek száma és tartalma változó lehet.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelzi, hogy hány háttér, kitöltés, vonal és effektus‑stílus van tárolva a témában:

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

Ha egy fájl több master‑t használ, ne feltételezze, hogy minden dia ugyanazzal a tényleges témával rendelkezik. Vizsgálja meg a diával kapcsolatos master‑t, és használja a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témára érzékeny kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolásból. Amikor a megfelelő bejegyzést a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/)‑ben módosítja, minden olyan objektum, amely még mindig a témaszínre hivatkozik, az új érték szerint lesz feloldva. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi végpont‑tól‑végpont példában egy alakzatot hozunk létre, amely a `Accent4` színt használja, a téma `Accent4` színét pirosra állítjuk, elmentjük a prezentációt, újra megnyitjuk, és kiírjuk a tényleges kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, látható színe pirosra változik a téma módosítása után. Ha a téma‑színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4`‑változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma‑színből világosabb és sötétebb változatokat színtranszformációk alkalmazásával állít elő. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colortransformoperation/) felsorolásával teszi elérhetővé.

![A fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** - Fő téma színek.

**2** - Világosabb és sötétebb változatok, melyek a fő téma színekből származnak.

Az alábbi példa hat téglalapot hoz létre a `Accent4`‑ből, ötötön luminancia‑transzformációt alkalmaz, majd elmenti az eredményt:

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

### **`SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan konvertált értékek egyik formából a másikba.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűkészletet tartalmaz a címsorokhoz és egy másodlagos betűkészletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) metódusok ezeket a készleteket exponálnak.

PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók használhatók szövegformázásban:

* `+mn‑lt` - Törzsszöveg latin (Minor latin betűtípus)
* `+mj‑lt` - Címsor latin (Major latin betűtípus)
* `+mn‑ea` - Törzsszöveg kelet‑ázsiai (Minor kelet‑ázsiai betűtípus)
* `+mj‑ea` - Címsor kelet‑ázsiai (Major kelet‑ázsiai betűtípus)

Az alábbi példa egy címsort hoz létre, amely a fő latin téma‑betűtípust használja, valamint egy törzssorban a kisebb latin betűtípust alkalmazza. Ezután módosítja a téma‑betűtípusokat és elmenti az eredményt:

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

A cím a fő betűtípust követi, a törzsszöveg a kisebb betűtípust. Azok a szövegek, amelyek explicite betűtípust adnak meg a téma‑azonosító helyett, nem váltanak automatikusan, ha a téma‑betűtípus‑sémája megváltozik.

{{% alert color="info" title="Tip" %}}
További információért a prezentáció betűtípusaival kapcsolatban, lásd a [PowerPoint Fonts](/slides/hu/php-java/powerpoint-fonts/) oldalt.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Forrás téma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti kialakítást, klónozza a forrás‑master‑t a cél‑prezentációba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) segítségével, majd a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) és a klónozott master segítségével klónozza. Ez a master‑t, az elrendezéseket és a hozzá tartozó témát együtt viszi.

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

Ez a preferált munkafolyamat, amikor a forrás‑dia megjelenése ugyanúgy kell, hogy legyen a cél‑helyen. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑master‑re megváltoztathatja a téma‑alapú színeket, betűtípusokat, háttereket és effektusokat.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑dia a jelenlegi master‑en és elrendezésen marad, inicializáljon egy dia‑szintű felülírást a forrás‑témából. Az [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/), az [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) és az [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódusok a három fő téma‑komponenst átmásolják a felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy a többi diára örökölt témát befolyásolná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg az [OverrideTheme.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódust.

### **Téma felülírásának alkalmazása egy elrendezésre**

Egy elrendezés‑szintű felülírás az arra épülő diákra vonatkozik, hacsak egy adott dia nem rendelkezik saját felülírással. Ugyanezeket az inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslidethememanager/) segítségével is használhatja:

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

Használjon master‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑kialakítással kell rendelkeznie, egy elrendezés‑felülírást, ha egy elrendezés‑családnak eltérő formázásra van szüksége, és csak egy dia‑felülírást valósítson meg valódi kivételek esetén. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változások előrejelzését.

## **Téma háttérstílusainak frissítése**

A téma háttér‑kitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/)‑ben vannak tárolva. A PowerPoint a felhasználói felületen több háttér‑választási lehetőséget mutathat, mint a gyűjteményben fizikailag tárolt kitöltésdefiníciók száma, mivel a UI a téma‑kitöltéseket a téma‑színekkel és egyéb stílus‑referenciákkal kombinálhatja.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.getStyleIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) értéket. A `0`‑ás index azt jelenti, hogy nincs témához kötött kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a PHP gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelöli. Ne tételezze fel, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelzi a rendelkezésre álló háttér‑kitöltések számát, egy tematikus háttér‑referenciát rendel az első masterhez, majd elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, akkor csak a master háttér módosítása nem változtatja meg azt a diát. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) metódust, amikor a végső, öröklődés után számító háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet nullára alapozott gyűjtemény‑indexként. Kerülje el egy fájlból származó stílus‑szám hard‑kódolását, és annak feltételezését, hogy egy másik fájlban ugyanazt a megjelenést eredményezi; a téma‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázással és a háttér‑öröklődéssel kapcsolatban tekintse meg a [Presentation Background](/slides/hu/php-java/presentation-background/) részt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/), a [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) és a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak a gyűjteményeket kell vizsgálnia, ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzaton alkalmazva](presentation-design_10.png)

PHP‑ban a gyűjtemény indexe nullára alapozott: a `get_Item(0)` az első tárolt stílust, a `get_Item(2)` a harmadikat jelenti. Az alakzat‑stílus‑referencia‑indexek egy külön fogalom, a [ShapeStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapestyle/) révén érhetők el. A téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetében az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus erősen erdei zöldre, a harmadik effektus‑stílus pedig 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílus‑helyet hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok a vonal‑, kitöltés‑ és árnyék‑beállítások módosítása után](presentation-design_11.png)

## **Tényleges témaértékek olvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A tényleges értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Egy diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) metódust hívja, egy háttérre a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/), egy kitöltésre pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) metódust.

Az alábbi példa beolvassa a tényleges témát, a háttér‑stílust és az első alakzat kitöltését egy diáról:

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

Használja a tényleges adatokat diagnosztikához, érvényesítéshez és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/)‑t vizsgálja, előfordulhat, hogy egy master‑, elrendezés‑, dia‑ vagy alakzat‑felülírást mellőz, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a master‑t módosítanám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidethememanager/)‑t és inicializálja annak felülírt témáját. A módosítás csak arra a diára lesz lokális; a többi dia a meglévő témákat örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációról a másikra?**

Amikor egy diát áthelyez és meg akarja őrizni a forrás megjelenését, klónozza a forrás‑master‑t a célba, majd a diát a klónozott master‑rel a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) segítségével. Ez a master‑t, az elrendezéseket és a témát együtt tartja.

**Hogyan tekinthetem meg a tényleges értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) metódust egy dia vagy elrendezés témához, valamint a megfelelő effektív‑adat metódusokat olyan formátum‑objektumok esetén, mint a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/). Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülírások alkalmazása után.