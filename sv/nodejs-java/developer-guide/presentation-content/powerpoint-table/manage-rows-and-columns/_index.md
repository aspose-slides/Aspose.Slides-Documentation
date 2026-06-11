---
title: Hantera rader och kolumner i PowerPoint‑tabeller med JavaScript
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/nodejs-java/manage-rows-and-columns/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med JavaScript och Aspose.Slides för Node.js via Java och snabbare redigering av presentationer samt datauppdateringar."
---
## **Introduktion**

För att låta dig hantera en tabells rader och kolumner i en PowerPoint‑presentation tillhandahåller Aspose.Slides klassen [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/) samt andra typer.

## **Ange första raden som rubrik**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och läs in presentationen.  
2. Hämta en bilds referens via dess index.  
3. Skapa ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)‑objekt och sätt det till null.  
4. Iterera igenom alla [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)‑objekt för att hitta den relevanta tabellen.  
5. Ange tabellens första rad som dess rubrik.  

Denna JavaScript‑kod visar hur du anger en tabells första rad som rubrik:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Initierar TableEx till null
    var tbl = null;
    // Itererar genom formerna och sätter en referens till tabellen
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Anger den första raden i en tabell som rubrik
            tbl.setFirstRow(true);
        }
    }
    // Sparar presentationen till disk
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Klona tabellens rad eller kolumn**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Klona tabellraden.  
7. Klona tabellkolumnen.  
8. Spara den ändrade presentationen.  

Denna JavaScript‑kod visar hur du klonar en PowerPoint‑tabells rad eller kolumn:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredder och rader med höjder
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Lägger till en tabellform på bilden
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Lägger till lite text i rad 1 cell 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Lägger till lite text i rad 1 cell 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Klonar rad 1 i slutet av tabellen
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Lägger till lite text i rad 2 cell 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Lägger till lite text i rad 2 cell 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Klonar rad 2 som den 4:e raden i tabellen
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Klonar första kolumnen i slutet
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Klonar 2:a kolumnen på den 4:e kolumnindexen
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Sparar presentationen till disk
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort rad eller kolumn från tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Definiera en array av `columnWidth`.  
4. Definiera en array av `rowHeight`.  
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)‑objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Ta bort tabellraden.  
7. Ta bort tabellkolumnen.  
8. Spara den ändrade presentationen.  

Denna JavaScript‑kod visar hur du tar bort en rad eller kolumn från en tabell:

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

## **Ange textformatering på radnivå i tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Åtkomst till det relevanta [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)‑objektet från bilden.  
4. Ange de första radens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ange de första radens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Ange de andra radens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Spara den ändrade presentationen.  

Denna JavaScript‑kod demonstrerar operationen.

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Låt oss anta att den första formen på den första bilden är en tabell
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Sätter teckenhöjden för cellerna i första raden
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Ställer in textjustering och högermarginal för cellerna i första raden
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Ställer in vertikal texttyp för cellerna i andra raden
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Sparar presentationen till disk
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange textformatering på kolumnnivå i tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och läs in presentationen,  
2. Hämta en bilds referens via dess index.  
3. Åtkomst till det relevanta [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)‑objektet från bilden.  
4. Ange de första kolumnens cellers [setFontHeight(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Ange de första kolumnens cellers [setAlignment(int value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).  
6. Ange de andra kolumnens cellers [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Spara den ändrade presentationen.  

Denna JavaScript‑kod demonstrerar operationen:

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Låt oss anta att den första formen på den första bilden är en tabell
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Sätter teckenhöjden för cellerna i den första kolumnen
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Sätter textjustering och högermarginal för cellerna i den första kolumnen i ett anrop
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Sätter vertikal texttyp för cellerna i den andra kolumnen
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

## **Hämta tabellstilsegenskaper**

Aspose.Slides låter dig hämta stilegenskaperna för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Denna JavaScript‑kod visar hur du får stilegenskaperna från en förinställd tabellstil:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// ändra standardstil‑förinställningens tema
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/stilar på en redan skapad tabell?**

Ja. Tabellen ärver bild‑/layout‑/master‑temat, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filter. Sortera dina data i minnet först, och fyll sedan på tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner och åsidosätt sedan specifika celler med lokal formatering; cellnivåformatering har företräde framför tabellstilen.