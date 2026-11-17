---
title: Beheer tabelcellen in presentaties in .NET
linktitle: Cellen beheren
type: docs
weight: 30
url: /nl/net/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer PowerPoint-tabelcellen in C#: identificeer samengevoegde cellen, verwijder randen, split cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie kunt maken of openen, een tabel van een dia kunt ophalen, de celopmaak via cel‑eigenschappen kunt bijwerken en de gewijzigde presentatie opslaan als een PPTX‑bestand.

Aspose.Slides gebruikt nul‑gebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Identificeer een samengevoegde tabelcel**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens wordt door alle rijen en kolommen gelopen en wordt [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) gebruikt om cellen in samengevoegde regio's te identificeren. Voor elke overeenkomst drukt het de celcoördinaten af in `row;column`‑volgorde, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), en de begincoördinaten van de regio, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) en [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

## **Verwijder tabelcelranden**

Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) aan en voeg een tabel toe aan de eerste dia met [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). De kolombreedtes, rijhoogtes en de positie van de tabel worden opgegeven in punten. Het voorbeeld stelt alle vier de celranden in op [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), waardoor ze onzichtbaar worden.

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

## **Voeg diagonale celranden toe**

Gebruik [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/) om een lijn te tekenen van de linkerbovenhoek naar de rechteronderhoek, en [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/) om een lijn te tekenen van de linksonderhoek naar de rechterbovenhoek. Een diagonale lijn kan een hoekkop markeren; beide diagonalen kunnen een X vormen om een cel als niet‑toepasbaar te markeren.

Elke diagonale is een [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). In de bijbehorende [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) stelt u [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) in op [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) en kiest u een [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Stel de [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) van de lijn in punten in.

Het voorbeeld maakt drie cellen in één rij: een rode neerwaartse diagonale lijn, een blauwe opwaartse diagonale lijn en beide diagonalen. Het laat de boven‑, onder‑, linker‑ en rechtercelranden ongewijzigd.

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

Een diagonale lijn is een opmaak‑eigenschap, geen cel‑splitsing. Elke cel behoudt één enkel [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); de gebieden aan beide zijden van een diagonale lijn kunnen niet onafhankelijk worden bewerkt.

De opgeslagen tabel, gerenderd in Microsoft PowerPoint:

![Drie tabelcellen met een rode diagonale lijn van links‑boven naar rechts‑onder, een blauwe diagonale lijn van links‑onder naar rechts‑boven, en beide diagonalen die een X vormen.](diagonal-cell-borders.png)

*Van links naar rechts: neerwaartse diagonale lijn (rood, 3 pt), opwaartse diagonale lijn (blauw, 5 pt), en beide diagonalen.*

## **Samenvoegen van tabelcellen**

Gebruik [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Geef de cellen op de linkerboven‑ en rechteronderhoek van het bereik op. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `false` behoudt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten, en voegt vervolgens de vier centrale cellen samen van `(1, 1)` tot en met `(2, 2)`. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruikt u de linkerboven‑positie: `table[1, 1]` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabellengrid, zodat de indexen van cellen buiten het bereik niet veranderen.

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

## **Splitsen van tabelcellen**

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolom‑indexen van cellen rechts daarvan wijzigen. Aspose.Slides volgt het tabelraster‑model van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punten en roept [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) aan op cel `(1, 1)`. De helft van de 70 punten brede cel wordt gebruikt om twee cellen met gelijke breedte te creëren.

Na deze splitsing worden de twee helften benaderd als `table[1, 1]` en `table[2, 1]`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolom 2 en 3 stonden, verplaatsen zich naar respectievelijk kolom 3 en 4. Rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolom‑indexen bij het benaderen van cellen na de splitsing.

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

### **Splits samengevoegde cellen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensvulling voor te bereiden, gebruikt u [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) om langs een bestaande rijgrens te splitsen, of [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) om langs een kolomgrens te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linker deel van de splitsing; het is relatief ten opzichte van de samengevoegde regio:

- Row split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Column split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Het voorbeeld gaat ervan uit dat een presentatie een tabel heeft als de eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Beginnend vanuit de lagere positie, gebruikt het [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) en [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) om de oorsprong te lokaliseren en controleert beide spans. `SplitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale tweekolomsamenvoeging gebruikt u in plaats daarvan `SplitByColSpan(1)`.

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

    // Haal de resulterende cellen op uit de tabel na het splitsen.
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

Het tabelraster en de omliggende cel‑indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide spans van 1 en [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) geeft `False` weer. Grotere regio's kunnen na één splitsing gedeeltelijk samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven in de bovenste (of linker) cel; de nieuwe cel is leeg maar erft de celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat afzonderlijke "Product A"- en "Product B"-cellen waarbij de celopmaak van het sjabloon behouden blijft. Zie de [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) voor details.

<!-- visual-explanation:manage-cells:start -->
[![De samengevoegde cel in kolom 1, rijen 2 en 3 splitst in Product A en Product B met dezelfde raster‑indexen.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*De rij‑span splitsing gebruikt de bestaande grens. Product A en Product B bezetten respectievelijk (1, 2) en (1, 3).*
<!-- visual-explanation:manage-cells:end -->

### **Splits een cel op een specifieke hoogte**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) neemt de hoogte van het bovenste deel in punten. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) neemt het aantal bestaande rasterrijen in het bovenste deel. Om een cel van 40 punten te centreren in de rechter kolom, trekt u 40 af van de werkelijke hoogte van de cel en deelt u de resterende ruimte gelijkmatig boven en onder.

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

De eerste splitsing voegt een rasterrij toe, waardoor de onderste 90 punten bij `[1, 1]` blijven. De tweede splitsing richt zich op die cel en voegt een extra rij eronder toe. De rechterkolom bevat nu `[1, 0]` op 50 punten (`margin`), `[1, 1]` op 40 punten en `[1, 2]` op 50 punten (`margin`). De linkercel beslaat alle drie de rijen met haar oorspronkelijke hoogte van 140 punten.

![De linkercel beslaat de volledige tabelhoogte naast drie cellen met Midden in het midden.](split-by-height.png)

## **Wijzig de achtergrondkleur van de tabelcel**

Dit voorbeeld maakt een tabel met kolommen van 150 punten en rijen van 50 punten. Het stelt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) in op solid en [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

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

## **Voeg een afbeelding toe in een tabelcel**

Plaats de invoerafbeelding in de werkmap voordat u dit voorbeeld uitvoert. Het laadt de afbeelding met [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) en voegt deze toe aan de afbeeldingscollectie van de presentatie met [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Vervolgens wijst het de afbeelding toe aan de afbeelding‑vulling van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) rekent de afbeelding uit om de cel te vullen, wat de beeldverhouding kan wijzigen. Kolombreedtes en rijhoogtes worden opgegeven in punten. De geladen afbeelding wordt automatisch vrijgegeven door de using‑declaratie.

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

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende kanten van één cel?**

Ja. De [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Bij stretching past de afbeelding zich aan de nieuwe cel aan; bij tiling worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/net/manage-hyperlinks/) worden ingesteld op het tekst‑(portion)‑niveau binnen het tekstframe van de cel of op het niveau van de volledige tabel/vorm. In de praktijk kent u de link toe aan een gedeelte of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) met onafhankelijke opmaak — lettertypefamilie, stijl, grootte en kleur.