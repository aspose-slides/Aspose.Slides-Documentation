---
title: Hantera presentationstabeller i JavaScript
linktitle: Hantera tabell
type: docs
weight: 10
url: /sv/nodejs-java/manage-table/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa & redigera tabeller i PowerPoint-bilder med JavaScript och Aspose.Slides för Node.js. Upptäck enkla kodexempel för att effektivisera dina tabellarbetsflöden."
---
## **Introduktion**

Tabeller i PowerPoint organiserar information i rader och kolumner, vilket gör det enklare att läsa och jämföra värden.

Aspose.Slides tillhandahåller klassen [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/), klassen [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) och andra typer som låter dig skapa, uppdatera och hantera tabeller i presentationer.

## **Skapa en tabell från grunden**

Skapa en tabell genom att ange dess position, kolumnbredder och radhöjder. Efter att ha lagt till den på en bild kan du formatera cellramar, slå ihop celler och infoga text.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Definiera en array med kolumnbredder i punkter.
4. Definiera en array med radhöjder i punkter.
5. Lägg till ett [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)-objekt på bilden via metoden [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-).
6. Iterera igenom varje [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) för att tillämpa formatering på de övre, nedre, högra och vänstra ramarna.
7. Slå ihop de två första cellerna i tabellens första rad.
8. Kom åt den sammanslagna cellen via dess [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--)‑metod.
9. Sätt texten i den sammanslagna cellen.
10. Spara den ändrade presentationen.

Exemplet nedan skapar en tabell med tre kolumner och fem rader vid (100, 50) punkter. Det applicerar röda ramar med en bredd på 5 punkter, slår ihop de två första cellerna i den första raden och sparar resultatet som `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Numrering i en standardtabell**

I en standardtabell är cellindex nollbaserade och använder ordningen (kolumn, rad). Den första cellen har index (0, 0).

Till exempel numreras cellerna i en tabell med 4 kolumner och 4 rader på följande sätt:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Detta exempel skapar 4 × 4‑tabellen som illustreras ovan, med kolumnbredder och radhöjder på 70 punkter samt röda cellramar med en bredd på 5 punkter. Koordinaterna visar cellindex; exemplet lämnar cellerna tomma och sparar tabellen som `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Åtkomst till en befintlig tabell**

Tabeller lagras i en bilds formsamling. Iterera genom formerna för att hitta en tabell, och använd sedan klassen [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) för att läsa eller uppdatera dess celler.

1. Läs in presentationen med hjälp av klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Hämta en referens till bilden som innehåller tabellen via dess index.
3. Iterera genom [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)-objekten och stoppa när en tabell hittas. Om bilden innehåller flera tabeller, använd [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) för att identifiera den du behöver.
4. Uppdatera texten i målcell.
5. Spara den ändrade presentationen.

Exemplet nedan öppnar `UpdateExistingTable.pptx` och hittar den första tabellen på den första bilden. Det sätter cellen i kolumn 0, rad 1 till `New` och sparar resultatet som `table1_out.pptx`. Inmatningen måste innehålla minst en bild, och den första tabellen på den bilden måste ha minst en kolumn och två rader.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

För att ändra storlek på en rad i en befintlig tabell och förstå varför dess faktiska höjd kan överstiga den begärda minimin, se [Styr radhöjd](/slides/sv/nodejs-java/manage-rows-and-columns/#control-row-height).

## **Hitta cellen som äger en TextFrame**

När generisk textbehandlingskod får ett [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) från en tabell, använd metoden [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) för att hämta den ägande [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/). För ett tabellcell-textram returnerar [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) ägaren och [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) returnerar `null`, även om tabellen själv är en form.

Cellkoordinaterna är tillgängliga via de skrivskyddade metoderna [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) och [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) ger också skrivskyddad navigation: den returnerar ägaren men ändrar inte ägarskap. Kontrollera alltid om den returnerade cellen är `null` innan du använder den.

För ett komplett exempel som identifierar tabellcell‑ och formägare, inklusive former associerade med SmartArt‑noder, se [Sök och ersätt text](/slides/sv/nodejs-java/search-and-replace-text/).

## **Justera text i en tabell**

Du kan kontrollera vertikal förankring och textorientering för enskilda tabellceller. Exemplet i detta avsnitt centrerar text i den första cellen och roterar den 270 grader.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Lägg till ett [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)-objekt på bilden.
4. Kom åt ett [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)-objekt från tabellen.
5. Kom åt det första [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/)-objektet och sätt dess text och färg.
6. Ställ in cellens vertikala förankring och textorientering med [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) och [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-).
7. Spara den ändrade presentationen.

Detta exempel skapar en 4 × 4‑tabell med kolumnbredder på 120 punkter och radhöjder på 100 punkter. Det formaterar texten i cell (0, 0), lägger till värden i de återstående cellerna i den första raden och sparar resultatet som `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in textformatering på tabellnivå**

Använd [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) för att tillämpa textformatering på alla celler i en tabell. Dess överlagringar accepterar del-, paragraf- och textram‑formatering, så du kan sätta dessa egenskaper utan att iterera genom enskilda celler.

1. Läs in presentationen med hjälp av klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Hämta en referens till bilden via dess index.
3. Kom åt ett [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/)-objekt från bilden.
4. Ställ in teckenstorleken med [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) för texten.
5. Ställ in styckejustering och högermarginal med [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) och [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Ställ in textens riktning med [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Spara den ändrade presentationen.

Exemplet nedan öppnar `table.pptx`, som måste innehålla minst en bild med en tabell som sin första form. Det sätter teckenstorleken till 25 punkter, högerjusterar stycken med en högermarginal på 20 punkter och gör texten vertikal. Den formaterade presentationen sparas som `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hämta tabellstilsegenskaper**

Använd [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) för att läsa en tabells förinställda stil och [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) för att tilldela den. Detta exempel tillämpar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) på en tabell, skriver ut förinställningsvärdet och tilldelar samma förinställning till en andra tabell. Båda tabellerna sparas i `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lås bildförhållandet för en tabell**

En tabells bildförhållande är förhållandet mellan dess bredd och höjd. Använd [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) för att låsa detta förhållande för en tabell.

Exemplet nedan öppnar `pres.pptx`, som måste innehålla minst en bild med en tabell som sin första form. Det skriver ut det aktuella låstillståndet, aktiverar låsning av bildförhållandet, skriver ut det uppdaterade tillståndet (`true`) och sparar resultatet som `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag aktivera höger-till-vänster (RTL) läsriktning för en hel tabell och texten i dess celler?**

Ja. Tabellen har en [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-)‑metod, och stycken har [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-). Att använda båda säkerställer korrekt RTL‑ordning och rendering i cellerna.

**Hur kan jag förhindra att användare flyttar eller ändrar storlek på en tabell i den slutgiltiga filen?**

Använd [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) för att inaktivera flytt, storleksändring, markering etc. Dessa lås gäller även för tabeller.

**Stöds det att infoga en bild i en cell som bakgrund?**

Ja. Du kan ange en [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) för en cell; bilden kommer att täcka cellområdet enligt valt läge (sträcka eller mosaik).