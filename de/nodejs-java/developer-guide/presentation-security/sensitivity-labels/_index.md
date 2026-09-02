---
title: Sensitivitätslabels in PowerPoint-Präsentationen in JavaScript verwalten
linktitle: Sensitivitätslabels
type: docs
weight: 50
url: /de/nodejs-java/sensitivity-labels/
keywords:
- Sensitivitätslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP-Metadaten
- Inhaltsmarkierung
- Informationsschutz
- Dokumentverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- Node.js
- JavaScript
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren von Microsoft Purview Sensitivitätslabels in PowerPoint PPTX-Präsentationen mit Aspose.Slides für Node.js via Java."
---
## **Übersicht**

Microsoft Purview Sensitivitätslabels helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatischen Präsentationsverarbeitung kann eine Anwendung ein vorhandenes Label beibehalten, ein durch eine Richtlinie ausgewähltes Label anwenden, dessen Status aktualisieren oder Metadaten eines älteren Microsoft Information Protection (MIP)-Workflows migrieren.

Aspose.Slides für Node.js via Java stellt moderne Sensitivitätslabel‑Metadaten über [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) bereit. Diese Methode gibt eine [SensitivityLabelCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX eingesehen und geändert werden kann.

{{% alert color="primary" title="Hinweis" %}}
Sensitivitätslabel‑Kennungen und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Prüfen Sie die Verfügbarkeit von Labels und Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschreiben die mit einem Label verbundenen Inhaltsmarkierungen; sie fügen nicht automatisch sichtbaren Text oder Formen zu Folien hinzu.
{{% /alert %}}

## **Sensitivitäts‑Label‑Eigenschaften verstehen**

Jedes [SensitivityLabel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/) enthält die folgenden Metadaten:

| Methoden | Zweck |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getId) und [SensitivityLabel.setId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Lesen oder Festlegen der Sensitivitätslabel‑Kennung in der Purview‑Richtlinie. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) und [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Lesen oder Festlegen der Site, die mit der Label‑Richtlinie verknüpft ist. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) und [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Lesen oder Festlegen, ob das Label aktiviert ist. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) und [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Lesen oder Festlegen, ob das Label entfernt wurde. Setzen Sie den Wert auf `true`, wenn der Entfernungsstatus in den Metadaten erhalten bleiben muss. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) und [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Lesen oder Festlegen, ob das Label automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Lesen der Inhaltsmarkierungstypen, die dem Label zugeordnet sind. |

Die Klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) definiert, wie ein Label zugewiesen wurde:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) steht für ein Standard‑ oder automatisch angewendetes Label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) steht für ein durch eine Benutzerentscheidung angewendetes Label, inklusive manuell angewendeter, empfohlener und verpflichtender Labels.

Die Klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) definiert die mit einem Label verbundene Markierung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Das Label wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Eine Kopfzeilen‑Inhaltsmarkierung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Eine Fußzeilen‑Inhaltsmarkierung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Eine Wasserzeichen‑Inhaltsmarkierung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Eine Verschlüsselungsschutz ist dem Label zugeordnet. |

Mehrere Markierungstypen können einem einzigen Label zugeordnet werden.

## **Vorhandene Sensitivitätslabels auflisten**

Lesen Sie die moderne Label‑Sammlung über [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) und iterieren Sie darüber. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltsmarkierung auf, die für jedes Label gespeichert ist:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Ein Sensitivitätslabel mit Inhaltsmarkierung hinzufügen**

Verwenden Sie [SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) mit Label‑Kennung, Site‑Kennung, aktivem Zustand und Zuweisungsmethode. Nachdem die Methode das neue [SensitivityLabel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Markierungswerte über die Liste hinzu, die von [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegeben wird.

Das folgende Beispiel fügt ein manuell ausgewähltes Label hinzu, das mit Fußzeilen‑ und Wasserzeichen‑Markierungen verknüpft ist, und speichert das Ergebnis anschließend als PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Sensitivitätslabel aktualisieren**

Die Werte des [SensitivityLabel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/) sind les‑ und schreibbar, außer dass die über [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegebene Liste über ihre Listoperationen geändert wird. Nachdem Sie das gewünschte Label gefunden haben, können Sie Kennung, Site‑Kennung, Aktivitätsstatus, Zuweisungsmethode, Entfernungsstatus und Inhaltsmarkierungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den Aktivitätsstatus und die Zuweisungsmethode des ersten Labels:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ein Sensitivitätslabel als entfernt markieren**

Um festzuhalten, dass ein Label entfernt wurde, finden Sie das Label und rufen Sie [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) mit `true` auf. Dadurch bleibt der Label‑Eintrag erhalten, während sein Entfernungsstatus protokolliert wird. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen möchten, verwenden Sie [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); mit [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) entfernen Sie sämtliche Einträge.

Das folgende Beispiel markiert ein bestimmtes Label als entfernt und speichert die aktualisierte Präsentation:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy‑MIP‑Sensitivitätslabels lesen und migrieren**

Ältere MIP‑basierte Workflows können Sensitivitätslabel‑Metadaten in benutzerdefinierten Dokumenteigenschaften statt in der modernen Label‑Sammlung speichern. Lesen Sie diese Metadaten mit [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Die Methode parsed die Legacy‑Benutzerdefiniert‑Eigenschaften und gibt ein Array von [SensitivityLabel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/)‑Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Label über [SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) zur modernen [SensitivityLabelCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/) hinzu. Da das Hinzufügen einer doppelten Label‑Kennung eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Sammlung, bevor es jedes Label kopiert. Sie können zusätzliche Validierungen einbauen, um sicherzustellen, dass jedes Legacy‑Label noch in der aktuellen Purview‑Richtlinie existiert.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Migration kopiert die geparsten Label‑Objekte in die moderne Sammlung. Sie erfordert kein Löschen aller benutzerdefinierten Dokumenteigenschaften, sodass unverwandte Dokumentmetadaten erhalten bleiben. Verwenden Sie [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/), um die modernen Label‑Metadaten in eine PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltsmarkierungstyps eine sichtbare Kopf‑, Fußzeile oder ein Wasserzeichen auf den Folien?**

Nein. Werte, die über die von [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegebene Liste hinzugefügt werden, beschreiben die Markierungen, die dem Sensitivitätslabel zugeordnet sind. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, falls Ihr Workflow diese Markierungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren eines Labels als entfernt und dem Löschen aus der Sammlung?**

Ein Aufruf von [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) mit `true` behält den Label‑Eintrag bei und protokolliert dessen Entfernungsstatus. Ein Aufruf von [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) entfernt den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätslabels enthalten?**

Ja. Legacy‑Labels können in benutzerdefinierten Dokumenteigenschaften verbleiben, während moderne Labels über [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) verfügbar sind. Verwenden Sie [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels), um die Legacy‑Metadaten zu lesen und nur die gültigen Labels zu migrieren, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn ein Label mit derselben Kennung mehrmals hinzugefügt wird?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) löst eine Ausnahme aus, wenn die Sammlung bereits ein Label mit derselben Kennung enthält. Prüfen Sie vor dem Hinzufügen oder Migrieren die vorhandenen Werte, die von [SensitivityLabel.getId](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sensitivitylabel/#getId) zurückgegeben werden.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätslabels zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [Presentation.save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.