---
title: Táblázatcellák kezelése prezentációkban .NET-ben
linktitle: Cellák kezelése
type: docs
weight: 30
url: /hu/net/manage-cells/
keywords:
- táblázatcella
- cellák egyesítése
- szegély eltávolítása
- cella felosztása
- kép a cellában
- háttérszín
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Könnyedén kezelje a táblázatcellákat a PowerPointban az Aspose.Slides for .NET segítségével. Tanulja meg a cellák gyors elérését, módosítását és formázását a zökkenőmentes diák automatizálásához."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy hozzáférjen és módosítsa a táblázatcellákat a PowerPoint‑prezentációkban. Ez a cikk elmagyarázza, hogyan azonosíthatja az egyesített táblázatcellákat, hogyan távolíthatja el a cellaszegélyeket, hogyan kezelheti a cellaszámozást az egyesítés vagy felosztás után, hogyan változtathatja meg egy cella háttérszínét, és hogyan adhat hozzá képet egy táblázatcellához. A példák bemutatják, hogyan hozhat létre vagy nyithat meg egy prezentációt, hogyan szerezhet be egy táblázatot egy diáról, hogyan frissítheti a cellaformázást a cella tulajdonságain keresztül, és hogyan mentheti el a módosított prezentációt PPTX fájlként.

## **Egyesített táblázatcellák azonosítása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a táblázatot az első diáról.  
3. Iteráljon a táblázat sorain és oszlopain, hogy megtalálja az egyesített cellákat.  
4. Mondjon ki egy üzenetet, amikor egyesített cellákat talál.

Ez a C# kód megmutatja, hogyan azonosíthatók az egyesített táblázatcellák egy prezentációban:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // feltételezve, hogy a Slide#0.Shape#0 egy táblázat
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Táblázatcellák szegélyeinek eltávolítása**

1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Szerzessen meg egy dia hivatkozást az indexe alapján.  
3. Határozzon meg egy oszlopsorozatot szélességgel.  
4. Határozzon meg egy sorok sorozatot magassággal.  
5. Adjon hozzá egy táblázatot a diához az `AddTable` metódussal.  
6. Iteráljon minden cellán, hogy törölje a felső, alsó, jobb és bal szegélyeket.  
7. Mentse el a módosított prezentációt PPTX fájlként.

Ez a C# kód megmutatja, hogyan távolíthatók el a szegélyek a táblázatcellákról:

```c#
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{
   // Hozzáfér az első diához
    Slide sld = (Slide)pres.Slides[0];

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Táblázat alakzatot ad hozzá a diához
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Kiírja a PPTX fájlt a lemezekre
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Számozás egyesített cellákban**

Ha összefésülünk 2 cellapárt (1, 1) x (2, 1) és (1, 2) x (2, 2), az eredményül kapott táblázat számozott lesz. Ez a C# kód bemutatja a folyamatot:

```c#
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Hozzáfér az első diához
    ISlide sld = presentation.Slides[0];

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad hozzá a diához
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Egyesíti a (1, 1) x (2, 1) cellákat
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Egyesíti a (1, 2) x (2, 2) cellákat
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Ezután további egyesítést végzünk a (1, 1) és (1, 2) cellák összefésülésével. Az eredmény egy középen nagy egyesített cellát tartalmazó táblázat:

```c#
// Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Hozzáfér az első diához
    ISlide slide = presentation.Slides[0];

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad hozzá a diához
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Egyesíti a (1, 1) x (2, 1) cellákat
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Egyesíti a (1, 2) x (2, 2) cellákat
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Egyesíti a (1, 2) x (2, 2) cellákat
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Kiírja a PPTX fájlt a lemezekre
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Számozás egy felosztott cellában**

Az előző példákban, amikor a táblázatcellák egyesültek, a többi cellában lévő számozás vagy számrendszer nem változott.

Ez alkalommal egy szabályos táblázatot (egy egyesített cellákat nem tartalmazó táblázatot) veszünk, majd megpróbáljuk felosztani a (1,1) cellát, hogy egy különleges táblázatot kapjunk. Érdemes figyelni a táblázat számozására, amely furcsának tűnhet. Azonban ez a mód, ahogyan a Microsoft PowerPoint számozza a táblázatcellákat, és az Aspose.Slides is ugyanezt teszi.

Ez a C# kód szemlélteti a leírt folyamatot:

```c#
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Hozzáfér az első diához
    ISlide slide = presentation.Slides[0];

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad hozzá a diához
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Beállítja a szegély formátumát minden cellához
    foreach (IRow row in table.Rows)
    {
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderTop.Width = 5;

            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderBottom.Width = 5;

            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderLeft.Width = 5;

            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
            cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
            cell.CellFormat.BorderRight.Width = 5;

        }
    }

    // Egyesíti a (1, 1) x (2, 1) cellákat
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Egyesíti a (1, 2) x (2, 2) cellákat
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Felosztja a (1, 1) cellát. 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Kiírja a PPTX fájlt a lemezekre
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **A táblázatcella háttérszínének módosítása**

Ez a C# kód megmutatja, hogyan változtatható meg egy táblázatcella háttérszíne:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // új táblázat létrehozása
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // egy cella háttérszínének beállítása
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Kép beszúrása egy táblázatcellába**

1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Szerzessen meg egy dia hivatkozást az indexe alapján.  
3. Határozzon meg egy oszlopok tömbjét szélességgel.  
4. Határozzon meg egy sorok tömbjét magassággal.  
5. Adjon hozzá egy táblázatot a diához az `AddTable` metódussal.  
6. Hozzon létre egy `Bitmap` objektumot a kép fájl tárolására.  
7. Adja hozzá a bitmap képet az `IPPImage` objektumhoz.  
8. Állítsa be a táblázatcella `FillFormat` értékét `Picture`-re.  
9. Tegye a képet a táblázat első cellájába.  
10. Mentse el a módosított prezentációt PPTX fájlként

Ez a C# kód megmutatja, hogyan helyezhető el egy kép egy táblázatcellában táblázat létrehozásakor:

```c#
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation presentation = new Presentation())
{
    // Hozzáfér az első diához
    ISlide slide = presentation.Slides[0];

    // Oszlopokat definiál szélességekkel és sorokat magasságokkal
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Táblázat alakzatot ad hozzá a diához
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Betölt egy képet a fájlból, és hozzáadja a prezentáció erőforrásaihoz
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Hozzáadja a képet az első táblázatcellához
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Elmenti a PPTX fájlt a lemezekre
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Beállíthatok különböző vonalvastagságot és stílust egy cella különböző oldalaihoz?**

Igen. A [top](https://reference.aspose.com/slides/hu/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/hu/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/hu/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/hu/net/aspose.slides/cellformat/borderright/) szegélyeknek külön tulajdonságaik vannak, így minden oldal vastagsága és stílusa eltérhet. Ez logikusan következik a cikkben bemutatott cella oldalankénti szegélyvezérlésből.

**Mi történik a képpel, ha a oszlop/sor méretét módosítom a kép cella háttérként való beállítása után?**

A viselkedés a [fill mode](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillmode/) (stretch/tile) értékétől függ. Nyújtás esetén a kép igazodik az új cellához; csempe esetén a csempeelemek újraszámolásra kerülnek. A cikk említi a képek megjelenítési módjait egy cellában.

**Hozzáadhatok hivatkozást a cella teljes tartalmához?**

[Hyperlinks](/slides/hu/net/manage-hyperlinks/) a cella szövegkeretén belüli (rész) szintjén vagy az egész táblázat/alak szintjén állítható be. Gyakorlatban a hivatkozást egy részre vagy a cella teljes szövegére lehet alkalmazni.

**Beállíthatok különböző betűtípusokat egyetlen cellán belül?**

Igen. A cella szövegkerete támogatja a [portions](https://reference.aspose.com/slides/hu/net/aspose.slides/portion/) (futamok) önálló formázását — betűcsalád, stílus, méret és szín.