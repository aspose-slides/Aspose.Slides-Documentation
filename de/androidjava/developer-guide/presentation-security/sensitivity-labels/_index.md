---
title: Sensitivitätsbezeichnungen in PowerPoint-Präsentationen unter Android verwalten
linktitle: Sensitivitätsbezeichnungen
type: docs
weight: 50
url: /de/androidjava/sensitivity-labels/
keywords:
- Sensitivitätsbezeichnung
- Microsoft Purview
- Microsoft Information Protection
- MIP-Metadaten
- Inhaltsmarkierung
- Informationsschutz
- Dokumentenverwaltung
- PowerPoint
- PPTX
- Präsentationssicherheit
- Android
- Java
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren Sie Microsoft Purview-Sensitivitätsbezeichnungen in PowerPoint-PPTX-Präsentationen mit Aspose.Slides für Android via Java."
---
## **Übersicht**

Microsoft Purview‑Sensitivitätsbezeichnungen helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatischen Präsentationsverarbeitung kann eine Anwendung eine vorhandene Bezeichnung beibehalten, eine durch eine Richtlinie ausgewählte Bezeichnung anwenden, ihren Zustand aktualisieren oder Metadaten einer älteren Microsoft Information Protection‑(MIP‑)Workflow‑Bezeichnung migrieren.

Aspose.Slides für Android via Java stellt moderne Metadaten für Sensitivitätsbezeichnungen über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) bereit. Diese Methode gibt eine [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX eingesehen und geändert werden kann.

{{% alert color="primary" title="Note" %}}
Sensitivitätsbezeichner‑ und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Überprüfen Sie in Ihrer Umgebung die Verfügbarkeit von Bezeichnungen und die Richtlinienanforderungen, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschreiben die mit einer Bezeichnung verknüpften Inhaltsmarkierungen; sie erzeugen nicht automatisch sichtbaren Text oder Formen auf Folien.
{{% /alert %}}

## **Eigenschaften von Sensitivitätsbezeichnungen verstehen**

Jede [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/) enthält die folgenden Metadaten:

| Methoden | Zweck |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getId--) und [ISensitivityLabel.setId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Abrufen oder Festlegen der Kennung der Sensitivitätsbezeichnung in der Purview‑Richtlinie. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) und [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Abrufen oder Festlegen der Site, die mit der Bezeichnungsrichtlinie verknüpft ist. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) und [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Abrufen oder Festlegen, ob die Bezeichnung aktiviert ist. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) und [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Abrufen oder Festlegen, ob die Bezeichnung entfernt wurde. Setzen Sie den Wert auf `true`, wenn der Entfernungsstatus in den Metadaten beibehalten werden muss. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) und [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Abrufen oder Festlegen, ob die Bezeichnung automatisch oder durch eine Benutzerentscheidung angewendet wurde. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Abrufen der mit der Bezeichnung verknüpften Inhalt‑Markierungstypen. |

Die Klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) definiert, wie eine Bezeichnung zugewiesen wurde:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) repräsentiert eine Standard‑ oder automatisch angewendete Bezeichnung.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) repräsentiert eine durch eine Benutzerentscheidung angewendete Bezeichnung, einschließlich manuell angewendeter, empfohlener und obligatorischer Bezeichnungen.

Die Klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) definiert die mit einer Bezeichnung verbundene Markierung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Die Bezeichnung wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Header‑Inhaltsmarkierung ist mit der Bezeichnung verknüpft. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Footer‑Inhaltsmarkierung ist mit der Bezeichnung verknüpft. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Wasserzeichen‑Inhaltsmarkierung ist mit der Bezeichnung verknüpft. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Verschlüsselungsschutz ist mit der Bezeichnung verknüpft. |

Mehrere Markierungstypen können einer Bezeichnung zugeordnet werden.

## **Vorhandene Sensitivitätsbezeichnungen auflisten**

Lesen Sie die moderne Bezeichnungs‑Collection über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und jede Inhaltsmarkierung auf, die für jede Bezeichnung gespeichert ist:

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

## **Eine Sensitivitätsbezeichnung mit Inhaltsmarkierung hinzufügen**

Verwenden Sie [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) mit Bezeichner‑ID, Site‑ID, aktiviert‑Zustand und Zuweisungsmethode. Nachdem die Methode das neue [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/) zurückgegeben hat, fügen Sie die erforderlichen Markierungswerte über die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegebene Liste hinzu.

Das folgende Beispiel fügt eine manuell ausgewählte Bezeichnung hinzu, die mit Footer‑ und Wasserzeichen‑Markierungen verknüpft ist, und speichert das Ergebnis anschließend als PPTX:

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

Die Werte des [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/) sind les‑ und schreibbar, wobei die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegebene Liste über ihre Listen‑Operationen geändert wird. Nachdem Sie die gewünschte Bezeichnung gefunden haben, können Sie Kennung, Site‑ID, Aktivierungszustand, Zuweisungsmethode, Entfernungsstatus und Inhaltsmarkierungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

Das folgende Beispiel aktualisiert den Aktivierungszustand und die Zuweisungsmethode der ersten Bezeichnung:

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

## **Eine Sensitivitätsbezeichnung als entfernt markieren**

Um festzuhalten, dass eine Bezeichnung entfernt wurde, finden Sie die Bezeichnung und rufen Sie [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` auf. Dadurch bleibt der Eintrag erhalten und sein Entfernungsstatus wird gespeichert. Wenn Sie stattdessen einen Eintrag aus der modernen Collection löschen müssen, verwenden Sie [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); mit [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) können Sie alle Einträge löschen.

Das folgende Beispiel markiert eine bestimmte Bezeichnung als entfernt und speichert die aktualisierte Präsentation:

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

Ältere, MIP‑basierte Workflows können Metadaten von Sensitivitätsbezeichnungen in benutzerdefinierten Dokumenteneigenschaften statt in der modernen Bezeichnungs‑Collection speichern. Lesen Sie diese Metadaten mit [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Die Methode analysiert die Legacy‑Eigenschaften und liefert ein Array von [ISensitivityLabel](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/)-Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jede zurückgegebene Bezeichnung über [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-) zur modernen [ISensitivityLabelCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/) hinzu. Da das Hinzufügen einer doppelten Bezeichner‑ID eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Collection, bevor jede Bezeichnung kopiert wird. Optional können Sie zusätzliche Validierungen einbauen, um sicherzustellen, dass jede Legacy‑Bezeichnung noch in der aktuellen Purview‑Richtlinie existiert.

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

Die Migration kopiert die analysierten Bezeichnungs‑Objekte in die moderne Collection. Es ist nicht nötig, alle benutzerdefinierten Dokumenteneigenschaften zu leeren, sodass unverknüpfte Dokumenten‑Metadaten erhalten bleiben. Verwenden Sie [IPresentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/), um die modernen Bezeichnungs‑Metadaten in eine PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltsmarkierungstyps einen sichtbaren Header, Footer oder ein Wasserzeichen auf den Folien?**

Nein. Die über die von [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) zurückgegebene Liste hinzugefügten Werte beschreiben die mit der Sensitivitätsbezeichnung verknüpften Markierungen. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, wenn Ihr Workflow diese Markierungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren einer Bezeichnung als entfernt und dem Löschen aus der Collection?**

Der Aufruf von [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) mit `true` bewahrt den Bezeichnungseintrag und protokolliert dessen Entfernungsstatus. Der Aufruf von [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) entfernt den Eintrag aus der modernen Collection. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätsbezeichnungen enthalten?**

Ja. Legacy‑Bezeichnungen können in benutzerdefinierten Dokumenteneigenschaften verbleiben, während moderne Bezeichnungen über [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) verfügbar sind. Verwenden Sie [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) zum Auslesen der Legacy‑Metadaten und migrieren Sie nur die gültigen Bezeichnungen, die noch nicht in der modernen Collection vorhanden sind.

**Was passiert, wenn dieselbe Bezeichner‑ID mehrmals hinzugefügt wird?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) wirft eine Ausnahme, wenn die Collection bereits eine Bezeichnung mit derselben Kennung enthält. Prüfen Sie die vorhandenen Werte, die von [ISensitivityLabel.getId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isensitivitylabel/#getId--) zurückgegeben werden, bevor Sie Bezeichnungen hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätsbezeichnungen zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [IPresentation.save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) mit [SaveFormat.Pptx](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.