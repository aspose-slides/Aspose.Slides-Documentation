---
title: Beheer rijen en kolommen in PowerPoint-tabellen met JavaScript
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/nodejs-java/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak rij
- tekstopmaak kolom
- tabelstijl
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met JavaScript en Aspose.Slides voor Node.js via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Introductie**

Om u in staat te stellen de rijen en kolommen van een tabel in een PowerPoint‑presentatie te beheren, biedt Aspose.Slides de klasse [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/) en andere typen.

## **Eerste rij als koptekst instellen**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) aan en laad de presentatie.  
2. Haal de referentie van een dia op via de index.  
3. Maak een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table)‑object aan en stel het in op null.  
4. Itereer door alle [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/)‑objecten om de betreffende tabel te vinden.  
5. Stel de eerste rij van de tabel in als koptekst.  

Deze JavaScript‑code toont hoe u de eerste rij van een tabel als koptekst instelt:

```javascript
// Instantieert de Presentation-klasse
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Initialiseert de null TableEx
    var tbl = null;
    // Iterateert door de shapes en zet een referentie naar de tabel
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Stelt de eerste rij van een tabel in als koptekst
            tbl.setFirstRow(true);
        }
    }
    // Slaat de presentatie op naar schijf
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rij of kolom van tabel klonen**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) aan en laad de presentatie,  
2. Haal de referentie van een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table)‑object toe aan de dia via de methode [addTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Kloon de tabelrij.  
7. Kloon de tabelkolom.  
8. Sla de gewijzigde presentatie op.  

Deze JavaScript‑code toont hoe u een rij of kolom van een PowerPoint‑tabel kloont:

```javascript
// Instantieert de Presentation-klasse
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Voegt een tabelvorm toe aan de dia
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Voegt wat tekst toe aan rij 1 cel 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Voegt wat tekst toe aan rij 1 cel 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Kloont rij 1 aan het einde van de tabel
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Voegt wat tekst toe aan rij 2 cel 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Voegt wat tekst toe aan rij 2 cel 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Kloont rij 2 als vierde rij van de tabel
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Kloont de eerste kolom aan het einde
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Kloont de tweede kolom op de vierde kolomindex
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Slaat de presentatie op naar schijf
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rij of kolom uit tabel verwijderen**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) aan en laad de presentatie,  
2. Haal de referentie van een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table)‑object toe aan de dia via de methode [addTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Verwijder de tabelrij.  
7. Verwijder de tabelkolom.  
8. Sla de gewijzigde presentatie op.  

Deze JavaScript‑code toont hoe u een rij of kolom uit een tabel verwijdert:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tekstopmaak op rijniveau van tabel instellen**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) aan en laad de presentatie,  
2. Haal de referentie van een dia op via de index.  
3. Verkrijg het relevante [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table)‑object van de dia.  
4. Stel de cellen van de eerste rij in op [setFontHeight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Stel de cellen van de eerste rij in op [setAlignment(int value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Stel de cellen van de tweede rij in op [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Sla de gewijzigde presentatie op.  

Deze JavaScript‑code demonstreert de bewerking.

```javascript
// Maakt een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Stelt de letterhoogte van de cellen in de eerste rij in
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Stelt de tekstuitlijning en de rechtermarge van de cellen in de eerste rij in
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Stelt het verticale tekstype van de cellen in de tweede rij in
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Slaat de presentatie op naar schijf
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tekstopmaak op kolomniveau van tabel instellen**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) aan en laad de presentatie,  
2. Haal de referentie van een dia op via de index.  
3. Verkrijg het relevante [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Table)‑object van de dia.  
4. Stel de cellen van de eerste kolom in op [setFontHeight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Stel de cellen van de eerste kolom in op [setAlignment(int value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Stel de cellen van de tweede kolom in op [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Sla de gewijzigde presentatie op.  

Deze JavaScript‑code demonstreert de bewerking:

```javascript
// Maakt een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Laten we aannemen dat de eerste vorm op de eerste dia een tabel is
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Stelt de letterhoogte van de cellen in de eerste kolom in
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Stelt de tekstuitlijning en de rechtermarge van de cellen in de eerste kolom in één keer
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Stelt het verticale teksttype van de cellen in de tweede kolom in
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tabelstijleigenschappen ophalen**

Aspose.Slides stelt u in staat de stijleigenschappen van een tabel op te halen zodat u die details voor een andere tabel of elders kunt gebruiken. Deze JavaScript‑code toont hoe u de stijleigenschappen van een vooraf ingestelde tabelstijl ophaalt:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// wijzig de standaard stijlvoorgave
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een tabel die al gemaakt is?**

Ja. De tabel erft het thema van de dia/lay‑out/master, en u kunt nog steeds vullingen, randen en tekstopmaken bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, tabellen van Aspose.Slides hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen opnieuw in in die volgorde.

**Kan ik gestreepte kolommen hebben terwijl ik aangepaste kleuren voor specifieke cellen behoud?**

Ja. Schakel gestreepte kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.