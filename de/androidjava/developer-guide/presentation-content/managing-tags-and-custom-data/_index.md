---
title: Tags und benutzerdefinierte Daten in Präsentationen auf Android verwalten
linktitle: Tags und benutzerdefinierte Daten
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
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML‑Daten in PowerPoint‑Präsentationen mit Aspose.Slides für Android via Java verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑Zeichenkettenpaare, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads enthalten können.

Aspose.Slides stellt APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Formebene bereit. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokumenten‑Management‑Kennungen, Workflow‑Status, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten in einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien – Dateien mit der Endung `.pptx` – werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und die Beziehungen, die zum Speichern von Präsentationsinhalt und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die über Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, wie sie in ISO/IEC 29500 definiert sind.

Benutzerdefinierte Daten können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ITagCollection)) oder benutzerdefinierte XML‑Teile ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection)) gespeichert werden. Beide sind über das [`ICustomData`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomData/)‑Interface verfügbar.

{{% alert color="primary" %}}

Tags speichern einfache Zeichenketten‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.

{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Methode [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) gibt die Sammlung benutzerdefinierter XML‑Teile zurück, die einem bestimmten Präsentationsobjekt zugeordnet sind. Beispiele:

- `presentation.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit der Präsentation selbst verknüpft sind.
- `slide.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Folie verknüpft sind.
- `shape.getCustomData().getCustomXmlParts()` enthält benutzerdefinierte XML‑Teile, die mit einer bestimmten Form verknüpft sind.

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) wenn Sie alle benutzerdefinierten XML‑Teile der Präsentation prüfen möchten, unabhängig davon, wo sie zugeordnet sind.

### **Einen benutzerdefinierten XML‑Teil zu einer Präsentation hinzufügen**

Verwenden Sie [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) um XML‑Daten zu einer benutzerdefinierten XML‑Teilsammlung hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur Präsentationsebene‑Sammlung hinzu:

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

    // add weist automatisch einen Bezeichner zu. Setze eine bestimmte UUID nur bei Bedarf.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Die `add`‑Methode kann XML auch als Byte‑Array oder Eingabestream akzeptieren, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Einen benutzerdefinierten XML‑Teil zu einer Folie oder Form hinzufügen**

Benutzerdefinierte XML‑Daten können einer bestimmten Folie oder Form zugeordnet werden, anstatt der gesamten Präsentation. Das ist sinnvoll, wenn Metadaten nur ein Objekt beschreiben, z. B. einen Vorlagen‑Schlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einen benutzerdefinierten XML‑Teil zu einer Folie und einen weiteren zu einer Form hinzu:

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

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `getCustomData().getCustomXmlParts()`‑Sammlung die Beziehung zu diesem Teil enthält. Präsentationsebene ist geeignet für dokumentweite Metadaten, Folienebene für Informationen, die zu einer bestimmten Folie gehören, und Formebene für Metadaten, die an einer einzelnen Form hängen.

### **Alle benutzerdefinierten XML‑Teile auflisten und prüfen**

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) um alle benutzerdefinierten XML‑Teile einer Präsentation abzurufen. Jeder [`ICustomXmlPart`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart/) liefert seine Kennung, den XML‑Inhalt und zugehörige Namespace‑Schemas.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile samt ihrer Namespace‑Schemas auf:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) gibt die XML‑Schemas zurück, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen nützlich sein, die XML von externen Systemen enthalten.

### **XML‑Inhalt und ItemId lesen und aktualisieren**

Verwenden Sie [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) und [`setXmlAsString()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) um mit XML als UTF‑8‑Zeichenkette zu arbeiten, oder [`getXmlData()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) und [`setXmlData()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) um mit den rohen XML‑Bytes zu arbeiten.

Die Methode [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) liefert die UUID, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Verwenden Sie [`setItemId()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-), wenn eine Integration eine neue Kennung benötigt.

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

    // Ersetze den Bezeichner, wenn die Integration dies erfordert.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Beim Aufruf von `setXmlAsString` oder `setXmlData` muss gültiges, nicht leeres XML übergeben werden. Nutzen Sie die eine oder die andere Darstellung, je nachdem, ob die Anwendung hauptsächlich mit Zeichenketten oder Binärdaten arbeitet.

### **Einen benutzerdefinierten XML‑Teil entfernen**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPart#remove--) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) entfernt einen spezifischen Teil aus einer benutzerdefinierten XML‑Teilsammlung.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen präsentationsweiten benutzerdefinierten XML‑Teil per Referenz:

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

Ein Element kann auch über den Index entfernt werden:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **Alle benutzerdefinierten XML‑Teile einer Sammlung leeren**

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

`clear` wirkt nur auf die ausgewählte Sammlung. Das Leeren der Sammlung einer Folie löscht beispielsweise nicht die Präsentations‑ oder Formebenen‑Sammlungen.

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

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Formen zu demselben zugrunde liegenden XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Verweisen behandelt werden:

- Das Aktualisieren mit `setXmlAsString`, `setXmlData` oder `setItemId` ändert den zugrunde liegenden XML‑Teil, sodass die Änderung überall wirksam wird, wo der Teil referenziert wird.
- `getItemId()` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil beim Prüfen von Objektsammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten `getCustomXmlParts()`‑Sammlung entfernt ihn nur aus dieser Sammlung. Verwenden Sie `ICustomXmlPart.remove()`, wenn der Teil selbst aus der gesamten Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten Sie die Objektsammlungen prüfen, um festzustellen, ob andere Folien oder Formen ihn noch referenzieren.

Die `add`‑Überladungen erzeugen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bereits bestehenden `ICustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen meist beim Laden von Präsentationen auf, die bereits solche Beziehungen enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Formebenen‑Sammlungen nach `ItemId` und meldet Teile, die von mehr als einem Ort referenziert werden:

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

Eine solche Prüfung ist vor der Modifizierung oder dem Löschen benutzerdefinierter XML‑Daten in von externen Systemen erstellten Präsentationen sinnvoll, weil derselbe Metadaten‑Teil an mehreren Beziehungen beteiligt sein kann.

## **Tag‑Werte abrufen**

In Slides entspricht ein Tag der Methode `IDocumentProperties.getKeywords()`. Dieser Beispielcode zeigt, wie ein Tag‑Wert mit Aspose.Slides für Android via Java für [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) abgerufen wird:

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

Wenn Sie Präsentationen anhand einer bestimmten Regel oder Eigenschaft klassifizieren müssen, können Sie dafür Tags hinzufügen. Beispiel: Möchten Sie Präsentationen aus nordamerikanischen Ländern kategorisieren, können Sie ein „NorthAmerican“‑Tag erstellen und das entsprechende Land als Wert zuweisen.

Der folgende Beispielcode zeigt, wie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation) mit Aspose.Slides für Android via Java hinzugefügt wird:

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

Tags, die über die Sammlung `getCustomData().getTags()` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Folglich kann ein als Tag gespeicherter benutzerdefinierter Bezeichner nicht aus dem getaggten PDF ausgelesen werden.

**Workaround**: Sie können einen benutzerdefinierten Bezeichner im **Alt‑Text** des Objekts speichern (z. B. `shape.setAlternativeText("MyId")`). Nach dem Export nach PDF kann der Alt‑Text im PDF‑Tag‑Baum erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Vorgang entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/) unterstützt die [clear](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#clear--)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag anhand seines Namens, ohne die gesamte Sammlung zu iterieren?**

Verwenden Sie [remove(name)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die vollständige Liste der Tag‑Namen für Analysen oder Filterungen abrufen?**

Verwenden Sie [getNamesOfTags](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tagcollection/); sie gibt ein Array aller Tag‑Namen zurück.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Soll ich `getXmlAsString`/`setXmlAsString` oder `getXmlData`/`setXmlData` verwenden, um einen benutzerdefinierten XML‑Teil zu aktualisieren?**

Verwenden Sie `getXmlAsString` und `setXmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `getXmlData` und `setXmlData`, wenn das XML bereits als Byte‑Array vorliegt oder eine binärorientierte Verarbeitung praktischer ist. Beide Darstellungen beziehen sich auf den XML‑Inhalt desselben benutzerdefinierten XML‑Teils.