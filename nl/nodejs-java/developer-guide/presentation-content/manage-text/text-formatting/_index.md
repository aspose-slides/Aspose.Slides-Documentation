---
title: Opmaak van presentatietekst in JavaScript
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/nodejs-java/text-formatting/
keywords:
- tekst markeren
- reguliere expressie
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype‑eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstvak
- regelafstand
- autofit‑eigenschap
- verankering tekstvak
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Opmaak en stijl van tekst in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Node.js via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe je tekst opmaakt in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Node.js via Java. Het behandelt markering, achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑verankering, tab‑stops en taalinstellingen.

In de onderstaande voorbeelden gebruiken we een bestand met de naam “sample.pptx”, dat een enkel tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Tekst markeren**

Gebruik de [TextFrame.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-)‑methode wanneer je tekst wilt markeren die overeenkomt met een specifiek voorbeeld binnen een tekstvak. De methode past een markeerkleur toe op overeenkomende tekstfragmenten en kan worden gebruikt met [TextSearchOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/) om te bepalen hoe de zoekopdracht wordt uitgevoerd, bijvoorbeeld om alleen volledige woorden te matchen.

De code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Markeer het woord "try" in de vorm.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Markeer het woord "to" in de vorm.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De [TextFrame.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-)‑methode markeert tekstreeksen die worden gevonden met een reguliere expressie. In Node.js via Java wordt deze API aangeboden op [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/).

De code‑voorbeeld hieronder markeert alle woorden die **zeven of meer tekens** bevatten:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Markeer alle woorden met zeven of meer tekens.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Achtergrondkleur van tekst instellen**

Gebruik [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) voor individuele tekstgedeelten.

De volgende code‑voorbeeld toont hoe je de achtergrondkleur voor de **hele alinea** instelt:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

De code‑voorbeeld hieronder laat zien hoe je de achtergrondkleur instelt voor **tekstgedeelten met een vette opmaak**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst­alinea’s uitlijnen**

Gebruik [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) om de alinea‑uitlijning binnen een tekstvak in te stellen. De waarde kan gecentreerd, links‑gealigneerd, rechts‑gealigneerd, uitgevuld, enzovoort zijn.

De volgende code‑voorbeeld toont hoe je de alinea naar het **midden** uitlijnt:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de uitlijning van de alinea in op midden.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die is toegewezen aan [PortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getFillFormat--). In de voorbeelden hieronder is `alpha = 50` een ARGB‑alfa‑waarde op een schaal van 0‑255, geen transparantiepercentage.

De code‑voorbeeld hieronder toont hoe je transparantie toepast op de **hele alinea**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Stel de opvulkleur van de tekst in op een transparante kleur.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

De volgende code‑voorbeeld toont hoe je transparantie toepast op **tekstgedeelten met een vette opmaak**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) om de afstand tussen tekens in een tekstvak te vergroten of te verkleinen.

De volgende JavaScript‑code toont hoe je de tekenafstand in de **hele alinea** vergroot:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Vergroot de tekenafstand.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

De code‑voorbeeld hieronder toont hoe je de tekenafstand vergroot in **tekstgedeelten met een vette opmaak**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
            portion.getPortionFormat().setSpacing(3); // Vergroot de tekenafstand.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan de tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑data voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning in de PowerPoint‑instellingen is ingeschakeld.

Om de rendering dichter bij PowerPoint te brengen, kun je kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) in op een waarde die aanzienlijk groter is dan de daadwerkelijke lettergrootte:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen om de weergave van Aspose.Slides beter af te stemmen op die van PowerPoint voor de getroffen lettertypen.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/).

De volgende code stelt het lettertype en de tekststijl in voor de hele alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het lettertype Times New Roman toe op alle gedeelten in de alinea.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Stel de lettertype‑eigenschappen in voor de alinea.
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

De code‑voorbeeld hieronder past soortgelijke eigenschappen toe op **tekstgedeelten met een vette opmaak**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Stel de lettertype‑eigenschappen in voor het tekstgedeelte.
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

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

De volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op `Vertical270`, waardoor de tekst **90 graden tegen de klok in** wordt geroteerd:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste rotatie voor tekstvakken instellen**

Gebruik [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) om een aangepaste rotatiehoek voor een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) in te stellen.

De code‑voorbeeld hieronder roteert het tekstvak met 3 graden met de klok mee binnen de vorm:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van alinea’s instellen**

Aspose.Slides biedt [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) en [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

De volgende code‑voorbeeld toont hoe je de regelafstand binnen de alinea specificeert:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Autofit‑type voor tekstvakken instellen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te bepalen of de tekst verkleint, overloopt of de vorm automatisch schaalt.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verankering van tekstvakken instellen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) definieert hoe tekst verticaal gepositioneerd wordt binnen een vorm, bijvoorbeeld bovenaan, in het midden of onderaan.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabulatie van tekst instellen**

Gebruik [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) en [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraphformat/#getTabs--) om tab‑stops in een alinea te configureren.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Controlertaal instellen**

Aspose.Slides biedt [PortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), waarmee je de controle‑taal voor een tekstgedeelte kunt instellen. De controle‑taal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

De volgende code‑voorbeeld toont hoe je de controle‑taal voor een tekstgedeelte instelt:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Stel de Id van een controle‑taal in.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Voeg een nieuw rechthoekig vorm toe met tekst.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Controleer de taal van de eerste tekstgedeelte.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standaardtekst‑stijl instellen**

Om standaard tekstopmaak op presentatieniveau toe te passen, gebruik je [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

De volgende code‑voorbeeld toont hoe je een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia’s in een nieuwe presentatie.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Haal het alinea‑formaat van het hoogste niveau op.
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

## **Tekst extraheren met het hoofdletter‑effect**

In PowerPoint zorgt het **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer je zo’n tekstgedeelte ophaalt met Aspose.Slides, retourneert de bibliotheek de tekst precies zoals ingevoerd. Om overeen te komen met de weergegeven tekst, controleer je [TextCapType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textcaptype/) en converteer je de geretourneerde string naar hoofdletters wanneer de waarde `All` is.

Stel dat we het volgende tekstvak hebben op de eerste dia van het bestand sample2.pptx.

![Het All Caps‑effect](all_caps_effect.png)

De code‑voorbeeld hieronder toont hoe je de tekst extraheert met het **All Caps**‑effect toegepast:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik je [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.getTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/#getTextFrame--) en pas alinea‑opmaak toe via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Hoe pas ik een gradient‑kleur toe op tekst in een PowerPoint‑dia?**

Om een gradient‑kleur op tekst toe te passen, gebruik je [PortionFormat.getFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Stel [FillFormat.setFillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) in op [FillType.Gradient](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) en configureer de gradient‑stops, richting en transparantie.