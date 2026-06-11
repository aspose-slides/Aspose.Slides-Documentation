---
title: Hantera tabellceller i presentationer i .NET
linktitle: Hantera celler
type: docs
weight: 30
url: /sv/net/manage-cells/
keywords:
- tabellcell
- sammanfoga celler
- ta bort ram
- dela cell
- bild i cell
- bakgrundsfärg
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera tabellceller i PowerPoint enkelt med Aspose.Slides för .NET. Bli expert på att snabbt komma åt, modifiera och formatera celler för smidig bildautomatisering."
---
## **Översikt**

Aspose.Slides låter dig komma åt och modifiera tabellceller i PowerPoint-presentationer. Den här artikeln förklarar hur du identifierar sammanslagna tabellceller, tar bort cellramar, arbetar med cellnumrering efter sammanslagning eller delning av celler, ändrar en cells bakgrundsfärg och lägger till en bild i en tabellcell. Exemplen visar hur du skapar eller öppnar en presentation, hämtar en tabell från en bild, uppdaterar cellformat via cellens egenskaper och sparar den modifierade presentationen som en PPTX-fil.

## **Identifiera en sammanslagen tabellcell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Hämta tabellen från den första bilden.
3. Iterera genom tabellens rader och kolumner för att hitta sammanslagna celler.
4. Skriv ut ett meddelande när sammanslagna celler hittas.

Denna C#-kod visar hur du identifierar sammanslagna tabellceller i en presentation:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // antar att Slide#0.Shape#0 är en tabell
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            ICell currentCell = table.Rows[i][j];
            if (currentCell.IsMergedCell)
            {
                Console.WriteLine(string.Format("Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.",
                                  i, j, currentCell.RowSpan, currentCell.ColSpan, currentCell.FirstRowIndex, currentCell.FirstColumnIndex));


            }
        }
    }
}
```

## **Ta bort tabellcellramar**

1. Skapa en instans av klassen `Presentation`.
2. Hämta en bilds referens via dess index.
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden `AddTable`.
6. Iterera genom varje cell för att rensa den övre, nedre, högra och vänstra ramen.
7. Spara den modifierade presentationen som en PPTX-fil.

Denna C#-kod visar hur du tar bort ramarna från tabellceller:

```c#
// Instansierar Presentation‑klassen som representerar en PPTX‑fil
using (Presentation pres = new Presentation())
{
   // Hämtar den första bilden
    Slide sld = (Slide)pres.Slides[0];

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Lägger till tabellform på bilden
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Anger ramformat för varje cell
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Skriver PPTX‑filen till disk
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Numrering i sammanslagna celler**

Om vi slår ihop 2 par celler (1, 1) x (2, 1) och (1, 2) x (2, 2) kommer den resulterande tabellen att numreras. Denna C#-kod demonstrerar processen:

```c#
// Instansierar Presentation‑klassen som representerar en PPTX‑fil
using (Presentation presentation = new Presentation())
{
    // Hämtar den första bilden
    ISlide sld = presentation.Slides[0];

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Lägger till en tabellform på bilden
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Anger ramformat för varje cell
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

    // Slår ihop celler (1, 1) x (2, 1)
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Slår ihop celler (1, 2) x (2, 2)
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Vi slår sedan ihop cellerna ytterligare genom att slå ihop (1, 1) och (1, 2). Resultatet är en tabell som innehåller en stor sammanslagen cell i mitten:

```c#
 // Instansierar Presentation‑klassen som representerar en PPTX‑fil
 using (Presentation presentation = new Presentation())
 {
     // Hämtar den första bilden
     ISlide slide = presentation.Slides[0];
 
     // Definierar kolumner med bredder och rader med höjder
     double[] dblCols = { 70, 70, 70, 70 };
     double[] dblRows = { 70, 70, 70, 70 };
 
     // Lägger till en tabellform på bilden
     ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
 
     // Anger ramformat för varje cell
     foreach (IRow row in table.Rows)
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
 
     // Slår ihop celler (1, 1) x (2, 1)
     table.MergeCells(table[1, 1], table[2, 1], false);
 
     // Slår ihop celler (1, 2) x (2, 2)
     table.MergeCells(table[1, 2], table[2, 2], false);
 
     // Slår ihop celler (1, 2) x (2, 2)
     table.MergeCells(table[1, 1], table[1, 2], true);
 
     //Skriver PPTX‑filen till disk
     presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
 }
```

## **Numrering i en delad cell**

I tidigare exempel, när tabellceller slogs ihop, förändrades inte numreringen eller nummeringssystemet i andra celler.

Denna gång tar vi en vanlig tabell (en tabell utan sammanslagna celler) och försöker sedan dela cell (1,1) för att få en speciell tabell. Du kanske vill uppmärksamma tabellens numrering, som kan verka märklig. Men så numererar Microsoft PowerPoint tabellceller och Aspose.Slides gör samma sak.

Denna C#-kod demonstrerar processen vi beskrev:

```c#
// Instansierar Presentation‑klassen som representerar en PPTX‑fil
using (Presentation presentation = new Presentation())
{
    // Hämtar den första bilden
    ISlide slide = presentation.Slides[0];

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Lägger till en tabellform på bilden
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Anger ramformat för varje cell
    foreach (IRow row in table.Rows)
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

    // Slår ihop celler (1, 1) x (2, 1)
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Slår ihop celler (1, 2) x (2, 2)
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Delar cell (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Skriver PPTX‑filen till disk
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Ändra tabellcellens bakgrundsfärg**

Denna C#-kod visar hur du ändrar en tabellcells bakgrundsfärg:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // skapa en ny tabell
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // sätt bakgrundsfärgen för en cell
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Lägg till en bild i en tabellcell**

1. Skapa en instans av `Presentation`-klassen.
2. Hämta en bilds referens via dess index.
3. Definiera en array av kolumner med bredd.
4. Definiera en array av rader med höjd.
5. Lägg till en tabell på bilden via metoden `AddTable`.
6. Skapa ett `Bitmap`-objekt för att hålla bildfilen.
7. Lägg till bitmap-bilden till `IPPImage`-objektet.
8. Ställ in `FillFormat` för tabellcellen till `Picture`.
9. Lägg till bilden i tabellens första cell.
10. Spara den modifierade presentationen som en PPTX-fil

Denna C#-kod visar hur du placerar en bild i en tabellcell när du skapar en tabell:

```c#
// Instansierar Presentation‑klassen som representerar en PPTX‑fil
using (Presentation presentation = new Presentation())
{
    // Hämtar den första bilden
    ISlide slide = presentation.Slides[0];

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Lägger till en tabellform på bilden
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Laddar en bild från en fil och lägger till den i presentationens resurser
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Lägger till bilden i den första tabellcellen
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Sparar PPTX‑filen till disk
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan jag ange olika linjetjocklekar och stilar för olika sidor av en enskild cell?**

Ja. [top](https://reference.aspose.com/slides/sv/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/sv/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/sv/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/sv/net/aspose.slides/cellformat/borderright/) har separata egenskaper, så tjocklek och stil för varje sida kan skilja sig. Detta följer logiskt av per-sida ramkontroll för en cell som demonstreras i artikeln.

**Vad händer med bilden om jag ändrar kolumn-/radstorlek efter att ha satt en bild som cellens bakgrund?**

Beteendet beror på [fill mode](https://reference.aspose.com/slides/sv/net/aspose.slides/picturefillmode/) (stretch/tile). Vid stretchning anpassas bilden till den nya cellen; vid tile-ning beräknas rutorna om. Artikeln nämner bildvisningslägen i en cell.

**Kan jag tilldela en hyperlänk till allt innehåll i en cell?**

[Hyperlinks](/slides/sv/net/manage-hyperlinks/) sätts på textnivå (portion) inom cellens textram eller på hela tabellens/figurens nivå. I praktiken tilldelar du länken till en portion eller till all text i cellen.

**Kan jag ange olika teckensnitt inom en enskild cell?**

Ja. En cells textram stödjer [portions](https://reference.aspose.com/slides/sv/net/aspose.slides/portion/) (körningar) med oberoende formatering—teckensnittsfamilj, stil, storlek och färg.