---
title: Opmaak van presentatietekst in JavaScript
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/nodejs-java/text-formatting/
keywords:
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype‑eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstkader
- regelafstand
- autofit‑eigenschap
- ankering tekstkader
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Formateer en style tekst in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Node.js via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst opmaakt in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekstverankering, tabstops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea bevat de onderstaande tekst. Zowel dia‑ als vorm‑indices beginnen bij nul. Voorbeelden die vette delen selecteren gebruiken effectieve opmaak, inclusief geërfde vette opmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere-expressie‑overeenkomsten te zoeken en te markeren, zie [Tekst zoeken en vervangen](/slides/nl/nodejs-java/search-and-replace-text/).

## **Achtergrondkleur van tekst instellen**

Gebruik [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) voor individuele tekstdelen.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele delen hebben voorrang op deze standaard:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de markeerkleur in voor de hele alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

Het code‑voorbeeld hieronder laat zien hoe u de achtergrondkleur instelt voor **tekstdelen met een vet lettertype**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Stel de markeerkleur in voor het tekstgedeelte.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De grijze tekstdelen](gray_text_portions.png)

## **Tekst‑alinea’s uitlijnen**

Gebruik [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) om de uitlijning van een alinea binnen een tekstkader in te stellen. De waarde kan gecentreerd, links uitgelijnd, rechts uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld toont hoe u de alinea naar het **midden** uitlijnt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de uitlijning van de alinea in op het midden.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie van tekst instellen**

De transparantie van tekst wordt geregeld via de alfa‑component van de kleur die is toegewezen aan [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfa‑kanaalwaarde op de schaal 0–255, geen transparantie‑percentage.

Het code‑voorbeeld hieronder laat zien hoe u transparantie toepast op de **hele alinea**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Stel de vulkleur van de tekst in op een transparante kleur.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld laat zien hoe u transparantie toepast op **tekstdelen met een vet lettertype**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Stel de transparantie van het tekstgedeelte in.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante tekstdelen](transparent_text_portions.png)

## **Tekensprong van tekst instellen**

Gebruik [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten afstand toe; negatieve waarden verkleinen de tekst.

De volgende JavaScript‑code toont hoe u de tekensprong in de **hele alinea** kunt vergroten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekensprong in de alinea](character_spacing_in_paragraph.png)

Het code‑voorbeeld hieronder toont hoe u de tekensprong in **tekstdelen met een vet lettertype** kunt vergroten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Opmerking: gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.getPortionFormat().setSpacing(3); // Vergroot de tekenafstand.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekensprong in de tekstdelen](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan de tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer in dergelijke gevallen dichter bij PowerPoint te krijgen, kunt u kerning uitschakelen voor tekstdelen die het betreffende lettertype gebruiken. Stel [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) in op een waarde die groter is dan de werkelijke lettergrootte. Dit voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertypenamen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor delen die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende delen met een lettergrootte kleiner dan 100 punten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor overeenkomende tekst onder de drempel voorkomt deze instelling kerning en kan het helpen om de weergave van Aspose.Slides beter te laten overeenkomen met de visuele uitvoer van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden getroffen.

## **Eigenschappen van tekstlettertype beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) of op individuele delen via [PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en een gestippelde onderstreping. Expliciete opmaak op individuele delen heeft voorrang op deze standaardinstellingen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Stel de lettertype-eigenschappen in voor de alinea.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een gestippelde onderstreping toe op delen waarvan de effectieve opmaak vet is:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Stel de lettertype-eigenschappen in voor het tekstgedeelte.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De lettertype‑eigenschappen voor tekstdelen](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** roteert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstkaders instellen**

Gebruik [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).

Het code‑voorbeeld hieronder roteert het tekstkader met 3 graden met de klok mee binnen de vorm:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), en [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om regelafstand in punten op te geven.

Het volgende voorbeeld stelt de afstand binnen de eerste alinea in op 200 % van de regelhoogte (dubbele regelafstand):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Regelafbreking regelen**

Regelafbreekregels voor alinea's zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende methoden behoren tot [ParagraphFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/), dus ze gelden voor een volledige alinea:

- [setLatinLineBreak](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) regelt de regelafbreekregels voor Latijn. In gemengde tekst kan het wijzigen ervan ook invloed hebben op waar aangrenzende Oost‑Aziatische tekst en interpunctie omslaan.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) regelt de regelafbreekregels voor Oost‑Aziatische tekst, inclusief beperkingen op tekens aan het begin en einde van een regel.

Deze regels vervangen niet [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-), dat automatisch afbreken binnen een tekstkader inschakelt. Ze beïnvloeden de lay-out wanneer er wordt afgebroken; ze voegen geen regelafbreek‑tekens toe. Een expliciete regelafbreking dwingt een nieuwe regel binnen de alinea af, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regelafbreek‑opties expliciet in en slaat "line_breaking.pptx" op. Om met een van de regels te experimenteren, wijzigt u de bijbehorende waarde terwijl u de andere instellingen onveranderd laat. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een kaderbreedte van 160 punten en nul horizontale tekstkader‑marges. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) wordt aangeroepen met [TextAutofitType.None](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textautofittype/) zodat tekstgrootte en kaderafmetingen vast blijven.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hangende interpunctie regelen**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) staat toe dat in aanmerking komende interpunctie zich uitstrekt voorbij de rechterkant van de tekstlijn in plaats van de volgende regel in te nemen. Het geldt voor de volledige alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in in een tekstkader van 100 punten breed en slaat "hanging_punctuation.pptx" op. Met 24‑punt Arial en nul horizontale tekstkader‑marges blijft de laatste punt achter "sentence" en rekt zich uit voorbij de rechterkant van de tekst. Stel de eigenschap in op [NullableBool.False](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/nullablebool/) voor vergelijking: met deze instellingen neemt de punt een aparte regel in. Afbreken is ingeschakeld en autofit is uitgeschakeld om de beschikbare breedte vast te houden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Niet elk leesteken kan hangen. Het zichtbare resultaat hangt af van de beschikbaarheid van lettertypen en de lay-out: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor tekstkaders instellen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt, of de vorm automatisch van grootte verandert. Het volgende voorbeeld configureert de vorm om te schalen zodat de tekst past en slaat het resultaat op in "autofit_type.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om het aantal regels na automatisch afbreken te tellen en te zien hoe de tekst of de breedte van de vorm het resultaat verandert, zie [Aantal gerenderde regels](/slides/nl/nodejs-java/manage-paragraph/). Alleen het aantal regels geeft niet aan of de tekst buiten de container overstroomt.

## **Anker van tekstkaders instellen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op in "text_anchor.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabulatie van tekst instellen**

Gebruik [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) en [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#getTabs--) om tabstops in een alinea te configureren. Het volgende voorbeeld stelt de standaardtab‑intervallen in op 100 punten en voegt een links uitgelijnde tabstop toe op 30 punten. Deze instellingen beïnvloeden tekst met tab‑tekens.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Controletaal instellen**

Aspose.Slides biedt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), waarmee u de controletaal voor een tekstdel kunt instellen. De controletaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia en minstens één alinea. Het vervangt de inhoud van de eerste alinea door "1。", stelt SimSun in als lettertype en wijst de vereenvoudigde Chinese controletaal (`zh-CN`) toe. Het slaat het resultaat op in "proofing_language.pptx":

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Stel de Id van een proeftaal in.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of creëren van een presentatie. Het volgende voorbeeld maakt een presentatie met Amerikaans Engels als standaardteksttaal, voegt een tekstvak toe en drukt `en-US` af voor het eerste tekstdel.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Voeg een nieuw rechthoekig vorm met tekst toe.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Controleer de taal van het eerste tekstgedeelte.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standaardtekstopmaak instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea's op het hoogste niveau in een nieuwe presentatie en slaat het op in "default_text_style.pptx". Tekst kan deze standaardwaarden erven tenzij meer specifieke opmaak ze overschrijft.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Verkrijg het alineaformaat van het hoogste niveau.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekst extraheren met het All‑Caps‑effect**

In PowerPoint maakt het toepassen van het **All Caps**‑lettertype‑effect dat tekst op de dia in hoofdletters wordt weergegeven, zelfs als het oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstdel opvraagt met Aspose.Slides, retourneert de bibliotheek de tekst precies zoals ingevoerd. Om overeen te komen met de weergegeven tekst, controleert u [TextCapType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textcaptype/) en zet u de geretourneerde tekenreeks om in hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist "sample2.pptx" met een tekstvak als eerste vorm op de eerste dia. Het eerste deel van de eerste alinea bevat "Hello, Aspose!" met het All Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All Caps‑effect](all_caps_effect.png)

Het code‑voorbeeld hieronder laat zien hoe u de tekst kunt extraheren met het **All Caps**‑effect toegepast:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe kan ik tekst in een tabel op een dia wijzigen?**

Om tekst in een tabel op een dia te wijzigen, gebruik [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/). Doorloop de cellen en werk elke cel bij via [Cell.getTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/#getTextFrame--) en alinea‑opmaak via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Hoe pas ik een kleurverloop toe op tekst in een PowerPoint‑dia?**

Om een kleurverloop op tekst toe te passen, gebruik [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Stel [FillFormat.setFillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) in op [FillType.Gradient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) en configureer de verloop‑stops, richting en transparantie.