---
title: Verwalten von Sensitivitätskennzeichnungen in PowerPoint‑Präsentationen in C++
linktitle: Sensitivitätskennzeichnungen
type: docs
weight: 50
url: /de/cpp/sensitivity-labels/
keywords:
- Sensitivitätskennzeichnung
- Microsoft Purview
- Microsoft Information Protection
- MIP-Metadaten
- Inhaltsmarkierung
- Informationsschutz
- Dokumentenverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- C++
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren Sie Microsoft Purview Sensitivitätskennzeichnungen in PowerPoint PPTX‑Präsentationen mit Aspose.Slides für C++."
---
## **Übersicht**

Microsoft Purview Sensitivitätskennzeichnungen helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Bei der automatischen Verarbeitung von Präsentationen kann eine Anwendung ein bestehendes Kennzeichen beibehalten, ein durch eine Richtlinie ausgewähltes Kennzeichen anwenden, dessen Zustand aktualisieren oder Kennzeichnungsmetadaten migrieren, die von einem älteren Microsoft Information Protection (MIP)-Workflow geschrieben wurden.

Aspose.Slides stellt moderne Kennzeichnungsmetadaten über [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) bereit. Diese Methode gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX eingesehen und geändert werden kann.

{{% alert color="info" title="Note" %}}
Kennzeichnungs‑IDs und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Überprüfen Sie die Verfügbarkeit von Kennzeichnungen und Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) beschreiben die mit einer Kennzeichnung verbundenen Inhaltsmarkierungen; sie fügen den Folien nicht automatisch sichtbaren Text oder Formen hinzu.
{{% /alert %}}

## **Sensitivitätskennzeichnungs‑Eigenschaften verstehen**

Jede [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Zugriffsmethoden | Zweck |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_id/) | Identifiziert die Sensitivitätskennzeichnung in der Purview‑Richtlinie. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identifiziert die mit der Kennzeichnungs‑Richtlinie verbundene Site. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Gibt an, ob die Kennzeichnung aktiviert ist. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Gibt an, dass die Kennzeichnung entfernt wurde. Setzen Sie den Wert auf `true`, wenn der Entfernungszustand in den Metadaten beibehalten werden muss. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Gibt an, ob die Kennzeichnung automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Listet die Inhaltsmarkierungstypen auf, die mit der Kennzeichnung verknüpft sind. |

Die Aufzählung [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelassignmenttype/) beschreibt, wie eine Kennzeichnung zugewiesen wurde:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelassignmenttype/) stellt eine Standard‑ oder automatisch angewendete Kennzeichnung dar.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelassignmenttype/) stellt eine durch Benutzerentscheidung angewendete Kennzeichnung dar, einschließlich manuell angewandter, empfohlener und obligatorischer Kennzeichnungen.

Die Aufzählung [SensitivityLabelContentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) identifiziert die mit einer Kennzeichnung verbundene Markierung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Die Kennzeichnung wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Kopfzeilen‑Inhaltsmarkierung ist mit der Kennzeichnung verbunden. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Fußzeilen‑Inhaltsmarkierung ist mit der Kennzeichnung verbunden. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Wasserzeichen‑Inhaltsmarkierung ist mit der Kennzeichnung verbunden. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Verschlüsselungssicherung ist mit der Kennzeichnung verbunden. |

Mehrere Markierungstypen können einer Kennzeichnung zugeordnet werden.

## **Vorhandene Sensitivitätskennzeichnungen auflisten**

Lesen Sie die moderne Kennzeichnungssammlung über [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und Inhaltsmarkierung auf, die für jede Kennzeichnung gespeichert ist:

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

## **Eine Sensitivitätskennzeichnung mit Inhaltsmarkierung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/add/) mit Kennzeichnungs‑ID, Site‑ID, Aktivierungszustand und Zuweisungsmethode. Nachdem die Methode das neue [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Markierungswerte über [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) hinzu.

Das folgende Beispiel fügt eine manuell ausgewählte Kennzeichnung hinzu, die mit Fußzeilen‑ und Wasserzeichen‑Markierungen verknüpft ist, und speichert das Ergebnis als PPTX:

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

## **Eine Sensitivitätskennzeichnung aktualisieren**

Die Werte des [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/) können über deren Getter‑ und Setter‑Methoden gelesen und geschrieben werden, wobei die über [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) zurückgegebene Sammlung durch deren Listenoperationen modifiziert wird. Nachdem Sie die gewünschte Kennzeichnung gefunden haben, können Sie deren Kennzeichnungs‑ID, Site‑ID, Aktivierungszustand, Zuweisungsmethode, Entfernungszustand und Inhaltsmarkierungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den Aktivierungszustand und die Zuweisungsmethode der ersten Kennzeichnung:

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

## **Eine Sensitivitätskennzeichnung als entfernt markieren**

Um festzuhalten, dass eine Kennzeichnung entfernt wurde, suchen Sie die Kennzeichnung und rufen Sie [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isremoved/) mit `true` auf. Dadurch bleibt der Kennzeichnungseintrag erhalten, während ihr Entfernungszustand vermerkt wird. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen wollen, verwenden Sie [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/removeat/); nutzen Sie [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/clear/), um alle Einträge zu entfernen.

Das folgende Beispiel markiert eine bestimmte Kennzeichnung als entfernt und speichert die aktualisierte Präsentation:

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

## **Legacy‑MIP‑Sensitivitätskennzeichnungen lesen und migrieren**

Ältere, auf MIP basierende Workflows können Sensitivitätskennzeichnungs‑Metadaten in benutzerdefinierten Dokumenteigenschaften anstelle der modernen Kennzeichnungssammlung speichern. Lesen Sie diese Metadaten mit [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Die Methode analysiert die alten benutzerdefinierten Eigenschaften und gibt ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/)-Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jede zurückgegebene Kennzeichnung über [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/add/) zur modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/) hinzu. Da das Hinzufügen einer doppelten Kennzeichnungs‑ID eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Sammlung, bevor jede Kennzeichnung kopiert wird. Sie können zusätzliche Validierungen einbauen, um zu bestätigen, dass jede Legacy‑Kennzeichnung noch in der aktuellen Purview‑Richtlinie existiert.

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

Die Migration kopiert die analysierten Kennzeichnungsobjekte in die moderne Sammlung. Sie erfordert nicht das Leeren aller benutzerdefinierten Dokumenteigenschaften, sodass unverknüpfte Dokumentmetadaten erhalten bleiben. Verwenden Sie [IPresentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/save/) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/), um die modernen Kennzeichnungs‑Metadaten in einer PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltsmarkierungstyps eine sichtbare Kopf‑, Fußzeile oder ein Wasserzeichen auf den Folien?**

Nein. Durch [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) hinzugefügte Werte beschreiben die mit der Sensitivitätskennzeichnung verbundenen Markierungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, wenn Ihr Workflow diese Markierungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren einer Kennzeichnung als entfernt und dem Löschen aus der Sammlung?**

Der Aufruf von [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isremoved/) mit `true` behält den Kennzeichnungseintrag bei und vermerkt seinen Entfernungszustand. Der Aufruf von [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/removeat/) entfernt den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätskennzeichnungen enthalten?**

Ja. Legacy‑Kennzeichnungen können in benutzerdefinierten Dokumenteigenschaften verbleiben, während moderne Kennzeichnungen über [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) verfügbar sind. Verwenden Sie [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/), um die Legacy‑Metadaten zu lesen und nur die gültigen Kennzeichnungen zu migrieren, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn dieselbe Kennzeichnungs‑ID mehrmals hinzugefügt wird?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/add/) wirft eine Argument‑Ausnahme, wenn die Sammlung bereits eine Kennzeichnung mit derselben ID enthält. Prüfen Sie vorhandene [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_id/)-Werte, bevor Sie Kennzeichnungen hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätskennzeichnungen zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/save/) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.