---
title: Verwalten von Sensitivitäts-Labels in PowerPoint-Präsentationen in C++
linktitle: Sensitivitäts-Labels
type: docs
weight: 50
url: /de/cpp/sensitivity-labels/
keywords:
- Sensitivitäts-Label
- Microsoft Purview
- Microsoft Information Protection
- MIP-Metadaten
- Inhaltskennzeichnung
- Informationsschutz
- Dokumentverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- C++
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren von Microsoft Purview Sensitivitäts-Labels in PowerPoint PPTX Präsentationen mit Aspose.Slides für C++."
---
## **Übersicht**

Microsoft Purview Sensitivity‑Labels helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Bei der automatisierten Präsentationsverarbeitung kann eine Anwendung ein bestehendes Label beibehalten, ein durch eine Richtlinie ausgewähltes Label anwenden, dessen Zustand aktualisieren oder Label‑Metadaten migrieren, die von einem älteren Microsoft Information Protection‑Workflow (MIP) geschrieben wurden.

Aspose.Slides stellt moderne Sensitivitäts‑Label‑Metadaten über [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) bereit. Diese Methode gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX eingesehen und geändert werden kann.

{{% alert color="primary" title="Hinweis" %}}
Sensitivitäts‑Label‑Kennungen und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Überprüfen Sie die Verfügbarkeit von Labels und Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) beschreiben die Inhaltskennzeichnungen, die einem Label zugeordnet sind; sie fügen selbst keine sichtbaren Texte oder Formen zu Folien hinzu.
{{% /alert %}}

## **Sensitivitäts‑Label‑Eigenschaften verstehen**

Jedes [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Accessors | Zweck |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_id/) | Kennzeichnet das Sensitivitäts‑Label in der Purview‑Richtlinie. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Kennzeichnet die mit der Richtlinie verknüpfte Site. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Gibt an, ob das Label aktiviert ist. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Gibt an, dass das Label entfernt wurde. Setzen Sie den Wert auf `true`, wenn der Entfernungszustand in den Metadaten erhalten bleiben muss. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Gibt an, ob das Label automatisch oder durch eine Benutzerentscheidung zugewiesen wurde. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Listet die Inhaltskennzeichnungstypen auf, die dem Label zugeordnet sind. |

Die Aufzählung [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelassignmenttype/) beschreibt, wie ein Label zugewiesen wurde:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelassignmenttype/) steht für ein Standard‑ oder automatisch angewendetes Label.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelassignmenttype/) steht für ein durch Benutzerentscheidung angewendetes Label, einschließlich manuell angewendeter, empfohlener und verpflichtender Labels.

Die Aufzählung [SensitivityLabelContentType](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) identifiziert die mit einem Label verbundene Kennzeichnung:

| Value | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Das Label wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Kopfzeilen‑Kennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Fußzeilen‑Kennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Wasserzeichen‑Kennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/de/cpp/aspose.slides/sensitivitylabelcontenttype/) | Eine Verschlüsselungsschutz ist dem Label zugeordnet. |

Mehrere Kennzeichnungstypen können einem Label zugeordnet sein.

## **Bestehende Sensitivitäts‑Labels auflisten**

Lesen Sie die moderne Label‑Sammlung über [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) und iterieren Sie darüber. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltskennzeichnung für jedes Label auf:

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

## **Ein Sensitivitäts‑Label mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/add/) mit der Label‑Kennung, Site‑Kennung, dem Aktivierungszustand und der Zuweisungsmethode. Nachdem die Methode das neue [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Kennwert‑Typen über [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) hinzu.

Das folgende Beispiel fügt ein manuell ausgewähltes Label hinzu, das mit Fußzeilen‑ und Wasserzeichen‑Kennzeichnungen verknüpft ist, und speichert das Ergebnis anschließend als PPTX:

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

## **Ein Sensitivitäts‑Label aktualisieren**

Die Werte des [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/) können über deren Getter‑ und Setter‑Methoden gelesen und geschrieben werden, wobei die durch [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) zurückgegebene Sammlung über Listenoperationen modifiziert wird. Nachdem Sie das gewünschte Label gefunden haben, können Sie Kennung, Site‑Kennung, Aktivierungszustand, Zuweisungsmethode, Entfernungszustand und Inhaltskennzeichnungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den Aktivierungszustand und die Zuweisungsmethode des ersten Labels:

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

## **Ein Sensitivitäts‑Label als entfernt markieren**

Um festzuhalten, dass ein Label entfernt wurde, finden Sie das Label und rufen Sie [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isremoved/) mit `true` auf. Dadurch bleibt der Eintrag erhalten, aber sein Entfernungsstatus wird gespeichert. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen müssen, verwenden Sie [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/removeat/); benutzen Sie [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/clear/), um sämtliche Einträge zu entfernen.

Das folgende Beispiel markiert ein bestimmtes Label als entfernt und speichert die aktualisierte Präsentation:

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

## **Legacy‑MIP‑Sensitivitäts‑Labels lesen und migrieren**

Ältere, auf MIP basierende Workflows können Sensitivitäts‑Label‑Metadaten in benutzerdefinierten Dokumenteneigenschaften statt in der modernen Label‑Sammlung speichern. Lesen Sie diese Metadaten mit [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Die Methode parst die Legacy‑Eigenschaften und gibt ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/)-Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Label über [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/add/) zur modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/) hinzu. Da das Hinzufügen einer doppelten Label‑Kennung eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Sammlung, bevor jedes Label kopiert wird. Sie können zusätzliche Validierungen einbauen, um sicherzustellen, dass jedes Legacy‑Label noch in der aktuellen Purview‑Richtlinie existiert.

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

Die Migration kopiert die geparsten Label‑Objekte in die moderne Sammlung. Es ist nicht nötig, alle benutzerdefinierten Dokumenteneigenschaften zu löschen, sodass nicht‑relevante Dokument‑Metadaten erhalten bleiben. Verwenden Sie [IPresentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/save/) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/), um die modernen Label‑Metadaten in eine PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltskennzeichnungstyps eine sichtbare Kopfzeile, Fußzeile oder ein Wasserzeichen auf Folien?**

Nein. Werte, die über [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) hinzugefügt werden, beschreiben die mit dem Sensitivitäts‑Label verbundenen Kennzeichnungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, wenn Ihr Workflow diese Kennzeichnungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren eines Labels als entfernt und dem Löschen aus der Sammlung?**

Der Aufruf von [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/set_isremoved/) mit `true` bewahrt den Label‑Eintrag und zeichnet seinen Entfernungsstatus auf. Der Aufruf von [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/removeat/) löscht den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Aufbewahrungsvorgaben Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitäts‑Labels enthalten?**

Ja. Legacy‑Labels können in benutzerdefinierten Dokumenteneigenschaften verbleiben, während moderne Labels über [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) verfügbar sind. Verwenden Sie [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/de/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/), um die Legacy‑Metadaten zu lesen und nur die gültigen Labels zu migrieren, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn ein Label mit derselben Kennung mehrfach hinzugefügt wird?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabelcollection/add/) wirft eine ArgumentException, wenn die Sammlung bereits ein Label mit derselben Kennung enthält. Prüfen Sie vorhandene [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/de/cpp/aspose.slides/isensitivitylabel/get_id/)-Werte, bevor Sie Labels hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitäts‑Labels zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation::Save](https://reference.aspose.com/slides/de/cpp/aspose.slides/ipresentation/save/) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.