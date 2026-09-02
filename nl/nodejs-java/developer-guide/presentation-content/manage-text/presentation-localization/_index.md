---
title: Automatiseer presentatielocalisatie in JavaScript
linktitle: Presentatielocalisatie
type: docs
weight: 100
url: /nl/nodejs-java/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- spellingcontrole onderdrukken
- proefleertaal
- taal-id
- meertalige tekst
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Stel proefleertalen in voor PowerPoint‑ en OpenDocument‑presentatietekst in JavaScript met Aspose.Slides, inclusief standaardinstellingen en meertalige alinea’s."
---
## **Overzicht**

Aspose.Slides for Node.js via Java maakt het mogelijk om proefleermetadata voor individuele tekstgedeelten te configureren. Gebruik [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) om de proefleertaal te identificeren, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) om spellingcontroles toe te staan of te onderdrukken, en [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) om de bredere “niet‑proeven”‑status te beheren. Omdat deze instellingen op het niveau van een gedeelte worden toegepast, kan één alinea meerdere talen en verschillende proefleerregels bevatten.

Dit artikel legt uit hoe u een taal toekent aan specifieke tekst, de standaardtaal instelt voor nieuwe tekst met [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), meertalige alinea’s bouwt, kiest tussen `SpellCheck` en `ProofDisabled`, en de beoogde instellingen behoudt bij gebruik van [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Deze eigenschappen slaan metadata op voor presentatietoepassingen; ze vertalen geen tekst, voeren geen woordenboek‑gebaseerde spellingcontrole uit, of geven fout gespelde woorden terug.

## **Stel de proefleertaal in voor tekst**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/), krijg toegang tot het gewenste tekstgedeelte via [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#getPortionFormat--), en ken de taal‑identifier toe. Het volgende voorbeeld maakt een vorm, stelt Brits‑Engels in als proefleertaal, en slaat het resultaat op met [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Stel de standaardtaal in voor nieuwe tekst**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de proefleertaal te specificeren die Aspose.Slides toekent aan nieuw aangemaakte tekst. Deze instelling is handig wanneer de meeste of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Het wijzigt niet de taalm.metadata van tekst die al een expliciete taal heeft.

Het volgende voorbeeld maakt een presentatie waarvan nieuwe tekst Duitse proefleerregels hanteert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gebruik meerdere talen in één alinea**

Een [Paragraph](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/paragraph/) bevat een collectie van tekstgedeelten. Maak een apart [Portion](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) voor elke taal en stel zijn `LanguageId` onafhankelijk in.

Dit voorbeeld maakt één alinea met Engelse en Franse gedeelten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Schakel spellingcontrole in of onderdruk dit voor individuele gedeelten**

[PortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portionformat/) erft de algemene tekst‑eigenschappen gedefinieerd door [BasePortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/). Krijg een gedeelte’s opmaak via [Portion.getPortionFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/#getPortionFormat--) en gebruik [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) om te bepalen of een presentatietoepassing spelling mag controleren voor dat gedeelte. De standaardwaarde is `false`: `true` staat spellingcontrole toe, terwijl `false` het onderdrukt.

De instelling geldt voor individuele tekstgedeelten. Verschillende gedeelten in dezelfde alinea kunnen dus verschillende waarden hebben. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) en `setSpellCheck` dienen complementaire doelen: `setLanguageId` identificeert de proefleertaal, terwijl `setSpellCheck` bepaalt of spellingcontroles zijn toegestaan voor het gedeelte.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) regelt ook proefleermetadata, maar representeert de bredere “niet‑proeven”‑status als een [NullableBool](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/nullablebool/). Gebruik `setSpellCheck` wanneer u een directe Boolean‑schakelaar nodig heeft voor spellingcontroles. Gebruik `setProofDisabled` wanneer u de “no‑proof”‑metadata van de presentatie wilt behouden of expliciet wilt beheren, inclusief de `NotDefined`‑status. Als u beide eigenschappen instelt, houd hun waarden consistent; combineer niet `setSpellCheck(true)` met `setProofDisabled(NullableBool.True)`.

Deze eigenschappen configureren proefleermetadata die door PowerPoint en andere presentatietoepassingen wordt gebruikt. Aspose.Slides gebruikt ze niet om woordenboek‑gebaseerde spellingcontroles uit te voeren of een lijst van fout gespelde woorden terug te geven.

Het volgende volledige voorbeeld maakt een invoerpresentatie, laadt deze, kent verschillende spelling‑ en proefleertaalinstellingen toe aan twee gedeelten in dezelfde alinea, slaat het resultaat op, opent het opnieuw, en controleert de opgeslagen waarden:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) combineert aangrenzende gedeelten die dezelfde opmaak hebben. Een verschil in `SpellCheck` alleen houdt dergelijke gedeelten niet gescheiden; nadat ze zijn samengevoegd, behoudt het resulterende gedeelte de `SpellCheck`‑waarde van het eerste gedeelte. Als gedeelten verschillende spelling‑instellingen nodig hebben, roep dan `joinPortionsWithSameFormatting` aan voordat u die instellingen toekent, of inspecteer de resulterende grens en pas de instellingen daarna opnieuw toe. Gedeelten met verschillende `LanguageId`‑waarden blijven gescheiden omdat hun proefleer‑opmaak verschilt.

## **FAQ**

**Vertaalt een taal‑ID de tekst?**

Nee. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) slaat proefleermetadata op voor spelling en grammatica; het wijzigt niet de tekstinhoud. Vertaal de tekst apart en stel vervolgens de juiste taal‑identifier in voor elk vertaald gedeelte.

**Regelt de proefleertaal lettertypen, woordafbreking of regelafbreking?**

Nee. De taal‑identifier dient uitsluitend voor proefleermetadata. Tekstweergave en lay‑out hangen voornamelijk af van de beschikbare [fonts](/slides/nl/nodejs-java/powerpoint-fonts/), het schrijfsysteem en de instellingen van het tekst‑frame. Voor betrouwbare weergave moet u de vereiste lettertypen leveren, [font‑substitutie](/slides/nl/nodejs-java/font-substitution/) configureren, of [lettertypen insluiten](/slides/nl/nodejs-java/embedded-font/) in de presentatie.

**Kan één alinea meerdere proefleertalen gebruiken?**

Ja. Ken elke taal toe aan een apart gedeelte, zoals getoond in het voorbeeld van de meertalige alinea.

**Moet ik `setDefaultTextLanguage` of `setLanguageId` gebruiken?**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) wanneer u een standaard wilt voor nieuw aangemaakte tekst. Gebruik [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) wanneer een specifiek gedeelte een expliciete proefleertaal nodig heeft of wanneer een alinea meerdere talen bevat.