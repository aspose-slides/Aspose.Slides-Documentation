---
title: Verwalten von Tags und benutzerdefinierten Daten in Präsentationen mit Java
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/java/managing-tags-and-custom-data/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für Java verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint-Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML-Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑String‑Paare, während benutzerdefinierte XML-Teile strukturierte Metadaten und anwendungsspezifische XML-Payloads speichern können.

Aspose.Slides bietet APIs zum Hinzufügen, Lesen, Aktualisieren, Überprüfen und Entfernen benutzerdefinierter XML-Teile auf Präsentations‑, Folien‑ und Form‑Ebene. Benutzerdefinierte XML-Teile sind nützlich für Integrationen, die Informationen wie Dokument-Management-Kennungen, Workflow-Status, Compliance-Metadaten, Vorlagen-Bindungsdaten oder andere strukturierte Anwendungsdaten in einer Präsentation speichern.

## **Datenablage in Präsentationsdateien**

PPTX-Dateien – Dateien mit der Endung `.pptx` – werden im PresentationML-Format gespeichert, das Teil der Office-Open-XML-Spezifikation ist. Office Open XML definiert die Paketstruktur und Beziehungen, die zur Speicherung von Präsentationsinhalten und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, die durch ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ITagCollection)) oder benutzerdefinierte XML-Teile ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPartCollection)) gespeichert werden. Beide sind über die [`ICustomData`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomData/) Schnittstelle verfügbar.

{{% alert color="info" %}}
Tags speichern einfache Zeichenketten‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML-Teile speichern strukturierte XML-Daten und können mit einer Präsentation, Folie oder Form verknüpft werden.
{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Methode [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomData#getCustomXmlParts--) gibt die Sammlung benutzerdefinierter XML‑Teile zurück, die mit einem bestimmten Präsentationsobjekt verknüpft sind. Beispiel:

- `presentation.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit der Präsentation selbst verknüpft sind.
- `slide.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Folie verknüpft sind.
- `shape.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Form verknüpft sind.

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getAllCustomXmlParts--), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen müssen, unabhängig davon, wo sie verknüpft sind.

### **Ein benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-), um XML‑Daten zu einer benutzerdefinierten XML‑Teil‑Sammlung hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur benutzerdefinierten Datensammlung auf Präsentationsebene hinzu:

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

    // add weist automatisch einen Bezeichner zu. Setzen Sie bei Bedarf eine spezifische UUID.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die Methode `add` kann XML auch als Byte‑Array oder Eingabestream akzeptieren, was nützlich ist, wenn XML‑Inhalte bereits in binärer Form vorliegen.

### **Ein benutzerdefinierten XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können mit einer bestimmten Folie oder Form verknüpft werden, anstatt mit der gesamten Präsentation. Das ist nützlich, wenn Metadaten nur ein Objekt beschreiben, z. B. einen Vorlagenschlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einer Folie einen benutzerdefinierten XML‑Teil und einer Form einen weiteren hinzu:

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

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `getCustomData().getCustomXmlParts()`‑Sammlung des Objekts die Beziehung zu diesem Teil enthält. Daten auf Präsentationsebene eignen sich für dokumentweite Metadaten, Daten auf Folienebene für Informationen, die zu einer bestimmten Folie gehören, und Daten auf Formebene für Metadaten, die an eine einzelne Form gebunden sind.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getAllCustomXmlParts--), um alle benutzerdefinierten XML‑Teile einer Präsentation abzurufen. Jeder [`ICustomXmlPart`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPart/) stellt seine Kennung, den XML-Inhalt und zugehörige Namespace-Schemas bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und deren Namespace-Schemas auf:

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

`ICustomXmlPart.getNamespaceSchemas()` liefert die XML-Schemas, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen, die XML von externen Systemen enthalten, nützlich sein.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) und [`setXmlAsString()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-), um mit XML als UTF-8-String zu arbeiten, oder [`getXmlData()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPart#getXmlData--) und [`setXmlData()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-), um mit den rohen XML-Bytes zu arbeiten.

`ICustomXmlPart.getItemId()` gibt die UUID zurück, die den benutzerdefinierten XML‑Teil im Office-Open-XML-Dokument identifiziert. Verwenden Sie [`setItemId()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-), wenn eine Integration einen neuen Bezeichner benötigt.

Das folgende Beispiel aktualisiert den XML-Inhalt und die Kennung:

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

    // Aktualisiere das XML als UTF-8-String.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData liefert denselben XML-Inhalt als Rohbytes.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // Ersetze die Kennung, wenn die Integration es erfordert.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Beim Aufruf von `setXmlAsString` oder `setXmlData` müssen Sie gültiges, nicht leeres XML bereitstellen. Verwenden Sie die eine oder andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Zeichenketten oder Byte-Daten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML-Daten zu entfernen:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPart#remove--) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) entfernt einen bestimmten Teil aus einer benutzerdefinierten XML‑Teil-Sammlung.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) entfernt den Teil an einem angegebenen Sammlungsindex.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/de/java/com.aspose.slides/ICustomXmlPartCollection#clear--) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen benutzerdefinierten XML‑Teil auf Präsentationsebene anhand einer Referenz:

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

Wenn Sie bereits ein `ICustomXmlPart` besitzen und diesen Teil aus der Präsentation entfernen möchten, anstatt eine bestimmte Sammlung anzusprechen, rufen Sie `customXmlPart.remove()` auf.

Sie können ein Element auch nach Index entfernen:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Alle benutzerdefinierten XML‑Teile aus einer Sammlung leeren**

Verwenden Sie `clear`, wenn alle mit einem bestimmten Präsentationsobjekt verknüpften benutzerdefinierten XML‑Teile entfernt werden sollen.

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

`clear` wirkt sich nur auf die ausgewählte Sammlung aus. Das Leeren der Sammlung einer Folie löscht beispielsweise nicht die Sammlungen auf Präsentations- oder Formebene.

Um jeden benutzerdefinierten XML‑Teil in der Präsentation zu entfernen, iterieren Sie über `getAllCustomXmlParts()` und entfernen jeden Teil:

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

In einer Office-Open-XML-Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Formen zu demselben zugrunde liegenden benutzerdefinierten XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Referenzen behandelt werden:

- Das Aktualisieren mit `setXmlAsString`, `setXmlData` oder `setItemId` ändert den zugrunde liegenden benutzerdefinierten XML‑Teil, sodass die Änderung überall dort wirksam wird, wo der Teil referenziert wird.
- `getItemId()` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil beim Prüfen von Sammlungen auf Objektebene zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten `getCustomXmlParts()`‑Sammlung entfernt ihn aus dieser Sammlung. Verwenden Sie `ICustomXmlPart.remove()`, wenn der Teil selbst aus der Präsentation entfernt werden soll.
- Bevor ein gemeinsam genutzter Teil gelöscht oder ersetzt wird, sollten Sie die Sammlungen auf Objektebene prüfen, um festzustellen, ob andere Folien oder Formen ihn noch referenzieren.

Die `add`‑Überladungen erzeugen einen neuen benutzerdefinierten XML‑Teil aus XML-Inhalt; sie akzeptieren keinen bestehenden `ICustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen am häufigsten beim Laden von Präsentationen auf, die diese bereits enthalten.

Das folgende Beispiel prüft die Sammlungen auf Präsentations-, Folien- und Formebene anhand von `ItemId` und meldet Teile, die an mehr als einer Stelle referenziert werden:

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

Eine solche Prüfung ist vor dem Ändern oder Löschen benutzerdefinierter XML-Daten in von externen Systemen erstellten Präsentationen nützlich, da derselbe Metadaten‑Teil an mehr als einer Beziehung beteiligt sein kann.

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Methode `IDocumentProperties.getKeywords()`. Dieser Beispielcode zeigt, wie man mit Aspose.Slides für Java einen Tag‑Wert für eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) abruft:

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

- der Name einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- der Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie Tags dafür hinzufügen. Beispielsweise können Sie, wenn Sie Präsentationen aus nordamerikanischen Ländern kategorisieren wollen, einen nordamerikanischen Tag erstellen und das entsprechende Land als Wert zuweisen.

Dieser Beispielcode zeigt, wie man mit Aspose.Slides für Java einen Tag zu einer [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation) hinzufügt:

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

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/java/com.aspose.slides/ISlide) festgelegt werden:

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

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/IAutoShape):

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

Tags, die über die Sammlung `getCustomData().getTags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übernommen, wenn die Präsentation nach PDF exportiert wird. Folglich kann ein als Tag zugewiesener benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Bezeichner im **Alt-Text** des Objekts speichern (z. B. `shape.setAlternativeText("MyId")`). Nach dem Export nach PDF kann der Alt-Text in der PDF-Tag-Struktur erscheinen.

## **FAQ**

**Kann ich alle Tags aus einer Präsentation, Folie oder Form in einem Vorgang entfernen?**  
Ja. Die [tag collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/) unterstützt eine [clear](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie kann ich ein einzelnes Tag nach seinem Namen löschen, ohne die gesamte Sammlung zu durchlaufen?**  
Verwenden Sie [remove(name)](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) auf der [tag collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu löschen.

**Wie kann ich die komplette Liste der Tag-Namen für Analysen oder Filterung abrufen?**  
Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [tag collection](https://reference.aspose.com/slides/de/java/com.aspose.slides/tagcollection/); sie gibt ein Array aller Tag-Namen zurück.

**Wie kann ich alle benutzerdefinierten XML-Teile finden, unabhängig davon, wo sie gespeichert sind?**  
Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/java/com.aspose.slides/Presentation#getAllCustomXmlParts--), um alle benutzerdefinierten XML-Teile in der Präsentation abzurufen.

**Soll ich `getXmlAsString`/`setXmlAsString` oder `getXmlData`/`setXmlData` verwenden, um einen benutzerdefinierten XML-Teil zu aktualisieren?**  
Verwenden Sie `getXmlAsString` und `setXmlAsString`, wenn die Anwendung mit UTF-8-XML-Text arbeitet. Verwenden Sie `getXmlData` und `setXmlData`, wenn das XML bereits als Byte-Array vorliegt oder eine binärorientierte Verarbeitung bequemer ist. Beide Darstellungen beziehen sich auf den XML-Inhalt desselben benutzerdefinierten XML-Teils.