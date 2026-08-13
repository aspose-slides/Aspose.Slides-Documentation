---
title: Alakzatok hatékony tulajdonságainak lekérése a prezentációkból PHP-ben
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/php-java/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- világítási rig
- ferde él alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for PHP via Java-t a helyi, örökölt és hatékony alakzatformázás megkülönböztetéséhez PowerPoint prezentációkban."
---
## **Understand Local, Inherited, and Effective Properties**

PowerPoint formázás több helyről származhat. Az objektumra közvetlenül tárolt érték a **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokat nézi, például egy bekezdés alapértelmezését, egy szövegstílust, egy elrendezést vagy mesterdia, egy témát vagy a bemutató szintű alapértelmezéseket. Ezek az értékek **örökölt értékek**. Az a érték, amely a teljes hierarchia feloldása után megmarad, a **hatékony érték** — az objektum megjelenítéséhez használt érték.

Például egy szövegrészlet nem definiálhat saját betűmagasságot. Ennek helyi [getFontHeight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/baseportionformat/) értéke ekkor `NAN`, ami azt jelenti, hogy "itt nincs beállítva". A részlet örökölhet magasságot a bekezdéséből, a bemutató alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/geteffective/) hívása a részlet formátumon a végső feloldott magasságot adja vissza.

Használja a kétféle formázási adatot különböző célokra:
- Olvassa vagy módosítsa a helyi formátumobjektumot, például a [PortionFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/)‑t, ha szabályozni szeretné, hogy hol van definiálva egy érték.
- Olvassa a hatékony adatobjektumot, például a [PortionFormat.getEffective által visszaadott adatot](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/geteffective/), ha a végső, megjelenített eredményre van szüksége. A hatékony adatok csak olvashatóak.

A példák futtatása előtt [telepítse az Aspose.Slides for PHP via Java](/slides/hu/php-java/installation/).

## **Compare Local, Inherited, and Effective Values**

A következő teljes példa létrehoz egy alakzatot, és betűmagasságokat alkalmaz a bemutató, a bekezdés és a részlet szintjén. Minden lépés kiírja az adott szinteken definiált értékeket és az ugyanarra a szövegrészletre vonatkozó eredményes hatékony értéket. Emellett bemutatja, miért kell a hatékony adatot a formázás módosítása után újra beolvasni.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Olvassa be a hatékony adatot az előző módosítások után.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Definiálja az örökölt értékeket két különböző szinten.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // A részlet helyi értéke felülírja mindkét örökölt értéket.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Az örökölt érték megváltoztatása nem írja felül a meglévő helyi értéket.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Törölje a helyi értéket. A részlet most ismét a bekezdéstől örököl.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Törölje a bekezdés értékét. A bemutató alapértelmezése most adja az eredményt.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ebben a példában a prioritás a részlet helyi formázása, majd a bekezdés formázása, végül a bemutató alapértelmezése. Más objektumoknak eltérő öröklődési láncaik lehetnek, de az elv ugyanaz: egy specifikusabb kifejezett érték nyer, és a [getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/geteffective/) a végső eredményt adja vissza.

## **Get Effective Text Properties**

A szövegformázás több objektumra van osztva:
- A [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textframeformat/geteffective/) feloldja a szövegkeret tulajdonságait, mint például a margók, rögzítés, automatikus illesztés és a függőleges szövegirány.
- A [TextStyle.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/textstyle/geteffective/) feloldja a bekezdésformázást minden szövegstílus szintjén.
- A [ParagraphFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/paragraphformat/geteffective/) feloldja a bekezdés tulajdonságait, például az igazítást, behúzást és a felsorolásjeleket.
- A [PortionFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/portionformat/geteffective/) feloldja a karaktertulajdonságokat, mint a betűmagasság, betűtípus, szín, félkövér és dőlt.

A következő példához a `text-formatting.pptx` fájlnak legalább egy diát és egy nem üres szövegkerettel rendelkező [AutoShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/autoshape/) elemet kell tartalmaznia. Az AutoShape megjelenhet a alakzatgyűjtemény bármely pozíciójában; a kód keres egy megfelelő objektumot, és a használat előtt ellenőrzi azt.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Get Effective 3D Properties**

A [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/) egy hatékony adatobjektumot ad vissza, amely egyesíti az összes feloldott 3D beállítást. Ennek [getCamera](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/), és [getBevelBottom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/threedformat/geteffective/) metódusai a megfelelő hatékony adatot teszik elérhetővé. Ezen kapcsolódó beállítások közös olvasása megkönnyíti a forma végső 3D megjelenésének megértését.

Ezzel a példával a `shape-3d.pptx` fájlnak az első diáján legalább egy alakzatot kell tartalmaznia. Alkalmazzon 3D kamerát, fényeket vagy rézsút beállításokat az alakzatra, ha azt szeretné, hogy a kimenet az alapértelmezettől eltérő értékeket tartalmazzon.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Get Effective Table Formatting**

A táblázatformázás származhat a táblázat stílusából, illetve a teljes táblázatra, egy oszlopra, egy sorra vagy egy egyedi cellára alkalmazott formátumokból. Az explicit módon definiált kitöltések ütközése esetén a prioritás: cella, sor, oszlop, majd a teljes táblázat. Egy cella hatékony formátuma a végső formátum, amely a cellát megrajzolja.

Ehhez a példához a `table-formatting.pptx` fájlnak az első diáján legalább egy táblázatot kell tartalmaznia. A táblázatnak legalább egy sorral és egy oszloppal kell rendelkeznie. A kód egy [Table](https://reference.aspose.com/slides/hu/php-java/aspose.slides/table/) elemet keres, ahelyett, hogy feltételezné, hogy a `getShapes()->get_Item(0)` egy táblázat.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Ha a színre van szüksége, nem csak a kitöltés típusára, először ellenőrizze a hatékony [getFillType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/geteffective/) értéket, majd olvassa el az arra vonatkozó metódust – például a [getSolidFillColor](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fillformat/geteffective/) egy szilárd kitöltés esetén.

## **Re-read Effective Data After Changes**

A hatékony adatok leírják a formázási hierarchiát a feloldás időpontjában. Hívja újra a `getEffective` függvényt, miután bármit módosított, ami részt vehet ebben a hierarchiában, többek között:
- az objektum helyi formázását;
- bekezdés vagy szövegkeret alapértelmezéseit;
- egy táblázat stílusát, táblázatot, oszlopot, sort vagy cellaformátumot;
- elrendezés vagy mesterdia formázását;
- téma adatokat vagy a bemutató szintű alapértelmezéseket;
- a diára rendelt elrendezést vagy mestert.

Ne tartson hatékony adatobjektumot állandó pillanatképként. Az Aspose.Slides belül cache-elhet bizonyos hatékony adatokat, és egy későbbi `getEffective` hívás frissítheti azokat. Ha az értékek összehasonlítására van szükség a módosítás előtt és után, másolja a szükséges skáláris értékeket – például betűmagasság, szín, igazítás vagy rézsútszélesség – saját változóiba a módosítás előtt.

Az érték megváltoztatásához frissítse a megfelelő helyi formátumobjektumot, majd hívja a `getEffective` függvényt az eredmény ellenőrzéséhez. A hatékony adatobjektumok maguk csak olvashatóak.

## **FAQ**

**How can I tell which level supplied an effective value?**

A hatékony adat tartalmazza a végleges értéket, de nem annak forrását. Vizsgálja meg a megfelelő helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez magában foglalhatja a részletet, bekezdést, szövegkeretet, elrendezést, mestert, témát és a bemutató alapértelmezéseit. A `NAN` vagy `null` értékek jelzik, hogy a keresés egy másik szintre folytatódik.

**What happens when no level defines a property?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtár alapértelmezést alkalmazza. Ez a feloldott érték megjelenik a hatékony adatokban, még akkor is, ha egy helyi objektum sem definiálja kifejezetten.

**Why does an effective value sometimes equal the local value?**

A helyi érték nyerte meg az öröklési számítást. Ez akkor várható, amikor a tulajdonság kifejezetten be van állítva az objektumon, és nincs specifikusabb szabály, ami felülírná.

**When should I use local data instead of effective data?**

Használjon helyi adatot egy adott formázási szint megtekintésére vagy szerkesztésére. Használjon hatékony adatot, ha a végső megjelenésre van szükség az öröklődés, a téma szabályok és a megfelelő stílusok feloldása után. A [complete comparison example](#compare-local-inherited-and-effective-values) mindkettőt bemutatja ugyanabban a munkafolyamatban.