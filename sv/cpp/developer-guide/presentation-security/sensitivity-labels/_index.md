---
title: Hantera känslighetsetiketter i PowerPoint-presentationer i C++
linktitle: Känslighetsetiketter
type: docs
weight: 50
url: /sv/cpp/sensitivity-labels/
keywords:
- känslighetsetikett
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- innehållsmärkning
- informationsskydd
- dokumentstyrning
- PowerPoint
- PPTX
- presentationssäkerhet
- C++
- Aspose.Slides
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview-känslighetsetiketter i PowerPoint PPTX-presentationer med Aspose.Slides för C++."
---
## **Översikt**

Microsoft Purview‑sensitivitetsetiketter hjälper organisationer att klassificera och hantera dokument. Under automatiserad presentationbearbetning kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess tillstånd eller migrera etiketmetadata som skrivits av ett äldre Microsoft Information Protection (MIP)-arbetsflöde.

Aspose.Slides exponerar modern metadata för sensitivitetsetiketter via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Denna metod returnerar en [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/) som kan inspekteras och modifieras innan presentationen sparas som PPTX.

{{% alert color="info" title="Note" %}}
Identifierare för sensitivitetsetiketter och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettens tillgänglighet och policykrav i din miljö innan du lägger till eller migrerar metadata. Värdena i [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) beskriver innehållsmärkningarna som är kopplade till en etikett; de lägger inte själva till synlig text eller former på bilderna.
{{% /alert %}}

## **Förstå egenskaper för sensitivitetsetiketter**

Varje [ISensitivityLabel](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/) innehåller följande metadata:

| Åtkomstmetoder | Syfte |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/set_id/) | Identifiera sensitivitetsetiketten i Purview‑policyn. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identifiera webbplatsen som är kopplad till etikettpolicyn. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Anger om etiketten är aktiverad. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Anger att etiketten har tagits bort. Sätt värdet till `true` när borttagningsstatusen måste behållas i metadata. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Specificera om etiketten tillämpades automatiskt eller genom ett användarbeslut. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Lista typerna av innehållsmärkning som är associerade med etiketten. |

SensitivitetsetikettTilldelningstyp‑enumerationen beskriver hur en etikett tilldelades:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sensitivitylabelassignmenttype/) representerar en standard‑ eller automatiskt tillämpad etikett.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

SensitivitetsetikettInnehållstyp‑enumerationen identifierar den märkning som är kopplad till en etikett:

| Värde | Betydelse |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sensitivitylabelcontenttype/) | Innehållsmärkning för sidhuvud är associerad med etiketten. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sensitivitylabelcontenttype/) | Innehållsmärkning för sidfot är associerad med etiketten. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sensitivitylabelcontenttype/) | Innehållsmärkning för vattenstämpel är associerad med etiketten. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/sv/cpp/aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera märkningstyper kan vara associerade med en etikett.

## **Lista befintliga sensitivitetsetiketter**

Läs den moderna etikettsamlingen från [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) och iterera över den. Följande exempel listar varje egendom och innehållsmärkning som lagras för varje etikett:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Lägg till en sensitivitetsetikett med innehållsmärkning**

Använd [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/add/) med etikettens identifierare, webbplatsidentifierare, aktiverat tillstånd och tilldelningsmetod. Efter att metoden har returnerat den nya [ISensitivityLabel](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/), lägg till de nödvändiga märkningarna via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Följande exempel lägger till en manuellt vald etikett som är associerad med sidfot- och vattenstämpelmärkningar, och sparar sedan resultatet som PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Uppdatera en sensitivitetsetikett**

ISensitivityLabel‑värdena kan läsas/skrivas via deras getter‑ och setter‑metoder, förutom att samlingen som returneras av [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) modifieras genom dess listoperationer. Efter att ha lokaliserat den önskade etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiverade tillstånd, tilldelningsmetod, borttagningsstatus och typer av innehållsmärkning. Spara presentationen för att bevara förändringarna.

Följande exempel uppdaterar det aktiverade tillståndet och tilldelningsmetoden för den första etiketten:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Markera en sensitivitetsetikett som borttagen**

För att bevara faktumet att en etikett har tagits bort, hitta etiketten och anropa [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/set_isremoved/) med `true`. Detta behåller etikettposten samtidigt som dess borttagna status registreras. Om du istället behöver ta bort en post från den moderna samlingen, använd [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/removeat/); använd [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/clear/) för att radera alla poster.

Följande exempel markerar en specifik etikett som borttagen och sparar den uppdaterade presentationen:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Läs och migrera äldre MIP‑sensitivitetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra metadata för sensitivitetsetiketter i anpassade dokumentegenskaper istället för den moderna etikettssamlingen. Läs den metadata med [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoden analyserar de äldre anpassade egenskaperna och returnerar en array av [ISensitivityLabel](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/)‑objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/add/). Eftersom tillägg av en duplicerad etikettidentifierare kastar ett undantag, kontrollerar exemplet destinationssamlingen innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Migreringen kopierar de analyserade etiket objekten till den moderna samlingen. Det kräver inte att alla anpassade dokumentegenskaper rensas, så orelaterad dokumentmetadata förblir intakt. Använd [IPresentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/save/) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/) för att skriva den moderna etiketmetadata till en PPTX‑fil.

## **Vanliga frågor**

**Skapar tillägg av en innehållsmärkningstyp ett synligt sidhuvud, sidfot eller vattenstämpel på bilder?**

Nej. Värden som läggs till via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) beskriver de märkningar som är kopplade till sensitivitetsetiketten. De skapar inte synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att ta bort den från samlingen?**

Att anropa [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/set_isremoved/) med `true` behåller etikettposten och registrerar dess borttagna status. Att anropa [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/removeat/) tar bort posten från den moderna samlingen. Välj den operation som motsvarar din organisations krav på bevarande av metadata.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna sensitivitetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Använd [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/sv/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna samlingen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabelcollection/add/) kastar ett argument‑undantag när samlingen redan innehåller en etikett med samma identifierare. Kontrollera befintliga [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/sv/cpp/aspose.slides/isensitivitylabel/get_id/)‑värden innan du lägger till eller migrerar etiketter.

**Vilket utdataformat bör användas för att bevara uppdaterade sensitivitetsetiketter?**

Spara presentationen som PPTX genom att anropa [IPresentation::Save](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ipresentation/save/) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/saveformat/), som visas i exemplen ovan.