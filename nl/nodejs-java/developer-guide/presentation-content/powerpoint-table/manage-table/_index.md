---
title: Beheer presentatietabellen in JavaScript
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/nodejs-java/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel benaderen
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint‑dia's met JavaScript en Aspose.Slides voor Node.js. Ontdek eenvoudige code‑voorbeelden om uw tabel‑werkstromen te stroomlijnen."
---
## **Introductie**

Een tabel in PowerPoint is een efficiënte manier om informatie weer te geven en te presenteren. De informatie in een raster van cellen (geordend in rijen en kolommen) is eenvoudig en makkelijk te begrijpen.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) klasse, [Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/) klasse en andere typen om u in staat te stellen tabellen te maken, bij te werken en te beheren in allerlei presentaties.

## **Tabel maken vanaf nul**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar de dia op via de index. 
3. Definieer een array van `columnWidth`.
4. Definieer een array van `rowHeight`.
5. Voeg een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) methode.
6. Iterate door elke [Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/) om opmaak toe te passen op de boven-, onder-, rechter- en linkerrand.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Benader een [Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).
9. Voeg tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).
10. Sla de gewijzigde presentatie op.

Deze JavaScript‑code laat zien hoe u een tabel in een presentatie maakt:
```javascript
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Benadert de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Voegt een tabelvorm toe aan de dia
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
    // Voegt cellen 1 en 2 van rij 1 samen
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

## **Nummering in standaardtabel**

In een standaardtabel is de nummering van cellen eenvoudig en nulgebaseerd. De eerste cel in een tabel heeft de index 0,0 (kolom 0, rij 0). 

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden als volgt genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Deze JavaScript‑code laat zien hoe u de nummering voor cellen in een tabel specificeert:
```javascript
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Benadert de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Voegt een tabelvorm toe aan de dia
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

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.

2. Haal een verwijzing naar de dia die de tabel bevat via de index. 

3. Maak een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object aan en zet het op null.

4. Iterate door alle [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) objecten totdat de tabel is gevonden.

   Als u vermoedt dat de dia waarmee u werkt één tabel bevat, kunt u eenvoudig alle vormen die de dia bevat controleren. Wanneer een vorm wordt herkend als een tabel, kunt u deze casten naar een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object. Maar als de dia verschillende tabellen bevat, kunt u beter zoeken naar de gewenste tabel via de [setAlternativeText(String value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Gebruik het [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object om met de tabel te werken. In het onderstaande voorbeeld hebben we een nieuwe rij aan de tabel toegevoegd.

6. Sla de gewijzigde presentatie op.

Deze JavaScript‑code laat zien hoe u een bestaande tabel benadert en ermee werkt:
```javascript
// Instantieert de Presentation-klasse die een PPTX-bestand vertegenwoordigt
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Benadert de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Initialiseert null TableEx
    var tbl = null;
    // Itereert door de vormen en stelt een verwijzing in naar de gevonden tabel
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Stelt de tekst in voor de eerste kolom van de tweede rij
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Slaat de gewijzigde presentatie op naar de schijf
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tekst uitlijnen in tabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar de dia op via de index. 
3. Voeg een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object toe aan de dia.
4. Benader een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) object uit de tabel.
5. Benader de [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/).
6. Lijn de tekst verticaal uit.
7. Sla de gewijzigde presentatie op.

Deze JavaScript‑code laat zien hoe u de tekst in een tabel uitlijnt:
```javascript
// Maakt een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Haalt de eerste dia op
    var slide = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Voegt de tabelvorm toe aan de dia
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Benadert het tekstframe
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
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Slaat de presentatie op naar de schijf
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tekstopmaak instellen op tabelniveau**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) klasse.
2. Haal een verwijzing naar de dia op via de index. 
3. Benader een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table) object van de Slide.
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) in voor de tekst.
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) in.
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) in.
7. Sla de gewijzigde presentatie op. 

Deze JavaScript‑code laat zien hoe u uw gewenste opmaakopties toepast op de tekst in een tabel:
```javascript
// Maakt een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Stelt de letterhoogte van de tabelcellen in
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Stelt de tekstuitlijning en rechter marge van de tabelcellen in één oproep in
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Stelt het verticale type van de tabelceltekst in
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tabelstijleigenschappen ophalen**

Aspose.Slides stelt u in staat de stijleigenschappen van een tabel op te halen zodat u die details voor een andere tabel of elders kunt gebruiken. Deze JavaScript‑code laat zien hoe u de stijleigenschappen van een vooraf ingestelde tabelstijl verkrijgt:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// wijzig het standaard stijl‑preset thema
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Beeldverhouding van tabel vergrendelen**

De beeldverhouding van een geometrische vorm is de verhouding van de afmetingen in verschillende dimensies. Aspose.Slides biedt de [**setAspectRatioLocked**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) eigenschap om de beeldverhouding voor tabellen en andere vormen te vergrendelen.

Deze JavaScript‑code laat zien hoe u de beeldverhouding voor een tabel vergrendelt:
```javascript
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

**Kan ik de lezerichting van rechts naar links (RTL) inschakelen voor een hele tabel en de tekst in de cellen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/setrighttoleft/) methode, en alinea's hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of van grootte wijzigen?**

Gebruik vormvergrendelingen om verplaatsen, grootte wijzigen, selectie, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding zal het celgebied bedekken volgens de gekozen modus (uitrekken of betegelen).