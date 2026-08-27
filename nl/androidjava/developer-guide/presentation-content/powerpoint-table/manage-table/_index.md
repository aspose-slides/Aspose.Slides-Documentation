---
title: Beheer presentatietabellen op Android
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/androidjava/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel benaderen
- aspectverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak en bewerk tabellen in PowerPoint‑dia’s met Aspose.Slides voor Android. Ontdek eenvoudige Java‑code‑voorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (geordend in rijen en kolommen) is duidelijk en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Table) klasse, de [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) interface, de [Cell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/cell/) klasse, de [ICell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/) interface en andere types om u in staat te stellen tabellen te maken, bij te werken en te beheren in allerlei presentaties.

## **Maak een tabel vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-) methode.  
6. Itereer door elke [ICell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/) om opmaak toe te passen op de boven-, onder-, rechter- en linker randen.  
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.  
8. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/) van een [ICell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/).  
9. Voeg wat tekst toe aan de [TextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Benadert de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Stelt de randopmaak in voor elke cel
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Voegt wat tekst toe aan de samengevoegde cel
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Slaat de presentatie op naar schijf
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nulgebaseerd. De eerste cel in een tabel heeft index 0,0 (kolom 0, rij 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze Java‑code laat zien hoe u de nummering voor cellen in een tabel specificeert:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Benadert de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Voegt een tabelvorm toe aan de dia
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Stelt de randopmaak in voor elke cel
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

    // Slaat de presentatie op naar schijf
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Toegang tot een bestaande tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar de dia die de tabel bevat via de index.  
3. Maak een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object aan en zet deze op null.  
4. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) objecten tot de tabel wordt gevonden.  

   Als u vermoedt dat de dia waarmee u werkt slechts één tabel bevat, kunt u eenvoudig alle vormen die de dia bevat controleren. Wanneer een vorm als een tabel wordt geïdentificeerd, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Table) object. Maar als de dia meerdere tabellen bevat, zoekt u beter de gewenste tabel via zijn [setAlternativeText(String value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).  

5. Gebruik het [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object om met de tabel te werken. In het onderstaande voorbeeld stellen we de tekst van een cel in de tabel in.  
6. Sla de gewijzigde presentatie op.

```java
import com.aspose.slides.*;

// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Benadert de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialiseert null TableEx
    ITable tbl = null;

    // Itereert door de vormen en zet een referentie naar de gevonden tabel
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Stelt de tekst in voor de eerste kolom van de tweede rij
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Slaat de gewijzigde presentatie op naar schijf
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoek de cel die een tekstframe bezit**

Wanneer algemene tekstverwerkingscode een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van een tabel ontvangt, gebruik dan de [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentCell--) methode om de bijbehorende [ICell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/) op te halen. Voor een tabel‑celtekstframe geeft [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentCell--) de eigenaar terug en geeft [ITextFrame.getParentShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` terug, ook al is de tabel zelf een vorm.

De celcoördinaten zijn beschikbaar via de alleen‑lees [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) en [ICell.getFirstRowIndex](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) methoden. [ITextFrame.getParentCell](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getParentCell--) biedt ook alleen‑lees navigatie: het retourneert de eigenaar maar wijzigt de eigendom niet. Controleer altijd of de geretourneerde cel `null` is voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabel‑cel- en vorm‑eigenaars identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knopen, zie [Search and Replace Text](/slides/nl/androidjava/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Voeg een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object toe aan de dia.  
4. Toegang tot een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) object uit de tabel.  
5. Toegang tot de [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) van het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Maakt een instantie van de Presentation‑klasse
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
    
    // Benadert het tekstframe
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Creëert het Paragraph‑object voor het tekstframe
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Creëert het Portion‑object voor de alinea
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Lijnt de tekst verticaal uit
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Slaat de presentatie op naar schijf
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation) klasse.  
2. Haal een referentie naar een dia op via de index.  
3. Toegang tot een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object van de dia.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) in voor de tekst.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) in.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) in.  
7. Sla de gewijzigde presentatie op.

```java
import com.aspose.slides.*;

// Maakt een instantie van de Presentation‑klasse
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Stelt de letterhoogte van de tabelcellen in
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Stelt de tekstuitlijning en rechter marge van de tabelcellen in één oproep in
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Stelt het verticale type van de tekst in de tabelcellen in
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tabelstijl‑eigenschappen ophalen**

Aspose.Slides stelt u in staat om de stijl‑eigenschappen van een tabel op te halen zodat u die details kunt gebruiken voor een andere tabel of elders. Deze Java‑code laat zien hoe u de stijl‑eigenschappen van een vooraf ingestelde tabelstijl kunt verkrijgen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // wijzig het standaard stijlvoorinstellingsthema 

    // Haal de stijlvoorinstelling van de tabel op
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Pas de opgehaalde stijlvoorinstelling toe op een andere tabel
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aspectverhouding van een tabel vergrendelen**

De aspectverhouding van een geometrische vorm is de verhouding van zijn afmetingen in verschillende dimensies. Aspose.Slides biedt de [**setAspectRatioLocked**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) eigenschap om u in staat te stellen de instelling voor de aspectverhouding van tabellen en andere vormen te vergrendelen.

```java
import com.aspose.slides.*;

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

**Kan ik de leesrichting van rechts‑naar‑links (RTL) inschakelen voor een hele tabel en de tekst in de cellen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) methode, en alinea’s hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Het gebruik van beide zorgt voor de correcte RTL‑volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of vergroten/verkleinen?**

Gebruik vorm‑vergrendelingen om verplaatsen, schalen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding bedekt het celgebied volgens de gekozen modus (uitrekken of tegel).