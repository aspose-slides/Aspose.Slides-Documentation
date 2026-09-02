---
title: Alakzat ható tulajdonságainak lekérdezése bemutatókból JavaScript-ben
linktitle: Ható tulajdonságok
type: docs
weight: 50
url: /hu/nodejs-java/shape-effective-properties/
keywords:
- alakzat tulajdonságai
- kamera tulajdonságok
- világítási rig
- ferde alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltés formátuma
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Node.js via Java könyvtárat a helyi, örökölt és ható alakzat formázás megkülönböztetéséhez a PowerPoint bemutatókban."
---
## **Helyi, örökölt és tényleges tulajdonságok megértése**

A PowerPoint formázás több helyről származhat. Az objektumra közvetlenül tárolt érték a **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokban keresi, például egy bekezdés alapértelmezésében, egy szövegstílusban, egy elrendezésben vagy mesterdiánban, egy témában vagy a bemutató szintű alapértelmezésekben. Ezek az értékek **örökölt értékek**. Az az érték, amely a teljes hierarchia feloldása után megmarad, a **ható érték**—az az érték, amelyet az objektum megjelenítéséhez használnak.

Például egy szövegrészlet nem adhatja meg saját betűmagasságát. Ennek a helyi [getFontHeight](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getFontHeight) értéke ilyenkor `NaN`, ami azt jelenti, hogy „itt nincs beállítva”. A részlet örökölhet magasságot a bekezdéséből, a bemutató alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getEffective) meghívása a PortionFormat objektumon a végleges feloldott magasságot adja vissza.

Használja a kétféle formázási adatot különböző célokra:

- Olvassa vagy módosítsa a helyi formátumobjektumot, például a [PortionFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/), ha azt szeretné szabályozni, hogy hol van definiálva az érték.
- Olvassa a [PortionFormat.getEffective által visszaadott ható adatot](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getEffective), ha a végső, megjelenített eredményre van szüksége. A ható adatok csak olvashatóak.

A példák futtatása előtt [telepítse az Aspose.Slides for Node.js via Java](/slides/hu/nodejs-java/installation/)-t.

## **Helyi, örökölt és ható értékek összehasonlítása**

Az alábbi teljes példa létrehoz egy alakzatot, és a betűmagasságot a bemutató, a bekezdés és a részlet szintjén alkalmazza. Minden lépés kiírja az adott szinteken definiált értékeket és a ugyanazon szövegrészlet eredményül kapott ható értékét. Emellett azt is bemutatja, miért kell a ható adatot újra olvasni a formázási módosítások után.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Olvassa a ható adatokat a korábbi módosítások után.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Határozza meg az örökölt értékeket két különböző szinten.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // A részlet helyi értéke felülírja mindkét örökölt értéket.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Az örökölt érték módosítása nem írja felül a már létező helyi értéket.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Törölje a helyi értéket. A részlet most újra a bekezdéstől örököl.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Törölje a bekezdés értékét. A bemutató alapértelmezése adja most az eredményt.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ebben a példában a prioritás a részlet helyi formázása, majd a bekezdés formázása, végül a bemutató alapértelmezése. Más objektumoknak eltérő öröklődési láncaik lehetnek, de az elv ugyanaz: egy konkrétabb, explicit érték nyer, és a [getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getEffective) a végső eredményt adja vissza.

## **Ható szövegtulajdonságok lekérdezése**

A szövegformázás több objektumra van szétosztva:

- A [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframeformat/#getEffective) feloldja a szövegkeret tulajdonságait, például a margókat, a rögzítést, az automatikus méretezést és a függőleges szövegirányt.
- A [TextStyle.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textstyle/#getEffective) feloldja a bekezdés formázását minden szövegstílus szinten.
- A [ParagraphFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/paragraphformat/#getEffective) feloldja a bekezdés tulajdonságait, például az igazítást, a behúzást és a felsorolást.
- A [PortionFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/portionformat/#getEffective) feloldja a karakter tulajdonságokat, például a betűmagasságot, a betűkészletet, a színt, a félkövér és a dőlt stílust.

A következő példához a `text-formatting.pptx`-nek legalább egy diát és egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) kell tartalmaznia, amelynek nem üres a szövegkerete. Az AutoShape megjelenhet a shape gyűjtemény bármelyik pozíciójában; a kód keres egy megfelelő objektumot, és használat előtt ellenőrzi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Ható 3D tulajdonságok lekérdezése**

A [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getEffective) egy ható adatobjektust ad vissza, amely összegyűjti az összes feloldott 3D beállítást. A [getCamera](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getCamera), a [getLightRig](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getLightRig), a [getBevelTop](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getBevelTop), és a [getBevelBottom](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/#getBevelBottom) metódusok a megfelelő ható adatot exponálnak. Ezeknek a kapcsolódó beállításoknak együttes olvasása egyszerűbbé teszi a forma végső 3D megjelenésének megértését.

Ehhez a példához a `shape-3d.pptx` első diáján legalább egy alakzatnak kell lennie. Alkalmazzon 3D kamerát, megvilágítást vagy levágási (bevel) beállításokat az alakzatra, ha azt szeretné, hogy a kimenet az alapértelmezett értékeken kívül is tartalmazzon értékeket.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Ható táblázatformázás lekérdezése**

A táblázat formázása a táblastílusból, valamint a teljes táblára, egy oszlopra, egy sorra vagy egy egyedi cellára alkalmazott formátumokból származhat. Az explicit módon meghatározott kitöltések közötti ütközések esetén a prioritás: cella, sor, oszlop, majd a teljes táblázat. A cella ható formátuma az a végső formátum, amely a cella megjelenítéséhez használatos.

Ehhez a példához a `table-formatting.pptx` első diáján legalább egy táblázatnak kell lennie. A táblázatnak legalább egy sorral és egy oszloppal kell rendelkeznie. A kód egy [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/) objektumot keres, ahelyett, hogy feltételezné, hogy a `getShapes().get_Item(0)` egy táblázat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Ha a színre van szükség, nem csak a kitöltés típusára, először ellenőrizze a ható [getFillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#getFillType), majd olvassa el a típusra alkalmazott metódust—például a [getSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) egy egyenletes kitöltésnél.

## **Ható adatok újbóli beolvasása módosítások után**

A ható adatok leírják a formázási hierarchiát a feloldás időpontjában. Hívja meg újra a `getEffective`-et, miután bármit módosított, ami részt vehet ebben a hierarchiában, többek között:

- az objektum helyi formázása;
- bekezdés vagy szövegkeret alapértelmezései;
- egy táblastílus, táblázat, oszlop, sor vagy cella formátuma;
- elrendezés vagy mesterdia formázása;
- témaadatok vagy prezentáció szintű alapértelmezések;
- a diához rendelt elrendezés vagy mester.

Ne tartson meg egy ható adatobjektumot állandó pillanatképként. Az Aspose.Slides a ható adat egyes részeit belsőleg gyorsítótárba helyezheti, és egy későbbi `getEffective` hívás frissítheti az adatot. Ha össze kell hasonlítania az értékeket módosítás előtt és után, másolja a szükséges skaláris értékeket – például betűmagasság, szín, igazítás vagy a levágás szélessége – saját változóiba a módosítás előtt.

Egy érték módosításához frissítse a megfelelő helyi formátumobjektumot, majd hívja meg a `getEffective`-et az eredmény ellenőrzéséhez. A ható adatobjektumok maguk csak olvashatóak.

## **GYIK**

**Hogyan tudom megállapítani, melyik szint biztosította a ható értéket?**

A ható adatok a végső értéket tartalmazzák, nem annak forrását. Vizsgálja meg a vonatkozó helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez magában foglalhatja a részletet, a bekezdést, a szövegkeretet, az elrendezést, a mestert, a témát és a bemutató alapértelmezéseit. A `NaN` vagy `null` értékek azt jelzik, hogy a keresés egy másik szintre folytatódik.

**Mi történik, ha egy szint sem definiál egy tulajdonságot?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtári alapértelmezést oldja fel. Ez a feloldott érték megjelenik a ható adatokban, még akkor is, ha egy helyi objektum sem definiálja explicit módon.

**Miért egyezik egy ható érték néha a helyi értékkel?**

A helyi érték nyerte meg az öröklődési számítást. Ez akkor várható, amikor a tulajdonság kifejezetten be van állítva az objektumon, és nincs konkrétabb szabály, amely felülírná.

**Mikor használjak helyi adatot a ható adat helyett?**

Használja a helyi adatokat egy adott formázási szint megtekintéséhez vagy szerkesztéséhez. Használja a ható adatokat, ha az öröklődés, a téma szabályai és a vonatkozó stílusok feloldása után a végső megjelenésre van szüksége. A [teljes összehasonlító példa](#compare-local-inherited-and-effective-values) mindkettőt bemutatja ugyanabban a munkafolyamatban.