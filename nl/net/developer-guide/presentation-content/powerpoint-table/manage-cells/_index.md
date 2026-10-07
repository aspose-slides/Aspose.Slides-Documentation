---
title: Beheer tabelcellen in presentaties in .NET
linktitle: Beheer cellen
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
description: "Beheer PowerPoint-tabelcellen in C#: identificeer samengevoegde cellen, verwijder randen, splits cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides stelt u in staat tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, celopmaak bijwerkt via cel‑eigenschappen en de aangepaste presentatie opslaat als een PPTX‑bestand.

Aspose.Slides gebruikt nul‑gebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Identificeer een samengevoegde tabelcel**

De voorbeeldcode opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Er wordt verondersteld dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens wordt door alle rijen en kolommen gelopen en wordt [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) gebruikt om cellen in samengevoegde regio's te identificeren. Voor elke overeenkomst worden de celcoördinaten in de volgorde `row;column` weergegeven, evenals [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), en de begencoördinaten van de regio, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) en [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/).

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

Maak een [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) en voeg een tabel toe aan de eerste dia met [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/). Kolombreedtes, rijhoogtes en de tabelpositie worden gespecificeerd in punten. Het voorbeeld stelt alle vier de celranden in op [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), waardoor ze onzichtbaar zijn.

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

## **Samenvoegen van tabelcellen**

Gebruik [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Geef de cellen op in de linkerboven‑ en rechtsonder‑hoek van het bereik. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `false` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punt, en voegt vervolgens de vier centrale cellen samen van `(1, 1)` tot en met `(2, 2)`. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruikt u de positie links‑boven: `table[1, 1]` in dit voorbeeld. De overige posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik niet veranderen.

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

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van cellen rechts daarvan wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 punt en roept [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) aan op cel `(1, 1)`. De helft van de 70‑punt breedte van de cel wordt doorgegeven om twee even brede cellen te creëren.

Na deze splitsing worden de twee helften benaderd als `table[1, 1]` en `table[2, 1]`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verschuiven naar kolommen 3 en 4. Rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

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

### **Splitsen van samengevoegde cellen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensvulling voor te bereiden, gebruikt u [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) om langs een bestaande rij‑grens te splitsen, of [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/) om langs een kolom‑grens te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linkerdeel van de splitsing; het is relatief ten opzichte van de samengevoegde regio:

- Rijsplitsing: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Kolomsplitsing: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Het voorbeeld gaat uit van een presentatie met een tabel als de eerste vorm op de eerste dia, waarbij `(1, 2)` en `(1, 3)` verticaal zijn samengevoegd. Vanuit de onderste positie gebruikt het [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) en [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) om de oorsprong te lokaliseren en controleert beide spans. `SplitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale tweekoloms‑samenvoeging gebruikt u in plaats daarvan `SplitByColSpan(1)`.

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

    // Haal de resulterende cellen uit de tabel op na het splitsen.
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

Het tabelraster en de omliggende cel‑indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) geeft `False` weer. Grotere regio's kunnen na één splitsing deels samengevoegd blijven.

De oorspronkelijke tekst en opmaak blijven in de boven‑ (of linkse) cel; de nieuwe cel is leeg maar erft celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen handmatig en stel eventuele gewenste tekstopmaak expliciet in.

De opgeslagen presentatie bevat aparte “Product A”‑ en “Product B”‑cellen met de opmaak van de sjablooncellen behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) voor details.

## **Wijzig de achtergrondkleur van een tabelcel**

Dit voorbeeld maakt een tabel met kolommen van 150 punt en rijen van 50 punt. Het stelt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) in op solide en [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) op rood voor cel `(2, 3)`, de derde kolom en vierde rij.

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

Plaats de invoer‑afbeelding in de werkmap voordat u dit voorbeeld uitvoert. De afbeelding wordt geladen met [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) en toegevoegd aan de afbeeldingscollectie van de presentatie met [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/). Vervolgens wordt de afbeelding toegewezen aan de picture‑fill van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) rekent de afbeelding uit om de cel te vullen, waardoor de beeldverhouding kan veranderen. Kolombreedtes en rijhoogtes worden in punten opgegeven. De geladen afbeelding wordt automatisch afgevoerd door de using‑statement.

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

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één enkele cel?**

Ja. De [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) randen hebben aparte eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile). Bij uitrekken past de afbeelding zich aan de nieuwe cel aan; bij tegelvorm worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/net/manage-hyperlinks/) worden ingesteld op het tekst‑(deel)niveau binnen het tekstframe van de cel of op het niveau van de gehele tabel/vorm. In de praktijk ken je de link toe aan een deel of aan alle tekst in de cel.

**Kan ik verschillende lettertypen instellen binnen één enkele cel?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertypefamilie, stijl, grootte en kleur.