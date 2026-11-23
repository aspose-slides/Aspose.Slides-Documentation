---
title: Presentatietekst opmaken in JavaScript
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
- lettertype-eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit-eigenschap
- tekstframe-ankering
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Opmaak en stijl van tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Node.js via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak en de eerste alinea bevat de onderstaande tekst. Zowel dia‑ als vorm‑indexen beginnen bij nul. Voorbeelden die vetgedrukte passages selecteren, gebruiken effectieve opmaak, inclusief geërfde vetopmaak:

![Sample text](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoek en vervang tekst](/slides/nl/nodejs-java/search-and-replace-text/).

## **Tekstachtergrondkleur instellen**

Gebruik [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) voor individuele tekstfragmenten.

Het volgende voorbeeld stelt een lichtgrijze markering in als standaard voor de eerste alinea. Expliciete markeerkleuren op individuele fragmenten hebben voorrang boven deze standaard:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de markeerkleur in voor de gehele alinea.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The gray paragraph](gray_paragraph.png)

De onderstaande code‑voorbeeld toont hoe u de achtergrondkleur kunt instellen voor **tekstfragmenten met een vet lettertype**:

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
            // Stel de markeerkleur in voor het tekstfragment.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The gray text portions](gray_text_portions.png)

## **Tekst‑alinea’s uitlijnen**

Gebruik [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) om de uitlijning van een alinea binnen een tekstframe in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld laat zien hoe u de alinea naar het **midden** kunt uitlijnen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Stel de uitlijning van de alinea in op midden.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The aligned paragraph](aligned_paragraph.png)

## **Lettertypes binnen een regel uitlijnen**

Gebruik [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) om tekstfragmenten met verschillende lettergroottes binnen een regel verticaal uit te lijnen. Deze instelling geldt voor de hele alinea en regelt de uitlijning binnen elke regel.

Het volgende zelfstandige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst in 18, 36 en 54 punten, met een verschillende lettertype‑uitlijning. Het maakt gebruik van Arial, schakelt autofit en omslag uit, en houdt de tekstvakken groot genoeg voor één regel.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

Lettertype‑uitlijning maakt gebruik van font‑metriek, zodat de zichtbare randen van individuele letters niet per se exact op één lijn liggen. Het voorbeeld bevat zowel een hoofdletter als een neerhangend teken om het verschil tussen basislijn‑ en onderkant‑uitlijning te laten zien. Beschikbaarheid van lettertypes en substitutie, de gebruikte tekens, en het verschil in lettergroottes beïnvloeden het resultaat. Frame‑afmetingen, marges, regel‑afstand, omslag en autofit beïnvloeden ook de lay‑out; gebruik dezelfde lettertypes en lay‑out‑instellingen bij het vergelijken van de modi.

Deze instelling verschilt van [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), die de horizontale alinea‑uitlijning regelt, en van [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), die het tekstblok verticaal binnen zijn vorm positioneert. Superscript‑ en subscript‑opmaak via [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) verschuift individuele fragmenten ten opzichte van de basislijn in plaats van de lettertype‑uitlijning voor de regellijnen van de alinea in te stellen.

## **Transparantie voor tekst instellen**

De transparantie van tekst wordt geregeld via het alfacomponent van de kleur die is toegewezen aan [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alphakanaalwaarde op de schaal 0–255, geen transparantie‑percentage.

Het onderstaande code‑voorbeeld toont hoe u transparantie kunt toepassen op de **hele alinea**:

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

![The transparent paragraph](transparent_paragraph.png)

Het volgende code‑voorbeeld toont hoe u transparantie kunt toepassen op **tekstfragmenten met een vet lettertype**:

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

            // Stel de transparantie van het tekstfragment in.
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

![The transparent text portions](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten afstand toe; negatieve waarden verkleinen de tekst.

De volgende JavaScript‑code laat zien hoe u de tekenafstand in de **hele alinea** kunt vergroten:

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

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Het onderstaande code‑voorbeeld toont hoe u de tekenafstand kunt vergroten in **tekstfragmenten met een vet lettertype**:

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

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypes uitschakelen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd iets strakker lijken dan dezelfde tekst die in PowerPoint wordt weergegeven. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypes kan negeren, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer in dergelijke gevallen dichter bij PowerPoint te laten lijken, kunt u kerning uitschakelen voor tekstfragmenten die het betreffende lettertype gebruiken. Stel [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) in op een waarde die groter is dan de werkelijke lettergrootte. Dit voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertypenamen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor fragmenten die Roboto gebruiken. Dit schakelt kerning uit voor overeenkomende fragmenten met een lettergrootte lager dan 100 punten:

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

Voor overeenkomende tekst onder de drempel voorkomt deze instelling kerning en kan het helpen de weergave van Aspose.Slides op de visuele output van PowerPoint af te stemmen voor lettertypen die door dit PowerPoint‑specifieke gedrag zijn beïnvloed.

## **Tekst‑lettertype‑eigenschappen beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) of op individuele fragmenten via [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op 12‑punt Times New Roman met vet, cursief en stippellijn‑onderstreping. Expliciete opmaak op individuele fragmenten heeft voorrang boven deze standaarden:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
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

![The font properties for the paragraph](font_properties_for_paragraph.png)

Het volgende voorbeeld past 13‑punt Times New Roman, cursieve opmaak en een stippellijn‑onderstreping toe op fragmenten waarvan de effectieve opmaak vet is:

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

            // Stel de lettertype‑eigenschappen in voor het tekstfragment.
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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Normalisatie van teksthoogte beheren**

Gebruik [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) bij het reproduceren van sjabloontypografie of bij het onderzoeken van verschillen in tekenhoogte. In PowerPoint strekt het inschakelen van normalisatie individuele tekens verticaal uit of comprimeert ze om hen een uniforme zichtbare hoogte te geven binnen het tekstfragment. Het garandeert geen gelijke teksthoogtes tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool.True of False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) om normalisatie expliciet in of uit te schakelen. `NullableBool.NotDefined` laat de lokale instelling onbepaald, zodat het fragment de waarde erft, bijvoorbeeld van de alinea‑[getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat). Het betekent niet `False`. Gebruik [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) en lees [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) om de uiteindelijke Booleaanse waarde te verkrijgen.

Het volgende zelfstandige voorbeeld vereist dat **Arial** geïnstalleerd is. Het maakt twee tekstblokken aan die dezelfde hoofdletters, kleine letters, neerhangende tekens en accenten bevatten op 54 punten. Beide alinea's schakelen normalisatie standaard in. Het bovenste fragment schakelt het expliciet uit; het onderste fragment erft het. De frame‑groottes, marges en alinea‑afstand zijn identiek, met omslag en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld drukt `False: false` en `NotDefined: true` af, en slaat vervolgens "text_height_normalization.pptx" op.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De onderstaande vergelijking is geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

Normalisatie verandert de tekenhoogte zonder de toegewezen [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight)‑waarde te wijzigen, die de lettergrootte in punten aangeeft. Alinea‑[setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) regelt de regelafstand, terwijl tekst‑frame‑[setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst of de container zich aanpast om te passen. Deze instellingen dienen verschillende doelen en kunnen de algehele lay‑out onafhankelijk beïnvloeden. Voor meer informatie over alinea‑opmaak en overerving, zie [Alinea beheren](/slides/nl/nodejs-java/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) op een tekstfragment om correcties, geannuleerde termen of eerdere prijzen weer te geven zonder de oorspronkelijke tekst te verwijderen. Stel het in op [TextStrikethroughType.Single of Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) voor één of twee doorhalingsstrepen door de tekst.

Om doorhalen te verwijderen, geef [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None) door. Dit schakelt het effect expliciet uit, zelfs als de omringende opmaak doorhalen specificeert. Daarentegen laat [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) de lokale instelling onbepaald, waardoor het fragment de opmaak kan erven, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen verwijderd is. Gebruik [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) om de resulterende opmaak te lezen, inclusief geërfde waarden.

Het volgende zelfstandige voorbeeld maakt drie prijsvergelijkingen. Elke alinea heeft aparte fragmenten voor het label, de vorige prijs en de huidige prijs, zodat alleen de vorige prijs wordt beïnvloed. De eerste rij past doorhalen toe en verwijdert het vervolgens; de andere rijen behouden respectievelijk een enkele en een dubbele doorhaling. Het wijzigen van deze instelling behoudt de tekst en de andere opmaak, inclusief de vetgedrukte vorige prijs.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Pas doorhalen toe, en verwijder het daarna expliciet van de eerste vorige prijs.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat, van boven naar beneden: geen doorhaling, enkele doorhaling en dubbele doorhaling.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** draait:

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

![The text rotation](text_rotation.png)

## **Cijfers naast elkaar weergeven in verticale tekst**

Om een tweecijferig getal bij elkaar te houden in een verticale Japanse label, plaats beide cijfers in één tekstfragment en roep [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) aan op de opmaak van dat fragment. Het voorbeeld gebruikt [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) en 40‑punt MS Gothic voor beide labels. Alleen de [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/)‑waarde die aan het numerieke fragment wordt doorgegeven, verschilt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In PowerPoint toont het linkerlabe`l` (`True`) de cijfers rechtop en naast elkaar tussen 和 en 年. In het rechterlabel (`False`) is het tweetal 90 graden met de klok mee geroteerd. De omringende Japanse tekens blijven in beide labels rechtop.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Aangepaste rotatie voor tekstkaders instellen**

Gebruik [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

Het onderstaande code‑voorbeeld roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

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

![The custom text rotation](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) en [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

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

![The line spacing within the paragraph](line_spacing.png)

## **Regelafbreking beheersen**

Regelafbrekingsregels voor alinea's zijn nuttig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst mixen. De volgende methoden behoren tot [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), dus ze gelden voor een volledige alinea:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) regelt de regelafbrekingsregels voor Latijnse tekst. In gemengde tekst kan het wijzigen ervan ook bepalen waar aangrenzende Oost‑Aziatische tekst en interpunctie worden afgebroken.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) regelt de regelafbrekingsregels voor Oost‑Aziatische tekst, inclusief beperkingen op tekens aan het begin en einde van een regel.

Deze regels vervangen niet [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), die automatisch omslaan binnen een tekstframe mogelijk maakt. Ze beïnvloeden de lay‑out wanneer omslaan plaatsvindt; ze voegen geen regelafbreektekens in. Een expliciete regelafbreking dwingt een nieuwe regel af binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinese en Latijnse tekst. Het stelt beide regelafbrekingsopties expliciet in en slaat "line_breaking.pptx" op. Om met een van de regels te experimenteren, wijzig de bijbehorende waarde terwijl de andere instellingen ongewijzigd blijven. Het voorbeeld gebruikt 24‑punt Arial en SimSun met een frame‑breedte van 160 punten en nul horizontale tekst‑frame‑marges. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) wordt aangeroepen met [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) zodat de tekstgrootte en frame‑afmetingen vast blijven.

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

## **Hangende interpunctie beheersen**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) laat toelaatbare interpunctie uitsteken voorbij de rechterrand van de tekstregel in plaats van de volgende regel in te nemen. Het geldt voor de hele alinea en verschilt van een hangende inspringing.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een 100‑punt breed tekstframe in en slaat "hanging_punctuation.pptx" op. Met 24‑punt Arial en nul horizontale tekst‑frame‑marges blijft de laatste punt achter "sentence" staan en strekt zich uit voorbij de rechtertekst‑rand. Stel de eigenschap in op [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen neemt de punt een aparte regel in. Omslaan is ingeschakeld en autofit is uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk leesteken kan hangen. De [lettertype‑ en lay‑out‑voorwaarden die hierboven zijn beschreven](#control-line-breaking) gelden ook voor deze vergelijking: het wijzigen van het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil verwijderen.

## **Autofit‑type voor tekstkaders instellen**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt, of de vorm automatisch aanpast. Het volgende voorbeeld configureert de vorm om te schalen zodat de tekst past en slaat het resultaat op in "autofit_type.pptx".

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

Om het aantal regels te tellen na automatisch omslaan en te zien hoe tekst‑ of vormbreedte het resultaat wijzigt, zie [Getelde weergegeven regels](/slides/nl/nodejs-java/manage-paragraph/). Het aantal regels alleen geeft niet aan of tekst buiten de container overlapt.

## **Anker van tekstkaders instellen**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) bepaalt hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op in "text_anchor.pptx".

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

## **Tekst‑tabulatie instellen**

Gebruik [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) en [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑intervallen in op 100 punten en voegt een links‑gealigneerde tab‑stop toe op 30 punten. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

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

![The paragraph tabs](paragraph_tabs.png)

## **Controlerende taal instellen**

Aspose.Slides biedt [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), waarmee u de correctietaal voor een tekstfragment kunt instellen. De correctietaal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist "presentation.pptx" met een tekstvak als eerste vorm op de eerste dia en minstens één alinea. Het vervangt de inhoud van de eerste alinea door "1。", stelt SimSun in als lettertype en wijst de vereenvoudigde Chinese correctietaal toe (`zh-CN`). Het slaat het resultaat op in "proofing_language.pptx":

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

    // Stel de Id van een correctietaal in.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Taalmetadata kopiëren**

Bij het kopiëren van meertalige tekst uit een sjabloon, bewaar zowel [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) als [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Het volgende zelfstandige voorbeeld maakt een bron‑fragment met VS‑Engels als taal en Frans als alternatieve taal en kopieert de tekst en identificatoren naar een fragment in een nieuwe presentatie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Als de bron geen alternatieve taal heeft, null maakt de doelwaarde leeg.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om een bron zonder alternatieve taal te proberen, laat de toewijzing van "fr-FR" weg. De alternatieve identifier is dan `null`, en dezelfde kopie‑instructie behoudt de afwezigheid zonder een standaardwaarde toe te voegen, zelfs als de bestemming eerder een alternatieve taal had toegewezen.

Deze identificatoren worden opgeslagen als taalmetadata. Het behouden ervan bepaalt niet welke woordenboek PowerPoint kiest voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de standaardtaal te definiëren voor tekst die bij het laden of maken van een presentatie wordt aangemaakt. Het volgende voorbeeld maakt een presentatie met VS‑Engels als standaardteksttaal, voegt een tekstvak toe, en drukt `en-US` af voor het eerste tekstfragment.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Voeg een nieuw rechthoekvorm met tekst toe.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Controleer de taal van het eerste tekstfragment.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Standaardtekstopmaak instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea's van het hoogste niveau in een nieuwe presentatie en slaat het op in "default_text_style.pptx". Tekst kan deze standaarden overerven tenzij meer specifieke opmaak ze overschrijft.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Haal het alineaformaat van het hoogste niveau op.
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

In PowerPoint maakt het toepassen van het **All Caps**‑fonteffect de tekst in hoofdletters zichtbaar op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo'n tekstfragment opvraagt met Aspose.Slides, geeft de bibliotheek de tekst precies terug zoals ingevoerd. Om de weergegeven tekst te matchen, controleer [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) en zet de geretourneerde tekenreeks om naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist "sample2.pptx" met een tekstvak als eerste vorm op de eerste dia. Het eerste fragment van de eerste alinea bevat "Hello, Aspose!" met het All Caps‑effect toegepast, zoals hieronder weergegeven.

![The All Caps effect](all_caps_effect.png)

Het onderstaande code‑voorbeeld toont hoe u de tekst kunt extraheren met het **All Caps**‑effect toegepast:

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

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) en alinea‑opmaak via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Hoe pas ik een gradient‑kleur toe op tekst in een PowerPoint‑dia?**

Om een gradient‑kleur op tekst toe te passen, gebruik [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Stel [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) in op [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) en configureer de gradient‑stops, richting en transparantie.