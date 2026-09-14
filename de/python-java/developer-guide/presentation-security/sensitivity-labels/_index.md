---
title: Verwalten von Sensitivitätsbezeichnungen in PowerPoint-Präsentationen in Python
linktitle: Sensitivitätsbezeichnungen
type: docs
weight: 50
url: /de/python-java/sensitivity-labels/
keywords:
- Sensitivitätsbezeichnung
- Microsoft Purview
- Microsoft Information Protection
- MIP-Metadaten
- Inhaltskennzeichnung
- Informationsschutz
- Dokumentverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- Python
- Aspose.Slides
description: "Lesen, Hinzufügen, Aktualisieren, Entfernen und Migrieren von Microsoft Purview Sensitivitätsbezeichnungen in PowerPoint PPTX-Präsentationen mit Aspose.Slides für Python via Java."
---
## **Übersicht**

Microsoft Purview Sensitivitätsbezeichnungen helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatisierten Präsentationsverarbeitung muss eine Anwendung möglicherweise ein bestehendes Label beibehalten, ein durch eine Richtlinie ausgewähltes Label anwenden, dessen Status aktualisieren oder Label‑Metadaten migrieren, die von einem älteren Microsoft Information Protection (MIP)-Workflow geschrieben wurden.

Aspose.Slides stellt moderne Metadaten für Sensitivitätsbezeichnungen über [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSensitivityLabels) zur Verfügung. Diese Methode gibt eine [SensitivityLabelCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/) zurück, die inspiziert und geändert werden kann, bevor die Präsentation als PPTX gespeichert wird.

{{% alert color="info" title="Hinweis" %}}

Sensitivitätsbezeichner und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Überprüfen Sie die Verfügbarkeit von Labels und die Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschreiben die mit einem Label verbundenen Inhaltskennzeichnungen; sie fügen selbst keine sichtbaren Texte oder Formen zu Folien hinzu.

{{% /alert %}}

## **Eigenschaften von Sensitivitätsbezeichnungen verstehen**

Jedes [SensitivityLabel](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/) enthält die folgenden Metadaten:

| Methoden | Zweck |
| --- | --- |
| [getId](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getId) und [setId](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#setId) | Abrufen oder Festlegen des Sensitivitätsbezeichners in der Purview‑Richtlinie. |
| [getSiteId](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getSiteId) und [setSiteId](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Abrufen oder Festlegen der Site, die der Label‑Richtlinie zugeordnet ist. |
| [isEnabled](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#isEnabled) und [setEnabled](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Abrufen oder Festlegen, ob das Label aktiviert ist. |
| [isRemoved](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#isRemoved) und [setRemoved](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Abrufen oder Festlegen, ob das Label entfernt wurde. Setzen Sie den Wert auf `True`, wenn der Entfernungsstatus in den Metadaten beibehalten werden muss. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) und [setAssignmentMethodType](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Abrufen oder Festlegen, ob das Label automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [getContentMarkTypes](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Abrufen der Inhaltskennzeichnungstypen, die dem Label zugeordnet sind. |

Die Klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelassignmenttype/) definiert, wie ein Label zugewiesen wurde:

- [Standard](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelassignmenttype/) stellt ein Standard‑ oder automatisch angewendetes Label dar.
- [Privileged](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelassignmenttype/) stellt ein durch eine Benutzerentscheidung angewendetes Label dar, einschließlich manuell angewendeter, empfohlener und zwingender Labels.

Die Klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcontenttype/) definiert die mit einem Label verbundene Kennzeichnung:

| Wert | Bedeutung |
| --- | --- |
| [None](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcontenttype/) | Das Label wurde standardmäßig oder automatisch angewendet. |
| [Header](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcontenttype/) | Die Header‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [Footer](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcontenttype/) | Die Footer‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [Watermark](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcontenttype/) | Die Wasserzeichen‑Inhaltskennzeichnung ist dem Label zugeordnet. |
| [Encryption](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcontenttype/) | Die Verschlüsselungsschutz ist dem Label zugeordnet. |

Mehrere Kennzeichnungstypen können einem einzelnen Label zugeordnet werden.

## **Vorhandene Sensitivitätsbezeichnungen auflisten**

Lesen Sie die moderne Label‑Sammlung über [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSensitivityLabels) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und Inhaltskennzeichnung auf, die für jedes Label gespeichert ist:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Sensitivitätsbezeichnung mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/#add) mit dem Label‑Bezeichner, dem Site‑Bezeichner, dem aktivierten Zustand und der Zuweisungsmethode. Nachdem die Methode das neue [SensitivityLabel](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Kennzeichnungswerte über die Liste hinzu, die von [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegeben wird.

Das folgende Beispiel fügt ein manuell ausgewähltes Label hinzu, das mit Footer‑ und Wasserzeichen‑Kennzeichnungen verbunden ist, und speichert das Ergebnis anschließend als PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sensitivitätsbezeichnung aktualisieren**

Die Werte von [SensitivityLabel](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/) sind les‑ und schreibbar, mit Ausnahme der Liste, die von [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegeben wird, welche über ihre Listoperationen geändert wird. Nachdem das erforderliche Label gefunden wurde, können Sie dessen Bezeichner, Site‑Bezeichner, aktivierten Zustand, Zuweisungsmethode, Entfernungsstatus und Inhaltskennzeichnungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den aktivierten Zustand und die Zuweisungsmethode des ersten Labels:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sensitivitätsbezeichnung als entfernt markieren**

Um die Tatsache zu bewahren, dass ein Label entfernt wurde, finden Sie das Label und rufen Sie [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#setRemoved) mit `True` auf. Dadurch bleibt der Label‑Eintrag erhalten und sein Entfernungsstatus wird protokolliert. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen müssen, verwenden Sie [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); verwenden Sie [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/#clear), um alle Einträge zu löschen.

Das folgende Beispiel markiert ein bestimmtes Label als entfernt und speichert die aktualisierte Präsentation:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Legacy‑MIP‑Sensitivitätsbezeichnungen lesen und migrieren**

Ältere, auf MIP basierende Workflows können Metadaten zu Sensitivitätsbezeichnungen in benutzerdefinierten Dokumenteigenschaften anstelle der modernen Label‑Sammlung speichern. Lesen Sie diese Metadaten mit [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Die Methode analysiert die alten benutzerdefinierten Eigenschaften und gibt ein Array von [SensitivityLabel](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/)‑Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Label über [SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/#add) zur modernen [SensitivityLabelCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/) hinzu. Da das Hinzufügen eines doppelten Label‑Bezeichners eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Sammlung, bevor jedes Label kopiert wird. Sie können zusätzliche Validierungen hinzufügen, um zu bestätigen, dass jedes Legacy‑Label noch in der aktuellen Purview‑Richtlinie existiert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Migration kopiert die geparsten Label‑Objekte in die moderne Sammlung. Es ist nicht nötig, alle benutzerdefinierten Dokumenteigenschaften zu löschen, sodass unverwandte Dokumentmetadaten erhalten bleiben. Verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/), um die modernen Label‑Metadaten in eine PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltskennzeichnungstyps eine sichtbare Kopf‑, Fußzeile oder ein Wasserzeichen auf Folien?**

Nein. Durch die Liste, die von [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegeben wird, hinzugefügte Werte beschreiben die mit dem Sensitivitätslabel verbundenen Kennzeichnungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, falls Ihr Workflow diese Kennzeichnungen darstellen muss.

**Was ist der Unterschied zwischen dem Markieren eines Labels als entfernt und dem Löschen aus der Sammlung?**

Ein Aufruf von [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#setRemoved) mit `True` behält den Label‑Eintrag bei und protokolliert dessen Entfernungsstatus. Ein Aufruf von [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) löscht den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Aufbewahrungsvorgaben Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätsbezeichnungen enthalten?**

Ja. Legacy‑Labels können in benutzerdefinierten Dokumenteigenschaften verbleiben, während moderne Labels über [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSensitivityLabels) verfügbar sind. Verwenden Sie [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getSensitivityLabels), um die Legacy‑Metadaten zu lesen und nur die gültigen Labels zu migrieren, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn ein Label mit demselben Bezeichner mehrmals hinzugefügt wird?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabelcollection/#add) löst eine Ausnahme aus, wenn die Sammlung bereits ein Label mit demselben Bezeichner enthält. Überprüfen Sie die vorhandenen Werte, die von [SensitivityLabel.getId](https://reference.aspose.com/slides/de/python-java/aspose.slides/sensitivitylabel/#getId) zurückgegeben werden, bevor Sie Labels hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätsbezeichnungen zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.