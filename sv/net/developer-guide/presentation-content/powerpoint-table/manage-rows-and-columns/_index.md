---
title: Hantera rader och kolumner i PowerPoint‑tabeller i .NET
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
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för .NET och snabba upp redigering av presentationer samt datauppdateringar."
---
## **Introduktion**

För att du ska kunna hantera en tabells rader och kolumner i en PowerPoint‑presentation erbjuder Aspose.Slides [Table](https://reference.aspose.com/slides/sv/net/aspose.slides/table/)‑klassen, [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑gränssnittet och många andra typer. 

## **Ange den första raden som rubrik**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och läs in presentationen. 
2. Hämta en bilds referens via dess index. 
3. Skapa ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objekt och sätt det till null. 
4. Iterera igenom alla [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/)‑objekt för att hitta den relevanta tabellen. 
5. Ange tabellens första rad som dess rubrik. 

Denna C#‑kod visar hur du anger en tabells första rad som rubrik:

```c#
 // Instansierar Presentation-klassen
 Presentation pres = new Presentation("table.pptx");

 // Hämtar den första bilden
 ISlide sld = pres.Slides[0];

 // Initierar null TableEx
 ITable tbl = null;

 // Itererar igenom formerna och sätter en referens till tabellen
 foreach (IShape shp in sld.Shapes)
 {
     if (shp is ITable)
     {
         tbl = (ITable)shp;
     }
 }

 // Anger den första raden i en tabell som dess rubrik
 tbl.FirstRow = true;

 // Sparar presentationen till disk
 pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Klona en tabellrad eller kolumn**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och läs in presentationen, 
2. Hämta en bilds referens via dess index. 
3. Definiera en array av `columnWidth`. 
4. Definiera en array av `rowHeight`. 
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objekt på bilden via metoden [AddTable](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addtable/). 
6. Klona tabellraden. 
7. Klona tabellkolumnen. 
8. Spara den ändrade presentationen. 

Denna C#‑kod visar hur du klonar en rad eller kolumn i en PowerPoint‑tabell:

```c#
 // Instansierar Presentation-klassen
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Hämtar den första bilden
    ISlide sld = presentation.Slides[0];

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Lägger till en tabellform på bilden
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Lägger till lite text i rad 1 cell 1
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Lägger till lite text i rad 1 cell 2
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Klonar rad 1 i slutet av tabellen
    table.Rows.AddClone(table.Rows[0], false);

    // Lägger till lite text i rad 2 cell 1
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Lägger till lite text i rad 2 cell 2
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Klonar rad 2 som den 4:e raden i tabellen
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Klonar första kolumnen i slutet
    table.Columns.AddClone(table.Columns[0], false);

    // Klonar 2:a kolumnen på 4:e kolumnindex
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Sparar presentationen till disk 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ta bort en rad eller kolumn från en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och läs in presentationen, 
2. Hämta en bilds referens via dess index. 
3. Definiera en array av `columnWidth`. 
4. Definiera en array av `rowHeight`. 
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objekt på bilden via metoden [AddTable](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addtable/). 
6. Ta bort tabellraden. 
7. Ta bort tabellkolumnen. 
8. Spara den ändrade presentationen. 

Denna C#‑kod visar hur du tar bort en rad eller kolumn från en tabell:

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

## **Ange textformatering på radnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och läs in presentationen, 
2. Hämta en bilds referens via dess index. 
3. Kom åt det relevanta [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objektet från bilden. 
4. Ställ in [FontHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/fontheight/) för cellerna i den första raden. 
5. Ställ in [Alignment](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/alignment/) och [MarginRight](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginright/) för cellerna i den första raden. 
6. Ställ in [TextVerticalType](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/textverticaltype/) för cellerna i den andra raden. 
7. Spara den ändrade presentationen. 

Denna C#‑kod demonstrerar operationen.

```c#
// Skapar en instans av Presentation-klassen
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Anta att den första formen på den första bilden är en tabell

// Anger teckensnittshöjd för cellerna i första raden
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Anger textjustering och högermarginal för cellerna i första raden
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Anger vertikal texttyp för cellerna i andra raden
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Sparar presentationen till disk
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Ange textformatering på kolumnnivå i tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och läs in presentationen, 
2. Hämta en bilds referens via dess index. 
3. Kom åt det relevanta [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objektet från bilden. 
4. Ställ in [FontHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/fontheight/) för cellerna i den första kolumnen. 
5. Ställ in [Alignment](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/alignment/) och [MarginRight](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginright/) för cellerna i den första kolumnen. 
6. Ställ in [TextVerticalType](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/textverticaltype/) för cellerna i den andra kolumnen. 
7. Spara den ändrade presentationen. 

Denna C#‑kod demonstrerar operationen: 

```c#
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Anta att den första formen på den första bilden är en tabell

// Anger teckensnittshöjd för cellerna i första kolumnen
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Anger textjustering och högermarginal för cellerna i första kolumnen i ett anrop
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Anger vertikal texttyp för cellerna i andra kolumnen
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Sparar presentationen till disk
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Hämta tabellens stilegenskaper**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna C#‑kod visar hur du får stilegenskaperna från en förinställd tabellstil: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ändra standardstilens förinställda tema 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/stilar på en redan skapad tabell?**

Ja. Tabellen ärver bildens/layou­tens/master‑tema, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, tabeller i Aspose.Slides har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först och fyll sedan tabellraderna på nytt i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner och åsidosätt sedan specifika celler med lokalt format; cellnivåformat har företräde framför tabellstilen.