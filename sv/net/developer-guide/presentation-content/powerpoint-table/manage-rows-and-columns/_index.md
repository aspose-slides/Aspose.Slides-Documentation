---
title: Hantera rader och kolumner i PowerPoint-tabeller i .NET
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/net/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första raden
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- radtextformatering
- kolumntextformatering
- tabellstil
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för .NET och snabba upp redigering av presentationer och datauppdateringar."
---
## **Introduktion**

Aspose.Slides för .NET låter dig hantera tabellstruktur och formatering i PowerPoint‑presentationer via klassen [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) och gränssnittet [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Du kan ange en rubrikrad, klona eller ta bort rader och kolumner, och tillämpa textformatering på en hel rad eller kolumn.

Denna artikel förklarar dessa operationer med C#‑exempel. Den visar också hur du hämtar en tabells stilförinställning så att du kan återanvända den. Index för tabellrader och -kolumner börjar på noll.

## **Styr radhöjd**

Använd [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) för att ange en rads minsta höjd i punkter. Det är en nedre gräns, inte en fast höjd. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) returnerar den faktiska höjden och är skrivskyddad. Åtkomst till raden sker via [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/).

Exemplet laddar [row-height-input.pptx](row-height-input.pptx), som har en tabell som den första formen på den första bilden. Dess första rad börjar på 70 punkter. Cellerna använder 18‑punkts Arial‑text, radbrytning och 6‑punkts marginaler högst och längst ner; den längre texten i den andra kolumnen bryts på flera rader. Exemplet ökar minimum till 100 punkter, minskar det sedan till 20 punkter, skriver ut den faktiska höjden efter varje ändring och sparar båda resultaten.

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

Med den medföljande presentationen lägger en ökning av minimum till extra utrymme i raden. En minskning tar bort det extra utrymmet, men den faktiska höjden förblir större än 20 punkter eftersom texten och cellmarginalerna behöver mer plats. Att enbart minska minimum kan inte tvinga raden under det utrymme som innehållet kräver.

Flera faktorer påverkar den faktiska höjden:

- **Text och teckenstorlek:** längre text, explicita radbrytningar eller ett större teckensnitt kan kräva mer vertikalt utrymme.
- **Radbrytning och kolumnbredd:** med radbrytning aktiverad kan en smalare [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) producera fler rader. En bredare kolumn kan minska det vertikala utrymmet som krävs.
- **Cellmarginaler:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) och [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) lägger till vertikalt utrymme. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) och [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) minskar bredden som är tillgänglig för text och kan orsaka ytterligare radbrytning.

För den här tabellen utan sammanslagna celler avgör den cell som behöver mest vertikalt utrymme den innehållsdrivna nedre gränsen för hela raden. För att förkorta raden kan du också behöva korta ner texten, minska teckenstorleken eller marginalerna, eller bredda en kolumn.

Bilderna nedan visar samma tabell i samma skala. I detta körning var de faktiska höjderna 70, 100 och 55,2 punkter: den sista raden förblev högre än sitt 20‑punkts minimum. Exakta textmått kan variera beroende på vilka teckensnitt som finns i din miljö. Ladda ner de sparade resultaten: [ökad minimum](row-height-increased.pptx) och [minskad minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, faktiskt 70 pt | Ökad: minimum 100 pt, faktiskt 100 pt | Minskad: minimum 20 pt, faktiskt 55,2 pt |
| --- | --- | --- |
| ![Originaltabell med en 70‑punkts första rad.](row-height-before.png) | ![Tabell efter att ha ökat den första radens minimum till 100 punkter.](row-height-increased.png) | ![Tabell efter att ha minskat den första radens minimum till 20 punkter; radbruten text håller raden högre än minimum.](row-height-decreased.png) |

## **Markera den första raden som rubrik**

Använd egenskapen [FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) för att markera den första raden för rubrikformatering. Dess utseende beror på den tabellstil som tillämpas på tabellen.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Åtkomst till den första bilden.
3. Åtkomst till tabellen som lagras som den första formen på bilden.
4. Aktivera rubrikformatering för dess första rad.
5. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden. Det aktiverar rubrikformatering för den första raden och sparar `First_row_header.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Klona en tabellrad eller -kolumn**

Klona rader eller kolumner för att återanvända deras innehåll och formatering. Du kan lägga till en kopia i slutet av tabellen eller infoga den på en specifik position.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Åtkomst till den första bilden.
3. Definiera kolumnbredderna och radhöjderna.
4. Lägg till en tabell med metoden [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Klona de erforderliga raderna.
6. Klona de erforderliga kolumnerna.
7. Spara den modifierade presentationen.

Exemplet kräver `Test.pptx` med minst en bild. Det skapar en tabell med tre kolumner och fem rader, med dimensioner angivna i punkter. Det lägger till kopior av den första raden och kolumnen, för att sedan infoga kopior av den andra raden och kolumnen vid index 3 (den fjärde positionen). Den resulterande tabellen har sju rader och fem kolumner. Argumentet `false` inaktiverar kloning i intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

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

## **Ta bort en rad eller kolumn från en tabell**

Ta bort rader eller kolumner som inte längre behövs i en tabell. Borttagning av ett objekt förskjuter indexen för de rader eller kolumner som följer efter det.

1. Skapa en presentation med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Åtkomst till den första bilden.
3. Definiera kolumnbredderna och radhöjderna.
4. Lägg till en tabell med metoden [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/).
5. Ta bort den andra raden och den andra kolumnen.
6. Spara den modifierade presentationen.

Detta exempel skapar en tre‑på‑tre‑tabell och tar bort raden och kolumnen vid index 1, vilket lämnar en två‑på‑två‑tabell i `TestTable_out.pptx`. Dimensionerna är i punkter. Argumentet `false` inaktiverar borttagning av intilliggande sammanslagna rader eller kolumner; den här tabellen har inga sammanslagna celler.

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

## **Ställ in textformatering på radnivå i tabellen**

Tillämpa textformatering på en hel rad för att hålla dess celler enhetliga. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Åtkomst till tabellen på den första bilden.
3. Ställ in [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) för den första raden.
4. Ställ in [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) och [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) för den första raden.
5. Ställ in [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) för den andra raden.
6. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två rader. Det applicerar 25‑punkts text, högerjustering och en 20‑punkts högermarginal för stycket på den första raden, och sätter sedan vertikal text i den andra raden.

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

## **Ställ in textformatering på kolumnnivå i tabellen**

Tillämpa textformatering på en hel kolumn för att hålla dess celler enhetliga. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Åtkomst till tabellen på den första bilden.
3. Ställ in [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) för den första kolumnen.
4. Ställ in [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) och [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) för den första kolumnen.
5. Ställ in [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) för den andra kolumnen.
6. Spara den modifierade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två kolumner. Det applicerar 25‑punkts text, högerjustering och en 20‑punkts högermarginal för stycket på den första kolumnen, och sätter sedan vertikal text i den andra kolumnen.

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

## **Hämta tabellstilsegenskaper**

Använd egenskapen [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) för att hämta den förinställning som har applicerats på en tabell och återanvända den på en annan tabell. Detta identifierar förinställningen snarare än individuella cellformateringsöverskrivningar.

Exemplet skapar en tabell, applicerar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/), och läser tillbaka förinställningen. Det skriver ut `DarkStyle1` och sparar tabellen i `table.pptx`.

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

**Kan jag tillämpa PowerPoint‑teman/stilar på en redan skapad tabell?**

Ja. Tabellen ärver bild‑/layout‑/master‑temat, och du kan fortfarande åsidosätta fyllningar, ramar och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filter. Sortera dina data i minnet först, och fyll sedan tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller egna färger på specifika celler?**

Ja. Aktivera bandade kolumner, och åsidosätt sedan specifika celler med lokal formatering; cell‑nivåformatering har företräde framför tabellstilen.