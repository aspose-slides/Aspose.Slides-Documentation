---
title: Tags und benutzerdefinierte Daten in Präsentationen mit .NET verwalten
linktitle: Tags und benutzerdefinierte Daten
type: docs
weight: 300
url: /de/net/managing-tags-and-custom-data/
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
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Tags und benutzerdefinierte XML-Daten in PowerPoint-Präsentationen mit Aspose.Slides für .NET verwalten, einschließlich Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML-Teile."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides mit Tags und benutzerdefinierten Daten in PowerPoint‑Präsentationen arbeitet. Präsentationsspezifische Daten können als Tags oder benutzerdefinierte XML‑Teile gespeichert werden. Tags sind einfache Schlüssel‑Wert‑String‑Paare, während benutzerdefinierte XML‑Teile strukturierte Metadaten und anwendungsspezifische XML‑Payloads speichern können.

Aspose.Slides bietet APIs zum Hinzufügen, Lesen, Aktualisieren, Prüfen und Entfernen benutzerdefinierter XML‑Teile auf Präsentations‑, Folien‑ und Form‑Ebene. Benutzerdefinierte XML‑Teile sind nützlich für Integrationen, die Informationen wie Dokument‑Management‑Kennungen, Workflow‑Zustand, Compliance‑Metadaten, Vorlagen‑Bindungsdaten oder andere strukturierte Anwendungsdaten innerhalb einer Präsentation speichern.

## **Datenspeicherung in Präsentationsdateien**

PPTX‑Dateien — Dateien mit der Endung `.pptx` — werden im PresentationML‑Format gespeichert, das Teil der Office Open XML‑Spezifikation ist. Office Open XML definiert die Paketstruktur und Beziehungen, die zum Speichern von Präsentationsinhalt und zugehörigen Daten verwendet werden.

Eine Präsentation enthält mehrere Teile, die durch Beziehungen verbunden sind. Beispielsweise enthält ein Folienteil den Inhalt einer einzelnen Folie und kann explizite Beziehungen zu anderen Teilen haben, wie in ISO/IEC 29500 definiert.

Benutzerdefinierte Daten können als Tags ([ITagCollection](https://reference.aspose.com/slides/de/net/aspose.slides/itagcollection)) oder benutzerdefinierte XML‑Teile ([ICustomXmlPartCollection](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection)) gespeichert werden. Beide sind über die [`ICustomData`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomdata/)‑Schnittstelle verfügbar.

{{% alert color="info" %}}

Tags speichern einfache String‑Schlüssel‑Wert‑Paare. Benutzerdefinierte XML‑Teile speichern strukturierte XML‑Daten und können einer Präsentation, Folie oder Form zugeordnet werden.

{{% /alert %}}

## **Arbeiten mit benutzerdefinierten XML‑Teilen**

Die Eigenschaft [`ICustomData.CustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomdata/customxmlparts/) liefert die Sammlung benutzerdefinierter XML‑Teile, die mit einem bestimmten Präsentationsobjekt verknüpft sind. Beispiele:

- `presentation.CustomData.CustomXmlParts` enthält benutzerdefinierte XML‑Teile, die der Präsentation selbst zugeordnet sind.
- `slide.CustomData.CustomXmlParts` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Folie zugeordnet sind.
- `shape.CustomData.CustomXmlParts` enthält benutzerdefinierte XML‑Teile, die einer bestimmten Form zugeordnet sind.

Verwenden Sie [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/allcustomxmlparts/), wenn Sie alle benutzerdefinierten XML‑Teile in der Präsentation prüfen möchten, unabhängig davon, wo sie verknüpft sind.

### **Hinzufügen eines benutzerdefinierten XML‑Teils zu einer Präsentation**

Verwenden Sie [`ICustomXmlPartCollection.Add`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/add/), um XML‑Daten zu einer benutzerdefinierten XML‑Teilsammlung hinzuzufügen. Das XML muss gültig und nicht leer sein.

Das folgende Beispiel fügt strukturierte Metadaten zur präsentationsweiten benutzerdefinierten Datensammlung hinzu:

```csharp
using System;
using Aspose.Slides;

var customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

using var presentation = new Presentation();
var customXmlPart = presentation.CustomData.CustomXmlParts.Add(customXmlContent);

// Add weist automatisch einen Bezeichner zu. Setzen Sie nur dann eine bestimmte GUID, wenn dies erforderlich ist.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
```

Die `Add`‑Methode kann XML auch als Byte‑Array oder Stream entgegennehmen, was nützlich ist, wenn XML‑Inhalt bereits in binärer Form vorliegt.

### **Hinzufügen eines benutzerdefinierten XML‑Teils zu einer Folie oder Form**

Benutzerdefinierte XML‑Daten können stattdessen einer bestimmten Folie oder Form zugeordnet werden. Das ist sinnvoll, wenn Metadaten nur ein einzelnes Objekt beschreiben, z. B. einen Vorlagenschlüssel, eine externe Datensatz‑Kennung oder Bindungsinformationen.

Das folgende Beispiel fügt einen benutzerdefinierten XML‑Teil zu einer Folie und einen weiteren zu einer Form hinzu:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.CustomData.CustomXmlParts.Add(
    "<slideMetadata xmlns=\"urn:example:slides\">" +
        "<templateKey>TitleSlide</templateKey>" +
    "</slideMetadata>");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

shape.TextFrame.Text = "Customer data";
shape.CustomData.CustomXmlParts.Add(
    "<shapeMetadata xmlns=\"urn:example:shapes\">" +
        "<recordId>CRM-4281</recordId>" +
    "</shapeMetadata>");

presentation.Save("object_custom_xml.pptx", SaveFormat.Pptx);
```

Die Ebene, auf der ein Teil hinzugefügt wird, bestimmt, welche `CustomData.CustomXmlParts`‑Sammlung die Beziehung zu diesem Teil enthält. Präsentationsweite Daten eignen sich für dokumentübergreifende Metadaten, Folien‑Daten für Informationen, die zu einer bestimmten Folie gehören, und Form‑Daten für Metadaten, die an einer einzelnen Form hängen.

### **Auflisten und Prüfen aller benutzerdefinierten XML‑Teile**

Verwenden Sie [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile aus einer Präsentation abzurufen. Jeder [`ICustomXmlPart`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/) stellt seine Kennung, den XML‑Inhalt und zugehörige Namespace‑Schemata bereit.

Das folgende Beispiel listet alle benutzerdefinierten XML‑Teile und deren Namespace‑Schemata auf:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    Console.WriteLine("ItemId: " + customXmlPart.ItemId);
    Console.WriteLine("XML:");
    Console.WriteLine(customXmlPart.XmlAsString);

    foreach (var namespaceSchema in customXmlPart.NamespaceSchemas)
    {
        Console.WriteLine("Namespace schema: " + namespaceSchema);
    }

    Console.WriteLine();
}
```

[`ICustomXmlPart.NamespaceSchemas`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/namespaceschemas/) gibt die XML‑Schemata zurück, die dem benutzerdefinierten XML‑Teil zugeordnet sind. Diese Information kann beim Prüfen von Präsentationen hilfreich sein, die XML von externen Systemen enthalten.

### **Lesen und Aktualisieren von XML‑Inhalt und ItemId**

Verwenden Sie [`ICustomXmlPart.XmlAsString`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/xmlasstring/) zur Arbeit mit XML als UTF‑8‑String oder [`ICustomXmlPart.XmlData`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/xmldata/) für die rohen XML‑Bytes. Beide Eigenschaften können gelesen und aktualisiert werden.

Die Eigenschaft [`ICustomXmlPart.ItemId`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/itemid/) enthält die GUID, die den benutzerdefinierten XML‑Teil im Office Open XML‑Dokument identifiziert. Sie kann ebenfalls geändert werden, wenn eine Integration eine neue Kennung erfordert.

Das folgende Beispiel aktualisiert den XML‑Inhalt und die Kennung:

```csharp
using System;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlPart = presentation.AllCustomXmlParts[0];

// Lese das aktuelle XML als Text.
var currentXmlContent = customXmlPart.XmlAsString;
Console.WriteLine(currentXmlContent);

// Aktualisiere das XML als UTF-8-String.
customXmlPart.XmlAsString =
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Approved</workflowState>" +
    "</metadata>";

// XmlData liefert denselben XML-Inhalt als Rohbytes.
var customXmlData = customXmlPart.XmlData;
Console.WriteLine(Encoding.UTF8.GetString(customXmlData));

// Ersetze die Kennung, wenn dies von der Integration benötigt wird.
customXmlPart.ItemId = Guid.NewGuid();

presentation.Save("updated_custom_xml.pptx", SaveFormat.Pptx);
```

Beim Zuweisen von `XmlAsString` oder `XmlData` stellen Sie gültiges, nicht leeres XML bereit. Verwenden Sie die eine oder andere Darstellung je nach dem, ob die Anwendung hauptsächlich mit Strings oder mit Byte‑Daten arbeitet.

### **Entfernen eines benutzerdefinierten XML‑Teils**

Aspose.Slides bietet mehrere Möglichkeiten, benutzerdefinierte XML‑Daten zu entfernen:

- [`ICustomXmlPart.Remove`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpart/remove/) entfernt den benutzerdefinierten XML‑Teil aus der Präsentation.
- [`ICustomXmlPartCollection.Remove`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/remove/) entfernt einen bestimmten Teil aus einer benutzerdefinierten XML‑Teilsammlung.
- [`ICustomXmlPartCollection.RemoveAt`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/removeat/) entfernt den Teil an einem angegebenen Sammlungs‑Index.
- [`ICustomXmlPartCollection.Clear`](https://reference.aspose.com/slides/de/net/aspose.slides/icustomxmlpartcollection/clear/) entfernt alle Teile aus einer bestimmten Sammlung.

Das folgende Beispiel entfernt einen präsentationsweiten benutzerdefinierten XML‑Teil per Referenz:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var customXmlParts = presentation.CustomData.CustomXmlParts;

if (customXmlParts.Count > 0)
{
    var customXmlPart = customXmlParts[0];
    customXmlParts.Remove(customXmlPart);
}

presentation.Save("custom_xml_removed.pptx", SaveFormat.Pptx);
```

Haben Sie bereits ein `ICustomXmlPart` und möchten diesen Teil aus der Präsentation entfernen, rufen Sie `customXmlPart.Remove()` auf, anstatt eine bestimmte Sammlung anzusprechen.

Sie können ein Element auch nach Index entfernen:

```csharp
presentation.CustomData.CustomXmlParts.RemoveAt(0);
```

### **Alle benutzerdefinierten XML‑Teile einer Sammlung löschen**

Verwenden Sie `Clear`, wenn alle benutzerdefinierten XML‑Teile, die einem bestimmten Präsentationsobjekt zugeordnet sind, entfernt werden sollen.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
presentation.Slides[0].CustomData.CustomXmlParts.Clear();

presentation.Save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
```

`Clear` wirkt nur auf die ausgewählte Sammlung. Das Löschen der Sammlung einer Folie löscht beispielsweise nicht die präsentationsweiten oder form‑spezifischen Sammlungen.

Um jeden benutzerdefinierten XML‑Teil in der Präsentation zu entfernen, iterieren Sie über `AllCustomXmlParts` und entfernen jeden Teil:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var customXmlPart in presentation.AllCustomXmlParts)
{
    customXmlPart.Remove();
}

presentation.Save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
```

### **Umgang mit verknüpften oder gemeinsam genutzten benutzerdefinierten XML‑Teilen**

In einer Office Open XML‑Präsentation kann derselbe benutzerdefinierte XML‑Teil von mehr als einem Präsentationsobjekt referenziert werden. Beispielsweise kann eine vorhandene Datei Beziehungen von mehreren Folien oder Formen zu demselben zugrunde liegenden XML‑Teil enthalten.

Ein gemeinsam genutzter Teil sollte als ein Datenobjekt mit mehreren Referenzen behandelt werden:

- Das Aktualisieren von `XmlAsString`, `XmlData` oder `ItemId` ändert den zugrunde liegenden XML‑Teil, sodass die Änderung überall wirksam wird, wo dieser Teil referenziert wird.
- `ItemId` kann verwendet werden, um denselben benutzerdefinierten XML‑Teil beim Prüfen objektbezogener Sammlungen zu identifizieren.
- Das Entfernen eines Teils aus einer bestimmten `CustomXmlParts`‑Sammlung entfernt ihn nur aus dieser Sammlung. Verwenden Sie `ICustomXmlPart.Remove()`, wenn der Teil selbst aus der Präsentation entfernt werden soll.
- Vor dem Löschen oder Ersetzen eines gemeinsam genutzten Teils sollten Sie die objektbezogenen Sammlungen prüfen, um festzustellen, ob andere Folien oder Formen noch darauf verweisen.

Die `Add`‑Überladungen erzeugen einen neuen benutzerdefinierten XML‑Teil aus XML‑Inhalt; sie akzeptieren keinen bestehenden `ICustomXmlPart`. Daher treten gemeinsam genutzte Beziehungen am häufigsten beim Laden von Präsentationen auf, die diese bereits enthalten.

Das folgende Beispiel prüft Präsentations‑, Folien‑ und Form‑Sammlungen nach `ItemId` und meldet Teile, die von mehr als einer Stelle referenziert werden:

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var referencesByItemId = new Dictionary<Guid, List<string>>();

var registerCustomXmlParts = (string ownerName, ICustomXmlPartCollection customXmlParts) =>
    {
        foreach (var customXmlPart in customXmlParts)
        {
            if (!referencesByItemId.ContainsKey(customXmlPart.ItemId))
            {
                referencesByItemId[customXmlPart.ItemId] = new List<string>();
            }

            referencesByItemId[customXmlPart.ItemId].Add(ownerName);
        }
    };

registerCustomXmlParts("Presentation", presentation.CustomData.CustomXmlParts);

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    registerCustomXmlParts("Slide " + (slideIndex + 1), slide.CustomData.CustomXmlParts);

    for (var shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.CustomData.CustomXmlParts);
    }
}

foreach (var referenceEntry in referencesByItemId)
{
    if (referenceEntry.Value.Count > 1)
    {
        Console.WriteLine("Shared custom XML part: " + referenceEntry.Key);

        foreach (var ownerName in referenceEntry.Value)
        {
            Console.WriteLine("  Referenced by: " + ownerName);
        }
    }
}
```

Eine solche Prüfung ist vor dem Ändern oder Löschen benutzerdefinierter XML‑Daten in von externen Systemen erstellten Präsentationen nützlich, weil derselbe Metadaten‑Teil an mehreren Beziehungen beteiligt sein kann.

## **Werte von Tags abrufen**

In Slides entspricht ein Tag der Eigenschaft `IDocumentProperties.Keywords`. Dieser Beispielcode zeigt, wie man mit Aspose.Slides für .NET den Wert eines Tags einer [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) abruft:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var keywords = presentation.DocumentProperties.Keywords;
```

## **Tags zu Präsentationen hinzufügen**

Aspose.Slides ermöglicht das Hinzufügen von Tags zu Präsentationen. Ein Tag besteht typischerweise aus zwei Elementen:

- dem Namen einer benutzerdefinierten Eigenschaft, z. B. `MyTag`;
- dem Wert der benutzerdefinierten Eigenschaft, z. B. `My Tag Value`.

Wenn Sie Präsentationen nach einer bestimmten Regel oder Eigenschaft klassifizieren möchten, können Sie dafür Tags hinzufügen. Beispiel: Möchten Sie Präsentationen aus nordamerikanischen Ländern kategorisieren, erstellen Sie ein „North America“‑Tag und setzen das jeweilige Land als dessen Wert.

Der folgende Beispielcode zeigt, wie ein Tag zu einer [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation) mit Aspose.Slides für .NET hinzugefügt wird:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var tags = presentation.CustomData.Tags;
tags["MyTag"] = "My Tag Value";
```

Tags können auch für eine [Slide](https://reference.aspose.com/slides/de/net/aspose.slides/slide) gesetzt werden:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
slide.CustomData.Tags["tag"] = "value";
```

Oder für eine einzelne [Shape](https://reference.aspose.com/slides/de/net/aspose.slides/shape):

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
shape.TextFrame.Text = "My text";
shape.CustomData.Tags["tag"] = "value";
```

### **Einschränkungen**

Tags, die über die Sammlung `CustomData.Tags` hinzugefügt werden, werden nur in der PowerPoint‑Datei gespeichert. Sie werden **nicht** in die PDF‑Tag‑Struktur übertragen, wenn die Präsentation nach PDF exportiert wird. Daher kann ein als Tag gespeicherter benutzerdefinierter Bezeichner nicht aus dem getaggten PDF abgerufen werden.

**Workaround**: Sie können einen benutzerdefinierten Bezeichner im **Alt‑Text** des Objekts speichern (z. B. `shape.AlternativeText = "MyId"`). Nach dem Export nach PDF kann der Alt‑Text im PDF‑Tag‑Baum erscheinen.

## **FAQ**

**Kann ich alle Tags einer Präsentation, Folie oder Form in einem Schritt entfernen?**

Ja. Die [Tag‑Sammlung](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/) unterstützt die [Clear](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/clear/)‑Operation, die alle Schlüssel‑Wert‑Paare auf einmal löscht.

**Wie lösche ich ein einzelnes Tag nach seinem Namen, ohne die gesamte Sammlung zu durchlaufen?**

Verwenden Sie `Remove(name)` auf der [TagCollection](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/), um das Tag anhand seines Schlüssels zu entfernen.

**Wie kann ich die komplette Liste der Tag‑Namen für Analysen oder Filter abrufen?**

Verwenden Sie `GetNamesOfTags` auf der [Tag‑Sammlung](https://reference.aspose.com/slides/de/net/aspose.slides/tagcollection/); sie liefert ein Array aller Tag‑Namen.

**Wie finde ich alle benutzerdefinierten XML‑Teile, unabhängig davon, wo sie gespeichert sind?**

Verwenden Sie [`Presentation.AllCustomXmlParts`](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/allcustomxmlparts/), um alle benutzerdefinierten XML‑Teile in der Präsentation abzurufen.

**Soll ich `XmlAsString` oder `XmlData` verwenden, um einen benutzerdefinierten XML‑Teil zu aktualisieren?**

Verwenden Sie `XmlAsString`, wenn die Anwendung mit UTF‑8‑XML‑Text arbeitet. Verwenden Sie `XmlData`, wenn das XML bereits als Byte‑Array vorliegt oder eine binär‑orientierte Verarbeitung praktischer ist. Beide Eigenschaften repräsentieren denselben XML‑Inhalt des benutzerdefinierten XML‑Teils.