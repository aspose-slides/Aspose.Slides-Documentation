---
title: Beheer rijen en kolommen in PowerPoint‑tabellen op Android
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/androidjava/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkoptekst
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak van rij
- tekstopmaak van kolom
- tabelstijl
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor Android via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Introductie**

Om u in staat te stellen de rijen en kolommen van een tabel in een PowerPoint‑presentatie te beheren, biedt Aspose.Slides de klasse [Tabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/table/) en de interface [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable), en vele andere typen.

## **Stel de eerste rij in als koptekst**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en laad de presentatie.  
2. Haal een referentie naar een dia op via de index.  
3. Maak een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object aan en stel het in op null.  
4. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/) objecten om de betreffende tabel te vinden.  
5. Stel de eerste rij van de tabel in als koptekst.  

Deze Java‑code laat zien hoe u de eerste rij van een tabel als koptekst instelt:

```java
// Maak een instantie van de Presentation-klasse
Presentation pres = new Presentation("table.pptx");
try {
    // Benadert de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Initialiseert de null TableEx
    ITable tbl = null;

    // Itereert door de shapes en stelt een referentie naar de tabel in
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Stelt de eerste rij van een tabel in als koptekst
            tbl.setFirstRow(true);
        }
    }
    
    // Slaat de presentatie op naar schijf
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kopieer een tabelrij of -kolom**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object toe aan de dia via de methode [addTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Kopieer de tabelrij.  
7. Kopieer de tabelkolom.  
8. Sla de aangepaste presentatie op.  

Deze Java‑code laat zien hoe u een rij of kolom van een PowerPoint‑tabel kunt kopiëren:

```java
 // Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation("Test.pptx");
try {
    // Benadert de eerste dia
    ISlide sld = pres.getSlides().get_Item(0);

    // Definieert kolommen met breedtes en rijen met hoogtes
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Voegt een tabelvorm toe aan de dia
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Voegt tekst toe aan rij 1 cel 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Voegt tekst toe aan rij 1 cel 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Kloont rij 1 aan het einde van de tabel
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Voegt tekst toe aan rij 2 cel 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Voegt tekst toe aan rij 2 cel 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Kloont rij 2 als vierde rij van de tabel
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Kloont de eerste kolom aan het einde
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Kloont de tweede kolom op index 4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Slaat de presentatie op naar schijf
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Verwijder een rij of kolom uit een tabel**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Definieer een array van `columnWidth`.  
4. Definieer een array van `rowHeight`.  
5. Voeg een [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object toe aan de dia via de methode [addTable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Verwijder de tabelrij.  
7. Verwijder de tabelkolom.  
8. Sla de aangepaste presentatie op.  

Deze Java‑code laat zien hoe u een rij of kolom uit een tabel kunt verwijderen:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Stel tekstopmaak in op rijniveau van de tabel**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Toegang tot het relevante [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object van de dia.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) methode in voor de cellen van de eerste rij.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) methoden in voor de cellen van de eerste rij.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) methode in voor de cellen van de tweede rij.  
7. Sla de aangepaste presentatie op.  

Deze Java‑code toont de werking.

```java
// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Laten we aannemen dat de eerste shape op de eerste dia een tabel is
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Stelt de letterhoogte van de cellen in de eerste rij in
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Stelt de tekstuitlijning en rechtermarge van de cellen in de eerste rij in
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Stelt het verticale teksttype van de cellen in de tweede rij in
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Slaat de presentatie op naar schijf
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Stel tekstopmaak in op kolomniveau van de tabel**

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en laad de presentatie,  
2. Haal een referentie naar een dia op via de index.  
3. Toegang tot het relevante [ITable](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ITable) object van de dia.  
4. Stel de [setFontHeight(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) methode in voor de cellen van de eerste kolom.  
5. Stel de [setAlignment(int value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight(float value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) methoden in voor de cellen van de eerste kolom.  
6. Stel de [setTextVerticalType(byte value)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) methode in voor de cellen van de tweede kolom.  
7. Sla de aangepaste presentatie op.  

Deze Java‑code toont de werking:

```java
// Maakt een instantie van de Presentation-klasse
Presentation pres = new Presentation();
try {
    // Laten we aannemen dat de eerste shape op de eerste dia een tabel is
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Stelt de letterhoogte van de cellen in de eerste kolom in
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Stelt de tekstuitlijning en rechtermarge van de cellen in de eerste kolom in met één oproep
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Stelt het verticale teksttype van de cellen in de tweede kolom in
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Haal tabelstijl‑eigenschappen op**

Aspose.Slides maakt het mogelijk om de stijl‑eigenschappen van een tabel op te halen zodat u die details voor een andere tabel of elders kunt gebruiken. Deze Java‑code laat zien hoe u de stijl‑eigenschappen van een vooraf ingestelde tabelstijl kunt verkrijgen:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // wijzig het standaard stijl preset thema
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een reeds gemaakte tabel?**

Ja. De tabel erft het thema van de dia/layout/master, en u kunt nog steeds vullingen, randen en tekstkleuren overschrijven bovenop dat thema.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul daarna de tabelrijen opnieuw in in die volgorde.

**Kan ik gestreepte kolommen hebben terwijl ik aangepaste kleuren op specifieke cellen behoud?**

Ja. Schakel gestreepte kolommen in, en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.