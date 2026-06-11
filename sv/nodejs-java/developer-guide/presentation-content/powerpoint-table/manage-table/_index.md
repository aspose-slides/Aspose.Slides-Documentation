---
title: Hantera presentationstabeller i JavaScript
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/nodejs-java/manage-table/
keywords:
- lägg till tabell
- skapa tabell
- åtkomst till tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med JavaScript och Aspose.Slides för Node.js. Upptäck enkla kodexempel för att förenkla ditt tabellarbetsflöde."
---
## **Introduktion**

En tabell i PowerPoint är ett effektivt sätt att visa och framställa information. Informationen i ett rutnät av celler (ordnade i rader och kolumner) är tydlig och lätt att förstå.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table), klassen [Cell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cell/) och andra typer som låter dig skapa, uppdatera och hantera tabeller i alla typer av presentationer.

## **Skapa tabell från grunden**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en slides referens via dess index. 
3. Definiera en array av `columnWidth`.
4. Definiera en array av `rowHeight`.
5. Lägg till ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)-objekt på sliden via metoden [addTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterera genom varje [Cell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cell/) för att tillämpa formatering på de övre, nedre, högra och vänstra kanterna.
7. Sammanfoga de två första cellerna i tabellens första rad. 
8. Få åtkomst till en [Cell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
9. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
10. Spara den modifierade presentationen.

```javascript
// Instansierar en Presentation-klass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första sliden
    var sld = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredd och rader med höjd
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Lägger till en tabellform till sliden
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Sätter kantformat för varje cell
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
    // Sammanfogar cellerna 1 och 2 i rad 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Lägger till lite text i den sammanfogade cellen
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Sparar presentationen till disk
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numrering i standardtabell**

I en standardtabell är numreringen av celler enkel och nollbaserad. Den första cellen i en tabell har indexet 0,0 (kolumn 0, rad 0). 

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Den här JavaScript-koden visar hur du specificerar numreringen för celler i en tabell:

```javascript
// Instansierar en Presentation-klass som representerar en PPTX-fil
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första sliden
    var sld = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredd och rader med höjd
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Lägger till en tabellform på sliden
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Sätter kantformat för varje cell
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
    // Sparar presentationen till disk
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Åtkomst till befintlig tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en referens till sliden som innehåller tabellen via dess index. 
3. Skapa ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)-objekt och sätt det till null.
4. Iterera genom alla [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)‑objekt tills tabellen hittas.

   Om du misstänker att sliden du hanterar innehåller en enda tabell kan du helt enkelt kontrollera alla former den innehåller. När en form identifieras som en tabell kan du typkonvertera den till ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)-objekt. Men om sliden du hanterar innehåller flera tabeller är det bättre att söka efter den tabell du behöver via dess [setAlternativeText(String value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Använd [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)-objektet för att arbeta med tabellen. I exemplet nedan lade vi till en ny rad i tabellen.
6. Spara den modifierade presentationen.

```javascript
// Instansierar Presentation-klassen som representerar en PPTX-fil
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Hämtar den första sliden
    var sld = pres.getSlides().get_Item(0);
    // Initierar null TableEx
    var tbl = null;
    // Itererar genom formerna och anger en referens till den hittade tabellen
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Sätter texten för den första kolumnen i den andra raden
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Sparar den modifierade presentationen till disk
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Justera text i tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en slides referens via dess index. 
3. Lägg till ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)-objekt på sliden.
4. Få åtkomst till ett [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/)-objekt från tabellen.
5. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/)-objektets [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/).
6. Justera texten vertikalt.
7. Spara den modifierade presentationen.

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första sliden
    var slide = pres.getSlides().get_Item(0);
    // Definierar kolumner med bredd och rader med höjd
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Lägger till tabellformen på sliden
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Hämtar textramen
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Skapar Paragraph-objektet för textramen
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Skapar Portion-objektet för paragrafen
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Justera texten vertikalt
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // Sparar presentationen till disk
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in textformatering på tabellnivå**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta en slides referens via dess index. 
3. Få åtkomst till ett [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Table)-objekt från sliden.
4. Ange [setFontHeight(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) för texten.
5. Ange [setAlignment(int value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Ange [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Spara den modifierade presentationen. 

```javascript
// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Låt oss anta att den första formen på den första sliden är en tabell
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Sätter tabellcellerna fonthöjd
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Sätter tabellcellernas textjustering och högermarginal i ett anrop
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Sätter den vertikala texttypen för tabellcellerna
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

## **Hämta tabellstilsattribut**

Aspose.Slides låter dig hämta stilattribut för en tabell så att du kan använda dessa detaljer för en annan tabell eller någon annanstans. Den här JavaScript-koden visar hur du får stilattributen från en förinställd tabellstil:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// ändra det förinställda standardstiltemat
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lås bildförhållandet för tabell**

Bildförhållandet för en geometrisk form är förhållandet mellan dess storlekar i olika dimensioner. Aspose.Slides tillhandahåller egenskapen [**setAspectRatioLocked**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) för att låta dig låsa inställningen för bildförhållandet för tabeller och andra former.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invertera
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag aktivera högertillvänster (RTL) läsriktning för en hel tabell och texten i dess celler?**

Ja. Tabellen har en [setRightToLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/setrighttoleft/)-metod, och stycken har [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den färdiga filen?**

Använd lås för former för att inaktivera flyttning, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt det valda läget (stretch eller tile).