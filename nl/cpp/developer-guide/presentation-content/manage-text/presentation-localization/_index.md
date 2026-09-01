---
title: Automatiseer presentatie‑lokalisatie in C++
linktitle: Presentatie‑lokalisatie
type: docs
weight: 100
url: /nl/cpp/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- spellingcontrole onderdrukken
- proefleertaal
- taal‑id
- meertalige tekst
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Stel proefleertalen in voor PowerPoint‑ en OpenDocument‑presentatietekst in C++ met Aspose.Slides, inclusief standaardwaarden en meertalige alinea's."
---
## **Overzicht**

Aspose.Slides for C++ stelt u in staat om proefleermetadata voor afzonderlijke tekstgedeelten te configureren. Gebruik [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_languageid/) om de proefleertaal te identificeren, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_spellcheck/) om spellingcontroles toe te staan of te onderdrukken, en [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_proofdisabled/) om de bredere “geen proef”-status te regelen. Omdat deze instellingen op gedeelte‑niveau worden toegepast, kan één alinea meerdere talen en verschillende proefleerrichtlijnen bevatten.

Dit artikel legt uit hoe u een taal toewijst aan specifieke tekst, de standaardtaal voor nieuwe tekst instelt met [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), meertalige alinea's bouwt, kiest tussen `SpellCheck` en `ProofDisabled`, en de bedoelde instellingen behoudt bij gebruik van [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Deze eigenschappen slaan metadata op voor presentatie‑applicaties; ze vertalen de tekst niet, voeren geen op woordenboek gebaseerde spellingcontrole uit en geven geen onjuiste woorden terug.

## **Stel de proefleertaal in voor tekst**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/), krijg toegang tot het benodigde tekstgedeelte via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/get_portionformat/), en ken zijn taal‑identificatie toe. Het volgende voorbeeld maakt een vorm, stelt Brits Engels in als proefleertaal, en slaat het resultaat op met [Presentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Stel de standaardtaal in voor nieuwe tekst**

Gebruik [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) om de proefleertaal op te geven die Aspose.Slides toewijst aan nieuw aangemaakte tekst. Deze instelling is handig wanneer het grootste deel of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Het wijzigt de taal‑metadata van tekst die reeds een expliciete taal heeft niet.

Het volgende voorbeeld maakt een presentatie waarvan de nieuwe tekst Duitse proefleerrichtlijnen gebruikt:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gebruik meerdere talen in één alinea**

Een [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) bevat een collectie tekstgedeelten. Maak een afzonderlijke [Portion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portion/) voor elke taal en stel de `LanguageId` onafhankelijk in.

Dit voorbeeld maakt één alinea met Engelse en Franse gedeelten:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Schakel spellingcontrole in of onderdrukken voor individuele gedeelten**

[IPortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportionformat/) erft de gemeenschappelijke texteigenschappen die gedefinieerd zijn door [IBasePortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/). Toegang tot het formaat van een gedeelte via [IPortion::get_PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/get_portionformat/) en roep [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_spellcheck/) aan om te bepalen of een presentatie‑applicatie spelling voor dat gedeelte mag controleren. De standaardwaarde is `false`: `true` staat spellingcontrole toe, terwijl `false` het onderdrukt.

De instelling geldt voor individuele tekstgedeelten. Verschillende gedeelten in dezelfde alinea kunnen daarom verschillende waarden gebruiken. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/) en `SpellCheck` dienen complementaire doelen: `LanguageId` identificeert de proefleertaal, terwijl `SpellCheck` bepaalt of spellingcontroles voor het gedeelte zijn toegestaan.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_proofdisabled/) regelt ook proeflezen, maar het vertegenwoordigt de bredere “niet proef‑lezen”‑status als een [NullableBool](https://reference.aspose.com/slides/nl/cpp/aspose.slides/nullablebool/). Gebruik `SpellCheck` wanneer u een directe Booleaanse schakelaar specifiek voor spellingcontroles nodig hebt. Gebruik `ProofDisabled` wanneer u de “geen proef”‑metadata van de presentatie wilt behouden of expliciet wilt beheren, inclusief de status `NullableBool::NotDefined`. Als u beide eigenschappen instelt, houd hun waarden consistent; combineer niet `SpellCheck = true` met `ProofDisabled = NullableBool::True`.

Deze eigenschappen configureren proefleermetadata die door PowerPoint en andere presentatie‑applicaties wordt gebruikt. Aspose.Slides gebruikt ze niet om op woordenboek gebaseerde spellingcontrole uit te voeren of een lijst met fout gespelde woorden terug te geven.

Het volgende volledige voorbeeld maakt een invoer‑presentatie, laadt deze, wijst verschillende spelling‑instellingen en proefleertalen toe aan twee gedeelten in dezelfde alinea, slaat het resultaat op, opent het opnieuw, en verifieert de opgeslagen waarden:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/joinportionswithsameformatting/) combineert aangrenzende gedeelten die dezelfde opmaak hebben. Een verschil in alleen `SpellCheck` houdt dergelijke gedeelten niet gescheiden; nadat ze zijn samengevoegd, behoudt het resulterende gedeelte de `SpellCheck`‑waarde van het eerste gedeelte. Als gedeelten verschillende spelling‑instellingen nodig hebben, roep dan `JoinPortionsWithSameFormatting` aan vóór het toewijzen van die instellingen, of inspecteer de resulterende gedeelte‑grenzen en pas de instellingen daarna opnieuw toe. Gedeelten met verschillende `LanguageId`‑waarden blijven gescheiden omdat hun proefleertaalkoppeling verschilt.

## **Veelgestelde vragen**

**Vertalen een taal‑ID de tekst?**

Nee. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_languageid/) slaat proefleermetadata op voor spelling en grammatica; het wijzigt de tekstinhoud niet. Vertaal de tekst apart en stel vervolgens de juiste taal‑identificatie in voor elk vertaald gedeelte.

**Bepaalt de proefleertaal lettertypen, afbrekingen of regelafbreking?**

Nee. De taalidentificatie dient alleen voor proeflezen. Tekstweergave en lay‑out hangen voornamelijk af van de beschikbare [lettertypen](/slides/nl/cpp/powerpoint-fonts/), het schrijfsysteem en de instellingen van het tekstkader. Voor betrouwbare weergave dient u de benodigde lettertypen te leveren, [lettertype‑vervanging](/slides/nl/cpp/font-substitution/) te configureren of [lettertypen in te sluiten](/slides/nl/cpp/embedded-font/) in de presentatie.

**Kan een alinea meerdere proefleertalen gebruiken?**

Ja. Wijs elke taal toe aan een afzonderlijk gedeelte, zoals geïllustreerd in het voorbeeld van een meertalige alinea.

**Moet ik `DefaultTextLanguage` of `LanguageId` gebruiken?**

Gebruik [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) wanneer u een standaard wilt voor nieuw aangemaakte tekst. Gebruik [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_languageid/) wanneer een specifiek gedeelte een expliciete proefleertaal nodig heeft of wanneer een alinea meerdere talen bevat.