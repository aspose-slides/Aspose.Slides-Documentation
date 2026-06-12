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
- tabelkoptekst
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
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor .NET en versnel de bewerking van presentaties en gegevensupdates."
---
## **Inleiding**

Om u in staat te stellen rijen en kolommen van een tabel in een PowerPoint‑presentatie te beheren, biedt Aspose.Slides de klasse [Table](https://reference.aspose.com/slides/nl/net/aspose.slides/table/) , de interface [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/)  en vele andere typen. 

## **Stel de eerste rij in als koptekst**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse en laad de presentatie. 
2. Haal een referentie naar een dia op via de index. 
3. Maak een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object aan en stel het in op null. 
4. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) objecten om de betreffende tabel te vinden. 
5. Stel de eerste rij van de tabel in als header. 

Deze C#‑code laat zien hoe u de eerste rij van een tabel als header instelt:

```c#
// Instantieert de Presentation-klasse
Presentation pres = new Presentation("table.pptx");

// Verkrijgt de eerste dia
ISlide sld = pres.Slides[0];

// Initialiseert de null TableEx
ITable tbl = null;

// Itereert door de vormen en stelt een referentie naar de tabel in
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Stelt de eerste rij van een tabel in als header
tbl.FirstRow = true;

// Slaat de presentatie op naar schijf
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Kloon een tabelrij of -kolom**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Definieer een array van `columnWidth`. 
4. Definieer een array van `rowHeight`. 
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object toe aan de dia via de [AddTable](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addtable/) methode. 
6. Kloon de tabelrij. 
7. Kloon de tabelkolom. 
8. Sla de gewijzigde presentatie op. 

Deze C#‑code laat zien hoe u een rij of kolom van een PowerPoint‑tabel kloont:

```c#
 // Instantieert de Presentation-klasse
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Toegang tot de eerste dia
    ISlide sld = presentation.Slides[0];

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Voegt een tabelvorm toe aan de dia
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Voegt tekst toe aan rij 1 cel 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Voegt tekst toe aan rij 1 cel 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Kloont rij 1 aan het einde van de tabel
    table.Rows.AddClone(table.Rows[0], false);

    // Voegt tekst toe aan rij 2 cel 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Voegt tekst toe aan rij 2 cel 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Kloont rij 2 als de 4e rij van de tabel
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Kloont de eerste kolom aan het einde
    table.Columns.AddClone(table.Columns[0], false);

    // Kloont de 2e kolom op index 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Slaat de presentatie op naar schijf 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Verwijder een rij of kolom uit een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Definieer een array van `columnWidth`. 
4. Definieer een array van `rowHeight`. 
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object toe aan de dia via de [AddTable](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addtable/) methode. 
6. Verwijder de tabelrij. 
7. Verwijder de tabelkolom. 
8. Sla de gewijzigde presentatie op. 

Deze C#‑code laat zien hoe u een rij of kolom uit een tabel verwijdert:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tekstopmaak instellen op rijniveau van de tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Toegang tot de relevante [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object op de dia. 
4. Stel de eerste‑rij‑cellen [FontHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/fontheight/) in. 
5. Stel de eerste‑rij‑cellen [Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/alignment/) en [MarginRight](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginright/) in. 
6. Stel de tweede‑rij‑cellen [TextVerticalType](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/textverticaltype/) in. 
7. Sla de gewijzigde presentatie op. 

Deze C#‑code demonstreert de bewerking.

```c#
// Maakt een instantie van de Presentation-klasse
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Laten we aannemen dat de eerste vorm op de eerste dia een tabel is

// Stelt de letterhoogte van de eerste-rijcellen in
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Stelt de uitlijning en de rechter marge van de eerste-rijcellen in
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Stelt het verticale type van de tekst in voor de tweede-rijcellen
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Slaat de presentatie op naar schijf
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tekstopmaak instellen op kolomniveau van de tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse en laad de presentatie, 
2. Haal een referentie naar een dia op via de index. 
3. Toegang tot de relevante [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) object op de dia. 
4. Stel de eerste‑kolom‑cellen [FontHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/fontheight/) in. 
5. Stel de eerste‑kolom‑cellen [Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/alignment/) en [MarginRight](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginright/) in. 
6. Stel de tweede‑kolom‑cellen [TextVerticalType](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/textverticaltype/) in. 
7. Sla de gewijzigde presentatie op. 

Deze C#‑code demonstreert de bewerking: 

```c#
 // Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Laten we aannemen dat de eerste vorm op de eerste dia een tabel is

 // Stelt de letterhoogte van de eerste kolomcellen in
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

 // Stelt de tekstuitlijning en de rechter marge van de eerste kolomcellen in één oproep
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

 // Stelt het verticale type van de tekst in voor de tweede kolomcellen
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

 // Slaat de presentatie op naar schijf
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tabelstijl‑eigenschappen ophalen**

Aspose.Slides maakt het mogelijk de stijl‑eigenschappen van een tabel op te halen zodat u die details kunt gebruiken voor een andere tabel of elders. Deze C#‑code toont hoe u de stijl‑eigenschappen van een vooraf ingestelde tabelstijl ophaalt: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // wijzig het standaard stijl preset thema 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik PowerPoint‑thema's/stijlen toepassen op een reeds gemaakte tabel?**

Ja. De tabel erft het thema van de dia/layout/master, en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, tabellen van Aspose.Slides hebben geen ingebouwde sortering of filters. Sorteer eerst uw gegevens in het geheugen en vul vervolgens de tabelrijen in die volgorde opnieuw.

**Kan ik gestreepte kolommen hebben terwijl ik aangepaste kleuren behoud voor specifieke cellen?**

Ja. Schakel gestreepte kolommen in, en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.