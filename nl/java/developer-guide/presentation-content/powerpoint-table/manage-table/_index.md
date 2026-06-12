---
title: Beheer presentatietabellen in Java
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/java/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel openen
- beeldverhouding
- tekst uitlijnen
- tekst opmaak
- tabelstijl
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor Java. Ontdek eenvoudige codevoorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (gerangschikt in rijen en kolommen) is eenvoudig en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Table) klasse, [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) interface, [Cell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/cell/) klasse, [ICell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icell/) interface, en andere typen die u in staat stellen tabellen te maken, bij te werken en te beheren in alle soorten presentaties. 

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) methode.  
6. Itereer door elke [ICell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icell/) om opmaak toe te passen op de boven-, onder-, rechter- en linker randen.  
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.  
8. Toegang krijgen tot de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/) van een [ICell](https://reference.aspose.com/slides/nl/java/com.aspose.slides/icell/).  
9. Voeg wat tekst toe aan de [TextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

Deze Java-code toont hoe u een tabel in een presentatie maakt:

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Stelt het randformaat in voor elke cel
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Voegt cellen 1 en 2 van rij 1 samen
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Voegt tekst toe aan de samengevoegde cel
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Slaat de presentatie op op schijf
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nulgebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0). 

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze Java-code toont hoe u de nummering voor cellen in een tabel specificeert:

```java
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
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

    // Slaat de presentatie op schijf
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  

2. Haal een referentie naar de dia op die de tabel bevat via de index.  

3. Maak een [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) object aan en stel deze in op null.  

4. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/) objecten totdat de tabel is gevonden.  

   Als u vermoedt dat de dia waarmee u werkt slechts één tabel bevat, kunt u eenvoudig alle vormen die de dia bevat controleren. Wanneer een vorm wordt geïdentificeerd als een tabel, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Table) object. Maar als de dia meerdere tabellen bevat, zoekt u beter naar de gewenste tabel via de [setAlternativeText(String value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).  

5. Gebruik het [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) object om met de tabel te werken. In het onderstaande voorbeeld hebben we een nieuwe rij aan de tabel toegevoegd.  

6. Sla de gewijzigde presentatie op.

Deze Java-code toont hoe u toegang krijgt tot en werkt met een bestaande tabel:

```java
// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Toegang tot de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialiseert null TableEx
    ITable tbl = null;

    // Itereert door de shapes en zet een referentie naar de gevonden tabel
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Stelt de tekst in voor de eerste kolom van de tweede rij
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Slaat de gewijzigde presentatie op schijf
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) object toe aan de dia.  
4. Verkrijg een [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) object uit de tabel.  
5. Toegang tot de [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) van het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.

Deze Java-code toont hoe u de tekst in een tabel uitlijnt:

```java
// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Haalt de eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Voegt de tabelvorm toe aan de dia
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Toegang tot het tekstframe
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Maakt het Paragraph-object voor het tekstframe
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Maakt het Portion-object voor de alinea
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Lijnt de tekst verticaal uit
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Slaat de presentatie op schijf
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Toegang tot een [ITable](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ITable) object van de dia.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) in voor de tekst.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) in.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) in.  
7. Sla de gewijzigde presentatie op. 

Deze Java-code toont hoe u uw voorkeurformatteringstoepassingen op de tekst in een tabel kunt toepassen:

```java
// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Laten we aannemen dat de eerste shape op de eerste dia een tabel is
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Stelt de letterhoogte van de tabelcellen in
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Stelt de tekstuitlijning en de rechter marge van de tabelcellen in één oproep in
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Stelt het verticale teksttype van de tabelcellen in
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabelstijl‑eigenschappen ophalen**

Aspose.Slides stelt u in staat de stijl‑eigenschappen van een tabel op te halen zodat u die details kunt gebruiken voor een andere tabel of ergens anders. Deze Java-code toont hoe u de stijl‑eigenschappen van een vooraf ingestelde tabelstijl kunt ophalen:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // wijzigt het standaard stijlvoorinstellingsthema 
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vergrendel de beeldverhouding van een tabel**

De beeldverhouding van een geometrische vorm is de verhouding van de afmetingen in verschillende dimensies. Aspose.Slides biedt de eigenschap [**setAspectRatioLocked**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) om de instelling van de beeldverhouding voor tabellen en andere vormen te vergrendelen. 

Deze Java-code toont hoe u de beeldverhouding voor een tabel vergrendelt:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // omkeren

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik de leesrichting van rechts naar links (RTL) voor een volledige tabel en de tekst in de cellen inschakelen?**

Ja. De tabel heeft een [setRightToLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/table/#setRightToLeft-boolean-) methode, en alinea's hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Door beide te gebruiken wordt de correcte RTL-volgorde en weergave binnen cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel verplaatsen of de grootte ervan wijzigen in het uiteindelijke bestand?**

Gebruik [shape locks](/slides/nl/java/applying-protection-to-presentation/) om verplaatsen, grootte wijzigen, selectie, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/java/com.aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding zal het celgebied bedekken volgens de gekozen modus (uitrekken of tegelen).