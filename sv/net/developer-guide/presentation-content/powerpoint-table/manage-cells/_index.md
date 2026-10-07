---
title: Hantera tabellceller i presentationer i .NET
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/net/manage-cells/
keywords:
- tabellcell
- sammanfoga celler
- ta bort kant
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera PowerPoint-tabellceller i C#: identifiera sammanslagna celler, ta bort kanter, dela celler och ange bakgrundsfärger samt bilder med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides gör det möjligt att komma åt och ändra tabellceller i PowerPoint‑presentationer. Denna artikel förklarar hur du identifierar sammanslagna tabellceller, tar bort cellkanter, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformat via cellens egenskaper och sparar den ändrade presentationen som en PPTX‑fil.

Aspose.Slides använder nollbaserade index för att komma åt tabellceller i ordning `(column, row)`.

## **Identifiera en sammanslagen tabellcell**

Exemplet öppnar en befintlig presentation och får åtkomst till den första formen på den första bilden som en tabell. Det förutsätter att bilden och formen finns och att formen är en tabell. Därefter itereras alla rader och kolumner och metoden [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) används för att identifiera celler i sammanslagna områden. För varje träff skrivs cellkoordinaterna ut i ordning `row;column`, samt [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/) och regionens startkoordinater, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) och [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **Ta bort tabellcellens kanter**

Skapa en [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) och lägg till en tabell på dess första bild med [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Kolumnbredder, radhöjder och tabellens position anges i punkter. Exemplet sätter alla fyra cellkanter till [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), vilket gör dem osynliga.

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

## **Sammanfoga tabellceller**

Använd [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) för att kombinera ett rektangulärt område av tabellceller till en cell. Ange cellerna i det övre vänstra respektive nedre högra hörnet av området. Det sista argumentet styr om sammanslagningen får omfatta celler utanför det angivna området; `false` begränsar sammanslagningen till det området.

Exemplet skapar en 4 × 4‑tabell med 70‑punkts kolumner och rader, och sammanslår sedan de fyra centrala cellerna från `(1, 1)` till `(2, 2)`. Den resulterande cellen spänner två kolumner och två rader, medan tabellens underliggande rutnät behåller fyra kolumner och fyra rader. För att komma åt den sammanslagna cellens innehåll eller format, använd dess övre‑vänstra position: `table[1, 1]` i detta exempel. De andra positionerna i det sammanslagna området förblir en del av tabellrutnätet, så index för celler utanför området ändras inte.

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

Sammanslagna celler i föregående exempel bevarar tabellens rutnät. Att dela en cell kan införa en ny rutnätskolumn och ändra kolumnindex för celler till höger om den. Aspose.Slides följer PowerPoints modell för tabellrutnät.

Detta exempel skapar en 4 × 4‑tabell med 70‑punkts kolumner och rader och anropar [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) på cell `(1, 1)`. Hälften av cellens 70‑punkts bredd skickas för att skapa två lika breda celler.

Efter den här delningen nås de två halvorna som `table[1, 1]` och `table[2, 1]`. Tabellrutnätet har nu fem kolumner: celler som ursprungligen låg i kolumnerna 2 och 3 flyttas till kolumnerna 3 respektive 4. Radvärden förblir oförändrad. Använd dessa uppdaterade kolumnindex när du hämtar celler efter delningen.

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

För att förbereda sammanslagna mallceller för datafyllning, använd [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) för att dela längs en befintlig radgräns, eller [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) för att dela längs en kolumngräns.

Argumentet `index` räknar rader i den övre delen respektive kolumner i den vänstra delen av delningen; det är relativt till det sammanslagna området:

- Raddelning: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Kolumndelning: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Exemplet förutsätter att en presentation har en tabell som den första formen på den första bilden, med `(1, 2)` och `(1, 3)` sammanslagna vertikalt. Från den lägre positionen används [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) och [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) för att lokalisera ursprunget och kontrollerar båda spannen. `SplitByRowSpan(1)` separerar sedan raderna 2 och 3 för produktnamn. För en horisontell två‑kolumns sammanslagning, använd `SplitByColSpan(1)` istället.

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

Tabellrutnätet och omgivande cellindex förblir oförändrade. Hämta de resulterande cellerna via deras koordinater; här har båda en spännvidd på 1 och [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) returnerar `False`. Större områden kan förbli delvis sammanslagna efter en delning.

Den ursprungliga texten och dess formatering kvarstår i den övre (eller vänstra) cellen; den nya cellen är tom men ärver cellformat såsom fyllning, kanter och marginaler. Fyll cellerna efter delning och ange eventuell önskad textformatering explicit.

Den sparade presentationen innehåller separata "Product A" och "Product B"‑celler med mallens cellformatering bevarad. Se [Cell API‑referens](https://reference.aspose.com/slides/net/aspose.slides/cell/) för detaljer.

## **Ändra bakgrundsfärgen för tabellcellen**

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

Placera inmatningsbilden i arbetskatalogen innan du kör detta exempel. Bilden laddas med [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) och läggs till i presentationens bildsamling med [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Därefter tilldelas bilden bildfyllningen för cell `(0, 0)`, den första cellen i tabellen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) sträcker bilden så att den fyller cellen, vilket kan förändra bildens bildförhållande. Kolumnbredder och radhöjder anges i punkter. Den inlästa bilden frisläpps automatiskt av sin using‑deklaration.

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

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enskild cell?**

Ja. Kanterna [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig åt.

**Vad händer med bilden om jag ändrar kolumn-/radstorlek efter att ha ställt in en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Vid stretch anpassas bilden till den nya cellen; vid tile beräknas plattorna om.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlänkar](/slides/sv/net/manage-hyperlinks/) sätts på text‑ (portion‑)nivå inom cellens textruta eller på hela tabellens/formens nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika teckensnitt i en enskild cell?**

Ja. En cells textruta stödjer [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) med oberoende formatering – teckensnittsfamilj, stil, storlek och färg.