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
- méretarány
- szöveg igazítása
- szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint diákban az Aspose.Slides for Android segítségével. Fedezzen fel egyszerű Java kódpéldákat, hogy hatékonyabbá tegye a táblázat-munkafolyamatait."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információk megjelenítésének és ábrázolásának. A cellák (sorokba és oszlopokba rendezve) rácsában lévő információ egyértelmű és könnyen érthető.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Table) osztályt, a [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) interfészt, a [Cell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cell/) osztályt, a [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) interfészt, valamint egyéb típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését a különféle bemutatókban.

## **Táblázat létrehozása nulláról**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Definiáljon egy `columnWidth` tömböt.  
4. Definiáljon egy `rowHeight` tömböt.  
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) metódus segítségével.  
6. Iteráljon végig minden [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) elemen, hogy formázást alkalmazzon a felső, alsó, jobb és bal szegélyekre.  
7. Olvassza össze a táblázat első sorának első két celláját.  
8. Érje el egy [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) objektumát.  
9. Adjon hozzá szöveget a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/) objektumhoz.  
10. Mentse el a módosított bemutatót.

Ez a Java kód megmutatja, hogyan hozhat létre táblázatot egy bemutatóban:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Táblázat alakzatot ad a diára
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
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
    // Összevonja az első sor első és második celláját
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Szöveget ad a összevont cellához
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Mentés a prezentációt lemezre
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullától indul. Az első cella a táblázatban 0,0 indexű (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a Java kód megmutatja, hogyan adhat meg számozást a táblázat celláira:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad a diára
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Mentés a prezentációt lemezre
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Meglévő táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot, és állítsa nullára.  
4. Iteráljon végig az összes [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektumon, amíg meg nem találja a táblázatot.  

   Ha úgy gondolja, hogy a vizsgált dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblázatként azonosít, átkonvertálhatja [Table](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Table) objektummá. Ha azonban a dia több táblázatot tartalmaz, jobb, ha a szükséges táblázatot a [setAlternativeText(String value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) metódus segítségével keresi.  
5. Használja a [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a táblázattal való munkához. Az alábbi példában egy cella szövegét állítjuk be a táblázatban.  
6. Mentse el a módosított bemutatót.

Ez a Java kód megmutatja, hogyan érheti el és dolgozhat egy meglévő táblázattal:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializálja a null TableEx-et
    ITable tbl = null;

    // Iterál a alakzatokon, és beállítja a megtalált táblázatra mutató hivatkozást
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Beállítja a szöveget a második sor első oszlopához
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Mentés a módosított prezentációt a lemezre
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A szövegkeretet tartalmazó cella megkeresése**

Amikor általános szövegfeldolgozó kód egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumot kap egy táblázatból, használja a [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentCell--) metódust a tulajdonos [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) lekéréséhez. Egy táblacellához tartozó szövegkeret esetén a [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentCell--) visszaadja a tulajdonost, míg a [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` értéket ad, még akkor is, ha a táblázat maga alakzat.

A cellakoordináták a csak-olvasásra szánt [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) és [ICell.getFirstRowIndex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) metódusokkal érhetők el. A [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentCell--) szintén csak-olvasásra szolgáló navigációt biztosít: visszaadja a tulajdonost, de nem módosítja a tulajdonjogot. Mindig ellenőrizze, hogy a visszakapott cella `null`-e, mielőtt felhasználná.

Egy teljes példa, amely azonosítja a táblacellák és alakzatok tulajdonosait, beleértve a SmartArt csomópontokhoz kapcsolódó alakzatokat, megtalálható a [Search and Replace Text](/slides/hu/androidjava/search-and-replace-text/) oldalon.

## **Szöveg igazítása egy táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diára.  
4. Érjen el egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumot a táblázatból.  
5. Érje el az [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/) elemet.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse el a módosított bemutatót.

Ez a Java kód megmutatja, hogyan igazítható a szöveg egy táblázatban:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosít egy Presentation osztályt
Presentation pres = new Presentation();
try {
    // Lekéri az első diát 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Táblázat alakzatot ad a diára
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Eléri a szövegkeretet
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Létrehozza a Paragraph objektumot a szövegkerethez
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Létrehozza a Portion objektumot a bekezdéshez
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Függőlegesen igazítja a szöveget
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Mentés a prezentációt a lemezre
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegformázás beállítása táblázatszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexén keresztül.  
3. Érjen el egy [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) objektumot a diáról.  
4. Állítsa be a szöveg [setFontHeight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) értékét.  
5. Állítsa be a [setAlignment(int value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight(float value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) értékeket.  
6. Állítsa be a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) értéket.  
7. Mentse el a módosított bemutatót.

Ez a Java kód megmutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázat szövegére:

```java
import com.aspose.slides.*;

// Létrehoz egy példányt a Presentation osztályból
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Tegyük fel, hogy az első dián az első alakzat egy táblázat
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Beállítja a táblázat celláinak betűmagasságát
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Beállítja a táblázat celláinak szövegigazítását és jobb margóját egy hívásban
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Beállítja a táblázat celláinak szöveg függőleges típusát
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázat stílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a táblázat stílus tulajdonságainak lekérését, hogy ezeket a részleteket más táblázatban vagy máshol felhasználhassa. Ez a Java kód megmutatja, hogyan kaphatja meg a stílus tulajdonságait egy táblázat előre beállított stílusából:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // módosítja az alapértelmezett stílus előre beállított témát

    // Lekéri a táblázat stílus előbeállítását
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Alkalmazza a lekért stílus előbeállítást egy másik táblázatra
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázat méretarányának zárolása**

A geometriai alakzat méretarányát a különböző dimenziók méreteinek aránya adja meg. Az Aspose.Slides a [**setAspectRatioLocked**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) tulajdonságot biztosítja a táblázatok és egyéb alakzatok méretarányának zárolásához.

Ez a Java kód megmutatja, hogyan zárolható a méretarány egy táblázat esetén:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertálja

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy egész táblázat és a celláinak szövege számára?**  
Igen. A táblázat rendelkezik egy [setRightToLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) metódussal, és a bekezdéseknek is van [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) metódusa. Mindkettő használata biztosítja a megfelelő RTL sorrendet és megjelenítést a cellákban.

**Hogyan akadályozhatom meg, hogy a felhasználók áthelyezzék vagy átméretezzék a táblázatot a végleges fájlban?**  
Használjon alakzatzárakat a mozgatás, átméretezés, kiválasztás stb. letiltásához. Ezek a zárak táblázatokra is érvényesek.

**Támogatott-e egy képet háttérként beilleszteni egy cellába?**  
Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a választott módtól (nyújtás vagy ismétlés) függően lefedi a cella területét.