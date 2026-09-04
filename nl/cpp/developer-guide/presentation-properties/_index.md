---
title: Beheer presentatie‑eigenschappen in C++
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/cpp/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- document‑eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document‑metadata
- metadata bewerken
- proefleestaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer de presentatie‑eigenschappen in Aspose.Slides voor C++ en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Introductie**

Aspose.Slides ondersteunt twee typen documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd met de Aspose.Slides API.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_documentproperties/). De volgende voorbeelden laten zien hoe deze eigenschappen gelezen, gewijzigd en beheerd kunnen worden.

{{% alert color="info" title="Opmerking" %}}
Let op dat u geen waarden kunt instellen voor de **Application**- en **Producer**-velden, omdat Aspose Ltd. en Aspose.Slides voor C++ x.x.x in deze velden worden weergegeven.
{{% /alert %}} 

## **Beheer presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om enkele eigenschappen toe te voegen aan presentatie‑bestanden. Deze documenteigenschappen maken het mogelijk om nuttige informatie op te slaan samen met de documenten (presentatie‑bestanden). Er zijn twee soorten documenteigenschappen:

- Systeem‑gedefinieerde (Ingebouwde) eigenschappen  
- Door gebruiker gedefinieerde (Aangepaste) eigenschappen  

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals documenttitel, naam van de auteur, documentstatistieken enzovoort. **Aangepaste** eigenschappen zijn die welke door de gebruikers worden gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden bepaald. Met Aspose.Slides voor C++ kunnen ontwikkelaars de waarden van zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen. Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatie‑bestanden te beheren. Klik simpelweg op het Office‑icoontje en vervolgens op **Voorbereiden | Eigenschappen | Geavanceerde eigenschappen** in Microsoft PowerPoint 2007. Na het kiezen van **Geavanceerde eigenschappen** verschijnt een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren. In het **Eigenschappen‑dialoog** ziet u onder andere tabbladen **Algemeen**, **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Elk tabblad maakt het mogelijk verschillende soorten informatie met betrekking tot de PowerPoint‑bestanden te configureren. Het tabblad **Aangepast** wordt gebruikt om aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openings­wachtwoord beschermt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie wordt versleuteld door `false` door te geven aan [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens `true` doorgeven aan [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) en de openbare metadata lezen zonder het openings­wachtwoord te verstrekken.

`set_OnlyLoadDocumentProperties` bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen zijn opgenomen in de versleuteling, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het volgende voorbeeld verifieert de laadmodus via [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) en leest vervolgens ingebouwde eigenschappen via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

In deze modus wordt de slide‑inhoud niet geladen. Slides, masters, layouts, shapes, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd `get_IsOnlyDocumentPropertiesLoaded` controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Waarschuwing" %}}
Openbare metadata kan auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Houd ze alleen openbaar wanneer indexerings‑, classificatie‑, zoek‑ of document‑beheersystemen een specifieke eis hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die na het aanroepen van `set_OnlyLoadDocumentProperties(true)` is geladen, bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat alleen‑metadata‑object niet opslaan, omdat de openbare eigenschappen consistent moeten blijven met de bijbehorende gegevens in de versleutelde presentatie. Het bijwerken hiervan vereist daarom het correcte openings­wachtwoord en een volledige lading.

Het volgende voorbeeld opent de presentatie met [LoadOptions::set_Password](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_password/), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt met [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) gecontroleerd of de versleuteling behouden blijft en wordt de openbare metadata opnieuw geopend zonder wachtwoord om de nieuwe waarden te verifiëren:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Als een applicatie niet is toegestaan om de presentatie‑inhoud te ontsleutelen of te laden, moet zij openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

Deze eigenschappen, zoals blootgelegd door het **IDocumentProperties**‑object, omvatten: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** en **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentatie‑bestanden is net zo eenvoudig als ze benaderen. U kunt eenvoudig een tekenreeks‑waarde toewijzen aan elke gewenste eigenschap en de eigenschapswaarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe de ingebouwde documenteigenschappen van het presentatie‑bestand kunnen worden gewijzigd.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Aangepaste presentatie‑eigenschappen toevoegen**

Aspose.Slides voor C++ maakt het ook mogelijk voor ontwikkelaars om aangepaste waarden voor presentatiedocumenteigenschappen toe te voegen. Hieronder staat een voorbeeld dat laat zien hoe de aangepaste eigenschappen voor een presentatie worden ingesteld.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantieer de Presentation‑klasse
auto presentation = System::MakeObject<Presentation>();

// Documenteigenschappen ophalen
auto documentProperties = presentation->get_DocumentProperties();

// Aangepaste eigenschappen toevoegen
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Eigenschapsnaam ophalen op een specifieke index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Geselecteerde eigenschap verwijderen
documentProperties->RemoveCustomProperty(getPropertyName);

// Presentatie opslaan
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides voor C++ maakt het ook mogelijk voor ontwikkelaars om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen voor een presentatie kunt benaderen en wijzigen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Proefleessysteemtaal instellen**

Aspose.Slides biedt de [LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/)‑eigenschap (blootgelegd door de [PortionFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/portionformat/)‑klasse) om de proefleestaal voor een PowerPoint‑document in te stellen. De proefleestaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze C++‑code toont hoe u de proefleestaal voor een PowerPoint‑document kunt instellen:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Standaardtaal instellen**

Deze C++‑code toont hoe u de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Voeg een nieuwe rechthoekvorm met tekst toe
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Controleert de taal van de eerste portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Live‑voorbeeld**

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal deel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of ze leeg instellen als de specifieke eigenschap dat toestaat.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven met de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) en vervolgens [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/cpp/examine-presentation/) voor een compleet voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings­wachtwoord?**

Ja. De presentatie moet zijn versleuteld door `false` door te geven aan `set_EncryptDocumentProperties`, en moet worden geladen door `true` door te geven aan `set_OnlyLoadDocumentProperties`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in de modus “alleen‑document‑eigenschappen”?**

Nee. Publieke en versleutelde eigenschapsdata moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het correcte openings­wachtwoord.