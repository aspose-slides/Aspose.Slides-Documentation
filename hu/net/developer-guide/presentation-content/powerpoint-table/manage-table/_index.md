---
title: Táblázatok kezelése .NET-ben
linktitle: Táblázat kezelése
type: docs
weight: 10
url: /hu/net/manage-table/
keywords:
- táblázat hozzáadása
- táblázat létrehozása
- táblázat elérése
- képarány
- szöveg igazítása
- szövegformázás
- táblázat stílus
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Táblázatok létrehozása és szerkesztése PowerPoint diákon az Aspose.Slides for .NET segítségével. Fedezze fel az egyszerű C# kódrészleteket a táblázati munkafolyamatok hatékonyabbá tételéhez."
---
## **Bevezetés**

A PowerPoint táblák sorokba és oszlopokba szervezik az információkat, megkönnyítve az értékek olvasását és összehasonlítását.

Aspose.Slides biztosítja a [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) osztályt, az [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interfészt, a [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) osztályt, az [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) interfészt és egyéb típusokat, amelyek lehetővé teszik táblák létrehozását, frissítését és kezelését a prezentációkban.

## **Táblázat létrehozása az alapoktól**

Hozzon létre egy táblázatot a pozíció, az oszlopszélességek és a sormagasságok megadásával. A diára való hozzáadás után formázhatja a cellaszegélyeket, egyesítheti a cellákat, és szöveget illeszthet be.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást a diára a indexe alapján.  
3. Határozzon meg egy pontban megadott oszlopszélességek tömbjét.  
4. Határozzon meg egy pontban megadott sormagasságok tömbjét.  
5. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) objektumot a diára a [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) metódus segítségével.  
6. Iteráljon végig minden [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) elemen, hogy formázza a felső, alsó, jobb és bal szegélyeket.  
7. Olvasztja össze a táblázat első sorának első két celláját.  
8. Érje el az egyesített cellát a [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) tulajdonságán keresztül.  
9. Állítsa be a szöveget az egyesített cellában.  
10. Mentse a módosított prezentációt.

Az alábbi példa egy három oszlopos és öt soros táblázatot hoz létre (100, 50) pontban. Piros szegélyeket alkalmaz 5 pontos szélességgel, egyesíti az első sor első két celláját, és a végeredményt `table.pptx` néven menti.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Számozás egy szabványos táblázatban**

Egy szabványos táblázatban a cella indexek 0-alapúak, és (oszlop, sor) sorrendet követnek. Az első cella indexe (0, 0).

Például egy 4 oszlopos és 4 soros táblázat cellái így vannak számozva:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Ez a példa létrehozza a fent ábrázolt 4 × 4-es táblázatot, 70 pontos oszlopszélességgel és sormagassággal, valamint 5 pontos szélességű piros cellaszegélyekkel. A koordináták a cella indexeket mutatják; a példa üresen hagyja a cellákat, és a táblázatot `StandardTables_out.pptx` néven menti.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Létező táblázat elérése**

A táblázatok a dia alakzatgyűjteményében tárolódnak. Iteráljon végig az alakzatokon, hogy megtalálja a táblázatot, majd használja az [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interfészt a cellák olvasásához vagy frissítéséhez.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztály használatával.  
2. Szerezzen hivatkozást a táblázatot tartalmazó diára a indexe alapján.  
3. Iteráljon végig az [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) objektumokon, és álljon meg, amikor táblázatot talál. Ha a dián több táblázat is van, használja az [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) attribútumot a kívánt azonosításához.  
4. Frissítse a szöveget a célcellaban.  
5. Mentse a módosított prezentációt.

Az alábbi példa megnyitja a `UpdateExistingTable.pptx` fájlt, és megtalálja az első táblázatot az első dián. A 0. oszlop, 1. sor cellájában a szöveget `New`-ra állítja, és a végeredményt `table1_out.pptx` néven menti. A bemenetnek legalább egy diát kell tartalmaznia, és az első táblázatnak legalább egy oszloppal és két sorral kell rendelkeznie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Egy létező táblázat sorának átméretezéséhez és annak megértéséhez, hogy miért haladhatja meg a tényleges magasság a kért minimumot, tekintse meg a [Sor magasságának vezérlése](/slides/hu/net/manage-rows-and-columns/#control-row-height) oldalt.

## **A szövegkeretet birtokló cella megtalálása**

Amikor egy általános szövegfeldolgozó kód egy táblázatból kap egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) objektumot, használja az [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) tulajdonságot a tulajdonos [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) lekérdezéséhez. Egy táblázatcella szövegkeret esetén az [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) be van állítva, és az [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) `null`, még akkor is, ha maga a táblázat egy alakzat.

A cellakoordináták a csak olvasható [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) és [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) tulajdonságokon keresztül érhetők el. Az [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) szintén csak olvasható: navigációt biztosít a tulajdonos felé, de nem változtatja meg a tulajdonjogot. Mindig ellenőrizze, hogy a visszakapott cella `null`-e, mielőtt használja.

Egy teljes példáért, amely azonosítja a táblázatcella és alakzat tulajdonosait, beleértve a SmartArt csomópontokhoz kapcsolódó alakzatokat, tekintse meg a [Szöveg keresése és cseréje](/slides/hu/net/search-and-replace-text/) oldalt.

## **Szöveg igazítása egy táblázatban**

Egyes táblázatcellák függőleges rögzítését és szövegirányát szabályozhatja. Ebben a szakaszban szereplő példa középre helyezi a szöveget az első cellában, és 270 fokkal elforgatja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást a diára a indexe alapján.  
3. Adjon hozzá egy [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) objektumot a diára.  
4. Érjen el egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) objektumot a táblázatból.  
5. Érje el az első [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) objektumot, és állítsa be a szöveget és a színt.  
6. Állítsa be a cella [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) és [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) értékeit.  
7. Mentse a módosított prezentációt.

Ez a példa egy 4 × 4-es táblázatot hoz létre 120 pontos oszlopszélességgel és 100 pontos sormagassággal. Formázza a (0, 0) cellában lévő szöveget, hozzáad értékeket az első sor többi cellájához, és a végeredményt `Vertical_Align_Text_out.pptx` néven menti.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Szövegformázás beállítása táblázat szinten**

Használja a [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) metódust a szövegformázás alkalmazásához a táblázat minden celláján. A túlterhelései lehetővé teszik a rész, bekezdés és szövegkeret formázását, így ezek a tulajdonságok egyenkénti cellák iterálása nélkül állíthatók be.

1. Töltse be a prezentációt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztály használatával.  
2. Szerezzen hivatkozást a diára a indexe alapján.  
3. Érjen el egy [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) objektumot a diáról.  
4. Állítsa be a szöveg [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) értékét.  
5. Állítsa be az [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) és a [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) értékeket.  
6. Állítsa be a [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) értékét.  
7. Mentse a módosított prezentációt.

Az alábbi példa megnyitja a `table.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, azon a dián első alakzatként egy táblázattal. A betűméretet 25 pontra, a bekezdéseket jobbra igazítja 20 pontos jobb margóval, és a szöveget függőlegessé teszi. A formázott prezentációt `result.pptx` néven menti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Táblázat stílus tulajdonságainak lekérése**

Használja a [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) elemet a táblázat előre beállított stílusának olvasásához vagy hozzárendeléséhez. Ez a példa a [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) stílust alkalmaz egy táblázatra, kiírja az előre beállított névét, és ugyanezt a stílust a második táblázatra is hozzárendeli. Mindkét táblázat a `table-style.pptx` fájlban kerül mentésre.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Táblázat képarányának zárolása**

A táblázat képaránya a szélesség és a magasság aránya. Használja az [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) elemet a képarány zárolásához egy táblázatnál.

Az alábbi példa megnyitja a `pres.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, ahol a táblázat az első alakzat. Kiírja a jelenlegi zárolási állapotot, engedélyezi a képarány zárolását, kiírja a frissített állapotot (`True`), és a végeredményt `pres-out.pptx` néven menti.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Engedélyezhetem a jobbról balra (RTL) olvasási irányt egy teljes táblázat és celláiban lévő szöveg számára?**

Igen. A táblázat rendelkezik egy [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) tulajdonsággal, a bekezdéseknek pedig [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) beállítása van. Mindkettő használata biztosítja a helyes RTL sorrendet és megjelenítést a cellákon belül.

**Hogyan akadályozhatom meg, hogy a felhasználók mozgassák vagy átméretezzék a táblázatot a végleges fájlban?**

Használja a [alakzat zárolások](/slides/hu/net/applying-protection-to-presentation/) lehetőséget a mozgatás, átméretezés, kiválasztás stb. letiltására. Ezek a zárolások táblázatokra is vonatkoznak.

**Támogatott-e egy kép beillesztése egy cellába háttérként?**

Igen. Beállíthat egy [képkitöltés](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) kitöltést a cellához; a kép a választott mód (nyújtás vagy csempe) szerint lefedi a cella területét.