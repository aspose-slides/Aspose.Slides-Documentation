---
title: Verwalten von Sensitivitätskennzeichnungen in PowerPoint-Präsentationen auf Android
linktitle: Sensitivitätskennzeichnungen
type: docs
weight: 50
url: /de/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Lesen, Hinzufügen, Aktualisieren, Entfernen und Migrieren von Microsoft Purview Sensitivitätskennzeichnungen in PowerPoint PPTX-Präsentationen mit Aspose.Slides für Android über Java."
---
## **Überblick**

Microsoft Purview Sensitivitätskennzeichnungen helfen Organisationen dabei, Dokumente zu klassifizieren und zu verwalten. Bei der automatisierten Verarbeitung von Präsentationen muss eine Anwendung möglicherweise eine vorhandene Kennzeichnung beibehalten, eine von einer Richtlinie ausgewählte Kennzeichnung anwenden, ihren Zustand aktualisieren oder Kennzeichnungs‑Metadaten migrieren, die von einem älteren Microsoft Information Protection (MIP)‑Workflow geschrieben wurden.

Aspose.Slides for Android via Java stellt moderne Sensitivitätskennzeichnungs‑Metadaten über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) bereit. Diese Methode gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX inspiziert und geändert werden kann.

{{% alert color="info" title="Hinweis" %}}
Sensitivitätskennzeichnungs‑IDs und Richtlinformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Validieren Sie die Verfügbarkeit von Kennzeichnungen und die Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschreiben die mit einer Kennzeichnung verbundenen Inhaltskennzeichnungen; sie erzeugen nicht von selbst sichtbaren Text oder Formen in Folien.
{{% /alert %}}

## **Sensitivitätskennzeichnungseigenschaften verstehen**

Jede [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Methoden | Zweck |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getId--) und [ISensitivityLabel.setId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Abrufen oder Festlegen der Kennzeichnungs‑ID in der Purview‑Richtlinie. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) und [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Abrufen oder Festlegen der Site‑ID, die mit der Kennzeichnungs‑Richtlinie verknüpft ist. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) und [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Abrufen oder Festlegen, ob die Kennzeichnung aktiviert ist. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) und [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Abrufen oder Festlegen, ob die Kennzeichnung entfernt wurde. Setzen Sie den Wert auf `true`, wenn der Entfernungs‑Zustand in den Metadaten beibehalten werden muss. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) und [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Abrufen oder Festlegen, ob die Kennzeichnung automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Abrufen der mit der Kennzeichnung verknüpften Inhaltsskennungs‑Typen. |

Die Klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) definiert, wie eine Kennzeichnung zugewiesen wurde:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) repräsentiert eine Standard‑ oder automatisch angewendete Kennzeichnung.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) repräsentiert eine Kennzeichnung, die durch eine Benutzerentscheidung angewendet wurde, einschließlich manuell angewendeter, empfohlener und verpflichtender Kennzeichnungen.

Die Klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) definiert die Kennzeichnung, die einer Kennzeichnung zugeordnet ist:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Die Kennzeichnung wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Header‑Inhaltskennzeichnung ist mit der Kennzeichnung verknüpft. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Footer‑Inhaltskennzeichnung ist mit der Kennzeichnung verknüpft. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Wasserzeichen‑Inhaltskennzeichnung ist mit der Kennzeichnung verknüpft. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Verschlüsselungsschutz ist mit der Kennzeichnung verknüpft. |

Mehrere Kennzeichnungstypen können einer Kennzeichnung zugeordnet werden.

## **Vorhandene Sensitivitätskennzeichnungen auflisten**

Lesen Sie die moderne Kennzeichnungssammlung über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltskennzeichnung auf, die für jede Kennzeichnung gespeichert sind:

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

## **Eine Sensitivitätskennzeichnung mit Inhaltskennzeichnung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) mit Kennzeichnungs‑ID, Site‑ID, aktivem Zustand und Zuweisungsmethode. Nachdem die Methode die neue [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Kennzeichnungswerte über die Liste hinzu, die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegeben wird.

Das folgende Beispiel fügt eine manuell ausgewählte Kennzeichnung hinzu, die mit Footer‑ und Wasserzeichen‑Kennzeichnungen verknüpft ist, und speichert das Ergebnis anschließend als PPTX:

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

## **Eine Sensitivitätskennzeichnung aktualisieren**

Die Werte der [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/) sind les‑ und schreibbar, außer die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegebene Liste wird über ihre List‑Operationen modifiziert. Nachdem Sie die gewünschte Kennzeichnung gefunden haben, können Sie deren Kennzeichnungs‑ID, Site‑ID, aktiv‑Zustand, Zuweisungsmethode, Entfernungs‑Zustand und Inhaltskennzeichnungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den aktiv‑Zustand und die Zuweisungsmethode der ersten Kennzeichnung:

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

## **Eine Sensitivitätskennzeichnung als entfernt markieren**

Um festzuhalten, dass eine Kennzeichnung entfernt wurde, finden Sie die Kennzeichnung und rufen Sie [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` auf. Dadurch bleibt der Kennzeichnungseintrag erhalten, während ihr Entfernungs‑Zustand verzeichnet wird. Wenn Sie stattdessen einen Eintrag aus der modernen Sammlung löschen möchten, verwenden Sie [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); verwenden Sie [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) zum Löschen aller Einträge.

Das folgende Beispiel markiert eine bestimmte Kennzeichnung als entfernt und speichert die aktualisierte Präsentation:

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

## **Legacy‑MIP‑Sensitivitätskennzeichnungen lesen und migrieren**

Ältere MIP‑basierte Workflows können Sensitivitätskennzeichnungs‑Metadaten in benutzerdefinierten Dokumenteigenschaften anstelle der modernen Kennzeichnungssammlung speichern. Lesen Sie diese Metadaten mit [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Die Methode analysiert die Legacy‑Eigenschaften und gibt ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/)‑Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jede zurückgegebene Kennzeichnung über [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) zur modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/) hinzu. Da das Hinzufügen einer doppelten Kennzeichnungs‑ID eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Sammlung, bevor jede Kennzeichnung kopiert wird. Sie können zusätzliche Validierungen einbauen, um sicherzustellen, dass jede Legacy‑Kennzeichnung noch in der aktuellen Purview‑Richtlinie existiert.

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

Die Migration kopiert die analysierten Kennzeichnungsobjekte in die moderne Sammlung. Es ist nicht erforderlich, alle benutzerdefinierten Dokumenteigenschaften zu leeren, sodass nicht‑relevante Dokumentmetadaten erhalten bleiben. Verwenden Sie [IPresentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/) zum Schreiben der modernen Kennzeichnungs‑Metadaten in eine PPTX‑Datei.

## **FAQ**

**Erstellt das Hinzufügen eines Inhaltskennzeichnungstyps eine sichtbare Kopfzeile, Fußzeile oder ein Wasserzeichen in den Folien?**

Nein. Durch die Liste, die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegeben wird, hinzugefügte Werte beschreiben die Kennzeichnungen, die mit der Sensitivitätskennzeichnung verbunden sind. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat ein, falls Ihr Workflow diese Kennzeichnungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren einer Kennzeichnung als entfernt und dem Löschen aus der Sammlung?**

Der Aufruf von [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` bewahrt den Kennzeichnungseintrag und verzeichnet den Entfernungs‑Zustand. Der Aufruf von [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) löscht den Eintrag aus der modernen Sammlung. Wählen Sie die Vorgehensweise, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätskennzeichnungen enthalten?**

Ja. Legacy‑Kennzeichnungen können in benutzerdefinierten Dokumenteigenschaften verbleiben, während moderne Kennzeichnungen über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) verfügbar sind. Verwenden Sie [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) zum Lesen der Legacy‑Metadaten und migrieren Sie nur die gültigen Kennzeichnungen, die noch nicht in der modernen Sammlung vorhanden sind.

**Was passiert, wenn dieselbe Kennzeichnungs‑ID mehrmals hinzugefügt wird?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) löst eine Ausnahme aus, wenn die Sammlung bereits eine Kennzeichnung mit derselben ID enthält. Prüfen Sie die vorhandenen Werte, die von [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getId--) zurückgegeben werden, bevor Sie Kennzeichnungen hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätskennzeichnungen zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.