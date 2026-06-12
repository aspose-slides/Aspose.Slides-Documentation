---
title: Beheer tabelcellen in presentaties met Java
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/java/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer tabelcellen moeiteloos in PowerPoint met Aspose.Slides voor Java. Leer snel toegang, wijziging en opmaak van cellen voor naadloze dia‑automatisering."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia haalt, de celopmaak via cel‑eigenschappen bijwerkt en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Identificeer een samengevoegde tabelcel**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan.  
2. Haal de tabel op van de eerste dia.  
3. Itereer door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.  
4. Print een bericht wanneer samengevoegde cellen worden gevonden.  

Deze Java‑code laat zien hoe u samengevoegde tabelcellen in een presentatie kunt identificeren:

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
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van kolommen met breedte.  
4. Definieer een array van rijen met hoogte.  
5. Voeg een tabel toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) methode.  
6. Itereer door elke cel om de boven‑, onder‑, rechts‑ en linkerranden te wissen.  
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.  

Deze Java‑code laat zien hoe u de randen van tabelcellen kunt verwijderen:

```java
// Maakt een instantie van de Presentation‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Benadert de eerste dia
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

    // Schrijft de PPTX naar schijf
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummering in samengevoegde cellen**
Als we twee paren cellen (1, 1) x (2, 1) en (1, 2) x (2, 2) samenvoegen, wordt de resulterende tabel genummerd. Deze Java‑code demonstreert het proces:

```java
// Instantieert de Presentation‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Benadert de eerste dia
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

    // Voegt cellen (1, 1) x (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Voegt cellen (1, 2) x (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Vervolgens voegen we de cellen verder samen door (1, 1) en (1, 2) te combineren. Het resultaat is een tabel met een grote samengevoegde cel in het midden:

```java
// Instantieert de Presentation‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Benadert de eerste dia
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

    // Voegt cellen (1, 1) x (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Voegt cellen (1, 2) x (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Voegt cellen (1, 1) x (1, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    
	// Schrijft het PPTX‑bestand naar schijf
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummering in een gesplitste cel**
Bij eerdere voorbeelden werden, wanneer tabelcellen samengevoegd werden, de nummering of het talstelsel in andere cellen niet aangepast.  

Deze keer nemen we een gewone tabel (een tabel zonder samengevoegde cellen) en proberen vervolgens cel (1,1) te splitsen om een speciale tabel te verkrijgen. Let op de nummering van deze tabel, die wellicht vreemd lijkt. Echter, dit is de manier waarop Microsoft PowerPoint tabelcellen nummeren en Aspose.Slides doet hetzelfde.  

Deze Java‑code demonstreert het beschreven proces:

```java
// Instantieert de Presentation‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Benadert de eerste dia
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

    // Voegt cellen (1, 1) x (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Voegt cellen (1, 2) x (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Splitst cel (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Schrijft het PPTX‑bestand naar schijf
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **De achtergrondkleur van een tabelcel wijzigen**

Deze Java‑code laat zien hoe u de achtergrondkleur van een tabelcel kunt wijzigen:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // maak een nieuwe tabel
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // stel de achtergrondkleur voor een cel in
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Een afbeelding in een tabelcel toevoegen**
1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van kolommen met breedte.  
4. Definieer een array van rijen met hoogte.  
5. Voeg een tabel toe aan de dia via de [AddTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) methode.  
6. Maak een `Images`‑object aan om het afbeeldingsbestand op te slaan.  
7. Voeg de `IImage`‑afbeelding toe aan het `IPPImage`‑object.  
8. Stel de `FillFormat` voor de tabelcel in op `Picture`.  
9. Voeg de afbeelding toe aan de eerste cel van de tabel.  
10. Sla de gewijzigde presentatie op als een PPTX‑bestand  

Deze Java‑code laat zien hoe u bij het maken van een tabel een afbeelding in een tabelcel kunt plaatsen:

```java
// Instantieert de Presentation‑klasse die een PPTX‑bestand voorstelt
Presentation pres = new Presentation();
try {
    // Benadert de eerste dia
    ISlide islide = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Maak een IPPImage‑object aan met het afbeeldingsbestand
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

    // Slaat het PPTX‑bestand op naar schijf
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cellformat/#getBorderRight--) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen. Dit volgt logisch uit de per‑zijde randbesturing voor een cel die in het artikel wordt gedemonstreerd.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rij‑grootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/nl/java/com.aspose.slides/picturefillmode/) (stretch/tile). Bij uitrekken past de afbeelding zich aan de nieuwe cel aan; bij betegeling worden de tegels opnieuw berekend. Het artikel noemt de weergavemodi van afbeeldingen in een cel.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/java/manage-hyperlinks/) worden ingesteld op tekst‑(portion)niveau binnen het tekstframe van de cel of op het niveau van de volledige tabel/vorm. In de praktijk wijst u de link toe aan een gedeelte of aan alle tekst in de cel.

**Kan ik verschillende lettertypes binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) (runs) met onafhankelijke opmaak — lettertypefamilie, stijl, grootte en kleur.