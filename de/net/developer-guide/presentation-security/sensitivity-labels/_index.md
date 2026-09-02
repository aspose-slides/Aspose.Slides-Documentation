---
title: Sensitivitätslabels in PowerPoint-Präsentationen in .NET verwalten
linktitle: Sensitivitätslabels
type: docs
weight: 50
url: /de/net/sensitivity-labels/
keywords:
- Sensitivitätslabel
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
description: "Lesen, Hinzufügen, Aktualisieren, Entfernen und Migrieren von Microsoft Purview Sensitivitätslabels in PowerPoint-PPTX-Präsentationen mit Aspose.Slides für .NET."
---
## **Übersicht**

Microsoft Purview Sensitivitätsbezeichnungen helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatisierten Präsentationsverarbeitung kann eine Anwendung ein vorhandenes Label beibehalten, ein von einer Richtlinie ausgewähltes Label anwenden, dessen Zustand aktualisieren oder Metadaten eines Labels, die von einem älteren Microsoft Information Protection (MIP)-Arbeitsablauf geschrieben wurden, migrieren.

Aspose.Slides stellt moderne Sensitivitätslabel‑Metadaten über [Presentation.SensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sensitivitylabels/). Diese Eigenschaft gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX inspiziert und geändert werden kann.

{{% alert color="primary" title="Note" %}}
Sensitivitätslabel‑IDs und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Überprüfen Sie die Verfügbarkeit von Labels und Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) beschreiben die mit einem Label verbundenen Inhaltskennzeichnungen; sie fügen nicht selbst sichtbaren Text oder Formen zu Folien hinzu.
{{% /alert %}}

## **Sensitivitätslabel‑Eigenschaften verstehen**

Jedes [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Eigenschaft | Zweck |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/id/) | Identifiziert das Sensitivitätslabel in der Purview‑Richtlinie. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/siteid/) | Identifiziert die Site, die mit der Label‑Richtlinie verknüpft ist. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isenabled/) | Gibt an, ob das Label aktiviert ist. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isremoved/) | Gibt an, dass das Label entfernt wurde. Setzen Sie diese Eigenschaft auf `true`, wenn der Entfernen‑Zustand in den Metadaten beibehalten werden muss. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Gibt an, ob das Label automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Listet die Inhaltskennzeichnungsarten auf, die dem Label zugeordnet sind. |

Die Aufzählung [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelassignmenttype/) beschreibt, wie ein Label zugewiesen wurde:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelassignmenttype/) repräsentiert ein Standard‑ oder automatisch angewendetes Label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelassignmenttype/) repräsentiert ein durch eine Benutzerentscheidung angewendetes Label, einschließlich manuell angewandter, empfohlener und obligatorischer Labels.

Die Aufzählung [SensitivityLabelContentType](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) identifiziert die mit einem Label verbundene Kennzeichnung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Das Label wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Header‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Footer‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Wasserzeichen‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/de/net/aspose.slides/sensitivitylabelcontenttype/) | Verschlüsselungsschutz ist dem Label zugeordnet. |

Mehrere Kennzeichnungstypen können einem Label zugeordnet werden.

## **Vorhandene Sensitivitätslabels auflisten**

Lesen Sie die moderne Label‑Sammlung aus [Presentation.SensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sensitivitylabels/) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und Inhaltskennzeichnung auf, die für jedes Label gespeichert ist:

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

## **Ein Sensitivitätslabel mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/add/) mit der Label‑ID, der Site‑ID, dem aktivierten Zustand und der Zuweisungsmethode. Nachdem die Methode das neue [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Kennzeichnungswerte über [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) hinzu.

Das folgende Beispiel fügt ein manuell ausgewähltes Label hinzu, das Footer‑ und Wasserzeichen‑Kennzeichnungen zugeordnet ist, und speichert das Ergebnis anschließend als PPTX:

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

## **Sensitivitätslabel aktualisieren**

Die Eigenschaften von [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/) sind les‑/schreibbar, außer dass die durch [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) zurückgegebene Sammlung über deren Listenoperationen modifiziert wird. Nachdem Sie das gewünschte Label gefunden haben, können Sie seine ID, Site‑ID, den aktivierten Zustand, die Zuweisungsmethode, den Entfernen‑Zustand und die Inhaltskennzeichnungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den aktivierten Zustand und die Zuweisungsmethode des ersten Labels:

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

## **Ein Sensitivitätslabel als entfernt markieren**

Um den Umstand zu erhalten, dass ein Label entfernt wurde, finden Sie das Label und setzen Sie [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isremoved/) auf `true`. Damit bleibt der Label‑Eintrag erhalten, während dessen Entfernen‑Zustand protokolliert wird. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen müssen, verwenden Sie [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/removeat/); verwenden Sie [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/clear/) , um alle Einträge zu löschen.

Das folgende Beispiel markiert ein bestimmtes Label als entfernt und speichert die aktualisierte Präsentation:

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

## **Legacy‑MIP‑Sensitivitätslabels lesen und migrieren**

Ältere MIP‑basierte Arbeitsabläufe können Sensitivitätslabel‑Metadaten in benutzerdefinierten Dokumenteneigenschaften anstelle der modernen Label‑Sammlung speichern. Lesen Sie diese Metadaten mit [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Die Methode analysiert die Legacy‑Eigenschaften und gibt ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/)‑Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Label über [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/add/) zur modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/) hinzu. Da das Hinzufügen einer doppelten Label‑ID eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Sammlung, bevor jedes Label kopiert wird. Sie können zusätzliche Validierungen hinzufügen, um zu bestätigen, dass jedes Legacy‑Label noch in der aktuellen Purview‑Richtlinie vorhanden ist.

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

Die Migration kopiert die analysierten Label‑Objekte in die moderne Sammlung. Es ist nicht erforderlich, alle benutzerdefinierten Dokumenteneigenschaften zu löschen, sodass nicht zugehörige Dokumenten‑Metadaten erhalten bleiben. Verwenden Sie [IPresentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/save/) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/), um die modernen Label‑Metadaten in eine PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltskennzeichnungstyps einen sichtbaren Header, Footer oder Wasserzeichen auf Folien?**

Nein. Durch [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/contentmarktypes/) hinzugefügte Werte beschreiben die mit dem Sensitivitätslabel verbundenen Kennzeichnungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, wenn Ihr Arbeitsablauf diese Kennzeichnungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren eines Labels als entfernt und dem Löschen aus der Sammlung?**

Das Setzen von [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/isremoved/) auf `true` bewahrt den Label‑Eintrag und protokolliert dessen Entfernen‑Zustand. Der Aufruf von [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/removeat/) löscht den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Metadaten‑Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätslabels enthalten?**

Ja. Legacy‑Labels können in benutzerdefinierten Dokumenteneigenschaften verbleiben, während moderne Labels über [Presentation.SensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/sensitivitylabels/) verfügbar sind. Verwenden Sie [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/de/net/aspose.slides/idocumentproperties/getsensitivitylabels/), um die Legacy‑Metadaten zu lesen und nur die gültigen Labels zu migrieren, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn ein Label mit derselben Kennung mehrmals hinzugefügt wird?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabelcollection/add/) wirft eine `ArgumentException`, wenn die Sammlung bereits ein Label mit derselben Kennung enthält. Überprüfen Sie die vorhandenen [ISensitivityLabel.Id](https://reference.aspose.com/slides/de/net/aspose.slides/isensitivitylabel/id/)‑Werte, bevor Sie Labels hinzufügen oder migrieren.

**Welches Ausgabformat sollte verwendet werden, um aktualisierte Sensitivitätslabels zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation.Save](https://reference.aspose.com/slides/de/net/aspose.slides/ipresentation/save/) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/net/aspose.slides.export/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.