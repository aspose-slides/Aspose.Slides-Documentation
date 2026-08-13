---
title: Zarządzanie etykietami wrażliwości w prezentacjach PowerPoint w C++
linktitle: Etykiety wrażliwości
type: docs
weight: 50
url: /pl/cpp/sensitivity-labels/
keywords:
- etykieta wrażliwości
- Microsoft Purview
- Microsoft Information Protection
- metadane MIP
- oznaczanie treści
- ochrona informacji
- zarządzanie dokumentami
- PowerPoint
- PPTX
- bezpieczeństwo prezentacji
- C++
- Aspose.Slides
description: "Odczyt, dodawanie, aktualizacja, usuwanie i migracja etykiet wrażliwości Microsoft Purview w prezentacjach PowerPoint PPTX przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Microsoft Purview sensitivity labels pomagają organizacjom klasyfikować i zarządzać dokumentami. Podczas automatycznego przetwarzania prezentacji aplikacja może potrzebować zachować istniejącą etykietę, zastosować etykietę wybraną przez zasadę, zaktualizować jej stan lub migrować metadane etykiet zapisane przez starszy przepływ pracy Microsoft Information Protection (MIP).

Aspose.Slides udostępnia nowoczesne metadane etykiet wrażliwości poprzez [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Metoda ta zwraca [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/), który można przeglądać i modyfikować przed zapisaniem prezentacji jako PPTX.

{{% alert color="info" title="Note" %}}
Identyfikatory etykiet wrażliwości oraz informacje o zasadach są definiowane w konfiguracji Microsoft Purview. Zweryfikuj dostępność etykiet i wymagania zasad w swoim środowisku przed dodaniem lub migracją metadanych. Wartości [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) opisują oznaczenia treści powiązane z etykietą; same w sobie nie dodają widocznego tekstu ani kształtów do slajdów.
{{% /alert %}}

## **Zrozumienie właściwości etykiet wrażliwości**

Każda [ISensitivityLabel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/) zawiera następujące metadane:

| Akcesory | Cel |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/set_id/) | Identyfikuj etykietę wrażliwości w polityce Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identyfikuj witrynę powiązaną z zasadą etykiety. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Wskazuje, czy etykieta jest włączona. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Wskazuje, że etykieta została usunięta. Ustaw wartość na `true`, gdy stan usunięcia musi być zachowany w metadanych. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Określa, czy etykieta została zastosowana automatycznie, czy na podstawie decyzji użytkownika. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Wymienia typy oznaczeń treści powiązane z etykietą. |

Wyliczenie [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelassignmenttype/) opisuje, jak etykieta została przypisana:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę domyślną lub automatycznie zastosowaną.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelassignmenttype/) reprezentuje etykietę zastosowaną na podstawie decyzji użytkownika, w tym etykiety zastosowane ręcznie, zalecane i obowiązkowe.

Wyliczenie [SensitivityLabelContentType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelcontenttype/) określa oznaczenie powiązane z etykietą:

| Wartość | Znaczenie |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Etykieta została zastosowana domyślnie lub automatycznie. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści nagłówka jest powiązane z etykietą. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści stopki jest powiązane z etykietą. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Oznaczenie treści znaku wodnego jest powiązane z etykietą. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/pl/cpp/aspose.slides/sensitivitylabelcontenttype/) | Ochrona szyfrowaniem jest powiązana z etykietą. |

Wiele typów oznaczeń może być powiązanych z jedną etykietą.

## **Wylistowanie istniejących etykiet wrażliwości**

Odczytaj nowoczesną kolekcję etykiet przy użyciu [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/), a następnie wylicz ją. Poniższy przykład wyświetla każdą właściwość i oznaczenie treści przechowywane dla każdej etykiety:

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

## **Dodaj etykietę wrażliwości z oznaczeniem treści**

Użyj [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/add/) z identyfikatorem etykiety, identyfikatorem witryny, stanem włączenia i metodą przypisania. Po zwróceniu nowej [ISensitivityLabel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/), dodaj wymagane wartości oznaczeń poprzez [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

Poniższy przykład dodaje ręcznie wybraną etykietę powiązaną z oznaczeniami stopki i znaku wodnego, a następnie zapisuje wynik jako PPTX:

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

## **Aktualizacja etykiety wrażliwości**

Wartości [ISensitivityLabel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/) są odczytywane i zapisywane za pomocą metod getter i setter, z wyjątkiem kolekcji zwróconej przez [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/), którą modyfikuje się przy użyciu operacji na liście. Po odnalezieniu wymaganej etykiety można zaktualizować jej identyfikator, identyfikator witryny, stan włączenia, metodę przypisania, stan usunięcia oraz typy oznaczeń treści. Zapisz prezentację, aby zachować zmiany.

Poniższy przykład aktualizuje stan włączenia i metodę przypisania pierwszej etykiety:

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

## **Oznacz etykietę wrażliwości jako usuniętą**

Aby zachować fakt, że etykieta została usunięta, znajdź etykietę i wywołaj [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) z `true`. To zachowuje wpis etykiety, jednocześnie rejestrując jej stan usunięcia. Jeśli zamiast tego musisz usunąć wpis ze współczesnej kolekcji, użyj [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/removeat/); użyj [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/clear/) aby usunąć wszystkie wpisy.

Poniższy przykład oznacza określoną etykietę jako usuniętą i zapisuje zaktualizowaną prezentację:

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

## **Odczyt i migracja starszych etykiet MIP**

Starsze przepływy pracy oparte na MIP mogą przechowywać metadane etykiet wrażliwości w niestandardowych właściwościach dokumentu zamiast w nowoczesnej kolekcji etykiet. Odczytaj te metadane za pomocą [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoda parsuje starsze właściwości niestandardowe i zwraca tablicę obiektów [ISensitivityLabel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/).

Aby migrować metadane, dodaj każdą zwróconą etykietę do nowoczesnej [ISensitivityLabelCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/) przy użyciu [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/add/). Ponieważ dodanie etykiety z duplikującym się identyfikatorem generuje wyjątek, przykład sprawdza docelową kolekcję przed skopiowaniem każdej etykiety. Możesz dodać dodatkową weryfikację, aby potwierdzić, że każda starsza etykieta nadal istnieje w bieżącej polityce Purview.

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

Migracja kopiuje sparsowane obiekty etykiet do nowoczesnej kolekcji. Nie wymaga czyszczenia wszystkich niestandardowych właściwości dokumentu, więc niepowiązane metadane dokumentu pozostają nienaruszone. Użyj [IPresentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/save/) z [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/), aby zapisać nowoczesne metadane etykiet do pliku PPTX.

## **FAQ**

**Czy dodanie typu oznaczenia treści tworzy widoczny nagłówek, stopkę lub znak wodny na slajdach?**

Nie. Wartości dodane za pomocą [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) opisują oznaczenia powiązane z etykietą wrażliwości. Nie tworzą one widocznego tekstu ani kształtów w prezentacji. Dodaj odpowiednią treść slajdu osobno, jeśli Twój przepływ pracy musi wyświetlać te oznaczenia.

**Jaka jest różnica między oznaczeniem etykiety jako usuniętej a jej usunięciem z kolekcji?**

Wywołanie [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/set_isremoved/) z wartością `true` zachowuje wpis etykiety i rejestruje jej stan usunięcia. Wywołanie [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/removeat/) usuwa wpis z nowoczesnej kolekcji. Wybierz operację, która odpowiada wymaganiom Twojej organizacji dotyczącym przechowywania metadanych.

**Czy prezentacja może zawierać zarówno starsze metadane MIP, jak i nowoczesne etykiety wrażliwości?**

Tak. Starsze etykiety mogą pozostawać w niestandardowych właściwościach dokumentu, podczas gdy nowoczesne etykiety są dostępne za pośrednictwem [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Użyj [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/pl/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) do odczytania starszych metadanych i migruj tylko te prawidłowe etykiety, które nie są już obecne w nowoczesnej kolekcji.

**Co się dzieje, gdy etykieta o tym samym identyfikatorze zostanie dodana więcej niż raz?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabelcollection/add/) zgłasza wyjątek argumentu, gdy kolekcja już zawiera etykietę o tym samym identyfikatorze. Sprawdź istniejące wartości [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isensitivitylabel/get_id/) przed dodaniem lub migracją etykiet.

**Jaki format wyjściowy należy użyć, aby zachować zaktualizowane etykiety wrażliwości?**

Zapisz prezentację jako PPTX, wywołując [IPresentation::Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/save/) z [SaveFormat::Pptx](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/saveformat/), jak pokazano w powyższych przykładach.