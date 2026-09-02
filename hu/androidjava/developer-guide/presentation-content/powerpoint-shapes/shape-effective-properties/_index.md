---
title: Alakzat Hatékony Tulajdonságainak Lekérése Prezentációkból Androidon
linktitle: Hatékony Tulajdonságok
type: docs
weight: 50
url: /hu/androidjava/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- világítás
- fokozott alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltés formátum
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Android Java-val a helyi, örökölt és hatékony alakzatformázás megkülönböztetésére a PowerPoint prezentációkban."
---
## **Helyi, örökölt és tényleges tulajdonságok megértése**

A PowerPoint formázás több helyről származhat. Az objektumon közvetlenül tárolt érték a **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokat nézi, például egy bekezdés alapértelmezettjét, egy szövegstílust, egy elrendezést vagy fődiát, egy témát vagy a prezentáció szintű alapértelmezéseket. Ezek az értékek **örökölt értékek**. Az az érték, amely a teljes hierarchia feloldása után megmarad, a **hatékony érték** — az objektum megjelenítéséhez használt érték.

Például egy szövegrészlet nem definiálhatja a saját betűmagasságát. A helyi [getFontHeight](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) értéke ilyenkor `Float.NaN`, ami azt jelenti, hogy „nincs itt beállítva”. A részlet örökölhet magasságot a bekezdéséből, a bemutató alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/#getEffective--) meghívása a részlet formázásán a végső feloldott magasságot adja vissza.

Használd a kétféle formázási adatot különböző célokra:

- Olvasd vagy módosítsd a helyi formátumobjektumot, például a [IPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/), ha szabályozni szeretnéd, hol van definiálva az érték.
- Olvasd a hatékony adatobjektumot, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformateffectivedata/), ha a végső, renderelt eredményre van szükséged. A hatékony adatok csak olvashatóak.

## **Helyi, örökölt és hatékony értékek összehasonlítása**

Az alábbi teljes példa létrehoz egy alakzatot, és a prezentáció, a bekezdés és a részlet szintjén alkalmaz betűmagasságot. Minden lépés kiírja az adott szinten definiált értékeket, valamint ugyanannak a szövegrészletnek a kapott hatékony értékét. Emellett bemutatja, miért kell a hatékony adatot újra beolvasni a formázási módosítások után.

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

            // Határozza meg az örökölt értékeket két különböző szinten.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // A részlet helyi értéke felülírja mindkét örökölt értéket.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Az örökölt érték módosítása nem írja felül a meglévő helyi értéket.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Törölje a helyi értéket. A részlet most újra a bekezdésből örököl.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Törölje a bekezdés értékét. A prezentáció alapértelmezése most adja a végeredményt.
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

        // Olvassa be a hatékony adatot az előző módosítások után.
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

A példában a prioritás a részlet helyi formázása, majd a bekezdés formázása, végül a prezentáció alapértelmezése. Más objektumok rendelkezhetnek eltérő öröklődési láncokkal, de az elv ugyanaz: egy specifikusabb, explicit érték nyer, és a [getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/#getEffective--) visszaadja a végső eredményt.

## **Hatékony szövegtulajdonságok lekérése**

Szövegformázás több objektumra oszlik:

- A [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#getEffective--) feloldja a szövegkeret tulajdonságait, például a margókat, rögzítést, automatikus kitöltést és a függőleges szövegirányt.
- A [ITextStyle.getEffective()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextstyle/#getEffective--) feloldja a bekezdés formázását minden szövegstílus szinten.
- A [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getEffective--) feloldja a bekezdés tulajdonságait, mint az igazítás, behúzás és a felsorolásjeleket.
- A [IPortionFormat.getEffective()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/#getEffective--) feloldja a karaktertulajdonságokat, mint a betűmagasság, betűtípus, szín, félkövér és dőlt.

A következő példához a `text-formatting.pptx` legalább egy diát és egy [AutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/autoshape/) nem üres szövegkerettel kell hogy tartalmazzon. Az AutoShape a forma gyűjtemény bármely pozíciójában megjelenhet; a kód keres egy megfelelő objektumot, és használat előtt ellenőrzi azt.

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

## **Hatékony 3D tulajdonságok lekérése**

[AThreeDFormat.getEffective()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformat/#getEffective--) egy [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/) objektumot ad vissza, amely csoportosítja az összes feloldott 3D beállítást. A [getCamera](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/#getCamera--), a [getLightRig](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), a [getBevelTop](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--) és a [getBevelBottom](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) metódusok a megfelelő hatékony adatokat teszik elérhetővé. Ezeknek a kapcsolódó beállításoknak az egyszerre történő olvasása megkönnyíti egy alakzat végső 3D megjelenésének megértését.

A példához a `shape-3d.pptx` első diáján legalább egy alakzatnak kell lennie. Alkalmazz 3D kamerát, fényeket vagy fazett beállításokat arra az alakzatra, ha a kimenetnek az alapértelmezett beállításokon kívül is tartalmaznia kell értékeket.

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

## **Hatékony táblázatformázás lekérése**

A táblázat formázása származhat a táblázat stílusból, valamint a teljes táblázatra, egy oszlopra, egy sorra vagy egy egyedi cellára alkalmazott formátumokból. Az explicit módon meghatározott kitöltések közti ütközések esetén a prioritás: cella, sor, oszlop, majd a teljes táblázat. A cella hatékony formátuma a végső formátum, amely a cella kirajzolásához használatos.

A példához a `table-formatting.pptx` első diáján legalább egy táblázatnak kell lennie. A táblázatnak legalább egy sorral és egy oszloppal kell rendelkeznie. A kód egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) keres, ahelyett, hogy azt feltételezné, hogy a `getShapes().get_Item(0)` egy táblázat.

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

Ha a színt kell használnod, nem csak a kitöltés típusát, először ellenőrizd a hatékony [getFillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/#getFillType--), majd olvasd el az arra a típusra vonatkozó metódust – például a [getSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) egy szilárd kitöltés esetén.

## **Hatékony adatok újraolvasása módosítások után**

Az effektív adatok leírják a formázási hierarchiát a feloldás időpontjában. Hívd újra a `getEffective` metódust, miután megváltoztattál bármilyen elemet, amely részt vehet a hierarchiában, beleértve:

- az objektum helyi formázását;
- a bekezdés vagy szövegkeret alapértelmezéseit;
- egy táblázat stílusát, táblázatot, oszlopot, sort vagy cellaformátumot;
- elrendezés vagy fődia formázását;
- témaadatokat vagy a prezentáció szintű alapértelmezéseket;
- a diára hozzárendelt elrendezést vagy fődiát.

Ne tarts egy hatékony adatobjektumot állandó pillanatképként. Az Aspose.Slides tárolhat néhány effektív adatot belső gyorsítótárban, és egy későbbi `getEffective` hívás frissítheti ezeket az adatokat. Ha össze kell hasonlítanod az értékeket módosítás előtt és után, másold a szükséges skalár értékeket – például betűmagasság, szín, igazítás vagy fazett szélesség – saját változóidba a módosítás előtt.

Érték módosításához frissítsd a megfelelő helyi formátumobjektumot, majd hívd a `getEffective` metódust az eredmény ellenőrzéséhez. A hatékony adatobjektumok maguk csak olvashatóak.

## **GYIK**

**Hogyan tudom megállapítani, melyik szint szolgáltatta a hatékony értéket?**

A hatékony adat tartalmazza a végső értéket, nem annak forrását. Vizsgáld meg az alkalmazandó helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez magában foglalhatja a részletet, a bekezdést, a szövegkeretet, az elrendezést, a fődiát, a témát és a prezentáció alapértelmezéseit. A nem definiált értékek, mint `Float.NaN` vagy `null`, azt jelzik, hogy a keresés egy másik szintre folytatódik.

**Mi történik, ha egyetlen szint sem definiál egy tulajdonságot?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtári alapértelmezést oldja fel. Ez a feloldott érték megjelenik a hatékony adatok között, még akkor is, ha egy helyi objektum sem definiálja kifejezetten.

**Miért egyezik néha a hatékony érték a helyi értékkel?**

A helyi érték nyerte meg az öröklődési számítást. Ez akkor várható, amikor a tulajdonság kifejezetten az objektumon van beállítva, és nincs specifikusabb szabály, amely felülírná.

**Mikor használjam a helyi adatot a hatékony adat helyett?**

Használd a helyi adatot egy adott formázási szint vizsgálatához vagy szerkesztéséhez. Használd a hatékony adatot, ha a végső megjelenésre van szükséged az öröklődés, a téma szabályok és az alkalmazható stílusok feloldása után. A [complete comparison example](#compare-local-inherited-and-effective-values) mindkettőt bemutatja ugyanabban a munkafolyamatban.