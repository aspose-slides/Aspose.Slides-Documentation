---
title: Hantera presentationstabeller i Java
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/java/manage-table/
keywords:
- lägga till tabell
- skapa tabell
- åtkomst till tabell
- bildförhållande
- justera text
- textformatering
- tabellstil
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och redigera tabeller i PowerPoint-bilder med Aspose.Slides för Java. Upptäck enkla kodexempel för att förenkla ditt tabellarbetsflöde."
---
## **Introduktion**

En tabell i PowerPoint är ett effektivt sätt att visa och framställa information. Informationen i ett rutnät av celler (ordnade i rader och kolumner) är tydlig och lätt att förstå.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Table), gränssnittet [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable), klassen [Cell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/cell/) , gränssnittet [ICell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icell/) och andra typer så att du kan skapa, uppdatera och hantera tabeller i alla typer av presentationer. 

## **Skapa en tabell från grunden**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en referens till en bild genom dess index. 
3. Definiera en array av `columnWidth`.
4. Definiera en array av `rowHeight`.
5. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)-objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterera genom varje [ICell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icell/) för att tillämpa formatering på övre, nedre, högra och vänstra kanterna.
7. Sammanfoga de två första cellerna i tabellens första rad. 
8. Få åtkomst till en [ICell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/). 
9. Lägg till lite text i [TextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframe/).
10. Spara den ändrade presentationen.

Den här Java-koden visar hur du skapar en tabell i en presentation:

```java
// Skapar en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredd och rader med höjd
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Lägger till en tabellform på bilden
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ställer in kantformatet för varje cell
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
    // Sammanfogar cellerna 1 och 2 i rad 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Lägger till lite text i den sammanslagna cellen
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Sparar presentationen till disk
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Numrering i en standardtabell**

I en standardtabell är numreringen av celler enkel och nollbaserad. Den första cellen i en tabell har index 0,0 (kolumn 0, rad 0). 

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Den här Java-koden visar hur du anger numreringen för celler i en tabell:

```java
// Skapar en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation();
try {
    // Hämtar första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Definierar kolumner med bredd och rader med höjd
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Lägger till en tabellform på bilden
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Ställer in kantformatet för varje cell
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

    // Sparar presentationen till disk
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Åtkomst till en befintlig tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).

2. Hämta en referens till bilden som innehåller tabellen genom dess index. 

3. Skapa ett [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)-objekt och sätt det till null.

4. Iterera genom alla [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/)‑objekt tills tabellen hittas.

   Om du misstänker att bilden du arbetar med innehåller en enda tabell kan du helt enkelt kontrollera alla former den innehåller. När en form identifieras som en tabell kan du kasta den till ett [Table](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Table)-objekt. Men om bilden du arbetar med innehåller flera tabeller är det bättre att söka efter den tabell du behöver via dess [setAlternativeText(String value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Använd [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)-objektet för att arbeta med tabellen. I exemplet nedan lade vi till en ny rad i tabellen.

6. Spara den ändrade presentationen.

Den här Java-koden visar hur du får åtkomst till och arbetar med en befintlig tabell:

```java
// Skapar en Presentation-klass som representerar en PPTX-fil
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Hämtar den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Initierar null TableEx
    ITable tbl = null;

    // Itererar genom formerna och sätter en referens till den hittade tabellen
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Ställer in texten för den första kolumnen i den andra raden
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Sparar den ändrade presentationen till disk
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Justera text i en tabell**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en referens till en bild genom dess index. 
3. Lägg till ett [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)-objekt på bilden. 
4. Få åtkomst till ett [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/)‑objekt från tabellen. 
5. Få åtkomst till [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/)[IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/).
6. Justera texten vertikalt.
7. Spara den ändrade presentationen.

Den här Java-koden visar hur du justerar texten i en tabell:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Hämtar den första bilden 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Definierar kolumner med bredd och rader med höjd
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Lägger till tabellformen på bilden
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Hämtar textramen
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Skapar Paragraph-objektet för textramen
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Skapar Portion-objektet för stycket
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Justerar texten vertikalt
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Sparar presentationen till disk
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange textformatering på tabellnivå**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta en referens till en bild genom dess index. 
3. Få åtkomst till ett [ITable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ITable)-objekt från bilden.
4. Ställ in [setFontHeight(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) för texten. 
5. Ställ in [setAlignment(int value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) och [setMarginRight(float value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-). 
6. Ställ in [setTextVerticalType(byte value)](https://reference.aspose.com/slides/sv/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Spara den ändrade presentationen. 

Den här Java-koden visar hur du tillämpar dina föredragna formateringsalternativ på texten i en tabell:

```java
// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Låt oss anta att den första formen på den första bilden är en tabell
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Ställer in tabellcellernas teckenhöjd
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Ställer in tabellcellernas textjustering och högermarginal i ett anrop
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Ställer in tabellcellernas vertikala texttyp
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hämta tabellstilens egenskaper**

Aspose.Slides låter dig hämta stil‑egenskaperna för en tabell så att du kan använda dessa uppgifter för en annan tabell eller någon annanstans. Denna Java‑kod visar hur du får stil‑egenskaperna från ett tabell‑förinställt stil:

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

## **Lås bildförhållandet för en tabell**

Bildförhållandet för en geometrisk form är förhållandet mellan dess mått i olika dimensioner. Aspose.Slides tillhandahåller egenskapen [**setAspectRatioLocked**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) för att låsa bildförhållandet för tabeller och andra former. 

Den här Java‑koden visar hur du låser bildförhållandet för en tabell:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // invertera

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag aktivera läsriktning från höger till vänster (RTL) för en hel tabell och texten i dess celler?**

Ja. Tabellen har en [setRightToLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/table/#setRightToLeft-boolean-)‑metod, och stycken har [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Genom att använda båda säkerställs korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutgiltiga filen?**

Använd [shape locks](/slides/sv/java/applying-protection-to-presentation/) för att inaktivera flyttning, storleksändring, markering osv. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/sv/java/com.aspose.slides/picturefillformat/) för en cell; bilden täcker cellområdet enligt valt läge (sträckning eller mosaik).