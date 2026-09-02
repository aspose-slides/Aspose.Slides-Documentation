---
title: Automatiseer presentatie‑lokalisatie in Java
linktitle: Presentatie‑lokalisatie
type: docs
weight: 100
url: /nl/java/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- spellingcontrole onderdrukken
- proefleestaal
- taal-id
- meertalige tekst
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Stel proefleestalen in voor PowerPoint- en OpenDocument-presentatietekst in Java met Aspose.Slides, inclusief standaardinstellingen en meertalige alinea's."
---
## **Overzicht**

Aspose.Slides for Java stelt u in staat om proefleegemetagegevens voor individuele tekstgedeeltes te configureren. Gebruik [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) om de proefleetaal te identificeren, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) om spellingcontroles toe te staan of te onderdrukken, en [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) om de bredere geen‑proef‑status te beheersen. Omdat deze instellingen op gedeelte‑niveau worden toegepast, kan één alinea meerdere talen en verschillende proefleesregels bevatten.

Dit artikel legt uit hoe u een taal toewijst aan specifieke tekst, de standaardtaal instelt voor nieuwe tekst met [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), meertalige alinea’s maakt, kiest tussen `SpellCheck` en `ProofDisabled`, en de beoogde instellingen behoudt bij gebruik van [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Deze eigenschappen slaan metagegevens op voor presentatietoepassingen; ze vertalen de tekst niet, voeren geen woordenboekgebaseerde spellingcontrole uit, en geven geen foutieve woorden terug.

## **Proefleestaal instellen voor tekst**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/), krijg toegang tot het gewenste tekstgedeelte via [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#getPortionFormat--), en wijs de taal‑identifier toe. Het volgende voorbeeld maakt een vorm, stelt Brits‑Engels in als proefleestaal, en slaat het resultaat op met [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Standaardtaal voor nieuwe tekst instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de proefleetaal op te geven die Aspose.Slides toekent aan nieuw aangemaakte tekst. Deze instelling is handig wanneer de meeste of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Ze wijzigt niet de taalmatagegevens van tekst die al een expliciete taal heeft.

Het volgende voorbeeld maakt een presentatie waarin de nieuwe tekst Duitse proefleesregels hanteert:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Meerdere talen in één alinea gebruiken**

Een [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) bevat een verzameling tekstgedeeltes. Maak een aparte [Portion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portion/) voor elke taal en stel de `LanguageId` onafhankelijk in.

Dit voorbeeld maakt één alinea met Engelse en Franse gedeeltes:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Spellingcontrole voor individuele gedeeltes in- of uitschakelen**

[IPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportionformat/) erft de gemeenschappelijke tekst‑eigenschappen die gedefinieerd zijn door [IBasePortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/). Verkrijg het formaat van een gedeelte via [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#getPortionFormat--) en gebruik [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) om te bepalen of een presentatietoepassing de spelling van dat gedeelte mag controleren. De standaardwaarde is `false`: `true` staat spellingcontrole toe, terwijl `false` dit onderdrukt.

De instelling geldt voor individuele tekstgedeeltes. Verschillende gedeeltes in dezelfde alinea kunnen derhalve verschillende waarden gebruiken. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) en `setSpellCheck` dienen complementaire doeleinden: `setLanguageId` identificeert de proefleetaal, terwijl `setSpellCheck` bepaalt of spellingcontroles zijn toegestaan voor het gedeelte.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) regelt eveneens proeflezen, maar vertegenwoordigt de bredere “niet‑proeven”‑status als een [NullableBool](https://reference.aspose.com/slides/nl/java/com.aspose.slides/nullablebool/). Gebruik `setSpellCheck` wanneer u een directe Boolean‑schakelaar specifiek voor spellingcontroles nodig heeft. Gebruik `setProofDisabled` wanneer u de metadata “geen‑proef” van de presentatie wilt behouden of expliciet wilt beheren, inclusief de `NotDefined`‑status. Als u beide eigenschappen instelt, houd de waarden consistent; combineer `setSpellCheck(true)` niet met `setProofDisabled(NullableBool.True)`.

Deze eigenschappen configureren proefleemetagegevens die door PowerPoint en andere presentatietoepassingen worden gebruikt. Aspose.Slides gebruikt ze niet om woordenboekgebaseerde spellingcontrole uit te voeren of een lijst met foutieve woorden terug te geven.

Het volgende volledige voorbeeld maakt een invoerpresentatie, laadt die, wijst verschillende spellingcontrole‑instellingen en proefleestalen toe aan twee gedeeltes in dezelfde alinea, slaat het resultaat op, opent het opnieuw, en verifieert de opgeslagen waarden:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) combineert aangrenzende gedeeltes die dezelfde opmaak hebben. Een verschil in `SpellCheck` alleen houdt dergelijke gedeeltes niet gescheiden; na het samenvoegen behoudt het resulterende gedeelte de `SpellCheck`‑waarde van het eerste gedeelte. Als gedeeltes verschillende spellingcontrole‑instellingen nodig hebben, roep `joinPortionsWithSameFormatting` aan vóór het toewijzen van die instellingen, of inspecteer de resulterende gedeelte‑grenzen en pas de instellingen daarna opnieuw toe. Gedeeltes met verschillende `LanguageId`‑waarden blijven gescheiden omdat hun proefleestaal‑opmaak verschilt.

## **FAQ**

**Verandert een taal‑ID de tekst?**

Nee. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) slaat proefleemetagegevens op voor spelling en grammatica; het wijzigt de tekstinhoud niet. Vertaal de tekst afzonderlijk en stel vervolgens de juiste taal‑identifier in voor elk vertaald gedeelte.

**Beheert de proefleestaal lettertypen, woordafbreking of regelafbreking?**

Nee. De taal‑identifier is uitsluitend voor proeflezen. Tekstweergave en lay‑out hangen voornamelijk af van de beschikbare [lettertypen](/slides/nl/java/powerpoint-fonts/), het schrijfsysteem en de instellingen van het tekst‑frame. Voor een betrouwbare weergave dient u de benodigde lettertypen te leveren, [lettertype‑substitutie](/slides/nl/java/font-substitution/) te configureren, of [lettertypen in te sluiten](/slides/nl/java/embedded-font/) in de presentatie.

**Kan één alinea meerdere proefleestalogissen gebruiken?**

Ja. Wijs elke taal toe aan een afzonderlijk gedeelte, zoals getoond in het voorbeeld van een meertalige alinea.

**Moet ik `setDefaultTextLanguage` of `setLanguageId` gebruiken?**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) wanneer u een standaard wilt voor nieuw aangemaakte tekst. Gebruik [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) wanneer een specifiek gedeelte een expliciete proefleestaal nodig heeft of wanneer een alinea meerdere talen bevat.