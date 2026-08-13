---
title: Verwalten von Sensitivitäts‑Labels in PowerPoint‑Präsentationen in Java
linktitle: Sensitivitäts‑Labels
type: docs
weight: 50
url: /de/java/sensitivity-labels/
keywords:
- Sensitivitäts‑Label
- Microsoft Purview
- Microsoft Information Protection
- MIP‑Metadaten
- Inhaltskennzeichnung
- Informationsschutz
- Dokumentenverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- Java
- Aspose.Slides
description: "Lesen, Hinzufügen, Aktualisieren, Entfernen und Migrieren von Microsoft Purview Sensitivitäts‑Labels in PowerPoint‑PPTX‑Präsentationen mit Aspose.Slides für Java."
---
## **Übersicht**

Microsoft Purview Sensitivity‑Labels helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatisierten Verarbeitung von Präsentationen kann eine Anwendung ein vorhandenes Label beibehalten, ein von einer Richtlinie ausgewähltes Label anwenden, dessen Zustand aktualisieren oder Metadaten von Labels migrieren, die von einem älteren Microsoft Information Protection (MIP)‑Workflow geschrieben wurden.

Aspose.Slides stellt moderne Sensitivity‑Label‑Metadaten über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) bereit. Diese Methode gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/) zurück, die inspiziert und geändert werden kann, bevor die Präsentation als PPTX gespeichert wird.

{{% alert color="info" title="Hinweis" %}}
Sensitivitäts‑Label‑Kennungen und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Prüfen Sie die Verfügbarkeit von Labels und die Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschreiben die Inhaltskennzeichnungen, die einem Label zugeordnet sind; sie fügen nicht automatisch sichtbaren Text oder Formen zu Folien hinzu.
{{% /alert %}}

## **Eigenschaften von Sensitivitätslabels verstehen**

Jedes [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Methoden | Zweck |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getId--) und [ISensitivityLabel.setId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Abrufen oder Festlegen des Kennzeichners des Sensitivitätslabels in der Purview‑Richtlinie. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getSiteId--) und [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Abrufen oder Festlegen der Site, die mit der Label‑Richtlinie verknüpft ist. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#isEnabled--) und [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Abrufen oder Festlegen, ob das Label aktiviert ist. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#isRemoved--) und [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Abrufen oder Festlegen, ob das Label entfernt wurde. Setzen Sie den Wert auf `true`, wenn der Entfernungszustand in den Metadaten erhalten bleiben muss. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) und [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Abrufen oder Festlegen, ob das Label automatisch oder durch eine Benutzerauswahl angewendet wurde. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Abrufen der Inhaltskennzeichnungstypen, die dem Label zugeordnet sind. |

Die Klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelassignmenttype/) definiert, wie ein Label zugewiesen wurde:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelassignmenttype/) steht für ein Standard‑ oder automatisch angewendetes Label.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelassignmenttype/) steht für ein durch eine Benutzerauswahl angewendetes Label, einschließlich manuell angewandter, empfohlener und obligatorischer Labels.

Die Klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) definiert die Kennzeichnung, die einem Label zugeordnet ist:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Das Label wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Kopfzeilen‑Kennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Fußzeilen‑Kennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Wasserzeichen‑Kennzeichnung ist dem Label zugeordnet. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/de/java/com.aspose.slides/sensitivitylabelcontenttype/) | Eine Verschlüsselungs‑Schutz ist dem Label zugeordnet. |

Mehrere Kennzeichnungstypen können einem Label zugeordnet sein.

## **Vorhandene Sensitivitätslabels auflisten**

Lesen Sie die moderne Label‑Collection über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltskennzeichnung auf, die für jedes Label gespeichert ist:

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

## **Ein Sensitivitätslabel mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) mit dem Label‑Kennzeichen, Site‑Kennzeichen, dem Aktivierungszustand und der Zuweisungsmethode. Nachdem die Methode das neue [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Kennwert‑Typen über die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegebene Liste hinzu.

Das folgende Beispiel fügt ein manuell ausgewähltes Label hinzu, das mit Fußzeilen‑ und Wasserzeichen‑Kennzeichnungen verknüpft ist, und speichert das Ergebnis anschließend als PPTX:

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

## **Ein Sensitivitätslabel aktualisieren**

Die Werte des [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/) sind les‑ und schreibbar, außer dass die über [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) erhaltene Liste über ihre Listenoperationen modifiziert wird. Nachdem das gewünschte Label gefunden wurde, können Sie Kennzeichen‑ID, Site‑ID, Aktivierungszustand, Zuweisungsmethode, Entfernungsstatus und Inhaltskennzeichnungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den Aktivierungszustand und die Zuweisungsmethode des ersten Labels:

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

## **Ein Sensitivitätslabel als entfernt markieren**

Um zu erhalten, dass ein Label entfernt wurde, finden Sie das Label und rufen Sie [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` auf. Dadurch bleibt der Label‑Eintrag erhalten, während sein Entfernungsstatus vermerkt wird. Wenn Sie stattdessen einen Eintrag aus der modernen Collection löschen müssen, verwenden Sie [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); verwenden Sie [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#clear--) zum Löschen aller Einträge.

Das folgende Beispiel markiert ein bestimmtes Label als entfernt und speichert die aktualisierte Präsentation:

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

## **Legacy‑MIP‑Sensitivitätslabels lesen und migrieren**

Ältere MIP‑basierte Workflows können Sensitivitäts‑Label‑Metadaten in benutzerdefinierten Dokumenteneigenschaften anstatt in der modernen Label‑Collection speichern. Lesen Sie diese Metadaten mit [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Die Methode analysiert die Legacy‑Eigenschaften und gibt ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/)-Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Label über [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) zur modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/) hinzu. Da das Hinzufügen eines doppelten Label‑Kennzeichners eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Collection, bevor jedes Label kopiert wird. Sie können weitere Prüfungen hinzufügen, um sicherzustellen, dass jedes Legacy‑Label noch in der aktuellen Purview‑Richtlinie existiert.

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

Die Migration kopiert die analysierten Label‑Objekte in die moderne Collection. Es ist nicht erforderlich, alle benutzerdefinierten Dokumenteneigenschaften zu leeren, sodass unverwandte Dokument‑Metadaten erhalten bleiben. Verwenden Sie [IPresentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/), um die modernen Label‑Metadaten in einer PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltskennzeichnungstyps eine sichtbare Kopf‑, Fußzeile oder ein Wasserzeichen auf den Folien?**

Nein. Die über die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegebene Liste hinzugefügten Werte beschreiben die Kennzeichnungen, die dem Sensitivitätslabel zugeordnet sind. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, wenn Ihr Workflow diese Kennzeichnungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren eines Labels als entfernt und dem Löschen aus der Collection?**

Der Aufruf von [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` behält den Label‑Eintrag bei und vermerkt seinen Entfernungsstatus. Der Aufruf von [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) löscht den Eintrag aus der modernen Collection. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätslabels enthalten?**

Ja. Legacy‑Labels können in benutzerdefinierten Dokumenteneigenschaften verbleiben, während moderne Labels über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) zugänglich sind. Verwenden Sie [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) zum Lesen der Legacy‑Metadaten und migrieren Sie nur die gültigen Labels, die noch nicht in der modernen Collection vorhanden sind.

**Was passiert, wenn ein Label mit derselben Kennzeichnung mehrfach hinzugefügt wird?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) wirft eine Ausnahme, wenn die Collection bereits ein Label mit derselben Kennzeichnung enthält. Prüfen Sie die vorhandenen Werte, die von [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isensitivitylabel/#getId--) zurückgegeben werden, bevor Sie Labels hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätslabels beizubehalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.