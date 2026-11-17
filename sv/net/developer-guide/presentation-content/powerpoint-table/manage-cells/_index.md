---
title: Hantera tabellceller i presentationer i .NET
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/net/manage-cells/
keywords:
- tabellcell
- slå ihop celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i C#: identifiera sammanslagna celler, ta bort ramar, dela celler och ange bakgrundsfärger och bilder med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides låter dig komma åt och ändra tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformatering genom cellegenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordningen `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Det itererar sedan genom alla rader och kolumner och använder [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) för att identifiera celler i sammanslagna områden. För varje matchning skriver det ut cellkoordinaterna i ordningen `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), och områdets startkoordinater, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) och [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Ta bort tabellcellramar**

Skapa en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och lägg till en tabell på dess första bild med [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Kolumnbredder, radhöjder och tabellposition anges i punkter. Exemplet sätter alla fyra cellramar till [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), vilket gör dem osynliga.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Lägg till diagonala cellramar**

Använd [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) för att rita en linje från det övre vänstra hörnet till det nedre högra, och [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) för att rita en linje från det nedre vänstra hörnet till det övre högra. En diagonal kan markera ett hörn rubrik; båda diagonalerna kan bilda ett X för att markera att en cell inte är tillämplig.

Varje diagonal är ett [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). I dess [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/), sätt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) till [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) och välj en [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Sätt linjens [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) i punkter.

Exemplet skapar tre celler i en rad: en röd diagonal nedåt, en blå diagonal uppåt och båda diagonalerna. Det lämnar de övre, nedre, vänstra och högra cellramarna oförändrade.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

En diagonal är en formateringsegenskap, inte en celluppdelning. Varje cell behåller en enda [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); områdena på vardera sidan av en diagonal kan inte redigeras separat.

Den sparade tabellen, renderad i Microsoft PowerPoint:

![Tre tabellceller som visar en röd diagonal från övre vänstra till nedre högra, en blå diagonal från nedre vänstra till övre högra, och båda diagonalerna bildar ett X.](diagonal-cell-borders.png)

*Från vänster till höger: diagonal nedåt (röd, 3 pt), diagonal uppåt (blå, 5 pt), och båda diagonalerna.*

## **Slå ihop tabellceller**

Använd [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) för att kombinera ett rektangulärt område av tabellceller till en enda cell. Specificera cellerna i det övre vänstra och nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får inkludera celler utanför det angivna området; `false` håller sammanslagningen inom det området.

Exemplet skapar en 4‑x‑4‑tabell med 70‑punkts kolumner och rader, och slår sedan ihop de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen spänner över två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller formatering, använd dess övre vänstra position: `table[1, 1]` i detta exempel. De övriga positionerna i det sammanslagna området förblir en del av tabellrutnätet, så indexen för celler utanför området ändras inte.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Dela tabellceller**

Att slå ihop celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan införa en ny rutnätskolumn och ändra kolumnindex för celler till höger om den. Aspose.Slides följer PowerPoints tabellrutnätsmodell.

Detta exempel skapar en 4‑x‑4‑tabell med 70‑punkts kolumner och rader och anropar [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) på cell `(1, 1)`. Hälften av cellens 70‑punkts bredd används för att skapa två celler med lika bredd.

Efter denna delning nås de två halvorna som `table[1, 1]` och `table[2, 1]`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen var i kolumnerna 2 och 3 flyttas till kolumnerna 3 respektive 4. Radrubriker förblir oförändrade. Använd dessa uppdaterade kolumnindex när du får åtkomst till celler efter delningen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Dela sammanslagna celler efter rad- eller kolumnspann**

För att förbereda sammanslagna mallceller för datainmatning, använd [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) för att dela längs en befintlig radgräns, eller [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) för att dela längs en kolumngräns.

`index`‑argumentet räknar rader i den övre delen eller kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Kolumndelning: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Med start från den nedre positionen använder det [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) och [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) för att lokalisera ursprunget och kontrollerar båda spannarna. `SplitByRowSpan(1)` separerar sedan raderna 2 och 3 för produktnamn. För en horisontell sammanslagning av två kolumner, använd `SplitByColSpan(1)` istället.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Hämta de resulterande cellerna från tabellen efter delning.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Tabellrutnätet och omkringliggande cellindex förblir oförändrade. Hämta de resulterande cellerna efter deras koordinater; här har båda ett spann på 1 och [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) skriver ut `False`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering kvarstår i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformatering som fyllning, ramar och marginaler. Fyll i cellerna efter delning och ange eventuell nödvändig textformatering explicit.

Den sparade presentationen innehåller separata celler för "Product A" och "Product B" med mallens cellformatering bevarad. Se [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) för detaljer.

<!-- visual-explanation:manage-cells:start -->
[![Den sammanslagna cellen i kolumn 1, raderna 2 och 3 delas upp i Product A och Product B med samma rutnätsindex.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Radspänningsdelningen använder den befintliga gränsen. Product A och Product B upptar (1, 2) respektive (1, 3).*
<!-- visual-explanation:manage-cells:end -->

### **Dela en cell på en specifik höjd**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) tar höjden av den övre delen i punkter. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) tar antalet befintliga rutnätsrader i den övre delen. För att centrera en 40‑punkts cell i den högra kolumnen, dra bort 40 från cellens faktiska höjd och dela det återstående utrymmet lika mycket ovan och under den.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Den första delningen lägger till en rutnätsrad, vilket lämnar de nedre 90 punkterna på `[1, 1]`. Den andra delningen riktar sig mot den cellen och lägger till ytterligare en rad under den. Den högra kolumnen innehåller nu `[1, 0]` på 50 punkter (`margin`), `[1, 1]` på 40 punkter och `[1, 2]` på 50 punkter (`margin`). Den vänstra cellen sträcker sig över alla tre rader med sin ursprungliga höjd på 140 punkter.

![Den vänstra cellen sträcker sig över hela tabellens höjd bredvid tre celler med Mitt i mitten.](split-by-height.png)

## **Ändra bakgrundsfärgen på tabellcellen**

Detta exempel skapar en tabell med 150‑punkts kolumner och 50‑punkts rader. Det sätter [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) till solid och [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) till röd för cell `(2, 3)`, i den tredje kolumnen och fjärde raden.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Lägg till en bild i en tabellcell**

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Den laddar bilden med [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) och lägger till den i presentationens bildsamling med [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Den tilldelar sedan bilden till bildfyllningen av cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) sträcker bilden för att fylla cellen, vilket kan ändra bildförhållandet. Kolumnbredder och radhöjder är i punkter. Den inlästa bilden frigörs automatiskt av dess using‑deklaration.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

**Kan jag ange olika linjetjocklekar och -stilar för olika sidor av en enskild cell?**

Ja. De [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/)‑ramarna har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig.

**Vad händer med bilden om jag ändrar kolumn-/radstorleken efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Vid stretching anpassas bilden till den nya cellen; vid tiling beräknas rutorna om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/net/manage-hyperlinks/) sätts på text‑ (del‑)nivå inne i cellens textram eller på hela tabellens/figurens nivå. I praktiken tilldelar du länken till en del eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enda cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (run) med oberoende formatering — teckensnittsfamilj, stil, storlek och färg.