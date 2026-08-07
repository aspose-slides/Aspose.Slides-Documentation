---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit JavaScript
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/nodejs-java/managing-tags-and-custom-data/
keywords:
- Dokumenteigenschaften
- Tag
- benutzerdefinierte Daten
- benutzerdefiniertes XML
- benutzerdefinierter XML-Teil
- XML-Metadaten
- ItemId
- Tag hinzufügen
- Paarwerte
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für Node.js via Java verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑Zeichenkettenpaare, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads speichern können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Form‑Ebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokument‑Management‑Kennungen, Workflow‑Status, Compliance‑Metadaten, Template‑Bindungsdaten oder andere strukturierte Anwendungsdaten in einer Präsentation speichern.

## **Speicherung von Daten in Präsentationsdateien**

PPTX‑Dateien – Dateien mit der Erweiterung `.pptx` – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und die Beziehungen, die zum Speichern von Präsentationsinhalten und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, die in ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten können als Tags ([TagCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/)) oder benutzerdefinierte XML‑Teile ([CustomXmlPartCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpartcollection/)) gespeichert werden. Beide sind über die Klasse [`CustomData`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customdata/) verfügbar.

{{% alert color="primary" %}}
Tags speichern einfache Zeichenketten‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.
{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Methode `getCustomXmlParts()` von [`CustomData`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customdata/) gibt die Sammlung benutzerdefinierter XML‑Teile zurück, die einem bestimmten Präsentationsobjekt zugeordnet sind. Beispiele:

- `presentation.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die der Präsentation selbst zugeordnet sind.
- `slide.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Folie zugeordnet sind.
- `shape.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Form zugeordnet sind.

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen möchten, unabhängig davon, wo sie zugeordnet sind.

### **Einen benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie die `add`‑Methode von [`CustomXmlPartCollection`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpartcollection/), um XML‑Daten zu einer Sammlung benutzerdefinierter XML‑Teile hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur präsentationsbezogenen benutzerdefinierten Datensammlung hinzu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add weist automatisch einen Bezeichner zu. Setzen Sie eine bestimmte UUID nur bei Bedarf.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die `add`‑Methode kann auch XML als Byte‑Array akzeptieren, was nützlich ist, wenn XML‑Inhalte bereits in binärer Form vorliegen.

### **Einen benutzerdefinierten XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können einer bestimmten Folie oder Form zugeordnet werden, anstatt der gesamten Präsentation. Das ist nützlich, wenn Metadaten nur ein Objekt beschreiben, z. B. einen Template‑Schlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einen benutzerdefinierten XML‑Teil zu einer Folie und einen weiteren zu einer Form hinzu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `getCustomData().getCustomXmlParts()`‑Sammlung die Beziehung zu diesem Teil enthält. Präsentationsbezogene Daten eignen sich für dokumentweite Metadaten, Folienbezogene für Informationen, die zu einer bestimmten Folie gehören, und Form‑bezogene für Metadaten, die an einer einzelnen Form hängen.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/), um alle benutzerdefinierten XML‑Teile aus einer Präsentation abzurufen. Jeder [`CustomXmlPart`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpart/) stellt seine Kennung, den XML‑Inhalt und die zugehörigen Namespace‑Schemas bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und ihre Namespace‑Schemas auf:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

[`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpart/) liefert die XML‑Schemas, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen hilfreich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie `getXmlAsString()` und `setXmlAsString()` von [`CustomXmlPart`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpart/), um XML als UTF‑8‑Zeichenkette zu verarbeiten, oder `getXmlData()` und `setXmlData()`, um mit den rohen XML‑Bytes zu arbeiten.

Die Methode `getItemId()` gibt die UUID zurück, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Verwenden Sie `setItemId()`, wenn eine Integration eine neue Kennung benötigt.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Lese das aktuelle XML als Text.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // Aktualisiere das XML als UTF-8-String.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData liefert denselben XML-Inhalt als Rohbytes.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // Ersetze die Kennung, wenn die Integration sie benötigt.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Beim Aufruf von `setXmlAsString` oder `setXmlData` müssen gültige, nicht leere XML‑Daten übergeben werden. Verwenden Sie die eine oder die andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Zeichenketten oder Byte‑Daten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpart/) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpartcollection/) entfernt ein bestimmtes Teil aus einer Sammlung benutzerdefinierter XML‑Teile.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpartcollection/) entfernt das Teil an einem angegebenen Sammlungs‑Index.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/customxmlpartcollection/) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt ein präsentationsbezogenes benutzerdefiniertes XML‑Teil per Referenz:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Falls Sie bereits ein `CustomXmlPart` besitzen und dieses Teil aus der Präsentation entfernen wollen, anstatt eine bestimmte Sammlung anzusprechen, rufen Sie `customXmlPart.remove()` auf.

Sie können auch ein Element nach Index entfernen:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Alle benutzerdefinierten XML‑Teile einer Sammlung leeren**

Verwenden Sie `clear`, wenn alle benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind, entfernt werden sollen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` wirkt nur auf die ausgewählte Sammlung. Das Leeren der Sammlung einer Folie beispielsweise leert nicht die präsentations‑ oder formbezogenen Sammlungen.

Um jeden benutzerdefinierten XML‑Teil in der Präsentation zu entfernen, iterieren Sie über `getAllCustomXmlParts()` und entfernen jedes Teil:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Verknüpfte oder geteilte benutzerdefinierte XML‑Teile behandeln**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Formen zum gleichen zugrunde liegenden XML‑Teil enthalten.

Ein geteilter Teil sollte als ein Datenobjekt mit mehreren Referenzen behandelt werden:

- Das Aktualisieren mit `setXmlAsString`, `setXmlData` oder `setItemId` ändert den zugrunde liegenden XML‑Teil, sodass die Änderung überall wirksam wird, wo der Teil referenziert wird.
- `getItemId()` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil bei der Prüfung objektbezogener Sammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten `getCustomXmlParts()`‑Sammlung entfernt es nur aus dieser Sammlung. Verwenden Sie `CustomXmlPart.remove()`, wenn das Teil selbst aus der gesamten Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines geteilten Teils sollten die objektbezogenen Sammlungen geprüft werden, um festzustellen, ob andere Folien oder Formen noch darauf verweisen.

Die `add`‑Überladungen erzeugen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen vorhandenen `CustomXmlPart`. Daher begegnet man geteilten Beziehungen am häufigsten beim Laden von Präsentationen, die bereits solche Beziehungen enthalten.

Das folgende Beispiel prüft präsentations-, folien- und formbezogene Sammlungen nach `ItemId` und meldet Teile, die von mehr als einem Ort referenziert werden:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Diese Art von Prüfung ist vor dem Ändern oder Löschen benutzerdefinierter XML‑Daten in von externen Systemen erstellten Präsentationen nützlich, da derselbe Metadaten‑Teil an mehreren Beziehungen teilnehmen kann.

## **Tag‑Werte abrufen**

In Slides entspricht ein Tag der Methode `DocumentProperties.getKeywords()`. Der folgende Beispielcode zeigt, wie man einen Tag‑Wert mit Aspose.Slides für Node.js via Java für [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) abruft:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Wenn Sie Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispiel: Möchten Sie Präsentationen aus nordamerikanischen Ländern kategorisieren, können Sie einen nordamerikanischen Tag erstellen und das jeweilige Land als Wert zuweisen.

Der folgende Beispielcode zeigt, wie man einem [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) mit Aspose.Slides für Node.js via Java einen Tag hinzufügt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/) gesetzt werden:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Einschränkungen**

Tags, die über die Sammlung `getCustomData().getTags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Daher kann ein als Tag gespeicherter benutzerdefinierter Identifikator aus dem getaggten PDF nicht abgerufen werden.

**Umgehung**: Sie können einen benutzerdefinierten Identifikator im **Alt‑Text** des Objekts speichern (z. B. `shape.setAlternativeText("MyId")`). Nach dem Export nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/)-Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich einen einzelnen Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie `remove(name)` auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/), um den Tag über seinen Schlüssel zu löschen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie `getNamesOfTags()` auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Sollte ich `getXmlAsString`/`setXmlAsString` oder `getXmlData`/`setXmlData` zum Aktualisieren eines benutzerdefinierten XML‑Teils verwenden?**

Verwenden Sie `getXmlAsString` und `setXmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `getXmlData` und `setXmlData`, wenn das XML bereits als Byte‑Array vorliegt oder die Verarbeitung binärorientiert ist. Beide Darstellungen beziehen sich auf denselben XML‑Inhalt des benutzerdefinierten XML‑Teils.