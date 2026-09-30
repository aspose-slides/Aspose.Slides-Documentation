---
title: Prezentációs táblázatok kezelése Androidon
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/androidjava/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázat elérése
- képarány
- szöveg igazítása
- szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint diákon az Aspose.Slides for Android segítségével. Fedezze fel az egyszerű Java kódpéldákat, hogy egyszerűsítse a táblázati munkafolyamatokat."
---
## **Bevezetés**

A PowerPoint táblázatai információkat sorokba és oszlopokba rendeznek, megkönnyítve az értékek olvasását és összehasonlítását.

Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) osztályt, az [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interfészt, a [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) osztályt, az [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) interfészt és további típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését a bemutatókban.

## **Táblázat létrehozása már a semmiből**

Táblázatot hozhat létre a pozíció, az oszlopszélességek és a sormagasságok megadásával. A diára való felhelyezés után formázhatja a cella szegélyeit, egyesítheti a cellákat, és szöveget szúrhat be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára a indexe alapján.
3. Határozzon meg egy tömböt oszlopszélességekkel pontban.
4. Határozzon meg egy tömböt sormagasságokkal pontban.
5. Adjon egy [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) objektumot a diára a [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódussal.
6. Iteráljon végig minden [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) elemen, hogy a felső, alsó, jobb és bal szegélyeket formázza.
7. Egyesítse a táblázat első sorának első két celláját.
8. Érje el az egyesített cellát a [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) metóduson keresztül.
9. Állítsa be a szöveget az egyesített cellában.
10. Mentse a módosított prezentációt.

Az alábbi példa három oszlopos és öt soros táblázatot hoz létre a (100, 50) pont helyen. Piros, 5 pont vastagságú szegélyeket alkalmaz, egyesíti az első sort első két celláját, és a végeredményt `table.pptx`‑ként menti.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cella indexek nulla‑alapúak, és a (oszlop, sor) sorrendet követik. Az első cella indexe (0, 0).

Például egy 4 oszlopos és 4 soros táblázat cellái a következőképpen vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a példa létrehozza a fent ábrázolt 4 × 4 táblát, oszlopszélességekkel és sormagasságokkal 70 pont, piros cellaszegélyekkel 5 pont vastagságban. A koordináták a cella indexeket szemléltetik; a példa a cellákat üresen hagyja, és a táblát `StandardTables_out.pptx`‑ként menti.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Meglévő táblázat elérése**

A táblázatok egy dia alakzatgyűjteményében tárolódnak. Iteráljon végig az alakzatokon, hogy megtalálja a táblázatot, majd használja az [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interfészt a cellák olvasásához vagy frissítéséhez.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal.
2. Szerezzen referenciát a táblázatot tartalmazó diára az indexe alapján.
3. Iteráljon végig a [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) objektumokon, és álljon meg, amikor táblázatot talál. Ha a dián több táblázat van, használja a [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) metódust a kívánt azonosításához.
4. Frissítse a célcella szövegét.
5. Mentse a módosított prezentációt.

Az alábbi példa megnyitja a `UpdateExistingTable.pptx`‑t, és megtalálja az első táblázatot az első dián. A 0. oszlop, 1. sor celláját `New`‑re állítja, majd a végeredményt `table1_out.pptx`‑ként menti. A bemenetnek legalább egy diát kell tartalmaznia, és az első táblázatnak legalább egy oszloppal és két sorral kell rendelkeznie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

A meglévő táblázat sorának átméretezéséhez, és annak megértéséhez, hogy a tényleges magasság miért haladhatja meg a kért minimumot, lásd a [Sor magasság szabályozása](/slides/hu/androidjava/manage-rows-and-columns/#control-row-height) részt.

## **A szövegkeretet tartalmazó cella megtalálása**

Amikor általános szövegfeldolgozó kód egy [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) objektumot kap egy táblázatból, használja a [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) metódust, hogy lekérje a tulajdonos [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) objektumot. Táblázat‑cella szövegkeret esetén a [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) visszaadja a tulajdonost, míg a [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null`‑t ad, még akkor is, ha a táblázat maga alakzat.

A cellakoordináták a csak‑olvasásra szánt [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) és [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) metódusokon keresztül érhetők el. A [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) szintén csak‑olvasási navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze, hogy a visszakapott cella nem `null`‑e, mielőtt használja.

A táblázat‑cella és alakzat tulajdonosokat, beleértve a SmartArt‑csomópontokhoz kapcsolódó alakzatokat, bemutató teljes példáért lásd a [Keresés és csere szövegben](/slides/hu/androidjava/search-and-replace-text/) oldalt.

## **Szöveg igazítása egy táblázatban**

Az egyes táblázatcellák függőleges rögzítését és szövegirányát szabályozhatja. Az ebben a szakaszban szereplő példa középre helyezi a szöveget az első cellában, és 270 fokban elforgatja azt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát a diára az indexe alapján.
3. Adjon egy [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) objektumot a diára.
4. Szerezzen egy [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) objektumot a táblázatból.
5. Szerezzen hozzá az első [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) objektumot, és állítsa be a szöveget és a színt.
6. Állítsa be a cella függőleges rögzítését és a szövegirányt a [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) és a [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) metódusokkal.
7. Mentse a módosított prezentációt.

Ez a példa egy 4 × 4 táblázatot hoz létre 120 pont oszlopszélességgel és 100 pont sormagassággal. Formázza a (0, 0) cellában lévő szöveget, hozzáad értékeket az első sor többi cellájához, és a végeredményt `Vertical_Align_Text_out.pptx`‑ként menti.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegformázás beállítása táblaszinton**

Használja a [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) metódust, hogy szövegformázást alkalmazzon az összes cellára egy táblázatban. Az overloadok részre, bekezdésre és szövegkeretre vonatkozó formázást fogadják, így ezeket a tulajdonságokat anélkül állíthatja be, hogy egyesével iterálna a cellákon.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal.
2. Szerezzen referenciát a diára az indexe alapján.
3. Szerezzen egy [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) objektumot a diáról.
4. Állítsa be a betűméretet a [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódussal a szöveghez.
5. Állítsa be a bekezdés igazítását és a jobb margót a [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metódusokkal.
6. Állítsa be a szöveg irányát a [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metódussal.
7. Mentse a módosított prezentációt.

Az alábbi példa megnyitja a `table.pptx`‑t, amelynek legalább egy diája van, azon a diáron egy táblázat az első alakzatként. A betűméretet 25 pontra állítja, a bekezdéseket jobbra igazítja 20 pont jobb margóval, és függőlegessé teszi a szöveget. A formázott prezentációt `result.pptx`‑ként menti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A táblázat stílus tulajdonságainak lekérése**

Használja a [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) metódust egy táblázat előre definiált stílusának olvasásához, és a [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) metódust a beállításához. Ez a példa a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) stílust alkalmaz egy táblázatra, kiírja a preset értékét, majd ugyanazt a presetet a második táblázatra is beállítja. Mindkét táblázatot `table-style.pptx`‑ben menti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A táblázat képarányának zárolása**

Egy táblázat képaránya a szélesség és a magasság aránya. Használja a [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) metódust a képarány zárolásához.

Az alábbi példa megnyitja a `pres.pptx`‑t, amelynek legalább egy diája van, azon a diáron egy táblázat az első alakzatként. Kiírja a jelenlegi zárási állapotot, engedélyezi a képarány zárolását, kiírja a frissített állapotot (`true`), és a végeredményt `pres-out.pptx`‑ként menti.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt a teljes táblázatra és a celláiban lévő szövegre?**

Igen. A táblázat rendelkezik egy [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) metódussal, a bekezdések pedig a [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metódussal. Mindkettő használata biztosítja a helyes RTL sorrendet és a megfelelő megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók elmozdítsák vagy átméretezzék a táblázatot a végleges fájlban?**

Használja a [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) funkciót a mozgás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások táblázatokra is érvényesek.

**Támogatott-e képet beilleszteni egy cella háttérként?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) formátumot egy cellára; a kép a választott módnak (nyújtás vagy csempe) megfelelően lefedi a cellaterületet.