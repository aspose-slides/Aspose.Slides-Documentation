---
title: Beheer presentatietabellen in .NET
linktitle: Tabel beheren
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
description: "Maak en bewerk tabellen in PowerPoint‑dia's met Aspose.Slides voor .NET. Ontdek eenvoudige C#‑codevoorbeelden om uw tabelprocessen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (gerangschikt in rijen en kolommen) is overzichtelijk en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/net/aspose.slides/table/)‑klasse, de [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/)‑interface, de [Cell](https://reference.aspose.com/slides/nl/net/aspose.slides/cell/)‑klasse, de [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/)‑interface en andere types om tabellen in allerlei presentaties te maken, bij te werken en te beheren. 

## **Een tabel vanaf nul maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.  
2. Verkrijg een referentie naar een slide via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/)‑object toe aan de slide via de [AddTable](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addtable/)‑methode.  
6. Loop door elke [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/) om opmaak toe te passen op de boven‑, onder‑, rechts‑ en linkerranden.  
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.  
8. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van een [ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/).  
9. Voeg wat tekst toe aan de [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

Deze C#‑code toont hoe je een tabel in een presentatie maakt:

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
Presentation pres = new Presentation();

// Verkrijgt de eerste dia
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
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Voegt tekst toe aan de samengevoegde cel
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Slaat de presentatie op op schijf
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nul‑gebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0). 

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze C#‑code toont hoe je de nummering voor cellen in een tabel specificeert:

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
using (Presentation pres = new Presentation())
{

    // Verkrijgt de eerste dia
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

    // Slaat de presentatie op op schijf
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.  

2. Verkrijg een referentie naar de slide die de tabel bevat via de index.  

3. Maak een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/)‑object en zet het op null.  

4. Loop door alle [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/)‑objecten totdat de tabel gevonden is.  

   Als je vermoedt dat de slide slechts één tabel bevat, kun je eenvoudig alle shapes die erin zitten nalopen. Wanneer een shape wordt herkend als een tabel, kun je het casten naar een [Table](https://reference.aspose.com/slides/nl/net/aspose.slides/table/)‑object. Maar als de slide meerdere tabellen bevat, zoek je het juiste object via de [AlternativeText](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/alternativetext/).  

5. Gebruik het [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/)‑object om met de tabel te werken. In het voorbeeld hieronder hebben we een nieuwe rij toegevoegd.  

6. Sla de gewijzigde presentatie op.

Deze C#‑code toont hoe je toegang krijgt tot en werkt met een bestaande tabel:

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Verkrijgt de eerste dia
    ISlide sld = pres.Slides[0];

    // Initialiseert TableEx op null
    ITable tbl = null;

    // Itereert door de shapes en stelt een referentie naar de gevonden tabel in
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Stelt de tekst in voor de eerste kolom van de tweede rij
    tbl[0, 1].TextFrame.Text = "New";

    // Slaat de gewijzigde presentatie op op schijf
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.  
2. Verkrijg een referentie naar een slide via de index.  
3. Voeg een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/)‑object toe aan de slide.  
4. Verkrijg een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/)‑object uit de tabel.  
5. Verkrijg het [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) van het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.

Deze C#‑code toont hoe je de tekst in een tabel uitlijnt:

```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.  
2. Verkrijg een referentie naar een slide via de index.  
3. Verkrijg een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/)‑object van de slide.  
4. Stel de [FontHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/fontheight/) in voor de tekst.  
5. Stel de [Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/alignment/) en [MarginRight](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginright/) in.  
6. Stel de [TextVerticalType](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/textverticaltype/) in.  
7. Sla de gewijzigde presentatie op.  

Deze C#‑code toont hoe je je gewenste opmaakopties toepast op de tekst in een tabel:

```c#
// Maakt een instantie van de Presentation-klasse
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Laten we aannemen dat de eerste shape op de eerste dia een tabel is

// Stelt de letterhoogte van de tabelcellen in
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Stelt de uitlijning en rechter marge van de tabelcellen in één oproep in
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Stelt het verticale type van de tekst in de tabelcellen in
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);


presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Stijl‑eigenschappen van een tabel ophalen**

Aspose.Slides stelt je in staat de stijl‑eigenschappen van een tabel op te halen zodat je die details kunt gebruiken voor een andere tabel of elders. Deze C#‑code laat zien hoe je de stijl‑eigenschappen van een tabel‑preset‑stijl kunt ophalen:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // wijzig het standaard stijlpresetthema
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Verhouding van een tabel vergrendelen**

De beeldverhouding van een geometrische vorm is de verhouding tussen de afmetingen in verschillende dimensies. Aspose.Slides biedt de eigenschap `AspectRatioLocked` om de verhouding voor tabellen en andere vormen te vergrendelen. 

Deze C#‑code laat zien hoe je de beeldverhouding van een tabel vergrendelt:

```c#
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

**Kan ik de rechts‑naar‑links (RTL) leesrichting voor een hele tabel en de tekst in de cellen inschakelen?**

Ja. De tabel heeft een [RightToLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/table/righttoleft/)‑eigenschap en alinea's hebben [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphformat/righttoleft/). Door beide te gebruiken, wordt de juiste RTL‑volgorde en weergave binnen de cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte aanpassen?**

Gebruik [shape locks](/slides/nl/net/applying-protection-to-presentation/) om verplaatsen, formaat wijzigen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. Je kunt een [picture fill](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding vult de celruimte volgens de gekozen modus (stretch of tile).