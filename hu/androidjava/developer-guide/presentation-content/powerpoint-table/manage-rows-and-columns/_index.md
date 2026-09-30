---
title: Sorok és oszlopok kezelése PowerPoint táblázatokban Androidon
linktitle: Sorok és oszlopok
type: docs
weight: 20
url: /hu/androidjava/manage-rows-and-columns/
keywords:
- táblázat sor
- táblázat oszlop
- első sor
- táblázat fejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázása
- oszlop szövegformázása
- táblázat stílus
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ke​zelje a táblázat sorait és oszlopait a PowerPointban az Aspose.Slides for Android via Java segítségével, és gyorsítsa a prezentáció szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java lehetővé teszi a táblázat szerkezetének és formázásának kezelését a PowerPoint‑prezentációkban a [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) osztály és az [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interfész segítségével. Megjelölhet egy fejlécsort, másolhat vagy eltávolíthat sorokat és oszlopokat, valamint szövegformázást alkalmazhat egy teljes sorra vagy oszlopra.

Ez a cikk elmagyarázza ezeket a műveleteket Java‑példákkal. Emellett bemutatja, hogyan lehet lekérni egy táblázat stílus‑presetjét, hogy újra felhasználhassa. A táblázat sor- és oszlopindexei 0‑alapúak.

## **Sormagasság vezérlése**

Használja az [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) metódust a sor minimális magasságának pontban történő beállításához. Ez egy alsó határ, nem rögzített magasság. Az [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) lekéri a tényleges magasságot. A sorhoz az [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--) segítségével férhet hozzá.

A példa betölti a [row-height-input.pptx](row-height-input.pptx) fájlt, amelyben a táblázat az első dián az első alakzatként szerepel. Az első sor 70 pontnál kezdődik. A cellák 18 pontos Arial szöveget, sortörést és 6 pontos felső és alsó margót használnak; a második oszlopban a hosszabb szöveg több sorba törik. A példa megnöveli a minimumot 100 pontra, majd lecsökkenti 20 pontra, minden változtatás után kiírja a tényleges magasságot, és elmenti mindkét eredményt.

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

A mellékelt prezentációval a minimum növelése helyet ad a sorban. A csökkentés eltávolítja ezt a plusz helyet, de a tényleges magasság továbbra is nagyobb lesz, mint 20 pont, mivel a szöveg és a cellamargók több helyet igényelnek. A minimum csak önmagában nem tudja alácsökkenteni a sort a tartalom által igényelt hely alá.

Több tényező befolyásolja a tényleges magasságot:

- **Szöveg és betűméret:** a hosszabb szöveg, explicite sortörések vagy nagyobb betűméret több függőleges helyet igényelhet.  
- **Sortörés és oszlopszélesség:** sortörés engedélyezésekor az oszlopszélesség csökkentése az [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) metódussal több sort eredményezhet. Egy szélesebb oszlop csökkentheti a függőlegesen szükséges helyet.  
- **Cellamargók:** az [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) és [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) függőleges helyet adnak hozzá. az [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) és [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) csökkentik a szöveg számára elérhető szélességet, ami további sortörést eredményezhet.

Ezen a táblázaton, amelyben nincs egyesített cella, a legtöbb függőleges helyet igénylő cella határozza meg a tartalom által vezérelt alsó határt a teljes sorra. A sor rövidebbé tételéhez esetleg a szöveget kell rövidíteni, a betűméretet vagy a margókat csökkenteni, vagy egy oszlopot szélesebbre tenni.

Az alábbi képek ugyanazt a táblázatot mutatják azonos méretben. A bemutatott eredményekben a tényleges magasságok 70, 100 és 55,2 pont voltak: az utolsó sor magasabb maradt, mint a 20 pontos minimum. A pontos szövegmérések a környezetben rendelkezésre álló betűtípusoktól függően változhatnak. Töltse le a mentett eredményeket: [increased minimum](row-height-increased.pptx) és [decreased minimum](row-height-decreased.pptx).

| Eredeti: minimum 70 pt, tényleges 70 pt | Növelve: minimum 100 pt, tényleges 100 pt | Csökkentve: minimum 20 pt, tényleges 55.2 pt |
| --- | --- | --- |
| ![Eredeti táblázat 70 pontos első sorral.](row-height-before.png) | ![Táblázat a első sor minimum 100 pontra növelése után.](row-height-increased.png) | ![Táblázat a első sor minimum 20 pontra csökkentése után; a sortörés a sort a minimumnál magasabbra tartja.](row-height-decreased.png) |

## **Állítsa be az első sort fejlécként**

Használja a [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-) metódust, hogy megjelölje az első sort fejlécként. A megjelenése a táblázatra alkalmazott táblastílustól függ.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal.  
2. Hozzáférés az első diához.  
3. Hozzáférés a dián az első alakzatként tárolt táblázathoz.  
4. Engedélyezze a fejlécek formázását az első sorra.  
5. Mentse a módosított prezentációt.

A példához `table.pptx` fájlra van szükség, amelyben a táblázat az első dián az első alakzatként szerepel. Engedélyezi az első sor fejlécek formázását, és elmenti a `First_row_header.pptx` fájlt.

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

## **Klónozzon táblázatsort vagy oszlopot**

Klónozza a sorokat vagy oszlopokat, hogy újra felhasználja a tartalmukat és formázásukat. A másolatot hozzáfűzheti a táblázat végéhez, vagy egy adott pozícióra beillesztheti.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal.  
2. Hozzáférés az első diához.  
3. Határozza meg az oszlopszélességeket és sormagasságokat.  
4. Adjon hozzá egy táblázatot az [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódussal.  
5. Klónozza a szükséges sorokat.  
6. Klónozza a szükséges oszlopokat.  
7. Mentse a módosított prezentációt.

A példához `Test.pptx` fájlra van szükség, amely legalább egy diát tartalmaz. Létrehoz egy három oszlopos és öt soros táblázatot, a méreteket pontban megadva. Az első sor és oszlop másolatait a végére fűzi, majd a második sor és oszlop másolatait a 3‑as indexnél (a negyedik pozíció) illeszti be. Az eredményül kapott táblázat hét sorból és öt oszlopból áll. A `false` argumentum megakadályozza a klónozást a szomszédos egyesített sorok vagy oszlopok esetén; ez a táblázat nem tartalmaz egyesített cellákat.

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

## **Táblázat sorának vagy oszlopának eltávolítása**

Távolítsa el a már nem szükséges sorokat vagy oszlopokat a táblázatból. Egy elem eltávolítása eltolja az azt követő sorok vagy oszlopok indexeit.

1. Hozzon létre egy prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal.  
2. Hozzáférés az első diához.  
3. Határozza meg az oszlopszélességeket és sormagasságokat.  
4. Adjon hozzá egy táblázatot az [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) metódussal.  
5. Távolítsa el a második sort és a második oszlopot.  
6. Mentse a módosított prezentációt.

Ez a példa egy három‑három táblázatot hoz létre, és eltávolítja az 1‑es indexű sort és oszlopot, így egy két‑két táblázat marad a `TestTable_out.pptx` fájlban. A méretek pontban vannak megadva. A `false` argumentum megakadályozza a szomszédos egyesített sorok vagy oszlopok eltávolítását; ez a táblázat nem tartalmaz egyesített cellákat.

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

Alkalmazzon szövegformázást egy teljes sorra, hogy a cellák egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy egyesével formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal.  
2. Hozzáférés az első dián lévő táblázathoz.  
3. Használja a [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódust az első sorra.  
4. Használja a [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metódusokat az első sorra.  
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust a második sorra.  
6. Mentse a módosított prezentációt.

A példához `table.pptx` fájlra van szükség, amelyben a táblázat az első dián az első alakzatként szerepel, és legalább két sor van. Az első sorra 25 pontos szöveget, jobb igazítást és 20 pontos jobb bekezdésmargót alkalmaz, majd a második sorra függőleges szöveget állít be.

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

Alkalmazzon szövegformázást egy teljes oszlopra, hogy a cellák egységesek legyenek. Beállíthat betűtulajdonságokat, bekezdésformázást és szövegirányt anélkül, hogy egyesével formázná a cellákat.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztállyal.  
2. Hozzáférés az első dián lévő táblázathoz.  
3. Használja a [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódust az első oszlopra.  
4. Használja a [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metódusokat az első oszlopra.  
5. Használja a [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust a második oszlopra.  
6. Mentse a módosított prezentációt.

A példához `table.pptx` fájlra van szükség, amelyben a táblázat az első dián az első alakzatként szerepel, és legalább két oszlop van. Az első oszlopra 25 pontos szöveget, jobb igazítást és 20 pontos jobb bekezdésmargót alkalmaz, majd a második oszlopra függőleges szöveget állít be.

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

## **Táblázat stílus tulajdonságainak lekérése**

Használja a [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) metódust, hogy lekérje egy táblázatra alkalmazott presetet, és újra felhasználja egy másik táblázaton. Ez a presetet azonosítja, nem az egyes cellák formázási felülírásait.

A példa létrehoz egy táblázatot, a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) presetet alkalmazza, és visszaolvassa a presetet. Kiírja a `DarkStyle1`-nek megfelelő egész értéket, majd elmenti a táblázatot a `table.pptx` fájlba.

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

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/elrendezés/mester téma beállításait, és továbbra is felülírhatja a kitöltéseket, szegélyeket és a szövegszíneket a téma felett.

**Rendezhetem a táblázat sorait úgy, mint az Excelben?**

Nem, az Aspose.Slides táblázatokban nincs beépített rendezés vagy szűrő. Először rendezd a adatokat a memóriában, majd töltsd fel a táblázat sorait a kívánt sorrendben.

**Lehet színes (csíkozott) oszlopok, miközben bizonyos cellákra egyedi színeket tartok fenn?**

Igen. Kapcsold be a csíkozott oszlopokat, majd felülírd a konkrét cellákat helyi formázással; a cellaszintű formázás felülírja a táblastílust.