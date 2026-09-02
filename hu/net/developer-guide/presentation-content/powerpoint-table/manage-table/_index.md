---
title: Prezentáció táblázatok kezelése .NET-ben
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/net/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázat elérése
- méretarány
- szöveg igazítása
- szövegformázás
- táblázat stílusa
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint diákon az Aspose.Slides for .NET segítségével. Fedezzen fel egyszerű C# kódpéldákat, amelyek áramvonalasítják a táblázatfolyamatokat."
---
## **Bevezetés**

A PowerPoint táblázat hatékony módja az információk megjelenítésének és ábrázolásának. A cellák rácsában (sorokba és oszlopokba rendezve) lévő információ egyértelmű és könnyen érthető.

Az Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/hu/net/aspose.slides/table/) osztályt, az [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) interfészt, a [Cell](https://reference.aspose.com/slides/hu/net/aspose.slides/cell/) osztályt, az [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/) interfészt és egyéb típusokat, amelyek lehetővé teszik táblázatok létrehozását, frissítését és kezelését a különféle bemutatókban.

## **Táblázat létrehozása az alapoktól**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Definiáljon egy `columnWidth` tömböt.  
4. Definiáljon egy `rowHeight` tömböt.  
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diára a [AddTable](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addtable/) metódussal.  
6. Iteráljon végig minden [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/) elemen, hogy a felső, alsó, jobb és bal szegélyek formázását alkalmazza.  
7. Egyesítse a táblázat első sorának első két celláját.  
8. Hozzon hozzáférést egy [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) elemhez.  
9. Adjon szöveget a [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/) objektumhoz.  
10. Mentse el a módosított prezentációt.

Ez a C# kód bemutatja, hogyan hozhat létre táblázatot egy prezentációban:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
Presentation pres = new Presentation();

// Eléri az első diát
ISlide sld = pres.Slides[0];

// Meghatározza az oszlopok szélességét és a sorok magasságát
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Táblázat alakzatot ad a diához
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Beállítja a szegély formátumát minden cellához
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
// Egyesíti a 1. sor 1. és 2. celláit
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Szöveget ad a egyesített cellához
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

Ez a C# kód létrehozza a fenti 4 × 4-es szabványos táblázatot, és beállítja minden cella szegélyformátumát:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation())
{

    // Eléri az első diát
    ISlide sld = pres.Slides[0];

    // Meghatározza az oszlopok szélességét és a sorok magasságát
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Táblázat alakzatot ad a diára
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

    // Elmenti a prezentációt a lemezre
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Meglévő táblázat elérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  

2. Szerezze meg a táblázatot tartalmazó dia hivatkozását az indexe alapján.  

3. Hozzon létre egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot, és állítsa null értékre.  

4. Iteráljon végig az összes [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) objektumon, amíg meg nem találja a táblázatot.  

   Ha úgy gondolja, hogy a dia csak egyetlen táblázatot tartalmaz, egyszerűen ellenőrizheti az összes benne lévő alakzatot. Ha egy alakzat táblázatként van azonosítva, átkonvertálhatja egy [Table](https://reference.aspose.com/slides/hu/net/aspose.slides/table/) objektummá. Ha a dián több táblázat is van, célszerű a keresett táblázatot az [AlternativeText](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/alternativetext/) alapján megtalálni.  

5. Használja az [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a táblázattal való munkához. Az alábbi példában egy új sort adtunk hozzá a táblázathoz.  

6. Mentse el a módosított prezentációt.

Ez a C# kód bemutatja, hogyan érhet el és dolgozhat egy meglévő táblázattal:

```c#
using Aspose.Slides;

// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Eléri az első diát
    ISlide sld = pres.Slides[0];

    // Inicializálja a null TableEx változót
    ITable tbl = null;

    // Végigiterál az alakzatokon és beállít egy hivatkozást a megtalált táblázatra
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Beállítja a szöveget a második sor első oszlopában
    tbl[0, 1].TextFrame.Text = "New";

    // Elmenti a módosított prezentációt a lemezre
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **A szövegkeretet tartalmazó cella megtalálása**

Amikor általános szövegfeldolgozó kód egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumot kap egy táblázatból, használja az [ITextFrame.ParentCell](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentcell/) tulajdonságot a tulajdonos [ICell](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/) lekéréséhez. Egy táblázatcella szövegkeretéhez az [ITextFrame.ParentCell](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentcell/) be van állítva, míg az [ITextFrame.ParentShape](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentshape/) `null`, annak ellenére, hogy maga a táblázat is egy alakzat.

A cella koordinátái a csak‑olvasható [ICell.FirstColumnIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/firstcolumnindex/) és [ICell.FirstRowIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/firstrowindex/) tulajdonságokból érhetők el. Az [ITextFrame.ParentCell](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentcell/) szintén csak‑olvasható: navigációt biztosít a tulajdonos felé, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze, hogy a visszaadott cella nem `null`, mielőtt felhasználná.

A táblázat‑cella és alakzat‑tulajdonosok azonosítását, valamint a SmartArt‑csomópontokhoz társított alakzatokat bemutató teljes példáért tekintse meg a [Search and Replace Text](/slides/hu/net/search-and-replace-text/) oldalt.

## **Szöveg igazítása egy táblázatban**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diához.  
4. Szerezze meg egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumot a táblázatból.  
5. Hozzon hozzáférést az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) elemhez.  
6. Igazítsa a szöveget függőlegesen.  
7. Mentse el a módosított prezentációt.

Ez a C# kód bemutatja, hogyan igazítható a szöveg egy táblázatban:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Létrehoz egy Presentation osztály példányt
Presentation presentation = new Presentation();

// Lekéri az első diát
ISlide slide = presentation.Slides[0];

// Meghatározza az oszlopok szélességét és a sorok magasságát
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Táblázat alakzatot ad a diához
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Eléri a szövegkeretet
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Létrehozza a bekezdés objektumot a szövegkerethez
IParagraph paragraph = txtFrame.Paragraphs[0];

// Létrehozza a szakasz objektumot a bekezdéshez
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Függőlegesen igazítja a szöveget
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Mentse el a prezentációt a lemezre
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Szövegformázás beállítása táblázatszinten**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia hivatkozását az indexe alapján.  
3. Hozzon hozzá egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektumot a diáról.  
4. Állítsa be a szöveg [FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/baseportionformat/fontheight/) értékét.  
5. Állítsa be az [Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) és a [MarginRight](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/marginright/) tulajdonságokat.  
6. Állítsa be a [TextVerticalType](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/textverticaltype/) értékét.  
7. Mentse el a módosított prezentációt.

Ez a C# kód bemutatja, hogyan alkalmazhatja a kívánt formázási beállításokat a táblázat szövegére:

```c#
using Aspose.Slides;

// Létrehoz egy Presentation osztály példányt
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Tegyük fel, hogy az első dia első alakzata egy táblázat

// Beállítja a táblázat celláinak betűmagasságát
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Beállítja a táblázat celláinak szövegigazítását és a jobb margót egy hívásban
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Beállítja a táblázat celláinak szöveg függőleges típusát
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Táblázat stílus tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a táblázat stílus tulajdonságainak lekérését, hogy ezeket a részleteket másik táblázathoz vagy más helyen felhasználhassa. Ez a C# kód bemutatja, hogyan kérhető le a stílus tulajdonság egy táblázat előre definiált stílusából:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // módosítja az alapértelmezett stíluspreset témát 

    // Lekéri a táblázat stíluspresetjét.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Alkalmazza a lekért stíluspresetet egy másik táblázatra.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Táblázat méretarányának rögzítése**

A geometriai alakzat méretarányát a különböző dimenziók méreteinek aránya határozza meg. Az Aspose.Slides a `AspectRatioLocked` tulajdonságot biztosítja, amely lehetővé teszi a táblázatok és egyéb alakzatok méretarány‑zárásának beállítását.

Ez a C# kód megmutatja, hogyan rögzíthető a méretarány egy táblázat esetén:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // fordítja meg

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt az egész táblázat és a celláinak szövege számára?**

Igen. A táblázat rendelkezik egy [RightToLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/table/righttoleft/) tulajdonsággal, a bekezdések pedig a [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraphformat/righttoleft/) beállítással rendelkeznek. A kettő együttes használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók a végleges fájlban áthelyezzék vagy átméretezzék a táblázatot?**

Használja az [alakzati zárolások](/slides/hu/net/applying-protection-to-presentation/) funkciót a mozgatás, átméretezés, kijelölés stb. letiltásához. Ezek a zárolások a táblázatokra is érvényesek.

**Támogatott-e egy kép beillesztése a cella háttérként?**

Igen. Beállíthat egy [képkitöltést](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/) a cellához; a kép a kiválasztott mód (nyújtás vagy csempe) szerint fedi le a cella területét.