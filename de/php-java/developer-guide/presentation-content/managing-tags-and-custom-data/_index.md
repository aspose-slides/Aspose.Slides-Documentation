---
title: Tags und benutzerdefinierte Daten in Präsentationen mit PHP verwalten
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/php-java/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- benutzerdefiniertes XML
- benutzerdefinierter XML-Teil
- XML-Metadaten
- ItemId
- Tag hinzufügen
- Schlüssel-Wert-Paare
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für PHP via Java verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile.
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑Zeichenketten, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads speichern können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Form‑Ebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokument‑Management‑Kennungen, Workflow‑Status, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten in einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Dateien mit der Erweiterung `.pptx` – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und Beziehungen, die zum Speichern von Präsentationsinhalt und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, die gemäß ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten können als Tags ([TagCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/)) oder benutzerdefinierte XML‑Teile ([CustomXmlPartCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpartcollection/)) gespeichert werden. Beide sind über die Klasse [`CustomData`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customdata/) verfügbar.

{{% alert color="primary" %}}
Tags speichern einfache Zeichenketten‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.
{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Methode [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customdata/#getCustomXmlParts) gibt die Sammlung benutzerdefinierter XML‑Teile zurück, die einem bestimmten Präsentationsobjekt zugeordnet sind. Beispiele:

- `$presentation->getCustomData()->getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die der Präsentation selbst zugeordnet sind.
- `$slide->getCustomData()->getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Folie zugeordnet sind.
- `$shape->getCustomData()->getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Form zugeordnet sind.

Verwenden Sie [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getAllCustomXmlParts), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen möchten, unabhängig davon, wo sie zugeordnet sind.

### **Einen benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpartcollection/#add), um XML‑Daten zu einer benutzerdefinierten XML‑Teilsammlung hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur präsentations‑weiten benutzerdefinierten Datensammlung hinzu:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add weist automatisch einen Bezeichner zu. Setzen Sie eine bestimmte UUID nur bei Bedarf.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Methode `add` kann auch XML als Byte‑Array oder Eingabestream entgegennehmen, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Einen benutzerdefinierten XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können einer bestimmten Folie oder Form zugeordnet werden, anstatt der gesamten Präsentation. Dies ist sinnvoll, wenn Metadaten nur ein Objekt beschreiben, etwa einen Vorlagenschlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einen benutzerdefinierten XML‑Teil zu einer Folie und einen weiteren zu einer Form hinzu:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `getCustomData()->getCustomXmlParts()`‑Sammlung die Beziehung zu diesem Teil enthält. Präsentations‑weite Daten eignen sich für dokumentweite Metadaten, Folien‑weite Daten für Informationen, die zu einer bestimmten Folie gehören, und Form‑weite Daten für Metadaten, die an eine einzelne Form gebunden sind.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getAllCustomXmlParts), um alle benutzerdefinierten XML‑Teile einer Präsentation abzurufen. Jeder [`CustomXmlPart`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/) stellt seine Kennung, den XML‑Inhalt und zugehörige Namespace‑Schemas bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und ihre Namespace‑Schemas auf:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) gibt die XML‑Schemas zurück, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen nützlich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#getXmlAsString) und [`setXmlAsString()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#setXmlAsString), um mit XML als UTF‑8‑Zeichenkette zu arbeiten, oder [`getXmlData()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#getXmlData) und [`setXmlData()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#setXmlData), um mit den rohen XML‑Bytes zu arbeiten.

Die Methode [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#getItemId) gibt die UUID zurück, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Verwenden Sie [`setItemId()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#setItemId), wenn eine Integration eine neue Kennung erfordert.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Lese das aktuelle XML als Text.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Aktualisiere das XML als UTF-8-Zeichenkette.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData liefert denselben XML-Inhalt als Rohbytes.
    $customXmlData = $customXmlPart->getXmlData();

    // Ersetze die Kennung, wenn sie von der Integration benötigt wird.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Beim Aufruf von `setXmlAsString` oder `setXmlData` muss gültiges, nicht‑leeres XML übergeben werden. Verwenden Sie die eine oder die andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Zeichenketten oder Byte‑Daten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpart/#remove) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpartcollection/#remove) entfernt einen bestimmten Teil aus einer benutzerdefinierten XML‑Teilsammlung.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpartcollection/#removeAt) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/de/php-java/aspose.slides/customxmlpartcollection/#clear) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen präsentations‑weiten benutzerdefinierten XML‑Teil per Referenz:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Falls Sie bereits ein `CustomXmlPart` besitzen und diesen Teil aus der Präsentation entfernen möchten, anstatt eine bestimmte Sammlung anzusprechen, rufen Sie `$customXmlPart->remove()` auf.

Sie können ein Element auch nach Index entfernen:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Alle benutzerdefinierten XML‑Teile einer Sammlung leeren**

Verwenden Sie `clear`, wenn alle benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind, entfernt werden sollen.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` wirkt nur auf die ausgewählte Sammlung. Beispielsweise löscht das Leeren einer Folien‑Sammlung nicht die präsentations‑weiten oder form‑weiten Sammlungen.

Um jeden benutzerdefinierten XML‑Teil in der Präsentation zu entfernen, iterieren Sie über `getAllCustomXmlParts()` und entfernen jeden Teil:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Verknüpfte oder gemeinsam genutzte benutzerdefinierte XML‑Teile behandeln**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine bestehende Datei Beziehungen von mehreren Folien oder Formen zum selben zugrunde liegenden XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Referenzen behandelt werden:

- Das Aktualisieren mit `setXmlAsString`, `setXmlData` oder `setItemId` ändert den zugrunde liegenden XML‑Teil, sodass die Änderung überall dort wirksam ist, wo der Teil referenziert wird.
- `getItemId()` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil während der Prüfung von objekt‑level‑Sammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten `getCustomXmlParts()`‑Sammlung entfernt ihn nur aus dieser Sammlung. Verwenden Sie `CustomXmlPart::remove()`, wenn der Teil selbst aus der Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten die objekt‑level‑Sammlungen geprüft werden, um festzustellen, ob andere Folien oder Formen ihn noch referenzieren.

Die `add`‑Überladungen erzeugen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bestehenden `CustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen am häufigsten beim Laden von Präsentationen auf, die bereits solche Referenzen enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Form‑Sammlungen nach `ItemId` und meldet Teile, die von mehr als einem Ort referenziert werden:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Eine solche Prüfung ist nützlich, bevor benutzerdefinierte XML‑Daten in Präsentationen, die von externen Systemen erstellt wurden, geändert oder gelöscht werden, weil derselbe Metadaten‑Teil an mehreren Beziehungen beteiligt sein kann.

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Methode `DocumentProperties::getKeywords()`. Dieser Beispielcode zeigt, wie man mit Aspose.Slides für PHP via Java den Tag‑Wert eines [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) abruft:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, zum Beispiel `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, zum Beispiel `My Tag Value`.

Wenn Sie Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispielsweise können Sie für nordamerikanische Länder einen Tag „NorthAmerican“ erstellen und das jeweilige Land als Wert zuweisen.

Dieser Beispielcode zeigt, wie man mit Aspose.Slides für PHP via Java einen Tag zu einer [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) hinzufügt:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/) gesetzt werden:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Einschränkungen**

Tags, die über die Sammlung `getCustomData()->getTags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Deshalb kann ein als Tag zugewiesener benutzerdefinierter Identifier nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Identifier im **Alt‑Text** des Objekts speichern (z. B. `$shape->setAlternativeText("MyId")`). Nach dem Export nach PDF kann der Alt‑Text im PDF‑Tag‑Baum erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/) unterstützt die Operation [clear](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/#clear), die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich einen einzelnen Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie [remove(name)](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/#remove) auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/), um den Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die komplette Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/#getNamesOfTags) auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/php-java/aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.

**Wie finde ich alle benutzerdefinierten XML‑Teile, ungeachtet ihres Speicherorts?**

Verwenden Sie [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getAllCustomXmlParts), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Soll ich `getXmlAsString`/`setXmlAsString` oder `getXmlData`/`setXmlData` zum Aktualisieren eines benutzerdefinierten XML‑Teils verwenden?**

Verwenden Sie `getXmlAsString` und `setXmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `getXmlData` und `setXmlData`, wenn das XML bereits als Byte‑Array vorliegt oder eine binär‑orientierte Verarbeitung praktischer ist. Beide Darstellungen beziehen sich auf denselben XML‑Inhalt des benutzerdefinierten XML‑Teils.