---
title: Sensitivitätskennzeichnungen in PowerPoint-Präsentationen in .NET verwalten
linktitle: Sensitivitätskennzeichnungen
type: docs
weight: 50
url: /de/net/sensitivity-labels/
keywords:
- Sensitivitätskennzeichnung
- Microsoft Purview
- Microsoft Information Protection
- MIP-Metadaten
- Inhaltskennzeichnung
- Informationsschutz
- Dokumentenverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- .NET
- C#
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren Sie Microsoft Purview Sensitivitätskennzeichnungen in PowerPoint PPTX‑Präsentationen mit Aspose.Slides für .NET."
---
## **Übersicht**

Microsoft Purview Sensitivitätskennzeichnungen helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatisierten Präsentationsverarbeitung kann eine Anwendung ein vorhandenes Kennzeichen beibehalten, ein durch eine Richtlinie ausgewähltes Kennzeichen anwenden, dessen Status aktualisieren oder Kennzeichnungsmetadaten, die von einem älteren Microsoft Information Protection (MIP)-Workflow geschrieben wurden, migrieren.

Aspose.Slides stellt moderne Metadaten für Sensitivitätskennzeichnungen über [Presentation.SensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sensitivitylabels/). Diese Eigenschaft gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/) zurück, die inspiziert und geändert werden kann, bevor die Präsentation als PPTX gespeichert wird.

{{% alert color="info" title="Hinweis" %}}

Sensitivitätskennzeichen‑Identifier und Richtlininformation sind durch Ihre Microsoft Purview‑Konfiguration definiert. Validieren Sie die Verfügbarkeit von Kennzeichen und Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) beschreiben die Inhaltskennzeichnungen, die einem Kennzeichen zugeordnet sind; sie fügen nicht automatisch sichtbaren Text oder Formen zu Folien hinzu.

{{% /alert %}}

## **Sensitivitätskennzeichnungs‑Eigenschaften verstehen**

Jedes [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Eigenschaft | Zweck |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/id/) | Identifiziert das Sensitivitätskennzeichen in der Purview‑Richtlinie. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/siteid/) | Identifiziert die mit der Kennzeichnungsrichtlinie verbundene Site. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isenabled/) | Gibt an, ob das Kennzeichen aktiviert ist. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isremoved/) | Zeigt an, dass das Kennzeichen entfernt wurde. Setzen Sie diese Eigenschaft auf `true`, wenn der Entfernungsstatus in den Metadaten beibehalten werden muss. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Gibt an, ob das Kennzeichen automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Listet die mit dem Kennzeichen verbundenen Inhaltskennzeichnungs‑Typen auf. |

Die Aufzählung [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelassignmenttype/) beschreibt, wie ein Kennzeichen zugewiesen wurde:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelassignmenttype/) steht für ein Standard‑ oder automatisch angewendetes Kennzeichen.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelassignmenttype/) steht für ein Kennzeichen, das durch eine Benutzerentscheidung angewendet wurde, einschließlich manuell angewendeter, empfohlener und verpflichtender Kennzeichnungen.

Die Aufzählung [SensitivityLabelContentType](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) identifiziert die mit einem Kennzeichen verbundene Kennzeichnung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Das Kennzeichen wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Ein Kopfzeilen‑Inhaltskennzeichen ist dem Kennzeichen zugeordnet. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Ein Fußzeilen‑Inhaltskennzeichen ist dem Kennzeichen zugeordnet. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Ein Wasserzeichen‑Inhaltskennzeichen ist dem Kennzeichen zugeordnet. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Verschlüsselungsschutz ist dem Kennzeichen zugeordnet. |

Mehrere Kennzeichnungstypen können einem Kennzeichen zugeordnet werden.

## **Vorhandene Sensitivitätskennzeichnungen auflisten**

Lesen Sie die moderne Kennzeichnungssammlung aus [Presentation.SensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sensitivitylabels/) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltskennzeichnung auf, die für jedes Kennzeichen gespeichert ist:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Ein Sensitivitätskennzeichen mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/add/) mit dem Kennzeichen‑Identifier, dem Site‑Identifier, dem Aktivierungsstatus und der Zuweisungsmethode. Nachdem die Methode das neue [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/) zurückgibt, fügen Sie die erforderlichen Kennzeichnungswerte über [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) hinzu.

Das folgende Beispiel fügt ein manuell ausgewähltes Kennzeichen hinzu, das mit Fußzeilen‑ und Wasserzeichen‑Kennzeichnungen verknüpft ist, und speichert das Ergebnis anschließend als PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Ein Sensitivitätskennzeichen aktualisieren**

Die Eigenschaften des [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/) sind les‑/schreibbar, außer dass die über [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) zurückgegebene Sammlung über deren List‑Operationen geändert wird. Nachdem Sie das gewünschte Kennzeichen gefunden haben, können Sie dessen Identifier, Site‑Identifier, Aktivierungsstatus, Zuweisungsmethode, Entfernungsstatus und Inhaltskennzeichnungs‑Typen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den Aktivierungsstatus und die Zuweisungsmethode des ersten Kennzeichens:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Ein Sensitivitätskennzeichen als entfernt markieren**

Um den Umstand zu erhalten, dass ein Kennzeichen entfernt wurde, finden Sie das Kennzeichen und setzen Sie [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isremoved/) auf `true`. Dadurch bleibt der Kennzeichniseintrag erhalten und sein Entfernungsstatus wird vermerkt. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen müssen, verwenden Sie [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/removeat/); verwenden Sie [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/clear/), um jeden Eintrag zu löschen.

Das folgende Beispiel markiert ein bestimmtes Kennzeichen als entfernt und speichert die aktualisierte Präsentation:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Legacy‑MIP‑Sensitivitätskennzeichnungen lesen und migrieren**

Ältere, auf MIP basierende Workflows können Metadaten für Sensitivitätskennzeichnungen in benutzerdefinierten Dokumenteigenschaften anstelle der modernen Kennzeichnungssammlung speichern. Lesen Sie diese Metadaten mit [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Die Methode analysiert die Legacy‑ benutzerdefinierten Eigenschaften und gibt ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/)‑Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Kennzeichen über [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/add/) zur modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/) hinzu. Da das Hinzufügen eines doppelten Kennzeichen‑Identifiers eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Sammlung, bevor jedes Kennzeichen kopiert wird. Sie können weitere Validierungen hinzufügen, um zu bestätigen, dass jedes Legacy‑Kennzeichen noch in der aktuellen Purview‑Richtlinie vorhanden ist.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Die Migration kopiert die analysierten Kennzeichenobjekte in die moderne Sammlung. Es ist nicht erforderlich, alle benutzerdefinierten Dokumenteigenschaften zu löschen, sodass nicht zugehörige Dokumentmetadaten erhalten bleiben. Verwenden Sie [IPresentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/save/) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/), um die modernen Kennzeichnungs‑Metadaten in eine PPTX‑Datei zu schreiben.

## **FAQ**

**Erstellt das Hinzufügen eines Inhaltskennzeichnungstyps eine sichtbare Kopf‑, Fußzeile oder ein Wasserzeichen auf Folien?**

Nein. Werte, die über [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) hinzugefügt werden, beschreiben die mit dem Sensitivitätskennzeichen verbundenen Kennzeichnungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, falls Ihr Workflow diese Kennzeichnungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren eines Kennzeichens als entfernt und dem Löschen aus der Sammlung?**

Das Setzen von [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isremoved/) auf `true` bewahrt den Kennzeichniseintrag und vermerkt seinen Entfernungsstatus. Der Aufruf von [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/removeat/) löscht den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätskennzeichnungen enthalten?**

Ja. Legacy‑Kennzeichen können in benutzerdefinierten Dokumenteigenschaften verbleiben, während moderne Kennzeichnungen über [Presentation.SensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sensitivitylabels/) verfügbar sind. Verwenden Sie [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/getsensitivitylabels/), um die Legacy‑Metadaten zu lesen und nur die gültigen Kennzeichen zu migrieren, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn ein Kennzeichen mit demselben Identifier mehrmals hinzugefügt wird?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/add/) wirft eine `ArgumentException`, wenn die Sammlung bereits ein Kennzeichen mit demselben Identifier enthält. Prüfen Sie die vorhandenen [ISensitivityLabel.Id](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/id/)-Werte, bevor Sie Kennzeichen hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätskennzeichnungen zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/save/) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.