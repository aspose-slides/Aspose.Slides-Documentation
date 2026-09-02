---
title: Alakzatok effektív tulajdonságainak lekérése prezentációkból Java-ban
linktitle: Effektív tulajdonságok
type: docs
weight: 50
url: /hu/java/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- világítási rendszer
- retesz alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltés formátum
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Java könyvtárat a helyi, örökölt és effektív alakzatformázás megkülönböztetéséhez PowerPoint-prezentációkban."
---
## **Értse meg a helyi, örökölt és effektív tulajdonságokat**

A PowerPoint formázás több forrásból jöhet. Az objektumon közvetlenül tárolt érték a **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokat vizsgálja, például a bekezdés alapértelmezését, egy szövegstílust, egy elrendezést vagy mesterdiát, egy témát vagy a bemutató szintű alapértelmezéseket. Ezek az értékek **örökölt értékek**. A teljes hierarchia feloldása után megmaradó érték a **effektív érték** – az objektum megjelenítéséhez használt érték.

Például egy szövegrészlet nem határozhatja meg a saját betűmagasságát. Ennek a helyi [getFontHeight](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) értéke akkor `Float.NaN`, ami azt jelenti, hogy „itt nincs beállítva”. A részlet örökölhet magasságot a bekezdéséből, a bemutató alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformat/#getEffective--) meghívása a részlet formátumán a végleges feloldott magasságot adja vissza.

A kétféle formázási adatot különböző célokra használja:

- Olvassa vagy módosítsa a helyi formátumobjektumot, például az [IPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformat/), amikor azt kell szabályozni, hogy hol van definiálva egy érték.
- Olvassa az effektív adatobjektumot, például az [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformateffectivedata/), amikor a végső, megjelenített eredményre van szükség. Az effektív adatok csak olvashatók.

## **Helyi, örökölt és effektív értékek összehasonlítása**

Az alábbi teljes példaprogram egy alakzatot hoz létre, és betűmagasságot állít be a bemutató, a bekezdés és a részlet szintjén. Minden lépés kiírja az adott szinteken definiált értékeket és az ugyanarra a szövegrészletre vonatkozó eredményes effektív értéket. Emellett bemutatja, miért kell a formázási módosítások után újra beolvasni az effektív adatot.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Definiálja az örökölt értékeket két különböző szinten.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // A részlet helyi értéke felülírja mindkét örökölt értéket.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Az örökölt érték módosítása nem írja felül a már meglévő helyi értéket.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Törli a helyi értéket. A részlet most újra a bekezdéstől örököl.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Törli a bekezdés értékét. A bemutató alapértelmezése adja most az eredményt.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Olvassa be az effektív adatot az előző módosítások után.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

Az ebben a példában a prioritás a részlet helyi formázása, aztán a bekezdés formázása, végül a bemutató alapértelmezése. Más objektumoknak eltérő öröklődési láncuk lehet, de az elv ugyanaz: egy specifikusabb, explicit érték nyer, és a [getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformat/#getEffective--) a végső eredményt adja vissza.

## **Effektív szövegtulajdonságok lekérdezése**

A szövegformázás több objektumra van osztva:

- A [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#getEffective--) feloldja a szövegkeret tulajdonságait, például a margókat, rögzítést, automatikus méretezést és a függőleges szövegirányt.
- Az [ITextStyle.getEffective()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextstyle/#getEffective--) feloldja a bekezdésformázást minden szövegstílus szinten.
- Az [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getEffective--) feloldja a bekezdés tulajdonságait, mint a igazítás, behúzás és felsorolásjel.
- Az [IPortionFormat.getEffective()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformat/#getEffective--) feloldja a karakter tulajdonságait, például betűmagasság, betűtípus, szín, félkövér és dőlt.

A következő példához a `text-formatting.pptx` fájlnak legalább egy diát és egy [AutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/)‑t kell tartalmaznia, amely nem üres szövegkerettel rendelkezik. Az AutoShape megjelenhet a alakzatgyűjtemény bármely pozíciójában; a kód egy megfelelő objektumot keres és használat előtt ellenőrzi.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Effektív 3D tulajdonságok lekérdezése**

Az [IThreeDFormat.getEffective()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformat/#getEffective--) visszaad egy [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformateffectivedata/) objektumot, amely az összes feloldott 3D beállítást csoportosítja. A [getCamera](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) és [getBevelBottom](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) metódusok a megfelelő effektív adatot teszik elérhetővé. Ezeknek a kapcsolódó beállításoknak az együttes olvasása könnyebbé teszi egy alakzat végső 3D megjelenésének megértését.

Ehhez a példához a `shape-3d.pptx` fájlnak legalább egy alakzatot kell tartalmaznia az első diáján. Alkalmazzon 3D kamerát, világítást vagy rézsút beállításokat az alakzatra, ha a kimenetben az alapértelmezettől eltérő értékeket szeretne.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Effektív táblázatformázás lekérdezése**

A táblázat formázása származhat a táblázat stílusából, valamint a teljes táblára, egy oszlopra, egy sorra vagy egy egyedi cellára alkalmazott formátumokból. A kifejezetten definiált kitöltések közötti ütközés esetén a prioritás: cella, sor, oszlop, majd a teljes táblázat. Egy cella effektív formátuma a végső formátum, amely a cellát megrajzolja.

Ehhez a példához a `table-formatting.pptx` fájlnak legalább egy táblázatot kell tartalmaznia az első diáján. A táblázatnak legalább egy sorral és egy oszloppal kell rendelkeznie. A kód egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itable/) objektumot keres, ahelyett, hogy azt feltételezné, hogy a `getShapes().get_Item(0)` egy táblázat.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Ha a színre van szüksége a kitöltés típusa helyett, először ellenőrizze az effektív [getFillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformateffectivedata/#getFillType--), majd olvassa el a típussal kapcsolatos metódust – például a [getSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) egy szilárd kitöltés esetén.

## **Effektív adatok újraolvasása módosítások után**

Az effektív adatok leírják a formázási hierarchiát a feloldás időpontjában. Hívja meg újra a `getEffective`‑et, miután bármit módosított, ami részt vehet ebben a hierarchiában, többek között:

- az objektum helyi formázása;
- bekezdés vagy szövegkeret alapértelmezései;
- egy táblázat stílus, táblázat, oszlop, sor vagy cella formátuma;
- elrendezés vagy mesterdia formázása;
- téma adatok vagy a bemutató szintű alapértelmezések;
- a diára hozzárendelt elrendezés vagy mester.

Ne tartson egy effektív adatobjektumot állandó pillanatképként. Az Aspose.Slides belsőleg cache-elhet bizonyos effektív adatokat, és egy későbbi `getEffective` hívás frissítheti azokat. Ha össze kell hasonlítania az értékeket módosítás előtt és után, másolja a szükséges skaláris értékeket – például betűmagasság, szín, igazítás vagy rézsútszélesség – saját változóiba a módosítás előtt.

Érték módosításához frissítse a megfelelő helyi formátumobjektumot, majd hívja meg a `getEffective`‑et az eredmény ellenőrzéséhez. Az effektív adatobjektumok maguk csak olvashatók.

## **GYIK**

**Hogyan tudom megmondani, hogy mely szint biztosította az effektív értéket?**

Az effektív adatok tartalmazzák a végső értéket, de nem annak forrását. Vizsgálja meg a vonatkozó helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez magában foglalhatja a részletet, a bekezdést, a szövegkeretet, az elrendezést, a master‑diát, a témát és a bemutató alapértelmezéseit. A nem definiált értékek, például `Float.NaN` vagy `null`, azt jelzik, hogy a keresés egy másik szintre folytatódik.

**Mi történik, ha egy szint sem definiálja a tulajdonságot?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtári alapértelmezést oldja fel. Ez a feloldott érték megjelenik az effektív adatokban, még akkor is, ha egy helyi objektum sem definiálja explicit módon.

**Miért egyes esetekben az effektív érték megegyezik a helyi értékkel?**

A helyi érték nyerte meg az öröklődési számítást. Ez akkor várható, amikor a tulajdonság kifejezetten be van állítva az objektumon, és nincs specifikusabb szabály, amely felülírná.

**Mikor használjak helyi adatot az effektív adat helyett?**

Használjon helyi adatot egy adott formázási szint megtekintéséhez vagy szerkesztéséhez. Használjon effektív adatot, ha a végső megjelenésre van szüksége az öröklődés, a témaszabályok és a vonatkozó stílusok feloldása után. A [teljes összehasonlítási példánk](#compare-local-inherited-and-effective-values) mindkettőt bemutatja ugyanabban a munkafolyamatban.