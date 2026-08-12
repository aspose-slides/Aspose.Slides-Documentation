---
title: Sensitivitätsbezeichnungen in PowerPoint‑Präsentationen in PHP verwalten
linktitle: Sensitivitätsbezeichnungen
type: docs
weight: 50
url: /de/php-java/sensitivity-labels/
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
- PHP
- Aspose.Slides
description: "Lesen, hinzufügen, aktualisieren, entfernen und migrieren von Microsoft Purview Sensitivitätsbezeichnungen in PowerPoint‑PPTX‑Präsentationen in PHP."
---
## **Übersicht**

Microsoft Purview Sensitivitätsbezeichnungen helfen Organisationen, Dokumente zu klassifizieren und zu verwalten. Während der automatisierten Präsentationsverarbeitung kann eine Anwendung möglicherweise ein vorhandenes Label beibehalten, ein von einer Richtlinie ausgewähltes Label anwenden, dessen Zustand aktualisieren oder Metadaten eines Labels migrieren, die von einem älteren Microsoft Information Protection (MIP)-Workflow geschrieben wurden.

Aspose.Slides für PHP via Java stellt moderne Sensitivitätslabel‑Metadaten über [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSensitivityLabels) bereit. Diese Methode gibt eine [SensitivityLabelCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/) zurück, die vor dem Speichern der Präsentation als PPTX eingesehen und geändert werden kann.

{{% alert color="primary" title="Note" %}}

Sensitivitätslabel‑Kennungen und Richtlinieninformationen werden durch Ihre Microsoft Purview‑Konfiguration definiert. Validieren Sie die Verfügbarkeit von Labels und Richtlinienanforderungen in Ihrer Umgebung, bevor Sie Metadaten hinzufügen oder migrieren. Die Werte von [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschreiben die Inhaltsmarkierungen, die einem Label zugeordnet sind; sie fügen von sich aus keinen sichtbaren Text oder Formen zu Folien hinzu.

{{% /alert %}}

## **Verstehen der Eigenschaften von Sensitivitätsbezeichnungen**

Jede [SensitivityLabel](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/) enthält die folgenden Metadaten:

| Methoden | Zweck |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getId) und [SensitivityLabel::setId](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#setId) | Ruft die Kennung des Sensitivitätslabels in der Purview‑Richtlinie ab oder legt sie fest. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getSiteId) und [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Ruft die mit der Label‑Richtlinie verbundene Site ab oder legt sie fest. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#isEnabled) und [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Gibt an, ob das Label aktiviert ist, bzw. legt es fest. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#isRemoved) und [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Gibt an, ob das Label entfernt wurde, bzw. legt es fest. Setzen Sie den Wert auf `true`, wenn der Entfernungszustand in den Metadaten beibehalten werden muss. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) und [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Gibt an, ob das Label automatisch oder durch eine Benutzerentscheidung angewendet wurde, bzw. legt es fest. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Ruft die mit dem Label verbundenen Inhaltsmarkierungstypen ab. |

Die Klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelassignmenttype/) definiert, wie ein Label zugewiesen wurde:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelassignmenttype/) stellt ein standardmäßiges oder automatisch angewendetes Label dar.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelassignmenttype/) stellt ein Label dar, das durch eine Benutzerentscheidung angewendet wurde, einschließlich manuell angewandter, empfohlener und verpflichtender Labels.

Die Klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcontenttype/) definiert die mit einem Label verbundene Markierung:

| Wert | Bedeutung |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcontenttype/) | Das Label wurde standardmäßig oder automatisch angewendet. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcontenttype/) | Header‑Inhaltsmarkierung ist mit dem Label verknüpft. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcontenttype/) | Footer‑Inhaltsmarkierung ist mit dem Label verknüpft. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcontenttype/) | Wasserzeichen‑Inhaltsmarkierung ist mit dem Label verknüpft. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcontenttype/) | Verschlüsselungsschutz ist mit dem Label verknüpft. |

Mehrere Markierungstypen können einem Label zugeordnet werden.

## **Vorhandene Sensitivitätsbezeichnungen auflisten**

Lesen Sie die moderne Label‑Collection über [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSensitivityLabels) und enumerieren Sie sie. Das folgende Beispiel listet jede Eigenschaft und Inhaltsmarkierung auf, die für jedes Label gespeichert ist:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Eine Sensitivitätsbezeichnung mit Inhaltsmarkierung hinzufügen**

Verwenden Sie [SensitivityLabelCollection::add](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/#add) mit der Label‑Kennung, Site‑Kennung, dem Aktivierungszustand und der Zuweisungsmethode. Nachdem die Methode das neue [SensitivityLabel](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/) zurückgibt, fügen Sie die erforderlichen Markierungswerte über die Liste zurückgegeben von [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) hinzu.

Das folgende Beispiel fügt ein manuell ausgewähltes Label mit Footer‑ und Wasserzeichen‑Markierungen hinzu und speichert das Ergebnis anschließend als PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eine Sensitivitätsbezeichnung aktualisieren**

Die Werte des [SensitivityLabel](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/) sind les‑ und schreibbar, außer dass die über [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegebene Liste über deren List‑Operationen geändert wird. Nachdem Sie das gewünschte Label gefunden haben, können Sie Kennung, Site‑Kennung, Aktivierungszustand, Zuweisungsmethode, Entfernungszustand und Inhaltsmarkierungstypen aktualisieren. Speichern Sie die Präsentation, um die Änderungen zu übernehmen.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Eine Sensitivitätsbezeichnung als entfernt markieren**

Um den Umstand zu erhalten, dass ein Label entfernt wurde, finden Sie das Label und rufen Sie [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#setRemoved) mit `true` auf. Dadurch bleibt der Label‑Eintrag erhalten und sein Entfernungszustand wird protokolliert. Wenn Sie stattdessen einen Eintrag aus der modernen Collection löschen müssen, verwenden Sie [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); mit [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/#clear) löschen Sie sämtliche Einträge.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Legacy‑MIP‑Sensitivitätsbezeichnungen lesen und migrieren**

Ältere, auf MIP basierende Workflows können Sensitivitätslabel‑Metadaten in benutzerdefinierten Dokumenteigenschaften statt in der modernen Label‑Collection speichern. Lesen Sie diese Metadaten mit [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Die Methode analysiert die Legacy‑Eigenschaften und gibt ein Java‑Array von [SensitivityLabel](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/)‑Objekten zurück.

Um die Metadaten zu migrieren, fügen Sie jedes zurückgegebene Label über [SensitivityLabelCollection::add](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/#add) zur modernen [SensitivityLabelCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/) hinzu. Da das Hinzufügen einer doppelten Label‑Kennung eine Ausnahme auslöst, prüft das Beispiel die Ziel‑Collection, bevor jedes Label kopiert wird. Sie können zusätzliche Validierungen einbauen, um zu bestätigen, dass jedes Legacy‑Label noch in der aktuellen Purview‑Richtlinie existiert.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Migration kopiert die geparsten Label‑Objekte in die moderne Collection. Es ist kein Leeren aller benutzerdefinierten Dokumenteigenschaften erforderlich, sodass nicht zugehörige Dokumentmetadaten unverändert bleiben. Verwenden Sie [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/), um die modernen Label‑Metadaten in einer PPTX‑Datei zu schreiben.

## **FAQ**

**Erzeugt das Hinzufügen eines Inhaltsmarkierungstyps eine sichtbare Kopfzeile, Fußzeile oder ein Wasserzeichen auf Folien?**

Nein. Werte, die über die Liste, die von [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) zurückgegeben wird, hinzugefügt werden, beschreiben die Markierungen, die dem Sensitivitätslabel zugeordnet sind. Sie erzeugen keinen sichtbaren Text oder Formen in der Präsentation. Fügen Sie den entsprechenden Folieninhalt separat hinzu, falls Ihr Workflow diese Markierungen rendern muss.

**Was ist der Unterschied zwischen dem Markieren eines Labels als entfernt und dem Löschen aus der Collection?**

Der Aufruf von [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#setRemoved) mit `true` bewahrt den Label‑Eintrag und protokolliert dessen Entfernungszustand. Der Aufruf von [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) löscht den Eintrag aus der modernen Collection. Wählen Sie die Operation, die den Aufbewahrungsanforderungen Ihrer Organisation entspricht.

**Kann eine Präsentation sowohl Legacy‑MIP‑Metadaten als auch moderne Sensitivitätslabels enthalten?**

Ja. Legacy‑Labels können in benutzerdefinierten Dokumenteigenschaften verbleiben, während moderne Labels über [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getSensitivityLabels) verfügbar sind. Verwenden Sie [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/de/php-java/aspose.slides/documentproperties/#getSensitivityLabels), um die Legacy‑Metadaten zu lesen und nur die gültigen Labels zu migrieren, die nicht bereits in der modernen Collection vorhanden sind.

**Was passiert, wenn ein Label mit derselben Kennung mehrmals hinzugefügt wird?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabelcollection/#add) löst eine Ausnahme aus, wenn die Collection bereits ein Label mit derselben Kennung enthält. Prüfen Sie die vorhandenen Werte, die von [SensitivityLabel::getId](https://reference.aspose.com/slides/de/php-java/aspose.slides/sensitivitylabel/#getId) zurückgegeben werden, bevor Sie Labels hinzufügen oder migrieren.

**Welches Ausgabeformat sollte verwendet werden, um aktualisierte Sensitivitätslabels zu erhalten?**

Speichern Sie die Präsentation als PPTX, indem Sie [Presentation::save](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#save) mit [SaveFormat::Pptx](https://reference.aspose.com/slides/de/php-java/aspose.slides/saveformat/) aufrufen, wie in den obigen Beispielen gezeigt.