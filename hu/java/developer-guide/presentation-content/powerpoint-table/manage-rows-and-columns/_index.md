---
title: "Sorok és oszlopok kezelése PowerPoint táblázatokban Java segítségével"
linktitle: "Sorok és oszlopok"
type: docs
weight: 20
url: /hu/java/manage-rows-and-columns/
keywords:
- táblázatsor
- táblázatoszlop
- első sor
- táblázatfejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- soros szövegformázás
- oszlopos szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Kezelje a táblázatok sorait és oszlopait PowerPoint-ban az Aspose.Slides for Java használatával, és gyorsítsa fel a prezentációk szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides for Java lehetővé teszi, hogy a PowerPoint‑prezentációk táblázatszerkezetét és formázását a [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) osztály és az [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) interfész segítségével kezelje. Kijelölhet egy fejlécsort, klónozhat vagy eltávolíthat sorokat és oszlopokat, és alkalmazhat szövegformázást egy egész sorra vagy oszlopra.

Ez a cikk bemutatja ezeket a műveleteket Java‑példákkal. Megmutatja, hogyan lehet lekérni egy táblázat stílus‑előbeállítását, hogy újra felhasználhassa. A táblázat sor- és oszlopindexei nulláról indulnak.

## **Sormagasság vezérlése**

Az [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) használatával állíthatja be egy sor minimális magasságát pontban. Ez egy alsó határ, nem rögzített magasság. Az [IRow.getHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#getHeight--) visszaadja a tényleges magasságot. A sort a [ITable.getRows](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getRows--) segítségével érheti el.

A példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amelyben a táblázat az első dián az első alakzat. Az első sor 70 pontnál kezdődik. A cellák 18 pontos Arial szöveget, sortörést és 6 pontos felső és alsó margót használnak; a második oszlopban a hosszabb szöveg több sorra törik. A példa a minimumot 100 pontra növeli, majd 20 pontra csökkenti, minden változtatás után kiírja a tényleges magasságot, és elmenti mindkét eredményt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A mellékelt prezentációval a minimum növelése helyet ad a sorban. A csökkentés eltávolítja ezt a plusz helyet, de a tényleges magasság továbbra is nagyobb lesz 20 pontnál, mert a szövegnek és a cellamargóknak több helyre van szükségük. A minimum csak önmagában nem kényszerítheti a sort a tartalma által igényelt hely alá.

Több tényező befolyásolja a tényleges magasságot:

- **Szöveg és betűméret:** hosszabb szöveg, explicit sortörések vagy nagyobb betűméret több függőleges helyet igényelhet.
- **Sortörés és oszlopszélesség:** sortörés engedélyezésekor a [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) segítségével a oszlopszélesség csökkentése több sort eredményezhet. Szélesebb oszlop csökkentheti a függőleges helyigényt.
- **Cellamargók:** [ICell.setMarginTop](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginTop-double-) és [ICell.setMarginBottom](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginBottom-double-) függőleges helyet adnak hozzá. [ICell.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginLeft-double-) és [ICell.setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setMarginRight-double-) csökkentik a szöveg számára rendelkezésre álló szélességet, ami további sortörést okozhat.

Egy egyesített cellákat nem tartalmazó táblázatnál az a cella, amelyik a legtöbb függőleges helyet igényli, határozza meg a sor alsó határát. A sor rövidebbé tételéhez gyakran szükséges a szöveg rövidítése, a betűméret vagy a margók csökkentése, illetve egy oszlop szélesítése.

Az alábbi képek ugyanazt a táblázatot mutatják azonos méretben. A bemutatott eredményekben a tényleges magasságok 70, 100 és 55,2 pont voltak: az utolsó sor magasabb maradt a 20 pontos minimumnál. A pontos szövegméretek a környezetben elérhető betűtípusoktól függően változhatnak. Töltse le a mentett eredményeket: [megnövelt minimum](row-height-increased.pptx) és [csökkentett minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Megnövelt: minimum 100 pt, tényleges 100 pt | Csökkentett: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti táblázat 70 pontos első sorral.](row-height-before.png) | ![Táblázat a első sor minimum 100 pontra növelése után.](row-height-increased.png) | ![Táblázat az első sor minimum 20 pontra csökkentése után; a sortörés miatt a sor magasabb marad a minimumnál.](row-height-decreased.png) |

## **Az első sor beállítása fejlécként**

Használja a [setFirstRow](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setFirstRow-boolean-) metódust az első sor fejlécként való megjelöléséhez. Megjelenése a táblára alkalmazott táblastílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Érje el a dián az első alakzatként tárolt táblázatot.
4. Engedélyezze a fejlécformázást az első sorra.
5. Mentse el a módosított prezentációt.

A példa `table.pptx` fájlt igényel, amelyben az első dián az első alakzat egy táblázat. Az első sorra engedélyezi a fejlécformázást, majd elmenti a `First_row_header.pptx` fájlt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Táblázat sorának vagy oszlopának klónozása**

Klónozza a sorokat vagy oszlopokat, hogy újra felhasználja a tartalmukat és formázásukat. A másolatot a táblázat végére fűzheti, vagy egy adott pozícióba beillesztheti.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Adja meg az oszlopszélességeket és sormagasságokat.
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódussal.
5. Klónozza a szükséges sorokat.
6. Klónozza a szükséges oszlopokat.
7. Mentse el a módosított prezentációt.

A példa `Test.pptx` fájlt igényel, amely legalább egy diát tartalmaz. Létrehoz egy három oszlopos és öt soros táblázatot, pontban megadott méretekkel. Az első sort és oszlopot a végére másolja, majd a második sort és oszlopot a 3‑as indexre (a negyedik pozícióra) illeszti be. Az eredmény egy hét soros és öt oszlopos táblázat. A `false` argumentum letiltja a klónozást összetartozó összeolvasztott sorokra vagy oszlopokra; ez a táblázat nem tartalmaz összeolvasztott cellákat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sor vagy oszlop eltávolítása a táblázatból**

Távolítson el sorokat vagy oszlopokat, amelyre már nincs szükség a táblázatban. Egy elem eltávolítása eltolja az azt követő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztállyal.
2. Érje el az első diát.
3. Adja meg az oszlopszélességeket és sormagasságokat.
4. Adjon hozzá egy táblázatot a [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódussal.
5. Távolítsa el a második sort és a második oszlopot.
6. Mentse el a módosított prezentációt.

Ez a példa egy három‑háromas táblázatot hoz létre, majd a 1‑es indexű sort és oszlopot eltávolítja, így egy két‑kétas táblázat marad a `TestTable_out.pptx` fájlban. A méretek pontban vannak megadva. A `false` argumentum letiltja az összeolvasztott sorok vagy oszlopok szomszédos eltávolítását; ez a táblázat nem tartalmaz összeolvasztott cellákat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegformázás beállítása a táblázatsor szintjén**

Alkalmazzon szövegformázást egy teljes sorra, hogy a cellák egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy egyes cellákat külön formázná.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztállyal.
2. Érje el a táblázatot az első dián.
3. Használja a [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódust az első sorra.
4. Használja a [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metódusokat az első sorra.
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust a második sorra.
6. Mentse el a módosított prezentációt.

A példa `table.pptx` fájlt igényel, amelyben az első dián az első alakzat egy táblázat, és legalább két sor szerepel benne. 25 pontos szöveget, jobbra igazítást és 20 pontos jobb oldali bekezdésmargót alkalmaz az első sorra, majd a második sorra függőleges szöveget állít be.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegformázás beállítása a táblázatoszlop szintjén**

Alkalmazzon szövegformázást egy teljes oszlopra, hogy a cellák egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy egyes cellákat külön formázná.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztállyal.
2. Érje el a táblázatot az első dián.
3. Használja a [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódust az első oszlopra.
4. Használja a [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metódusokat az első oszlopra.
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust a második oszlopra.
6. Mentse el a módosított prezentációt.

A példa `table.pptx` fájlt igényel, amelyben az első dián az első alakzat egy táblázat, és legalább két oszlop szerepel benne. 25 pontos szöveget, jobbra igazítást és 20 pontos jobb oldali bekezdésmargót alkalmaz az első oszlopra, majd a második oszlopra függőleges szöveget állít be.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A táblázat stílus tulajdonságainak lekérése**

Használja a [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) metódust a táblázatra alkalmazott előbeállítás lekéréséhez, majd azt egy másik táblázaton újra felhasználhatja. Ez az előbeállítást azonosítja, nem pedig az egyes cellák felülírt formázását.

A példa létrehoz egy táblázatot, alkalmazza a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/#DarkStyle1) előbeállítást, majd visszaolvassa azt. Kiírja a `DarkStyle1`-nek megfelelő egész értéket, és menti a táblázatot a `table.pptx` fájlba.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/elrendezés/mester témát, és továbbra is felülírhatja a kitöltéseket, szegélyeket és szövegszíneket a téma felett.

**Rendezhetem a táblázat sorait, mint az Excelben?**

Nem, az Aspose.Slides táblázatokban nincs beépített rendezés vagy szűrés. Először rendezze az adatokat a memóriában, majd töltse fel a táblázatsorokat a kívánt sorrendben.

**Lehetnek csíkos (csíkolt) oszlopok, miközben egyes cellák egyéni színeit megtartom?**

Igen. Kapcsolja be a csíkos oszlopokat, majd a konkrét cellákat helyi formázással felülírja; a cellaszintű formázás felülbírálja a táblastílust.