---
title: Beheer rijen en kolommen in PowerPoint‑tabellen in .NET
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/net/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak van rij
- tekstopmaak van kolom
- tabelstijl
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor .NET en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Introductie**

Aspose.Slides for .NET stelt u in staat om de tabelstructuur en opmaak in PowerPoint‑presentaties te beheren via de [Table](https://reference.aspose.com/slides/net/aspose.slides/table/)‑klasse en de [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑interface. U kunt een koprij aanwijzen, rijen en kolommen klonen of verwijderen, en tekstopmaak toepassen op een volledige rij of kolom.

Dit artikel legt deze bewerkingen uit met C#‑voorbeelden. Het laat ook zien hoe u het stijl‑preset van een tabel kunt ophalen zodat u het opnieuw kunt gebruiken. Rijen‑ en kolom‑indices in een tabel beginnen bij nul.

## **Rijhoogte regelen**

Gebruik [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) om de minimale hoogte van een rij in punten in te stellen. Dit is een ondergrens, geen vaste hoogte. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) geeft de werkelijke hoogte terug en is alleen‑lezen. Toegang tot de rij verkrijgt u via [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Het voorbeeld laadt [row-height-input.pptx](row-height-input.pptx), dat een tabel bevat als het eerste object op de eerste dia. De eerste rij begint op 70 punten. De cellen gebruiken 18‑punt Arial‑tekst, tekstomloop en 6‑punt boven‑ en ondermarges; de langere tekst in de tweede kolom wordt over meerdere regels verdeeld. Het voorbeeld verhoogt de minimumwaarde naar 100 punten, verlaagt deze vervolgens naar 20 punten, drukt de werkelijke hoogte na elke wijziging af en slaat beide resultaten op.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Met de meegeleverde presentatie voegt het verhogen van de minimumwaarde ruimte toe aan de rij. Het verlagen ervan verwijdert die extra ruimte, maar de werkelijke hoogte blijft hoger dan 20 punten omdat de tekst en cel‑marges meer ruimte nodig hebben. Het alleen verlagen van de minimumwaarde kan de rij niet onder de door de inhoud benodigde ruimte dwingen.

Verschillende factoren beïnvloeden de werkelijke hoogte:

- **Tekst en lettergrootte:** langere tekst, expliciete regeleinden of een groter lettertype kunnen meer verticale ruimte vereisen.
- **Omloop en kolombreedte:** met ingeschakelde omloop kan een smallere [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) meer regels produceren. Een bredere kolom kan de benodigde verticale ruimte verminderen.
- **Cel‑marges:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) en [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) voegen verticale ruimte toe. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) en [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) verkleinen de breedte die beschikbaar is voor tekst en kunnen extra omloop veroorzaken.

Voor deze tabel zonder samengevoegde cellen bepaalt de cel die het meeste verticale ruimte nodig heeft de inhoud‑gedreven ondergrens voor de hele rij. Om de rij korter te maken, moet u mogelijk ook de tekst inkorten, de lettergrootte of marges verkleinen, of een kolom breder maken.

De afbeeldingen hieronder tonen dezelfde tabel op dezelfde schaal. In deze uitvoering waren de werkelijke hoogtes 70, 100 en 55.2 punten: de laatste rij bleef hoger dan het minimum van 20 punten. Exacte tekstmetingen kunnen variëren afhankelijk van de lettertypes die in uw omgeving beschikbaar zijn. Download de opgeslagen resultaten: [verhoogd minimum](row-height-increased.pptx) en [verlaagd minimum](row-height-decreased.pptx).

| Origineel: minimum 70 pt, werkelijke 70 pt | Verhoogd: minimum 100 pt, werkelijke 100 pt | Verlaagd: minimum 20 pt, werkelijke 55.2 pt |
| --- | --- | --- |
| ![Originele tabel met een eerste rij van 70 punten.](row-height-before.png) | ![Tabel na het verhogen van het minimum van de eerste rij naar 100 punten.](row-height-increased.png) | ![Tabel na het verlagen van het minimum van de eerste rij naar 20 punten; omloop van de tekst houdt de rij hoger dan het minimum.](row-height-decreased.png) |

## **Stel de eerste rij in als kop**

Gebruik de eigenschap [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) om de eerste rij te markeren voor kop‑opmaak. Het uiterlijk hangt af van de tabelstijl die op de tabel is toegepast.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse.
2. Open de eerste dia.
3. Open de tabel die als eerste vorm op de dia is opgeslagen.
4. Schakel kop‑opmaak in voor de eerste rij.
5. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia. Het schakelt kop‑opmaak in voor de eerste rij en slaat `First_row_header.pptx` op.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Een tabelrij of -kolom klonen**

Kloon rijen of kolommen om hun inhoud en opmaak opnieuw te gebruiken. U kunt een kopie aan het einde van de tabel toevoegen of deze op een specifieke positie invoegen.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse.
2. Open de eerste dia.
3. Definieer de kolombreedtes en rij‑hoogtes.
4. Voeg een tabel toe met de [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)‑methode.
5. Kloon de benodigde rijen.
6. Kloon de benodigde kolommen.
7. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `Test.pptx` met ten minste één dia. Het maakt een tabel met drie kolommen en vijf rijen, met afmetingen opgegeven in punten. Het voegt kopieën van de eerste rij en eerste kolom toe, en voegt vervolgens kopieën van de tweede rij en tweede kolom in op index 3 (de vierde positie). De resulterende tabel heeft zeven rijen en vijf kolommen. Het argument `false` schakelt klonen in aangrenzende samengevoegde rijen of kolommen uit; deze tabel bevat geen samengevoegde cellen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Een rij of kolom uit een tabel verwijderen**

Verwijder rijen of kolommen die niet langer nodig zijn in een tabel. Het verwijderen van een element verschuift de indices van de rijen of kolommen die erop volgen.

1. Maak een presentatie met de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse.
2. Open de eerste dia.
3. Definieer de kolombreedtes en rij‑hoogtes.
4. Voeg een tabel toe met de [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)‑methode.
5. Verwijder de tweede rij en tweede kolom.
6. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een drie‑bij‑drie tabel en verwijdert de rij en kolom op index 1, waardoor er een twee‑bij‑twee tabel overblijft in `TestTable_out.pptx`. De afmetingen zijn in punten. Het argument `false` schakelt het verwijderen van aangrenzende samengevoegde rijen of kolommen uit; deze tabel bevat geen samengevoegde cellen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Tekstopmaak instellen op rijniveau**

Pas tekstopmaak toe op een volledige rij om de cellen consistent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekst‑richting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse.
2. Open de tabel op de eerste dia.
3. Stel [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in voor de eerste rij.
4. Stel [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) en [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) in voor de eerste rij.
5. Stel [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) in voor de tweede rij.
6. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en ten minste twee rijen. Het past 25‑punt tekst, rechts‑uitlijning en een 20‑punt rechter alinea‑margin toe op de eerste rij, en stelt vervolgens verticale tekst in op de tweede rij.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Tekstopmaak instellen op kolomniveau**

Pas tekstopmaak toe op een volledige kolom om de cellen consistent te houden. U kunt lettertype‑eigenschappen, alinea‑opmaak en tekst‑richting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑klasse.
2. Open de tabel op de eerste dia.
3. Stel [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) in voor de eerste kolom.
4. Stel [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) en [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) in voor de eerste kolom.
5. Stel [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) in voor de tweede kolom.
6. Sla de gewijzigde presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als eerste vorm op de eerste dia en ten minste twee kolommen. Het past 25‑punt tekst, rechts‑uitlijning en een 20‑punt rechter alinea‑margin toe op de eerste kolom, en stelt vervolgens verticale tekst in op de tweede kolom.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Tabelstijl‑eigenschappen ophalen**

Gebruik de eigenschap [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) om het toegepaste preset van een tabel op te halen en opnieuw te gebruiken op een andere tabel. Hiermee wordt het preset geïdentificeerd in plaats van individuele cel‑opmaak‑overschrijvingen.

Het voorbeeld maakt een tabel, past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) toe en leest het preset terug. Het drukt `DarkStyle1` af en slaat de tabel op in `table.pptx`.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kan ik PowerPoint‑thema's/stijlen toepassen op een tabel die al is aangemaakt?**  
Ja. De tabel erft het thema van de dia/layout/master en u kunt nog steeds vullingen, randen en tekstkleuren overschrijven bovenop dat thema.

**Kan ik tabelrijen sorteren zoals in Excel?**  
Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer eerst uw gegevens in het geheugen en vul vervolgens de tabelrijen opnieuw in volgens die volgorde.

**Kan ik gestreepte kolommen hebben terwijl ik aangepaste kleuren op specifieke cellen behoud?**  
Ja. Schakel gestreepte kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.