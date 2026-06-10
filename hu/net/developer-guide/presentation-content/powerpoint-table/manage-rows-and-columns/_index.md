---
title: "PowerPoint táblázatok sorainak és oszlopainak kezelése .NET-ben"
linktitle: "Sorok és oszlopok"
type: docs
weight: 20
url: /hu/net/manage-rows-and-columns/
keywords:
- tábla sor
- tábla oszlop
- első sor
- tábla fejléc
- sor klónozása
- oszlop klónozása
- sor másolása
- oszlop másolása
- sor eltávolítása
- oszlop eltávolítása
- sor szövegformázása
- oszlop szövegformázása
- tábla stílus
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje a táblázatok sorait és oszlopait PowerPointban az Aspose.Slides for .NET segítségével, és gyorsítsa fel a prezentációk szerkesztését és az adatok frissítését."
---
## **Bevezetés**

Ahhoz, hogy táblázatok sorait és oszlopait kezelhesse egy PowerPoint‑prezentációban, az Aspose.Slides a [Table](https://reference.aspose.com/slides/hu/net/aspose.slides/table/) osztályt, az [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) interfészt és számos egyéb típust biztosít. 

## **Az első sor beállítása fejlécnek**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltse be a prezentációt. 
2. Szerezze be egy dia hivatkozását az indexe alapján. 
3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot, és állítsa null értékre. 
4. Iteráljon végig az összes [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) objektumon, hogy megtalálja a megfelelő táblázatot. 
5. Állítsa a táblázat első sorát fejlécnek. 

Ez a C# kód bemutatja, hogyan állítható be egy táblázat első sora fejlécként:

```c#
// Példányosítja a Presentation osztályt
Presentation pres = new Presentation("table.pptx");

// Eléri az első diát
ISlide sld = pres.Slides[0];

// Inicializálja a null TableEx-et
ITable tbl = null;

// Végigiterál a formákon, és hivatkozást állít be a táblázatra
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Beállítja a táblázat első sorát fejlécnek
tbl.FirstRow = true;

// Mentse a prezentációt a lemezre
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Táblázatsor vagy -oszlop klónozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltse be a prezentációt, 
2. Szerezze be egy dia hivatkozását az indexe alapján. 
3. Definiáljon egy `columnWidth` tömböt. 
4. Definiáljon egy `rowHeight` tömböt. 
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diára a [AddTable](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addtable/) metódus segítségével. 
6. Klónozza a táblázat sorát. 
7. Klónozza a táblázat oszlopát. 
8. Mentse el a módosított prezentációt. 

Ez a C# kód bemutatja, hogyan klónozható egy PowerPoint táblázat sora vagy oszlopa:

```c#
 // Példányosítja a Presentation osztályt
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Eléri az első diát
    ISlide sld = presentation.Slides[0];

    // Meghatározza az oszlopokat szélességekkel és a sorokat magasságokkal
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Hozzáad egy táblázat alakzatot a diához
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Szöveget ad a 1. sor 1. cellájához
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Szöveget ad a 1. sor 2. cellájához
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Klónozza az 1. sort a táblázat végén
    table.Rows.AddClone(table.Rows[0], false);

    // Szöveget ad a 2. sor 1. cellájához
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Szöveget ad a 2. sor 2. cellájához
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Klónozza a 2. sort a táblázat 4. soraként
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Klónozza az első oszlopot a végén
    table.Columns.AddClone(table.Columns[0], false);

    // Klónozza a 2. oszlopot a 4. oszlop indexén
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Mentse a prezentációt a lemezre 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Sor vagy oszlop eltávolítása táblázatból**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltse be a prezentációt, 
2. Szerezze be egy dia hivatkozását az indexe alapján. 
3. Definiáljon egy `columnWidth` tömböt. 
4. Definiáljon egy `rowHeight` tömböt. 
5. Adjon egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diára a [AddTable](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addtable/) metódus segítségével. 
6. Távolítsa el a táblázat sorát. 
7. Távolítsa el a táblázat oszlopát. 
8. Mentse el a módosított prezentációt. 

Ez a C# kód bemutatja, hogyan távolítható el egy sor vagy oszlop egy táblázatból:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Szövegformázás beállítása táblázatsor szinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltsd be a prezentációt, 
2. Szerezze be egy dia hivatkozását az indexe alapján. 
3. Érje el a megfelelő [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diáról. 
4. Állítsa be az első sor celláinak [FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontheight/). 
5. Állítsa be az első sor celláinak [Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) és [MarginRight](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginright/) értékeit. 
6. Állítsa be a második sor celláinak [TextVerticalType](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/textverticaltype/). 
7. Mentse el a módosított prezentációt. 

Ez a C# kód demonstrálja a műveletet.

```c#
// Példányosítja a Presentation osztályt
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Feltételezzük, hogy az első dia első alakzata egy táblázat

// Beállítja az első sor celláinak betűméretét
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Beállítja az első sor celláinak szövegigazítását és jobb margóját
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Beállítja a második sor celláinak függőleges szöveg típusát
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Mentse a prezentációt a lemezre
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Szövegformázás beállítása táblázatoszlop szinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból, és töltsd be a prezentációt, 
2. Szerezze be egy dia hivatkozását az indexe alapján. 
3. Érje el a megfelelő [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diáról. 
4. Állítsa be az első oszlop celláinak [FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontheight/). 
5. Állítsa be az első oszlop celláinak [Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) és [MarginRight](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginright/) értékeit. 
6. Állítsa be a második oszlop celláinak [TextVerticalType](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/textverticaltype/). 
7. Mentse el a módosított prezentációt. 

Ez a C# kód demonstrálja a műveletet: 

```c#
// Példányosítja a Presentation osztályt
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Feltételezzük, hogy az első dia első alakzata egy táblázat

// Beállítja az első oszlop celláinak betűmagasságát
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Beállítja az első oszlop celláinak szövegigazítását és jobb margóját egy hívásban
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Beállítja a második oszlop celláinak függőleges szöveg típusát
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Mentse a prezentációt a lemezre
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Táblázat stílus tulajdonságok lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy táblázat stílus tulajdonságait, hogy azokat egy másik táblázathoz vagy máshová felhasználhassa. Ez a C# kód bemutatja, hogyan kaphatók meg a stílus tulajdonságok egy táblázat előre beállított stílusából: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // módosítja az alapértelmezett stílus előre beállított témát
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Alkalmazhatok PowerPoint témákat/stílusokat egy már létrehozott táblázatra?**

Igen. A táblázat örökli a dia/ablak/mester téma beállításait, és továbbra is felülbírálhatja a kitöltéseket, szegélyeket és a szövegszíneket ezen a témán.

**Rendezhetem a táblázat sorait, mint az Excelben?**

Nem, az Aspose.Slides táblázatoknak nincs beépített rendezése vagy szűrése. Először rendezd a data‑t a memóriában, majd töltsd fel a táblázat sorait a kívánt sorrendben.

**Lehetnek csíkos (sávos) oszlopok, miközben egyedi színeket tartok meg bizonyos cellákban?**

Igen. Kapcsold be a csíkos oszlopokat, majd felülbírálhatod a konkrét cellákat helyi formázással; a cellaszintű formázás elsőbbséget élvez a táblázat stílusával szemben.