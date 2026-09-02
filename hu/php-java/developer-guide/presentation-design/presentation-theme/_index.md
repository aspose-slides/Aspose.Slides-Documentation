---
title: Prezentációs témák kezelése PHP-ben
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/php-java/presentation-theme/
keywords:
- PowerPoint téma
- bemutató téma
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
- bemutató
- PHP
- Aspose.Slides
description: "Mesterprezentációs témák az Aspose.Slides for PHP (Java-on keresztül) segítségével a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkázással."
---
## **Bevezetés**

Egy bemutató téma egy összehangolt szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témaérzékeny objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre több objektumot is frissíthet.

Az Aspose.Slides‑ben a bemutató‑szintű témához a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) biztosít hozzáférést. Egy bemutató alacsonyabb szinteken is tartalmazhat téma‑felülbírálásokat. A master felülbírálhatja a bemutató témáját a [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egy egyedi dia felülbírálhatja a neki örökölt témát a [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) segítségével. Gyakorlati szempontból a dia hatékony témája ezen öröklődési lánc mentén kerül feloldásra: bemutatói téma, master felülbírálás, elrendezés felülbírálás és dia felülbírálás.

![Téma alkotóelemei: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint a hatékony értékek lekérdezése az öröklődés és felülbírálások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) és [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mastertheme/) segítségével teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése különösen hasznos, ha a bemutató külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hogy hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus tárolódik a témában:

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

Ha egy fájl több master‑t használ, ne feltételezze, hogy minden dia ugyanazt a hatékony témát használja. Ellenőrizze a diához tartozó master‑t, és használja a később ebből a cikkből bemutatott hatékony‑téma munkafolyamatot, amikor elrendezési vagy dia‑felülbírálások létezhetnek.

## **Témaszínek módosítása**

A téma‑érzékeny kitöltések, vonalak és szövegek a [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolt logikai színére hivatkozhatnak. Amikor a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/) megfelelő bejegyzését megváltoztatja, minden, még mindig a téma‑színre hivatkozó objektum az új értékkel kerül feloldásra. Azokra az objektumokra, amelyek közvetlen RGB‑színt használnak, a téma‑szín‑frissítés nem hat.

Az alábbi vég‑végi példa egy olyan alakzatot hoz létre, amely az `Accent4` színt használja, megváltoztatja a téma `Accent4` színét vörösre, elmenti a bemutatót, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, a látható színe pirosra vált a téma módosítása után. Ha a séma‑színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4`‑módosítások már nem befolyásolják azt a kitöltést.

### **Kiegészítő palettáról színek használata**

A PowerPoint világosabb és sötétebb variánsokat származtat egy téma‑színből színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colortransformoperation/) felsoroltban teszi elérhetővé.

![A fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – A fő téma színekből előállított világosabb és sötétebb variánsok.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapján, ötön luminancia‑transzformációt alkalmaz, és elmenti az eredményt:

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

Ezek a variánsok továbbra is a téma‑színen alapulnak. Ha a `Accent4` később megváltozik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) felsorolt a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorscheme/) ugyanazokat a téma‑helyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma‑betűtípusok módosítása**

A téma‑betűtípus‑séma egy fő betűtípus‑készletet tartalmaz a címsorokhoz és egy kisegész betűtípus‑készletet a törzsszöveghez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontscheme/) metódusok ezen készleteket teszik elérhetővé.

A PowerPoint‑kompatibilis téma‑betűtípus‑azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő latin téma‑betűtípust használja, illetve egy törzssort, amely a kisegész latin téma‑betűtípust használja. Ezután megváltoztatja a téma‑betűtípusokat, és elmenti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a kisegész betűtípust követi. A szöveg, amely kifejezett betűtárgyalási nevet tartalmaz a téma‑azonosító helyett, nem vált automatikusan, amikor a téma‑betűtípus‑séma megváltozik.

A fő és kisegész betűtípus‑gyűjtemények tartalmazhatnak betűtípus‑leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek az ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához tekintse meg a [Script‑Specific Theme Fonts](/slides/hu/php-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információ a bemutató‑betűtípusokról a [PowerPoint Fonts](/slides/hu/php-java/powerpoint-fonts/) oldalon található.
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez tartozó diákra**

Használja a [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) metódust, ha rendelkezik egy PowerPoint témafájl (.thmx)‑vel, és minden, egy adott masterhez tartozó diát újraszabni szeretne. Válassza ki a master‑t a [Presentation::getMasters](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) gyűjteményből, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) képvisel, majd adja meg a témafájl elérési útját a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.  
1. Alkalmazza a külső témát az új master‑re.  
1. Hozzárendeli az új master‑t azokhoz a diákhoz, amelyek korábban a kiválasztott masterhez tartoztak.  
1. Visszaadja az így létrehozott [MasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/)-t.

Az alábbi példa egy külső témát alkalmaz az első masterhez tartozó diákra, és elmenti a bemutatót:

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

Érvénytelen, sérült vagy nem támogatott téma esetén [PptxReadException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pptxreadexception/) keletkezhet. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak akkor mentse a bemutatót, amikor a téma sikeresen alkalmazásra került.

Csak a kiválasztott masterhez tartozó diák kerülnek átrendezésre. Más masterhez tartozó diák megőrzik eredeti master‑üket és témájukat. A téma‑érzékeny színek, betűtípusok, kitöltések, vonalak, háttér‑ és effektus‑stílusok a külső témával kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezési‑ és dia‑szintű felülbírálások szintén felülírhatják az új master‑től örökölt értékeket.

A téma olyan betűtípusokra hivatkozhat, amelyek nincsenek jelen a futtatási környezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket [custom font sources](/slides/hu/php-java/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/php-java/font-substitution/) beállítást.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális dia‑ vagy elrendezési‑szintű téma‑felülbírálás létrehozását.

### **Különböző külső témák alkalmazása többmesteres bemutatóban**

Ha a releváns master előre nem ismert, szerezze be egy reprezentatív dia segítségével a [Slide::getLayoutSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/) és a [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslide/) metódusokkal. Minden hívás egy új master‑t hoz létre a bemutatóban, ezért mentse el az eredeti master‑referenciákat a témák alkalmazása előtt.

Az alábbi példa két szakaszból származó diák segítségével meghatározza a master‑eket, és mindkét csoporthoz külön‑külön külső témát alkalmaz:

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

Az első hívás csak a `$firstGroupMaster`‑hez tartozó diákra hat, a második csak a `$secondGroupMaster`‑hez tartozó diákra. Más masterhez tartozó diákok nincsenek átalakítva.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik bemutatóba szeretne helyezni, és megtartani az eredeti megjelenését, klónozza a forrás‑master‑t a cél‑bemutatóba a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) segítségével, majd klónozza a diát a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) és a klónozott master használatával. Így a master, az elrendezései és a hozzájuk tartozó téma együttesen kerül átvitelre.

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

Ez a preferált munkafolyamat, ha a forrás‑dia megjelenése azonos kell legyen a cél‑bemutatóban. A tartalom egyszerű klónozása egy nem kapcsolódó cél‑masterbe megváltoztathatja a téma‑alapú színeket, betűtípusokat, háttereket és effekteket.

### **Témaértékek alkalmazása meglévő diára**

Ha a cél‑diasnak a jelenlegi master‑en és elrendezésen kell maradnia, inicializáljon egy dia‑szintű felülbírálást a forrástémából. A [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) és [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódusok a három fő téma‑komponenst másolják a felülbírálásba.

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

Ez megváltoztatja a dia által használt témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívja a [OverrideTheme.clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/overridetheme/) metódust.

### **Témafelülbírálás alkalmazása elrendezésre**

Az elrendezés‑szintű felülbírálás az adott elrendezést használó diákra vonatkozik, kivéve, ha egy adott dia saját felülbírálással rendelkezik. Ugyanezeket az inicializáló metódusokat a [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/layoutslidethememanager/) segítségével használhatja:

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

Használjon master‑ vagy bemutató‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑designra van szüksége; használjon elrendezés‑felülbírálást, ha egy elrendezés‑családnak más stílusra van szüksége; és csak dia‑felülbírálást alkalmazzon valós kivételek esetén. A túlzott dia‑szintű felülbírálások megnehezítik a későbbi globális téma‑változtatások előreláthatóságát.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/)‑ben tárolódnak. A PowerPoint a felhasználói felületén több háttér‑választási lehetőséget jeleníthet meg, mint amennyi kitöltés‑definíció fizikailag tárolva van ebben a gyűjteményben, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és egyéb stílus‑referenciákkal.

![PowerPoint háttérstílus‑galéria egy bemutató‑témához](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és a jelenlegi [Background.getStyleIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) értéket. A `0`‑es index azt jelenti, hogy nincs téma‑kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a PHP gyűjtemény közvetlen indexelésétől, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezze, hogy minden bemutató ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa jelenti a rendelkezésre álló háttér‑kitöltés számát, egy téma‑háttér‑referenciát rendel az első masterhez, és elmenti a bemutatót:

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

A látható eredmény a master által hivatkozott téma‑bejegyzéstől, valamint az elrendezési vagy dia‑szintű háttér‑felülbírálásoktól függ. Ha egy dia saját háttérrel rendelkezik, a csak a master háttér módosítása nem feltétlenül változtatja meg a dia megjelenését. Használja a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/)‑t, ha a teljes öröklődés után alkalmazott végső háttérre van szüksége.

{{% alert color="warning" title="Warning" %}}
Ne tekintse a stílus‑indexet nullától induló gyűjtemény‑indexnek. Kerülje azt is, hogy egy fájlból származó stílusszámot keményen kódolja, és azt feltételezze, hogy egy másik fájlban ugyanazt a megjelenést adja; a téma‑stílusdefiníciók bemutatónként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázás és a háttér‑öröklődés részletei a [Presentation Background](/slides/hu/php-java/presentation-background/) oldalon találhatók.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája különálló kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) és [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hu/php-java/aspose.slides/formatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív témaeffektek, amelyek ugyanarra az alakzatra vannak alkalmazva](presentation-design_10.png)

PHP‑ban ezekhez a gyűjteményekhez való hozzáféréskor a gyűjtemény indexe nullától indul: a `get_Item(0)` az első tárolt stílus, a `get_Item(2)` a harmadik. Egy alakzat stílus‑referencia‑indexei egy külön fogalom, amely a [ShapeStyle](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapestyle/)‑ben érhető el. Egy téma‑stílus módosítása a rá hivatkozó alakzatokra hat, míg a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

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

A referált slotokat használó alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdei zöldre, a harmadik effektus‑stílus pedig a 10 pont távolságú külső árnyékra változik. A pontos vizuális eredmény továbbra is attól függ, hogy az egyes alakzatok mely slotokra hivatkoznak, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállításainak módosítása után](presentation-design_11.png)

## **Megállapítás, hogy egy hatékony szilárd kitöltés téma‑színt használ‑e**

A kitöltés lehet közvetlenül egy objektumon tárolva, vagy öröklődhet bekezdésből, elrendezésből, master‑ből, téma‑stílusból vagy egy másik formázási szintből. Hívja a [FillFormat::getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) metódust, hogy ezt a hierarchiát feloldja egy változtathatatlan hatékony kitöltési adatra. Először ellenőrizze a `getFillType` eredményét. Csak akkor, ha ez `FillType::Solid`, olvassa el a szilárd‑kitöltés tulajdonságait.

Szilárd kitöltés esetén a `getSolidFillColor` a végső, megjelenített RGB‑értéket adja vissza az öröklődés, a téma‑keresés és a színtranszformációk után. A `getSolidFillSchemeColor` metódus a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/schemecolor/) slotot adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor::NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések vagy téma‑színek, vagy közvetlen RGB‑színek, ez az érték a közvetlen RGB‑kitöltést jelöli.

Ne csak a helyi [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/colorformat/) értékét használja az osztályozáshoz. Például egy szövegrésznek lehet, hogy nincs helyi séma‑színe (`NotDefined`), de a hatékony kitöltése örököl egy téma‑színt, amely `Text1`‑re vagy `Accent6`‑ra vonatkozik. Ezzel szemben a `getSolidFillSchemeColor` megmutatja, hogy mely logikai téma‑slot hozta létre a hatékony színt, de nem mondja meg, hogy a slot az objektumból, bekezdésből, elrendezésből, master‑ből vagy egy másik szintből származik.

Az alábbi példa betölti a bemutatót, auditálja mind az alakzat‑kitöltéseket, mind a szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a hozzájuk tartozó séma‑színt, valamint megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín‑változásokat:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

A `NotDefined` ág egy auditlistát ad a szilárd kitöltésekről, amelyek nem reagálnak a téma‑szín‑slotok változásaira. Ezeket az objektumokat akkor ellenőrizze, amikor egy bemutatónak egy új márka‑palettát kell követnie. A jelentett RGB‑érték továbbra is a jelenlegi megjelenést mutatja, míg a séma‑érték magyarázatot ad arra, hogy ez a megjelenés kapcsolódik‑e a témához.

A hatékony formátumú objektumok "pillanatképek". A bemutató téma, egy téma‑felülbírálás vagy bármely örökölt formázás módosítása után hívja újra a `getEffective`‑et, és olvassa ki az új hatékony kitöltési adatokat, mielőtt összehasonlítaná vagy jelentést készítene a színekről.

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok megmutatják, mi van meghatározva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülbírálások feloldása után. Egy diára a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/) hívható. Háttérre a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/), kitöltésre pedig a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) használható.

Az alábbi példa egy dia hatékony témáját, háttérét és első alakzat kitöltését olvassa be:

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

Használja a hatékony adatokat diagnosztikához, érvényesítéshez és összehasonlításokhoz. Ha csak a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) ellenőrzi, kihagyhat egy master‑, elrendezés‑, dia‑ vagy alakzat‑felülbírálást, amely megváltoztatja a végső megjelenést.

## **GYIK**

**A külső téma alkalmazása minden diára hat a bemutatóban?**

Nem. A [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslide/) csak azokat a diákat rendeli újra, amelyek a kiválasztott masterhez tartoznak. Más master‑t használó diák megtartják meglévő témájukat.

**Alkalmazhatok témát egyetlen diára anélkül, hogy a master‑t megváltoztatnám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidethememanager/)‑jét, és inicializálja a felülbírálás‑témát. A változás csak az adott diára vonatkozik; a többi dia továbbra is a meglévő témáikat örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egyik bemutatóból a másikba?**

Amikor egy diát áthelyez és meg szeretné őrizni a forrás‑megjelenését, klónozza a forrás‑master‑t a cél‑bemutatóba, majd a diát a klónozott masterrel a [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/masterslidecollection/) és a [SlideCollection.addClone](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidecollection/) segítségével. Így a master, az elrendezések és a téma együtt marad.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülbírálások után?**

Használja a [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat‑metódusokat formátumobjektumokhoz, például a [Background.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/background/) és a [FillFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/) hívásokhoz. Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülbírálások alkalmazása után.