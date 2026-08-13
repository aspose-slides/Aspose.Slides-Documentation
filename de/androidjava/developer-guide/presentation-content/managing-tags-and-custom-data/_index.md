---
title: "Verwalten von Tags und benutzerdefinierten Daten in Präsentationen unter Android"
linktitle: "Tags und benutzerdefinierte Daten"
type: docs
weight: 300
url: /de/androidjava/managing-tags-and-custom-data
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint‑Präsentationen mit Aspose.Slides für Android via Java verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑String‑Paare, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads speichern können.

Aspose.Slides bietet APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Form‑Ebene. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokumentverwaltungs‑IDs, Workflow‑Status, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten innerhalb einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Dateien mit der Endung `.pptx` – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und Beziehungen, die zum Speichern von Präsentationsinhalten und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, die in ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITagCollection)) oder benutzerdefinierte XML‑Teile ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection)) gespeichert werden. Beide sind über die [`ICustomData`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomData/)‑Schnittstelle verfügbar.

{{% alert color="info" %}}
Tags speichern einfache String‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können mit einer Präsentation, Folie oder Form verknüpft werden.
{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--)‑Methode gibt die Sammlung benutzerdefinierter XML‑Teile zurück, die mit einem bestimmten Präsentationsobjekt verknüpft sind. Zum Beispiel:

- `presentation.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit der Präsentation selbst verknüpft sind.
- `slide.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Folie verknüpft sind.
- `shape.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Form verknüpft sind.

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen möchten, unabhängig davon, wo sie verknüpft sind.

### **Ein benutzerdefiniertes XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) um XML‑Daten zu einer Sammlung benutzerdefinierter XML‑Teile hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur präsentationsweiten benutzerdefinierten Datensammlung hinzu:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add weist automatisch einen Bezeichner zu. Setzen Sie eine bestimmte UUID nur bei Bedarf.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die `add`‑Methode kann XML auch als Byte‑Array oder Eingabestream akzeptieren, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Ein benutzerdefiniertes XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können mit einer bestimmten Folie oder Form verknüpft werden, anstatt mit der gesamten Präsentation. Dies ist sinnvoll, wenn Metadaten nur ein einzelnes Objekt beschreiben, z. B. einen Vorlagen‑Schlüssel, eine externe Datensatz‑ID oder Bindungsinformationen.

Das folgende Beispiel fügt einer Folie ein benutzerdefiniertes XML‑Teil und einer Form ein weiteres hinzu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `getCustomData().getCustomXmlParts()`‑Sammlung die Beziehung zu diesem Teil enthält. Präsentationsweite Daten eignen sich für dokumentübergreifende Metadaten, Folien‑Daten für Informationen, die zu einer bestimmten Folie gehören, und Form‑Daten für Metadaten, die an einer einzelnen Form hängen.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) um alle benutzerdefinierten XML‑Teile aus einer Präsentation abzurufen. Jeder [`ICustomXmlPart`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart/) gibt seine Kennung, den XML‑Inhalt und die zugehörigen Namespace‑Schemas zurück.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und deren Namespace‑Schemas auf:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) liefert die XML‑Schemas, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen hilfreich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) und [`setXmlAsString()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) um mit XML als UTF‑8‑String zu arbeiten, oder [`getXmlData()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) und [`setXmlData()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) um mit den rohen XML‑Bytes zu arbeiten.

Die [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--)‑Methode gibt die UUID zurück, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Verwenden Sie [`setItemId()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) wenn eine Integration eine neue Kennung erfordert.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // Lese das aktuelle XML als Text.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // Aktualisiere das XML als UTF-8-Zeichenkette.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData liefert denselben XML-Inhalt als Rohbytes.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Ersetze die Kennung, wenn die Integration dies erfordert.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Beim Aufruf von `setXmlAsString` oder `setXmlData` müssen gültige, nicht leere XML‑Daten übergeben werden. Verwenden Sie die eine oder die andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Zeichenketten oder Binärdaten arbeitet.

### **Ein benutzerdefiniertes XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#remove--) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) entfernt ein bestimmtes Teil aus einer Sammlung benutzerdefinierter XML‑Teile.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) entfernt das Teil an einem angegebenen Sammlungs‑Index.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt ein präsentationsweites benutzerdefiniertes XML‑Teil per Referenz:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wenn Sie bereits ein `ICustomXmlPart` besitzen und dieses Teil aus der gesamten Präsentation entfernen möchten, rufen Sie `customXmlPart.remove()` auf.

Sie können ein Element auch nach Index entfernen:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Alle benutzerdefinierten XML‑Teile aus einer Sammlung leeren**

Verwenden Sie `clear`, wenn alle benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind, entfernt werden sollen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` wirkt nur auf die ausgewählte Sammlung. Das Leeren der Folien‑Sammlung löscht beispielsweise nicht die präsentationsweiten oder form‑spezifischen Sammlungen.

Um jedes benutzerdefinierte XML‑Teil in der Präsentation zu entfernen, iterieren Sie über `getAllCustomXmlParts()` und entfernen jedes Teil:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Verknüpfte oder gemeinsam genutzte benutzerdefinierte XML‑Teile behandeln**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine bestehende Datei Beziehungen von mehreren Folien oder Formen zu demselben zugrunde liegenden XML‑Teil enthalten.

Ein gemeinsam genutztes Teil sollte als ein Datenobjekt mit mehreren Verweisen behandelt werden:

- Das Aktualisieren mit `setXmlAsString`, `setXmlData` oder `setItemId` ändert das zugrunde liegende XML‑Teil, sodass die Änderung überall wirksam wird, wo das Teil referenziert wird.
- `getItemId()` kann verwendet werden, um dasselbe benutzerdefinierte XML‑Teil beim Prüfen von Objektsammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer konkreten `getCustomXmlParts()`‑Sammlung entfernt es nur aus dieser Sammlung. Verwenden Sie `ICustomXmlPart.remove()` wenn das Teil selbst aus der gesamten Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten Sie die Objektsammlungen prüfen, um festzustellen, ob andere Folien oder Formen noch darauf verweisen.

Die `add`‑Überladungen erzeugen ein neues benutzerdefiniertes XML‑Teil aus XML‑Inhalt; sie akzeptieren kein vorhandenes `ICustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen meist beim Laden von Präsentationen auf, die diese bereits enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Form‑Sammlungen nach `ItemId` und meldet Teile, die an mehr als einer Stelle referenziert werden:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Eine solche Prüfung ist vor dem Ändern oder Löschen benutzerdefinierter XML‑Daten in von externen Systemen erstellten Präsentationen sinnvoll, weil dasselbe Metadaten‑Teil an mehreren Beziehungen beteiligt sein kann.

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Methode `IDocumentProperties.getKeywords()`. Dieser Beispielcode zeigt, wie Sie mit Aspose.Slides für Android via Java den Wert eines Tags einer [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) erhalten:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispielsweise können Sie für nordamerikanische Länder ein Tag „NorthAmerican“ erstellen und das jeweilige Land als Wert zuweisen.

Der folgende Beispielcode zeigt, wie Sie einer [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) über Aspose.Slides für Android via Java ein Tag hinzufügen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlide) gesetzt werden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/IAutoShape):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **Einschränkungen**

Tags, die über die `getCustomData().getTags()`‑Sammlung hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Umgehung**: Sie können einen benutzerdefinierten Bezeichner im **Alt‑Text** des Objekts speichern (z. B. `shape.setAlternativeText("MyId")`). Nach dem Export nach PDF kann der Alt‑Text in der PDF‑Tag‑Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [tag collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie [remove(name)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) auf der [tag collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die komplette Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [tag collection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Soll ich `getXmlAsString`/`setXmlAsString` oder `getXmlData`/`setXmlData` zum Aktualisieren eines benutzerdefinierten XML‑Teils verwenden?**

Verwenden Sie `getXmlAsString` und `setXmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `getXmlData` und `setXmlData`, wenn das XML bereits als Byte‑Array vorliegt oder eine binärorientierte Verarbeitung günstiger ist. Beide Darstellungen beziehen sich auf den XML‑Inhalt desselben benutzerdefinierten XML‑Teils.