---
title: PowerPoint táblázatok kezelése .NET-ben
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/net/manage-table/
keywords:
- tábla hozzáadása
- tábla létrehozása
- tábla elérése
- méretarány
- szöveg igazítása
- szövegformázás
- tábla stílus
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Hozzon létre és szerkesszen táblázatokat PowerPoint diákon az Aspose.Slides for .NET segítségével. Fedezzen fel egyszerű C# kódrészleteket, amelyek egyszerűsítik a táblázati munkafolyamatokat."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információ megjelenítésének és ábrázolásának. A cellák rácsában (sorokba és oszlopokba rendezve) lévő információ egyértelmű és könnyen érthető.

Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/net/aspose.slides/table/) osztályt, a [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) interfészt, a [Cell](https://reference.aspose.com/slides/hu/net/aspose.slides/cell/) osztályt, a [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/) interfészt, és más típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését mindenféle bemutatóban.

## **Táblázat létrehozása alapból**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Határozzon meg egy `columnWidth` tömböt.  
4. Határozzon meg egy `rowHeight` tömböt.  
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diára a [AddTable](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addtable/) metódussal.  
6. Iteráljon minden [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/) elemen, hogy formázást alkalmazzon a felső, alsó, jobb és bal szegélyekre.  
7. Egyesítse a táblázat első sorának első két celláját.  
8. Érje el egy [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/).  
9. Adjon hozzá szöveget a [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/)-hez.  
10. Mentse a módosított bemutatót.

Ez a C# kód bemutatja, hogyan hozhat létre táblázatot egy bemutatóban:

```c#
// Létrehozza a PPTX fájlt képviselő Presentation osztály példányát
Presentation pres = new Presentation();

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Adds a table shape to the slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Sets the border format for each cell
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Összevonja az 1. sor 1. és 2. celláit
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Szöveget ad a összevont cellához
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Elmenti a prezentációt a lemezre
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cellák számozása egyszerű és nullától indul. Az első cella indexe 0,0 (oszlop 0, sor 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a C# kód megmutatja, hogyan adható meg a cellák számozása egy táblázatban:

```c#
// Létrehozza a PPTX fájlt képviselő Presentation osztályt
using (Presentation pres = new Presentation())
{
    // Eléri az első diát
    ISlide sld = pres.Slides[0];

    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad a diához
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

    // A prezentáció mentése a lemezre
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Létező táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  

2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexe alapján.  

3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot, és állítsa null-ra.  

4. Iteráljon minden [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) objektumon, amíg a táblázat megtalálható.

   Ha úgy véli, hogy a diához csak egy táblázat tartozik, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Amikor egy alakzatot táblázatként azonosítanak, típuskonverzióval [Table](https://reference.aspose.com/slides/hu/net/aspose.slides/table/) objektummá alakítható. Ha azonban a diához több táblázat is tartozik, akkor célszerűbb az [AlternativeText](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/alternativetext/) segítségével megtalálni a kívánt táblázatot.  

5. Használja a [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a táblázattal való munkához. Az alábbi példában egy új sort adtunk a táblázathoz.  

6. Mentse a módosított bemutatót.

Ez a C# kód megmutatja, hogyan érheti el és dolgozhat egy létező táblázattal:

```c#
// Létrehozza a PPTX fájlt képviselő Presentation osztályt
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{
    // Eléri az első diát
    ISlide sld = pres.Slides[0];

    // Null TableEx-et inicializál
    ITable tbl = null;

    // Végigiterál a formákon és beállítja a megtalált táblázatra mutató hivatkozást
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Beállítja a szöveget a második sor első oszlopához
    tbl[0, 1].TextFrame.Text = "New";

    // Elmenti a módosított prezentációt a lemezre
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Szöveg igazítása egy táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diára.  
4. Érje el a táblázatból egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumot.  
5. Érje el a [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) elemet.  
6. Igazítsa függőlegesen a szöveget.  
7. Mentse a módosított bemutatót.

Ez a C# kód megmutatja, hogyan igazítható a szöveg egy táblázatban:

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Szövegformázás beállítása táblaszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Szerezze be a dia hivatkozását az indexe alapján.  
3. Érje el a [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diámból.  
4. [FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontheight/) beállítása a szöveghez.  
5. [Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) és [MarginRight](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginright/) beállítása.  
6. [TextVerticalType](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/textverticaltype/) beállítása.  
7. Mentse a módosított bemutatót.  

Ez a C# kód megmutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázat szövegére:

```c#
// Létrehozza a Presentation osztály egy példányát
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Tegyük fel, hogy az első dia első alakzata egy táblázat

// Sets the table cells' font height
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Sets the table cells' text alignment and right margin in one call
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Sets the table cells' text vertical type
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Táblázat stílustulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a táblázat stílustulajdonságainak lekérését, hogy ezeket a részleteket egy másik táblázathoz vagy más helyen felhasználhassa. Ez a C# kód megmutatja, hogyan kaphatók meg a stílustulajdonságok egy táblázat előre beállított stílusából:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // módosítja az alapértelmezett stílus előre beállított témát
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Táblázat méretarányának zárolása**

A geometriai alakzat méretaránya a különböző dimenziók méretének aránya. Az Aspose.Slides a `AspectRatioLocked` tulajdonságot biztosítja, amely lehetővé teszi a táblázatok és egyéb alakzatok méretarány-beállításának zárolását.

Ez a C# kód bemutatja, hogyan zárolható a méretarány egy táblázat esetén:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // megfordítja

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy teljes táblázat és annak celláinak szövege számára?**  
Igen. A táblázat rendelkezik egy [RightToLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/table/righttoleft/) tulajdonsággal, a bekezdések pedig [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphformat/righttoleft/) tulajdonsággal. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákban.

**Hogyan akadályozhatom meg, hogy a felhasználók a végleges fájlban áthelyezzék vagy átméretezzék a táblázatot?**  
Használja a [shape locks](/slides/hu/net/applying-protection-to-presentation/) lehetőséget a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép cellába háttérként való beszúrása?**  
Igen. Beállíthat egy [picture fill](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/) kitöltést egy cellához; a kép a kiválasztott mód (nyújtás vagy csempe) szerint lefedi a cella területét.