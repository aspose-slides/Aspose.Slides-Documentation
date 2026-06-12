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
description: "Beheer moeiteloos tabelcellen in PowerPoint met Aspose.Slides voor .NET. Beheers het snel benaderen, wijzigen en opmaken van cellen voor een naadloze dia-automatisering."
---
## **Overzicht**

Aspose.Slides stelt u in staat tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering om kunt gaan na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, celopmaak bijwerkt via cel‑eigenschappen en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Een samengevoegde tabelcel identificeren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
2. Haal de tabel op van de eerste dia.  
3. Loop door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.  
4. Print een bericht wanneer er samengevoegde cellen worden gevonden.

Deze C#‑code laat zien hoe u samengevoegde tabelcellen in een presentatie kunt identificeren:

```c#
using (Presentation pres = new Presentation("SomePresentationWithTable.pptx"))
{
    ITable table = pres.Slides[0].Shapes[0] as ITable; // veronderstel dat Slide#0.Shape#0 een tabel is
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

## **Tabelcelranden verwijderen**
1. Maak een instantie van de `Presentation`‑klasse.  
2. Haal een referentie naar een dia op via het indexnummer.  
3. Definieer een array met kolommen en hun breedte.  
4. Definieer een array met rijen en hun hoogte.  
5. Voeg een tabel toe aan de dia met de `AddTable`‑methode.  
6. Loop door elke cel en maak de boven‑, onder‑, rechter‑ en linker‑rand leeg.  
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C#‑code laat zien hoe u de randen van tabelcellen verwijdert:

```c#
// Instantieert de Presentation-klasse die een PPTX‑bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{
   // Toegang tot de eerste dia
    Slide sld = (Slide)pres.Slides[0];

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Voegt de tabelvorm toe aan de dia
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
    foreach (IRow row in tbl.Rows)
        foreach (ICell cell in row)
        {
            cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
            cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
        }

    // Schrijft het PPTX‑bestand naar schijf
    pres.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Nummering in samengevoegde cellen**
Als we 2 paren cellen samenvoegen (1, 1) × (2, 1) en (1, 2) × (2, 2), wordt de resulterende tabel genummerd. Deze C#‑code demonstreert het proces:

```c#
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
    // Toegang tot de eerste dia
    ISlide sld = presentation.Slides[0];

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

    // Voegt cellen (1, 1) x (2, 1) samen
    tbl.MergeCells(tbl[1, 1], tbl[2, 1], false);

    // Voegt cellen (1, 2) x (2, 2) samen
    tbl.MergeCells(tbl[1, 2], tbl[2, 2], false);

    presentation.Save("MergeCells_out.pptx", SaveFormat.Pptx);
}
```

Vervolgens voegen we de cellen verder samen door (1, 1) en (1, 2) te combineren. Het resultaat is een tabel met een grote samengevoegde cel in het midden:

```c#
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
    // Toegang tot de eerste dia
    ISlide slide = presentation.Slides[0];

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Voegt een tabelvorm toe aan de dia
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
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

    // Voegt cellen (1, 1) x (2, 1) samen
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Voegt cellen (1, 2) x (2, 2) samen
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Voegt cellen (1, 2) x (2, 2) samen
    table.MergeCells(table[1, 1], table[1, 2], true);

    // Schrijft het PPTX‑bestand naar schijf
    presentation.Save("MergeCells1_out.pptx", SaveFormat.Pptx);
}
```

## **Nummering in een opgesplitste cel**
In eerdere voorbeelden veranderde de nummering in andere cellen niet toen tabelcellen werden samengevoegd.

Deze keer nemen we een normale tabel (een tabel zonder samengevoegde cellen) en splitsen we cel (1, 1) om een speciale tabel te krijgen. Let op de nummering van deze tabel; die kan vreemd lijken. Dat is echter de manier waarop Microsoft PowerPoint tabelcellen nummert en Aspose.Slides doet hetzelfde.

Deze C#‑code demonstreert het beschreven proces:

```c#
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
    // Toegang tot de eerste dia
    ISlide slide = presentation.Slides[0];

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Voegt een tabelvorm toe aan de dia
    ITable table = slide.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
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

    // Voegt cellen (1, 1) x (2, 1) samen
    table.MergeCells(table[1, 1], table[2, 1], false);

    // Voegt cellen (1, 2) x (2, 2) samen
    table.MergeCells(table[1, 2], table[2, 2], false);

    // Splits cel (1, 1). 
    table[1, 1].SplitByWidth(table[2, 1].Width / 2);

    // Schrijft het PPTX‑bestand naar schijf
    presentation.Save("CellSplit_out.pptx", SaveFormat.Pptx);
}
```

## **Achtergrondkleur van de tabelcel wijzigen**

Deze C#‑code laat zien hoe u de achtergrondkleur van een tabelcel wijzigt:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // maak een nieuwe tabel
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // stel de achtergrondkleur voor een cel in
    ICell cell = table[2, 3];
    cell.CellFormat.FillFormat.FillType = FillType.Solid;
    cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
}
```

## **Afbeelding toevoegen in een tabelcel**

1. Maak een instantie van de`Presentation`‑klasse.  
2. Haal een referentie naar een dia op via het indexnummer.  
3. Definieer een array met kolommen en hun breedte.  
4. Definieer een array met rijen en hun hoogte.  
5. Voeg een tabel toe aan de dia met de `AddTable`‑methode.  
6. Maak een `Bitmap`‑object aan om het afbeeldingsbestand op te slaan.  
7. Voeg de bitmap‑afbeelding toe aan het `IPPImage`‑object.  
8. Stel het `FillFormat` van de tabelcel in op `Picture`.  
9. Voeg de afbeelding toe aan de eerste cel van de tabel.  
10. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze C#‑code laat zien hoe u een afbeelding in een tabelcel plaatst bij het maken van een tabel:

```c#
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
using (Presentation presentation = new Presentation())
{
    // Toegang tot de eerste dia
    ISlide slide = presentation.Slides[0];

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 100, 100, 100, 100, 90 };

    // Voegt een tabelvorm toe aan de dia
    ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

    // Laadt een afbeelding van een bestand en voegt deze toe aan de presentatieresources
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Voegt de afbeelding toe aan de eerste tabelcel
    table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Slaat het PPTX‑bestand op naar schijf
    presentation.Save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [boven](https://reference.aspose.com/slides/nl/net/aspose.slides/cellformat/bordertop/)/[onder](https://reference.aspose.com/slides/nl/net/aspose.slides/cellformat/borderbottom/)/[linker](https://reference.aspose.com/slides/nl/net/aspose.slides/cellformat/borderleft/)/[rechter](https://reference.aspose.com/slides/nl/net/aspose.slides/cellformat/borderright/) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kunnen verschillen. Dit volgt logisch uit de per‑zijde‑randbesturing voor een cel die in het artikel wordt getoond.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [vulmodus](https://reference.aspose.com/slides/nl/net/aspose.slides/picturefillmode/) (stretch/tile). Bij uitrekken past de afbeelding zich aan de nieuwe cel aan; bij tegelen worden de tegels opnieuw berekend. Het artikel beschrijft de weergavemodi van afbeeldingen in een cel.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/net/manage-hyperlinks/) worden ingesteld op tekst‑ (deel‑)niveau binnen het tekstframe van de cel of op het niveau van de volledige tabel/vorm. In de praktijk kent u de link toe aan een deel of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel gebruiken?**

Ja. Het tekstframe van een cel ondersteunt [porties](https://reference.aspose.com/slides/nl/net/aspose.slides/portion/) (runs) met onafhankelijke opmaak — lettertypefamilie, stijl, grootte en kleur.