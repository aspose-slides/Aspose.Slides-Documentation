---
title: Hantera rader och kolumner i PowerPoint-tabeller på Android
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/androidjava/manage-rows-and-columns/
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
- Android
- Java
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för Android via Java och snabba upp redigering av presentationer och datauppdateringar."
---
## **Introduktion**

För att låta dig hantera en tabells rader och kolumner i en PowerPoint-presentation tillhandahåller Aspose.Slides klassen [Table](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/table/), gränssnittet [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITable) och många andra typer.

## **Ange den första raden som rubrik**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-klassen och läs in presentationen.  
2. Hämta en slides referens via dess index.  
3. Skapa ett [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITable)-objekt och sätt det till null.  
4. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)-objekt för att hitta den relevanta tabellen.  
5. Ange tabellens första rad som dess rubrik.  

Denna Java‑kod visar hur du anger en tabells första rad som rubrik:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("table.pptx");
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Initierar null TableEx
    ITable tbl = null;

    // Itererar genom formerna och sätter en referens till tabellen
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Sätter den första raden i en tabell som dess rubrik
            tbl.setFirstRow(true);
        }
    }
    
    // Sparar presentationen till disk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Klona en tabellrad eller -kolumn**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-klassen och läs in presentationen,  
2. Hämta en slides referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITable)-objekt på sliden via metoden [addTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Klona tabellraden.  
7. Klona tabellkolumnen.  
8. Spara den ändrade presentationen.  

Denna Java‑kod visar hur du klonar en PowerPoint‑tabells rad eller kolumn:

```java
 // Instansierar Presentation-klassen
Presentation pres = new Presentation("Test.pptx");
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredder och rader med höjder
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Lägger till en tabellform på bilden
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Lägger till text i rad 1 cell 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Lägger till text i rad 1 cell 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Klonar rad 1 i slutet av tabellen
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Lägger till text i rad 2 cell 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Lägger till text i rad 2 cell 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Klonar rad 2 som fjärde raden i tabellen
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Klonar första kolumnen i slutet
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Klonar andra kolumnen på fjärde kolumnindexet
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Sparar presentationen till disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort en rad eller kolumn från en tabell**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-klassen och läs in presentationen,  
2. Hämta en slides referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITable)-objekt på sliden via metoden [addTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Ta bort tabellraden.  
7. Ta bort tabellkolumnen.  
8. Spara den ändrade presentationen.  

Denna Java‑kod visar hur du tar bort en rad eller kolumn från en tabell:

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

## **Ange textformatering på radnivå i tabellen**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-klassen och läs in presentationen,  
2. Hämta en slides referens via dess index.  
3. Åtkomst till det relevanta [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITable)-objektet från sliden.  
4. Ange första‑radens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ange första‑radens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Ange andra‑radens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Spara den ändrade presentationen.  

Denna Java‑kod demonstrerar operationen.

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Låt oss anta att den första formen på den första bilden är en tabell
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Anger den första radens cellers teckenhöjd
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Anger den första radens cellers textjustering och högermarginal
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Anger den andra radens cellers vertikala texttyp
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Sparar presentationen till disk
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange textformatering på kolumnnivå i tabellen**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-klassen och läs in presentationen,  
2. Hämta en slides referens via dess index.  
3. Åtkomst till det relevanta [ITable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ITable)-objektet från sliden.  
4. Ange första‑kolumnens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ange första‑kolumnens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Ange andra‑kolumnens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Spara den ändrade presentationen.  

Denna Java‑kod demonstrerar operationen:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Låt oss anta att den första formen på den första bilden är en tabell
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Anger den första kolumnens cellers teckenhöjd
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Anger den första kolumnens cellers textjustering och högermarginal i ett anrop
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Anger den andra kolumnens cellers vertikala texttyp
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hämta tabellens stilegenskaper**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna Java‑kod visar hur du får stilegenskaperna från en förinställd tabellstil:

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

**Kan jag tillämpa PowerPoint‑teman/stilar på en redan skapad tabell?**

Ja. Tabellen ärver slide/layout/master‑temat, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filter. Sortera dina data i minnet först, och fyll sedan på tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner, och överskriv sedan specifika celler med lokal formatering; cellnivåformatering har företräde framför tabellstilen.