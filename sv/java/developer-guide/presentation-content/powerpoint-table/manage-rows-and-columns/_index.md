---
title: Hantera rader och kolumner i PowerPoint-tabeller med Java
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/java/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första rad
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- radtextformatering
- kolumntextformatering
- tabellstil
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för Java och snabba upp redigering av presentationer och datauppdateringar."
---
## **Introduktion**

För att du ska kunna hantera en tabells rader och kolumner i en PowerPoint‑presentation tillhandahåller Aspose.Slides klassen [Tabell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/table/) , gränssnittet [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable) och många andra typer.

## **Ange den första raden som rubrik**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och ladda presentationen.  
2. Hämta en bilds referens via dess index.  
3. Skapa ett [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)‑objekt och sätt det till null.  
4. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/)‑objekt för att hitta den relevanta tabellen.  
5. Ange tabellens första rad som dess rubrik.  

Den här Java‑koden visar hur du anger en tabells första rad som rubrik:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("table.pptx");
try {
    // Kommer åt den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Initierar null TableEx
    ITable tbl = null;

    // Itererar genom formerna och sätter en referens till tabellen
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Sätter den första raden i en tabell som rubrik
            tbl.setFirstRow(true);
        }
    }
    
    // Sparar presentationen till disk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Klona en tabellrad eller kolumn**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och ladda presentationen,  
2. Hämta en bilds referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Klona tabellraden.  
7. Klona tabellkolumnen.  
8. Spara den ändrade presentationen.  

Den här Java‑koden visar hur du klonar en PowerPoint‑tabells rad eller kolumn:

```java
 // Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("Test.pptx");
try {
    // Kommer åt den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredd och rader med höjd
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Lägger till en tabellform på bilden
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Lägger till lite text i rad 1 cell 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Lägger till lite text i rad 1 cell 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klona rad 1 i slutet av tabellen
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Lägger till lite text i rad 2 cell 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Lägger till lite text i rad 2 cell 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klona rad 2 som den 4:e raden i tabellen
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klona den första kolumnen i slutet
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klona den andra kolumnen på 4:e kolumnindex
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Sparar presentationen till disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort en rad eller kolumn från en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och ladda presentationen,  
2. Hämta en bilds referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Ta bort tabellraden.  
7. Ta bort tabellkolumnen.  
8. Spara den ändrade presentationen.  

Den här Java‑koden visar hur du tar bort en rad eller kolumn från en tabell:

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

## **Ange textformatering på radnivå för tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och ladda presentationen,  
2. Hämta en bilds referens via dess index.  
3. Hämta det relevanta [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)‑objektet från bilden.  
4. Ställ in de första radens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ställ in de första radens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Ställ in de andra radens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Spara den ändrade presentationen.  

Den här Java‑koden demonstrerar operationen.

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Anta att den första formen på den första bilden är en tabell
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Anger teckenhöjd för cellerna i första raden
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Anger textjustering och högermarginal för cellerna i första raden
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Anger vertikal texttyp för cellerna i andra raden
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Sparar presentationen till disk
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange textformatering på kolumnnivå för tabellen**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och ladda presentationen,  
2. Hämta en bilds referens via dess index.  
3. Hämta det relevanta [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)‑objektet från bilden.  
4. Ställ in de första kolumnens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ställ in de första kolumnens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Ställ in de andra kolumnens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Spara den ändrade presentationen.  

Den här Java‑koden demonstrerar operationen:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Anta att den första formen på den första bilden är en tabell
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Anger teckenhöjd för cellerna i första kolumnen
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Anger textjustering och högermarginal för cellerna i första kolumnen i ett anrop
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Anger vertikal texttyp för cellerna i andra kolumnen
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hämta stilegenskaper för tabellen**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Den här Java‑koden visar hur du får stilegenskaperna från en förinställd tabellstil:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // ändra standardstilens förinställda tema
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Kan jag applicera PowerPoint‑teman/-stilar på en tabell som redan är skapad?**

Ja. Tabellen ärver bild‑/layout‑/master‑temat, och du kan fortfarande åsidosätta fyllningar, ramar och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filter. Sortera dina data i minnet först, och fyll sedan på tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller egna färger på specifika celler?**

Ja. Aktivera bandade kolumner, och åsidosätt sedan specifika celler med lokal formatering; cellnivåformatering har företräde framför tabellstilen.