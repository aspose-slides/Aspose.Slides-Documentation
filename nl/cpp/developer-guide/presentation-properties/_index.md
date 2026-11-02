---
title: Beheer presentatie-eigenschappen in C++
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/cpp/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- document-eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen aanpassen
- documentmetadata
- metadata bewerken
- controleertaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides voor C++ en optimaliseer zoekopdrachten, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Introductie**

Aspose.Slides for C++ ondersteunt **ingebouwde** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, titel en door de gebruiker gedefinieerde waarden.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de interface [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) . Een exemplaar van deze interface wordt geretourneerd door [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de applicatie- en producentmetadata bij het opslaan van presentaties; deze velden identificeren de software die de output heeft gemaakt.
{{% /alert %}}

## **Beheer presentatiedocumenteigenschappen**

Documenteigenschappen slaan beschrijvende informatie op naast de presentatietekst. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** bewaren door de gebruiker gedefinieerde naam/waarde-paren.

Aspose.Slides for C++ biedt toegang tot beide categorieën. In PowerPoint selecteert u **File → Info → Properties → Advanced Properties** om documentmetadata te inspecteren. Het dialoogvenster groepeert informatie in tabbladen zoals **Summary**, **Statistics**, **Contents** en **Custom**. Gebruik het tabblad **Custom** om door de gebruiker gedefinieerde eigenschappen te beheren.

## **Openbare eigenschappen lezen uit een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de presentatie-inhoud als de documenteigenschappen. Wanneer een presentatie wordt versleuteld door `false` door te geven aan [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens `true` doorgeven aan [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/), en de openbare metadata lezen zonder het openingswachtwoord op te geven.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen in de encryptie waren opgenomen, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen openbaar zijn gelaten. Het verifieert de laadmethode via [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/), en leest vervolgens ingebouwde eigenschappen via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

In deze modus wordt de inhoud van de dia's niet geladen. Dia's, masters, indelingen, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel nodig heeft.

{{% alert color="warning" title="Security" %}}
Openbare metadata kunnen auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootstellen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexerings‑, classificatie‑, zoek‑ of document‑beheersystemen een specifieke vereiste hebben om er zonder wachtwoord toegang toe te krijgen.
{{% /alert %}}

## **Eigenschappen van een versleutelde presentatie bijwerken**

Voor een versleuteld PPTX‑bestand is een presentatie die wordt geladen door `true` door te geven aan [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) bedoeld om openbare metadata te lezen. Aspose.Slides kan geen gewijzigde eigenschappen opslaan vanuit dat alleen‑metadata‑object omdat de openbare eigenschappen consistent moeten blijven met de bijbehorende gegevens in de versleutelde presentatie. Het bijwerken ervan vereist daarom het juiste openingswachtwoord en een volledige laadactie.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare documenteigenschappen en een bekend openingswachtwoord. Het opent de volledige presentatie met [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) gebruikt om te verifiëren dat de versleuteling behouden blijft en wordt de openbare metadata opnieuw geopend zonder wachtwoord om de nieuwe waarden te controleren:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Als een applicatie niet is toegestaan om de presentatie-inhoud te ontsleutelen of te laden, moet deze openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

De interface [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) toont ingebouwde metadata via get‑methoden met type, waaronder [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/), en [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Dit voorbeeld opent een bestaande presentatie en print de opgeslagen metadata naar de console. Waarden zijn afhankelijk van de invoerpresentatie; sommige velden kunnen leeg zijn.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Ingebouwde eigenschappen wijzigen**

Om ingebouwde metadata bij te werken, gebruikt u de set‑methoden op het object dat wordt geretourneerd door [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Dit voorbeeld opent een bestaande presentatie, roept [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), en [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) aan, en slaat vervolgens de bijgewerkte presentatie op met [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). De opgeslagen PPTX bevat de nieuwe metadata.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Beheer de hyperlink‑basis**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) leest de document‑niveau basis voor relatieve hyperlinks. Dit is handig bij het verplaatsen van een presentatie en de gelinkte bestanden naar een andere locatie. Het is gescheiden van de individuele hyperlink‑[IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): het wijzigen van de basis herschrijft niet de opgeslagen linkadressen of wijzigt absolute bestemmingen.

Het voorbeeld vereist een presentatie die zowel een relatieve link bevat, bijvoorbeeld `target.html`, als een absolute link, bijvoorbeeld `https://example.org/absolute.html`. Het leest de bestaande basis, wijst een nieuw basisadres toe met [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Vervolgens wordt de basis gewist met `u""` en wordt de lege waarde geverifieerd in een apart opgeslagen bestand. Vervang het voorbeeldbasisadres door de locatie van uw gelinkte bestanden.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

De twee verificatie‑berichten moeten `True` afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen onaangetast.

Een relatieve link naar `target.pptx` opende `old/target.pptx` toen de basis naar de `old`‑map wees. Na het wijzigen van de basis naar de `new`‑map, opslaan en opnieuw openen van de presentatie, opende dezelfde link `new/target.pptx`. Een absolute link bleef hetzelfde bestand openen. Test uw relatieve links in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste presentatiedocumenteigenschappen toevoegen**

Aangepaste eigenschappen slaan metadata op die geen overeenkomstig ingebouwd veld heeft. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) stelt u in staat een waarde toe te wijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een gehele versie‑waarde toe, en slaat de presentatie op met [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Het toewijzen van een waarde aan een bestaande naam vervangt de waarde van die eigenschap.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Toegang tot en wijzigen van aangepaste eigenschappen**

Dit voorbeeld opent een presentatie met aangepaste eigenschappen en gebruikt [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) om erover te itereren. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) accepteert een nul‑gebaseerde index en retourneert de naam die wordt gebruikt door [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) en [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). Het voorbeeld print elke oorspronkelijke naam en waarde, vervangt elke waarde door een genummerde tekenreeks ongeacht het originele type, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, brengt de lus geen wijzigingen aan.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Live‑voorbeeld**

Probeer de online app [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen zijn een integraal onderdeel van de presentatie en kunnen niet volledig worden verwijderd. U kunt echter wel hun waarden wijzigen of, indien toegestaan door de specifieke eigenschap, ze leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, aangezien Aspose.Slides de waarde van de eigenschap automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) en vervolgens [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) om de opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/cpp/examine-presentation/) voor een volledig rapportage‑voorbeeld en indelingsspecifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De presentatie moet versleuteld zijn door `false` door te geven aan [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), en moet geladen worden door `true` door te geven aan [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**Kan ik een versleuteld PPTX‑bestand bijwerken in alleen‑document‑eigenschappen‑modus?**

Nee. Openbare en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledig laden van de presentatie met het juiste openingswachtwoord.