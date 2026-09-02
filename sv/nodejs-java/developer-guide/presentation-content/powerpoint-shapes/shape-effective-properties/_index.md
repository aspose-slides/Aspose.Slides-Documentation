---
title: Hämta formens effektiva egenskaper från presentationer i JavaScript
linktitle: Effektiva egenskaper
type: docs
weight: 50
url: /sv/nodejs-java/shape-effective-properties/
keywords:
- formegenskaper
- kameraegenskaper
- ljusrigg
- avfasad form
- textram
- textstil
- teckenhöjd
- fyllningsformat
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du använder Aspose.Slides för Node.js via Java för att särskilja lokal, ärvd och effektiv formatering av former i PowerPoint‑presentationer."
---
## **Förstå lokala, ärvda och effektiva egenskaper**

PowerPoint‑formatering kan komma från flera ställen. Värdet som lagras direkt på ett objekt är dess **lokala värde**. Om det värdet inte är satt tittar PowerPoint på föräldraformateringskällor, såsom ett paragrafstandard, en textstil, en layout‑ eller master‑bild, ett tema eller standardinställningar på presentationsnivå. Dessa värden är **ärvda värden**. Värdet som återstår när hela hierarkin har lösts är **det effektiva värdet**—värdet som används för att rendera objektet.

Till exempel kanske en textdel inte har definierat sin egen teckenhöjd. Dess lokala [getFontHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getFontHeight)‑värde är då `NaN`, vilket betyder ”inte satt här”. Textdelen kan ärva en höjd från sitt stycke, presentationens standardtextstil eller en annan tillämplig källa. Att anropa [getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getEffective) på portionens format returnerar den slutligt lösta höjden.

Använd de två typerna av formateringsdata för olika ändamål:

- Läs eller ändra ett lokalt formatobjekt, såsom [PortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/), när du behöver kontrollera var ett värde är definierat.
- Läs de [effektiva data som returneras av PortionFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getEffective) när du behöver det slutliga, renderade resultatet. Effektiva data är skrivskyddade.

Innan du kör exemplen, [installera Aspose.Slides för Node.js via Java](/slides/sv/nodejs-java/installation/).

## **Jämför lokala, ärvda och effektiva värden**

Det följande kompletta exemplet skapar en form och applicerar teckenhöjder på presentations-, stycke‑ och portionsnivå. Varje steg skriver ut värdena som definierats på dessa nivåer samt det resulterande effektiva värdet för samma textdel. Det visar också varför effektiva data måste läsas igen efter formateringsändringar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // Läs effektiva data efter föregående förändringar.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // Definiera ärvda värden på två olika nivåer.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // Ett lokalt värde på portionen åsidosätter båda ärvda värdena.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // Att ändra ett ärvt värde åsidosätter inte ett befintligt lokalt värde.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // Rensa det lokala värdet. Portionen ärver nu igen från paragrafen.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // Rensa paragrafvärdet. presentationsstandardvärdet levererar nu resultatet.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Prioriteten i detta exempel är portionslokal formatering, sedan styckeformatering och slutligen presentationsstandard. Andra objekt kan ha olika arvskedjor, men principen är densamma: ett mer specifikt explicit värde vinner, och [getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getEffective) returnerar slutresultatet.

## **Hämta effektiva textegenskaper**

Textformatering är fördelad på flera objekt:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#getEffective) löser egenskaper för textramar såsom marginaler, förankring, autofit och vertikal textriktning.
- [TextStyle.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textstyle/#getEffective) löser styckeformatering för varje nivå av textstil.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#getEffective) löser paragraf‑egenskaper såsom justering, indrag och punktlistor.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getEffective) löser teckensegenskaper såsom teckenhöjd, teckensnitt, färg, fetstil och kursiv stil.

För nästa exempel måste `text-formatting.pptx` innehålla minst en bild och en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) med en icke‑tom textram. AutoShape kan förekomma på någon position i formsamlingen; koden söker efter ett lämpligt objekt och validerar det innan det används.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **Hämta effektiva 3D‑egenskaper**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getEffective) returnerar ett effektivt dataobjekt som grupperar alla lösta 3D‑inställningar. Dess [getCamera](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getBevelTop) och [getBevelBottom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getBevelBottom)‑metoder visar motsvarande effektiva data. Att läsa dessa relaterade inställningar tillsammans gör det lättare att förstå den slutliga 3D‑utseendet på en form.

För detta exempel måste `shape-3d.pptx` innehålla minst en form på den första bilden. Applicera 3D‑kamera, belysning eller chiselinställningar på den formen om du vill att resultatet ska innehålla andra värden än standard.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **Hämta effektiv tabellformatering**

Tabellformatering kan komma från tabellstilen och från format som tillämpas på hela tabellen, en kolumn, en rad eller en enskild cell. Vid konflikter mellan explicit definierade fyllningar är prioriteten cell, rad, kolumn och sedan hela tabellen. Den effektiva formateringen av en cell är det slutgiltiga formatet som används för att rita den cellen.

För detta exempel måste `table-formatting.pptx` innehålla minst en tabell på den första bilden. Tabellen måste ha minst en rad och en kolumn. Koden söker efter en [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/) istället för att anta att `getShapes().get_Item(0)` är en tabell.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

Om du behöver färgen snarare än bara fyllningstypen, kontrollera först den effektiva [getFillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/#getFillType), och läs sedan den metod som gäller för den typen—till exempel [getSolidFillColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) för en solid fyllning.

## **Läs effektiva data på nytt efter ändringar**

Effektiva data beskriver formateringshierarkin vid den tidpunkt de lösts. Anropa `getEffective` igen efter att du ändrat något som kan delta i den hierarkin, inklusive:

- objektets lokala formatering;
- paragraf‑ eller textram‑standarder;
- en tabellstil, tabell, kolumn, rad eller cellformat;
- layout‑ eller master‑bildformatering;
- temadata eller standardinställningar på presentationsnivå;
- layouten eller mastern som är tilldelad en bild.

Behåll inte ett effektivt dataobjekt som en permanent ögonblicksbild. Aspose.Slides kan cache‑a vissa effektiva data internt, och ett senare anrop av `getEffective` kan uppdatera dessa data. Om du behöver jämföra värden före och efter en ändring, kopiera de skalära värden du behöver—såsom teckenhöjd, färg, justering eller chiselbredd—till egna variabler innan du gör ändringen.

För att ändra ett värde, uppdatera det lämpliga lokala formatobjektet och anropa sedan `getEffective` för att verifiera resultatet. Effektiva dataobjekt är i sig skrivskyddade.

## **FAQ**

**Hur kan jag avgöra vilken nivå som levererade ett effektivt värde?**

Effektiva data innehåller det slutgiltiga värdet, inte dess källa. Inspektera de tillämpliga lokala objekten från den mest specifika nivån och utåt. För text kan detta inkludera portionen, paragrafen, textramen, layouten, mastern, temat och presentationsstandarder. Odefinierade värden såsom `NaN` eller `null` indikerar att sökningen fortsätter till en annan nivå.

**Vad händer när ingen nivå definierar en egenskap?**

Aspose.Slides löser det lämpliga PowerPoint‑ eller bibliotek‑standardvärdet. Det lösta värdet visas i de effektiva data även om inget lokalt objekt explicit definierar det.

**Varför är ett effektivt värde ibland lika med det lokala värdet?**

Det lokala värdet vann arvberäkningen. Detta är förväntat när egenskapen är explicit satt på objektet och ingen mer specifik regel åsidosätter den.

**När bör jag använda lokala data istället för effektiva data?**

Använd lokala data för att inspektera eller redigera en specifik formateringsnivå. Använd effektiva data när du behöver det slutliga utseendet efter arv, temaregelverk och tillämpliga stilar har lösts. Det [kompletta jämförelseexemplet](#compare-local-inherited-and-effective-values) demonstrerar båda i samma arbetsflöde.