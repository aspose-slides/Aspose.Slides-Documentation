---
title: Beheer tabelcellen in presentaties op Android
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/androidjava/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer tabelcellen moeiteloos in PowerPoint met Aspose.Slides voor Android via Java. Leer snel cellen openen, aanpassen en opmaken voor naadloze dia-automatisering."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te openen en te bewerken. Dit artikel beschrijft hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, de opmaak van cellen bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Een samengevoegde tabelcel identificeren**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse aan.
2. Haal de tabel op van de eerste dia.
3. Itereer door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.
4. Geef een bericht weer wanneer er samengevoegde cellen worden gevonden.

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // ervan uitgaande dat Slide#0.Shape#0 een tabel is
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabelcelranden verwijderen**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse aan.
2. Haal een verwijzing naar een dia op via de index.
3. Definieer een array van kolommen met breedte.
4. Definieer een array van rijen met hoogte.
5. Voeg een tabel toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) methode.
6. Itereer door elke cel om de boven‑, onder‑, rechter‑ en linkerranden te wissen.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

```java
// Maakt een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Schrijft het PPTX-bestand naar de schijf
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummering in samengevoegde cellen**
Als we twee paren cellen (1, 1) x (2, 1) en (1, 2) x (2, 2) samenvoegen, wordt de resulterende tabel genummerd. Deze Java‑code toont het proces:

```java
// Instancieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Voegt cellen (1, 1) en (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Voegt cellen (1, 2) en (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Vervolgens voegen we de cellen verder samen door (1, 1) en (1, 2) te combineren. Het resultaat is een tabel met een grote samengevoegde cel in het midden:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Voegt cellen (1, 1) en (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Voegt cellen (1, 2) en (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Voegt cellen (1, 1) en (1, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Schrijft het PPTX-bestand naar de schijf
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummering in een gesplitste cel**
In eerdere voorbeelden veranderde de nummering of het nummersysteem in andere cellen niet wanneer tabelcellen werden samengevoegd.

Deze keer nemen we een reguliere tabel (een tabel zonder samengevoegde cellen) en proberen we cel (1,1) te splitsen om een speciale tabel te krijgen. Let op de nummering van deze tabel, die misschien vreemd lijkt. Echter, dit is hoe Microsoft PowerPoint tabelcellen nummert en Aspose.Slides doet hetzelfde.

Deze Java‑code toont het beschreven proces:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Voegt cellen (1, 1) en (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Voegt cellen (1, 2) en (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Splits cel (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

	// Schrijft het PPTX-bestand naar de schijf
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De achtergrondkleur van een tabelcel wijzigen**
Deze Java‑code laat zien hoe u de achtergrondkleur van een tabelcel wijzigt:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // maak een nieuwe tabel
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // stel de achtergrondkleur in voor een cel
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Een afbeelding in een tabelcel plaatsen**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse aan.
2. Haal een verwijzing naar een dia op via de index.
3. Definieer een array van kolommen met breedte.
4. Definieer een array van rijen met hoogte.
5. Voeg een tabel toe aan de dia via de [AddTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) methode.
6. Maak een `Images`‑object aan om het afbeeldingsbestand op te slaan.
7. Voeg de `IImage`‑afbeelding toe aan het `IPPImage`‑object.
8. Stel het `FillFormat` van de tabelcel in op `Picture`.
9. Voeg de afbeelding toe aan de eerste cel van de tabel.
10. Sla de gewijzigde presentatie op als een PPTX‑bestand

Deze Java‑code laat zien hoe u een afbeelding in een tabelcel plaatst bij het maken van een tabel:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide islide = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Maak een IPPImage-object met het afbeeldingsbestand
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Voegt de afbeelding toe aan de eerste tabelcel
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Slaat het PPTX-bestand op op de schijf
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik verschillende lijndiktes en -stijlen instellen voor de verschillende zijden van één enkele cel?**

Ja. De [boven](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[onder](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[linker](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[rechter](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cellformat/#getBorderRight--) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kunnen verschillen. Dit volgt logisch uit de per‑zijde randconfiguratie voor een cel die in het artikel wordt gedemonstreerd.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [vullingsmodus](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/picturefillmode/) (stretch/tilen). Bij stretch past de afbeelding zich aan de nieuwe cel aan; bij tilen worden de tegels opnieuw berekend. Het artikel noemt de weergavemodi van afbeeldingen in een cel.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/androidjava/manage-hyperlinks/) worden ingesteld op tekstdelen (portion) binnen het tekstframe van de cel of op het niveau van de hele tabel/vorm. In de praktijk kent u de link toe aan een gedeelte of aan alle tekst in de cel.

**Kan ik verschillende lettertypen gebruiken binnen één enkele cel?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) (runs) met onafhankelijke opmaak – lettertypefamilie, stijl, grootte en kleur.