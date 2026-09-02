---
title: Prezentációs táblázatok kezelése Java-ban
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/java/manage-table/
keywords:
- tábla hozzáadása
- tábla létrehozása
- tábla elérése
- képarány
- szöveg igazítása
- szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint-diákon az Aspose.Slides for Java segítségével. Fedezze fel az egyszerű kódrészleteket, hogy hatékonyabbá tegye a táblázati munkafolyamatokat."
---
## **Bevezetés**

A PowerPoint táblázata hatékony módja az információk megjelenítésének és ábrázolásának. A cellák (sorokba és oszlopokba rendezett) rácsában lévő információk egyszerűek és könnyen érthetőek.

Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Table) osztályt, az [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) interfészt, a [Cell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cell/) osztályt, az [ICell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/) interfészt és egyéb típusokat biztosít, amelyekkel táblázatokat hozhat létre, frissíthet és kezelhet mindenféle bemutatóban. 

## **Táblázat létrehozása a semmiből**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a diára való hivatkozást az indexén keresztül.  
3. `columnWidth` tömbjének definiálása.  
4. `rowHeight` tömbjének definiálása.  
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot a diára a [addTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) metódus segítségével.  
6. Iteráljon minden [ICell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/) elemen a felső, alsó, jobb és bal szegélyek formázásához.  
7. Fésülje össze a táblázat első sorának első két celláját.  
8. Érje el egy [ICell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/) [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/) objektumát.  
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)-hez.  
10. Mentse a módosított bemutatót.  

Ez a Java kód bemutatja, hogyan hozhat létre táblázatot egy bemutatóban:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Létrehozza a Presentation osztály egy példányát, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Táblázat alakzatot ad hozzá a diához
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegélyformátumot minden cellához
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
    // Összevonja az 1. sor 1. és 2. celláját
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Szöveget ad a összevont cellához
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Mentse a bemutatót a lemezre
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egy standard táblázatban**

Egy standard táblázatban a cellák számozása egyszerű és nulláról kezdődik. A táblázat első cellája 0,0 (oszlop 0, sor 0) indexel.

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a Java kód bemutatja, hogyan adhatja meg a cellák számozását egy táblázatban:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Elindít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Oszlopok szélességének és sorok magasságának meghatározása
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad hozzá a diához
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegélyformátumot minden cellához
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

    // Mentse a bemutatót a lemezre
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Létező táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  

2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexén keresztül.  

3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot, és állítsa null értékre.  

4. Iteráljon az összes [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) objektumon, amíg a táblázat meg nem található.  
   Ha úgy gondolja, hogy a feldolgozott dia egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzatot táblázatként azonosít, akkor típuskonvertálhatja [Table](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Table) objektummá. Ha a dia több táblázatot tartalmaz, akkor célszerűbb a szükséges táblázatot a [setAlternativeText(String value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-) metódus alapján keresni.  

5. Használja az [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot a táblázat kezeléséhez. Az alábbi példában új sort adtunk a táblázathoz.  

6. Mentse a módosított bemutatót.  

Ez a Java kód bemutatja, hogyan érheti el és dolgozhat fel egy létező táblázatot:

```java
import com.aspose.slides.*;

// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Inicializálja a null TableEx-et
    ITable tbl = null;

    // Végig iterál a alakzatokon és beállítja a megtalált táblázatra a hivatkozást
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Beállítja a szöveget a második sor első oszlopához
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Mentse a módosított bemutatót a lemezre
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Keresse meg a szövegkeretet tartalmazó cellát**

Ha általános szövegfeldolgozó kód egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) objektumot kap egy táblázatból, használja az [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentCell--) metódust a tulajdonos [ICell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/) lekéréséhez. Egy táblacellás szövegkeret esetén az [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentCell--) visszaadja a tulajdonost, míg az [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentShape--) `null` értéket ad, még akkor is, ha a táblázat maga alakzat.

A cellakoordináták a csak olvasható [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/#getFirstColumnIndex--) és [ICell.getFirstRowIndex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/#getFirstRowIndex--) metódusokon keresztül érhetők el. Az [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentCell--) szintén csak olvasható navigációt biztosít: visszaadja a tulajdonost, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze a visszakapott cellát `null` érték ellen, mielőtt felhasználná.

Egy teljes példáért, amely azonosítja a táblacellákat és alakzat tulajdonosokat, beleértve a SmartArt csomópontokkal kapcsolatos alakzatokat, lásd a [Search and Replace Text](/slides/hu/java/search-and-replace-text/) oldalt.

## **Szöveg igazítása egy táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a diára való hivatkozást az indexén keresztül.  
3. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumot a diára.  
4. Érjen hozzá egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) objektumhoz a táblázatból.  
5. Érjen hozzá az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/) objektumához.  
6. Igazítsa függőlegesen a szöveget.  
7. Mentse a módosított bemutatót.  

Ez a Java kód bemutatja, hogyan igazíthatja a szöveget egy táblázatban:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation();
try {
    // Lekéri az első diát
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Hozzáadja a táblázat alakzatot a diához
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
    
    // Mentse a bemutatót a lemezre
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegformázás beállítása a táblázat szintjén**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.  
2. Szerezze meg a diára való hivatkozást az indexén keresztül.  
3. Érjen hozzá egy [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITable) objektumhoz a diáról.  
4. Állítsa be a [setFontHeight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) metódust a szöveghez.  
5. Állítsa be a [setAlignment(int value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) és a [setMarginRight(float value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) metódusokat.  
6. Állítsa be a [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) metódust.  
7. Mentse a módosított bemutatót.  

Ez a Java kód bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat egy táblázat szövegére:

```java
import com.aspose.slides.*;

// Létrehozza a Presentation osztály egy példányát
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Tegyük fel, hogy az első dia első alakzata egy táblázat
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Beállítja a táblázat celláinak betűmagasságát
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Egy hívással beállítja a cellák szövegigazítását és jobb margóját
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Beállítja a cellák szöveg függőleges típusát
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblázat stílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, így ezeket a részleteket felhasználhatja egy másik táblázathoz vagy máshová. Ez a Java kód bemutatja, hogyan szerezheti meg a stílus tulajdonságokat egy táblázat előre beállított stílusából:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // módosítja az alapértelmezett stílus előbeállítását

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

## **Táblázat képarányának zárolása**

A geometriai alakzat képaránya annak különböző dimenziókban mért méreteinek aránya. Az Aspose.Slides biztosítja a **setAspectRatioLocked** tulajdonságot, amely lehetővé teszi a képarány beállításának zárolását táblázatok és egyéb alakzatok esetén.  

Ez a Java kód bemutatja, hogyan zárolhatja a képarányt egy táblázatra:

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

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy egész táblázatra és a cellák szövegére?**

Igen. A táblázat rendelkezik egy [setRightToLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/table/#setRightToLeft-boolean-) metódussal, és a bekezdések rendelkeznek a [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) beállítással. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók mozgassák vagy átméretezzék a táblázatot a végleges fájlban?**

Használja a [shape locks](/slides/hu/java/applying-protection-to-presentation/) funkciókat a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép cellán belüli háttérként történő beszúrása?**

Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a kiválasztott mód (nyújtás vagy csempe) szerint lefedi a cella területét.