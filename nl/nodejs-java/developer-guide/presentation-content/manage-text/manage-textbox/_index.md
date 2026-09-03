---
title: Beheer tekstvakken in presentaties met JavaScript
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/nodejs-java/manage-textbox/
keywords:
- tekstvak
- tekstkader
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak, identificeer, formatteer en werk tekstvakken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java."
---
## **Inleiding**

In Aspose.Slides voor Node.js via Java wordt de tekst van een dia opgeslagen in tekstkaders die tot vormen behoren. De [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/)-klasse vertegenwoordigt de meest voorkomende vorm die tekst bevat en geeft de tekst beschikbaar via de [AutoShape.getTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#getTextFrame)‑methode.

{{% alert color="info" title="Note" %}}

Elke auto‑vorm is afgeleid van [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/), maar niet elke vorm is een auto‑vorm of ondersteunt een tekstkader. Bij het verwerken van een bestaande presentatie moet u controleren of een vorm een instantie is van [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) voordat u de tekst benadert.

{{% /alert %}}

## **Een tekstvak maken op een dia**

Om een tekstvak te maken, voegt u een auto‑vorm toe aan een dia, voegt u tekst toe aan het tekstkader en slaat u de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

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

De coördinaten en afmetingen die aan [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addAutoShape) worden doorgegeven, worden gemeten in punten. [AutoShape.addTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#addTextFrame) initialiseert het tekstkader met de opgegeven tekst.

## **Controleren op een tekstvakvorm**

Gebruik de [AutoShape.isTextBox](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#isTextBox)‑methode om te bepalen of een auto‑vorm wordt beschouwd als een tekstvak. Dit is handig wanneer een presentatie zowel tekstdragende als puur grafische auto‑vormen bevat.

![A text box and a shape](istextbox.png)

Het volgende voorbeeld inspecteert elke auto‑vorm in een presentatie:

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

Een nieuw toegevoegde auto‑vorm wordt pas als tekstvak beschouwd wanneer ze niet‑lege tekst bevat. U kunt die tekst leveren via [AutoShape.addTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#addTextFrame) of [TextFrame.setText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#setText). Het toevoegen of toewijzen van een lege tekenreeks zorgt ervoor dat [AutoShape.isTextBox](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#isTextBox) `false` teruggeeft:

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

De eerste twee oproepen geven `true` weer; de laatste twee geven `false` weer.

## **Zoek de vorm die een tekstkader bezit**

Generieke tekstverwerkingscode kan een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) ontvangen zonder te weten welk presentatie‑object het bevat. Gebruik de alleen‑lezen [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentShape)‑methode om terug te navigeren naar de bijbehorende [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/).

Voor een tekstkader dat eigendom is van een auto‑vorm of een andere tekstdragende vorm, geeft [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentShape) de eigenaar terug en geeft [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentCell) `null` terug. Controleer de geretourneerde waarde voordat u deze benadert. Om zowel vorm‑ als tabelcel‑eigenaars te identificeren, inclusief vormen die gekoppeld zijn aan SmartArt‑knooppunten, zie [Search and Replace Text](/slides/nl/nodejs-java/search-and-replace-text/).

## **Kolommen toevoegen aan een tekstvak**

De [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setColumnCount)‑methode verdeelt het tekstkader in kolommen, terwijl [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) de ruimte tussen kolommen in punten instelt. Beide instellingen behoren tot [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/) en kunnen worden aangepast via het tekstkader van een bestaand tekstvak. Tekst stroomt opnieuw tussen kolommen binnen dezelfde vorm; hij gaat niet verder naar een andere vorm.

Het volgende voorbeeld maakt een drie‑koloms tekstvak met 10 punten tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

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

## **Tekst extraheren uit individuele kolommen**

Gebruik [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#splitTextByColumns) om de tekst op te halen die aan elke visuele kolom in een bestaand tekstkader is toegewezen. De methode retourneert één tekenreeks per kolom, in kolom‑gebaseerde leesvolgorde. Een tekstkader met één kolom produceert een array met één element, en een lege kolom wordt weergegeven door een lege tekenreeks. De tekenreeksen bevatten alleen platte tekst; op‑gedeelte‑niveau opmaak wordt niet behouden.

Dit is nuttig wanneer u:

- Tekst extraheren terwijl de kolom‑gebaseerde leesvolgorde behouden blijft.
- De inhoud van dia's met meerdere kolommen indexeren of vergelijken.
- Elke kolom exporteren naar een afzonderlijk bestand, database‑veld of andere bestemming.
- Inspecteren hoe tekst wordt herverdeeld na het wijzigen van het aantal kolommen met [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setColumnCount), de tussenafstand met [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), het lettertype of de grootte van het tekstkader.

De methode meldt de tekst die is verdeeld binnen het huidige [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/), maar laat tekst niet automatisch van de ene vorm naar een andere of tussen tekstvakken stromen. Kolom‑verdeling kan afhangen van beschikbare lettertypen en andere tekst‑indelingsinstellingen, dus zorg ervoor dat de benodigde lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

Het volgende voorbeeld laadt een presentatie, vindt de eerste auto‑vorm met meerdere kolommen en een tekstkader, leest het geconfigureerde aantal kolommen, en schrijft de tekst van elke kolom naar een afzonderlijk bestand. Vormen die geen tekstkader bieden, worden overgeslagen.

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

## **Tekst bijwerken**

Om tekst door de hele presentatie bij te werken, doorloopt u de dia's en vormen, selecteert u auto‑vormen en bewerkt u vervolgens hun tekstgedeelten. Werken op gedeelten‑niveau maakt het mogelijk zowel tekst als teken‑opmaak te wijzigen.

Het volgende voorbeeld vervangt elke instantie van `years` door `months` in de tekst van auto‑vormen en maakt elk getroffen gedeelte vet:

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

Deze doorloop werkt alleen tekst bij in auto‑vormen. Tekst die is opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist een doorloop van de respectieve collecties van die objecten.

## **Een tekstvak met een hyperlink toevoegen**

Een hyperlink kan aan een specifiek tekstgedeelte worden toegewezen, zodat alleen die tekst als klikbare link fungeert. Gebruik [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) om het gedeelte te koppelen aan een externe URL.

Het volgende voorbeeld maakt gekoppelde tekst en slaat deze op in een presentatie:

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

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder op een master‑ of lay‑outdia?**

Een [placeholder](/slides/nl/nodejs-java/manage-placeholder/) kan zijn positie en opmaak overerven van een [master‑dia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) of een [layout‑dia](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/). Een regulier tekstvak is een onafhankelijke vorm op de dia waarop het werd gemaakt en krijgt geen placeholder‑gedrag wanneer de lay‑out verandert.

**Hoe kan ik tekst vervangen zonder de tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de doorloop tot vormen die instanties zijn van [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/), zoals getoond in het voorbeeld Tekst bijwerken. Grafieken, tabellen en SmartArt slaan tekst op in hun eigen objectmodellen, dus ze worden niet aangepast door die lus.