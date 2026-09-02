---
title: Beheer presentatietabellen in .NET
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/net/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel openen
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint-slides met Aspose.Slides voor .NET. Ontdek eenvoudige C#-code-voorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (geordend in rijen en kolommen) is eenvoudig en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/net/aspose.slides/table/) klasse, de [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) interface, de [Cell](https://reference.aspose.com/slides/nl/net/aspose.slides/cell/) klasse, de [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/) interface en andere typen om u in staat te stellen tabellen te maken, bij te werken en te beheren in alle soorten presentaties. 

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal via de index de referentie van een dia op.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object toe aan de dia via de [AddTable](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addtable/) methode.  
6. Itereer over elke [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/) om opmaak toe te passen op de boven, onder, rechts en links randen.  
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.  
8. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van een [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/).  
9. Voeg wat tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maakt een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();

// Toegang tot de eerste dia
ISlide sld = pres.Slides[0];

// Definieert kolommen met breedtes en rijen met hoogtes
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Voegt een tabelvorm toe aan de dia
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Stelt het randformaat in voor elke cel
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
// Voegt cellen 1 en 2 van rij 1 samen
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Voegt wat tekst toe aan de samengevoegde cel
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Slaat de presentatie op naar schijf
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nul-gebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0). 

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze C#-code maakt de bovenstaande standaard-tabel van 4 × 4 en stelt het randformaat in voor elke cel:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maakt een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
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

    // Slaat de presentatie op naar schijf
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal via de index een referentie op naar de dia die de tabel bevat.  
3. Maak een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object aan en stel het in op null.  
4. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) objecten tot de tabel wordt gevonden.  

   Als u vermoedt dat de dia waarmee u werkt slechts één tabel bevat, kunt u eenvoudig alle vormen die erop staan controleren. Wanneer een vorm wordt geïdentificeerd als een tabel, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/net/aspose.slides/table/) object. Maar als de dia meerdere tabellen bevat, zoekt u beter de gewenste tabel via de [AlternativeText](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/alternativetext/).  

5. Gebruik het [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object om met de tabel te werken. In het onderstaande voorbeeld hebben we een nieuwe rij aan de tabel toegevoegd.  
6. Sla de gewijzigde presentatie op.

```c#
using Aspose.Slides;

// Maakt een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Toegang tot de eerste dia
    ISlide sld = pres.Slides[0];

    // Initialiseert null TableEx
    ITable tbl = null;

    // Itereert door de shapes en stelt een referentie in naar de gevonden tabel
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Stelt de tekst in voor de eerste kolom van de tweede rij
    tbl[0, 1].TextFrame.Text = "New";

    // Slaat de gewijzigde presentatie op naar schijf
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Zoek de cel die een TextFrame bezit**

Wanneer generieke tekstverwerkingscode een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) van een tabel ontvangt, gebruik dan de eigenschap [ITextFrame.ParentCell](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentcell/) om de eigenaar [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/) op te halen. Voor een tabelcel-tekstkader is [ITextFrame.ParentCell](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentcell/) ingesteld en is [ITextFrame.ParentShape](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentshape/) `null`, zelfs hoewel de tabel zelf een shape is.  

De celcoördinaten zijn beschikbaar via de alleen-lezende eigenschappen [ICell.FirstColumnIndex](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/firstcolumnindex/) en [ICell.FirstRowIndex](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/firstrowindex/). [ITextFrame.ParentCell](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentcell/) is ook alleen-lezend: het biedt navigatie naar de eigenaar, maar verandert de eigendom niet. Controleer altijd of de geretourneerde cel `null` is voordat u deze gebruikt.  

Voor een compleet voorbeeld dat tabel-cellen en shape-eigenaren identificeert, inclusief shapes die aan SmartArt-knooppunten zijn gekoppeld, zie [Search and Replace Text](/slides/nl/net/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal via de index de referentie van een dia op.  
3. Voeg een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object toe aan de dia.  
4. Toegang tot een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) object uit de tabel.  
5. Toegang tot de [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) van het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Maakt een instantie van de Presentation-klasse
Presentation presentation = new Presentation();

// Haalt de eerste dia op 
ISlide slide = presentation.Slides[0];

// Definieert kolommen met breedtes en rijen met hoogtes
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Voegt de tabelvorm toe aan de dia
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Toegang tot het tekstkader
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creëert het Paragraph-object voor het tekstkader
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creëert het Portion-object voor de paragraaf
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Lijnt de tekst verticaal uit
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Slaat de presentatie op naar schijf
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.  
2. Haal via de index de referentie van een dia op.  
3. Toegang tot een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object van de dia.  
4. Stel de [FontHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/fontheight/) in voor de tekst.  
5. Stel de [Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/alignment/) en [MarginRight](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginright/) in.  
6. Stel de [TextVerticalType](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/textverticaltype/) in.  
7. Sla de gewijzigde presentatie op. 

```c#
using Aspose.Slides;

// Maakt een instantie van de Presentation-klasse
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Laten we aannemen dat de eerste shape op de eerste dia een tabel is

// Stelt de letterhoogte van de tabelcellen in
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Stelt de tekstuitlijning en rechter marge van de tabelcellen in één keer in
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Stelt het verticale type van de tabelcellen in
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tabel-stijleigenschappen opvragen**

Aspose.Slides stelt u in staat de stijleigenschappen van een tabel op te halen, zodat u die details kunt gebruiken voor een andere tabel of elders. Deze C#-code laat zien hoe u de stijleigenschappen van een vooraf ingestelde tabelstijl verkrijgt: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // wijzig het standaard stijlpreset-thema

    // Haal het stijlpreset van de tabel op.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Pas het opgehaalde stijlpreset toe op een andere tabel.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Verhouding van een tabel vergrendelen**

De beeldverhouding van een geometrische vorm is de verhouding van zijn afmetingen in verschillende dimensies. Aspose.Slides biedt de eigenschap `AspectRatioLocked` waarmee u de beeldverhoudingsinstelling voor tabellen en andere vormen kunt vergrendelen. 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // omkeren

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik de leesrichting van rechts-naar-links (RTL) voor een volledige tabel en de tekst in de cellen inschakelen?**

Ja. De tabel biedt de eigenschap [RightToLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/table/righttoleft/), en alinea's hebben [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphformat/righttoleft/). Door beide te gebruiken wordt de juiste RTL-volgorde en weergave binnen cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte wijzigen?**

Gebruik [shape locks](/slides/nl/net/applying-protection-to-presentation/) om verplaatsen, grootte wijzigen, selectie, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding bedekt het celgebied volgens de gekozen modus (stretch of tile).