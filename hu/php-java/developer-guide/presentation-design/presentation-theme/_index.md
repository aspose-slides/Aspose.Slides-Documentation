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
- téma betűtípusa
- téma stílusa
- téma effektusa
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Az Aspose.Slides PHP (Java segítségével) fő prezentációs témái a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához konzisztens márkázással."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet definiál. A téma‑tudatos objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma‑váltás egyszerre több objektumot frissíthet.

Az Aspose.Slides-ben a prezentáció-szintű téma a [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) metóduson keresztül érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülbírálásokat. Egy master felülbírálhatja a prezentáció témáját a [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/) segítségével, míg egy elrendezés vagy egyedi dia felülbírálhatja a örökölt témát a [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) metódussal. Gyakorlatban egy dia hatékony témája ezen öröklődési lánc mentén kerül feloldásra: prezentációs téma, master felülbírálás, elrendezés felülbírálás és dia felülbírálás.

![Téma komponensek: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint az öröklődés és felülbírálások feloldása után kapott hatékony értékek olvasása.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) objektum a téma színsémáját, betűtípus‑sémáját és formátumsémáját a [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), a [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) és a [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) metódusokon keresztül teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mert a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa kiolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hogy hány háttér‑, kitöltés‑, vonal‑ és effektusstílus van tárolva a témában:

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

Ha a fájl több master‑t használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizzük a diára vonatkozó master‑t, és a később bemutatott “effective‑theme” munkafolyamatot használjuk, amikor elrendezési vagy dia‑felülbírálások is létezhetnek.

## **Téma színeinek módosítása**

A téma‑tudatos kitöltések, vonalak és szövegek egy logikai színre hivatkozhatnak a [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) felsorolásból. Amikor a megfelelő bejegyzést módosítjuk a [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/)‑ben, minden olyan objektum, amely még mindig az adott téma‑színre hivatkozik, az új értékhez lesz feloldva. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg egy téma‑szín frissítésekor.

Az alábbi vég‑végi példa egy `Accent4` színt használó alakzatot hoz létre, a téma `Accent4` színét pirosra állítja, elmenti a prezentációt, újra megnyitja, majd kiírja a hatékony kitöltés‑színt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, a látható színe pirosra vált a téma módosítása után. Ha a téma‑színt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4`‑változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma‑színből világosabb és sötétebb változatokat színtranszformációk alkalmazásával származtat. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/) felsorolás segítségével teszi elérhetővé.

![A fő téma színei, valamint a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színei.

**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre `Accent4` alapján, az ötöt luminansz‑transzformációval módosítja, majd elmenti az eredményt:

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

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha a `Accent4` később megváltozik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **A `SchemeColor` értékek leképezése a `ColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg a [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív elnevezései; nem dinamikusan konvertált értékek.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűtípus‑készletet tartalmaz a címsorokhoz és egy mellékes betűtípus‑készletet a törzsszöveghez. A [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) és a [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) metódusok ezeket a készleteket teszik elérhetővé.

A PowerPoint‑kompatibilis téma‑betűtípus azonosítók a szövegformázásban használhatók:

* `+mn‑lt` – Body Font Latin (Minor Latin Font)
* `+mj‑lt` – Heading Font Latin (Major Latin Font)
* `+mn‑ea` – Body Font East Asian (Minor East Asian Font)
* `+mj‑ea` – Heading Font East Asian (Major East Asian Font)
* `+mn‑cs` – Body Font Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Heading Font Complex Script (Major Complex Script Font)

Az alábbi példa létrehoz egy címsort, amely a fő Latin téma‑betűtípust, valamint egy törzssort, amely a mellékes Latin téma‑betűtípust használja. Ezután módosítja a téma‑betűtípusokat és elmenti az eredményt:

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

A címsor a fő betűtípusnak, a törzsszöveg pedig a mellékes betűtípusnak felel meg. Az explicit betűtípus‑névvel ellátott szöveg nem vált automatikusan, ha a téma‑betűtípus‑sémát megváltoztatják.

A fő és mellékes betűtípus‑gyűjtemények egyedi írásrendszerekre – például cirill, arab, japán, grúz vagy thaana – is tartalmazhatnak betűtípus‑leképezéseket. Ezeknek a leképezéseknek az ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/php-java/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűtípusokról: lásd a [PowerPoint Fonts](/slides/hu/php-java/powerpoint-fonts/) oldalt.
{{% /alert %}}

### **Téma‑betűtípus hivatkozások feloldása**

Szöveg ellenőrzésekor a [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) visszaadhat egy téma‑hivatkozást (például `+mn‑lt`) a betűcsaládnév helyett. Hívjuk a [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/)‑t a megfelelő hatékony téma‑adatokkal a hivatkozás feloldásához. A `+mj` és `+mn` előtagok a fő‑ illetve mellékes betűtípus‑készletet választják; a `-lt`, `-ea` és `-cs` utótagok a Latin, East Asian és Complex Script betűtípusokat jelölik.

A hatékony témát a [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) metódussal kapjuk meg azon objektumnál, amelynek a témája a vizsgált szövegre vonatkozik. Egy normál dián lévő szöveg esetén ezt a metódust a diához kell hívni, így a kontextus tartalmazza a dia örökölt témáját és a helyi felülbírálásokat. Elrendezés vagy master ellenőrzésekor a saját hatékony témáját használjuk. Ne feltételezzük, hogy az első master témája minden dián érvényes.

Az alábbi példa egy szövegrészt hoz létre, amely kifejezetten a mellékes Latin betűtípusra hivatkozik. Egy slide‑betűtípus‑sémát inicializál a [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) segítségével, és a fő‑ és mellékes Latin családokat `Arial`‑ra és `Calibri`‑ra állítja, így az eredmény bemeneti fájl nélkül reprodukálható.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

A kimenet `+mn‑lt -> Calibri`, majd `Verdana -> Verdana`. A tárolt hivatkozás változatlan marad, míg a kifejezett családnév változatlanul visszatér. Ha a rész `+mj‑lt`‑et használt volna, a téma szerint `Arial`‑ra oldódna fel.

A téma‑hivatkozás feloldása megmondja, hogy a téma mely betűcsaládját határozza meg. Nem ellenőrzi a betűtípus‑elérhetőséget vagy a helyettesítés/karakter‑fallback során végül használt betűtípus‑fájlt. Lásd a [Font Selection Sequence](/slides/hu/php-java/font-selection-sequence/) és a [Font Substitution](/slides/hu/php-java/font-substitution/) oldalakat a különálló lépésekhez.

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolatos problémákat oldanak meg.

### **Külső téma alkalmazása egy master‑függő diákra**

Használjuk a [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) metódust, ha egy PowerPoint témafájlt (`.thmx`) szeretnénk alkalmazni, és minden olyan diát átformázni, amely egy adott master‑re támaszkodik. Válasszuk ki a master‑t a [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) kollekcióból, amelyet a [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) képvisel, majd adjuk át a témafájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új master‑diát a kiválasztott master alapján.  
1. Alkalmazza a külső témát az új master‑re.  
1. Az új master‑t hozzárendeli minden diához, amely korábban a kiválasztott master‑re támaszkodott.  
1. Visszaadja a frissen létrehozott [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) objektumot.

Az alábbi példa külső témát alkalmaz az első master‑re támaszkodó diákra, majd elmenti a prezentációt:

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

Érvénytelen, sérült vagy nem támogatott téma esetén [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/) keletkezhet. Ellenőrizzük a felhasználók által megadott útvonalakat, kezeljük a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentsük a prezentációt.

Csak azok a diák, amelyek a kiválasztott master‑re támaszkodtak, lesznek átállítva. A többi master‑hez tartozó diák megtartják meglévő master‑eiket és témáikat. A téma‑tudatos színek, betűtípusok, kitöltések, vonalak, hátterek és effektusok az új külső témához lesznek feloldva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑szintű és dia‑szintű felülbírálások szintén felülírhatják az új master‑től örökölt értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek nem érhetők el a futási környezetben. Az egységes megjelenítés és export érdekében telepítsük a szükséges betűtípusokat, biztosítsuk őket a [custom font sources](/slides/hu/php-java/custom-font/) segítségével, vagy konfiguráljuk a [font substitution](/slides/hu/php-java/font-substitution/) beállítást.

Ez egy közvetlen master‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útvonalát várja, és nem igényel manuális slide‑ vagy layout‑szintű téma‑felülbírálások létrehozását.

### **Különböző külső témák alkalmazása több‑masteres prezentációban**

Ha a releváns master előre nem ismert, szerezze be azt egy reprezentatív dia [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) és [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) segítségével. A téma‑alkalmazások előtt tárolja el az eredeti master‑referenciákat, mivel minden hívás egy új master‑t hoz létre a prezentációban.

Az alábbi példa két szakaszból származó diákat használ a master‑ek megtalálásához, majd minden csoportnak más‑más külső témát alkalmaz:

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

Az első hívás csak azokra a diákra hat, amelyek `$firstGroupMaster`‑re támaszkodtak, a második hívás pedig csak a `$secondGroupMaster`‑re támaszkodókra. A többi master‑hez tartozó diák nem lesznek átformálva.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni annak eredeti dizájnját, klónozza a forrás‑master‑t a cél‑prezentációba a [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) segítségével, majd a diát a [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) és a klónozott master‑rel klónozza. Ez együtt szállítja a master‑t, annak elrendezéseit és a hozzá tartozó témát.

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

Ez a preferált munkafolyamat, amikor a forrásdia ugyanúgy kell, hogy megjelenjen a célnál. A tartalmat egy nem kapcsolódó cél‑master‑re klónozva megváltozhat a téma‑alapú szín, betűtípus, háttér és effektus.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél‑dia a saját master‑én és elrendezésén marad, inicializáljon egy dia‑szintű felülbírálást a forrástémából. A [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), a [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) és a [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) metódusok a három fő téma‑komponenst átmásolják a felülbírálásba.

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

Ez megváltoztatja a diára vonatkozó témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülbírálás eltávolításához, és az örökölt értékek visszaállításához hívja meg a [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) metódust.

### **Téma felülbírálás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülbírálás az adott elrendezést használó diákra hat, kivéve ha egy konkrét dia saját felülbírálással rendelkezik. Ugyanezeket az inicializáló metódusokat használhatja a [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/) segítségével:

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

Használjon master vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak kell ugyanazt az alaprendszert megosztania; használjon elrendezés‑felülbírálást, ha egy elrendezés‑családnak más stílusra van szüksége; és csak dia‑felülbírálást alkalmazzon valódi kivételekhez. A túlzott dia‑szintű felülbírálások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/)‑ben tárolódnak. A PowerPoint a felhasználói felületen több háttér‑választást jeleníthet meg, mint ahány kitöltés‑definíció fizikailag tárolva van ebben a kollekcióban, mert a felület kombinálhat téma‑kitöltéseket téma‑színekkel és más stílus‑hivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használnánk, ellenőrizzük a tárolt kollekciót és a jelenlegi [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/) értéket. A `0`‑s index azt jelenti, hogy nincs téma‑kitöltés; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér attól, hogy a PHP‑kollekció indexelését közvetlenül használnánk, ahol a `get_Item(0)` az első tárolt elemet jelenti. Ne feltételezzük, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa a rendelkezésre álló háttér‑kitöltések számát jelenti, egy téma‑háttér‑referenciát rendeli az első master‑hez, majd elmenti a prezentációt:

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

A látható eredmény a master által referált téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülbírálásoktól függ. Ha egy dia saját hátteret használ, a csak a master hátterének módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/)‑t, ha a végleges háttérre van szükség az öröklődés után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a stílus‑indexet null‑alapú kollekció‑indexként. Emellett kerülje a stílus‑szám kézi kódolását egy fájlból, és annak feltételezését, hogy egy másik fájlban ugyanazt a megjelenést eredményezi; a téma‑stílus‑definíciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/php-java/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátumsémája külön kitöltés‑, vonal‑ és effektus‑stílus‑gyűjteményeket tartalmaz, amelyeket a [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), a [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) és a [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) metódusok tesznek elérhetővé. A tipikus Office‑témák gyakran három fő stílus‑bejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázást képviselik, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett, hogy rögzített számra támaszkodna.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzaton alkalmazva](presentation-design_10.png)

PHP‑ben ezeknek a gyűjteményeknek az indexelése null‑alapú: a `get_Item(0)` az első tárolt stílust, a `get_Item(2)` a harmadikat jelenti. Az alakzat‑stílus‑referencia indexek egy külön koncepció, amelyet a [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/) tesz elérhetővé. Egy téma‑stílus módosítása azok az alakzatok érint, amelyek hivatkoznak arra a téma‑stílusra; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílus‑bejegyzések léteznek-e, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, bekapcsol egy külső árnyékot a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

Az ilyen slotokra hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, mely slotokra hivatkozik az adott alakzat, és hogy a közvetlen formázás felülírja-e a témát.

![Téma‑effektus‑stílusok a vonal, kitöltés és árnyék beállításainak módosítása után](presentation-design_11.png)

## **Kitöltés‑ és vonal‑stílusok kiválasztása egy alakzatra**

Egy alakzat a [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) és a [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex) metódusok segítségével függetlenül választhatja ki a kitöltést és a körvonalat. Mindkét metódus esetén az `1` index a megfelelő téma‑gyűjtemény első bejegyzését (`get_Item(0)`) jelöli, a `2` index a másodikat (`get_Item(1)`).

Az alábbi példa két kitöltés‑stílust (arany és égkék) és két vonal‑stílust (sötétkék 6 pt és sötétrózsaszín 12 pt) hoz létre egy új prezentáció alap‑témájában. A diát három szakaszban menti, így összehasonlíthatók az eredmények a PowerPoint‑ban.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Kezdeti stílusok | Jobb körvonal módosítása | Első téma‑kitöltés szerkesztése |
|:---:|:---:|:---:|
| ![Arany és égkék téglalapok egyező vékony sötétkék körvonalakkal](theme-style-initial.png) | ![Az égkék téglalap most vastag sötétrózsaszín körvonallal rendelkezik](theme-style-line-changed.png) | ![A bal téglalap most zöld, a körvonalak változatlanok](theme-style-fill-changed.png) |

Másik vonal‑stílus kiválasztása csak a jobb téglalap körvonalát változtatja. Az első téma‑kitöltés szerkesztése minden, azt használó alakzatot frissít. Itt csak a bal téglalap válik zöldre.

Egy meglévő alakzaton a helyi kitöltő‑szín, vonal‑szín vagy vonal‑vastagság felülbírálhatja a téma‑stílus adott részét. Ha egy stílus‑index módosítása nem hoz látható változást, ellenőrizze az alakzat [direct formatting](/slides/hu/php-java/shape-formatting/) beállításait.

## **Annak meghatározása, hogy egy hatékony szilárd kitöltés téma‑színt használ-e**

A kitöltés tárolható közvetlenül egy objektumon, vagy örökölhető bekezdésből, elrendezésből, master‑ből, téma‑stílusból vagy egyéb formázási szintből. Hívja a [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/)‑t, hogy az öröklődési hierarchiát egy változhatatlan hatékony kitöltés‑adatba oldja fel. Először ellenőrizze a `getFillType` eredményét. Csak akkor olvassa a szilárd‑kitöltés tulajdonságait, ha az érték `FillType::Solid`.

Szilárd kitöltés esetén a `getSolidFillColor` visszaadja a végső renderelt RGB‑értéket az öröklődés, a téma‑lekérdezés és a színtranszformációk alkalmazása után. A `getSolidFillSchemeColor` metódus a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) slotot adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor::NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy sémához tartozik. Egy olyan munkafolyamatban, ahol a kitöltések csak téma‑színek vagy közvetlen RGB‑színek lehetnek, ez az érték jelzi a közvetlen RGB‑kitöltést.

Ne használja csak a helyi [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) értéket a kitöltés osztályozásához. Például egy szövegrésznek lehet, hogy nincs helyi sémaszín‑definíciója, így a helyi értéke `NotDefined`, míg hatékony kitöltése egy téma‑színből öröklődik és `Text1`‑re vagy `Accent6`‑ra oldódik fel. Ezzel ellentétben a `getSolidFillSchemeColor` megmondja, mely logikai téma‑slot hozta létre a hatékony színt, de nem mondja meg, hogy az a slot honnan származik (objektum, bekezdés, elrendezés, master vagy más szint).

Az alábbi példa betölti egy prezentációt, ellenőrzi a forma‑ és szövegrész‑kitöltéseket, kiírja minden végső RGB‑értéket és a hozzá tartozó sémaszínt, valamint megjelöli azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín‑változásokat:

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

A `NotDefined` ágba tartozó kitöltések listája azoknak a szilárd kitöltéseknek az auditja, amelyek nem reagálnak a téma‑szín‑slotok változásaira. Ezeket az objektumokat érdemes felülvizsgálni, ha egy prezentációnak egy új márka‑palettát kell követnie. A jelentett RGB‑érték még mindig a jelenlegi megjelenést mutatja, míg a sémáérték azt magyarázza, hogy ez a megjelenés kapcsolódik-e a témához.

A hatékony‑formátum‑objektumok pillanatfelvételek. A prezentáció témájának, egy téma‑felülbírálásnak vagy bármely örökölt formázás megváltoztatása után hívja újra a `getEffective`‑et, és olvassa ki az új hatékony kitöltés‑adatokat, mielőtt összehasonlítaná vagy jelenteni kívánná a színeket.

## **Hatékony téma‑értékek olvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülbírálások feloldása után. Diára a [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) metódust hívjuk. Háttérre a [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), kitöltésre pedig a [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) metódust.

Az alábbi példa beolvassa a hatékony témát, háttér‑stílust és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat renderelési diagnosztikához, ellenőrzéshez és összehasonlításhoz. Ha csak a [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑et ellenőrzi, lemaradhat egy master, elrendezés, dia vagy alakzat felülbírálásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Érintheti-e egy külső téma minden diákat a prezentációban?**

Nem. A [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) csak azokat a diákat rendeli újra, amelyek a kiválasztott master‑re támaszkodnak. A más master‑eket használó diák megtartják meglévő témáikat.

**Alkalmazhatok-e témát egyetlen diára anélkül, hogy a master‑t változtatnám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/)‑ét, és inicializálja a felülbíráló témát. A módosítás csak arra a diára lesz lokális; a többi dia továbbra is a saját meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egy prezentációból egy másikba?**

Amikor egy diát áthelyez és meg akarja őrizni a forrás‑dizájnt, klónozza a forrás‑master‑t a célba, majd a diát a klónozott master‑rel klónozza a [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) és a [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) segítségével. Ez együtt tartja a master‑t, az elrendezéseket és a témát.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülbírálások után?**

Használja a [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat metódusokat a formátum‑objektumokhoz, például a [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) és a [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Ezek az API‑k visszaadják a feloldott értékeket az öröklődés és felülbírálások alkalmazása után.