---
title: Beheer presentatietabellen in JavaScript
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/nodejs-java/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel openen
- aspectratio
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Tabellen maken en bewerken in PowerPoint-dia's met JavaScript en Aspose.Slides voor Node.js. Ontdek eenvoudige codevoorbeelden om uw tabelwerkstromen te stroomlijnen."
---
## **Inleiding**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (geordend in rijen en kolommen) is duidelijk en gemakkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) klasse, de [Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/) klasse en andere typen waarmee u tabellen kunt maken, bijwerken en beheren in allerlei presentaties.

## **Tabel maken vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een slide op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object toe aan de slide via de [addTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) methode.  
6. Itereer door elke [Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechter- en linker randen.  
7. Voeg de vier cellen in de linkerbovenhoek van de tabel (de eerste twee kolommen van de eerste twee rijen) samen tot één cel.  
8. Verkrijg de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) van een [Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/).  
9. Voeg tekst toe aan de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).  
10. Sla de gewijzigde presentatie op.

Deze JavaScript‑code laat zien hoe u een tabel in een presentatie maakt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantie van de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste slide
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Voegt een tabelvorm toe aan de slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Stelt het randformaat in voor elke cel
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Voegt het 2x2‑blok linksboven van cellen samen tot één cel
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Voegt tekst toe aan de samengevoegde cel
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Slaat de presentatie op naar de schijf
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nummering in een standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nul‑gebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze JavaScript‑code laat zien hoe u de nummering van cellen in een tabel specificeert:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste slide
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Voegt een tabelvorm toe aan de slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Stelt het randformaat in voor elke cel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Slaat de presentatie op naar de schijf
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bestaande tabel benaderen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar de slide die de tabel bevat op via de index.  
3. Maak een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object aan en zet het op null.  
4. Itereer door alle [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) objecten totdat de tabel gevonden is.  

   Als u vermoedt dat de slide waarmee u werkt een enkele tabel bevat, kunt u eenvoudig alle shapes die erin zitten controleren. Wanneer een shape wordt geïdentificeerd als een tabel, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object. Maar als de slide meerdere tabellen bevat, is het beter om de gewenste tabel te zoeken via zijn [setAlternativeText(String value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).  

5. Gebruik het [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object om met de tabel te werken. In het voorbeeld hieronder stellen we de tekst van een cel in de tabel in.  
6. Sla de gewijzigde presentatie op.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Toegang tot de eerste slide
    var sld = pres.getSlides().get_Item(0);
    // Initialiseert null TableEx
    var tbl = null;
    // Itereert door de shapes en zet een referentie naar de gevonden tabel
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Stelt de tekst in voor de eerste kolom van de tweede rij
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Slaat de gewijzigde presentatie op op schijf
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zoek de cel die een TextFrame bezit**

Wanneer generieke tekstverwerkingscode een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) uit een tabel ontvangt, gebruikt u de [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentCell--) methode om de eigenaar‑[Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/) op te halen. Voor een textframe in een tabelcel geeft [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentCell--) de eigenaar terug en geeft [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentShape--) `null` terug, hoewel de tabel zelf een shape is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen methoden [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) en [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentCell--) biedt ook alleen‑lezen navigatie: het retourneert de eigenaar maar wijzigt de eigendom niet. Controleer altijd of de geretourneerde cel niet `null` is voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabelcel‑ en shape‑eigenaars identificeert, inclusief shapes die gekoppeld zijn aan SmartArt‑nodes, zie [Search and Replace Text](/slides/nl/nodejs-java/search-and-replace-text/).

## **Tekst uitlijnen in tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een slide op via de index.  
3. Voeg een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object toe aan de slide.  
4. Verkrijg een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) object uit de tabel.  
5. Verkrijg de [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) van het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).  
6. Lijn de tekst verticaal uit.  
7. Sla de gewijzigde presentatie op.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Maakt een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste slide op
    var slide = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Voegt de tabelvorm toe aan de slide
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Toegang tot het tekstframe
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Maakt het Paragraph-object voor het tekstframe
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Maakt het Portion-object voor de alinea
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Lijnt de tekst verticaal uit
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Slaat de presentatie op naar de schijf
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse aan.  
2. Haal een referentie naar een slide op via de index.  
3. Verkrijg een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object van de slide.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) in voor de tekst.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) in.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) in.  
7. Sla de gewijzigde presentatie op.  

```javascript
// Maakt een instantie van de Presentation‑klasse
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Laten we aannemen dat de eerste shape op de eerste slide een tabel is
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Stelt de letterhoogte van de tabelcellen in
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Stelt de tekstuitlijning en de rechter marge van de tabelcellen in één oproep in
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Stelt het verticale type van de tabelcellen in
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vooraf ingestelde tabelstijl instellen**

Aspose.Slides levert de ingebouwde PowerPoint‑tabelstijlen aan als de [TableStylePreset](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tablestylepreset/) enumeratie, zodat u dezelfde uitstraling op elke tabel kunt toepassen. Deze JavaScript‑code laat zien hoe u de standaardstijl van een tabel vervangt door een vooraf ingestelde stijl:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// wijzig het standaard stijlvoorinstellingsthema
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vergrendel Aspectratio van Tabel**

De aspectratio van een geometrische vorm is de verhouding van de afmetingen in verschillende dimensies. Aspose.Slides biedt de eigenschap [**setAspectRatioLocked**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) om de aspectratio‑instelling voor tabellen en andere vormen te vergrendelen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik de leesrichting van rechts naar links (RTL) inschakelen voor een volledige tabel en de tekst in de cellen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/setrighttoleft/) methode, en alinea's hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Door beide te gebruiken wordt de correcte RTL‑volgorde en weergave in de cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of wijzigen van grootte?**

Gebruik shape‑vergrendelingen om verplaatsen, vergroten/verkleinen, selecteren, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding als achtergrond in een cel ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding bedekt het celgebied volgens de gekozen modus (rekken of tegel).