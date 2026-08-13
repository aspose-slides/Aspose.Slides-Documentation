---
title: Správa štítků citlivosti v prezentacích PowerPoint v C++
linktitle: Štítky citlivosti
type: docs
weight: 50
url: /cs/cpp/sensitivity-labels/
keywords:
- štítek citlivosti
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- označování obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- bezpečnost prezentací
- C++
- Aspose.Slides
description: "Číst, přidávat, aktualizovat, odstraňovat a migrovat štítky citlivosti Microsoft Purview v prezentacích PowerPoint PPTX pomocí Aspose.Slides pro C++."
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatického zpracování prezentace může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku zapsaná starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides poskytuje moderní metadata štítků citlivosti prostřednictvím [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Tato metoda vrací [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/), kterou lze prozkoumat a upravit před uložením prezentace jako PPTX.

{{% alert color="info" title="Poznámka" %}}
Identifikátory štítků citlivosti a informace o politice jsou definovány vaší konfigurací Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve svém prostředí před přidáním nebo migrací metadat. Hodnoty [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) popisují typy označení obsahu spojené se štítkem; samy o sobě nepřidávají do snímků viditelný text ani tvary.
{{% /alert %}}

## **Pochopení vlastností štítků citlivosti**

Každý [ISensitivityLabel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/) obsahuje následující metadata:

| Přístupové metody | Účel |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/set_id/) | Identifikuje štítek citlivosti v politice Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identifikuje web spojený s politikou štítku. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Udává, zda je štítek povolen. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Udává, že byl štítek odstraněn. Nastavte hodnotu na `true`, pokud má být stav odstranění zachován v metadatech. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Určuje, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Uvádí typy označení obsahu spojené se štítkem. |

Výčtový typ [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelassignmenttype/) popisuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě rozhodnutí uživatele, včetně manuálně aplikovaných, doporučených a povinných štítků.

Výčtový typ [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelcontenttype/) určuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozí nebo automaticky. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu záhlaví je spojeno se štítkem. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu zápatí je spojeno se štítkem. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelcontenttype/) | Označení obsahu vodoznaku je spojeno se štítkem. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/cs/cpp/aspose.slides/sensitivitylabelcontenttype/) | Ochrana šifrováním je spojena se štítkem. |

S jedním štítkem může být spojeno více typů označení.

## **Seznam existujících štítků citlivosti**

Přečtěte moderní kolekci štítků z [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) a enumerujte ji. Následující příklad vypisuje všechny vlastnosti a označení obsahu uložené pro každý štítek:

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

## **Přidání štítku citlivosti s označením obsahu**

Použijte [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/add/) s identifikátorem štítku, identifikátorem webu, stavem povolení a metodou přiřazení. Po vrácení nové [ISensitivityLabel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/) přidejte požadované hodnoty označení pomocí [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Následující příklad přidá ručně vybraný štítek spojený s označením zápatí a vodoznaku a poté výsledek uloží jako PPTX:

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

## **Aktualizace štítku citlivosti**

Hodnoty [ISensitivityLabel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/) jsou čitelné/zapisovatelné přes jejich get a set metody, kromě toho, že kolekce vrácená [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) je upravována pomocí operací seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webu, stav povolení, metodu přiřazení, stav odstranění a typy označení obsahu. Uložte prezentaci, aby se změny zachovaly.

Následující příklad aktualizuje stav povolení a metodu přiřazení prvního štítku:

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

## **Označení štítku citlivosti jako odstraněného**

Aby se zachoval fakt, že byl štítek odstraněn, najděte štítek a zavolejte [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/set_isremoved/) s `true`. Tím se ponechá záznam o štítku a zaznamená se jeho odstraněný stav. Pokud místo toho potřebujete odstranit záznam z moderní kolekce, použijte [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/removeat/); použijte [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/clear/) k odstranění všech záznamů.

Následující příklad označí konkrétní štítek jako odstraněný a uloží aktualizovanou prezentaci:

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

## **Čtení a migrace starých MIP štítků citlivosti**

Starší pracovní postupy založené na MIP mohou ukládat metadata štítků citlivosti do vlastních vlastností dokumentu místo moderní kolekce štítků. Přečtěte tato metadata pomocí [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoda analyzuje staré vlastní vlastnosti a vrací pole objektů [ISensitivityLabel](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/).

Aby se metadata migrovala, přidejte každý vrácený štítek do moderní [ISensitivityLabelCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/) pomocí [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/add/). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad před kopírováním každého štítku kontroluje cílovou kolekci. Můžete přidat další validaci, aby se potvrdilo, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace zkopíruje analyzované objekty štítků do moderní kolekce. Není nutné vymazat všechny vlastní vlastnosti dokumentu, takže nesouvisející metadata dokumentu zůstávají nedotčena. Použijte [IPresentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/save/) s [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/) k zápisu moderních metadat štítků do souboru PPTX.

## **FAQ**

**Vytváří přidání typu označení obsahu viditelné záhlaví, zápatí nebo vodoznak na snímcích?**

Ne. Hodnoty přidané pomocí [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) popisují označení spojená se štítkem citlivosti. Nevytvářejí v prezentaci viditelný text ani tvary. Přidejte odpovídající obsah snímku samostatně, pokud váš pracovní postup musí tato označení vykreslit.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Volání [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/set_isremoved/) s `true` zachová záznam o štítku a zaznamená jeho odstraněný stav. Volání [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/removeat/) smaže záznam z moderní kolekce. Vyberte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní štítky citlivosti?**

Ano. Staré štítky mohou zůstat ve vlastních vlastnostech dokumentu, zatímco moderní štítky jsou dostupné prostřednictvím [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Použijte [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/cs/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) k přečtení starých metadat a migrujte pouze platné štítky, které již v moderní kolekci nejsou.

**Co se stane, když je štítek se stejným identifikátorem přidán více než jednou?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabelcollection/add/) vyvolá výjimku argumentu, když kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isensitivitylabel/get_id/).

**Jaký výstupní formát použít pro zachování aktualizovaných štítků citlivosti?**

Uložte prezentaci jako PPTX voláním [IPresentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ipresentation/save/) s [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/saveformat/), jak je uvedeno v příkladech výše.