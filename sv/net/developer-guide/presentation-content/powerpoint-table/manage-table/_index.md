---
title: Hantera presentationstabeller i .NET
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/net/manage-table/
keywords:
- lägg till tabell
- skapa tabell
- åtkomst till tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för .NET. Upptäck enkla C#-kodexempel för att effektivisera ditt tabell-arbetsflöde."
---
## **Introduktion**

Tabeller i PowerPoint organiserar information i rader och kolumner, vilket gör det enklare att läsa och jämföra värden.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/net/aspose.slides/table/), gränssnittet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), klassen [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/), gränssnittet [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) och andra typer för att låta dig skapa, uppdatera och hantera tabeller i presentationer.

## **Skapa en tabell från grunden**

Skapa en tabell genom att ange dess position, kolumnbredder och radhöjder. Efter att ha lagt till den på en bild kan du formatera cellkanter, slå ihop celler och infoga text.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Definiera en array med kolumnbredder i punkter.
4. Definiera en array med radhöjder i punkter.
5. Lägg till ett [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) objekt på bilden via metoden [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
6. Iterera igenom varje [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) för att tillämpa formatering på de övre, nedre, högra och vänstra kanterna.
7. Sammanfoga de två första cellerna i tabellens första rad.
8. Få åtkomst till den sammanslagna cellen via dess [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) egenskap.
9. Ställ in texten i den sammanslagna cellen.
10. Spara den ändrade presentationen.

Exemplet nedan skapar en tabell med tre kolumner och fem rader vid (100, 50) punkter. Den applicerar röda kanter med en bredd på 5 punkter, sammanslår de två första cellerna i den första raden och sparar resultatet som `table.pptx`.

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

## **Numrering i en standardtabell**

I en standardtabell är cellindex nollbaserade och använder ordningen (kolumn, rad). Den första cellen har index (0, 0).

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på detta sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Detta exempel skapar 4 × 4‑tabellen som illustreras ovan, med kolumnbredder och radhöjder på 70 punkter samt röda cellkanter med en bredd på 5 punkter. Koordinaterna illustrerar cellindex; exemplet lämnar cellerna tomma och sparar tabellen som `StandardTables_out.pptx`.

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

## **Åtkomst till en befintlig tabell**

Tabeller lagras i en bilds shape‑samling. Iterera genom formerna för att hitta en tabell och använd sedan [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑gränssnittet för att läsa eller uppdatera dess celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen med dess index.
3. Iterera genom objekten [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) och stoppa när en tabell hittas. Om bilden innehåller flera tabeller, använd [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) för att identifiera den du behöver.
4. Uppdatera texten i målcellens.
5. Spara den ändrade presentationen.

Exemplet nedan öppnar `UpdateExistingTable.pptx` och hittar den första tabellen på den första bilden. Det sätter cellen i kolumn 0, rad 1 till `New` och sparar resultatet som `table1_out.pptx`. Inmatningen måste innehålla minst en bild, och den första tabellen på den bilden måste ha minst en kolumn och två rader.

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

För att ändra storlek på en rad i en befintlig tabell och förstå varför dess faktiska höjd kan överstiga den begärda minimin, se [Control Row Height](/slides/sv/net/manage-rows-and-columns/#control-row-height).

## **Hitta cellen som äger en TextFrame**

När generisk textbehandlingskod tar emot en [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) från en tabell, använd egenskapen [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) för att hämta den ägande [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/). För ett tabell‑cell‑textframe är [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) satt och [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) är `null`, även om tabellen själv är en shape.

Cellkoordinaterna är tillgängliga via de skrivskyddade egenskaperna [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) och [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) är också skrivskyddad: den ger navigering till ägaren men ändrar inte ägarskapet. Kontrollera alltid om den returnerade cellen är `null` innan du använder den.

För ett komplett exempel som identifierar tabell‑cell‑ och shape‑ägare, inklusive former som är associerade med SmartArt‑noder, se [Search and Replace Text](/slides/sv/net/search-and-replace-text/).

## **Justera text i en tabell**

Du kan styra vertikal förankring och textriktning för enskilda tabellceller. Exemplet i detta avsnitt centrerar text i den första cellen och roterar den 270 grader.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Lägg till ett [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) objekt på bilden.
4. Få åtkomst till ett [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) objekt från tabellen.
5. Få åtkomst till den första [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) och ange dess text och färg.
6. Ställ in cellens [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) och [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/).
7. Spara den ändrade presentationen.

Detta exempel skapar en 4 × 4‑tabell med kolumnbredder på 120 punkter och radhöjder på 100 punkter. Det formaterar texten i cell (0, 0), lägger till värden i de återstående cellerna i den första raden och sparar resultatet som `Vertical_Align_Text_out.pptx`.

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

## **Ställ in textformatering på tabellnivå**

Använd [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) för att tillämpa textformatering på alla celler i en tabell. Dess överlagringar accepterar formatering för portion, stycke och textframe, så du kan ange dessa egenskaper utan att iterera genom enskilda celler.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Hämta en referens till bilden med dess index.
3. Få åtkomst till ett [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) objekt från bilden.
4. Ställ in [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) för texten.
5. Ställ in [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) och [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Ställ in [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Spara den ändrade presentationen.

Exemplet nedan öppnar `table.pptx`, som måste innehålla minst en bild med en tabell som sin första shape. Det ställer in teckenstorleken till 25 punkter, högerjusterar stycken med en högermarginal på 20 punkter och gör texten vertikal. Den formaterade presentationen sparas som `result.pptx`.

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

## **Hämta tabellstils­egenskaper**

Använd [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) för att läsa eller tilldela en tabells förinställda stil. Detta exempel applicerar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) på en tabell, skriver ut förinställningsnamnet och tilldelar samma förinställning till en andra tabell. Båda tabellerna sparas i `table-style.pptx`.

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

## **Låsa bildförhållandet för en tabell**

En tabells bildförhållande är förhållandet mellan dess bredd och höjd. Använd [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) för att låsa detta förhållande för en tabell.

Exemplet nedan öppnar `pres.pptx`, som måste innehålla minst en bild med en tabell som sin första shape. Det skriver ut det aktuella låstillståndet, aktiverar låsning av bildförhållandet, skriver ut det uppdaterade tillståndet (`True`) och sparar resultatet som `pres-out.pptx`.

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

## **FAQ**

**Kan jag aktivera läsriktning från höger till vänster (RTL) för en hel tabell och texten i dess celler?**

Ja. Tabellen har en egenskap [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) och stycken har [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutliga filen?**

Använd [shape locks](/slides/sv/net/applying-protection-to-presentation/) för att inaktivera flyttning, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt det valda läget (stretch eller tile).