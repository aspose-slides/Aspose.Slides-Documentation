---
title: Beheer presentatietabellen in .NET
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/net/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- toegang tot tabel
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor .NET. Ontdek eenvoudige C#-code-voorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Tabellen in PowerPoint organiseren informatie in rijen en kolommen, waardoor het gemakkelijker wordt om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) klasse, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) klasse, [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) interface en andere typen om u in staat te stellen tabellen in presentaties te maken, bij te werken en te beheren.

## **Maak een tabel vanaf nul**

Maak een tabel door de positie, kolombreedtes en rijhoogtes op te geven. Nadat u deze aan een dia hebt toegevoegd, kunt u celranden opmaken, cellen samenvoegen en tekst invoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Definieer een array met kolombreedtes in points.
4. Definieer een array met rijhoogtes in points.
5. Voeg een [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object toe aan de dia via de [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) methode.
6. Loop door elke [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) om opmaak toe te passen op de boven-, onder-, rechter- en linker randen.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Toegang tot de samengevoegde cel via de [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) eigenschap.
9. Stel de tekst in de samengevoegde cel in.
10. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder maakt een tabel met drie kolommen en vijf rijen op (100, 50) points. Het past rode randen toe met een breedte van 5 points, voegt de eerste twee cellen in de eerste rij samen en slaat het resultaat op als `table.pptx`.

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

## **Nummering in een Standaardtabel**

In een standaardtabel zijn celindices nulgebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft index (0, 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de hierboven geïllustreerde 4 × 4-tabel, met kolombreedtes en rijhoogtes van 70 points en rode celranden met een breedte van 5 points. De coördinaten illustreren celindices; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

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

## **Toegang tot een bestaande tabel**

Tabellen worden opgeslagen in de vormverzameling van een dia. Loop door de vormen om een tabel te vinden, en gebruik vervolgens de [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interface om de cellen te lezen of bij te werken.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia die de tabel bevat op basis van de index.
3. Loop door de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) objecten en stop wanneer een tabel wordt gevonden. Als de dia meerdere tabellen bevat, gebruik dan [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) om de gewenste tabel te identificeren.
4. Werk de tekst in de doelcel bij.
5. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel op kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet ten minste één dia bevatten, en de eerste tabel op die dia moet ten minste één kolom en twee rijen hebben.

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

Om een rij in een bestaande tabel te wijzigen en te begrijpen waarom de werkelijke hoogte de gevraagde minimumhoogte kan overschrijden, zie [Rijhoogte beheren](/slides/nl/net/manage-rows-and-columns/#control-row-height).

## **Zoek de cel die een tekstframe bezit**

Wanneer generieke tekstverwerkingscode een [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) van een tabel ontvangt, gebruik dan de [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) eigenschap om de bijbehorende [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) op te halen. Voor een tekstframe van een tabelcel is [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) ingesteld en is [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) `null`, hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen-lezen [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) en [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) eigenschappen. [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) is ook alleen-lezen: het biedt navigatie naar de eigenaar maar verandert de eigendom niet. Controleer altijd of de geretourneerde cel `null` is voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabelcel- en vormeigenaars identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knooppunten, zie [Zoek en vervang tekst](/slides/nl/net/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

U kunt de verticale verankering en tekstoriëntatie van individuele tabelcellen besturen. Het voorbeeld in deze sectie centreert tekst in de eerste cel en roteert deze met 270 graden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Voeg een [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object toe aan de dia.
4. Toegang tot een [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) object van de tabel.
5. Toegang tot de eerste [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) en stel de tekst en kleur in.
6. Stel het [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) en [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) van de cel in.
7. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een 4 × 4-tabel met kolombreedtes van 120 points en rijhoogtes van 100 points. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de overige cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

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

## **Tekstopmaak instellen op tabelniveau**

Gebruik [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren gedeelte-, alinea- en tekstframe‑opmaak, zodat u deze eigenschappen kunt instellen zonder door individuele cellen te itereren.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) klasse.
2. Verkrijg een referentie naar de dia op basis van de index.
3. Toegang tot een [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) object van de dia.
4. Stel de [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in voor de tekst.
5. Stel de [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) en [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) in.
6. Stel de [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) in.
7. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `table.pptx`, die ten minste één dia moet bevatten met een tabel als eerste vorm. Het stelt de lettergrootte in op 25 points, rechtlijnigt alinea's met een rechtermarge van 20 points, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

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

## **Tabelstijleigenschappen ophalen**

Gebruik [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) om de vooraf ingestelde stijl van een tabel te lezen of toe te wijzen. Dit voorbeeld past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) toe op één tabel, drukt de presetnaam af, en kent dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

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

## **Vergrendel beeldverhouding van een tabel**

De beeldverhouding van een tabel is de verhouding tussen de breedte en de hoogte. Gebruik [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) om deze verhouding voor een tabel te vergrendelen.

Het voorbeeld hieronder opent `pres.pptx`, die ten minste één dia moet bevatten met een tabel als eerste vorm. Het drukt de huidige vergrendelingsstatus af, schakelt de vergrendeling van de beeldverhouding in, drukt de bijgewerkte status (`True`) af, en slaat het resultaat op als `pres-out.pptx`.

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

## **Veelgestelde vragen**

**Kan ik de rechts‑naar‑links (RTL) lezerichting voor een volledige tabel en de tekst in de cellen inschakelen?**

Ja. De tabel biedt een [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) eigenschap, en alinea's hebben [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen de cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel verplaatsen of van grootte veranderen in het uiteindelijke bestand?**

Gebruik [shape locks](/slides/nl/net/applying-protection-to-presentation/) om verplaatsen, van grootte wijzigen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding binnen een cel als achtergrond ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding zal het celgebied bedekken volgens de gekozen modus (uitrekken of betegelen).