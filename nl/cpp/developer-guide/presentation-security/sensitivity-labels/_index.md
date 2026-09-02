---
title: Beheer gevoeligheidslabels in PowerPoint-presentaties in C++
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/cpp/sensitivity-labels/
keywords:
- gevoeligheidslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- inhoudsmarkering
- informatiebeveiliging
- documentbeheer
- PowerPoint
- PPTX
- presentatiebeveiliging
- C++
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview-gevoeligheidslabels in PowerPoint-PPTX-presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Microsoft Purview‑gevoeligheidslabels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatieverwerking kan een applicatie een bestaand label moeten behouden, een label toepassen dat door een beleid is geselecteerd, de status bijwerken of label‑metadata migreren die door een oudere Microsoft Information Protection (MIP)‑workflow is geschreven.

Aspose.Slides maakt moderne gevoeligheidslabel‑metadata beschikbaar via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Deze methode retourneert een [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="primary" title="Opmerking" %}}

Gevoeligheidslabel‑identifiers en beleidsinformatie worden bepaald door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van labels en de beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia's.

{{% /alert %}}

## **Begrijp de eigenschappen van gevoeligheidslabels**

Elke [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/) bevat de volgende metadata:

| Accessors | Doel |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_id/) | Identificeer het gevoeligheidslabel in het Purview‑beleid. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identificeer de site die bij het label‑beleid hoort. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Geef aan of het label is ingeschakeld. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Geef aan dat het label is verwijderd. Stel de waarde in op `true` wanneer de verwijderingsstatus in de metadata moet worden bewaard. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Specificeer of het label automatisch of via een gebruikersbeslissing is toegepast. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Sommeer de type inhoudsmarkeringen die aan het label zijn gekoppeld. |

De enumeratie [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelassignmenttype/) beschrijft hoe een label is toegewezen:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard of automatisch toegepast label.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De enumeratie [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) identificeert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Koptekst‑markering is aan het label gekoppeld. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Voettekst‑markering is aan het label gekoppeld. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Watermerk‑markering is aan het label gekoppeld. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Encryptiebescherming is aan het label gekoppeld. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelcollectie via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) en doorloop deze. Het volgende voorbeeld somt elke eigenschap en inhoudsmarkering op die voor elk label is opgeslagen:

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

## **Voeg een gevoeligheidslabel toe met inhoudsmarkering**

Gebruik [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/add/) met de label‑identifier, site‑identifier, ingeschakelde status en toewijzingsmethode. Nadat de methode het nieuwe [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/) heeft geretourneerd, voegt u de vereiste markeringstypen toe via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan voettekst‑ en watermerk‑markeringen, en slaat vervolgens het resultaat op als PPTX:

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

## **Werk een gevoeligheidslabel bij**

De waarden van [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/) zijn lees‑/schrijfbaar via hun getter‑ en setter‑methoden, behalve dat de collectie die wordt geretourneerd door [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) wordt aangepast via de lijstbewerkingen. Nadat u het gewenste label hebt gevonden, kunt u de identifier, site‑identifier, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en inhoudsmarkeringstypen bijwerken. Sla de presentatie vervolgens op om de wijzigingen te bewaren.

Het volgende voorbeeld werkt de ingeschakelde status en de toewijzingsmethode van het eerste label bij:

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

## **Markeer een gevoeligheidslabel als verwijderd**

Om het feit te behouden dat een label is verwijderd, vindt u het label en roept u [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) aan met `true`. Hierdoor blijft de label‑invoer behouden terwijl de verwijderingsstatus wordt geregistreerd. Als u in plaats daarvan een invoer uit de moderne collectie wilt verwijderen, gebruikt u [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/removeat/); gebruik [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/clear/) om alle invoeren te verwijderen.

Het volgende voorbeeld markeert een specifiek label als verwijderd en slaat de bijgewerkte presentatie op:

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

## **Lees en migreer legacy MIP‑gevoeligheidslabels**

Oudere MIP‑gebaseerde workflows kunnen gevoeligheidslabel‑metadata opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelcollectie. Lees die metadata met [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). De methode ontleedt de legacy‑aangepaste eigenschappen en retourneert een array van [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/) objecten.

Om de metadata te migreren, voegt u elk geretourneerd label toe aan de moderne [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/add/). Omdat het toevoegen van een dubbele label‑identifier een uitzondering oplevert, controleert het voorbeeld de doelcollectie voordat elk label wordt gekopieerd. U kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog steeds bestaat in het huidige Purview‑beleid.

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

De migratie kopieert de geparseerde labelobjecten naar de moderne collectie. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat ongerelateerde documentmetadata intact blijft. Gebruik [IPresentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/) met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/) om de moderne label‑metadata naar een PPTX‑bestand te schrijven.

## **FAQ**

**Voegt het toevoegen van een inhoudsmarkeringstype een zichtbare koptekst, voettekst of watermerk toe aan dia's?**

Nee. De waarden die via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) worden toegevoegd, beschrijven de markeringen die bij het gevoeligheidslabel horen. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud apart toe als uw workflow deze markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Het aanroepen van [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) met `true` houdt de label‑invoer bij en registreert de verwijderingsstatus. Het aanroepen van [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/removeat/) verwijdert de invoer uit de moderne collectie. Kies de bewerking die past bij de metadata‑retentievereisten van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven bestaan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Gebruik [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet aanwezig zijn in de moderne collectie.

**Wat gebeurt er wanneer een label met dezelfde identifier meer dan één keer wordt toegevoegd?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/add/) werpt een argument‑exception wanneer de collectie al een label met dezelfde identifier bevat. Controleer bestaande [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_id/) waarden voordat u labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [IPresentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/) aan te roepen met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/), zoals getoond in de voorbeelden hierboven.