---
title: Sensitivitätsbezeichnungen in PowerPoint-Präsentationen in Java verwalten
linktitle: Sensitivitätsbezeichnungen
type: docs
weight: 50
url: /de/java/sensitivity-labels/
keywords:
- Sensitivitätsbezeichnung
- Microsoft Purview
- Microsoft Information Protection
- MIP-Metadaten
- Inhaltskennzeichnung
- Informationsschutz
- Dokumentenverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- Java
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren Sie Microsoft Purview Sensitivitätsbezeichnungen in PowerPoint PPTX-Präsentationen mit Aspose.Slides für Java."
---
## **Übersicht**

Microsoft Purview Sensitivitätsbezeichnungen helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatischen Präsentationsverarbeitung muss eine Anwendung möglicherweise eine vorhandene Bezeichnung beibehalten, eine von einer Richtlinie ausgewählte Bezeichnung anwenden, ihren Zustand aktualisieren oder Metadaten einer älteren Microsoft Information Protection (MIP)-Workflow‑Bezeichnung migrieren.

Aspose.Slides stellt moderne Sensitivitätsbezeichner‑Metadaten über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) bereit. Diese Methode gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX eingesehen und geändert werden kann.

{{% alert color="primary" title="Hinweis" %}}

Sensitivitätsbezeichner‑IDs und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Überprüfen Sie in Ihrer Umgebung die Verfügbarkeit von Bezeichnungen und Richtlinienanforderungen, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschreiben die mit einer Bezeichnung verknüpften Inhaltskennzeichnungen; sie fügen nicht selbst sichtbaren Text oder Formen zu Folien hinzu.

{{% /alert %}}

## **Sensitivitätsbezeichner‑Eigenschaften verstehen**

Jede [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Methoden | Zweck |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getId--) und [ISensitivityLabel.setId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Abrufen oder Festlegen der Sensitivitätsbezeichner‑ID in der Purview‑Richtlinie. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getSiteId--) und [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Abrufen oder Festlegen der Site, die der Bezeichner‑Richtlinie zugeordnet ist. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#isEnabled--) und [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Abrufen oder Festlegen, ob die Bezeichnung aktiviert ist. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#isRemoved--) und [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Abrufen oder Festlegen, ob die Bezeichnung entfernt wurde. Setzen Sie den Wert auf `true`, wenn der Entfernungsstatus in den Metadaten erhalten bleiben muss. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) und [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Abrufen oder Festlegen, ob die Bezeichnung automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Abrufen der Inhaltkennzeichnungs‑Typen, die der Bezeichnung zugeordnet sind. |

Die Klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelassignmenttype/) definiert, wie eine Bezeichnung zugewiesen wurde:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelassignmenttype/) stellt eine Standard‑ oder automatisch angewendete Bezeichnung dar.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelassignmenttype/) stellt eine durch Benutzerentscheidung angewendete Bezeichnung dar, einschließlich manuell angewendeter, empfohlener und verpflichtender Bezeichnungen.

Die Klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) definiert die mit einer Bezeichnung verbundene Kennzeichnung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Die Bezeichnung wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Kopfzeilen‑Inhaltskennzeichnung ist der Bezeichnung zugeordnet. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Fußzeilen‑Inhaltskennzeichnung ist der Bezeichnung zugeordnet. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Wasserzeichen‑Inhaltskennzeichnung ist der Bezeichnung zugeordnet. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Verschlüsselung ist der Bezeichnung zugeordnet. |

Mehrere Kennzeichnungstypen können einer Bezeichnung zugeordnet sein.

## **Vorhandene Sensitivitätsbezeichnungen auflisten**

Lesen Sie die moderne Bezeichnungssammlung über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltskennzeichnung für jede Bezeichnung auf:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Eine Sensitivitätsbezeichnung mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) mit Bezeichner‑ID, Site‑ID, aktiviertem Zustand und Zuweisungsmethode. Nachdem die Methode das neue [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Kennzeichnungswerte über die Liste von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) hinzu.

Das folgende Beispiel fügt eine manuell ausgewählte Bezeichnung hinzu, die mit Fußzeilen‑ und Wasserzeichen‑Kennzeichnungen verknüpft ist, und speichert das Ergebnis anschließend als PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eine Sensitivitätsbezeichnung aktualisieren**

Die Werte des [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/) sind les‑ und schreibbar, außer dass die Liste, die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegeben wird, über deren List‑Operationen modifiziert wird. Nachdem Sie die gewünschte Bezeichnung gefunden haben, können Sie deren Bezeichner‑ID, Site‑ID, aktivierten Zustand, Zuweisungsmethode, Entfernungsstatus und Inhaltskennzeichnungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den aktivierten Zustand und die Zuweisungsmethode der ersten Bezeichnung:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eine Sensitivitätsbezeichnung als entfernt kennzeichnen**

Um festzuhalten, dass eine Bezeichnung entfernt wurde, finden Sie die Bezeichnung und rufen Sie [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` auf. Dadurch bleibt der Bezeichnungseintrag erhalten, während ihr Entfernungsstatus protokolliert wird. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen möchten, verwenden Sie [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); verwenden Sie [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#clear--) zum Löschen aller Einträge.

Das folgende Beispiel kennzeichnet eine bestimmte Bezeichnung als entfernt und speichert die aktualisierte Präsentation:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy‑MIP‑Sensitivitätsbezeichnungen lesen und migrieren**

Ältere MIP‑basierte Workflows können Sensitivitätsbezeichner‑Metadaten in benutzerdefinierten Dokumenteneigenschaften statt in der modernen Bezeichnungssammlung speichern. Lesen Sie diese Metadaten mit [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Die Methode analysiert die Legacy‑Eigenschaften und gibt ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/)‑Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jede zurückgegebene Bezeichnung der modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/) über [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) hinzu. Da das Hinzufügen einer doppelten Bezeichner‑ID eine Ausnahme auslöst, prüft das Beispiel vor dem Kopieren jede Bezeichnung in der Ziel‑Collection. Sie können weitere Validierungen hinzufügen, um sicherzustellen, dass jede Legacy‑Bezeichnung noch in der aktuellen Purview‑Richtlinie existiert.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Migration kopiert die analysierten Bezeichner‑Objekte in die moderne Sammlung. Sie erfordert nicht das Löschen aller benutzerdefinierten Dokumenteneigenschaften, sodass unverwandte Dokumenten‑Metadaten erhalten bleiben. Verwenden Sie [IPresentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/), um die modernen Bezeichner‑Metadaten in eine PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltskennzeichnungstyps eine sichtbare Kopf‑, Fußzeile oder ein Wasserzeichen auf den Folien?**

Nein. Durch die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegebene Liste hinzugefügte Werte beschreiben die mit der Sensitivitätsbezeichnung verbundenen Kennzeichnungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, falls Ihr Workflow diese Kennzeichnungen rendern muss.

**Was ist der Unterschied zwischen dem Kennzeichnen einer Bezeichnung als entfernt und dem Löschen aus der Sammlung?**

Der Aufruf von [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` behält den Bezeichnungseintrag bei und protokolliert seinen Entfernungsstatus. Der Aufruf von [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) entfernt den Eintrag aus der modernen Sammlung. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätsbezeichnungen enthalten?**

Ja. Legacy‑Bezeichnungen können in benutzerdefinierten Dokumenteneigenschaften verbleiben, während moderne Bezeichnungen über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) verfügbar sind. Verwenden Sie [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--), um die Legacy‑Metadaten zu lesen und nur die gültigen Bezeichnungen zu migrieren, die nicht bereits in der modernen Sammlung vorhanden sind.

**Was passiert, wenn dieselbe Bezeichner‑ID mehrmals hinzugefügt wird?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) löst eine Ausnahme aus, wenn die Sammlung bereits eine Bezeichnung mit derselben ID enthält. Prüfen Sie die vorhandenen Werte, die von [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getId--) zurückgegeben werden, bevor Sie Bezeichnungen hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätsbezeichnungen zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.