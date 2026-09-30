---
title: Hantera rader och kolumner i PowerPoint-tabeller med JavaScript
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
description: "Hantera tabellrader och -kolumner i PowerPoint med JavaScript och Aspose.Slides för Node.js via Java samt snabba upp redigering av presentationer och datauppdateringar."
---
## **Introduktion**

Aspose.Slides för Node.js via Java låter dig hantera tabellstruktur och formatering i PowerPoint-presentationer via klassen [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Du kan ange en rubrikrad, klona eller ta bort rader och kolumner, samt tillämpa textformatering på en hel rad eller kolumn.

Den här artikeln förklarar dessa operationer med JavaScript-exempel. Den visar också hur du hämtar en tabells stilförinställning så att du kan återanvända den. Rads- och kolumnindex i tabeller är nollbaserade.

## **Styr radens höjd**

Använd [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) för att ange en rads minsta höjd i punkter. Det är en nedre gräns, inte en fast höjd. [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) returnerar den faktiska höjden. Åtkom raden via [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--).

Exemplet laddar [row-height-input.pptx](row-height-input.pptx), som har en tabell som den första formen på den första bilden. Dess första rad börjar på 70 punkter. Cellerna använder 18‑punkts Arial‑text, radbrytning och 6‑punkts marginaler högst och längst ner; den längre texten i den andra kolumnen radbryts till flera rader. Exemplet ökar minimin till 100 punkter, minskar det sedan till 20 punkter, skriver ut den faktiska höjden efter varje förändring och sparar båda resultaten.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Med den medföljande presentationen lägger ökning av minimum till extra utrymme i raden. Minskning tar bort det extra utrymmet, men den faktiska höjden förblir större än 20 punkter eftersom texten och cellmarginalerna kräver mer plats. Att bara minska minimum kan inte tvinga raden under det utrymme som innehållet kräver.

Flera faktorer påverkar den faktiska höjden:

- **Text och teckenstorlek:** längre text, explicita radbrytningar eller ett större teckensnitt kan kräva mer vertikalt utrymme.
- **Radbrytning och kolumnbredd:** med radbrytning aktiverad kan minskning av kolumnbredden med [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) skapa fler rader. En bredare kolumn kan minska det vertikala utrymmet.
- **Cellmarginaler:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) och [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) lägger till vertikalt utrymme. [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) och [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) minskar bredden som är tillgänglig för text och kan orsaka extra radbrytning.

För denna tabell utan sammanslagna celler bestämmer den cell som behöver mest vertikalt utrymme den innehållsdrivna lägre gränsen för hela raden. För att göra raden kortare kan du också behöva förkorta texten, minska teckenstorleken eller marginalerna, eller bredda en kolumn.

Bilderna nedan visar samma tabell i samma skala. I de illustrerade resultaten var de faktiska höjderna 70, 100 och 55.2 punkter: den sista raden förblev högre än sitt 20‑punkts minimum. Exakta textmått kan variera med de teckensnitt som finns i din miljö. Ladda ner de sparade resultaten: [ökad minimum](row-height-increased.pptx) och [minskad minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, faktiskt 70 pt | Ökad: minimum 100 pt, faktiskt 100 pt | Minskad: minimum 20 pt, faktiskt 55.2 pt |
| --- | --- | --- |
| ![Original tabell med en 70‑punkts första rad.](row-height-before.png) | ![Tabell efter att ha ökat den första radens minimum till 100 punkter.](row-height-increased.png) | ![Tabell efter att ha minskat den första radens minimum till 20 punkter; radbruten text håller raden högre än minimum.](row-height-decreased.png) |

## **Ställ in den första raden som rubrik**

Använd metoden [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) för att markera den första raden för rubrikformatering. Dess utseende beror på tabellstilen som tillämpas på tabellen.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Öppna den första bilden.
3. Hämta tabellen som lagras som den första formen på bilden.
4. Aktivera rubrikformatering för dess första rad.
5. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden. Det aktiverar rubrikformatering för den första raden och sparar `First_row_header.pptx`.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Klona en tabellrad eller -kolumn**

Klona rader eller kolumner för att återanvända deras innehåll och formatering. Du kan lägga till en kopia i slutet av tabellen eller infoga den på en specifik position.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Öppna den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Klona de önskade raderna.
6. Klona de önskade kolumnerna.
7. Spara den ändrade presentationen.

Exemplet kräver `Test.pptx` med minst en bild. Det skapar en tabell med tre kolumner och fem rader, med dimensioner angivna i punkter. Det lägger till kopior av den första raden och kolumnen, och infogar sedan kopior av den andra raden och kolumnen på index 3 (den fjärde positionen). Den resulterande tabellen har sju rader och fem kolumner. Argumentet `false` inaktiverar kloning i intilliggande sammanslagna rader eller kolumner; denna tabell har inga sammanslagna celler.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ta bort en rad eller kolumn från en tabell**

Ta bort rader eller kolumner som inte längre behövs i en tabell. När ett objekt tas bort förskjuts indexen för raderna eller kolumnerna som följer.

1. Skapa en presentation med klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Öppna den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).
5. Ta bort den andra raden och den andra kolumnen.
6. Spara den ändrade presentationen.

Detta exempel skapar en tre‑x‑tre tabell och tar bort raden och kolumnen på index 1, vilket lämnar en två‑x‑två tabell i `TestTable_out.pptx`. Dimensionerna är i punkter. Argumentet `false` inaktiverar borttagning av intilliggande sammanslagna rader eller kolumner; denna tabell har inga sammanslagna celler.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in textformatering på tabellradnivå**

Tillämpa textformatering på en hel rad för att hålla dess celler enhetliga. Du kan ange teckensnittsegenskaper, styckeformat och textriktning utan att formatera varje cell individuellt.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Åtkom tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) för den första raden.
4. Använd [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) och [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) för den första raden.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) för den andra raden.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två rader. Det applicerar 25‑punkts text, högerjustering och en 20‑punkts högermarginal för stycket på den första raden, och ställer in vertikal text i den andra raden.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in textformatering på tabellkolumnnivå**

Tillämpa textformatering på en hel kolumn för att hålla dess celler enhetliga. Du kan ange teckensnittsegenskaper, styckeformat och textriktning utan att formatera varje cell individuellt.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Åtkom tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) för den första kolumnen.
4. Använd [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) och [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) för den första kolumnen.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) för den andra kolumnen.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två kolumner. Det applicerar 25‑punkts text, högerjustering och en 20‑punkts högermarginal för stycket på den första kolumnen, och ställer in vertikal text i den andra kolumnen.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hämta egenskaper för tabellstil**

Använd metoden [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) för att hämta förinställningen som tillämpats på en tabell och återanvända den på en annan tabell. Detta identifierar förinställningen snarare än enskilda cellformat‑åsidosättningar.

Exemplet skapar en tabell, tillämpar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) och läser sedan tillbaka förinställningen. Det skriver ut det heltalsvärde som motsvarar `DarkStyle1` och sparar tabellen i `table.pptx`.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan jag applicera PowerPoint-teman/stilar på en tabell som redan har skapats?**

Ja. Tabellen ärver slide/layout/master‑temat, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först, och återpopulate sedan tabellraderna i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner, och åsidosätt sedan specifika celler med lokal formatering; cell‑nivå‑formatering har företräde framför tabellstilen.