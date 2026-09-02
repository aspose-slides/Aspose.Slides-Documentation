---
title: Automatiseer presentatielocalisatie in .NET
linktitle: Presentatielocalisatie
type: docs
weight: 100
url: /nl/net/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- spellingcontrole onderdrukken
- proefleestaal
- taal-ID
- meertalige tekst
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Stel proefleestalen in voor PowerPoint- en OpenDocument-presentatietekst in .NET met Aspose.Slides, inclusief standaardinstellingen en meertalige alinea's."
---
## **Overzicht**

Aspose.Slides for .NET laat u proeflezen metadata configureren voor afzonderlijke tekstgedeelten. Gebruik [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/languageid/) om de proefleestaal te identificeren, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/spellcheck/) om spellingcontroles toe te staan of te onderdrukken, en [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/proofdisabled/) om de bredere geen‑proef status te regelen. Omdat deze instellingen op het gedeelte‑niveau worden toegepast, kan één alinea meerdere talen en verschillende proeflezen‑regels bevatten.

Dit artikel legt uit hoe u een taal toewijst aan specifieke tekst, de standaardtaal voor nieuwe tekst instelt met [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/defaulttextlanguage/), meer‑talige alinea’s bouwt, kiest tussen `SpellCheck` en `ProofDisabled`, en de beoogde instellingen behoudt bij gebruik van [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/joinportionswithsameformatting/). Deze eigenschappen slaan metadata op voor presentatie‑applicaties; ze vertalen de tekst niet, voeren geen op‑woordenboek gebaseerde spellingcontrole uit, en geven geen verkeerd gespelde woorden terug.

## **Stel de proefleestaal in voor tekst**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/), krijg toegang tot het gewenste tekstgedeelte via [IPortion.PortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/portionformat/), en wijs de taal‑identifier toe. Het volgende voorbeeld maakt een vorm, stelt Brits‑Engels in als proefleestaal, en slaat het resultaat op met [Presentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Stel de standaardtaal in voor nieuwe tekst**

Gebruik [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/defaulttextlanguage/) om de proefleestaal op te geven die Aspose.Slides toewijst aan nieuw aangemaakte tekst. Deze instelling is nuttig wanneer de meeste of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Het wijzigt niet de taal‑metadata van tekst die al een expliciete taal heeft.

Het volgende voorbeeld maakt een presentatie waarbij de nieuwe tekst Duitse proefleesregels gebruikt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Gebruik meerdere talen in één alinea**

Een [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) bevat een collectie van tekstgedeelten. Maak een aparte [Portion](https://reference.aspose.com/slides/nl/net/aspose.slides/portion/) voor elke taal en stel diens `LanguageId` onafhankelijk in.

Dit voorbeeld maakt één alinea met Engelse en Franse gedeelten:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Schakel spellingcontrole in of onderdruk deze voor individuele gedeelten**

[IPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/) erft de algemene teksteigenschappen gedefinieerd door [IBasePortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/). Toegang tot het format van een gedeelte via [IPortion.PortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/portionformat/) en stel [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/spellcheck/) in om te bepalen of een presentatie‑applicatie spelling mag controleren voor dat gedeelte. De standaardwaarde is `false`: `true` staat spellingcontrole toe, terwijl `false` deze onderdrukt.

De instelling geldt voor afzonderlijke tekstgedeelten. Verschillende gedeelten in dezelfde alinea kunnen daardoor verschillende waarden gebruiken. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/languageid/) en `SpellCheck` dienen complementaire doelen: `LanguageId` identificeert de proefleestaal, terwijl `SpellCheck` bepaalt of spellingcontroles zijn toegestaan voor het gedeelte.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/proofdisabled/) regelt ook proeflezen, maar het vertegenwoordigt de bredere "do not proof"‑status als een [NullableBool](https://reference.aspose.com/slides/nl/net/aspose.slides/nullablebool/). Gebruik `SpellCheck` wanneer u een directe Boolean‑schakelaar nodig hebt specifiek voor spellingcontroles. Gebruik `ProofDisabled` wanneer u de geen‑proef‑metadata van de presentatie wilt behouden of expliciet wilt regelen, inclusief de `NotDefined`‑status. Als u beide eigenschappen instelt, houd hun waarden consistent; combineer `SpellCheck = true` niet met `ProofDisabled = NullableBool.True`.

Deze eigenschappen configureren proefleesmadata die worden gebruikt door PowerPoint en andere presentatie‑applicaties. Aspose.Slides maakt er geen gebruik voor het uitvoeren van op‑woordenboek gebaseerde spellingcontrole of het retourneren van een lijst met verkeerd gespelde woorden.

Het volgende volledige voorbeeld maakt een invoerpresentatie, laadt deze, kent verschillende spelling‑instellingen en proefleestalen toe aan twee gedeelten in dezelfde alinea, slaat het resultaat op, opent het opnieuw, en verifieert de opgeslagen waarden:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/joinportionswithsameformatting/) combineert aangrenzende gedeelten die dezelfde opmaak hebben. Een verschil in `SpellCheck` alleen houdt dergelijke gedeelten niet gescheiden; nadat ze zijn samengevoegd, behoudt het resulterende gedeelte de `SpellCheck`‑waarde van het eerste gedeelte. Als gedeelten verschillende spelling‑instellingen nodig hebben, roep `JoinPortionsWithSameFormatting` aan voordat u die instellingen toekent, of inspecteer de resulterende gedeelte‑grenzen en pas de instellingen daarna opnieuw toe. Gedeelten met verschillende `LanguageId`‑waarden blijven gescheiden omdat hun proefleestaak‑opmaak verschilt.

## **FAQ**

**Vertalt een taal‑ID de tekst?**

Nee. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/languageid/) slaat proefleesmadata op voor spelling en grammatica; het wijzigt de tekstinhoud niet. Vertaal de tekst apart, en stel vervolgens de juiste taal‑identifier in voor elk vertaald gedeelte.

**Beheert de proefleestaal lettertypen, koppeltekengebruik of regelafbreking?**

Nee. De taal‑identifier is uitsluitend voor proeflezen. Tekstweergave en lay‑out hangen voornamelijk af van de beschikbare [fonts](/slides/nl/net/powerpoint-fonts/), het schrijfsysteem, en de instellingen van het tekst‑frame. Voor betrouwbare weergave, zorg voor de benodigde lettertypen, configureer [font substitution](/slides/nl/net/font-substitution/), of [embed fonts](/slides/nl/net/embedded-font/) in de presentatie.

**Kan één alinea verschillende proefleestalen gebruiken?**

Ja. Wijs elke taal toe aan een afzonderlijk gedeelte, zoals getoond in het voorbeeld van een meertalige alinea.

**Moet ik `DefaultTextLanguage` of `LanguageId` gebruiken?**

Gebruik [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/defaulttextlanguage/) wanneer u een standaard wilt voor nieuw aangemaakte tekst. Gebruik [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/languageid/) wanneer een specifiek gedeelte een expliciete proefleestaal nodig heeft of wanneer een alinea meerdere talen bevat.