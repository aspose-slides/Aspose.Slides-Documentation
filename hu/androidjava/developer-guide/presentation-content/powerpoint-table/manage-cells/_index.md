---
title: A táblázatcellák kezelése prezentációkban Androidon
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/androidjava/manage-cells/
keywords:
- táblázatcella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Könnyedén kezelje a táblázatcellákat PowerPointban az Aspose.Slides for Android Java segítségével. Tanulja meg a cellák gyors elérését, módosítását és stílusának beállítását a zökkenőmentes diák automatizálásához."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi táblázatcellák elérését és módosítását PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan azonosíthatók az egyesített táblázatcellák, hogyan távolíthatók el a cellaszegélyek, hogyan kezelhető a cellaszámozás egyesítés vagy felbontás után, hogyan változtatható meg egy cella háttérszíne, valamint hogyan adható kép egy táblázatcellához. A példák bemutatják, hogyan hozhatunk létre vagy nyithatunk meg egy prezentációt, hogyan szerezhetünk be egy táblázatot egy diáról, hogyan frissíthetjük a cella formázását a cella‑tulajdonságok segítségével, és hogyan menthetjük a módosított prezentációt PPTX fájlként.

## **Egyesített táblázatcella azonosítása**
1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezzük be a táblázatot az első diáról. 
3. Iteráljunk végig a táblázat sorain és oszlopain, hogy megtaláljuk az egyesített cellákat.
4. Írjuk ki az üzenetet, ha egyesített cellákat találtunk.

Ez a Java‑kód bemutatja, hogyan azonosíthatók egyesített táblázatcellák egy prezentációban:

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

## **Táblázatcella szegélyek eltávolítása**
1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezzük be a dia referenciaját az indexe alapján. 
3. Definiáljunk egy oszlopsorozatot szélességgel.
4. Definiáljunk egy sorcsomagot magassággal.
5. Adjunk hozzá egy táblázatot a diára a [addTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) metódussal.
6. Iteráljunk végig minden cellán, hogy töröljük a felső, alsó, jobb és bal szegélyeket.
7. Mentse el a módosított prezentációt PPTX fájlként.

Ez a Java‑kód megmutatja, hogyan távolíthatók el a szegélyek a táblázatcellákból:

```java
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Táblázat alakzatot ad a diára
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
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

    // Írása a PPTX fájlt a lemezre
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egyesített cellákban**
Ha két cellapárt egyesítünk (1, 1) × (2, 1) és (1, 2) × (2, 2), a kapott táblázat számozott lesz. Ez a Java‑kód demonstrálja a folyamatot:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad a diához
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

    // Egyesíti a cellákat (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Egyesíti a cellákat (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Ezután további egyesítést végzünk, az (1, 1) és (1, 2) cellákat egyesítve. Az eredmény egy középső nagy egyesített cellát tartalmazó táblázat:

```java
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
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

    // Egyesíti a cellákat (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Egyesíti a cellákat (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Egyesíti a cellákat (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Kiírja a PPTX fájlt a lemezre
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számozás egy felosztott cellában**
Az előző példákban, amikor a táblázatcellákat egyesítettük, a többi cella számozása nem változott.  

Ezúttal egy szabályos táblázatot (azaz egy nem egyesített cellákat tartalmazót) veszünk, majd megpróbáljuk felosztani a (1,1) cellát, hogy egy speciális táblázatot kapjunk. Érdemes figyelni ennek a táblázatnak a számozására, amely elsőre furcsának tűnhet. Ennek az az oka, hogy a Microsoft PowerPoint a táblázatcellákat ilyen módon számozza, és az Aspose.Slides is ugyanezt a logikát követi.  

Ez a Java‑kód mutatja be a leírt folyamatot:

```java
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
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

    // Egyesíti a cellákat (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Egyesíti a cellákat (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Felosztja a (1, 1) cellát
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

	// Kiírja a PPTX fájlt a lemezre
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **A táblázatcella háttérszínének módosítása**

Ez a Java‑kód bemutatja, hogyan változtatható meg egy táblázatcella háttérszíne:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // új táblázat létrehozása
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

## **Kép beillesztése a táblázatcellába**

1. Hozzunk létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
2. Szerezzük be a dia referenciaját az indexe alapján.
3. Definiáljunk egy oszlopsorozatot szélességgel.
4. Definiáljunk egy sorcsomagot magassággal.
5. Adjunk hozzá egy táblázatot a diára a [AddTable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) metódussal.
6. Hozzunk létre egy `Images` objektumot a kép fájl tárolására.
7. Adjunk hozzá egy `IImage` képet a `IPPImage` objektumhoz.
8. Állítsuk be a `FillFormat`‑ot a táblázatcellához `Picture`‑re.
9. Helyezzük el a képet a táblázat első cellájában.
10. Mentse el a módosított prezentációt PPTX fájlként.

Ez a Java‑kód megmutatja, hogyan helyezhetünk el egy képet egy táblázatcellában táblázat létrehozásakor:

```java
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();
try {
    // Eléri az első diát
    ISlide islide = pres.getSlides().get_Item(0);

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Táblázat alakzatot ad a diára
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Létrehoz egy IPPImage objektumot a képfájl használatával
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Hozzáadja a képet az első táblázatcella
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Elmenti a PPTX fájlt a lemezre
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Beállíthatok‑e különböző vonalvastagságokat és stílusokat egy cella egyes oldalaira?**

Igen. A [felső](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[alsó](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[bal](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[jobb](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellformat/#getBorderRight--) szegélyek különálló tulajdonságokkal rendelkeznek, így minden oldal vastagsága és stílusa eltérő lehet. Ez logikusan következik a cikkben bemutatott oldalankénti szegélyvezérlésből.

**Mi történik a képpel, ha a cella háttérként beállítottá téve módosítom az oszlop/sor méretét?**

A viselkedés a [kitöltési módtól](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturefillmode/) (nyújtás/csempézés) függ. Nyújtás esetén a kép alkalmazkodik az új cellához, csempézés esetén a csempéket újraszámítják. A cikk említi a képmegjelenítési módokat egy cellában.

**Hozhatok‑e hiperhivatkozást a cella teljes tartalmához?**

A [Hyperlinks](/slides/hu/androidjava/manage-hyperlinks/) a cella szövegkeretén belüli szövegrész (portion) szintjén vagy a teljes táblázat/alkalmazás szintjén állítható be. Gyakorlatban a hivatkozást egy részhez vagy a cella összes szövegéhez rendeljük.

**Beállíthatok‑e különböző betűtípusokat egyetlen cellában?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/portion/) (futás) független formázását – betűtípus, stílus, méret és szín.