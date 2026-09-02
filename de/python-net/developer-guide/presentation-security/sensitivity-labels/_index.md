---
title: Sensitivitätslabels in PowerPoint-Präsentationen mit Python verwalten
linktitle: Sensitivitätslabels
type: docs
weight: 50
url: /de/python-net/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren Sie Microsoft Purview Sensitivitätslabels in PowerPoint-PPTX-Präsentationen mit Aspose.Slides für Python via .NET."
---
## **Übersicht**

Microsoft Purview Sensitivitätslabels helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatischen Präsentationsverarbeitung muss eine Anwendung ein vorhandenes Label beibehalten, ein von einer Richtlinie ausgewähltes Label anwenden, dessen Zustand aktualisieren oder Metadaten eines von einem älteren Microsoft Information Protection (MIP)‑Workflow geschriebenen Labels migrieren.

Aspose.Slides für Python via .NET stellt moderne Sensitivitätslabel‑Metadaten über [Presentation.sensitivity_labels](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/sensitivity_labels/) bereit. Diese Eigenschaft liefert eine [SensitivityLabelCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/), die vor dem Speichern der Präsentation als PPTX eingesehen und geändert werden kann.

{{% alert color="primary" title="Hinweis" %}}

Sensitivitätslabel‑Kennungen und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Validieren Sie die Verfügbarkeit von Labels und Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/content_mark_types/) beschreiben die mit einem Label verbundenen Inhaltskennzeichnungen; sie erzeugen nicht automatisch sichtbaren Text oder Formen auf Folien.

{{% /alert %}}

## **Sensitivitätslabel‑Eigenschaften verstehen**

Jedes [SensitivityLabel](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/) enthält die folgenden Metadaten:

| Eigenschaft | Zweck |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/id/) | Identifiziert das Sensitivitätslabel in der Purview‑Richtlinie. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifiziert die Site, die mit der Label‑Richtlinie verknüpft ist. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Gibt an, ob das Label aktiviert ist. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/is_removed/) | Gibt an, dass das Label entfernt wurde. Setzen Sie diese Eigenschaft auf `True`, wenn der Entfernungszustand in den Metadaten erhalten bleiben muss. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Gibt an, ob das Label automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Listet die Inhalt‑Kennzeichnungstypen auf, die dem Label zugeordnet sind. |

Die Aufzählung [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelassignmenttype/) beschreibt, wie ein Label zugewiesen wurde:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelassignmenttype/) steht für ein Standard‑ oder automatisch angewendetes Label.
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelassignmenttype/) steht für ein durch eine Benutzerentscheidung angewendetes Label, einschließlich manuell angewendeter, empfohlener und obligatorischer Labels.

Die Aufzählung [SensitivityLabelContentType](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcontenttype/) identifiziert die mit einem Label verbundene Kennzeichnung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcontenttype/) | Das Label wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcontenttype/) | Der Header‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcontenttype/) | Der Footer‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcontenttype/) | Der Wasserzeichen‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcontenttype/) | Der Verschlüsselungsschutz ist dem Label zugeordnet. |

Mehrere Kennzeichnungstypen können einem Label zugeordnet werden.

## **Vorhandene Sensitivitätslabels auflisten**

Lesen Sie die moderne Label‑Sammlung aus [Presentation.sensitivity_labels](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/sensitivity_labels/) und iterieren Sie darüber. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltskennzeichnung für jedes Label auf:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Ein Sensitivitätslabel mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/add/) mit dem Label‑Identifier, dem Site‑Identifier, dem Aktivierungszustand und der Zuweisungsmethode. Übergeben Sie den Site‑Identifier als Python‑Objekt vom Typ `uuid.UUID`. Nachdem die Methode das neue [SensitivityLabel](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/) zurückgegeben hat, hängen Sie die erforderlichen Kennzeichnungswerte an [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/content_mark_types/) an.

Das folgende Beispiel fügt ein manuell ausgewähltes Label hinzu, das mit Footer‑ und Wasserzeichenkennzeichnungen verknüpft ist, und speichert das Ergebnis als PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Sensitivitätslabel aktualisieren**

Die Eigenschaften des [SensitivityLabel](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/) sind les‑/schreibbar, außer dass die von [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/content_mark_types/) zurückgegebene Liste über ihre Listenoperationen geändert wird. Nachdem Sie das gewünschte Label gefunden haben, können Sie dessen Identifier, Site‑Identifier, Aktivierungszustand, Zuweisungsmethode, Entfernungszustand und Inhaltskennzeichnungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den Aktivierungszustand und die Zuweisungsmethode des ersten Labels:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Sensitivitätslabel als entfernt markieren**

Um festzuhalten, dass ein Label entfernt wurde, finden Sie das Label und setzen Sie [SensitivityLabel.is_removed](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/is_removed/) auf `True`. Dadurch bleibt der Label‑Eintrag erhalten, während sein Entfernungszustand gespeichert wird. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen möchten, verwenden Sie [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); verwenden Sie [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/clear/) zum Entfernen aller Einträge.

Das folgende Beispiel markiert ein bestimmtes Label als entfernt und speichert die aktualisierte Präsentation:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Legacy‑MIP‑Sensitivitätslabels lesen und migrieren**

Ältere, auf MIP basierende Workflows können Sensitivitätslabel‑Metadaten in benutzerdefinierten Dokumenteneigenschaften anstelle der modernen Label‑Sammlung speichern. Lesen Sie diese Metadaten mit [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Die Methode parsed die Legacy‑Eigenschaften und gibt [SensitivityLabel](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/)-Objekte zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Label über [SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/add/) zur modernen [SensitivityLabelCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/) hinzu. Da das Hinzufügen eines doppelten Label‑Identifiers eine Ausnahme auslöst, prüft das Beispiel die Zielsammlung, bevor jedes Label kopiert wird. Sie können weitere Validierungen einbauen, um zu bestätigen, dass jedes Legacy‑Label noch in der aktuellen Purview‑Richtlinie existiert.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

Die Migration kopiert die geparsten Label‑Objekte in die moderne Sammlung. Sie erfordert nicht das Löschen aller benutzerdefinierten Dokumenteneigenschaften, sodass nicht verwandte Dokumenten‑Metadaten erhalten bleiben. Verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) mit [SaveFormat.PPTX](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/), um die modernen Label‑Metadaten in einer PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltskennzeichnungstyps einen sichtbaren Header, Footer oder ein Wasserzeichen auf den Folien?**

Nein. Werte, die über [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/content_mark_types/) hinzugefügt werden, beschreiben die mit dem Sensitivitätslabel verbundenen Kennzeichnungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, wenn Ihr Workflow diese Kennzeichnungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren eines Labels als entfernt und dem Löschen aus der Sammlung?**

Das Setzen von [SensitivityLabel.is_removed](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/is_removed/) auf `True` behält den Label‑Eintrag bei und protokolliert seinen Entfernungszustand. Der Aufruf von [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) löscht den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätslabels enthalten?**

Ja. Legacy‑Labels können in benutzerdefinierten Dokumenteneigenschaften verbleiben, während moderne Labels über [Presentation.sensitivity_labels](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/sensitivity_labels/) verfügbar sind. Verwenden Sie [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/get_sensitivity_labels/), um die Legacy‑Metadaten zu lesen und nur die gültigen Labels zu migrieren, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn ein Label mit demselben Identifier mehrmals hinzugefügt wird?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabelcollection/add/) löst eine Ausnahme aus, wenn die Sammlung bereits ein Label mit demselben Identifier enthält. Prüfen Sie die vorhandenen [SensitivityLabel.id](https://reference.aspose.com/slides/de/python-net/aspose.slides/sensitivitylabel/id/)-Werte, bevor Sie Labels hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätslabels zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) mit [SaveFormat.PPTX](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.