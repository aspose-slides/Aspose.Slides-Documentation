---
title: Hantera textrutor i presentationer med JavaScript
linktitle: Hantera textruta
type: docs
weight: 20
url: /sv/nodejs-java/manage-textbox/
keywords:
- textruta
- textram
- lägga till text
- uppdatera text
- skapa textruta
- kontrollera textruta
- lägga till textkolumn
- lägga till hyperlänk
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa, identifiera, formatera och uppdatera textrutor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java."
---
## **Introduktion**

I Aspose.Slides för Node.js via Java lagras bildtext i textramar som tillhör former. Klassen [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) representerar den vanligaste textbärande formen och exponerar dess text via metoden [AutoShape.getTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Varje autoform härstammar från [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/), men inte varje form är en autoform eller stöder en textram. När du bearbetar en befintlig presentation, kontrollera att en form är en instans av [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) innan du får åtkomst till dess text.

{{% /alert %}}

## **Skapa en textruta på en bild**

För att skapa en textruta, lägg till en autoform på en bild, lägg till text i dess textram och spara presentationen. Följande exempel skapar en rektangulär textruta:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Koordinaterna och dimensionerna som skickas till [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addAutoShape) mäts i punkter. [AutoShape.addTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#addTextFrame) initierar textramen med den angivna texten.

## **Kontrollera om en form är en textruta**

Använd metoden [AutoShape.isTextBox](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#isTextBox) för att avgöra om en autoform behandlas som en textruta. Detta är användbart när en presentation innehåller både textbärande och enbart grafiska autoformer.

![En textruta och en form](istextbox.png)

Följande exempel inspekterar varje autoform i en presentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

En nylagt autoform betraktas inte som en textruta förrän den innehåller icke‑tom text. Du kan ange den texten via [AutoShape.addTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#addTextFrame) eller [TextFrame.setText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#setText). Att lägga till eller tilldela en tom sträng gör att [AutoShape.isTextBox](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#isTextBox) returnerar `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

De två första anropen skriver ut `true`; de två sista skriver ut `false`.

## **Hitta formen som äger en textram**

Generisk text‑behandlingskod kan ta emot en [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) utan att veta vilket presentationsobjekt som innehåller den. Använd den skrivskyddade metoden [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentShape) för att navigera tillbaka till dess ägande [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/).

För en textram som ägs av en autoform eller en annan textbärande form returnerar [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentShape) ägaren och [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentCell) returnerar `null`. Kontrollera det returnerade värdet innan du använder det. För att identifiera både form‑ och tabell‑cell‑ägare, inklusive former som är kopplade till SmartArt‑noder, se [Search and Replace Text](/slides/sv/nodejs-java/search-and-replace-text/).

## **Lägg till kolumner i en textruta**

Metoden [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setColumnCount) delar textramen i kolumner, medan [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) anger avståndet mellan kolumner i punkter. Båda inställningarna tillhör [TextFrameFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/) och kan ändras via textramen i en befintlig textruta. Text flödar om mellan kolumner inom samma form; den fortsätter inte in i en annan form.

Följande exempel skapar en tre‑kolumns textruta med 10 punkter mellan kolumnerna, sparar presentationen och läser de lagrade inställningarna från utdatafilen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Extrahera text från enskilda kolumner**

Använd [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#splitTextByColumns) för att hämta den text som är tilldelad varje visuell kolumn i en befintlig textram. Metoden returnerar en sträng för varje kolumn i kolumnbaserad läsordning. En en‑kolumns textram ger en array med ett element, och en tom kolumn representeras av en tom sträng. Strängarna innehåller enbart vanlig text; formatering på portionsnivå bevaras inte.

Detta är användbart när du behöver:

- Extrahera text samtidigt som den kolumnbaserade läsordningen bevaras.
- Indexera eller jämföra innehållet i bildspel med flera kolumner.
- Exportera varje kolumn till en separat fil, databasfält eller annan destination.
- Inspektera hur text omfördelas efter att ha ändrat antalet kolumner med [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setColumnCount), avståndet med [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), teckensnittet eller storleken på textramen.

Metoden rapporterar texten som distribueras inom den aktuella [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/); den flödar inte automatiskt text mellan separata former eller textrutor. Kolumndistribution kan bero på tillgängliga teckensnitt och andra textlayout‑inställningar, så se till att de nödvändiga teckensnitten finns tillgängliga när konsekventa resultat är viktiga.

Följande exempel laddar en presentation, hittar den första multi‑kolumns autoformen med en textram, läser dess konfigurerade kolumnantal och skriver texten från varje kolumn till en separat fil. Former som inte tillhandahåller en textram hoppas över.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Uppdatera text**

För att uppdatera text i hela en presentation, iterera genom bilderna och formerna, välj autoformer och redigera sedan deras textportioner. Att arbeta på portionsnivå låter dig ändra både text och teckenformatering.

Följande exempel ersätter varje förekomst av `years` med `months` i auto‑form‑text och gör varje påverkad portion fetstil:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Denna genomgång uppdaterar endast text i autoformer. Text som lagras i tabeller, diagram, SmartArt eller grupperade former kräver att deras egna samlingar traverseras.

## **Lägg till en textruta med hyperlänk**

En hyperlänk kan tilldelas en specifik textportion, så att endast den texten fungerar som den klickbara länken. Använd [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) för att koppla portionen till en extern URL.

Följande exempel skapar länkt text och sparar den i en presentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad är skillnaden mellan en textruta och en platshållare för text på en master‑ eller layoutbild?**

En [placeholder](/slides/sv/nodejs-java/manage-placeholder/) kan ärva sin position och formatering från en [master slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/) eller [layout slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/). En vanlig textruta är en oberoende form på bilden där den skapades och får inte platshållarbeteende när layouten ändras.

**Hur kan jag ersätta text utan att ändra text i diagram, tabeller eller SmartArt?**

Begränsa traverseringen till former som är instanser av [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/), som visas i exemplet för Uppdatera text. Diagram, tabeller och SmartArt lagrar text i sina egna objektmodeller, så de ändras inte av den loopen.