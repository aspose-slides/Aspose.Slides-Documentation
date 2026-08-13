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

Microsoft Purview-gevoeligheidslabels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatie‑verwerking kan een applicatie een bestaand label moeten behouden, een label dat door een beleid is geselecteerd toepassen, de status bijwerken, of label‑metadata migreren die door een oudere Microsoft Information Protection (MIP)‑workflow is geschreven.

Aspose.Slides maakt moderne gevoeligheidslabel‑metadata beschikbaar via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Deze methode retourneert een [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="info" title="Note" %}}
Identificatoren van gevoeligheidslabels en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van labels en beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia's.
{{% /alert %}}

## **Begrijp eigenschappen van gevoeligheidslabels**

Elke [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/) bevat de volgende metadata:

| Accessors | Doel |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_id/) | Het gevoeligheidslabel identificeren in het Purview‑beleid. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_siteid/) | De site identificeren die bij het label‑beleid hoort. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Aangeven of het label ingeschakeld is. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Aangeven dat het label is verwijderd. Zet de waarde op `true` wanneer de verwijderingsstatus moet worden bewaard in de metadata. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Opgeven of het label automatisch of via een beslissing van de gebruiker is toegepast. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Lijst met de inhoudsmarkeringstypen die aan het label zijn gekoppeld. |

De enumeratie [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelassignmenttype/) beschrijft hoe een label is toegewezen:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard‑ of automatisch toegepast label.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat door een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De enumeratie [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) identificeert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Een header‑inhoudsmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Een footer‑inhoudsmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Een watermerk‑inhoudsmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/nl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Versleutelingsbescherming is gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst van bestaande gevoeligheidslabels**

Lees de moderne labelcollectie via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) en doorloop deze. Het volgende voorbeeld geeft elke eigenschap en inhoudsmarkering weer die voor elk label is opgeslagen:

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

Gebruik [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/add/) met de label‑identificator, site‑identificator, ingeschakelde status en toewijzingsmethode. Nadat de methode het nieuwe [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeringwaarden toe via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan footer‑ en watermerk‑markeringen, en slaat het resultaat vervolgens op als PPTX:

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

De waarden van [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/) kunnen worden gelezen en geschreven via hun getter‑ en setter‑methoden, behalve dat de collectie die wordt geretourneerd door [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) wordt aangepast via de lijst‑operaties. Nadat je het gewenste label hebt gevonden, kun je de identificator, site‑identificator, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en inhoudsmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te behouden.

Het volgende voorbeeld werkt de ingeschakelde status en toewijzingsmethode van het eerste label bij:

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

Om te behouden dat een label is verwijderd, vind je het label en roep je [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) aan met `true`. Dit behoudt het label‑item terwijl de verwijderingsstatus wordt geregistreerd. Als je in plaats daarvan een item uit de moderne collectie wilt verwijderen, gebruik je [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/removeat/); gebruik [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/clear/) om alle items te verwijderen.

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

## **Lees en migreer legacy MIP-gevoeligheidslabels**

Oudere MIP‑gebaseerde workflows kunnen gevoeligheidslabel‑metadata opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelcollectie. Lees die metadata met [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). De methode ontleedt de legacy‑aangepaste eigenschappen en retourneert een array van [ISensitivityLabel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/)‑objecten.

Om de metadata te migreren, voeg je elk geretourneerd label toe aan de moderne [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/add/). Omdat het toevoegen van een duplicate label‑identificator een uitzondering oplevert, controleert het voorbeeld de bestemmingscollectie voordat elk label wordt gekopieerd. Je kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog bestaat in het huidige Purview‑beleid.

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

De migratie kopieert de ontlede labelobjecten naar de moderne collectie. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat ongegerelateerde documentmetadata intact blijven. Gebruik [IPresentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/) met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **Veelgestelde vragen**

**Creëert het toevoegen van een inhoudsmarkeringstype een zichtbaar kop‑, voettekst‑ of watermerk op dia’s?**

Nee. De waarden die via [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) worden toegevoegd, beschrijven de markeringen die bij het gevoeligheidslabel horen. Ze genereren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud apart toe als uw workflow die markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Het aanroepen van [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) met `true` houdt het label‑item vast en registreert de verwijderingsstatus. Het aanroepen van [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/removeat/) verwijdert het item uit de moderne collectie. Kies de bewerking die past bij de retentie‑eisen van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven staan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Gebruik [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/nl/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet in de moderne collectie aanwezig zijn.

**Wat gebeurt er wanneer een label met dezelfde identificator meer dan één keer wordt toegevoegd?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabelcollection/add/) gooit een argument‑exception wanneer de collectie al een label met dezelfde identificator bevat. Controleer bestaande [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/nl/cpp/aspose.slides/isensitivitylabel/get_id/)‑waarden voordat je labels toevoegt of migreert.

**Welk outputformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [IPresentation::Save](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ipresentation/save/) aan te roepen met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/saveformat/), zoals getoond in de voorbeelden hierboven.