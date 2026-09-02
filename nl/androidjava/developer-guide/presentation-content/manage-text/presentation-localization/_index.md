---
title: Automatisering van presentatie-lokalisatie op Android
linktitle: Presentatie-lokalisatie
type: docs
weight: 100
url: /nl/androidjava/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- spellingcontrole onderdrukken
- proefleestaal
- taal-id
- meertalige tekst
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Stel proefleestalen in voor PowerPoint- en OpenDocument-presentatietekst op Android met Aspose.Slides for Android via Java, inclusief standaardinstellingen en meertalige alinea's."
---
## **Overzicht**

Aspose.Slides for Android via Java stelt u in staat om proefleesmetadata voor afzonderlijke tekstgedeelten te configureren. Gebruik [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) om de proefleestaal te identificeren, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) om spellingcontroles toe te staan of te onderdrukken, en [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) om de bredere geen‑proefleesstatus te besturen. Omdat deze instellingen op deelniveau worden toegepast, kan één alinea meerdere talen en verschillende proefleesregels bevatten.

Dit artikel legt uit hoe u een taal toewijst aan specifieke tekst, de standaardtaal instelt voor nieuwe tekst met [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), meertalige alinea’s bouwt, kiest tussen `SpellCheck` en `ProofDisabled`, en de bedoelde instellingen behoudt bij gebruik van [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Deze eigenschappen slaan metadata op voor presentatie‑applicaties; ze vertalen geen tekst, voeren geen woordenboek‑gebaseerde spellingcontrole uit, en retourneren geen foutieve woorden.

## **De proefleestaal voor tekst instellen**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/), krijg toegang tot het gewenste tekstdeel via [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#getPortionFormat--), en wijs de taal‑identifier toe. Het volgende voorbeeld maakt een vorm, stelt Brits‑Engels in als proefleestaal, en slaat het resultaat op met [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

## **De standaardtaal voor nieuwe tekst instellen**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) om de proefleestaal op te geven die Aspose.Slides toekent aan nieuw aangemaakte tekst. Deze instelling is handig wanneer het grootste deel of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Het verandert de taal‑metadata niet van tekst die al een expliciete taal heeft.

Het volgende voorbeeld maakt een presentatie waarvan nieuwe tekst Duitse proefleesregels gebruikt:

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

Een [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) bevat een verzameling tekstdelen. Maak een afzonderlijk [Portion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portion/) voor elke taal en stel de `LanguageId` onafhankelijk in.

Dit voorbeeld maakt één alinea met Engelse en Franse delen:

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

## **Spellingcontrole voor individuele delen in- of uitschakelen**

[IPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportionformat/) erft de gemeenschappelijke teksteigenschappen die gedefinieerd zijn door [IBasePortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/). Krijg een deel’s opmaak via [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#getPortionFormat--) en gebruik [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) om te bepalen of een presentatie‑applicatie de spelling van dat deel mag controleren. De standaardwaarde is `false`: `true` staat spellingcontrole toe, terwijl `false` het onderdrukt.

De instelling geldt voor individuele tekstdelen. Verschillende delen in dezelfde alinea kunnen dus verschillende waarden hebben. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) en `setSpellCheck` dienen complementaire doelen: `setLanguageId` identificeert de proefleestaal, terwijl `setSpellCheck` bepaalt of spellingcontroles zijn toegestaan voor het deel.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) bestuurt ook proeflezen, maar representeert de bredere “niet proeflezen”‑status als een [NullableBool](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/nullablebool/). Gebruik `setSpellCheck` wanneer u een directe Booleaanse schakelaar nodig heeft specifiek voor spellingcontroles. Gebruik `setProofDisabled` wanneer u de geen‑proeflees‑metadata van de presentatie wilt behouden of expliciet wilt besturen, inclusief de `NotDefined`‑status. Als u beide eigenschappen instelt, houd hun waarden dan consistent; combineer `setSpellCheck(true)` niet met `setProofDisabled(NullableBool.True)`.

Deze eigenschappen configureren proefleesmetadata die door PowerPoint en andere presentatie‑applicaties worden gebruikt. Aspose.Slides gebruikt ze niet om woordenboek‑gebaseerde spellingcontroles uit te voeren of een lijst met foutieve woorden te retourneren.

Het volgende volledige voorbeeld maakt een invoer‑presentatie, laadt deze, wijst verschillende spelling‑checkinstellingen en proefleestalisten toe aan twee delen in dezelfde alinea, slaat het resultaat op, opent het opnieuw, en controleert de opgeslagen waarden:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) voegt aangrenzende delen samen die dezelfde opmaak hebben. Een verschil in `SpellCheck` alleen houdt dergelijke delen niet gescheiden; nadat ze zijn samengevoegd, behoudt het resulterende deel de `SpellCheck`‑waarde van het eerste deel. Als delen verschillende spelling‑checkinstellingen nodig hebben, roep `joinPortionsWithSameFormatting` dan aan voordat u die instellingen toewijst, of inspecteer de resulterende deel‑grenzen en pas de instellingen daarna opnieuw toe. Delen met verschillende `LanguageId`‑waarden blijven gescheiden omdat hun proeflees‑taalonmaak verschilt.

## **FAQ**

**Vertaalt een taal‑ID de tekst?**

Nee. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) slaat proefleesmetadata op voor spelling en grammatica; het wijzigt de tekstinhoud niet. Vertaal de tekst apart en stel vervolgens de juiste taal‑identifier in voor elk vertaald deel.

**Beheerst de proefleestaal lettertypen, afbreken of regelafbreking?**

Nee. De taal‑identifier is uitsluitend voor proeflezen. Tekstweergave en lay‑out hangen vooral af van de beschikbare [fonts](/slides/nl/androidjava/powerpoint-fonts/), het schriftsysteem en de instellingen van het tekstkader. Zorg voor de benodigde lettertypen, configureer [font substitution](/slides/nl/androidjava/font-substitution/), of [embed fonts](/slides/nl/androidjava/embedded-font/) in de presentatie voor betrouwbare weergave.

**Kan een alinea meerdere proefleestaligen gebruiken?**

Ja. Ken elke taal toe aan een apart deel, zoals getoond in het voorbeeld van een meertalige alinea.

**Moet ik `setDefaultTextLanguage` of `setLanguageId` gebruiken?**

Gebruik [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) wanneer u een standaard wilt voor nieuw aangemaakte tekst. Gebruik [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) wanneer een specifiek deel een expliciete proefleestaal nodig heeft of wanneer een alinea meerdere talen bevat.