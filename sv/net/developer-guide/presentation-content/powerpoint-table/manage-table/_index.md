---
title: Hantera presentationstabeller i .NET
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/net/manage-table/
keywords:
- lägg till tabell
- skapa tabell
- åtkomst till tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för .NET. Upptäck enkla C#‑kodexempel för att förenkla dina tabellarbetsflöden."
---
## **Introduktion**

En tabell i PowerPoint är ett effektivt sätt att visa och framställa information. Informationen i ett rutnät av celler (arrangerade i rader och kolumner) är rak och lätt att förstå.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/sv/net/aspose.slides/table/) , gränssnittet [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/) , klassen [Cell](https://reference.aspose.com/slides/sv/net/aspose.slides/cell/) , gränssnittet [ICell](https://reference.aspose.com/slides/sv/net/aspose.slides/icell/) , samt andra typer så att du kan skapa, uppdatera och hantera tabeller i alla typer av presentationer. 

## **Skapa en tabell från grunden**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) .
2. Hämta en slids referens genom dess index. 
3. Definiera en array av `columnWidth`.
4. Definiera en array av `rowHeight`.
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/) objekt på sliden via metoden [AddTable](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addtable/) .
6. Iterera genom varje [ICell](https://reference.aspose.com/slides/sv/net/aspose.slides/icell/) för att tillämpa formatering på de övre, nedre, högra och vänstra kantlinjerna.
7. Slå samman de två första cellerna i tabellens första rad. 
8. Åtkomst till en [ICell](https://reference.aspose.com/slides/sv/net/aspose.slides/icell/)s [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/) . 
9. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/) .
10. Spara den ändrade presentationen.

Denna C#‑kod visar hur du skapar en tabell i en presentation:

```c#
 // Instansierar en Presentation-klass som representerar en PPTX-fil
 Presentation pres = new Presentation();

 // Åtkomst till den första sliden
 ISlide sld = pres.Slides[0];

 // Definierar kolumner med bredd och rader med höjd
 double[] dblCols = { 50, 50, 50 };
 double[] dblRows = { 50, 30, 30, 30, 30 };

 // Lägger till en tabellform på sliden
 ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

 // Ställer in kantformat för varje cell
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
 // Slår ihop cellerna 1 och 2 i rad 1
 tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

 // Lägger till lite text i den sammanslagna cellen
 tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

 // Sparar presentationen till disk
 pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Numrering i en standardtabell**

I en standardtabell är numreringen av celler enkel och nollbaserad. Den första cellen i en tabell har indexet 0,0 (kolumn 0, rad 0). 

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Denna C#‑kod visar hur du specificerar numreringen för celler i en tabell:

```c#
 // Instansierar en Presentation-klass som representerar en PPTX-fil
 using (Presentation pres = new Presentation())
 {
 
     // Åtkomst till den första sliden
     ISlide sld = pres.Slides[0];
 
     // Definierar kolumner med bredd och rader med höjd
     double[] dblCols = { 70, 70, 70, 70 };
     double[] dblRows = { 70, 70, 70, 70 };
 
     // Lägger till en tabellform på sliden
     ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);
 
     // Ställer in kantformat för varje cell
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
 
     // Sparar presentationen till disk
     pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
 }
```

## **Åtkomst till en befintlig tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) .
2. Hämta en referens till sliden som innehåller tabellen via dess index. 
3. Skapa ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objekt och sätt det till null.
4. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/)‑objekt tills tabellen hittas.

   Om du misstänker att sliden du arbetar med innehåller en enda tabell kan du helt enkelt kontrollera alla former den innehåller. När en form identifieras som en tabell kan du typkonvertera den till ett [Table](https://reference.aspose.com/slides/sv/net/aspose.slides/table/)‑objekt. Men om sliden innehåller flera tabeller är det bättre att söka efter den tabell du behöver via dess [AlternativeText](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/alternativetext/).

5. Använd [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objektet för att arbeta med tabellen. I exemplet nedan lade vi till en ny rad i tabellen.
6. Spara den ändrade presentationen.

Denna C#‑kod visar hur du får åtkomst till och arbetar med en befintlig tabell:

```c#
 // Instansierar en Presentation-klass som representerar en PPTX-fil
 using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
 {
 
     // Åtkomst till den första sliden
     ISlide sld = pres.Slides[0];
 
     // Initierar null TableEx
     ITable tbl = null;
 
     // Itererar genom formerna och sätter en referens till den hittade tabellen
     foreach (IShape shp in sld.Shapes)
         if (shp is ITable)
             tbl = (ITable)shp;
 
     // Sätter texten för första kolumnen i den andra raden
     tbl[0, 1].TextFrame.Text = "New";
 
     // Sparar den ändrade presentationen till disk
     pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Justera text i en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) .
2. Hämta en slids referens genom dess index. 
3. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objekt på sliden. 
4. Åtkomst till ett [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/)‑objekt från tabellen. 
5. Åtkomst till [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/)-[IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/) .
6. Justera texten vertikalt.
7. Spara den ändrade presentationen.

Denna C#‑kod visar hur du justerar texten i en tabell:

```c#
 // Skapar en instans av Presentation-klassen
 Presentation presentation = new Presentation();

 // Hämtar den första sliden
 ISlide slide = presentation.Slides[0];

 // Definierar kolumner med bredd och rader med höjd
 double[] dblCols = { 120, 120, 120, 120 };
 double[] dblRows = { 100, 100, 100, 100 };

 // Lägger till tabellformen på sliden
 ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
 tbl[1, 0].TextFrame.Text = "10";
 tbl[2, 0].TextFrame.Text = "20";
 tbl[3, 0].TextFrame.Text = "30";

 // Hämtar textramen
 ITextFrame txtFrame = tbl[0, 0].TextFrame;

 // Skapar Paragraph-objektet för textramen
 IParagraph paragraph = txtFrame.Paragraphs[0];

 // Skapar Portion-objektet för stycket
 IPortion portion = paragraph.Portions[0];
 portion.Text = "Text here";
 portion.PortionFormat.FillFormat.FillType = FillType.Solid;
 portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

 // Justera texten vertikalt
 ICell cell = tbl[0, 0];
 cell.TextAnchorType = TextAnchorType.Center;
 cell.TextVerticalType = TextVerticalType.Vertical270;

 // Sparar presentationen till disk
 presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Ställ in textformatering på tabellnivå**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)‑klassen.
2. Hämta en slids referens genom dess index. 
3. Åtkomst till ett [ITable](https://reference.aspose.com/slides/sv/net/aspose.slides/itable/)‑objekt från sliden.
4. Ställ in [FontHeight](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/fontheight/) för texten. 
5. Ställ in [Alignment](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/alignment/) och [MarginRight](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginright/) .
6. Ställ in [TextVerticalType](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/textverticaltype/) .
7. Spara den ändrade presentationen. 

Denna C#‑kod visar hur du tillämpar dina föredragna formateringsalternativ på texten i en tabell:

```c#
 // Skapar en instans av Presentation-klassen
 Presentation presentation = new Presentation();
 ISlide slide = presentation.Slides[0];

 ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Låt oss anta att den första formen på den första sliden är en tabell

 // Ställer in fonthöjden för tabellcellerna
 PortionFormat portionFormat = new PortionFormat();
 portionFormat.FontHeight = 25;
 someTable.SetTextFormat(portionFormat);

 // Ställer in tabellcellernas textjustering och högermarginal i ett anrop
 ParagraphFormat paragraphFormat = new ParagraphFormat();
 paragraphFormat.Alignment = TextAlignment.Right;
 paragraphFormat.MarginRight = 20;
 someTable.SetTextFormat(paragraphFormat);

 // Ställer in tabellcellernas vertikala texttyp
 TextFrameFormat textFrameFormat = new TextFrameFormat();
 textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
 someTable.SetTextFormat(textFrameFormat);


 presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Hämta tabellstilens egenskaper**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna C#‑kod visar hur du får stilegenskaperna från en förinställd tabellstil: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ändra standardstilens förinställda tema 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Lås bildförhållandet för en tabell**

Bildförhållandet för en geometrisk form är förhållandet mellan dess storlekar i olika dimensioner. Aspose.Slides tillhandahåller egenskapen `AspectRatioLocked` så att du kan låsa bildförhållandeinställningen för tabeller och andra former. 

Denna C#‑kod visar hur du låser bildförhållandet för en tabell:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // invertera

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan jag aktivera läsriktning från höger till vänster (RTL) för en hel tabell och texten i dess celler?**

Ja. Tabellen har en [RightToLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/table/righttoleft/)‑egenskap, och stycken har [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphformat/righttoleft/). Genom att använda båda säkerställer du korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutliga filen?**

Använd [shape locks](/slides/sv/net/applying-protection-to-presentation/) för att inaktivera flytt, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan sätta en [picture fill](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt valt läge (stretch eller tile).