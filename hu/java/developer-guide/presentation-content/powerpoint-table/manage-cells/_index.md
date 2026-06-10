---
title: Java használatával táblacellák kezelése prezentációkban
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/java/manage-cells/
keywords:
- táblacella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Könnyedén kezelje a táblacellákat PowerPoint-ban az Aspose.Slides for Java segítségével. Gyorsan elsajátíthatja a cellák elérését, módosítását és formázását a zökkenőmentes diák automatizálásához."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi táblázatcellák elérését és módosítását a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatja az egyesített táblázatcellákat, hogyan távolíthatja el a cellaszegélyeket, hogyan kezelheti a cellaszámozást az egyesítés vagy felosztás után, hogyan változtathatja meg egy cella háttérszínét, és hogyan adhat hozzá képet egy táblázatcellához. A példák azt mutatják, hogyan hozhat létre vagy nyithat meg egy prezentációt, hogyan szerezhet be egy táblázatot egy diából, hogyan frissítheti a cellaformázást a cella‑tulajdonságokon keresztül, és hogyan mentheti a módosított prezentációt PPTX fájlként.

## **Egyesített táblázatcellák azonosítása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Szerezze meg a táblázatot az első diáról.
3. Iteráljon a táblázat sorain és oszlopain, hogy megtalálja az egyesített cellákat.
4. Írjon ki üzenetet, amikor egyesített cellákat talál.

Ez a Java kód megmutatja, hogyan azonosíthatja az egyesített táblázatcellákat egy prezentációban:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // feltételezve, hogy a Slide#0.Shape#0 egy táblázat
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Táblacellaszegélyek eltávolítása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Szerezze meg a diát a indexe alapján.
3. Definiáljon egy oszlopok szélességét tartalmazó tömböt.
4. Definiáljon egy sorok magasságát tartalmazó tömböt.
5. Adjon hozzá egy táblázatot a diához az [addTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) módszerrel.
6. Iteráljon minden cellán, hogy törölje a felső, alsó, jobb és bal szegélyeket.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a Java kód megmutatja, hogyan távolítható el a szegély a táblacellákról:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Hozzáad egy táblázat alakzatot a diához
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegélyformátumot minden cellához
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Kiírja a PPTX fájlt a lemezre
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egyesített cellákban**
Ha két cellapárt egyesítünk (1, 1) x (2, 1) és (1, 2) x (2, 2), a kapott táblázat számozott lesz. Ez a Java kód szemlélteti a folyamatot:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Hozzáad egy táblázat alakzatot a diához
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

    // Egyesíti a (1, 1) x (2, 1) cellákat
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Egyesíti a (1, 2) x (2, 2) cellákat
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ezután további egyesítést hajtunk végre a (1, 1) és (1, 2) cellák összevonásával. Az eredmény egy táblázat, amely közepén egy nagy egyesített cellát tartalmaz:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Hozzáad egy táblázat alakzatot a diához
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

    // Egyesíti a (1, 1) x (2, 1) cellákat
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Egyesíti a (1, 2) x (2, 2) cellákat
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Egyesíti a (1, 1) x (1, 2) cellákat
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Kiírja a PPTX fájlt a lemezre
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egy felosztott cellában**
Az előző példákban, amikor a táblacellákat egyesítették, a többi cella számozása vagy számrendszere nem változott.

Ezúttal egy normál táblázatot (egy, egyesített cellákat nem tartalmazó táblát) használunk, majd megpróbáljuk felosztani az (1,1) cellát, hogy egy speciális táblát kapjunk. Érdemes figyelni erre a táblázat számozására, amely furcsának tűnhet. Azonban ez a Microsoft PowerPoint módja a táblacellák számozására, és az Aspose.Slides is ugyanezt teszi.

Ez a Java kód bemutatja a leírt folyamatot:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Hozzáad egy táblázat alakzatot a diához
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

    // Egyesíti a (1, 1) x (2, 1) cellákat
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Egyesíti a (1, 2) x (2, 2) cellákat
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Felosztja a (1, 1) cellát
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Kiírja a PPTX fájlt a lemezre
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A táblacellaháttér színének módosítása**

Ez a Java kód megmutatja, hogyan változtatható meg egy táblacella háttérszíne:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // létrehoz egy új táblát
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // beállítja egy cella háttérszínét 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Kép hozzáadása egy táblacellába**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
2. Szerezze meg a diát az indexe alapján.
3. Definiáljon egy oszlopok szélességét tartalmazó tömböt.
4. Definiáljon egy sorok magasságát tartalmazó tömböt.
5. Adjon hozzá egy táblázatot a diához az [AddTable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) módszerrel.
6. Hozzon létre egy `Images` objektumot a kép fájl tárolására.
7. Adja hozzá az `IImage` képet az `IPPImage` objektumhoz.
8. Állítsa be a `FillFormat` értékét a táblacellához `Picture`‑re.
9. Adja hozzá a képet a táblázat első cellájához.
10. Mentse a módosított prezentációt PPTX fájlként

Ez a Java kód megmutatja, hogyan helyezzen el egy képet egy táblacellában táblázat létrehozásakor:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide islide = pres.getSlides().get_Item(0);

    // Definiálja az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Hozzáad egy táblázat alakzatot a diához
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Létrehoz egy IPPImage objektumot a képfájl felhasználásával
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Hozzáadja a képet az első táblázat cellához
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Mentés a PPTX fájl lemezre
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust a cella egyes oldalain?**

Igen. A [felső](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellformat/#getBorderTop--)/[alsó](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellformat/#getBorderBottom--)/[bal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellformat/#getBorderLeft--)/[jobb](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellformat/#getBorderRight--) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet. Ez logikusan következik a cikkben bemutatott cella per oldalra vonatkozó szegélyvezérlésből.

**Mi történik a képpel, ha megváltoztatom az oszlop/sor méretét miután képet állítottam be a cella háttérként?**

A viselkedés a [kitöltési mód](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturefillmode/) (nyújtás/csempézés) függvénye. Nyújtás esetén a kép a új cellához igazodik; csempézés esetén a csempéket újraszámolják. A cikk említi a kép megjelenítési módjait egy cellában.

**Hozzáadhatok hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/java/manage-hyperlinks/) a cella szövegkeretén belüli szövegszakasz (portion) szintjén vagy a teljes táblázat/forma szintjén állítható be. Gyakorlatban a hivatkozást egy szakaszhoz vagy a cella teljes szövegéhez rendeli.

**Beállíthatok különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/portion/) (futtatások) független formázásával – betűcsalád, stílus, méret és szín.